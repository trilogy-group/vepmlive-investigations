using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PortfolioEngineCore.Infrastructure.Entities;

namespace PortfolioEngineCore
{
    public partial class Admininfos : PFEBase
    {
        private const string MaxIdColumn = "MaxId";
        private const string WresIdColumn = "WRES_ID";
        private const string CantCreateNewGroupRecordMessage = "Can't create new Group record";
        private const string NoResourceMatchesSuppliedMessage = "No Resource matches supplied";
        private const string PiNotFoundMessage = "PI not found";

        #region Fields (1) 

        private readonly SqlConnection _sqlConnection;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the PFEAdmininfos class.
        /// </summary>
        /// <param name="basepath">The basepath.</param>
        /// <param name="username">The username.</param>
        /// <param name="pid">The pid.</param>
        /// <param name="company">The company.</param>
        /// <param name="dbcnstring">The dbcnstring.</param>
        /// <param name="secLevel">The sec level.</param>
        /// <param name="bDebug">if set to <c>true</c> [b debug].</param>
        /// 
        public Admininfos(string basepath, string username, string pid, string company, string dbcnstring,
                         SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading Admininfos Class");

            _sqlConnection = _PFECN;
        }

        #endregion Constructors 

        #region Methods (23) 

        // Public Methods (20) 

        public int GetWResID()
        {
            return _userWResID;
        }

        /// <summary>
        /// checks if a Cost Category Role can be deleted, returns reason or empty in string
        /// </summary>
        /// <param name="UID"> UID of the ROLE.</param>
        /// <returns></returns>
        public bool CanDeleteCostCategoryRole(int checkRoleUID, out string sresult)
        {
            try
            {
                string smessage = "";
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                // as we are checking for Cost Category Roles we know it is a leaf entry in the Cost Category structure - but there could be multiple CCRs

                List<int> CCRlist = new List<int>();

                sCommand = "Select CA_UID From EPGP_CATEGORIES Where CA_ROLE=@Role_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@Role_uid", checkRoleUID);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    CCRlist.Add(DBAccess.ReadIntValue(SqlReader["CA_UID"]));
                }
                SqlReader.Close();

                // run the SP for each one and stack up the messages
                foreach (int rolecheckitem in CCRlist)
                {
                    SqlCommand = new SqlCommand("EPG_SP_ReadCategoryUsedCTs", _sqlConnection);
                    SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommand.Parameters.AddWithValue("BCUID", rolecheckitem);
                    SqlReader = SqlCommand.ExecuteReader();

                    while (SqlReader.Read())
                    {
                        smessage += DBAccess.ReadStringValue(SqlReader["Type"]) + ": ";
                        smessage += DBAccess.ReadStringValue(SqlReader["Name"]) + "\n";
                    }
                    SqlReader.Close();
                }
                _sqlConnection.Close();

                sresult = smessage;
                return ((smessage.Length > 0) == false);
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CanDeleteCostCategoryRole, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// checks if a Cost Category Role can be deleted, returns reason or empty in string
        /// </summary>
        /// <param name="checkCCUID"> UID of the Cost Category Role</param>
        /// <param name="checkRoleUID"> UID of the Role</param>
        /// <returns></returns>
        public bool CanDeleteCostCategoryRolebyCCRId(int checkCCUID, int checkRoleUID, out string sresult)
        {
            try
            {
                string smessage = "";
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                // as we are checking for Cost Category Roles we know it is a leaf entry in the Cost Category structure

                // however if Role doesn't match CCRole we want to block delete
                bool bRoleMatch = false;
                sCommand = "Select CA_UID From EPGP_CATEGORIES Where CA_ROLE=@Role_uid And CA_UID=@CCRole_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@Role_uid", checkRoleUID);
                SqlCommand.Parameters.AddWithValue("@CCRole_uid", checkCCUID);
                SqlReader = SqlCommand.ExecuteReader();

                if (SqlReader.Read())
                {
                    bRoleMatch = true;
                }
                SqlReader.Close();

                if (bRoleMatch == true)
                {
                    SqlCommand = new SqlCommand("EPG_SP_ReadCategoryUsedCTs", _sqlConnection);
                    SqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlCommand.Parameters.AddWithValue("BCUID", checkCCUID);
                    SqlReader = SqlCommand.ExecuteReader();

                    while (SqlReader.Read())
                    {
                        smessage += DBAccess.ReadStringValue(SqlReader["Type"]) + ": ";
                        smessage += DBAccess.ReadStringValue(SqlReader["Name"]) + "\n";
                    }
                    SqlReader.Close();
                    _sqlConnection.Close();
                }
                else
                {
                    smessage += "Role Id does not match CCR Id " + "\n";
                }

                sresult = smessage;
                return ((smessage.Length > 0) == false);
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CanDeleteCostCategoryRolebyCCRId, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// checks if a lookup value can be deleted, returns reason or empty in string
        /// </summary>
        /// <param name="UID"> LV_UID.</param>
        /// <returns></returns>
        public bool CanDeleteLookupValue(int checklookupUID, out string sresult)
        {
            // there is a version of this in Lookup.cs but that works differently - passed in a list of items and it checks each one in turn
            try
            {
                var messageString = string.Empty;
                var messageStringBuilder = new StringBuilder(messageString);

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
                _sqlConnection.Open();

                var lookupValues = GetLookUpValues(checklookupUID);
                ProcessLookUpValues(checklookupUID, lookupValues, messageStringBuilder, ref messageString);

                sresult = messageString;
                return messageString.Length > 0 == false;
            }
            catch (Exception exception)
            {
                Trace.TraceError("Exception Suppressed: {0}", exception);
                throw new PFEException((int)PFEError.CanDeleteLookupValue, exception.GetBaseMessage());
            }
            finally
            {
                _sqlConnection?.Close();
            }
        }

        private List<EPKLookupValue> GetLookUpValues(int checklookupUID)
        {
            var lookupValues = new List<EPKLookupValue>();

            var command = "SELECT LV_UID,LV_VALUE,LV_ID,LV_LEVEL FROM EPGP_LOOKUP_VALUES"
                + " WHERE LOOKUP_UID =(Select LOOKUP_UID From EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid)"
                + " ORDER BY LV_ID";
            using (var sqlCommand = new SqlCommand(command, _sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@LV_uid", checklookupUID);
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    var found = false;
                    var levelThisValue = 0;
                    while (sqlReader.Read())
                    {
                        var uId = SqlDb.ReadIntValue(sqlReader["LV_UID"]);
                        var level = SqlDb.ReadIntValue(sqlReader["LV_LEVEL"]);
                        var name = SqlDb.ReadStringValue(sqlReader["LV_VALUE"]);

                        if (found == false)
                        {
                            if (uId == checklookupUID)
                            {
                                found = true;
                                levelThisValue = level;
                                CreateAndAddItem(uId, name, lookupValues);
                            }
                        }
                        else
                        {
                            if (level <= levelThisValue)
                            {
                                break;
                            }
                            CreateAndAddItem(uId, name, lookupValues);
                        }
                    }
                }
            }
            return lookupValues;
        }

        private void ProcessLookUpValues(int checklookupUID, List<EPKLookupValue> lookupValues, StringBuilder messageStringBuilder, ref string messageString)
        {
            foreach (var LVcheckitem in lookupValues)
            {
                int lookupUId;
                string lookupName;
                List<CField> clnFields;

                GetFieldsFromLookUp(LVcheckitem, messageStringBuilder, out lookupUId, out lookupName, out clnFields);

                foreach (var field in clnFields)
                {
                    if (field.Id >= 9105 && field.Id <= 9109)
                    {
                        ProcessTsCodeField(field, lookupUId, messageStringBuilder);
                    }
                    else if (field.Id >= 9305 && field.Id <= 9309)
                    {
                        ProcessRpCodeField(field, lookupUId, messageStringBuilder);
                    }
                    else if (field.Id >= 11801 && field.Id <= 11805)
                    {
                        ProcessCtCodeField(field, lookupUId, messageStringBuilder);
                    }
                    else if (field.Id > 20000)
                    {
                        string tableName;
                        string fieldName;
                        Common.CalculateTableFieldName(field.CFField, field.CFTable, out tableName, out fieldName);

                        if ((Common.CustomFieldTable)field.CFTable == Common.CustomFieldTable.ResourceINT)
                        {
                            ProcessResourceField(fieldName, lookupUId, messageStringBuilder, field);
                        }
                        else if ((Common.CustomFieldTable)field.CFTable == Common.CustomFieldTable.PortfolioINT)
                        {
                            ProcessPortfolioField(fieldName, lookupUId, messageStringBuilder, field);
                        }
                    }
                    messageString = messageStringBuilder.ToString();
                }
                if (!ProcessMessage(checklookupUID, lookupUId, lookupName, ref messageString))
                {
                    break;
                }
            }
        }

        private void GetFieldsFromLookUp(
            EPKLookupValue LVcheckitem,
            StringBuilder messageStringBuilder,
            out int lookupUId,
            out string lookupName,
            out List<CField> clnFields)
        {
            lookupUId = LVcheckitem.UID;
            lookupName = LVcheckitem.Name;

            // this is a complicated check, first part as per usual using SP but then much much more added

            using (var readUsedListCommand = new SqlCommand("EPG_SP_ReadUsedListValue", _sqlConnection))
            {
                readUsedListCommand.CommandType = CommandType.StoredProcedure;
                readUsedListCommand.Parameters.AddWithValue("LV_UID", lookupUId);
                using (var usedListReader = readUsedListCommand.ExecuteReader())
                {
                    while (usedListReader.Read())
                    {
                        messageStringBuilder.Append(string.Format("{0}: ", SqlDb.ReadStringValue(usedListReader["UsedMessage"])));
                        messageStringBuilder.Append(string.Format("{0}\n", SqlDb.ReadStringValue(usedListReader["UsedData"])));
                    }
                }
            }

            const string Command = "Select FA_NAME as Field_Name,FA_FIELD_ID as Field_ID,0 as Table_ID,0 as Field_IN_TABLE"
                + " From EPGP_FIELD_ATTRIBS"
                + " Where (FA_FIELD_ID >= 9105 And FA_FIELD_ID <= 9109) Or (FA_FIELD_ID >= 9305 And FA_FIELD_ID <= 9309)"
                + " Or (FA_FIELD_ID >= 9505 And FA_FIELD_ID <= 9509)Or (FA_FIELD_ID >= 11801 And FA_FIELD_ID <= 11805)"
                + " Union"
                + " Select FA_NAME as Field_Name,FA_FIELD_ID as Field_ID,FA_TABLE_ID as Table_ID,FA_FIELD_IN_TABLE as Field_IN_TABLE"
                + " From EPGC_FIELD_ATTRIBS"
                + " Where FA_FORMAT = 4"
                + " Order by Field_ID";
            using (var selectCommand = new SqlCommand(Command, _sqlConnection))
            {
                using (var selectReader = selectCommand.ExecuteReader())
                {
                    clnFields = new List<CField>();
                    while (selectReader.Read())
                    {
                        var cField = new CField
                        {
                            Id = SqlDb.ReadIntValue(selectReader["Field_ID"]),
                            Name = SqlDb.ReadStringValue(selectReader["Field_Name"]),
                            CFTable = SqlDb.ReadIntValue(selectReader["Table_ID"]),
                            CFField = SqlDb.ReadIntValue(selectReader["Field_IN_TABLE"])
                        };
                        clnFields.Add(cField);
                    }
                }
            }
        }

        private void ProcessTsCodeField(CField field, int lookupUId, StringBuilder messageStringBuilder)
        {
            var fieldString = string.Format("CAT_CODE_{0:0}", field.Id - 9104);
            var command = string.Format(
                "Select DISTINCT Top 3 RES_NAME,PRD_NAME"
                + " From EPG_TS_CATEGORY_VALUES cv"
                + " Inner Join EPG_TS_CHARGES ch ON ch.CHG_UID = cv.CAT_CHG_UID"
                + " Inner Join EPG_TS_TIMESHEETS ts ON ts.TS_UID = ch.TS_UID"
                + " Inner Join EPG_PERIODS p On p.PRD_ID = ts.PRD_ID and p.CB_ID=0"
                + " Inner Join EPG_RESOURCES r On r.WRES_ID = ts.WRES_ID"
                + " Where cv.{0} = {1}",
                fieldString,
                lookupUId);
            using (var sqlCommand = new SqlCommand(command, _sqlConnection))
            {
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        messageStringBuilder.Append(
                            string.Format(
                                "Timesheet  {0}  {1}:  {2}\n",
                                SqlDb.ReadStringValue(sqlReader["PRD_NAME"]),
                                field.Name,
                                SqlDb.ReadStringValue(sqlReader["RES_NAME"])));
                    }
                }
            }
        }

        private void ProcessRpCodeField(CField field, int lookupUId, StringBuilder messageStringBuilder)
        {
            var fieldString = string.Format("CAT_CODE_{0:0}", field.Id - 9304);
            var command = string.Format(
                "Select DISTINCT TOP 3 PROJECT_NAME"
                + " From EPGP_RP_CATEGORY_VALUES cv"
                + " Inner Join EPG_RESOURCEPLANS c On c.CMT_UID=cv.CAT_CMT_UID"
                + " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=c.PROJECT_ID"
                + " Where cv.{0} = {1}",
                fieldString,
                lookupUId);
            using (var sqlCommand = new SqlCommand(command, _sqlConnection))
            {
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        messageStringBuilder.Append(
                            string.Format("Resource Plan  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(sqlReader["PROJECT_NAME"])));
                    }
                }
            }
        }

        private void ProcessCtCodeField(CField field, int lookupUId, StringBuilder messageStringBuilder)
        {
            var fieldString = string.Format("OC_{0:00}", field.Id - 11800);
            var command = string.Format(
                "Select DISTINCT Top 3 PROJECT_NAME,CT_NAME,BC_NAME,CB_NAME"
                + " From EPGP_COST_DETAILS cv"
                + " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=cv.PROJECT_ID"
                + " Inner Join EPGP_COST_TYPES ct On ct.CT_ID=cv.CT_ID"
                + " Inner Join EPGP_COST_CATEGORIES cc On cc.BC_UID=cv.BC_UID"
                + " Inner Join EPGP_COST_BREAKDOWNS cb On cb.CB_ID=cv.CB_ID"
                + " Where cv.{0} = {1}",
                fieldString,
                lookupUId);
            var sqlCommand = new SqlCommand(command, _sqlConnection);
            using (var sqlReader = sqlCommand.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    messageStringBuilder.Append(
                        string.Format(
                            "PI Cost Value  {0}  {1}  {2}  {3}:  {4}\n",
                            SqlDb.ReadStringValue(sqlReader["CT_NAME"]),
                            SqlDb.ReadStringValue(sqlReader["CB_NAME"]),
                            SqlDb.ReadStringValue(sqlReader["BC_NAME"]),
                            field.Name,
                            SqlDb.ReadStringValue(sqlReader["PROJECT_NAME"])));
                }
            }
        }

        private void ProcessResourceField(string fieldName, int lookupUId, StringBuilder messageStringBuilder, CField field)
        {
            var command = string.Format(
                "Select Top 3 RES_NAME"
                + " From EPGC_RESOURCE_INT_VALUES iv"
                + " Inner Join EPG_RESOURCES r On r.WRES_ID=iv.WRES_ID"
                + " Where iv.{0} = {1}",
                fieldName,
                lookupUId);
            using (var sqlCommand = new SqlCommand(command, _sqlConnection))
            {
                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        messageStringBuilder.Append(string.Format("Resource  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(sqlReader["RES_NAME"])));
                    }
                }
            }
        }

        private void ProcessPortfolioField(string fieldName, int lookupUId, StringBuilder messageStringBuilder, CField field)
        {
            var command = string.Format(
                "Select Top 3 PROJECT_NAME"
                + " From EPGP_PROJECT_INT_VALUES iv"
                + " Inner Join EPGP_PROJECTS p On p.PROJECT_ID=iv.PROJECT_ID"
                + " Where iv.{0} = {1}",
                fieldName,
                lookupUId);
            using (var selectProjectCommand = new SqlCommand(command, _sqlConnection))
            {
                using (var projectReader = selectProjectCommand.ExecuteReader())
                {
                    while (projectReader.Read())
                    {
                        messageStringBuilder.Append(string.Format("PI  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(projectReader["PROJECT_NAME"])));
                    }
                }
            }

            //  PI codes also used for Program Data
            command = string.Format(
                "Select Top 3 LV_VALUE as Program_Name"
                + " From EPGP_PROG_INT_VALUES iv"
                + " Inner Join EPGP_LOOKUP_VALUES p On p.LV_UID=iv.PROG_UID"
                + " Where iv.{0} = {1}",
                fieldName,
                lookupUId);
            using (var selectValueCommand = new SqlCommand(command, _sqlConnection))
            {
                using (var valueReader = selectValueCommand.ExecuteReader())
                {
                    while (valueReader.Read())
                    {
                        messageStringBuilder.Append(string.Format("Program Data  {0}:  {1}\n", field.Name, SqlDb.ReadStringValue(valueReader["Program_Name"])));
                    }
                }
            }
        }

        private static bool ProcessMessage(int checklookupUID, int lookupUId, string lookupName, ref string messageString)
        {
            if (messageString.Length > 0)
            {
                if (lookupUId != checklookupUID)
                {
                    messageString = string.Format("Child item:{0}\n{1}", lookupName, messageString);
                }
                return false;
            }
            return true;
        }

        private static void CreateAndAddItem(int uId, string name, List<EPKLookupValue> LVlist)
        {
            EPKLookupValue LVitem;
            LVitem = new EPKLookupValue
            {
                UID = uId,
                Name = name
            };
            LVlist.Add(LVitem);
        }

        /// <summary>
        /// checks if a lookup value can be deleted, returns reason or empty in string
        /// </summary>
        /// <param name="UID"> LV_UID.</param>
        /// <returns></returns>
        public bool CanDeleteLookupValueasCC(int checklookupUID, out string sresult, out int nRoleUID)
        {
            try
            {
                string smessage = "";
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                sCommand = "Select CA_Role From EPGP_CATEGORIES Where CA_UID=@ccUID Order By CA_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@ccUID", checklookupUID);
                SqlReader = SqlCommand.ExecuteReader();

                int lRoleUID = 0;
                if (SqlReader.Read())
                {
                    lRoleUID = DBAccess.ReadIntValue(SqlReader["CA_Role"]);
                }
                SqlReader.Close();
                _sqlConnection.Close();

                if (lRoleUID > 0)
                {
                    bool bCanDelete = CanDeleteLookupValue(lRoleUID, out smessage);
                    nRoleUID = lRoleUID;
                    sresult = smessage;
                    return bCanDelete;
                }
                else
                {
                    nRoleUID = 0;
                    sresult = "Can't find Cost Category Role";
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CanDeleteLookupValueasCC, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// checks if a WorkSchedule can be deleted, returns reason or empty in string
        /// </summary>
        /// <param name="UID"> UID of the WH.</param>
        /// <returns></returns>

        public bool CanDeleteWorkSchedule(int checkUID, out string sresult)
        {
            try
            {
                string deletemessage = "";
                int lEntity = 10;

                bool bCanDelete = CanDeleteResourceGroup(checkUID, lEntity, out deletemessage);

                sresult = deletemessage;
                return bCanDelete;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CanDeleteWorkSchedule, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// checks if a Holiday can be deleted, returns reason or empty in string
        /// </summary>
        /// <param name="UID"> UID of the HOL.</param>
        /// <returns></returns>

        public bool CanDeleteHolidaySchedule(int checkUID, out string sresult)
        {
            try
            {
                string deletemessage = "";
                int lEntity = 11;

                bool bCanDelete = CanDeleteResourceGroup(checkUID, lEntity, out deletemessage);

                sresult = deletemessage;
                return bCanDelete;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CanDeleteHolidaySchedule, exception.GetBaseMessage());
            }
        }

        public bool CanDeleteResourceGroup(int checkUID, int lEntity, out string sresult)
        {
            try
            {
                string smessage = "";
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                sCommand = "Select Distinct Top 3 RES_NAME From EPG_GROUP_MEMBERS m" +
                    " Join EPG_GROUPS g On g.GROUP_ID=m.GROUP_ID And g.GROUP_ENTITY=@Entity" +
                    " Join EPG_RESOURCES r On r.WRES_ID=m.MEMBER_UID" +
                    " Where m.GROUP_ID=@GroupID ORDER BY RES_NAME";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@Entity", lEntity);
                SqlCommand.Parameters.AddWithValue("@GroupID", checkUID);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    smessage += "Used for Resource: ";
                    smessage += DBAccess.ReadStringValue(SqlReader["RES_NAME"]) + "\n";
                }
                SqlReader.Close();

                _sqlConnection.Close();

                sresult = smessage;
                return ((smessage.Length > 0) == false);
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CanDeleteResourceGroup, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// deletes a department lookup item and infos.
        /// </summary>
        /// <param name="deletedeptUID">UID of dept item.</param>
        /// <returns></returns>
        public bool DeleteDepartments(int deletedeptUID)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeleteDepartments", "Input", "DeptUID=" + deletedeptUID.ToString());

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                // we must check if this is a summary row and if so delete it and all its children - read lookup and make a list

                List<EPKLookupValue> LVlist = new List<EPKLookupValue>();
                EPKLookupValue LVitem;

                sCommand = "SELECT LV_UID,LV_VALUE,LV_ID,LV_LEVEL FROM EPGP_LOOKUP_VALUES" +
                    " WHERE LOOKUP_UID =(Select LOOKUP_UID From EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid)" +
                    " ORDER BY LV_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@LV_uid", deletedeptUID);
                SqlReader = SqlCommand.ExecuteReader();

                bool bfound = false;
                int levelthisvalue = 0;
                while (SqlReader.Read())
                {
                    int uid = DBAccess.ReadIntValue(SqlReader["LV_UID"]);
                    int level = DBAccess.ReadIntValue(SqlReader["LV_LEVEL"]);
                    string name = DBAccess.ReadStringValue(SqlReader["LV_VALUE"]);

                    if (bfound == false)
                    {
                        if (uid == deletedeptUID)
                        {
                            bfound = true;
                            levelthisvalue = level;
                            LVitem = new EPKLookupValue();
                            LVitem.UID = uid;
                            LVitem.Name = name;
                            LVlist.Add(LVitem);
                        }
                    }
                    else
                    {
                        if (level <= levelthisvalue) break;
                        else
                        {
                            LVitem = new EPKLookupValue();
                            LVitem.UID = uid;
                            LVitem.Name = name;
                            LVlist.Add(LVitem);
                        }
                    }
                }
                SqlReader.Close();

                SqlTransaction transaction = _sqlConnection.BeginTransaction();
                foreach (EPKLookupValue LVcheckitem in LVlist)
                {
                    int lookupUID = LVcheckitem.UID;
                    string lookupname = LVcheckitem.Name;

                    sCommand = "DELETE FROM EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@LV_uid", lookupUID);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                }
                transaction.Commit();

                // get rid of any orphaned attribute rows
                sCommand = "DELETE FROM EPG_RES_MANAGERS WHERE CODE_UID NOT IN (SELECT LV_UID FROM EPGP_LOOKUP_VALUES)";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.ExecuteNonQuery();
                sCommand = "DELETE FROM EPG_DEPT_MANAGERS WHERE CODE_UID NOT IN (SELECT LV_UID FROM EPGP_LOOKUP_VALUES)";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.ExecuteNonQuery();

                _sqlConnection.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeleteDepartments, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// deletes holiday schedule.
        /// </summary>
        /// <param name="sXML">XML defn of holiday schedule.</param>
        /// <param name="sresult">XML defn result.</param>
        /// <returns></returns>
        public bool DeleteHolidaySchedule(string sXML, out string sresult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeleteHolidaySchedule", "Input", sXML);

                CStruct xholschedule = new CStruct();
                xholschedule.LoadXML(sXML);
                int deletehsUID = xholschedule.GetIntAttr("Id");
                string dataid = xholschedule.GetStringAttr("DataId");

                CStruct xResult = new CStruct();
                xResult.Initialize("HolidaySchedule");
                CStruct xstatus = xResult.CreateSubStruct("Result");
                if (dataid.Length > 0) xResult.CreateStringAttr("DataId", dataid);

                if (deletehsUID > 0)
                {
                    SqlCommand SqlCommand;
                    SqlDataReader SqlReader;
                    string sCommand;

                    if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                    _sqlConnection.Open();

                    // no checks, we were not stopping a delete because a resource was using this Holiday Schedule (i.e. is in the Group) - leaving it that way

                    // make sure this isn't a group of a different flavour
                    string foundgroupname = "";
                    int foundgroupentity = 0;
                    sCommand = "SELECT GROUP_NAME, GROUP_ENTITY FROM EPG_GROUPS Where GROUP_ID=@Id";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@Id", deletehsUID);
                    SqlReader = SqlCommand.ExecuteReader();

                    if (SqlReader.Read())
                    {
                        foundgroupname = DBAccess.ReadStringValue(SqlReader["GROUP_NAME"]);
                        foundgroupentity = DBAccess.ReadIntValue(SqlReader["GROUP_ENTITY"]);
                    }
                    SqlReader.Close();

                    if (foundgroupname.Length > 0 && foundgroupentity != 11)
                    {
                        //throw new PFEException((int)PFEError.DeleteWorkSchedule, "Group with selected Id: " + foundgroupname + "  is not a Holiday Schedule");
                        xResult.CreateIntAttr("Id", deletehsUID);
                        xstatus.CreateIntAttr("Status", 1);
                        xstatus.CreateCDataSection("Group with selected Id: " + foundgroupname + "  is not a Holiday Schedule");
                    }
                    else
                    {
                        SqlTransaction transaction = _sqlConnection.BeginTransaction();

                        sCommand = "DELETE FROM EPG_GROUP_NONWORK_ITEMS WHERE GROUP_ID=@id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@id", deletehsUID);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        sCommand = "DELETE FROM EPG_GROUP_NONWORK_HOURS WHERE GROUP_ID=@id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@id", deletehsUID);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        sCommand = "DELETE FROM EPG_GROUP_MEMBERS WHERE GROUP_ID=@id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@id", deletehsUID);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        sCommand = "DELETE FROM EPG_GROUPS WHERE GROUP_ID=@id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@id", deletehsUID);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        transaction.Commit();
                        _sqlConnection.Close();

                        xResult.CreateIntAttr("Id", deletehsUID);
                        xstatus.CreateIntAttr("Status", 0);
                    }
                }
                else
                {
                    xstatus.CreateIntAttr("Status", 1);
                    xstatus.CreateCDataSection("No Holiday Schedule PFE Id");
                }

                sresult = xResult.XML();
                return true;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeleteHolidaySchedule, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Deletes  Work entries for a PI - Work2 from SP List.
        /// </summary>
        /// <param name="data">xml defn of the PI and and items.</param>
        /// <returns></returns>
        public bool DeleteListWork(string data, out string sResult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeleteListWork", "Input", data);

                string stablename = "EPGP_PI_WORK2";
                CStruct xItems = new CStruct();
                xItems.LoadXML(data);
                List<CStruct> listPIs = xItems.GetList("Project");


                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                SqlTransaction transaction = null;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                bool bupdateOK = true;
                String sErrorMessage = "empty";
                CStruct xResult = new CStruct();
                xResult.Initialize("Data");

                foreach (CStruct xProject in listPIs)
                {
                    string PIExtId = xProject.GetStringAttr("ExtId");
                    int nProjectID = 0;
                    int nTotalRows = 0;
                    // get the Project Id of this PI
                    sCommand = "SELECT PROJECT_ID From EPGP_PROJECTS Where PROJECT_EXT_UID=@ExtId";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@ExtId", PIExtId);
                    SqlReader = SqlCommand.ExecuteReader();
                    if (SqlReader.Read())
                    {
                        nProjectID = DBAccess.ReadIntValue(SqlReader["PROJECT_ID"]);
                    }
                    SqlReader.Close();
                    if (nProjectID == 0)
                    {
                        sErrorMessage = "PI not found";
                        bupdateOK = false;
                    }
                    else
                    {
                        bupdateOK = true;
                    }

                    if (bupdateOK == true)
                    {
                        sCommand = "Delete From " + stablename + " Where PROJECT_ID=@ProjectId And PW_ITEM_ID=@Id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@ProjectID", nProjectID);
                        SqlParameter pwid = SqlCommand.Parameters.Add("@Id", SqlDbType.NVarChar, 128);
                        SqlCommand.Transaction = transaction;

                        List<CStruct> listWIs = xProject.GetList("Item");
                        foreach (CStruct xWI in listWIs)
                        {
                            string WIExtId = xWI.GetStringAttr("Id");
                            pwid.Value = WIExtId;
                            int nrows = SqlCommand.ExecuteNonQuery();
                            nTotalRows += nrows;
                        }
                    }
                    CStruct xPIResult = xResult.CreateSubStruct("Project");
                    if (bupdateOK == true)
                    {
                        if (transaction != null) transaction.Commit();
                        xPIResult.CreateIntAttr("Status", 0);
                        xPIResult.CreateStringAttr("ExtId", PIExtId);
                        xPIResult.CreateCDataSection("Work rows deleted = " + nTotalRows.ToString());
                    }
                    else
                    {
                        if (transaction != null) transaction.Rollback();
                        xPIResult.CreateIntAttr("Status", 1);
                        xPIResult.CreateStringAttr("ExtId", PIExtId);
                        xPIResult.CreateCDataSection(sErrorMessage);
                    }
                    transaction = null;
                    nProjectID = 0;
                    nTotalRows = 0;
                }

                _sqlConnection.Close();
                sResult = xResult.XML();
                return bupdateOK;

            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeleteListWork, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// deletes lookup item.
        /// </summary>
        /// <param name="deletelookupUID">UID of lookup item.</param>
        /// <returns></returns>
        public bool DeleteLookup(int deletelookupUID)
        {
            try
            {
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                // we must check if this is a summary row and if so delete it and all its children - read lookup and make a list

                List<EPKLookupValue> LVlist = new List<EPKLookupValue>();
                EPKLookupValue LVitem;

                sCommand = "SELECT LV_UID,LV_VALUE,LV_ID,LV_LEVEL FROM EPGP_LOOKUP_VALUES" +
                    " WHERE LOOKUP_UID =(Select LOOKUP_UID From EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid)" +
                    " ORDER BY LV_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@LV_uid", deletelookupUID);
                SqlReader = SqlCommand.ExecuteReader();

                bool bfound = false;
                int levelthisvalue = 0;
                while (SqlReader.Read())
                {
                    int uid = DBAccess.ReadIntValue(SqlReader["LV_UID"]);
                    int level = DBAccess.ReadIntValue(SqlReader["LV_LEVEL"]);
                    string name = DBAccess.ReadStringValue(SqlReader["LV_VALUE"]);

                    if (bfound == false)
                    {
                        if (uid == deletelookupUID)
                        {
                            bfound = true;
                            levelthisvalue = level;
                            LVitem = new EPKLookupValue();
                            LVitem.UID = uid;
                            LVitem.Name = name;
                            LVlist.Add(LVitem);
                        }
                    }
                    else
                    {
                        if (level <= levelthisvalue) break;
                        else
                        {
                            LVitem = new EPKLookupValue();
                            LVitem.UID = uid;
                            LVitem.Name = name;
                            LVlist.Add(LVitem);
                        }
                    }
                }
                SqlReader.Close();

                SqlTransaction transaction = _sqlConnection.BeginTransaction();
                foreach (EPKLookupValue LVcheckitem in LVlist)
                {
                    int lookupUID = LVcheckitem.UID;
                    //string lookupname = LVcheckitem.Name;

                    sCommand = "DELETE FROM EPGP_LOOKUP_VALUES Where LV_UID=@LV_uid";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@LV_uid", lookupUID);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                }
                transaction.Commit();

                _sqlConnection.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeleteLookup, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// deletes a personal item.
        /// </summary>
        /// <param name="deleteitemUID">UID of item.</param>
        /// <returns></returns>
        public bool DeletePersonalItem(int deleteitemUID)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeletePersonalItem", "Input", "ItemUID=" + deleteitemUID.ToString());

                SqlCommand SqlCommand;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                SqlTransaction transaction = _sqlConnection.BeginTransaction();

                sCommand = "DELETE FROM EPG_NONWORK_HOURS Where NWI_ID=@NWI_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@NWI_uid", deleteitemUID);
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                sCommand = "DELETE FROM EPG_NONWORK_ITEMS Where NWI_ID=@NWI_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@NWI_uid", deleteitemUID);
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                transaction.Commit();

                _sqlConnection.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeletePersonalItem, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Deletes all Work entries for a PI - Work2 from SP List.
        /// </summary>
        /// <param name="data">xml defn of the PI </param>
        /// <returns></returns>
        public bool DeletePIListWork(string data, out string sResult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeletePIListWork", "Input", data);

                string stablename = "EPGP_PI_WORK2";
                CStruct xItems = new CStruct();
                xItems.LoadXML(data);
                List<CStruct> listPIs = xItems.GetList("Project");


                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                bool bupdateOK = true;
                String sErrorMessage = "empty";
                CStruct xResult = new CStruct();
                xResult.Initialize("Data");

                foreach (CStruct xProject in listPIs)
                {
                    string PIExtId = xProject.GetStringAttr("ExtId");
                    int nProjectID = 0;
                    int nTotalRows = 0;
                    // get the Project Id of this PI
                    sCommand = "SELECT PROJECT_ID From EPGP_PROJECTS Where PROJECT_EXT_UID=@ExtId";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@ExtId", PIExtId);
                    SqlReader = SqlCommand.ExecuteReader();
                    if (SqlReader.Read())
                    {
                        nProjectID = DBAccess.ReadIntValue(SqlReader["PROJECT_ID"]);
                    }
                    SqlReader.Close();
                    if (nProjectID == 0)
                    {
                        sErrorMessage = "PI not found";
                        bupdateOK = false;
                    }
                    else
                    {
                        bupdateOK = true;
                    }

                    if (bupdateOK == true)
                    {
                        sCommand = "Delete From " + stablename + " Where PROJECT_ID=@ProjectId";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@ProjectID", nProjectID);
                        int nrows = SqlCommand.ExecuteNonQuery();
                        nTotalRows += nrows;
                    }
                    CStruct xPIResult = xResult.CreateSubStruct("Project");
                    if (bupdateOK == true)
                    {
                        xPIResult.CreateIntAttr("Status", 0);
                        xPIResult.CreateStringAttr("ExtId", PIExtId);
                        xPIResult.CreateCDataSection("Work rows deleted = " + nTotalRows.ToString());
                    }
                    else
                    {
                        xPIResult.CreateIntAttr("Status", 1);
                        xPIResult.CreateStringAttr("ExtId", PIExtId);
                        xPIResult.CreateCDataSection(sErrorMessage);
                    }
                    nProjectID = 0;
                    nTotalRows = 0;
                }

                _sqlConnection.Close();
                sResult = xResult.XML();
                return bupdateOK;

            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeletePIListWork, exception.GetBaseMessage());
            }
        }

        private string CheckIfResourceExists(string extId, ref int wresId)
        {
            var sErrorMessage = string.Empty;

            if (extId.Length > 0)
            {
                var nMatchWresId = 0;

                using (var command = new SqlCommand("Select WRES_ID From EPG_RESOURCES Where WRES_EXT_UID=@ExtId", _sqlConnection))
                {
                    command.Parameters.AddWithValue("@ExtId", extId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nMatchWresId = SqlDb.ReadIntValue(reader[WresIdColumn]);
                        }
                    }
                }
                
                if (nMatchWresId <= 0)
                {
                    sErrorMessage = $"{NoResourceMatchesSuppliedMessage} ExtId";
                }
                else if (wresId > 0 && wresId != nMatchWresId)
                {
                    sErrorMessage = "Supplied ExtId does not match supplied Id";
                }

                wresId = nMatchWresId;
            }
            else if (wresId > 0)
            {
                using (var command = new SqlCommand("Select WRES_EXT_UID From EPG_RESOURCES Where WRES_ID=@WresId", _sqlConnection))
                {
                    command.Parameters.AddWithValue("@WresId", wresId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            sErrorMessage = $"{NoResourceMatchesSuppliedMessage} Id";
                        }
                    }
                }
            }
            else
            {
                sErrorMessage = $"{NoResourceMatchesSuppliedMessage} Id";
            }

            return sErrorMessage;
        }

        /// <summary>
        /// deletes role item, including any CCRs
        /// </summary>
        /// <param name="deletelookupUID">UID of role item.</param>
        /// <returns></returns>
        public bool DeleteRole(int deletelookupUID)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeleteRole", "Input", "RoleUID=" + deletelookupUID.ToString());

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                // we know this is a role so we know any Cost Category will be a leaf
                if (deletelookupUID <= 0) return false;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                SqlTransaction transaction = _sqlConnection.BeginTransaction();

                // delete Cost Categories then Categories
                sCommand = "Delete From EPGP_COST_CATEGORIES Where BC_ROLE=@role_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@role_uid", deletelookupUID);
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                sCommand = "Delete From EPGP_CATEGORIES Where CA_ROLE=@role_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@role_uid", deletelookupUID);
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                sCommand = "EPG_SP_CleanCTAdmin ";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                transaction.Commit();

                _sqlConnection.Close();

                return DeleteLookup(deletelookupUID);
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeleteRole, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// deletes cost category role item
        /// </summary>
        /// <param name="deleteCCUID">UID of cost category role item.</param>
        /// <returns></returns>
        public bool DeleteCCRole(int deleteCCUID)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeleteCCRole", "Input", "CCRoleUID=" + deleteCCUID.ToString());

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                // we know this is a cost category role and therefore a leaf
                if (deleteCCUID <= 0) return false;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                SqlTransaction transaction = _sqlConnection.BeginTransaction();

                // delete Cost Categories then Categories
                sCommand = "Delete From EPGP_COST_CATEGORIES Where CA_UID=@CCrole_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@CCrole_uid", deleteCCUID);
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                sCommand = "Delete From EPGP_CATEGORIES Where CA_UID=@CCrole_uid";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@CCrole_uid", deleteCCUID);
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                sCommand = "EPG_SP_CleanCTAdmin ";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                transaction.Commit();

                _sqlConnection.Close();

                return true;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeleteCCRole, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// counts Cost Categort Roles for a role item, part of Delete Role
        /// </summary>
        /// <param name="deletelookupUID">UID of role item</param>
        /// <returns></returns>
        public int CountRoleCategories(int deletelookupUID)
        {
            try
            {
                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                int numberCategorieswithRole;
                sCommand = "Select COUNT(*) as CountCategories From EPGP_CATEGORIES Where CA_ROLE=@RoleId";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Parameters.AddWithValue("@RoleId", deletelookupUID);
                SqlReader = SqlCommand.ExecuteReader();
                if (SqlReader.Read())
                    numberCategorieswithRole = DBAccess.ReadIntValue(SqlReader["CountCategories"]);
                else
                    numberCategorieswithRole = 0;
                SqlReader.Close();

                _sqlConnection.Close();
                return numberCategorieswithRole;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.CountRoleCategories, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// deletes a Work Schedule.
        /// </summary>
        /// <param name="deleteWorkScheduleUID">UID of Work Schedule.</param>
        /// <returns></returns>
        public bool DeleteWorkSchedule(string sXML, out string sresult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "DeleteWorkSchedule", "Input", sXML);

                CStruct xworkschedule = new CStruct();
                xworkschedule.LoadXML(sXML);
                int deleteWorkScheduleUID = xworkschedule.GetIntAttr("Id");
                string dataid = xworkschedule.GetStringAttr("DataId");

                CStruct xResult = new CStruct();
                xResult.Initialize("WorkSchedule");
                CStruct xstatus = xResult.CreateSubStruct("Result");
                if (dataid.Length > 0) xResult.CreateStringAttr("DataId", dataid);

                if (deleteWorkScheduleUID > 0)
                {
                    SqlCommand SqlCommand;
                    SqlDataReader SqlReader;
                    string sCommand;

                    if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                    _sqlConnection.Open();

                    // no checks, we were not stopping a delete because a resource was using this Work Schedule (i.e. in the Group) - leaving it that way

                    // make sure this isn't a group of a different flavour
                    string foundgroupname = "";
                    int foundgroupentity = 0;
                    sCommand = "SELECT GROUP_NAME, GROUP_ENTITY FROM EPG_GROUPS Where GROUP_ID=@Id";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@Id", deleteWorkScheduleUID);
                    SqlReader = SqlCommand.ExecuteReader();

                    if (SqlReader.Read())
                    {
                        foundgroupname = DBAccess.ReadStringValue(SqlReader["GROUP_NAME"]);
                        foundgroupentity = DBAccess.ReadIntValue(SqlReader["GROUP_ENTITY"]);
                    }
                    SqlReader.Close();

                    if (foundgroupname.Length > 0 && foundgroupentity != 10)
                    {
                        //throw new PFEException((int)PFEError.DeleteWorkSchedule, "Group with selected Id: " + foundgroupname + "  is not a Work Schedule");
                        xResult.CreateIntAttr("Id", deleteWorkScheduleUID);
                        xstatus.CreateIntAttr("Status", 1);
                        xstatus.CreateCDataSection("Group with selected Id: " + foundgroupname + "  is not a Work Schedule");

                    }
                    else
                    {
                        SqlTransaction transaction = _sqlConnection.BeginTransaction();

                        sCommand = "DELETE FROM EPG_GROUP_WEEKLYHOURS WHERE GROUP_ID=@id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@id", deleteWorkScheduleUID);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        sCommand = "DELETE FROM EPG_GROUP_MEMBERS WHERE GROUP_ID=@id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@id", deleteWorkScheduleUID);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        sCommand = "DELETE FROM EPG_GROUPS WHERE GROUP_ID=@id";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@id", deleteWorkScheduleUID);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        transaction.Commit();
                        _sqlConnection.Close();

                        xResult.CreateIntAttr("Id", deleteWorkScheduleUID);
                        xstatus.CreateIntAttr("Status", 0);
                    }
                }
                else
                {
                    xstatus.CreateIntAttr("Status", 1);
                    xstatus.CreateCDataSection("No Work Schedule PFE Id");
                }

                sresult = xResult.XML();
                return true;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.DeleteWorkSchedule, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Gets the cost category roles.
        /// </summary>
        /// <returns></returns>
        public IList<CostCategory> GetCostCategoryRoles()
        {
            var costCategories = new List<CostCategory>();

            var dataTable = new DataTable();

            using (var sqlCommand = new SqlCommand("SELECT CA_UID, CA_NAME, CA_LEVEL, CA_ROLE FROM dbo.EPGP_CATEGORIES ORDER BY CA_ID", _sqlConnection))
            {
                sqlCommand.CommandType = CommandType.Text;

                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }

                _sqlConnection.Open();

                dataTable.Load(sqlCommand.ExecuteReader());

                _sqlConnection.Close();
            }

            CostCategory parentCategory = null;

            foreach (var category in from row in dataTable.AsEnumerable()
                                     select new
                                     {
                                         CostCategoryRoleId = (int)row["CA_UID"],
                                         RoleId = (int)row["CA_ROLE"],
                                         Name = (string)row["CA_NAME"],
                                         Level = (int)row["CA_LEVEL"]
                                     })
            {
                var cat = category;

                if (cat.RoleId == 0)
                {
                    var costCategory = new CostCategory
                    {
                        Id = cat.CostCategoryRoleId,
                        Name = cat.Name,
                        Level = cat.Level,
                        CostCategories = new List<CostCategory>(),
                        Roles = new List<Role>()
                    };

                    parentCategory = (from c in costCategories where c.Level == cat.Level - 1 orderby c.Id descending select c).FirstOrDefault();

                    if (parentCategory == null)
                    {
                        costCategories.Add(costCategory);
                        parentCategory = costCategories.Last();
                    }
                    else
                    {
                        parentCategory.CostCategories.Add(costCategory);
                        parentCategory = parentCategory.CostCategories.Last();
                    }
                }
                else
                {
                    if (parentCategory != null)
                    {
                        parentCategory.Roles.Add(new Role
                        {
                            Id = cat.RoleId,
                            Name = cat.Name,
                            CostCategoryRoleId = cat.CostCategoryRoleId
                        });
                    }
                }
            }

            return costCategories;
        }

        private int GetUID(List<PfECategory> oldItems, int mcUID, int CATUID, ref int lMaxUID)
        {
            foreach (PfECategory categoryitem in oldItems)
            {
                if (categoryitem.mc_Uid == mcUID && categoryitem.ID == CATUID)
                {
                    return categoryitem.Uid;
                }
            }
            lMaxUID += 1;
            return lMaxUID;
        }

        private void InsertOnEpgLookupValue(Dictionary<int, PFELookup> dicDepts, SqlTransaction transaction, int nLookupId)
        {
            if (dicDepts == null)
            {
                throw new ArgumentNullException(nameof(dicDepts));
            }
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            const string SCommand = @"SET NOCOUNT ON;"
                       + "Insert Into EPGP_LOOKUP_VALUES (LOOKUP_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_EXT_UID)"
                       + " Values (@LV_lookupuid,@LV_value,@LV_fullvalue,@LV_id,@LV_level,@LV_extid);"
                       + "Select @@IDENTITY as NewID";

            using (var command = new SqlCommand(SCommand, _sqlConnection))
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                var pLookupUid = command.Parameters.Add("@LV_lookupuid", SqlDbType.Int);
                var pLevel = command.Parameters.Add("@LV_level", SqlDbType.Int);
                var pId = command.Parameters.Add("@LV_id", SqlDbType.Int);
                var pValue = command.Parameters.Add("@LV_value", SqlDbType.VarChar);
                var pFullvalue = command.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                var pExtid = command.Parameters.Add("@LV_extid", SqlDbType.VarChar);

                foreach (var deptitem in dicDepts)
                {
                    if (deptitem.Value.bflag == false)
                    {
                        pLookupUid.Value = nLookupId;
                        pLevel.Value = deptitem.Value.level;
                        pId.Value = deptitem.Value.ID;
                        pValue.Value = deptitem.Value.name;
                        pFullvalue.Value = deptitem.Value.fullname;
                        pExtid.Value = deptitem.Value.ExtId;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                deptitem.Value.UID = Convert.ToInt32(reader["NewID"]);
                            }
                        }
                    }
                }
            }
        }

        private void ApplyUpdateOnEpgpLookupValues(SqlTransaction transaction, DataTable dataTable)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            if (dataTable == null)
            {
                throw new ArgumentNullException(nameof(dataTable));
            }

            const string SCommand = 
                @"Update EPGP_LOOKUP_VALUES SET LV_VALUE=@LV_value, LV_FULLVALUE=@LV_fullvalue, LV_LEVEL=@LV_level, LV_ID=@LV_id, LV_EXT_UID=@LV_extid" +
                " Where LV_UID=@LV_uid";

            using (var command = new SqlCommand(SCommand, _sqlConnection))
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;

                var pUid = command.Parameters.Add("@LV_uid", SqlDbType.Int);
                var pLevel = command.Parameters.Add("@LV_level", SqlDbType.Int);
                var pId = command.Parameters.Add("@LV_id", SqlDbType.Int);
                var pValue = command.Parameters.Add("@LV_value", SqlDbType.VarChar);
                var pFullvalue = command.Parameters.Add("@LV_fullvalue", SqlDbType.VarChar);
                var pExtid = command.Parameters.Add("@LV_extid", SqlDbType.VarChar);

                foreach (DataRow row in dataTable.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        pUid.Value = row["LV_UID"];
                        pLevel.Value = row["LV_LEVEL"];
                        pId.Value = row["LV_ID"];
                        pValue.Value = row["LV_VALUE"];
                        pFullvalue.Value = row["LV_FULLVALUE"];
                        pExtid.Value = row["LV_EXT_UID"];
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void InitializeId(SqlTransaction transaction, string sCommand, out int id)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            using (var sqlCommand = new SqlCommand(sCommand, _sqlConnection))
            {
                sqlCommand.Transaction = transaction;


                using (var sqlReader = sqlCommand.ExecuteReader())
                {
                    id = GetNextIdValue(sqlReader);
                }
            }
        }

        private int GetNextIdValue(IDataReader sqlReader)
        {
            if (sqlReader == null)
            {
                throw new ArgumentNullException(nameof(sqlReader));
            }

            int id;
            if (sqlReader.Read())
            {
                id = SqlDb.ReadIntValue(sqlReader[MaxIdColumn]) + 1;
            }
            else
            {
                throw new PFEException((int)PFEError.UpdateWorkSchedule, CantCreateNewGroupRecordMessage);
            }

            return id;
        }

        private void InsertOrUpdateEpgGroups(SqlTransaction transaction, string sCommand, string sTitle, int id)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            using (var sqlCommand = new SqlCommand(sCommand, _sqlConnection))
            {
                sqlCommand.Transaction = transaction;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@NewName", sTitle);
                sqlCommand.ExecuteNonQuery();
            }
        }

        private void DeleteDuplicatedWork(SqlTransaction transaction, string sCommand, int nProjectId)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            using (var command = new SqlCommand(sCommand, _sqlConnection))
            {
                command.Parameters.AddWithValue("@ProjectID", nProjectId);
                command.CommandType = CommandType.Text;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
            }
        }

        private bool IsBUpdateOk(string piExtId, ref string sErrorMessage, ref int nProjectID)
        {
            using (var reader = GetEpgpProjects(piExtId))
            {
                if (reader.Read())
                {
                    nProjectID = SqlDb.ReadIntValue(reader["PROJECT_ID"]);
                }

                if (nProjectID == 0)
                {
                    sErrorMessage = PiNotFoundMessage;
                    return false;
                }

                return true;
            }
        }

        private SqlDataReader GetEpgpProjects(string piExtId)
        {
            if (string.IsNullOrWhiteSpace(piExtId))
            {
                throw new ArgumentException(nameof(piExtId));
            }

            const string SCommand = "SELECT PROJECT_ID From EPGP_PROJECTS Where PROJECT_EXT_UID=@ExtId";
            var sqlCommand = new SqlCommand(SCommand, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ExtId", piExtId);

            return sqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Updates the Personal Items List.
        /// </summary>
        /// <param name="data">xml defn of the items - flat list.</param>
        /// <returns></returns>
        public bool UpdatePersonalItems(string data, out string sResult, out string sError)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdatePersonalItems", "Input", data);

                CStruct xItems = new CStruct();
                xItems.LoadXML(data);
                Dictionary<int, PFELookup> dicItems = new Dictionary<int, PFELookup>();
                GetPersonalItems(xItems, "Item", dicItems);

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                bool bupdateOK = true;
                string sErrorMessage = "";
                List<PFELookup> errorItems = new List<PFELookup>();

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                SqlTransaction transaction = _sqlConnection.BeginTransaction();

                sCommand = "SELECT NWI_ID,NWI_SEQ,NWI_LEVEL,NWI_IS_ITEM,NWI_NAME,NWI_CHARGENUMBER,NWI_CHARGESTATUS From EPG_NONWORK_ITEMS";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Transaction = transaction;
                DataTable dataTable = new DataTable();
                dataTable.Load(SqlCommand.ExecuteReader());

                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string sName = DBAccess.ReadStringValue(row["NWI_NAME"]);
                        int nLevel = DBAccess.ReadIntValue(row["NWI_LEVEL"]);
                        int nUID = DBAccess.ReadIntValue(row["NWI_ID"]);
                        int nID = DBAccess.ReadIntValue(row["NWI_SEQ"]);
                        int nIsItem = DBAccess.ReadIntValue(row["NWI_IS_ITEM"]);
                        string sChargeNumber = DBAccess.ReadStringValue(row["NWI_CHARGENUMBER"]);
                        string sStatus = DBAccess.ReadStringValue(row["NWI_CHARGESTATUS"]);

                        int nkey = GetItemKey(dicItems, nUID, sName);
                        if (nkey > 0)
                        {
                            PFELookup value = dicItems[nkey];
                            value.bflag = true;
                            value.UID = nUID;   // if matched on title then set the UID we found

                            string sNewStatus;
                            if (value.Status == 1) sNewStatus = "1"; else sNewStatus = "0";

                            if (nID != value.ID || nLevel != value.level || sName != value.name || sChargeNumber != value.ChargeNumber || sStatus.ToUpper() != sNewStatus.ToUpper())
                            {
                                row["NWI_NAME"] = value.name;
                                row["NWI_LEVEL"] = value.level;
                                row["NWI_SEQ"] = value.ID;
                                row["NWI_IS_ITEM"] = 1;
                                row["NWI_CHARGENUMBER"] = value.ChargeNumber;
                                row["NWI_CHARGESTATUS"] = sNewStatus;
                            }
                        }
                        else
                        {
                            //  this is an error in Data Sync as Delete not allowed as part of update, all existing items must exist in update
                            bupdateOK = false;
                            sErrorMessage = "Incomplete Item List, value missing";
                            PFELookup oItemLookup = new PFELookup();
                            oItemLookup.name = sName;
                            oItemLookup.UID = nUID;
                            errorItems.Add(oItemLookup);
                        }
                    }
                    //  apply updates to dbs
                    if (bupdateOK)
                    {
                        sCommand = @"Update EPG_NONWORK_ITEMS SET NWI_NAME=@NWI_name, NWI_CHARGENUMBER=@NWI_cn, NWI_CHARGESTATUS=@NWI_cs, NWI_SEQ=@NWI_seq, NWI_LEVEL=@NWI_level,NWI_IS_ITEM=@NWI_isitem" +
                            " Where NWI_ID=@NWI_uid";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.CommandType = CommandType.Text;

                        SqlParameter pUID = SqlCommand.Parameters.Add("@NWI_uid", SqlDbType.Int);
                        SqlParameter pNAME = SqlCommand.Parameters.Add("@NWI_name", SqlDbType.VarChar);
                        SqlParameter pCN = SqlCommand.Parameters.Add("@NWI_cn", SqlDbType.VarChar);
                        SqlParameter pCS = SqlCommand.Parameters.Add("@NWI_cs", SqlDbType.VarChar);
                        SqlParameter pSEQ = SqlCommand.Parameters.Add("@NWI_seq", SqlDbType.Int);
                        SqlParameter pLEVEL = SqlCommand.Parameters.Add("@NWI_level", SqlDbType.Int);
                        SqlParameter pISITEM = SqlCommand.Parameters.Add("@NWI_isitem", SqlDbType.TinyInt);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState == DataRowState.Modified)
                            {
                                pUID.Value = row["NWI_ID"];
                                pNAME.Value = row["NWI_NAME"];
                                pCN.Value = row["NWI_CHARGENUMBER"];
                                pCS.Value = row["NWI_CHARGESTATUS"];
                                pSEQ.Value = row["NWI_SEQ"];
                                pLEVEL.Value = row["NWI_LEVEL"];
                                pISITEM.Value = row["NWI_IS_ITEM"];
                                SqlCommand.ExecuteNonQuery();
                            }
                        }
                    }

                }
                dataTable.Dispose();

                //  check for inserts
                //     note - if an item that doesn't exist is passed in, with or without an Id, it is created - so WE should always change or check its ExtId to the new ID passed back
                if (bupdateOK)
                {
                    // Get new UID
                    int newUID = 0;
                    sCommand = "SELECT MAX(NWI_ID) as MaxId FROM EPG_NONWORK_ITEMS";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Transaction = transaction;
                    SqlReader = SqlCommand.ExecuteReader();

                    if (SqlReader.Read())
                    {
                        newUID = DBAccess.ReadIntValue(SqlReader["MaxId"]);
                    }
                    else
                    {
                        throw new PFEException((int)PFEError.UpdatePersonalItems, "Can't create new Item record");
                    }
                    SqlReader.Close();

                    sCommand = @"Insert Into EPG_NONWORK_ITEMS (NWI_ID,NWI_NAME,NWI_CHARGENUMBER,NWI_CHARGESTATUS,NWI_SEQ,NWI_LEVEL,NWI_IS_ITEM)" +
                                " Values (@NWI_uid,@NWI_name,@NWI_cn,@NWI_cs,@NWI_seq,@NWI_level,@NWI_isitem)";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.CommandType = CommandType.Text;

                    SqlParameter pUID = SqlCommand.Parameters.Add("@NWI_uid", SqlDbType.Int);
                    SqlParameter pNAME = SqlCommand.Parameters.Add("@NWI_name", SqlDbType.VarChar);
                    SqlParameter pCN = SqlCommand.Parameters.Add("@NWI_cn", SqlDbType.VarChar);
                    SqlParameter pCS = SqlCommand.Parameters.Add("@NWI_cs", SqlDbType.VarChar);
                    SqlParameter pSEQ = SqlCommand.Parameters.Add("@NWI_seq", SqlDbType.Int);
                    SqlParameter pLEVEL = SqlCommand.Parameters.Add("@NWI_level", SqlDbType.Int);
                    SqlParameter pISITEM = SqlCommand.Parameters.Add("@NWI_isitem", SqlDbType.TinyInt);

                    foreach (KeyValuePair<int, PFELookup> lookupitem in dicItems)
                    {
                        if (lookupitem.Value.bflag == false)
                        {
                            newUID++;
                            pUID.Value = newUID;
                            pNAME.Value = lookupitem.Value.name;
                            pCN.Value = lookupitem.Value.ChargeNumber;
                            pSEQ.Value = lookupitem.Value.ID;
                            pLEVEL.Value = lookupitem.Value.level;
                            pISITEM.Value = 1;
                            string sStatus;
                            if (lookupitem.Value.Status == 1) sStatus = "1"; else sStatus = "0";
                            pCS.Value = sStatus;
                            SqlCommand.ExecuteNonQuery();
                            lookupitem.Value.UID = newUID;  // need to report the new UID back
                        }
                    }
                }
                if (bupdateOK) transaction.Commit();
                _sqlConnection.Close();

                CStruct xResult = new CStruct();
                xResult.Initialize("Data");
                if (bupdateOK == false)
                {
                    foreach (PFELookup personalitem in errorItems)
                    {
                        sErrorMessage += "  " + personalitem.name;
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, PFELookup> personalitem in dicItems)
                    {
                        CStruct xItem = xResult.CreateSubStruct("Item");
                        xItem.CreateIntAttr("Id", personalitem.Value.UID);
                        xItem.CreateStringAttr("DataId", personalitem.Value.DataId);
                    }
                }
                sResult = xResult.XML();
                sError = sErrorMessage;
                return bupdateOK;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.UpdatePersonalItems, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Updates Non Work entries for Personal Items for a resource.
        /// </summary>
        /// <param name="data">xml defn of the resources, Categories, and items.</param>
        /// <returns></returns>
        public bool UpdateResourceTimeoff(string data, out string sResult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateResourceTimeoff", "Input", data);

                CStruct xResource = new CStruct();
                xResource.LoadXML(data);

                int WresId = xResource.GetIntAttr("Id");
                string ExtId = xResource.GetStringAttr("ExtId");
                string DataId = xResource.GetStringAttr("DataId");

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                bool bupdateOK = true;
                CStruct xResult = new CStruct();
                xResult.Initialize("Resource");
                xResult.CreateIntAttr("Id", WresId);
                xResult.CreateStringAttr("DataId", DataId);
                xResult.CreateStringAttr("ExtId", ExtId);

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                // check if the resource exists and pick up the WresId if necessary
                var sErrorMessage = CheckIfResourceExists(ExtId, ref WresId);

                if (sErrorMessage.Length > 0)
                {
                    bupdateOK = false;
                    CStruct xStatus = xResult.CreateSubStruct("Result");
                    xStatus.CreateIntAttr("Status", 1);
                    xStatus.CreateCDataSection(sErrorMessage);
                }

                if (bupdateOK)
                {
                    // set up workhours and holiday information for this resource so we can check against
                    sCommand = "Select h.* From EPG_GROUP_WEEKLYHOURS h" +
                        " Inner Join EPG_GROUP_MEMBERS m On m.GROUP_ID=h.GROUP_ID" +
                        " Inner Join EPG_RESOURCES r On r.WRES_ID=m.MEMBER_UID" +
                        " WHERE r.WRES_ID = @WresId";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@WresId", WresId);
                    DataTable dataTable1 = new DataTable();
                    dataTable1.Load(SqlCommand.ExecuteReader());

                    sCommand = "Select h.* From EPG_GROUP_NONWORK_HOURS h" +
                        " Inner Join EPG_GROUP_MEMBERS m On m.GROUP_ID=h.GROUP_ID" +
                        " Inner Join EPG_RESOURCES r On r.WRES_ID=m.MEMBER_UID" +
                        " WHERE r.WRES_ID = @WresId";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@WresId", WresId);
                    DataTable dataTable2 = new DataTable();
                    dataTable2.Load(SqlCommand.ExecuteReader());

                    Workhours workhours = new Workhours();
                    workhours.Initialize(dataTable1, dataTable2);

                    dataTable1.Dispose();
                    dataTable2.Dispose();


                    // delete all the Time Off entries for this resource before add in new ones - this was changed May 2013 for V4.4.1 and does make more sense
                    SqlTransaction transaction = _sqlConnection.BeginTransaction();
                    sCommand = "DELETE FROM EPG_NONWORK_HOURS Where WRES_ID=@WresId";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@WresId", WresId);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                    List<CStruct> listcats = xResource.GetList("Category");
                    foreach (CStruct xSelCat in listcats)
                    {
                        int CatId = xSelCat.GetIntAttr("Id");
                        string CatExtId = xSelCat.GetStringAttr("ExtId");

                        CStruct xCatResult = xResult.CreateSubStruct("Category");
                        xCatResult.CreateIntAttr("Id", CatId);
                        xCatResult.CreateStringAttr("ExtId", CatExtId);

                        bool bCatUpdateOK = false;
                        bool bCatUpdateOKAsIs = true;

                        // check if Non Work item exists
                        sCommand = "Select 'found' where EXISTS (Select NWI_ID From EPG_NONWORK_ITEMS Where NWI_ID=@Id)";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.Parameters.AddWithValue("@Id", CatId);
                        SqlReader = SqlCommand.ExecuteReader();
                        if (SqlReader.Read())
                        {
                            bCatUpdateOK = true;
                        }
                        SqlReader.Close();

                        if (bCatUpdateOK)
                        {
                            List<CStruct> listItems = xSelCat.GetList("Item");
                            int nTotalRows = 0;

                            foreach (CStruct xSelItem in listItems)
                            {
                                string sHol = xSelItem.GetStringAttr("Date");
                                DateTime dHol = DateTime.Parse(sHol);
                                double hours = xSelItem.GetDoubleAttr("Hours", 0) * 100;

                                bool boktosave = true;
                                double dayworkhours = workhours.workhours(dHol);
                                if (hours > dayworkhours) { bCatUpdateOKAsIs = false; hours = dayworkhours; }
                                if (hours <= 0) { bCatUpdateOKAsIs = false; boktosave = false; }
                                if (hours > 2400) { bCatUpdateOKAsIs = false; hours = 2400; }
                                if (dHol < DateTime.Parse("1950-01-01") || dHol > DateTime.Parse("2100-01-01")) { bCatUpdateOKAsIs = false; boktosave = false; }

                                if (boktosave)
                                {
                                    sCommand = "INSERT Into EPG_NONWORK_HOURS (NWI_ID,WRES_ID,NWH_DATE,NWH_TIMESTAMP,NWH_HOURS,NWH_ENTEREDBY_WRES_ID)" +
                                            " Values (@NWI_uid,@WresId,@date,Getdate(),@hours,@UserWresId)";
                                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                                    SqlCommand.Parameters.AddWithValue("@NWI_uid", CatId);
                                    SqlCommand.Parameters.AddWithValue("@WresId", WresId);
                                    SqlCommand.Parameters.AddWithValue("@UserWresId", _userWResID);
                                    SqlCommand.Parameters.AddWithValue("@date", dHol);
                                    SqlCommand.Parameters.AddWithValue("@hours", hours);
                                    SqlCommand.Transaction = transaction;
                                    int nrows = SqlCommand.ExecuteNonQuery();
                                    nTotalRows += nrows;
                                    if (nrows == 0) bCatUpdateOKAsIs = false;
                                }
                            }

                            CStruct xStatus = xCatResult.CreateSubStruct("Result");
                            if (bCatUpdateOK && bCatUpdateOKAsIs)
                            {
                                //transaction.Commit();
                                xStatus.CreateIntAttr("Status", 0);
                            }
                            else if (bCatUpdateOK)
                            {
                                //transaction.Rollback();
                                //transaction.Commit();
                                xStatus.CreateIntAttr("Status", 0);
                                xStatus.CreateCDataSection(string.Format(@"Hours adjusted for this category, rows inserted for this category = {0:0}", nTotalRows));
                            }
                        }
                        else
                        {
                            CStruct xStatus = xCatResult.CreateSubStruct("Result");
                            xStatus.CreateIntAttr("Status", 1);
                            xStatus.CreateCDataSection(string.Format(@"Invalid category"));
                        }
                    }
                    transaction.Commit();
                }
                _sqlConnection.Close();

                sResult = xResult.XML();
                return bupdateOK;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.UpdateResourceTimeoff, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Updates the role lookup.
        /// </summary>
        /// <param name="data">xmll defn of role structure.</param>
        /// <returns></returns>
        public bool UpdateRoles(string data, out string sResult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateRoles", "Input", data);

                CStruct xItem = new CStruct();
                xItem.LoadXML(data);
                int RoleID = xItem.GetIntAttr("Id");
                string ExtId = xItem.GetStringAttr("ExtId");
                string Title = xItem.GetStringAttr("Title");

                if (RoleID == 0 && Title.Length == 0)
                {
                    sResult = "No Role Id or Title passed";
                    return false;
                }

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                int nLookupUID = 0;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                bool bupdateOK = true;
                string sErrorMessage = "";

                // first check that we have a Lookup Table defined for Roles
                var transaction = _sqlConnection.BeginTransaction();
                nLookupUID = GetNLookupId(transaction);

                if (nLookupUID <= 0)
                {
                    // must be first time we've saved a Role Lookup
                    //   LOOKUP_UID is Identity so read it back at same time as insert
                    nLookupUID = GetNewLookupId(transaction);
                    UpdateAdminRecord(transaction, nLookupUID);
                }

                if (nLookupUID <= 0)
                {
                    throw new PFEException((int)PFEError.UD_NoLookupTable, "Can't Find/Create Lookup Table");
                }

                if (bupdateOK)
                {
                    // look to update existing role - first on Id then on name
                    int nFoundRoleID = 0;
                    sCommand = "Select LV_UID From EPGP_LOOKUP_VALUES Where LOOKUP_UID=@LookupUID And LV_UID=@UID";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@LookupUID", nLookupUID);
                    SqlCommand.Parameters.AddWithValue("@UID", RoleID);
                    SqlCommand.Transaction = transaction;
                    SqlReader = SqlCommand.ExecuteReader();
                    if (SqlReader.Read()) nFoundRoleID = (int)SqlReader.GetInt32Safely("LV_UID");
                    SqlReader.Close();

                    if (nFoundRoleID == 0)  // no matching Id check for matxhing name
                    {
                        sCommand = "Select LV_UID From EPGP_LOOKUP_VALUES Where LOOKUP_UID=@LookupUID And LV_VALUE=@Name";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@LookupUID", nLookupUID);
                        SqlCommand.Parameters.AddWithValue("@Name", Title);
                        SqlCommand.Transaction = transaction;
                        SqlReader = SqlCommand.ExecuteReader();
                        if (SqlReader.Read()) nFoundRoleID = (int)SqlReader.GetInt32Safely("LV_UID");  // if there are > 1 we won't know but it's too late by then to check for dups!
                        SqlReader.Close();
                    }

                    if (nFoundRoleID > 0)  // update existing item
                    {
                        sCommand = @"Update EPGP_LOOKUP_VALUES SET LV_VALUE=@LV_value, LV_FULLVALUE=@LV_fullvalue, LV_EXT_UID=@LV_extid Where LV_UID=@LV_uid";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.CommandType = CommandType.Text;

                        SqlCommand.Parameters.AddWithValue("@LV_value", Title);
                        SqlCommand.Parameters.AddWithValue("@LV_fullvalue", Title);
                        SqlCommand.Parameters.AddWithValue("@LV_extid", ExtId);
                        SqlCommand.Parameters.AddWithValue("@LV_uid", nFoundRoleID);
                        SqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // we are adding a new role
                        //    need to figure max ID so we can use the next one
                        int NewId = 0;
                        sCommand = "SELECT MAX(LV_ID) as MaxId FROM EPGP_LOOKUP_VALUES Where LOOKUP_UID=@LookupUID";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@LookupUID", nLookupUID);
                        SqlCommand.Transaction = transaction;
                        SqlReader = SqlCommand.ExecuteReader();

                        if (SqlReader.Read())
                        {
                            NewId = DBAccess.ReadIntValue(SqlReader["MaxId"]) + 1;
                        }
                        SqlReader.Close();
                        if (NewId == 0) NewId = 1;

                        sCommand = @"SET NOCOUNT ON;"
                                   +
                                   "Insert Into EPGP_LOOKUP_VALUES (LOOKUP_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_EXT_UID)"
                                   + " Values (@LV_lookupuid,@LV_value,@LV_fullvalue,@LV_id,@LV_level,@LV_extid);"
                                   + "Select @@IDENTITY as NewID";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.CommandType = CommandType.Text;

                        SqlCommand.Parameters.AddWithValue("@LV_lookupuid", nLookupUID);
                        SqlCommand.Parameters.AddWithValue("@LV_level", 1);
                        SqlCommand.Parameters.AddWithValue("@LV_id", NewId);
                        SqlCommand.Parameters.AddWithValue("@LV_value", Title);
                        SqlCommand.Parameters.AddWithValue("@LV_fullvalue", Title);
                        SqlCommand.Parameters.AddWithValue("@LV_extid", ExtId);

                        SqlReader = SqlCommand.ExecuteReader();
                        if (SqlReader.Read())
                        {
                            int NewRoleId = Convert.ToInt32(SqlReader["NewID"]);
                        }
                        SqlReader.Close();
                    }

                    // update the role names in the Cost Categories in case of any name changes
                    sCommand = "Update EPGP_CATEGORIES Set CA_NAME = EPGP_LOOKUP_VALUES.LV_VALUE" +
                               " From EPGP_CATEGORIES Join EPGP_LOOKUP_VALUES On EPGP_CATEGORIES.CA_ROLE=EPGP_LOOKUP_VALUES.LV_UID";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.CommandType = CommandType.Text;
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                    sCommand = "Update EPGP_COST_CATEGORIES Set BC_NAME = EPGP_LOOKUP_VALUES.LV_VALUE" +
                               " From EPGP_COST_CATEGORIES Join EPGP_LOOKUP_VALUES On EPGP_COST_CATEGORIES.BC_ROLE=EPGP_LOOKUP_VALUES.LV_UID";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.CommandType = CommandType.Text;
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();
                }

                // update the role names in the Cost Categories in case of any name changes
                sCommand = "Update EPGP_CATEGORIES Set CA_NAME = EPGP_LOOKUP_VALUES.LV_VALUE" +
                           " From EPGP_CATEGORIES Join EPGP_LOOKUP_VALUES On EPGP_CATEGORIES.CA_ROLE=EPGP_LOOKUP_VALUES.LV_UID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                sCommand = "Update EPGP_COST_CATEGORIES Set BC_NAME = EPGP_LOOKUP_VALUES.LV_VALUE" +
                           " From EPGP_COST_CATEGORIES Join EPGP_LOOKUP_VALUES On EPGP_COST_CATEGORIES.BC_ROLE=EPGP_LOOKUP_VALUES.LV_UID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.CommandType = CommandType.Text;
                SqlCommand.Transaction = transaction;
                SqlCommand.ExecuteNonQuery();

                if (bupdateOK) transaction.Commit();
                _sqlConnection.Close();

                sResult = sErrorMessage;
                return bupdateOK;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.UpdateRoles, exception.GetBaseMessage());
            }
        }

        private int GetNLookupId(SqlTransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            var nLookupUid = 0;

            using (var command = new SqlCommand("SELECT ADM_ROLE_CODE FROM EPG_ADMIN", _sqlConnection))
            {
                command.Transaction = transaction;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nLookupUid = (int)reader.GetInt32Safely("ADM_ROLE_CODE");
                    }
                }
            }

            return nLookupUid;
        }

        private int GetNewLookupId(SqlTransaction transaction)
        {
            const string SLookupName = "Role Lookup";
            const string SCommand = "SET NOCOUNT ON;"
                + "INSERT Into EPGP_LOOKUP_TABLES  (LOOKUP_NAME) Values(@Name);"
                + "Select @@IDENTITY as NewID";

            var newId = 0;

            using (var command = new SqlCommand(SCommand, _sqlConnection))
            {
                command.Parameters.AddWithValue("@Name", SLookupName);
                command.Transaction = transaction;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        newId = Convert.ToInt32(reader["NewID"]);
                    }
                }
            }

            return newId;
        }

        private void UpdateAdminRecord(SqlTransaction transaction, int nLookupUid)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            using (var command = new SqlCommand(@"Update EPG_ADMIN SET ADM_ROLE_CODE = @LookupUID", _sqlConnection))
            {
                command.Parameters.AddWithValue("@LookupUID", nLookupUid);
                command.CommandType = CommandType.Text;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Updates the role lookup - old version.
        /// </summary>
        /// <param name="data">xmll defn of role structure.</param>
        /// <returns></returns>
        public bool UpdateRoles_OLD(string data, out string sResult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateRoles", "Input", data);

                CStruct xItems = new CStruct();
                xItems.LoadXML(data);
                int Level = 0;
                int ID = 0;
                string fullname = "";
                Dictionary<int, PFELookup> dicItems = new Dictionary<int, PFELookup>();
                // the result of GetLookup is to go through the structure and get all items in turn into a List
                GetLookup(xItems, "Role", dicItems, Level, ref ID, fullname);

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                int nLookupUID = 0;
                string sCommand;

                bool bupdateOK = true;
                string sErrorMessage = "";
                List<PFELookup> errorRoles = new List<PFELookup>();

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                var transaction = _sqlConnection.BeginTransaction();
                nLookupUID = GetNLookupId(transaction);

                if (nLookupUID <= 0)
                {
                    // must be first time we've saved a Role Lookup
                    //   LOOKUP_UID is Identity so read it back at same time as insert
                    nLookupUID = GetNewLookupId(transaction);
                    UpdateAdminRecord(transaction, nLookupUID);
                }

                if (nLookupUID <= 0)
                {
                    throw new PFEException((int)PFEError.UD_NoLookupTable, "Can't Find/Create Lookup Table");
                }

                // now we are passing in CC UID we need to figure the Role UID from the CC UID passed in
                sCommand =
                    "Select CA_UID,CA_ROLE,LV_VALUE From EPGP_CATEGORIES c Join EPGP_LOOKUP_VALUES l On l.LV_UID=c.CA_ROLE Order By CA_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Transaction = transaction;
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    int nCC_UID = DBAccess.ReadIntValue(SqlReader["CA_UID"]);
                    int nRole_UID = DBAccess.ReadIntValue(SqlReader["CA_ROLE"]);
                    string sRole_Name = DBAccess.ReadStringValue(SqlReader["LV_VALUE"]);

                    int nkey = GetItemKey(dicItems, nCC_UID, sRole_Name);
                    if (nkey > 0)
                    {
                        PFELookup value = dicItems[nkey];
                        if (value.UID_real == 0)
                        // we may have already encountered this role and if so stick with first one we hit?
                        {
                            value.bflag = true;
                            value.UID = nCC_UID; // if matched on title then set the UID we found
                            value.UID_real = nRole_UID;
                        }
                    }
                }
                SqlReader.Close();


                sCommand =
                    "SELECT LOOKUP_UID,LV_UID,LV_EXT_UID,LV_VALUE,LV_FULLVALUE,LV_ID,LV_LEVEL,LV_INACTIVE From EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @LookupUID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlCommand.Transaction = transaction;
                SqlCommand.Parameters.AddWithValue("@LookupUID", nLookupUID);
                DataTable dataTable = new DataTable();
                dataTable.Load(SqlCommand.ExecuteReader());

                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string sName = DBAccess.ReadStringValue(row["LV_VALUE"]);
                        int nLevel = DBAccess.ReadIntValue(row["LV_LEVEL"]);
                        //int nInActive = DBAccess.ReadIntValue(row["LV_INACTIVE"]);
                        int nUID = DBAccess.ReadIntValue(row["LV_UID"]);
                        int nID = DBAccess.ReadIntValue(row["LV_ID"]);
                        string sExtID = DBAccess.ReadStringValue(row["LV_EXT_UID"]);
                        string sFullName = DBAccess.ReadStringValue(row["LV_FULLVALUE"]);

                        int nkey = GetRoleItemKey(dicItems, nUID, sName); // can't use key now as key = CC UID
                        if (nkey > 0)
                        {
                            PFELookup value = dicItems[nkey];
                            value.bflag = true;
                            value.UID_real = nUID; // if matched on title then set the UID we found

                            if (nID != value.ID || nLevel != value.level || sName != value.name ||
                                sFullName != value.fullname || sExtID != value.ExtId)
                            {
                                row["LV_VALUE"] = value.name;
                                row["LV_LEVEL"] = value.level;
                                row["LV_EXT_UID"] = value.ExtId;
                                row["LV_ID"] = value.ID;
                                row["LV_FULLVALUE"] = value.fullname;
                            }
                        }
                        else
                        {
                            //  this is an error in Data Sync as Delete not allowed as part of update, all existing items must exist in update
                            bupdateOK = false;
                            sErrorMessage = "Incomplete Lookup List, value missing";
                            PFELookup oItemLookup = new PFELookup();
                            oItemLookup.name = sName;
                            oItemLookup.UID = nUID;
                            oItemLookup.ExtId = sExtID;
                            errorRoles.Add(oItemLookup);
                        }
                    }
                    //  apply updates to dbs
                    if (bupdateOK)
                    {
                        ApplyUpdateOnEpgpLookupValues(transaction, dataTable);
                    }

                }
                dataTable.Dispose();

                //  check for inserts
                //     note - if an item that doesn't exist is passed in, with or without an Id, it is created - so WE should always change or check its ExtId to the new ID passed back
                if (bupdateOK)
                {
                    InsertOnEpgLookupValue(dicItems, transaction, nLookupUID);

                    // update the role names in the Cost Categories in case of any name changes
                    sCommand = "Update EPGP_CATEGORIES Set CA_NAME = EPGP_LOOKUP_VALUES.LV_VALUE" +
                               " From EPGP_CATEGORIES Join EPGP_LOOKUP_VALUES On EPGP_CATEGORIES.CA_ROLE=EPGP_LOOKUP_VALUES.LV_UID";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.CommandType = CommandType.Text;
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                    sCommand = "Update EPGP_COST_CATEGORIES Set BC_NAME = EPGP_LOOKUP_VALUES.LV_VALUE" +
                               " From EPGP_COST_CATEGORIES Join EPGP_LOOKUP_VALUES On EPGP_COST_CATEGORIES.BC_ROLE=EPGP_LOOKUP_VALUES.LV_UID";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.CommandType = CommandType.Text;
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();
                }

                if (bupdateOK)
                {
                    // moved this call back to a higher level where it belons now we've got rid of this crazy sending Cat UID back instead of role UID
                    //  so transaction goes away again
                    //bupdateOK = UpdateCategoriesFromRoles(transaction);

                    if (bupdateOK)
                    {
                        //  need to set the CC UID for new roles (hopefully we will have added a CCR) - spagetti springs to mind
                        sCommand =
                            "Select CA_UID,CA_ROLE From EPGP_CATEGORIES c Join EPGP_LOOKUP_VALUES l On l.LV_UID=c.CA_ROLE Order By CA_ID";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Transaction = transaction;
                        SqlReader = SqlCommand.ExecuteReader();

                        while (SqlReader.Read())
                        {
                            int nCC_UID = DBAccess.ReadIntValue(SqlReader["CA_UID"]);
                            int nRole_UID = DBAccess.ReadIntValue(SqlReader["CA_ROLE"]);

                            int nkey = GetRoleItemKey(dicItems, nRole_UID);
                            if (nkey > 0)
                            {
                                PFELookup value = dicItems[nkey];
                                if (value.UID == 0)
                                {
                                    value.UID = nCC_UID;
                                }
                            }
                        }
                        SqlReader.Close();
                    }
                    else
                    {
                        throw new PFEException((int)PFEError.UpdateRoles, "Error generating Cost Categories");
                    }
                }

                if (bupdateOK) transaction.Commit();

                // used to do this inside UpdateCategoriesFromRoles but using CC UID changes everything
                if (bupdateOK)
                {
                    //SecurityLevels secLevel = SecurityLevels.AdminCalc;
                    //PortfolioEngineCore.AdminFunctions pec = new PortfolioEngineCore.AdminFunctions(_basepath, _username,
                    //                                                                                _pid, _company,
                    //                                                                                _dbcnstring, secLevel);
                    //bool bret = pec.CalcAllDefaultFTEs();
                    _sqlConnection.Close();
                }

                CStruct xResult = new CStruct();
                if (bupdateOK == false)
                {
                    //xResult.Initialize("Error");
                    foreach (PFELookup roleitem in errorRoles)
                    {
                        sErrorMessage += ": " + roleitem.name;
                    }
                    //xResult.CreateIntAttr("Id", 1);
                    //xResult.CreateCDataSection(sErrorMessage);
                    throw new PFEException((int)PFEError.UpdateRoles, sErrorMessage);
                }
                else
                {
                    xResult.Initialize("Data");
                    foreach (KeyValuePair<int, PFELookup> lookupitem in dicItems)
                    {
                        CStruct xItem = xResult.CreateSubStruct("Role");
                        xItem.CreateIntAttr("Id", lookupitem.Value.UID);  // sending back the UID of CC
                        xItem.CreateStringAttr("DataId", lookupitem.Value.DataId);
                    }
                }
                sResult = xResult.XML();
                return bupdateOK;   //  will always be true righgt now
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.UpdateRoles, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Updates(replaces) Work for a PI - either Work1(Planner) or Work2(MSP).
        /// </summary>
        /// <param name="data">xmll defn of work.</param>
        /// <returns></returns>
        public bool UpdateScheduledWork(int worktype, string data, out string sResult)
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateScheduledWork", "Input", data);

                string stablename = "EPGP_PI_WORK1";
                string sdeleteWorkFromTable = "EPGP_PI_WORK2";
                if (worktype == 2)
                {
                    stablename = "EPGP_PI_WORK2";
                    sdeleteWorkFromTable = "EPGP_PI_WORK1";
                }
                CStruct xItems = new CStruct();
                xItems.LoadXML(data);
                List<CStruct> listPIs = xItems.GetList("Project");


                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                SqlTransaction transaction = null;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                bool bupdateOK = true;
                String sErrorMessage = "empty";
                CStruct xResult = new CStruct();
                xResult.Initialize("Data");

                foreach (CStruct xProject in listPIs)
                {
                    string PIExtId = xProject.GetStringAttr("ExtId");
                    int PISourceId = xProject.GetIntAttr("Source");
                    int nProjectID = 0;
                    int nTotalRows = 0;

                    if (IsBUpdateOk(PIExtId, ref sErrorMessage, ref nProjectID))
                    {
                        // start a transaction and delete all existing work
                        transaction = _sqlConnection.BeginTransaction();
                        // Delete work from table to avoid duplicate work hours in resource analyzer 
                        // since resource analyzer combines data from EPGP_PI_WORK1 & EPGP_PI_WORK2 tables
                        sCommand = "Delete from " + sdeleteWorkFromTable + " Where PROJECT_ID=@ProjectID";
                        DeleteDuplicatedWork(transaction, sCommand, nProjectID);

                        sCommand = "Delete from " + stablename + " Where PROJECT_ID=@ProjectID";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@ProjectID", nProjectID);
                        SqlCommand.CommandType = CommandType.Text;
                        SqlCommand.Transaction = transaction;
                        SqlCommand.ExecuteNonQuery();

                        sCommand = "INSERT Into " + stablename + " (PROJECT_ID,WRES_ID,PW_ITEM_ID,PW_SOURCE,PW_DATE,PW_WORK,PW_MAJORCATEGORY)" +
                                " Values (@ProjectID,@WresId,@WI,@WIExtId,@date,@hours,'')";
                        // MajorCategory needs to be Empty String rather than NULL to Group correctly with TSWORK from PfE
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Parameters.AddWithValue("@ProjectID", nProjectID);
                        SqlParameter pwresid = SqlCommand.Parameters.Add("@WresId", SqlDbType.Int);
                        SqlParameter pwi = SqlCommand.Parameters.Add("@WI", SqlDbType.NVarChar, 255);
                        SqlParameter pextid = SqlCommand.Parameters.Add("@WIExtId", SqlDbType.Int);
                        SqlParameter pdate = SqlCommand.Parameters.Add("@date", SqlDbType.Date);
                        SqlParameter phours = SqlCommand.Parameters.Add("@hours", SqlDbType.Float);
                        SqlCommand.Transaction = transaction;

                        //  WORK now to be passed by resource as before so remove reference to WI
                        //List<CStruct> listWIs = xProject.GetList("Item");
                        //foreach (CStruct xWI in listWIs)
                        //{
                        //    //string WIExtId = xWI.GetStringAttr("ExtId");
                        //    string WIName = xWI.GetStringAttr("Id");
                        //    // not doing any checking on the WI, far as PfE is concerned these two values don't really matter

                        List<CStruct> listResources = xProject.GetList("Resource");
                        foreach (CStruct xResource in listResources)
                        {
                            int WresId = xResource.GetIntAttr("Id");
                            List<CStruct> listWork = xResource.GetList("Work");
                            foreach (CStruct xWork in listWork)
                            {
                                double hours = xWork.GetDoubleAttr("Hours", 0);
                                string sDate = xWork.GetStringAttr("Date");
                                DateTime workdate = DateTime.Parse(sDate);

                                pwresid.Value = WresId;
                                //pwi.Value = WIName;
                                pwi.Value = DBNull.Value;
                                pextid.Value = PISourceId;
                                pdate.Value = workdate;
                                phours.Value = hours * 100;
                                int nrows = SqlCommand.ExecuteNonQuery();
                                nTotalRows += nrows;
                            }
                        }
                        //}
                        // we've merrily added the records requested, if there are errors then find them now and rollback
                        if (bupdateOK == true)
                        {
                            sErrorMessage = "These Resources are not defined:";
                            sCommand = "Select DISTINCT WRES_ID From " + stablename + " Where PROJECT_ID=@ProjectId And WRES_ID Not In (Select WRES_ID From EPG_RESOURCES)";
                            SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                            SqlCommand.Parameters.AddWithValue("@ProjectId", nProjectID);
                            SqlCommand.Transaction = transaction;
                            SqlReader = SqlCommand.ExecuteReader();
                            while (SqlReader.Read())
                            {
                                sErrorMessage += " " + DBAccess.ReadIntValue(SqlReader["WRES_ID"]);
                                bupdateOK = false;
                            }
                            SqlReader.Close();
                        }
                    }
                    CStruct xPIResult = xResult.CreateSubStruct("Project");
                    if (bupdateOK == true)
                    {
                        if (transaction != null) transaction.Commit();
                        xPIResult.CreateIntAttr("Status", 0);
                        xPIResult.CreateStringAttr("ExtId", PIExtId);
                        xPIResult.CreateCDataSection("Work rows added = " + nTotalRows.ToString());
                    }
                    else
                    {
                        if (transaction != null) transaction.Rollback();
                        xPIResult.CreateIntAttr("Status", 1);
                        xPIResult.CreateStringAttr("ExtId", PIExtId);
                        xPIResult.CreateCDataSection(sErrorMessage);
                    }
                    transaction = null;
                    nProjectID = 0;
                    nTotalRows = 0;
                }
                _sqlConnection.Close();
                sResult = xResult.XML();

                // if there are any AutoPost instructions then set a job on the queue to do that
                int[,] autoposts = new int[10, 2];
                bool bRet = GetAutoPosts("ScheduledWork", ref autoposts);
                if (autoposts[0, 0] > 0)
                {
                    // there is at least one autopost instruction so set up a job
                    bRet = PostCostValuesForScheduledWork();
                }

                return bupdateOK;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.UpdateScheduledWork, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// Get Cost Category Roles
        /// </summary>
        /// <returns></returns>
        public string GetCCRs()
        {
            try
            {
                CStruct xResult = new CStruct();
                xResult.Initialize("Data");

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                // get all Categories
                sCommand = "Select c.*, r.LV_VALUE,r.LV_EXT_UID From EPGP_CATEGORIES c Left Join EPGP_LOOKUP_VALUES r On r.LV_UID=c.CA_ROLE Order by CA_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                List<PfECategory> categories = new List<PfECategory>();
                int maxlevel = 0;
                while (SqlReader.Read())
                {
                    PfECategory category = new PfECategory();
                    category.Uid = DBAccess.ReadIntValue(SqlReader["CA_UID"]);
                    category.Role = DBAccess.ReadIntValue(SqlReader["CA_ROLE"]);
                    category.Level = DBAccess.ReadIntValue(SqlReader["CA_LEVEL"]);
                    if (category.Role > 0)
                        category.Name = DBAccess.ReadStringValue(SqlReader["LV_VALUE"]);
                    else
                        category.Name = DBAccess.ReadStringValue(SqlReader["CA_NAME"]);
                    category.ExtId = DBAccess.ReadStringValue(SqlReader["LV_EXT_UID"]);
                    category.UOM = DBAccess.ReadStringValue(SqlReader["CA_UOM"]);
                    categories.Add(category);
                    if (category.Level > maxlevel) maxlevel = category.Level;
                }
                SqlReader.Close();

                if (maxlevel > 0)
                {
                    string[] ParentNodes = new string[maxlevel + 1];
                    foreach (PfECategory cat in categories)
                    {
                        string sParentName = "";
                        for (int i = 1; i < cat.Level; i++)
                        {
                            sParentName = sParentName + ParentNodes[i] + ".";
                        }
                        cat.ParentName = sParentName;
                        ParentNodes[cat.Level] = cat.Name;
                    }
                }

                SortedList<string, PfECategory> sortedCCRs = new SortedList<string, PfECategory>();
                string firstcat = "";
                foreach (PfECategory cat in categories)
                {
                    if (cat.Role > 0)
                    {
                        if (!sortedCCRs.ContainsKey(cat.Name + cat.ParentName))
                            sortedCCRs.Add(cat.Name + cat.ParentName, cat);  // order by Name then Parent? - various options here
                        if (firstcat.Length == 0) firstcat = cat.ParentName;
                    }
                }

                string sresult = "";
                if (sortedCCRs.Count > 0)
                {
                    // see if there is a common root to the Parent Name, if there is remove it
                    string commonroot = "";
                    string[] sections = firstcat.Split('.');
                    bool bmatch = true;
                    for (int i = 0; i < sections.GetUpperBound(0); i++)
                    {
                        string trycommonroot = commonroot + sections[i] + ".";
                        int len = trycommonroot.Length;
                        foreach (KeyValuePair<string, PfECategory> keyvalue in sortedCCRs)
                        {
                            if (keyvalue.Value.ParentName.Length < len || (trycommonroot != keyvalue.Value.ParentName.Substring(0, len))) bmatch = false;
                        }
                        if (bmatch == false) break;
                        commonroot = trycommonroot;
                    }
                    int cl = commonroot.Length;

                    CStruct xData = new CStruct();
                    xData.Initialize("Data");
                    foreach (KeyValuePair<string, PfECategory> keyvalue in sortedCCRs)
                    {
                        CStruct xRole = xData.CreateSubStruct("Role");
                        xRole.CreateIntAttr("Id", keyvalue.Value.Role);
                        xRole.CreateIntAttr("CCRId", keyvalue.Value.Uid);
                        xRole.CreateStringAttr("Title", keyvalue.Value.Name);
                        xRole.CreateStringAttr("ExtId", keyvalue.Value.ExtId);

                        string parentname = "";
                        if (keyvalue.Value.ParentName.Length >= cl)
                        {
                            parentname = keyvalue.Value.ParentName.Substring((cl));
                        }
                        xRole.CreateStringAttr("CCRName", parentname + keyvalue.Value.Name);  // want full name here not just parent name
                    }

                    sresult = xData.XML();
                }
                _dba.WriteImmTrace("DataSynch", "GetCCRs", "Output", sresult);

                return sresult;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.GetCCRs, exception.GetBaseMessage());
            }
        }


        /// <summary>
        /// Get Depts
        /// </summary>
        /// <returns></returns>
        public string GetDepts()
        {
            try
            {
                CStruct xData = new CStruct();
                xData.Initialize("Data");

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                // get Dept Managers
                Dictionary<int, string> dicManagers = new Dictionary<int, string>();
                Dictionary<int, string> dicExecutives = new Dictionary<int, string>();
                string Managers = "";
                string Executives = "";
                int lprecCodeUID = 0;
                sCommand = "Select dm.*,RES_NAME From EPG_DEPT_MANAGERS dm Join EPG_RESOURCES r On r.WRES_ID=dm.WRES_ID Order By CODE_UID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    int CodeUID = DBAccess.ReadIntValue(SqlReader["CODE_UID"]);
                    if (CodeUID != lprecCodeUID && lprecCodeUID > 0)
                    {
                        dicManagers.Add(lprecCodeUID, Managers);
                        dicExecutives.Add(lprecCodeUID, Executives);
                        Managers = "";
                        Executives = "";
                    }
                    lprecCodeUID = CodeUID;
                    int WresId = DBAccess.ReadIntValue(SqlReader["WRES_ID"]);
                    int canread = DBAccess.ReadIntValue(SqlReader["CANREAD"]);
                    int canwrite = DBAccess.ReadIntValue(SqlReader["CANWRITE"]);
                    if (canwrite == 1)
                    { if (Managers.Length == 0) Managers = WresId.ToString(); else Managers += "," + WresId.ToString(); }
                    else
                    { if (Executives.Length == 0) Executives = WresId.ToString(); else Executives += "," + WresId.ToString(); }
                }
                SqlReader.Close();
                if (lprecCodeUID > 0)
                {
                    dicManagers.Add(lprecCodeUID, Managers);
                    dicExecutives.Add(lprecCodeUID, Executives);
                }


                // get all Dept values
                sCommand = "Select * From EPGP_LOOKUP_VALUES Where LOOKUP_UID=(Select ADM_RPE_DEPT_CODE From EPG_ADMIN) Order by LV_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    CStruct xDept = xData.CreateSubStruct("Department");
                    int LV_UID = DBAccess.ReadIntValue(SqlReader["LV_UID"]);
                    xDept.CreateIntAttr("Id", LV_UID);
                    xDept.CreateIntAttr("Level", DBAccess.ReadIntValue(SqlReader["LV_LEVEL"]));
                    xDept.CreateStringAttr("Title", DBAccess.ReadStringValue(SqlReader["LV_VALUE"]));
                    xDept.CreateStringAttr("ExtId", DBAccess.ReadStringValue(SqlReader["LV_EXT_UID"]));
                    if (dicManagers.ContainsKey(LV_UID)) xDept.CreateStringAttr("Managers", dicManagers[LV_UID]);
                    if (dicExecutives.ContainsKey(LV_UID)) xDept.CreateStringAttr("Executives", dicExecutives[LV_UID]);
                }
                SqlReader.Close();

                _dba.WriteImmTrace("DataSynch", "GetDepts", "Output", xData.XML());

                return xData.XML();
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.GetDepts, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Get Work Schedules
        /// </summary>
        /// <returns></returns>
        public string GetWHs()
        {
            try
            {
                CStruct xData = new CStruct();
                xData.Initialize("Data");

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                int lDefaultWH = 0;
                sCommand = "Select ADM_DEF_FTE_WH From EPG_ADMIN";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    lDefaultWH = DBAccess.ReadIntValue(SqlReader["ADM_DEF_FTE_WH"]);
                }
                SqlReader.Close();

                // get all WH values
                sCommand = "Select wh.*,GROUP_NAME From EPG_GROUP_WEEKLYHOURS wh Join EPG_GROUPS g On g.GROUP_ID=wh.GROUP_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    CStruct xDet = xData.CreateSubStruct("WorkSchedule");
                    xDet.CreateIntAttr("Id", DBAccess.ReadIntValue(SqlReader["GROUP_ID"]));
                    xDet.CreateStringAttr("Title", DBAccess.ReadStringValue(SqlReader["GROUP_NAME"]));
                    xDet.CreateIntAttr("Monday", DBAccess.ReadIntValue(SqlReader["GROUP_HOURS_MON"]));
                    xDet.CreateIntAttr("Tuesday", DBAccess.ReadIntValue(SqlReader["GROUP_HOURS_TUE"]));
                    xDet.CreateIntAttr("Wednesday", DBAccess.ReadIntValue(SqlReader["GROUP_HOURS_WED"]));
                    xDet.CreateIntAttr("Thursday", DBAccess.ReadIntValue(SqlReader["GROUP_HOURS_THU"]));
                    xDet.CreateIntAttr("Friday", DBAccess.ReadIntValue(SqlReader["GROUP_HOURS_FRI"]));
                    xDet.CreateIntAttr("Saturday", DBAccess.ReadIntValue(SqlReader["GROUP_HOURS_SAT"]));
                    xDet.CreateIntAttr("Sunday", DBAccess.ReadIntValue(SqlReader["GROUP_HOURS_SUN"]));
                    if (lDefaultWH == DBAccess.ReadIntValue(SqlReader["GROUP_ID"])) xDet.CreateIntAttr("Default", 1);

                }
                SqlReader.Close();

                _dba.WriteImmTrace("DataSynch", "GetWHs", "Output", xData.XML());

                return xData.XML();
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.GetWHs, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Get Holiday Schedules
        /// </summary>
        /// <returns></returns>
        public string GetHOLs()
        {
            try
            {
                CStruct xData = new CStruct();
                xData.Initialize("Data");

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                int lDefaultHOL = 0;
                sCommand = "Select ADM_DEF_FTE_HOL From EPG_ADMIN";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    lDefaultHOL = DBAccess.ReadIntValue(SqlReader["ADM_DEF_FTE_HOL"]);
                }
                SqlReader.Close();

                // get all HOL values
                sCommand = "Select h.*,GROUP_NAME From EPG_GROUP_NONWORK_HOURS h Join EPG_GROUPS g On g.GROUP_ID=h.GROUP_ID";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                int lcurrentHOL = 0;
                CStruct xDet = new CStruct();
                while (SqlReader.Read())
                {
                    int lHOL = DBAccess.ReadIntValue(SqlReader["GROUP_ID"]);
                    if (lHOL != lcurrentHOL)
                    {
                        xDet = xData.CreateSubStruct("HolidaySchedule");
                        xDet.CreateIntAttr("Id", lHOL);
                        xDet.CreateStringAttr("Title", DBAccess.ReadStringValue(SqlReader["GROUP_NAME"]));
                        if (lDefaultHOL == lHOL) xDet.CreateIntAttr("Default", 1);
                        lcurrentHOL = lHOL;
                    }

                    CStruct xDet1 = xDet.CreateSubStruct("Holiday");
                    xDet1.CreateStringAttr("Title", DBAccess.ReadStringValue(SqlReader["NWH_COMMENT"]));
                    xDet1.CreateDoubleAttr("Hours", (DBAccess.ReadDoubleValue(SqlReader["NWH_HOURS"])) / 100);
                    xDet1.CreateDateAttr("Date", DBAccess.ReadDateValue(SqlReader["NWH_DATE"]));

                }
                SqlReader.Close();

                _dba.WriteImmTrace("DataSynch", "GetHOLs", "Output", xData.XML());

                return xData.XML();
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.GetHOLs, exception.GetBaseMessage());
            }
        }

        /// <summary>
        /// Get Personal Items
        /// </summary>
        /// <returns></returns>
        public string GetPersonalItems()
        {
            try
            {
                CStruct xData = new CStruct();
                xData.Initialize("Data");

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                sCommand = "Select NWI_NAME,NWI_ID From EPG_NONWORK_ITEMS Order By NWI_SEQ";
                SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                SqlReader = SqlCommand.ExecuteReader();

                while (SqlReader.Read())
                {
                    CStruct xDet = xData.CreateSubStruct("Item");
                    xDet.CreateIntAttr("Id", DBAccess.ReadIntValue(SqlReader["NWI_ID"]));
                    xDet.CreateStringAttr("Title", DBAccess.ReadStringValue(SqlReader["NWI_NAME"]));
                }
                SqlReader.Close();

                _dba.WriteImmTrace("DataSynch", "GetPersonalItems", "Output", xData.XML());

                return xData.XML();
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.GetPersonalItems, exception.GetBaseMessage());
            }
        }


        // Private Methods (4) 

        private int GetItemKey(Dictionary<int, PFELookup> dicItems, int nUID, string sName)
        {
            if (dicItems.ContainsKey(nUID))
            {
                return nUID;
            }
            else
            {
                // check if an entry exists with the correct Title passed in w/o a UID, if so assume it is the right one
                foreach (KeyValuePair<int, PFELookup> lookupitem in dicItems)
                {
                    if (lookupitem.Value.bflag == false)   // && lookupitem.Value.UID == 0) // don't check if already matched
                    {
                        if (lookupitem.Value.name == sName)
                        {
                            return lookupitem.Key;
                        }
                    }
                }
                return 0;
            }
        }

        private void GetLookup(CStruct xItems, string itemname, Dictionary<int, PFELookup> Items, int Level, ref int ID, string fullname)
        {
            List<CStruct> listitems = xItems.GetList(itemname);
            Level += 1;
            string parentname = fullname;
            foreach (CStruct xSelItem in listitems)
            {
                string sItemName = xSelItem.GetStringAttr("Title");
                int UID = xSelItem.GetIntAttr("Id");
                string ExtId = xSelItem.GetStringAttr("ExtId");
                string DataId = xSelItem.GetStringAttr("DataId");
                string sManagers = xSelItem.GetStringAttr("Managers");
                string sExecutives = xSelItem.GetStringAttr("Executives");
                PFELookup oItemLookup = new PFELookup();
                oItemLookup.name = sItemName;
                if (parentname.Length == 0) oItemLookup.fullname = sItemName; else oItemLookup.fullname = parentname + "." + sItemName;
                oItemLookup.UID = UID;
                ID++; oItemLookup.ID = ID;
                oItemLookup.ExtId = ExtId;
                oItemLookup.DataId = DataId;
                oItemLookup.level = Level;
                oItemLookup.bflag = false;

                int ientry;
                oItemLookup.Managers = new List<int>();
                oItemLookup.Executives = new List<int>();
                string[] sarray = sManagers.Split(',');
                foreach (string sentry in sarray) if (int.TryParse(sentry, out ientry)) oItemLookup.Managers.Add(ientry);
                sarray = sExecutives.Split(',');
                foreach (string sentry in sarray) if (int.TryParse(sentry, out ientry)) oItemLookup.Executives.Add(ientry);

                int nkey;
                if (oItemLookup.UID == 0) nkey = oItemLookup.ID + 200000000; else nkey = oItemLookup.UID;
                Items.Add(nkey, oItemLookup);

                GetLookup(xSelItem, itemname, Items, Level, ref ID, oItemLookup.fullname);
            }
        }

        private void GetPersonalItems(CStruct xItems, string itemname, Dictionary<int, PFELookup> Items)
        {
            List<CStruct> listitems = xItems.GetList(itemname);
            int ID = 0;
            foreach (CStruct xSelItem in listitems)
            {
                string sItemName = xSelItem.GetStringAttr("Title");
                int UID = xSelItem.GetIntAttr("Id");
                string ExtId = xSelItem.GetStringAttr("ExtId");
                string DataId = xSelItem.GetStringAttr("DataId");
                string ChargeNumber = xSelItem.GetStringAttr("ChargeCode");
                int Status = xSelItem.GetIntAttr("ChargeStatus");
                PFELookup oItemLookup = new PFELookup();
                oItemLookup.name = sItemName;
                oItemLookup.UID = UID;
                ID++; oItemLookup.ID = ID;
                oItemLookup.level = 1;
                oItemLookup.ExtId = ExtId;
                oItemLookup.DataId = DataId;
                oItemLookup.ChargeNumber = ChargeNumber;
                oItemLookup.Status = Status;
                oItemLookup.bflag = false;

                int nkey;
                if (oItemLookup.UID == 0) nkey = oItemLookup.ID + 200000000; else nkey = oItemLookup.UID;
                Items.Add(nkey, oItemLookup);
            }
        }

        private int GetRoleItemKey(Dictionary<int, PFELookup> dicItems, int nUID)
        {
            // looking for Role where key is CC so have to troll through - at this point we are finished creating/updating roles so have a full list
            foreach (KeyValuePair<int, PFELookup> lookupitem in dicItems)
            {
                if (lookupitem.Value.UID_real == nUID)
                {
                    return lookupitem.Key;
                }
            }
            return 0;
        }

        private int GetRoleItemKey(Dictionary<int, PFELookup> dicItems, int nUID, string sName)
        {
            // looking for Role where key is CC so have to troll through
            foreach (KeyValuePair<int, PFELookup> lookupitem in dicItems)
            {
                if (lookupitem.Value.UID_real == nUID) // role was found as a CC so we have the Role UID in here
                {
                    return lookupitem.Key;
                }
            }

            // this role wasn't found in the input data as a CC but check again on name to see if there is a matching role which didn't have a CC
            foreach (KeyValuePair<int, PFELookup> lookupitem in dicItems)
            {
                if (lookupitem.Value.bflag == false)   // && lookupitem.Value.UID == 0) // don't check if already matched
                {
                    if (lookupitem.Value.name == sName)
                    {
                        lookupitem.Value.UID = 0;  // clear out incorrect CC UID as now is a new one
                        return lookupitem.Key;
                    }
                }
            }

            return 0;
        }

        #endregion Methods 

        #region Nested Classes (3) 


        private class CField
        {
            #region Fields (4) 

            public int CFField;
            public int CFTable;
            public int Id;
            public string Name;

            #endregion Fields 
        }
        private class PfECategory
        {
            #region Fields (6) 

            public int ID;
            public int Level;
            public string Name;
            public string ParentName;
            public int Role;
            public int Uid;
            public int mc_Uid;
            public string ExtId;
            public string UOM;

            #endregion Fields 
        }
        #endregion Nested Classes 
        /// <summary>
        /// Updates a Work Schedule.
        /// </summary>
        /// <param name="data">xmll defn of Work Schedule.</param>
        /// <returns></returns>
        public bool UpdateWorkSchedule(string sXML, out string sresult)
        //  unlike in PFE we are not touching the members of the group here, just changing the attributes if the group exists already
        {
            try
            {
                _dba.WriteImmTrace("DataSynch", "UpdateWorkSchedule", "Input", sXML);

                CStruct xWSItem = new CStruct();
                xWSItem.LoadXML(sXML);
                string sTitle = xWSItem.GetStringAttr("Title");
                int Id = xWSItem.GetIntAttr("Id");
                string dataid = xWSItem.GetStringAttr("DataId");
                string sDefault = xWSItem.GetStringAttr("Default");
                double dSunday = xWSItem.GetDoubleAttr("Sunday", 0);
                double dMonday = xWSItem.GetDoubleAttr("Monday", 0);
                double dTuesday = xWSItem.GetDoubleAttr("Tuesday", 0);
                double dWednesday = xWSItem.GetDoubleAttr("Wednesday", 0);
                double dThursday = xWSItem.GetDoubleAttr("Thursday", 0);
                double dFriday = xWSItem.GetDoubleAttr("Friday", 0);
                double dSaturday = xWSItem.GetDoubleAttr("Saturday", 0);

                CStruct xResult = new CStruct();
                xResult.Initialize("WorkSchedule");
                CStruct xstatus = xResult.CreateSubStruct("Result");
                if (dataid.Length > 0) xResult.CreateStringAttr("DataId", dataid);

                SqlCommand SqlCommand;
                SqlDataReader SqlReader;
                string sCommand;

                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();

                //  the group record is updated or added - EPG_GROUPS
                //  the Work Schedule record is deleted and reset - EPG_GROUP_WEEKLYHOURS

                SqlTransaction transaction = _sqlConnection.BeginTransaction();

                // check if group exists
                //     If an Id is given then first looks by Id, if that fails then by Title, if that also fails then it's an error
                //     If an Id not given it looks by Title and if found updates, otherwise it is new
                bool boktocontinue = true;
                string sExistingTitle = "";
                bool bFound = false;
                if (Id > 0)
                {
                    sCommand = "SELECT GROUP_NAME FROM EPG_GROUPS Where GROUP_ID=@Id And GROUP_ENTITY=10";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@Id", Id);
                    SqlCommand.Transaction = transaction;
                    SqlReader = SqlCommand.ExecuteReader();
                    if (SqlReader.Read())
                    {
                        sExistingTitle = DBAccess.ReadStringValue(SqlReader["GROUP_NAME"]);
                        bFound = true;
                    }
                    SqlReader.Close();
                }
                if (bFound == false)
                {
                    sCommand = "SELECT GROUP_ID FROM EPG_GROUPS Where GROUP_NAME=@Name And GROUP_ENTITY=10";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@Name", sTitle);
                    SqlCommand.Transaction = transaction;
                    SqlReader = SqlCommand.ExecuteReader();
                    if (SqlReader.Read())
                    {
                        sExistingTitle = sTitle;
                        Id = DBAccess.ReadIntValue(SqlReader["GROUP_ID"]);
                        bFound = true;
                    }
                    SqlReader.Close();
                }
                if (Id > 0 && bFound == false)
                {
                    //  Group doesn't exist for given Id
                    xResult.CreateIntAttr("Id", Id);
                    xstatus.CreateIntAttr("Status", 1);
                    xstatus.CreateCDataSection("WorkSchedule Group not found in PortfolioEngine");
                    boktocontinue = false;
                }

                if (boktocontinue)
                {
                    if (Id > 0)
                    {
                        // record exists
                        if (sExistingTitle != sTitle)
                        {
                            sCommand = @"Update EPG_GROUPS SET GROUP_NAME=@NewName Where GROUP_ID=@Id";
                            InsertOrUpdateEpgGroups(transaction, sCommand, sTitle, Id);
                        }
                    }
                    else
                    {
                        // insert new GROUPS record
                        sCommand = "SELECT MAX(GROUP_ID) as MaxId FROM EPG_GROUPS";
                        InitializeId(transaction, sCommand, out Id);

                        sCommand = "INSERT Into EPG_GROUPS (GROUP_ID,GROUP_NAME,GROUP_ENTITY) Values (@Id,@NewName,10)";
                        InsertOrUpdateEpgGroups(transaction, sCommand, sTitle, Id);
                    }

                    // Delete and then Insert attributes record
                    sCommand = "Delete From EPG_GROUP_WEEKLYHOURS Where GROUP_ID=@Id";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@Id", Id);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                    sCommand = "INSERT Into EPG_GROUP_WEEKLYHOURS (GROUP_ID,GROUP_HOURS_MON,GROUP_HOURS_TUE,GROUP_HOURS_WED,GROUP_HOURS_THU,GROUP_HOURS_FRI,GROUP_HOURS_SAT,GROUP_HOURS_SUN)" +
                                " Values (@Id,@mon,@tue,@wed,@thu,@fri,@sat,@sun)";
                    SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    SqlCommand.Parameters.AddWithValue("@Id", Id);
                    SqlCommand.Parameters.AddWithValue("@mon", dMonday * 100);
                    SqlCommand.Parameters.AddWithValue("@tue", dTuesday * 100);
                    SqlCommand.Parameters.AddWithValue("@wed", dWednesday * 100);
                    SqlCommand.Parameters.AddWithValue("@thu", dThursday * 100);
                    SqlCommand.Parameters.AddWithValue("@fri", dFriday * 100);
                    SqlCommand.Parameters.AddWithValue("@sat", dSaturday * 100);
                    SqlCommand.Parameters.AddWithValue("@sun", dSunday * 100);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                    // check out the DEFAULT setting
                    if (sDefault == "1")
                    {
                        sCommand = @"Update EPG_ADMIN Set ADM_DEF_FTE_WH=@WHId";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Transaction = transaction;
                        SqlCommand.Parameters.AddWithValue("@WHId", Id);
                        SqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        bool bResetDefault = false;
                        sCommand = "SELECT ADM_DEF_FTE_WH,ADM_DEF_FTE_HOL FROM EPG_ADMIN";
                        SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                        SqlCommand.Transaction = transaction;
                        SqlReader = SqlCommand.ExecuteReader();
                        if (SqlReader.Read())
                        {
                            if (DBAccess.ReadIntValue(SqlReader["ADM_DEF_FTE_WH"]) == Id) bResetDefault = true;
                        }
                        SqlReader.Close();

                        if (bResetDefault == true)
                        {
                            sCommand = @"Update EPG_ADMIN Set ADM_DEF_FTE_WH=@WHId";
                            SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                            SqlCommand.Transaction = transaction;
                            SqlCommand.Parameters.AddWithValue("@WHId", 0);
                            SqlCommand.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    // check if this WH specification is used to calculate default FTEs
                    bool bCalcDefaultFTEs = false;
                    //sCommand = "SELECT ADM_DEF_FTE_WH,ADM_DEF_FTE_HOL FROM EPG_ADMIN";
                    //SqlCommand = new SqlCommand(sCommand, _sqlConnection);
                    //SqlReader = SqlCommand.ExecuteReader();
                    //if (SqlReader.Read())
                    //{
                    //    if (DBAccess.ReadIntValue(SqlReader["ADM_DEF_FTE_WH"]) == Id) bCalcDefaultFTEs=true;
                    //}
                    //SqlReader.Close();

                    // now we are told the answer to this (no point recalculating if just set OFF) so:
                    if (sDefault == "1") bCalcDefaultFTEs = true;

                    //SecurityLevels secLevel = SecurityLevels.AdminCalc;
                    //PortfolioEngineCore.AdminFunctions pec = new PortfolioEngineCore.AdminFunctions(_basepath, _username, _pid, _company, _dbcnstring,  secLevel);
                    //bool bret = pec.CalcRPAllAvailabilities();

                    //if (bCalcDefaultFTEs == true) bret = pec.CalcAllDefaultFTEs();
                    bool bret = AdminFunctions.CalcRPAllAvailabilities(_dba);
                    if (bCalcDefaultFTEs == true) bret = AdminFunctions.CalcAllDefaultFTEs(_dba);

                    _sqlConnection.Close();

                    xResult.CreateIntAttr("Id", Id);
                    xstatus.CreateIntAttr("Status", 0);
                }

                sresult = xResult.XML();
                return true;
            }
            catch (Exception exception)
            {
                throw new PFEException((int)PFEError.UpdateWorkSchedule, exception.GetBaseMessage());
            }
        }

        private bool GetAutoPosts(string datatype, ref int[,] autoposts)
        {
            if (_PFECN.State != ConnectionState.Open) _PFECN.Open();
            int larrayindex = 0;
            int lmainkey = -1;
            if (datatype.ToUpper() == "SCHEDULEDWORK") { lmainkey = 21; }
            else if (datatype.ToUpper() == "TIMESHEETS") { lmainkey = 31; }
            else if (datatype.ToUpper() == "RESOURCEPLANS") { lmainkey = 1; }

            const string cmdText = "SELECT CT_ID,CB_ID From EPGP_COST_VALUES_TOSET Where TOSET_MAINKEY=@mainkey";
            SqlCommand oCommand = new SqlCommand(cmdText, _dba.Connection);
            oCommand.Parameters.AddWithValue("@mainkey", lmainkey);
            SqlDataReader reader = oCommand.ExecuteReader();
            if (reader.Read())
            {
                if (autoposts.GetUpperBound(0) >= larrayindex)
                {
                    autoposts[larrayindex, 0] = DBAccess.ReadIntValue(reader["CT_ID"]);
                    autoposts[larrayindex, 1] = DBAccess.ReadIntValue(reader["CB_ID"]);
                }
                larrayindex++;
            }
            reader.Close();

            return true;
        }

        private bool PostCostValuesForScheduledWork()
        {
            try
            {
                if (_PFECN.State != ConnectionState.Open) _PFECN.Open();

                CStruct xRequest = new CStruct();
                xRequest.Initialize("Request");
                CStruct xSet = xRequest.CreateSubStruct("EPKSet");
                xSet.CreateString("EPKAuth", "");
                CStruct xProcess = xSet.CreateSubStruct("EPKProcess");
                // SetSavePSCostValues = 5
                xProcess.CreateInt("RequestNo", 5);
                var job = new PfeJob()
                {
                    Context = 0,
                    Session = Guid.NewGuid().ToString(),
                    UserId = _dba.UserWResID,
                    Comment = "PostCostValues Scheduled Work ",
                    ContextData = xRequest.XML()
                };
                job.Queue(new DbRepository(_dba), new Msmq(), _basepath);
            }
            catch (Exception ex)
            {
                _dba.HandleException("PostCostValuesForTimesheetData", (StatusEnum)99999, ex);
            }
            finally { _dba.Close(); }
            return (_dba.Status == StatusEnum.rsSuccess);
        }


        /// <summary>
        /// Posts Cost Values for a CB/CT combination, optional list of PROJECT_IDs
        /// </summary>
        /// <param name="data">xml defn of CB and CT, optional one or more PI entries </param>
        /// <returns>Result is status info, instruction is request to send data to WE</returns>
        public bool PostCostValues(string data, out string sResult, out string sPostInstruction)
        {
            // can be called from webservice or directly from 'outside' as well as within PfE code?
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            string sCVResult = "";
            bool bRet = dbaCostValues.PostCostValues(_dba, data, out sCVResult, out sPostInstruction);
            _sqlConnection.Close();
            sResult = sCVResult;
            return bRet;
        }
    }
}
