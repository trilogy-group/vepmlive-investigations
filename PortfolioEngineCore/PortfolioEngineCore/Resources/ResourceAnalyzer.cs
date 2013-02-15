using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class ResourceAnalyzer : PFEBase
    {
        #region Fields (1)

        private readonly SqlConnection _sqlConnection;

        #endregion Fields
        
        
        public ResourceAnalyzer(string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ResourceAnalyzer Class");
            _sqlConnection = _PFECN;

            _userWResID = Utilities.ResolveNTNameintoWResID(_sqlConnection, username);
        }

        public ResourceAnalyzer(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading ResourceAnalyzer Class");
            _sqlConnection = _PFECN;

        }

        public bool GetResourceAnalyzerUserCalendarSettingsXML(out string sReply)
        {
            sReply = "";
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xRPA = new CStruct();
            xRPA.Initialize("ResourceAnalyzerCalendars");

            Dictionary<int, CStruct> cals = new Dictionary<int, CStruct>();

            CStruct xSec;
            bool bSec = Security.CheckUserGlobalPermission(_dba, _userWResID, GlobalPermissionsEnum.gpCommitments);

            xSec = xRPA.CreateSubStruct("Security");

            if (bSec == false)
                xSec.CreateIntAttr("Value", 0);
            else
                xSec.CreateIntAttr("Value", 1);
  

            string cmdText = "SELECT CB_ID, CB_NAME FROM EPGP_COST_BREAKDOWNS ORDER BY CB_NAME";

            SqlCommand oCommand = new SqlCommand(cmdText,  _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            CStruct xCalenders;
            xCalenders = xRPA.CreateSubStruct("Calendars");

            CStruct xLastCalenderInfo;
            xLastCalenderInfo = xRPA.CreateSubStruct("LastUserData");


            if (bSec)
            {
                CStruct xCalender;
                CStruct xPeriods;
                CStruct xCMTCal;
                int cal_id;
                string cal_name;
                int per_id;
                string per_name;
                int first_cal_id = -1;
                int first_earliest_per_id = -1;
                int first_lastest_per_id = -1;

                while (reader.Read())
                {
                    xCalender = xCalenders.CreateSubStruct("Calendar");

                    cal_id = DBAccess.ReadIntValue(reader["CB_ID"]);

                    if (first_cal_id == -1)
                        first_cal_id = cal_id;

                    cal_name = DBAccess.ReadStringValue(reader["CB_NAME"]);

                    xCalender.CreateIntAttr("calID", cal_id);
                    xCalender.CreateStringAttr("calName", cal_name);
                    xPeriods = xCalender.CreateSubStruct("Periods");
                    cals.Add(cal_id, xPeriods);

                }
                reader.Close();

                cmdText = "SELECT PRD_ID, CB_ID, PRD_NAME FROM EPG_PERIODS ORDER BY CB_ID, PRD_ID";

                oCommand = new SqlCommand(cmdText,  _sqlConnection);
                reader = oCommand.ExecuteReader();


                while (reader.Read())
                {
                    cal_id = DBAccess.ReadIntValue(reader["CB_ID"]);

                    if (cals.TryGetValue(cal_id, out xPeriods) == true)
                    {
                        per_id = DBAccess.ReadIntValue(reader["PRD_ID"]);
                        per_name = DBAccess.ReadStringValue(reader["PRD_NAME"]);

                        if (cal_id == first_cal_id)
                        {
                            if (first_earliest_per_id == -1)
                                first_earliest_per_id = per_id;

                            first_lastest_per_id = per_id;
                        }


                        CStruct xPeriod = xPeriods.CreateSubStruct("Period");
                        xPeriod.CreateIntAttr("perID", per_id);
                        xPeriod.CreateStringAttr("perName", per_name);
                    }

                }
                reader.Close();

                cmdText = "SELECT ADM_PORT_COMMITMENTS_CB_ID  FROM EPG_ADMIN";

                oCommand = new SqlCommand(cmdText, _sqlConnection);
                reader = oCommand.ExecuteReader();
                int CalID = 0;
                bool bIsNull;

                while (reader.Read())
                {
                    CalID = DBAccess.ReadIntValue(reader["ADM_PORT_COMMITMENTS_CB_ID"],out bIsNull);

                    if (bIsNull)
                        CalID = -1;
                }
                reader.Close();

                xCMTCal = xCalenders.CreateSubStruct("CmtCal");
                xCMTCal.CreateIntAttr("Value", CalID);

                string sXML = "";

                cmdText = "SELECT * FROM EPG_USERINFO WHERE WRES_ID = " + _userWResID.ToString() +
                          " AND UINF_CONTEXT = 20100";
                oCommand = new SqlCommand(cmdText,  _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    sXML = DBAccess.ReadStringValue(reader["UINF_XML"]);
                }
                reader.Close();

                if (sXML != "")
                {
                    CStruct cRoot = new CStruct();

                    cRoot.LoadXML(sXML);

                    CStruct rdCal = cRoot.GetSubStruct("RDCal");
                    CStruct rdStart = cRoot.GetSubStruct("RDStart");
                    CStruct rdEnd = cRoot.GetSubStruct("RDEnd");

                    int lStart = -1;
                    int lEnd = -1;
                    int cbID = -1;

                    if (rdCal != null)
                    {
                        cbID = rdCal.GetInt(string.Empty);

                        if (cals.TryGetValue(cbID, out xPeriods) == true)
                        {

                            if (rdStart != null)
                                lStart = rdStart.GetInt(string.Empty);

                            if (rdEnd != null)
                                lEnd = rdEnd.GetInt(string.Empty);

                        }
                        else
                            cbID = -1;
                    }


                    xLastCalenderInfo.CreateIntAttr("lastCalID", cbID);
                    xLastCalenderInfo.CreateIntAttr("lastStartPerID", lStart);
                    xLastCalenderInfo.CreateIntAttr("lastFinishPerID", lEnd);
                }
                else
                {
                    xLastCalenderInfo.CreateIntAttr("lastCalID", first_cal_id);
                    xLastCalenderInfo.CreateIntAttr("lastStartPerID", first_earliest_per_id);
                    xLastCalenderInfo.CreateIntAttr("lastFinishPerID", first_lastest_per_id);
                }
            }

            sReply = xRPA.XML();
            return true;  // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool SetResourceAnalyzerUserCalendarSettingsXML(int calID, int startID, int endID)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();
            
            string cmdText = "SELECT * FROM EPG_USERINFO WHERE WRES_ID = " + _userWResID.ToString() + " AND UINF_CONTEXT = 20100";
            SqlCommand oCommand = new SqlCommand(cmdText,  _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            string sXML = "";

            while (reader.Read())
            {
                sXML = DBAccess.ReadStringValue(reader["UINF_XML"]);

            }
            reader.Close();
  
            if (sXML == "")
                sXML = "<RCUserSettings><RDCal>2</RDCal><RDStart>1</RDStart><RDEnd>16</RDEnd><RDPubStart>0</RDPubStart><RDPubEnd>0</RDPubEnd></RCUserSettings>";

            XmlDocument oXMLDocument = new XmlDocument();
            oXMLDocument.PreserveWhitespace = true;
            oXMLDocument.LoadXml(sXML);

            XmlNode RootNode = null;

            foreach (XmlNode oNode in oXMLDocument.ChildNodes)
            {
                if (oNode.NodeType == System.Xml.XmlNodeType.Element)
                {
                    RootNode = oNode;
                    break;
                }
            }

            if (RootNode != null)
            {

                XmlNode rdCal = RootNode.SelectSingleNode("RDCal");
                XmlNode rdStart = RootNode.SelectSingleNode("RDStart");
                XmlNode rdEnd = RootNode.SelectSingleNode("RDEnd");

                if (rdCal != null)
                    rdCal.InnerText = calID.ToString();

                if (rdStart != null)
                    rdStart.InnerText = startID.ToString();

                if (rdEnd != null)
                    rdEnd.InnerText = endID.ToString();
            }

            cmdText = "DELETE FROM EPG_USERINFO WHERE WRES_ID = " + _userWResID.ToString() + " AND UINF_CONTEXT = 20100";
            oCommand = new SqlCommand(cmdText,  _sqlConnection);
            oCommand.ExecuteNonQuery();

            cmdText = "INSERT INTO EPG_USERINFO (WRES_ID ,UINF_CONTEXT,UINF_DATA, UINF_XML) VALUES(" + _userWResID.ToString() + ", 20100,0, " + DBAccess.PrepareText(RootNode.OuterXml) + ")";
            oCommand = new SqlCommand(cmdText,  _sqlConnection);
            oCommand.ExecuteNonQuery();

            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }


        public bool GetResourceAnalyzerViewsXML(out string sReply)
        {
            sReply = "";
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            CStruct xRPE = new CStruct();
            xRPE.Initialize("Views");

            //string sCommand = "SELECT VIEW_GUID,VIEW_NAME,VIEW_PERSONAL,VIEW_DEFAULT FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";
            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32000 AND (WRES_ID=0 OR WRES_ID=" + this._userWResID.ToString() + ") ORDER BY VIEW_DEFAULT DESC,WRES_ID DESC,VIEW_NAME";

            SqlCommand oCommand = new SqlCommand(sCommand,  _sqlConnection);
            SqlDataReader reader = oCommand.ExecuteReader();

            while (reader.Read())
            {
                CStruct xView = new CStruct();
                //CStruct xView = xRPE.CreateSubStruct("View");
                //xView.CreateGuidAttr("ViewGUID", DBAccess.ReadGuidValue(reader["VIEW_GUID"]));
                //xView.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["VIEW_NAME"]));
                //xView.CreateBooleanAttr("Personal", DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]));
                //xView.CreateBooleanAttr("Default", DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]));
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xView.LoadXML(sXML);
                    xRPE.AppendSubStruct(xView);
                }
            }
            reader.Close();
            sReply = xRPE.XML();
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool GetResourceAnalyzerViewXML(Guid guidView, out string sReply)
        {
            sReply = "";

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open(); 
            
            CStruct xView = new CStruct();
            //xView.Initialize("View");

            string sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32000 AND VIEW_GUID=@guid";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand,  _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                //Guid guidView2 = DBAccess.ReadGuidValue(reader["VIEW_GUID"]);
                //string sName = DBAccess.ReadStringValue(reader["VIEW_NAME"]);
                //bool bPersonal = DBAccess.ReadBoolValue(reader["VIEW_PERSONAL"]);
                //bool bDefault = DBAccess.ReadBoolValue(reader["VIEW_DEFAULT"]);
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                    xView.LoadXML(sXML);
                //xView.SetIntAttr("ViewUID", nUID);
                //xView.SetStringAttr("Name", sName);
                //xView.SetBooleanAttr("Personal", bPersonal);
                //xView.SetBooleanAttr("Default", bDefault);
            }
            reader.Close();
            sReply = xView.XML(); ;
            //        Exit_Function:
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool SaveResourceAnalyzerViewXML(Guid guidView, string sName, bool bPersonal, bool bDefault, string sData)
        {

            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();          
            
            //SqlCommand cmd = new SqlCommand("DELETE FROM EPG_VIEWS WHERE VIEW_CONTEXT=30000 AND VIEW_UID=?",  _sqlConnection);
            //cmd.Parameters.AddWithValue("VIEW_UID", nViewUID);
            //int lRowsAffected = cmd.ExecuteNonQuery();
            string sCommand;
            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@vname,WRES_ID=@wres,VIEW_DEFAULT=@vdef,VIEW_DATA=@vdata,VIEW_CONTEXT=32000 WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand,  _sqlConnection);
            cmd.Parameters.AddWithValue("@vname", sName);
            cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
            cmd.Parameters.AddWithValue("@vdef", bDefault);
            cmd.Parameters.AddWithValue("@vdata", sData);
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                sCommand = "INSERT INTO EPG_VIEWS (VIEW_GUID,VIEW_NAME,WRES_ID,VIEW_DEFAULT,VIEW_DATA,VIEW_CONTEXT) VALUES(@guid,@name,@wres,@def,@vdata,32000)";
                cmd = new SqlCommand(sCommand,  _sqlConnection);
                cmd.Parameters.AddWithValue("@guid", guidView);
                cmd.Parameters.AddWithValue("@name", sName);
                cmd.Parameters.AddWithValue("@wres", bPersonal ? this._userWResID : 0);
                cmd.Parameters.AddWithValue("@def", bDefault);
                cmd.Parameters.AddWithValue("@vdata", sData);
                nRowsAffected = cmd.ExecuteNonQuery();
            }

            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool DeleteResourceAnalyzerViewXML(Guid guidView)
        {
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open(); 
            
            string sCommand = "DELETE FROM EPG_VIEWS WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand,  _sqlConnection);
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();
            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool RenameResourceAnalyzerViewXML(Guid guidView, string sName)
        {
            string sCommand;
            CStruct xView = null;
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            sCommand = "SELECT VIEW_DATA FROM EPG_VIEWS WHERE VIEW_CONTEXT=32000 AND VIEW_GUID=@guid";
            //string sCommand = "SELECT WAU_UID,UINF_VIEWNAME,UINF_XML FROM EPGT_LOCALVIEWS WHERE UINF_VIEWNAME=" + _dba.PrepareText(sViewName) + " ORDER BY UINF_VIEWNAME";

            SqlCommand oCommand = new SqlCommand(sCommand,  _sqlConnection);
            oCommand.Parameters.AddWithValue("@guid", guidView);
            SqlDataReader reader = oCommand.ExecuteReader();

            if (reader.Read())
            {
                string sXML = DBAccess.ReadStringValue(reader["VIEW_DATA"]);
                if (sXML != string.Empty)
                {
                    xView = new CStruct();
                    xView.LoadXML(sXML);
                }
            }
            reader.Close();

            if (xView == null)
                return false;

            xView.SetStringAttr("Name", sName);

            sCommand = "UPDATE EPG_VIEWS SET VIEW_NAME=@name,VIEW_DATA = @vdata WHERE VIEW_GUID=@guid";
            SqlCommand cmd = new SqlCommand(sCommand,  _sqlConnection);
            cmd.Parameters.AddWithValue("@name", sName);
            cmd.Parameters.AddWithValue("@vname", xView.XML());
            cmd.Parameters.AddWithValue("@guid", guidView);
            int nRowsAffected = cmd.ExecuteNonQuery();

            if (nRowsAffected == 0)
            {
                return false;
            }


            return true; // (_dba.Status == StatusEnum.rsSuccess);
        }

        public bool SetResourceAnalyzerDraggedDataXML(string dataXML)
        {
            CStruct xRoot = new CStruct();
            if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
            _sqlConnection.Open();

            if (xRoot.LoadXML(dataXML) == false)
            {

               // _dba.Status = StatusEnum.rsRequestInvalidParameter;
                return false;
            }
            

            List<CStruct> clnCMTData = xRoot.GetList("CMT");

            foreach (CStruct xRow in clnCMTData)
            {
                int cmtuid = xRow.GetIntAttr("CMT_UID");

                if (cmtuid != 0)
                {
                    List<CStruct> clnPerData = xRow.GetList("Period");

                    string sCommand = "UPDATE EPG_RESOURCEPLANS SET CMT_TIMESTAMP= " + FormatSQLDateTime(DateTime.Now) + ", CMT_ENTEREDBY_WRES_ID = " + this._userWResID.ToString() + " WHERE CMT_UID = " + cmtuid.ToString();
                    SqlCommand cmd = new SqlCommand(sCommand,_sqlConnection);
                    int nRowsAffected = cmd.ExecuteNonQuery();

                    sCommand = "DELETE FROM EPG_RESOURCEPLANS_HOURS WHERE CMT_UID = " + cmtuid.ToString();
                    cmd = new SqlCommand(sCommand,_sqlConnection);
                    nRowsAffected = cmd.ExecuteNonQuery();

                    sCommand = "INSERT INTO EPG_RESOURCEPLANS_HOURS (CMT_UID, PRD_ID, CMH_HOURS, CMH_FTES, CMH_REVENUES, CMH_MODE, CMH_PENDING) " +
                               "VALUES(" + cmtuid.ToString() + ",@prd,@hrs,@ftes,0,0,0)";

                    cmd = new SqlCommand(sCommand,_sqlConnection);
                    SqlParameter pPRD_ID = cmd.Parameters.Add("@prd", SqlDbType.Int);
                    SqlParameter pCMH_HOURS = cmd.Parameters.Add("@hrs", SqlDbType.Decimal);
                    SqlParameter pCMH_FTES = cmd.Parameters.Add("@ftes", SqlDbType.Decimal);

                    foreach (CStruct xI in clnPerData)
                    {

                        pPRD_ID.Value = xI.GetIntAttr("PeriodID");
                        pCMH_HOURS.Value = xI.GetDoubleAttr("Hours", 0);
                        pCMH_FTES.Value =  (xI.GetDoubleAttr("FTES", 0) / 100);
                        nRowsAffected = cmd.ExecuteNonQuery();
                    }
  
                }

            }


            return true;

        }

        private string FormatSQLDateTime(DateTime dt)
        {
            return "CONVERT(DATETIME, '" + dt.ToString("yyyy-MM-dd HH:mm:ss") + "', 102)";
        }

    }
}
