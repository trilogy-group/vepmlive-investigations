using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using CostDataValues;


namespace PortfolioEngineCore
{

    public class RPEN_Resource
    {
        public int id;
        public string extid;
        public string NTacct;
        public string Name;
        public string eMail;
    }

    public class RPEN_Delegate
    {
        public int wres_id;
        public RPEN_Resource wres_res = null;
        public Dictionary<int, RPEN_Resource>  wres_delg = new Dictionary<int, RPEN_Resource>();
    }

    public class RPEN_Project
    {
        public int PID;
        public string extid;
        public string Name;
        public int PMid;
        public RPEN_Delegate PMdlg = null;
        public List<RPEN_NoteEntry> notes = new List<RPEN_NoteEntry>();
    }

    public class RPEN_Depts
    {
        public int dept_code;
        public Dictionary<int, RPEN_Resource> dept_mgrs = new Dictionary<int, RPEN_Resource>();
    }

    public class RPEN_CMT
    {
  
        public int UID;
        public int Res;
        public int pendingres;
        public int enteredbyres;
        public Guid cmtGuid;
        public int dept;
        public RPEN_Depts dept_cls = null;
        public List<RPEN_NoteEntry>  notes = new List<RPEN_NoteEntry>();
   
    }


    public class RPEN_NoteEntry
    {
        public int UID;
        public int PID;
        public Guid cmtGuid;
        public int resID;
        public string title;
        public string html;
        public int context;
        public string resName;
        public string resNTAcctount;
        public string resEmail;
        public string resExtUID;
        public RPEN_Project project = null;
        public RPEN_CMT cmt = null;

    }


    public class ResourcePlanNotifications : PFEBase
    {

        #region Fields (1)

        private readonly SqlConnection _sqlConnection;

        #endregion Fields

        public ResourcePlanNotifications(string basepath, string username, string pid, string company, string dbcnstring,
                                         SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {
            debug.AddMessage("Loading ModelSupport Class");
            _sqlConnection = _PFECN;
            _userWResID = Utilities.ResolveNTNameintoWResID(_sqlConnection, username);
        }

        public ResourcePlanNotifications(string sBaseInfo)
            : base(sBaseInfo)
        {
            debug.AddMessage("Loading CostAnalyzerData Class");
            _sqlConnection = _PFECN;
        }

        public string GetRPENotifcations()
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();
                
                CStruct xRoot = new CStruct();

                xRoot.Initialize("RPENotifications");

                xRoot.CreateIntAttr("ThisUser", _userWResID);

                string sCommand = "";
                SqlCommand oCommand = null;
                SqlDataReader reader = null;

                Dictionary<string, string> pilist = new Dictionary<string, string>();
                Dictionary<string, string> cmtguid = new Dictionary<string, string>();
                Dictionary<string, string> pmlist = new Dictionary<string, string>();
                Dictionary<string, string> deptlist = new Dictionary<string, string>();
                Dictionary<string, string> rmlist = new Dictionary<string, string>();

                List<string> cmtres = new List<string>();
              

                string temppid;
                string tempguid;
                string pid;
                string guid;
                string pms;
                string rms;
                string depts;
                int cnt = 0;


                sCommand = "SELECT RPEN_UID, RPEN_PROJECT_ID, RPEN_CMT_GUID, RPEN_TIMESTAMP, " +
                              "RPEN_WRES_ID, RPEN_TO, RPEN_TITLE, RPEN_HTML, " +
                              "RPEN_CONTEXT, RPEN_EVENT_CONTEXT, " + 
                              "EPG_RESOURCES.RES_NAME, EPG_RESOURCES.WRES_NT_ACCOUNT, EPG_RESOURCES.WRES_EMAIL, EPG_RESOURCES.WRES_EXT_UID " + 
                              " FROM EPG_RPE_NOTES INNER JOIN " +
                              " EPG_RESOURCES ON RPEN_WRES_ID = EPG_RESOURCES.WRES_ID " +
                              " WHERE  (RPEN_CONTEXT = 1) AND (RPEN_PFE_PROCESSED = 0) " +
                              " ORDER BY RPEN_PROJECT_ID";

                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    ++cnt;
                    CStruct xNode = xRoot.CreateSubStruct("RPEN");
                    xNode.CreateStringAttr("UID", DBAccess.ReadStringValue(reader["RPEN_UID"]));
                    pid = DBAccess.ReadStringValue(reader["RPEN_PROJECT_ID"]);
                    xNode.CreateStringAttr("PID", pid);
                    guid = DBAccess.ReadStringValue(reader["RPEN_CMT_GUID"]);
                    xNode.CreateStringAttr("GUID", guid);

                    xNode.CreateStringAttr("WRESID", DBAccess.ReadStringValue(reader["RPEN_WRES_ID"]));
                    xNode.CreateStringAttr("TITLE", DBAccess.ReadStringValue(reader["RPEN_TITLE"]));
                    xNode.CreateStringAttr("HTML", DBAccess.ReadStringValue(reader["RPEN_HTML"]));
                    xNode.CreateStringAttr("ECONTEXT", DBAccess.ReadStringValue(reader["RPEN_EVENT_CONTEXT"]));

                    xNode.CreateStringAttr("WResName", DBAccess.ReadStringValue(reader["RES_NAME"]));
                    xNode.CreateStringAttr("WResNT", DBAccess.ReadStringValue(reader["WRES_NT_ACCOUNT"]));
                    xNode.CreateStringAttr("WResEmail", DBAccess.ReadStringValue(reader["WRES_EMAIL"]));
                    xNode.CreateStringAttr("WResExtUID", DBAccess.ReadStringValue(reader["WRES_EXT_UID"]));

                    if (pilist.TryGetValue(pid,out temppid) == false)
                    {
                        pilist.Add(pid,pid);
                    }

                    if (cmtguid.TryGetValue(guid,out tempguid) == false)
                    {
                        cmtguid.Add(guid,guid);
                    }


                }
                reader.Close();
                reader = null;

                if (cnt == 0)
                    return "";


                sCommand = "UPDATE  EPG_RPE_NOTES SET RPEN_PFE_PROCESSED = 1 WHERE RPEN_CONTEXT = 1 AND RPEN_PFE_PROCESSED = 0";
                oCommand = new SqlCommand(sCommand, _sqlConnection);
                oCommand.ExecuteNonQuery();


                pid = "";
                guid = "";

                foreach (string sx in pilist.Values)
                {
                    if (pid == "")
                        pid = sx;
                    else
                         pid += "," + sx;
                }


                foreach (string sx in cmtguid.Values)
                {
                    if (guid == "")
                        guid = "'" + sx + "'";
                    else
                        guid += ",'" + sx + "'";
                }


                sCommand = "SELECT * FROM  EPGP_PROJECTS WHERE PROJECT_ID IN (" + pid + ")";
                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xNode = xRoot.CreateSubStruct("PROJECT");
                    xNode.CreateStringAttr("PID", DBAccess.ReadStringValue(reader["PROJECT_ID"]));
                    xNode.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["PROJECT_NAME"]));
                    xNode.CreateStringAttr("EXTUID", DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]));

                    pms = DBAccess.ReadStringValue(reader["PROJECT_MANAGER"]);
                    xNode.CreateStringAttr("PM", pms);

                    if (pmlist.TryGetValue(pms, out temppid) == false)
                    {
                        pmlist.Add(pms, pms);
                    }

                }
                reader.Close();
                reader = null;

                sCommand = "SELECT EPG_RESOURCEPLANS.CMT_UID, EPG_RESOURCEPLANS.CMT_GUID, EPG_RESOURCEPLANS.WRES_ID," +
                            " EPG_RESOURCEPLANS.WRES_ID_PENDING, EPG_RESOURCEPLANS.CMT_ENTEREDBY_WRES_ID, " +                   
                            " EPG_RESOURCEPLANS.CMT_DEPT " + 
                           " FROM  EPG_RESOURCEPLANS  WHERE CMT_GUID IN (" + guid + ")";

                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xNode = xRoot.CreateSubStruct("CMT");
                    xNode.CreateStringAttr("UID", DBAccess.ReadStringValue(reader["CMT_UID"]));
                    xNode.CreateStringAttr("GUID", DBAccess.ReadStringValue(reader["CMT_GUID"]));
                    xNode.CreateStringAttr("WRES", DBAccess.ReadStringValue(reader["WRES_ID"]));
                    xNode.CreateStringAttr("WRESPend", DBAccess.ReadStringValue(reader["WRES_ID_PENDING"]));
                    xNode.CreateStringAttr("EnteredBy", DBAccess.ReadStringValue(reader["CMT_ENTEREDBY_WRES_ID"]));
                    xNode.CreateStringAttr("Dept", DBAccess.ReadStringValue(reader["CMT_DEPT"]));

                    string resid = DBAccess.ReadStringValue(reader["WRES_ID"]);

                    if (resid != "0")
                        cmtres.Add(resid);

                    resid = DBAccess.ReadStringValue(reader["WRES_ID_PENDING"]);

                    if (resid != "0")
                        cmtres.Add(resid);


                    depts = DBAccess.ReadStringValue(reader["CMT_DEPT"]);

                    if (deptlist.TryGetValue(depts, out temppid) == false)
                    {
                        deptlist.Add(depts, depts);
                    }

                }
                reader.Close();
                reader = null;


                depts = "";
                foreach (string sx in deptlist.Values)
                {
                    if (depts == "")
                        depts = sx;
                    else
                        depts += "," + sx;
                }

                sCommand = "SELECT * FROM EPG_RES_MANAGERS " +
                    " WHERE CODE_UID IN (" + depts + ")";


                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();

                while (reader.Read())
                {
                    string drm = "";
                    CStruct xNode = xRoot.CreateSubStruct("DEPT");
                    xNode.CreateStringAttr("Dept", DBAccess.ReadStringValue(reader["CODE_UID"]));
                    xNode.CreateStringAttr("WRES", DBAccess.ReadStringValue(reader["WRES_ID"]));

                    drm = DBAccess.ReadStringValue(reader["WRES_ID"]);

                    if (rmlist.TryGetValue(drm, out temppid) == false)
                    {
                        rmlist.Add(drm, drm);
                    }

                }
                reader.Close();
                reader = null;

                sCommand = "SELECT * FROM EPG_DEPT_MANAGERS " +
                           " WHERE CODE_UID IN (" + depts + ") AND CANWRITE = 1";

                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xNode = xRoot.CreateSubStruct("DEPT");
                    xNode.CreateStringAttr("Dept", DBAccess.ReadStringValue(reader["CODE_UID"]));
                    xNode.CreateStringAttr("WRES", DBAccess.ReadStringValue(reader["WRES_ID"]));

                    depts = DBAccess.ReadStringValue(reader["WRES_ID"]);

                    if (rmlist.TryGetValue(depts, out temppid) == false)
                    {
                        rmlist.Add(depts, depts);
                    }

                }
                reader.Close();
                reader = null;


                depts = "";
                foreach (string sx in rmlist.Values)
                {
                    if (depts == "")
                        depts = sx;
                    else
                        depts += "," + sx;
                }

                sCommand = "SELECT * FROM EPG_DELEGATES " +
                           " WHERE WRES_ID IN (" + depts + ") AND  (SURR_CONTEXT = 2 OR SURR_CONTEXT = 5)";


                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xNode = xRoot.CreateSubStruct("DEPTDEL");
                    xNode.CreateStringAttr("WRES", DBAccess.ReadStringValue(reader["WRES_ID"]));
                    xNode.CreateStringAttr("DELG", DBAccess.ReadStringValue(reader["SURR_WRES_ID"]));
                    

                    depts = DBAccess.ReadStringValue(reader["SURR_WRES_ID"]);

                    if (rmlist.TryGetValue(depts, out temppid) == false)
                    {
                        rmlist.Add(depts, depts);
                    }

                }
                reader.Close();
                reader = null;

                depts = "";
                foreach (string sx in pmlist.Values)
                {
                    if (depts == "")
                        depts = sx;
                    else
                        depts += "," + sx;
                }

                sCommand = "SELECT * FROM EPG_DELEGATES " +
                           " WHERE WRES_ID IN (" + depts + ") AND  (SURR_CONTEXT = 4)";


                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xNode = xRoot.CreateSubStruct("PMDEL");
                    xNode.CreateStringAttr("WRES", DBAccess.ReadStringValue(reader["WRES_ID"]));
                    xNode.CreateStringAttr("DELG", DBAccess.ReadStringValue(reader["SURR_WRES_ID"]));


                    depts = DBAccess.ReadStringValue(reader["SURR_WRES_ID"]);

                    if (pmlist.TryGetValue(depts, out temppid) == false)
                    {
                        pmlist.Add(depts, depts);
                    }

                }
                reader.Close();
                reader = null;

                foreach (string sx in pmlist.Values)
                {

                    if (rmlist.TryGetValue(sx, out temppid) == false)
                    {
                        rmlist.Add(sx, sx);
                    }
                }

                foreach (string sx in cmtres)
                {

                    if (rmlist.TryGetValue(sx, out temppid) == false)
                    {
                        rmlist.Add(sx, sx);
                    }
                }

                if (rmlist.TryGetValue(_userWResID.ToString(), out temppid) == false)
                {
                    rmlist.Add(_userWResID.ToString(), _userWResID.ToString());
                }
                

                depts = "";
                foreach (string sx in rmlist.Values)
                {
                    if (depts == "")
                        depts = sx;
                    else
                        depts += "," + sx;
                }

                sCommand = "SELECT * FROM EPG_RESOURCES " +
                           " WHERE WRES_ID IN (" + depts + ")";


                oCommand = new SqlCommand(sCommand, _sqlConnection);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xNode = xRoot.CreateSubStruct("RES");
                    xNode.CreateStringAttr("WRES", DBAccess.ReadStringValue(reader["WRES_ID"]));
                    xNode.CreateStringAttr("Name", DBAccess.ReadStringValue(reader["RES_NAME"]));
                    xNode.CreateStringAttr("ResNT", DBAccess.ReadStringValue(reader["WRES_NT_ACCOUNT"]));
                    xNode.CreateStringAttr("ResEMail", DBAccess.ReadStringValue(reader["WRES_EMAIL"]));
                    xNode.CreateStringAttr("ResExtID", DBAccess.ReadStringValue(reader["WRES_EXT_UID"]));

                }
                reader.Close();
                reader = null;
                _dba.WriteImmTrace("RPEN_Notify", "GetRPENotifcations", "Returning Data", xRoot.XML());


                return xRoot.XML();
            }
            catch(Exception ex)
            {
                return "";
            }

        }

        public string CreateTicket(string sData)
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Open) _sqlConnection.Close();
                _sqlConnection.Open();


                string sCommand = "";
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                Guid guidTicket = Guid.NewGuid();

                sCommand = "INSERT INTO EPG_DATA_CACHE(DC_TICKET,DC_TIMESTAMP,DC_DATA) VALUES(@ticket,@timestamp,@cachedata)";
                
                oCommand = new SqlCommand(sCommand, _sqlConnection);

                oCommand.Parameters.AddWithValue("@ticket", guidTicket);
                oCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);
                oCommand.Parameters.AddWithValue("@cachedata", sData);
                oCommand.ExecuteNonQuery();

                _sqlConnection.Close();

                return guidTicket.ToString();
            }

            catch (Exception e)
            {
                return "";
            }
        }
    }
}
