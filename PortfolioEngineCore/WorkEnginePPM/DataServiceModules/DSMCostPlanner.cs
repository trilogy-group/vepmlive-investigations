using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using PortfolioEngineCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Utilities=WorkEnginePPM.Core.ResourceManagement.Utilities;

namespace WorkEnginePPM.DataServiceModules
{
    public class DSMCostPlanner : PFEBase
    {
        #region Private Variables

        private SPWeb _spWeb;
        private string _fileId;
        private string _listId;
        private DSMResult _dSMResult;

        private const string colCalendar = "calendar";
        private const string colProject = "piname";
        private const string colCostType = "costtype";
        private const string colCostCategory = "costcategory";
        private const string colPeriod = "period";
        private const string colCostAmount = "costamount";
        private const string colQTY = "qty";
        private const string colFTE = "fte";
        private const string colDetailRow = "detailrow";
        private const string colOC_01 = "oc_01";
        private const string colOC_02 = "oc_02";
        private const string colOC_03 = "oc_03";
        private const string colOC_04 = "oc_04";
        private const string colOC_05 = "oc_05";
        private const string colTEXT_01 = "text_01";
        private const string colTEXT_02 = "text_02";
        private const string colTEXT_03 = "text_03";
        private const string colTEXT_04 = "text_04";
        private const string colTEXT_05 = "text_05";

        private DataTable _dtInsertCostData;

        private DataView _dvRawData;
        private DataView _dvCostBreakdowns;
        private DataView _dvProjects;
        private DataView _dvCostTypes;
        private DataView _dvCostCategories;
        private DataView _dvPeriods;
        private DataView _dvCostCustomFields;
        private DataView _dvCostBreakdownAttribs;

        private Int32 _totalRecords = 0, _successRecords = 0, _failedRecords = 0, _processedRecords = 0;

        private SPContext context;
        private SPRegionalSettings spRegionalSettings;
        private string dateSeparator;
        private SPCalendarOrderType calendarOrderType;

        #endregion

        #region Public Variables

        public event DSMProgressChangedEventHandler DSMProgressChanged;
        public event DSMCompletedEventHandler DSMCompleted;

        #endregion

        public DSMCostPlanner(SPWeb spWeb, string fileId, string listId, string basepath, string username, string pid, string company, string dbcnstring, SecurityLevels secLevel, bool bDebug = false)
            : base(basepath, username, pid, company, dbcnstring, secLevel, bDebug)
        {

            _spWeb = spWeb;
            _fileId = fileId;
            _listId = listId;

            if (!_spWeb.CurrentUser.IsSiteAdmin)
            {
                throw new Exception("You need to be a Site Collection Administrator in order to import cost planner data.");
            }

            _dSMResult = new DSMResult();

            _dtInsertCostData = new DataTable();
            _dtInsertCostData.Columns.Add("calendarid", typeof(Int32));
            _dtInsertCostData.Columns.Add("calendarname", typeof(String));
            _dtInsertCostData.Columns.Add("projectid", typeof(Int32));
            _dtInsertCostData.Columns.Add("projectname", typeof(String));
            _dtInsertCostData.Columns.Add("costtypeid", typeof(Int32));
            _dtInsertCostData.Columns.Add("costtypename", typeof(String));
            _dtInsertCostData.Columns.Add("bc_uid", typeof(Int32));
            _dtInsertCostData.Columns.Add("costcategoryname", typeof(String));
            _dtInsertCostData.Columns.Add("bc_seq", typeof(Int32));
            _dtInsertCostData.Columns.Add("rt_uid", typeof(Int32));
            _dtInsertCostData.Columns.Add("oc_01", typeof(Int32));
            _dtInsertCostData.Columns.Add("oc_02", typeof(Int32));
            _dtInsertCostData.Columns.Add("oc_03", typeof(Int32));
            _dtInsertCostData.Columns.Add("oc_04", typeof(Int32));
            _dtInsertCostData.Columns.Add("oc_05", typeof(Int32));
            _dtInsertCostData.Columns.Add("text_01", typeof(String));
            _dtInsertCostData.Columns.Add("text_02", typeof(String));
            _dtInsertCostData.Columns.Add("text_03", typeof(String));
            _dtInsertCostData.Columns.Add("text_04", typeof(String));
            _dtInsertCostData.Columns.Add("text_05", typeof(String));
            _dtInsertCostData.Columns.Add("bd_period", typeof(Int32));
            _dtInsertCostData.Columns.Add("bdperiodname", typeof(String));
            _dtInsertCostData.Columns.Add("bd_value", typeof(Double));
            _dtInsertCostData.Columns.Add("bd_cost", typeof(Double));
            _dtInsertCostData.Columns.Add("isdirty", typeof(Boolean));
            _dtInsertCostData.Columns.Add("iscustomfielddirty", typeof(Boolean));
            _dtInsertCostData.Columns.Add("rowerror", typeof(String));
            _dtInsertCostData.Columns.Add("isdefault", typeof(Boolean));

            context = SPContext.GetContext(_spWeb);
            spRegionalSettings = _spWeb.CurrentUser.RegionalSettings ?? context.RegionalSettings;
            dateSeparator = spRegionalSettings.DateSeparator;
            calendarOrderType = (SPCalendarOrderType)spRegionalSettings.DateFormat;
        }

        public void ImportData()
        {
            Exception exception = null;
            try
            {
                RaiseDSMProgressChangedEvent("Loading CSV file...");

                FillDataViewFromCSVFile();
                FillMasterRecordDataViews();

                RaiseDSMProgressChangedEvent("Processing CSV file...");

                String calendarValue = "", projectValue = "", costTypeValue = "", costCategoryFullName = "", costCategoryValue = "", periodValue = "", detailRowValue = "";
                Int32 oc_01Value = 0, oc_02Value = 0, oc_03Value = 0, oc_04Value = 0, oc_05Value = 0;
                String text_01Value = "", text_02Value = "", text_03Value = "", text_04Value = "", text_05Value = "";
                Double qty = 0, costAmount = 0;
                Int32 calendarId = 0, projectId = 0, costTypeId = 0, costCategoryId = 0, periodId = 0, detailRowId = 0;
                List<String> customIdentityValues = new List<string>();

                #region Process Rows & Validate

                foreach (DataRowView row in _dvRawData)
                {
                    Boolean isCalendarIdDirty = false;
                    Boolean isProjectIdDirty = false;
                    Boolean isCostTypeIdDirty = false;
                    Boolean isCostCategoryIdDirty = false;
                    Boolean isPeriodIdDirty = false;
                    Boolean isRowDirty = false;
                    StringBuilder rowError = new StringBuilder();
                    Boolean isCustomFieldDirty = false;
                    //Boolean isCustomFieldInvalid = false;
                    Boolean doCheckForIdentity = false;

                    foreach (DataColumn col in _dvRawData.Table.Columns)
                    {
                        switch (col.ColumnName)
                        {
                            case colCalendar:
                                if (calendarValue != Convert.ToString(row[col.ColumnName]))
                                {
                                    calendarValue = Convert.ToString(row[col.ColumnName]);
                                    calendarId = GetMasterRecordId(col.ColumnName, calendarValue, "0", null);
                                    customIdentityValues.Clear();
                                }
                                if (calendarId == 0)
                                {
                                    isCalendarIdDirty = true;
                                    rowError.Append(FormatMessage(calendarValue, null, null, null, null, 0, 0, "Invalid Calendar."));
                                }
                                break;
                            case colProject:
                                if (projectValue != Convert.ToString(row[col.ColumnName]))
                                {
                                    projectValue = Convert.ToString(row[col.ColumnName]);
                                    projectId = GetMasterRecordId(col.ColumnName, projectValue, _listId, null);
                                    customIdentityValues.Clear();
                                }
                                if (projectId == 0)
                                {
                                    isProjectIdDirty = true;
                                    rowError.Append(FormatMessage(calendarValue, projectValue, null, null, null, 0, 0, "Invalid Project."));
                                }
                                break;
                            case colCostType:
                                if (costTypeValue != Convert.ToString(row[col.ColumnName]))
                                {
                                    costTypeValue = Convert.ToString(row[col.ColumnName]);
                                    costTypeId = GetMasterRecordId(col.ColumnName, costTypeValue, "0", null);
                                    customIdentityValues.Clear();
                                }
                                if (costTypeId == 0)
                                {
                                    isCostTypeIdDirty = true;
                                    rowError.Append(FormatMessage(calendarValue, projectValue, costTypeValue, null, null, 0, 0, "Invalid Cost type."));
                                }
                                break;
                            case colCostCategory:
                                if (costCategoryFullName != Convert.ToString(row[col.ColumnName]))
                                {
                                    string[] costCategoryArray = Convert.ToString(row[col.ColumnName]).Split('.');
                                    costCategoryFullName = Convert.ToString(row[col.ColumnName]);
                                    costCategoryValue = costCategoryArray[costCategoryArray.Length - 1];
                                    costCategoryId = GetMasterRecordId(col.ColumnName, costCategoryValue, costTypeId.ToString(), costCategoryArray);
                                    customIdentityValues.Clear();
                                    if (costCategoryId == 0)
                                    {
                                        isCostCategoryIdDirty = true;
                                        rowError.Append(FormatMessage(calendarValue, projectValue, costTypeValue, String.Join(" > ", costCategoryArray), null, 0, 0, "Invalid Cost Category."));
                                    }
                                }
                                break;
                            case colPeriod:
                                if (periodValue != Convert.ToString(row[col.ColumnName]))
                                {
                                    periodValue = Convert.ToString(row[col.ColumnName]);
                                    periodId = GetMasterRecordId(col.ColumnName, periodValue, calendarId.ToString(), null);
                                }
                                if (periodId == 0)
                                {
                                    isPeriodIdDirty = true;
                                    rowError.Append(FormatMessage(calendarValue, projectValue, costTypeValue, costCategoryValue, periodValue, 0, 0, "Invalid Period."));
                                }
                                break;
                            case colDetailRow:
                                if (detailRowValue != Convert.ToString(row[col.ColumnName]))
                                {
                                    detailRowValue = Convert.ToString(row[col.ColumnName]);
                                    if (String.IsNullOrEmpty(detailRowValue))
                                    {
                                        detailRowId = 0;
                                    }
                                    else
                                    {
                                        detailRowId = Convert.ToInt32(row[col.ColumnName]);
                                    }
                                    doCheckForIdentity = true;
                                }
                                break;
                            case colQTY:
                                if (!string.IsNullOrEmpty(Convert.ToString(row[col.ColumnName])))
                                {
                                    qty = Convert.ToDouble(row[col.ColumnName]);
                                    costAmount = qty * GetRateOrFTEConversion(calendarId, costCategoryId, periodId, true);
                                }
                                break;
                            case colFTE:
                                if (!string.IsNullOrEmpty(Convert.ToString(row[col.ColumnName])))
                                {
                                    qty = Convert.ToDouble(row[col.ColumnName]);
                                    costAmount = GetRateOrFTEConversion(calendarId, costCategoryId, periodId, false);
                                    qty = qty * (costAmount / 100);
                                }
                                break;
                            case colCostAmount:
                                if (!string.IsNullOrEmpty(Convert.ToString(row[col.ColumnName])))
                                {
                                    costAmount = Convert.ToDouble(row[col.ColumnName]);
                                }
                                break;
                            default:

                                _dvCostCustomFields.RowFilter = String.Empty;
                                _dvCostCustomFields.RowFilter = string.Format("ct_id={0} and fa_name='{1}'", costTypeId, col.ColumnName);
                                if (_dvCostCustomFields.Count > 0)
                                {
                                    Int32 cfEditable = Convert.ToInt32(_dvCostCustomFields[0]["cf_editable"]);
                                    Int32 cfVisible = Convert.ToInt32(_dvCostCustomFields[0]["cf_visible"]);
                                    Int32 cfRequired = Convert.ToInt32(_dvCostCustomFields[0]["cf_required"]);
                                    Int32 cfIdentity = Convert.ToInt32(_dvCostCustomFields[0]["cf_identity"]);

                                    Int32 value;

                                    if (cfEditable == 0 && cfVisible == 0)
                                    {
                                        if (Int32.TryParse(Convert.ToString(row[col.ColumnName]), out value))
                                        {
                                            isCustomFieldDirty = Convert.ToInt32(row[col.ColumnName]) > 0;
                                        }
                                        else
                                        {
                                            isCustomFieldDirty = !String.IsNullOrEmpty(Convert.ToString(row[col.ColumnName]));
                                        }
                                        if (isCustomFieldDirty)
                                        {
                                            rowError.Append(FormatMessage(calendarValue, projectValue, costTypeValue, costCategoryValue, null, 0, 0, String.Format("Data cannot be imported as {0} is not editable or visible", col.ColumnName)));
                                        }
                                    }

                                    if (cfRequired == 1)
                                    {
                                        if (Int32.TryParse(Convert.ToString(row[col.ColumnName]), out value))
                                        {
                                            isCustomFieldDirty = Convert.ToInt32(row[col.ColumnName]) == 0;
                                        }
                                        else
                                        {
                                            isCustomFieldDirty = String.IsNullOrEmpty(Convert.ToString(row[col.ColumnName]));
                                        }
                                        if (isCustomFieldDirty)
                                        {
                                            rowError.Append(FormatMessage(calendarValue, projectValue, costTypeValue, costCategoryValue, null, 0, 0, String.Format("Data cannot be imported as {0} is required.", col.ColumnName)));
                                        }
                                    }


                                    if (!string.IsNullOrEmpty(Convert.ToString(row[col.ColumnName])))
                                    {
                                        if (cfIdentity == 1 && doCheckForIdentity && detailRowId > 0)
                                        {
                                            String key = String.Format("{0}-{1}-{2}-{3}-{4}", calendarId, projectId, costTypeId, costCategoryId, row[col.ColumnName]);
                                            if (customIdentityValues.Contains(key) == false)
                                            {
                                                customIdentityValues.Add(key);
                                            }
                                            else
                                            {
                                                isCustomFieldDirty = true;
                                                rowError.Append(FormatMessage(calendarValue, projectValue, costTypeValue, costCategoryValue, null, 0, 0, String.Format("Data cannot be imported as {0} has two or more rows with the same identity.", col.ColumnName)));
                                            }
                                        }

                                        switch (Convert.ToInt32(_dvCostCustomFields[0]["fa_field_id"]))
                                        {
                                            case 11801:
                                                oc_01Value = Convert.ToInt32(row[col.ColumnName]);
                                                break;
                                            case 11802:
                                                oc_02Value = Convert.ToInt32(row[col.ColumnName]);
                                                break;
                                            case 11803:
                                                oc_03Value = Convert.ToInt32(row[col.ColumnName]);
                                                break;
                                            case 11804:
                                                oc_04Value = Convert.ToInt32(row[col.ColumnName]);
                                                break;
                                            case 11805:
                                                oc_05Value = Convert.ToInt32(row[col.ColumnName]);
                                                break;
                                            case 11811:
                                                text_01Value = Convert.ToString(row[col.ColumnName]);
                                                break;
                                            case 11812:
                                                text_02Value = Convert.ToString(row[col.ColumnName]);
                                                break;
                                            case 11813:
                                                text_03Value = Convert.ToString(row[col.ColumnName]);
                                                break;
                                            case 11814:
                                                text_04Value = Convert.ToString(row[col.ColumnName]);
                                                break;
                                            case 11815:
                                                text_05Value = Convert.ToString(row[col.ColumnName]);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                //else
                                //{
                                //    isCustomFieldInvalid = true;
                                //    rowError.Append(FormatMessage(calendarValue, projectValue, costTypeValue, null, null, 0, 0, String.Format("Data cannot be imported as {0} is invalid custom field.", col.ColumnName)));
                                //}
                                break;
                        }
                    }

                    //pending code for rateid
                    isRowDirty = isCalendarIdDirty || isProjectIdDirty || isCostTypeIdDirty || isCostCategoryIdDirty || isPeriodIdDirty;//|| isCustomFieldInvalid;
                    _dtInsertCostData.Rows.Add(new object[] { calendarId, calendarValue, projectId, projectValue, costTypeId, costTypeValue, costCategoryId, costCategoryValue, detailRowId, 0, oc_01Value, oc_02Value, oc_03Value, oc_04Value, oc_05Value, text_01Value, text_02Value, text_03Value, text_04Value, text_05Value, periodId, periodValue, qty, costAmount, isRowDirty, isCustomFieldDirty, rowError.ToString(), false });

                    qty = costAmount = 0;
                    oc_01Value = oc_02Value = oc_03Value = oc_04Value = oc_05Value = 0;
                    text_01Value = text_02Value = text_03Value = text_04Value = text_05Value = "";

                }


                #endregion

                #region Save Rows

                var costDataQuery = from row in _dtInsertCostData.AsEnumerable()
                                    group row by new { calendarid = row["calendarid"], calendarname = row["calendarname"], projectid = row["projectid"], projectname = row["projectname"], costtypeid = row["costtypeid"], costtypename = row["costtypename"] } into grp
                                    select new
                                    {
                                        key = grp.Key
                                    };
                foreach (var grp in costDataQuery)
                {
                    calendarId = Convert.ToInt32(grp.key.calendarid);
                    calendarValue = Convert.ToString(grp.key.calendarname);
                    projectId = Convert.ToInt32(grp.key.projectid);
                    projectValue = Convert.ToString(grp.key.projectname);
                    costTypeId = Convert.ToInt32(grp.key.costtypeid);
                    costTypeValue = Convert.ToString(grp.key.costtypename);

                    if (calendarId == 0 || projectId == 0 || costTypeId == 0)
                    {
                        DataRow[] invalidRows = _dtInsertCostData.Select(string.Format("calendarid={0} and calendarname='{1}' and projectid={2} and projectname='{3}' and costtypeid={4} and costtypename='{5}'", calendarId, calendarValue, projectId, projectValue, costTypeId, costTypeValue));
                        if (invalidRows != null && invalidRows.Count() > 0)
                        {
                            _processedRecords = _processedRecords + invalidRows.Count();
                            _failedRecords = _failedRecords + invalidRows.Count();
                            LogDSMMessage(Convert.ToString(invalidRows[0]["rowerror"]), 1);
                            RaiseDSMProgressChangedEvent("Importing Data...");
                        }
                    }
                    else
                    {

                        #region Filter and Save Rows

                        DataRow[] invalidRows = _dtInsertCostData.Select(string.Format("calendarid={0} and projectid={1} and costtypeid={2} and iscustomfielddirty='True'", calendarId, projectId, costTypeId));

                        if (invalidRows != null && invalidRows.Count() > 0)
                        {
                            Int32 failCount = (from row in _dtInsertCostData.AsEnumerable()
                                               where
                                               row["calendarid"].Equals(calendarId) &&
                                               row["projectid"].Equals(projectId) &&
                                               row["costtypeid"].Equals(costTypeId)
                                               select row).Count();
                            _processedRecords = _processedRecords + failCount;
                            _failedRecords = _failedRecords + failCount;
                            LogDSMMessage(Convert.ToString(invalidRows[0]["rowerror"]), 1);
                            RaiseDSMProgressChangedEvent("Importing Data...");
                        }
                        else
                        {
                            _dvCostCategories.RowFilter = String.Empty;
                            _dvCostCategories.RowFilter = String.Format("ct_id={0}", costTypeId);
                            foreach (DataRowView dataRowView in _dvCostCategories)
                            {
                                //pending code for rateid
                                var costCategoryRowCount = (from row in _dtInsertCostData.AsEnumerable()
                                                            where
                                                            row["calendarid"].Equals(calendarId) &&
                                                            row["projectid"].Equals(projectId) &&
                                                            row["costtypeid"].Equals(costTypeId) &&
                                                            row["bc_uid"].Equals(dataRowView["bc_uid"])
                                                            select row).Count();
                                if (costCategoryRowCount == 0)
                                    _dtInsertCostData.Rows.Add(new object[] { calendarId, calendarValue, projectId, projectValue, costTypeId, costTypeValue, dataRowView["bc_uid"], dataRowView["bc_name"], 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", 0, "", 0, 0, false, false, "", true });

                            }

                            DataTable dtInsertCostDetails = new DataTable();
                            dtInsertCostDetails.Columns.Add("BC_UID");
                            dtInsertCostDetails.Columns.Add("BC_SEQ");
                            dtInsertCostDetails.Columns.Add("RT_UID");
                            dtInsertCostDetails.Columns.Add("OC_01");
                            dtInsertCostDetails.Columns.Add("OC_02");
                            dtInsertCostDetails.Columns.Add("OC_03");
                            dtInsertCostDetails.Columns.Add("OC_04");
                            dtInsertCostDetails.Columns.Add("OC_05");
                            dtInsertCostDetails.Columns.Add("TEXT_01");
                            dtInsertCostDetails.Columns.Add("TEXT_02");
                            dtInsertCostDetails.Columns.Add("TEXT_03");
                            dtInsertCostDetails.Columns.Add("TEXT_04");
                            dtInsertCostDetails.Columns.Add("TEXT_05");

                            DataTable dtInsertCostDetailValues = new DataTable();
                            dtInsertCostDetailValues.Columns.Add("BC_UID");
                            dtInsertCostDetailValues.Columns.Add("BC_SEQ");
                            dtInsertCostDetailValues.Columns.Add("BD_PERIOD");
                            dtInsertCostDetailValues.Columns.Add("BD_VALUE");
                            dtInsertCostDetailValues.Columns.Add("BD_COST");

                            var insertCostDetailsQuery = from row in _dtInsertCostData.AsEnumerable()
                                                         where
                                                         row["calendarid"].Equals(calendarId) &&
                                                         row["projectid"].Equals(projectId) &&
                                                         row["costtypeid"].Equals(costTypeId)
                                                         group row by new
                                                         {
                                                             calendarid = row["calendarid"],
                                                             calendarname = row["calendarname"],
                                                             projectid = row["projectid"],
                                                             projectname = row["projectname"],
                                                             costtypeid = row["costtypeid"],
                                                             costtypename = row["costtypename"],
                                                             bc_uid = row["bc_uid"],
                                                             costcategoryname = row["costcategoryname"],
                                                             bc_seq = row["bc_seq"],
                                                             rt_uid = row["rt_uid"],
                                                             oc_01 = row["oc_01"],
                                                             oc_02 = row["oc_02"],
                                                             oc_03 = row["oc_03"],
                                                             oc_04 = row["oc_04"],
                                                             oc_05 = row["oc_05"],
                                                             text_01 = row["text_01"],
                                                             text_02 = row["text_02"],
                                                             text_03 = row["text_03"],
                                                             text_04 = row["text_04"],
                                                             text_05 = row["text_05"],
                                                             isdirty = row["isdirty"],
                                                             iscustomfielddirty = row["iscustomfielddirty"]
                                                         } into icdGrp
                                                         select new
                                                         {
                                                             key = icdGrp.Key
                                                         };

                            foreach (var icdGrp in insertCostDetailsQuery)
                            {
                                Boolean isDirty = Convert.ToBoolean(icdGrp.key.isdirty);
                                if (!isDirty)
                                {
                                    dtInsertCostDetails.Rows.Add(new object[] { 
                                    icdGrp.key.bc_uid, 
                                    icdGrp.key.bc_seq, 
                                    icdGrp.key.rt_uid, 
                                    icdGrp.key.oc_01, 
                                    icdGrp.key.oc_02, 
                                    icdGrp.key.oc_03, 
                                    icdGrp.key.oc_04, 
                                    icdGrp.key.oc_05, 
                                    icdGrp.key.text_01, 
                                    icdGrp.key.text_02, 
                                    icdGrp.key.text_03, 
                                    icdGrp.key.text_04, 
                                    icdGrp.key.text_05
                                });
                                }
                            }

                            var insertCostDetailValueQuery = from row in _dtInsertCostData.AsEnumerable()
                                                             where
                                                             row["calendarid"].Equals(calendarId) &&
                                                             row["projectid"].Equals(projectId) &&
                                                             row["costtypeid"].Equals(costTypeId)
                                                             select row;

                            foreach (DataRow row in insertCostDetailValueQuery)
                            {
                                Boolean isDirty = Convert.ToBoolean(row["isdirty"]);
                                if (isDirty)
                                {
                                    if (!Convert.ToBoolean(row["isdefault"]))
                                    {
                                        _failedRecords = _failedRecords + 1;
                                        LogDSMMessage(Convert.ToString(row["rowerror"]), 1);
                                    }
                                }
                                else
                                {
                                    if (!Convert.ToBoolean(row["isdefault"]))
                                    {
                                        dtInsertCostDetailValues.Rows.Add(new object[] { row["bc_uid"], row["bc_seq"], row["bd_period"], row["bd_value"], row["bd_cost"] });
                                        _successRecords = _successRecords + 1;
                                        LogDSMMessage(FormatMessage(Convert.ToString(row["calendarname"]), Convert.ToString(row["projectname"]), Convert.ToString(row["costtypename"]), Convert.ToString(row["costcategoryname"]), Convert.ToString(row["bdperiodname"]), Convert.ToDouble(row["bd_value"]), Convert.ToDouble(row["bd_cost"]), "Processed."), 0);
                                    }
                                }
                                if (!Convert.ToBoolean(row["isdefault"]))
                                {
                                    _processedRecords = _processedRecords + 1;
                                }
                            }

                            if (SaveRows(calendarId, projectId, costTypeId, dtInsertCostDetails, dtInsertCostDetailValues))
                            {
                                LogDSMMessage(FormatMessage(calendarValue, projectValue, costTypeValue, null, null, 0, 0, "Data import succeeded."), 0);
                            }
                            else
                            {
                                LogDSMMessage(FormatMessage(calendarValue, projectValue, costTypeValue, null, null, 0, 0, "Data import failed."), 1);
                            }

                            RaiseDSMProgressChangedEvent("Importing Data...");
                        }

                        #endregion

                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                exception = ex;
                LogDSMMessage(ex.Message, 2);
            }
            finally
            {
                LogDSMMessage(String.Format("Import completed {0}!", exception != null ? "with errors" : "successfully"), exception != null ? 1 : 0);
                RaiseDSMCompletedEvent(exception);
            }
        }

        private Boolean SaveRows(Int32 calendarId, Int32 projectId, Int32 costTypeId, DataTable dtInsertCostDetails, DataTable dtInsertCostDetailValues)
        {
            Boolean returnValue = false;
            try
            {
                Int32 rowsAffected;
                String sResult;
                _dba.Open();
                _dba.BeginTransaction();
                if (dbaEditCosts.DeleteCostDetails(_dba, calendarId, costTypeId, projectId, out rowsAffected) == StatusEnum.rsSuccess)
                {
                    if (dbaEditCosts.DeleteCostDetailValues(_dba, calendarId, costTypeId, projectId, dtInsertCostDetailValues) == StatusEnum.rsSuccess)
                    {
                        if (dbaEditCosts.InsertCostDetails(_dba, calendarId, costTypeId, projectId, dtInsertCostDetails) == StatusEnum.rsSuccess)
                        {
                            if (dbaEditCosts.InsertCostDetailValues(_dba, calendarId, costTypeId, projectId, dtInsertCostDetailValues) == StatusEnum.rsSuccess)
                            {
                                _dba.CommitTransaction();
                                dbaCCV.CalculateCostValues(_dba, costTypeId, calendarId, projectId, out sResult);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (_dba != null)
                {
                    if (_dba.Status != StatusEnum.rsSuccess)
                    {
                        _dba.RollbackTransaction();
                        returnValue = false;
                    }
                    else
                    {
                        _dba.CommitTransaction();
                        returnValue = true;
                    }
                    _dba.Close();
                }
            }

            return returnValue;
        }

        private Int32 GetMasterRecordId(string columnName, string columnValue, string foreignKeyId, string[] costCategoryArray)
        {
            Int32 returnValue = 0;
            switch (columnName)
            {
                case colCalendar:
                    _dvCostBreakdowns.RowFilter = String.Empty;
                    _dvCostBreakdowns.RowFilter = string.Format("cb_name='{0}'", columnValue);
                    if (_dvCostBreakdowns.Count > 0)
                    {
                        returnValue = Convert.ToInt32(_dvCostBreakdowns[0]["cb_id"]);
                    }
                    break;
                case colProject:
                    _dvProjects.RowFilter = String.Empty;
                    _dvProjects.RowFilter = string.Format("project_ext_uid like ('{0}.{1}%') and project_name='{2}'", _spWeb.ID, foreignKeyId, columnValue);
                    if (_dvProjects.Count > 0)
                    {
                        returnValue = Convert.ToInt32(_dvProjects[0]["project_id"]);
                    }
                    break;
                case colCostType:
                    _dvCostTypes.RowFilter = String.Empty;
                    _dvCostTypes.RowFilter = string.Format("ct_name='{0}'", columnValue);
                    if (_dvCostTypes.Count > 0)
                    {
                        returnValue = Convert.ToInt32(_dvCostTypes[0]["ct_id"]);
                    }
                    break;
                case colCostCategory:
                    _dvCostCategories.RowFilter = String.Empty;
                    if (costCategoryArray != null && costCategoryArray.Length >= 2)
                    {
                        Int32 bc_id = Int32.MaxValue;
                        foreach (string costCategory in costCategoryArray)
                        {
                            if (bc_id == Int32.MaxValue)
                            {
                                _dvCostCategories.RowFilter = String.Empty;
                                _dvCostCategories.RowFilter = string.Format("ct_id={0} and bc_name='{1}'", foreignKeyId, costCategory);
                            }
                            else
                            {
                                _dvCostCategories.RowFilter = String.Empty;
                                _dvCostCategories.RowFilter = string.Format("ct_id={0} and bc_name='{1}' and bc_id>={2}", foreignKeyId, costCategory, bc_id);
                            }
                            if (_dvCostCategories.Count == 0)
                            {
                                bc_id = Int32.MaxValue;
                                break;
                            }
                            else
                            {
                                bc_id = Convert.ToInt32(_dvCostCategories[0]["bc_id"]);
                            }
                        }
                        _dvCostCategories.RowFilter = String.Empty;
                        _dvCostCategories.RowFilter = string.Format("ct_id={0} and bc_name='{1}' and bc_id>={2}", foreignKeyId, columnValue, bc_id);
                    }
                    else
                    {
                        _dvCostCategories.RowFilter = string.Format("ct_id={0} and bc_name='{1}'", foreignKeyId, columnValue);
                    }

                    if (_dvCostCategories.Count > 0)
                    {
                        returnValue = Convert.ToInt32(_dvCostCategories[0]["bc_uid"]);
                    }
                    break;
                case colPeriod:
                    _dvPeriods.RowFilter = String.Empty;
                    columnValue = Utilities.GetValidDateInFormat(calendarOrderType, columnValue, dateSeparator);

                    _dvPeriods.RowFilter = string.Format("cb_id={0} and prd_start_date='{1}'", foreignKeyId, columnValue);
                    if (_dvPeriods.Count > 0)
                    {
                        returnValue = Convert.ToInt32(_dvPeriods[0]["prd_id"]);
                    }
                    break;
                default:
                    return 0;
            }
            return returnValue;
        }

        private Double GetRateOrFTEConversion(Int32 calendarId, Int32 costCategoryId, Int32 periodId, Boolean isQty)
        {
            Double returnValue = 0;
            _dvCostBreakdownAttribs.RowFilter = String.Empty;
            _dvCostBreakdownAttribs.RowFilter = string.Format("cb_id={0} and ba_bc_uid={1} and ba_prd_id={2}", calendarId, costCategoryId, periodId);
            if (_dvCostBreakdownAttribs.Count > 0)
            {
                if (isQty)
                    returnValue = Convert.ToDouble(_dvCostBreakdownAttribs[0]["ba_rate"]);
                else
                    returnValue = Convert.ToDouble(_dvCostBreakdownAttribs[0]["ba_fte_conv"]);
            }
            return returnValue;
        }

        private DataView FillDataViewFromCSVFile()
        {

            using (var epmLiveFileStore = new EPMLiveFileStore(_spWeb))
            {
                DataTable dtRawData = new DataTable();
                try
                {
                    using (Stream stream = epmLiveFileStore.GetStream(_fileId))
                    {
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            string[] headers = sr.ReadLine().Split(',');
                            foreach (string header in headers)
                            {
                                dtRawData.Columns.Add(header.ToLower());
                            }

                            if (!dtRawData.Columns.Contains(colCalendar) ||
                                !dtRawData.Columns.Contains(colProject) ||
                                !dtRawData.Columns.Contains(colCostType) ||
                                !dtRawData.Columns.Contains(colCostCategory) ||
                                !dtRawData.Columns.Contains(colPeriod) ||
                                !dtRawData.Columns.Contains(colCostAmount) ||
                                !(dtRawData.Columns.Contains(colQTY) || dtRawData.Columns.Contains(colFTE)) ||
                                !dtRawData.Columns.Contains(colDetailRow))
                            {
                                List<String> errorMessage = new List<string>();

                                if (!dtRawData.Columns.Contains(colCalendar))
                                    errorMessage.Add(colCalendar);
                                if (!dtRawData.Columns.Contains(colProject))
                                    errorMessage.Add(colProject);
                                if (!dtRawData.Columns.Contains(colCostType))
                                    errorMessage.Add(colCostType);
                                if (!dtRawData.Columns.Contains(colCostCategory))
                                    errorMessage.Add(colCostCategory);
                                if (!dtRawData.Columns.Contains(colPeriod))
                                    errorMessage.Add(colPeriod);
                                if (!dtRawData.Columns.Contains(colCostAmount))
                                    errorMessage.Add(colCostAmount);
                                if (!dtRawData.Columns.Contains(colQTY))
                                    errorMessage.Add(colQTY);
                                if (!dtRawData.Columns.Contains(colFTE))
                                    errorMessage.Add(colFTE);
                                if (!dtRawData.Columns.Contains(colDetailRow))
                                    errorMessage.Add(colDetailRow);

                                throw new Exception(String.Format("Cost planner file to be imported is not in proper format or dosenot contain appropriate primary column(s) {0}. Please contact administrator.", String.Join(", ", errorMessage)));
                            }

                            while (!sr.EndOfStream)
                            {
                                string[] rows = sr.ReadLine().Split(',');
                                DataRow dr = dtRawData.NewRow();
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    dr[i] = rows[i];
                                }
                                dtRawData.Rows.Add(dr);
                            }
                        }

                        _dvRawData = new DataView(dtRawData);
                        _dvRawData.Sort = string.Format("{0} ASC, {1} ASC, {2} ASC, {3} ASC, {4} ASC, {5} ASC", colCalendar, colProject, colCostType, colCostCategory, colDetailRow, colPeriod);

                        _totalRecords = _dvRawData.Count;


                    }
                }
                finally
                {
                    epmLiveFileStore.Delete(_fileId);
                }

                return _dvRawData;

            }
        }

        private void FillMasterRecordDataViews()
        {
            if (_PFECN.State != ConnectionState.Open) _PFECN.Open();

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select cb_id, cb_name from epgp_cost_breakdowns", _PFECN))
            {
                DataTable dtCostBreakdowns = new DataTable();
                sqlDataAdapter.Fill(dtCostBreakdowns);
                _dvCostBreakdowns = new DataView(dtCostBreakdowns);
                dtCostBreakdowns.Dispose();
                dtCostBreakdowns = null;
            }

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select project_id, project_name, project_ext_uid from epgp_projects", _PFECN))
            {
                DataTable dtProjects = new DataTable();
                sqlDataAdapter.Fill(dtProjects);
                _dvProjects = new DataView(dtProjects);
                dtProjects.Dispose();
                dtProjects = null;
            }

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select ct_id, ct_name from epgp_cost_types", _PFECN))
            {
                DataTable dtCostTypes = new DataTable();
                sqlDataAdapter.Fill(dtCostTypes);
                _dvCostTypes = new DataView(dtCostTypes);
                dtCostTypes.Dispose();
                dtCostTypes = null;
            }

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select cc.bc_uid, cc.bc_id, bc_name, bc_level, bc_uom, ac.ct_id from epgp_cost_categories cc inner join epgp_avail_categories ac on (cc.bc_uid = ac.bc_uid) order by ac.CT_ID,bc_id", _PFECN))
            {
                DataTable dtCategories = new DataTable();
                sqlDataAdapter.Fill(dtCategories);
                _dvCostCategories = new DataView(dtCategories);
                dtCategories.Dispose();
                dtCategories = null;
            }

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select prd_id, cb_id, prd_name, prd_start_date from epg_periods", _PFECN))
            {
                DataTable dtPeriods = new DataTable();
                sqlDataAdapter.Fill(dtPeriods);
                _dvPeriods = new DataView(dtPeriods);
                dtPeriods.Dispose();
                dtPeriods = null;
            }

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from epgp_cost_custom_fields inner join epgp_field_attribs on (fa_field_id = cf_field_id) order by ct_id, cf_id", _PFECN))
            {
                DataTable dtCostCustomFields = new DataTable();
                sqlDataAdapter.Fill(dtCostCustomFields);
                _dvCostCustomFields = new DataView(dtCostCustomFields);
                dtCostCustomFields.Dispose();
                dtCostCustomFields = null;
            }

            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from epgp_cost_breakdown_attribs order by ba_bc_uid, ba_prd_id", _PFECN))
            {
                DataTable dtCostBreakdownAttribs = new DataTable();
                sqlDataAdapter.Fill(dtCostBreakdownAttribs);
                _dvCostBreakdownAttribs = new DataView(dtCostBreakdownAttribs);
                dtCostBreakdownAttribs.Dispose();
                dtCostBreakdownAttribs = null;
            }

            _PFECN.Close();

        }

        private string FormatMessage(string calendarName, string projectName, string costTypeName, string costCategoryName, string periodName, double quantity, double cost, string errorMessage)
        {
            StringBuilder message = new StringBuilder();
            if (!String.IsNullOrEmpty(errorMessage))
                message.Append(String.Format("<b>{0}</b><br/>", errorMessage));
            if (!String.IsNullOrEmpty(calendarName))
                message.Append(String.Format("Calendar : {0}<br/>", calendarName));
            if (!String.IsNullOrEmpty(projectName))
                message.Append(String.Format("Project : {0}<br/>", projectName));
            if (!String.IsNullOrEmpty(costTypeName))
                message.Append(String.Format("Cost Type : {0}<br/>", costTypeName));
            if (!String.IsNullOrEmpty(costCategoryName))
                message.Append(String.Format("Cost Category : {0}<br/>", costCategoryName));
            if (!String.IsNullOrEmpty(periodName))
                message.Append(String.Format("Period : {0}<br/>", periodName));
            if (quantity != 0)
                message.Append(String.Format("Quantity : {0}<br/>", quantity));
            if (cost != 0)
                message.Append(String.Format("Cost : {0}<br/>", cost));
            return message.ToString();
        }

        private void LogDSMMessage(string message, Int32 messageType)
        {
            //  0 Info   
            //  1 Warning
            //  2 Error
            DSMMessage dSMMessage = new DSMMessage();
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

        private void RaiseDSMProgressChangedEvent(String currentProcess)
        {

            Int32 percentage = (_processedRecords == 0 ? 0 : (_processedRecords * 100) / _totalRecords);
            _dSMResult.CurrentProcess = (percentage == 100 ? "Import Completed. Check the log for more details." : currentProcess);
            _dSMResult.TotalRecords = _totalRecords;
            _dSMResult.ProcessedRecords = _processedRecords;
            _dSMResult.SuccessRecords = _successRecords;
            _dSMResult.FailedRecords = _failedRecords;
            _dSMResult.PercentComplete = percentage;
            DSMProgressChanged(this, new DSMProgressChangedEventHandlerArgs(_processedRecords, _dSMResult));
        }

        private void RaiseDSMCompletedEvent(Exception exception)
        {
            _dSMResult.CurrentProcess = String.Format("Import Completed{0}. Check the log for more details.", exception == null ? "" : " with errors");
            _dSMResult.TotalRecords = _totalRecords;
            _dSMResult.ProcessedRecords = _processedRecords;
            _dSMResult.SuccessRecords = _successRecords;
            _dSMResult.FailedRecords = _failedRecords;
            _dSMResult.PercentComplete = 100;
            DSMCompleted(this, new DSMCompletedEventHandlerArgs(exception, false, _dSMResult));
        }
    }
}
