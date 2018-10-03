using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EPMLiveCore;
using EPMLiveEnterprise.WebSvcEvents;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PSLibrary = Microsoft.Office.Project.Server.Library;

namespace EPMLiveEnterprise.Layouts.epmlive
{
    public partial class econfig : LayoutsPageBase
    {
        protected DropDownList ddlAssignedToField;
        protected CheckBox chkLockSynch;
        protected CheckBox chkForceWS;
        protected Label lblError;
        protected ListBox lstAllTemplates;
        protected ListBox lstSelectedTemplates;
        protected Label lblProjectPublished;
        protected Label lblStatusingApplied;
        protected CheckBox chkCrossSite;
        protected TextBox txtDefaultURL;
        protected DropDownList ddlTimesheet;
        protected DropDownList ddlTimesheetHours;
        protected TextBox txtUrls;

        protected Label lblResCreated;
        protected Label lblResUpdated;
        protected Label lblResDeleted;

        protected void lnkSynchResources_Click(object sender, EventArgs e)
        {
            ResourceSyncher resSynch = new ResourceSyncher(SPContext.Current.Site.ID);
            resSynch.synchAllResources();
            resSynch.end();

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/econfig.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void lnkReactivate_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                var eventLog = default(EventLog);

                try
                {
                    eventLog = new EventLog("EPM Live", ".", "EPM Live Feature Activation");

                    var events = new Events()
                    {
                        Url = $"{SPContext.Current.Site.Url}/_vti_bin/psi/events.asmx",
                        UseDefaultCredentials = true
                    };

                    var handlerDataSet = events.ReadEventHandlerAssociations();

                    foreach (var definition in EventDefinition.AllDefinitions)
                    {
                        InstallEvent(events, handlerDataSet, definition.Value, eventLog);
                    }
                }
                catch (Exception ex)
                {
                    const int eventId = 650;

                    var logMessage = $"Error Installing Enterprise Event Handler:\r\n {ex.Message}{ex.StackTrace}{ex.InnerException}";
                    eventLog?.WriteEntry(logMessage, EventLogEntryType.Error, eventId);
                }
                finally
                {
                    eventLog?.Dispose();
                }
            });
        }

        private void InstallEvent(Events events, EventHandlersDataSet dataSet, EventDefinition definition, EventLog logger)
        {
            const string assemblyName = "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
            const int orderValue = 10;
            const int logEventId = 610;

            var query = $"EventId = {definition.EventId} and name = '{definition.Name}'";
            if (dataSet.EventHandlers.Select(query).Length <= 0)
            {
                var newDs = new EventHandlersDataSet();
                newDs.EventHandlers.AddEventHandlersRow(
                    definition.EventHandlerUid,
                    definition.Name,
                    assemblyName,
                    definition.ClassName,
                    definition.EventId,
                    string.Empty,
                    orderValue);

                events.CreateEventHandlerAssociations(newDs);

                var logMessage = $"Successfully started install of EPM Live {definition.LoggerDescription}";
                logger.WriteEntry(logMessage, EventLogEntryType.Information, logEventId);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadEnterpriseFields();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ArrayList arrDel = new ArrayList();
            foreach (ListItem li in lstAllTemplates.Items)
            {
                if (li.Selected)
                {
                    arrDel.Add(li);
                    lstSelectedTemplates.Items.Add(li);
                }
            }

            foreach (ListItem li in arrDel)
            {
                lstAllTemplates.Items.Remove(li);
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            ArrayList arrDel = new ArrayList();
            foreach (ListItem li in lstSelectedTemplates.Items)
            {
                if (li.Selected)
                {
                    arrDel.Add(li);
                    lstAllTemplates.Items.Add(li);
                }
            }

            foreach (ListItem li in arrDel)
            {
                lstSelectedTemplates.Items.Remove(li);
            }
        }

        private void loadTemplates(string validtemplates)
        {
            Hashtable hshTemplates = new Hashtable();
            SPWebTemplateCollection sptemps = SPContext.Current.Web.GetAvailableWebTemplates(SPContext.Current.Web.Language);

            SortedList sl = new SortedList();

            foreach (SPWebTemplate webTemplate in sptemps)
            {
                if (!webTemplate.IsHidden)
                    hshTemplates.Add(webTemplate.Title, webTemplate.Title);
            }

            using (SPWeb web = SPContext.Current.Web)
            {
                string[] templates = validtemplates.Split('|');
                foreach (string template in templates)
                {
                    if (hshTemplates.Contains(template))
                    {
                        lstSelectedTemplates.Items.Add(new ListItem(hshTemplates[template].ToString(), template));
                        hshTemplates.Remove(template);
                    }
                }
            }

            foreach (DictionaryEntry de in hshTemplates)
            {
                lstAllTemplates.Items.Add(new ListItem(de.Value.ToString(), de.Key.ToString()));
            }
        }

        private void loadEnterpriseFields()
        {
            Guid siteGuid = SPContext.Current.Site.ID;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = SPContext.Current.Site)
                {
                    try
                    {
                        WebSvcCustomFields.CustomFields cf = new WebSvcCustomFields.CustomFields();
                        cf.Url = SPContext.Current.Site.Url + "/_vti_bin/PSI/customfields.asmx";
                        cf.UseDefaultCredentials = true;

                        WebSvcCustomFields.CustomFieldDataSet dsF = cf.ReadCustomFieldsByEntity(new Guid(PSLibrary.EntityCollection.Entities.TaskEntity.UniqueId));

                        ddlAssignedToField.Items.Add(new ListItem("[Not Specified]", ""));
                        ddlTimesheet.Items.Add(new ListItem("[Select Field]", ""));
                        ddlTimesheetHours.Items.Add(new ListItem("[Select Field]", ""));

                        foreach (DataRow dr in dsF.Tables[0].Select("MD_PROP_TYPE_ENUM = 21"))
                        {
                            ListItem li = new ListItem(dr["MD_PROP_NAME"].ToString(), dr["MD_PROP_UID"].ToString());
                            ddlAssignedToField.Items.Add(li);
                        }

                        foreach (DataRow dr in dsF.Tables[0].Select("MD_PROP_TYPE_ENUM = 15"))
                        {
                            ListItem li = new ListItem(dr["MD_PROP_NAME"].ToString(), dr["MD_PROP_ID"].ToString());
                            ddlTimesheetHours.Items.Add(li);
                        }

                        foreach (DataRow dr in dsF.Tables[0].Select("MD_PROP_TYPE_ENUM = 17"))
                        {
                            ListItem li = new ListItem(dr["MD_PROP_NAME"].ToString(), dr["MD_PROP_UID"].ToString());
                            ddlTimesheet.Items.Add(li);
                        }

                        ddlTimesheetHours.Items.Add(new ListItem("Actual Work", "251658250"));

                        using (var connection = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
                        {
                            connection.Open();

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='AssignedToField'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ddlAssignedToField.SelectedValue = reader.GetString(0);
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='TimesheetField'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ddlTimesheet.SelectedValue = reader.GetString(0);
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='TimesheetHoursField'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ddlTimesheetHours.SelectedValue = reader.GetString(0);
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='LockSynch'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    chkLockSynch.Checked = bool.Parse(reader.GetString(0));
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='ForceWS'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    chkForceWS.Checked = bool.Parse(reader.GetString(0));
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='ValidTemplates'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    loadTemplates(reader.GetString(0));
                                }
                                else
                                {
                                    loadTemplates(string.Empty);
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='CrossSite'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    chkCrossSite.Checked = bool.Parse(reader.GetString(0));
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='DefaultURL'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txtDefaultURL.Text = reader.GetString(0);
                                }
                            }

                            using (var command = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='ConnectedURLs'", connection))
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    txtUrls.Text = reader.GetString(0);
                                }
                            }
                        }

                        lblError.Visible = false;

                        WebSvcEvents.Events events = new EPMLiveEnterprise.WebSvcEvents.Events();
                        events.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/events.asmx";
                        events.UseDefaultCredentials = true;

                        WebSvcEvents.EventHandlersDataSet ds = events.ReadEventHandlerAssociations();

                        if (ds.EventHandlers.Select("EventId = 53 and name = 'EPMLivePublisher'").Length <= 0)
                            lblProjectPublished.Text = "Not Installed";
                        else
                            lblProjectPublished.Text = "Installed";

                        if (ds.EventHandlers.Select("EventId = 133 and name = 'EPMLiveStatusing'").Length <= 0)
                            lblStatusingApplied.Text = "Not Installed";
                        else
                            lblStatusingApplied.Text = "Installed";

                        if (ds.EventHandlers.Select("EventId = 95 and name = 'EPMLiveResUpdated'").Length <= 0)
                            lblResUpdated.Text = "Not Installed";
                        else
                            lblResUpdated.Text = "Installed";

                        if (ds.EventHandlers.Select("EventId = 89 and name = 'EPMLiveResCreated'").Length <= 0)
                            lblResCreated.Text = "Not Installed";
                        else
                            lblResCreated.Text = "Installed";

                        if (ds.EventHandlers.Select("EventId = 92 and name = 'EPMLiveResDeleting'").Length <= 0)
                            lblResDeleted.Text = "Not Installed";
                        else
                            lblResDeleted.Text = "Installed";
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("401"))
                        {
                            lblError.Text = "Error: 401 Unauthorized<br>This usually means the service account that is current running your SharePoint Application Pool does not have access to the Project Server Site.";
                            lblError.Visible = true;
                        }
                        else
                        {
                            Response.Write("Error: " + ex.Message + "<br>Current User: " + HttpContext.Current.User.Identity.Name);
                        }
                    }
                }
            });
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                var connectionString = CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id);
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    setVal(connection, "AssignedToField", ddlAssignedToField.SelectedValue);
                    setVal(connection, "TimesheetField", ddlTimesheet.SelectedValue);
                    setVal(connection, "TimesheetHoursField", ddlTimesheetHours.SelectedValue);
                    setVal(connection, "LockSynch", chkLockSynch.Checked.ToString());
                    setVal(connection, "ForceWS", chkForceWS.Checked.ToString());
                    setVal(connection, "CrossSite", chkCrossSite.Checked.ToString());
                    setVal(connection, "DefaultURL", txtDefaultURL.Text);
                    setVal(connection, "ConnectedURLs", txtUrls.Text);

                    var templatesBuilder = new StringBuilder();
                    foreach (ListItem item in lstSelectedTemplates.Items)
                    {
                        if (templatesBuilder.Length > 0)
                        {
                            templatesBuilder.Append("|");
                        }

                        templatesBuilder.Append(item.Value);
                    }

                    setVal(connection, "ValidTemplates", templatesBuilder.ToString());
                }
            });
        }

        private void setVal(SqlConnection connection, string itemKey, string itemValue)
        {
            var updateExisting = false;
            var queryText = $"SELECT config_value FROM ECONFIG where config_name='{itemKey}'";

            using (var command = new SqlCommand(queryText, connection))
            using (var dataReader = command.ExecuteReader())
            {
                updateExisting = dataReader.Read();
            }

            var cmdText = updateExisting
                ? $"UPDATE ECONFIG set config_value = @val where config_name='{itemKey}'"
                : $"INSERT INTO ECONFIG (config_value,config_name) VALUES (@val,'{itemKey}')";

            using (var command = new SqlCommand(cmdText, connection))
            {
                command.Parameters.AddWithValue("@val", itemValue);
                command.ExecuteNonQuery();
            }
        }
    }
}
