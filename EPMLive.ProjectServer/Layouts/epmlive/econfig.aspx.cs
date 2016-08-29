using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PSLibrary = Microsoft.Office.Project.Server.Library;
using System.Data.SqlClient;
using System.Diagnostics;

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

                EventLog myLog = new EventLog("EPM Live", ".", "EPM Live Feature Activation");
                //myLog.MaximumKilobytes = 32768;

                try
                {
                    WebSvcEvents.Events events = new EPMLiveEnterprise.WebSvcEvents.Events();
                    events.Url = SPContext.Current.Site.Url + "/_vti_bin/psi/events.asmx";
                    events.UseDefaultCredentials = true;

                    WebSvcEvents.EventHandlersDataSet ds = events.ReadEventHandlerAssociations();

                    //========================Publish=========================
                    if (ds.EventHandlers.Select("EventId = 53 and name = 'EPMLivePublisher'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("73DBE692-F21D-4129-8E2B-8B1ED4FA00F5"), "EPMLivePublisher", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.OnPublish", 53, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Publishing EventHandler (Project.Published)", EventLogEntryType.Information, 610);
                    }
                    //========================Statusing=========================
                    if (ds.EventHandlers.Select("EventId = 133 and name = 'EPMLiveStatusing'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("8BBBBC25-7E9D-440b-BE1C-78ED667D5D0B"), "EPMLiveStatusing", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.Status", 133, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Statusing EventHandler (Statusing.Applied)", EventLogEntryType.Information, 610);
                    }
                    //========================Resource Changed=========================
                    if (ds.EventHandlers.Select("EventId = 95 and name = 'EPMLiveResUpdated'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("B0C1D09C-F1F6-4a6b-858C-529E22B7688C"), "EPMLiveResUpdated", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 95, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Updated)", EventLogEntryType.Information, 610);
                    }
                    //========================Resource Added=========================
                    if (ds.EventHandlers.Select("EventId = 89 and name = 'EPMLiveResCreated'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("286DE0F8-2042-4c8b-A8F7-3E276150CD9C"), "EPMLiveResCreated", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 89, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Created)", EventLogEntryType.Information, 610);
                    }
                    ////========================Resource Deleted=========================
                    if (ds.EventHandlers.Select("EventId = 92 and name = 'EPMLiveResDeleting'").Length <= 0)
                    {
                        WebSvcEvents.EventHandlersDataSet newDs = new EPMLiveEnterprise.WebSvcEvents.EventHandlersDataSet();
                        newDs.EventHandlers.AddEventHandlersRow(new Guid("074BCE6F-CF3B-4a94-BCC4-A262B32AE41E"), "EPMLiveResDeleting", "EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5", "EPMLiveEnterprise.ResourceEvents", 92, "", 10);
                        events.CreateEventHandlerAssociations(newDs);
                        myLog.WriteEntry("Successfully started install of EPM Live Resource EventHandler (Resource.Deleting)", EventLogEntryType.Information, 610);
                    }
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry("Error Installing Enterprise Event Handler:\r\n " + ex.Message + ex.StackTrace + ex.InnerException, EventLogEntryType.Error, 650);
                }
            });
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

                        //SqlConnection cn = new SqlConnection(EPMLiveHelperClasses.getEPMLiveConnectionString(siteGuid));
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='AssignedToField'", cn);
                        SqlDataReader dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            ddlAssignedToField.SelectedValue = dReader.GetString(0);
                        }
                        dReader.Close();

                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='TimesheetField'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            ddlTimesheet.SelectedValue = dReader.GetString(0);
                        }
                        dReader.Close();

                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='TimesheetHoursField'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            ddlTimesheetHours.SelectedValue = dReader.GetString(0);
                        }
                        dReader.Close();

                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='LockSynch'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            chkLockSynch.Checked = bool.Parse(dReader.GetString(0));
                        }
                        dReader.Close();

                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='ForceWS'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            chkForceWS.Checked = bool.Parse(dReader.GetString(0));
                        }
                        dReader.Close();


                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='ValidTemplates'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            loadTemplates(dReader.GetString(0));
                        }
                        else
                            loadTemplates("");
                        dReader.Close();

                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='CrossSite'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            chkCrossSite.Checked = bool.Parse(dReader.GetString(0));
                        }
                        dReader.Close();


                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='DefaultURL'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            txtDefaultURL.Text = dReader.GetString(0);
                        }
                        dReader.Close();

                        cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='ConnectedURLs'", cn);
                        dReader = cmd.ExecuteReader();
                        if (dReader.Read())
                        {
                            txtUrls.Text = dReader.GetString(0);
                        }
                        dReader.Close();

                        cn.Close();
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
                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(SPContext.Current.Site.WebApplication.Id));
                cn.Open();

                setVal(cn, "AssignedToField", ddlAssignedToField.SelectedValue);
                setVal(cn, "TimesheetField", ddlTimesheet.SelectedValue);
                setVal(cn, "TimesheetHoursField", ddlTimesheetHours.SelectedValue);
                setVal(cn, "LockSynch", chkLockSynch.Checked.ToString());
                setVal(cn, "ForceWS", chkForceWS.Checked.ToString());
                setVal(cn, "CrossSite", chkCrossSite.Checked.ToString());
                setVal(cn, "DefaultURL", txtDefaultURL.Text);
                setVal(cn, "ConnectedURLs", txtUrls.Text);

                string validtemplates = "";

                foreach (ListItem li in lstSelectedTemplates.Items)
                {
                    validtemplates += "|" + li.Value;
                }
                if (validtemplates.Length > 1)
                    validtemplates = validtemplates.Substring(1);

                setVal(cn, "ValidTemplates", validtemplates);


                cn.Close();
            });
        }

        private void setVal(SqlConnection cn, string key, string val)
        {
            SqlCommand cmd = new SqlCommand("SELECT config_value FROM ECONFIG where config_name='" + key + "'", cn);
            SqlDataReader dReader = cmd.ExecuteReader();
            if (dReader.Read())
            {
                dReader.Close();
                cmd = new SqlCommand("UPDATE ECONFIG set config_value = @val where config_name='" + key + "'", cn);
                cmd.Parameters.AddWithValue("@val", val);
                cmd.ExecuteNonQuery();
            }
            else
            {
                dReader.Close();
                cmd = new SqlCommand("INSERT INTO ECONFIG (config_value,config_name) VALUES (@val,'" + key + "')", cn);
                cmd.Parameters.AddWithValue("@val", val);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
