using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EPMLiveIntegration;
using RestSharp;
using UplandIntegrations.Infrastructure;
using UplandIntegrations.PowerSteering.Entities;

namespace UplandIntegrations.PowerSteering.Infrastructure
{
    internal abstract class ObjectManager : IObjectManager
    {
        #region Fields (6) 

        private const string ERROR_MESSAGE = "Could not process a request. Status: ({0}) {1}. Endpoint: [{2}] {3}";
        private readonly RestClient _client;
        private readonly string _fieldResource;
        private readonly RestClient _metadataClient;
        private readonly List<HttpStatusCode> _validStatuCodes;
        private List<Field> _fields;

        #endregion Fields 

        #region Constructors (1) 

        protected ObjectManager(RestClient client, string serviceUrl, string fieldResource)
        {
            _metadataClient = new RestClient
            {
                BaseUrl = client.BaseUrl + "/metadataservice/v1",
                Authenticator = client.Authenticator
            };

            _metadataClient.AddDefaultHeader("Accept", "application/xml, text/xml");

            client.BaseUrl += serviceUrl;
            _client = client;

            _fieldResource = fieldResource;

            _validStatuCodes = new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
                HttpStatusCode.Created,
                HttpStatusCode.NoContent
            };
        }

        #endregion Constructors 

        #region Properties (1) 

        protected abstract Dictionary<string, string> MappedColumns { get; }

        #endregion Properties 

        #region Methods (12) 

        // Protected Methods (8) 

        protected abstract void BuildObjects(DataTable items, List<string> columns, List<Entity> entities,
            List<Entity> list);

        protected IRestResponse Execute(IRestRequest request)
        {
            IRestResponse response = _client.Execute(request);

            if (_validStatuCodes.Contains(response.StatusCode))
            {
                return response;
            }

            if (!string.IsNullOrEmpty(response.ErrorMessage)) throw new Exception(response.ErrorMessage);

            throw new Exception(string.Format(ERROR_MESSAGE,
                (int) response.StatusCode, response.StatusDescription, request.Method,
                _client.BaseUrl + "/" + request.Resource));
        }

        protected T Execute<T>(IRestRequest request) where T : new()
        {
            IRestResponse<T> response = request.Resource.Equals(_fieldResource)
                ? _metadataClient.Execute<T>(request)
                : _client.Execute<T>(request);

            if (_validStatuCodes.Contains(response.StatusCode))
            {
                return response.Data;
            }

            if (!string.IsNullOrEmpty(response.ErrorMessage)) throw new Exception(response.ErrorMessage);

            throw new Exception(string.Format(ERROR_MESSAGE,
                (int) response.StatusCode, response.StatusDescription, request.Method,
                _client.BaseUrl + "/" + request.Resource));
        }

        protected void FillObjects(IEnumerable<string> columns, List<Entity> newObjects, List<Entity> existingObjects,
            Entity entity, DataRow row)
        {
            foreach (string column in from column in columns
                let col = column.ToLower()
                where !col.Equals("spid")
                select column)
            {
                Entity.Set(entity, GetValue(row, column), Entity.GetFieldName(column, GetFields()));
            }

            if (entity.Fields.ContainsKey("owner"))
            {
                try
                {
                    entity.Fields["owner"] = entity.Fields["owner"].Split(',')[0];
                }
                catch { }
            }

            entity.EPMLiveId = Convert.ToInt32(row["SPID"]);

            string id = null;

            try
            {
                id = entity.Fields["id"] ?? string.Empty;
            }
            catch { }

            if (!string.IsNullOrEmpty(id))
            {
                existingObjects.Add(entity);
            }
            else
            {
                newObjects.Add(entity);
            }
        }

        private static string GetValue(DataRow row, string column)
        {
            var value = (row[column] ?? string.Empty).ToString();

            if (string.IsNullOrEmpty(value) || !column.ToLower().Contains("date")) return value;

            try
            {
                value = DateTime.Parse(value).ToString("yyyy-MM-dd");
            }
            catch { }

            return value;
        }

        protected Entity FindById(string id, string resource)
        {
            if (string.IsNullOrEmpty(id)) return null;

            IRestResponse response = Execute(new RestRequest(resource + "/" + id));
            return Entity.Deserialize(response.Content, GetFields());
        }

        protected IEnumerable<Field> GetFields()
        {
            if (_fields != null) return _fields;

            _fields = Execute<List<Field>>(new RestRequest(_fieldResource));
            return _fields;
        }

        protected Entity Insert(Entity entity)
        {
            var request = new RestRequest(entity.ObjectKind.ToLower(), Method.POST) {RequestFormat = DataFormat.Xml};
            request.AddParameter("application/xml", entity.Serialize(GetFields()), ParameterType.RequestBody);
            request.AddParameter("Accept", "application/xml", ParameterType.HttpHeader);

            IRestResponse response = Execute(request);

            Entity result = Entity.Deserialize(response.Content, GetFields(), entity);
            result.EPMLiveId = entity.EPMLiveId;

            return result;
        }

        protected Entity Update(Entity entity)
        {
            var request = new RestRequest(entity.ObjectKind.ToLower(), Method.PUT) {RequestFormat = DataFormat.Xml};
            request.AddParameter("application/xml", entity.Serialize(GetFields()), ParameterType.RequestBody);
            request.AddParameter("Accept", "application/xml", ParameterType.HttpHeader);

            Execute(request);

            return entity;
        }

        // Private Methods (3) 

        private void Delete(string id)
        {
            var request = new RestRequest(_fieldResource.Split('/')[1] + "/" + id, Method.DELETE);
            Execute(request);
        }

        private Type GetColumnType(string type)
        {
            return type.Equals("date") ? typeof (DateTime) : typeof (string);
        }

        private string GetDefaultListColumn(Field field)
        {
            if (field.Name.Equals("name")) return "Title";

            return MappedColumns.ContainsKey(field.Name)
                ? MappedColumns[field.Name]
                : Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(field.Name);
        }

        // Internal Methods (1) 

        internal List<ColumnProperty> GetColumns(IEnumerable<Field> fields)
        {
            List<ColumnProperty> columnProperties = (from field in fields
                where !field.Name.Equals("id")
                orderby field.Name
                select new ColumnProperty
                {
                    ColumnName = field.Name,
                    DiplayName = field.DisplayName,
                    DefaultListColumn = GetDefaultListColumn(field),
                    type = GetColumnType(field.Type)
                }).ToList();

            columnProperties.Insert(0, new ColumnProperty
            {
                ColumnName = "id",
                DiplayName = "Id",
                type = typeof (string)
            });

            return columnProperties;
        }

        #endregion Methods 

        #region Implementation of IObjectManager

        public virtual IEnumerable<IntTransactionResult> DeleteItems(string[] itemIds, Guid integrationId)
        {
            IEnumerable<Task<IntTransactionResult>> tasks =
                itemIds.Select(id => Task<IntTransactionResult>.Factory.StartNew(() =>
                {
                    try
                    {
                        Delete(id);
                        return new IntTransactionResult(id, 0, null, TransactionType.DELETE);
                    }
                    catch (Exception exception)
                    {
                        return new IntTransactionResult(id, 0, null, TransactionType.DELETE, exception.Message);
                    }
                }));

            return tasks.Select(task => task.Result);
        }


        public virtual List<ColumnProperty> GetColumns()
        {
            return GetColumns(GetFields());
        }

        public virtual IEnumerable<IntObject> GetItems(string[] itemIds)
        {
            var tasks = new List<Task<IntObject>>();

            tasks.AddRange(itemIds.Select(id => Task<IntObject>.Factory.StartNew(() =>
            {
                try
                {
                    Entity entity = FindById(id, _fieldResource.Split('/')[1]);
                    return new IntObject(id, entity);
                }
                catch (Exception exception)
                {
                    return new IntObject(id, exception);
                }
            })));

            return tasks.Select(task => task.Result);
        }

        public virtual string TranslateIdToUserEmail(string userId)
        {
            return string.Empty;
        }

        public virtual IEnumerable<IntTransactionResult> UpsertItems(DataTable items, Guid integrationId)
        {
            List<string> columns = (from DataColumn column in items.Columns select column.ColumnName).ToList();

            var newEntities = new List<Entity>();
            var existingEntities = new List<Entity>();

            BuildObjects(items, columns, newEntities, existingEntities);

            var tasks = new List<Task<IntTransactionResult>>();

            tasks.AddRange(newEntities.Select(obj => Task<IntTransactionResult>.Factory.StartNew(() =>
            {
                string psId = string.Empty;
                int spId = obj.EPMLiveId;

                try
                {
                    Entity intObject = Insert(obj);
                    psId = intObject.Fields["id"];

                    return new IntTransactionResult(psId, spId, intObject, TransactionType.INSERT);
                }
                catch (Exception exception)
                {
                    exception = exception.InnerException ?? exception;
                    return new IntTransactionResult(psId, spId, null, TransactionType.INSERT,
                        exception.Message);
                }
            })));

            tasks.AddRange(existingEntities.Select(obj => Task<IntTransactionResult>.Factory.StartNew(() =>
            {
                string psId = string.Empty;
                int spId = obj.EPMLiveId;

                try
                {
                    Entity intObject = Update(obj);
                    psId = intObject.Fields["id"];

                    return new IntTransactionResult(psId, spId, intObject, TransactionType.UPDATE);
                }
                catch (Exception exception)
                {
                    exception = exception.InnerException ?? exception;
                    return new IntTransactionResult(psId, spId, null, TransactionType.UPDATE,
                        exception.Message);
                }
            })));

            return tasks.Select(task => task.Result);
        }

        #endregion
    }
}