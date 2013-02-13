using System;
using System.Collections.Generic;
using System.Text;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using EPMLiveWebParts.ReportFiltering.DomainServices;
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

            var filteredTitlesAsJson = "{}";

            if(RequestParametersAreValid())
            {
                var web = SPContext.Current.Web;
                var list = web.Lists[_listName];
                var field = list.Fields[_fieldName];

                var fieldSelection = GetFieldSelection(field, web);

                if (!fieldSelection.HasFieldSelections) return;

                var filteredTitles = QueryHelper.GetFilteredTitles(web, fieldSelection);

                filteredTitlesAsJson = GetFilteredTitlesAsJson(filteredTitles);

                PersistSelectedFields(web, _webPartId, fieldSelection, list);
            }

            Response.ContentType = "application/json";
            Response.Write(filteredTitlesAsJson);
        }

        private ReportFilterSelection GetFieldSelection(SPField field, SPWeb web)
        {
            var selectedFields = new List<string>();
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
