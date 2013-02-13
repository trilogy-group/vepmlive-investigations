using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;

namespace EPMLiveWebParts.BuyNow
{
    [ToolboxItemAttribute(false)]
    public class BuyNow : WebPart
    {
        protected override void CreateChildControls()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            Guid siteuid = SPContext.Current.Site.ID;

            SPWeb web = SPContext.Current.Web;
            
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(siteuid))
                {
                    if(site.WebApplication.Features[new Guid("19e6ae14-9e68-44fa-9a08-c1c4514bf12e")] != null)
                    {

                        try
                        {
                            MethodInfo m;

                            Assembly assemblyInstance = Assembly.Load("EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                            Type thisClass = assemblyInstance.GetType("EPMLiveAccountManagement.Settings", true, true);
                            m = thisClass.GetMethod("getConnectionStringByWebApp");
                            string sConn = (string)m.Invoke(null, new object[] { site.WebApplication.Name });

                            SqlConnection cn = new SqlConnection(sConn);
                            cn.Open();


                            SqlCommand cmd = new SqlCommand("2012SP_GetActivationInfo", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@siteid", siteuid);
                            cmd.Parameters.AddWithValue("@username", "");

                            DataSet ds = new DataSet();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(ds);

                            int ActivationType = 0;

                            try
                            {
                                ActivationType = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                            }
                            catch { }


                            cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@siteid", siteuid);
                            cmd.Parameters.AddWithValue("@contractLevel", EPMLiveCore.CoreFunctions.getContractLevel(site));

                            SqlDataReader dr = cmd.ExecuteReader();
                            bool isOwner = false;
                            bool bIsTrial = false;

                            if(dr.Read())
                            {
                                if(dr.GetString(13).ToLower() == EPMLiveCore.CoreFunctions.GetRealUserName(SPContext.Current.Web.CurrentUser.LoginName).ToLower())
                                {
                                    isOwner = true;
                                }
                            }
                            dr.Close();

                            cmd = new SqlCommand(@"SELECT     top 1 dbo.CONTRACTLEVELS.istrial, dbo.CONTRACTLEVEL_TITLES.TITLE, ORDERS.expiration, orders.order_id, dbo.CONTRACTLEVELS.contractlevel
                                                        FROM         dbo.ORDERS INNER JOIN
                                                                              dbo.CONTRACTLEVELS ON dbo.ORDERS.contractid = dbo.CONTRACTLEVELS.contractId INNER JOIN
                                                                              dbo.CONTRACTLEVEL_TITLES ON dbo.CONTRACTLEVELS.contractlevel = dbo.CONTRACTLEVEL_TITLES.CONTRACTLEVEL INNER JOIN
                                                                              dbo.ACCOUNT ON dbo.ORDERS.account_ref = dbo.ACCOUNT.account_ref INNER JOIN
                                                                              dbo.ACCOUNT_EXTERNAL_SITES ON dbo.ACCOUNT.account_id = dbo.ACCOUNT_EXTERNAL_SITES.account_id
                                                        WHERE     (dbo.CONTRACTLEVEL_TITLES.GroupId = 2) AND (siteguid = @siteid)", cn);
                            cmd.Parameters.AddWithValue("@siteid", site.ID);

                            dr = cmd.ExecuteReader();
                            if(dr.Read())
                            {
                                try
                                {
                                    bIsTrial = dr.GetBoolean(0);
                                }
                                catch { }

                                try
                                {
                                    if(dr.GetInt32(4) == 5)
                                        bIsTrial = true;
                                }
                                catch { }


                            } 
                            dr.Close();


                            if(isOwner && ActivationType == 3 && bIsTrial)
                            {
                                string url = (web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl;

                                writer.WriteLine("<script language=\"javascript\">");
                                writer.WriteLine("function buynow(){SP.UI.ModalDialog.showModalDialog({url: '" + url + "/_layouts/epmlive/v2purchase.aspx',width: 800,height: 600});}");
                                writer.WriteLine("</script>");

                                writer.WriteLine("<Style>");
                                writer.WriteLine(@".upgradeButton
                                                    {
                                                        background-color: #9DD167;
                                                        color: white;
                                                        border: 1px solid #6ABD3D;
                                                        font-family:Helvetica;
                                                        font-size:14px;
                                                        font-weight:bold;
                                                        padding-top:5px;
                                                        padding-bottom:5px;
                                                        width:75px;
                                                        text-align:center;
                                                        text-decorcation:none;
                                                        cursor:pointer;
                                                    }

                                                    .upgradeButton:hover
                                                    {
                                                    background-color:#98C964;
                                                    }
                                                    </style>");

                                writer.WriteLine("<div class=\"upgradeButton\" onclick=\"javascript:buynow();\">Upgrade</div>");
                            }
                        }
                        catch { }
                    }
                }
            });
        }
    }
}
