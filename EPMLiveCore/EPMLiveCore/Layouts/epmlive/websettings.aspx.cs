using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Win32;
namespace EPMLiveCore
{
    public partial class websettings : LayoutsPageBase
    {
        protected string strSiteUrl;
        protected string strCurrentTemplate;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SPWeb web = SPContext.Current.Web;
                {
                    lblSiteId.Text = web.Site.ID.ToString();
                    lblWebId.Text = web.ID.ToString();
                    SPList oList;
                    oList = web.Lists["Master Page Gallery"] as SPList;
                    if (oList != null)
                    {
                        string sFullFileNameAndPath = "";
                        string sFileName = "";
                        strSiteUrl = web.Url;
                        foreach (SPListItem liMP in oList.Items)
                        {
                            SPField fldFullFileNameAndPath = liMP.Fields.GetFieldByInternalName("FileRef");
                            if (liMP[fldFullFileNameAndPath.Id] != null)
                            {
                                sFullFileNameAndPath = liMP[fldFullFileNameAndPath.Id].ToString();
                            }

                            SPField fldFileName = liMP.Fields.GetFieldByInternalName("FilenameNoLink");
                            if (liMP[fldFileName.Id] != null)
                            {
                                sFileName = liMP[fldFileName.Id].ToString();
                            }

                            if (sFileName.ToUpper().Contains(".master") || sFileName.ToUpper().Contains(".MASTER"))
                            {
                                ListItem li = new ListItem(sFileName.Replace(".master", "").Replace(".MASTER", ""), sFullFileNameAndPath);
                                ddlMasterPages.Items.Add(li);
                            }
                        }
                        ddlMasterPages.SelectedValue = web.MasterUrl;
                    }

                    if (CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing") == "True")
                        chkDisablePublishing.Checked = true;
                    else
                        chkDisablePublishing.Checked = false;

                    try
                    {
                        chkDisablePlanners.Checked = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveDisablePlanners"));
                    }
                    catch { }

                    try
                    {
                        chkDisableContextualSlideouts.Checked = bool.Parse(CoreFunctions.getConfigSetting(web, "EPMLiveDisableContextualSlideouts"));
                    }
                    catch { }

                    try
                    {
                        ////EPML-5445
                        //var supportIntegration = CoreFunctions.getConfigSetting(web, "SupportIntegration");
                        //chkSupportIntegration.Checked = !string.IsNullOrEmpty(supportIntegration) && Convert.ToBoolean(supportIntegration);
                        ////EPML-5445
                    }
                    catch { }

                    try
                    {
                        tbPublicCommentDefaultTxt.Text = CoreFunctions.getConfigSetting(web, "EPMLivePublicCommentText");
                    }
                    catch { }

                    // Set additional information on product including versions and DB names
                    SetProductAdditionalInfo(web);

                    if (!web.CurrentUser.IsSiteAdmin)
                    {
                        pnlAllowSynch.Visible = false;
                        ////EPML-5445
                        //ifsSupportIntegration.Visible = false;
                        ////EPML-5445
                    }
                    else
                    {
                        if (CoreFunctions.getConfigSetting(web, "EPMLiveAllowListSynch").ToLower() == "true")
                            chkAllowSynch.Checked = true;
                        else
                            chkAllowSynch.Checked = false;
                        if (web.Properties.ContainsKey("EPMLiveTemplateID"))
                        {
                            string sChildSiteTemplateID = web.Properties["EPMLiveTemplateID"].ToString();
                            SPSite site = SPContext.Current.Site;
                            {
                                string sTemplateID;
                                foreach (SPWeb subWeb in site.AllWebs)
                                {
                                    try
                                    {
                                        if (subWeb.Properties.ContainsKey("EPMLiveTemplateID"))
                                        {
                                            string sIDCheck = subWeb.Properties["EPMLiveTemplateID"].ToString();
                                            if (sChildSiteTemplateID == sIDCheck)
                                            {
                                                sTemplateID = subWeb.ID.ToString();
                                                string sIDs = web.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                                                if (sIDs != null && sIDs.Contains(sTemplateID))
                                                {
                                                    lblSelectedTemplate.Text = subWeb.Title;
                                                    strCurrentTemplate = sTemplateID;
                                                }
                                            }
                                        }
                                    }
                                    catch { }
                                    subWeb.Close();
                                    subWeb.Dispose();
                                }
                            }
                        }

                        //EPML-5445
                        //ifsSupportIntegration.Visible = true;
                        //EPML-5445
                    }
                    foreach (SPList list in web.Lists)
                    {
                        if (!list.Hidden)
                        {
                            ddlResources.Items.Add(list.Title);
                        }
                    }
                    try
                    {
                        ddlResources.SelectedValue = CoreFunctions.getConfigSetting(web, "EPMLiveResourcePool");
                    }
                    catch { }

                    if (web.ServerRelativeUrl.ToLower() == CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL").ToLower())
                    {
                        pnlResources.Visible = true;
                    }

                    if (web.Properties.ContainsKey("TemplateVersion"))
                    {
                        txtVersion.Text = "v " + web.Properties["TemplateVersion"];
                    }

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT * FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid", cn);
                        cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                        cmd.Parameters.AddWithValue("@webid", web.ID);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            chkArchive.Checked = true;
                        }
                        dr.Close();

                        cn.Close();
                    });

                    string disableMyWorkspaces = CoreFunctions.getConfigSetting(web, "EPMLiveDisableMyWorkspaces");
                    cbDisableMyWorkspaces.Checked = !string.IsNullOrEmpty(disableMyWorkspaces) ? bool.Parse(disableMyWorkspaces) : false;
                    string disableCommonActions = CoreFunctions.getConfigSetting(web, "EPMLiveDisableCommonActions");
                    cbDisableCommonActions.Checked = !string.IsNullOrEmpty(disableCommonActions) ? bool.Parse(disableCommonActions) : false;
                    string disableCreateNew = CoreFunctions.getConfigSetting(web, "EPMLiveDisableCreateNew");
                    cbDisableCreateNew.Checked = !string.IsNullOrEmpty(disableCreateNew) ? bool.Parse(disableCreateNew) : false;

                }
            }
        }

        private void SetProductAdditionalInfo(SPWeb web)
        {
            #region EPMLive Version

            lblEPMLVersion.Text = CoreFunctions.GetFullAssemblyVersion();

            #endregion

            #region SharePoint Version

            try
            {
                lblSPVersion.Text = Convert.ToString(web.Site.WebApplication.Farm.BuildVersion);
            }
            catch 
            { }
 
            #endregion

            #region EPMLive Database

            string epmliveConnection = string.Empty;
            string errMsg = "Cannot get EPMLive database information.";
            try
            {
                epmliveConnection = CoreFunctions.getConnectionString(web.Site.WebApplication.Id);
                if (!string.IsNullOrEmpty(epmliveConnection))
                {
                    using (SqlConnection conn = new SqlConnection(epmliveConnection))
                    {
                        lblEMPLDB.Text = string.Format("Name: {0}", conn.Database);
                        lblEPMLDBServer.Text = string.Format("Server: {0}", conn.DataSource);
                    }
                }
                else 
                {
                    lblEMPLDB.Text = errMsg;
                }
            }
            catch
            {
                lblEMPLDB.Text = errMsg;
            } 
            #endregion

            #region Reporting Database
            
            errMsg = "Cannot get Reporting database information.";
            if (!string.IsNullOrEmpty(epmliveConnection))
            {
                string info = Utilities.GetReportingDbConnectionString(epmliveConnection, web.Site.ID, web.Site.WebApplication.Id);
                if (!string.IsNullOrEmpty(info))
                {
                    try
                    {
                        using (SqlConnection reportingConn = new SqlConnection(info))
                        {
                            lblReportingDB.Text = string.Format("Name: {0}", reportingConn.Database);
                            lblReportingDBServer.Text = string.Format("Server: {0}", reportingConn.DataSource);
                        }
                    }
                    catch
                    {
                        lblReportingDB.Text = errMsg;
                    }
                }
                else
                {
                    lblReportingDB.Text = errMsg;
                }
            }
            else
            {
                lblReportingDB.Text = errMsg;
            }

            #endregion

            #region PFE Database

            string basePath = GetBasePath();
            errMsg = "Cannot get PFE database information.";
            if (!string.IsNullOrEmpty(basePath))
            {
                string pfeConnection = Utilities.GetPFEDBConnectionString(basePath);
                if (!string.IsNullOrEmpty(pfeConnection))
                {
                    try
                    {
                        if (pfeConnection.StartsWith("provider", StringComparison.InvariantCultureIgnoreCase))
                        {
                            // Removing "Provider" part from connection string
                            pfeConnection = pfeConnection.Substring(pfeConnection.IndexOf(';') + 1);
                        }
                        using (SqlConnection pfeConn = new SqlConnection(pfeConnection))
                        {
                            lblPFEDB.Text = string.Format("Name: {0}", pfeConn.Database);
                            lblPFEDBServer.Text = string.Format("Server: {0}", pfeConn.DataSource);
                        }
                    }
                    catch
                    {
                        lblPFEDB.Text = errMsg;
                    }
                }
                else
                {
                    lblPFEDB.Text = errMsg;
                }
            }
            else
            {
                lblPFEDB.Text = errMsg;
            }

            #endregion
        }

        private string GetBasePath()
        {
            try
            {
                string basePath = CoreFunctions.getConfigSetting(SPContext.Current.Web.Site.RootWeb, "EPKBasepath").Replace("/", "").Replace("\\", "");
                return basePath;
            }
            catch { return ""; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;

            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePublishing", chkDisablePublishing.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePlanners", chkDisablePlanners.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableContextualSlideouts", chkDisableContextualSlideouts.Checked.ToString());
            ////EPML-5445
            //CoreFunctions.setConfigSetting(web, "SupportIntegration", chkSupportIntegration.Checked.ToString());
            ////EPML-5445
            CoreFunctions.setConfigSetting(web, "EPMLivePublicCommentText", tbPublicCommentDefaultTxt.Text.ToString());

            if (web.CurrentUser.IsSiteAdmin)
            {
                CoreFunctions.setConfigSetting(web, "EPMLiveAllowListSynch", chkAllowSynch.Checked.ToString());
                if(Request["TemplateSelected"] == "true")
                    CoreFunctions.setConfigSetting(web, "EPMLiveTemplateID", Request["selectedWebID"]);
            }

            CoreFunctions.setConfigSetting(web, "EPMLiveResourcePool", ddlResources.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableMyWorkspaces", cbDisableMyWorkspaces.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableCommonActions", cbDisableCommonActions.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableCreateNew", cbDisableCreateNew.Checked.ToString());

            web.MasterUrl = ddlMasterPages.SelectedValue.ToString();
            web.Update();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                cn.Open();

                if(chkArchive.Checked)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid", cn);
                    cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                    cmd.Parameters.AddWithValue("@webid", web.ID);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.Read())
                    {
                        dr.Close();
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO PERSONALIZATIONS ([Key],SiteId,webid) Values ('webarchived', @siteId, @webid)", cn);
                        cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                        cmd.Parameters.AddWithValue("@webid", web.ID);
                        cmd.ExecuteNonQuery();
                    }

                }
                else
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid", cn);
                    cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                    cmd.Parameters.AddWithValue("@webid", web.ID);
                    cmd.ExecuteNonQuery();
                }

                cn.Close();
            });

            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]);
            }
            else
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("settings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

    }
}
