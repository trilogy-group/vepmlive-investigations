using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveAccountManagement
{
    public partial class expired : LayoutsPageBase
    {
        protected int minBuy = 1;
        protected int accountref = 0;
        protected string siteUrl = "";
        protected string account_ref;
        protected string quantity;
        protected string version;
        protected string level;
        protected string accountid;


        protected Label lblTitle;
        protected Panel pnlTrial;
        protected LinkButton lnkFreeUsers;
        protected Panel pnlAccounts;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;

            siteUrl = site.Url;
            try
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

                int inTrial = 0;
                int daysLeft = 0;
                bool expired = false;

                int users = 0;
                int max = 0;
                if (dr.Read())
                {
                    accountid = dr.GetGuid(2).ToString();
                    inTrial = dr.GetInt32(4);
                    try
                    {
                        expired = dr.GetBoolean(6);
                    }
                    catch { }
                    try
                    {
                        daysLeft = dr.GetInt32(7);
                    }
                    catch { }
                    try
                    {
                        accountref = dr.GetInt32(10);
                        account_ref = accountref.ToString();
                    }
                    catch { }
                    try
                    {
                        users = dr.GetInt32(1) / 5;
                    }
                    catch { }
                    minBuy = users + 1;

                    max = dr.GetInt32(0);
                    int count = dr.GetInt32(1);
                    int buyUsers = 1;
                    if (inTrial == 1)
                    {
                        buyUsers = count;
                    }
                    else
                    {
                        buyUsers = count - max;
                        if (buyUsers < 1)
                            buyUsers = 1;
                    }
                    quantity = buyUsers.ToString();

                }
                dr.Close();

                cmd = new SqlCommand("SELECT min(version) as version from orders where account_ref=@accountref", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@accountref", accountref);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                version = ds.Tables[0].Rows[0][0].ToString();

                if (inTrial == 1 && expired || max == 0)
                {
                    lblTitle.Text = "Account Expired";
                    pnlTrial.Visible = true;
                }
                else if (expired)
                {
                    lblTitle.Text = "Maximum Exceeded";
                    pnlAccounts.Visible = true;
                }
            }
            catch (Exception ex) { }

            level = Settings.getContractLevel();
        }
        protected void lnkFreeUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://my.epmlive.com/home/accounts");
        }
    }
}