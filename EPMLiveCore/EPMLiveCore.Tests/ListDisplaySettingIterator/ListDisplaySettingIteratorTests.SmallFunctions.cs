using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;
using Shouldly;
using System.Data.SqlClient.Fakes;
using Microsoft.SharePoint.Fakes;
using System.Fakes;
using EPMLiveCore.Fakes;
using System.Collections.Specialized;
using Microsoft.SharePoint;
using EPMLiveCore;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using System.Web.UI.Fakes;

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
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private EPMLiveCore.ListDisplaySettingIterator _testEntity;
        private IDisposable _shimsContext;
        private readonly StringBuilder query = new StringBuilder();
        private readonly StringBuilder functionsInvoked = new StringBuilder();
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int DataReaderResult = 0;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitShims();
            query.Clear();
            functionsInvoked.Clear();
            maxDatareaderCount = 1;
            currentDataReaderCount = 0;

            _testEntity = new EPMLiveCore.ListDisplaySettingIterator();
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(EPMLiveCore.ListDisplaySettingIterator));
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
            var expectedFunctions = new string[] 
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter",
            };

            // Act
            var methodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                methodName,
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
            var expectedFunctions = new string[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "EntityEditor.UpdateEntities",
                "ControlCollectionExtensions.AddAfter",
            };

            // Act
            var methodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                methodName,
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
            var expectedFunctions = new string[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter",
            };

            // Act
            var methodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                methodName,
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
            var expectedFunctions = new string[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "EntityEditor.UpdateEntities",
                "ControlCollectionExtensions.AddAfter",
            };

            // Act
            var methodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                methodName,
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
            var expectedFunctions = new string[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter",
            };

            // Act
            var methodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                methodName,
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
            var expectedFunctions = new string[]
            {
                "ListDisplaySettingIterator.GenerateControlDataForLookupField",
                "ControlCollectionExtensions.AddAfter",
            };

            // Act
            var methodName = "AddTypeAheadFieldControls";
            var result = _privateObject.Invoke(
                methodName,
                parameters);

            // Assert
            var assertions = AssertFunctions(expectedFunctions);
            assertions.Add(() => result.ShouldBeNull());
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        private void InitShims()
        {
            ShimEntityEditor.AllInstances.UpdateEntitiesArrayList = (_, _1) =>
            {
                functionsInvoked.Append("\nEntityEditor.UpdateEntities");
            };
            ShimListDisplaySettingIterator.AllInstances.GetQueryStringLookupValSPField = (_, _1) => new SPFieldLookupValueCollection
            {
                new ShimSPFieldLookupValue().Instance,
            };
            ShimControlCollectionExtensions.AddAfterControlCollectionControlControl = (_, _1, _2) =>
            {
                functionsInvoked.Append("\nControlCollectionExtensions.AddAfter");
            };
            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection().Instance;
            ShimControl.AllInstances.ParentGet = _ => new ShimControl().Instance;
            ShimListFieldIteratorExtensions.GetFormFieldByFieldListFieldIteratorSPField = (_, _1) => new ShimFormField().Instance;
            ShimListDisplaySettingIterator.AllInstances.GenerateControlDataForLookupFieldSPFieldBoolean = (_, _1, _2) => 
            {
                functionsInvoked.Append("\nListDisplaySettingIterator.GenerateControlDataForLookupField");
                return DummyString;
            };
            InitSPShims();
        }

        private void InitSPShims()
        {
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => DummyString;
            var sPFieldLookupValues = new List<SPFieldLookupValue>()
            {
                new ShimSPFieldLookupValue().Instance,
            };
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
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection()
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
            var sPListItems = new List<SPListItem>()
            {
                new ShimSPListItem(),
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
                        returnString = (new Guid()).ToString();
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
            ShimSqlConnection.AllInstances.StateGet = _ => System.Data.ConnectionState.Open;
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
                query.Append("\n" + command.CommandText);
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        if (key == "FA_FORMAT")
                        {
                            return 4;
                        }
                        else if (key == "CMT_TIMESTAMP" || key == "RPEN_TIMESTAMP" || key == "PRD_FINISH_DATE" || key == "PRD_CLOSED_DATE")
                        {
                            return DateTime.Now;
                        }
                        else if (key == "CMT_GUID")
                        {
                            return new Guid();
                        }

                        else if (key == "ADM_PORT_COMMITMENTS_OPMODE")
                        {
                            return 0;
                        }
                        else if (key == "CB_ID")
                        {
                            return 14;
                        }
                        else if (key == "VIEW_DATA")
                        {
                            return "<Dummy></Dummy>";
                        }
                        return DataReaderResult;
                    },
                }.Instance;
            };
        }

        private List<Action> AssertQueries(string[] expectedQueries)
        {
            var assertions = new List<Action>();
            foreach (var expectedQuery in expectedQueries)
            {
                assertions.Add(() => query.ToString().ShouldContain(expectedQuery));
            }
            return assertions;
        }

        private List<Action> AssertFunctions(string[] expectedFunctions)
        {
            var assertions = new List<Action>();
            foreach (var expectedFunction in expectedFunctions)
            {
                assertions.Add(() => functionsInvoked.ToString().ShouldContain(expectedFunction));
            }
            return assertions;
        }
    }
}
