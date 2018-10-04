using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin;
using EPMLiveReportsAdmin.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests
{
    [TestClass]
    public class ListRefreshTests
    {
        private IDisposable shimsContext;
        private RefreshLists refreshLists;
        private PrivateObject privateObject;
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private static readonly List<string> LogStatus = new List<string>();
        private bool AddItemsWasCalled;
        private const string ResultText = "ResultText";
        private static string CustomErrorMessageAddItemMethod = string.Empty;
        private bool AddItemsMyWorkWasCalled = false;
        private string CustomErrorMessageAddItemsMyWorkMethod = string.Empty;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            LogStatus.Clear();
            refreshLists = new RefreshLists(new ShimSPWeb(), DummyString);
            privateObject = new PrivateObject(refreshLists);

            privateObject.SetFieldOrProperty("_ArrayListTableNames", new ArrayList());
            privateObject.SetFieldOrProperty("_dsMyWorkLists", new ShimDataSet
            {
                TablesGet = () =>
                {
                    var list = new List<DataTable>
                    {
                        new ShimDataTable()
                    };
                    return new ShimDataTableCollection().Bind(list);
                }
            }.Instance);
            privateObject.SetFieldOrProperty("_dsLists", new ShimDataSet
            {
                TablesGet = () =>
                {
                    var list = new List<DataTable>
                    {
                        new ShimDataTable()
                    };
                    return new ShimDataTableCollection().Bind(list);
                }
            }.Instance);
            privateObject.SetFieldOrProperty("_ArrayListNames", new string[] 
            {
                DummyString,
                DummyString,
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimRefreshLists.AllInstances.InitializeSPWebString = (_, web, listName) => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimReportData.ConstructorGuid = (_, guid) => { };
            ShimGridGanttSettings.ConstructorSPList = (_, list) => { };
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) => true;
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, LongMsg, level, type, timerJobGuid) =>
                {
                    LogStatus.Add($"{listId} - {listName} - {shortMsg} - {LongMsg} - {level} - {type} - {timerJobGuid}");
                    return true;
                };
            ShimReportData.AllInstances.Dispose = _ => { };
            ShimRefreshLists.AllInstances.InitializeResultsDTStringBoolean =
                (_, listsNames, refreshAll) => new ShimDataTable();
            ShimProcessSecurity.ProcessSecurityOnListRefreshSPWebSPListSqlConnection = (web, list, connection) => { };
            ShimReportData.AllInstances.GetClientReportingConnection = _ => new SqlConnection();
            ShimReportData.AllInstances.GetTableNameString = (_, tableName) => DummyString;
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) => DummyString;
            ShimReportData.AllInstances.DeleteMyWorkGuid = (_, guid) => true;

        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseOnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on list";
            var insertAllItemsDBWasCalled = false;
            var resultsDataTable = new DataTable();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            };
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };


            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue(),
                () => insertAllItemsDBWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseOnAddItemsError_ExecutesCorrectly()
        {
            // Arrange
            var insertAllItemsDBWasCalled = false;
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyString}";
            var resultsDataTable = new DataTable();
            privateObject.SetFieldOrProperty("_ArrayListNames", new string[]
            {
                DummyString,
                DummyString
            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            };
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => insertAllItemsDBWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseOnAddItemsListDoestNotExists_ExecutesCorrectly()
        {
            // Arrange
            var insertAllItemsDBWasCalled = false;
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;List not present";
            var resultsDataTable = new DataTable();
            privateObject.SetFieldOrProperty("_ArrayListNames", new string[]
            {
                DummyString,
                DummyString
            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            };
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = "The list does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => insertAllItemsDBWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseOnException_ExecutesCorrectly()
        {
            // Arrange
            const string DummyException = "Dummy Exception";
            var insertAllItemsDBWasCalled = false;
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            var resultsDataTable = new DataTable();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            };
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) =>
            {
                throw new Exception(DummyException);
            };
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => insertAllItemsDBWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseEnabledWorkListAndAddItemsError_ExecutesCorrectly()
        {
            // Arrange
            var insertAllItemsDBWasCalled = false;
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyString}";
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            };
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkError;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimCoreFunctions.getListSettingStringSPList = (name, list) => GetSettings();

            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => insertAllItemsDBWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseEnabledWorkListAndErrorListNotExists_ExecutesCorrectly()
        {
            // Arrange
            var insertAllItemsDBWasCalled = false;
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;List not present";
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            };
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkError;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimCoreFunctions.getListSettingStringSPList = (name, list) => GetSettings();

            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemsMyWorkMethod = "The list does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => insertAllItemsDBWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseEnabledWorkListOnException_ExecutesCorrectly()
        {
            // Arrange
            const string DummyException = "Dummy Exception";
            var insertAllItemsDBWasCalled = false;
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {
                    TitleGet = () => DummyString
                }
            };
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkException;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimCoreFunctions.getListSettingStringSPList = (name, list) => GetSettings();

            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemsMyWorkMethod = "The list does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => insertAllItemsDBWasCalled.ShouldBeTrue());
        }

        private string GetSettings()
        {
            var settings  = new string[]
            {
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
                bool.TrueString,
            };

            return string.Join("\n" , settings);
        }

        private void AddItemsError(RefreshLists refreshList, Guid jobGuid, string listName, out bool error, out string errorMessage)
        {
            AddItemsWasCalled = true;
            error = true;
            errorMessage = string.IsNullOrEmpty(CustomErrorMessageAddItemMethod) ? DummyString : CustomErrorMessageAddItemMethod;
        }

        private void AddItemsScuccess(RefreshLists refreshList, Guid jobGuid, string listName, out bool error, out string errorMessage)
        {
            AddItemsWasCalled = true;
            error = false;
            errorMessage = string.Empty;
        }

        private void AddItemsMyWorkSuccess(RefreshLists refreshList, Guid jobGuid, string listName, Guid listId, out bool error, out string errorMessage)
        {
            error = false;
            errorMessage = string.Empty;
        }

        private void AddItemsMyWorkError(RefreshLists refreshList, Guid jobGuid, string listName, Guid listId, out bool error, out string errorMessage)
        {
            AddItemsMyWorkWasCalled = true;
            error = true;
            errorMessage = string.IsNullOrEmpty(CustomErrorMessageAddItemsMyWorkMethod) ? DummyString : CustomErrorMessageAddItemsMyWorkMethod;
        }

        private void AddItemsMyWorkException(RefreshLists refreshList, Guid jobGuid, string listName, Guid listId, out bool error, out string errorMessage)
        {
            throw new Exception("Dummy Exception");
        }
    }
}
