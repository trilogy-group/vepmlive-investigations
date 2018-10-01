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
using System.Linq;
using System.Security.Principal.Fakes;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ADSyncTests
    {
        private IDisposable _shimObject;
        private ADSync _testObj;
        private PrivateObject _privateObj;
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

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyError = "Dummy Error";

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

            _shimObject = ShimsContext.Create();
            _testObj = new ADSync();
            _privateObj = new PrivateObject(_testObj);

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
                }
            };

            _web = new ShimSPWeb
            {
                SiteGet = () => _site,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => spList
                }
            };

            ShimSPSite.AllInstances.OpenWeb = _ => _web;

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => _web;

            ShimSPQuery.Constructor = _ => { };

            ShimEPMData.ConstructorGuid = (_, __) => { };
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new ShimSqlConnection();
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => _nonQueryExecuted = true;
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
            dataTable.Columns.Add("SID");
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add(DummyString);

            return dataTable;
        }

        [TestMethod]
        public void InitiateSync_OnValidCall_ConfirmResult()
        {
            // Arrange
            string processLog;
            bool hasErrors;

            _privateObj.SetFieldOrProperty("_hasSID", true);

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
            var executionLogs = (List<string>)_privateObj.GetFieldOrProperty("_ExecutionLogs");
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
    }
}
