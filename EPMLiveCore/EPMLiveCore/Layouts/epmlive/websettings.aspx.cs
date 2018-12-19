using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using SysTrace = System.Diagnostics.Trace;

namespace EPMLiveCore
{
    public partial class websettings : LayoutsPageBase
    {
        protected string StrSiteUrl { get; set; }
        protected string StrCurrentTemplate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var web = SPContext.Current.Web;
                lblSiteId.Text = web.Site.ID.ToString();
                lblWebId.Text = web.ID.ToString();
                AddMasterPages(web);

                chkDisablePublishing.Checked = CoreFunctions.getConfigSetting(web, "EPMLiveDisablePublishing") == "True"
                    ? true
                    : false;
                TrySetCheckedProperty(web, chkDisablePlanners, "EPMLiveDisablePlanners");
                TrySetCheckedProperty(web, chkDisableContextualSlideouts, "EPMLiveDisableContextualSlideouts");

                try
                {
                    tbPublicCommentDefaultTxt.Text = CoreFunctions.getConfigSetting(web, "EPMLivePublicCommentText");
                }
                catch (Exception ex)
                {
                    SysTrace.WriteLine(ex);
                }

                SetProductAdditionalInfo(web);
                UpdateAllowSynch(web);

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
                catch (Exception ex)
                {
                    SysTrace.WriteLine(ex);
                }

                if (web.ServerRelativeUrl.Equals(CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL"), StringComparison.InvariantCultureIgnoreCase))
                {
                    pnlResources.Visible = true;
                }

                if (web.Properties.ContainsKey("TemplateVersion"))
                {
                    txtVersion.Text = $"v {web.Properties["TemplateVersion"]}";
                }

                MarkArchivedPersonalizationsChecked(web);
                cbDisableMyWorkspaces.Checked = GetConfigSettingIfNotEmpty(web, "EPMLiveDisableMyWorkspaces");
                cbDisableCommonActions.Checked = GetConfigSettingIfNotEmpty(web, "EPMLiveDisableCommonActions");
                cbDisableCreateNew.Checked = GetConfigSettingIfNotEmpty(web, "EPMLiveDisableCreateNew");
            }
        }

        private void TrySetCheckedProperty(SPWeb web, CheckBox checkBox, string settingKey)
        {
            try
            {
                checkBox.Checked = bool.Parse(CoreFunctions.getConfigSetting(web, settingKey));
            }
            catch (Exception ex)
            {
                SysTrace.WriteLine(ex);
            }
        }

        private void MarkArchivedPersonalizationsChecked(SPWeb web)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var connection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                {
                    connection.Open();

                    using (var cmd = new SqlCommand(
                        "SELECT * FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid",
                        connection))
                    {
                        cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                        cmd.Parameters.AddWithValue("@webid", web.ID);
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                chkArchive.Checked = true;
                            }
                        }
                    }
                }
            });
        }

        private void UpdateAllowSynch(SPWeb web)
        {
            if (!web.CurrentUser.IsSiteAdmin)
            {
                pnlAllowSynch.Visible = false;
            }
            else
            {
                chkAllowSynch.Checked = CoreFunctions.getConfigSetting(web, "EPMLiveAllowListSynch")
                    .Equals("true", StringComparison.InvariantCultureIgnoreCase)
                    ? true
                    : false;
                if (web.Properties.ContainsKey("EPMLiveTemplateID"))
                {
                    var sChildSiteTemplateID = web.Properties["EPMLiveTemplateID"].ToString();
                    var site = SPContext.Current.Site;
                    foreach (SPWeb subWeb in site.AllWebs)
                    {
                        try
                        {
                            if (subWeb.Properties.ContainsKey("EPMLiveTemplateID"))
                            {
                                var idCheck = subWeb.Properties["EPMLiveTemplateID"].ToString();
                                if (sChildSiteTemplateID == idCheck)
                                {
                                    var templateId = subWeb.ID.ToString();
                                    var Ids = web.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                                    if (Ids != null && Ids.Contains(templateId))
                                    {
                                        lblSelectedTemplate.Text = subWeb.Title;
                                        StrCurrentTemplate = templateId;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SysTrace.WriteLine(ex);
                        }
                        subWeb.Close();
                        subWeb.Dispose();
                    }
                }
            }
        }

        private void AddMasterPages(SPWeb web)
        {
            var oList = web.Lists["Master Page Gallery"] as SPList;
            if (oList != null)
            {
                var sFullFileNameAndPath = string.Empty;
                var sFileName = string.Empty;
                StrSiteUrl = web.Url;
                foreach (SPListItem masterPageItem in oList.Items)
                {
                    var fldFullFileNameAndPath = masterPageItem.Fields.GetFieldByInternalName("FileRef");
                    if (masterPageItem[fldFullFileNameAndPath.Id] != null)
                    {
                        sFullFileNameAndPath = masterPageItem[fldFullFileNameAndPath.Id].ToString();
                    }

                    var fldFileName = masterPageItem.Fields.GetFieldByInternalName("FilenameNoLink");
                    if (masterPageItem[fldFileName.Id] != null)
                    {
                        sFileName = masterPageItem[fldFileName.Id].ToString();
                    }

                    if (sFileName.IndexOf(".master", 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        var listItem = new ListItem(
                            sFileName.Replace(".master", string.Empty).Replace(".MASTER", string.Empty),
                            sFullFileNameAndPath);
                        ddlMasterPages.Items.Add(listItem);
                    }
                }
                ddlMasterPages.SelectedValue = web.MasterUrl;
            }
        }

        private bool GetConfigSettingIfNotEmpty(SPWeb web, string settingKey)
        {
            var settingValue = CoreFunctions.getConfigSetting(web, settingKey);
            if (!string.IsNullOrWhiteSpace(settingValue))
            {
                bool settingBooleanValue;
                if (!bool.TryParse(settingValue, out settingBooleanValue))
                {
                    throw new InvalidOperationException($"A valid bool is expected in {settingValue}");
                }

                return settingBooleanValue;
            }

            return false;
        }

        /// <summary>
        /// Set additional information on product including versions and DB names
        /// </summary>
        private void SetProductAdditionalInfo(SPWeb web)
        {
            var WebSettingsHelper = new WebSettingsHelper(web);
            WebSettingsHelper.SetEPMLiveVersion(lblEPMLVersion);
            WebSettingsHelper.SetSharePointVersion(lblSPVersion);
            WebSettingsHelper.SetEPMLiveDatabase(lblEMPLDB, lblEPMLDBServer);
            WebSettingsHelper.SetReportingDatabase(lblReportingDB, lblReportingDBServer);
            WebSettingsHelper.SetPFEDatabase(lblPFEDB, lblPFEDBServer);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var web = SPContext.Current.Web;
            web.Site.CatchAccessDeniedException = false;
            web.AllowUnsafeUpdates = true;

            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePublishing", chkDisablePublishing.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisablePlanners", chkDisablePlanners.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableContextualSlideouts", chkDisableContextualSlideouts.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLivePublicCommentText", tbPublicCommentDefaultTxt.Text.ToString());

            if (web.CurrentUser.IsSiteAdmin)
            {
                CoreFunctions.setConfigSetting(web, "EPMLiveAllowListSynch", chkAllowSynch.Checked.ToString());
                if (Request["TemplateSelected"] == "true")
                {
                    CoreFunctions.setConfigSetting(web, "EPMLiveTemplateID", Request["selectedWebID"]);
                }
            }

            CoreFunctions.setConfigSetting(web, "EPMLiveResourcePool", ddlResources.SelectedValue);
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableMyWorkspaces", cbDisableMyWorkspaces.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableCommonActions", cbDisableCommonActions.Checked.ToString());
            CoreFunctions.setConfigSetting(web, "EPMLiveDisableCreateNew", cbDisableCreateNew.Checked.ToString());

            web.MasterUrl = ddlMasterPages.SelectedValue.ToString();
            web.Update();
            UpdatePersonalizations(web);

            var requestSource = Request["Source"];
            if (!string.IsNullOrWhiteSpace(requestSource))
            {
                Response.Redirect(requestSource);
            }
            else
            {
                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

        private void UpdatePersonalizations(SPWeb web)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var connection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                {
                    connection.Open();

                    if (chkArchive.Checked)
                    {
                        var recordExists = true;
                        using (var cmd = new SqlCommand("SELECT * FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid", connection))
                        {
                            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                            cmd.Parameters.AddWithValue("@webid", web.ID);
                            using (var dataReader = cmd.ExecuteReader())
                            {
                                recordExists = dataReader.Read();
                            }
                        }
                        if (!recordExists)
                        {
                            using (var cmd = new SqlCommand(
                                "INSERT INTO PERSONALIZATIONS ([Key],SiteId,webid) Values ('webarchived', @siteId, @webid)",
                                connection))
                            {
                                cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                                cmd.Parameters.AddWithValue("@webid", web.ID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        using (var cmd = new SqlCommand(
                            "DELETE FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid",
                            connection))
                        {
                            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                            cmd.Parameters.AddWithValue("@webid", web.ID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            });
        }
    }
}
