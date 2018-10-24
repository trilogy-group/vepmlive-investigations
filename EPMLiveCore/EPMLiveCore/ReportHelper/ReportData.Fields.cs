using System;
using System.Data.SqlClient;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        private const string LookupMulti = "lookupmulti";
        private const string UserMulti = "usermulti";
        private const string IdText = "id";
        private const string ResultType = "ResultType";
        private const string Currency = "currency";
        private const string Number = "number";
        private const string DateTimeText = "datetime";
        private const string BooleanText = "boolean";
        private const string TextId = "text";
        private const string TotalRollup = "totalrollup";
        private const int Size256 = 256;
        private const int Size8001 = 8001;
        private const int DefaultSize = -1;
        private const string ColumnName = "ColumnName";
        private const string InternalNameLower = "internalname";
        private const string SharePointType = "SharepointType";
        private const string LookupLower = "lookup";
        private const string ColumnNameLower = "columnname";
        private const string MultiChoice = "multichoice";
        private const string UniqueIdentifier = "uniqueidentifier";
        private const string IntText = "int";
        private const string DateTimeLower = "datetime";
        private const string FloatLower = "float";
        private const string ColumnType = "ColumnType";
        private const string User = "user";
        private const string SemiColonHash = ";#";
        private const string SingleQuote = "'";
        private const string InsertAction = "insert";
        private const string UpdateAction = "update";
        private const string EpmLiveId = "EPM Live";
        private const string EpmLiveReportingGetColumnValue = "EPMLive Reporting GetColumnValue";
        private const string AssignedTo = "AssignedTo";
        private const string Work = "Work";
        private const string WorkTypeText = "WorkType";
        private const string DataSourceText = "DataSource";
        private const string AssignedToText = "assignedtotext";
        private const string InternalName = "InternalName";
        private const string Lookup = "Lookup";
        private const string SAccount = "SAccount";
        private const string DatabaseName = "DatabaseName";
        private const string ReportingV2 = "reportingV2";

        protected readonly string _epmLiveCs;
        protected readonly Guid _siteId;
        protected readonly Guid _webId;
        protected string webTitle = string.Empty;
        protected EPMData _DAO;
        protected SqlCommand _cmdWithParams;
        protected bool _isReportingV2Enabled;
        protected bool _isRootWeb = true;
        protected SqlParameterCollection _params;
        protected string _siteName;
        protected string _siteUrl;
        private string _sqlError;
        private bool _disposed;

        public string SiteName
        {
            get { return _siteName; }
        }

        public bool EPMLiveConOpen
        {
            get { return _DAO.EPMLiveConOpen; }
        }

        public string UserName
        {
            get { return _DAO.UserName; }
            set { _DAO.UserName = value; }
        }

        public string Password
        {
            get { return _DAO.Password; }
            set { _DAO.Password = value; }
        }

        public bool UseSqlAccount
        {
            get { return _DAO.UseSqlAccount; }
            set { _DAO.UseSqlAccount = value; }
        }

        public string SiteUrl
        {
            get { return _siteUrl; }
        }

        public string Command
        {
            get { return _DAO.Command; }
            set { _DAO.Command = value; }
        }
    }
}