using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace PortfolioEngineCore
{
    public class dbaLookups
    {
        private const int KeyOffset = 200000000;

        public static StatusEnum SelectLookups(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT LOOKUP_UID, LOOKUP_NAME, LOOKUP_DESC FROM EPGP_LOOKUP_TABLES"
                            + " WHERE LOOKUP_UID <> (SELECT ADM_RPE_DEPT_CODE FROM EPG_ADMIN)"
                            + " AND LOOKUP_UID <> (SELECT ADM_ROLE_CODE FROM EPG_ADMIN)"
                            + " ORDER BY LOOKUP_NAME";
            return dba.SelectData(cmdText, (StatusEnum)99941, out dt);
        }
        public static StatusEnum SelectLookup(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT LOOKUP_UID, LOOKUP_NAME, LOOKUP_DESC FROM EPGP_LOOKUP_TABLES WHERE LOOKUP_UID = @p1";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99940, out dt);
        }
        public static StatusEnum SelectLookupValues(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT LV_UID, LV_VALUE, LV_LEVEL, LV_INACTIVE FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99939, out dt);
        }

        public static StatusEnum UpdateLookupInfo(
            DBAccess dba,
            ref int nLOOKUP_UID,
            string sName,
            string sDesc,
            DataTable dtValues,
            out string sReply)
        {
            sReply = string.Empty;
            try
            {
                if (!MakeSureNameIsUnique(dba, nLOOKUP_UID, ref sName, ref sReply))
                {
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                //  Save the new Lookup values ready for updating
                var inserts = false;
                var updates = false;
                var deletes = false;

                int maxLevel;
                var valuesDictionary = PopulateDictionary(dtValues, out maxLevel, ref inserts);

                // figure fullname
                var levelName = new string[maxLevel + 1];

                if (!CheckDuplicateSiblings(ref sReply, valuesDictionary, levelName))
                {
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                CreateOrUpdateTable(dba, ref nLOOKUP_UID, sName, sDesc);

                if (nLOOKUP_UID > 0)
                {
                    // update the Lookup VALUES - update existing then insert new value - using IDENTITY so can't delete and re-add
                    using (var transaction = dba.Connection.BeginTransaction())
                    {
                        ProcessLookUps(
                            dba,
                            nLOOKUP_UID,
                            valuesDictionary,
                            updates,
                            deletes,
                            transaction,
                            inserts);
                        transaction.Commit();
                    }
                }
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                sReply = SqlDb.FormatAdminError("exception", "Lookups.UpdateLookupInfo", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        private static bool MakeSureNameIsUnique(DBAccess dbAccess, int lookUpId, ref string name, ref string reply)
        {
            name = name.Trim();
            if (name.Length == 0)
            {
                reply = SqlDb.FormatAdminError("error", "Lookups.UpdateLookupInfo", "Please enter a Lookup Name");
                return false;
            }
            const string commandText = "SELECT LOOKUP_UID From EPGP_LOOKUP_TABLES WHERE LOOKUP_NAME = @p1";
            DataTable dataTable;
            if (dbAccess.SelectDataByName(commandText, name, (StatusEnum)99999, out dataTable) != StatusEnum.rsSuccess)
            {
                reply = SqlDb.FormatAdminError("exception", "Lookups.UpdateLookupInfo1", dbAccess.StatusText);
            }
            else if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                var existingId = SqlDb.ReadIntValue(row["LOOKUP_UID"]);
                if (existingId != lookUpId)
                {
                    reply = SqlDb.FormatAdminError(
                        "error",
                        "Lookups.UpdateLookupInfo",
                        string.Format("Can't save Lookup.\nA Lookup with name '{0}' already exists", name));
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static Dictionary<int, PFELookupItem> PopulateDictionary(
            DataTable dtValues,
            out int maxLevel,
            ref bool inserts)
        {
            // read new lookup values into dic
            var valuesDictionary = new Dictionary<int, PFELookupItem>();
            var index = 0;
            maxLevel = 0;
            foreach (DataRow row in dtValues.Rows)
            {
                var itemLookup = new PFELookupItem();
                index++;
                itemLookup.UID = SqlDb.ReadIntValue(row["LV_UID"]);
                itemLookup.ID = index;
                itemLookup.level = SqlDb.ReadIntValue(row["LV_LEVEL"]);
                itemLookup.inactive = SqlDb.ReadIntValue(row["LV_INACTIVE"]);
                itemLookup.name = SqlDb.ReadStringValue(row["LV_VALUE"]);

                int key;
                if (itemLookup.UID == 0)
                {
                    key = itemLookup.ID + KeyOffset;
                    inserts = true;
                }
                else
                {
                    key = itemLookup.UID;
                }
                valuesDictionary.Add(key, itemLookup);

                if (maxLevel < itemLookup.level)
                {
                    maxLevel = itemLookup.level;
                }
            }
            return valuesDictionary;
        }

        private static bool CheckDuplicateSiblings(
            ref string reply,
            Dictionary<int, PFELookupItem> valuesDictionary,
            string[] levelName)
        {
            // used to check for duplicate siblings
            var fullNames = new Dictionary<string, string>();

            foreach (var itemLookup in valuesDictionary)
            {
                var level = itemLookup.Value.level;
                levelName[level] = itemLookup.Value.name;
                var stringBuilder = new StringBuilder(string.Empty);
                for (var index = 1; index <= level - 1; index++)
                {
                    stringBuilder.Append(levelName[index]).Append(".");
                }
                var parentName = stringBuilder.ToString();

                itemLookup.Value.fullname = string.Format("{0}{1}", parentName, itemLookup.Value.name);

                // need to check for duplicate siblings so stuff full name into dic, any error will be dup
                if (fullNames.ContainsKey(itemLookup.Value.fullname))
                {
                    reply = SqlDb.FormatAdminError(
                        "error",
                        "Lookups.UpdateLookupInfo",
                        string.Format(
                            "Can't save Lookup.\nDuplicate value not allowed: {0}",
                            itemLookup.Value.fullname));
                    return false;
                }
                fullNames.Add(itemLookup.Value.fullname, itemLookup.Value.fullname);
            }
            return true;
        }

        private static void CreateOrUpdateTable(DBAccess dbAccess, ref int lookUpId, string name, string desc)
        {
            string commandText;
            SqlCommand sqlCommand;
            if (lookUpId == 0)
            {
                AddTable(dbAccess, out lookUpId, name, desc);
            }
            else
            {
                UpdateTable(dbAccess, lookUpId, name, desc);
            }
        }

        private static void AddTable(DBAccess dbAccess, out int lookUpId, string name, string desc)
        {
            var guid = Guid.NewGuid();
            var guidString = guid.ToString();
            const string commandText = "INSERT Into EPGP_LOOKUP_TABLES (LOOKUP_NAME,LOOKUP_DESC,LOOKUP_EXT_UID)"
                + " Values(@ppLOOKUP_NAME, @pLOOKUP_DESC,@pLOOKUP_EXT_UID)";
            using (var sqlCommand = new SqlCommand(commandText, dbAccess.Connection))
            {
                sqlCommand.Parameters.AddWithValue("@ppLOOKUP_NAME", name);
                sqlCommand.Parameters.AddWithValue("@pLOOKUP_DESC", desc);
                sqlCommand.Parameters.AddWithValue("@pLOOKUP_EXT_UID", guidString);
                sqlCommand.ExecuteNonQuery();
            }
            dbAccess.GetLastIdentityValue(out lookUpId);
        }

        private static void UpdateTable(DBAccess dbAccess, int lookUpId, string name, string desc)
        {
            const string commandText = "UPDATE EPGP_LOOKUP_TABLES  SET LOOKUP_NAME=@pLOOKUP_NAME,"
                + "LOOKUP_DESC=@pLOOKUP_DESC WHERE LOOKUP_UID = @pLOOKUP_UID";
            using (var sqlCommand = new SqlCommand(commandText, dbAccess.Connection))
            {
                sqlCommand.Parameters.AddWithValue("@pLOOKUP_NAME", name);
                sqlCommand.Parameters.AddWithValue("@pLOOKUP_DESC", desc);
                sqlCommand.Parameters.AddWithValue("@pLOOKUP_UID", lookUpId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        private static void ProcessLookUps(
            DBAccess dba,
            int lookUpId,
            Dictionary<int, PFELookupItem> valuesDictionary,
            bool updates,
            bool deletes,
            SqlTransaction transaction,
            bool inserts)
        {
            const string commandText =
                "SELECT LOOKUP_UID,LV_UID,LV_EXT_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_INACTIVE From EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @LookupUID";
            using (var sqlCommand = new SqlCommand(commandText, dba.Connection))
            {
                sqlCommand.Transaction = transaction;
                sqlCommand.Parameters.AddWithValue("@LookupUID", lookUpId);
                using (var dataTable = new DataTable())
                {
                    dataTable.Load(sqlCommand.ExecuteReader());

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            var existingName = SqlDb.ReadStringValue(row["LV_VALUE"]);
                            var existingLevel = SqlDb.ReadIntValue(row["LV_LEVEL"]);
                            var existingInActive = SqlDb.ReadIntValue(row["LV_INACTIVE"]);
                            var uId = SqlDb.ReadIntValue(row["LV_UID"]);
                            var existingId = SqlDb.ReadIntValue(row["LV_ID"]);

                            var existingFullName = SqlDb.ReadStringValue(row["LV_FULLVALUE"]);

                            if (valuesDictionary.ContainsKey(uId))
                            {
                                var value = valuesDictionary[uId];
                                value.bflag = true;
                                if (existingId != value.ID
                                    || existingLevel != value.level
                                    || existingName != value.name
                                    || existingFullName != value.fullname
                                    || existingInActive != value.inactive)
                                {
                                    row["LV_VALUE"] = value.name;
                                    row["LV_LEVEL"] = value.level;
                                    row["LV_EXT_UID"] = value.ExtId;
                                    row["LV_ID"] = value.ID;
                                    row["LV_INACTIVE"] = value.inactive;
                                    row["LV_FULLVALUE"] = value.fullname;
                                    updates = true;
                                }
                            }
                            else
                            {
                                //  item deleted
                                deletes = true;
                                row.Delete();
                            }
                        }

                        if (updates)
                        {
                            UpdateDbs(dba, transaction, dataTable);
                        }

                        if (deletes)
                        {
                            DeleteDbs(dba, transaction, dataTable);
                        }
                    }
                }
            }

            Insert(dba, lookUpId, inserts, transaction, valuesDictionary);
        }

        private static void UpdateDbs(DBAccess dba, SqlTransaction transaction, DataTable dataTable)
        {
            //  apply updates to dbs
            var commandText =
                @"Update EPGP_LOOKUP_VALUES SET LV_VALUE=@LV_value, LV_FULLVALUE=@LV_fullvalue, LV_LEVEL=@LV_level, LV_ID=@LV_id, LV_EXT_UID=@LV_extid,"
                + " LV_INACTIVE=@LV_inactive Where LV_UID=@LV_uid";
            using (var sqlCommand = new SqlCommand(commandText, dba.Connection)
            {
                Transaction = transaction,
                CommandType = CommandType.Text
            })
            {
                var uId = sqlCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                var level = sqlCommand.Parameters.Add("@LV_level", SqlDbType.Int);
                var id = sqlCommand.Parameters.Add("@LV_id", SqlDbType.Int);
                var fieldValue = sqlCommand.Parameters.Add("@LV_value", SqlDbType.VarChar);
                var fullValue = sqlCommand.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                var extId = sqlCommand.Parameters.Add("@LV_extid", SqlDbType.VarChar);
                var inactive = sqlCommand.Parameters.Add("@LV_inactive", SqlDbType.Int);

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        uId.Value = row["LV_UID"];
                        level.Value = row["LV_LEVEL"];
                        id.Value = row["LV_ID"];
                        fieldValue.Value = row["LV_VALUE"];
                        fullValue.Value = row["LV_FULLVALUE"];
                        extId.Value = row["LV_EXT_UID"];
                        inactive.Value = row["LV_INACTIVE"];
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private static void DeleteDbs(DBAccess dba, SqlTransaction transaction, DataTable dataTable)
        {
            //  apply deletes to dbs
            var commandText = @"Delete From EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid";
            using (var sqlCommand = new SqlCommand(commandText, dba.Connection))
            {
                sqlCommand.Transaction = transaction;
                sqlCommand.CommandType = CommandType.Text;

                var uId = sqlCommand.Parameters.Add("@LV_uid", SqlDbType.Int);
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        uId.Value = row["LV_UID", DataRowVersion.Original];
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private static void Insert(
            DBAccess dba,
            int nLOOKUP_UID,
            bool inserts,
            SqlTransaction transaction,
            Dictionary<int, PFELookupItem> valuesDictionary)
        {
            //  check for inserts
            if (inserts)
            {
                var commandText = @"SET NOCOUNT ON;"
                    + "Insert Into EPGP_LOOKUP_VALUES (LOOKUP_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_EXT_UID,LV_INACTIVE)"
                    + " Values (@LV_lookupuid,@LV_value,@LV_fullvalue,@LV_id,@LV_level,@LV_extid,@LV_inactive);"
                    + "Select @@IDENTITY as NewID";
                using (var sqlCommand = new SqlCommand(commandText, dba.Connection)
                {
                    Transaction = transaction,
                    CommandType = CommandType.Text
                })
                {
                    var lookupUId = sqlCommand.Parameters.Add("@LV_lookupuid", SqlDbType.Int);
                    var level = sqlCommand.Parameters.Add("@LV_level", SqlDbType.Int);
                    var id = sqlCommand.Parameters.Add("@LV_id", SqlDbType.Int);
                    var fieldValue = sqlCommand.Parameters.Add("@LV_value", SqlDbType.VarChar);
                    var fullValue = sqlCommand.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                    var extId = sqlCommand.Parameters.Add("@LV_extid", SqlDbType.VarChar);
                    var inactive = sqlCommand.Parameters.Add("@LV_inactive", SqlDbType.Int);

                    foreach (var lookupItem in valuesDictionary)
                    {
                        if (lookupItem.Value.bflag == false)
                        {
                            lookupUId.Value = nLOOKUP_UID;
                            level.Value = lookupItem.Value.level;
                            id.Value = lookupItem.Value.ID;
                            fieldValue.Value = lookupItem.Value.name;
                            fullValue.Value = lookupItem.Value.fullname;
                            var guid = Guid.NewGuid();
                            extId.Value = guid.ToString();
                            inactive.Value = lookupItem.Value.inactive;

                            using (var dataReader = sqlCommand.ExecuteReader())
                            {
                                if (dataReader.Read())
                                {
                                    lookupItem.Value.UID = Convert.ToInt32(dataReader["NewID"]);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static StatusEnum CanDeleteLookupItems(DBAccess dba, string sLVUIDs, out string sReply)
        {
            // there is a version of this in AdminInfos.cs but that works the old way - passed in ONE item and it determines if there are any children, etc
            sReply = string.Empty;
            try
            {
                var message = ProcessItems(dba, sLVUIDs);

                if (message != string.Empty)
                {
                    sReply = SqlDb.FormatAdminError("error", "Lookups.CanDeleteLookupItems", message);
                }

                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                sReply = SqlDb.FormatAdminError("exception", "CostCategories.CanDeleteCostCategory", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        private static string ProcessItems(DBAccess dbAccess, string lvUIds)
        {
            // check if each Lookup Item can be deleted
            var message = string.Empty;
            if (lvUIds.Length > 0)
            {
                var arrayLvUId = lvUIds.Split(',');
                var numberOfMessageLines = 0;
                for (var i = 0; i <= arrayLvUId.GetUpperBound(0); i++)
                {
                    var lVUIdString = arrayLvUId[i];
                    // CC-77951 Not replacing to TryParse because the original version stops execution if this fails
                    var lvuid = int.Parse(lVUIdString);
                    if (lvuid > 0)
                    {
                        bool firstMessage;
                        ReadUSedListValues(dbAccess, lvuid, out firstMessage, ref numberOfMessageLines, ref message);
                        var cleanFields = ReadListFieldsUSedInOtherPlaces(dbAccess);

                        foreach (var field in cleanFields)
                        {
                            if (field.Id >= 9105 && field.Id <= 9109)
                            {
                                ReadTsFields(dbAccess, field, lvuid, ref firstMessage, ref message);
                            }
                            else if (field.Id >= 9305 && field.Id <= 9309)
                            {
                                ReadRpCodeFields(dbAccess, field, lvuid, ref firstMessage, ref message);
                            }
                            else if (field.Id >= 11801 && field.Id <= 11805)
                            {
                                ReadCtCodeFields(dbAccess, field, lvuid, ref firstMessage, ref message);
                            }
                            else if (field.Id > 20000)
                            {
                                // PI or Resource fields Code fields
                                string tableName;
                                string fieldName;
                                Common.CalculateTableFieldName(field.CFField, field.CFTable, out tableName, out fieldName);

                                if ((Common.CustomFieldTable)field.CFTable == Common.CustomFieldTable.ResourceINT)
                                {
                                    ReadResourceCodeFields(dbAccess, fieldName, lvuid, ref firstMessage, field, ref message);
                                }
                                else if ((Common.CustomFieldTable)field.CFTable == Common.CustomFieldTable.PortfolioINT)
                                {
                                    ReadPiCodeFields(dbAccess, fieldName, lvuid, ref firstMessage, field, ref message);
                                }
                            }
                        }
                    }
                }
            }
            return message;
        }

        private static void ReadPiCodeFields(DBAccess dbAccess, string fieldName, int lvuid, ref bool firstMessage, CField field, ref string message)
        {
            //  PI code fields
            var textCommand = string.Format(
                "Select Top 3 PROJECT_NAME"
                + " From EPGP_PROJECT_INT_VALUES iv"
                + " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=iv.PROJECT_ID"
                + " Where iv.{0} = {1}",
                fieldName,
                lvuid);

            var stringBuilder = new StringBuilder(message);

            using (var sqlCommand = new SqlCommand(textCommand, dbAccess.Connection))
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (firstMessage)
                    {
                        firstMessage = false;
                        stringBuilder.Append("Cannot Delete Lookup Item, it is used as follows: \n");
                    }
                    stringBuilder.AppendFormat("PI  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(reader["PROJECT_NAME"]));
                }
                reader.Close();
            }

            ReadPiProgramData(dbAccess, fieldName, lvuid, ref firstMessage, field, stringBuilder);

            message = stringBuilder.ToString();
        }

        private static void ReadPiProgramData(
            DBAccess dbAccess,
            string fieldName,
            int lvuid,
            ref bool firstMessage,
            CField field,
            StringBuilder stringBuilder)
        {
            //  PI codes also used for Program Data
            var textCommand = string.Format(
                "Select Top 3 LV_VALUE as Program_Name"
                + " From EPGP_PROG_INT_VALUES iv"
                + " Inner Join EPGP_LOOKUP_VALUES p On p.LV_UID=iv.PROG_UID"
                + " Where iv.{0} = {1}",
                fieldName,
                lvuid);

            using (var sqlCommand = new SqlCommand(textCommand, dbAccess.Connection))
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (firstMessage)
                    {
                        firstMessage = false;
                        stringBuilder.Append("Cannot Delete Lookup Item, it is used as follows: \n");
                    }
                    stringBuilder.AppendFormat("Program Data  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(reader["Program_Name"]));
                }
            }
        }

        private static void ReadResourceCodeFields(DBAccess dbAccess, string fieldName, int lvuid, ref bool firstMessage, CField field, ref string message)
        {
            // resource code fields
            var textCommand = string.Format(
                "Select Top 3 RES_NAME"
                + " From EPGC_RESOURCE_INT_VALUES iv"
                + " Inner Join EPG_RESOURCES r On r.WRES_ID=iv.WRES_ID"
                + " Where iv.{0} = {1}",
                fieldName,
                lvuid);

            var stringBuilder = new StringBuilder(message);
            using (var sqlCommand = new SqlCommand(textCommand, dbAccess.Connection))
            {
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (firstMessage)
                        {
                            firstMessage = false;
                            stringBuilder.Append("Cannot Delete Lookup Item, it is used as follows: \n");
                        }
                        stringBuilder.AppendFormat("Resource  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(reader["RES_NAME"]));
                    }
                }
            }
            message = stringBuilder.ToString();
        }

        private static void ReadCtCodeFields(DBAccess dbAccess, CField field, int lvuid, ref bool firstMessage, ref string message)
        {
            string sField;
            string textCommand;

            // CT Code fields
            sField = string.Format("OC_{0:00}", field.Id - 11800);
            textCommand = string.Format("Select DISTINCT Top 3 PROJECT_NAME,CT_NAME,BC_NAME,CB_NAME"
                + " From EPGP_COST_DETAILS cv"
                + " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=cv.PROJECT_ID"
                + " Inner Join EPGP_COST_TYPES ct On ct.CT_ID=cv.CT_ID"
                + " Inner Join EPGP_COST_CATEGORIES cc On cc.BC_UID=cv.BC_UID"
                + " Inner Join EPGP_COST_BREAKDOWNS cb On cb.CB_ID=cv.CB_ID" + " Where cv.{0} = {1}",
                sField,
                lvuid);
            var stringBuilder = new StringBuilder(message);
            using (var sqlCommand = new SqlCommand(textCommand, dbAccess.Connection))
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (firstMessage)
                    {
                        firstMessage = false;
                        stringBuilder.Append("Cannot Delete Lookup Item, it is used as follows: \n");
                    }
                    stringBuilder.Append(
                        string.Format(
                            "PI Cost Value  {0}  {1}  {2}  {3}:  {4}\n",
                            SqlDb.ReadStringValue(reader["CT_NAME"]),
                            SqlDb.ReadStringValue(reader["CB_NAME"]),
                            SqlDb.ReadStringValue(reader["BC_NAME"]),
                            field.Name,
                            SqlDb.ReadStringValue(reader["PROJECT_NAME"])));
                }
            }
            message = stringBuilder.ToString();
        }

        private static void ReadRpCodeFields(DBAccess dbAccess, CField field, int lvuid, ref bool firstMessage, ref string message)
        {
            // RP Code fields
            var sField = string.Format("CAT_CODE_{0:0}", field.Id - 9304);

            var textCommand = string.Format("Select DISTINCT TOP 3 PROJECT_NAME"
                + " From EPGP_RP_CATEGORY_VALUES cv"
                + " Inner Join EPG_RESOURCEPLANS c On c.CMT_UID=cv.CAT_CMT_UID"
                + " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=c.PROJECT_ID" + " Where cv.{0} = {1}",
                sField,
                lvuid);

            var stringBuilder = new StringBuilder(message);
            using (var sqlCommand = new SqlCommand(textCommand, dbAccess.Connection))
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (firstMessage)
                    {
                        firstMessage = false;
                        stringBuilder.Append("Cannot Delete Lookup Item, it is used as follows: \n");
                    }
                    stringBuilder.AppendFormat("Resource Plan  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(reader["PROJECT_NAME"]));
                }
            }
            message = stringBuilder.ToString();
        }

        private static void ReadTsFields(DBAccess dbAccess, CField field, int lvuid, ref bool firstMessage, ref string message)
        {
            // TS Code fields
            var sField = string.Format("CAT_CODE_{0:0}", field.Id - 9104);
            var textCommand = string.Format(
                "Select DISTINCT Top 3 RES_NAME,PRD_NAME"
                + " From EPG_TS_CATEGORY_VALUES cv"
                + " Inner Join EPG_TS_CHARGES ch ON ch.CHG_UID = cv.CAT_CHG_UID"
                + " Inner Join EPG_TS_TIMESHEETS ts ON ts.TS_UID = ch.TS_UID"
                + " Inner Join EPG_PERIODS p On p.PRD_ID = ts.PRD_ID and p.CB_ID=0"
                + " Inner Join EPG_RESOURCES r On r.WRES_ID = ts.WRES_ID"
                + " Where cv.{0} = {1}",
                sField,
                lvuid);

            var stringBuilder = new StringBuilder(message);
            using (var sqlCommand = new SqlCommand(textCommand, dbAccess.Connection))
            using (var reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (firstMessage)
                    {
                        firstMessage = false;
                        stringBuilder.Append("Cannot Delete Lookup Item, it is used as follows: \n");
                    }
                    stringBuilder.Append(string.Format(
                        "Timesheet  {0}  {1}:  {2}\n",
                        SqlDb.ReadStringValue(reader["PRD_NAME"]),
                        field.Name,
                        SqlDb.ReadStringValue(reader["RES_NAME"])));
                }
            }
            message = stringBuilder.ToString();
        }

        private static List<CField> ReadListFieldsUSedInOtherPlaces(DBAccess dbAccess)
        {
            //  other chcecks not in SP
            //  read list of Code fields used anywhere
            var textCommand = "Select FA_NAME as Field_Name,FA_FIELD_ID as Field_ID,0 as Table_ID,0 as Field_IN_TABLE"
                + " From EPGP_FIELD_ATTRIBS"
                + " Where (FA_FIELD_ID >= 9105 And FA_FIELD_ID <= 9109) Or (FA_FIELD_ID >= 9305 And FA_FIELD_ID <= 9309)"
                + " Or (FA_FIELD_ID >= 9505 And FA_FIELD_ID <= 9509)Or (FA_FIELD_ID >= 11801 And FA_FIELD_ID <= 11805)"
                + " Union"
                + " Select FA_NAME as Field_Name,FA_FIELD_ID as Field_ID,FA_TABLE_ID as Table_ID,FA_FIELD_IN_TABLE as Field_IN_TABLE"
                + " From EPGC_FIELD_ATTRIBS"
                + " Where FA_FORMAT = 4"
                + " Order by Field_ID";
            List<CField> cleanFields;

            using (var sqlCommand = new SqlCommand(textCommand, dbAccess.Connection))
            using (var reader = sqlCommand.ExecuteReader())
            {
                cleanFields = new List<CField>();
                while (reader.Read())
                {
                    var field = new CField
                    {
                        Id = SqlDb.ReadIntValue(reader["Field_ID"]),
                        Name = SqlDb.ReadStringValue(reader["Field_Name"]),
                        CFTable = SqlDb.ReadIntValue(reader["Table_ID"]),
                        CFField = SqlDb.ReadIntValue(reader["Field_IN_TABLE"])
                    };
                    cleanFields.Add(field);
                }
            }
            return cleanFields;
        }

        private static void ReadUSedListValues(DBAccess dbAccess, int lvuid, out bool firstMessage, ref int numberOfMessageLines, ref string message)
        {
            firstMessage = true;
            var stringBuilder = new StringBuilder(message);
            using (var sqlCommand = new SqlCommand("EPG_SP_ReadUsedListValue", dbAccess.Connection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@LV_UID", lvuid);
                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (numberOfMessageLines < 12)
                        {
                            if (firstMessage)
                            {
                                firstMessage = false;
                                stringBuilder.Append("Cannot Delete Lookup Item, it is used as follows: \n");
                            }

                            stringBuilder.AppendFormat("{0}: ", SqlDb.ReadStringValue(reader["UsedMessage"]));
                            stringBuilder.AppendFormat("{0}\n", SqlDb.ReadStringValue(reader["UsedData"]));
                        }
                        numberOfMessageLines++;
                    }
                }
            }
            message = stringBuilder.ToString();
        }

        public static StatusEnum DeleteLookup(DBAccess dba, int nLOOKUP_UID, out string sReply)
        {
            SqlCommand oCommand;
            string cmdText;
            sReply = "";
            try
            {
                // check if Lookup can be deleted
                string sdeletemessage;
                if (CanDeleteLookup(dba, nLOOKUP_UID, out sdeletemessage) != StatusEnum.rsSuccess) return dba.Status;
                if (sdeletemessage.Length > 0)
                {
                    sReply = DBAccess.FormatAdminError("error", "Lookups.DeleteLookup", "This Lookup cannot be deleted, it is currently used as follows:" + "\n" + "\n" + sdeletemessage);
                    return StatusEnum.rsRequestCannotBeCompleted;
                }

                //    clear any VALUES entries
                cmdText = "DELETE FROM EPGP_LOOKUP_VALUES Where LOOKUP_UID = @pLOOKUP_UID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pLOOKUP_UID", nLOOKUP_UID);
                oCommand.ExecuteNonQuery();

                // Delete the TABLE entry
                cmdText = "DELETE FROM EPGP_LOOKUP_TABLES Where LOOKUP_UID = @pLOOKUP_UID";
                oCommand = new SqlCommand(cmdText, dba.Connection);
                oCommand.Parameters.AddWithValue("@pLOOKUP_UID", nLOOKUP_UID);
                oCommand.ExecuteNonQuery();

                return dba.Status;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "Lookups.DeleteLookup", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }

        public static StatusEnum CanDeleteLookup(DBAccess dba, int nLOOKUP_UID, out string sReply)
        {
            SqlCommand oCommand;
            SqlDataReader reader;
            sReply = "";
            try
            {
                // check if LOOKUP can be deleted
                oCommand = new SqlCommand("EPG_SP_ReadUsedLookups", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.AddWithValue("@LookupUID", nLOOKUP_UID);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    sReply += DBAccess.ReadStringValue(reader["UsedMessage"]) + ":  " + DBAccess.ReadStringValue(reader["UsedData"]) + "\n";
                }
                reader.Close();
                return StatusEnum.rsSuccess;
            }
            catch (Exception ex)
            {
                sReply = DBAccess.FormatAdminError("exception", "CostViews.CanDeleteCostView", ex.Message);
                return StatusEnum.rsRequestCannotBeCompleted;
            }
        }


        private class PFELookupItem
        {
            public int UID;
            public string ExtId;
            public string name;
            public string fullname;
            public int ID;
            public int level;
            public int inactive;
            public bool bflag;
        }
        private class CField
        {
            public int CFField;
            public int CFTable;
            public int Id;
            public string Name;
        }
    }
}

