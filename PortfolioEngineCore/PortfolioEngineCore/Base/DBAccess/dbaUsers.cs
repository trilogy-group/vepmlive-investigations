using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace PortfolioEngineCore
{
    public class dbaUsers
    {
        private const int CodeId = 4;
        private const int ResorceId = 7;
        public const int ErrorCode = 99871;
        private const int WorkitemStartDateId = 9936;
        private const int ProjectNameId = 9900;
        private const int ProjectStartDateId = 9901;
        private const int ProjectFinishDateId = 9902;

        private const int StageNameId = 9911;
        private const int CreatedById = 9920;
        private const int StageOwnerId = 9922;
        private const int WProjectId = 9924;
        private const int ItemManagerId = 9925;
        private const int ProjectPriorityId = 9928;
        private const int ScheduleManagerId = 9930;
        private const int DoubleTypeId = 203;
        private const int DateTypeId = 205;
        private const int StringTypeId2 = 202;
        private const int StringTypeId1 = 201;
        private const int GroupPermissionStatus = 99925;
        private static int CCStatus = 99999;

        private const string ValueName = "Value";
        private const string WorkitemStartDate = "WORKITEM_START_DATE";
        private const string ScheduleManager = "ScheduleManager";
        private const string ProjectName = "PROJECT_NAME";
        private const string ProjectStartDate = "PROJECT_START_DATE";
        private const string ProjectFinishDate = "PROJECT_FINISH_DATE";
        private const string CreatedBy = "CreatedBy";
        private const string ProjectCreated = "PROJECT_CREATED";
        private const string StageOwner = "StageOwner";
        private const string WProject = "WPROJ_ID";
        private const string ItemManager = "ItemManager";
        private const string ProjectPriority = "PROJECT_PRIORITY";
        private const string StageName = "STAGE_NAME";

        private const string StringType = "s";
        private const string DateType = "d";
        private const string IntegerType = "i";
        
        private const string IdName = "ID";
        private const string Field = "Field";
        private const string DoubleType = "dbl";
        private const string ProjectIdName = "PROJECT_ID";
        private const string ProjectExtUid = "PROJECT_EXT_UID";
        private const string PortfolioItem = "PortfolioItem";
        private const string ItemId = "ItemID";
        private const string Team = "Team";
        private const int LinkedScheduleId = 9224;
        private const int ProgramGroupId = 9960;
        private const string WresId = "WRES_ID";
        private const string GroupName = "GROUP_NAME";
        private const string LvUid = "LV_UID";
        private const string LvFullvalue = "LV_FULLVALUE";
        private const string FaFieldId = "FA_FIELD_ID";
        private const string FaName = "FA_NAME";
        private const string FaFormat = "FA_FORMAT";
        private const string FaTableId = "FA_TABLE_ID";
        private const string FaFieldInTable = "FA_FIELD_IN_TABLE";
        private const string FaLookupUid = "FA_LOOKUP_UID";
        private const string FieldId = "FIELD_ID";
        private const string FieldName = "FIELD_NAME";
        private const string FieldFormat = "FIELD_FORMAT";
        

        public static StatusEnum ExecuteSQLSelect(SqlCommand oCommand, out SqlDataReader reader)
        {
            if (oCommand == null)
            {
                throw new ArgumentNullException(nameof(oCommand));
            }
            var eStatus = StatusEnum.rsSuccess;
            reader = null;
            try
            {
                reader = oCommand.ExecuteReader();
            }
            catch(Exception ex)
            {
                eStatus = (StatusEnum)99871;
                Trace.TraceError("Error: {0}", ex);
            }
            return eStatus;
        }
        public static StatusEnum ExportPIInfo(DBAccess dbAccess, string projectIds, out string result)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var status = StatusEnum.rsSuccess;

            // see if we have a list of mapped fields, if we do the we will use them to limit the fields we pass
            var bMappedFields = false;

            var lookupIds = new List<int>();
            var standardFields = new SortedList<int, EPKItem>();
            var customFields = new SortedList<int, EPKCustomField>();
            var mvsFields = new SortedList<int, IDictionary<int, string>>();
            var fields = new StringBuilder();
            var joins = new StringBuilder();

            AddStandartPortfolioFields(dbAccess, standardFields, bMappedFields);
            var bNeedResources = AddCustomPortfolioFields(dbAccess, bMappedFields, customFields, lookupIds);
            var clnLookupValues = GetLookupValues(dbAccess, lookupIds);
            if (standardFields.ContainsKey(ProgramGroupId))
            {
                AddProgramGroups(dbAccess, projectIds, mvsFields);
            }

            var resources = GetResources(dbAccess, bNeedResources);
            AddStandartFields(fields, joins, standardFields);
            AddCustomField(customFields, fields, joins);

            var portfolioItems = ReadyToPutTheBeastTogetherAndReadSomeData(
                dbAccess,
                projectIds,
                fields.ToString(),
                joins.ToString(),
                standardFields,
                mvsFields,
                customFields,
                clnLookupValues,
                resources);

            result = portfolioItems.XML();
            return status;
        }

        private static void AddStandartPortfolioFields(DBAccess dbAccess, IDictionary<int, EPKItem> standardFields, bool bMappedFields)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            SqlDataReader reader;
            // We want these fields regardless so we'll just add them - they won't be mapped
            var cmdText = new StringBuilder();
            cmdText.Append("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS")
                .Append(" Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID");
            using (var command = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                if (ExecuteSQLSelect(command, out reader) == StatusEnum.rsSuccess)
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = DBAccess.ReadIntValue(reader[FieldId]);
                            var epkItem = new EPKItem
                            {
                                ID = id,
                                Name = DBAccess.ReadStringValue(reader[FieldName]),
                                Value = DBAccess.ReadIntValue(reader[FieldFormat])
                            };

                            standardFields.Add(id, epkItem);
                        }
                    }
                }
            }

            cmdText.Clear();
            //  now read marked list from EPGT_FIELDS
            cmdText.Append("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f");
            if (bMappedFields)
            {
                cmdText.Append(" Join EPG_WE_MAPPING m On f.FIELD_ID=m.WEM_EPK_FIELD_ID And WEM_ENTITY=20");
            }
            cmdText.Append(" Where FIELD_EXPORT=1 ORDER BY FIELD_ID");
            using (var command = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                if (ExecuteSQLSelect(command, out reader) == StatusEnum.rsSuccess)
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = DBAccess.ReadIntValue(reader[FieldId]);
                            var epkItem = new EPKItem
                            {
                                ID = id,
                                Name = DBAccess.ReadStringValue(reader[FieldName]),
                                Value = DBAccess.ReadIntValue(reader[FieldFormat])
                            };
                            standardFields.Add(id, epkItem);
                        }
                    }
                }
            }
        }

        private static bool AddCustomPortfolioFields(
            DBAccess dbAccess,
            bool bMappedFields,
            IDictionary<int, EPKCustomField> customFields,
            ICollection<int> lookupIds)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (customFields == null)
            {
                throw new ArgumentNullException(nameof(customFields));
            }
            if (lookupIds == null)
            {
                throw new ArgumentNullException(nameof(lookupIds));
            }

            var bNeedResources = false;
            var cmdText = new StringBuilder();
            cmdText.Append("Select * From EPGC_FIELD_ATTRIBS f");
            if (bMappedFields)
            {
                cmdText.Append(" Join EPG_WE_MAPPING m On f.FA_FIELD_ID=m.WEM_EPK_FIELD_ID And WEM_ENTITY=20");
            }
            cmdText.Append(" Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID");

            using (var oCommand = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                SqlDataReader reader;
                if (ExecuteSQLSelect(oCommand, out reader) == StatusEnum.rsSuccess)
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = DBAccess.ReadIntValue(reader[FaFieldId]);
                            var customField = new EPKCustomField
                            {
                                ID = id,
                                Name = DBAccess.ReadStringValue(reader[FaName]),
                                Fieldtype = DBAccess.ReadIntValue(reader[FaFormat]),
                                CFTable = DBAccess.ReadIntValue(reader[FaTableId]),
                                CFField = DBAccess.ReadIntValue(reader[FaFieldInTable]),
                                LookupID = DBAccess.ReadIntValue(reader[FaLookupUid])
                            };
                            customFields.Add(id, customField);
                            // if it is a Code then add the Lookup to those we need to go get 
                            if (customField.Fieldtype == CodeId && customField.LookupID > 0 && !lookupIds.Contains(id))
                            {
                                lookupIds.Add(id);
                            }
                            if (customField.Fieldtype == ResorceId)
                            {
                                bNeedResources = true;
                            }
                        }
                    }
                }
            }
            return bNeedResources;
        }

        private static IDictionary<int, string> GetLookupValues(DBAccess dbAccess, IEnumerable<int> lookupIds)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (lookupIds == null)
            {
                throw new ArgumentNullException(nameof(lookupIds));
            }
            var lookupValues = new SortedList<int, string>();
            var lookupList = new StringBuilder();

            foreach (var lookupId in lookupIds)
            {
                if (lookupList.Length > 0)
                {
                    lookupList.AppendFormat(",{0}", lookupId);
                }
                else
                {
                    lookupList.Append(lookupId);
                }
            }

            // get the full(?) values for the lookup tables
            if (lookupList.Length > 0)
            {
                using (var command = new SqlCommand("PPM_SP_ReadLookupValuesByLookup", dbAccess.Connection))
                {
                    command.Parameters.AddWithValue("sList", lookupList.ToString());
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var intValue = DBAccess.ReadIntValue(reader[LvUid]);
                            var stringValue = DBAccess.ReadStringValue(reader[LvFullvalue]);
                            lookupValues.Add(intValue, stringValue);
                        }
                    }
                }
            }
            return lookupValues;
        }

        private static void AddProgramGroups(DBAccess dbAccess, string projectIds, IDictionary<int, IDictionary<int, string>> mvsFields)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            if (mvsFields == null)
            {
                throw new ArgumentNullException(nameof(mvsFields));
            }
            var prevProjectId = 0;
            var sGroups = string.Empty;
            var cmdText = new StringBuilder();
            cmdText.Append("Select pg.PROG_UID,PROJECT_ID,LV_FULLVALUE as GROUP_NAME From EPGP_PI_PROGS pg")
                .Append(" Join EPGP_LOOKUP_VALUES lv on lv.LV_UID=pg.PROG_UID");
            if (projectIds.Length > 0)
            {
                cmdText.AppendFormat(" JOIN dbo.EPG_FN_ConvertListToTable(N'{0}') LT on PROJECT_ID=LT.TokenVal", projectIds);
            }
            cmdText.Append(" Order By PROJECT_ID,pg.FIELD_ID");

            using (var command = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                SqlDataReader reader;
                if (ExecuteSQLSelect(command, out reader) == StatusEnum.rsSuccess)
                {
                    var mvValues = new SortedList<int, string>();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var projectId = DBAccess.ReadIntValue(reader[WresId]);
                            var stringValue = DBAccess.ReadStringValue(reader[GroupName]);
                            if (projectId != prevProjectId && prevProjectId > 0)
                            {
                                if (!mvValues.ContainsKey(prevProjectId))
                                {
                                    mvValues.Add(prevProjectId, sGroups);
                                }
                                sGroups = string.Empty;
                            }
                            if (sGroups.Length > 0)
                            {
                                sGroups = sGroups + ", " + stringValue;
                            }
                            else
                            {
                                sGroups = stringValue;
                            }
                            prevProjectId = projectId;
                        }
                    }

                    if (sGroups.Length > 0 && !mvValues.ContainsKey(prevProjectId))
                    {
                        mvValues.Add(prevProjectId, sGroups);
                    }
                    mvsFields.Add(ProgramGroupId, mvValues);
                }
            }
        }

        /// <summary>
        /// get a resources collection if we need to resolve any Custom Fields
        /// </summary>
        private static IDictionary<int, string> GetResources(DBAccess dbAccess, bool bNeedResources)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var resources = new SortedList<int, string>();
            if (!bNeedResources)
            {
                return resources;
            }

            var cmdText = "Select WRES_ID,RES_NAME From EPG_RESOURCES";
            using (var command = new SqlCommand(cmdText, dbAccess.Connection))
            {
                SqlDataReader reader;
                if (ExecuteSQLSelect(command, out reader) == StatusEnum.rsSuccess)
                {
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var id = DBAccess.ReadIntValue(reader[WresId]);
                            var name = DBAccess.ReadStringValue(reader["RES_NAME"]);
                            resources.Add(id, name);
                        }
                    }
                }
            }
            return resources;
        }

        private static void AddStandartFields(StringBuilder fields, StringBuilder joins, IDictionary<int, EPKItem> standardFields)
        {
            if (fields == null)
            {
                throw new ArgumentNullException(nameof(fields));
            }
            if (joins == null)
            {
                throw new ArgumentNullException(nameof(joins));
            }
            if (standardFields == null)
            {
                throw new ArgumentNullException(nameof(standardFields));
            }

            fields.Append("pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,")
                .Append("PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE");
            joins.Append(" ");

            if (standardFields.ContainsKey(LinkedScheduleId)) //  Linked Schedule
            {
                fields.Append(",ps.WPROJ_ID");
                joins.Append(" Left Join EPGX_PROJECT_VERSIONS ps On ps.PROJECT_ID=pi.PROJECT_ID");
            }
            if (standardFields.ContainsKey(StageNameId)) //  Stage
            {
                fields.Append(",sg.STAGE_NAME");
                joins.Append(" Left Join EPGP_STAGES sg On sg.STAGE_ID=pi.PROJECT_STAGE_ID");
            }
            if (standardFields.ContainsKey(StageOwnerId)) //  Stage Owner
            {
                fields.Append(",r1.RES_NAME as StageOwner");
                joins.Append(" Left Join EPG_RESOURCES r1 On r1.WRES_ID=pi.PROJECT_OWNER");
            }
            if (standardFields.ContainsKey(ItemManagerId)) //  Item Manager
            {
                fields.Append(",r2.RES_NAME as ItemManager");
                joins.Append(" Left Join EPG_RESOURCES r2 On r2.WRES_ID=pi.PROJECT_MANAGER");
            }
            if (standardFields.ContainsKey(ScheduleManagerId)) //  Schedule Manager
            {
                fields.Append(",r3.RES_NAME as ScheduleManager");
                joins.Append(" Left Join EPG_RESOURCES r3 On r3.WRES_ID=pi.PROJECT_PLAN_OWNER");
            }
            if (standardFields.ContainsKey(CreatedById)) //  Created By
            {
                fields.Append(",r4.RES_NAME as CreatedBy");
                joins.Append(" Left Join EPG_RESOURCES r4 On r4.WRES_ID=pi.PROJECT_CREATEDBY");
            }
        }

        private static void AddCustomField(IDictionary<int, EPKCustomField> customFields, StringBuilder fields, StringBuilder joins)
        {
            if (customFields == null)
            {
                throw new ArgumentNullException(nameof(customFields));
            }
            if (fields == null)
            {
                throw new ArgumentNullException(nameof(fields));
            }
            if (joins == null)
            {
                throw new ArgumentNullException(nameof(joins));
            }
            var isStringType1 = false;
            var isStringType2 = false;
            var isDoubleType = false;
            var isDateType = false;

            foreach (var customField in customFields)
            {
                string tableName;
                string fieldName;
                switch (customField.Value.CFTable)
                {
                    case StringTypeId1:
                        if (EPKClass01.GetTableAndField(customField.Value.CFTable, customField.Value.CFField, out tableName, out fieldName))
                        {
                            fields.AppendFormat(",{0}", fieldName);
                            if (!isStringType1)
                            {
                                joins.AppendFormat(" LEFT JOIN {0} x1 ON x1.PROJECT_ID=pi.PROJECT_ID", tableName);
                            }
                            customField.Value.FieldName = fieldName;
                            isStringType1 = true;
                        }
                        break;
                    case StringTypeId2:
                        if (EPKClass01.GetTableAndField(customField.Value.CFTable, customField.Value.CFField, out tableName, out fieldName))
                        {
                            fields.AppendFormat(",{0}", fieldName);
                            if (!isStringType2)
                            {
                                joins.AppendFormat(" LEFT JOIN {0} x2 ON x2.PROJECT_ID=pi.PROJECT_ID", tableName);
                            }
                            customField.Value.FieldName = fieldName;
                            isStringType2 = true;
                        }
                        break;
                    case DoubleTypeId:
                        if (EPKClass01.GetTableAndField(customField.Value.CFTable, customField.Value.CFField, out tableName, out fieldName))
                        {
                            fields.AppendFormat(",{0}", fieldName);
                            if (!isDoubleType)
                            {
                                joins.AppendFormat(" LEFT JOIN {0} x3 ON x3.PROJECT_ID=pi.PROJECT_ID", tableName);
                            }
                            customField.Value.FieldName = fieldName;
                            isDoubleType = true;
                        }
                        break;
                    case DateTypeId:
                        if (EPKClass01.GetTableAndField(customField.Value.CFTable, customField.Value.CFField, out tableName, out fieldName))
                        {
                            fields.AppendFormat(",{0}", fieldName);
                            if (!isDateType)
                            {
                                joins.AppendFormat(" LEFT JOIN {0} x5 ON x5.PROJECT_ID=pi.PROJECT_ID", tableName);
                            }
                            customField.Value.FieldName = fieldName;
                            isDateType = true;
                        }
                        break;
                    default: 
                        // nothing here
                        break;
                }
            }
        }

        private static CStruct ReadyToPutTheBeastTogetherAndReadSomeData(
            DBAccess dbAccess,
            string projectIds,
            string sFields,
            string sJoins,
            IDictionary<int, EPKItem> standardFields,
            IDictionary<int, IDictionary<int, string>> mvsFields,
            IDictionary<int, EPKCustomField> customFields,
            IDictionary<int, string> lookupValues,
            IDictionary<int, string> resources)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var cmdText = new StringBuilder();
            cmdText.AppendFormat("SELECT {0} FROM EPGP_PROJECTS pi {1}", sFields, sJoins);
            if (projectIds.Length > 0)
            {
                cmdText.AppendFormat(" JOIN dbo.EPG_FN_ConvertListToTable(N'{0}') LT on pi.PROJECT_ID=LT.TokenVal", projectIds);
            }
            cmdText.Append(" Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID");

            var portfolioItems = new CStruct();
            portfolioItems.Initialize("PortfolioItems");
            portfolioItems.CreateStringAttr("Key", "EPK");

            using (var command = new SqlCommand(cmdText.ToString(), dbAccess.Connection))
            {
                SqlDataReader reader;
                if (ExecuteSQLSelect(command, out reader) == StatusEnum.rsSuccess)
                {
                    using (reader)
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        reader.Close();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ProcessDataRow(dbAccess, row, portfolioItems, standardFields, mvsFields, customFields, lookupValues, resources);
                        }
                    }
                }
            }
            return portfolioItems;
        }

        private static void ProcessDataRow(
            DBAccess dbAccess,
            DataRow row,
            CStruct portfolioItems,
            IDictionary<int, EPKItem> standardFields,
            IDictionary<int, IDictionary<int, string>> mvsFields,
            IDictionary<int, EPKCustomField> customFields,
            IDictionary<int, string> lookupValues,
            IDictionary<int, string> resources)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            if (portfolioItems == null)
            {
                throw new ArgumentNullException(nameof(portfolioItems));
            }
            if (standardFields == null)
            {
                throw new ArgumentNullException(nameof(standardFields));
            }
            var projectId = DBAccess.ReadIntValue(row[ProjectIdName]);
            var projectExtId = DBAccess.ReadStringValue(row[ProjectExtUid]);
            if (projectId <= 0 || projectExtId.Length <= 0)
            {
                return;
            }
            var portfolioItem = portfolioItems.CreateSubStruct(PortfolioItem);
            portfolioItem.CreateStringAttr(ItemId, projectExtId);

            //  get the team -  another SELECT withing the main one is ok? I guess so but not if using SQLDataREader by the way
            var steamlist = GetStreamList(dbAccess, projectId);
            if (steamlist.Length > 0)
            {
                var subStruct = portfolioItem.CreateSubStruct(Field);
                subStruct.CreateStringAttr(IdName, Team);
                subStruct.CreateStringAttr(ValueName, steamlist);
            }

            string xmlType;
            string stringValue;
            DateTime dateValue;
            double doubleValue = 0;
            int intValue;

            foreach (var standardField in standardFields)
            {
                xmlType = GetValues(standardField.Value.ID, row, projectId, mvsFields, out stringValue, out intValue, out dateValue);

                if (xmlType.Length > 0)
                {
                    CreateStandartAttribute(portfolioItem, standardField.Value.ID, xmlType, dateValue, intValue, doubleValue, stringValue);
                }
            }

            foreach (var customField in customFields)
            {
                xmlType = GetValues(customField.Value, row, lookupValues, resources, out stringValue, out intValue, out doubleValue, out dateValue);
                if (xmlType.Length > 0)
                {
                    CreateCustomAttribute(portfolioItem, customField.Value.ID, xmlType, dateValue, intValue, doubleValue, stringValue);
                }
            }
        }

        private static string GetStreamList(DBAccess dbAccess,int projectId)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            SqlDataReader reader;
            var cmdText = "Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ";
            var oCommand = new SqlCommand(cmdText, dbAccess.Connection);
            oCommand.Parameters.AddWithValue("@PROJECT_ID", projectId);

            if (ExecuteSQLSelect(oCommand, out reader) != StatusEnum.rsSuccess)
            {
                return string.Empty;
            }

            var steamlist = new StringBuilder();
            using (reader)
            {
                while (reader.Read())
                {
                    var steamMember = DBAccess.ReadIntValue(reader[WresId]).ToString();
                    if (steamlist.Length == 0)
                    {
                        steamlist.Append(steamMember);
                    }
                    else
                    {
                        steamlist.AppendFormat(",{0}", steamMember);
                    }
                }
            }
            return steamlist.ToString();
        }

        private static void CreateCustomAttribute(
            CStruct xPortfolioItem,
            int fieldValueID,
            string xmlType,
            DateTime dateValue,
            int intValue, double doubleValue,
            string stringValue)
        {
            if (xPortfolioItem == null)
            {
                throw new ArgumentNullException(nameof(xPortfolioItem));
            }
            var xField = xPortfolioItem.CreateSubStruct(Field);
            xField.CreateIntAttr(IdName, fieldValueID);
            switch (xmlType)
            {
                case DateType:
                    xField.CreateDateAttr(ValueName, dateValue);
                    break;
                case IntegerType:
                    xField.CreateIntAttr(ValueName, intValue);
                    break;
                case DoubleType:
                    xField.CreateDoubleAttr(ValueName, doubleValue);
                    break;
                default:
                    xField.CreateStringAttr(ValueName, stringValue);
                    break;
            }
        }

        private static string GetValues(
            EPKCustomField customField,
            DataRow row,
            IDictionary<int, string> lookupValues,
            IDictionary<int, string> resources,
            out string stringValue,
            out int intValue,
            out double doubleValue,
            out DateTime dateValue)
        {
            if (customField == null)
            {
                throw new ArgumentNullException(nameof(customField));
            }
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            var xmlType = string.Empty;

            stringValue = string.Empty;
            dateValue = DateTime.MinValue;
            doubleValue = 0;
            intValue = 0;

            switch (customField.CFTable)
            {
                case StringTypeId1:
                    if (customField.Fieldtype == CodeId)
                    {
                        intValue = DBAccess.ReadIntValue(row[customField.FieldName]);
                        stringValue = GetLookupValue(lookupValues, intValue);
                        xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    }
                    else if (customField.Fieldtype == ResorceId)
                    {
                        intValue = DBAccess.ReadIntValue(row[customField.FieldName]);
                        stringValue = GetLookupValue(resources, intValue);
                        xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    }
                    else
                    {
                        xmlType = IntegerType;
                        intValue = DBAccess.ReadIntValue(row[customField.FieldName]);
                    }
                    break;
                case StringTypeId2:
                    stringValue = DBAccess.ReadStringValue(row[customField.FieldName]);
                    xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    break;
                case DoubleTypeId:
                    xmlType = DoubleType;
                    doubleValue = DBAccess.ReadDoubleValue(row[customField.FieldName]);
                    break;
                case DateTypeId:
                    dateValue = DBAccess.ReadDateValue(row[customField.FieldName]);
                    xmlType = dateValue == DateTime.MinValue ? string.Empty : DateType;
                    break;
                default:
                    xmlType = string.Empty;
                    break;
            }
            return xmlType;
        }

        private static void CreateStandartAttribute(
            CStruct portfolioItem,
            int fieldValueId,
            string xmlType,
            DateTime dateValue,
            int intValue,
            double doubleValue,
            string stringValue)
        {
            if (portfolioItem == null)
            {
                throw new ArgumentNullException(nameof(portfolioItem));
            }
            var subStruct = portfolioItem.CreateSubStruct(Field);
            subStruct.CreateIntAttr(IdName, fieldValueId);
            switch (xmlType)
            {
                case DateType:
                    subStruct.CreateDateAttr(ValueName, dateValue);
                    break;
                case IntegerType:
                    subStruct.CreateIntAttr(ValueName, intValue);
                    break;
                case DoubleType:
                    subStruct.CreateDoubleAttr(ValueName, doubleValue);
                    break;
                default:
                    subStruct.CreateStringAttr(ValueName, stringValue);
                    break;
            }
        }

        private static string GetValues(
            int fieldValueId,
            DataRow row,
            int projectId,
            IDictionary<int, IDictionary<int, string>> mvsFields,
            out string stringValue,
            out int intValue,
            out DateTime dateValue)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            stringValue = string.Empty;
            dateValue = DateTime.MinValue;
            intValue = 0;
            string xmlType;

            switch (fieldValueId)
            {
                case ProjectNameId:
                    xmlType = StringType;
                    stringValue = DBAccess.ReadStringValue(row[ProjectName]);
                    break;
                case 9903:
                    xmlType = IntegerType;
                    intValue = projectId;
                    break;
                case ProjectStartDateId:
                    dateValue = DBAccess.ReadDateValue(row[ProjectStartDate]);
                    xmlType = dateValue == DateTime.MinValue ? string.Empty : DateType;
                    break;
                case ProjectFinishDateId:
                    dateValue = DBAccess.ReadDateValue(row[ProjectFinishDate]);
                    xmlType = dateValue == DateTime.MinValue ? string.Empty : DateType;
                    break;
                case StageNameId:
                    stringValue = DBAccess.ReadStringValue(row[StageName]);
                    xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    break;
                case 9918:
                    xmlType = string.Empty;
                    break;
                case CreatedById:
                    stringValue = DBAccess.ReadStringValue(row[CreatedBy]);
                    xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    break;
                case 9921:
                    dateValue = DBAccess.ReadDateValue(row[ProjectCreated]);
                    xmlType = dateValue == DateTime.MinValue ? string.Empty : DateType;
                    break;
                case StageOwnerId:
                    stringValue = DBAccess.ReadStringValue(row[StageOwner]);
                    xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    break;
                case WProjectId:
                    xmlType = IntegerType;
                    intValue = DBAccess.ReadIntValue(row[WProject]);
                    break;
                case ItemManagerId:
                    stringValue = DBAccess.ReadStringValue(row[ItemManager]);
                    xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    break;
                case ProjectPriorityId:
                    xmlType = IntegerType;
                    intValue = DBAccess.ReadIntValue(row[ProjectPriority]);
                    break;
                case ScheduleManagerId:
                    stringValue = DBAccess.ReadStringValue(row[ScheduleManager]);
                    xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    break;
                case WorkitemStartDateId:
                    dateValue = DBAccess.ReadDateValue(row[WorkitemStartDate]);
                    xmlType = dateValue == DateTime.MinValue ? string.Empty : DateType;
                    break;
                case ProgramGroupId:
                    stringValue = GetMVValue(mvsFields, fieldValueId, projectId);
                    xmlType = stringValue.Length > 0 ? StringType : string.Empty;
                    break;
                default:
                    xmlType = string.Empty;
                    break;
            }
            return xmlType;
        }

        public static string GetMVValue(IDictionary<int, IDictionary<int, string>> mvsFields, int fieldId, int wresId)
        {
            if (mvsFields == null)
            {
                throw new ArgumentNullException(nameof(mvsFields));
            }
            string sValue = string.Empty;

            if (mvsFields.ContainsKey(fieldId))
            {
                var mvValues = mvsFields[fieldId];
                if (mvValues.ContainsKey(wresId))
                {
                    sValue = mvValues[wresId];
                }
            }
            return sValue;
        }
        public static string GetLookupValue(IDictionary<int, string> lookupValues, int id)
        {
            if (lookupValues == null)
            {
                throw new ArgumentNullException(nameof(lookupValues));
            }

            var value = string.Empty;
            if (lookupValues.ContainsKey(id))
            {
                value = lookupValues[id];
            }
            return value;
        }

        public static StatusEnum SelectGroupPermissions(DBAccess dbAccess, int groupId, out DataTable dataTable)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var cmdText = new StringBuilder();
            cmdText.Append("SELECT distinct (p.PERM_UID), p.PERM_ID, p.PERM_LEVEL, p.PERM_NAME, CAST(p.PERM_NOTES AS NVARCHAR(MAX)), p.PERM_WEINCLUDE, ")
                .Append("gp.GROUP_ID From EPG_PERMISSIONS p")
                .Append(" Left Join EPG_GROUP_PERMISSIONS gp On gp.PERM_UID=p.PERM_UID and gp.GROUP_ID=@p1")
                .Append(" Where p.PERM_WEINCLUDE=1")
                .Append(" Order by PERM_ID");

            dbAccess.SelectDataById(cmdText.ToString(), groupId, (StatusEnum)GroupPermissionStatus, out dataTable);
            return dbAccess.Status;
        }

        public static StatusEnum SelectAvailCCs(DBAccess dbAccess, int ctId, out DataTable dataTable)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var cmdText = new StringBuilder();
            cmdText.Append("SELECT cc.*,ac.BC_UID as BC_UID_incl From EPGP_COST_CATEGORIES cc")
                             .Append(" Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID=cc.BC_UID and ac.CT_ID=@p1")
                             .Append(" Order by BC_ID");
            dbAccess.SelectDataById(cmdText.ToString(), ctId, (StatusEnum)CCStatus, out dataTable);
            return dbAccess.Status;
        }

        public static StatusEnum SelectCTCalcs(DBAccess dbAccess, int ctId, out DataTable dataTable)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            var cmdText = new StringBuilder();
            cmdText.Append("SELECT * From EPGP_COST_CALC")
                             .Append(" Where CT_ID=@p1")
                             .Append(" Order by CL_ID");
            dbAccess.SelectDataById(cmdText.ToString(), ctId, (StatusEnum)CCStatus, out dataTable);
            return dbAccess.Status;
        }
    }
}