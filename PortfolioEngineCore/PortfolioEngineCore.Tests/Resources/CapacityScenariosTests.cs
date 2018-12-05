﻿using System;
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
using Shouldly;

namespace PortfolioEngineCore.Tests.Resources
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CapacityScenariosTests
    {
        private CapacityScenarios testObject;
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
        private const string RoleBasedCSAllowedMethodName = "RoleBasedCSAllowed";
        private const string GetCapacityScenariosXMLMethodName = "GetCapacityScenariosXML";
        private const string DeleteCapacityScenarioMethodName = "DeleteCapacityScenario";
        private const string AddCapacityScenarioXMLMethodName = "AddCapacityScenarioXML";
        private const string GetCapacityScenarioValuesXMLMethodName = "GetCapacityScenarioValuesXML";
        private const string SaveCapacityScenarioMethodName = "SaveCapacityScenario";
        private const string SaveCapacityScenarioDataMethodName = "SaveCapacityScenarioData";
        private const string SaveCurrentScenarioDataMethodName = "SaveCurrentScenarioData";
        private const string GetListTicketMethodName = "GetListTicket";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new CapacityScenarios
            (
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                SecurityLevels.AdminCalc
            );
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
                output = true;
                return DummyInt;
            };
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimSqlDb.ReadDateValueObject = _ => currentDate;
            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean = (_, _1, _2, _3, _4) => StatusEnum.rsRequestInvalid;
            ShimActivation.AllInstances.checkActivationStringStringString = (_, _1, _2, _3) => { };
            ShimPFEEncrypt.DecryptStringString = (_, input) => input;
            ShimDatabase.AllInstances.OpenDatabaseStringString = (_, _1, _2) => new SqlConnection();
            ShimBaseSecurity.AllInstances.ChecksScurityStringSecurityLevels = (_, _1, _2) => true;
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
                Read = () => false,
                Close = () => { },
                ItemGetString = input => input
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void RoleBasedCSAllowed_WhenCalled_ReturnsAllowedBoolean()
        {
            // Arrange
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var actual = (bool)privateObject.Invoke(RoleBasedCSAllowedMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => readHit.ShouldBe(Two));
        }

        [TestMethod]
        public void GetCapacityScenariosXML_WhenCalled_ReturnsCapacityScenariosXml()
        {
            // Arrange
            var readHit = 0;
            var parameters = new object[]
            {
                DummyString,
                true,
                DummyString
            };
            var scenarioXml = new XmlDocument();

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var actual = (bool)privateObject.Invoke(GetCapacityScenariosXMLMethodName, publicInstance, parameters);
            scenarioXml.LoadXml((string)parameters[0]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => scenarioXml.FirstChild.Name.ShouldBe("CapacityScenarios"),
                () => scenarioXml.FirstChild.Attributes["CB_ID"].Value.ShouldBe("-1"),
                () => scenarioXml.FirstChild.SelectNodes("//CapacityScenario").Count.ShouldBe(One),
                () => scenarioXml.FirstChild.SelectSingleNode("//CapacityScenario").Attributes["ID"].Value.ShouldBe(DummyInt.ToString()),
                () => scenarioXml.FirstChild.SelectSingleNode("//CapacityScenario").Attributes["Name"].Value.ShouldBe(DummyString),
                () => scenarioXml.FirstChild.SelectSingleNode("//CapacityScenario").Attributes["WRES"].Value.ShouldBe(DummyInt.ToString()));
        }

        [TestMethod]
        public void DeleteCapacityScenario_WhenCalled_DeletesCapacityScenario()
        {
            // Arrange
            var expected = new List<string>()
            {
                $"DELETE FROM EPGP_CAPACITY_SETVALUES WHERE CS_ID = {One}",
                $"DELETE FROM EPGP_CAPACITY_SETS WHERE CS_ID = {One}"
            };
            var queries = new List<string>();

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                validations += 1;
                queries.Add(instance.CommandText);
                return DummyInt;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                DeleteCapacityScenarioMethodName,
                publicInstance,
                new object[]
                {
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(2),
                () => expected.Any(x => !queries.Contains(x)).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateTrueRoleTrue_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = true;
            const bool isRole = true;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, WRES_ID, CS_ROLE_BASED)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateTrueRoleFalse_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = true;
            const bool isRole = false;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, WRES_ID)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateFalseRoleTrue_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = false;
            const bool isRole = true;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME, CS_ROLE_BASED)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void AddCapacityScenarioXML_PrivateFalseRoleFalse_AddsCapacityScenarioXML()
        {
            // Arrange
            const bool isPrivate = false;
            const bool isRole = false;
            var expected = new List<string>()
            {
                "SELECT MAX(CS_ID) AS MAXID FROM EPGP_CAPACITY_SETS",
                "INSERT INTO EPGP_CAPACITY_SETS (CS_ID,  DEPT_UID, CS_NAME)"
            };
            var queries = new List<string>();
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                queries.Add(instance.CommandText);
                return dataReader;
            };
            ShimCapacityScenarios.AllInstances.PrivateAllowed = _ => isPrivate;
            ShimCapacityScenarios.AllInstances.RoleBasedCSAllowed = _ => isRole;

            // Act
            var actual = (int)privateObject.Invoke(
                AddCapacityScenarioXMLMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true,
                    One,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => expected.Any(x => !queries.Any(q => q.Contains(x))).ShouldBeFalse());
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CapacityIdNegative_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = -5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("100"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Requested Capacity Scenario ID was less than -1"),
                () => result.ShouldBeFalse(),
                () => status.ShouldBe((int)StatusEnum.rsPIResourceCalendarNotSet));
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CapacityIdPositiveCalIdNegative_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = true;
                return DummyInt;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("101"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Planning Calendar has not been set.  Please contact your Administrator"),
                () => result.ShouldBeFalse(),
                () => status.ShouldBe((int)StatusEnum.rsPIResourceCalendarNotSet));
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CalIdNotNegativeGetPeriodsNotSuccess_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dbAccess, int CalID, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>();
                return StatusEnum.rsBasePathNotSet;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectNodes("//CS_Values/CS_Value").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Per_ID"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Hours"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("102"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Failed to load periods"),
                () => result.ShouldBeFalse());
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CalIdNotNegativeGetCostCategoryRolesNotSuccess_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dbAccess, int CalID, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = One,
                        PeriodName = DummyString,
                        StartDate = currentDate,
                        FinishDate = DateTime.Now
                    }
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetCostCategoryRolesStructDBAccessInt32Int32CStructOutBoolean = (DBAccess dbAccess, int CalID, int num, out CStruct costCategoryRoles, bool value) =>
            {
                costCategoryRoles = null;
                return StatusEnum.rsBasePathNotSet;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectNodes("//CS_Values/CS_Value").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Per_ID"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Hours"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectNodes("//Periods/Period").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Name"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Start"].Value.ShouldBe(currentDate.ToString("yyyy-MM-ddTHH:mm:ss")),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Value"].Value.ShouldBe("103"),
                () => actual.FirstChild.SelectSingleNode("//Error").Attributes["Desc"].Value.ShouldBe("Failed to Cost Category Roles etc."),
                () => result.ShouldBeFalse());
        }

        [TestMethod]
        public void GetCapacityScenarioValuesXML_CostCategoryRolesSuccess_ReturnsCapaciryScenarioValuesXml()
        {
            // Arrange
            const int capacityId = 5;
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                capacityId,
                DummyString,
                One
            };
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimDBCommon.GetPeriodsDBAccessInt32ListOfCPeriodOut = (DBAccess dbAccess, int CalID, out List<CPeriod> clnPeriods) =>
            {
                clnPeriods = new List<CPeriod>()
                {
                    new CPeriod()
                    {
                        PeriodID = One,
                        PeriodName = DummyString,
                        StartDate = currentDate,
                        FinishDate = DateTime.Now
                    }
                };
                return StatusEnum.rsSuccess;
            };
            ShimDBCommon.GetCostCategoryRolesStructDBAccessInt32Int32CStructOutBoolean = (DBAccess dbAccess, int CalID, int num, out CStruct costCategoryRoles, bool value) =>
            {
                const string costCategoryRolesXml = @"
                    <CostCategoryRoles>
                        <CostCategoryRole/>
                        <CostCategoryRole/>
                    </CostCategoryRoles>";
                costCategoryRoles = new CStruct();
                costCategoryRoles.LoadXML(costCategoryRolesXml);
                return StatusEnum.rsSuccess;
            };

            // Act
            var result = (bool)privateObject.Invoke
            (
                GetCapacityScenarioValuesXMLMethodName,
                publicInstance,
                parameters
            );
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe("CapacityScenarioValues"),
                () => actual.FirstChild.SelectNodes("//CS_Values/CS_Value").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Per_ID"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Values/CS_Value").Attributes["Hours"].Value.ShouldBe(DummyInt.ToString()),
                () => actual.FirstChild.SelectNodes("//Periods/Period").Count.ShouldBe(One),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Name"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["Start"].Value.ShouldBe(currentDate.ToString("yyyy-MM-ddTHH:mm:ss")),
                () => actual.FirstChild.SelectNodes("//CostCategoryRoles/CostCategoryRole").Count.ShouldBe(Two),
                () => result.ShouldBeTrue());
        }

        [TestMethod]
        public void SaveCapacityScenario_WhenCalled_SavesCapacityScenario()
        {
            // Arrange
            const int capacityId = 5;
            const string xmlData = @"
                <CS_Values>
                    <CS_Value Per_ID=""1"" Role_ID=""1"" Hours=""1"" FTEs=""1""/>
                    <CS_Value Per_ID=""2"" Role_ID=""2"" Hours=""2"" FTEs=""2""/>
                </CS_Values>";
            var readHit = 0;
            var expectedQueries = new List<string>()
            {
                $"DELETE FROM EPGP_CAPACITY_SETVALUES WHERE CS_ID = {capacityId}",
                $"INSERT INTO EPGP_CAPACITY_SETVALUES (CS_ID, CB_ID, DEPT_UID, BD_PERIOD, ROLE_ID, CS_AVAIL, CS_FTES)  VALUES({capacityId},{DummyInt},0,@prd,@roleid,@hrs,@ftes)"
            };
            var queries = new List<string>();

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object input, out bool output) =>
            {
                output = false;
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                validations += 1;
                queries.Add(instance.CommandText);
                return DummyInt;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                SaveCapacityScenarioMethodName,
                publicInstance,
                new object[]
                {
                    capacityId,
                    xmlData
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => queries.Count.ShouldBe(3),
                () => expectedQueries.Any(x => !queries.Contains(x)).ShouldBeFalse(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void SaveCapacityScenarioData_WhenCalled_SavesCapacityScenarioData()
        {
            // Arrange
            var xmlData = $@"
                <xmlcfg Name=""{DummyString}"" ID=""-1"" WRES=""0"" DEPT=""1"" RMODE=""1"">
                    <CS_Values/>
                </xmlcfg>";
            var actual = new XmlDocument();
            var parameters = new object[]
            {
                xmlData,
                DummyString,
                DummyInt
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimCapacityScenarios.AllInstances.AddCapacityScenarioXMLStringBooleanInt32Int32 = (_, capName, wres, deptId, mode) =>
            {
                if (capName.Equals(DummyString) && wres.Equals(false) && deptId.Equals(One) && mode.Equals(One))
                {
                    validations += 1;
                }
                return Five;
            };
            ShimCapacityScenarios.AllInstances.SaveCapacityScenarioInt32String = (_, capacityId, xml) =>
            {
                if (capacityId.Equals(Five))
                {
                    validations += 1;
                }
                return true;
            };

            // Act
            var result = (bool)privateObject.Invoke(SaveCapacityScenarioDataMethodName, publicInstance, parameters);
            var status = (int)parameters[2];
            actual.LoadXml((string)parameters[1]);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => status.ShouldBe(Zero),
                () => actual.FirstChild.Name.ShouldBe("CSID"),
                () => actual.FirstChild.Attributes["Value"].Value.ShouldBe(Five.ToString()),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void SaveCurrentScenarioData_WhenCalled_SavesCurrentScenarioData()
        {
            // Arrange
            const string dataXml = @"<xmlcfg Name=""{DummyString}"" ID=""-1"" WRES=""0"" DEPT=""1"" RMODE=""1""/>";
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit.Equals(One);
            };

            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlDb.ReadIntValueObject = _ => Zero;
            ShimCapacityScenarios.AllInstances.AddCapacityScenarioXMLStringBooleanInt32Int32 = (_, capName, wres, deptId, mode) =>
            {
                if (capName.Equals(DummyString) && wres.Equals(false) && deptId.Equals(One) && mode.Equals(One))
                {
                    validations += 1;
                }
                return Five;
            };
            ShimCapacityScenarios.AllInstances.SaveCapacityScenarioInt32String = (_, capacityId, xml) =>
            {
                if (capacityId.Equals(Five))
                {
                    validations += 1;
                }
                return true;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                SaveCurrentScenarioDataMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    dataXml
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void GetListTicket_WhenCalled_ReturnsListTicket()
        {
            // Arrange
            var readHit = 0;

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit <= Two;
            };

            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readHit = 0;
                return dataReader;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                if (instance.Parameters["@pdta"].Value.Equals($"{DummyString},{DummyString}"))
                {
                    validations += 1;
                }
                return DummyInt;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetListTicketMethodName,
                publicInstance,
                new object[]
                {
                    DummyString,
                    true
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBe(string.Empty),
                () => validations.ShouldBe(1));
        }
    }
}