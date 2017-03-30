using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Collections;

namespace EPMLiveAccountManagement
{
    public class AccountManagement
    {
        public static DataSet GetActivationInfo(Guid siteid, string username)
        {
            DataSet ds = new DataSet();

            SqlConnection cn = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("2012SP_GetActivationInfo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", siteid);
            cmd.Parameters.AddWithValue("@username", username);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            cn.Close();

            return ds;
        }


        public static ArrayList GetActivatedFeatures(Guid siteid)
        {

            ArrayList arr = new ArrayList();

            DataSet ds = new DataSet();

            SqlConnection cn = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("2012SP_GetActivatedFeatures", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", siteid);

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                arr = new ArrayList(dr.GetString(0).Split(','));
            }
            dr.Close();

            cn.Close();

            return arr;
        }

        public static bool SetAccountUserLevel(Guid siteid, string username, int level)
        {

            SqlConnection cn = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("2012SP_SetAccountUserLevel", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", siteid);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@level", level);

            cmd.ExecuteNonQuery();

            cn.Close();

            return true;
        }
    }
}
