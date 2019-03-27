using System;
using System.Web.UI.WebControls;

namespace EPMLiveCore
{
    public partial class CascadingLookupFieldControl
    {
        private void UpdateChildren(string ChildrenField)
        {
            var children = ChildrenField.Split(
                new[]
                {
                    "] "
                },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var child in children)
            {
                var control = FindControlRecursive(Page, child);
                if (control != null)
                {
                    var childField = (CascadingLookupFieldControl)control.Parent.Parent;
                    if (childField != null)
                    {
                        control = FindControlRecursive(Page, childField.strFilterValueField);
                        if (control != null)
                        {
                            var ddlFilterValueField = (DropDownList)control;
                            PopulateChild(childField, ddlFilterValueField.SelectedValue);

                            if (!string.IsNullOrWhiteSpace(childField.strChildrenField))
                            {
                                UpdateChildren(childField.strChildrenField);
                            }
                        }
                    }
                }
            }
        }

        private void PopulateChild(CascadingLookupFieldControl field, string filterValue)
        {
            var query = BuildQuery(field.strField, field.strParentField, field.strFilterValueField, filterValue);
            var queryResults = ExecuteQuery(field.strUrl, field.strList, field.strField, query);
            if (queryResults != null)
            {
                BindDDL(field, queryResults.GetDataTable(), field.strField);
            }
        }
    }
}