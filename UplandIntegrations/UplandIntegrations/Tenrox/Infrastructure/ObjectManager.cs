using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using EPMLiveIntegration;
using UplandIntegrations.TenroxIntegrationService;
using UserToken = UplandIntegrations.TenroxAuthService.UserToken;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal abstract class ObjectManager : IObjectManager
    {
        #region Fields (9) 

        protected readonly Binding Binding;
        protected readonly EndpointAddress EndpointAddress;
        protected readonly object Token;
        private readonly UserToken _authToken;
        private readonly string _endpointAddress;
        private readonly Dictionary<string, Type> _objectFields;
        private readonly Type _objectType;
        protected Dictionary<string, string> DisplayNameDict;
        protected Dictionary<string, string> MappingDict;

        #endregion Fields 

        #region Constructors (1) 

        protected ObjectManager(Binding binding, string endpointAddress, string svcUrl, UserToken token, Type objectType,
            Type tokenType)
        {
            MappingDict = new Dictionary<string, string>();
            DisplayNameDict = new Dictionary<string, string>();

            _authToken = token;
            _endpointAddress = endpointAddress;
            _objectType = objectType;
            _objectFields = new Dictionary<string, Type>();

            Binding = binding;
            Token = TranslateToken(_authToken, tokenType);
            EndpointAddress = new EndpointAddress(_endpointAddress + "sdk/" + svcUrl);
        }

        #endregion Constructors 

        #region Methods (7) 

        // Public Methods (4) 

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
                let valid = !_objectFields.ContainsKey(field + "Id")
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

        public abstract IEnumerable<TenroxObject> GetItems(int[] itemIds);

        public void UpdateBinding(int itemId, int objectType, Guid integrationId)
        {
            var endpointAddress = new EndpointAddress(_endpointAddress + "sdk/integrations.svc");

            using (var integrationsClient = new IntegrationsClient(Binding, endpointAddress))
            {
                var integration = new Integration
                {
                    ObjectId = itemId,
                    ObjectType = objectType,
                    ID24 = integrationId.ToString()
                };

                object token = TranslateToken(_authToken, typeof (TenroxIntegrationService.UserToken));
                integrationsClient.Save((TenroxIntegrationService.UserToken) token, integration);
            }
        }

        public abstract IEnumerable<TenroxUpsertResult> UpsertItems(DataTable items, Guid integrationId);
        
        // Protected Methods (1) 

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

        // Private Methods (2) 

        private Type GetProperType(Type propertyType)
        {
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                return propertyType.GetGenericArguments()[0];
            }

            return propertyType;
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