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
    }
}
