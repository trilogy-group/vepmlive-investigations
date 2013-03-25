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
    }
}

