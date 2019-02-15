using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.DirectoryServices.Fakes;
using System.Security.Principal.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ADSyncTests
    {
        private IDisposable _shimObject;
        private ADSync _testObj;
        private PrivateObject _privateObj;
        private PrivateType _privateType;
        private ShimSPSite _site;
        private ShimSPWeb _web;
        private bool _fieldAdded;
        private bool _listItemAdded;
        private bool _listItemUpdated;
        private bool _listItemDeleted;
        private bool _listUpdated;
        private bool _deRefreshCacheCalled;
        private bool _nonQueryExecuted;
        private bool _daoDisposed;
        private bool _userAdded;
        private string _sqlString;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyError = "Dummy Error";

        private const string AuditResourcePoolMethod = "AuditResourcePool";
        private const string UpdateResourcePoolMethod = "UpdateResourcePool";
        private const string GetResourcepoolItemMethod = "GetResourcepoolItem";
        private const string UpdateResourceMethod = "UpdateResource";
        private const string CheckForSIDandDisableColumnMethod = "CheckForSIDandDisableColumn";
        private const string PopulateAllGroupUserAttributesMethod = "PopulateAllGroupUserAttributes";
        private const string DisableUsersMethod = "DisableUsers";
        private const string GetSizeLimitMethod = "GetSizeLimit";
        private const string InitializeMethod = "Initialize";
        private const string AddResourceToDataTableMethod = "AddResourceToDataTable";
        private const string AddPropertiesMethod = "AddProperties";
        private const string GetUserSIDMethod = "GetUserSID";

        private const string SIDField = "SID";
        private const string IDField = "ID";
        private const string TitleField = "Title";
        private const string SharepointAccountField = "SharepointAccount";
        private const string HasSIDProperty = "_hasSID";
        private const string ExecutionLogsProperty = "_ExecutionLogs";
        private const string HasErrorsProperty = "_hasErrors";
        private const string ListProperty = "_list";
        private const string AdUsersProperty = "_adUsers";
        private const string DAOProperty = "_DAO";
        private const string AdFieldMappingsProperty = "_adFieldMappings";
        private const string ResourcePoolProperty = "_resourcePool";
        private const string ProcessedUsersProperty = "_processedUsers";
        private const string AdFieldMappingValuesProperty = "_adFieldMappingValues";
        private const string WebProperty = "_web";
        private const string GroupNameProperty = "_groupName";
        private const string AdGroupNameAndPathProperty = "_adGroupNameAndPath";
        private const string AdExclusionsProperty = "_adExclusions";
        private const string DisableUsersProperty = "_disableUsers";

        [TestInitialize]
        public void TestInitialize()
        {
            _fieldAdded = false;
            _listItemAdded = false;
            _listItemUpdated = false;
            _listItemDeleted = false;
            _listUpdated = false;
            _deRefreshCacheCalled = false;
            _nonQueryExecuted = false;
            _daoDisposed = false;
            _userAdded = false;
            _sqlString = string.Empty;

            _shimObject = ShimsContext.Create();
            _testObj = new ADSync();
            _privateObj = new PrivateObject(_testObj);
            _privateType = new PrivateType(typeof(ADSync));

            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void SetupShims()
        {
            var listCount = 1;

            var spListItem = new ShimSPListItem
            {
                Update = () => _listItemUpdated = true,
                ItemGetString = _ => DummyString,
                Delete = () =>
                {
                    _listItemDeleted = true;
                    listCount--;
                }
            };

            var spListItemCollection = new ShimSPListItemCollection
            {
                CountGet = () => listCount,
                Add = () =>
                {
                    _listItemAdded = true;
                    return spListItem;
                },
                GetDataTable = () => new ShimDataTable
                {
                    Clone = () => CreateDataTable()
                },
                DeleteInt32 = _ => _listItemDeleted = true,
                ItemGetInt32 = _ => spListItem
            };

            var spList = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    ContainsFieldString = _ => false,
                    AddStringSPFieldTypeBoolean = (name, __, ___) =>
                    {
                        _fieldAdded = true;
                        return name;
                    },
                    ItemGetString = _ => new ShimSPField()
                },
                ItemsGet = () => spListItemCollection,
                Update = () => _listUpdated = true,
                GetItemByIdInt32 = _ => spListItem,
                GetItemsSPQuery = _ => spListItemCollection
            };

            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid(),
                AllWebsGet = () => new ShimSPWebCollection
                {
                    ItemGetString = _ => _web
                },
                RootWebGet = () => _web
            };

            var userCount = 0;
            _web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => spList
                },
                UrlGet = () => DummyString,
                AllUsersGet = () => new ShimSPUserCollection
                {
                    ItemGetString = _ =>
                    {
                        userCount++;

                        return userCount == 1 ? null : new ShimSPUser();
                    },
                    AddStringStringStringString = (_1, _2, _3, _4) => _userAdded = true
                }
            };

            ShimSPSite.AllInstances.OpenWeb = _ => _web;

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => _web;

            ShimSPQuery.Constructor = _ => { };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimEPMData.ConstructorGuid = (_, __) => { };
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new ShimSqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (instance, __) =>
            {
                _nonQueryExecuted = true;
                _sqlString = instance.Command;

                return true;
            };
            ShimEPMData.AllInstances.AddParamStringObject = (_, __, ___) => { };
            ShimEPMData.AllInstances.Dispose = _ => _daoDisposed = true;

            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) => DummyString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, item) =>
            {
                switch (item)
                {
                    case "EPMLIVEaddelete":
                        return "true";
                    case "EPMLIVEadSizeLimit":
                        return DummyInt.ToString();
                    case "EPMLIVEadfields":
                        return $"{DummyString};{DummyString}";
                    default:
                        return DummyString;
                }
            };

            ShimDomain.GetComputerDomain = () => new ShimDomain();

            ShimActiveDirectoryPartition.AllInstances.ToString01 = _ => $"{DummyString}.Domain";

            ShimDirectoryEntry.ConstructorString = (_, __) => { };
            ShimDirectoryEntry.ConstructorStringStringStringAuthenticationTypes = (_1, _2, _3, _4, _5) => { };
            ShimDirectoryEntry.AllInstances.RefreshCache = _ => _deRefreshCacheCalled = true;
            ShimDirectoryEntry.AllInstances.PropertiesGet = _ => new ShimPropertyCollection
            {
                ItemGetString = item => new ShimPropertyValueCollection
                {
                    ItemGetInt32 = ___ => new byte[] { }
                }
            };

            ShimDirectorySearcher.ConstructorDirectoryEntry = (_, __) => { };
            ShimDirectorySearcher.ConstructorDirectoryEntryString = (_, __, ___) => { };
            ShimDirectorySearcher.AllInstances.FindAll = _ => new ShimSearchResultCollection
            {
                Dispose = () => { }
            }.Bind(new SearchResult[]
            {
                new ShimSearchResult
                {
                    GetDirectoryEntry = () => new ShimDirectoryEntry
                    {
                        NameGet = () => DummyString,
                        PathGet = () => DummyString
                    },
                    PathGet = () => DummyString
                }.Instance
            });
            ShimDirectorySearcher.AllInstances.FindOne = _ => new ShimSearchResult
            {
                PropertiesGet = () => new ShimResultPropertyCollection
                {
                    ItemGetString = __ => new ShimResultPropertyValueCollection
                    {
                        ItemGetInt32 = ___ => DummyString
                    }
                }
            };

            ShimSecurityIdentifier.ConstructorByteArrayInt32 = (_, __, ___) => { };
            ShimSecurityIdentifier.AllInstances.ValueGet = _ => DummyString;
        }

        private DataTable CreateDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(SIDField);
            dataTable.Columns.Add(IDField);
            dataTable.Columns.Add(TitleField);
            dataTable.Columns.Add(SharepointAccountField);
            dataTable.Columns.Add(DummyString);

            return dataTable;
        }

        [TestMethod]
        public void InitiateSync_OnValidCall_ConfirmResult()
        {
            // Arrange
            string processLog;
            bool hasErrors;

            _privateObj.SetFieldOrProperty(HasSIDProperty, true);

            // Act
            _testObj.InitiateSync(_site.Instance, out processLog, out hasErrors, Guid.NewGuid());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _fieldAdded.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeTrue(),
                () => _listUpdated.ShouldBeTrue(),
                () => _deRefreshCacheCalled.ShouldBeTrue(),
                () => _daoDisposed.ShouldBeTrue(),
                () => processLog.ShouldContain("AD Sync process started at:"),
                () => processLog.ShouldContain("AD Sync process finished at:"),
                () => hasErrors.ShouldBeFalse());
        }

        [TestMethod]
        public void InitiateSync_OnError_LogError()
        {
            // Arrange
            string processLog;
            bool hasErrors;

            ShimEPMData.ConstructorGuid = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            _testObj.InitiateSync(_site.Instance, out processLog, out hasErrors, Guid.NewGuid());

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: InitiateSync() -- Message: {DummyError}"));
        }

        [TestMethod]
        public void GetADGroupUserAttributes_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimDirectoryEntry.AllInstances.RefreshCacheStringArray = (_, __) => _deRefreshCacheCalled = true;

            // Act
            var result = _testObj.GetADGroupUserAttributes(DummyString, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _deRefreshCacheCalled.ShouldBeTrue(),
                () => result.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetADGroupUserAttributes_OnError_LogError()
        {
            // Arrange
            ShimDirectoryEntry.ConstructorString = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            var result = _testObj.GetADGroupUserAttributes(DummyString, DummyString);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => result.Count.ShouldBe(0),
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: GetADGroupUserAttributes() -- Message: { DummyError}"));
        }

        [TestMethod]
        public void AddResourceToDataTable_OnError_LogError()
        {
            // Arrange, Act
            _privateObj.Invoke(AddResourceToDataTableMethod, DummyString);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs[0].ShouldContain($"     ERROR -- Location: AddResourceToDataTable() module level -- Message: "));
        }

        [TestMethod]
        public void GetGroups_OnError_LogError()
        {
            // Arrange
            ShimDirectoryEntry.ConstructorString = (_, __) =>
            {
                throw new Exception(DummyError);
            };
            ShimDirectorySearcher.ConstructorDirectoryEntry = (_, __) =>
            {
                throw new Exception(DummyError);
            };
            ShimSearchResult.AllInstances.GetDirectoryEntry = _ =>
            {
                throw new Exception(DummyError);
            };

            // Act
            var result = _testObj.GetGroups(DummyString);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            this.ShouldSatisfyAllConditions(
                () => result.Count.ShouldBe(0),
                () => executionLogs.ShouldContain($"     WARNING -- Location: GetGroups() -- Path:{DummyString} -- Message:{DummyError}"));
        }

        [TestMethod]
        public void AddTimerJob_WhenExecuteScalarReturnsGuidAndRunNowIsTrue_ConfirmResult()
        {
            // Arrange
            var jobEnqueued = false;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => Guid.NewGuid();
            ShimCoreFunctions.enqueueGuidInt32 = (_, __) => jobEnqueued = true;

            // Act
            var result = _testObj.AddTimerJob(_web, DummyInt, DummyInt, DummyString, true);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _sqlString.ShouldContain("UPDATE TIMERJOBS"),
                () => _nonQueryExecuted.ShouldBeTrue(),
                () => jobEnqueued.ShouldBeTrue(),
                () => _daoDisposed.ShouldBeTrue());
        }

        [TestMethod]
        public void AddTimerJob_WhenExecuteScalarReturnsNullAndRunNowIsFalse_ConfirmResult()
        {
            // Arrange
            var jobEnqueued = false;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => null;
            ShimCoreFunctions.enqueueGuidInt32 = (_, __) => jobEnqueued = true;

            // Act
            var result = _testObj.AddTimerJob(_web, DummyInt, DummyInt, DummyString, false);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => _sqlString.ShouldContain("INSERT INTO TIMERJOBS"),
                () => _nonQueryExecuted.ShouldBeTrue(),
                () => jobEnqueued.ShouldBeFalse(),
                () => _daoDisposed.ShouldBeTrue());
        }

        [TestMethod]
        public void AddTimerJob_OnError_LogError()
        {
            // Arrange
            var jobEnqueued = false;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) =>
            {
                throw new Exception(DummyError);
            };
            ShimCoreFunctions.enqueueGuidInt32 = (_, __) => jobEnqueued = true;

            // Act
            var result = _testObj.AddTimerJob(_web, DummyInt, DummyInt, DummyString, false);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => _nonQueryExecuted.ShouldBeFalse(),
                () => jobEnqueued.ShouldBeFalse(),
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: AddTimerJob() -- Message: {DummyError}"));
        }

        [TestMethod]
        public void GetUserSIDByCN_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            var result = _testObj.GetUserSIDByCN(DummyString, DummyString);

            // Assert
            result.ShouldBe(DummyString.ToUpper());
        }

        [TestMethod]
        public void GetUserSIDByCN_OnError_LogError()
        {
            // Arrange
            ShimDirectoryEntry.ConstructorStringStringStringAuthenticationTypes = (_, _1, _2, _3, _4) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            var result = _testObj.GetUserSIDByCN(DummyString, DummyString);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeNullOrWhiteSpace(),
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: GetUserSIDByCN() -- CN: {DummyString} -- Domain: {DummyString} -- Message: {DummyError}"));
        }

        [TestMethod]
        public void AuditResourcePool_WhenUserNotDeleted_ConfirmResult()
        {
            // Arrange
            var list = new ShimSPList
            {
                ItemsGet = () => new ShimSPListItemCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = _ => new ShimSPListItem
                    {
                        ItemGetString = __ => DummyString,
                        Update = () => _listItemUpdated = true
                    }
                }
            }.Instance;

            _privateObj.SetFieldOrProperty(ListProperty, list);

            // Act
            _privateObj.Invoke(AuditResourcePoolMethod);

            // Assert
            _listItemUpdated.ShouldBeTrue();
        }

        [TestMethod]
        public void AuditResourcePool_OnError_LogError()
        {
            // Arrange
            var list = new ShimSPList
            {
                ItemsGet = () => new ShimSPListItemCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = _ =>
                    {
                        throw new Exception(DummyError);
                    }
                }
            }.Instance;

            _privateObj.SetFieldOrProperty(ListProperty, list);

            // Act
            _privateObj.Invoke(AuditResourcePoolMethod);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => _listItemUpdated.ShouldBeFalse(),
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: AuditResourcePool() -- SID: -- Message: {DummyError}"));
        }

        [TestMethod]
        public void UpdateResourcePool_OnValidCall_ConfirmResult()
        {
            // Arrange
            var dataTable = CreateDataTable();
            var dataRow = dataTable.NewRow();

            dataRow[SIDField] = DummyString;
            dataTable.Rows.Add(dataRow);

            var list = new ShimSPList
            {
                ItemsGet = () => new ShimSPListItemCollection
                {
                    Add = () =>
                    {
                        _listItemAdded = true;
                        return new ShimSPListItem();
                    }
                }
            }.Instance;

            var dao = new ShimEPMData().Instance;

            _privateObj.SetFieldOrProperty(AdUsersProperty, dataTable);
            _privateObj.SetFieldOrProperty(ListProperty, list);
            _privateObj.SetFieldOrProperty(DAOProperty, dao);

            // Act
            _privateObj.Invoke(UpdateResourcePoolMethod);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _listItemAdded.ShouldBeTrue(),
                () => _nonQueryExecuted.ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateResource_OnError_LogError()
        {
            // Arrange
            var adFieldMappings = new List<string>() { DummyString };
            var listItem = new ShimSPListItem
            {
                ItemGetString = _ => DummyString,
                Update = () => { }
            };
            var dataTable = CreateDataTable();
            var dataRow = dataTable.NewRow();

            dataRow[SIDField] = DummyString;
            dataTable.Rows.Add(dataRow);

            _privateObj.SetFieldOrProperty(AdFieldMappingsProperty, adFieldMappings);

            // Act
            _privateObj.Invoke(UpdateResourceMethod, listItem.Instance, dataRow);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs[0].ShouldContain($"     ERROR -- Location: UpdateResource() -- SID: {DummyString} SPField:  ADField: -- Message:"));
        }

        [TestMethod]
        public void GetResourcepoolItem_WhenSIDFound_ConfirmResult()
        {
            // Arrange
            SetupForGetResourcepoolItem();

            // Act
            var result = (SPListItem)_privateObj.Invoke(GetResourcepoolItemMethod, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe(DummyString),
                () => _listItemAdded.ShouldBeFalse());
        }

        private void SetupForGetResourcepoolItem()
        {
            var dataTable = CreateDataTable();
            var dataRow = dataTable.NewRow();

            dataRow[SIDField] = DummyString;
            dataRow[IDField] = DummyInt;
            dataTable.Rows.Add(dataRow);

            var list = new ShimSPList
            {
                ItemsGet = () => new ShimSPListItemCollection
                {
                    Add = () =>
                    {
                        _listItemAdded = true;
                        return new ShimSPListItem
                        {
                            NameGet = () => DummyString
                        };
                    }
                },
                GetItemByIdInt32 = _ => new ShimSPListItem
                {
                    NameGet = () => DummyString
                }.Instance
            }.Instance;

            _privateObj.SetFieldOrProperty(HasSIDProperty, true);
            _privateObj.SetFieldOrProperty(ResourcePoolProperty, dataTable);
            _privateObj.SetFieldOrProperty(ListProperty, list);
        }

        [TestMethod]
        public void GetResourcepoolItem_WhenSIDNotFound_ConfirmResult()
        {
            // Arrange
            SetupForGetResourcepoolItem();

            // Act
            var result = (SPListItem)_privateObj.Invoke(GetResourcepoolItemMethod, $"{DummyString}_");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe(DummyString),
                () => _listItemAdded.ShouldBeTrue());
        }

        [TestMethod]
        public void UpdateResource_WhenNotSharepointAccount_ConfirmResult()
        {
            // Arrange
            SPListItem listItem;
            DataRow dataRow;
            SetupForUpdateResource(out listItem, out dataRow, DummyString);

            // Act
            _privateObj.Invoke(UpdateResourceMethod, listItem, dataRow);

            // Assert
            var processedUsers = (List<string>)_privateObj.GetFieldOrProperty(ProcessedUsersProperty);
            this.ShouldSatisfyAllConditions(
                () => _listItemUpdated.ShouldBeTrue(),
                () => _userAdded.ShouldBeFalse(),
                () => processedUsers.Count.ShouldBe(1),
                () => processedUsers[0].ShouldBe(DummyString));
        }

        private void SetupForUpdateResource(out SPListItem listItem, out DataRow dataRow, string fieldName)
        {
            var adFieldMappings = new List<string>() { DummyString };
            var adFieldMappingValues = new Hashtable();
            var dataTable = CreateDataTable();

            listItem = new ShimSPListItem
            {
                Update = () => _listItemUpdated = true
            }.Instance;

            dataRow = dataTable.NewRow();
            dataRow[SIDField] = DummyString;
            dataRow[TitleField] = DummyString;
            dataRow[DummyString] = DummyString;
            dataRow[SharepointAccountField] = DummyString;
            dataTable.Rows.Add(dataRow);

            adFieldMappingValues.Add(DummyString, fieldName);

            _privateObj.SetFieldOrProperty(AdFieldMappingsProperty, adFieldMappings);
            _privateObj.SetFieldOrProperty(AdFieldMappingValuesProperty, adFieldMappingValues);
            _privateObj.SetFieldOrProperty(WebProperty, _web.Instance);
        }

        [TestMethod]
        public void UpdateResource_WhenSharepointAccount_ConfirmResult()
        {
            // Arrange
            SPListItem listItem;
            DataRow dataRow;
            SetupForUpdateResource(out listItem, out dataRow, SharepointAccountField);

            // Act
            _privateObj.Invoke(UpdateResourceMethod, listItem, dataRow);

            // Assert
            var processedUsers = (List<string>)_privateObj.GetFieldOrProperty(ProcessedUsersProperty);
            this.ShouldSatisfyAllConditions(
                () => _listItemUpdated.ShouldBeTrue(),
                () => _userAdded.ShouldBeTrue(),
                () => processedUsers.Count.ShouldBe(1),
                () => processedUsers[0].ShouldBe(DummyString));
        }

        [TestMethod]
        public void CheckForSIDandDisableColumn_WhenListContainsSIDAndItemsCountGreaterThanZero_ConfirmResult()
        {
            // Arrange
            SetupForCheckForSIDandDisableColumn(true, 1);

            // Act
            var result = (bool)_privateObj.Invoke(CheckForSIDandDisableColumnMethod);

            // Assert
            var adUsers = (DataTable)_privateObj.GetFieldOrProperty(AdUsersProperty);
            var hasSID = (bool)_privateObj.GetFieldOrProperty(HasSIDProperty);
            this.ShouldSatisfyAllConditions(
                () => _listUpdated.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeFalse(),
                () => _listItemDeleted.ShouldBeFalse(),
                () => _fieldAdded.ShouldBeFalse(),
                () => result.ShouldBeTrue(),
                () => adUsers.ShouldNotBeNull(),
                () => hasSID.ShouldBeTrue());
        }

        private void SetupForCheckForSIDandDisableColumn(bool containsField, int itemCount)
        {
            var list = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    ContainsFieldString = _ => containsField,
                    AddStringSPFieldTypeBoolean = (_, __, ___) =>
                    {
                        _fieldAdded = true;
                        return DummyString;
                    },
                    ItemGetString = _ => new ShimSPField()
                },
                ItemsGet = () => new ShimSPListItemCollection
                {
                    CountGet = () => itemCount,
                    GetDataTable = () => CreateDataTable(),
                    Add = () =>
                    {
                        _listItemAdded = true;
                        return new ShimSPListItem
                        {
                            Update = () => _listItemUpdated = true
                        };
                    },
                    DeleteInt32 = _ => _listItemDeleted = true
                },
                Update = () => _listUpdated = true
            }.Instance;

            _privateObj.SetFieldOrProperty(ListProperty, list);
        }

        [TestMethod]
        public void CheckForSIDandDisableColumn_WhenListContainsSIDAndItemsCountIsZero_ConfirmResult()
        {
            // Arrange
            SetupForCheckForSIDandDisableColumn(true, 0);

            // Act
            var result = (bool)_privateObj.Invoke(CheckForSIDandDisableColumnMethod);

            // Assert
            var adUsers = (DataTable)_privateObj.GetFieldOrProperty(AdUsersProperty);
            var hasSID = (bool)_privateObj.GetFieldOrProperty(HasSIDProperty);
            this.ShouldSatisfyAllConditions(
                () => _listUpdated.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeTrue(),
                () => _fieldAdded.ShouldBeFalse(),
                () => result.ShouldBeTrue(),
                () => adUsers.ShouldNotBeNull(),
                () => hasSID.ShouldBeTrue());
        }

        [TestMethod]
        public void CheckForSIDandDisableColumn_WhenListDoesNotContainSIDAndItemsCountIsZero_ConfirmResult()
        {
            // Arrange
            SetupForCheckForSIDandDisableColumn(false, 0);

            // Act
            var result = (bool)_privateObj.Invoke(CheckForSIDandDisableColumnMethod);

            // Assert
            var adUsers = (DataTable)_privateObj.GetFieldOrProperty(AdUsersProperty);
            var hasSID = (bool)_privateObj.GetFieldOrProperty(HasSIDProperty);
            this.ShouldSatisfyAllConditions(
                () => _listUpdated.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _listItemDeleted.ShouldBeTrue(),
                () => _fieldAdded.ShouldBeTrue(),
                () => result.ShouldBeTrue(),
                () => adUsers.ShouldNotBeNull(),
                () => hasSID.ShouldBeFalse());
        }

        [TestMethod]
        public void CheckForSIDandDisableColumn_OnError_LogError()
        {
            // Arrange
            var list = new ShimSPList
            {
                TitleGet = () => DummyString
            };

            _privateObj.SetFieldOrProperty(ListProperty, list.Instance);

            // Act
            var result = (bool)_privateObj.Invoke(CheckForSIDandDisableColumnMethod);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs[0].ShouldContain($"     ERROR -- Location: CheckForSIDandDisableColumn() -- List: {DummyString} -- Message: "));
        }

        [TestMethod]
        public void PopulateAllGroupUserAttributes_WhenUserNotDisabled_ConfirmResult()
        {
            // Arrange
            var adGroupNameAndPath = new Hashtable
            {
                [DummyString] = DummyString
            };
            var adExclusions = new ArrayList();
            var adUsers = CreateDataTable();
            var adFieldMappings = new List<string> { DummyString };
            var adFieldMappingValues = new Hashtable
            {
                [DummyString] = DummyString
            };

            var count = 0;
            ShimDirectorySearcher.AllInstances.FindOne = _ =>
            {
                count++;
                return count == 1 ? null : new ShimSearchResult()
                {
                    PropertiesGet = () => new ShimResultPropertyCollection
                    {
                        ItemGetString = __ => new ShimResultPropertyValueCollection
                        {
                            ItemGetInt32 = ___ => DummyString
                        }
                    }
                };
            };

            _privateObj.SetFieldOrProperty(GroupNameProperty, DummyString);
            _privateObj.SetFieldOrProperty(AdGroupNameAndPathProperty, adGroupNameAndPath);
            _privateObj.SetFieldOrProperty(AdExclusionsProperty, adExclusions);
            _privateObj.SetFieldOrProperty(AdUsersProperty, adUsers);
            _privateObj.SetFieldOrProperty(AdFieldMappingsProperty, adFieldMappings);
            _privateObj.SetFieldOrProperty(AdFieldMappingValuesProperty, adFieldMappingValues);

            // Act
            var result = (bool)_privateObj.Invoke(PopulateAllGroupUserAttributesMethod);

            // Assert
            adUsers.Rows.Count.ShouldBe(1);
        }

        [TestMethod]
        public void PopulateAllGroupUserAttributes_OnError_LogError()
        {
            // Arrange
            ShimDirectoryEntry.ConstructorString = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            _privateObj.Invoke(PopulateAllGroupUserAttributesMethod);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: PopulateAllGroupUserAttributes() module level -- Message: { DummyError}"));
        }

        [TestMethod]
        public void DisableUsers_OnError_LogError()
        {
            // Arrange
            var disableUsers = new List<string> { DummyString };
            ShimSPQuery.Constructor = _ =>
            {
                throw new Exception(DummyError);
            };

            _privateObj.SetFieldOrProperty(DisableUsersProperty, disableUsers);

            // Act
            _privateObj.Invoke(DisableUsersMethod);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: DisableUsers() -- SID: {DummyString} -- Message: {DummyError}"));
        }

        [TestMethod]
        public void UpdateResourcePool_OnError_LogError()
        {
            // Arrange
            var adUsers = CreateDataTable();
            var dataRow = adUsers.NewRow();
            adUsers.Rows.Add(dataRow);

            _privateObj.SetFieldOrProperty(AdUsersProperty, adUsers);

            // Act
            _privateObj.Invoke(UpdateResourcePoolMethod);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs[0].ShouldContain($"     ERROR -- Location: UpdateResourcePool() -- SID:  -- Message:"));
        }

        [TestMethod]
        public void GetResourcepoolItem_OnError_LogError()
        {
            // Arrange
            var resourcePool = CreateDataTable();
            var dataRow = resourcePool.NewRow();
            resourcePool.Rows.Add(dataRow);

            _privateObj.SetFieldOrProperty(ResourcePoolProperty, resourcePool);
            _privateObj.SetFieldOrProperty(HasSIDProperty, true);

            ShimDataTable.AllInstances.SelectString = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            _privateObj.Invoke(GetResourcepoolItemMethod, DummyString);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs[0].ShouldContain($"     ERROR -- Location: GetResourcepoolItem() -- SID: {DummyString} -- Message: {DummyError}"));
        }

        [TestMethod]
        public void GetSizeLimit_OnError_ReturnZero()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            var result = (int)_privateType.InvokeStatic(GetSizeLimitMethod);

            // Assert
            result.ShouldBe(0);
        }

        [TestMethod]
        public void Initialize_OnError_LogError()
        {
            // Arrange
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_1, _2, _3, _4) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            _privateObj.Invoke(InitializeMethod, _web.Instance);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: Initialize() -- Message: {DummyError}"));
        }

        [TestMethod]
        public void AddProperties_OnError_LogError()
        {
            // Arrange
            var adFieldMappings = new List<string>() { DummyString };

            _privateObj.SetFieldOrProperty(AdFieldMappingsProperty, adFieldMappings);

            ShimDirectorySearcher.AllInstances.PropertiesToLoadGet = _ =>
            {
                throw new Exception(DummyError);
            };

            // Act
            _privateObj.Invoke(AddPropertiesMethod, new ShimDirectorySearcher().Instance);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: AddProperties() module level -- Message: { DummyError}"));
        }

        [TestMethod]
        public void GetUserSID_OnError_LogError()
        {
            // Arrange
            ShimDirectoryEntry.ConstructorStringStringStringAuthenticationTypes = (_1, _2, _3, _4, _5) =>
            {
                throw new Exception(DummyError);
            };

            // Act
            var result = (string)_privateObj.Invoke(GetUserSIDMethod, DummyString);

            // Assert
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty(ExecutionLogsProperty);
            var hasErrors = (bool)_privateObj.GetFieldOrProperty(HasErrorsProperty);
            this.ShouldSatisfyAllConditions(
                () => result.ShouldBeNullOrWhiteSpace(),
                () => hasErrors.ShouldBeTrue(),
                () => executionLogs.ShouldContain($"     ERROR -- Location: GetUserSID() -- Path: {DummyString} -- Message: { DummyError}"));
        }
    }
}
