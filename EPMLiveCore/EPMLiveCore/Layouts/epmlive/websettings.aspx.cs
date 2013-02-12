using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
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

                    if (!web.CurrentUser.IsSiteAdmin)
                    {
                        pnlAllowSynch.Visible = false;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;

            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePublishing", chkDisablePublishing.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePlanners", chkDisablePlanners.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableContextualSlideouts", chkDisableContextualSlideouts.Checked.ToString());

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
