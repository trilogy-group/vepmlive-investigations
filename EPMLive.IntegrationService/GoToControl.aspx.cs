using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Data.SqlClient;
using System.Web.Security;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.Web;


namespace EPMLiveIntegrationService
{
    public partial class GoToControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Control = Request["Control"];
            string ID = Request["ID"];
            string IntegrationId = Request["IntegrationId"];
            string url = "";

            if(string.IsNullOrEmpty(Control))
            {
                lblMessage.Text = "Control Not Specified";
            }
            else
            {
                if(string.IsNullOrEmpty(IntegrationId))
                {
                    lblMessage.Text = "Integration Id Not Specified";
                }
                else
                {
                    try
                    {
                        SPFarm farm = SPFarm.Local;
                        //Get all SharePoint Web services 
                        SPWebService service = farm.Services.GetValue<SPWebService>("");

                        foreach(SPWebApplication webapp in service.WebApplications)
                        {
                            if(webapp.Name == System.Configuration.ConfigurationManager.AppSettings["WebApplication"])
                            {

                                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(webapp.Id));
                                cn.Open();

                                SqlCommand cmd = new SqlCommand("SELECT INT_LIST_ID,SITE_ID, WEB_ID, LIST_ID from INT_LISTS where INT_LIST_ID=@intlistid", cn);
                                cmd.Parameters.AddWithValue("@intlistid", IntegrationId);
                                
                                Guid listid = Guid.Empty;
                                Guid siteid = Guid.Empty;
                                Guid webid = Guid.Empty;
                                Guid intlistuid = Guid.Empty;

                                SqlDataReader dr = cmd.ExecuteReader();
                                if(dr.Read())
                                {
                                    intlistuid = dr.GetGuid(0);
                                    siteid = dr.GetGuid(1);
                                    webid = dr.GetGuid(2);
                                    listid = dr.GetGuid(3);
                                }

                                dr.Close();
                                
                                
                                if (webid != Guid.Empty)
                                {
                                    if (Control.ToLower().StartsWith("epmlive-"))
                                    {
                                        Control = Control.Substring(8);

                                        SPSecurity.RunWithElevatedPrivileges(delegate()
                                        {
                                            using (SPSite site = new SPSite(siteid))
                                            {
                                                using (SPWeb web = site.OpenWeb(webid))
                                                {
                                                    //SPList list = web.Lists[listid];

                                                    //SPQuery query = new SPQuery();
                                                    //query.Query = "<Where><Eq><FieldRef Name='INTUID" + srccolid + "'/><Value Type='Text'>" + ID + "</Value></Eq></Where>";

                                                    //SPListItemCollection lic = list.GetItems(query);

                                                    //if(lic.Count > 0)
                                                    //{
                                                    //    url = web.Url + "/_layouts/epmlive/integration/opencontrol.aspx?control=" + Control + "&id=" + lic[0].ID +"&intid=" + IntegrationId;
                                                    //}
                                                    url = web.Url + "/_layouts/epmlive/integration/opencontrol.aspx?control=" + Control + "&id=" + ID + "&intid=" + IntegrationId;

                                                }

                                            }


                                        });

                                    }
                                    else
                                    {
                                        cmd = new SqlCommand(@"SELECT     INT_LISTS_1.INT_COLID, dbo.INT_LISTS.LIST_ID, dbo.INT_LISTS.INT_COLID AS Expr1, dbo.INT_LISTS.SITE_ID, dbo.INT_LISTS.WEB_ID, 
                                                                      INT_LISTS_1.INT_LIST_ID
                                                                        FROM         dbo.INT_CONTROLS INNER JOIN
                                                                      dbo.INT_LISTS AS INT_LISTS_1 ON dbo.INT_CONTROLS.INT_LIST_ID = INT_LISTS_1.INT_LIST_ID RIGHT OUTER JOIN
                                                                      dbo.INT_LISTS ON INT_LISTS_1.LIST_ID = dbo.INT_LISTS.LIST_ID WHERE     (dbo.INT_LISTS.INT_LIST_ID = @integrationid) and Control=@control", cn);
                                        cmd.Parameters.AddWithValue("@integrationid", IntegrationId);
                                        cmd.Parameters.AddWithValue("@control", Control);

                                        int destcolid = 0;
                                        int srccolid = 0;
                                        dr = cmd.ExecuteReader();
                                        if (dr.Read())
                                        {
                                            if (!dr.IsDBNull(0))
                                                destcolid = dr.GetInt32(0);

                                            srccolid = dr.GetInt32(2);

                                            dr.Close();
                                            SPSecurity.RunWithElevatedPrivileges(delegate()
                                            {
                                                EPMLiveCore.API.Integration.IntegrationCore core = new EPMLiveCore.API.Integration.IntegrationCore(siteid, webid);
                                                string ItemId = "";
                                                if (!string.IsNullOrEmpty(ID))
                                                {

                                                    using (SPSite site = new SPSite(siteid))
                                                    {
                                                        using (SPWeb web = site.OpenWeb(webid))
                                                        {
                                                            SPList list = web.Lists[listid];

                                                            try
                                                            {
                                                                SPQuery query = new SPQuery();
                                                                query.Query = "<Where><Eq><FieldRef Name='INTUID" + srccolid + "'/><Value Type='Text'>" + ID + "</Value></Eq></Where>";

                                                                SPListItemCollection lic = list.GetItems(query);

                                                                if (lic.Count > 0)
                                                                {
                                                                    ItemId = lic[0]["INTUID" + destcolid].ToString();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        }

                                                    }



                                                    if (ItemId != "")
                                                    {
                                                        url = core.GetControlURL(intlistuid, listid, Control, ItemId);
                                                    }
                                                    else
                                                    {
                                                        lblMessage.Text = "Couldn't find matching ID";
                                                    }
                                                }
                                                else
                                                {
                                                    url = core.GetControlURL(intlistuid, listid, Control, "");
                                                }
                                            });
                                        }
                                        else
                                        {
                                            dr.Close();
                                            lblMessage.Text = "Invalid Control";
                                        }
                                    }
                                }
                                else
                                {
                                    lblMessage.Text = "Invalid Integration";
                                }
                                cn.Close();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        lblMessage.Text = "Configuration Error: " + ex.Message;
                    }
                }
            }

            if (!string.IsNullOrEmpty(url))
                Response.Redirect(url);
        }
        
    }
}