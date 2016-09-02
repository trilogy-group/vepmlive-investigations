using System;
using System.Text;
using System.Web;
using System.Xml;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;
using ReportFiltering.Repositories;

namespace ReportFiltering.DomainServices
{
    public class TitleFilterQueryService
    {
        const int MaxLookupfilter = 300;
        
        public void MergeExistingQueryWithTitleQuery(SPList list, Guid reportWebPartId, ref XmlDocument xmlDocContainingQueryXml)
        {
            var titleFilterQuery = GetQueryForFilteringTitles(list, reportWebPartId);
            if (string.IsNullOrEmpty(titleFilterQuery)) return;

            var whereClauseNode = xmlDocContainingQueryXml.SelectSingleNode("//Where");
            if (whereClauseNode == null)
            {
                whereClauseNode = xmlDocContainingQueryXml.CreateElement("Where");
                xmlDocContainingQueryXml.FirstChild.PrependChild(whereClauseNode);
            }

            var titleFilterQueryXml = new XmlDocument();
            titleFilterQueryXml.LoadXml(titleFilterQuery);

            var titleFilterQueryNode = xmlDocContainingQueryXml.CreateElement("In");
            titleFilterQueryNode.InnerXml = titleFilterQueryXml.FirstChild.InnerXml; 

            var newAndClauseNode = xmlDocContainingQueryXml.CreateElement("And");

            if (whereClauseNode.HasChildNodes)
            {
                newAndClauseNode.AppendChild(whereClauseNode.FirstChild.Clone());
                newAndClauseNode.AppendChild(titleFilterQueryNode);
                whereClauseNode.ReplaceChild(newAndClauseNode, whereClauseNode.FirstChild);
            }
            else
            {
                whereClauseNode.AppendChild(titleFilterQueryNode);
            }
        }

        public string GetQueryForFilteringTitles(SPList list, Guid reportWebPartGuid)
        {
            var titleFilterQuery = string.Empty;

            var searchCriteria = new ReportFilterSearchCriteria
                                     {
                                         SiteId = list.ParentWeb.Site.ID,
                                         WebId = list.ParentWeb.ID,
                                         WebPartId = reportWebPartGuid,
                                         UserId = list.ParentWeb.CurrentUser.ID.ToString()
                                     };

            var userSettingsRepo = new ReportFilterUserSettingsRepository(list.ParentWeb);
            var userSettings = userSettingsRepo.GetUserSettings(searchCriteria);

            if (userSettings.IsValid)
            {
                var filterValues = new StringBuilder();

                foreach (var title in userSettings.TitleSelections)
                {
                    filterValues.AppendFormat("<Value Type='text'>{0}</Value>", HttpUtility.HtmlEncode(title));
                }

                if (userSettings.ListId == list.ID)
                {
                    if (userSettings.TitleSelections.Count < MaxLookupfilter)
                    {
                        titleFilterQuery = string.Format("<In><FieldRef Name=\"Title\"/><Values>{0}</Values></In>", filterValues.ToString());
                    }
                }
                else if (userSettings.ListId != Guid.Empty)
                {
                    titleFilterQuery = GetTitleFilterQueryForLookup(list, userSettings, filterValues);
                }
            }

            return titleFilterQuery;
        }

        private static string GetTitleFilterQueryForLookup(SPList list, ReportFilterUserSettings userSettings, StringBuilder filterValues)
        {
            var titleFilterQuery = string.Empty;
            var reportFilterField = string.Empty;
 
            foreach (SPField oField in list.Fields)
            {
                if (oField.Type != SPFieldType.Lookup) continue;
                try
                {
                    var oLookup = (SPFieldLookup) oField;
                    if (new Guid(oLookup.LookupList) == userSettings.ListId)
                    {
                        reportFilterField = oLookup.InternalName;
                        break;
                    }
                }
                catch (FormatException)
                {
                    // Don't do anything, string wasn't a valid guid. Guid.TryParse() is only available in
                    // .NET 4.0 and above so this empty catch is suitable for now.
                }
            }

            if (userSettings.TitleSelections.Count < MaxLookupfilter && reportFilterField != string.Empty)
            {
                //titleFilterQuery = string.Format("<In><FieldRef Name=\"{0}\"/><Values>{1}</Values></In>", HttpUtility.HtmlEncode(reportFilterField), HttpUtility.HtmlEncode(filterValues.ToString()));
                titleFilterQuery = string.Format("<In><FieldRef Name=\"{0}\"/><Values>{1}</Values></In>", HttpUtility.HtmlEncode(reportFilterField), filterValues.ToString());
            }
            return titleFilterQuery;
        }
    }
}