using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;

namespace EPMLiveCore
{
    public partial class CascadingLookupFieldControl
    {
        private void InitializeDDL(DropDownList ddl, string defineNone)
        {
            ddl.Items.Clear();

            try
            {
                bool convertedDefineNone;
                if (!bool.TryParse(defineNone, out convertedDefineNone))
                {
                    throw new InvalidOperationException("defineNone cannot be converted to bool.");
                }
                if (convertedDefineNone)
                {
                    ddl.Items.Add(new ListItem("[Select One...]", string.Empty));
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private void EnsureDDLHasValues(CascadingLookupFieldControl field)
        {
            try
            {
                field.ClearError();

                var minItems = 0;
                try
                {
                    minItems = Convert.ToBoolean(field.strDefineNone)
                        ? 1
                        : 0;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }

                if (field.ddlCLField.Items.Count <= minItems)
                {
                    throw new Exception("No lookup results present.");
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                field.ReportError(ex, string.Empty);
            }
        }

        private void BindDDL(CascadingLookupFieldControl field, DataTable dtItems, string FieldName)
        {
            InitializeDDL(field.ddlCLField, field.strDefineNone);

            if (dtItems != null)
            {
                var dtResults = dtItems.DefaultView.ToTable(true, FieldName);
                BindDDL(field, dtResults.Select(), FieldName);
            }

            EnsureDDLHasValues(field);
        }

        private void BindDDL(CascadingLookupFieldControl field, DataRow[] drRows, string FieldName)
        {
            InitializeDDL(field.ddlCLField, field.strDefineNone);

            if (drRows != null)
            {
                foreach (var dataRow in drRows.Where(
                    dataRow => field.ddlCLField.Items.FindByValue(dataRow[FieldName].ToString()) == null))
                {
                    field.ddlCLField.Items.Add(
                        new ListItem(dataRow[FieldName].ToString(), dataRow[FieldName].ToString()));
                }
            }

            EnsureDDLHasValues(field);
        }

        private void PopulateDropdown()
        {
            EnsureChildControls();

            try
            {
                ClearError();

                if (string.IsNullOrWhiteSpace(strFilterValueField))
                {
                    var query = BuildQuery(strField, strParentField, strFilterValueField, string.Empty);
                    var queryResults = ExecuteQuery(strUrl, strList, strField, query);
                    if (queryResults != null)
                    {
                        BindDDL(this, queryResults.GetDataTable(), strField);
                    }
                }
                else
                {
                    var filterValueField = (DropDownList)FindControlRecursive(Page, strFilterValueField);
                    var query = BuildQuery(
                        strField,
                        strParentField,
                        strFilterValueField,
                        filterValueField.SelectedValue);
                    var queryResults = ExecuteQuery(strUrl, strList, strField, query);
                    if (queryResults != null)
                    {
                        BindDDL(this, queryResults.GetDataTable(), strField);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                ReportError(ex);
            }
        }
    }
}