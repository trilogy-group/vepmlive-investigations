using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    public class dbaGeneral
    {
        public static StatusEnum SelectAdmin(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPG_ADMIN";
            return dba.SelectData(cmdText, (StatusEnum)99942, out dt);
        }
        public static StatusEnum SelectLookups(DBAccess dba, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_LOOKUP_TABLES ORDER BY LOOKUP_UID";
            return dba.SelectData(cmdText, (StatusEnum)99941, out dt);
        }
        public static StatusEnum SelectLookup(DBAccess dba, int nLookupId, out DataTable dt)
        {
            string cmdText = "SELECT * FROM EPGP_LOOKUP_VALUES WHERE LOOKUP_UID = @p1 ORDER BY LV_ID";
            return dba.SelectDataById(cmdText, nLookupId, (StatusEnum)99940, out dt);
        }
        public static bool CheckUserGlobalPermission(DBAccess dba, GlobalPermissionsEnum ePermUID)
        {
            bool bRet = false;
            // Administrator has all permissions
            int lWResID = dba.UserWResID;
            if (lWResID == 1)
                bRet = true;
            else
            {
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                oCommand = new SqlCommand("EPG_SP_CheckUserGlobalPermission", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("WResID", SqlDbType.Int).Value = lWResID;
                oCommand.Parameters.Add("PermUID", SqlDbType.Int).Value = (int)ePermUID;
                reader = oCommand.ExecuteReader();

                if (reader.Read())
                    bRet = true;

                reader.Close();
            }
            return bRet;
        }

        public static string CheckUserPermissionForProject(DBAccess dba, int ProjectID, out string sStatus)
        {
            sStatus = string.Empty;
            bool bSuperPIM = Security.CheckUserGlobalPermission(dba, dba.UserWResID, GlobalPermissionsEnum.gpSuperPIM);
            if (bSuperPIM == false) 
            {
                int nValidCount = 0;
                string sCommand = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS" +
                 " LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID" +
                 " WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = " + dba.UserWResID.ToString("0") + " OR SU.SURR_WRES_ID = " + dba.UserWResID.ToString("0") + ")" +
                 " AND PROJECT_ID = " + ProjectID + "  ORDER BY PROJECT_NAME";

                SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                SqlDataReader reader = null;
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    nValidCount++;
                }
                reader.Close();
                if (nValidCount == 0)
                {
                    sStatus = "You do not have permission to view the selected project(s)";
                }
            }
            return sStatus;
        }

        public static string CreateTicket(DBAccess dba, string sData)
        {
            try
            {
                string sCommand = "";
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                System.Guid guidTicket = System.Guid.NewGuid();

                sCommand = "INSERT INTO EPG_DATA_CACHE(DC_TICKET,DC_TIMESTAMP,DC_DATA) VALUES(@ticket,@timestamp,@cachedata)";

                oCommand = new SqlCommand(sCommand, dba.Connection);

                oCommand.Parameters.AddWithValue("@ticket", guidTicket);
                oCommand.Parameters.AddWithValue("@timestamp", System.DateTime.Now);
                oCommand.Parameters.AddWithValue("@cachedata", sData);
                oCommand.ExecuteNonQuery();
                return guidTicket.ToString();
            }

            catch (System.Exception e)
            {
                return "";
            }
        }
        public static bool GetPIList(DBAccess dba, out string sReply)
        {
            sReply = "";
            int nStatus = 0;
            string sStatus = "";
            CStruct xPIs = new CStruct();
            xPIs.Initialize("PIs");
            string sProjectIDs = "";
            bool bSuperPIM = Security.CheckUserGlobalPermission(dba, dba.UserWResID, GlobalPermissionsEnum.gpSuperPIM);
            bool bSuperRM = Security.CheckUserGlobalPermission(dba, dba.UserWResID, GlobalPermissionsEnum.gpSuperRM);

            string sCommand = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS WHERE PROJECT_EXT_UID IS NOT NULL OR PROJECT_EXT_UID <> '' ORDER BY PROJECT_NAME";
            SqlCommand oCommand = new SqlCommand(sCommand, dba.Connection);
            SqlDataReader reader = null;
            reader = oCommand.ExecuteReader();
            while (reader.Read())
            {
                CStruct xPI = xPIs.CreateSubStruct("PI");
                int lUID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                if (sProjectIDs == "")
                    sProjectIDs = lUID.ToString();
                else
                    sProjectIDs += "," + lUID.ToString();
                string wepid = DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
                xPI.CreateIntAttr("id", lUID);
                xPI.CreateStringAttr("wepid", wepid);
                xPI.CreateStringAttr("name", DBAccess.ReadStringValue(reader["PROJECT_NAME"]));
            }
            reader.Close();
            reader = null;

            if (bSuperPIM == false)
            {
                xPIs = new CStruct();
                xPIs.Initialize("PIs");

                sCommand = "SELECT PROJECT_ID, PROJECT_EXT_UID, PROJECT_NAME FROM EPGP_PROJECTS" +
                " LEFT JOIN EPG_DELEGATES SU ON SURR_CONTEXT = 4 AND SURR_CONTEXT_VALUE = PROJECT_ID" +
                " WHERE PROJECT_MARKED_DELETION = 0 AND (PROJECT_MANAGER = " + dba.UserWResID.ToString("0") + " OR SU.SURR_WRES_ID = " + dba.UserWResID.ToString("0") + ")" +
                " AND PROJECT_ID in (" + sProjectIDs + ")  ORDER BY PROJECT_NAME";

                oCommand = new SqlCommand(sCommand, dba.Connection, dba.Transaction);
                reader = oCommand.ExecuteReader();
                while (reader.Read())
                {
                    CStruct xPI = xPIs.CreateSubStruct("PI");
                    int lUID = DBAccess.ReadIntValue(reader["PROJECT_ID"]);
                    string wepid = DBAccess.ReadStringValue(reader["PROJECT_EXT_UID"]);
                    xPI.CreateIntAttr("id", lUID);
                    xPI.CreateStringAttr("wepid", wepid);
                    xPI.CreateStringAttr("name", DBAccess.ReadStringValue(reader["PROJECT_NAME"]));
                }
                reader.Close();
            }
            //{
            //    PortfolioItems.PortfolioItems pis = new PortfolioItems.PortfolioItems(_basepath, _username, _pid, _company, _dbcnstring, _debug);
            //    string sExtIDList;
            //    string sPIDList;
            //    string sXML;
            //    pis.ObtainManagedPortfolioItems(out sExtIDList, out sPIDList, out sXML);
            //}
            sReply = xPIs.XML();
            bool bResult = (dba.Status == StatusEnum.rsSuccess);
            return bResult;
        }
    }
}

