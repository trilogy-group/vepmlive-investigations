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

        private const string EPMLiveRegistryPath = @"SOFTWARE\Wow6432Node\EPMLive\PortfolioEngine\";

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
                        tbWalkMe.Text = CoreFunctions.getConfigSetting(web, "EPMLiveWalkMeId");
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
                        ifsWalkMe.Visible = false;
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

                        ifsWalkMe.Visible = true;
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

            #region Product Databases
            string epmliveConnection = string.Empty;
            // EPML Database
            try
            {
                epmliveConnection = CoreFunctions.getConnectionString(web.Site.WebApplication.Id);
                if (!string.IsNullOrEmpty(epmliveConnection))
                {
                    using (SqlConnection conn = new SqlConnection(epmliveConnection))
                    {
                        lblEMPLDB.Text += conn.Database;
                        lblEPMLDBServer.Text += conn.DataSource;
                    }
                }
            }
            catch
            { }
            // Reporting Database
            if (!string.IsNullOrEmpty(epmliveConnection))
            {
                SqlConnection conn = null;
                SqlDataReader reader = null;
                try
                {
                    using (conn = new SqlConnection(epmliveConnection))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "select DatabaseName, DatabaseServer from RPTDATABASES where SiteId = '" + web.Site.ID + "' and WebApplicationId = '" + web.Site.WebApplication.Id + "'";
                            cmd.Connection = conn;
                            reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                lblReportingDB.Text += Convert.ToString(reader["DatabaseName"]);
                                lblReportingDBServer.Text += Convert.ToString(reader["DatabaseServer"]);
                            }
                            reader.Close();
                            reader.Dispose();
                        }
                        conn.Close();
                    }
                }
                catch
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                    if (conn != null)
                    {
                        conn.Dispose();
                    }
                }
            }
            // PFE Database
            try
            {
                Uri uri = new Uri(web.Site.RootWeb.Url);
                // Getting site part from the URL
                string registryPath = uri.Segments[uri.Segments.Length - 1];
                // Preparing exact registry path based on site
                registryPath = EPMLiveRegistryPath + registryPath;
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath, false))
                {
                    foreach (string value in key.GetValueNames())
                    {
                        if (value.Equals("ConnectionString", StringComparison.InvariantCultureIgnoreCase))
                        {
                            string connectionString = key.GetValue(value) as string;
                            if (connectionString.StartsWith("provider", StringComparison.InvariantCultureIgnoreCase))
                            {
                                // Removing "Provider" part from connection string
                                connectionString = connectionString.Substring(connectionString.IndexOf(';') + 1);
                            }
                            using (SqlConnection pfeConn = new SqlConnection(connectionString))
                            {
                                lblPFEDB.Text += pfeConn.Database;
                                lblPFEDBServer.Text += pfeConn.DataSource;
                            }
                            break;
                        }
                    }
                }
            }
            catch
            { }

            #endregion
        }        

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;

            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePublishing", chkDisablePublishing.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePlanners", chkDisablePlanners.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableContextualSlideouts", chkDisableContextualSlideouts.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveWalkMeId", tbWalkMe.Text.ToString());
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
