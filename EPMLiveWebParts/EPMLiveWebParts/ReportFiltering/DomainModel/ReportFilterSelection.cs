using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    public class ReportFilterSelection
    {
        public string InternalFieldName { get; set; }
        public string FieldNameForDisplay { get; set; }
        public List<string> SelectedFields { get; set; }
        public CamlComparisonOperator CamlComparisonOperator { get; set; }
        public SPFieldType FieldType { get; set; }
        public bool IsLookUp { get; set; }
        public bool IsPercentage { get; set; }
        public SPFieldType LookupFieldType { get; set; }
        public Guid ListToFilterOn { get; set; }
        public bool HasErrors { get; set; }
        public List<string> Errors { get; set; }
        public bool HasFieldSelections
        {
            get { return SelectedFields.Count > 0; }
        }

        public ReportFilterSelection()
        {
            SelectedFields = new List<string>();
            Errors = new List<string>();
            CamlComparisonOperator = CamlComparisonOperator.Empty;
        }
    }
}