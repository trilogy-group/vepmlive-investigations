using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class v2licensing : LayoutsPageBase
    {
        protected string sAccount = "";
        protected string sTrial = "";
        protected bool bIsTrial = false;
        protected string expiration = "";
        protected string sPurchased = "";
        protected string sInUse = "";

        protected void Page_Load(object sender, EventArgs e)
        {


            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(Web.Site.ID))
                {
                    using(SPWeb web = site.OpenWeb(Web.ID))
                    {
                        SqlConnection cn = null;
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            cn = new SqlConnection(Settings.getConnectionString());
                            cn.Open();
                        });


                        SqlCommand cmd = new SqlCommand(@"SELECT     top 1 dbo.CONTRACTLEVELS.istrial, dbo.CONTRACTLEVEL_TITLES.TITLE, ORDERS.expiration, orders.order_id, dbo.CONTRACTLEVELS.contractlevel
                                                        FROM         dbo.ORDERS INNER JOIN
                                                                              dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId INNER JOIN
                                                                              dbo.CONTRACTLEVEL_TITLES ON dbo.CONTRACTLEVELS.contractlevel = dbo.CONTRACTLEVEL_TITLES.CONTRACTLEVEL INNER JOIN
                                                                              dbo.ACCOUNT ON dbo.ORDERS.account_ref = dbo.ACCOUNT.account_ref INNER JOIN
                                                                              dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id
                                                        WHERE     (dbo.CONTRACTLEVEL_TITLES.GroupId = 2) AND (siteguid = @siteid)", cn);
                        cmd.Parameters.AddWithValue("@siteid", site.ID);

                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            lblVersion.Text = dr.GetString(1);
                            try
                            {
                                bIsTrial = dr.GetBoolean(0);
                            }
                            catch { }

                            if(bIsTrial)
                                lblVersion.Text += " - Trial";

                            try
                            {
                                expiration = dr.GetDateTime(2).ToShortDateString();
                            }
                            catch { }

                            try
                            {
                                if(dr.GetInt32(4) == 5)
                                    bIsTrial = true;
                            }
                            catch { }

                            dr.Close();
                        }
                        else
                        {
                            dr.Close();
                            lblVersion.Text = "EPM Live Trial";
                            bIsTrial = true;

                            cmd = new SqlCommand(@"[2010SP_GetSiteAccountNums]", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@siteid", site.ID);
                            cmd.Parameters.AddWithValue("@contractLevel", 2);
                            
                            dr = cmd.ExecuteReader();
                            if(dr.Read())
                            {
                                expiration = dr.GetDateTime(9).ToShortDateString();
                                sPurchased = "Max. Users: " + dr.GetInt32(0).ToString();
                                sInUse = "In use: " + dr.GetInt32(1).ToString();
                            }
                            dr.Close();
                        }
                        


                        cmd = new SqlCommand(@"SELECT     account_ref
                                                        FROM         dbo.ACCOUNT_EXTERNAL_SITES INNER JOIN
                                                        dbo.ACCOUNT ON dbo.ACCOUNT_EXTERNAL_SITES.account_id = dbo.ACCOUNT.account_id where siteguid=@siteid", cn);
                        cmd.Parameters.AddWithValue("@siteid", site.ID);

                        dr = cmd.ExecuteReader();

                        if(dr.Read())
                        {
                            sAccount = dr.GetInt32(0).ToString();
                        }
                        dr.Close();

                        if(bIsTrial)
                        {

                            sTrial = "<br>Trial Expires: " + expiration;

                        }


                        cmd = new SqlCommand(@"SELECT     dbo.DETAILTYPES.detail_name, SUM(dbo.ORDERDETAIL.quantity) AS Qty
                        FROM         dbo.ORDERS INNER JOIN
                                              dbo.ACCOUNT ON dbo.ORDERS.account_ref = dbo.ACCOUNT.account_ref INNER JOIN
                                              dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id INNER JOIN
                                              dbo.ORDERDETAIL ON dbo.ORDERS.order_id = dbo.ORDERDETAIL.order_id INNER JOIN
                                              dbo.DETAILTYPES ON dbo.ORDERDETAIL.detail_type_id = dbo.DETAILTYPES.detail_type_id
                        WHERE     (dbo.ACCOUNT_EXTERNAL_SITES.siteguid = @siteid)
                        GROUP BY dbo.DETAILTYPES.detail_name", cn);
                        cmd.Parameters.AddWithValue("@siteid", site.ID);

                        dr = cmd.ExecuteReader();

                        if(sPurchased == "")
                        {
                            while(dr.Read())
                            {

                                sPurchased += dr.GetString(0) + ": " + dr.GetInt32(1).ToString() + "<br>";

                            }
                        }
                        dr.Close();

                        cn.Close();
                    }
                }
            });

        }
    }
}
