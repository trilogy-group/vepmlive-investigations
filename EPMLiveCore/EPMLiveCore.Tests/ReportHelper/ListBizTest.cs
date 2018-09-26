using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.ReportHelper
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ListBizTest
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private ListBiz _listBiz;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const string DummyString2 = "DummyString'";
        private const int DummyInt = 1;
        private const string SiteId = "SiteId";

        private const string PopulateInstance = "PopulateInstance";
        private const string UpdateListMapping = "UpdateListMapping";
        private const string CreateNewMapping = "CreateNewMapping";
        private const string FieldExistsInCollection = "FieldExistsInCollection";
        private const string Create = "Create";
        private const string Update = "Update";
        private const string Delete = "Delete";
        private const string GetLog = "GetLog";
        private const string ClearLog = "ClearLog";
        private const string GetMaximumLogLevel = "GetMaximumLogLevel";
        private const string GetMappedFieldsStrings = "GetMappedFieldsStrings";
        private const string GetMappedFields = "GetMappedFields";
        private const string SetResourceListFlag = "SetResourceListFlag";
        private const string Snapshot = "Snapshot";
        private const string RegisterEvent = "RegisterEvent";
        private const string GetListEvents = "GetListEvents";
        private const string RemoveEvent = "RemoveEvent";

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.GetListMappingGuid = (_, _1) => null;

            _listBiz = new ListBiz(new Guid(), new Guid());
            _privateObject = new PrivateObject(_listBiz);
            _privateType = new PrivateType(typeof(ListBiz));
            InitializeSetUp();
            _privateObject.GetFieldOrProperty("ResourceList");
            _privateObject.GetFieldOrProperty("System");
            _privateObject.GetFieldOrProperty("ListName");
        }

        private void InitializeSetUp()
        {
            ShimSPSite.ConstructorGuid = (_, _1) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            var listSPWeb = new List<SPWeb>() { new ShimSPWeb() };
            ICollection<SPWeb> spWebCollection = listSPWeb;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection().Bind(spWebCollection);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        [TestMethod]
        public void PopulateInstance_DataRowIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimDataRow().Instance };
            var count = 0;
            ShimDataRow.AllInstances.ItemGetString = (_, _1) =>
            {
                count++;
                if (count >= 4)
                {
                    return true;
                }
                else
                {
                    return DummyString;
                }
            };
            
            // Act
            var actualResult = _privateObject.Invoke(
                PopulateInstance,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void UpdateListMapping_ListItemCollectionIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ListItemCollection() };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            var listSPWeb = new List<SPWeb>() { new ShimSPWeb() };
            ICollection<SPWeb> spWebCollection = listSPWeb;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection().Bind(spWebCollection);
            ShimSPWeb.AllInstances.DoesUserHavePermissionsStringSPBasePermissions = (_, _1, _2) => true;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimListBiz.AllInstances.UpdateColumnDefCollection = (_, _1) => { };
            ShimListBiz.AllInstances.RegisterEvent = _ => { };

            // Act
            var actualResult = _privateObject.Invoke(
                UpdateListMapping,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void UpdateListMapping_GuidIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new Guid() };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            var listSPWeb = new List<SPWeb>() { new ShimSPWeb() };
            ICollection<SPWeb> spWebCollection = listSPWeb;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection().Bind(spWebCollection);
            ShimSPWeb.AllInstances.DoesUserHavePermissionsStringSPBasePermissions = (_, _1, _2) => true;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => SiteId;
            ShimListBiz.AllInstances.GetMappedFields = _ => new ColumnDefCollection();
            ShimListBiz.AllInstances.UpdateColumnDefCollection = (_, _1) => { };
            ShimListBiz.AllInstances.RegisterEvent = _ => { };

            // Act
            var actualResult = _privateObject.Invoke(
                UpdateListMapping,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        private void CreateNewMappingSetup()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            ShimSPWeb.AllInstances.DoesUserHavePermissionsStringSPBasePermissions = (_, _1, _2) => true;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => SiteId;

            var listSPField = new List<SPField>() { new ShimSPField() };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind(listSPField);
            ShimSPField.AllInstances.HiddenGet = _ => false;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Guid;
            ShimSPFieldCollection.AllInstances.TryGetFieldByStaticNameString = (_, _1) => new ShimSPField()
            {
                TitleGet = () => DummyString,
                IdGet = () => new Guid()
            };
            ShimListBiz.FieldExistsInCollectionListItemCollectionString = (_, _1) => false;
            ShimListItemCollection.AllInstances.AddListItem = (_, _1) => new ShimListItem();
            ShimListBiz.AllInstances.CreateColumnDefCollectionListOfColumnDefString = (_, _1, _2, _3) => new ShimListBiz();

            ShimSPList.AllInstances.TitleGet = _ => DummyString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, _1) => DummyString;
            ShimListBiz.Constructor = _ => new ShimListBiz();
            ShimListBiz.AllInstances.GetMappedFields = _ => new ColumnDefCollection();
            ShimListBiz.AllInstances.UpdateColumnDefCollection = (_, _1) => { };
            ShimListBiz.AllInstances.RegisterEvent = _ => { };
        }

        [TestMethod]
        public void CreateNewMapping_GuidAndListItemCollectionIsNotNull_ReturnListBiz()
        {
            // Arrange
            var parameters = new object[] { new Guid(), new Guid(), new ListItemCollection(), true };
            CreateNewMappingSetup();

            // Act
            var actualResult = _privateType.InvokeStatic(
                CreateNewMapping,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void CreateNewMapping_GuidWebIdListItemCollectionIsNotNull_ReturnListBiz()
        {
            // Arrange
            var parameters = new object[] { new Guid(), new Guid(), new Guid(), new ListItemCollection() };
            CreateNewMappingSetup();
            ShimSPSite.AllInstances.OpenWebGuid = (_, _1) => new ShimSPWeb();
            ShimListBiz.AllInstances.CreateColumnDefCollectionListOfColumnDefStringGuid = (_, _1, _2, _3, _4) => new ShimListBiz();

            // Act
            var actualResult = _privateType.InvokeStatic(
                CreateNewMapping,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void FieldExistsInCollection_ListItemCollectionAndFieldNameIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { new ListItemCollection(), DummyString };
            var listListItem = new List<ListItem>() { new ShimListItem() };
            ShimListItemCollection.Constructor = _ => new ShimListItemCollection().Bind(listListItem);

            // Act
            var actualResult = _privateType.InvokeStatic(
                FieldExistsInCollection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }


        private void CreateSetup()
        {
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.AllDayEvent;
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.GetSafeTableNameString = (_, _1) => DummyString;
            ShimReportData.AllInstances.CreateTableStringListOfColumnDef = (_, _1, _2) => false;
            ShimReportData.AllInstances.InsertLogGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => true;
            ShimReportData.AllInstances.TableExistsString = (_, _1) => true;
            ShimReportData.AllInstances.InsertListGuidStringStringBoolean = (_, _1, _2, _3, _4) => false;
            ShimReportData.AllInstances.InsertListColumnsGuidListOfColumnDef = (_, _1, _2) => false;
            _privateObject.SetFieldOrProperty("_listName", DummyString);
        }

        [TestMethod]
        public void Create_ColumnDefCollectionAndListOfColumnDefIsNotNull_ConfirmResult()
        {
            // Arrange
            CreateSetup();
            var listColumnDef = new List<ColumnDef>() { new ColumnDef(new ShimSPField().Instance) };
            var parameters = new object[] { new ColumnDefCollection(), listColumnDef, DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                Create,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void Create_ColumnDefCollectionAndListOfColumnDefAndWebIdIsNotNull_ConfirmResult()
        {
            // Arrange
            CreateSetup();
            var listColumnDef = new List<ColumnDef>() { new ColumnDef(new ShimSPField().Instance) };
            var parameters = new object[] { new ColumnDefCollection(), listColumnDef, DummyString, new Guid() };
            ShimReportData.ConstructorBooleanGuidGuid = (_, _1, _2, _3) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                Create,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void Update_ColumnDefCollectionIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ColumnDefCollection() };
            ShimListBiz.AllInstances.GetMappedFields = _ => new ColumnDefCollection();
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.AddColumnsStringListOfColumnDef = (_, _1, _2) => false;
            ShimReportData.AllInstances.DeleteColumnsStringListOfColumnDef = (_, _1, _2) => false;
            ShimReportData.AllInstances.InsertListColumnsGuidListOfColumnDef = (_, _1, _2) => false;
            ShimReportData.AllInstances.DeleteListColumnsGuidListOfColumnDef = (_, _1, _2) => false;
            ShimReportData.AllInstances.UpdateListGuidBoolean = (_, _1, _2) => false;
            ShimReportData.AllInstances.InsertLogGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => false;
            _privateObject.SetFieldOrProperty("_listName", DummyString);

            // Act
            var actualResult = _privateObject.Invoke(
                Update,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void Delete_InputIsEmpty_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimListBiz.AllInstances.RemoveEvent = _ => { };
            _privateObject.SetFieldOrProperty("_tableName", DummyString2);
            _privateObject.SetFieldOrProperty("_tableNameSnapshot", DummyString2);
            ShimReportData.AllInstances.DeleteTableString = (_, _1) => true;
            ShimReportData.AllInstances.DeleteListGuid = (_, _1) => true;
            ShimReportData.AllInstances.DeleteLogGuid = (_, _1) => true;
            ShimReportData.AllInstances.DeleteWorkGuid = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                Delete,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void Delete_InputIsEmpty_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimListBiz.AllInstances.RemoveEvent = _ => { };
            _privateObject.SetFieldOrProperty("_tableName", DummyString2);
            _privateObject.SetFieldOrProperty("_tableNameSnapshot", DummyString2);
            ShimReportData.AllInstances.DeleteTableString = (_, _1) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                Delete,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void GetLog_MinimumLevelIsNotNull_ReturnDataTable()
        {
            // Arrange
            var parameters = new object[] { DummyInt };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.GetLogGuidInt32 = (_, _1, _2) => new DataTable();

            // Act
            var actualResult = _privateObject.Invoke(
                GetLog,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void ClearLog_TypeIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { DummyInt };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.DeleteLogGuidInt32 = (_, _1, _2) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ClearLog,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ClearLog_TypeIsNotNullSuccessIsFalse_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { string.Empty };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.DeleteLogGuid = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                ClearLog,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void GetMaximumLogLevel_InputIsEmpty_ReturnLevel()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.GetMaximumLogLevelGuid = (_, _1) => DummyInt;

            // Act
            var actualResult = _privateObject.Invoke(
                GetMaximumLogLevel,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void GetMappedFieldsStrings_InputIsEmpty_ReturnListOfField()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.GetListColumnsGuid = (_, _1) => new ShimDataTable();
            var listDataRow = new List<DataRow>() { new ShimDataRow() };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(listDataRow);
            ShimDataRow.AllInstances.ItemGetString = (_, _1) => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetMappedFieldsStrings,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetMappedFields_InputIsEmpty_ReturnColumnDefCollection()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.GetListColumnsGuid = (_, _1) => new ShimDataTable();
            var listDataRow = new List<DataRow>() { new ShimDataRow() };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection().Bind(listDataRow);
            var count = 0;
            ShimDataRow.AllInstances.ItemGetString = (_, _1) =>
            {
                count++;
                if (count == 4)
                {
                    return DummyInt;
                }
                else
                {
                    return DummyString;
                }
            };

            // Act
            var actualResult = _privateObject.Invoke(
                GetMappedFields,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void SetResourceListFlag_FlagIsTrue_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { true };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimReportData.AllInstances.UpdateListGuidBoolean = (_, _1, _2) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                SetResourceListFlag,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void Snapshot_InputIsEmpty_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            _privateObject.SetFieldOrProperty("_listName", DummyString2);
            ShimReportData.AllInstances.SnapshotListsString = (_, _1) => true;
            ShimReportData.AllInstances.InsertLogGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                Snapshot,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void Snapshot_InputIsEmpty_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            _privateObject.SetFieldOrProperty("_listName", DummyString2);
            ShimReportData.AllInstances.SnapshotListsString = (_, _1) => false;
            ShimReportData.AllInstances.InsertLogGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                Snapshot,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void RegisterEvent_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            var listSPWeb = new List<SPWeb>() { new ShimSPWeb() };
            ICollection<SPWeb> spWebCollection = listSPWeb;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection().Bind(spWebCollection);
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimListBiz.AllInstances.GetListEventsSPListStringStringListOfSPEventReceiverType =
                (_, _1, _2, _3, _4) => new List<SPEventReceiverDefinition>()
                {
                    new ShimSPEventReceiverDefinition()
                    {
                        Delete = () => { },
                        Update = () => { }
                    }
                };
            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection()
            {
                AddSPEventReceiverTypeStringString = (_1, _2, _3) => { }
            };
            ShimSPList.AllInstances.Update = _ => { };

            // Act
            var actualResult = _privateObject.Invoke(
                RegisterEvent,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void GetListEvents_SPListAndListOfSPEventReceiverTypeIsNotNull_ReturnListOfSPEventReceiverDefinition()
        {
            // Arrange
            var parameters = new object[]
            {
                new ShimSPList().Instance,
                DummyString,
                DummyString,
                new List<SPEventReceiverType>() { SPEventReceiverType.AppInstalled }
            };
            var listSPEventReceiverDefinition = new List<SPEventReceiverDefinition>()
            {
                new ShimSPEventReceiverDefinition()
                {
                    AssemblyGet = () => DummyString,
                    ClassGet = () => DummyString,
                    TypeGet = () => SPEventReceiverType.AppInstalled
                }
            };
            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection().Bind(listSPEventReceiverDefinition);

            // Act
            var actualResult = _privateObject.Invoke(
                GetListEvents,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void RemoveEvent_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            var listSPWeb = new List<SPWeb>() { new ShimSPWeb() };
            ICollection<SPWeb> spWebCollection = listSPWeb;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection().Bind(spWebCollection);
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            var listSPEventReceiverDefinition = new List<SPEventReceiverDefinition>() { new ShimSPEventReceiverDefinition() };
            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection().Bind(listSPEventReceiverDefinition);
            ShimSPEventReceiverDefinition.AllInstances.ClassGet = _ => "EPMLiveReportsAdmin.ListEvents";
            ShimSPEventReceiverDefinition.AllInstances.Delete = _ => { };
            ShimReportData.AllInstances.InsertLogGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                RemoveEvent,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void RemoveEvent_InputIsEmptyListIsNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            var listSPWeb = new List<SPWeb>() { new ShimSPWeb() };
            ICollection<SPWeb> spWebCollection = listSPWeb;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection().Bind(spWebCollection);
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimReportData.AllInstances.ReportErrorGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => { };
            _privateObject.SetFieldOrProperty("_listName", DummyString2);
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimReportData.AllInstances.InsertLogGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                RemoveEvent,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void RemoveEvent_InputIsEmptyListIsNullExceptionHandled_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportData.ConstructorGuid = (_, _1) => new ShimReportData();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun =>
            {
                codeToRun();
            };
            var listSPWeb = new List<SPWeb>() { new ShimSPWeb() };
            ICollection<SPWeb> spWebCollection = listSPWeb;
            ShimSPSite.AllInstances.AllWebsGet = _ => new ShimSPWebCollection().Bind(spWebCollection);
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimReportData.AllInstances.ReportErrorGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => { };
            ShimReportData.AllInstances.InsertLogGuidStringStringStringInt32 = (_, _1, _2, _3, _4, _5) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                RemoveEvent,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }
    }
}
