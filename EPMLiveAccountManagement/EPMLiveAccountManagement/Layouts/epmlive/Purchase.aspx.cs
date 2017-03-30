using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class Purchase : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });


            SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", SPContext.Current.Site.ID);
            cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());

            SqlDataReader dr = cmd.ExecuteReader();
            string account_ref = "";
            int buyUsers = 1;

            if(dr.Read())
            {
                account_ref = dr.GetInt32(10).ToString();
                int max = dr.GetInt32(0);
                int count = dr.GetInt32(1);
                int inTrial = dr.GetInt32(4);

                if(inTrial == 1)
                {
                    buyUsers = count;
                }
                else
                {
                    buyUsers = count - max;
                    if(buyUsers < 0)
                        buyUsers = 0;
                }
            }
            dr.Close();

            cmd = new SqlCommand("SELECT min(version) as version from orders where account_ref=@accountref", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@accountref", account_ref);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            string version = ds.Tables[0].Rows[0][0].ToString();
            string level = Settings.getContractLevel();

            cn.Close();
            
        }
    }
}
