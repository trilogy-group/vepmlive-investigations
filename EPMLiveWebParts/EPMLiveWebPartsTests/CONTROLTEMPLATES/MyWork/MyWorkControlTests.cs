using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveWebParts.CONTROLTEMPLATES.MyWork;
using EPMLiveWebParts.CONTROLTEMPLATES.MyWork.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.ControlTemplates.MyWork
{
    [TestClass]
    public class MyWorkControlTests
    {
        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string OtherDummyString = "OtherDummyString";
        private const string ExampleUrl = "http://example.com";
        private const string DecimalSeparator = ".";
        private const string ThousandSeparator = ",";
        private const string MethodPageLoad = "Page_Load";
        private const string FieldNonCompleteQuery = "NonCompleteQuery";
        private const string FieldDebugTag = "DebugTag";
        private const string FieldUserHasDesignerPermission = "UserHasDesignerPermission";
        private const string FieldNewItemButtonLists = "NewItemButtonLists";
        private MyWorkControl _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringWriter _responseWriter;
        private HttpResponse _httpResponse;
        private NameValueCollection _requestParams;
        private bool _connectedToDb;
        private bool _unconnectedFromDb;
        private Guid _siteId;
        private Guid _listId;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new MyWorkControl();
            _privateObject = new PrivateObject(_testObject);

            CreateSPContextShims();
            CreateSqlConnectionShims();
            CreatePageShims();

            _testObject.UseCentralizedSettings = true;

            ShimEPMData.AllInstances.GetTableSqlConnection = (_, __) => new DataTable();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _responseWriter?.Dispose();
        }

        [TestMethod]
        public void PageLoad_DebugMode_SetsDebugTag()
        {
            // Arrange
            _requestParams.Add("epmdebug", "all");

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var debugTag = _privateObject.GetFieldOrProperty(FieldDebugTag);
            this.ShouldSatisfyAllConditions(
                () => debugTag.ShouldNotBeNull(),
                () => debugTag.ShouldBe("debug=\"Error,Problem,Info,Check,IOError,IO,Cookie,Page\""));
        }

        [TestMethod]
        public void PageLoad_DesignerPermissions_SetsTrue()
        {
            // Arrange

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var doesHavePermission = _privateObject.GetFieldOrProperty(FieldUserHasDesignerPermission);
            this.ShouldSatisfyAllConditions(
                () => doesHavePermission.ShouldNotBeNull(),
                () => doesHavePermission.ShouldBe(true));
        }

        [TestMethod]
        public void PageLoad_GetNewItemButtonListsNotCentralizedSettings_SetsField()
        {
            // Arrange
            _testObject.UseCentralizedSettings = false;
            _testObject.MyWorkSelectedLst = new string[] { DummyString, string.Empty };
            _testObject.SelectedLst = new string[] { OtherDummyString, string.Empty };

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var newItemButtonLists = _privateObject.GetFieldOrProperty(FieldNewItemButtonLists);
            this.ShouldSatisfyAllConditions(
                () => newItemButtonLists.ShouldNotBeNull(),
                () => newItemButtonLists.ShouldBe(DummyString));
        }

        [TestMethod]
        public void PageLoad_GetNewItemButtonListsCentralizedSettings_SetsField()
        {
            // Arrange
            _testObject.UseCentralizedSettings = true;

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            var newItemButtonLists = _privateObject.GetFieldOrProperty(FieldNewItemButtonLists);
            var lists = newItemButtonLists.ShouldBeOfType<string>();
            this.ShouldSatisfyAllConditions(
                () => lists.ShouldNotBeNull(),
                () => lists.ShouldContainWithoutWhitespace($"{{Name:'{DummyString}',ListID:'{_listId.ToString().ToLower()}',UsePopUp:'False',Rollup:false}}"),
                () => lists.ShouldContainWithoutWhitespace($"{{Name:'{OtherDummyString}',ListID:'{_listId.ToString().ToLower()}',UsePopUp:'False',Rollup:false}}"));
        }

        [TestMethod]
        public void PageLoad_LoadGridSettings_SetsFields()
        {
            // Arrange

            // Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });
            //_testObject.GetType().GetMethod("LoadGridSettings", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            // Assert
            var isNewItemIndicatorEnabled = _privateObject.GetFieldOrProperty("IsNewItemIndicatorEnabled");
            var newItemIndicatorDays = _privateObject.GetFieldOrProperty("NewItemIndicatorDays");
            var daysAgoEnabled = _privateObject.GetFieldOrProperty("DaysAgoEnabled");
            var daysAgo = _privateObject.GetFieldOrProperty("DaysAgo");
            var daysAfterEnabled = _privateObject.GetFieldOrProperty("DaysAfterEnabled");
            var daysAfter = _privateObject.GetFieldOrProperty("DaysAfter");
            this.ShouldSatisfyAllConditions(
                () => isNewItemIndicatorEnabled.ShouldBe(true),
                () => newItemIndicatorDays.ShouldBe(4),
                () => daysAgoEnabled.ShouldBe(true),
                () => daysAgo.ShouldBe(2),
                () => daysAfterEnabled.ShouldBe(false),
                () => daysAfter.ShouldBe(3));
        }

        [TestMethod]
        public void PageLoad_ConfigureRegionalSettings_SetsProperties()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _testObject.DecimalSeparator.ShouldNotBeNull(),
                () => _testObject.GroupSeparator.ShouldNotBeNull(),
                () => _testObject.DecimalSeparator.ShouldBe(DecimalSeparator),
                () => _testObject.GroupSeparator.ShouldBe(ThousandSeparator));
        }

        //[TestMethod]
        //public void NonCompleteQuery_()
        //{
        //    // Arrange
        //    _privateObject.Invoke(MethodPageLoad, new object[] { _testObject, EventArgs.Empty });

        //    // Act
        //    var result = _privateObject.GetFieldOrProperty(FieldNonCompleteQuery);

        //    // Assert
        //}

        private void CreateSPContextShims()
        {
            _siteId = Guid.NewGuid();
            _listId = Guid.NewGuid();

            ShimSPContext.CurrentGet = () => new ShimSPContext { WebGet = () => new ShimSPWeb() };
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();

            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.DoesUserHavePermissionsStringSPBasePermissions = (a, b, c) => true;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.UrlGet = _ => ExampleUrl;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => ExampleUrl;

            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.IDGet = _ => _siteId;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.ContentDatabaseGet = _ => new ShimSPContentDatabase();

            ShimSPUser.AllInstances.IDGet = _ => Id;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;

            ShimSPListCollection.AllInstances.TryGetListString = (_, __) => new ShimSPList();
            ShimSPList.AllInstances.IDGet = _ => _listId;
            ShimSPList.AllInstances.HiddenGet = _ => false;

            ShimSPRegionalSettings.AllInstances.DecimalSeparatorGet = _ => DecimalSeparator;
            ShimSPRegionalSettings.AllInstances.ThousandSeparatorGet = _ => ThousandSeparator;

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = callback => callback?.Invoke();
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;

            ShimCoreFunctions.getLockedWebSPWeb = web => Guid.NewGuid();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, setting) =>
            {
                switch (setting)
                {
                    case myworksettings.GENERAL_SETTINGS_WORK_DAY_FILTERS:
                        return $"{bool.TrueString}|2|{bool.FalseString}|3";
                    case myworksettings.GENERAL_SETTINGS_NEW_ITEM_INDICATOR:
                        return $"{bool.TrueString}|4";
                    default:
                        return $"{DummyString},{OtherDummyString}";
                }
            };

            ShimGridGanttSettings.ConstructorSPList = (_, __) => { };
        }

        private void CreateSqlConnectionShims()
        {
            _connectedToDb = false;
            _unconnectedFromDb = false;

            var didRead = false;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => _connectedToDb = true;
            ShimSqlConnection.AllInstances.Close = _ => _unconnectedFromDb = true;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.ConstructorStringSqlConnection = (a, b, c) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                didRead = false;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (didRead)
                        {
                            return false;
                        }

                        didRead = true;
                        return true;
                    },
                    ItemGetInt32 = __ => Guid.NewGuid(),
                    GetGuidInt32 = __ => Guid.NewGuid(),
                    GetStringInt32 = __ => DummyString
                };
            };
        }

        private void CreatePageShims()
        {
            ShimControl.AllInstances.PageGet = _ => new ShimPage();

            _responseWriter = new StringWriter();
            _httpResponse = new HttpResponse(_responseWriter);
            ShimPage.AllInstances.ResponseGet = _ => _httpResponse;

            _requestParams = new NameValueCollection();
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = key =>
                {
                    return DummyString;
                },
                ParamsGet = () => _requestParams
            };
        }
    }
}
