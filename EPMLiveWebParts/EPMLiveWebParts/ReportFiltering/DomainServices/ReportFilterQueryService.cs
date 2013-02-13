using System;
using System.Text;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;

namespace ReportFiltering.DomainServices
{
    public class ReportFilterQueryService 
    {
        public static string GetQueryForFiltering(ReportFilterSelection fieldSelection)
        {
            switch (fieldSelection.FieldType)
            {
                case SPFieldType.Choice:
                case SPFieldType.Lookup:
                    return GetFilterForMultiSelect(fieldSelection);
                case SPFieldType.Currency:
                case SPFieldType.Text:
                case SPFieldType.Number:
                case SPFieldType.Integer:
                    return GetFilterForSingleSelect(fieldSelection);
                case SPFieldType.DateTime:
                    return GetFilterForDateTime(fieldSelection);
                case SPFieldType.User:
                    return GetFilterForUser(fieldSelection);
            }

            return string.Empty;
        }

        private static string GetFilterForMultiSelect(ReportFilterSelection fieldSelection)
        {
            var returnQuery = new StringBuilder();
            returnQuery.AppendFormat("<Where><In><FieldRef Name='{0}' /><Values>", fieldSelection.InternalFieldName);

            var fieldType = fieldSelection.IsLookUp ? fieldSelection.LookupFieldType : fieldSelection.FieldType;

            foreach (var selectedField in fieldSelection.SelectedFields)
            {
                returnQuery.AppendFormat("<Value Type='{1}'>{0}</Value>", selectedField, fieldType);
            }

            returnQuery.Append("</Values></In></Where>");
            return returnQuery.ToString();
        }

        private static string GetFilterForSingleSelect(ReportFilterSelection fieldSelection)
        {
            if (string.IsNullOrEmpty(fieldSelection.CamlComparisonOperator.Operator)) return string.Empty;
            
            var returnQuery = new StringBuilder();

            HandlePercentageFieldIfApplicable(fieldSelection);

            returnQuery.AppendFormat("<Where><{0}><FieldRef Name='{1}' /><Value Type='{3}'>{2}</Value></{0}></Where>", fieldSelection.CamlComparisonOperator.Operator, fieldSelection.InternalFieldName, fieldSelection.SelectedFields[0], fieldSelection.FieldType);

            return returnQuery.ToString();
        }

        private static void HandlePercentageFieldIfApplicable(ReportFilterSelection fieldSelection)
        {
            if (!fieldSelection.IsPercentage) return;
            if (fieldSelection.SelectedFields.Count <= 0) return;
            
            decimal result;
            decimal.TryParse(fieldSelection.SelectedFields[0], out result);

            if (result != 0) result = result/100;
            fieldSelection.SelectedFields[0] = result.ToString();
        }

        private static string GetFilterForDateTime(ReportFilterSelection fieldSelection)
        {
            var returnQuery = new StringBuilder();
            //2012-10-01T02:48:44Z

            var startDate = new DateTime();
            var startDateWasSuccessful = DateTime.TryParse(fieldSelection.SelectedFields[0], out startDate);

            var endDate = new DateTime();
            var endDateWasSuccessful = DateTime.TryParse(fieldSelection.SelectedFields[1], out endDate);

            if (startDateWasSuccessful && endDateWasSuccessful)
            {
                var startDateFormatted = string.Format("{0}-{1}-{2}T00:00:00Z", startDate.Year, startDate.Month, startDate.Day);
                var endDateFormatted = string.Format("{0}-{1}-{2}T00:00:00Z", endDate.Year, endDate.Month, endDate.Day);
                returnQuery.AppendFormat("<Where><And><Geq><FieldRef Name='{0}' /><Value Type='DateTime'>{1}</Value></Geq><Leq><FieldRef Name='{0}' /><Value Type='DateTime'>{2}</Value></Leq></And></Where>", fieldSelection.InternalFieldName, startDateFormatted, endDateFormatted);
            }

            return returnQuery.ToString();
        }

        private static string GetFilterForUser(ReportFilterSelection fieldSelection)
        {
            var returnQuery = new StringBuilder();
            returnQuery.AppendFormat("<Where><In><FieldRef Name='{0}' /><Values>", fieldSelection.InternalFieldName);

            foreach (var selectedField in fieldSelection.SelectedFields)
            {
                returnQuery.AppendFormat("<Value Type='UserMulti'>{0}</Value>", selectedField);
            }

            returnQuery.Append("</Values></In></Where>");
            return returnQuery.ToString();
        }
    }
}