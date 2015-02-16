using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.SPFields
{
    [Guid("784A776A-5032-4D1B-AE14-D72DFC63CF26")]
    public class DaysHoursBreakdownFieldControl : BaseFieldControl
    {
        #region Fields (10) 

        /// <summary>
        /// The uncompressed version of this javascript can be found in DaysHoursBreakdownFieldControl.ascx (commented)
        /// </summary>
        private const string DAYS_HOURS_BREAKDOWN_SCRIPT =
            @"(function(){$(function(){function f(){var a=[],c=[];b.each(function(){a.push(parseFloat($(this).val()));c.push($(this).attr(""dhbdate"")+"":""+parseFloat($(this).val()))});d.val(eval(a.join(""+"")));$(""input[title=DaysHoursBreakdownValue]"").first().val(c.join("",""))}var h=$(""input[title=DaysHoursBreakdownInfo]"").first().val().split(""|""),d=$(""input[id$=NumberField][title=""+h[2]+""]"").first(),b=$(""input[dhbcontrol=true]"");$(""input[title=DaysHoursBreakdownPostBackMarker]"").first().val(""false"");$(""input[title=DaysHoursBreakdownFirstLoad]"").first().val(""false"");b.each(function(){$(this).change(function(){var a=!1,c=$(this).data(""oldVal""),b=$(this).val(),e=parseFloat(b),g=parseFloat($(this).attr(""dhbmaxhours"")),d=$(this).attr(""title"");e?0>e?(alert(""Hours cannot be less than 0.""),a=!0):e>g&&(alert(""The maximum working hours defined in the Work Hours list for ""+d+"" are: ""+g+"".""),a=!0):(alert(b+"" is not a valid number.""),a=!0);a?$(this).val(c):($(this).data(""oldVal"",$(this).val()),f())}).focus(function(){$(this).data(""oldVal"",$(this).val())})});f()})})();";

        private TextBox _finishDateTextBox;
        private TextBox _firstLoadTextBox;
        private Dictionary<string, string> _holidayDictionary;
        private TextBox _postBackMarkerTextBox;
        private Dictionary<string, decimal> _previousHours;
        private SPGridView _spGridView;
        private TextBox _startDateTextBox;
        private TextBox _valueTextBox;
        private Dictionary<string, decimal> _workHoursDictionary;

        #endregion Fields 

        #region Properties (1) 

        /// <summary>
        /// Gets the name of the default rendering template.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> object that names a rendering template. </returns>
        protected override string DefaultTemplateName
        {
            get { return "DaysHoursBreakdownFieldControl"; }
        }

        #endregion Properties 

        #region Methods (12) 

        // Public Methods (1) 

        /// <summary>
        /// Updates the underlying value of the field to the latest user-set value.
        /// </summary>
        public override void UpdateFieldValueInItem()
        {
            string callBackId = HttpContext.Current.Request.Form.Get("__CALLBACKID");

            if (!string.IsNullOrEmpty(callBackId) && callBackId.EndsWith("UserField")) return;

            var dhbField = Field as DaysHoursBreakdownField;

            if (dhbField == null) return;

            if (!_postBackMarkerTextBox.Text.Equals("false")) return;

            string[] hours = _valueTextBox.Text.Split(',').Select(hour => hour.Split(':')[1]).ToArray();

            ListItem[dhbField.HoursField] = hours.Sum(hour => Convert.ToDecimal(hour));

            ItemFieldValue = string.Join(",", hours);
        }

        // Protected Methods (1) 

        /// <summary>
        /// Creates any child controls necessary to render the field, such as a label control, link control, or text box control.
        /// </summary>
        protected override void CreateChildControls()
        {
            if (ControlMode == SPControlMode.Display) return;

            if (Field == null) return;

            var dhbField = Field as DaysHoursBreakdownField;

            if (dhbField == null) return;

            base.CreateChildControls();

            var gridPanel = (Panel) TemplateContainer.FindControl("DaysHoursBreakdownGridPanel");
            var gridErrorPanel = (Panel) TemplateContainer.FindControl("DaysHoursBreakdownErrorPanel");
            var errorLabel = (Label) TemplateContainer.FindControl("DaysHoursBreakdownGridErrorLabel");
            var errorTextBox = (TextBox) TemplateContainer.FindControl("DaysHoursBreakdownErrorTextBox");

            gridPanel.Visible = true;
            gridErrorPanel.Visible = false;
            errorLabel.Text = string.Empty;
            errorTextBox.Text = string.Empty;

            try
            {
                LoadBlockedDays(dhbField);

                var infoTextBox = (TextBox) TemplateContainer.FindControl("DaysHoursBreakdownInfoTextBox");

                infoTextBox.Text = string.Format("{0}|{1}|{2}",
                                                 Fields.GetFieldByInternalName(dhbField.StartDateField).Title,
                                                 Fields.GetFieldByInternalName(dhbField.FinishDateField).Title,
                                                 Fields.GetFieldByInternalName(dhbField.HoursField).Title);

                InitializeControls();

                string datePattern = GetDatePattern();

                if (ControlMode == SPControlMode.Edit)
                {
                    SPListItem spListItem = SPContext.Current.ListItem;

                    try
                    {
                        _startDateTextBox.Text = ((DateTime) spListItem[dhbField.StartDateField]).ToString(datePattern);
                        _finishDateTextBox.Text = ((DateTime) spListItem[dhbField.FinishDateField]).ToString(datePattern);
                    }
                    catch
                    {
                    }
                }

                _previousHours = new Dictionary<string, decimal>();

                FillGridView(datePattern);
            }
            //EPML-3726 : If user doesn't have permission then argumentexception thrown, so handle it and display appropriate error message as suggested in Jira Item.
            catch (ArgumentException ex)
            {
                gridPanel.Visible = false;
                gridErrorPanel.Visible = true;
                errorLabel.Text = string.Format("<b>Error: </b>You do not have permission to read required information from the resource pool. You must have at least read-only access to the resource pool in order to enter Time Off. Please contact your system administrator to have your permissions adjusted.");
                errorTextBox.Text = "You dont have permisions to the resource pool. Please contact your administrator.";
            }
            catch (Exception exception)
            {
                gridPanel.Visible = false;
                gridErrorPanel.Visible = true;
                errorLabel.Text = string.Format("<b>Error: </b>{0}", exception.Message);
                errorTextBox.Text = exception.Message;
            }
        }

        // Private Methods (10) 

        /// <summary>
        /// Dates the changed.
        /// </summary>
        private void DateChanged()
        {
            string value = _valueTextBox.Text;

            if (!string.IsNullOrEmpty(value))
            {
                _previousHours = value.Split(',').Select(hour => hour.Split(':'))
                    .ToDictionary(h => h[0], h => Convert.ToDecimal(h[1]));
            }

            FillGridView(GetDatePattern());
        }

        /// <summary>
        /// Fills the grid view.
        /// </summary>
        /// <param name="datePattern">The date pattern.</param>
        private void FillGridView(string datePattern)
        {
            var dataTable = new DataTable("DaysHoursBreakdown");

            _spGridView.Columns.Clear();

            string startDateValue = _startDateTextBox.Text;

            if (!string.IsNullOrEmpty(startDateValue))
            {
                string finishDateValue = _finishDateTextBox.Text;

                if (!string.IsNullOrEmpty(finishDateValue))
                {
                    DateTime startDate = DateTime.ParseExact(startDateValue, datePattern, null);
                    DateTime finishDate = DateTime.ParseExact(finishDateValue, datePattern, null);

                    if (finishDate.Date < startDate.Date)
                    {
                        throw new Exception("The finish date cannot be smaller than the start date.");
                    }

                    DataRow dataRow = dataTable.NewRow();

                    bool validDatesSelected = false;

                    var currentHours = new string[] {};

                    if (ItemFieldValue != null)
                    {
                        currentHours = ((string) ItemFieldValue).Split(',');
                    }

                    int index = 0;

                    for (DateTime dateTime = startDate; dateTime <= finishDate; dateTime = dateTime.AddDays(1))
                    {
                        string columnName = dateTime.ToString("yyyyMMdd");

                        decimal hours;

                        if (ControlMode == SPControlMode.Edit && _firstLoadTextBox.Text.Equals(string.Empty) &&
                            currentHours.Any())
                        {
                            hours = Convert.ToDecimal(currentHours[index]);
                        }
                        else
                        {
                            hours = _workHoursDictionary[dateTime.ToString("dddd", new CultureInfo("en-US"))];

                            if (_holidayDictionary.ContainsKey(columnName)) hours = 0;

                            if (_previousHours.ContainsKey(columnName)) hours = _previousHours[columnName];
                        }

                        dataTable.Columns.Add(columnName);
                        dataRow[columnName] = hours.ToString(CultureInfo.InvariantCulture);

                        validDatesSelected = true;

                        index++;
                    }

                    if (validDatesSelected) dataTable.Rows.Add(dataRow);
                }
            }

            DataRow gvRow = null;

            if (dataTable.Rows.Count > 0) gvRow = dataTable.Rows[0];

            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                string columnName = dataColumn.ColumnName;
                DateTime dateTime = DateTime.ParseExact(columnName, "yyyyMMdd", CultureInfo.InvariantCulture);
                string day = dateTime.ToString("dddd", new CultureInfo("en-US"));
                string title = day;
                decimal hours = 8;

                if (gvRow != null) hours = Convert.ToDecimal(gvRow[columnName]);

                if (_holidayDictionary.ContainsKey(columnName)) title = _holidayDictionary[columnName];

                var templateField = new TemplateField
                                        {
                                            HeaderText = dateTime.ToString("M/d"),
                                            ItemTemplate =
                                                new ItemTemplate(columnName, title, _workHoursDictionary[day],
                                                                 hours == 0)
                                        };

                templateField.HeaderStyle.Width = 40;
                _spGridView.Columns.Add(templateField);
            }


            _spGridView.DataSource = dataTable;
            _spGridView.DataBind();

            if (gvRow == null) return;

            _spGridView.Width = _spGridView.HeaderRow.Cells.Count*42;
        }

        /// <summary>
        /// Finishes the date text box text changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FinishDateTextBoxTextChanged(object sender, EventArgs e)
        {
            var errorPanel = TemplateContainer.FindControl("DHBErrorPanel");
            var erroLabel = ((Label) TemplateContainer.FindControl("DHBErrorLabel"));

            try
            {
                errorPanel.Visible = false;
                erroLabel.Text = string.Empty;

                _finishDateTextBox.Text = ((TextBox) sender).Text;
                DateChanged();
            }
            catch (Exception exception)
            {
                errorPanel.Visible = true;
                erroLabel.Text = string.Format("<b>Error: </b>{0}", exception.Message);
            }
        }

        /// <summary>
        /// Gets the date pattern.
        /// </summary>
        /// <returns></returns>
        private string GetDatePattern()
        {
            SPWeb spWeb = SPContext.Current.Web;

            SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ?? spWeb.RegionalSettings;
            var cultureInfo = new CultureInfo((int) spRegionalSettings.LocaleId);

            return cultureInfo.DateTimeFormat.ShortDatePattern.Replace('-', '/').Replace('.', '/');
        }

        /// <summary>
        /// Gets the holidays.
        /// </summary>
        /// <param name="holidaysList">The holidays list.</param>
        /// <param name="resourceListItem">The resource list item.</param>
        private void GetHolidays(SPList holidaysList, SPListItem resourceListItem)
        {
            int holidayScheduleId = new SPFieldLookupValue((string) resourceListItem["HolidaySchedule"]).LookupId;

            foreach (SPListItem holidayListItem in holidaysList.Items)
            {
                if (new SPFieldLookupValue((string) holidayListItem["HolidaySchedule"]).LookupId !=
                    holidayScheduleId) continue;

                var dateTime = (DateTime) holidayListItem["Date"];

                string key = dateTime.ToString("M/d/yyyy");

                if (!_holidayDictionary.ContainsKey(key))
                    _holidayDictionary.Add(key, (string) holidayListItem["Title"]);
            }
        }

        /// <summary>
        /// Gets the required lists.
        /// </summary>
        /// <param name="spListCollection">The sp list collection.</param>
        /// <param name="dhbField">The DHB field.</param>
        /// <param name="holidaysList">The holidays list.</param>
        /// <param name="holidaySchedulesList">The holiday schedules list.</param>
        /// <param name="resourcesList">The resources list.</param>
        /// <param name="workHoursList">The work hours list.</param>
        private static void GetRequiredLists(SPListCollection spListCollection, DaysHoursBreakdownField dhbField,
                                             out SPList holidaysList, out SPList holidaySchedulesList,
                                             out SPList resourcesList, out SPList workHoursList)
        {
            holidaySchedulesList = null;

            resourcesList = spListCollection[dhbField.ResourcePoolList];

            if (resourcesList == null) throw new Exception("Cannot find the Resources list.");

            workHoursList = spListCollection[dhbField.WorkHoursList];

            if (workHoursList == null) throw new Exception("Cannot find the WorkHours list.");

            holidaysList = spListCollection[dhbField.HolidaysList];

            if (holidaysList == null) throw new Exception("Cannot find the Holidays list.");

            SPField holidaySchedulesField = holidaysList.Fields.GetFieldByInternalName(dhbField.HolidaySchedulesField);

            if (holidaySchedulesField != null)
            {
                holidaySchedulesList =
                    spListCollection.GetList(new Guid(((SPFieldLookup) holidaySchedulesField).LookupList), false);
            }

            if (holidaySchedulesList == null) throw new Exception("Cannot find the Holiday Schedules list.");
        }

        /// <summary>
        /// Gets the work hours.
        /// </summary>
        /// <param name="workHoursList">The work hours list.</param>
        /// <param name="resourceListItem">The resource list item.</param>
        /// <param name="spWeb">The sp web.</param>
        private void GetWorkHours(SPList workHoursList, SPListItem resourceListItem, SPWeb spWeb)
        {
            var workHoursLookupValue = new SPFieldLookupValue((string) resourceListItem["WorkHours"]);

            foreach (SPListItem workHourlistItem in workHoursList.Items.Cast<SPListItem>()
                .Where(workHourlistItem => workHourlistItem.ID == workHoursLookupValue.LookupId))
            {
                foreach (
                    string day in new[] {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
                {
                    _workHoursDictionary.Add(day, Convert.ToDecimal(workHourlistItem[day]));
                }

                break;
            }

            if (_workHoursDictionary.Count == 0)
            {
                throw new Exception(string.Format("No work hours are defined for '{0}'.", spWeb.CurrentUser.LoginName));
            }
        }

        /// <summary>
        /// Initializes the controls.
        /// </summary>
        private void InitializeControls()
        {
            _startDateTextBox = (TextBox) TemplateContainer.FindControl("DaysHoursBreakdownStartDateTextBox");
            _startDateTextBox.TextChanged += StartDateTextBoxTextChanged;

            _finishDateTextBox = (TextBox) TemplateContainer.FindControl("DaysHoursBreakdownFinishDateTextBox");
            _finishDateTextBox.TextChanged += FinishDateTextBoxTextChanged;

            _postBackMarkerTextBox = (TextBox) TemplateContainer.FindControl("DaysHoursBreakdownPostBackMarkerTextBox");
            _firstLoadTextBox = (TextBox) TemplateContainer.FindControl("DaysHoursBreakdownFirstLoadTextBox");
            _valueTextBox = (TextBox) TemplateContainer.FindControl("DaysHoursBreakdownValueTextBox");

            _spGridView = (SPGridView) TemplateContainer.FindControl("DaysHoursBreakdownGridView");

            var updatePanel = (UpdatePanel) TemplateContainer.FindControl("DaysHoursBreakdownUpdatePanel");

            ScriptManager.RegisterStartupScript(updatePanel, updatePanel.GetType(), "DaysHoursBreakdownScript",
                                                DAYS_HOURS_BREAKDOWN_SCRIPT, true);
        }

        /// <summary>
        /// Loads the blocked days.
        /// </summary>
        /// <param name="dhbField">The DHB field.</param>
        private void LoadBlockedDays(DaysHoursBreakdownField dhbField)
        {
            SPWeb spWeb = SPContext.Current.Web;

            string resourcePoolUrl;

            Guid lockedWeb = CoreFunctions.getLockedWeb(spWeb);
            using (SPWeb configWeb = Utils.GetConfigWeb(spWeb, lockedWeb))
            {
                resourcePoolUrl = CoreFunctions.getConfigSetting(configWeb, "EPMLiveResourceURL", true, false);
            }

            using (var spSite = new SPSite(resourcePoolUrl))
            {
                using (SPWeb web = spSite.OpenWeb())
                {
                    SPListCollection spListCollection = web.Lists;

                    SPList holidaysList;
                    SPList holidaySchedulesList;
                    SPList resourcesList;
                    SPList workHoursList;

                    GetRequiredLists(spListCollection, dhbField, out holidaysList, out holidaySchedulesList,
                                     out resourcesList,
                                     out workHoursList);

                    _workHoursDictionary = new Dictionary<string, decimal>();
                    _holidayDictionary = new Dictionary<string, string>();

                    bool resourceFoundInPool = false;

                    foreach (SPListItem resourceListItem in resourcesList.Items)
                    {
                        object spAccount = resourceListItem["SharePointAccount"];

                        if (spAccount == null) continue;

                        var spFieldUserValue = new SPFieldUserValue(web, (string)spAccount);
                        SPUser spUser = spFieldUserValue.User;

                        if (spUser == null) continue;

                        if (spUser.ID != web.CurrentUser.ID) continue;

                        try
                        {
                            GetWorkHours(workHoursList, resourceListItem, web);
                        }
                        catch
                        {
                            throw new Exception("Your user account does not have a Work Hours schedule specified in the Resource Pool.  Please contact your Administrator to correctly associate your account with a Work Hours schedule.");
                        }

                        try
                        {
                            GetHolidays(holidaysList, resourceListItem);
                        }
                        catch
                        {
                            throw new Exception("Your user account is not associated with a Holiday Schedule in the Resource Pool.  Please contact your Administrator to correctly associate your account with a Holiday Schedule.");
                        }

                        resourceFoundInPool = true;

                        break;
                    }

                    if (!resourceFoundInPool)
                    {
                        throw new Exception(string.Format("Cannot find '{0}' in the Resource Pool.",
                                                          web.CurrentUser.LoginName));
                    }
                }
            }
        }

        /// <summary>
        /// Starts the date text box text changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void StartDateTextBoxTextChanged(object sender, EventArgs e)
        {
            var errorPanel = TemplateContainer.FindControl("DHBErrorPanel");
            var errorLabel = ((Label) TemplateContainer.FindControl("DHBErrorLabel"));

            try
            {
                errorPanel.Visible = false;
                errorLabel.Text = string.Empty;

                _startDateTextBox.Text = ((TextBox) sender).Text;
                DateChanged();
            }
            catch (Exception exception)
            {
                errorPanel.Visible = true;
                errorLabel.Text = string.Format("<b>Error: </b>{0}", exception.Message);
            }
        }

        #endregion Methods 

        #region Nested type: ItemTemplate

        private class ItemTemplate : ITemplate
        {
            private readonly bool _blocked;
            private readonly string _columnName;
            private readonly decimal _hours;
            private readonly string _title;

            /// <summary>
            /// Initializes a new instance of the <see cref="ItemTemplate"/> class.
            /// </summary>
            /// <param name="columnName">Name of the column.</param>
            /// <param name="title">The title.</param>
            /// <param name="hours">The hours.</param>
            /// <param name="blocked">if set to <c>true</c> [blocked].</param>
            public ItemTemplate(string columnName, string title, decimal hours, bool blocked)
            {
                _columnName = columnName;
                _title = title;
                _hours = hours;
                _blocked = blocked;
            }

            #region Implementation of ITemplate

            /// <summary>
            /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control"/> object that child controls and templates belong to. These child controls are in turn defined within an inline template.
            /// </summary>
            /// <param name="container">The <see cref="T:System.Web.UI.Control"/> object to contain the instances of controls from the inline template.</param>
            public void InstantiateIn(Control container)
            {
                var textBox = new TextBox
                                  {
                                      Width = 20,
                                      MaxLength = 5,
                                  };

                textBox.DataBinding += TextBoxDataBinding;
                textBox.Attributes.Add("style", "text-align:center;margin-left:5px;");
                textBox.Attributes.Add("dhbcontrol", "true");
                textBox.Attributes.Add("title", _title);
                textBox.Attributes.Add("dhbdate", _columnName);
                textBox.Attributes.Add("dhbmaxhours", _hours.ToString(CultureInfo.InvariantCulture));

                if (_blocked) textBox.Attributes.Add("disabled", "disabled");

                container.Controls.Add(textBox);
            }

            /// <summary>
            /// Texts the box data binding.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void TextBoxDataBinding(object sender, EventArgs e)
            {
                var textBox = (TextBox) sender;

                var spGridViewRow = (SPGridViewRow) textBox.NamingContainer;

                object value = DataBinder.Eval(spGridViewRow.DataItem, _columnName);

                if (value != DBNull.Value) textBox.Text = value.ToString();
            }

            #endregion
        }

        #endregion
    }
}