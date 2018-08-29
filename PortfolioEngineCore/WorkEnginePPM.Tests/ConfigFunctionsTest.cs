using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Specialized.Fakes;
using System.Configuration.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.DirectoryServices.Fakes;
using System.IO.Fakes;
using System.Linq;
using System.Net.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests
{
    [TestClass]
    public class ConfigFunctionsTest
    {
        private IDisposable _shimsObject;
        private ConfigFunctions _testObj;
        private PrivateObject _privateObj;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUser = "xyz\\DummyString";
        private const string DummyDomain = "DummySubDomain.DummyDomain";
        private const string DummyField = "DummyField";
        private const string DummyField2 = "DummyField2";
        private const string DummyFilterField = "DummyFilterField";
        private const string EPMLiveListConfig = "EPMLiveListConfig";
        private const string UseWbs = "UseWbs";
        private const string ExtId = "<Item EXTID";
        private const string CData = "<Title><![CDATA[";
        private const string TotalSettings = "TotalSettings";
        private const string GeneralSettings = "GeneralSettings";
        private const string DisplaySettings = "DisplaySettings";
        private const string EnableResourcePlan = "EnableResourcePlan";
        private const string Url = "URL";
        private const string TotalSettingsValue = "epmlivelisttotals-URL";
        private const string GeneralSettingsValue = "URL-GridSettings";
        private const string DisplaySettingsValue = "DisplaySettingURL";
        private const string EnableResourcePlanValue = "URL-EnableResPlan";
        private const string CipherText = "k1sq1YvNq35Mwn5ZqaJVDQ==";
        private const string EPMLiveKeys = "EPMLiveKeys";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new ConfigFunctions();
            _privateObj = new PrivateObject(_testObj);

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser
            {
                LoginNameGet = () => DummyString
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite
            {
                ContentDatabaseGet = () => new ShimSPContentDatabase()
            };
            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (action) =>
            {
                action();
            };

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x =>
                {
                    if (x == EPMLiveListConfig)
                    {
                        return null;
                    }

                    return new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Computed
                    };
                }
            };
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid()
            };

            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, __) => true;

            ShimSPFarm.LocalGet = () => new ShimSPFarm();

            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();
        }

        [TestMethod]
        public void GetCleanUserName_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimCoreFunctions.GetCleanUserNameWithDomainSPWebString = (_, __) => DummyString;

            // Act
            var result = ConfigFunctions.GetCleanUsername(new ShimSPWeb().Instance);

            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetUserString_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimDomain.GetComputerDomain = () => new ShimDomain();
            ShimActiveDirectoryPartition.AllInstances.ToString01 = _ => DummyDomain;
            ShimDirectoryEntry.Constructor = _ => { };
            ShimDirectorySearcher.Constructor = _ => { };
            ShimDirectorySearcher.AllInstances.FindAll = _ => new ShimSearchResultCollection
            {
                CountGet = () => DummyInt,
                ItemGetInt32 = x => new ShimSearchResult
                {
                    GetDirectoryEntry = () => new ShimDirectoryEntry
                    {
                        PropertiesGet = () => new ShimPropertyCollection
                        {
                            ItemGetString = y => new ShimPropertyValueCollection
                            {
                                ValueGet = () => DummyString
                            }
                        }
                    }
                }
            };
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection
            {
                ItemGetString = x =>
                {
                    if (x != DummyUser)
                    {
                        return null;
                    }
                    return new ShimSPUser()
                    {
                        IDGet = () => DummyInt,
                        NameGet = () => DummyString
                    };
                },
                AddStringStringStringString = (_1, _2, _3, _4) => { }
            };

            // Act
            var result = ConfigFunctions.getUserString(DummyUser, new ShimSPWeb().Instance, DummyString);

            // Assert
            result.ShouldBe($"{DummyInt};#{DummyString}");
        }

        [TestMethod]
        public void GetSiteItems_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimSPWeb.AllInstances.GetSiteDataSPSiteDataQuery = (_, __) => new DataTable();

            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;

            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;

            var viewFieldCollection = new ShimSPViewFieldCollection();
            viewFieldCollection.Bind(new[] { DummyString });
            ShimSPView.AllInstances.ViewFieldsGet = _ => viewFieldCollection;
            ShimSPView.AllInstances.ParentListGet = _ => new ShimSPList();

            var xmlSchema = $"<Parent DisplayNameSrcField='{DummyString}' />";
            ShimSPField.AllInstances.SchemaXmlGet = _ => xmlSchema;
            ShimSPField.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;

            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => { };

            ShimSqlCommand.AllInstances.ExecuteReader = _ => {
                var count = 1;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (count == 1)
                        {
                            count++;
                            return true;
                        }
                        return false;
                    },
                    GetGuidInt32 = x => Guid.NewGuid(),
                    Close = () => { }
                };
            };

            ShimSPSiteDataQuery.Constructor = _ => { };

            var xmlQuery = $"<OrderBy><FieldRef Name='{DummyField2}' NULLABLE='TRUE'/></OrderBy>";

            // Act
            var result = ConfigFunctions.getSiteItems(
                new ShimSPWeb().Instance, 
                new ShimSPView().Instance,
                xmlQuery, 
                DummyFilterField, 
                UseWbs, 
                DummyString, 
                new string[] 
                {
                    DummyField
                });

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetItemXml_WhenFieldLookup_ConfirmResult()
        {
            // Arrange
            SetupForGetItemXml();

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => DummyInt;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPFieldLookup()
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;

            ShimSPFieldLookup.AllInstances.GetFieldValueString = (_, __) => DummyString;

            ShimSPFieldLookup.AllInstances.LookupListGet = _ => Guid.NewGuid().ToString();

            // Act
            var result = ConfigFunctions.getItemXml(
                new ShimSPListItem().Instance,
                new Hashtable() { [DummyString] = DummyString },
                new ShimSPItemEventDataCollection().Instance,
                new ShimSPWeb().Instance);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExtId),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CData));
        }

        [TestMethod]
        public void GetItemXml_WhenFieldDateTime_ConfirmResult()
        {
            // Arrange
            SetupForGetItemXml();

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => DateTime.Now;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPField()
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;

            // Act
            var result = ConfigFunctions.getItemXml(
                new ShimSPListItem().Instance,
                new Hashtable() { [DummyString] = DummyString },
                new ShimSPItemEventDataCollection().Instance,
                new ShimSPWeb().Instance);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExtId),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CData));
        }

        [TestMethod]
        public void GetItemXml_WhenFieldUser_ConfirmResult()
        {
            // Arrange
            SetupForGetItemXml();

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => DummyString;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPFieldUser
                {
                    GetFieldValueString = y => DummyString
                }.Instance
            };

            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPFieldUser
                {
                    GetFieldValueString = y => DummyString
                }.Instance
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;

            ShimSPFieldUserValue.ConstructorSPWebString = (_, __, ___) => { };
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser
            {
                LoginNameGet = () => DummyString
            };
            
            ShimCoreFunctions.GetRealUserNameStringSPSite = (_, __) => DummyString;

            // Act
            var result = ConfigFunctions.getItemXml(
                new ShimSPListItem().Instance,
                new Hashtable() { [DummyString] = DummyString },
                new ShimSPItemEventDataCollection().Instance,
                new ShimSPWeb().Instance);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExtId),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CData));
        }

        [TestMethod]
        public void GetItemXml_WhenFieldNumber_ConfirmResult()
        {
            // Arrange
            SetupForGetItemXml();

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => DummyInt;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPField()
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var result = ConfigFunctions.getItemXml(
                new ShimSPListItem().Instance,
                new Hashtable() { [DummyString] = DummyString },
                new ShimSPItemEventDataCollection().Instance,
                new ShimSPWeb().Instance);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExtId),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CData));
        }

        [TestMethod]
        public void GetItemXml_WhenFieldBoolean_ConfirmResult()
        {
            // Arrange
            SetupForGetItemXml();

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => "True";

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPField()
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Boolean;

            // Act
            var result = ConfigFunctions.getItemXml(
                new ShimSPListItem().Instance,
                new Hashtable() { [DummyString] = DummyString },
                new ShimSPItemEventDataCollection().Instance,
                new ShimSPWeb().Instance);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExtId),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CData));
        }

        [TestMethod]
        public void GetItemXml_WhenFieldCalculate_ConfirmResult()
        {
            // Arrange
            SetupForGetItemXml();

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => DummyString;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPField
                {
                    GetFieldValueAsTextObject = y => DummyString
                }
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Calculated;

            // Act
            var result = ConfigFunctions.getItemXml(
                new ShimSPListItem().Instance,
                new Hashtable() { [DummyString] = DummyString },
                new ShimSPItemEventDataCollection().Instance,
                new ShimSPWeb().Instance);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExtId),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CData));
        }

        [TestMethod]
        public void GetItemXml_WhenFieldOthers_ConfirmResult()
        {
            // Arrange
            SetupForGetItemXml();

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, __) => DummyString;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x => new ShimSPField()
            };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Computed;

            // Act
            var result = ConfigFunctions.getItemXml(
                new ShimSPListItem().Instance,
                new Hashtable() { [DummyString] = DummyString },
                new ShimSPItemEventDataCollection().Instance,
                new ShimSPWeb().Instance);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldContain(ExtId),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain(CData));
        }

        private static void SetupForGetItemXml()
        {
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList();
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;
            ShimSPListItem.AllInstances.TitleGet = _ => DummyString;
            ShimSPListItem.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPListItem.AllInstances.ItemGetGuid = (_, __) => new ShimSPField();

            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.TitleGet = _ => DummyString;

            var dataTable = new DataTable();

            ShimAPITeam.GetResourcePoolStringSPWeb = (_, __) => dataTable;

            ShimSPFieldUserValueCollection.ConstructorSPWebString = (_, __, ___) => { };

            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;

            ShimSPField.AllInstances.GetFieldValueString = (_, __) => DummyString;

            ShimSPList.AllInstances.GetItemByIdInt32 = (_, __) => new ShimSPListItem
            {
                TitleGet = () => DummyString
            };

            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPList();
        }

        [TestMethod]
        public void GetFarmSetting_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string PoolingInterval = "PollingInterval";
            const string QueueThreads = "QueueThreads";
            const string ExpectedValuePollingInterval = "10";
            const string ExpectedValueQueueThreads = "5";

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();

            // Act
            var result1 = ConfigFunctions.getFarmSetting(PoolingInterval);
            var result2 = ConfigFunctions.getFarmSetting(QueueThreads);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result1.ShouldBe(ExpectedValuePollingInterval),
                () => result2.ShouldBe(ExpectedValueQueueThreads));
        }

        [TestMethod]
        public void SetFarmSetting_WhenExistingSetting_ConfirmResult()
        {
            // Arrange
            var updated = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable() { [DummyString] = DummyString };
            ShimSPFarm.AllInstances.Update = _ => updated = true;

            // Act
            ConfigFunctions.setFarmSetting(DummyString, DummyString);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void SetFarmSetting_WhenNotExistingSetting_ConfirmResult()
        {
            // Arrange
            var updated = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            ShimSPFarm.AllInstances.Update = _ => updated = true;

            // Act
            ConfigFunctions.setFarmSetting(DummyString, DummyString);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void GetWebAppSetting_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimSPWebService.ContentServiceGet = () => new ShimSPWebService();
            ShimSPWebService.AllInstances.WebApplicationsGet = _ => new ShimSPWebApplicationCollection();

            ShimConfigurationManager.AppSettingsGet = () => new NameValueCollection() { [DummyString] = DummyString };

            // Act
            var result = ConfigFunctions.getWebAppSetting(Guid.NewGuid(), DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListSetting_WhenTotalSettings_ConfirmResult()
        {
            // Arrange
            SetupForGetListSetting();

            // Act
            var result = ConfigFunctions.getListSetting(new ShimSPList().Instance, TotalSettings);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListSetting_WhenGeneralSettings_ConfirmResult()
        {
            // Arrange
            SetupForGetListSetting();

            // Act
            var result = ConfigFunctions.getListSetting(new ShimSPList().Instance, GeneralSettings);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListSetting_WhenDisplaySettings_ConfirmResult()
        {
            // Arrange
            SetupForGetListSetting();

            // Act
            var result = ConfigFunctions.getListSetting(new ShimSPList().Instance, DisplaySettings);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListSetting_WhenEnableResourcePlan_ConfirmResult()
        {
            // Arrange
            SetupForGetListSetting();

            // Act
            var result = ConfigFunctions.getListSetting(new ShimSPList().Instance, EnableResourcePlan);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        private static void SetupForGetListSetting()
        {
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            ShimSPList.AllInstances.Update = _ => { };
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView
            {
                UrlGet = () => DummyString
            };

            ShimSPField.ConstructorSPFieldCollectionStringString = (_, _1, _2, _3) => { };
            ShimSPField.AllInstances.Update = _ => { };
            ShimSPField.AllInstances.HiddenSetBoolean = (_, __) => { };

            ShimPath.GetDirectoryNameString = _ => Url;

            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, key) =>
            {
                if (key == TotalSettingsValue ||
                    key == GeneralSettingsValue ||
                    key == DisplaySettingsValue ||
                    key == EnableResourcePlanValue)
                {
                    return true;
                }
                return false;
            };
            ShimStringDictionary.AllInstances.ItemGetString = (_, key) =>
            {
                if (key == TotalSettingsValue ||
                    key == GeneralSettingsValue ||
                    key == DisplaySettingsValue ||
                    key == EnableResourcePlanValue)
                {
                    return DummyString;
                }
                return null;
            };
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimSPWeb.AllInstances.Close = _ => { };

            ShimSPSite.ConstructorGuid = (_, __) => { };
        }

        [TestMethod]
        public void SetConfigSetting_WhenValueIsEmpty_ConfirmResult()
        {
            // Arrange
            var updated = false;
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();
            ShimSPPropertyBag.AllInstances.Update = _ => updated = true;
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, __) => true;
            ShimStringDictionary.AllInstances.ItemGetString = (_, __) => string.Empty;

            // Act
            ConfigFunctions.setConfigSetting(new ShimSPWeb().Instance, DummyString, string.Empty);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void SetConfigSetting_WhenSettingExists_ConfirmResult()
        {
            // Arrange
            var updated = false;
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();
            ShimSPPropertyBag.AllInstances.Update = _ => updated = true;
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, __) => true;
            ShimStringDictionary.AllInstances.ItemGetString = (_, __) => string.Empty;

            // Act
            ConfigFunctions.setConfigSetting(new ShimSPWeb().Instance, DummyString, DummyString);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void SetConfigSetting_WhenSettingNotExists_ConfirmResult()
        {
            // Arrange
            var updated = false;
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();
            ShimSPPropertyBag.AllInstances.Update = _ => updated = true;
            ShimStringDictionary.AllInstances.ContainsKeyString = (_, __) => false;
            ShimStringDictionary.AllInstances.AddStringString = (_, __, ___) => { };

            // Act
            ConfigFunctions.setConfigSetting(new ShimSPWeb().Instance, DummyString, DummyString);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void GetLockConfigSetting_WhenGuidIsNotEmpty_ConfirmResult()
        {
            // Arrange
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();

            ShimConfigFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            ShimConfigFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => DummyString;

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => new ShimSPSite()
            };

            // Act
            var result = ConfigFunctions.getLockConfigSetting(new ShimSPWeb().Instance, DummyString, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetLockConfigSetting_WhenGuidIsEmpty_ConfirmResult()
        {
            // Arrange
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();

            ShimConfigFunctions.getLockedWebSPWeb = _ => Guid.Empty;
            ShimConfigFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => DummyString;

            // Act
            var result = ConfigFunctions.getLockConfigSetting(new ShimSPWeb().Instance, DummyString, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void FarmEncode_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string Expected = "342395117854676768122";
            ShimSPFarm.LocalGet = () => new ShimSPFarm();
            ShimSPPersistedObject.AllInstances.IdGet = _ => new Guid("FB2F7E71-BE24-448A-B31B-108C1B3AC812");

            // Act
            var result = ConfigFunctions.farmEncode(DummyString);

            // Assert
            result.ShouldBe(Expected);
        }

        [TestMethod]
        public void ComputerCode_OnValidCall_ConfirmResult()
        {
            // Arrange
            const string Expected = "000000000035";
            ShimDns.GetHostName = () => DummyString;

            // Act
            var result = ConfigFunctions.computerCode(DummyString);

            // Assert
            result.ShouldBe(Expected);
        }

        [TestMethod]
        public void Encrypt_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ConfigFunctions.Encrypt(DummyString, DummyString);

            // Assert
            result.ShouldBe(CipherText);
        }

        [TestMethod]
        public void Decrypt_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = ConfigFunctions.Decrypt(CipherText, DummyString);

            // Assert
            result.ShouldBe(DummyString);
        }

        [TestMethod]
        public void DeleteKey_OnValidCall_ConfirResult()
        {
            // Arrange
            var updated = false;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb()
            };

            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();

            ShimSPPersistedObject.AllInstances.FarmGet = _ => new ShimSPFarm();
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable() { [EPMLiveKeys] = $"{DummyUser}\t{DummyString}" };

            ShimSPFarm.AllInstances.Update = _ => updated = true;

            // Act
            ConfigFunctions.deleteKey(DummyString);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void FeatureList_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimConfigFunctions.farmEncodeString = _ => DummyString;
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable() { [EPMLiveKeys] = $"{DummyString}\t{DummyString}" };

            // Act
            var result = ConfigFunctions.featureList();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Count().ShouldBe(1),
                () => result.Contains(DummyString).ShouldBeTrue());
        }

        [TestMethod]
        public void Enqueue_OnValidCall_ConfirmResult()
        {
            // Arrange
            var commandExecuted = false;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => new ShimSPSite
                {
                    WebApplicationGet = () => new ShimSPWebApplication()
                }
            };

            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();

            ShimSPWebService.ContentServiceGet = () => new ShimSPWebService
            {
                WebApplicationsGet = () => new ShimSPWebApplicationCollection()
            };

            ShimConfigurationManager.ConnectionStringsGet = () => new ShimConnectionStringSettingsCollection();
            ShimConnectionStringSettingsCollection.AllInstances.ItemGetString = (_, __) => new ShimConnectionStringSettings
            {
                ConnectionStringGet = () => DummyString
            };

            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };

            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                commandExecuted = true;
                return DummyInt;
            };

            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => 2;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            
            // Act
            ConfigFunctions.enqueue(Guid.NewGuid(), DummyInt);

            // Assert
            commandExecuted.ShouldBeTrue();
        }
    }
}
