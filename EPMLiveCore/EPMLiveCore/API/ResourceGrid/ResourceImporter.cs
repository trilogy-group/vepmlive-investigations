using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.API
{
    public class ResourceImporter
    {
        #region Fields (14) 

        private const char TAB_SEPERATOR = '-';

        private const string VALIDATE_ACCOUNT_QUERY =
            @"<Where><Eq><FieldRef Name=""SharePointAccount"" LookupId=""true"" /><Value Type=""User"">{0}</Value></Eq></Where>";

        private const string VALIDATE_DISPLAY_NAME_QUERY =
            @"<Where><Eq><FieldRef Name=""Title"" /><Value Type=""Text"">{0}</Value></Eq></Where>";

        private const string VALIDATE_EMAIL_QUERY =
            @"<Where><Eq><FieldRef Name=""Email"" /><Value Type=""Text"">{0}</Value></Eq></Where>";

        private readonly Act _act;
        private readonly DataTable _dtResources;
        private readonly string _fileId;
        private readonly bool _isOnline;
        private readonly StringBuilder _masterLog;
        private readonly IList<ProcessedResource> _processedResources;
        private readonly SPWeb _spWeb;
        private string _currentProcess;
        private int _step;
        private int _totalResources;

        #endregion Fields 

        #region Constructors (1) 

        public ResourceImporter(SPWeb spWeb, string data)
        {
            if (!spWeb.CurrentUser.IsSiteAdmin)
            {
                throw new Exception("You need to be a Site Collection Administrator in order to import resources.");
            }

            _spWeb = spWeb;
            _fileId = data;
            _dtResources = new DataTable();
            _masterLog = new StringBuilder();
            _currentProcess = string.Empty;
            _totalResources = 0;
            _processedResources = new List<ProcessedResource>();
            _act = new Act(_spWeb);
            _isOnline = _act.IsOnline;
        }

        #endregion Constructors 

        #region Properties (1) 

        private int ProgressPercentage
        {
            get
            {
                if (_step == 1) return 1;
                if (_step == 3) return 99;

                int percentage = (_processedResources.Count*100)/_totalResources;
                return percentage > 98 ? 98 : percentage;
            }
        }

        #endregion Properties 

        #region Delegates and Events (2) 

        // Events (2) 

        public event ImportCompletedEventHandler ImportCompleted;

        public event ImportProgressChangedEventHandler ImportProgressChanged;

        #endregion Delegates and Events 

        #region Methods (16) 

        // Public Methods (1) 

        public void ImportAsync()
        {
            Exception exception = null;
            try
            {
                LoadSpreadsheet();
                ImportResources();
            }
            catch (Exception e)
            {
                exception = e;
            }
            finally
            {
                ImportCompleted(this,
                                new ImportCompletedEventHandlerArgs(exception, false, null, _masterLog.ToString(),
                                                                    _processedResources));
            }
        }

        // Private Methods (15) 

        private void AddMasterLog(string message, bool isHeader)
        {
            if (isHeader)
            {
                _masterLog.AppendLine();
                _masterLog.AppendLine(message.ToUpper());
            }
            else
            {
                AddMasterLog(message, 1);
            }
        }

        private void AddMasterLog(string message, int indentLevel)
        {
            _masterLog.AppendLine(new string(TAB_SEPERATOR, indentLevel*2) + " " + message);
        }

        private void AddNewResource(DataRow row, bool isGeneric)
        {
            var lockedColumns = new List<string> {"ID", "EXTID"};

            if (isGeneric)
            {
                lockedColumns.Add("FirstName");
                lockedColumns.Add("LastName");
                lockedColumns.Add("SharePointAccount");
                lockedColumns.Add("Email");
                lockedColumns.Add("Permissions");
                lockedColumns.Add("TimesheetManager");
                lockedColumns.Add("TimesheetDelegates");
                lockedColumns.Add("TimesheetAdministrator");
                lockedColumns.Add("ResourceLevel");
            }
            else
            {
                lockedColumns.Add("Title");

                if (_isOnline)
                {
                    lockedColumns.Add("SharePointAccount");
                }
            }

            SPList spList = _spWeb.Lists["Resources"];

            ValidateUser(row, isGeneric, true, spList);

            SPListItem spListItem = spList.AddItem();

            UpdateItem(row, lockedColumns, spList, spListItem, isGeneric);
        }

        private void BuildResourceTable()
        {
            Dictionary<string, object[]> usersDict = GetSiteUsers();

            Dictionary<string, Dictionary<string, int>> lookupFieldDict;
            Dictionary<string, SPFieldType> fieldDict = GetListFields(out lookupFieldDict);

            foreach (DataRow row in _dtResources.Rows)
            {
                foreach (DataColumn column in _dtResources.Columns)
                {
                    string col = column.ColumnName;
                    object value = row[col];
                    string val = string.Empty;

                    if (value != null && value != DBNull.Value) val = value.ToString();

                    if (!string.IsNullOrEmpty(val))
                    {
                        if (fieldDict.ContainsKey(col))
                        {
                            try
                            {
                                if (col.Equals("ResourceLevel"))
                                {
                                    if (!string.IsNullOrEmpty(val))
                                    {
                                        value = lookupFieldDict["ResourceLevel"][val];
                                    }

                                    row[col] = value;
                                    continue;
                                }

                                if (col.Equals("Permissions"))
                                {
                                    if (!string.IsNullOrEmpty(val))
                                    {
                                        IEnumerable<string> permissions =
                                            val.Split(',')
                                               .Select(
                                                   p =>
                                                   lookupFieldDict["Permissions"][p.Trim()].ToString(
                                                       CultureInfo.InvariantCulture));
                                        value = string.Join(",", permissions.ToArray());
                                    }

                                    row[col] = value;
                                    continue;
                                }

                                switch (fieldDict[col])
                                {
                                    case SPFieldType.Boolean:
                                        if (val.Equals("0")) value = false;
                                        else if (val.Equals("1")) value = true;
                                        break;
                                    case SPFieldType.DateTime:
                                        value = DateTime.FromOADate(Convert.ToDouble(val));
                                        break;
                                    case SPFieldType.User:
                                        try
                                        {
                                            value = new SPFieldUserValue(_spWeb, (int) usersDict[val][0], val);
                                        }
                                        catch
                                        {
                                            bool found = false;

                                            foreach (var pair in usersDict.Where(p => p.Value[1].ToString().Equals(val))
                                                )
                                            {
                                                found = true;
                                                value = new SPFieldUserValue(_spWeb, (int) pair.Value[0], pair.Key);
                                                break;
                                            }

                                            if (!found)
                                            {
                                                SPUser spUser = _spWeb.EnsureUser(val);
                                                usersDict.Add(spUser.LoginName, new object[] {spUser.ID, spUser.Name});
                                                value = new SPFieldUserValue(_spWeb, spUser.ID, spUser.Name);
                                            }
                                        }
                                        break;
                                    case SPFieldType.Lookup:
                                        value = new SPFieldLookupValue(lookupFieldDict[col][val], val);
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                string message = string.Format("Resource: {0} (ID: {1}). Field: {2} Error: {3}",
                                                               row["Title"], row["ID"], col, e.Message);
                                AddMasterLog(message, 2);
                            }
                        }
                    }

                    row[col] = value;
                }
            }
        }

        private string GetCellReference(Cell cell)
        {
            string cellReference = cell.CellReference.Value;

            foreach (string num in Regex.Split(cellReference, @"\D+").Where(num => !string.IsNullOrEmpty(num)))
            {
                cellReference = cellReference.Replace(num, string.Empty);
            }

            return cellReference;
        }

        private string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            if (cell.CellValue != null)
            {
                SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;

                string value = cell.CellValue.InnerXml;

                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                }

                return value;
            }

            return string.Empty;
        }

        private Dictionary<string, SPFieldType> GetListFields(
            out Dictionary<string, Dictionary<string, int>> lookupFieldDict)
        {
            lookupFieldDict = new Dictionary<string, Dictionary<string, int>>();
            var fieldDict = new Dictionary<string, SPFieldType>();

            SPList spList = _spWeb.Lists["Resources"];

            foreach (DataColumn dataColumn in _dtResources.Columns)
            {
                try
                {
                    string columnName = dataColumn.ColumnName;
                    SPField spField = spList.Fields.GetFieldByInternalName(columnName);
                    fieldDict.Add(columnName, spField.Type);

                    if (columnName.Equals("ResourceLevel"))
                    {
                        lookupFieldDict.Add(columnName, new Dictionary<string, int>());

                        try
                        {
                            int actType;
                            foreach (ActLevel actLevel in _act.GetLevelsFromSite(out actType, string.Empty))
                            {
                                lookupFieldDict[columnName].Add(actLevel.name, actLevel.id);
                            }
                        }
                        catch
                        {
                        }

                        continue;
                    }

                    if (columnName.Equals("Permissions"))
                    {
                        lookupFieldDict.Add(columnName, new Dictionary<string, int>());

                        try
                        {
                            foreach (SPGroup spGroup in _spWeb.Groups)
                            {
                                lookupFieldDict[columnName].Add(spGroup.Name, spGroup.ID);
                            }
                        }
                        catch
                        {
                        }

                        continue;
                    }

                    if (spField.Type != SPFieldType.Lookup) continue;

                    lookupFieldDict.Add(columnName, new Dictionary<string, int>());

                    var spFieldLookup = ((SPFieldLookup) spField);

                    SPListItemCollection spListItemCollection =
                        _spWeb.Lists[new Guid(spFieldLookup.LookupList)].GetItems("ID", spFieldLookup.LookupField);
                    foreach (SPListItem spListItem in spListItemCollection)
                    {
                        lookupFieldDict[columnName].Add(spListItem[spFieldLookup.LookupField].ToString(),
                                                        (int) spListItem["ID"]);
                    }
                }
                catch
                {
                }
            }

            return fieldDict;
        }

        private Dictionary<string, object[]> GetSiteUsers()
        {
            var usersDict = new Dictionary<string, object[]>();

            SPListItemCollection spListItemCollection = _spWeb.SiteUserInfoList.GetItems("Name", "Title", "ID");
            foreach (SPListItem spListItem in spListItemCollection)
            {
                try
                {
                    usersDict.Add(spListItem["Name"].ToString(), new[] {spListItem["ID"], spListItem["Title"]});
                }
                catch
                {
                }
            }

            return usersDict;
        }

        private void ImportResources()
        {
            _step = 2;

            AddMasterLog("Importing Resources", true);

            foreach (DataRow row in _dtResources.Rows)
            {
                var resource = new ProcessedResource();
                string message = string.Empty;

                try
                {
                    resource.Id = row["ID"].ToString();
                    resource.Name = (string) row["Title"];

                    message = string.Format("Importing resource {1} of {2}: {0} . . .", resource.Name,
                                            _processedResources.Count + 1, _totalResources);

                    AddMasterLog(message, false);

                    var isGeneric = (bool) row["Generic"];

                    AddMasterLog(string.Format("Is Generic? {0}.", isGeneric ? "YES" : "NO"), 3);

                    if (string.IsNullOrEmpty(resource.Id))
                    {
                        AddMasterLog("Is New? YES.", 3);
                        AddNewResource(row, isGeneric);
                    }
                    else
                    {
                        AddMasterLog("Is New? NO.", 3);
                        UpdateResource(row, isGeneric);
                    }

                    AddMasterLog("SUCCESS.", 2);
                    resource.Processed = true;
                }
                catch (Exception e)
                {
                    resource.Processed = false;
                    resource.Comment = e.Message;

                    AddMasterLog("FAILURE. Reason: " + e.Message, 2);
                }
                finally
                {
                    _currentProcess = message;
                    _processedResources.Add(resource);
                    ReportProgress();
                }
            }
        }

        private void LoadSpreadsheet()
        {
            _step = 1;

            AddMasterLog("Loading Spreadsheet", true);

            ReportProgress();

            using (var epmLiveFileStore = new EPMLiveFileStore(_spWeb))
            {
                using (Stream stream = epmLiveFileStore.GetStream(_fileId))
                {
                    ParseExcelResources(stream);
                }

                epmLiveFileStore.Delete(_fileId);
            }

            BuildResourceTable();

            _totalResources = _dtResources.Rows.Count;
        }

        private void ParseExcelResources(Stream stream)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(stream, false))
            {
                IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string rId = sheets.First().Id.Value;
                var worksheetPart = (WorksheetPart) document.WorkbookPart.GetPartById(rId);
                Worksheet worksheet = worksheetPart.Worksheet;
                var sheetData = worksheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                var fieldCellDict = new Dictionary<string, string>();

                int rowIndex = 0;
                foreach (Row row in rows)
                {
                    rowIndex++;

                    if (rowIndex == 1)
                    {
                        foreach (Cell cell in row)
                        {
                            string columnName = GetCellValue(document, cell);
                            _dtResources.Columns.Add(columnName, typeof (object));

                            fieldCellDict.Add(GetCellReference(cell), columnName);
                        }
                    }

                    if (rowIndex < 3)
                    {
                        continue;
                    }

                    bool isEmpty = true;

                    DataRow dataRow = _dtResources.NewRow();

                    for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    {
                        Cell cell = row.Descendants<Cell>().ElementAt(i);

                        string columnName = fieldCellDict[GetCellReference(cell)];
                        string value = GetCellValue(document, cell);

                        dataRow[columnName] = value;

                        if (!string.IsNullOrEmpty(value)) isEmpty = false;
                    }

                    if (!isEmpty) _dtResources.Rows.Add(dataRow);
                }
            }
        }

        private void ReportProgress()
        {
            ImportProgressChanged(this, new ImportProgressChangedEventHandlerArgs(
                                            ProgressPercentage, new ResourceImporterState(
                                                                    _step, _currentProcess, _masterLog.ToString(),
                                                                    _processedResources)));
        }

        private void UpdateItem(DataRow row, ICollection<string> lockedColumns, SPList spList, SPListItem spListItem,
                                bool isGeneric)
        {
            SPWeb spWeb = spList.ParentWeb;
            SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ?? spWeb.RegionalSettings;

            foreach (
                string columnName in
                    _dtResources.Columns.Cast<DataColumn>()
                                .Select(c => c.ColumnName)
                                .Where(c => !lockedColumns.Contains(c)))
            {
                object value = row[columnName];

                string col = columnName.Replace(" ", "_x0020_");

                if (value != null && value != DBNull.Value)
                {
                    string sValue = value.ToString();
                    if (!string.IsNullOrEmpty(sValue))
                    {
                        if (col.Equals("Title"))
                        {
                            value = sValue.Trim();
                        }
                        else
                        {
                            SPField spField = spList.Fields.GetFieldByInternalName(col);
                            if (spField.Type == SPFieldType.DateTime)
                            {
                                value =
                                    SPUtility.CreateISO8601DateTimeFromSystemDateTime(
                                        ((DateTime) value).ToUniversalTime());
                            }
                        }
                    }
                    else
                    {
                        value = null;
                    }
                }
                else
                {
                    value = null;
                }

                spListItem[col] = value;
                AddMasterLog(string.Format("{0}: {1}", columnName, value), 4);
            }

            if (isGeneric) spListItem["Title"] = spListItem["Title"];

            spListItem.Update();
        }

        private void UpdateResource(DataRow row, bool isGeneric)
        {
            try
            {
                var lockedColumns = new List<string> {"ID", "EXTID", "Title", "Generic", "SharePointAccount", "Email"};

                if (isGeneric)
                {
                    lockedColumns.Add("FirstName");
                    lockedColumns.Add("LastName");
                }

                SPList spList = _spWeb.Lists["Resources"];

                ValidateUser(row, isGeneric, false, spList);

                SPListItem spListItem = null;

                try
                {
                    spListItem = spList.GetItemById(Convert.ToInt32(row["ID"]));
                }
                catch
                {
                }

                if (spListItem == null)
                {
                    throw new Exception("Cannot find a resource with ID " + row["ID"] + " in the Resource Pool.");
                }

                UpdateItem(row, lockedColumns, spList, spListItem, isGeneric);
            }
            catch (SPException e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private void ValidateUser(DataRow row, bool isGeneric, bool isNew, SPList resourcePool)
        {
            int id = -1;

            if (!isNew)
            {
                id = Convert.ToInt32(row["ID"]);
            }

            object oEmail = row["Email"];
            object oTitle = row["Title"];
            object oAccount = row["SharePointAccount"];

            if (isNew && !isGeneric)
            {
                if (oEmail == null || oEmail == DBNull.Value) throw new Exception("Please provide an email.");
                if (string.IsNullOrEmpty(oEmail.ToString())) throw new Exception("Please provide an email.");
            }

            if (!isNew)
            {
                if (oEmail == null || oEmail == DBNull.Value) oEmail = string.Empty;
            }

            if (isGeneric)
            {
                if (oTitle == null || oTitle == DBNull.Value) throw new Exception("Please provide a display name.");
                if (string.IsNullOrEmpty(oTitle.ToString())) throw new Exception("Please provide a display name.");
            }
            else
            {
                if (oTitle == null || oTitle == DBNull.Value) oTitle = string.Empty;
            }

            if (!isGeneric && !_isOnline)
            {
                if (oAccount == null || oAccount == DBNull.Value)
                    throw new Exception("Please provide a SharePoint account.");
                if (string.IsNullOrEmpty(oAccount.ToString()))
                    throw new Exception("Please provide a SharePoint account.");
            }
            else
            {
                if (oAccount == null || oAccount == DBNull.Value) oAccount = string.Empty;
            }

            string email = oEmail.ToString();

            if (!string.IsNullOrEmpty(email))
            {
                SPListItemCollection items =
                    resourcePool.GetItems(new SPQuery {Query = string.Format(VALIDATE_EMAIL_QUERY, email)});

                if (items.Count > 0)
                {
                    SPListItem spListItem = items[0];

                    if (spListItem.ID != id)
                    {
                        string message = string.Format("{0} (ID: {1}) has the same email address.", spListItem.Title,
                                                       spListItem.ID);
                        throw new Exception(message);
                    }
                }
            }

            string title = oTitle.ToString();

            if (!string.IsNullOrEmpty(title))
            {
                SPListItemCollection items =
                    resourcePool.GetItems(new SPQuery {Query = string.Format(VALIDATE_DISPLAY_NAME_QUERY, title)});

                if (items.Count > 0)
                {
                    if (items[0].ID != id)
                    {
                        throw new Exception("Resource with the same name already exists.");
                    }
                }
            }

            string account = oAccount.ToString();

            if (!string.IsNullOrEmpty(account))
            {
                SPFieldUserValue spFieldUserValue = null;

                try
                {
                    spFieldUserValue = new SPFieldUserValue(_spWeb, account);
                }
                catch
                {
                }

                if (spFieldUserValue != null)
                {
                    SPListItemCollection items =
                        resourcePool.GetItems(new SPQuery
                            {
                                Query =
                                    string.Format(VALIDATE_ACCOUNT_QUERY,
                                                  spFieldUserValue.User.ID)
                            });

                    if (items.Count > 0)
                    {
                        SPListItem spListItem = items[0];
                        if (spListItem.ID != id)
                        {
                            string message = string.Format(@"{0} (ID: {1}) has the same SharePoint account.",
                                                           spListItem.Title, spListItem.ID);
                            throw new Exception(message);
                        }
                    }
                }
            }
        }

        #endregion Methods 
    }

    [DataContract]
    public class ProcessedResource
    {
        #region Constructors (1) 

        internal ProcessedResource()
        {
        }

        #endregion Constructors 

        #region Properties (5) 

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public bool IsNew
        {
            get { return string.IsNullOrEmpty(Id); }
            set { return; }
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Processed { get; set; }

        #endregion Properties 
    }

    public delegate void ImportProgressChangedEventHandler(object sender, ImportProgressChangedEventHandlerArgs args);

    public class ImportProgressChangedEventHandlerArgs : ProgressChangedEventArgs
    {
        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.ComponentModel.ProgressChangedEventArgs" /> class.
        /// </summary>
        /// <param name="progressPercentage">
        ///     The percentage of an asynchronous task that has been completed.
        /// </param>
        /// <param name="userState">
        ///     A unique user state.
        /// </param>
        public ImportProgressChangedEventHandlerArgs(int progressPercentage, object userState)
            : base(progressPercentage, userState)
        {
        }

        #endregion Constructors 
    }

    public delegate void ImportCompletedEventHandler(object sender, ImportCompletedEventHandlerArgs args);

    public class ImportCompletedEventHandlerArgs : AsyncCompletedEventArgs
    {
        #region Fields (2) 

        private readonly IList<ProcessedResource> _resources;
        private readonly string _result;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.ComponentModel.AsyncCompletedEventArgs" /> class.
        /// </summary>
        /// <param name="error">Any error that occurred during the asynchronous operation.</param>
        /// <param name="cancelled">A value indicating whether the asynchronous operation was canceled.</param>
        /// <param name="userState">
        ///     The optional user-supplied state object passed to the
        ///     <see cref="M:System.ComponentModel.BackgroundWorker.RunWorkerAsync(System.Object)" />
        ///     method.
        /// </param>
        /// <param name="result">The result.</param>
        /// <param name="resources">The resources.</param>
        public ImportCompletedEventHandlerArgs(Exception error, bool cancelled, object userState,
                                               string result, IList<ProcessedResource> resources)
            : base(error, cancelled, userState)
        {
            _result = result;
            _resources = resources;
        }

        #endregion Constructors 

        #region Properties (2) 

        public IList<ProcessedResource> Resources
        {
            get { return _resources; }
        }

        public string Result
        {
            get { return _result; }
        }

        #endregion Properties 
    }

    public class ResourceImporterState
    {
        #region Fields (4) 

        private readonly string _currentProcess;
        private readonly string _log;
        private readonly IList<ProcessedResource> _resources;
        private readonly int _step;

        #endregion Fields 

        #region Constructors (1) 

        public ResourceImporterState(int step, string currentProcess, string log, IList<ProcessedResource> resources)
        {
            _step = step;
            _currentProcess = currentProcess;
            _log = log;
            _resources = resources;
        }

        #endregion Constructors 

        #region Properties (4) 

        public string CurrentProcess
        {
            get { return _currentProcess; }
        }

        public string Log
        {
            get { return _log; }
        }

        public IList<ProcessedResource> Resources
        {
            get { return _resources; }
        }

        public int Step
        {
            get { return _step; }
        }

        #endregion Properties 
    }
}