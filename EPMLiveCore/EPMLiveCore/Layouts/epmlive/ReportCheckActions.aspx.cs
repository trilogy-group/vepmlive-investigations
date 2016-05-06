using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.ReportHelper;
using System.Data;

namespace EPMLiveCore
{
    public partial class ReportCheckActions : LayoutsPageBase
    {
        string _action;
        string _listId;
        protected string output = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            _action = Request["action"];
            _listId = Request["listid"];
            Execute();
        }

        private void Execute()
        {
            switch (_action)
            {
                case "deletecheck":
                    DeleteCheck();
                    break;
            }
        }

        private void DeleteCheck()
        {
            var reportBiz = new ReportBiz(SPContext.Current.Site.ID);
            EPMData _DAO = new EPMData(SPContext.Current.Site.ID);
            _DAO.Command = "SELECT TableName FROM RPTList WHERE RPTListID=@RPTListID";
            _DAO.AddParam("@RPTListID", _listId);
            string sTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString();
            DataTable refTables = reportBiz.GetReferencingTables(_DAO, sTableName);
            
            if (refTables.Rows.Count == 0)
            {
                output = "true";
                //reportBiz.GetListBiz(new Guid(Request["List"])).Delete();
            }
            else
            {
                string sLists = GetRefLists(refTables, _DAO);
                //SPUtility.Redirect("epmlive/ListMappings.aspx?delete=true&id=" + param + "&name=" + sTableName, SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
                output = "false," + sLists;
            }
        }

        private string GetRefLists(DataTable refTables, EPMData dao)
        {
            string sRefLists = string.Empty;
            foreach (DataRow table in refTables.Rows)
            {
                if (!table["oObjName"].ToString().ToLower().Contains("snapshot"))
                {
                    sRefLists = sRefLists + dao.GetListName(table["oObjName"].ToString()) + ",";
                }
            }

            sRefLists = sRefLists.Remove(sRefLists.LastIndexOf(","));
            return sRefLists;
        }
    }
}
