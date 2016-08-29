using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using PortfolioEngineCore.Infrastructure;
using PortfolioEngineCore.Infrastructure.Entities;
using PortfolioEngineCore.Infrastructure.Fields;

namespace PortfolioEngineCore
{
    internal sealed class ResourceRepository : IRepository<Resource>
    {
        #region Fields (2) 

        private readonly FieldFactory _fieldFactory = new FieldFactory();
        private readonly SqlConnection _sqlConnection;

        #endregion Fields 

        #region Enums (1) 

        private enum CustomFieldTable
        {
            ResourceINT = 101,
            ResourceTEXT = 102,
            ResourceDEC = 103,
            ResourceNTEXT = 104,
            ResourceDATE = 105,
            ResourceMV = 151,
            PortfolioINT = 201,
            PortfolioTEXT = 202,
            PortfolioDEC = 203,
            PortfolioNTEXT = 204,
            PortfolioDATE = 205,
            Program = 251,
            ProjectINT = 301,
            ProjectTEXT = 302,
            ProjectDEC = 303,
            ProjectNTEXT = 304,
            ProjectDATE = 305,
            ProgramText = 402,
            TaskWIINT = 801,
            TaskWITEXT = 802,
            TaskWIDEC = 803
        }

        #endregion Enums 

        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourceRepository" /> class.
        /// </summary>
        /// <param name="sqlConnection">The SQL connection.</param>
        internal ResourceRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        #endregion Constructors 

        #region Methods (27) 

        // Public Methods (1) 

        /// <summary>
        ///     Deletes the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="currentUserId">The current user id.</param>
        public void Delete(Resource resource, int currentUserId)
        {
            using (var sqlCommand = new SqlCommand("EPG_SP_DeleteResource", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@WRESID", resource.Id);
                sqlCommand.Parameters.AddWithValue("@ReplacementWRESID", currentUserId);

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                _sqlConnection.Close();
            }
        }

        // Private Methods (23) 

        /// <summary>
        ///     Adds the permission.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="permissionGroup">The permission group.</param>
        private void AddPermission(Resource resource, KeyValuePair<int, string> permissionGroup)
        {
            const string query =
                @"INSERT INTO dbo.EPG_GROUP_MEMBERS (MEMBER_UID, GROUP_ID) VALUES(@ResourceId, @GroupId)";

            using (var sqlCommand = new SqlCommand(query, _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);
                sqlCommand.Parameters.AddWithValue("@GroupId", permissionGroup.Key);

                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Calculates the name of the table field.
        /// </summary>
        /// <param name="fieldId">The field id.</param>
        /// <param name="tableId">The table id.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="fieldName">Name of the field.</param>
        private static void CalculateTableFieldName(int fieldId, int tableId, out string tableName, out string fieldName)
        {
            var customFieldTable =
                (CustomFieldTable) Enum.Parse(typeof (CustomFieldTable), tableId.ToString(CultureInfo.InvariantCulture));

            switch (customFieldTable)
            {
                case CustomFieldTable.ResourceINT:
                    tableName = "EPGC_RESOURCE_INT_VALUES";
                    fieldName = string.Format("RI_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ResourceTEXT:
                    tableName = "EPGC_RESOURCE_TEXT_VALUES";
                    fieldName = string.Format("RT_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ResourceDEC:
                    tableName = "EPGC_RESOURCE_DEC_VALUES";
                    fieldName = string.Format("RC_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ResourceNTEXT:
                    tableName = "EPGC_RESOURCE_NTEXT_VALUES";
                    fieldName = string.Format("RN_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ResourceDATE:
                    tableName = "EPGC_RESOURCE_DATE_VALUES";
                    fieldName = string.Format("RD_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ResourceMV:
                    tableName = "EPGC_RESOURCE_MV_VALUES";
                    fieldName = "MVR_UID";
                    break;
                case CustomFieldTable.PortfolioINT:
                    tableName = "EPGP_PROJECT_INT_VALUES";
                    fieldName = string.Format("PI_{0:000}", fieldId);
                    break;
                case CustomFieldTable.PortfolioTEXT:
                    tableName = "EPGP_PROJECT_TEXT_VALUES";
                    fieldName = string.Format("PT_{0:000}", fieldId);
                    break;
                case CustomFieldTable.PortfolioDEC:
                    tableName = "EPGP_PROJECT_DEC_VALUES";
                    fieldName = string.Format("PC_{0:000}", fieldId);
                    break;
                case CustomFieldTable.PortfolioNTEXT:
                    tableName = "EPGP_PROJECT_NTEXT_VALUES";
                    fieldName = string.Format("PN_{0:000}", fieldId);
                    break;
                case CustomFieldTable.PortfolioDATE:
                    tableName = "EPGP_PROJECT_DATE_VALUES";
                    fieldName = string.Format("PD_{0:000}", fieldId);
                    break;
                case CustomFieldTable.Program:
                    tableName = "EPGP_PI_PROGS";
                    fieldName = "PROG_UID";
                    break;
                case CustomFieldTable.ProjectINT:
                    tableName = "EPGX_PROJ_INT_VALUES";
                    fieldName = string.Format("XI_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ProjectTEXT:
                    tableName = "EPGX_PROJ_TEXT_VALUES";
                    fieldName = string.Format("XT_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ProjectDEC:
                    tableName = "EPGX_PROJ_DEC_VALUES";
                    fieldName = string.Format("XC_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ProjectNTEXT:
                    tableName = "EPGX_PROJ_NTEXT_VALUES";
                    fieldName = string.Format("XN_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ProjectDATE:
                    tableName = "EPGX_PROJ_DATE_VALUES";
                    fieldName = string.Format("XD_{0:000}", fieldId);
                    break;
                case CustomFieldTable.ProgramText:
                    tableName = "EPGP_PI_PROGS";
                    fieldName = string.Format("PROG_PI_TEXT{0:0}", fieldId);
                    break;
                case CustomFieldTable.TaskWIINT:
                    tableName = "EPGP_PI_WORKITEMS";
                    fieldName = string.Format("WORKITEM_FLAG{0:0}", fieldId);
                    break;
                case CustomFieldTable.TaskWITEXT:
                    tableName = "EPGP_PI_WORKITEMS";
                    fieldName = string.Format("WORKITEM_CTEXT{0:0}", fieldId);
                    break;
                case CustomFieldTable.TaskWIDEC:
                    tableName = "EPGP_PI_WORKITEMS";
                    fieldName = string.Format("WORKITEM_NUMBER{0:0}", fieldId);
                    break;
                default:
                    tableName = "Unknown Table";
                    fieldName = string.Empty;
                    break;
            }
        }

        /// <summary>
        ///     Deletes the permission.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="permissionGroup">The permission group.</param>
        private void DeletePermission(Resource resource, KeyValuePair<int, string> permissionGroup)
        {
            const string query =
                @"DELETE FROM dbo.EPG_GROUP_MEMBERS WHERE MEMBER_UID = @ResourceId AND GROUP_ID = @GroupId";

            using (var sqlCommand = new SqlCommand(query, _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);
                sqlCommand.Parameters.AddWithValue("@GroupId", permissionGroup.Key);

                sqlCommand.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     Generates the new resource id.
        /// </summary>
        /// <returns></returns>
        private int GenerateNewResourceId()
        {
            int resourceId;

            using (var sqlCommand = new SqlCommand("SELECT dbo.PFE_FN_GenerateNewResourceId()", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                resourceId = (int) sqlCommand.ExecuteScalar();

                _sqlConnection.Close();
            }

            return resourceId;
        }

        /// <summary>
        ///     Gets the available custom fields.
        /// </summary>
        /// <returns></returns>
        private DataTable GetAvailableCustomFields()
        {
            var dataTable = new DataTable();

            using (var sqlCommand = new SqlCommand("EPG_SP_ReadResCFields", _sqlConnection))
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                dataTable.Load(sqlCommand.ExecuteReader());

                _sqlConnection.Close();
            }

            return dataTable;
        }

        /// <summary>
        ///     Gets the changed properties.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        private DataTable GetChangedProperties(Resource resource)
        {
            Resource existingResource = FindById(resource.Id);

            var changedProperties = new DataTable();

            changedProperties.Columns.Add("FieldId", typeof (int));
            changedProperties.Columns.Add("FieldName", typeof (string));
            changedProperties.Columns.Add("PropertyName", typeof (string));
            changedProperties.Columns.Add("NewValue", typeof (object));
            changedProperties.Columns.Add("ExistingValue", typeof (object));

            foreach (PropertyInfo propertyInfo in resource.GetType().GetProperties())
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(typeof (FieldInfoAttribute), false);

                if (!customAttributes.Any()) continue;

                var fieldInfoAttribute = (FieldInfoAttribute) customAttributes[0];

                string propertyName = propertyInfo.Name;

                if (propertyName.Equals("Permissions")) continue;

                object newValue = resource.GetType().GetProperty(propertyName).GetValue(resource, null) ?? string.Empty;
                object existingValue = resource.GetType().GetProperty(propertyName).GetValue(existingResource, null) ??
                                       string.Empty;

                if (!newValue.ToString().Equals(existingValue.ToString()))
                {
                    changedProperties.Rows.Add(fieldInfoAttribute.Id, fieldInfoAttribute.Name, propertyName, newValue,
                                               existingValue);
                }
            }

            if (resource.PermissionsDictionary.Count == existingResource.PermissionsDictionary.Count)
            {
                if (
                    resource.PermissionsDictionary.Any(
                        kvp => !existingResource.PermissionsDictionary.ContainsKey(kvp.Key)))
                {
                    changedProperties.Rows.Add(3200, null, "Permissions", resource.Permissions,
                                               existingResource.Permissions);
                }
                else
                {
                    if (resource.PermissionsDictionary.Any(kvp => kvp.Value.Contains("|DEL")))
                    {
                        changedProperties.Rows.Add(3200, null, "Permissions", resource.Permissions,
                                                   existingResource.Permissions);
                    }
                }
            }
            else
            {
                changedProperties.Rows.Add(3200, null, "Permissions", resource.Permissions,
                                           existingResource.Permissions);
            }

            List<IField> existingCustomFields = existingResource.CustomFields.ToList();
            List<IField> customFields = resource.CustomFields.ToList();

            foreach (IField customField in customFields)
            {
                int fieldId = customField.Id;

                if (existingCustomFields.Exists(f => f.Id == fieldId))
                {
                    IField existingCustomValueField = existingCustomFields.First(f => f.Id == fieldId);
                    if (!customField.ToString().Equals(existingCustomValueField.ToString()))
                    {
                        if (customField is CodeField)
                        {
                            changedProperties.Rows.Add(fieldId, null, customField.Name,
                                                       ((CodeField) customField).GetCode(),
                                                       ((CodeField) existingCustomValueField).GetCode());
                        }
                        else
                        {
                            changedProperties.Rows.Add(fieldId, null, customField.Name, customField.GetValue(),
                                                       existingCustomValueField.GetValue());
                        }
                    }
                }
                else
                {
                    changedProperties.Rows.Add(fieldId, null, customField.Name, customField.GetValue(), null);
                }
            }

            if (existingCustomFields.Count > customFields.Count)
            {
                foreach (IField existingCustomField in existingCustomFields
                    .Where(existingCustomField => !customFields.Exists(f => f.Id == existingCustomField.Id)))
                {
                    changedProperties.Rows.Add(existingCustomField.Id, null, existingCustomField.Name, null,
                                               existingCustomField.GetValue());
                }
            }

            return changedProperties;
        }

        /// <summary>
        ///     Gets the custom field.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="value"> </param>
        /// <returns></returns>
        private IField GetCustomField(int id, string name, object value)
        {
            foreach (DataRow dataRow in GetAvailableCustomFields().Rows.Cast<DataRow>()
                                                                  .Where(dataRow => (int) dataRow["FA_FIELD_ID"] == id))
            {
                var fieldType = (int) dataRow["FA_FORMAT"];

                IField field = _fieldFactory.Make(id, name, fieldType);

                DataRowCollection lookupValueCollection = GetLookupValues().Rows;

                bool valueNotNull = value != null && value != DBNull.Value && !string.IsNullOrEmpty(value.ToString());

                switch (fieldType)
                {
                    case (int) PFEFieldType.CodeField:
                        if (valueNotNull)
                        {
                            int code;

                            try
                            {
                                code = Convert.ToInt32(value);
                            }
                            catch
                            {
                                DataRow lookupValue =
                                    lookupValueCollection.Cast<DataRow>()
                                                         .First(
                                                             row =>
                                                             row["LV_FULLVALUE"].ToString().Equals(value.ToString()));
                                code = (int) lookupValue["LV_UID"];
                            }

                            try
                            {
                                DataRow lookupValue =
                                    lookupValueCollection.Cast<DataRow>().First(row => (int) row["LV_UID"] == code);

                                ((CodeField) field).SetCode(code);
                                field.SetValue(lookupValue["LV_FULLVALUE"]);
                            }
                            catch
                            {
                                throw new PFEException((int) PFEError.InvalidLookup, "Lookup cannot be found.");
                            }
                        }
                        else
                        {
                            ((CodeField) field).SetCode(-1);
                        }
                        break;
                    case (int) PFEFieldType.MultiValueCodeField:
                        if (valueNotNull)
                        {
                            var dictionary = new Dictionary<int, string>();

                            foreach (int code in ((string) value).Split(',')
                                                                 .Select(val => Convert.ToInt32(val))
                                                                 .Where(code => !dictionary.ContainsKey(code)))
                            {
                                try
                                {
                                    DataRow lookupValue =
                                        lookupValueCollection.Cast<DataRow>().First(row => (int) row["LV_UID"] == code);

                                    dictionary.Add(code, lookupValue["LV_FULLVALUE"].ToString());
                                }
                                catch
                                {
                                    throw new PFEException((int) PFEError.InvalidLookup, "Lookup cannot be found.");
                                }
                            }

                            field.SetValue(dictionary);
                        }
                        else
                        {
                            ((MultiValueCodeField) field).SetValue(new Dictionary<int, string>());
                        }
                        break;
                    default:
                        field.SetValue(value);
                        break;
                }

                return field;
            }

            throw new PFEException((int) PFEError.CustomFieldNotFound,
                                   string.Format("{0} is not a valid custom field Id.", id));
        }

        /// <summary>
        ///     Gets the custom fields.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="resource">The resource.</param>
        private void GetCustomFields(int id, ref Resource resource)
        {
            DataTable dataTable = GetAvailableCustomFields();

            var singleValuequeryFields = new List<string>();
            var multiValuequeryFields = new List<string>();

            GetQueryFields(ref singleValuequeryFields, ref multiValuequeryFields, ref dataTable);

            if (singleValuequeryFields.Count > 0)
            {
                GetCustomFieldValues(id, singleValuequeryFields, dataTable, ref resource);
            }

            if (multiValuequeryFields.Count > 0)
            {
                GetMultiValueCustomFieldValues(id, dataTable, ref resource);
            }
        }

        /// <summary>
        ///     Gets the custom field values.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="queryFields">The query fields.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="resource">The resource.</param>
        private void GetCustomFieldValues(int id, List<string> queryFields, DataTable dataTable, ref Resource resource)
        {
            using (var sqlCommand = new SqlCommand("PFE_SP_GetCustomFieldValues", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Fields", SqlDbType.NVarChar)
                    {Value = string.Join(",", queryFields.ToArray())});
                sqlCommand.Parameters.Add(new SqlParameter("@ResourceId", SqlDbType.Int) {Value = id});

                DataTable lookupValues = GetLookupValues();

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        var tableId = (int) dataRow["FA_TABLE_ID"];

                        if (tableId == (int) CustomFieldTable.ResourceNTEXT ||
                            tableId == (int) CustomFieldTable.ResourceMV)
                            continue;

                        var fieldType = (int) dataRow["FA_FORMAT"];

                        IField field = _fieldFactory.Make((int) dataRow["FA_FIELD_ID"], (string) dataRow["FA_NAME"],
                                                          fieldType);

                        object value = sqlDataReader[(string) dataRow["FieldName"]];

                        if (fieldType == (int) PFEFieldType.CodeField)
                        {
                            if (value.GetType() != typeof (DBNull))
                            {
                                var code = (int) value;

                                DataRow lookupValue =
                                    lookupValues.Rows.Cast<DataRow>().FirstOrDefault(row => (int) row["LV_UID"] == code);

                                if (lookupValue != null)
                                {
                                    ((CodeField) field).SetCode(code);
                                    field.SetValue(lookupValue["LV_FULLVALUE"]);
                                }
                            }
                        }
                        else
                        {
                            if (value.GetType() != typeof (DBNull))
                            {
                                field.SetValue(value);
                            }
                        }

                        resource.CustomFields.Add(field);
                    }

                    break;
                }

                _sqlConnection.Close();
            }
        }

        /// <summary>
        ///     Gets the general information.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="resource">The resource.</param>
        private void GetGeneralInformation(int id, ref Resource resource)
        {
            using (var sqlCommand = new SqlCommand("EPG_SP_ReadResourceInfos", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@WresID", SqlDbType.Int) {Value = id});

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (!sqlDataReader.HasRows)
                {
                    throw new PFEException((int) PFEError.FindResourceById,
                                           string.Format("Cannot find the resource with id {0}", id));
                }

                while (sqlDataReader.Read())
                {
                    // ReSharper disable PossibleInvalidOperationException
                    resource.Id = (int) sqlDataReader.GetInt32Safely("WRES_ID");
                    // ReSharper restore PossibleInvalidOperationException
                    resource.Name = sqlDataReader.GetStringSafely("RES_NAME");
                    resource.Password = sqlDataReader.GetStringSafely("WRES_PASSWORD");
                    resource.UseNTLogin = sqlDataReader.GetByteSafely("WRES_USE_NT_LOGON");
                    resource.NTAccount = sqlDataReader.GetStringSafely("WRES_NT_ACCOUNT");
                    resource.CanLogin = sqlDataReader.GetByteSafely("WRES_CAN_LOGIN");
                    resource.AvailableFrom = sqlDataReader.GetDateTimeSafely("WRES_AVAILABLEFROM");
                    resource.AvailableTo = sqlDataReader.GetDateTimeSafely("WRES_AVAILABLETO");
                    resource.Email = sqlDataReader.GetStringSafely("WRES_EMAIL");
                    resource.InActive = sqlDataReader.GetByteSafely("WRES_INACTIVE");
                    resource.IsResource = sqlDataReader.GetByteSafely("WRES_IS_RESOURCE");
                    resource.IsGeneric = sqlDataReader.GetByteSafely("WRES_IS_GENERIC");
                    resource.TSDepartment = sqlDataReader.GetInt32Safely("WRES_DEPT");
                    resource.RPDepartment = sqlDataReader.GetInt32Safely("WRES_RP_DEPT");
                    resource.Notes = sqlDataReader.GetStringSafely("WRES_NOTES");
                    resource.ExternalUId = sqlDataReader.GetStringSafely("WRES_EXT_UID");
                    resource.Trace = sqlDataReader.GetInt32Safely("WRES_TRACE");
                    resource.CostCategoryRoleId = sqlDataReader.GetInt32Safely("CCUID");
                    resource.RateId = sqlDataReader.GetInt32Safely("RT_UID");

                    break;
                }

                _sqlConnection.Close();
            }
        }

        /// <summary>
        ///     Gets the groups.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="resource">The resource.</param>
        private void GetGroups(int id, ref Resource resource)
        {
            using (var sqlCommand = new SqlCommand("EPG_SP_ReadGroupsForMember", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@WresID", SqlDbType.Int) {Value = id});

                var dictionary = new Dictionary<int, Dictionary<int, string>>();

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    // ReSharper disable PossibleInvalidOperationException
                    var gid = (int) sqlDataReader.GetInt32Safely("GROUP_ID");
                    string gname = sqlDataReader.GetStringSafely("GROUP_NAME");
                    var gentity = (int) sqlDataReader.GetInt32Safely("GROUP_ENTITY");
                    // ReSharper restore PossibleInvalidOperationException

                    if (!dictionary.ContainsKey(gentity))
                    {
                        dictionary.Add(gentity, new Dictionary<int, string>());
                    }

                    Dictionary<int, string> groupEntity = dictionary[gentity];

                    if (!groupEntity.ContainsKey(gid))
                    {
                        groupEntity.Add(gid, gname);
                    }
                }

                _sqlConnection.Close();

                foreach (var keyValuePair in dictionary)
                {
                    foreach (var valuePair in keyValuePair.Value)
                    {
                        int groupId = valuePair.Key;
                        string groupName = valuePair.Value;

                        switch (keyValuePair.Key)
                        {
                            case 1:
                                resource.PermissionsDictionary.Add(groupId, groupName);
                                break;
                            case 10:
                                resource.WorkingHoursListId = groupId;
                                resource.WorkingHoursListName = groupName;
                                break;
                            case 11:
                                resource.HolidaysListId = groupId;
                                resource.HolidaysListName = groupName;
                                break;
                            case 12:
                                resource.TimesheetListId = groupId;
                                resource.TimesheetListName = groupName;
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the lookup values.
        /// </summary>
        /// <returns></returns>
        private DataTable GetLookupValues()
        {
            using (var sqlCommand =
                new SqlCommand("SELECT LV_UID, LV_FULLVALUE FROM dbo.EPGP_LOOKUP_VALUES ORDER BY LV_UID",
                               _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                var dataTable = new DataTable();
                dataTable.Load(sqlCommand.ExecuteReader());

                _sqlConnection.Close();

                return dataTable;
            }
        }

        /// <summary>
        ///     Gets the multi value custom field values.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="dataTable">The data table.</param>
        /// <param name="resource">The resource.</param>
        private void GetMultiValueCustomFieldValues(int id, DataTable dataTable, ref Resource resource)
        {
            const string query =
                @"SELECT dbo.EPGC_RESOURCE_MV_VALUES.MVR_FIELD_ID, dbo.EPGC_RESOURCE_MV_VALUES.MVR_UID, dbo.EPGP_LOOKUP_VALUES.LV_VALUE 
                                   FROM   dbo.EPGP_LOOKUP_VALUES INNER JOIN dbo.EPGC_RESOURCE_MV_VALUES ON dbo.EPGP_LOOKUP_VALUES.LV_UID = dbo.EPGC_RESOURCE_MV_VALUES.MVR_UID
                                   WHERE  (dbo.EPGC_RESOURCE_MV_VALUES.WRES_ID = @ResourceId)";

            using (var sqlCommand = new SqlCommand(query, _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.Add(new SqlParameter("@ResourceId", SqlDbType.Int) {Value = id});

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                var dictionary = new Dictionary<int, Dictionary<int, string>>();

                while (sqlDataReader.Read())
                {
                    int fieldId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("MVR_FIELD_ID"));
                    int code = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("MVR_UID"));
                    string value = sqlDataReader.GetString(sqlDataReader.GetOrdinal("LV_VALUE"));

                    if (!dictionary.ContainsKey(fieldId))
                    {
                        dictionary.Add(fieldId, new Dictionary<int, string>());
                    }

                    dictionary[fieldId].Add(code, value);
                }

                _sqlConnection.Close();

                foreach (var keyValuePair in dictionary)
                {
                    KeyValuePair<int, Dictionary<int, string>> pair = keyValuePair;

                    foreach (IField field in from DataRow dataRow in dataTable.Rows
                                             let fieldId = (int) dataRow["FA_FIELD_ID"]
                                             where pair.Key == fieldId
                                             select _fieldFactory.Make(fieldId, (string) dataRow["FA_NAME"],
                                                                       (int) PFEFieldType.MultiValueCodeField))
                    {
                        field.SetValue(pair.Value);

                        resource.CustomFields.Add(field);

                        break;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the query fields.
        /// </summary>
        /// <param name="singleValueQueryFields">The single value query fields.</param>
        /// <param name="multiValueQueryFields">The multi value query fields.</param>
        /// <param name="dataTable">The data table.</param>
        private void GetQueryFields(ref List<string> singleValueQueryFields, ref List<string> multiValueQueryFields,
                                    ref DataTable dataTable)
        {
            dataTable.Columns.Add("TableName", typeof (string));
            dataTable.Columns.Add("FieldName", typeof (string));

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var tableId = (int) dataRow["FA_TABLE_ID"];
                var fieldId = (int) dataRow["FA_FIELD_IN_TABLE"];

                string tableName;
                string fieldName;

                CalculateTableFieldName(fieldId, tableId, out tableName, out fieldName);

                dataRow.SetField("TableName", tableName);
                dataRow.SetField("FieldName", fieldName);

                if (tableId == (int) CustomFieldTable.ResourceNTEXT || tableId == (int) CustomFieldTable.ResourceMV)
                {
                    multiValueQueryFields.Add(fieldName);
                }
                else
                {
                    singleValueQueryFields.Add(fieldName);
                }
            }
        }

        /// <summary>
        ///     Gets the resource custom field values.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="sql">The SQL.</param>
        /// <param name="dbFieldName">Name of the db field.</param>
        /// <param name="typeKey">The type key.</param>
        private void GetResourceCustomFieldValues(Resource resource, Dictionary<string, List<string>> dictionary,
                                                  string fieldName, string sql, string dbFieldName, string typeKey)
        {
            using (var sqlCommand = new SqlCommand(sql, _sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);

                sqlCommand.CommandType = CommandType.Text;

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal(dbFieldName));
                    string type = string.Format("{0} {1}", typeKey, fieldName);

                    if (!dictionary.ContainsKey(type)) dictionary.Add(type, new List<string>());

                    dictionary[type].Add(name);
                }

                _sqlConnection.Close();
            }
        }

        /// <summary>
        ///     Gets the unboxed value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private object GetUnboxedValue(object value, Type type)
        {
            string stringValue = value.ToString();

            switch (type.Name)
            {
                case "Byte":
                    if (stringValue.Equals("0") || stringValue.ToLower().Equals("false")) return (byte) 0;
                    if (stringValue.Equals("1") || stringValue.ToLower().Equals("true")) return (byte) 1;
                    return Convert.ToByte(value);
                case "DateTime":
                    return new DateTime(Convert.ToInt32(stringValue.Substring(0, 4)),
                                        Convert.ToInt32(stringValue.Substring(5, 2)),
                                        Convert.ToInt32(stringValue.Substring(8, 2)),
                                        Convert.ToInt32(stringValue.Substring(11, 2)),
                                        Convert.ToInt32(stringValue.Substring(14, 2)),
                                        Convert.ToInt32(stringValue.Substring(0x11, 2)), new GregorianCalendar());
                default:
                    return Convert.ChangeType(value, type);
            }
        }

        /// <summary>
        ///     Inserts the basic resource information.
        /// </summary>
        /// <param name="resource">The resource.</param>
        private void InsertBasicResourceInformation(Resource resource)
        {
            const string query =
                "INSERT INTO dbo.EPG_RESOURCES (WRES_ID, RES_NAME, WRES_EXT_UID) VALUES(@Id, @Name, @ExtId)";
            using (var sqlCommand = new SqlCommand(query, _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.AddWithValue("@Id", resource.Id);
                sqlCommand.Parameters.AddWithValue("@Name", resource.Name);
                sqlCommand.Parameters.AddWithValue("@ExtId", resource.ExternalUId);

                sqlCommand.CommandType = CommandType.Text;

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                _sqlConnection.Close();
            }
        }

        /// <summary>
        ///     Determines whether [is resource in use] [the specified resource].
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="checkLevel">The check level.</param>
        /// <returns>
        ///     <c>true</c> if [is resource in use] [the specified resource]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsResourceInUse(Resource resource, StringBuilder stringBuilder, int checkLevel)
        {
            string messageTitle = checkLevel == 1
                                      ? "This resource cannot be deleted. It is used as follows:"
                                      : "This resource has been associated with the following items. If you continue, all of the following items will be assigned to you.";

            bool resourceInUse = false;

            if (_sqlConnection.State == ConnectionState.Open)
            {
                _sqlConnection.Close();
            }

            _sqlConnection.Open();

            using (
                var sqlCommand = new SqlCommand(string.Format("EPG_SP_ReadUsedResource{0}", checkLevel), _sqlConnection)
                )
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@WresID", SqlDbType.Int) {Value = resource.Id});

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    stringBuilder.AppendLine(messageTitle);
                    stringBuilder.AppendLine();

                    var dictionary = new Dictionary<string, List<string>>();

                    while (sqlDataReader.Read())
                    {
                        string type = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Type"));
                        string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));

                        if (!dictionary.ContainsKey(type)) dictionary.Add(type, new List<string>());

                        dictionary[type].Add(name);
                    }

                    if (dictionary.Count > 0)
                    {
                        foreach (var keyValuePair in dictionary)
                        {
                            string type = keyValuePair.Key.Split('.')[1];

                            stringBuilder.AppendLine(string.Format("{0}: \t {1}", type,
                                                                   string.Join(", ", keyValuePair.Value.ToArray())));
                        }

                        resourceInUse = true;
                    }
                }
            }

            _sqlConnection.Close();

            return resourceInUse;
        }

        /// <summary>
        ///     Updates the cost category.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="costCategoryId">The cost category id.</param>
        private void UpdateCostCategory(Resource resource, int costCategoryId)
        {
            using (var sqlCommand = new SqlCommand("PFE_SP_UpdateResourceCostCategory", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);
                sqlCommand.Parameters.AddWithValue("@CostCategoryId", costCategoryId);

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                _sqlConnection.Close();
            }
        }

        /// <summary>
        ///     Updates the custom fields.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="changedCustomFields">The changed custom fields.</param>
        private void UpdateCustomFields(Resource resource, DataRow[] changedCustomFields)
        {
            DataTable availableCustomFields = GetAvailableCustomFields();

            foreach (CustomFieldTable customFieldTable in Enum.GetValues(typeof (CustomFieldTable)))
            {
                var tableId = (int) customFieldTable;

                var fields = from changedFields in changedCustomFields.AsEnumerable()
                             let changedFieldId = (int) changedFields["FieldId"]
                             join availableFields in availableCustomFields.AsEnumerable() on changedFieldId equals
                                 (int) availableFields["FA_FIELD_ID"]
                             let fieldTableId = (int) availableFields["FA_TABLE_ID"]
                             where fieldTableId == tableId
                             select new
                                 {
                                     FieldId = changedFieldId,
                                     FieldValue = changedFields["NewValue"],
                                     FieldFormat = Enum.Parse(typeof (PFEFieldType),
                                                              availableFields["FA_FORMAT"].ToString()),
                                     TableId = fieldTableId,
                                     TableFieldId = (int) availableFields["FA_FIELD_IN_TABLE"],
                                 };

                string tableName = null;

                var dictionary = new Dictionary<string, object>();
                var mvDictionary = new Dictionary<int, object>();

                foreach (var field in fields)
                {
                    object fieldValue = field.FieldValue;
                    int tblId = field.TableId;

                    string fieldName;
                    CalculateTableFieldName(field.TableFieldId, tblId, out tableName, out fieldName);

                    if (tblId != (int) CustomFieldTable.ResourceMV)
                    {
                        dictionary.Add(fieldName, fieldValue);
                    }
                    else
                    {
                        int fieldId = field.FieldId;

                        if (!mvDictionary.ContainsKey(fieldId))
                        {
                            mvDictionary.Add(fieldId, null);
                        }

                        mvDictionary[fieldId] = fieldValue;
                    }
                }

                if (dictionary.Count > 0)
                {
                    if (_sqlConnection.State == ConnectionState.Open)
                    {
                        _sqlConnection.Close();
                    }

                    _sqlConnection.Open();

                    object customFieldResourceId;

                    string query = string.Format(@"SELECT COUNT(WRES_ID) FROM dbo.{0} WHERE WRES_ID = @ResourceId",
                                                 tableName);

                    using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);

                        customFieldResourceId = sqlCommand.ExecuteScalar();
                    }

                    if (customFieldResourceId == DBNull.Value) customFieldResourceId = 0;

                    if (int.Parse(customFieldResourceId.ToString()) == 0)
                    {
                        query = string.Format(@"INSERT INTO dbo.{0} (WRES_ID) VALUES(@ResourceId)", tableName);

                        using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);

                            sqlCommand.ExecuteNonQuery();
                        }
                    }

                    IEnumerable<string> updates =
                        dictionary.Select(keyValuePair => string.Format(@"[{0}] = @{0}", keyValuePair.Key));

                    query = string.Format(@"UPDATE dbo.{0} SET {1} WHERE WRES_ID = @ResourceId", tableName,
                                          string.Join(",", updates.ToArray()));

                    using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        foreach (var keyValuePair in dictionary)
                        {
                            sqlCommand.Parameters.AddWithValue(string.Format("@{0}", keyValuePair.Key),
                                                               keyValuePair.Value);
                        }

                        sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);

                        sqlCommand.ExecuteNonQuery();
                    }

                    _sqlConnection.Close();
                }

                if (mvDictionary.Count <= 0) continue;

                foreach (var keyValuePair in mvDictionary)
                {
                    if (_sqlConnection.State == ConnectionState.Open)
                    {
                        _sqlConnection.Close();
                    }

                    _sqlConnection.Open();

                    string query =
                        @"DELETE FROM dbo.EPGC_RESOURCE_MV_VALUES WHERE WRES_ID = @ResourceId AND MVR_FIELD_ID = @FieldId";

                    using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);
                        sqlCommand.Parameters.AddWithValue("@FieldId", keyValuePair.Key);

                        sqlCommand.ExecuteNonQuery();
                    }

                    var value = (Dictionary<int, string>) keyValuePair.Value;

                    if (value.Count > 0)
                    {
                        foreach (var valuePair in value)
                        {
                            query =
                                @"INSERT INTO dbo.EPGC_RESOURCE_MV_VALUES (WRES_ID, MVR_FIELD_ID, MVR_UID) VALUES(@ResourceId, @FieldId, @ValueId)";

                            using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                            {
                                sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);
                                sqlCommand.Parameters.AddWithValue("@FieldId", keyValuePair.Key);
                                sqlCommand.Parameters.AddWithValue("@ValueId", valuePair.Key);

                                sqlCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    _sqlConnection.Close();
                }
            }
        }

        /// <summary>
        ///     Updates the general information.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        /// <param name="changedProperties">The changed properties.</param>
        private void UpdateGeneralInformation(int resourceId, DataTable changedProperties)
        {
            DataRow[] dataRows = changedProperties.Select("FieldName IS NOT NULL");

            if (!dataRows.Any()) return;

            string query = string.Format(@"UPDATE dbo.EPG_RESOURCES SET {0} WHERE [WRES_ID] = @WRES_ID",
                                         string.Join(",", (from dataRow in dataRows
                                                           select dataRow["FieldName"] as string
                                                           into fieldName
                                                           where !string.IsNullOrEmpty(fieldName)
                                                           select string.Format("[{0}] = @{0}", fieldName)).ToArray()));

            using (var sqlCommand = new SqlCommand(query, _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                foreach (DataRow dataRow in dataRows)
                {
                    sqlCommand.Parameters.AddWithValue(string.Format("@{0}", dataRow["FieldName"]), dataRow["NewValue"]);
                }

                sqlCommand.Parameters.AddWithValue("@WRES_ID", resourceId);

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                _sqlConnection.Close();
            }
        }

        /// <summary>
        ///     Updates the groups.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="dataRow">The data row.</param>
        private void UpdateGroups(Resource resource, DataRow dataRow)
        {
            var propertyName = (string) dataRow["PropertyName"];

            int groupEntityId = -1;

            switch (propertyName)
            {
                case "Permissions":
                    groupEntityId = 1;
                    break;
                case "HolidaysListId":
                    groupEntityId = 11;
                    break;
                case "WorkingHoursListId":
                    groupEntityId = 10;
                    break;
                case "TimesheetListId":
                    groupEntityId = 12;
                    break;
            }

            if (_sqlConnection.State == ConnectionState.Open)
            {
                _sqlConnection.Close();
            }

            _sqlConnection.Open();

            string query;

            if (!propertyName.Equals("Permissions"))
            {
                query =
                    @"DELETE FROM dbo.EPG_GROUP_MEMBERS WHERE MEMBER_UID = @ResourceId AND GROUP_ID In (SELECT GROUP_ID FROM dbo.EPG_GROUPS WHERE GROUP_ENTITY = @GroupEntityId)";

                using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);
                    sqlCommand.Parameters.AddWithValue("@GroupEntityId", groupEntityId);

                    sqlCommand.ExecuteNonQuery();
                }

                object newValue = dataRow["NewValue"];

                if (newValue != null)
                {
                    query = @"INSERT INTO dbo.EPG_GROUP_MEMBERS (MEMBER_UID, GROUP_ID) VALUES(@ResourceId, @GroupId)";

                    using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        sqlCommand.Parameters.AddWithValue("@ResourceId", resource.Id);
                        sqlCommand.Parameters.AddWithValue("@GroupId", newValue);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                foreach (var keyValuePair in resource.PermissionsDictionary)
                {
                    bool isNew = keyValuePair.Value.Contains("ADD");

                    if (isNew)
                    {
                        DeletePermission(resource, keyValuePair);
                        AddPermission(resource, keyValuePair);
                    }
                    else
                    {
                        DeletePermission(resource, keyValuePair);
                    }
                }
            }

            _sqlConnection.Close();
        }

        /// <summary>
        ///     Validates the resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        private void ValidateResource(Resource resource)
        {
            IList<string> errorMessages;

            if (resource.Validate(out errorMessages))
            {
                if (!resource.IsGeneric.HasValue || resource.IsGeneric.Value == 0)
                {
                    if (!string.IsNullOrEmpty(resource.Email))
                    {
                        int? resourceId = FindIdBy("WRES_EMAIL", resource.Email);
                        if (resourceId.HasValue && resourceId != resource.Id)
                        {
                            errorMessages.Add("Another resource with the same email address already exists.");
                        }
                    }
                }
            }

            if (errorMessages.Count > 0)
            {
                throw new PFEException((int) PFEError.UpdateResourceValidation,
                                       string.Format("Validation Errors: {0}", string.Join(" ", errorMessages.ToArray())));
            }
        }

        // Internal Methods (3) 

        /// <summary>
        ///     Builds the resource.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="permissionGroups">The permission groups.</param>
        /// <param name="username">The username.</param>
        /// <param name="extId">The ext id.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        internal Resource BuildResource(DataRow dataRow, IEnumerable<Group> permissionGroups, string username,
                                        string extId, int? id)
        {
            Resource resource;

            try
            {
                int resourceId = GetResourceId(id, extId, username);

                resource = FindById(resourceId);
            }
            catch (PFEException)
            {
                resource = new Resource {Id = 0};
            }

            var typeDictionary = new Dictionary<string, Type>();

            DataColumnCollection dcCollection = dataRow.Table.Columns;

            foreach (PropertyInfo propertyInfo in resource.GetType().GetProperties())
            {
                foreach (
                    FieldInfoAttribute fieldInfoAttribute in
                        propertyInfo.GetCustomAttributes(typeof (FieldInfoAttribute), false)
                                    .Cast<FieldInfoAttribute>()
                                    .Where(
                                        fieldInfo =>
                                        dcCollection.Contains(fieldInfo.Id.ToString(CultureInfo.InvariantCulture)))
                    )
                {
                    int fieldId = fieldInfoAttribute.Id;

                    string columnName = fieldId.ToString(CultureInfo.InvariantCulture);
                    object value = dataRow[columnName];

                    bool valueIsNull = false;

                    if (value == null || value == DBNull.Value) valueIsNull = true;
                    else if (value is string && string.IsNullOrEmpty((string) value)) valueIsNull = true;

                    string propertyName = propertyInfo.Name;

                    if (!propertyName.Equals("Id") && !propertyName.Equals("CustomFields") &&
                        !propertyName.Equals("Permissions"))
                    {
                        if (!valueIsNull)
                        {
                            if (!typeDictionary.ContainsKey(columnName))
                            {
                                Type propertyType = propertyInfo.PropertyType;

                                propertyType = propertyType.IsGenericType &&
                                               propertyType.GetGenericTypeDefinition() == typeof (Nullable<>)
                                                   ? Nullable.GetUnderlyingType(propertyType)
                                                   : propertyType;

                                typeDictionary.Add(columnName, propertyType);
                            }
                            propertyInfo.SetValue(resource, GetUnboxedValue(value, typeDictionary[columnName]), null);
                        }
                        else
                        {
                            propertyInfo.SetValue(resource, null, null);
                        }
                    }
                    else if (propertyName.Equals("Permissions"))
                    {
                        if (!valueIsNull)
                        {
                            resource.PermissionsDictionary.Clear();

                            Dictionary<string, bool> dictionary =
                                ((string) value).Split(',')
                                                .Select(perm => perm.Split(':'))
                                                .ToDictionary(p => p[0], p => bool.Parse(p[1]));

                            foreach (Group perm in permissionGroups)
                            {
                                string name = perm.Name;

                                if (!dictionary.ContainsKey(name)) continue;

                                if (dictionary[name])
                                {
                                    resource.PermissionsDictionary.Add(perm.Id, name + "|ADD");
                                }
                                else
                                {
                                    resource.PermissionsDictionary.Add(perm.Id, name + "|DEL");
                                }
                            }
                        }
                        else
                        {
                            resource.PermissionsDictionary.Clear();
                        }
                    }
                }
            }

            foreach (IField customField in from DataColumn dataColumn in dcCollection
                                           select dataColumn.ColumnName
                                           into columnName
                                           where
                                               !columnName.Equals("Id") && !columnName.Equals("ExtId") &&
                                               !columnName.Equals("Username") && !columnName.Equals("DataId")
                                           let fieldId = Convert.ToInt32(columnName) where fieldId >= 20000
                                           let value = dataRow[columnName] where value != DBNull.Value
                                           select GetCustomField(fieldId, string.Empty, value)
                                           into customField where !resource.CustomFields.Contains(customField)
                                           select customField)
            {
                List<IField> fields = resource.CustomFields.ToList();

                int fieldIndex = fields.FindIndex(f => f.Id == customField.Id);

                if (fieldIndex > -1)
                {
                    fields.RemoveAt(fieldIndex);

                    if (!(customField is CodeField) || ((CodeField) customField).GetCode() != -1)
                    {
                        fields.Add(customField);
                    }

                    resource.CustomFields = fields;
                }
                else
                {
                    resource.CustomFields.Add(customField);
                }
            }

            return resource;
        }

        /// <summary>
        ///     Determines whether this instance can delete the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        internal string CanDelete(Resource resource, out string message)
        {
            var stringBuilder = new StringBuilder();

            if (IsResourceInUse(resource, stringBuilder, 1))
            {
                var dictionary = new Dictionary<string, List<string>>();

                var customFieldsDataTable = new DataTable();

                const string query =
                    @"SELECT FA_NAME AS Name, FA_FIELD_ID AS FieldId, FA_TABLE_ID AS TableId, FA_FIELD_IN_TABLE AS FieldInTable 
                      FROM EPGC_FIELD_ATTRIBS WHERE FA_FORMAT = 7 AND (FA_TABLE_ID = @TableId1 OR FA_TABLE_ID = @TableId2) ORDER BY FieldId";

                using (var sqlCommand = new SqlCommand(query, _sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@TableId1", (int) CustomFieldTable.PortfolioINT);
                    sqlCommand.Parameters.AddWithValue("@TableId2", (int) CustomFieldTable.ResourceINT);

                    sqlCommand.CommandType = CommandType.Text;

                    if (_sqlConnection.State == ConnectionState.Open)
                    {
                        _sqlConnection.Close();
                    }

                    _sqlConnection.Open();

                    customFieldsDataTable.Load(sqlCommand.ExecuteReader());

                    _sqlConnection.Close();
                }

                foreach (DataRow dataRow in customFieldsDataTable.Rows)
                {
                    object tableId = dataRow["TableId"];

                    if (tableId == null || tableId == DBNull.Value) continue;

                    string tableName;
                    string fieldName;

                    CalculateTableFieldName((int) dataRow["FieldId"], (int) tableId, out tableName,
                                            out fieldName);

                    if ((int) tableId == (int) CustomFieldTable.ResourceINT)
                    {
                        string sql =
                            string.Format(
                                "SELECT TOP 2 RES_NAME FROM EPGC_RESOURCE_INT_VALUES V INNER JOIN EPG_RESOURCES R ON R.WRES_ID = V.WRES_ID WHERE V.{0} = @ResourceId",
                                fieldName);

                        GetResourceCustomFieldValues(resource, dictionary, fieldName, sql, "RES_NAME", "Resource");
                    }
                    else
                    {
                        string sql =
                            string.Format(
                                "SELECT TOP 2 PROJECT_NAME FROM EPGP_PROJECT_INT_VALUES V INNER JOIN EPGP_PROJECTS P ON P.PROJECT_ID = V.PROJECT_ID WHERE V.{0} = @ResourceId",
                                fieldName);

                        GetResourceCustomFieldValues(resource, dictionary, fieldName, sql, "PROJECT_NAME", "PI");

                        sql =
                            string.Format(
                                "SELECT TOP 2 LV_VALUE AS PROGRAM_NAME FROM EPGP_PROG_INT_VALUES V INNER JOIN EPGP_LOOKUP_VALUES P ON P.LV_UID = V.PROG_UID WHERE V.{0} = @ResourceId",
                                fieldName);

                        GetResourceCustomFieldValues(resource, dictionary, fieldName, sql, "PROGRAM_NAME",
                                                     "Program Data");
                    }
                }

                if (dictionary.Count > 0)
                {
                    foreach (var keyValuePair in dictionary)
                    {
                        string type = keyValuePair.Key.Split('.')[1];

                        stringBuilder.AppendLine(string.Format("{0}: \t {1}", type,
                                                               string.Join(", ", keyValuePair.Value.ToArray())));
                    }
                }

                message = stringBuilder.ToString();

                return "NO";
            }

            stringBuilder = new StringBuilder();

            if (IsResourceInUse(resource, stringBuilder, 2))
            {
                message = stringBuilder.ToString();
                return "WITH WARNING";
            }

            message = string.Empty;

            return "YES";
        }

        /// <summary>
        ///     Gets the resource id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="externalUId">The external U id.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        internal int GetResourceId(int? id, string externalUId, string username)
        {
            object resourceId = null;

            if (id.HasValue)
            {
                resourceId = FindIdBy("WRES_ID", id.Value);
            }

            if (resourceId == null && !string.IsNullOrEmpty(externalUId))
            {
                resourceId = FindIdBy("WRES_EXT_UID", externalUId);
            }

            if (resourceId == null && !string.IsNullOrEmpty(username))
            {
                resourceId = FindIdBy("WRES_NT_ACCOUNT", username);
            }

            if (resourceId != null)
            {
                return Convert.ToInt32(resourceId);
            }

            throw new PFEException((int) PFEError.GetResourceId, "Cannot find the requested resource in PFE.");
        }

        #endregion Methods 

        #region Implementation of IRepository<Resource>

        /// <summary>
        ///     Adds the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns></returns>
        public int Add(Resource resource)
        {
            ValidateResource(resource);

            resource.Id = GenerateNewResourceId();

            InsertBasicResourceInformation(resource);

            Update(resource);

            return resource.Id;
        }


        /// <summary>
        ///     Updates the specified resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        public void Update(Resource resource)
        {
            ValidateResource(resource);

            if (!resource.IsGeneric.HasValue || resource.IsGeneric.Value == 0)
            {
                resource.UseNTLogin = 1;
                resource.CanLogin = 1;
                resource.IsResource = 1;
            }
            else if (resource.IsGeneric.Value == 1)
            {
                resource.UseNTLogin = 0;
                resource.CanLogin = 0;
                resource.IsResource = 0;
            }

            DataTable changedProperties = GetChangedProperties(resource);

            if (changedProperties.Rows.Count <= 0) return;

            UpdateGeneralInformation(resource.Id, changedProperties);

            foreach (DataRow dataRow in changedProperties.Select("PropertyName = 'CostCategoryRoleId'"))
            {
                int costCategoryId = 0;

                try
                {
                    costCategoryId = (int) dataRow["NewValue"];
                }
                catch (Exception)
                {
                }

                if (costCategoryId != 0) UpdateCostCategory(resource, costCategoryId);
            }

            foreach (DataRow dataRow in changedProperties.Select("FieldId >= 3200 AND FieldId <= 3203"))
            {
                UpdateGroups(resource, dataRow);
            }

            DataRow[] changedCustomFields = changedProperties.Select("FieldId >= 20000");
            if (changedCustomFields.Any())
            {
                UpdateCustomFields(resource, changedCustomFields);
            }
        }

        [Obsolete("Resource repository only supports Delete(resource, currentUserId)")]
        public void Delete(Resource entity)
        {
            throw new NotImplementedException("Resource repository only supports Delete(resource, currentUserId)");
        }

        /// <summary>
        ///     Finds the id by.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int? FindIdBy(string key, object value)
        {
            object resourceId;

            using (var sqlCommand = new SqlCommand(@"PFE_SP_GetResourceIdBy", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("@Col", SqlDbType.VarChar) {Value = key});
                sqlCommand.Parameters.Add(new SqlParameter("@Value", SqlDbType.VarChar) {Value = value});

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                resourceId = sqlCommand.ExecuteScalar();

                _sqlConnection.Close();
            }

            return resourceId != DBNull.Value ? (int?) resourceId : null;
        }

        [Obsolete("Resource repository does not support Find All operation.")]
        public IEnumerable<Resource> FindAll()
        {
            throw new NotImplementedException("Resource repository does not support Find All operation.");
        }

        /// <summary>
        ///     Finds the resource by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Resource FindById(int id)
        {
            int? resourceId = FindIdBy("WRES_ID", id);

            if (!resourceId.HasValue)
            {
                throw new PFEException((int) PFEError.FindById, "Cannot find the requested resource in PFE.");
            }

            var resource = new Resource();

            GetGeneralInformation(id, ref resource);

            GetGroups(id, ref resource);

            GetCustomFields(id, ref resource);

            return resource;
        }

        #endregion
    }
}