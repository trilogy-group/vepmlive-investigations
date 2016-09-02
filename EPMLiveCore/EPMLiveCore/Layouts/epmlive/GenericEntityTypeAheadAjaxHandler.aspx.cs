using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Text;
using System.Data;
using EPMLiveCore.ReportingProxy;
using System.Collections.Generic;

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

        bool _isMultiSelect = false;
        string _selectedChildren = string.Empty;

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

            if (!string.IsNullOrEmpty(Request["isMultiSelect"]))
            {
                _isMultiSelect = Convert.ToBoolean(Request["isMultiSelect"]);
            }

            if (!string.IsNullOrEmpty(Request["selectedChildren"]))
            {
                _selectedChildren = Request["selectedChildren"];
            }
        }

        private void IssueQuery()
        {
            SPUser originalUser = SPContext.Current.Web.CurrentUser;
            if (!string.IsNullOrEmpty(_parentListField))
            {
                SPList list = SPContext.Current.Web.Lists[_listID];
                SPQuery query = new SPQuery();
                if (!_isMultiSelect)
                {
                    query.Query = "<Where><Eq><FieldRef Name='" + _parentListField + "' LookupId='TRUE'/><Value Type='Lookup'>" + int.Parse(_parentValue).ToString() + "</Value></Eq></Where>";
                }
                else
                {
                    string[] values = _parentValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    query.Query = BuildDynamicSPQueryWithMultipleOrConditions(_parentListField, values);
                }
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
                query.Query += "<OrderBy><FieldRef Name='" + _field + "' Ascending='True' /></OrderBy>";

                query.ViewFieldsOnly = true;
                SPListItemCollection items = list.GetItems(query);
                if (items.Count > 0)
                {
                    DataTable dt = items.GetDataTable();
                    _sbResult = new StringBuilder();

                    if (!string.IsNullOrEmpty(_selectedChildren))
                    {
                        try
                        {
                            var rows = from r in dt.AsEnumerable()
                                       where !_selectedChildren.Contains(r[_field].ToString())
                                       select r;
                            dt = rows.CopyToDataTable();
                        }
                        catch
                        { }
                    }

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

                //This special check needs to add to load Roles and Departments and few other lists which won't configured / added as part of List mapping screen.
                bool isEmptyTableName = true;
                if (list.EnableThrottling)
                {
                    try
                    {
                        string tableName = string.Empty;

                        tableName = GetTableName(list.ID);
                        if (!string.IsNullOrEmpty(tableName))
                        {
                            isEmptyTableName = false;
                            DataTable dt = ReportingData.GetReportingData(SPContext.Current.Web, list.Title, false, string.Empty, _field);
                            _sbResult = new StringBuilder();

                            if (dt != null)
                            {
                                foreach (DataRow r in dt.Rows)
                                {
                                    _sbResult.Append(r["ID"].ToString() + "^^" + r[_field].ToString() + "^^" + (!string.IsNullOrEmpty(r[_field].ToString()) ? r[_field].ToString() : string.Empty) + ";#");
                                }
                            }
                        }
                    }
                    catch { }
                }
                
                if(!list.EnableThrottling || isEmptyTableName)
                {
                    query.Query += "<OrderBy><FieldRef Name='" + _field + "' Ascending='True' /></OrderBy>";
                    query.ViewFieldsOnly = true;
                    SPListItemCollection items = list.GetItems(query);
                    DataTable dt = items.GetDataTable();
                    _sbResult = new StringBuilder();

                    if (dt != null)
                    {
                        //dt.DefaultView.Sort = _field;
                        //dt = dt.DefaultView.ToTable();
                        DataRow[] results = dt.Select("", _field + " ASC");
                        foreach (DataRow r in results)
                        {
                            _sbResult.Append(r["ID"].ToString() + "^^" + r[_field].ToString() + "^^" + (!string.IsNullOrEmpty(r[_field].ToString()) ? r[_field].ToString() : string.Empty) + ";#");
                        }
                    }
                }
            }
        }

        private string GetTableName(Guid listID)
        {
            string sql;
            string tableName = string.Empty;
            try
            {
                var queryExecutor = new QueryExecutor(SPContext.Current.Web);
                sql = string.Format("SELECT TableName FROM RPTList WHERE RPTListId='{0}' AND SiteId='{1}'", listID, SPContext.Current.Site.ID);
                DataTable dt = queryExecutor.ExecuteReportingDBQuery(sql, new Dictionary<string, object> { });

                if (dt != null)
                {
                    tableName = Convert.ToString(dt.Rows[0]["TableName"]);
                }
            }
            catch { }

            return tableName;

        }

        #region Dynamic SPQuery Generation Methods

        private static String BuildDynamicSPQueryWithMultipleOrConditions(string lookupField, string[] selectedParents)
        {
            String query = String.Empty;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement nodeWhere;

                //Create root node SPListItems
                nodeWhere = xmlDoc.CreateElement("Where");
                xmlDoc.AppendChild(nodeWhere);

                XmlElement nodeOr = null;
                int locCtr = 0;

                if (selectedParents.Length == 1)
                {
                    XmlElement nodeEq = BuildEqNodeForSPQuery(ref xmlDoc, ref nodeWhere);
                    BuildEqNodeInnerXmlForSPQuery(ref xmlDoc, ref nodeEq, lookupField, selectedParents[0].ToString());
                }
                else
                {
                    foreach (string val in selectedParents)
                    {
                        //Increment counter. We will need it to find the last item
                        locCtr++;

                        if (locCtr == 1)
                        {
                            nodeOr = BuildDynamicOrEqCombination(ref xmlDoc, ref nodeWhere, lookupField, val);
                        }
                        else if (locCtr == selectedParents.Length)
                        {
                            //We will need to include the last 2 nodes in the Or node. Is this the last record?
                            UpdateOrNode(ref xmlDoc, ref nodeOr, lookupField, val);
                        }
                        else
                        {
                            nodeOr = BuildDynamicOrEqCombination(ref xmlDoc, ref nodeOr, lookupField, val);
                        }
                    }
                }
                query = xmlDoc.InnerXml;
            }
            catch (Exception ex)
            { }

            return query;
        }

        /// <summary>
        /// Update Or node with a new Eq node
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="nodeParent"></param>
        /// <param name="id"></param>
        private static void UpdateOrNode(ref XmlDocument xmlDoc, ref XmlElement nodeParent, string lookupField, string val)
        {
            XmlElement nodeEq = BuildEqNodeForSPQuery(ref xmlDoc, ref nodeParent);
            nodeParent.AppendChild(nodeEq);

            BuildEqNodeInnerXmlForSPQuery(ref xmlDoc, ref nodeEq, lookupField, val);
        }

        /// <summary>
        /// Build Xml node with a combination of Or and Eq
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="nodeParent"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private static XmlElement BuildDynamicOrEqCombination(ref XmlDocument xmlDoc, ref XmlElement nodeParent, string lookupField, string val)
        {
            XmlElement nodeOr = BuildOrNodeForSPQuery(ref xmlDoc, ref nodeParent);
            XmlElement nodeEq = BuildEqNodeForSPQuery(ref xmlDoc, ref nodeOr);
            nodeOr.AppendChild(nodeEq);
            BuildEqNodeInnerXmlForSPQuery(ref xmlDoc, ref nodeEq, lookupField, val);
            return nodeOr;
        }

        /// <summary>
        /// Build Xml node for "Or"
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="nodeListItem"></param>
        private static XmlElement BuildOrNodeForSPQuery(ref XmlDocument xmlDoc, ref XmlElement nodeParent)
        {
            XmlElement nodeOr = null;
            try
            {
                nodeOr = xmlDoc.CreateElement("Or");
                nodeParent.AppendChild(nodeOr);
            }
            catch (Exception ex)
            { }
            return nodeOr;
        }

        /// <summary>
        /// Build Xml node for "Eq"
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="nodeListItem"></param>
        private static XmlElement BuildEqNodeForSPQuery(ref XmlDocument xmlDoc, ref XmlElement nodeParent)
        {
            XmlElement nodeEq = null;
            try
            {
                nodeEq = xmlDoc.CreateElement("Eq");
                nodeParent.AppendChild(nodeEq);
            }
            catch (Exception ex)
            { }
            return nodeEq;
        }

        /// <summary>
        /// Build Xml node for "Eq"
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="nodeParent"></param>
        private static void BuildEqNodeInnerXmlForSPQuery(ref XmlDocument xmlDoc, ref XmlElement nodeParent, string fieldName, string val)
        {
            try
            {
                XmlElement nodeFieldRef = xmlDoc.CreateElement("FieldRef");
                nodeFieldRef.SetAttribute("Name", fieldName);

                XmlElement nodeValue = xmlDoc.CreateElement("Value");
                nodeValue.SetAttribute("Type", "LookupMulti");
                nodeValue.InnerText = val;

                nodeParent.AppendChild(nodeFieldRef);
                nodeParent.AppendChild(nodeValue);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

    }
}