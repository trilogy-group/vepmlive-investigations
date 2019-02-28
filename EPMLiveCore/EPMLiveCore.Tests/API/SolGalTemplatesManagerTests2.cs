using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Net.Fakes;
using System.Text;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.API.SolLibTemplatesManager"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class SolLibTemplatesManagerTests2
    {
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private PrivateType _privateType;
        private IDisposable _shimsContext;
        private readonly StringBuilder _query = new StringBuilder();
        private readonly StringBuilder _functionsInvoked = new StringBuilder();
        private int _currentDataReaderCount;
        private int _maxDatareaderCount;
        private int _dataReaderResult;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitShims();
            _query.Clear();
            _functionsInvoked.Clear();
            _maxDatareaderCount = 1;
            _currentDataReaderCount = 0;

            _privateType = new PrivateType(typeof(SolLibTemplatesManager));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void CreateNewWorkspace_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xml = @"<data>
                        </data>";
            var parameters = new object[]
            {
                new XMLDataManager(xml),
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance
            };
            const string ExpectedResult = "00000000-0000-0000-0000-000000000000";
            var expectedFunctions = new[]
            {
                "WorkspaceData.SendCompletedSignalsToDBWorkspaceData.AddWsPermission",
                "SolLibTemplatesManager.RenameProjectFileByProject",
                "SolLibTemplatesManager.SyncOldItemWithNewItem"
            };

            // Act
            const string MethodName = "CreateNewWorkspace";
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBe(ExpectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void CreateNewWorkspace_ItemsCountZero_CheckBehaviour()
        {
            // Arrange
            var xml = @"<data>
                        </data>";
            var parameters = new object[]
            {
                new XMLDataManager(xml),
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance
            };
            ShimSolLibTemplatesManager.FieldExistsInListSPListString = (_, _1) => false;
            var sPListItems = new List<SPListItem>();
            ShimSPListItemCollection.AllInstances.CountGet = _ => sPListItems.Count;
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => sPListItems.GetEnumerator();
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (_, index) => new ShimSPListItem();
            const string ExpectedResult = "00000000-0000-0000-0000-000000000000";
            var expectedFunctions = new[]
            {
                "WorkspaceData.SendCompletedSignalsToDBWorkspaceData.AddWsPermission",
                "SolLibTemplatesManager.SyncOldItemWithNewItem"
            };

            // Act
            const string MethodName = "CreateNewWorkspace";
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBe(ExpectedResult));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void ExecuteCreateWorkspaceProcedures_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                new ShimXMLDataManager().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance
            };
            ShimSolLibTemplatesManager.ChildWebExistsSPSiteString = (_, _1) => false;
            ShimSolLibTemplatesManager.CreateNewWorkspaceFromInstalledTempsListOfStringSPListItemXMLDataManagerSPSiteSPWebSPSiteSPWeb =
                (_, _1, _2, _3, _4, _5, _6) =>
                {
                    return DummyString;
                };
            ShimXMLDataManager.AllInstances.GetPropValString = (_, propertyName) =>
            {
                var returnString = string.Empty;
                switch (propertyName)
                {
                    case "UniquePermission":
                    case "InheritTopLink":
                    case "IncludeContent":
                    case "DoNotDelRequest":
                    case "IsTemplate":
                    case "IsNew":
                        returnString = true.ToString();
                        break;
                    case "ListGuid":
                        returnString = new Guid().ToString();
                        break;
                    case "CreateNewFrom":
                        returnString = "installedtemps";
                        break;
                    default:
                        returnString = DummyInt.ToString();
                        break;
                }

                return returnString;
            };

            // Act
            const string MethodName = "ExecuteCreateWorkspaceProcedures";
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void CreateNewWorkspaceFromInstalledTemps_ParametersGiven_ExceptionThrown()
        {
            // Arrange
            var parameters = new object[]
            {
                new List<string> { DummyString, DummyInt.ToString() },
                new ShimSPListItem().Instance,
                new ShimXMLDataManager().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance
            };

            // Act
            const string MethodName = "CreateNewWorkspaceFromInstalledTemps";
            Action action = () => _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            var ex = Should.Throw<Exception>(action);
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(NullReferenceException)),
                () => ex.Message.ShouldContain("Object reference not set"));
        }

        [TestMethod]
        public void CreateNewWorkspaceFromOnlineTemps_ParametersGiven_ThrowsException()
        {
            // Arrange
            var parameters = new object[]
            {
                new List<string> { DummyString, DummyInt.ToString() },
                new ShimXMLDataManager().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance
            };

            // Act
            const string MethodName = "CreateNewWorkspaceFromOnlineTemps";
            Action action = () => _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            var ex = Should.Throw<Exception>(action);
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(NullReferenceException)),
                () => ex.Message.ShouldContain("Object reference not set"));
        }

        [TestMethod]
        public void CreateNewWorkspaceFromExistingWorkspace_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                new List<string> { DummyString, DummyInt.ToString() },
                new ShimXMLDataManager().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance
            };

            // Act
            const string MethodName = "CreateNewWorkspaceFromExistingWorkspace";
            Action action = () => _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            var ex = Should.Throw<Exception>(action);
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(NullReferenceException)),
                () => ex.Message.ShouldContain("Object reference not set"));
        }

        [TestMethod]
        public void CreateWorkspace_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { "<dummy></dummy>" };
            ShimSolLibTemplatesManager.ExecuteCreateWorkspaceProceduresXMLDataManagerSPSiteSPWebSPSiteSPWeb = (_, _1, _2, _3, _4) => DummyString;
            ShimSolLibTemplatesManager.BuildWebInfoXmlStringXMLDataManagerSPSiteSPWebSPSiteSPWeb = (_, _1, _2, _3, _4, _5) => DummyString;

            // Act
            const string MethodName = "CreateWorkspace";
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void CompareSPWebTempByTitle_NullParametersGiven_ReturnZero()
        {
            // Arrange
            var parameters = new object[] { null, null };

            // Act
            const string MethodName = "CompareSPWebTempByTitle";
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(0));
        }

        [TestMethod]
        public void GetListEvents_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                new ShimSPList().Instance,
                DummyString,
                DummyString,
                new List<SPEventReceiverType>
                {
                    SPEventReceiverType.AppInstalled,
                    SPEventReceiverType.AppUninstalling
                }
            };

            // Act
            const string MethodName = "GetListEvents";
            var result = (List<SPEventReceiverDefinition>)_privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.Count.ShouldBe(0));
        }

        [TestMethod]
        public void SolutionFileExists_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPSite().Instance, DummyString };

            // Act
            const string MethodName = "SolutionFileExists";
            var result = (bool)_privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse());
        }

        [TestMethod]
        public void UserCanCreateSubSite_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPSite().Instance, DummyString };
            ShimSolLibTemplatesManager.UserCanCreateSubSiteSPSiteString = null;

            // Act
            const string MethodName = "UserCanCreateSubSite";
            var result = (bool)_privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue());
        }

        [TestMethod]
        public void BuildSPQueryToGetAll_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { };
            var expectedQuery = "<Where><Eq><FieldRef Name='Active' /><Value Type='Bool'>True</Value></Eq></Where><OrderBy><FieldRef Name=\"Title0\" Ascending=\"True\" /></OrderBy>";

            // Act
            const string MethodName = "BuildSPQueryToGetAll";
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedQuery));
        }

        [TestMethod]
        public void CreateNewWorkspaceFromSolutionGallery_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                new ShimXMLDataManager().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance,
                new ShimSPSite().Instance,
                new ShimSPWeb().Instance
            };
            var expectedResult = "00000000-0000-0000-0000-000000000000";

            // Act
            const string MethodName = "CreateNewWorkspaceFromSolutionGallery";
            var result = _privateType.InvokeStatic(MethodName, parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBe(expectedResult));
        }

        private void InitShims()
        {
            ShimSolLibTemplatesManager.UserCanCreateSubSiteSPSiteString = (_, _1) => true;
            ShimSolLibTemplatesManager.InstallOnlineSolutionByFeatureXmlListOfStringStringStringStringOutSPSiteSPWebSPSiteSPWeb =
                (List<string> tempSolNames, string xmlString, string rootFilePath, out string tempName, SPSite cSite, SPWeb cWeb, SPSite cESite, SPWeb cEWeb) =>
                {
                    tempName = DummyString;
                };
            ShimWebClient.Constructor = _ => { };
            ShimWebClient.AllInstances.DownloadDataString = (_, _1) =>
            {
                var encoding = Encoding.ASCII;
                var bytes = encoding.GetBytes(DummyString);
                return bytes;
            };
            ShimSPWeb.AllInstances.GetAvailableWebTemplatesUInt32 = (_, _1) => new ShimSPWebTemplateCollection().Instance;
            ShimSolLibTemplatesManager.GetSiteRelativeWebUrlStringSPSite = (_, _1) => DummyString;
            ShimSPListItem.AllInstances.ItemGetGuid = (_, _1) => DummyString;
            ShimSPList.AllInstances.GetItemByIdInt32 = (_, _1) => new ShimSPListItem().Instance;
            ShimSPListCollection.AllInstances.GetListGuidBoolean = (_, _1, _2) => new ShimSPList().Instance;
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyInt.ToString();
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection
            {
                DummyString,
                DummyInt.ToString(),
                true.ToString()
            };
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, internalName) =>
            {
                if (internalName != null && internalName.Contains("TemplateType"))
                {
                    return new ShimSPFieldChoice().Instance;
                }
                return new ShimSPFieldText().Instance;
            };
            ShimSPListItemCollection.AllInstances.Add = _ => new ShimSPListItem().Instance;
            ShimSolLibTemplatesManager.SyncOldItemWithNewItemSPSiteStringSPWebGuidSPListItemSPListItemStringSPListString =
                (_, _1, _2, _3, _4, _5, _6, _7, _8) =>
                {
                    _functionsInvoked.Append("\nSolLibTemplatesManager.SyncOldItemWithNewItem");
                };
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPList().Instance;
            ShimSPListCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimSPList().Instance;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList().Instance;
            ShimSolLibTemplatesManager.RenameProjectFileByProjectItemSPWebStringString = (_, _1, _2) =>
            {
                _functionsInvoked.Append("\nSolLibTemplatesManager.RenameProjectFileByProject");
            };
            ShimSPListItem.AllInstances.ItemGetString = (_, _1) => DummyString;
            var sPListItems = new List<SPListItem>
            {
                new ShimSPListItem()
            };
            ShimSPListItemCollection.AllInstances.CountGet = _ => sPListItems.Count;
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => sPListItems.GetEnumerator();
            ShimSPListItemCollection.AllInstances.ItemGetInt32 = (_, index) => new ShimSPListItem();
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Instance;
            ShimSPField.ConstructorSPFieldCollectionString = (_, _1, _2) => { };
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb().Instance;
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, _1) => true;
            ShimSPListCollection.AllInstances.TryGetListString = (_, _1) => new ShimSPList().Instance;
            ShimWebInitHelper.EeEnsureWebInitFeatureStringSPSiteSPWebSPSite = (_, _1, _2, _3) => true;
            ShimWorkspaceData.SendCompletedSignalsToDBGuidSPWebGuidStringStringStringString = (_, _1, _2, _3, _4, _5, _6) =>
            {
                _functionsInvoked.Append("WorkspaceData.SendCompletedSignalsToDB");
            };
            ShimWorkspaceData.AddWsPermissionGuidGuid = (_, _1) =>
            {
                _functionsInvoked.Append("WorkspaceData.AddWsPermission");
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext().Instance;
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb().Instance;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser().Instance;
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPWebCollection.AllInstances.ItemGetString = (_, key) => new ShimSPWeb().Instance;
            ShimSPWeb.AllInstances.WebsGet = _ => new ShimSPWebCollection().Instance;
            ShimSPListCollection.AllInstances.ItemGetString = (_, key) => new ShimSPList().Instance;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection().Instance;
            ShimCoreFunctions.createSiteStringStringStringStringStringBooleanBooleanSPWebGuidOutStringOutStringOutStringOut =
                (string title, string description, string url, string template, string user, bool unique, bool toplink,
            SPWeb parentWeb, out Guid createdWebId, out string createdWebUrl, out string createdWebServerRelativeUrl, out string createdWebTitle) =>
                {
                    createdWebId = new Guid();
                    createdWebUrl = DummyString;
                    createdWebServerRelativeUrl = DummyString;
                    createdWebTitle = DummyString;
                    return "0";
                };
            ShimSPSite.AllInstances.AllowUnsafeUpdatesSetBoolean = (_, value) => { };
            ShimSPSite.ConstructorString = (_, _1) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb().Instance;
            ShimSPWeb.AllInstances.DoesUserHavePermissionsStringSPBasePermissions = (_, _1, _2) => true;
            ShimSPSite.AllInstances.OpenWebString = (_, _1) => new ShimSPWeb().Instance;
            ShimXMLDataManager.AllInstances.GetPropValString = (_, propertyName) =>
            {
                var returnString = string.Empty;
                switch (propertyName)
                {
                    case "UniquePermission":
                    case "InheritTopLink":
                    case "IncludeContent":
                    case "DoNotDelRequest":
                    case "IsTemplate":
                    case "IsNew":
                    case "CreateFromLiveTemp":
                        returnString = true.ToString();
                        break;
                    case "ListGuid":
                        returnString = new Guid().ToString();
                        break;
                    default:
                        returnString = DummyInt.ToString();
                        break;
                }

                return returnString;
            };
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser().Instance;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite().Instance;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb().Instance;
            ShimDateTime.NowGet = () => new DateTime(2010, 10, 10, 10, 10, 10);
            SetupSqlShims();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
        }

        private void SetupSqlShims()
        {
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            ShimSqlConnection.ConstructorString = (_, _1) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                if (command.CommandText == "SELECT dbo.PFE_FN_CheckUserSecurityClearance(@Username, @SecurityLevel)")
                {
                    return true;
                }
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                _query.Append("\n" + command.CommandText);
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                _query.AppendLine(command.CommandText);
                return new ShimSqlDataReader
                {
                    Close = () => _currentDataReaderCount = 0,
                    Read = () =>
                    {
                        _currentDataReaderCount++;
                        return _currentDataReaderCount <= _maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        _dataReaderResult++;
                        if (key == "FA_FORMAT")
                        {
                            return 4;
                        }

                        if (key == "CMT_TIMESTAMP" || key == "RPEN_TIMESTAMP" || key == "PRD_FINISH_DATE" || key == "PRD_CLOSED_DATE")
                        {
                            return DateTime.Now;
                        }

                        if (key == "CMT_GUID")
                        {
                            return new Guid();
                        }

                        if (key == "ADM_PORT_COMMITMENTS_OPMODE")
                        {
                            return 0;
                        }

                        if (key == "CB_ID")
                        {
                            return 14;
                        }

                        if (key == "VIEW_DATA")
                        {
                            return "<Dummy></Dummy>";
                        }
                        return _dataReaderResult;
                    }
                }.Instance;
            };
        }
        
        private List<Action> AssertFunctions(string[] expectedFunctions)
        {
            var assertions = new List<Action>();
            foreach (var expectedFunction in expectedFunctions)
            {
                assertions.Add(() => _functionsInvoked.ToString().ShouldContain(expectedFunction));
            }
            return assertions;
        }
    }
}
