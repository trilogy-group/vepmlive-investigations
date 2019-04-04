using System;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public partial class CascadingLookupFieldControl
    {
        private SPQuery BuildQuery(string field, string parentField, string filterValueField, string filterValue)
        {
            var query = new SPQuery();
            string xaml;

            if (string.IsNullOrWhiteSpace(parentField) || string.IsNullOrWhiteSpace(filterValueField))
            {
                xaml = @"<ViewFields><FieldRef Name='{0}' /></ViewFields><OrderBy><FieldRef Name='{0}' /></OrderBy>";
                query.Query = string.Format(xaml, field);
            }
            else
            {
                xaml =
                    @"<ViewFields><FieldRef Name='{0}' /><FieldRef Name='{1}' /></ViewFields><OrderBy><FieldRef Name='{0}' /></OrderBy><Where><Eq><FieldRef Name='{1}' /><Value Type='Text'>{2}</Value></Eq></Where>";
                query.Query = string.Format(xaml, field, parentField, filterValue);
            }

            return query;
        }

        private SPListItemCollection ExecuteQuery(string url, string list, string field, SPQuery query)
        {
            using (var site = new SPSite(url))
            using (var spWeb = site.OpenWeb())
            {
                if (spWeb.Url != url)
                {
                    throw new Exception("Configuration Error (Url). Please contact Administrator.");
                }
                SPList objects;
                try
                {
                    objects = spWeb.Lists[list];
                }
                catch
                {
                    throw new Exception("Configuration Error (List). Please contact Administrator.");
                }
                try
                {
                    // CC-78270 Value previously assigned to an unused variable,
                    // possible bug?
                    objects.Fields.GetFieldByInternalName(field);
                }
                catch
                {
                    throw new Exception("Configuration Error (Field). Please contact Administrator.");
                }
                return objects.GetItems(query);
            }
        }
    }
}