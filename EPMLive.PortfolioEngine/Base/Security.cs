
using System;
using System.Data;
using System.Data.SqlClient;

namespace PortfolioEngineCore
{
    internal class Security
    {
        public static StatusEnum GetResourcesUserCanView(DBAccess dba, int lWResID, out string sWResIDs)
        {
            sWResIDs = "";
            try
            {
                SqlCommand oCommand = null;
                SqlDataReader reader = null;
                oCommand = new SqlCommand("EPG_SP_GetResourcesUserCanView", dba.Connection);
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add("WResID", SqlDbType.Int).Value = lWResID;
                reader = oCommand.ExecuteReader();
                string s = "";
                while (reader.Read())
                {
                    Common.AddIDToList(ref s, DBAccess.ReadIntValue(reader["WRES_ID"]));
                }
                sWResIDs = s;
                reader.Close();
            }
            catch (Exception ex)
            {
                return dba.HandleException("GetResourcesUserCanView", (StatusEnum)99999, ex);
            }
            return StatusEnum.rsSuccess;
        }

        public static bool CheckUserGlobalPermission(DBAccess dba, int lWResID, GlobalPermissionsEnum ePermUID)
        {
            bool bRet = false;
            // Administrator has all permissions
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
                reader = null;
            }
            return bRet;
        }
    }
}
