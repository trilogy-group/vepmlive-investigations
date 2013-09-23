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
using UplandIntegrations.TenroxAuthService;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal abstract class ObjectManager : IObjectManager
    {
        #region Fields (6) 

        protected readonly Binding Binding;
        protected readonly EndpointAddress EndpointAddress;
        protected readonly object Token;
        private readonly Type _objectType;
        protected Dictionary<string, string> DisplayNameDict;
        protected Dictionary<string, string> MappingDict;

        #endregion Fields 

        #region Constructors (1) 

        protected ObjectManager(Binding binding, string endpointAddress, UserToken token, Type objectType,
            Type tokenType)
        {
            MappingDict = new Dictionary<string, string>();
            DisplayNameDict = new Dictionary<string, string>();

            Binding = binding;
            Token = TranslateToken(token, tokenType);
            EndpointAddress = new EndpointAddress(endpointAddress);
            _objectType = objectType;
        }

        #endregion Constructors 

        #region Methods (5) 

        // Public Methods (3) 

        public virtual List<ColumnProperty> GetColumns()
        {
            List<ColumnProperty> columns = (from property in _objectType.GetProperties()
                let name = property.Name
                where
                    !name.Equals("SystemDataObjectsDataClassesIEntityWithKeyEntityKey") &&
                    !name.ToLower().EndsWith("id")
                let attributes = property.GetCustomAttributes(typeof (DataMemberAttribute))
                where attributes.Any()
                select new ColumnProperty
                {
                    ColumnName = name,
                    DiplayName =
                        name.Equals("UniqueId")
                            ? "ID"
                            : Regex.Replace(name, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 "),
                    type = GetProperType(property.PropertyType)
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

        public abstract IEnumerable<TenroxUpsertResult> UpsertItems(DataTable items, Guid integrationId,
            string integrationKey);

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