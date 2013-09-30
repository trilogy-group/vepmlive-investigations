using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EPMLiveIntegration;
using UplandIntegrations.TenroxIntegrationService;
using UplandIntegrations.TenroxUserService;
using UserToken = UplandIntegrations.TenroxAuthService.UserToken;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal abstract class ObjectManager : IObjectManager
    {
        #region Fields (11) 

        protected readonly Binding Binding;
        protected readonly EndpointAddress EndpointAddress;
        protected readonly object Token;
        private readonly UserToken _authToken;
        private readonly Type _clientType;
        private readonly string _endpointAddress;
        private readonly Dictionary<string, Type> _objectFields;
        private readonly Type _objectType;
        private readonly TenroxUserService.UserToken _userToken;
        protected Dictionary<string, string> DisplayNameDict;
        protected Dictionary<string, string> MappingDict;

        #endregion Fields 

        #region Constructors (1) 

        protected ObjectManager(Binding binding, string endpointAddress, string svcUrl, UserToken token, Type objectType,
            Type tokenType, Type clientType)
        {
            DisplayNameDict = new Dictionary<string, string>();
            MappingDict = new Dictionary<string, string>();

            _authToken = token;
            _clientType = clientType;
            _objectFields = new Dictionary<string, Type>();
            _objectType = objectType;
            _endpointAddress = endpointAddress;
            _userToken = (TenroxUserService.UserToken) TranslateToken(_authToken, typeof (TenroxUserService.UserToken));

            Binding = binding;
            EndpointAddress = new EndpointAddress(_endpointAddress + "sdk/" + svcUrl);
            Token = TranslateToken(_authToken, tokenType);
        }

        #endregion Constructors 

        #region Properties (1) 

        public int ObjectId { get; protected set; }

        #endregion Properties 

        #region Methods (15) 

        // Public Methods (5) 

        public virtual IEnumerable<TenroxTransactionResult> DeleteItems(int[] itemIds, Guid integrationId)
        {
            using (IDisposable client = GetClient())
            {
                IEnumerable<Task<TenroxTransactionResult>> tasks =
                    itemIds.Select(id => Task<TenroxTransactionResult>.Factory.StartNew(() =>
                    {
                        try
                        {
                            _clientType.GetMethod("Delete").Invoke(client, new[] {Token, id});
                            DeleteBinding(id, integrationId);

                            return new TenroxTransactionResult(id, TransactionType.DELETE);
                        }
                        catch (Exception exception)
                        {
                            return new TenroxTransactionResult(id, TransactionType.DELETE, exception.Message);
                        }
                    }));

                foreach (var task in tasks)
                {
                    yield return task.Result;
                }
            }
        }

        public virtual List<ColumnProperty> GetColumns()
        {
            PropertyInfo[] properties = _objectType.GetProperties();

            foreach (PropertyInfo property in from property in properties
                let name = property.Name
                where !name.Equals("SystemDataObjectsDataClassesIEntityWithKeyEntityKey")
                let attributes = property.GetCustomAttributes(typeof (DataMemberAttribute))
                where attributes.Any()
                select property)
            {
                _objectFields.Add(property.Name, GetProperType(property.PropertyType));
            }

            List<ColumnProperty> columns = (from pair in _objectFields
                let field = pair.Key
                let dn = field.Equals("UniqueId")
                    ? "ID"
                    : Regex.Replace(field, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ")
                let displayName = dn.EndsWith(" Id") ? dn.Replace(" Id", string.Empty) : dn
                let valid = !_objectFields.ContainsKey(field + "Id") && !field.Equals("Id") && !field.Equals("UniqueId")
                where valid
                select new ColumnProperty
                {
                    ColumnName = field,
                    DiplayName = displayName,
                    type = pair.Value
                }).ToList();

            foreach (ColumnProperty column in columns)
            {
                string name = column.ColumnName;

                if (MappingDict.ContainsKey(name))
                {
                    column.DefaultListColumn = MappingDict[name];
                }

                if (DisplayNameDict.ContainsKey(name))
                {
                    column.DiplayName = DisplayNameDict[name];
                }
            }

            columns.Insert(0, new ColumnProperty
            {
                ColumnName = "Id",
                DiplayName = "EPMLive ID"
            });

            columns.Insert(0, new ColumnProperty
            {
                ColumnName = "UniqueId",
                DiplayName = "ID"
            });

            return columns;
        }

        public virtual IEnumerable<TenroxObject> GetItems(int[] itemIds)
        {
            var tasks = new List<Task<TenroxObject>>();

            using (IDisposable client = GetClient())
            {
                tasks.AddRange(itemIds.Select(id => Task<TenroxObject>.Factory.StartNew(() =>
                {
                    try
                    {
                        object txObject = _clientType.GetMethod("QueryByUniqueId").Invoke(client, new[] {Token, id});
                        return new TenroxObject(id, txObject);
                    }
                    catch (Exception exception)
                    {
                        return new TenroxObject(id, exception);
                    }
                })));

                foreach (var task in tasks)
                {
                    yield return task.Result;
                }
            }
        }

        public string TranslateIdToUserEmail(int userId)
        {
            if (userId == 0) return string.Empty;

            using (var usersClient = new UsersClient(Binding, EndpointAddress))
            {
                User user = usersClient.QueryByUniqueId(_userToken, userId);
                if (user != null)
                {
                    return user.Email;
                }
            }

            return string.Empty;
        }

        public virtual IEnumerable<TenroxTransactionResult> UpsertItems(DataTable items, Guid integrationId)
        {
            using (IDisposable client = GetClient())
            {
                List<string> columns = (from DataColumn column in items.Columns select column.ColumnName).ToList();

                var newObjects = new List<object>();
                var existingObjects = new List<object>();

                BuildObjects(items, client, columns, newObjects, existingObjects);

                var tasks = new List<Task<TenroxTransactionResult>>();

                tasks.AddRange(newObjects.Select(obj => Task<TenroxTransactionResult>.Factory.StartNew(() =>
                {
                    int uniqueId = 0;
                    try
                    {
                        uniqueId = SaveObject(client, obj);
                        UpdateBinding(uniqueId, integrationId);

                        return new TenroxTransactionResult(uniqueId, TransactionType.INSERT);
                    }
                    catch (Exception exception)
                    {
                        return new TenroxTransactionResult(uniqueId, TransactionType.INSERT, exception.Message);
                    }
                })));

                tasks.AddRange(existingObjects.Select(obj => Task<TenroxTransactionResult>.Factory.StartNew(() =>
                {
                    int uniqueId = 0;

                    try
                    {
                        uniqueId = SaveObject(client, obj);
                        return new TenroxTransactionResult(uniqueId, TransactionType.UPDATE);
                    }
                    catch (Exception exception)
                    {
                        return new TenroxTransactionResult(uniqueId, TransactionType.UPDATE, exception.Message);
                    }
                })));

                foreach (var task in tasks)
                {
                    yield return task.Result;
                }
            }
        }

        // Protected Methods (5) 

        protected abstract void BuildObjects(DataTable items, object client, List<string> columns,
            List<object> newObjects, List<object> existingObjects);

        protected void FillObjects(IEnumerable<string> columns, List<object> newObjects, List<object> existingObjects,
            object obj, DataRow row)
        {
            Type type = obj.GetType();

            foreach (
                string column in
                    from column in columns
                    let col = column.ToLower()
                    where !col.Equals("id") && !col.Equals("spid")
                    select column)
            {
                try
                {
                    PropertyInfo property = type.GetProperty(column);
                    property.SetValue(obj, GetValue(row[column], property));
                }
                catch { }
            }

            int uniqueId;
            int.TryParse((type.GetProperty("UniqueId").GetValue(obj) ?? string.Empty).ToString(), out uniqueId);

            if (uniqueId > 0)
            {
                existingObjects.Add(obj);
            }
            else
            {
                newObjects.Add(obj);
            }
        }

        protected object GetValue(object value, PropertyInfo property)
        {
            try
            {
                Type type = GetProperType(property.PropertyType);

                string val = value.ToString();

                if (type == typeof (string))
                {
                    return val;
                }

                if (type == typeof (DateTime))
                {
                    return DateTime.Parse(val);
                }

                if (type == typeof (int))
                {
                    return int.Parse(val);
                }

                if (type == typeof (decimal))
                {
                    return decimal.Parse(val);
                }

                if (type == typeof (float))
                {
                    return float.Parse(val);
                }

                if (type == typeof (double))
                {
                    return double.Parse(val);
                }

                if (type == typeof (bool))
                {
                    return bool.Parse(val);
                }
            }
            catch { }

            return value;
        }

        protected int TranslateEmailToUserId(string email)
        {
            if (string.IsNullOrEmpty(email)) return 0;

            using (var usersClient = new UsersClient(Binding, EndpointAddress))
            {
                User user = usersClient.QueryByEmail(_userToken, email);
                if (user != null)
                {
                    return user.UniqueId;
                }
            }

            return 0;
        }

        protected void UpdateBinding(int itemId, Guid integrationId)
        {
            var endpointAddress = new EndpointAddress(_endpointAddress + "sdk/integrations.svc");

            using (var integrationsClient = new IntegrationsClient(Binding, endpointAddress))
            {
                var token =
                    (TenroxIntegrationService.UserToken)
                        TranslateToken(_authToken, typeof (TenroxIntegrationService.UserToken));

                Integration integration = integrationsClient.QueryByAll(token)
                    .FirstOrDefault(i => i.ID24.Equals(integrationId.ToString()) && i.ObjectType.Equals(ObjectId)) ??
                                          new Integration
                                          {
                                              ObjectId = itemId,
                                              ObjectType = ObjectId,
                                              ID24 = integrationId.ToString()
                                          };

                integrationsClient.Save(token, integration);
            }
        }

        // Private Methods (5) 

        private void DeleteBinding(int itemId, Guid integrationId)
        {
            var endpointAddress = new EndpointAddress(_endpointAddress + "sdk/integrations.svc");

            using (var integrationsClient = new IntegrationsClient(Binding, endpointAddress))
            {
                var token =
                    (TenroxIntegrationService.UserToken)
                        TranslateToken(_authToken, typeof (TenroxIntegrationService.UserToken));
                foreach (Integration integration in integrationsClient.QueryByAll(token)
                    .Where(i => i.ID24.Equals(integrationId.ToString()) && i.ObjectId == itemId))
                {
                    integrationsClient.Delete(token, integration.UniqueId);
                    break;
                }
            }
        }

        private IDisposable GetClient()
        {
            return (IDisposable) Activator.CreateInstance(_clientType, new object[] {Binding, EndpointAddress});
        }

        private Type GetProperType(Type propertyType)
        {
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                return propertyType.GetGenericArguments()[0];
            }

            return propertyType;
        }

        private int SaveObject(IDisposable client, object obj)
        {
            object o = _clientType.GetMethod("Save").Invoke(client, new[] {Token, obj});
            return (int) o.GetType().GetProperty("UniqueId").GetValue(o);
        }

        private object TranslateToken(UserToken token, Type tokenType)
        {
            object newToken = Activator.CreateInstance(tokenType);

            foreach (PropertyInfo property in typeof (UserToken).GetProperties())
            {
                newToken.GetType().GetProperty(property.Name).SetValue(newToken, property.GetValue(token));
            }

            foreach (FieldInfo field in typeof (UserToken).GetFields())
            {
                newToken.GetType().GetField(field.Name).SetValue(newToken, field.GetValue(token));
            }

            return newToken;
        }

        #endregion Methods 
    }
}