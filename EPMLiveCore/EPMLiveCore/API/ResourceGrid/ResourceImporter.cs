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
using EPMLiveCore.Jobs;
using System.Threading;

namespace EPMLiveCore.API
{
    public class ResourceImporter
    {
        #region Fields (13) 

        private const char TAB_SEPERATOR = '-';

        //private const string VALIDATE_ACCOUNT_QUERY =
        //    @"<Where><Eq><FieldRef Name=""SharePointAccount"" LookupId=""true"" /><Value Type=""User"">{0}</Value></Eq></Where>";

        //private const string VALIDATE_DISPLAY_NAME_QUERY =
        //    @"<Where><Eq><FieldRef Name=""Title"" /><Value Type=""Text"">{0}</Value></Eq></Where>";

        private const string VALIDATE_EMAIL_QUERY =
            @"<Where><Eq><FieldRef Name=""Email"" /><Value Type=""Text"">{0}</Value></Eq></Where>";

        private readonly Act _act;
        private readonly DataTable _dtResources;
        private readonly string _fileId;
        private readonly bool _isOnline;
        private readonly SPWeb _spWeb;
        private string _currentProcess;
        
        private ResourceImportResult _dSMResult;
        private Int32 _totalRecords = 0, _successRecords = 0, _failedRecords = 0, _processedRecords = 0;

        public bool IsImportCancelled;

        #endregion

        #region Constructors (1) 

        public ResourceImporter(SPWeb spWeb, string data, bool isImportCancelled)
        {
            if (!spWeb.CurrentUser.IsSiteAdmin)
            {
                throw new Exception("You need to be a Site Collection Administrator in order to import resources.");
            }

            _spWeb = spWeb;
            _fileId = data;
            _dtResources = new DataTable();
            _currentProcess = string.Empty;
            _act = new Act(_spWeb);
            _isOnline = _act.IsOnline;
            _dSMResult = new ResourceImportResult();
        }

        #endregion Constructors         

        #region Delegates and Events (2) 

        // Events (2) 

        public event ImportCompletedEventHandler ImportCompleted;

        public event ImportProgressChangedEventHandler ImportProgressChanged;

        #endregion Delegates and Events 

        #region Methods (17) 

        // Public Methods (1) 

        public void ImportAsync()
        {
            Exception exception = null;
            try
            {
                if (!this.IsImportCancelled)
                {
                    LoadSpreadsheet();
                    ImportResources(); 
                }
            }
            catch (Exception e)
            {
                exception = e;
                LogImportMessage(e.Message, 2);
            }
            finally
            {
                string msg = string.Empty;
                if (!this.IsImportCancelled)
                { 
                    msg = String.Format("Import completed {0}!", exception != null ? "with errors" : "successfully");
                }
                else
                {
                    msg = String.Format("Import cancelled!");
                }
                
                LogImportMessage(msg, exception != null ? 1 : 0);
                RaiseImportCompletedEvent(exception);
            }
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
                if (!this.IsImportCancelled)
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
                                            if (val.Contains(","))
                                            {
                                                var collection = new SPFieldUserValueCollection();
                                                collection.AddRange(
                                                    val.Split(',')
                                                        .Select(u => u.Trim())
                                                        .Select(uv => GetUserValue(usersDict, uv)));
                                                value = collection;
                                            }
                                            else
                                            {
                                                value = GetUserValue(usersDict, val);
                                            }
                                            break;
                                        case SPFieldType.Lookup:
                                            //if (val.Contains(","))
                                            //{
                                            //    var collection = new SPFieldLookupValueCollection();
                                            //    collection.AddRange(
                                            //        val.Split(',')
                                            //            .Select(v => v.Trim())
                                            //            .Select(lv => new SPFieldLookupValue(lookupFieldDict[col][lv], lv)));
                                            //    value = collection;
                                            //}
                                            //else
                                            //{
                                                value = new SPFieldLookupValue(lookupFieldDict[col][val], val);
                                            //}
                                            break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    string message = string.Format("Resource: {0} (ID: {1}). Field: {2} Error: {3}",
                                        row["Title"], row["ID"], col, e.Message);
                                    LogImportMessage(message, 2);
                                }
                            }
                        }

                        row[col] = value;
                    }
                }
                else
                {
                    break;
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

            var errors = new List<string>();

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
                        catch { }

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
                        catch { }

                        continue;
                    }

                    if (spField.Type != SPFieldType.Lookup) continue;

                    lookupFieldDict.Add(columnName, new Dictionary<string, int>());

                    var spFieldLookup = ((SPFieldLookup)spField);

                    SPListItemCollection spListItemCollection =
                        _spWeb.Lists[new Guid(spFieldLookup.LookupList)].GetItems("ID", spFieldLookup.LookupField);

                    foreach (SPListItem spListItem in spListItemCollection)
                    {
                        string lookupValue = string.Empty;

                        try
                        {
                            lookupValue = spListItem[spFieldLookup.LookupField].ToString();
                            lookupFieldDict[columnName].Add(lookupValue, (int)spListItem["ID"]);
                        }
                        catch (ArgumentException exception)
                        {
                            errors.Add(string.Format(@"{0} ({1}): {2}", columnName, lookupValue, exception.Message));
                        }
                    }
                }
                catch { }
            }

            if (errors.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, errors.ToArray()));
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
                catch { }
            }

            return usersDict;
        }

        private SPFieldUserValue GetUserValue(Dictionary<string, object[]> usersDict, string val)
        {
            SPFieldUserValue value = null;

            try
            {
                value = new SPFieldUserValue(_spWeb, (int) usersDict[val][0], val);
            }
            catch
            {
                bool found = false;

                foreach (var pair in usersDict.Where(p => p.Value[1].ToString().Equals(val)))
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

            return value;
        }

        private void ImportResources()
        {
            LogImportMessage("Importing Resources", 0);

            foreach (DataRow row in _dtResources.Rows)
            {
                if (!this.IsImportCancelled)
                {
                    string message = string.Empty;

                    try
                    {
                        message = string.Format("Importing resource {1} of {2}: {0} . . .", (string)row["Title"],
                            _processedRecords + 1, _totalRecords);

                        RaiseImportProgressChangedEvent(message);

                        var isGeneric = (bool)row["Generic"];

                        if (string.IsNullOrEmpty(row["ID"].ToString()))
                        {
                            AddNewResource(row, isGeneric);
                        }
                        else
                        {
                            UpdateResource(row, isGeneric);
                        }

                        _successRecords++;
                        _processedRecords++;
                        RaiseImportProgressChangedEvent(_currentProcess);
                    }
                    catch (Exception e)
                    {
                        LogImportMessage("FAILURE. Reason: " + e.Message, 2);
                        _failedRecords++;
                        _processedRecords++;
                        RaiseImportProgressChangedEvent(_currentProcess);
                    }
                    finally
                    {
                        _currentProcess = message;
                        RaiseImportProgressChangedEvent(_currentProcess);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void LoadSpreadsheet()
        {
            if (!this.IsImportCancelled)
            {
                LogImportMessage("Loading Spreadsheet", 0);

                RaiseImportProgressChangedEvent("Loading Spreadsheet");

                using (var epmLiveFileStore = new EPMLiveFileStore(_spWeb))
                {
                    using (Stream stream = epmLiveFileStore.GetStream(_fileId))
                    {
                        if (!this.IsImportCancelled)
                        {
                            ParseExcelResources(stream); 
                        }
                    }

                    epmLiveFileStore.Delete(_fileId);
                }

                if (!this.IsImportCancelled)
                {
                    BuildResourceTable(); 
                }

                _totalRecords = _dtResources.Rows.Count;
            }
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
                    if (!this.IsImportCancelled)
                    {
                        rowIndex++;

                        if (rowIndex == 1)
                        {
                            foreach (Cell cell in row)
                            {
                                string columnName = GetCellValue(document, cell);
                                _dtResources.Columns.Add(columnName, typeof(object));

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
                            try
                            {
                                Cell cell = row.Descendants<Cell>().ElementAt(i);

                                string columnName = fieldCellDict[GetCellReference(cell)];
                                string value = GetCellValue(document, cell);

                                dataRow[columnName] = value;

                                if (!string.IsNullOrEmpty(value)) isEmpty = false;
                            }
                            catch { }
                        }

                        if (!isEmpty) _dtResources.Rows.Add(dataRow);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void UpdateItem(DataRow row, ICollection<string> lockedColumns, SPList spList, SPListItem spListItem,
            bool isGeneric)
        {
            if (!this.IsImportCancelled)
            {
                foreach (
                        string columnName in
                            _dtResources.Columns.Cast<DataColumn>()
                                .Select(c => c.ColumnName)
                                .Where(c => !lockedColumns.Contains(c)))
                {
                    try
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
                                                ((DateTime)value).ToUniversalTime());
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
                    }
                    catch { }
                }

                if (isGeneric) spListItem["Title"] = spListItem["Title"];

                spListItem.Update(); 
            }
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
                catch { }

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

            //EPMLCID-4783: can't import a new user with same first and last name as existing user in resource pool
            //Keep this code as commented reason is that if in future we need to validate user based on SPAccount/Title then we can uncomment this piece of code.

            //string title = oTitle.ToString();

            //if (!string.IsNullOrEmpty(title))
            //{
            //    SPListItemCollection items =
            //        resourcePool.GetItems(new SPQuery {Query = string.Format(VALIDATE_DISPLAY_NAME_QUERY, title)});

            //    if (items.Count > 0)
            //    {
            //        if (items[0].ID != id)
            //        {
            //            throw new Exception("Resource with the same name already exists.");
            //        }
            //    }
            //}

            //string account = oAccount.ToString();

            //if (!string.IsNullOrEmpty(account))
            //{
            //    SPFieldUserValue spFieldUserValue = null;

            //    try
            //    {
            //        spFieldUserValue = new SPFieldUserValue(_spWeb, account);
            //    }
            //    catch { }

            //    if (spFieldUserValue != null)
            //    {
            //        SPListItemCollection items =
            //            resourcePool.GetItems(new SPQuery
            //            {
            //                Query =
            //                    string.Format(VALIDATE_ACCOUNT_QUERY,
            //                        spFieldUserValue.User.ID)
            //            });

            //        if (items.Count > 0)
            //        {
            //            SPListItem spListItem = items[0];
            //            if (spListItem.ID != id)
            //            {
            //                string message = string.Format(@"{0} (ID: {1}) has the same SharePoint account.",
            //                    spListItem.Title, spListItem.ID);
            //                throw new Exception(message);
            //            }
            //        }
            //    }
            //}
        }

        private void LogImportMessage(string message, Int32 messageType)
        {
            //  0 Info   
            //  1 Warning
            //  2 Error
            ResourceImportMessage dSMMessage = new ResourceImportMessage();
            dSMMessage.Kind = messageType;
            dSMMessage.Message = message;
            dSMMessage.DateTime = DateTime.Now;

            if (messageType == 0)
            {
                _dSMResult.Log.InfoCount++;
            }
            else if (messageType == 1)
            {
                _dSMResult.Log.WarningCount++;
            }
            else if (messageType == 2)
            {
                _dSMResult.Log.ErrorCount++;
            }

            _dSMResult.Log.Messages.Add(dSMMessage);
            dSMMessage = null;
        }

        private void RaiseImportProgressChangedEvent(String currentProcess)
        {
            Int32 percentage = (_processedRecords == 0 ? 0 : (_processedRecords * 100) / _totalRecords);
            _dSMResult.CurrentProcess = (percentage == 100 ? string.Format("Import {0}. Check the log for more details.", this.IsImportCancelled? "Cancelled" : "Completed") : currentProcess);
            _dSMResult.TotalRecords = _totalRecords;
            _dSMResult.ProcessedRecords = _processedRecords;
            _dSMResult.SuccessRecords = _successRecords;
            _dSMResult.FailedRecords = _failedRecords;
            _dSMResult.PercentComplete = percentage;
            ImportProgressChanged(this, new ImportProgressChangedEventHandlerArgs(_processedRecords, _dSMResult));
        }

        private void RaiseImportCompletedEvent(Exception exception)
        {            
            _dSMResult.CurrentProcess = String.Format("Import {0}{1}. Check the log for more details.", this.IsImportCancelled? "Cancelled" : "Completed", exception == null ? "" : " with errors");
            _dSMResult.TotalRecords = _totalRecords;
            _dSMResult.ProcessedRecords = _processedRecords;
            _dSMResult.SuccessRecords = _successRecords;
            _dSMResult.FailedRecords = _failedRecords;
            _dSMResult.PercentComplete = 100;
            ImportCompleted(this, new ImportCompletedEventHandlerArgs(exception, false, _dSMResult));
        }        

        #endregion Methods
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
            : base(progressPercentage, userState) { }

        #endregion Constructors 
    }

    public delegate void ImportCompletedEventHandler(object sender, ImportCompletedEventHandlerArgs args);

    public class ImportCompletedEventHandlerArgs : AsyncCompletedEventArgs
    {
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
        public ImportCompletedEventHandlerArgs(Exception error, bool cancelled, object userState)
            : base(error, cancelled, userState)
        {            
        }

        #endregion Constructors         
    }    
}