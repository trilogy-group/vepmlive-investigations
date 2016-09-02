using System;
using System.Collections.Generic;
using System.Text;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using EPMLiveWebParts.ReportFiltering.DomainServices;
using EPMLiveWebParts.Utilities;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore;
using ReportFiltering.Repositories;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class getreportfiltertitles : LayoutsPageBase
    {
        private string _listName;
        private string _fieldName;
        private string _selectedFields;
        private string _webPartId;
        private string _filterOperator;

        protected void Page_Load(object sender, EventArgs e)
        {
            _listName = Request.Form["ListName"];
            _fieldName = Request.Form["FieldName"];
            _selectedFields = Request.Form["SelectedFields"];
            _webPartId = Request.Form["WebPartId"];
            _filterOperator = Request.Form["FilterOperator"];

            var jsonToReturn = "{}";

            if(RequestParametersAreValid())
            {
                var web = SPContext.Current.Web;
                var list = web.Lists[_listName];
                var field = list.Fields[_fieldName];

                var fieldSelection = GetFieldSelection(field, web);

                if (!fieldSelection.HasFieldSelections) return;

                var filteredTitles = QueryHelper.GetFilteredTitles(web, fieldSelection);

                if (fieldSelection.HasErrors)
                {
                    jsonToReturn = GetJsonWithErrorMessage(fieldSelection);
                }
                else
                {
                    jsonToReturn = GetFilteredTitlesAsJson(filteredTitles);

                    PersistSelectedFields(web, _webPartId, fieldSelection, list);
                }
            }

            Response.ContentType = "application/json";
            Response.Write(jsonToReturn);
        }

        private string GetJsonWithErrorMessage(ReportFilterSelection fieldSelection)
        {
            var jsonToReturn = new StringBuilder();
            jsonToReturn.Append("[");

            foreach (var errorMessage in fieldSelection.Errors)
            {
                var formattedFilteredTitle = errorMessage.Replace("\"", "\\\"");
                jsonToReturn.AppendFormat("{{\"error\":\"{0}\"}},", formattedFilteredTitle);
            }

            jsonToReturn.Append("]");

            return jsonToReturn.ToString().Replace(",]", "]");
        }

        private ReportFilterSelection GetFieldSelection(SPField field, SPWeb web)
        {
            var selectedFields = new List<string>();
            _selectedFields = CleanValueIfFromPeoplePicker(_selectedFields);
            selectedFields.PopulateFromCommaSeparatedString(_selectedFields);

            var returnValue = new ReportFilterSelection
            {
                InternalFieldName = field.InternalName,
                FieldNameForDisplay = field.Title,
                FieldType = field.Type,
                ListToFilterOn = web.Lists[_listName].ID,
                SelectedFields = selectedFields,
                CamlComparisonOperator = CamlComparisonOperator.GetCamlOperatorByValue(_filterOperator)
            };

            return returnValue;
        }

        /// <summary>
        /// The value coming in from the people picker differs based on browser. This will clean it up so we
        /// just have the chosen values and not any additional stuff.
        /// </summary>
        /// <param name="selectedFields"></param>
        private string CleanValueIfFromPeoplePicker(string selectedFields)
        {
            //TODO: Clean this entire method up. It was hurried to get a bug fix out to production last minute. I know its gross.
            if (string.IsNullOrEmpty(selectedFields)) return "";
            
            // If &#160 is in the string, then its coming from Internet Explorer, so strip off the stuff we don't need.
            const string stringThatIndicatesPeoplePickerIsFromInternetExplorer = "&#160";
            if(selectedFields.Contains(stringThatIndicatesPeoplePickerIsFromInternetExplorer))
            {
                var indexOf = selectedFields.IndexOf(stringThatIndicatesPeoplePickerIsFromInternetExplorer);
                selectedFields = selectedFields.Left(indexOf);
            }

            // Trim the string and remove the ending comma if present.
            selectedFields = selectedFields.Trim();
            if (selectedFields.EndsWith(","))
            {
                selectedFields = selectedFields.Left(selectedFields.Length);
            }

            // Split the array and run through each element to trim it.
            var selectedFieldsAsArray = selectedFields.Split(',');
            for (var i = 0; i < selectedFieldsAsArray.Length; i++)
            {
                selectedFieldsAsArray[i] = selectedFieldsAsArray[i].Trim();
            }

            // Convert it back into a comma separated value and return.
            var fieldsAsCsv = String.Join(",", selectedFieldsAsArray);
            return fieldsAsCsv;
        }

        private bool RequestParametersAreValid()
        {
            if (string.IsNullOrEmpty(_listName)) return false;
            if (string.IsNullOrEmpty(_fieldName)) return false;
            
            return true;
        }

        private string GetFilteredTitlesAsJson(List<string> filteredTitles)
        {
            if (filteredTitles == null) return "";
            
            filteredTitles.Sort();
            
            var jsonToReturn = new StringBuilder();
            jsonToReturn.Append("[");

            foreach (var filteredTitle in filteredTitles)
            {
                var formattedFilteredTitle = filteredTitle.Replace("\"", "\\\"");
                jsonToReturn.AppendFormat("{{\"title\":\"{0}\"}},", formattedFilteredTitle);
            }

            jsonToReturn.Append("]");

            return jsonToReturn.ToString().Replace(",]", "]");
        }

        private void PersistSelectedFields(SPWeb web, string reportId, ReportFilterSelection fieldSelection, SPList list)
        {
            var userSettings = GetPersistedSettings(web, reportId);
            userSettings.FieldSelection = fieldSelection;
            userSettings.SiteId = web.Site.ID;
            userSettings.UserId = web.CurrentUser.ID.ToString();
            userSettings.WebId = web.ID;
            userSettings.ListId = list.ID;
            userSettings.WebPartId = WebPartHelper.ConvertWebPartIdToGuid(reportId);

            PersistUserSettings(userSettings, web);
        }

        private ReportFilterUserSettings GetPersistedSettings(SPWeb web, string reportId)
        {
            var repo = new ReportFilterUserSettingsRepository(web);
            var searchCriteria = new ReportFilterSearchCriteria
            {
                SiteId = web.Site.ID,
                UserId = web.CurrentUser.ID.ToString(),
                WebId = web.ID,
                WebPartId = WebPartHelper.ConvertWebPartIdToGuid(reportId)
            };

            ReportFilterUserSettings userSettings = null;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                userSettings = repo.GetUserSettings(searchCriteria);
            });

            return userSettings;
        }

        private void PersistUserSettings(ReportFilterUserSettings userSettings, SPWeb web)
        {
            var repo = new ReportFilterUserSettingsRepository(web);

            SPSecurity.RunWithElevatedPrivileges(() => repo.PersistUserSettings(userSettings));
        }
    }
}
