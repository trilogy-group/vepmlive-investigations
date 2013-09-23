using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using EPMLiveIntegration;
using Tenrox.Shared.Utilities;

namespace UplandIntegrations.Tenrox.Infrastructure
{
    internal abstract class ObjectManager : IObjectManager
    {
        #region Fields (6) 

        protected readonly Binding Binding;
        protected readonly EndpointAddress EndpointAddress;
        protected readonly UserToken Token;
        private readonly Type _objectType;
        protected Dictionary<string, string> DisplayNameDict;
        protected Dictionary<string, string> MappingDict;

        #endregion Fields 

        #region Constructors (1) 

        protected ObjectManager(Binding binding, string endpointAddress, UserToken token, Type objectType)
        {
            MappingDict = new Dictionary<string, string>();
            DisplayNameDict = new Dictionary<string, string>();

            Binding = binding;
            EndpointAddress = new EndpointAddress(endpointAddress);
            Token = token;
            _objectType = objectType;
        }

        #endregion Constructors 

        #region Methods (3) 

        // Public Methods (2) 

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
        // Private Methods (1) 

        private Type GetProperType(Type propertyType)
        {
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                return propertyType.GetGenericArguments()[0];
            }

            return propertyType;
        }

        #endregion Methods 
    }
}