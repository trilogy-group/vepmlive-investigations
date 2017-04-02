using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class manageaccountusers : LayoutsPageBase
    {
        private int accountref = 0;
        private int maxUsers = 0;
        private int currentUsers = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                MenuTemplate propertyNameListMenu = new MenuTemplate();
                propertyNameListMenu.ID = "PropertyNameListMenu";
                MenuItemTemplate testMenu = new MenuItemTemplate("Delete User", "/_layouts/images/delete.gif");
                testMenu.ClientOnClickScript = "DeleteUser('%UID%');";

                propertyNameListMenu.Controls.Add(testMenu);

                this.Controls.Add(propertyNameListMenu);

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
                string owneruname = "";

                if(dr.Read())
                {
                    accountref = dr.GetInt32(10);
                    maxUsers = dr.GetInt32(0);
                    currentUsers = dr.GetInt32(1);
                    owneruname = dr.GetString(13);
                }
                dr.Close();

                DataSet ds = new DataSet();
                cmd = new SqlCommand("SELECT uid, name, email, REPLACE(username, 'epm\\', '') as username from vwaccountusers where account_ref=@ref ", cn);
                cmd.Parameters.AddWithValue("@ref", accountref);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                GvItems.DataSource = ds;
                GvItems.DataBind();

                cn.Close();

                if(owneruname.ToLower() != EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower())
                {
                    Response.Redirect("../AccessDenied.aspx");
                }
            }
        }
    }
}
