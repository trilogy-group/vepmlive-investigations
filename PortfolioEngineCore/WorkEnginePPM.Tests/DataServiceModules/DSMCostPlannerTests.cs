using System;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.DataServiceModules.Fakes;

namespace WorkEnginePPM.DataServiceModules.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class DSMCostPlannerTests
    {
        private IDisposable _shimContext;
        private DSMCostPlanner _testEntity;
        private PrivateObject _privateObject;
        private PrivateType _privateType;

        private const string GetMasterRecordIdMethodName = "GetMasterRecordId";
        private const string GetRateOrFteConversionMethodName = "GetRateOrFTEConversion";
        private const string FillDataViewFromCsvFileMethodName = "FillDataViewFromCSVFile";
        private const string FillMasterRecordDataViewsMethodName = "FillMasterRecordDataViews";
        private const string UpdateProjectMethodName = "UpdateProject";
        private const string SaveRowsMethodName = "SaveRows";

        private const string ColCalendarFieldName = "colCalendar";
        private const string ColProjectFieldName = "colProject";
        private const string ColCostTypeFieldName = "colCostType";
        private const string ColCostCategoryFieldName = "colCostCategory";
        private const string ColPeriodFieldName = "colPeriod";
        private const string ColCostAmountFieldName = "colCostAmount";
        private const string ColQtyFieldName = "colQTY";
        private const string ColDetailRowFieldName = "colDetailRow";
        private const string TotalRecordsFieldName = "_totalRecords";

        private const string DvCostBreakdownsFieldName = "_dvCostBreakdowns";
        private const string DvProjectsFieldName = "_dvProjects";
        private const string DvCostTypesFieldName = "_dvCostTypes";
        private const string DvCostCategoriesFieldName = "_dvCostCategories";
        private const string DvPeriodsFieldName = "_dvPeriods";
        private const string DvCostCustomFieldsFieldName = "_dvCostCustomFields";
        private const string DvCostBreakdownAttribsFieldName = "_dvCostBreakdownAttribs";
        private const string BreakDownAttCostCategoryUidFieldName = "ba_bc_uid";
        private const string BreakDownAttFteConvFieldName = "ba_fte_conv";
        private const string BreakDownAttProductIdFieldName = "ba_prd_id";
        private const string BreakDownAttRateFieldName = "ba_rate";
        private const string CostCategoryIdFieldName = "bc_id";
        private const string CostCategoryNameFieldName = "bc_name";
        private const string CostCategoryUidFieldName = "bc_uid";
        private const string CalendarIdFieldName = "cb_id";
        private const string CalendarNameFieldName = "cb_name";
        private const string CostTypeIdFieldName = "ct_id";
        private const string CostTypeNameFieldName = "ct_name";
        private const string PeriodFinishDateFieldName = "PRD_FINISH_DATE";
        private const string PeriodIdFieldName = "prd_id";
        private const string PeriodStartDateFieldName = "PRD_START_DATE";
        private const string ProjectExtUidFieldName = "project_ext_uid";
        private const string ProjectIdFieldName = "project_id";
        private const string project_name = "project_name";
        private const string CostCategory1 = "CostCategory1";
        private const string CostCategory2 = "CostCategory2";

        private ShimSPWeb _web;

        private static readonly Guid DummyWebId = new Guid("171d4895-fc1c-4cdb-883b-ccca50d9c6ad");
        private const string DummyString = "DummyString";
        private const int DummyCalendarId = 10;
        private const int DummyCostCategoryId = 20;
        private const int DummyPeriodId = 30;
        private const double DummyRate = 40;
        private const double DummyFteConv = 50;
        private const int DummyProjectId = 60;
        private const int DummyCostTypeId = 70;
        private const string DummyColumnValue = "DummyColumnValue";
        private const int DummyId = 100;
        private const int DummyId2 = 150;
        private const string DummyForeignKeyId = "109";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();

            string listId,
                basePath,
                username,
                pid,
                company,
                dataBaseConnectionString;
            listId = Guid.NewGuid().ToString();
            var fileId = basePath = username = pid = company = dataBaseConnectionString = "Test Connection";
            var secLevel = SecurityLevels.Base;
            var isDebug = false;

            _web = new ShimSPWeb()
            {
                IDGet = () => DummyWebId,
                CurrentUserGet = () => new ShimSPUser()
                {
                    IsSiteAdminGet = () => true
                }
            };
            ShimSPContext.GetContextSPWeb = instance => new ShimSPContext()
            {
                RegionalSettingsGet = () => new ShimSPRegionalSettings()
                {
                    DateSeparatorGet = () => "/",
                    DateFormatGet = () => 1
                }
            };

            ShimPFEBase.AllInstances.PFEBaseCommonStringStringStringStringStringSecurityLevelsBoolean = (sender, basePathParam, usernameParam, pidParam, companyParam, dataBaseConnectionStringParam, secLevelParam, debugParam) => { };

            _testEntity = new DSMCostPlanner(_web, fileId, listId, basePath, username, pid, company, dataBaseConnectionString, secLevel, isDebug);
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(DSMCostPlanner));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
            _testEntity?.Dispose();
        }

        [TestCategory("DataServiceModules")]
        [TestMethod()]
        public void ImportDataTest_WhenCostType_0()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                string[] headers = "Calendar,PIName,CostType,CostCategory,Period,CostAmount,Source,TransactionType,QTY,DetailRow,Date,Account Number,PO Number,Invoice Number,Vendor".Split(',');
                int costtype = 0;
                string fileId, listId, basepath, username, pid, company, dbcnstring;
                fileId = listId = basepath = username = pid = company = dbcnstring = "Test Connection";
                SecurityLevels secLevel = SecurityLevels.Base;
                bool bDebug = false;
                ShimPFEBase.AllInstances.PFEBaseCommonStringStringStringStringStringSecurityLevelsBoolean = (instance, a, b, c, d, e, f, g) =>
                {

                };
                ShimSPWeb web = new ShimSPWeb();
                ShimSPWeb.AllInstances.CurrentUserGet = (instance) => { return new ShimSPUser() { IsSiteAdminGet = () => { return true; } }; };
                ShimSPContext.GetContextSPWeb = (instance) => { return new ShimSPContext() { RegionalSettingsGet = () => { return new ShimSPRegionalSettings() { DateSeparatorGet = () => { return "/"; }, DateFormatGet = () => { return 1; } }; } }; };
                ShimDSMCostPlanner.AllInstances.RaiseDSMProgressChangedEventString = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.FillDataViewFromCSVFile = (instance) => { return new ShimDataView(); };
                ShimDSMCostPlanner.AllInstances.RaiseDSMCompletedEventException = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.GetMasterRecordIdStringStringStringStringArray = (str, str1, str2, str3, int1) => { return costtype; };
                ShimDSMCostPlanner.AllInstances.FillMasterRecordDataViews = (instance) => { };
                ShimDSMCostPlanner.AllInstances.GetRateOrFTEConversionInt32Int32Int32Boolean = (instance, a, b, c, d) => { return 5; };

                DataView _dvRawData = new DataView();

                DSMCostPlanner _DSMCostPlanner = new DSMCostPlanner(web, fileId, listId, basepath, username, pid, company, dbcnstring, secLevel, bDebug);

                DataTable dtRawData = new DataTable();
                foreach (string header in headers)
                {
                    dtRawData.Columns.Add(header.ToLower());
                }
                string[] rows = "Calendar Months,First project,Budget,Capital,10/1/2016,120,Infosys,Account Alias Issue,120,2,24-Jan,ACCT 134,57575,130,EPM".Split(',');
                DataRow dr = dtRawData.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }

                dtRawData.Rows.Add(dr);
                _dvRawData = new DataView(dtRawData);
                typeof(DSMCostPlanner).GetField("_dvRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, _dvRawData);
                //typeof(DSMCostPlanner).GetField("dtRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, dtRawData);
                FieldInfo fi = typeof(DSMCostPlanner).GetField("_dtInsertCostData", BindingFlags.NonPublic | BindingFlags.Instance);
                DataTable _dvCostCustomFields = new DataTable();
                headers = "CT_ID,CF_ID,CF_FIELD_ID,CF_EDITABLE,CF_VISIBLE,CF_FROZEN,CF_IDENTITY,CF_REQUIRED,FA_FIELD_ID,FA_NAME,FA_DESC,FA_LOOKUPONLY,FA_LOOKUP_UID,FA_LEAFONLY,FA_USEFULLNAME,FA_VALUE_UNIQUE,FA_ADMIN".Split(',');
                foreach (string header in headers)
                {
                    _dvCostCustomFields.Columns.Add(header.ToLower());
                }

                rows = "0,11801,11801,0,0,1,1,1,11801,Source,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "0,11802,11802,0,0,1,1,1,11802,TransactionType,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "0,11803,11803,0,0,1,1,1,11803,Vendor,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                typeof(DSMCostPlanner).GetField("_dvCostCustomFields", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));
                typeof(DSMCostPlanner).GetField("_dvCostCategories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));
                _DSMCostPlanner.ImportData();
                var _fileId = typeof(DSMCostPlanner).GetField("_fileId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                var _listId = typeof(DSMCostPlanner).GetField("_listId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                Assert.IsNotNull(_DSMCostPlanner);
                Assert.AreEqual(_fileId, fileId);
                Assert.AreEqual(_listId, listId);
            }
        }

        [TestCategory("DataServiceModules")]
        [TestMethod()]
        public void ImportDataTest_WhenCostType_1()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                string[] headers = "Calendar,PIName,CostType,CostCategory,Period,CostAmount,Source,TransactionType,QTY,DetailRow,Date,Account Number,PO Number,Invoice Number,Vendor,fte,test column1,test column2".Split(',');
                string fileId, listId, basepath, username, pid, company, dbcnstring;
                fileId = listId = basepath = username = pid = company = dbcnstring = "Test Connection";
                SecurityLevels secLevel = SecurityLevels.Base;
                bool bDebug = false;
                ShimPFEBase.AllInstances.PFEBaseCommonStringStringStringStringStringSecurityLevelsBoolean = (instance, a, b, c, d, e, f, g) =>
                {

                };
                ShimSPWeb web = new ShimSPWeb();
                ShimSPWeb.AllInstances.CurrentUserGet = (instance) => { return new ShimSPUser() { IsSiteAdminGet = () => { return true; } }; };
                ShimSPContext.GetContextSPWeb = (instance) => { return new ShimSPContext() { RegionalSettingsGet = () => { return new ShimSPRegionalSettings() { DateSeparatorGet = () => { return "/"; }, DateFormatGet = () => { return 1; } }; } }; };
                ShimDSMCostPlanner.AllInstances.RaiseDSMProgressChangedEventString = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.FillDataViewFromCSVFile = (instance) => { return new ShimDataView(); };
                ShimDSMCostPlanner.AllInstances.RaiseDSMCompletedEventException = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.GetMasterRecordIdStringStringStringStringArray = (str, str1, str2, str3, int1) => { return 1; };
                ShimDSMCostPlanner.AllInstances.FillMasterRecordDataViews = (instance) => { };
                ShimDSMCostPlanner.AllInstances.GetRateOrFTEConversionInt32Int32Int32Boolean = (instance, a, b, c, d) => { return 5; };

                DataView _dvRawData = new DataView();

                DSMCostPlanner _DSMCostPlanner = new DSMCostPlanner(web, fileId, listId, basepath, username, pid, company, dbcnstring, secLevel, bDebug);

                DataTable dtRawData = new DataTable();
                foreach (string header in headers)
                {
                    dtRawData.Columns.Add(header.ToLower());
                }
                string[] rows = "Calendar Months,First project,Budget,Capital,10/1/2016,120,Infosys,Account Alias Issue,120,2,24-Jan,ACCT 134,57575,130,EPM,20,,".Split(',');
                DataRow dr = dtRawData.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }

                dtRawData.Rows.Add(dr);
                _dvRawData = new DataView(dtRawData);
                typeof(DSMCostPlanner).GetField("_dvRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, _dvRawData);
                //typeof(DSMCostPlanner).GetField("dtRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, dtRawData);
                FieldInfo fi = typeof(DSMCostPlanner).GetField("_dtInsertCostData", BindingFlags.NonPublic | BindingFlags.Instance);
                DataTable _dvCostCustomFields = new DataTable();
                headers = "CT_ID,CF_ID,CF_FIELD_ID,CF_EDITABLE,CF_VISIBLE,CF_FROZEN,CF_IDENTITY,CF_REQUIRED,FA_FIELD_ID,FA_NAME,FA_DESC,FA_LOOKUPONLY,FA_LOOKUP_UID,FA_LEAFONLY,FA_USEFULLNAME,FA_VALUE_UNIQUE,FA_ADMIN".Split(',');
                foreach (string header in headers)
                {
                    _dvCostCustomFields.Columns.Add(header.ToLower());
                }

                rows = "1,11801,11801,0,0,1,1,1,11801,Source,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11802,11802,0,0,1,1,1,11802,TransactionType,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11803,11803,0,0,1,1,1,11803,Vendor,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11804,11804,0,0,1,1,1,11804,account number,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11805,11805,0,0,1,1,1,11805,date,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11811,11811,0,0,1,1,1,11811,po number,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11812,11812,0,0,1,1,1,11812,invoice number,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11813,11813,0,0,1,1,1,11813,vendor,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11814,11814,0,0,1,1,1,11814,test column1,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11815,11815,0,0,1,1,1,11815,test column2,120,0,9,0,0,NULL,NULL".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                typeof(DSMCostPlanner).GetField("_dvCostCustomFields", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));
                typeof(DSMCostPlanner).GetField("_dvCostCategories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));

                _DSMCostPlanner.ImportData();
                var _fileId = typeof(DSMCostPlanner).GetField("_fileId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                var _listId = typeof(DSMCostPlanner).GetField("_listId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                Assert.IsNotNull(_DSMCostPlanner);
                Assert.AreEqual(_fileId, fileId);
                Assert.AreEqual(_listId, listId);
            }
        }

        [TestCategory("DataServiceModules")]
        [TestMethod()]
        public void ImportDataTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                string[] headers = "Calendar,PIName,CostType,CostCategory,Period,CostAmount,Source,TransactionType,QTY,DetailRow,Date,Account Number,PO Number,Invoice Number,Vendor".Split(',');

                string fileId, listId, basepath, username, pid, company, dbcnstring;
                fileId = listId = basepath = username = pid = company = dbcnstring = "Test Connection";
                SecurityLevels secLevel = SecurityLevels.Base;
                bool bDebug = false;
                ShimPFEBase.AllInstances.PFEBaseCommonStringStringStringStringStringSecurityLevelsBoolean = (instance, a, b, c, d, e, f, g) =>
                {

                };
                ShimSPWeb web = new ShimSPWeb();
                ShimSPWeb.AllInstances.CurrentUserGet = (instance) => { return new ShimSPUser() { IsSiteAdminGet = () => { return true; } }; };
                ShimSPContext.GetContextSPWeb = (instance) => { return new ShimSPContext() { RegionalSettingsGet = () => { return new ShimSPRegionalSettings() { DateSeparatorGet = () => { return "/"; }, DateFormatGet = () => { return 1; } }; } }; };
                ShimDSMCostPlanner.AllInstances.RaiseDSMProgressChangedEventString = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.FillDataViewFromCSVFile = (instance) => { return new ShimDataView(); };
                ShimDSMCostPlanner.AllInstances.RaiseDSMCompletedEventException = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.GetMasterRecordIdStringStringStringStringArray = (str, str1, str2, str3, int1) => { return 1; };
                ShimDSMCostPlanner.AllInstances.FillMasterRecordDataViews = (instance) => { };
                ShimDSMCostPlanner.AllInstances.GetRateOrFTEConversionInt32Int32Int32Boolean = (instance, a, b, c, d) => { return 5; };
                ShimDSMCostPlanner.AllInstances.SaveRowsInt32Int32Int32DataTableDataTable = (a, b, c, d, e, f) => { return true; };
                DataView _dvRawData = new DataView();

                DSMCostPlanner _DSMCostPlanner = new DSMCostPlanner(web, fileId, listId, basepath, username, pid, company, dbcnstring, secLevel, bDebug);

                DataTable dtRawData = new DataTable();
                foreach (string header in headers)
                {
                    dtRawData.Columns.Add(header.ToLower());
                }
                string[] rows = "Calendar Months,First project,Budget,Capital,10/1/2016,120,Infosys,Account Alias Issue,120,2,24-Jan,ACCT 134,57575,130,EPM".Split(',');
                DataRow dr = dtRawData.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }

                dtRawData.Rows.Add(dr);
                _dvRawData = new DataView(dtRawData);
                typeof(DSMCostPlanner).GetField("_dvRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, _dvRawData);
                //typeof(DSMCostPlanner).GetField("dtRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, dtRawData);
                FieldInfo fi = typeof(DSMCostPlanner).GetField("_dtInsertCostData", BindingFlags.NonPublic | BindingFlags.Instance);
                DataTable _dvCostCustomFields = new DataTable();
                headers = "CT_ID,CF_ID,CF_FIELD_ID,CF_EDITABLE,CF_VISIBLE,CF_FROZEN,CF_IDENTITY,CF_REQUIRED,FA_FIELD_ID,FA_NAME,FA_DESC,FA_LOOKUPONLY,FA_LOOKUP_UID,FA_LEAFONLY,FA_USEFULLNAME,FA_VALUE_UNIQUE,FA_ADMIN,bc_uid,bc_name".Split(',');
                foreach (string header in headers)
                {
                    _dvCostCustomFields.Columns.Add(header.ToLower());
                }

                rows = "1,11801,11801,0,0,1,1,1,11801,Source,120,0,9,0,0,NULL,NULL,1,test".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11802,11802,0,0,1,1,1,11802,TransactionType,120,0,9,0,0,NULL,NULL,1,test".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11803,11803,0,0,1,1,1,11803,Vendor,120,0,9,0,0,NULL,NULL,1,test".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                typeof(DSMCostPlanner).GetField("_dvCostCustomFields", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));
                typeof(DSMCostPlanner).GetField("_dvCostCategories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));
                _DSMCostPlanner.ImportData();
                var _fileId = typeof(DSMCostPlanner).GetField("_fileId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                var _listId = typeof(DSMCostPlanner).GetField("_listId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                Assert.IsNotNull(_DSMCostPlanner);
                Assert.AreEqual(_fileId, fileId);
                Assert.AreEqual(_listId, listId);
            }
        }

        [TestCategory("DataServiceModules")]
        [TestMethod()]
        public void ImportDataTest_Execute_Catch_Block()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                string[] headers = "Calendar,PIName,CostType,CostCategory,Period,CostAmount,Source,TransactionType,QTY,DetailRow,Date,Account Number,PO Number,Invoice Number,Vendor".Split(',');
                string fileId, listId, basepath, username, pid, company, dbcnstring;
                fileId = listId = basepath = username = pid = company = dbcnstring = "Test Connection";
                SecurityLevels secLevel = SecurityLevels.Base;
                bool bDebug = false;
                ShimPFEBase.AllInstances.PFEBaseCommonStringStringStringStringStringSecurityLevelsBoolean = (instance, a, b, c, d, e, f, g) =>
                {

                };
                ShimSPWeb web = new ShimSPWeb();
                ShimSPWeb.AllInstances.CurrentUserGet = (instance) => { return new ShimSPUser() { IsSiteAdminGet = () => { return true; } }; };
                ShimSPContext.GetContextSPWeb = (instance) => { return new ShimSPContext() { RegionalSettingsGet = () => { return new ShimSPRegionalSettings() { DateSeparatorGet = () => { return "/"; }, DateFormatGet = () => { return 1; } }; } }; };
                ShimDSMCostPlanner.AllInstances.RaiseDSMProgressChangedEventString = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.FillDataViewFromCSVFile = (instance) => { return new ShimDataView(); };
                ShimDSMCostPlanner.AllInstances.RaiseDSMCompletedEventException = (instance, str) => { };
                ShimDSMCostPlanner.AllInstances.GetMasterRecordIdStringStringStringStringArray = (str, str1, str2, str3, int1) => { return 1; };
                ShimDSMCostPlanner.AllInstances.FillMasterRecordDataViews = (instance) => { };
                ShimDSMCostPlanner.AllInstances.GetRateOrFTEConversionInt32Int32Int32Boolean = (instance, a, b, c, d) => { return 5; };

                DataView _dvRawData = new DataView();

                DSMCostPlanner _DSMCostPlanner = new DSMCostPlanner(web, fileId, listId, basepath, username, pid, company, dbcnstring, secLevel, bDebug);

                DataTable dtRawData = new DataTable();
                foreach (string header in headers)
                {
                    dtRawData.Columns.Add(header.ToLower());
                }
                string[] rows = "Calendar Months,First project,Budget,Capital,10/1/2016,120,Infosys,Account Alias Issue,120,2,24-Jan,ACCT 134,57575,130,EPM".Split(',');
                DataRow dr = dtRawData.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }

                dtRawData.Rows.Add(dr);
                _dvRawData = new DataView(dtRawData);
                typeof(DSMCostPlanner).GetField("_dvRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, _dvRawData);
                //typeof(DSMCostPlanner).GetField("dtRawData", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, dtRawData);
                FieldInfo fi = typeof(DSMCostPlanner).GetField("_dtInsertCostData", BindingFlags.NonPublic | BindingFlags.Instance);
                DataTable _dvCostCustomFields = new DataTable();
                headers = "CT_ID,CF_ID,CF_FIELD_ID,CF_EDITABLE,CF_VISIBLE,CF_FROZEN,CF_IDENTITY,CF_REQUIRED,FA_FIELD_ID,FA_NAME,FA_DESC,FA_LOOKUPONLY,FA_LOOKUP_UID,FA_LEAFONLY,FA_USEFULLNAME,FA_VALUE_UNIQUE,FA_ADMIN,bc_uid".Split(',');
                foreach (string header in headers)
                {
                    _dvCostCustomFields.Columns.Add(header.ToLower());
                }

                rows = "1,11801,11801,0,0,1,1,1,11801,Source,120,0,9,0,0,NULL,NULL,1".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11802,11802,0,0,1,1,1,11802,TransactionType,120,0,9,0,0,NULL,NULL,1".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                rows = "1,11803,11803,0,0,1,1,1,11803,Vendor,120,0,9,0,0,NULL,NULL,1".Split(',');
                dr = _dvCostCustomFields.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                _dvCostCustomFields.Rows.Add(dr);
                typeof(DSMCostPlanner).GetField("_dvCostCustomFields", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));
                typeof(DSMCostPlanner).GetField("_dvCostCategories", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(_DSMCostPlanner, new DataView(_dvCostCustomFields));
                _DSMCostPlanner.ImportData();


                var _fileId = typeof(DSMCostPlanner).GetField("_fileId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                var _listId = typeof(DSMCostPlanner).GetField("_listId", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_DSMCostPlanner);
                Assert.IsNotNull(_DSMCostPlanner);
                Assert.AreEqual(_fileId, fileId);
                Assert.AreEqual(_listId, listId);
            }
        }

        [TestMethod]
        public void SaveRows_DataBaseAccessFailOpen_ReturnsFalse()
        {
            // Arrange
            var dataTableInsertCostDetails = new DataTable();
            var dataTableInsertCostDetailsValue = new DataTable();

            // Act
            var actualResult = (bool)_privateObject.Invoke(SaveRowsMethodName, DummyCalendarId, DummyProjectId, DummyCostTypeId, dataTableInsertCostDetails, dataTableInsertCostDetailsValue);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void SaveRows_DbAccessStatusSuccess_ReturnsTrue()
        {
            // Arrange
            var actualBeginTransaction = false;
            var actualCommitTransaction = false;
            var actualClose = false;
            var actualRollbackTransaction = false;
            var actualOpen = false;

            var dataTableInsertCostDetails = new DataTable();
            var dataTableInsertCostDetailsValue = new DataTable();

            var dbAccess = new ShimDBAccess();
            var sqlDb = new ShimSqlDb(dbAccess)
            {
                Open = () =>
                {
                    actualOpen = true;
                    return StatusEnum.rsSuccess;
                },
                BeginTransaction = () => actualBeginTransaction = true,
                CommitTransaction = () => actualCommitTransaction = true,
                StatusGet = () => StatusEnum.rsSuccess,
                Close = () => actualClose = true,
                RollbackTransaction = () => actualRollbackTransaction = true
            };

            ShimdbaEditCosts.DeleteCostDetailsDBAccessInt32Int32Int32Int32Out = (DBAccess dba, int calendarId, int costTypeId, int projectId, out int rowsAffected) =>
            {
                rowsAffected = 1;
                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.DeleteCostDetailValuesDBAccessInt32Int32Int32DataTable = (dba, calendarId, costTypeId, projectId, dataTable) => StatusEnum.rsSuccess;
            ShimdbaEditCosts.InsertCostDetailsDBAccessInt32Int32Int32DataTable = (dba, calendarId, costTypeId, projectId, dataTable) => StatusEnum.rsSuccess;
            ShimdbaEditCosts.InsertCostDetailValuesDBAccessInt32Int32Int32DataTable = (dba, calendarId, costTypeId, projectId, dataTable) => StatusEnum.rsSuccess;
            ShimDSMCostPlanner.AllInstances.UpdateProjectInt32 = (sender, projectId) => true;

            _privateObject.SetField("_dba", dbAccess.Instance);

            // Act
            var actualResult = (bool)_privateObject.Invoke(SaveRowsMethodName, DummyCalendarId, DummyProjectId, DummyCostTypeId, dataTableInsertCostDetails, dataTableInsertCostDetailsValue);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => actualBeginTransaction.ShouldBeTrue(),
                () => actualCommitTransaction.ShouldBeTrue(),
                () => actualClose.ShouldBeTrue(),
                () => actualRollbackTransaction.ShouldBeFalse(),
                () => actualOpen.ShouldBeTrue());
        }

        [TestMethod]
        public void SaveRows_DbAccessStatusSessionExpired_ReturnsFalse()
        {
            // Arrange
            var actualBeginTransaction = false;
            var actualCommitTransaction = false;
            var actualClose = false;
            var actualRollbackTransaction = false;
            var actualOpen = false;

            var dataTableInsertCostDetails = new DataTable();
            var dataTableInsertCostDetailsValue = new DataTable();

            var dbAccess = new ShimDBAccess();
            var sqlDb = new ShimSqlDb(dbAccess)
            {
                Open = () =>
                {
                    actualOpen = true;
                    return StatusEnum.rsSuccess;
                },
                BeginTransaction = () => actualBeginTransaction = true,
                CommitTransaction = () => actualCommitTransaction = true,
                StatusGet = () => StatusEnum.rsSessionExpired,
                Close = () => actualClose = true,
                RollbackTransaction = () => actualRollbackTransaction = true
            };

            ShimdbaEditCosts.DeleteCostDetailsDBAccessInt32Int32Int32Int32Out = (DBAccess dba, int calendarId, int costTypeId, int projectId, out int rowsAffected) =>
            {
                rowsAffected = 1;
                return StatusEnum.rsSuccess;
            };
            ShimdbaEditCosts.DeleteCostDetailValuesDBAccessInt32Int32Int32DataTable = (dba, calendarId, costTypeId, projectId, dataTable) => StatusEnum.rsSuccess;
            ShimdbaEditCosts.InsertCostDetailsDBAccessInt32Int32Int32DataTable = (dba, calendarId, costTypeId, projectId, dataTable) => StatusEnum.rsSuccess;
            ShimdbaEditCosts.InsertCostDetailValuesDBAccessInt32Int32Int32DataTable = (dba, calendarId, costTypeId, projectId, dataTable) => StatusEnum.rsSuccess;
            ShimDSMCostPlanner.AllInstances.UpdateProjectInt32 = (sender, projectId) => true;

            _privateObject.SetField("_dba", dbAccess.Instance);

            // Act
            var actualResult = (bool)_privateObject.Invoke(SaveRowsMethodName, DummyCalendarId, DummyProjectId, DummyCostTypeId, dataTableInsertCostDetails, dataTableInsertCostDetailsValue);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeFalse(),
                () => actualBeginTransaction.ShouldBeTrue(),
                () => actualCommitTransaction.ShouldBeTrue(),
                () => actualClose.ShouldBeTrue(),
                () => actualRollbackTransaction.ShouldBeTrue(),
                () => actualOpen.ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateProject_ItemFound_returnTrue()
        {
            // Arrange
            _web.ListsGet = () => new ShimSPListCollection()
            {
                ItemGetGuid = itemName => new ShimSPList()
                {
                    GetItemByIdInt32 = itemId => new ShimSPListItem()
                    {
                        Update = () => { }
                    }
                }
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (action) =>
            {
                action();
            };
            _privateObject.SetField(DvProjectsFieldName, CreateDataViewProject());

            // Act
            var actualResult = (bool)_privateObject.Invoke(UpdateProjectMethodName, DummyProjectId);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateProject_ItemNotFound_returnTrue()
        {
            // Arrange
            _web.ListsGet = () => new ShimSPListCollection()
            {
                ItemGetString = itemName => new ShimSPList()
                {
                    GetItemByIdInt32 = itemId => null
                }
            };

            // Act
            var actualResult = (bool)_privateObject.Invoke(UpdateProjectMethodName, DummyProjectId);

            // Assert
            actualResult.ShouldBeFalse();
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnCalendar_ReturnsId()
        {
            // Arrange
            _privateObject.SetField(DvCostBreakdownsFieldName, CreateDataViewCostBreakdown());

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, (string)_privateType.GetStaticField(ColCalendarFieldName), DummyColumnValue, string.Empty, new string[0]);

            // Assert
            actualResult.ShouldBe(DummyId);
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnProject_ReturnsId()
        {
            // Arrange
            _privateObject.SetField(DvProjectsFieldName, CreateDataViewProject());

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, (string)_privateType.GetStaticField(ColProjectFieldName), DummyColumnValue, string.Empty, new string[0]);

            // Assert
            actualResult.ShouldBe(DummyId);
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnCostType_ReturnsId()
        {
            // Arrange
            _privateObject.SetField(DvCostTypesFieldName, CreateDataViewCostType());

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, (string)_privateType.GetStaticField(ColCostTypeFieldName), DummyColumnValue, string.Empty, new string[0]);

            // Assert
            actualResult.ShouldBe(DummyId);
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnCostCategoryArrayEmpty_ReturnsId()
        {
            // Arrange
            _privateObject.SetField(DvCostCategoriesFieldName, CreateDataViewCostCategory());

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, (string)_privateType.GetStaticField(ColCostCategoryFieldName), DummyColumnValue, DummyForeignKeyId, new string[0]);

            // Assert
            actualResult.ShouldBe(DummyId);
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnCostCategoryArrayFilled_ReturnsZero()
        {
            // Arrange
            _privateObject.SetField(DvCostCategoriesFieldName, CreateDataViewCostCategory2Rows());

            var costCategory = new[]
            {
                "CostCategory1",
                "CostCategory2"
            };

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, (string)_privateType.GetStaticField(ColCostCategoryFieldName), DummyColumnValue, DummyForeignKeyId, costCategory);

            // Assert
            actualResult.ShouldBe(0);
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnCostCategoryArrayFilledForeignKeyNotFound_ReturnsZero()
        {
            // Arrange
            _privateObject.SetField(DvCostCategoriesFieldName, CreateDataViewCostCategory2Rows());

            var costCategory = new[]
            {
                DummyString,
                "CostCategory2"
            };

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, (string)_privateType.GetStaticField(ColCostCategoryFieldName), DummyColumnValue, DummyForeignKeyId, costCategory);

            // Assert
            actualResult.ShouldBe(0);
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnPeriod_ReturnsId()
        {
            // Arrange
            _privateObject.SetField(DvPeriodsFieldName, CreateDataViewPeriods());

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, (string)_privateType.GetStaticField(ColPeriodFieldName), "2/2/2018", DummyForeignKeyId, new string[0]);

            // Assert
            actualResult.ShouldBe(DummyId);
        }

        [TestMethod]
        public void GetMasterRecordId_ColumnInvalid_ReturnsZero()
        {
            // Arrange
            _privateObject.SetField(DvCostCategoriesFieldName, CreateDataViewCostCategory2Rows());

            // Act
            var actualResult = (int)_privateObject.Invoke(GetMasterRecordIdMethodName, DummyString, DummyColumnValue, DummyForeignKeyId, new string[0]);

            // Assert
            actualResult.ShouldBe(0);
        }

        [TestMethod]
        public void GetRateOrFTEConversion_IsQtyTrue_ReturnRateValue()
        {
            // Arrange
            _privateObject.SetField(DvCostBreakdownAttribsFieldName, CreateDataViewCostBreakdownAttribs());

            // Act
            var actualResult = (double)_privateObject.Invoke(GetRateOrFteConversionMethodName, DummyCalendarId, DummyCostCategoryId, DummyPeriodId, true);

            // Assert
            actualResult.ShouldBe(DummyRate);
        }

        [TestMethod]
        public void GetRateOrFTEConversion_IsQtyFalse_ReturnFteConvValue()
        {
            // Arrange
            _privateObject.SetField(DvCostBreakdownAttribsFieldName, CreateDataViewCostBreakdownAttribs());

            // Act
            var actualResult = (double)_privateObject.Invoke(GetRateOrFteConversionMethodName, DummyCalendarId, DummyCostCategoryId, DummyPeriodId, false);

            // Assert
            actualResult.ShouldBe(DummyFteConv);
        }

        [TestMethod]
        public void FillDataViewFromCSVFile_StreamWhitespace_ThrowException()
        {
            // Arrange
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("       ");
            writer.Flush();
            stream.Position = 0;

            ShimEPMLiveFileStore.ConstructorSPWeb = (sender, spWeb) => new ShimEPMLiveFileStore(sender)
            {
                GetStreamString = fileId => stream,
                DeleteString = fileId => { }
            };

            // Act
            Action action = () => _privateObject.Invoke(FillDataViewFromCsvFileMethodName);

            // Assert
            action.ShouldThrow<Exception>().Message.ShouldBe("Cost planner file to be imported is not in proper format or dosenot contain appropriate primary column(s) calendar, piname, costtype, costcategory, period, costamount, qty, fte, detailrow. Please contact administrator.");

            writer.Dispose();
            stream.Dispose();
        }

        [TestMethod]
        public void FillDataViewFromCSVFile_StreamValid_ReturnsDataView()
        {
            // Arrange
            var calendarField = (string)_privateType.GetStaticField(ColCalendarFieldName);
            var projectField = (string)_privateType.GetStaticField(ColProjectFieldName);
            var costTypeField = (string)_privateType.GetStaticField(ColCostTypeFieldName);
            var costCategoryField = (string)_privateType.GetStaticField(ColCostCategoryFieldName);
            var periodField = (string)_privateType.GetStaticField(ColPeriodFieldName);
            var costAmountField = (string)_privateType.GetStaticField(ColCostAmountFieldName);
            var qtyField = (string)_privateType.GetStaticField(ColQtyFieldName);
            var detailRowField = (string)_privateType.GetStaticField(ColDetailRowFieldName);

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.WriteLine($"{calendarField},{projectField},{costTypeField},{costCategoryField},{periodField},{costAmountField},{qtyField},{detailRowField}");
            writer.WriteLine("1,2,3,4,5,6,7,8");
            writer.Flush();
            stream.Position = 0;

            ShimEPMLiveFileStore.ConstructorSPWeb = (sender, spWeb) => new ShimEPMLiveFileStore(sender)
            {
                GetStreamString = fileId => stream,
                DeleteString = fileId => { }
            };

            // Act
            var actualResult = (DataView)_privateObject.Invoke(FillDataViewFromCsvFileMethodName);

            // Assert
            var actualTotalRecords = (int)_privateObject.GetField(TotalRecordsFieldName);

            this.ShouldSatisfyAllConditions(
                () => actualTotalRecords.ShouldBe(1),
                () => actualResult.Table.Columns.Count.ShouldBe(8),
                () => actualResult.Table.Columns.Contains(calendarField).ShouldBeTrue(),
                () => actualResult.Table.Columns.Contains(projectField).ShouldBeTrue(),
                () => actualResult.Table.Columns.Contains(costTypeField).ShouldBeTrue(),
                () => actualResult.Table.Columns.Contains(costCategoryField).ShouldBeTrue(),
                () => actualResult.Table.Columns.Contains(periodField).ShouldBeTrue(),
                () => actualResult.Table.Columns.Contains(costAmountField).ShouldBeTrue(),
                () => actualResult.Table.Columns.Contains(qtyField).ShouldBeTrue(),
                () => actualResult.Table.Columns.Contains(detailRowField).ShouldBeTrue(),
                () => actualResult.Count.ShouldBe(1),
                () => actualResult[0][0].ShouldBe("1"),
                () => actualResult[0][1].ShouldBe("2"),
                () => actualResult[0][2].ShouldBe("3"),
                () => actualResult[0][3].ShouldBe("4"),
                () => actualResult[0][4].ShouldBe("5"),
                () => actualResult[0][5].ShouldBe("6"),
                () => actualResult[0][6].ShouldBe("7"),
                () => actualResult[0][7].ShouldBe("8"));

            writer.Dispose();
            stream.Dispose();
        }

        [TestMethod]
        public void FillMasterRecordDataViews_Should_FillDataViews()
        {
            // Arrange
            var actualSqlConnectionClosed = false;
            ShimSqlConnection.AllInstances.StateGet = sender => ConnectionState.Closed;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => actualSqlConnectionClosed = true;

            ShimDbDataAdapter.AllInstances.FillDataTable = (sender, dataTableParam) =>
            {
                dataTableParam = new DataTable();
                return 1;
            };

            _privateObject.SetField("_PFECN", new ShimSqlConnection().Instance);

            // Act
            _privateObject.Invoke(FillMasterRecordDataViewsMethodName);

            // Assert
            var dvCostBreakDown = (DataView)_privateObject.GetField(DvCostBreakdownsFieldName);
            var dvProjects = (DataView)_privateObject.GetField(DvProjectsFieldName);
            var dvCostTypes = (DataView)_privateObject.GetField(DvCostTypesFieldName);
            var dvCostCategories = (DataView)_privateObject.GetField(DvCostCategoriesFieldName);
            var dvPeriods = (DataView)_privateObject.GetField(DvPeriodsFieldName);
            var dvCostCustomFields = (DataView)_privateObject.GetField(DvCostCustomFieldsFieldName);
            var dvCostBreakdownAttibs = (DataView)_privateObject.GetField(DvCostBreakdownAttribsFieldName);

            this.ShouldSatisfyAllConditions(
                () => actualSqlConnectionClosed.ShouldBeTrue(),
                () => dvCostBreakDown.ShouldNotBeNull(),
                () => dvProjects.ShouldNotBeNull(),
                () => dvCostTypes.ShouldNotBeNull(),
                () => dvCostCategories.ShouldNotBeNull(),
                () => dvPeriods.ShouldNotBeNull(),
                () => dvCostCustomFields.ShouldNotBeNull(),
                () => dvCostBreakdownAttibs.ShouldNotBeNull());
        }

        private static DataView CreateDataViewPeriods()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(CalendarIdFieldName);
            dataTable.Columns.Add(PeriodStartDateFieldName);
            dataTable.Columns.Add(PeriodFinishDateFieldName);
            dataTable.Columns.Add(PeriodIdFieldName);

            var dataRow = dataTable.NewRow();
            dataRow[CalendarIdFieldName] = DummyForeignKeyId;
            dataRow[PeriodStartDateFieldName] = new DateTime(2018, 1, 1);
            dataRow[PeriodFinishDateFieldName] = new DateTime(2018, 3, 3);
            dataRow[PeriodIdFieldName] = DummyId;
            dataTable.Rows.Add(dataRow);

            var dataView = new DataView(dataTable);
            return dataView;
        }

        private static DataView CreateDataViewCostCategory()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(CostTypeIdFieldName);
            dataTable.Columns.Add(CostCategoryNameFieldName);
            dataTable.Columns.Add(CostCategoryUidFieldName);

            var dataRow = dataTable.NewRow();
            dataRow[CostTypeIdFieldName] = DummyForeignKeyId;
            dataRow[CostCategoryNameFieldName] = DummyColumnValue;
            dataRow[CostCategoryUidFieldName] = DummyId;
            dataTable.Rows.Add(dataRow);

            var dataView = new DataView(dataTable);
            return dataView;
        }

        private static DataView CreateDataViewCostCategory2Rows()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(CostTypeIdFieldName);
            dataTable.Columns.Add(CostCategoryNameFieldName);
            dataTable.Columns.Add(CostCategoryUidFieldName);
            dataTable.Columns.Add(CostCategoryIdFieldName);

            var dataRow = dataTable.NewRow();
            dataRow[CostTypeIdFieldName] = DummyForeignKeyId;
            dataRow[CostCategoryNameFieldName] = CostCategory1;
            dataRow[CostCategoryIdFieldName] = DummyId;
            dataRow[CostCategoryUidFieldName] = DummyId;
            dataTable.Rows.Add(dataRow);

            var dataRow2 = dataTable.NewRow();
            dataRow2[CostTypeIdFieldName] = DummyForeignKeyId;
            dataRow2[CostCategoryNameFieldName] = CostCategory2;
            dataRow2[CostCategoryIdFieldName] = DummyId;
            dataRow2[CostCategoryUidFieldName] = DummyId2;
            dataTable.Rows.Add(dataRow2);

            var dataView = new DataView(dataTable);
            return dataView;
        }

        private static DataView CreateDataViewCostType()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(CostTypeNameFieldName);
            dataTable.Columns.Add(CostTypeIdFieldName);

            var dataRow = dataTable.NewRow();
            dataRow[CostTypeNameFieldName] = DummyColumnValue;
            dataRow[CostTypeIdFieldName] = DummyId;
            dataTable.Rows.Add(dataRow);

            var dataView = new DataView(dataTable);
            return dataView;
        }

        private static DataView CreateDataViewProject()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(ProjectExtUidFieldName);
            dataTable.Columns.Add(project_name);
            dataTable.Columns.Add(ProjectIdFieldName);

            var dataRow = dataTable.NewRow();
            dataRow[ProjectExtUidFieldName] = $"{DummyWebId.ToString()}.";
            dataRow[project_name] = DummyColumnValue;
            dataRow[ProjectIdFieldName] = DummyId;
            dataTable.Rows.Add(dataRow);

            var dataView = new DataView(dataTable);
            return dataView;
        }

        private static DataView CreateDataViewCostBreakdown()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(CalendarNameFieldName);
            dataTable.Columns.Add(CalendarIdFieldName);

            var dataRow = dataTable.NewRow();
            dataRow[CalendarNameFieldName] = DummyColumnValue;
            dataRow[CalendarIdFieldName] = DummyId;
            dataTable.Rows.Add(dataRow);

            var dataView = new DataView(dataTable);
            return dataView;
        }

        private static DataView CreateDataViewCostBreakdownAttribs()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(CalendarIdFieldName);
            dataTable.Columns.Add(BreakDownAttCostCategoryUidFieldName);
            dataTable.Columns.Add(BreakDownAttProductIdFieldName);
            dataTable.Columns.Add(BreakDownAttRateFieldName);
            dataTable.Columns.Add(BreakDownAttFteConvFieldName);

            var dataRow = dataTable.NewRow();
            dataRow[CalendarIdFieldName] = DummyCalendarId;
            dataRow[BreakDownAttCostCategoryUidFieldName] = DummyCostCategoryId;
            dataRow[BreakDownAttProductIdFieldName] = DummyPeriodId;
            dataRow[BreakDownAttRateFieldName] = DummyRate;
            dataRow[BreakDownAttFteConvFieldName] = DummyFteConv;
            dataTable.Rows.Add(dataRow);

            var dataView = new DataView(dataTable);
            return dataView;
        }
    }
}