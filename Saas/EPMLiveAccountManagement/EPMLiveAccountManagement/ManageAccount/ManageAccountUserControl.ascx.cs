using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveAccountManagement.ManageAccount
{

    public partial class ManageAccountUserControl : UserControl
    {
        private SqlConnection cn;
        protected ToolBar tbMain;
        protected ToolBarButton btnNewAccount;
        protected string weburl;
        protected string SiteList;
        protected string strUserWidth;
        protected string strSiteUsageWidth;
        protected string strAccountStyle = "display:none";

        protected string account_ref;
        protected string quantity;
        protected string level;

        protected override void OnInit(EventArgs e)
        {
            
        }

        protected void ddlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            weburl = SPContext.Current.Web.ServerRelativeUrl;
            if (weburl == "/")
                weburl = "";

            

            string username = EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName);
            Guid uid = Guid.Empty;
            Guid account = Guid.Empty;
            SPUser user = SPContext.Current.Web.CurrentUser;

            //username = "epm\\pablowest1";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT UID,firstname, lastname,address1,address2,city,state,zip,country,phone,email from USERS where username like @username", cn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    uid = dr.GetGuid(0);
                    lblName.Text = dr.GetString(1) + " " + dr.GetString(2);
                    if (!dr.IsDBNull(3))
                        lblAddress.Text = dr.GetString(3) + "<br>";
                    if (!dr.IsDBNull(4) && dr.GetString(4) != "")
                        lblAddress.Text += dr.GetString(4) + "<br>";
                    if (!dr.IsDBNull(5) && dr.GetString(5) != "")
                        lblAddress.Text += dr.GetString(5) + "<br>";
                    if (!dr.IsDBNull(6) && dr.GetString(6) != "")
                        lblAddress.Text += dr.GetString(6) + "<br>";
                    if (!dr.IsDBNull(7) && dr.GetString(7) != "")
                        lblAddress.Text += dr.GetString(7) + "<br>";
                    if (!dr.IsDBNull(8) && dr.GetString(8) != "")
                        lblAddress.Text += dr.GetString(8) + "<br>";

                    if (!dr.IsDBNull(9))
                        lblPhone.Text = dr.GetString(9);

                    lblEmail.Text = dr.GetString(10);
                }

                dr.Close();

                if (uid != Guid.Empty)
                {
                   

                    if (!IsPostBack)
                    {
                        cmd = new SqlCommand("SELECT accountdescription,account_id FROM ACCOUNT where owner_id=@uid",cn);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            ddlAccount.Items.Add(new ListItem(dr.GetString(0), dr.GetGuid(1).ToString()));
                        }
                        dr.Close();

                    
                        try
                        {
                            ddlAccount.SelectedValue = Request["account_id"];
                        }
                        catch { }
                    }

                    if(ddlAccount.Items.Count > 0)
                    {
                        strAccountStyle = "";
                        cmd = new SqlCommand("SELECT accountdescription,account_ref FROM ACCOUNT where account_id=@accountid", cn);
                        cmd.Parameters.AddWithValue("@accountid", ddlAccount.SelectedValue);
                        dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            lblAccountName.Text = dr.GetString(0);
                            lblAccountNumber.Text = dr.GetInt32(1).ToString();
                        }
                        dr.Close();


                        cmd = new SqlCommand("SELECT siteguid FROM ACCOUNT_EXTERNAL_SITES where account_id=@accountid", cn);
                        cmd.Parameters.AddWithValue("@accountid", ddlAccount.SelectedValue);
                        dr = cmd.ExecuteReader();

                        float siteUsage = 0;

                        while(dr.Read())
                        {
                            try
                            {

                                SPSite site = new SPSite(dr.GetGuid(0), user.UserToken);
                                site.CatchAccessDeniedException = false;
                                if(site.OpenWeb().DoesUserHavePermissions(SPBasePermissions.ViewListItems))
                                {
                                    SiteList += "<tr><td class=\"ms-vb2\" style=\"padding-left:10px;\"> <img src=\"/_layouts/images/SharePointFoundation16.png\"><font class=\"ms-vb\"> <a class=\"ms-vb\" href=\"" + site.Url + "\" target=\"_blank\">" + site.RootWeb.Title + "</a> (" + (site.Usage.Storage / 1024 / 1024).ToString() + " MB) - " + site.RootWeb.Description + "</td></tr>";
                                    siteUsage += site.Usage.Storage / 1024 / 1024;
                                }
                            }
                            catch { }
                        }
                        dr.Close();

                        cmd = new SqlCommand("SELECT * FROM vwAccountOrders where account_id=@accountid", cn);
                        cmd.Parameters.AddWithValue("@accountid", ddlAccount.SelectedValue);
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);

                        gvOrders.DataSource = ds.Tables[0];
                        gvOrders.DataBind();


                        cmd = new SqlCommand("SP_GetAccountUsers", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@account_id", ddlAccount.SelectedValue);
                        ds = new DataSet();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                        gvUsers.DataSource = ds.Tables[0];
                        gvUsers.DataBind();




                        /*lblUserCount.Text = ds.Tables[0].Rows.Count.ToString();

                        cmd = new SqlCommand("SELECT sum(quantity) FROM dbo.ACCOUNT INNER JOIN dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref where account_id=@accountid and expiration >= GETDATE()", cn);
                        cmd.Parameters.AddWithValue("@accountid", ddlAccount.SelectedValue);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            if (dr.IsDBNull(0))
                            {
                                dr.Close();

                                cmd = new SqlCommand("SELECT case when dateadd(m,monthsfree,dtcreated) > GETDATE() then maxusers else 0 end as maxusers from account where account_id=@accountid", cn);
                                cmd.Parameters.AddWithValue("@accountid", ddlAccount.SelectedValue);
                                dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    lblMaxUsers.Text = dr.GetInt32(0).ToString() + " Trial Users";
                                    quantity = dr.GetInt32(0).ToString();
                                    try
                                    {
                                        strUserWidth = ((float)ds.Tables[0].Rows.Count / (float)dr.GetInt32(0) * 100.00).ToString();
                                    }
                                    catch { strUserWidth = "100"; }
                                }
                                dr.Close();
                            }
                            else
                            {
                                lblMaxUsers.Text = dr.GetInt32(0).ToString();

                                if (ds.Tables[0].Rows.Count > dr.GetInt32(0))
                                    quantity = (ds.Tables[0].Rows.Count - dr.GetInt32(0)).ToString();
                                else
                                    quantity = "0";
                                strUserWidth = ((float)ds.Tables[0].Rows.Count / (float)dr.GetInt32(0) * 100.00).ToString();

                                dr.Close();
                            }
                        }
                        */

                        cmd = new SqlCommand("2010SP_GetAccountNums", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@accountid", ddlAccount.SelectedValue);
                        cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());

                        dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            lblMaxUsers.Text = dr.GetInt32(0).ToString();
                            lblUserCount.Text = dr.GetInt32(1).ToString();

                            if(dr.GetInt32(1) - dr.GetInt32(0) < 0)
                                quantity = "0";
                            else
                                quantity = (dr.GetInt32(1) - dr.GetInt32(0)).ToString();

                            float w = (float)dr.GetInt32(1) / (float)dr.GetInt32(0) * (float)100;

                            if(w > 100)
                                strUserWidth = "100";
                            else
                                strUserWidth = w.ToString();
                        }

                        dr.Close();


                        cmd = new SqlCommand("SELECT case when sum(diskspace) is null then 500 else sum(diskspace) end as spaceusage FROM dbo.ACCOUNT INNER JOIN dbo.ORDERS ON dbo.ACCOUNT.account_ref = dbo.ORDERS.account_ref where account_id=@accountid and expiration >= GETDATE()", cn);
                        cmd.Parameters.AddWithValue("@accountid", ddlAccount.SelectedValue);
                        dr = cmd.ExecuteReader();

                        if(dr.Read())
                        {

                            strSiteUsageWidth = ((float)siteUsage / (float)dr.GetInt32(0) * 100.00).ToString();

                            lblDiskQuota.Text = dr.GetInt32(0).ToString();
                            lbldiskusage.Text = siteUsage.ToString();
                        }
                        dr.Close();

                        account_ref = lblAccountNumber.Text;
                        level = Settings.getContractLevel();
                    }
                }

                if (ddlAccount.Items.Count == 0)
                {
                    tbMain.Visible = false;
                }
                cn.Close();
            });
        }


    }
}
