using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore.WEIntegration
{
    public class WEIntegration : PFEBase
    {
        public WEIntegration(string basepath, string username, string pid, string company, string dbcnstring, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, SecurityLevels.BaseAdmin, bDebug)
        {
            debug.AddMessage("Loading WEIntegration Class");

        }

        public string SetDatabaseVersion(string data)
        {
            // <SetDatabaseVersion>
            //   <Params /> 
            //   <Data>
            //       <Database Version="43000000" Comment="comment" />
            //   </Data>

            CStruct xData = new CStruct();
            xData.LoadXML(data);
            CStruct xDataInputElement = xData.GetSubStruct("Data");
            CStruct xDBS = xDataInputElement.GetSubStruct("Database");

            int nVersion = xDBS.GetIntAttr("Version");
            string comment = xDBS.GetStringAttr("Comment");
            if (comment.Length == 0) comment = "PEC.SetDatabaseVersion";

            if (_PFECN.State != ConnectionState.Open) _PFECN.Open();

            try
            {
                string sCommand = "Insert into dbo.EPG_SYSTEM (SY_VERSION,SY_INSTALLED,SY_INCLUDE) VALUES(@Version, GETDATE(),@Comment)";
                SqlCommand SqlCommand = new SqlCommand(sCommand, _PFECN);
                SqlCommand.Parameters.AddWithValue("@Version", nVersion);
                SqlCommand.Parameters.AddWithValue("@Comment", comment);
                SqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return "FAILED: " + ex.Message;
            }

            _PFECN.Close();

            return "SUCCESS";
        }

        public string ExecuteReportExtract(string data)
        {

            CStruct xData = new CStruct();
            xData.LoadXML(data);

            // ExecuteReportExtract>
            //   <Params /> 
            //   <Data>
            //       <ReportExtract Connection="" Execute="1" />
            //   </Data>

            CStruct xDataInputElement = xData.GetSubStruct("Data");
            CStruct xExtract = xDataInputElement.GetSubStruct("ReportExtract");

            string sConnection = xExtract.GetStringAttr("Connection");
            string sExecute = xExtract.GetStringAttr("Execute");

            if (_PFECN.State != ConnectionState.Open) _PFECN.Open();

            bool bOkToContinue = true;
            if (sConnection.Length > 0)
            {
                bOkToContinue = ImportReportingConnection(sConnection);
            }

            if (sExecute == "1")
            {
                string sCommand = "Select ADM_WE_REPORTING_DB_CONNECT From EPG_ADMIN";
                SqlCommand SqlCommand = new SqlCommand(sCommand, _PFECN);
                SqlDataReader SqlReader = SqlCommand.ExecuteReader();

                string sWEReportingDBConnect = "";
                if (SqlReader.Read())
                {
                    sWEReportingDBConnect = DBAccess.ReadStringValue(SqlReader["ADM_WE_REPORTING_DB_CONNECT"]);
                }
                SqlReader.Close();

                if (sWEReportingDBConnect.Length > 0)
                {
                    string sBasePath = this._basepath;
                    string sPfEConnection = convertToSQL(this._dbcnstring);
                    PfEReporting.PfE_ReportingDB reporting = new PfEReporting.PfE_ReportingDB();
                    reporting.ReportingDB_Build(sPfEConnection, sWEReportingDBConnect, sBasePath);
                }
            }
            _PFECN.Close();

            return "STATUS";
        }

        public string PostTimesheetData(string data)
        {
            _dba.WriteImmTrace("WEIntegration", "PostTimesheetData", "Input", data);

            CStruct xData = new CStruct();
            xData.LoadXML(data);

            // PostTimesheetData  or  Data       or  Timesheets  
            //   Data                  Timesheets      Timesheet
            //     Timesheets             Timesheet    Timesheet
            //       Timesheet            Timesheet

            // not sure what kind of error/status return is neeeded
            //  will throw an exception if resource or project not found anywhere and nothing will be updated - nothing to return as a result
            //  alternative would be to build up status for each Timesheet entry and return the whole thing
            //  or just return entries in error ...

            // June 12, 2013 - jason tells me to just ignore records where NOT FOUND in PfE as error is annoying and "it really doesn't affect anything"
            // Following result from test after changes and with an invalid resource and an invalid date:
            //    <PostTimesheetData>
            //       <Result Status="0">
            //       </Result>
            //       <Result Status="0" Timesheets="3" WithError="2" />
            //       </PostTimesheetData>
            //  don't know why Result tag there twice but thought safer to leave it alone

            CStruct xTimesheets=null;
            CStruct xDataInputElement = xData.GetSubStruct("Data");
            if (xDataInputElement == null) xTimesheets = xData.GetSubStruct("Timesheets");
            else xTimesheets = xDataInputElement.GetSubStruct("Timesheets");
            if (xTimesheets == null) xTimesheets = xData;

            List<CStruct> listTSs = xTimesheets.GetList("Timesheet");
            if (listTSs == null)
            {
                //Only throw this exception in case of listTSs object is returning Null value.
                //If listTSs object is not null then continue execution of EPKSynch job as per usual.
                throw new PFEException((int)PFEError.PostTimesheetData, "No Timesheet information");
            }

            SqlCommand SqlCommand;
            SqlDataReader SqlReader;
            SqlTransaction transaction = null;
            string sCommand;

            if (_PFECN.State != ConnectionState.Open)  _PFECN.Open();

            // we'll stash the PROJECT_IDs we get from the WEPIDs as we hit them, same for WRESIDs
            Dictionary<string, int> projectIDs = new Dictionary<string, int>();
            Dictionary<string, PfEResource> resourceIDs = new Dictionary<string, PfEResource>();
            PfEResource oResource;

            CStruct xResult = new CStruct();
            xResult.Initialize("Result");

            int lprocessedtimesheets = 0;
            int linvalidtimesheets = 0;
            foreach (CStruct xTS in listTSs)
            {
                string resource = xTS.GetStringAttr("Resource");
                string sDate = xTS.GetStringAttr("period_start");
                DateTime periodstart = DateTime.Parse(sDate);
                sDate = xTS.GetStringAttr("period_end");
                DateTime periodend = DateTime.Parse(sDate);

                bool bUpdateOK = true;
                // have we hit this resource already? If not need to pick up info
                oResource = null;
                if (!resourceIDs.TryGetValue(resource, out oResource))
                {
                    // no point using TS Department here as unknown to WE
                    sCommand = "Select WRES_ID,RES_NAME,WRES_RP_DEPT as DeptId, LV_VALUE as Department From EPG_RESOURCES r" +
                                " Left Join EPGP_LOOKUP_VALUES lv On lv.LV_UID=r.WRES_RP_DEPT" +
                                " Where r.WRES_NT_ACCOUNT=@NTLogin";
                    SqlCommand = new SqlCommand(sCommand, _PFECN);
                    SqlCommand.Parameters.AddWithValue("@NTLogin", resource);
                    SqlReader = SqlCommand.ExecuteReader();
                    if (SqlReader.Read())
                    {
                        oResource=new PfEResource();
                        oResource.WresID = DBAccess.ReadIntValue(SqlReader["WRES_ID"]);
                        oResource.DeptId = DBAccess.ReadIntValue(SqlReader["DeptId"]);
                        oResource.Dept = DBAccess.ReadStringValue(SqlReader["Department"]);
                        resourceIDs.Add(resource, oResource);
                    }
                    SqlReader.Close();
                }
                if (oResource == null)
                {
                    if (bUpdateOK) { bUpdateOK = false; linvalidtimesheets += 1;}

                    // old drastic reaction to error
                    //throw new PFEException((int)PFEError.PostTimesheetData, "Resource Not Found: " + resource);

                    // errors not even reported now - per Jason June 2013: Users don't want to see these errors, they don't mean anything
                    //CStruct xError = xResult.CreateSubStruct("Error");
                    //xError.CreateCDataSection("Resource Not Found: " + resource);
                }
                else
                {
                    // ready to deal with this Timeshet - start a transaction and delete existing hours information
                    transaction = _PFECN.BeginTransaction();
                    int ChgId = 0;
                    sCommand = "Delete EPG_WE_ACTUALHOURS From EPG_WE_ACTUALHOURS" +
                               " join EPG_WE_CHARGES On EPG_WE_ACTUALHOURS.WEH_CHG_UID=EPG_WE_CHARGES.WEC_CHG_UID" +
                               " Where WRES_ID=@WresId and (WEH_DATE>=@Start and WEH_DATE <=@End)";
                    SqlCommand = new SqlCommand(sCommand, _PFECN);
                    SqlCommand.Parameters.AddWithValue("@WresId", oResource.WresID);
                    SqlCommand.Parameters.AddWithValue("@Start", periodstart);
                    SqlCommand.Parameters.AddWithValue("@End", periodend);
                    SqlCommand.CommandType = CommandType.Text;
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();

                    List<CStruct> listHours = xTS.GetList("Hours");
                    if (!(listHours == null) && (listHours.Count > 0))
                    {
                        PfEChargeItem oCurrentCharge = new PfEChargeItem();
                        foreach (CStruct xHours in listHours)
                        {
                            string PIExtId = xHours.GetStringAttr("Project");
                            int lProjID = 0;

                            // have we hit this project already? If not need to pick up PROJECT_ID from dbs
                            if (!projectIDs.TryGetValue(PIExtId, out lProjID))
                            {
                                sCommand = "Select PROJECT_ID From EPGP_PROJECTS Where PROJECT_EXT_UID=@ExtId";
                                SqlCommand = new SqlCommand(sCommand, _PFECN);
                                SqlCommand.Parameters.AddWithValue("@ExtId", PIExtId);
                                SqlCommand.Transaction = transaction;
                                SqlReader = SqlCommand.ExecuteReader();
                                if (SqlReader.Read())
                                {
                                    lProjID = DBAccess.ReadIntValue(SqlReader["PROJECT_ID"]);
                                }
                                SqlReader.Close();
                            }
                            if (lProjID <= 0)
                            {
                                if (bUpdateOK) { bUpdateOK = false; linvalidtimesheets += 1; }

                                // old drastic reaction to error
                                //if (transaction != null) transaction.Rollback();
                                //throw new PFEException((int)PFEError.PostTimesheetData,"Project Not Found: " + resource + ", " + PIExtId);

                                // errors not even reported now - June 2013
                                //CStruct xError = xResult.CreateSubStruct("Error");
                                //xError.CreateCDataSection("Project Not Found: " + resource + ", " + PIExtId);
                            }
                            else
                            {

                                PfEChargeItem oCharge = new PfEChargeItem();
                                oCharge.ProjectID = lProjID;
                                oCharge.WresId = oResource.WresID;
                                oCharge.DeptId = oResource.DeptId;
                                oCharge.Dept = oResource.Dept;
                                oCharge.MajorCategory = xHours.GetStringAttr("MajorCategory");
                                oCharge.Category = xHours.GetStringAttr("Category");
                                string sWorkDate = xHours.GetStringAttr("Date");
                                DateTime dWorkdate = DateTime.Parse(sWorkDate);
                                double dHours = xHours.GetDoubleAttr("Hours", 0)*100;
                                int lType = xHours.GetIntAttr("Type");

                                // we have a charge fully defined
                                if (dWorkdate < periodstart || dWorkdate > periodend)
                                {
                                    if (bUpdateOK) { bUpdateOK = false; linvalidtimesheets += 1; }                                
                                    
                                    // old drastic reaction to error
                                    //if (transaction != null) transaction.Rollback();
                                    //throw new PFEException((int) PFEError.PostTimesheetData,"Timesheet Information outside specified range: " + resource +", " + PIExtId);
                                    
                                    // errors not even reported now - June 2013
                                    //CStruct xError = xResult.CreateSubStruct("Error");
                                    //xError.CreateCDataSection("Timesheet Information outside specified range: " + resource + ", " + PIExtId);
                                }
                                else
                                {
                                    SetCharge(transaction, oCharge, oCurrentCharge, dWorkdate, dHours, lType, ref ChgId);
                                    oCurrentCharge = oCharge;
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
                lprocessedtimesheets += 1;
            }

            //if (linvalidtimesheets > 0) { xResult.CreateIntAttr("Status", 1); }
            //else { xResult.CreateIntAttr("Status", 0); }
            xResult.CreateIntAttr("Status", 0);

            xResult.CreateIntAttr("Timesheets", lprocessedtimesheets);
            xResult.CreateIntAttr("WithError", linvalidtimesheets);

            // if there are any AutoPost instructions then set a job on the queue to do that
            int[,] autoposts = new int[10, 2];
            bool bRet = GetAutoPosts("Timesheets", ref autoposts);
            if (autoposts[0, 0] > 0)
            {
                // there is at least one autopost instruction so set up a job
                bRet = PostCostValuesForTimesheetData();
            }


            return xResult.XML();
        }

        private bool GetAutoPosts(string datatype, ref int[,] autoposts)
        {
            if (_PFECN.State != ConnectionState.Open) _PFECN.Open();
            int larrayindex = 0;
            int lmainkey = -1;
            if (datatype.ToUpper() == "TIMESHEETS") { lmainkey = 31; }
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

        private bool PostCostValuesForTimesheetData()
        {
            try
            {
                if (_PFECN.State != ConnectionState.Open) _PFECN.Open();

                CStruct xRequest = new CStruct();
                xRequest.Initialize("Request");
                CStruct xSet = xRequest.CreateSubStruct("EPKSet");
                xSet.CreateString("EPKAuth", "");
                CStruct xProcess = xSet.CreateSubStruct("EPKProcess");
                // SetSaveCostValuesWEActuals = 8
                xProcess.CreateInt("RequestNo", 8);

                const string sCommand = "INSERT INTO EPG_JOBS(JOB_GUID,JOB_CONTEXT,JOB_SESSION,WRES_ID,JOB_SUBMITTED,JOB_STATUS,JOB_COMMENT,JOB_CONTEXT_DATA) VALUES(@JOB_GUID,@JOB_CONTEXT,@JOB_SESSION,@WRES_ID,@JOB_SUBMITTED,@JOB_STATUS,@JOB_COMMENT,@JOB_CONTEXT_DATA)";
                SqlCommand cmd = new SqlCommand(sCommand, _dba.Connection, _dba.Transaction);
                cmd.Parameters.AddWithValue("@JOB_GUID", Guid.NewGuid());
                //    qjcCustom = 0
                cmd.Parameters.AddWithValue("@JOB_CONTEXT", 0);
                cmd.Parameters.AddWithValue("@JOB_SESSION", Guid.NewGuid());
                cmd.Parameters.AddWithValue("@WRES_ID", _dba.UserWResID);
                cmd.Parameters.AddWithValue("@JOB_SUBMITTED", DateTime.Now);
                cmd.Parameters.AddWithValue("@JOB_STATUS", 0); // For now let 0 mean Not Started
                cmd.Parameters.AddWithValue("@JOB_COMMENT", "PostCostValues Timesheet Data ");
                cmd.Parameters.AddWithValue("@JOB_CONTEXT_DATA", xRequest.XML());
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                _dba.HandleException("PostCostValuesForTimesheetData", (StatusEnum)99999, ex);
            }
            finally { _dba.Close(); }
            return (_dba.Status == StatusEnum.rsSuccess);
        }


        private bool SetCharge(SqlTransaction transaction, PfEChargeItem oCharge, PfEChargeItem oCurrentCharge, DateTime dWorkdate, double dHours, int lType, ref int ChgId)
        {
            SqlCommand SqlCommand;
            SqlDataReader SqlReader;
            string sCommand;

            // Are these hours for the same Charge as the prev one?
            if (oCharge.ProjectID==oCurrentCharge.ProjectID && oCharge.WresId==oCurrentCharge.WresId  
                            && oCharge.DeptId==oCurrentCharge.DeptId && oCharge.Dept==oCurrentCharge.Dept
                            && oCharge.MajorCategory==oCurrentCharge.MajorCategory && oCharge.Category==oCurrentCharge.Category)
            {
                // use CHG_UID from previous time around
            }
            else
            {
                // See if charge record we need already exists
                ChgId = 0;
                sCommand = "Select WEC_CHG_UID From EPG_WE_CHARGES" +
                            " WHERE WRES_ID=@WresId and PROJECT_ID=@ProjId and WEC_MAJORCATEGORY = @MC and WEC_CATEGORY = @Cat" +
                            " and WEC_DEPT_NAME = @DeptName and WEC_DEPT_UID = @DeptId";
                SqlCommand = new SqlCommand(sCommand, _PFECN);
                SqlCommand.Parameters.AddWithValue("@WresId", oCharge.WresId);
                SqlCommand.Parameters.AddWithValue("@ProjId", oCharge.ProjectID);
                SqlCommand.Parameters.AddWithValue("@MC", oCharge.MajorCategory);
                SqlCommand.Parameters.AddWithValue("@Cat", oCharge.Category);
                SqlCommand.Parameters.AddWithValue("@DeptName", oCharge.Dept);
                SqlCommand.Parameters.AddWithValue("@DeptId", oCharge.DeptId);
                SqlCommand.Transaction = transaction;
                SqlReader = SqlCommand.ExecuteReader();
                if (SqlReader.Read())
                {
                    ChgId = DBAccess.ReadIntValue(SqlReader["WEC_CHG_UID"]);
                }
                SqlReader.Close();

                if (ChgId <= 0)
                //  add new charge record
                {
                    sCommand = "SET NOCOUNT ON;"
                                + "INSERT Into EPG_WE_CHARGES "
                                + " (WRES_ID,PROJECT_ID,WEC_MAJORCATEGORY,WEC_CATEGORY,WEC_DEPT_NAME,WEC_DEPT_UID)"
                                + " Values(@WresId,@ProjId,@MC,@Cat,@DeptName,@DeptId);"
                                + "Select @@IDENTITY as NewID";
                    SqlCommand = new SqlCommand(sCommand, _PFECN);
                    SqlCommand.Parameters.AddWithValue("@WresId", oCharge.WresId);
                    SqlCommand.Parameters.AddWithValue("@ProjId", oCharge.ProjectID);
                    SqlCommand.Parameters.AddWithValue("@MC", oCharge.MajorCategory);
                    SqlCommand.Parameters.AddWithValue("@Cat", oCharge.Category);
                    SqlCommand.Parameters.AddWithValue("@DeptName", oCharge.Dept);
                    SqlCommand.Parameters.AddWithValue("@DeptId", oCharge.DeptId);
                    SqlCommand.Transaction = transaction;
                    SqlReader = SqlCommand.ExecuteReader();
                    if (SqlReader.Read())
                    {
                        ChgId = Convert.ToInt32(SqlReader["NewID"]);
                    }
                    SqlReader.Close();
                }
            }

            if (ChgId > 0)
            {
                // see if we already have an ActualHours record for this date, if so update it, otherwise insert a new one
                int oldChgId = 0;
                sCommand = "Select WEH_CHG_UID From EPG_WE_ACTUALHOURS" +
                            " WHERE WEH_CHG_UID=@ChgId and WEH_DATE=@Date";
                SqlCommand = new SqlCommand(sCommand, _PFECN);
                SqlCommand.Parameters.AddWithValue("@ChgId", ChgId);
                SqlCommand.Parameters.AddWithValue("@Date", dWorkdate);
                SqlCommand.Transaction = transaction;
                SqlReader = SqlCommand.ExecuteReader();
                if (SqlReader.Read())
                {
                    oldChgId = DBAccess.ReadIntValue(SqlReader["WEH_CHG_UID"]);
                }
                SqlReader.Close();

                if (ChgId == oldChgId)
                {
                    sCommand = "Update EPG_WE_ACTUALHOURS ";
                    if (lType == 2)
                        sCommand += " Set WEH_OVERTIMEHOURS = @Hours";
                    else
                        sCommand += " Set WEH_NORMALHOURS = @Hours";
                    sCommand += " Where WEH_CHG_UID = @ChgId And WEH_DATE = @Date";

                    SqlCommand = new SqlCommand(sCommand, _PFECN);
                    SqlCommand.Parameters.AddWithValue("@ChgId", ChgId);
                    SqlCommand.Parameters.AddWithValue("@Date", dWorkdate);
                    SqlCommand.Parameters.AddWithValue("@Hours", dHours);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();
                }
                else
                {
                    double dNormalhours = 0;
                    double dOvertimehours = 0;
                    if (lType == 2)
                        dOvertimehours = dHours;
                    else
                        dNormalhours = dHours;
                    sCommand = "INSERT Into EPG_WE_ACTUALHOURS (WEH_CHG_UID,WEH_DATE,WEH_NORMALHOURS,WEH_OVERTIMEHOURS) Values (@ChgId,@Date,@NHours,@OHours)";
                    SqlCommand = new SqlCommand(sCommand, _PFECN);
                    SqlCommand.Parameters.AddWithValue("@ChgId", ChgId);
                    SqlCommand.Parameters.AddWithValue("@Date", dWorkdate);
                    SqlCommand.Parameters.AddWithValue("@NHours", dNormalhours);
                    SqlCommand.Parameters.AddWithValue("@OHours", dOvertimehours);
                    SqlCommand.Transaction = transaction;
                    SqlCommand.ExecuteNonQuery();
                }
            }

            return true;
        }

        public DataTable GetPfeFields(int type)
        {
            if(_PFECN.State != ConnectionState.Open)
                _PFECN.Open();

            SqlCommand oCommand = new SqlCommand("EPG_SP_ReadFieldsForWE", _PFECN);
            oCommand.Parameters.AddWithValue("@SelectMode", type);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader dr = oCommand.ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("epkField");
            dt.Columns.Add("epkFieldId");
            dt.Columns.Add("epkFieldType");

            while(dr.Read())
            {
                int nFieldID = (int)dr["FIELD_ID"];
                string sFieldName = (string)dr["FIELD_NAME"];
                //int nFieldFormat = (int)reader["FIELD_FORMAT"];
                dt.Rows.Add(new object[] { sFieldName, nFieldID, type });
            }

            dr.Close();

            _PFECN.Close();

            return dt;
        }

        public DataTable GetPfeCostViews()
        {
            if(_PFECN.State != ConnectionState.Open)
                _PFECN.Open();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("costView");
            dt.Columns.Add("costViewId");

            SqlCommand oCommand = new SqlCommand("PPM_SP_ReadCostViewsForWE", _PFECN);
            oCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = oCommand.ExecuteReader();
            while(reader.Read())
            {
                int nViewUID = (int)reader["VIEW_UID"];
                string sViewName = (string)reader["VIEW_NAME"];
                dt.Rows.Add(new object[] { sViewName, nViewUID });
            }

            _PFECN.Close();

            return dt;

        }

        public string DisplayProjects(string data)   // pass in stuff like "<Projects>" + ids.ToLower() + "</Projects>"
        {
 
            CStruct xData = new CStruct();
            CStruct xReply = new CStruct();
            xReply.Initialize("Reply");
            SqlCommand SqlCommand;
            string sCommand = "";

            try
            {
                _dba.WriteImmTrace("WEIntegration", "DisplayProjects", "Input", data);


                xData.LoadXML(data);

                Guid guidTicket = xData.GetGuidAttr("SessionId");
                string sData = xData.InnerText;

                if (guidTicket == Guid.Empty)
                    guidTicket = Guid.NewGuid();
                
                if(_PFECN.State != ConnectionState.Open) _PFECN.Open();

                sCommand = "INSERT INTO EPG_DATA_CACHE(DC_TICKET,DC_TIMESTAMP,DC_DATA) VALUES(@ticket,@timestamp,@cachedata)";
                SqlCommand = new SqlCommand(sCommand, _PFECN);

                SqlCommand.Parameters.AddWithValue("@ticket", guidTicket);
                SqlCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);
                SqlCommand.Parameters.AddWithValue("@cachedata", sData);
                SqlCommand.ExecuteNonQuery();

                _PFECN.Close();

                xReply.CreateString("Error", "");
                xReply.CreateInt("STATUS", 0);

                CStruct xDisplayProjectsOut = null;
                xDisplayProjectsOut = xReply.CreateSubStruct("DisplayProjects");
                xDisplayProjectsOut.CreateGuidAttr("SessionId", guidTicket);
            }
            catch (Exception ex)
            {
                _dba.WriteImmTrace("WEIntegration", "DisplayProjects", "Error", ex.Message);

                xReply.CreateString("Error", ex.Message);
                xReply.CreateInt("STATUS", 99999);

            }

            return xReply.XML();

        }
        #region Private Classes ()
        private class PfEResource
        {
            public string Name;
            public int WresID;
            public int DeptId;
            public string Dept;
        }
        private class PfEChargeItem
        {
            public int ProjectID;
            public int WresId;
            public int DeptId;
            public string Dept;
            public string MajorCategory;
            public string Category;
        }
        #endregion Private Classes

        private static string convertToSQL(string sOLEDBconnect)
        {
            string[] sComponents = sOLEDBconnect.Split(';');
            string sSQL = string.Empty;
            foreach (string sentry in sComponents)
            {
                if (!sentry.ToUpper().Contains("PROVIDER"))
                {
                    sSQL += ";" + sentry;
                }
            }
            if (sSQL.Length < 1) return string.Empty; else return sSQL.Remove(0, 1);
        }

        private bool ImportReportingConnection(string connection)
        {
            SqlCommand SqlCommand;
            string sReply = "";

            bool bResult = false;

            try
            {
                string sCommand;
                sCommand = "Update EPG_ADMIN Set ADM_WE_REPORTING_DB_CONNECT=@Conn";
                SqlCommand = new SqlCommand(sCommand, _PFECN);
                SqlCommand.Parameters.AddWithValue("@Conn", connection);
                SqlCommand.ExecuteNonQuery();

                //oCommand = new OleDbCommand(sCommand, _dba.Connection);
                //oCommand.Parameters.AddWithValue("@Conn", connection);
                //oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //sReply = HandleException("ImportReportingConnection", 99999, ex);
                return false;
            }

            bResult = true;

            return bResult;
        }

    }
}
