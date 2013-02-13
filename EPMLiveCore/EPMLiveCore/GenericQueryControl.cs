using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebControls;
using System.Data;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Collections;
using EPMLiveCore.GlobalResources;

namespace EPMLiveCore
{
    public class GenericQueryControl : SimpleQueryControl, ICallbackEventHandler
    {
        private GenericEntityPickerPropertyBag propertyBag;
        private SPWeb web;
        private SPList list;
        private DataTable dataTable;

        private string searchField = null;
        private string searchOperator = null;

        //should be a select not dropdown, because of EventValidation issue of AJAX like functionality with WebControls
        protected HtmlSelect drpdSearchOperators;

        public SPWeb Web
        {
            get
            {
                if (web == null)
                {
                    try
                    {
                        web = SPContext.Current.Site.OpenWeb(PropertyBag.LookupWebID);
                    }
                    catch { }
                }
                return web;
            }
        }

        public SPList List
        {
            get
            {
                if (list == null)
                {
                    try
                    {
                        list = Web.Lists[PropertyBag.LookupListID];
                    }
                    catch { }
                }
                return list;
            }
        }

        public GenericEntityPickerPropertyBag PropertyBag
        {
            get
            {
                if (propertyBag == null)
                {
                    propertyBag = new GenericEntityPickerPropertyBag(this.PickerDialog.CustomProperty);
                }

                return propertyBag;
            }
        }

        public GenericQueryControl()
        { }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EnsureChildControls();
            }
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (web != null)
            {
                web.Dispose();
            }
        }

        private DataTable GetListTable(string search, string groupName)
        {
            SPField searchField = list.Fields[new Guid(groupName)];
            SPListItemCollection items = null;

            if (!string.IsNullOrEmpty(search))
            {
                SPQuery query = new SPQuery();

                if (searchField.Type == SPFieldType.DateTime)
                    search = SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.Parse(search));

                string valueType = searchField.TypeAsString;
                if (searchField.Type == SPFieldType.Calculated)
                    valueType = "Text";

                query.ViewAttributes = "Scope=\"Recursive\"";
                query.Query = string.Format("<Where><{0}><FieldRef ID=\"{1}\"/><Value Type=\"{2}\">{3}</Value></{0}></Where>"
                    , searchOperator ?? "Eq"
                    , searchField.Id.ToString()
                    , valueType
                    , search);

                items = list.GetItems(query);
            }
            // return all items when search is blank?
            //else
            //{
            //    items = list.Items;
            //}

            if (items != null)
            {
                foreach (SPListItem item in items)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        SPField field = item.Fields[new Guid(col.ColumnName)];
                        string sData = string.Empty;
                        try
                        {
                            sData = field.GetFieldValueAsText(item[field.Id]);
                        }
                        catch { }

                        row[col] = sData;
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        protected override int IssueQuery(string search, string groupName, int pageIndex, int pageSize)
        {
            ArrayList columnDisplayNames = ((TableResultControl)PickerDialog.ResultControl).ColumnDisplayNames;
            ArrayList columnNames = ((TableResultControl)PickerDialog.ResultControl).ColumnNames;
            ArrayList columnWidths = ((TableResultControl)PickerDialog.ResultControl).ColumnWidths;
            columnWidths.Clear();
            Guid queryFldID = new Guid(groupName);
            if (propertyBag.LookupFieldTargetFieldID != queryFldID &&
                List.Fields[propertyBag.LookupFieldTargetFieldID].Title != List.Fields[queryFldID].Title)
            {
                SPField fld = List.Fields[queryFldID];
                columnDisplayNames.Add(fld.Title);
                columnNames.Add(fld.Id.ToString());
            }

            if (columnNames.Count > 0)
            {

                int width = (int)(100 / columnNames.Count);
                for (int i = 0; i < columnNames.Count; i++)
                {
                    columnWidths.Add(width.ToString() + "%");
                }
            }

            DataTable table = this.GetListTable(search, groupName);

            PickerDialog.Results = table;
            PickerDialog.ResultControl.PageSize = table.Rows.Count;

            return table.Rows.Count;
        }

        public override PickerEntity GetEntity(DataRow row)
        {
            PickerEntity entity = new PickerEntity();
            entity.DisplayText = row[List.Fields.GetFieldByInternalName(propertyBag.LookupFieldInternalName).Id.ToString()].ToString();
            entity.Key = row[SPBuiltInFieldId.ID.ToString()].ToString();
            entity.Description = entity.DisplayText;
            entity.IsResolved = true;

            //foreach (DataColumn col in row.Table.Columns)
            //{
            //    foreach (string internalName in PropertyBag.SearchFields)
            //    {
            //        if (internalName == col.ExtendedProperties["InternalName"].ToString())
            //        {
            //            entity.EntityData.Add(col.ColumnName, row[col]);
            //            break;
            //        }
            //    }
            //}


            // go set value in source item
            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{
            //    using (SPSite es = new SPSite(SPContext.Current.Site.ID))
            //    {
            //        using (SPWeb ew = es.OpenWeb(propertyBag.ParentWebID))
            //        {
            //            SPList l = ew.Lists[PropertyBag.ListID];
            //            SPListItem i = l.GetItemById(PropertyBag.ItemID);
            //            i[PropertyBag.LookupFieldSourceFieldID] = entity.Key + ";#" + entity.DisplayText;
            //        }
            //    }
            //});

            return entity;
        }

        protected override void CreateChildControls()
        {
            dataTable = new DataTable();

            Table htmlTable = new Table();
            htmlTable.Width = Unit.Percentage(100.0);
            htmlTable.Attributes.Add("cellspacing", "0");
            htmlTable.Attributes.Add("cellpadding", "0");
            TableRow row = new TableRow();
            row.Width = Unit.Percentage(100.0);
            Label label = new Label();
            TableCell cell = new TableCell();
            cell.CssClass = "ms-descriptiontext";
            cell.Attributes.Add("style", "white-space:nowrap");
            string str = SPHttpUtility.HtmlEncode(SPResource.GetString("PickerDialogDefaultSearchLabel", new object[0]));
            str = string.Format(CultureInfo.InvariantCulture, "<b>{0}</b>&nbsp;", new object[] { str });
            label.Text = str;
            cell.Controls.Add(label);
            this.ColumnList = new DropDownList();
            this.ColumnList.ID = "columnList";
            this.ColumnList.CssClass = "ms-pickerdropdown";
            cell.Controls.Add(this.ColumnList);
            row.Cells.Add(cell);

            //Punches-in the search operator dropdown
            cell = new TableCell();
            cell.Style.Add("padding-right", "20px");
            drpdSearchOperators = new HtmlSelect();
            drpdSearchOperators.ID = "queryOperators";
            drpdSearchOperators.Attributes.Add("class", "ms-pickerdropdown");

            cell.Controls.Add(drpdSearchOperators);
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Width = Unit.Percentage(100.0);
            this.QueryTextBox = new InputFormTextBox();
            this.QueryTextBox.ID = "queryTextBox";
            this.QueryTextBox.CssClass = "ms-pickersearchbox";
            this.QueryTextBox.AccessKey = SPResource.GetString("PickerDialogSearchAccessKey", new object[0]);
            this.QueryTextBox.Width = Unit.Percentage(100.0);
            this.QueryTextBox.MaxLength = 0x3e8;
            this.QueryTextBox.Text = QueryText;
            cell.Controls.Add(this.QueryTextBox);
            row.Cells.Add(cell);
            label.AssociatedControlID = "queryTextBox";
            cell = new TableCell();
            this.QueryButton = new ImageButton();
            this.QueryButton.ID = "queryButton";
            this.QueryButton.OnClientClick = "executeQuery();return false;";
            this.QueryButton.ToolTip = SPResource.GetString("PickerDialogSearchToolTip", new object[0]);
            this.QueryButton.AlternateText = SPResource.GetString("PickerDialogSearchToolTip", new object[0]);
            if (!Web.RegionalSettings.IsRightToLeft)
            {
                this.QueryButton.ImageUrl = "/_layouts/images/gosearch.gif";
            }
            else
            {
                this.QueryButton.ImageUrl = "/_layouts/images/gortl.gif";
            }
            HtmlGenericControl control = new HtmlGenericControl("div");
            control.Attributes.Add("class", "ms-searchimage");
            control.Controls.Add(this.QueryButton);
            cell.Controls.Add(control);
            row.Cells.Add(cell);
            htmlTable.Rows.Add(row);
            this.Controls.Add(htmlTable);

            SPList list = Web.Lists[propertyBag.LookupListID];
            
            //fills the search fields initially  
            foreach (SPField field in list.Fields)
            {
                if (!field.Hidden && field.Reorderable)
                {
                    // add table columns
                    if (!Page.IsPostBack)
                    {
                        mColumnList.Items.Add(new ListItem(field.Title, field.Id.ToString()));
                    }

                    DataColumn col = dataTable.Columns.Add();
                    col.ColumnName = field.Id.ToString();
                    col.Caption = field.Title;
                    col.ExtendedProperties.Add("InternalName", field.InternalName);
                }
            }

            if (!dataTable.Columns.Contains(SPBuiltInFieldId.ID.ToString()))
            {
                SPField idField = list.Fields[SPBuiltInFieldId.ID];

                DataColumn col = dataTable.Columns.Add();
                col.ColumnName = idField.Id.ToString();
                col.Caption = idField.Title;
                col.ExtendedProperties.Add("InternalName", idField.InternalName);
            }

            if (mColumnList.Items.Count == 0)
            {
                SPField field = List.Fields[PropertyBag.LookupFieldInternalName];
                mColumnList.Items.Add(new ListItem(field.Title, field.Id.ToString()));
            }

            // reorder items 
            // Make Title the first field
            // then order the rest alphabetically
            string s = list.Fields.GetFieldByInternalName(propertyBag.LookupFieldInternalName).Id.ToString();
            ListItem li = mColumnList.Items.Cast<ListItem>().Where(i => i.Value == s).FirstOrDefault();
            ListItem[] liArray = mColumnList.Items.Cast<ListItem>().Where(i => i.Value != s).OrderBy(i => i.Text).ToArray<ListItem>();
            mColumnList.Items.Clear();
            mColumnList.Items.Add(li);
            mColumnList.Items.AddRange(liArray);

            //fills the search operators initally
            FillSearchOperators(ColumnList.SelectedValue);
        }

        private void FillSearchOperators(string searchField)
        {
            drpdSearchOperators.Items.Clear();

            SPField queryField = List.Fields[new Guid(searchField)];
            
            drpdSearchOperators.Items.Add(new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorEquals, "Eq"));
            drpdSearchOperators.Items.Add(new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorNotEqual, "Neq"));

            if (queryField.Type == SPFieldType.Counter || queryField.Type == SPFieldType.Integer
                || queryField.Type == SPFieldType.Number || queryField.Type == SPFieldType.Currency
                || queryField.Type == SPFieldType.DateTime)
            {
                drpdSearchOperators.Items.Add(new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorLessThan, "Lt"));
                drpdSearchOperators.Items.Add(new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorLessThanOrEqualTo, "Leq"));
                drpdSearchOperators.Items.Add(new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorGreaterThan, "Gt"));
                drpdSearchOperators.Items.Add(new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorGreaterThanOrEqualTo, "Geq"));
            }
            else
            {
                if (queryField.Type != SPFieldType.Boolean && queryField.Type != SPFieldType.DateTime)
                {
                    drpdSearchOperators.Items.Insert(0, new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorContains, "Contains"));
                }

                drpdSearchOperators.Items.Insert(1, new ListItem(WorkEngineLookupPickerResources.lookupWithPickerOperatorBeginsWith, "BeginsWith"));
            }

        }

        protected override void OnPreRender(EventArgs e)
        {
            //generate callback script for search field changes
            ClientScriptManager cs = Page.ClientScript;
            string context = GenerateContextScript();
            string cbr = cs.GetCallbackEventReference(this, "searchField", "SearchFieldChangedResult", context, false);
            String callbackScript = "function SearchFieldChanged() {"
               + "var searchField= 'searchFieldChangedTo:' + document.getElementById('" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.ColumnList.ClientID) + "').value;"
               + cbr + "; }";

            cs.RegisterClientScriptBlock(this.GetType(), "SearchFieldChanged",
                callbackScript, true);

            ColumnList.Attributes.Add("onchange", "SearchFieldChanged();");

            //HACK: fragment from the base class with query operators hack
            string str = this.Page.ClientScript.GetCallbackEventReference(this, "search", "PickerDialogHandleQueryResult", "ctx", "PickerDialogHandleQueryError", true);

            this.Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "__SEARCH__", "<script>\r\n                function executeQuery()\r\n                {\r\n   var operators=document.getElementById('" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.drpdSearchOperators.ClientID) + "');                 var query=document.getElementById('" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.QueryTextBox.ClientID) + "');\r\n                    var list=document.getElementById('" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.ColumnList.ClientID) + "');\r\n                    var search='';\r\n                    var multiParts = new Array();\r\n       multiParts.push(operators.value);\r\n             if(list!=null)\r\n                        multiParts.push(list.value);\r\n                    else\r\n                        multiParts.push('');\r\n                    multiParts.push(query.value);\r\n\r\n                    search = ConvertMultiColumnValueToString(multiParts);\r\n                    PickerDialogSetClearState();\r\n                    \r\n                    var ctx = new PickerDialogCallbackContext();\r\n                    ctx.resultTableId = 'resultTable';\r\n                    ctx.queryTextBoxElementId = '" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.QueryTextBox.ClientID) + "';\r\n                    ctx.errorElementId = '" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.PickerDialog.ErrorLabel.ClientID) + "';\r\n                    ctx.htmlMessageElementId = '" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.PickerDialog.HtmlMessageLabel.ClientID) + "';\r\n                    ctx.queryButtonElementId = '" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.QueryButton.ClientID) + "';\r\n                    PickerDialogShowWait(ctx);\r\n                    " + str + ";\r\n                }\r\n                </script>");
            this.QueryTextBox.Text = this.QueryText;
            this.QueryTextBox.Attributes.Add("onKeyDown", "var e=event; if(!e) e=window.event; if(!browseris.safari && e.keyCode==13) { document.getElementById('" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.QueryButton.ClientID) + "').click(); return false; }");
            if ((this.QueryTextBox.Text.Length > 0) && !this.Page.IsPostBack)
            {
                string group = string.Empty;
                if (this.ColumnList.SelectedItem != null)
                {
                    group = this.ColumnList.SelectedItem.Value;
                }
                this.ExecuteQuery(group, this.QueryText);
            }
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "SetFocus", "<script>\r\n                    var objQueryTextBox = document.getElementById('" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.QueryTextBox.ClientID) + "'); \r\n                    if (objQueryTextBox != null)\r\n                    {\r\n                        try\r\n                        {\r\n                            objQueryTextBox.focus();\r\n                        }\r\n                        catch(e)\r\n                        {\r\n                        }\r\n                    }\r\n                  </script>");
        }

        private string GenerateContextScript()
        {
            StringBuilder context = new StringBuilder();
            context.Append("function SearchFieldChangedResult(searchOperators, context)");
            context.Append("{");
            context.Append("var drpdSearchOperators = document.getElementById('" + SPHttpUtility.EcmaScriptStringLiteralEncode(this.drpdSearchOperators.ClientID) + "');");
            context.Append("drpdSearchOperators.length=0;");
            context.Append("var operators = searchOperators.split(';');");
            context.Append("for(op=0;op<operators.length;op++)");
            context.Append("{");
            context.Append("var operator = operators[op].split(',');");
            context.Append("var option = document.createElement('option');");
            context.Append("option.text = operator[0];");
            context.Append("option.value = operator[1];");
            context.Append("drpdSearchOperators.add(option);");
            context.Append("}");
            context.Append("}");

            return context.ToString();
        }

        public new string GetCallbackResult()
        {
            if (String.IsNullOrEmpty(searchField))
                return base.GetCallbackResult();

            FillSearchOperators(searchField);

            string operators = "";
            foreach (ListItem item in drpdSearchOperators.Items)
            {
                if (operators.Length >= 1)
                    operators += ";";
                operators += item.Text + "," + item.Value;
            }

            return operators;
        }

        public new void RaiseCallbackEvent(string eventArgument)
        {
            //Wraps the base method to cut the hacked-in search operator

            if (eventArgument.StartsWith("searchFieldChangedTo:"))
            {
                searchField = eventArgument.Replace("searchFieldChangedTo:", "");
                return;
            }
            else
            {
                SPFieldMultiColumnValue multiVal = new SPFieldMultiColumnValue(eventArgument);
                if (multiVal.Count == 3)
                {
                    searchOperator = multiVal[0];
                    eventArgument = eventArgument.Replace(";#" + searchOperator, "");
                    base.RaiseCallbackEvent(eventArgument);
                }
                else
                    base.RaiseCallbackEvent(eventArgument);
            }


        }
    }
}
