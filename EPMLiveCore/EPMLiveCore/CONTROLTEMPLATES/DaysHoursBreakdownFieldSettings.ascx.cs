using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.ListDefinitions;
using EPMLiveCore.SPFields;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    [Guid("DB1B3E1B-EA79-4291-B64B-8D4D0105D48E")]
    public partial class DaysHoursBreakdownFieldSettings : UserControl, IFieldEditor
    {
        #region Fields (7) 

        private string _finishDateField = default(string);
        private string _holidaySchedulesField = default(string);
        private string _holidaysList = default(string);
        private string _hoursField = default(string);
        private string _resourcePoolList = default(string);
        private string _startDateField = default(string);
        private string _workHoursList = default(string);

        #endregion Fields 

        #region Methods (3) 

        // Protected Methods (2) 

        /// <summary>
        /// Holidayses the drop down list selection index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HolidaysDropDownListSelectionIndexChanged(object sender, EventArgs e)
        {
            BindHolidaySchedulesDropDownList(SPContext.Current.Web.Lists[((DropDownList) sender).SelectedValue].Fields);
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ErrorLabel.Visible = false;

                if (!IsPostBack)
                {
                    var dateTimeFields = new List<SPField>();
                    var stringFields = new List<SPField>();

                    SPContext spContext = SPContext.Current;

                    SPFieldCollection spFieldCollection = spContext.Fields;

                    foreach (SPField spField in spFieldCollection)
                    {
                        if (spField.Hidden || spField.ReadOnlyField) continue;

                        SPFieldType spFieldType = spField.Type;

                        switch (spFieldType)
                        {
                            case SPFieldType.DateTime:
                                dateTimeFields.Add(spField);
                                break;
                            case SPFieldType.Number:
                                stringFields.Add(spField);
                                break;
                        }
                    }

                    StartDateFieldDropDownList.DataSource = dateTimeFields;
                    StartDateFieldDropDownList.DataValueField = "InternalName";
                    StartDateFieldDropDownList.DataTextField = "Title";
                    StartDateFieldDropDownList.DataBind();

                    FinishDateFieldDropDownList.DataSource = dateTimeFields;
                    FinishDateFieldDropDownList.DataValueField = "InternalName";
                    FinishDateFieldDropDownList.DataTextField = "Title";
                    FinishDateFieldDropDownList.DataBind();

                    HoursDropDownList.DataSource = stringFields;
                    HoursDropDownList.DataValueField = "InternalName";
                    HoursDropDownList.DataTextField = "Title";
                    HoursDropDownList.DataBind();

                    //IEnumerable<SPList> resourcePoolLists =
                    //    spContext.Web.GetListByTemplateId((int) EPMLiveLists.ResourcePool);

                    SPList resourcePoolList = spContext.Web.Lists.TryGetList("Resources");

                    if (resourcePoolList == null)
                        throw new Exception("No Resource Pool list found for the current web.");

                    var resourcePoolLists = new List<SPList> {resourcePoolList};

                    IEnumerable<SPList> workHoursLists = spContext.Web.GetListByTemplateId((int) EPMLiveLists.WorkHours);
                    if (workHoursLists == null) throw new Exception("No Work Hours list found for the current web.");

                    IEnumerable<SPList> holidaysLists = spContext.Web.GetListByTemplateId((int) EPMLiveLists.Holidays);
                    if (holidaysLists == null) throw new Exception("No Holidays list found for the current web.");

                    ResourcePoolDropDownList.DataSource = resourcePoolLists;
                    ResourcePoolDropDownList.DataValueField = "Title";
                    ResourcePoolDropDownList.DataTextField = "Title";
                    ResourcePoolDropDownList.DataBind();

                    WorkHoursDropDownList.DataSource = workHoursLists;
                    WorkHoursDropDownList.DataValueField = "Title";
                    WorkHoursDropDownList.DataTextField = "Title";
                    WorkHoursDropDownList.DataBind();

                    HolidaysDropDownList.DataSource = holidaysLists;
                    HolidaysDropDownList.DataValueField = "Title";
                    HolidaysDropDownList.DataTextField = "Title";
                    HolidaysDropDownList.DataBind();

                    if (string.IsNullOrEmpty(_holidaySchedulesField)) _holidaysList = HolidaysDropDownList.Items[0].Value;

                    BindHolidaySchedulesDropDownList(spContext.Web.Lists[_holidaysList].Fields);

                    var dropDownLists = new List<KeyValuePair<string, DropDownList>>
                                            {
                                                new KeyValuePair<string, DropDownList>(_startDateField,
                                                                                       StartDateFieldDropDownList),
                                                new KeyValuePair<string, DropDownList>(_finishDateField,
                                                                                       FinishDateFieldDropDownList),
                                                new KeyValuePair<string, DropDownList>(_hoursField, HoursDropDownList),
                                                new KeyValuePair<string, DropDownList>(_holidaySchedulesField,
                                                                                       HolidaySchedulesDropDownList),
                                                new KeyValuePair<string, DropDownList>(_resourcePoolList,
                                                                                       ResourcePoolDropDownList),
                                                new KeyValuePair<string, DropDownList>(_workHoursList,
                                                                                       WorkHoursDropDownList),
                                                new KeyValuePair<string, DropDownList>(_holidaysList,
                                                                                       HolidaysDropDownList)
                                            };


                    foreach (var dropDownList in dropDownLists)
                    {
                        string key = dropDownList.Key;

                        if (string.IsNullOrEmpty(key)) continue;

                        foreach (ListItem listItem in dropDownList.Value.Items.Cast<ListItem>()
                            .Where(listItem => listItem.Value.Equals(key)))
                        {
                            listItem.Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    _startDateField = StartDateFieldDropDownList.SelectedValue;
                    _finishDateField = FinishDateFieldDropDownList.SelectedValue;
                    _hoursField = HoursDropDownList.SelectedValue;
                    _holidaySchedulesField = HolidaySchedulesDropDownList.SelectedValue;
                    _resourcePoolList = ResourcePoolDropDownList.SelectedValue;
                    _workHoursList = WorkHoursDropDownList.SelectedValue;
                    _holidaysList = HolidaysDropDownList.SelectedValue;

                    ValidateSettings();
                }
            }
            catch (Exception exception)
            {
                ReportError(exception);
            }
        }

        // Private Methods (1) 

        /// <summary>
        /// Binds the holiday schedules drop down list.
        /// </summary>
        /// <param name="spFieldCollection">The sp field collection.</param>
        private void BindHolidaySchedulesDropDownList(SPFieldCollection spFieldCollection)
        {
            var spFields = new List<SPField>();

            spFields.AddRange(
                spFieldCollection.Cast<SPField>().Where(
                    spField => !spField.Hidden && !spField.ReadOnlyField && spField.Type == SPFieldType.Lookup));

            HolidaySchedulesDropDownList.DataSource = spFields;
            HolidaySchedulesDropDownList.DataValueField = "InternalName";
            HolidaySchedulesDropDownList.DataTextField = "Title";
            HolidaySchedulesDropDownList.DataBind();
        }

        #endregion Methods 

        #region Implementation of IFieldEditor

        /// <summary>
        /// Initializes the field property editor when the page loads.
        /// </summary>
        /// <param name="field">An object that instantiates a custom field (column) class that derives from the <see cref="T:Microsoft.SharePoint.SPField"/> class.</param>
        public void InitializeWithField(SPField field)
        {
            if (IsPostBack) return;

            var daysHoursBreakdownField = field as DaysHoursBreakdownField;

            if (daysHoursBreakdownField == null) return;

            _startDateField = daysHoursBreakdownField.StartDateField;
            _finishDateField = daysHoursBreakdownField.FinishDateField;
            _hoursField = daysHoursBreakdownField.HoursField;
            _holidaySchedulesField = daysHoursBreakdownField.HolidaySchedulesField;
            _resourcePoolList = daysHoursBreakdownField.ResourcePoolList;
            _workHoursList = daysHoursBreakdownField.WorkHoursList;
            _holidaysList = daysHoursBreakdownField.HolidaysList;
        }

        /// <summary>
        /// Validates and saves the changes the user has made in the field property editor control.
        /// </summary>
        /// <param name="field">The field (column) whose properties are being saved.</param>
        /// <param name="isNewField">true to indicate that the field is being created; false to indicate that an existing field is being modified.</param>
        public void OnSaveChange(SPField field, bool isNewField)
        {
            ValidateSettings();

            var daysHoursBreakdownField = field as DaysHoursBreakdownField;

            if (daysHoursBreakdownField != null)
            {
                if (isNewField)
                {
                    daysHoursBreakdownField.UpdateCustomProperty("StartDateField", _startDateField);
                    daysHoursBreakdownField.UpdateCustomProperty("FinishDateField", _finishDateField);
                    daysHoursBreakdownField.UpdateCustomProperty("HoursField", _hoursField);
                    daysHoursBreakdownField.UpdateCustomProperty("HolidaySchedulesField", _holidaySchedulesField);
                    daysHoursBreakdownField.UpdateCustomProperty("ResourcePoolList", _resourcePoolList);
                    daysHoursBreakdownField.UpdateCustomProperty("WorkHoursList", _workHoursList);
                    daysHoursBreakdownField.UpdateCustomProperty("HolidaysList", _holidaysList);
                }
                else
                {
                    daysHoursBreakdownField.StartDateField = _startDateField;
                    daysHoursBreakdownField.FinishDateField = _finishDateField;
                    daysHoursBreakdownField.HoursField = _hoursField;
                    daysHoursBreakdownField.HolidaySchedulesField = _holidaySchedulesField;
                    daysHoursBreakdownField.ResourcePoolList = _resourcePoolList;
                    daysHoursBreakdownField.WorkHoursList = _workHoursList;
                    daysHoursBreakdownField.HolidaysList = _holidaysList;
                }
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the field property editor should be in a special section on the page.
        /// </summary>
        /// <returns>true if the editor should be in its own section; otherwise, false. </returns>
        public bool DisplayAsNewSection
        {
            get { return true; }
        }

        /// <summary>
        /// Reports the error.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private void ReportError(Exception exception)
        {
            ErrorLabel.Text = string.Format(@"<b>ERROR: </b>{0}", exception.Message);
            ErrorLabel.Visible = true;
        }

        /// <summary>
        /// Validates the settings.
        /// </summary>
        private void ValidateSettings()
        {
            if (string.IsNullOrEmpty(_startDateField)) throw new Exception("Please select a Start date field.");
            if (string.IsNullOrEmpty(_finishDateField)) throw new Exception("Please select a Finish date field.");
            if (string.IsNullOrEmpty(_hoursField)) throw new Exception("Please select an Hours field.");
            if (string.IsNullOrEmpty(_holidaySchedulesField))
                throw new Exception("Please select a Holiday Schedules field.");
            if (string.IsNullOrEmpty(_resourcePoolList)) throw new Exception("Please select a Resource Pool list.");
            if (string.IsNullOrEmpty(_workHoursList)) throw new Exception("Please select a Work Hours list.");
            if (string.IsNullOrEmpty(_holidaysList)) throw new Exception("Please select a Holidays list.");

            if (_startDateField.Equals(_finishDateField))
                throw new Exception("The Start date field must be different than the Finish date field.");
        }

        #endregion
    }
}