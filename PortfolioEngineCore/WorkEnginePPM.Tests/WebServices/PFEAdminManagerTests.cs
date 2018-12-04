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
using System.Web.Fakes;
using System.Xml;
using System.Xml.Linq;
//using EPMLiveCore.API.Fakes;
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
using PortfolioEngineCore.Infrastructure.Entities;
using RPADataCache;
using Shouldly;
using WorkEnginePPM.Fakes;
using WorkEnginePPM.WebServices.Core;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PFEAdminManagerTests
    {
        private PFEAdminManager testObject;
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
        private int validations;
        private const int DummyInt = 1;
        private const int Zero = 0;
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
        private const string BuildCostCategoryTreeMethodName = "BuildCostCategoryTree";
        private const string InitilizeAdminCoreMethodName = "InitilizeAdminCore";
        private const string DeleteDepartmentsMethodName = "DeleteDepartments";
        private const string DeleteHolidayScheduleMethodName = "DeleteHolidaySchedule";
        private const string DeleteListWorkMethodName = "DeleteListWork";
        private const string DeletePersonalItemsMethodName = "DeletePersonalItems";
        private const string DeletePIListWorkMethodName = "DeletePIListWork";
        private const string DeleteResourceTimeoffMethodName = "DeleteResourceTimeoff";
        private const string DeleteWorkScheduleMethodName = "DeleteWorkSchedule";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new PFEAdminManager(spWeb);
            privateObject = new PrivateObject(testObject);
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
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
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
            //ShimSqlDb.ReadDateValueObject = _ => currentDate;
            //ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean = (_, _1, _2, _3, _4) => StatusEnum.rsRequestInvalid;
            //ShimActivation.AllInstances.checkActivationStringStringString = (_, _1, _2, _3) => { };
            //ShimPFEEncrypt.DecryptStringString = (_, input) => input;
            //ShimDatabase.AllInstances.OpenDatabaseStringString = (_, _1, _2) => new SqlConnection();
            //ShimBaseSecurity.AllInstances.ChecksScurityStringSecurityLevels = (_, _1, _2) => true;
            ShimConfigFunctions.GetCleanUsernameSPWeb = _ => DummyString;
            //ShimPFEBase.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimPFEBase();
            //ShimResponse.SuccessString = input => input;
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
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
        public void BuildCostCategoryTree_WhenCalled_ReturnsCostCategoryElement()
        {
            // Arrange
            const string xmlString = "<CostCategories/>";
            var childCostCategory = new CostCategory()
            {
                Id = Two,
                Name = "Child",
                Roles = new List<Role>(),
                CostCategories = new List<CostCategory>()
            };
            var parentCostCategory = new CostCategory()
            {
                Id = One,
                Name = "Parent",
                Roles = new List<Role>()
                {
                    new Role()
                    {
                        Id = One,
                        CostCategoryRoleId = One,
                        Name = DummyString
                    }
                },
                CostCategories = new List<CostCategory>()
                {
                    childCostCategory
                }
            };
            var document = XDocument.Parse(xmlString);

            var parameters = new object[]
            {
                parentCostCategory,
                document.Element("CostCategories")
            };

            // Act
            privateObject.Invoke(BuildCostCategoryTreeMethodName, nonPublicInstance, parameters);
            var actual = (XElement)parameters[1];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual
                    .Element("CostCategory")
                    .Attribute("Id")
                    .Value
                    .ShouldBe(One.ToString()),
                () => actual
                    .Element("CostCategory")
                    .Attribute("Name")
                    .Value
                    .ShouldBe("Parent"),
                () => actual
                    .Element("CostCategory")
                    .Element("Role")
                    .Attribute("CostCategoryRoleId")
                    .Value
                    .ShouldBe(One.ToString()),
                () => actual
                    .Element("CostCategory")
                    .Element("CostCategory")
                    .Attribute("Id")
                    .Value
                    .ShouldBe(Two.ToString()),
                () => actual
                    .Element("CostCategory")
                    .Element("CostCategory")
                    .Attribute("Name")
                    .Value
                    .ShouldBe("Child"));
        }

        [TestMethod]
        public void InitilizeAdminCore_WhenCalled_ReturnsAdminInfos()
        {
            // Arrange and Act
            var actual = (Admininfos)privateObject.Invoke(
                InitilizeAdminCoreMethodName,
                nonPublicInstance,
                new object[]
                {
                    SecurityLevels.AdminCalc,
                    false,
                    DummyString
                });

            // Assert
            actual.ShouldNotBeNull();
        }

        [TestMethod]
        public void DeleteDepartments_WhenCalled_ReturnsDataXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <Department Id=""1"" DataId=""1""/>
                        <Department Id=""2"" DataId=""2""/>
                        <Department Id=""3"" DataId=""3""/>
                        <Department Id=""4"" DataId=""4""/>
                    </Data>
                </xmlcfg>";
            var methodHit = 0;
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.CanDeleteLookupValueInt32StringOut = (Admininfos instance, int id, out string message) =>
            {
                methodHit += 1;
                message = DummyString;

                if (methodHit.Equals(Four))
                {
                    throw new Exception(DummyString);
                }

                return !methodHit.Equals(One);
            };
            ShimAdmininfos.AllInstances.DeleteDepartmentsInt32 = (_, input) =>
            {
                return input.Equals(Two);
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeleteDepartmentsMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectNodes("//Department").Count.ShouldBe(Four),
                () => actual.FirstChild.SelectSingleNode($@"//Department[@DataId=""{One}""]/Result").Attributes["Status"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode($@"//Department[@DataId=""{Two}""]/Result").Attributes["Status"].Value.ShouldBe(Zero.ToString()),
                () => actual.FirstChild.SelectSingleNode($@"//Department[@DataId=""{Three}""]/Result").Attributes["Status"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode($@"//Department[@DataId=""{Four}""]/Result").InnerText.ShouldBe($"Error: {DummyString}"),
                () => methodHit.ShouldBe(Four));
        }

        [TestMethod]
        public void DeleteHolidaySchedule_WhenCalled_ReturnsDataXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <HolidaySchedule Id=""1"" DataId=""1""/>
                        <HolidaySchedule Id=""2"" DataId=""2""/>
                        <HolidaySchedule Id=""3"" DataId=""3""/>
                    </Data>
                </xmlcfg>";
            var methodHit = 0;
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.CanDeleteHolidayScheduleInt32StringOut = (Admininfos instance, int id, out string message) =>
            {
                methodHit += 1;
                message = DummyString;

                if (methodHit.Equals(Three))
                {
                    throw new Exception(DummyString);
                }

                return !methodHit.Equals(One);
            };
            ShimAdmininfos.AllInstances.DeleteHolidayScheduleStringStringOut = (Admininfos instance, string xml, out string resultXml) =>
            {
                resultXml = @"<Result Status=""0""/>";
                return true;
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeleteHolidayScheduleMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.SelectNodes("//Data/HolidaySchedule").Count.ShouldBe(Two),
                () => actual.SelectSingleNode($@"//Data/HolidaySchedule[@DataId=""{One}""]/Result").Attributes["Status"].Value.ShouldBe(One.ToString()),
                () => actual.SelectSingleNode($@"//Data/Result").Attributes["Status"].Value.ShouldBe(Zero.ToString()),
                () => methodHit.ShouldBe(Three));
        }

        [TestMethod]
        public void DeleteListWork_WithoutException_ReturnsResultXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <ListWork Id=""1"" DataId=""1""/>
                    </Data>
                </xmlcfg>";
            const string resultXml = @"<Result Status=""1""/>";
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.DeleteListWorkStringStringOut = (Admininfos instance, string xml, out string outXml) =>
            {
                outXml = resultXml;
                return true;
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeleteListWorkMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe(DeleteListWorkMethodName),
                () => actual.FirstChild.SelectNodes("//Result").Count.ShouldBe(2),
                () => actual.FirstChild.SelectSingleNode($"//Result[@Status='{Zero}']").ShouldNotBeNull(),
                () => actual.FirstChild.SelectSingleNode($"//Result[@Status='{One}']").ShouldNotBeNull());
        }

        [TestMethod]
        public void DeleteListWork_WithException_ReturnsResultXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <ListWork Id=""1"" DataId=""1""/>
                    </Data>
                </xmlcfg>";
            const string resultXml = @"<Result Status=""0""/>";
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.DeleteListWorkStringStringOut = (Admininfos instance, string xml, out string outXml) =>
            {
                outXml = resultXml;
                throw new Exception(DummyString);
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeleteListWorkMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["PfEFailure"].Value.ShouldBe(bool.FalseString));
        }

        [TestMethod]
        public void DeletePersonalItems_WhenCalled_ReturnsDataXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <Item Id=""1"" DataId=""1""/>
                        <Item Id=""2"" DataId=""2""/>
                        <Item Id=""3"" DataId=""3""/>
                    </Data>
                </xmlcfg>";
            var methodHit = 0;
            var actual = new XmlDocument();

            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();
            ShimAdmininfos.AllInstances.DeletePersonalItemInt32 = (_, __) =>
            {
                methodHit += 1;
                if (methodHit.Equals(Three))
                {
                    throw new Exception(DummyString);
                }
                return !methodHit.Equals(One);
            };

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeletePersonalItemsMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.SelectNodes("//Data/Item").Count.ShouldBe(Three),
                () => actual.SelectSingleNode($@"//Data/Item[@DataId=""{One}""]/Result").Attributes["Status"].Value.ShouldBe(One.ToString()),
                () => actual.SelectSingleNode($@"//Data/Item[@DataId=""{Two}""]/Result").Attributes["Status"].Value.ShouldBe(Zero.ToString()),
                () => actual.SelectSingleNode($@"//Data/Item[@DataId=""{Three}""]/Result").InnerText.ShouldBe($"Error: {DummyString}"),
                () => methodHit.ShouldBe(Three));
        }

        [TestMethod]
        public void DeletePIListWork_WithoutException_ReturnsResultXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <ListWork Id=""1"" DataId=""1""/>
                    </Data>
                </xmlcfg>";
            const string resultXml = @"<Result Status=""1""/>";
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.DeletePIListWorkStringStringOut = (Admininfos instance, string xml, out string outXml) =>
            {
                outXml = resultXml;
                return true;
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeletePIListWorkMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe(DeletePIListWorkMethodName),
                () => actual.FirstChild.SelectNodes("//Result").Count.ShouldBe(2),
                () => actual.FirstChild.SelectSingleNode($"//Result[@Status='{Zero}']").ShouldNotBeNull(),
                () => actual.FirstChild.SelectSingleNode($"//Result[@Status='{One}']").ShouldNotBeNull());
        }

        [TestMethod]
        public void DeletePIListWork_WithException_ReturnsResultXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <ListWork Id=""1"" DataId=""1""/>
                    </Data>
                </xmlcfg>";
            const string resultXml = @"<Result Status=""0""/>";
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.DeletePIListWorkStringStringOut = (Admininfos instance, string xml, out string outXml) =>
            {
                outXml = resultXml;
                throw new Exception(DummyString);
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeletePIListWorkMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["PfEFailure"].Value.ShouldBe(bool.FalseString));
        }

        [TestMethod]
        public void DeleteResourceTimeoff_WhenCalled_ReturnsDataXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <Resource Id=""1"" DataId=""1""/>
                        <Resource Id=""2"" DataId=""2""/>
                    </Data>
                </xmlcfg>";
            var methodHit = 0;
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.DeleteResourceTimeoffStringStringOut = (Admininfos instance, string xml, out string resultXml) =>
            {
                methodHit += 1;
                resultXml = @"<Result Status=""0""/>";
                if (methodHit.Equals(Two))
                {
                    throw new Exception(DummyString);
                }
                return true;
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeleteResourceTimeoffMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.SelectNodes("//Data/Resource").Count.ShouldBe(One),
                () => actual.SelectSingleNode($@"//Data/Resource/Result").InnerText.ShouldBe($"Error: {DummyString}"),
                () => actual.SelectSingleNode($@"//Data/Result").Attributes["Status"].Value.ShouldBe(Zero.ToString()),
                () => methodHit.ShouldBe(Two));
        }

        [TestMethod]
        public void DeleteWorkSchedule_WhenCalled_ReturnsDataXml()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Data>
                        <WorkSchedule Id=""1"" DataId=""1""/>
                        <WorkSchedule Id=""2"" DataId=""2""/>
                        <WorkSchedule Id=""3"" DataId=""3""/>
                    </Data>
                </xmlcfg>";
            var methodHit = 0;
            var actual = new XmlDocument();

            ShimAdmininfos.AllInstances.CanDeleteWorkScheduleInt32StringOut = (Admininfos instance, int id, out string message) =>
            {
                methodHit += 1;
                message = DummyString;

                if (methodHit.Equals(Three))
                {
                    throw new Exception(DummyString);
                }

                return !methodHit.Equals(One);
            };
            ShimAdmininfos.AllInstances.DeleteWorkScheduleStringStringOut = (Admininfos instance, string xml, out string resultXml) =>
            {
                resultXml = @"<Result Status=""0""/>";
                return true;
            };
            ShimAdmininfos.ConstructorStringStringStringStringStringSecurityLevelsBoolean = (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdmininfos();

            // Act
            actual.LoadXml((string)privateObject.Invoke(DeleteWorkScheduleMethodName, nonPublicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.SelectNodes("//Data/WorkSchedule").Count.ShouldBe(Two),
                () => actual.SelectSingleNode($@"//Data/WorkSchedule[@DataId=""{One}""]/Result").Attributes["Status"].Value.ShouldBe(One.ToString()),
                () => actual.SelectSingleNode($@"//Data/Result").Attributes["Status"].Value.ShouldBe(Zero.ToString()),
                () => methodHit.ShouldBe(Three));
        }
    }
}