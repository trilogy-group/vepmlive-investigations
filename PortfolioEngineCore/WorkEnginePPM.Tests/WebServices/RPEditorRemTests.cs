using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Reflection;
using System.Web.Fakes;
using System.Web.SessionState.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RPEditorRemTests
    {
        private RPEditor testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags nonPublicStatic;
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
        private Dictionary<string, string> configSettings;
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
        private const string ResourcePlansMethodName = "ResourcePlans";
        private const string AdminFunctionsMethodName = "AdminFunctions";
        private const string BuildResultXMLMethodName = "BuildResultXML";
        private const string GeneralFunctionsMethodName = "GeneralFunctions";

        [TestInitialize]
        public void Setup()
        {
            testObject = new RPEditor();
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
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.TransactionSetSqlTransaction = (_, __) => { };
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.RootWebGet = _ => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, key) =>
            {
                if (configSettings.ContainsKey(key))
                {
                    return configSettings[key];
                }
                return DummyString;
            };
            ShimConfigFunctions.GetCleanUsernameSPWeb = _ => DummyString;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSqlDb.AllInstances.TransactionGet = _ => transaction;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimSqlDb.ReadDateValueObject = _ => currentDate;
            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean = (_, _1, _2, _3, _4) => StatusEnum.rsRequestInvalid;
            ShimHttpRequest.AllInstances.UrlGet = _ => new Uri(SampleUrl);
            ShimUri.AllInstances.PortGet = _ => DummyInt;
            ShimWebAdmin.GetSPSessionStringHttpContextString = (_, __) => DummyString;
        }

        private void SetupVariables()
        {
            validations = 0;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            nonPublicStatic = BindingFlags.Static | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            currentDate = DateTime.Now;
            configSettings = new Dictionary<string, string>()
            {
                ["epkbasepath"] = DummyString,
                ["ppmpid"] = DummyString,
                ["ppmcompany"] = DummyString,
                ["ppmdbconn"] = DummyString
            };
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
                Read = () => false,
                Close = () => { },
                ItemGetString = input => input,
                GetInt32Int32 = _ => DummyInt,
                GetStringInt32 = _ => DummyString,
                GetGuidInt32 = _ => guid,
                GetDateTimeInt32 = _ => currentDate
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void ResourcePlans_FunctionIsNotSaveResourcePlan_ReturnsResult()
        {
            // Arrange
            var xmlString = $@"<xmlcfg Function=""GetPlanRowNotes"" guid=""{guid}""/>";
            var context = new ShimHttpContext()
            {
                RequestGet = () => new ShimHttpRequest()
            };
            var readhit = 0;
            var actual = new XmlDocument();

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var result = (string)privateObject.Invoke(
                ResourcePlansMethodName,
                publicStatic,
                new object[]
                {
                    context.Instance,
                    xmlString
                });
            actual.LoadXml(result);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("GetPlanRowNotes"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.SelectSingleNode("//Grid/Toolbar").ShouldNotBeNull(),
                () => actual.FirstChild.SelectSingleNode("//Grid/Panel").ShouldNotBeNull(),
                () => actual.FirstChild.SelectSingleNode("//Grid/Cfg").ShouldNotBeNull(),
                () => actual.FirstChild.SelectSingleNode("//Grid/LeftCols").ShouldNotBeNull(),
                () => actual.FirstChild.SelectSingleNode("//Grid/Head").ShouldNotBeNull(),
                () => actual.FirstChild.SelectNodes($"//Grid/Body/B/I[@Title='{DummyString}']").Count.ShouldBe(Two));
        }

        [TestMethod]
        public void ResourcePlans_FunctionIsSaveResourcePlan_ReturnsResult()
        {
            // Arrange
            var xmlString = $@"
                <xmlcfg Function=""SaveResourcePlan"" guid=""{guid}"">
                    <StartPeriod>1</StartPeriod>
                    <FinishPeriod>1</FinishPeriod>
                    <Data>
                        <Grid/>
                    </Data>
                </xmlcfg>";
            var context = new ShimHttpContext()
            {
                RequestGet = () => new ShimHttpRequest()
            };
            var readhit = 0;
            var actual = new XmlDocument();

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimResourcePlans.AllInstances.SaveResourcePlanStructCStructInt32Int32 = (_, _1, _2, _3) =>
            {
                validations += 1;
                return true;
            };
            ShimRPEditor.ProcessAnyNotificationsString = _ =>
            {
                validations += 1;
            };

            // Act
            var result = (string)privateObject.Invoke(
                ResourcePlansMethodName,
                publicStatic,
                new object[]
                {
                    context.Instance,
                    xmlString
                });
            actual.LoadXml(result);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("SaveResourcePlan"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.SelectSingleNode("//Grid/IO").Attributes["Result"].Value.ShouldBe("0"),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void AdminFunctions_WhenCalled_ReturnsResultXml()
        {
            // Arrange
            var xmlString = $@"
                <xmlcfg guid=""{guid}"">
                    <Data Function=""SaveReportingConnection"">
                        <Grid/>
                    </Data>
                </xmlcfg>";
            var context = new ShimHttpContext()
            {
                RequestGet = () => new ShimHttpRequest()
            };
            var readhit = 0;

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimAdminFunctions.AllInstances.SaveReportingConnectionCStruct = (_, __) =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                AdminFunctionsMethodName,
                publicStatic,
                new object[]
                {
                    context.Instance,
                    xmlString
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(string.Empty),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void BuildResultXML_WhenCalled_ReturnsResultXml()
        {
            // Arrange
            var parameters = new object[]
            {
                DummyString,
                Five,
                DummyString
            };
            var actual = new XmlDocument();

            // Act
            var result = (CStruct)privateObject.Invoke(BuildResultXMLMethodName, nonPublicStatic, parameters);
            actual.LoadXml(result.XML());

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe(Five.ToString()),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.Attributes["Message"].Value.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GeneralFunctions_FunctionCreateTicket_ReturnsResultXml()
        {
            // Arrange
            const string functionName = "CreateTicket";
            var xmlString = $@"
                <xmlcfg Function=""{functionName}"" Context=""{DummyString}"">
                    <Data>
                    </Data>
                </xmlcfg>";
            var readhit = 0;
            var context = new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = _ => DummyString,
                    RemoveString = _ =>
                    {
                        validations += 1;
                    }
                }
            };
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                context.Instance,
                xmlString
            };

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimWebAdmin.GetConnectionStringHttpContext = _ => DummyString;
            ShimHttpContext.CurrentGet = () => context;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;

            // Act
            actual.LoadXml((string)privateObject.Invoke(GeneralFunctionsMethodName, publicStatic, parameters));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe(functionName),
                () => actual.FirstChild.Attributes["Context"].Value.ShouldBe(DummyString),
                () => Guid.TryParse(actual.FirstChild.Attributes["Ticket"].Value, out guid).ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GeneralFunctions_FunctionSynchronizeTeamExportNotSuccess_ReturnsResultXml()
        {
            // Arrange
            const string functionName = "SynchronizeTeam";
            var xmlString = $@"
                <xmlcfg Function=""{functionName}"" Context=""{DummyString}"">
                    <SynchronizeTeam Project_UIDs=""1,2"">
                    </SynchronizeTeam>
                </xmlcfg>";
            var readhit = 0;
            var context = new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = _ => DummyString,
                    RemoveString = _ =>
                    {
                        validations += 1;
                    }
                }
            };
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                context.Instance,
                xmlString
            };

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimWebAdmin.GetConnectionStringHttpContext = _ => DummyString;
            ShimHttpContext.CurrentGet = () => context;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = (DBAccess instance, string id, out string xmlOut) =>
            {
                validations += 1;
                xmlOut = DummyString;
                return StatusEnum.rsServerError;
            };

            // Act
            actual.LoadXml((string)privateObject.Invoke(GeneralFunctionsMethodName, publicStatic, parameters));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("GeneralFunctions2"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe("0"),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GeneralFunctions_FunctionSynchronizeTeamXmlNodeNull_ReturnsResultXml()
        {
            // Arrange
            const string functionName = "SynchronizeTeam";
            var xmlString = $@"
                <xmlcfg Function=""{functionName}"" Context=""{DummyString}"">
                    <SynchronizeTeam Project_UIDs=""1,2"">
                    </SynchronizeTeam>
                </xmlcfg>";
            var readhit = 0;
            var context = new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = _ => DummyString,
                    RemoveString = _ =>
                    {
                        validations += 1;
                    }
                }
            };
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                context.Instance,
                xmlString
            };

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimWebAdmin.GetConnectionStringHttpContext = _ => DummyString;
            ShimHttpContext.CurrentGet = () => context;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = (DBAccess instance, string id, out string xmlOut) =>
            {
                validations += 1;
                xmlOut = DummyString;
                return StatusEnum.rsSuccess;
            };
            ShimRPEditor.SendXMLToWorkEngineDBAccessStringStringXmlNodeOut =
                (DBAccess dba, string sContext, string sXMLRequest, out XmlNode xNode) =>
                {
                    validations += 1;
                    xNode = null;
                    return StatusEnum.rsSuccess;
                };

            // Act
            actual.LoadXml((string)privateObject.Invoke(GeneralFunctionsMethodName, publicStatic, parameters));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("GeneralFunctions4"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe("0"),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GeneralFunctions_FunctionSynchronizeTeamStatusNotZero_ReturnsResultXml()
        {
            // Arrange
            const string functionName = "SynchronizeTeam";
            var xmlString = $@"
                <xmlcfg Function=""{functionName}"" Context=""{DummyString}"">
                    <SynchronizeTeam Project_UIDs=""1,2"">
                    </SynchronizeTeam>
                    <Result Status=""1""/>
                </xmlcfg>";
            var readhit = 0;
            var context = new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = _ => DummyString,
                    RemoveString = _ =>
                    {
                        validations += 1;
                    }
                }
            };
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                context.Instance,
                xmlString
            };

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimWebAdmin.GetConnectionStringHttpContext = _ => DummyString;
            ShimHttpContext.CurrentGet = () => context;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = (DBAccess instance, string id, out string xmlOut) =>
            {
                validations += 1;
                xmlOut = DummyString;
                return StatusEnum.rsSuccess;
            };
            ShimRPEditor.SendXMLToWorkEngineDBAccessStringStringXmlNodeOut =
                (DBAccess dba, string sContext, string sXMLRequest, out XmlNode xNode) =>
                {
                    validations += 1;
                    actual.LoadXml(xmlString);
                    xNode = actual.FirstChild.SelectSingleNode("//Result");
                    return StatusEnum.rsSuccess;
                };

            // Act
            actual.LoadXml((string)privateObject.Invoke(GeneralFunctionsMethodName, publicStatic, parameters));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("GeneralFunctions8"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe("0"),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GeneralFunctions_FunctionSynchronizeTeamErrorNodeNotNull_ReturnsResultXml()
        {
            // Arrange
            const string functionName = "SynchronizeTeam";
            var xmlString = $@"
                <xmlcfg Function=""{functionName}"" Context=""{DummyString}"">
                    <SynchronizeTeam Project_UIDs=""1,2"">
                    </SynchronizeTeam>
                    <Result Status=""1"">
                        <Error ID=""1"">{DummyString}</Error>
                    </Result>
                </xmlcfg>";
            var readhit = 0;
            var context = new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = _ => DummyString,
                    RemoveString = _ =>
                    {
                        validations += 1;
                    }
                }
            };
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                context.Instance,
                xmlString
            };

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimWebAdmin.GetConnectionStringHttpContext = _ => DummyString;
            ShimHttpContext.CurrentGet = () => context;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = (DBAccess instance, string id, out string xmlOut) =>
            {
                validations += 1;
                xmlOut = DummyString;
                return StatusEnum.rsSuccess;
            };
            ShimRPEditor.SendXMLToWorkEngineDBAccessStringStringXmlNodeOut =
                (DBAccess dba, string sContext, string sXMLRequest, out XmlNode xNode) =>
                {
                    validations += 1;
                    actual.LoadXml(xmlString);
                    xNode = actual.FirstChild.SelectSingleNode("//Result");
                    return StatusEnum.rsSuccess;
                };

            // Act
            actual.LoadXml((string)privateObject.Invoke(GeneralFunctionsMethodName, publicStatic, parameters));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("GeneralFunctions6"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe("0"),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GeneralFunctions_FunctionSynchronizeTeamItemNotNull_ReturnsResultXml()
        {
            // Arrange
            const string functionName = "SynchronizeTeam";
            var xmlString = $@"
                <xmlcfg Function=""{functionName}"" Context=""{DummyString}"">
                    <SynchronizeTeam Project_UIDs=""1,2"">
                    </SynchronizeTeam>
                    <Result Status=""1"">
                        <Item Error=""ErrorMessage"">{DummyString}</Item>
                    </Result>
                </xmlcfg>";
            var readhit = 0;
            var context = new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = _ => DummyString,
                    RemoveString = _ =>
                    {
                        validations += 1;
                    }
                }
            };
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                context.Instance,
                xmlString
            };

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimWebAdmin.GetConnectionStringHttpContext = _ => DummyString;
            ShimHttpContext.CurrentGet = () => context;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = (DBAccess instance, string id, out string xmlOut) =>
            {
                validations += 1;
                xmlOut = DummyString;
                return StatusEnum.rsSuccess;
            };
            ShimRPEditor.SendXMLToWorkEngineDBAccessStringStringXmlNodeOut =
                (DBAccess dba, string sContext, string sXMLRequest, out XmlNode xNode) =>
                {
                    validations += 1;
                    actual.LoadXml(xmlString);
                    xNode = actual.FirstChild.SelectSingleNode("//Result");
                    return StatusEnum.rsSuccess;
                };

            // Act
            actual.LoadXml((string)privateObject.Invoke(GeneralFunctionsMethodName, publicStatic, parameters));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("GeneralFunctions7"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["ID"].Value.ShouldBe("0"),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GeneralFunctions_FunctionSynchronizeTeam_ReturnsResultXml()
        {
            // Arrange
            const string functionName = "SynchronizeTeam";
            var xmlString = $@"
                <xmlcfg Function=""{functionName}"" Context=""{DummyString}"">
                    <SynchronizeTeam Project_UIDs=""1,2"">
                    </SynchronizeTeam>
                    <Result Status=""0""/>
                </xmlcfg>";
            var readhit = 0;
            var context = new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = _ => DummyString,
                    RemoveString = _ =>
                    {
                        validations += 1;
                    }
                },
                RequestGet = () => new ShimHttpRequest()
            };
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                context.Instance,
                xmlString
            };

            dataReader.Read = () =>
            {
                readhit += 1;
                return readhit <= Two;
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readhit = 0;
                return dataReader;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimWebAdmin.GetConnectionStringHttpContext = _ => DummyString;
            ShimHttpContext.CurrentGet = () => context;
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsSuccess;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = (DBAccess instance, string id, out string xmlOut) =>
            {
                validations += 1;
                xmlOut = DummyString;
                return StatusEnum.rsSuccess;
            };
            ShimRPEditor.SendXMLToWorkEngineDBAccessStringStringXmlNodeOut =
                (DBAccess dba, string sContext, string sXMLRequest, out XmlNode xNode) =>
                {
                    validations += 1;
                    actual.LoadXml(xmlString);
                    xNode = actual.FirstChild.SelectSingleNode("//Result");
                    return StatusEnum.rsSuccess;
                };

            // Act
            actual.LoadXml((string)privateObject.Invoke(GeneralFunctionsMethodName, publicStatic, parameters));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("Result"),
                () => actual.FirstChild.Attributes["Status"].Value.ShouldBe("0"),
                () => actual.FirstChild.Attributes["Function"].Value.ShouldBe("SynchronizeTeam"),
                () => validations.ShouldBe(5));
        }
    }
}