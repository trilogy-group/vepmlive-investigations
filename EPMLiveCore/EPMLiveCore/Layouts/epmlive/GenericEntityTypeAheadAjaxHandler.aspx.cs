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
            string result = string.Empty;
            if (_sbResult != null)
            {
                result = _sbResult.ToString();
            }

            output = result;
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
                query.Query = "<Where><Eq><FieldRef Name='" + _parentListField + "' LookupId='TRUE'/><Value Type='Lookup'>" + int.Parse(_parentValue).ToString() + "</Value></Eq></Where>";
                if (_field.Contains("ID") || _parentListField.Contains("ID"))
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='" + _parentListField + "' /><FieldRef Name='Title' />";
                }
                else if (_field.Contains("Title") || _parentListField.Contains("Title"))
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='" + _parentListField + "' /><FieldRef Name='ID' />";
                }
                else
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='" + _parentListField + "' /><FieldRef Name='ID' /><FieldRef Name='Title' />";
                }
                query.ViewFieldsOnly = true;
                SPListItemCollection items = list.GetItems(query);
                if (items.Count > 0)
                {
                    DataTable dt = items.GetDataTable();
                    _sbResult = new StringBuilder();

                    foreach (DataRow r in dt.Rows)
                    {
                        _sbResult.Append(r["ID"].ToString() + "^^" + r[_field].ToString() + "^^" + (!string.IsNullOrEmpty(r[_field].ToString()) ? r[_field].ToString() : string.Empty) + ";#");
                    }
                }
            }
            else
            {
                SPList list = SPContext.Current.Web.Lists[_listID];
                SPQuery query = new SPQuery();
                query.Query = "";
                if ((_field.Trim().ToLower() == "id"))
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='Title' />";
                }
                else if ((_field.Trim().ToLower() == "title"))
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='ID' />";
                }
                else
                {
                    query.ViewFields = "<FieldRef Name='" + _field + "' /><FieldRef Name='ID' /><FieldRef Name='Title' />";
                }
                query.ViewFieldsOnly = true;
                SPListItemCollection items = list.GetItems(query);
                DataTable dt = items.GetDataTable();
                _sbResult = new StringBuilder();

                if (dt != null)
                {
                    DataRow[] results = dt.Select("", _field + " ASC");
                    foreach (DataRow r in results)
                    {
                        _sbResult.Append(r["ID"].ToString() + "^^" + r[_field].ToString() + "^^" + (!string.IsNullOrEmpty(r[_field].ToString()) ? r[_field].ToString() : string.Empty) + ";#");
                    }
                }

            }
        }
    }
}