using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.DirectoryServices.Fakes;
using System.IO.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

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

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = (action) =>
            {
                action();
            };

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = x =>
                {
                    if (x == "EPMLiveListConfig")
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

            var xmlQuery = $"<OrderBy><FieldRef Name='DummyField2' NULLABLE='TRUE'/></OrderBy>";

            // Act
            var result = ConfigFunctions.getSiteItems(
                new ShimSPWeb().Instance, 
                new ShimSPView().Instance,
                xmlQuery, 
                "DummyFilterField", 
                "UseWbs", 
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
                () => result.ShouldContain("<Item EXTID"),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain("<Title><![CDATA["));
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
                () => result.ShouldContain("<Item EXTID"),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain("<Title><![CDATA["));
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
                () => result.ShouldContain("<Item EXTID"),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain("<Title><![CDATA["));
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
                () => result.ShouldContain("<Item EXTID"),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain("<Title><![CDATA["));
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
                () => result.ShouldContain("<Item EXTID"),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain("<Title><![CDATA["));
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
                () => result.ShouldContain("<Item EXTID"),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain("<Title><![CDATA["));
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
                () => result.ShouldContain("<Item EXTID"),
                () => result.ShouldContain(DummyString),
                () => result.ShouldContain("<Title><![CDATA["));
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
            //dataTable.Columns.Add("SPID", typeof(int));
            //dataTable.Columns.Add("EXTID", typeof(int));

            //var dataRow = dataTable.NewRow();
            //dataRow["SPID"] = DummyInt;
            //dataRow["EXTID"] = DummyInt;

            //dataTable.Rows.Add(dataRow);

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

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();

            // Act
            var result1 = ConfigFunctions.getFarmSetting(PoolingInterval);
            var result2 = ConfigFunctions.getFarmSetting(QueueThreads);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result1.ShouldBe("10"),
                () => result2.ShouldBe("5"));
        }

        [TestMethod]
        public void SetFarmSetting_WhenExistingSetting_ConfirmResult()
        {
            // Arrange
            var updated = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable() { [DummyString] = DummyString };
            ShimSPFarm.AllInstances.Update = _ => { updated = true; };

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
            ShimSPFarm.AllInstances.Update = _ => { updated = true; };

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
        public void GetListSetting_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;

            ShimSPList.AllInstances.Update = _ => { };
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView
            {
                UrlGet = () => DummyString
            };

            ShimSPField.ConstructorSPFieldCollectionStringString = (_, _1, _2, _3) => { };
            ShimSPField.AllInstances.Update = _ => { };
            ShimSPField.AllInstances.HiddenSetBoolean = (_, __) => { };

            ShimPath.GetDirectoryNameString = _ => "URL";

            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.PropertiesGet = _ => new ShimSPPropertyBag();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyString;
            ShimSPWeb.AllInstances.Close = _ => { };

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb();

            // Act
            var result = ConfigFunctions.getListSetting(new ShimSPList().Instance, "TotalSettings");

            // Assert
        }
    }
}
