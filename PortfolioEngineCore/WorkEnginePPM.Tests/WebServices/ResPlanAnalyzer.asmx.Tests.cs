using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.Services.Fakes;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using RPADataCache;
using Shouldly;
using WorkEnginePPM.Fakes;
using WebServiceFakes = System.Web.Services.Fakes;
using PortfolioEngineCoreFakes = PortfolioEngineCore.Fakes;
using PortfolioEngineCore.PortfolioItems.Fakes;
using PortfolioEngineCore.PortfolioItems;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ResPlanAnalyzerRemTests
    {
        private ResPlanAnalyzer testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags publicInstance;
        private BindingFlags nonPublicInstance;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPListCollection spListCollection;
        private ShimSPList spList;
        private ShimSPListItemCollection spListItemCollection;
        private ShimSPListItem spListItem;
        private ShimSPFieldCollection spFieldCollection;
        private ShimSPField spField;
        private ShimSPUser spUser;
        private ShimSPFolderCollection spFolderCollection;
        private ShimSPFolder spFolder;
        private ShimSPFileCollection spFileCollection;
        private ShimSPFile spFile;
        private ShimSPViewCollection spViewCollection;
        private ShimSPView spView;
        private ShimSPViewFieldCollection spViewFieldCollection;
        private ShimSPFieldLinkCollection spFieldLinkCollection;
        private ShimSPContentTypeCollection spContentTypeCollection;
        private ShimSPContentType spContentType;
        private ShimSqlTransaction transaction;
        private ShimSqlDataReader dataReader;
        private Guid guid;
        private DateTime currentDate;
        private int validations;
        private const int DummyInt = 1;
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;
        private const int Four = 4;
        private const int Five = 5;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string GetRPSessionKeyMethodName = "GetRPSessionKey";
        private const string ExecuteMethodName = "Execute";
        private const string GetRAUserCalendarInfoMethodName = "GetRAUserCalendarInfo";
        private const string GetPortfolioItemListMethodName = "GetPortfolioItemList";

        [TestInitialize]
        public void Setup()
        {
            testObject = new ResPlanAnalyzer();
            privateObject = new PrivateObject(testObject);

            SetupShims();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.BeginTransaction = _ => transaction;
            ShimDbTransaction.AllInstances.Dispose = _ => { };
            ShimSqlConnection.AllInstances.CreateCommand = _ => new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.TransactionSetSqlTransaction = (_, __) => { };
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuidSPUserToken = (_, _1, _2) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) => input;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
            ShimConfigFunctions.getConfigSettingSPWebString = (_, input) => input;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => spListItemCollection;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimUnsecuredLayoutsPageBase.AllInstances.SiteGet = _ => spSite;
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => spWeb;
            ShimAct.ConstructorSPWeb = (_, __) => new ShimAct();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSPContext.AllInstances.SiteGet = _ => spSite;
            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => new ShimSPFieldLookupValueCollection();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimDisabledItemEventScope.Constructor = _ => new ShimDisabledItemEventScope();
            ShimDisabledItemEventScope.AllInstances.Dispose = _ => { };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => spUser;
            ShimSPSiteDataQuery.Constructor = _ => new ShimSPSiteDataQuery();
            ShimSqlDb.AllInstances.TransactionGet = _ => transaction;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimSqlDb.ReadDateValueObject = _ => currentDate;
            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean = (_, _1, _2, _3, _4) => StatusEnum.rsRequestInvalid;
            WebServiceFakes.ShimWebService.AllInstances.ContextGet = _ => null;
            PortfolioEngineCoreFakes.ShimUtilities.GetConnectionStringString = _ => DummyString;
            ShimDbConnectionStringBuilder.AllInstances.ConnectionStringGet = _ => DummyString;
            ShimDbConnectionStringBuilder.AllInstances.ConnectionStringSetString = (_, __) => { };
            ShimDbConnectionStringBuilder.AllInstances.RemoveString = (_, __) => true;
            ShimWebAdmin.CapturePFEBaseInfoStringOutStringOutStringOutStringOutStringOutSecurityLevelsOut =
                (out string basepath, out string username, out string ppmId, out string ppmCompany, out string ppmDbConn, out SecurityLevels secLevel) =>
                {
                    basepath = DummyString;
                    username = DummyString;
                    ppmId = DummyString;
                    ppmCompany = DummyString;
                    ppmDbConn = DummyString;
                    secLevel = SecurityLevels.AdminCalc;
                };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            currentDate = DateTime.Now;
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                SiteGet = () => spSite,
                ListsGet = () => spListCollection,
                GetFolderString = _ => spFolder,
                GetFileString = _ => spFile,
                FoldersGet = () => spFolderCollection,
                CurrentUserGet = () => spUser,
                ServerRelativeUrlGet = () => SampleUrl,
                AllUsersGet = () => new ShimSPUserCollection(),
                SiteUsersGet = () => new ShimSPUserCollection(),
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => spWeb,
                FeaturesGet = () => new ShimSPFeatureCollection()
                {
                    ItemGetGuid = _ => new ShimSPFeature()
                },
                ContentDatabaseGet = () => new ShimSPContentDatabase()
            };
            spListCollection = new ShimSPListCollection()
            {
                TryGetListString = _ => spList,
                ItemGetString = _ => spList,
                ItemGetGuid = _ => spList
            };
            spList = new ShimSPList()
            {
                IDGet = () => guid,
                FieldsGet = () => spFieldCollection,
                GetItemByIdInt32 = _ => spListItem,
                ItemsGet = () => spListItemCollection,
                GetItemsSPQuery = _ => spListItemCollection,
                RootFolderGet = () => spFolder,
                ParentWebGet = () => spWeb,
                DefaultViewGet = () => spView,
                ViewsGet = () => spViewCollection,
                ContentTypesGet = () => spContentTypeCollection,
                TitleGet = () => DummyString,
                EventReceiversGet = () => new ShimSPEventReceiverDefinitionCollection(),
                DefaultViewUrlGet = () => SampleUrl
            };
            spListItemCollection = new ShimSPListItemCollection()
            {
                CountGet = () => DummyInt,
                ItemGetInt32 = _ => spListItem
            };
            spListItem = new ShimSPListItem()
            {
                IDGet = () => DummyInt,
                TitleGet = () => DummyString,
                ItemGetString = _ => DummyString,
                ItemGetGuid = _ => DummyString,
                ItemSetGuidObject = (_, __) => { },
                Update = () => { },
                FileGet = () => spFile,
                ParentListGet = () => spList,
                NameGet = () => DummyString
            };
            spFieldCollection = new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = _ => spField,
                ContainsFieldString = _ => false,
                GetFieldString = _ => spField,
                ItemGetString = _ => spField
            };
            spField = new ShimSPField()
            {
                IdGet = () => guid,
                TitleGet = () => DummyString,
                InternalNameGet = () => DummyString,
                ReadOnlyFieldGet = () => false,
                HiddenGet = () => false,
                ReorderableGet = () => true,
                TypeAsStringGet = () => DummyString
            };
            spUser = new ShimSPUser()
            {
                IDGet = () => DummyInt,
                IsSiteAdminGet = () => true,
                UserTokenGet = () => new ShimSPUserToken()
            };
            spFolderCollection = new ShimSPFolderCollection()
            {
                ItemGetString = _ => spFolder,
                AddString = _ => spFolder
            };
            spFolder = new ShimSPFolder()
            {
                ExistsGet = () => false,
                SubFoldersGet = () => spFolderCollection,
                FilesGet = () => spFileCollection,
                UrlGet = () => SampleUrl,
                UniqueIdGet = () => guid,
                ParentWebGet = () => spWeb
            };
            spFileCollection = new ShimSPFileCollection()
            {
                CountGet = () => DummyInt,
                AddStringByteArrayBoolean = (_1, _2, _3) => spFile,
                AddStringStream = (_1, _2) => spFile,
                ItemGetString = _ => spFile
            };
            spFile = new ShimSPFile()
            {
                Delete = () => { },
                OpenBinaryStream = () => null,
                NameGet = () => DummyString,
                GetListItemStringArray = _ => spListItem
            };
            spViewCollection = new ShimSPViewCollection()
            {
                ItemGetString = _ => spView
            };
            spView = new ShimSPView()
            {
                ViewFieldsGet = () => spViewFieldCollection,
                ServerRelativeUrlGet = () => SampleUrl
            };
            spViewFieldCollection = new ShimSPViewFieldCollection();
            spContentTypeCollection = new ShimSPContentTypeCollection()
            {
                ItemGetString = _ => spContentType
            };
            spContentType = new ShimSPContentType()
            {
                IdGet = () => default(SPContentTypeId),
                FieldLinksGet = () => spFieldLinkCollection
            };
            spFieldLinkCollection = new ShimSPFieldLinkCollection()
            {
                ItemGetGuid = _ => new ShimSPFieldLink()
            };
            transaction = new ShimSqlTransaction()
            {
                Commit = () => { },
                Rollback = () => { }
            };
            dataReader = new ShimSqlDataReader()
            {
                Read = () => false
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetRPSessionKey_WhenCalled_ReturnsConfigSetting()
        {
            // Arrange
            var expected = $"EPKBasepath_RPA{DummyString}";

            // Act
            var actual = (string)privateObject.Invoke(GetRPSessionKeyMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void Execute_FunctionIsReloadPlanData_ReturnsMethodOutput()
        {
            // Arrange
            const string function = "ReloadPlanData";
            const string dataXml = "";

            ShimResPlanAnalyzer.AllInstances.ReloadPlanDataHttpContextRPAData = (_, _1, _2) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimResPlanAnalyzer.GetCachedDataHttpContextString = (_, _1) =>
            {
                validations += 1;
                return null;
            };
            ShimResPlanAnalyzer.AllInstances.GetRPSessionKey = _ =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                ExecuteMethodName,
                publicInstance,
                new object[]
                {
                    function,
                    dataXml
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(DummyString),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GetRAUserCalendarInfo_WhenCalled_ReturnsCalenderInfo()
        {
            // Arrange
            const string calInfoXml = @"<xmlcfg/>";
            var actual = new XmlDocument();

            ShimResourceAnalyzer.AllInstances.GetResourceAnalyzerUserCalendarSettingsXMLStringOut =
                (ResourceAnalyzer instance, out string xml) =>
                {
                    validations += 1;
                    xml = calInfoXml;
                    return true;
                };

            // Act
            actual.LoadXml((string)privateObject.Invoke(
                GetRAUserCalendarInfoMethodName,
                publicStatic,
                new object[]
                {
                    default(HttpContext),
                    DummyString,
                    new RPAData()
                }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Context"].Value.ShouldBe("GetRAUserCalendarInfo"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.SelectNodes("//xmlcfg").Count.ShouldBe(1),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetPortfolioItemList_WhenCalled_Returns()
        {
            // Arrange
            const string calInfoXml = @"<xmlcfg/>";
            var actual = new XmlDocument();

            ShimPortfolioItems.AllInstances.ObtainManagedPortfolioItemsStringOutStringOutStringOut =
                (PortfolioItems instance, out string value1, out string value2, out string xml) =>
                {
                    validations += 1;
                    value1 = DummyString;
                    value2 = DummyString;
                    xml = calInfoXml;
                };

            // Act
            actual.LoadXml((string)privateObject.Invoke(
                GetPortfolioItemListMethodName,
                publicStatic,
                new object[]
                {
                    default(HttpContext),
                    DummyString,
                    new RPAData()
                }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Context"].Value.ShouldBe("GetPortfolioItemList"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.SelectSingleNode("//IDLists").Attributes["EXTLIST"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//IDLists").Attributes["IDLIST"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectNodes("//xmlcfg").Count.ShouldBe(1),
                () => validations.ShouldBe(1));
        }
    }
}