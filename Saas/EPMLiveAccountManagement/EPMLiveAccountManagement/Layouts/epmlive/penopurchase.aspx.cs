using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class penopurchase : LayoutsPageBase
    {
        protected string owneremail;
        protected string ownername;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {


                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(Settings.getConnectionString());
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteid", site.ID);
                cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    ownername = dr.GetString(5);
                    owneremail = dr.GetString(14);
                }
                dr.Close();



                cn.Close();
            });
        }
    }
}
