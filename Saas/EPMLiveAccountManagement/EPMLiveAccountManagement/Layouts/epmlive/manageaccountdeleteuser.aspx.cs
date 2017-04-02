using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class manageaccountdeleteuser : LayoutsPageBase
    {
        private Guid accountid;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;
            SPWeb web = SPContext.Current.Web;

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
                accountid = dr.GetGuid(2);
            }
            dr.Close();

            DataSet ds = new DataSet();
            cmd = new SqlCommand("delete from account_users where account_id=@accountid and user_id=@uid", cn);
            cmd.Parameters.AddWithValue("@accountid", accountid);
            cmd.Parameters.AddWithValue("@uid", Request["uid"]);
            cmd.ExecuteNonQuery();
            cn.Close();

            string url = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

            Response.Redirect(url + "/_layouts/epmlive/manageaccountusers.aspx?isdlg=1");
        }
    }
}
