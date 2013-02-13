using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Text;
using System.Data;

namespace EPMLiveCore
{
    public partial class GenericEntityTypeAheadAjaxHandler : LayoutsPageBase
    {
        protected string output = "";

        Guid _webID;
        Guid _listID;
        Guid _fieldID;
        string _field = string.Empty;
        string _parent = string.Empty;
        string _parentValue = string.Empty;
        string _parentListField = string.Empty;
        StringBuilder _sbResult;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitVals();
            IssueQuery();
            OutputResult();
        }

        private void OutputResult()
        {
            string result = _sbResult.ToString();
            if (!string.IsNullOrEmpty(result))
            {
                output = result;
            }
        }

        private void InitVals()
        {
            if (!string.IsNullOrEmpty(Request["webid"]))
            {
                _webID = new Guid(Request["webid"]);
            }

            if (!string.IsNullOrEmpty(Request["listid"]))
            {
                _listID = new Guid(Request["listid"]);
            }

            if (!string.IsNullOrEmpty(Request["fieldid"]))
            {
                _fieldID = new Guid(Request["fieldid"]);
            }

            if (!string.IsNullOrEmpty(Request["field"]))
            {
                _field = Request["field"];
            }

            if (!string.IsNullOrEmpty(Request["parent"]))
            {
                _parent = Request["parent"];
            }

            if (!string.IsNullOrEmpty(Request["parentvalue"]))
            {
                _parentValue = Request["parentvalue"];
            }

            if (!string.IsNullOrEmpty(Request["parentlistfield"]))
            {
                _parentListField = Request["parentlistfield"];
            }
        }

        private void IssueQuery()
        {
            SPUser originalUser = SPContext.Current.Web.CurrentUser;
            if (!string.IsNullOrEmpty(_parentListField))
            {
                SPList list = SPContext.Current.Web.Lists[_listID];
                SPQuery query = new SPQuery();
                query.Query = "";
                if (_field.Contains("ID") || _parentListField.Contains("ID"))
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='" + _parentListField + "' />";
                }
                else
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='" + _parentListField + "' /><FieldRef Name='ID' />";
                }
                query.ViewFieldsOnly = true;
                SPListItemCollection items = list.GetItems(query);
                DataTable dt = items.GetDataTable();
                _sbResult = new StringBuilder();
                SPFieldLookupValue testVal = null;

                if (dt != null)
                {
                    DataRow[] results = dt.Select("", _field + " ASC");
                    foreach (DataRow r in results)
                    {
                        try
                        {
                            testVal = new SPFieldLookupValue(list.GetItemById((int)r["ID"])[_parentListField].ToString());
                        }
                        catch { }

                        if (testVal.LookupId == int.Parse(_parentValue))
                        {
                            _sbResult.Append(r["ID"].ToString() + "," + (!string.IsNullOrEmpty(r[_field].ToString()) ? r[_field].ToString() : string.Empty) + ";#");
                        }
                    }
                }
            }
            else
            {
                SPList list = SPContext.Current.Web.Lists[_listID];
                SPQuery query = new SPQuery();
                query.Query = "";
                query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='ID' />";
                query.ViewFieldsOnly = true;
                SPListItemCollection items = list.GetItems(query);
                DataTable dt = items.GetDataTable();
                _sbResult = new StringBuilder();

                if (dt != null)
                {
                    DataRow[] results = dt.Select("", _field + " ASC");
                    foreach (DataRow r in results)
                    {
                        _sbResult.Append(r["ID"].ToString() + "," + (!string.IsNullOrEmpty(r[_field].ToString()) ? r[_field].ToString() : string.Empty) + ";#");
                    }
                }

            }

        }
    }
}
