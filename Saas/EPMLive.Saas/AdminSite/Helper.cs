using System.Data;
using System.Web;
using System.Data.SqlClient;

namespace AdminSite
{
    public class Helper
    {
        public static string GetCurrentUser()
        {
            //return "epm\\jhughes";
            return HttpContext.Current.User.Identity.Name;
        }

        public static bool checkPermissions(int level, SqlConnection cn)
        {

            SqlCommand cmdGet = new SqlCommand("spCheckAccess", cn);
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.Parameters.AddWithValue("@username", GetCurrentUser());
            cmdGet.Parameters.AddWithValue("@levelid", level);
            SqlDataReader dr = cmdGet.ExecuteReader();

            if(dr.Read())
            {

                if(dr.GetInt32(0) > 0)
                {
                    dr.Close();
                    return true;
                }
                else
                    dr.Close();
            }
            else
                dr.Close();

            return false;
        }
    }
}

