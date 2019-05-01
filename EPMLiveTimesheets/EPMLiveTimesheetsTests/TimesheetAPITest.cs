using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLive.TestFakes;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Web;
using System.Collections.Specialized;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.SharePoint.Fakes;
using TimeSheets;
using TimeSheets.Fakes;
using System.Data.SqlClient.Fakes;
using System.Globalization;
using Microsoft.SharePoint.Administration.Fakes;
using System.Collections;
using EPMLiveCore.ReportHelper.Fakes;
using System.Data.Fakes;
using System.Data;
using System.Data.Common.Fakes;

namespace EPMLiveTimesheets.Tests
{
    [TestClass]
    public class TimesheetAPITest : TestClassInitializer<TimesheetAPI>
    {
        private const string DummyUrl = "http://dummy.url";
        private const string FirstField = "FirstField";

        [TestInitialize]
        public new void TestInitialize()
        {

            ShimObject = ShimsContext.Create();
            ShimWebPart.AllInstances.ZoneIDGet = _ => DummyString;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            TestEntity = new TimesheetAPI();
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(TimesheetAPI));
            InitializeAllControls();

        }
        [TestMethod]
        public void iiGetTSData_MyWork_HasData()
        {
            //Arrange
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            ShimTimesheetSettings.ConstructorSPWeb = (instance, __) =>
            {
                instance.TimesheetFields = new ArrayList { FirstField };
            };
            ShimMyWorkReportData.AllInstances.ExecuteSqlString = (instance, _string) => GetDataTable();
            ShimDataTable.AllInstances.PrimaryKeySetDataColumnArray = (_, __) => { };

            //Act
            DataSet result =(DataSet)PrivateType.InvokeStatic("iiGetTSData", new ShimSqlConnection().Instance, new ShimSPWeb().Instance, DummyString, new Guid(), new ShimMyWorkReportData().Instance, DummyString);
            
            //Assert
            Assert.AreEqual(result.Tables.Count, Convert.ToInt32(PrivateType.GetStaticField("myworktableid")));
        }


        [TestMethod]
        public void iiGetTSData_MyWork_IsEmpty()
        {
            //Arrange
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            ShimTimesheetSettings.ConstructorSPWeb = (instance, __) =>
            {
                instance.TimesheetFields = new ArrayList { FirstField };
            };
            ShimMyWorkReportData.AllInstances.ExecuteSqlString = (instance, _string) => { return new DataTable(); };
            ShimDataTable.AllInstances.PrimaryKeySetDataColumnArray = (_, __) => { };

            //Act
            DataSet result = (DataSet)PrivateType.InvokeStatic("iiGetTSData", new ShimSqlConnection().Instance, new ShimSPWeb().Instance, DummyString, new Guid(), new ShimMyWorkReportData().Instance, DummyString);

            //Assert
            Assert.AreEqual(result.Tables.Count, Convert.ToInt32(PrivateType.GetStaticField("myworktableid")));
        }
        private void SetupShimsForSharePoint()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.ViewContextGet = _ => new ShimSPViewContext();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.LocaleGet = _ => new CultureInfo(1033);
            ShimSPWeb.AllInstances.LanguageGet = _ => DummyInt;
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = elevated => { elevated(); };
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPFarm.LocalGet = () => new ShimSPFarm();
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            ShimSPPersistedObject.AllInstances.NameGet = _ => DummyString;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPWebApplication.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPFeature();
            ShimSPViewContext.AllInstances.ViewGet = _ => new ShimSPView();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPView.AllInstances.TitleGet = _ => DummyString;
            ShimSPView.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DiscussionBoard;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
        }
        private static void SetupShimsForSqlClient()
        {
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => new ShimSqlCommand();
            
            ShimSqlDataAdapter.ConstructorSqlCommand = (_, __) => new ShimSqlDataAdapter();
            
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, dataset) =>
            {
                dataset.Tables.Add(GetDataTable());
                return DummyInt;
            };
            ShimDbDataAdapter.AllInstances.FillDataTable = (_, dataTable) =>
            {
                dataTable.Columns.Add("PROJECT");
                dataTable.Columns.Add("PROJECT_ID");
                dataTable.Columns.Add("SITE_UID");
                dataTable.Columns.Add("LIST_UID");
                dataTable.Columns.Add("WEB_UID");
                dataTable.Columns.Add("ITEM_ID");
                dataTable.Columns.Add("LIST");
                dataTable.Rows.Add(new object[] { DummyString, DummyInt, DummyGuid, DummyGuid, DummyGuid, DummyInt, DummyString });
                
                ShimMyWorkReportData.AllInstances.ExecuteSqlString = (instance, _string) => GetDataTable();
                return DummyInt;
            };
           
            ShimDataSet.Constructor = (@this) => new ShimDataSet(@this)
            {
                // fake DataTableCollection of data set
                TablesGet = () => new ShimDataTableCollection()
                {
                    ItemGetInt32 = (S) =>
                    {
                        return GetDataTable();
                    }
                },
            };


        }

        private static DataTable GetDataTable()
        {
            var dt = new DataTable("TestTABLE");
            dt.Columns.Add("LIST_UID");
            dt.Columns.Add("ITEM_ID");
            dt.Columns.Add("ASSIGNEDTOID");
            dt.Columns.Add("LIST");
            dt.Columns.Add("TS_UID");
            dt.Columns.Add("WEB_UID");
            dt.Columns.Add("SITE_UID");
            dt.Columns.Add("ListId");
            dt.Columns.Add("ItemId");
            dt.Columns.Add("PROJECT");
            dt.Columns.Add("PROJECT_ID");
            dt.Columns.Add("IsAssignment");
            dt.Rows.Add(new object[] { DummyString, DummyInt, DummyGuid, DummyGuid, DummyGuid, DummyInt, DummyString, DummyGuid, DummyGuid, DummyGuid, DummyInt, DummyString });
            return dt;
        }
    }
}
