using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Diagnostics;
using System.Collections;
using System.Data.SqlClient;

namespace EPMLiveCore
{
    public partial class adsyncadmin : LayoutsPageBase
    {
        protected Label lbl_domain;
        protected Label lblMessages;
        protected Label lblLastRun;
        protected ListBox lb_options;
        protected ListBox lb_selections;
        protected HiddenField selections;
        protected Panel pnl_fieldMappings;
        protected Table tbl_fieldMappings;
        protected HtmlTextArea txtArea_entityExclusions;
        protected Button btnRunManually;

        protected CheckBoxList CheckBoxList_days;
        protected CheckBox cbDelete;
        protected InputFormControl FrequencyOptions;

        protected DropDownList FixTimes;
        protected DropDownList DropDownListScheduleType;
        protected DropDownList DropDownListDays;
        protected DropDownList DropDownListTime;

        string[] _adSavedGroups;
        string _domain;

        List<string> _resourcePoolFields = new List<string>();
        List<string> _adFields = null;
        List<string> _groups = new List<string>();
        List<string> _ExecutionLogs = new List<string>();
        List<string> _SavedFieldMappings = new List<string>();

        ADSync _ADSync;
        Hashtable _htDropdownIds;
        Hashtable _SavedFieldMappingValues = new Hashtable();

        protected void Page_Init(object sender, EventArgs e)
        {
            Act act = new Act(Web);
            if(act.IsOnline)
            {
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/noaccess.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            else
            {

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    _ADSync = new ADSync();
                    _htDropdownIds = new Hashtable();
                    DropDownListScheduleType.SelectedIndexChanged += new EventHandler(DropDownListScheduleType_SelectedIndexChanged);

                    InitDomain();
                    InitGroups();
                    InitActiveDirectorySizeLimitTextBox();
                    InitResourcePoolFields();
                    InitSchedule();
                    InitExclusions();
                    InitDelete();
                    LoadScheduleStatus();
                });
            }
        }

        protected void btnRunManually_Click(object sender, EventArgs e)
        {
            int iTime;
            string sTime = DropDownListTime.SelectedValue;
            string days = GetOptions();
            iTime = 0;
            if (sTime != string.Empty)
            {
                iTime = int.Parse(sTime);
            }

            _ADSync.AddTimerJob(SPContext.Current.Site.RootWeb, iTime, 2, GetOptions(), true);
            string redirectURL = SPContext.Current.Site.ServerRelativeUrl;
            if (!redirectURL.EndsWith("/"))
            {
                redirectURL = redirectURL + "/";
            }
            redirectURL = redirectURL + "_layouts/epmlive/adsyncadmin.aspx";
            Response.Redirect(redirectURL);
        }

        protected void LoadScheduleStatus()
        {
            //if (!IsPostBack)
            {
                try
                {
                    SPSite site = SPContext.Current.Site;
                    {
                        SPWeb web = SPContext.Current.Web;
                        {
                            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(site.WebApplication.Id));
                            SPSecurity.RunWithElevatedPrivileges(delegate()
                            {
                                cn.Open();
                            });
                            SqlCommand cmd = new SqlCommand("select timerjobuid,runtime,percentComplete,status,dtfinished,result from vwQueueTimerLog where siteguid=@siteguid and listguid is null and jobtype=8", cn);
                            cmd.Parameters.AddWithValue("@siteguid", site.ID);
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                if (!dr.IsDBNull(1))
                                {
                                    DropDownListTime.SelectedValue = dr.GetInt32(1).ToString();
                                }
                                btnRunManually.Enabled = true;
                                if (!dr.IsDBNull(3))
                                {
                                    if (dr.GetInt32(3) == 0)
                                    {
                                        lblMessages.Text = "Queued";
                                        btnRunManually.Enabled = false;
                                    }
                                    else if (dr.GetInt32(3) == 1)
                                    {
                                        lblMessages.Text = "Processing (" + dr.GetInt32(2).ToString("##0") + "%)";
                                        btnRunManually.Enabled = false;
                                    }
                                    else if (!dr.IsDBNull(5))
                                    {
                                        lblMessages.Text = dr.GetString(5);
                                    }
                                    else
                                    {
                                        lblMessages.Text = "No Results";
                                    }
                                }

                                if (!dr.IsDBNull(4))
                                    lblLastRun.Text = dr.GetDateTime(4).ToString();
                            }
                            dr.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        if (!EventLog.SourceExists("EPMLive AD Sync - Page_Load"))
                            EventLog.CreateEventSource("EPMLive AD Sync  - Page_Load", "EPM Live");

                        EventLog myLog = new EventLog("EPM Live", ".", "EPMLive AD Sync Page_Load");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 2040);
                    });
                }

            }
        }

        protected void InitExclusions()
        {
            string savedExclusions = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadexclusionsByCN");
            if (savedExclusions != null && savedExclusions != string.Empty)
            {
                txtArea_entityExclusions.Value = savedExclusions;
            }
        }

        protected void InitDelete()
        {
            string savedDelete = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEaddelete");
            if (savedDelete != null && savedDelete != string.Empty)
            {
                cbDelete.Checked = bool.Parse(savedDelete);
            }
        }

        protected void SaveAll()
        {
            string groups = string.Empty;
            string fieldMappings = string.Empty;
            string schedule = string.Empty;
            string entityExclusions = string.Empty;
            string days = GetOptions();
            string delete = string.Empty;
            string sTime = DropDownListTime.SelectedValue;

            int iScheduleType;
            int iTime;


            iTime = 0;
            if (sTime != string.Empty)
            {
                iTime = int.Parse(sTime);
            }
            iScheduleType = int.Parse(DropDownListScheduleType.SelectedValue);

            groups = GetGroups();
            fieldMappings = GetFieldMappings();
            entityExclusions = GetEntityExclusions();
            delete = GetDelete();
            var sizeLimit = GetActiveDirectorySizeLimit();

            if (FinalizeSave(groups, fieldMappings, entityExclusions, delete, days, iScheduleType, iTime, sizeLimit))
            {
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

        protected bool FinalizeSave(string groups, string fieldmappings, string entityExclusions, string delete, string days, int scheduleType, int time, int sizeLimit)
        {
            SPSite site = SPContext.Current.Site;
            using(SPWeb web = site.OpenWeb(site.RootWeb.ID))
            {
                CoreFunctions.setConfigSetting(web, "EPMLIVEadgroups", groups);
                CoreFunctions.setConfigSetting(web, "EPMLIVEadfields", fieldmappings);
                CoreFunctions.setConfigSetting(web, "EPMLIVEadexclusions", entityExclusions);
                CoreFunctions.setConfigSetting(web, "EPMLIVEaddelete", delete);
                CoreFunctions.setConfigSetting(web, "EPMLIVEadscheduledays", days);
                CoreFunctions.setConfigSetting(web, "EPMLIVEadscheduletype", scheduleType.ToString());
                CoreFunctions.setConfigSetting(web, "EPMLIVEadscheduletime", time.ToString());
                CoreFunctions.setConfigSetting(web, "EPMLIVEadSizeLimit", sizeLimit.ToString());

                return SaveJob(time, scheduleType, days);
            }
        }

        protected string GetGroups()
        {
            string groups = string.Empty;
            if (!string.IsNullOrEmpty(selections.Value))
            {
                groups = selections.Value;
            }
            return groups;
        }

        protected string GetFieldMappings()
        {
            string fieldMappings = string.Empty;
            int i = 0;
            foreach (string resField in _resourcePoolFields)
            {
                DropDownList ddl = (DropDownList)_htDropdownIds[resField];
                string val = Request.Form[ddl.UniqueID];
                if (val != string.Empty)
                {
                    if (resField.ToLower() == "title")
                    {
                        fieldMappings = fieldMappings + "|" + resField + ";" + "displayname";
                    }
                    else if (resField.ToLower() == "sharepointaccount")
                    {
                        fieldMappings = fieldMappings + "|" + resField + ";" + "samaccountname";
                    }
                    else
                    {
                        fieldMappings = fieldMappings + "|" + resField + ";" + val;
                    }
                }
                i++;
            }
            return fieldMappings;
        }

        protected bool SaveJob(int time, int scheduleType, string days)
        {
            return _ADSync.AddTimerJob(SPContext.Current.Site.RootWeb, time, scheduleType, days, false);
        }

        protected string GetEntityExclusions()
        {
            string exclusions = string.Empty;
            string[] tmp;
            if (txtArea_entityExclusions.Value.Contains(";"))
            {
                tmp = txtArea_entityExclusions.Value.Split(";".ToCharArray()[0]);
            }
            else
            {
                tmp = new string[1];
                tmp[0] = txtArea_entityExclusions.Value;
            }
            foreach (string cn in tmp)
            {
                string sid = _ADSync.GetUserSIDByCN(cn, _domain);
                if (sid != string.Empty)
                {
                    exclusions = exclusions + sid + ";";
                }
                else
                {
                    _ExecutionLogs.Add("     INFO -- Unable to locate SID for:" + cn + " -- AD Path: LDAP://CN=" + cn + ",CN=Users," + _domain);
                }
            }
            //Save CN's for use in InitExclusions()
            EPMLiveCore.CoreFunctions.setConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadexclusionsByCN", txtArea_entityExclusions.Value);
            return exclusions;
        }

        protected string GetDelete()
        {
            if (cbDelete.Checked)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        protected string GetOptions()
        {
            string sOptions = string.Empty;
            if (DropDownListScheduleType.SelectedValue == "2")
            {
                foreach (ListItem item in CheckBoxList_days.Items)
                {
                    if (item.Selected)
                    {
                        sOptions = sOptions + item.Value + ",";
                    }
                }

                if (sOptions.EndsWith(","))
                {
                    sOptions = sOptions.Remove(sOptions.LastIndexOf(","));
                }
            }
            else
            {
                foreach (ListItem item in CheckBoxList_days.Items)
                {
                    sOptions = DropDownListDays.SelectedValue;
                }
            }
            return sOptions;
        }

        protected void InitDomain()
        {
            _domain = _ADSync.GetFullDomain();
            lbl_domain.Text = _domain;
        }

        protected void InitSchedule()
        {
            string sDays = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadscheduledays");
            string type = string.Empty;
            string time = string.Empty;
            if (sDays != null && sDays != string.Empty)
            {
                //Init. scheduletype 
                type = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadscheduletype");
                DropDownListScheduleType.SelectedValue = type;

                //Init. scheduletime
                time = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadscheduletime");
                DropDownListTime.SelectedValue = time;

                //Init. days
                char[] splitter = ",".ToCharArray();
                Array sOptions = sDays.Split(splitter[0]);
                foreach (string day in sOptions)
                {
                    foreach (ListItem item in CheckBoxList_days.Items)
                    {
                        if (item.Value == day)
                        {
                            item.Selected = true;
                        }
                    }
                }
            }



        }

        protected void InitResourcePoolFields()
        {
            string resWebUrl = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveResourceURL", true, true);
            string savedFieldMappings = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadfields");
            SPList list = null;
            
            using(SPWeb rWeb = SPContext.Current.Site.RootWeb.Site.AllWebs[resWebUrl])
            {
                list = rWeb.Lists["Resources"];
            }

            //Clearout any existing fields
            tbl_fieldMappings.Rows.Clear();

            //Check for saved fieldmappings
            if (savedFieldMappings != null || savedFieldMappings != string.Empty)
            {
                InitSavedFieldMappings(savedFieldMappings);
            }

            foreach (SPField field in list.Fields)
            {
                if (field.Type == SPFieldType.Text || field.Type == SPFieldType.Choice || field.InternalName.ToLower() == "sharepointaccount")
                {
                    if (!field.Hidden && field.InternalName.ToLower() != "sid" && !field.ReadOnlyField && !field.Sealed)
                    {
                        _resourcePoolFields.Add(field.InternalName);
                        InitResourceField(field.InternalName);
                    }
                }
            }
        }

        protected void InitSavedFieldMappings(string fieldmappings)
        {
            string[] adFieldMappings = fieldmappings.Split("|".ToCharArray()[0]);
            foreach (string field in adFieldMappings)
            {
                string[] keyValue = field.Split(";".ToCharArray()[0]);
                if (keyValue.Length > 1 && !_SavedFieldMappingValues.Contains(keyValue[0]))
                {
                    _SavedFieldMappingValues.Add(keyValue[0], keyValue[1]);
                    _SavedFieldMappings.Add(keyValue[0]);
                }
                else if (keyValue.Length > 1)
                {
                    _ExecutionLogs.Add(keyValue[0] + " is already mapped.");
                }
            }
        }

        protected void InitResourceField(string fieldname)
        {
            TableRow row = new TableRow();
            Label lbl = new Label();
            TableCell cell = new TableCell();
            TableCell cell2 = new TableCell();
            DropDownList ddl = ADFields(fieldname);
            _htDropdownIds.Add(fieldname, ddl);

            lbl.Text = fieldname;
            lbl.CssClass = "ms-authoringcontrols";

            cell.Controls.Add(lbl);
            cell2.Controls.Add(ddl);

            row.Cells.Add(cell);
            row.Cells.Add(cell2);
            tbl_fieldMappings.Rows.Add(row);
        }

        protected DropDownList ADFields(string fieldname)
        {
            DropDownList ddl = new DropDownList();
            ListItem[] adFields = null;
            ddl.ID = "ddl" + fieldname.Trim();

            try
            {
                if (_adFields == null)
                {
                    _adFields = _ADSync.GetADGroupUserAttributes(_domain, _groups[0]);
                }

                adFields = new ListItem[_adFields.Count + 1];
                int i = 1;
                adFields[0] = new ListItem();
                foreach (string adField in _adFields)
                {
                    ListItem li = new ListItem();
                    li.Text = adField;
                    li.Value = adField;
                    adFields[i] = li;
                    i++;
                }

                ddl.Items.AddRange(adFields);
                switch (fieldname.ToLower())
                {
                    case "title":
                        ddl.SelectedValue = "displayName";
                        ddl.Enabled = false;
                        break;

                    case "sharepointaccount":
                        ddl.SelectedValue = "sAMAccountName";
                        ddl.Enabled = false;
                        break;

                    default:
                        ddl.SelectedIndex = 0;
                        break;
                }

                if (_SavedFieldMappings != null && _SavedFieldMappings.Count > 0 && _SavedFieldMappings.Contains(fieldname))
                {
                    ddl.SelectedValue = _SavedFieldMappingValues[fieldname].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            return ddl;
        }

        protected void InitGroups()
        {
            string path = "LDAP://" + _domain;
            _groups = _ADSync.GetGroups(path);
            lb_options.Items.Clear();
            lb_selections.Items.Clear();
            int index = 0;

            //Init. Group selections IF previously saved.
            string savedGroups = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadgroups");
            if (savedGroups != null && savedGroups != string.Empty)
            {
                _adSavedGroups = savedGroups.Split("|".ToCharArray()[0]);
            }


            SortedList sl = new SortedList();
            //Init. Group options listbox
            foreach (string group in _groups)
            {
                sl.Add(group, index.ToString());
                
                index++;
            }

            foreach (DictionaryEntry de in sl)
            {
                ListItem item = new ListItem();
                item.Text = de.Key.ToString();
                item.Value = de.Value.ToString();
                lb_options.Items.Add(item);
            }

            //Populate previously selected groups IF ANY are present
            if (_adSavedGroups != null && _adSavedGroups.Length > 0)
            {
                foreach (string sgroup in _adSavedGroups)
                {
                    if (sgroup != string.Empty)
                    {
                        try
                        {
                            ListItem item = new ListItem();
                            item.Text = sgroup;
                            item.Value = lb_options.Items.FindByText(sgroup).Value;
                            lb_selections.Items.Add(item);
                            lb_options.Items.Remove(lb_options.Items.FindByText(sgroup));
                        }
                        catch (Exception ex)
                        {
                            _ExecutionLogs.Add("     INFO -- Group: " + sgroup + " has been renamed or deleted.");
                        }
                    }
                }
            }
        }

        void DropDownListScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListScheduleType.SelectedValue == "3")
            {
                DropDownListDays.Visible = true;
                CheckBoxList_days.Visible = false;
                FrequencyOptions.LabelText = "Day of Month";
            }
            else
            {
                DropDownListDays.Visible = false;
                CheckBoxList_days.Visible = true;
                FrequencyOptions.LabelText = "Day(s) of Week";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SaveAll();

            
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _ADSync = null;
        }

        private void InitActiveDirectorySizeLimitTextBox()
        {
            var savedSizeLimit = CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLIVEadSizeLimit");

            if (string.IsNullOrEmpty(savedSizeLimit))
            {
                savedSizeLimit = "5000";
            }

            SizeLimitTextBox.Text = savedSizeLimit;
        }

        private int GetActiveDirectorySizeLimit()
        {
            int returnValue;

            try
            {
                returnValue = int.Parse(SizeLimitTextBox.Text);
            }
            catch (Exception)
            {
                returnValue = 0;
            }

            return returnValue;
        }
    }
}
