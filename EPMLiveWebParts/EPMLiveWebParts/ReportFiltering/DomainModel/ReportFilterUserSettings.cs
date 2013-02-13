using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EPMLiveWebParts.ReportFiltering.DomainServices;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    public class ReportFilterUserSettings
    {
        public Guid? WebPartId { get; set; }
        public string UserId { get; set; }
        public Guid? SiteId { get; set; }
        public Guid? WebId { get; set; }
        public Guid? ListId { get; set; }
        public ReportFilterSelection FieldSelection { get; set; }
        public List<string> TitleSelections { get; set; }
        public string CamlQueryOperator { get; set; }

        public ReportFilterUserSettings()
        {
            TitleSelections = new List<string>();
            FieldSelection = new ReportFilterSelection();
        }

        /// <summary>
        /// Formats the value as:
        /// 
        /// Title,Title,Title|FieldType|FieldName:InternalFieldName:Selection,Selection,Selection|CamlQueryOperator
        /// 
        /// Each section is denoted by a pipe "|" symbol and are as follows:
        /// 
        /// Section 1 = This stores the "Title" values that the user selected for the list in the ListId property.
        /// Section 2 = This stores the type of field such as date, choice, lookup, text, etc.
        /// Section 3 = This stores the field name, field internal name, and the values selected for that field. For multi select, it will be comma separated, for single select there will be one value, for date range there will be two comma separated values etc.
        /// Section 4 = This stores the caml query operator used for filtering (for non dropdown types). For example "eq" for equals, "gt" for greater than, etc. This is used for currency, text, and date range types.
        /// 
        /// </summary>
        public string Value
        {
            get
            {
                return string.Format("{0}|{1}|{2}|{3}", GetTitleSelectionsFromEncodedString(), FieldSelection.FieldType, GetFieldSelectionFromEncodedString(), CamlQueryOperator);
            }
        }

        public bool IsValid
        {
            get { return WebPartId != null && !string.IsNullOrEmpty(UserId) && SiteId != null && WebId != null && ListId != null; }
        }

        private string GetTitleSelectionsFromEncodedString()
        {
            return TitleSelections != null ? string.Join(",", TitleSelections.ToArray()) : string.Empty;
        }

        private string GetFieldSelectionFromEncodedString()
        {
            var selectedFields = new StringBuilder();

            selectedFields.AppendFormat("{0}:{1}:{2}", FieldSelection.FieldNameForDisplay, FieldSelection.InternalFieldName, string.Join(",", FieldSelection.SelectedFields.ToArray()));

            return selectedFields.ToString();
        }

        public void Hydrate(IDataReader reader)
        {
            if (reader.Read() == false) return;

            if (reader["FK"] != DBNull.Value) WebPartId = new Guid(reader["FK"].ToString());
            if (reader["SiteId"] != DBNull.Value) SiteId = new Guid(reader["SiteId"].ToString());
            if (reader["WebId"] != DBNull.Value) WebId = new Guid(reader["WebId"].ToString());
            if (reader["UserId"] != DBNull.Value) UserId = reader["UserId"].ToString();
            if (reader["ListId"] != DBNull.Value) ListId = new Guid(reader["ListId"].ToString());
            if (reader["Value"] == DBNull.Value) return;
            
            PopulateSelectedFields(reader["Value"].ToString());
            PopulateSelectedTitles(reader["Value"].ToString());
            PopulateCamlQueryOperatorFromEncodedString(reader["Value"].ToString());
        }

        private void PopulateSelectedTitles(string storedValue)
        {
            var sections = storedValue.Split(new[] { '|' });
            var titles = sections[0];
            if (!string.IsNullOrEmpty(titles))
            {
                TitleSelections.AddRange(titles.Split(new[] { ',' }));
            }
        }

        private void PopulateSelectedFields(string storedValue)
        {
            var sections = storedValue.Split(new[] { '|' });
            var fieldSection = sections[2];
            var fieldTypeSection = sections[1];

            if (string.IsNullOrEmpty(fieldSection)) return;            
            
            var reportFilterSelection = new ReportFilterSelection();
            var columnAndFieldsSection = fieldSection.Split(new[] { ':' });

            reportFilterSelection.FieldNameForDisplay = columnAndFieldsSection[0];
            reportFilterSelection.InternalFieldName = columnAndFieldsSection[1];
            reportFilterSelection.FieldType = SPFieldTypeHelper.GetFieldType(fieldTypeSection);
            reportFilterSelection.SelectedFields.AddRange(columnAndFieldsSection[2].Split(new[] { ',' }));

            //TODO: RHS - Setting the list ID in two places is a smell. Consider refactoring to one.
            if (ListId != null) reportFilterSelection.ListToFilterOn = ListId.Value;
            FieldSelection = reportFilterSelection;
        }

        private void PopulateCamlQueryOperatorFromEncodedString(string storedValue)
        {
            var sections = storedValue.Split(new[] { '|' });
            var camlQueryOperatorSection = sections[3];
            
            //TODO: RHS - This is being set in both this class and the FieldSelection subclass. Put it in one place.
            CamlQueryOperator = camlQueryOperatorSection;
            FieldSelection.CamlComparisonOperator.Operator = CamlQueryOperator;
        }
    }
}