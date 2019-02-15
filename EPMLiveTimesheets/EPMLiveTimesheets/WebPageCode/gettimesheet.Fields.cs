using System.Data;
using Microsoft.SharePoint;

namespace TimeSheets
{
    public partial class gettimesheet
    {
        private const string IdUserName = "@username";
        private const string IdSiteGuid = "@siteguid";
        private const string IdPeriod = "@period_id";
        private const string IdSite = "@siteid";
        private const string WidthText = "width";
        private const string AlignText = "align";
        private const string IdText = "id";
        private const string ColumnText = "column";
        private const string TrueText = "True";
        private const string SpTsGetTsForSiteText = "spTSGetTSForSite";
        private const string ColumnHead = "//head/column";
        private const string XPathText = "//head/beforeInit";
        private const string TypeText = "type";
        private const string ColorText = "color";
        private const string RoText = "ro";
        private const string ChText = "ch";
        private const string SingleNodePath = "//head";
        private const string Zero = "0";
        private const string CellText = "cell";
        private const string StyleText = "style";
        private const string TitleText = "Title";
        private const string ProjectText = "Project";
        private const string ListText = "List";
        private const string WebUId = "Web_UID";
        private const string ListUId = "List_UID";
        private const string ItemId = "ITEM_ID";
        private const string ColumnValueText = "columnValue";
        private const string ColumnNameText = "columnName";
        private const string UserDataText = "userdata";
        private const string NameText = "name";
        private readonly SPSite site = SPContext.Current.Site;
        private int period;
        private string username = SPContext.Current.Web.CurrentUser.LoginName;
        private readonly DataSet dsTSHours = new DataSet();
        private readonly DataSet dsTSMeta = new DataSet();
        private DataSet dsTimesheetTasks;
        private static readonly string bgcolor = "EFEFEF";
        private bool submitted;
        private bool usecurrent = true;
        private DataTable dtTemp = new DataTable();
    }
}