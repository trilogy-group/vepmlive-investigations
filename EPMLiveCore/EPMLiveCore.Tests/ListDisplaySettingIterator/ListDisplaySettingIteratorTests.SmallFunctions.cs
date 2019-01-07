using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Text;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace EPMLiveCore.Tests
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.ListDisplaySettingIterator"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ListDisplaySettingIteratorTests2
    {
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private PrivateObject _privateObject;
        private ListDisplaySettingIterator _testEntity;
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

            _testEntity = new ListDisplaySettingIterator();
            _privateObject = new PrivateObject(_testEntity);
            _privateObject.SetFieldOrProperty("lookupField", DummyString);
            _privateObject.SetFieldOrProperty("lookupValue", $"{DummyInt},{DummyInt + 1}");
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void AddTypeAheadFieldControls_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPFieldLookup().Instance };
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.ContainsKeyString = (_, _1) => false;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.IsParentFieldString = (_, _1) => true;
            var expectedFunctions = new[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter"
            };

            // Act
            const string MethodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void AddTypeAheadFieldControls_ParentAndEnhancedTrueAndDataTypeGeneric_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPFieldLookup().Instance };
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.ContainsKeyString = (_, _1) => true;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.IsParentFieldString = (_, _1) => true;
            ShimLookupConfigData.AllInstances.TypeGet = _ => "2";
            var expectedFunctions = new[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "EntityEditor.UpdateEntities",
                "ControlCollectionExtensions.AddAfter"
            };

            // Act
            const string MethodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void AddTypeAheadFieldControls_ParentAndEnhancedTrueAndDataTypeModified_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPFieldLookup().Instance };
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.ContainsKeyString = (_, _1) => true;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.IsParentFieldString = (_, _1) => true;
            ShimLookupConfigData.AllInstances.TypeGet = _ => "1";
            var expectedFunctions = new[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter"
            };

            // Act
            const string MethodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void AddTypeAheadFieldControls_ParentFalseEnhancedTrueAndDataTypeGeneric_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPFieldLookup().Instance };
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.ContainsKeyString = (_, _1) => true;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.IsParentFieldString = (_, _1) => false;
            ShimLookupConfigData.AllInstances.TypeGet = _ => "2";
            var expectedFunctions = new[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "EntityEditor.UpdateEntities",
                "ControlCollectionExtensions.AddAfter"
            };

            // Act
            const string MethodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void AddTypeAheadFieldControls_ParentFalseEnhancedTrueAndDataTypeModified_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPFieldLookup().Instance };
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.ContainsKeyString = (_, _1) => true;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.IsParentFieldString = (_, _1) => false;
            ShimLookupConfigData.AllInstances.TypeGet = _ => "1";
            var expectedFunctions = new[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter"
            };

            // Act
            const string MethodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void AddTypeAheadFieldControls_ParentFalseEnhancedTrueAndAllowMultipleTrue_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPFieldLookup().Instance };
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            ShimEnhancedLookupConfigValuesHelper.AllInstances.ContainsKeyString = (_, _1) => true;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.IsParentFieldString = (_, _1) => false;
            ShimLookupConfigData.AllInstances.TypeGet = _ => "1";
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;
            var expectedFunctions = new[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter"
            };

            // Act
            const string MethodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void CreateChildControls_EmptyInput_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { };
            SetupForCreateChildControlsTestMethod();
            var expectedFunctions = new[]
            {
                "ITemplate.InstantiateIn",
                "ListDisplaySettingIterator.InsertLookupValueByQueryString"
            };

            // Act
            const string MethodName = "CreateChildControls";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void InsertLookupValueByQueryString_EmptyInput_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { };
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            _privateObject.SetFieldOrProperty("lookupValue", $"{DummyInt},{DummyInt + 1}");
            _privateObject.SetFieldOrProperty("lookupField", DummyString);
            ShimListFieldIteratorExtensions.GetFormFieldByTypeListFieldIteratorType = (_, _1) =>
            {
                _functionsInvoked.Append("\nListFieldIteratorExtensions.GetFormFieldByType");
                return new List<FormField>();
            };
            const string ExpectedFunction = "ListFieldIteratorExtensions.GetFormFieldByType";

            // Act
            const string MethodName = "InsertLookupValueByQueryString";
            var result = _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _functionsInvoked.ToString().ShouldContain(ExpectedFunction),
                () => result.ShouldBeNull());
        }

        [TestMethod]
        public void GetQueryStringLookupVal_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimFormField().Instance };
            ShimFieldMetadata.AllInstances.FieldGet = _ => new ShimSPFieldLookup().Instance;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => new Guid().ToString();

            // Act
            const string MethodName = "GetQueryStringLookupVal";
            var result = (SPFieldLookupValueCollection)_privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(2));
        }

        [TestMethod]
        public void GetQueryStringLookupVal_SPFieldParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPFieldLookup().Instance };
            ShimListDisplaySettingIterator.AllInstances.GetQueryStringLookupValSPField = null;
            ShimSPFieldLookup.AllInstances.AllowMultipleValuesGet = _ => true;
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => new Guid().ToString();

            // Act
            const string MethodName = "GetQueryStringLookupVal";
            var result = (SPFieldLookupValueCollection)_privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count.ShouldBe(2));
        }

        [TestMethod]
        public void ProcessNewItemRecent_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPListItem().Instance };
            ShimSPList.AllInstances.TitleGet = _ => DummyString;
            ShimSPListItem.AllInstances.TitleGet = _ => DummyString;
            ShimGridGanttSettings.ConstructorSPList = (_, _1) => { };
            ShimQueryExecutor.AllInstances.ExecuteEpmLiveQueryStringIDictionaryOfStringObject = (_, _1, _2) =>
            {
                _query.Append($"\n{_1}");
                return new DataTable();
            };
            var expectedQueries = new[]
            {
                "AND [F_Date] NOT IN (SELECT TOP 20 [F_Date] FROM FRF WHERE [Type] = 2 ORDER BY [F_Date] DESC)",
                "IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 2) > 20)",
                "IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=2)",
                "INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Icon], [Title], [Type], [F_Date])",
                "SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=2",
                "SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=2",
                "UPDATE FRF SET [F_Date] = GETDATE() ",
                "VALUES (@siteid, @webid, @listid, @itemid, @userid, @icon, @title, 2, GETDATE())",
                "WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=2 ",
                "WHERE [Type] = 2 "
            };

            // Act
            const string MethodName = "ProcessNewItemRecent";
            _privateObject.Invoke(MethodName, parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void CustomHandler_NullParametersGiven_ChildControlAdded()
        {
            // Arrange
            var parameters = new object[] { null, null };
            _privateObject.SetFieldOrProperty("list", new ShimSPList().Instance);
            _privateObject.SetFieldOrProperty("mode", SPControlMode.New);
            ShimSPList.AllInstances.ValidationFormulaGet = _ => DummyString;
            ShimListDisplaySettingIterator.AllInstances.CreateChildControls = _ => _functionsInvoked.Append("\nCreateChildControls");

            // Act
            const string MethodName = "CustomHandler";
            _privateObject.Invoke(
                MethodName,
                parameters);

            // Assert
            _functionsInvoked.ToString().ShouldContain("CreateChildControls");
        }

        private void InitShims()
        {
            var controlTemplateMock = new Mock<ITemplate>();
            controlTemplateMock.Setup(x => x.InstantiateIn(It.IsAny<TemplateContainer>()))
                .Callback(() => _functionsInvoked.Append("\nITemplate.InstantiateIn"));
            ShimTemplateBasedControl.AllInstances.ControlTemplateGet = _ => controlTemplateMock.Object;
            ShimEntityEditor.AllInstances.UpdateEntitiesArrayList = (_, _1) =>
            {
                _functionsInvoked.Append("\nEntityEditor.UpdateEntities");
            };
            ShimListDisplaySettingIterator.AllInstances.GetQueryStringLookupValSPField = (_, _1) => new SPFieldLookupValueCollection
            {
                new ShimSPFieldLookupValue().Instance
            };
            ShimControlCollectionExtensions.AddAfterControlCollectionControlControl = (_, _1, _2) =>
            {
                _functionsInvoked.Append("\nControlCollectionExtensions.AddAfter");
            };
            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection().Instance;
            ShimControl.AllInstances.ParentGet = _ => new ShimControl().Instance;
            ShimListFieldIteratorExtensions.GetFormFieldByFieldListFieldIteratorSPField = (_, _1) => new ShimFormField().Instance;
            ShimListDisplaySettingIterator.AllInstances.GenerateControlDataForLookupFieldSPFieldBoolean = (_, _1, _2) =>
            {
                _functionsInvoked.Append("\nListDisplaySettingIterator.GenerateControlDataForLookupField");
                return DummyString;
            };
            InitSpShims();
        }
        
        private void SetupForCreateChildControlsTestMethod()
        {
            var internalName = "internalName";
            _privateObject.SetFieldOrProperty("isFeatureActivated", true);
            ShimSPFieldCollection.AllInstances.CountGet = _ => 4;
            ShimSPFieldCollection.AllInstances.ItemGetInt32 = (_, index) =>
            {
                if (index == 0)
                {
                    return new ShimSPField
                    {
                        InternalNameGet = () => internalName
                    }.Instance;
                }

                return new ShimSPField
                {
                    InternalNameGet = () => DummyString
                }.Instance;
            };
            var sortedList = new SortedList();
            sortedList.Add(internalName, true);
            _privateObject.SetFieldOrProperty("arrwpFields", sortedList);
            _privateObject.SetFieldOrProperty("mode", SPControlMode.Edit);
            ShimFormComponent.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Instance;
            ShimListDisplaySettingIterator.AllInstances.IsFieldExcludedSPField = (_, _1) => false;
            ShimListDisplaySettingIterator.AllInstances.InsertLookupValueByQueryString = _ =>
            {
                _functionsInvoked.Append("\nListDisplaySettingIterator.InsertLookupValueByQueryString");
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>().GetEnumerator();
        }

        private void InitSpShims()
        {
            ShimSaveButton.SaveItemSPContextBooleanString = (_, _1, _2) => false;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DocumentLibrary;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList().Instance;
            ShimFieldMetadata.AllInstances.FieldGet = _ => new ShimSPField().Instance;
            ShimSPSite.AllInstances.OpenWebGuid = (_, _1) => new ShimSPWeb().Instance;
            ShimSPSite.ConstructorGuid = (_, _1) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite().Instance;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => DummyString;
            ShimFormComponent.AllInstances.ListIdGet = _ => new Guid();
            ShimFormComponent.AllInstances.ItemIdGet = _ => DummyInt;
            ShimSPFieldLookup.AllInstances.LookupFieldGet = _ => DummyString;
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => DummyString;
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList().Instance;
            ShimEnhancedLookupConfigValuesHelper.AllInstances.GetFieldDataString = (_, _1) => new ShimLookupConfigData().Instance;
            ShimSPWeb.AllInstances.GetAvailableWebTemplatesUInt32 = (_, _1) => new ShimSPWebTemplateCollection().Instance;
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
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPList().Instance;
            ShimSPListCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimSPList().Instance;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList().Instance;
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
                string returnString;
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

        private List<Action> AssertQueries(string[] expectedQueries)
        {
            var assertions = new List<Action>();
            foreach (var expectedQuery in expectedQueries)
            {
                assertions.Add(() => _query.ToString().ShouldContain(expectedQuery));
            }
            return assertions;
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
