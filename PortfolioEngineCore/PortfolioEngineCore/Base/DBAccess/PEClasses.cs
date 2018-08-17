using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PortfolioEngineCore
{
    public class EPKItem
    {
        public int ID;
        public string Name;
        public int Value;
    }

    public class EPKCustomField
    {
        public int ID;
        public string Name;
        public string FieldName;
        public int Value;
        public int Fieldtype;
        public int CFTable;
        public int CFField;
        public int LookupID;
    }

    internal class CostCategoryInternal
    {
        public int UID;
        public int ID;
        public int Level;
        public string UOM;
        public int ParentUID;
        public string RollupUOM;
        public bool IsSummary;
        public bool HasData;
        public bool IsAvailable;
    }
    internal class CostValues
    {
        private double[,] quantities;
        private double[,] costs;

        private int lPeriodCount;
        private int lCategoryCount;

        public CostValues(int periodCount, int categoryCount)
        {
            //  category 0 is the TOTAL line
            lPeriodCount = periodCount;
            lCategoryCount = categoryCount + 1;
            quantities = new double[lPeriodCount, lCategoryCount];
            costs = new double[lPeriodCount, lCategoryCount];
        }

        public void SetArrays()
        {
            for (int i = 0; i < lPeriodCount; i++)
            {
                for (int j = 0; j < lCategoryCount; j++)
                {
                    quantities[i, j] = 0;
                    costs[i, j] = 0;
                }
            }
        }

        public void setCost(int period, int category, double costvalue)
        {
            if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                costs[period - 1, category] = costvalue;
        }

        public void incrCost(int period, int category, double costvalue)
        {
            if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                costs[period - 1, category] += costvalue;
        }

        public double getCost(int period, int category)
        {
            if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
            {
                return costs[period - 1, category];
            }
            else
            {
                return 0;
            }
        }

        public void setQuantity(int period, int category, double quantityvalue)
        {
            if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                quantities[period - 1, category] = quantityvalue;
        }
        public void incrQuantity(int period, int category, double quantityvalue)
        {
            if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
                quantities[period - 1, category] += quantityvalue;
        }

        public double getQuantity(int period, int category)
        {
            if ((period > 0 && period <= lPeriodCount) && (category >= 0 && category < lCategoryCount))
            {
                return quantities[period - 1, category];
            }
            else
            {
                return 0;
            }
        }
    }

    internal class CostTotal
    {
        public int CB_ID;
        public int CT_ID;
        public int FIELD_ID;
    }

    public class dbaUsers
    {
        private static string ValueName = "Value";
        private static int CodeId = 4;
        private static int ResorceId = 7;
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
        private const string IdName = "ID";
        private const string Field = "Field";
        private const string DoubleType = "dbl";
        private const int DoubleTypeId = 203;
        private const int DateTypeId = 205;
        private const int StringTypeId2 = 202;
        private const int StringTypeId1 = 201;
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
            StatusEnum eStatus = StatusEnum.rsSuccess;
            reader = null;
            try
            {
                reader = oCommand.ExecuteReader();
            }
            catch
            {
                //eStatus = HandleStatusError(SeverityEnum.Exception, "ExecuteSQL", (StatusEnum)eStatusOnException, ex.Message.ToString());
                eStatus = (StatusEnum)99871;
            }
            return eStatus;
        }
        public static StatusEnum ExportPIInfo(DBAccess dbAccess, string projectIds, out string result)
        {
            var status = StatusEnum.rsSuccess;

            // see if we have a list of mapped fields, if we do the we will use them to limit the fields we pass
            var bMappedFields = false;

            var lookupIds = new List<int>();
            var standardFields = new SortedList<int, EPKItem>();
            var customFields = new SortedList<int, EPKCustomField>();
            var mvsFields = new SortedList<int, SortedList<int, string>>();
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

        private static SortedList<int, string> GetLookupValues(DBAccess dbAccess, IEnumerable<int> lookupIds)
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

        private static void AddProgramGroups(DBAccess dbAccess, string projectIds, IDictionary<int, SortedList<int, string>> mvsFields)
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
            var sGroups = "";
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
                                sGroups = "";
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
        private static SortedList<int, string> GetResources(DBAccess dbAccess, bool bNeedResources)
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
                }
            }
        }

        private static CStruct ReadyToPutTheBeastTogetherAndReadSomeData(
            DBAccess dbAccess,
            string projectIds,
            string sFields,
            string sJoins,
            IDictionary<int, EPKItem> standardFields,
            SortedList<int, SortedList<int, string>> mvsFields,
            IDictionary<int, EPKCustomField> customFields,
            SortedList<int, string> lookupValues,
            SortedList<int, string> resources)
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
            SortedList<int, SortedList<int, string>> mvsFields,
            IDictionary<int, EPKCustomField> customFields,
            SortedList<int, string> lookupValues,
            SortedList<int, string> resources)
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
            var steamlist = GetStreamList(dbAccess);
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

        private static string GetStreamList(DBAccess dbAccess)
        {
            if (dbAccess == null)
            {
                throw new ArgumentNullException(nameof(dbAccess));
            }
            SqlDataReader reader;
            var steamlist = "";
            var cmdText = "Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ";
            var oCommand = new SqlCommand(cmdText, dbAccess.Connection);
            if (ExecuteSQLSelect(oCommand, out reader) != StatusEnum.rsSuccess)
            {
                return steamlist;
            }

            using (reader)
            {
                while (reader.Read())
                {
                    var steamMember = DBAccess.ReadIntValue(reader[WresId]).ToString();
                    if (steamlist.Length == 0)
                    {
                        steamlist = steamMember;
                    }
                    else
                    {
                        steamlist += "," + steamMember;
                    }
                }
            }
            return steamlist;
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
            SortedList<int, string> lookupValues,
            SortedList<int, string> resources,
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

            stringValue = "";
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
                        xmlType = stringValue.Length > 0 ? StringType : "";
                    }
                    else if (customField.Fieldtype == ResorceId)
                    {
                        intValue = DBAccess.ReadIntValue(row[customField.FieldName]);
                        stringValue = GetLookupValue(resources, intValue);
                        xmlType = stringValue.Length > 0 ? StringType : "";
                    }
                    else
                    {
                        xmlType = IntegerType;
                        intValue = DBAccess.ReadIntValue(row[customField.FieldName]);
                    }
                    break;
                case StringTypeId2:
                    stringValue = DBAccess.ReadStringValue(row[customField.FieldName]);
                    xmlType = stringValue.Length > 0 ? StringType : "";
                    break;
                case DoubleTypeId:
                    xmlType = DoubleType;
                    doubleValue = DBAccess.ReadDoubleValue(row[customField.FieldName]);
                    break;
                case DateTypeId:
                    dateValue = DBAccess.ReadDateValue(row[customField.FieldName]);
                    xmlType = dateValue == DateTime.MinValue ? "" : DateType;
                    break;
                default:
                    xmlType = "";
                    break;
            }
            return xmlType;
        }

        private static void CreateStandartAttribute(
            CStruct xPortfolioItem,
            int fieldValueId,
            string xmlType,
            DateTime dateValue,
            int intValue,
            double doubleValue,
            string stringValue)
        {
            if (xPortfolioItem == null)
            {
                throw new ArgumentNullException(nameof(xPortfolioItem));
            }
            var xField = xPortfolioItem.CreateSubStruct(Field);
            xField.CreateIntAttr(IdName, fieldValueId);
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
            int fieldValueId,
            DataRow row,
            int projectId,
            SortedList<int, SortedList<int, string>> mvsFields,
            out string stringValue,
            out int intValue,
            out DateTime dateValue)
        {
            if (row == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            stringValue = "";
            dateValue = DateTime.MinValue;
            intValue = 0;
            var xmlType = string.Empty;

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
                    xmlType = dateValue == DateTime.MinValue ? "" : DateType;
                    break;
                case ProjectFinishDateId:
                    dateValue = DBAccess.ReadDateValue(row[ProjectFinishDate]);
                    xmlType = dateValue == DateTime.MinValue ? "" : DateType;
                    break;
                case StageNameId:
                    stringValue = DBAccess.ReadStringValue(row[StageName]);
                    xmlType = stringValue.Length > 0 ? StringType : "";
                    break;
                case 9918:
                    xmlType = "";
                    break;
                case CreatedById:
                    stringValue = DBAccess.ReadStringValue(row[CreatedBy]);
                    xmlType = stringValue.Length > 0 ? StringType : "";
                    break;
                case 9921:
                    dateValue = DBAccess.ReadDateValue(row[ProjectCreated]);
                    xmlType = dateValue == DateTime.MinValue ? "" : DateType;
                    break;
                case StageOwnerId:
                    stringValue = DBAccess.ReadStringValue(row[StageOwner]);
                    xmlType = stringValue.Length > 0 ? StringType : "";
                    break;
                case WProjectId:
                    xmlType = IntegerType;
                    intValue = DBAccess.ReadIntValue(row[WProject]);
                    break;
                case ItemManagerId:
                    stringValue = DBAccess.ReadStringValue(row[ItemManager]);
                    xmlType = stringValue.Length > 0 ? StringType : "";
                    break;
                case ProjectPriorityId:
                    xmlType = IntegerType;
                    intValue = DBAccess.ReadIntValue(row[ProjectPriority]);
                    break;
                case ScheduleManagerId:
                    stringValue = DBAccess.ReadStringValue(row[ScheduleManager]);
                    xmlType = stringValue.Length > 0 ? StringType : "";
                    break;
                case WorkitemStartDateId:
                    dateValue = DBAccess.ReadDateValue(row[WorkitemStartDate]);
                    xmlType = dateValue == DateTime.MinValue ? "" : DateType;
                    break;
                case ProgramGroupId:
                    stringValue = GetMVValue(mvsFields, fieldValueId, projectId);
                    xmlType = stringValue.Length > 0 ? StringType : "";
                    break;
                default:
                    xmlType = "";
                    break;
            }
            return xmlType;
        }

        public static string GetMVValue(SortedList<int, SortedList<int, string>> clnMVs, int lFieldID, int lWresID)
        {
            string sValue = "";
            SortedList<int, string> clnMVValues;

            if (clnMVs.ContainsKey(lFieldID))
            {
                clnMVValues = clnMVs[lFieldID];
                if (clnMVValues.ContainsKey(lWresID)) sValue = clnMVValues[lWresID];
            }
            return sValue;
        }
        public static string GetLookupValue(SortedList<int, string> clnLookupValues, int lID)
        {
            string sValue = "";
            if (clnLookupValues.ContainsKey(lID)) sValue = clnLookupValues[lID];
            return sValue;
        }
        public static StatusEnum SelectGroupPermissions(DBAccess dba, int nGroupId, out DataTable dt)
        {
            string cmdText = "SELECT distinct (p.PERM_UID), p.PERM_ID, p.PERM_LEVEL, p.PERM_NAME, CAST(p.PERM_NOTES AS NVARCHAR(MAX)), p.PERM_WEINCLUDE, "
                                + "gp.GROUP_ID From EPG_PERMISSIONS p"
                                + " Left Join EPG_GROUP_PERMISSIONS gp On gp.PERM_UID=p.PERM_UID and gp.GROUP_ID=@p1"
                                + " Where p.PERM_WEINCLUDE=1"
                                + " Order by PERM_ID";

            dba.SelectDataById(cmdText, nGroupId, (StatusEnum)99925, out dt);
            return dba.Status;
        }
        public static StatusEnum SelectAvailCCs(DBAccess dba, int nCTId, out DataTable dt)
        {
            string cmdText = "SELECT cc.*,ac.BC_UID as BC_UID_incl From EPGP_COST_CATEGORIES cc"
                                + " Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID=cc.BC_UID and ac.CT_ID=@p1"
                                + " Order by BC_ID";
            dba.SelectDataById(cmdText, nCTId, (StatusEnum)99999, out dt);
            return dba.Status;
        }
        public static StatusEnum SelectCTCalcs(DBAccess dba, int nCTId, out DataTable dt)
        {
            string cmdText = "SELECT * From EPGP_COST_CALC"
                                + " Where CT_ID=@p1"
                                + " Order by CL_ID";
            dba.SelectDataById(cmdText, nCTId, (StatusEnum)99999, out dt);
            return dba.Status;
        }
    }


    public class dbaCCV
    {
        public static StatusEnum CalculateCostValues(DBAccess dba, int nCTID, int nCBID, int nProjectID, out string sResult)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;

            if (!(nCTID > 0) || !(nCBID >= 0)) goto Exit_Function;

            SqlCommand cmd;
            SqlDataReader reader;
            string cmdText;

            // likely will have to expand on this parameter options later
            bool bDeleteAllProjects = false;
            bool bAllProjects = false;
            List<int> listPIs = new List<int>();
            if (nProjectID > 0)
            {
                listPIs.Add(nProjectID);
            }
            else
            {
                bDeleteAllProjects = true;
                bAllProjects = true;
                cmdText = "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION = 0";
                cmd = new SqlCommand(cmdText, dba.Connection);
                if (dbaUsers.ExecuteSQLSelect(cmd, out reader) == StatusEnum.rsSuccess)
                {
                    while (reader.Read())
                    {
                        int lProjectID = (int)reader["PROJECT_ID"];
                        listPIs.Add(lProjectID);
                    }
                    reader.Close();
                }
            }

            int lPeriodCount = 0;
            cmdText = "Select MAX(PRD_ID) as PeriodCount From EPG_PERIODS Where CB_ID=" + nCBID.ToString();
            cmd = new SqlCommand(cmdText, dba.Connection);
            if (dbaUsers.ExecuteSQLSelect(cmd, out reader) == StatusEnum.rsSuccess)
            {
                if (reader.Read())
                {
                    lPeriodCount = DBAccess.ReadIntValue(reader["PeriodCount"]);
                }
                reader.Close();
            }

            Dictionary<int, CostCategoryInternal> costcategories = new Dictionary<int, CostCategoryInternal>();  // DIC because I want foreach to get back in order put in
            List<int> costcategoriesindex = new List<int>();   //  used as a lookup to access the costcategories in reverse order below
            int nMaxLevel = 0;
            string susedUOM = "";
            bool bsingleUOM = true;
            cmdText = "SELECT cc.BC_UID,BC_ID,BC_LEVEL,BC_UOM,ac.BC_UID as Avail_BC_UID FROM EPGP_COST_CATEGORIES cc"
                        + " Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID = cc.BC_UID And ac.CT_ID=" + nCTID.ToString()
                        + " ORDER BY cc.BC_ID";
            cmd = new SqlCommand(cmdText, dba.Connection);
            if (dbaUsers.ExecuteSQLSelect(cmd, out reader) == StatusEnum.rsSuccess)
            {
                while (reader.Read())
                {
                    CostCategoryInternal costcategory = new CostCategoryInternal();
                    costcategory.UID = DBAccess.ReadIntValue(reader["BC_UID"]);
                    costcategory.ID = DBAccess.ReadIntValue(reader["BC_ID"]);
                    costcategory.Level = DBAccess.ReadIntValue(reader["BC_LEVEL"]);
                    if (costcategory.Level > nMaxLevel) nMaxLevel = costcategory.Level;
                    costcategory.UOM = DBAccess.ReadStringValue(reader["BC_UOM"]);
                    costcategory.RollupUOM = costcategory.UOM;

                    if (DBAccess.ReadIntValue(reader["Avail_BC_UID"]) > 0)   //  this category available for this CT
                    {
                        costcategory.IsAvailable = true;
                        if (bsingleUOM && costcategory.UOM != "")  // check to see if we use more than one non-blank UOM
                        {
                            if (susedUOM == "")
                            {
                                susedUOM = costcategory.UOM;
                            }
                            else
                            {
                                if (susedUOM != costcategory.UOM) bsingleUOM = false;
                            }
                        }
                    }
                    else
                    {
                        costcategory.IsAvailable = false;
                    };

                    costcategories.Add(costcategory.UID, costcategory);
                    costcategoriesindex.Add(costcategory.UID);   // just used to access the Dictionary in reverse order - will be saved in entry (BC_ID-1)
                }
                reader.Close();
            }
            int lCategoryCount = costcategories.Count;

            // set parent UIDs
            int[] ParentUIDs = new int[nMaxLevel + 1];
            foreach (KeyValuePair<int, CostCategoryInternal> costcategoryentry in costcategories)
            {
                CostCategoryInternal costcategory = costcategoryentry.Value;
                ParentUIDs[costcategory.Level] = costcategory.UID;
                if (costcategory.Level > 1) costcategory.ParentUID = ParentUIDs[costcategory.Level - 1];
            }
            ParentUIDs = null;

            // 'Roll up' the UOM values to determine when the quantities will be rolled up - if only one UOM used then always roll up

            // Rollup UOMs to summary lines without UOM - set to NO if childs with diff UOMs - only consider categories available for this CT
            //    This means that if a summary contains > 1 UOM it won't rollup even if the summary UOM is set to one of the values - TOUGH!

            string sTotalUoM = "@@@@";
            if (!bsingleUOM)  // if only one UOM can always roll up
            {
                for (int i = lCategoryCount - 1; i >= 0; i--)
                {
                    int categoryUID = costcategoriesindex[i];
                    CostCategoryInternal costcategory = costcategories[categoryUID];

                    if (costcategory.IsAvailable)
                    {
                        string sUOM = costcategory.RollupUOM;   // final determined UOM for this line as children already handled
                        if (costcategory.ParentUID == 0)
                        {
                            // this is a level 1 Category so check UOM against Total line UoM
                            if (sTotalUoM == "@@@@") sTotalUoM = sUOM; else if (sTotalUoM != sUOM) sTotalUoM = "@@NO@@";
                        }
                        else
                        {
                            // rollup UOM all the way up to level 1
                            while (costcategory.ParentUID > 0)
                            {
                                costcategory = costcategories[costcategory.ParentUID];
                                if (costcategory.RollupUOM == "") costcategory.RollupUOM = sUOM; else if (costcategory.RollupUOM != sUOM) costcategory.RollupUOM = "@@NO@@";
                            }
                        }
                    }
                }
            }



            // set arrays to hold Cost Values - incl extra category line for TOTALS
            CostValues costvalues = new CostValues(lPeriodCount, lCategoryCount);


            //   FOR EACH PI from here
            foreach (int ProjectID in listPIs)
            {
                //  reset arrays and category switches
                costvalues.SetArrays();
                foreach (KeyValuePair<int, CostCategoryInternal> costcategoryentry in costcategories)
                {
                    CostCategoryInternal costcategory = costcategoryentry.Value;
                    costcategory.IsSummary = false;
                    costcategory.HasData = false;
                }

                // read cost values
                cmdText = "SELECT BD_VALUE,BD_COST,BD_PERIOD,BC_UID FROM EPGP_DETAIL_VALUES  WHERE PROJECT_ID=" + ProjectID.ToString() +
                              " AND CB_ID=" + nCBID.ToString() +
                              " AND CT_ID=" + nCTID.ToString();
                cmd = new SqlCommand(cmdText, dba.Connection);
                if (dbaUsers.ExecuteSQLSelect(cmd, out reader) == StatusEnum.rsSuccess)
                {
                    while (reader.Read())
                    {
                        int period = DBAccess.ReadIntValue(reader["BD_PERIOD"]);  // doesn't seem worth trying to figure a Period offset in the arrays for periods not used but could do that at the beginning fofr all PIs I suppose 
                        int category = DBAccess.ReadIntValue(reader["BC_UID"]);

                        if (costcategories.ContainsKey(category))
                        {
                            CostCategoryInternal costcategory = costcategories[category];

                            if (costcategory.IsAvailable)
                            {
                                costcategory.HasData = true;
                                category = costcategory.ID;
                                costvalues.incrCost(period, category, DBAccess.ReadDoubleValue(reader["BD_COST"]));
                                costvalues.incrQuantity(period, category, DBAccess.ReadDoubleValue(reader["BD_VALUE"]));
                            }
                        }
                    }
                    reader.Close();
                }

                //  Rollup values using Cost Categories and UOMs determined earlier

                //  values can start at any level so need to mark the nodes that are summary for this PI and make sure they have no values except those that are rolled up
                // not sure this is effective because we  found that when a summary value mistakenly was there for a CCR with details it counted the summary plus the detais, doubling up that little bit - KT June 2012
                for (int i = lCategoryCount - 1; i >= 0; i--)
                {
                    int categoryUID = costcategoriesindex[i];
                    CostCategoryInternal costcategory = costcategories[categoryUID];

                    if (costcategory.IsSummary == false)  // if already a summary then no need to look at it
                    {
                        if (costcategory.HasData == true)
                        {
                            // mark as summary and clear values (just in case) all the way up to level 1
                            while (costcategory.ParentUID > 0)
                            {
                                costcategory = costcategories[costcategory.ParentUID];
                                costcategory.IsSummary = true;

                                for (int j = 1; j <= lPeriodCount; j++)
                                {
                                    costvalues.setCost(j, costcategory.ID, 0);
                                    costvalues.setQuantity(j, costcategory.ID, 0);
                                }

                            }
                        }
                    }
                }

                // ok now we can roll up the values
                for (int i = lCategoryCount - 1; i >= 0; i--)
                {
                    int categoryUID = costcategoriesindex[i];
                    CostCategoryInternal costcategory = costcategories[categoryUID];
                    if (costcategory.ParentUID == 0)
                    {
                        // this is a level 1 Category so total to TOTAL line - stored in row where BC_UID = 0
                        for (int j = 1; j <= lPeriodCount; j++)
                        {
                            costvalues.incrCost(j, 0, costvalues.getCost(j, costcategory.ID));
                        }

                        if (sTotalUoM != "@@NO@@")
                        {
                            for (int j = 1; j <= lPeriodCount; j++)
                            {
                                costvalues.incrQuantity(j, 0, costvalues.getQuantity(j, costcategory.ID));
                            }
                        }
                    }
                    else
                    {
                        CostCategoryInternal parent_costcategory = costcategories[costcategory.ParentUID];
                        int thisrow = costcategory.ID;
                        int parentrow = parent_costcategory.ID;

                        for (int j = 1; j <= lPeriodCount; j++)
                        {
                            costvalues.incrCost(j, parentrow, costvalues.getCost(j, thisrow));
                        }

                        //if (costcategory.RollupUOM != "" && costcategory.RollupUOM == parent_costcategory.RollupUOM)
                        if (bsingleUOM || (costcategory.RollupUOM == parent_costcategory.RollupUOM))
                        {
                            for (int j = 1; j <= lPeriodCount; j++)
                            {
                                costvalues.incrQuantity(j, parentrow, costvalues.getQuantity(j, thisrow));
                            }
                        }
                    }
                }

                // write out the results
                int lRowsAffected = 0;
                try
                {
                    cmdText = "DELETE FROM  EPGP_COST_VALUES WHERE CB_ID=" + nCBID.ToString() + " AND CT_ID=" + nCTID.ToString();

                    if (!bDeleteAllProjects) cmdText = cmdText + " AND PROJECT_ID=" + ProjectID.ToString();
                    bDeleteAllProjects = false;

                    cmd = new SqlCommand(cmdText, dba.Connection);
                    lRowsAffected = cmd.ExecuteNonQuery();

                    try
                    {
                        cmdText = "INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY)" +
                                    " VALUES(" + nCBID.ToString() + "," + nCTID.ToString() + "," + ProjectID.ToString() + ",@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)";
                        cmd = new SqlCommand(cmdText, dba.Connection);
                        SqlParameter pBC_UID = cmd.Parameters.Add("@BC_UID", SqlDbType.Int);
                        SqlParameter pBD_PERIOD = cmd.Parameters.Add("@BD_PERIOD", SqlDbType.Int);
                        SqlParameter pBD_VALUE = cmd.Parameters.Add("@BD_VALUE", SqlDbType.Float);
                        SqlParameter pBD_COST = cmd.Parameters.Add("@BD_COST", SqlDbType.Float);
                        SqlParameter pBD_IsSummary = cmd.Parameters.Add("@BD_IS_SUMMARY", SqlDbType.Int);

                        pBD_VALUE.Precision = 25;
                        pBD_VALUE.Scale = 6;
                        pBD_COST.Precision = 25;
                        pBD_COST.Scale = 6;

                        int lValueRowsAffected = 0;
                        // Write out the Grand Total line
                        for (int i = 1; i <= lPeriodCount; i++)
                        {
                            if (costvalues.getCost(i, 0) != 0 || costvalues.getQuantity(i, 0) != 0)
                            {
                                pBC_UID.Value = 0;
                                pBD_PERIOD.Value = i;
                                pBD_IsSummary.Value = 1;
                                pBD_VALUE.Value = costvalues.getQuantity(i, 0);
                                pBD_COST.Value = costvalues.getCost(i, 0);
                                lValueRowsAffected += cmd.ExecuteNonQuery();
                            }
                        }

                        // Write out the Cost Category lines
                        for (int j = 0; j < lCategoryCount; j++)
                        {
                            int categoryUID = costcategoriesindex[j];
                            CostCategoryInternal costcategory = costcategories[categoryUID];
                            int thisrow = costcategory.ID;

                            for (int i = 1; i <= lPeriodCount; i++)
                            {
                                if (costvalues.getCost(i, thisrow) != 0 || costvalues.getQuantity(i, thisrow) != 0)
                                {
                                    pBC_UID.Value = costcategory.UID;
                                    pBD_PERIOD.Value = i;
                                    int nIsSummary;
                                    if (costcategory.IsSummary) nIsSummary = 1; else nIsSummary = 0;
                                    pBD_IsSummary.Value = nIsSummary;
                                    pBD_VALUE.Value = costvalues.getQuantity(i, thisrow);
                                    pBD_COST.Value = costvalues.getCost(i, thisrow);
                                    lValueRowsAffected += cmd.ExecuteNonQuery();
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        eStatus = dba.HandleStatusError(SeverityEnum.Exception, "InsertCOST_VALUES", (StatusEnum)99848, ex.Message.ToString());
                    }

                }
                catch (Exception ex)
                {
                    eStatus = dba.HandleStatusError(SeverityEnum.Exception, "UpdatePermGroup_Delete_Perms", (StatusEnum)99847, ex.Message.ToString());
                }

            }            //   FOREACH PI ends here


            if (eStatus == StatusEnum.rsSuccess) eStatus = SetCostTotals(dba, nCTID, nCBID, listPIs, bAllProjects);
            Exit_Function:
            sResult = "CCV Complete";
            return eStatus;
        }
        internal static StatusEnum SetCostTotals(DBAccess dba, int nCTID, int nCBID, List<int> listPIs, bool bAllProjects)
        {
            StatusEnum eStatus = StatusEnum.rsSuccess;

            if (!(nCTID > 0) || !(nCBID >= 0)) goto Exit_Function;

            SqlCommand cmd;
            SqlDataReader reader;
            string cmdText;

            List<CostTotal> costtotals = new List<CostTotal>();
            try
            {
                cmd = new SqlCommand("EPG_SP_ReadCostTotals", dba.Connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CostTotal costtotal = new CostTotal();
                    costtotal.CT_ID = DBAccess.ReadIntValue(reader["CT_ID"]);
                    costtotal.CB_ID = DBAccess.ReadIntValue(reader["CB_ID"]);
                    costtotal.FIELD_ID = DBAccess.ReadIntValue(reader["BUDGET_TOTAL_FIELD"]);
                    costtotals.Add(costtotal);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "Set COST_VALUES", (StatusEnum)99846, ex.Message.ToString());
                goto Exit_Function;
            }
            if (costtotals.Count == 0) goto Exit_Function;

            try
            {
                int lRowsAffected = 0;
                foreach (CostTotal costtotal in costtotals)
                {
                    if (costtotal.CT_ID == nCTID && costtotal.CB_ID == nCBID)
                    {
                        // read info on Total Field
                        string sTable;
                        string sField;
                        cmdText = "SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=" + costtotal.FIELD_ID.ToString();
                        cmd = new SqlCommand(cmdText, dba.Connection);
                        reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int lTable = DBAccess.ReadIntValue(reader["FA_TABLE_ID"]);
                            int lFieldinTable = DBAccess.ReadIntValue(reader["FA_FIELD_IN_TABLE"]);
                            if (!(EPKClass01.GetTableAndField(lTable, lFieldinTable, out sTable, out sField))) goto Exit_Function;
                        }
                        else
                        {
                            goto Exit_Function;
                        }
                        reader.Close();

                        // read info on CT
                        int lEditMode = -1;
                        cmdText = "SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=" + nCTID.ToString();
                        cmd = new SqlCommand(cmdText, dba.Connection);
                        reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            lEditMode = DBAccess.ReadIntValue(reader["CT_EDIT_MODE"]);
                        }
                        else
                        {
                            goto Exit_Function;
                        }
                        reader.Close();
                        if (lEditMode == -1) goto Exit_Function;

                        // first zeroize Cost value(s) and then set from COST VALUES

                        //   we are going to deal differently with CTs populated by the user rather than entered in EPK
                        //   use TOTAL row except for user entered directly to DBS where we total ALL (non-summary)rows
                        if (bAllProjects)
                        {
                            cmdText = "Update " + sTable + " SET " + sField + "=0";
                            cmd = new SqlCommand(cmdText, dba.Connection);
                            lRowsAffected += cmd.ExecuteNonQuery();

                            cmdText = "Update " + sTable + " SET " + sField +
                            "=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES" +
                            " WHERE  (CB_ID=" + nCBID.ToString() + " AND CT_ID =" + nCTID.ToString();

                            if (lEditMode == 0)
                            {
                                cmdText = cmdText + " AND BD_IS_SUMMARY=0";
                            }
                            else
                            {
                                cmdText = cmdText + " AND BC_UID=0";
                            }

                            cmdText = cmdText + ") AND (" + sTable + ".PROJECT_ID=PROJECT_ID))";

                            cmd = new SqlCommand(cmdText, dba.Connection);
                            lRowsAffected += cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            foreach (int nProjectID in listPIs)
                            {
                                cmdText = "Update " + sTable + " SET " + sField + "=0" + " Where PROJECT_ID=" + nProjectID.ToString();
                                cmd = new SqlCommand(cmdText, dba.Connection);
                                lRowsAffected += cmd.ExecuteNonQuery();

                                cmdText = "Update " + sTable + " SET " + sField +
                                "=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES" +
                                " WHERE  (CB_ID=" + nCBID.ToString() + " AND CT_ID =" + nCTID.ToString();

                                if (lEditMode == 0)
                                {
                                    cmdText = cmdText + " AND BD_IS_SUMMARY=0";
                                }
                                else
                                {
                                    cmdText = cmdText + " AND BC_UID=0";
                                }

                                cmdText = cmdText + ") AND (" + sTable + ".PROJECT_ID=PROJECT_ID))";
                                cmdText = cmdText + " Where PROJECT_ID=" + nProjectID.ToString();

                                cmd = new SqlCommand(cmdText, dba.Connection);
                                lRowsAffected += cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                eStatus = dba.HandleStatusError(SeverityEnum.Exception, "Set COST_VALUES", (StatusEnum)99845, ex.Message.ToString());
                goto Exit_Function;
            }

        Exit_Function:
            return eStatus;
        }
    }


    public enum CustomFieldTable
    {
        Unknown = 0,
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
        ProgramText = 402, //  ??
        TaskWIINT = 801,
        TaskWITEXT = 802,
        TaskWIDEC = 803
    }

    //public enum FieldType
    //{
    //    TypeCost = 8,
    //    TypeCode = 4,
    //    TypeMVCode = 40,
    //    TypeFlag = 13,
    //    TypeText = 9,
    //    TypeNumber = 3,
    //    TypeDate = 1,
    //    TypeNText = 19,
    //}

    //public enum EntityID
    //{
    //    Resource = 1,
    //    Portfolio = 2,
    //    Program = 3,
    //    Project = 4,
    //    Task = 5,
    //    Unknown = 0
    //}

    //public class EPKClass01
    //{

    //    public static int GetEntityID(int iTable)
    //    {
    //        EntityID nEntity;
    //        CustomFieldTable nTable = (CustomFieldTable)iTable;
    //        if (nTable >= CustomFieldTable.ResourceINT && nTable <= CustomFieldTable.ResourceMV)
    //            nEntity = EntityID.Resource;
    //        else if (nTable >= CustomFieldTable.PortfolioINT && nTable <= CustomFieldTable.PortfolioDATE)
    //            nEntity = EntityID.Portfolio;
    //        else if (nTable == CustomFieldTable.Program)
    //            nEntity = EntityID.Program;
    //        else if (nTable >= CustomFieldTable.ProjectINT && nTable <= CustomFieldTable.ProjectDATE)
    //            nEntity = EntityID.Project;
    //        else if (nTable >= CustomFieldTable.TaskWIINT && nTable <= CustomFieldTable.TaskWIDEC)
    //            nEntity = EntityID.Task;
    //        else
    //            nEntity = EntityID.Unknown;
    //        int iEntity = (Int32)nEntity;
    //        return iEntity;
    //    }

    //    public static string GetEntity(int iEntity)
    //    {
    //        string sEntity = "";
    //        EntityID nEntity = (EntityID)iEntity;

    //        if (nEntity == EntityID.Resource)
    //            sEntity = "Resource";
    //        else if (nEntity == EntityID.Portfolio)
    //            sEntity = "Portfolio";
    //        else if (nEntity == EntityID.Program)
    //            sEntity = "Program";
    //        else if (nEntity == EntityID.Project)
    //            sEntity = "Project";
    //        else if (nEntity == EntityID.Task)
    //            sEntity = "Task";
    //        else
    //            sEntity = "Unknown";
    //        return sEntity;
    //    }
    //    public static string GetDataType(int iFieldType)
    //    {
    //        string sDataType = "";
    //        FieldType nFieldType = (FieldType)iFieldType;

    //        switch (nFieldType)
    //        {
    //            case FieldType.TypeCost:
    //                sDataType = "Cost";
    //                break;
    //            case FieldType.TypeCode:
    //                sDataType = "Code";
    //                break;
    //            case FieldType.TypeDate:
    //                sDataType = "Date";
    //                break;
    //            case FieldType.TypeFlag:
    //                sDataType = "Flag";
    //                break;
    //            case FieldType.TypeNumber:
    //                sDataType = "Number";
    //                break;
    //            case FieldType.TypeText:
    //                sDataType = "Text";
    //                break;
    //            case FieldType.TypeNText:
    //                sDataType = "RTF";
    //                break;
    //            default:
    //                sDataType = "Unknown";
    //                break;

    //        }
    //        return sDataType;
    //    }

    //    public static string GetFieldFormat(int iDataType)
    //    {
    //        string sdatatype = "";
    //        FieldType nDataType = (FieldType)iDataType;
    //        switch (nDataType)
    //        {
    //            case FieldType.TypeCost:
    //                sdatatype = "Cost";
    //                break;
    //            case FieldType.TypeCode:
    //                sdatatype = "Code";
    //                break;
    //            case FieldType.TypeMVCode:
    //                sdatatype = "MV Code";
    //                break;
    //            case FieldType.TypeFlag:
    //                sdatatype = "Flag";
    //                break;
    //            case FieldType.TypeText:
    //                sdatatype = "Text";
    //                break;
    //            case FieldType.TypeNumber:
    //                sdatatype = "Number";
    //                break;
    //            case FieldType.TypeDate:
    //                sdatatype = "Date";
    //                break;
    //            case FieldType.TypeNText:
    //                sdatatype = "NText";
    //                break;
    //            default:
    //                sdatatype = "Unknown Type";
    //                break;
    //        }
    //        return sdatatype;
    //    }

    //    public static bool GetTableAndField(int iTable, int iField, out string sTable, out string sField)
    //    {
    //        bool bFound = true;
    //        string stable = "";
    //        string sfield = "";
    //        CustomFieldTable nTable = (CustomFieldTable)iTable;
    //        switch (nTable)
    //        {
    //            case CustomFieldTable.ResourceINT:
    //                stable = "EPGC_RESOURCE_INT_VALUES";
    //                sfield = "RI_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceTEXT:
    //                stable = "EPGC_RESOURCE_TEXT_VALUES";
    //                sfield = "RT_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceDEC:
    //                stable = "EPGC_RESOURCE_DEC_VALUES";
    //                sfield = "RC_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceNTEXT:
    //                stable = "EPGC_RESOURCE_NTEXT_VALUES";
    //                sfield = "RN_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceDATE:
    //                stable = "EPGC_RESOURCE_DATE_VALUES";
    //                sfield = "RD_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.ResourceMV:
    //                stable = "EPGC_RESOURCE_MV_VALUES";
    //                sfield = "MVR_UID";
    //                break;
    //            case CustomFieldTable.PortfolioINT:
    //                stable = "EPGP_PROJECT_INT_VALUES";
    //                sfield = "PI_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioTEXT:
    //                stable = "EPGP_PROJECT_TEXT_VALUES";
    //                sfield = "PT_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioDEC:
    //                stable = "EPGP_PROJECT_DEC_VALUES";
    //                sfield = "PC_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioNTEXT:
    //                stable = "EPGP_PROJECT_NTEXT_VALUES";
    //                sfield = "PN_" + String.Format("{0:d3}", iField);
    //                break;
    //            case CustomFieldTable.PortfolioDATE:
    //                stable = "EPGP_PROJECT_DATE_VALUES";
    //                sfield = "PD_" + String.Format("{0:d3}", iField);
    //                break;
    //            default:
    //                stable = "Unknown Table";
    //                sfield = "";
    //                bFound = false;
    //                break;
    //        }

    //        sTable = stable;
    //        sField = sfield;
    //        return bFound;
    //    }

    //    public static int GetTableID(int iEntity, int iDataType)
    //    {
    //        CustomFieldTable nTable = 0;
    //        FieldType nDataType = (FieldType)iDataType;
    //        EntityID nEntity = (EntityID)iEntity;

    //        switch (nEntity)
    //        {
    //            case EntityID.Resource:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                    case FieldType.TypeCost:
    //                        nTable = CustomFieldTable.ResourceDEC;
    //                        break;
    //                    case FieldType.TypeDate:
    //                        nTable = CustomFieldTable.ResourceDATE;
    //                        break;
    //                    case FieldType.TypeCode:
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.ResourceINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.ResourceTEXT;
    //                        break;
    //                    case FieldType.TypeMVCode:
    //                        nTable = CustomFieldTable.ResourceMV;
    //                        break;
    //                }
    //                break;
    //            case EntityID.Portfolio:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                    case FieldType.TypeCost:
    //                        nTable = CustomFieldTable.PortfolioDEC;
    //                        break;
    //                    case FieldType.TypeDate:
    //                        nTable = CustomFieldTable.PortfolioDATE;
    //                        break;
    //                    case FieldType.TypeCode:
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.PortfolioINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.PortfolioTEXT;
    //                        break;
    //                    case FieldType.TypeNText:
    //                        nTable = CustomFieldTable.PortfolioNTEXT;
    //                        break;
    //                }
    //                break;
    //            case EntityID.Program:
    //                nTable = CustomFieldTable.Program;
    //                break;
    //            case EntityID.Project:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                    case FieldType.TypeCost:
    //                        nTable = CustomFieldTable.ProjectDEC;
    //                        break;
    //                    case FieldType.TypeDate:
    //                        nTable = CustomFieldTable.ProjectDATE;
    //                        break;
    //                    case FieldType.TypeCode:
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.ProjectINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.ProjectTEXT;
    //                        break;
    //                    case FieldType.TypeNText:
    //                        nTable = CustomFieldTable.ProjectNTEXT;
    //                        break;
    //                }
    //                break;
    //            case EntityID.Task:
    //                switch (nDataType)
    //                {
    //                    case FieldType.TypeNumber:
    //                        nTable = CustomFieldTable.TaskWIDEC;
    //                        break;
    //                    case FieldType.TypeFlag:
    //                        nTable = CustomFieldTable.TaskWIINT;
    //                        break;
    //                    case FieldType.TypeText:
    //                        nTable = CustomFieldTable.TaskWITEXT;
    //                        break;
    //                }
    //                break;
    //            default:
    //                nTable = CustomFieldTable.Unknown;
    //                break;
    //        }
    //        return (int)nTable;
    //    }

    //}
}
