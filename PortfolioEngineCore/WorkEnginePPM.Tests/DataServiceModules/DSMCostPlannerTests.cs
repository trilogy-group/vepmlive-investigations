using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.SharePoint.Fakes;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.DataServiceModules.Fakes;
using System.Data.Fakes;
using System.Reflection;
using System.Data;

namespace WorkEnginePPM.DataServiceModules.Tests
{
    [TestClass()]
    public class DSMCostPlannerTests
    {
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
    }
}