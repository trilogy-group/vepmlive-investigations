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
        protected string SiteUrl { get; set; }
        protected string CurrentTemplate { get; set; }

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

                    using (var command = new SqlCommand(
                        "SELECT * FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid",
                        connection))
                    {
                        command.Parameters.AddWithValue("@siteid", web.Site.ID);
                        command.Parameters.AddWithValue("@webid", web.ID);
                        using (var dataReader = command.ExecuteReader())
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
                    var childSiteTemplateID = web.Properties["EPMLiveTemplateID"].ToString();
                    var site = SPContext.Current.Site;
                    foreach (SPWeb subWeb in site.AllWebs)
                    {
                        try
                        {
                            if (subWeb.Properties.ContainsKey("EPMLiveTemplateID"))
                            {
                                var idCheck = subWeb.Properties["EPMLiveTemplateID"].ToString();
                                if (childSiteTemplateID == idCheck)
                                {
                                    var templateId = subWeb.ID.ToString();
                                    var Ids = web.Site.RootWeb.Properties["EPMLiveSiteTemplateIDs"];
                                    if (Ids != null && Ids.Contains(templateId))
                                    {
                                        lblSelectedTemplate.Text = subWeb.Title;
                                        CurrentTemplate = templateId;
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
            var masterPageGallerList = web.Lists["Master Page Gallery"] as SPList;
            if (masterPageGallerList != null)
            {
                var fullFileNameAndPath = string.Empty;
                var fileName = string.Empty;
                SiteUrl = web.Url;
                foreach (SPListItem masterPageItem in masterPageGallerList.Items)
                {
                    var fldFullFileNameAndPath = masterPageItem.Fields.GetFieldByInternalName("FileRef");
                    if (masterPageItem[fldFullFileNameAndPath.Id] != null)
                    {
                        fullFileNameAndPath = masterPageItem[fldFullFileNameAndPath.Id].ToString();
                    }

                    var fieldFileName = masterPageItem.Fields.GetFieldByInternalName("FilenameNoLink");
                    if (masterPageItem[fieldFileName.Id] != null)
                    {
                        fileName = masterPageItem[fieldFileName.Id].ToString();
                    }

                    if (fileName.IndexOf(".master", 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                    {
                        var listItem = new ListItem(
                            fileName.Replace(".master", string.Empty).Replace(".MASTER", string.Empty),
                            fullFileNameAndPath);
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
            var webSettingsAdditionalInfo = new WebSettingsAdditionalInfo(web);
            webSettingsAdditionalInfo.SetEPMLiveVersion(lblEPMLVersion);
            webSettingsAdditionalInfo.SetSharePointVersion(lblSPVersion);
            webSettingsAdditionalInfo.SetEPMLiveDatabase(lblEMPLDB, lblEPMLDBServer);
            webSettingsAdditionalInfo.SetReportingDatabase(lblReportingDB, lblReportingDBServer);
            webSettingsAdditionalInfo.SetPFEDatabase(lblPFEDB, lblPFEDBServer);
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
                        using (var command = new SqlCommand(
                            "SELECT * FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid",
                            connection))
                        {
                            command.Parameters.AddWithValue("@siteid", web.Site.ID);
                            command.Parameters.AddWithValue("@webid", web.ID);
                            using (var dataReader = command.ExecuteReader())
                            {
                                recordExists = dataReader.Read();
                            }
                        }
                        if (!recordExists)
                        {
                            using (var command = new SqlCommand(
                                "INSERT INTO PERSONALIZATIONS ([Key],SiteId,webid) Values ('webarchived', @siteId, @webid)",
                                connection))
                            {
                                command.Parameters.AddWithValue("@siteid", web.Site.ID);
                                command.Parameters.AddWithValue("@webid", web.ID);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        using (var command = new SqlCommand(
                            "DELETE FROM PERSONALIZATIONS WHERE ([Key] = 'webarchived') AND (SiteId = @siteId) and WebId=@webid",
                            connection))
                        {
                            command.Parameters.AddWithValue("@siteid", web.Site.ID);
                            command.Parameters.AddWithValue("@webid", web.ID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            });
        }
    }
}
