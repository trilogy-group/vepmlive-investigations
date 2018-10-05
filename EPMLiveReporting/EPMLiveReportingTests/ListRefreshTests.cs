using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Linq;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin;
using EPMLiveReportsAdmin.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests
{
    [TestClass]
    public class ListRefreshTests
    {
        private const string DummyException = "Dummy Exception";
        private const string DummyString = "DummyString";
        private static string CustomErrorMessageAddItemsMyWorkMethod = string.Empty;
        private static string CustomErrorMessageAddItemMethod = string.Empty;
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private static readonly List<string> LogStatus = new List<string>();
        private static bool AddItemsWasCalled = false;
        private static bool AddItemsMyWorkWasCalled = false;
        private IDisposable shimsContext;
        private RefreshLists refreshLists;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            LogStatus.Clear();
            refreshLists = new RefreshLists(new ShimSPWeb(), DummyString);
            privateObject = new PrivateObject(refreshLists);

            privateObject.SetFieldOrProperty("_ArrayListTableNames", new ArrayList());
            privateObject.SetFieldOrProperty("_dsMyWorkLists", new ShimDataSet().Instance);
            //{
            //    TablesGet = () =>
            //    {
            //        var list = new List<DataTable>
            //        {
            //            new ShimDataTable()
            //        };
            //        return new ShimDataTableCollection().Bind(list);
            //    }
            //}.Instance);
            privateObject.SetFieldOrProperty("_dsLists", new ShimDataSet().Instance);
            //{
            //    TablesGet = () =>
            //    {
            //        var list = new List<DataTable>
            //        {
            //            new ShimDataTable()
            //        }.AsEnumerable();
            //        return new ShimDataTableCollection().Bind(list);
            //    }
            //}.Instance);
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
            ShimProcessSecurity.ProcessSecurityOnRefreshAllSPWebListOfSPListSqlConnection = (web, list, connection) => { };
            ShimReportData.AllInstances.GetClientReportingConnection = _ => new SqlConnection();
            ShimReportData.AllInstances.GetTableNameString = (_, tableName) => DummyString;
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) => DummyString;
            ShimReportData.AllInstances.DeleteMyWorkGuid = (_, guid) => true;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.ItemGetString = (_, listName) => new ShimSPList();
            ShimSPList.AllInstances.TitleGet = _ => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (name, list) => GetSettingsContent();
            ShimDataSet.AllInstances.TablesGet = _ =>
            {
                var list = new List<DataTable>
                {
                    new ShimDataTable()
                };
                return new ShimDataTableCollection().Bind(list);
            };


        }

        [TestMethod]
        public void StartRefresh_RefreshAllTrueOnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => new ShimSPList();
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllWorkHoursListError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyString}";
            const string ListName = "Work Hours";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = string.Empty;

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllWorkHoursListErrorAddMessage_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = DummyString;
            var expectedErrorMessage = $"{DummyString}&nbsp;{DummyString}";
            const string ListName = "Work Hours";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = string.Empty;

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldStartWith(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllWorkHoursListNotFoundError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;List not present";
            const string ListName = "Work Hours";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = "List does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllWorkHoursListNotFoundErrorAddMessage_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = DummyString;
            var expectedErrorMessage = $"{DummyString}&nbsp;List not present";
            const string ListName = "Work Hours";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = "List does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldStartWith(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllWorkHoursListException_ExecutesCorrectly()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            const string ListName = "Work Hours";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllIsReportingListError_ExecuteCorrectly()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyString}";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == DummyString ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) => DummyString;
            privateObject.SetFieldOrProperty("_sListNames", $"{DummyString},{DummyString}");
            CustomErrorMessageAddItemMethod = string.Empty;

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllOnProcessSecurityRefreshAllException_LogErrorMessage()
        {
            // Arrange
            const string ExpectedErrorMessage = "ProcessSecurity failed on refresh all.";
            var expectedMessage = $"{ExpectedErrorMessage} - {DummyException}";
            var resultsDataTable = new DataTable();
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => false;
            ShimSPListCollection.AllInstances.TryGetListString = null;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) => DummyString;
            ShimProcessSecurity.ProcessSecurityOnRefreshAllSPWebListOfSPListSqlConnection = (web, list, connection) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(expectedMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseOnProcessSecurityOnListRefreshException_LogErrorMessage()
        {
            // Arrange
            var errorMessage = string.Empty;
            var resultsDataTable = new DataTable();
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => false;
            ShimSPListCollection.AllInstances.TryGetListString = null;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) => DummyString;
            ShimProcessSecurity.ProcessSecurityOnListRefreshSPWebSPListSqlConnection = (web, list, connection) =>
            {
                throw new Exception(DummyException);
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
                () => resultsDataTable.ShouldNotBeNull(),
                () => errorMessage.ShouldContain(DummyException));
        }

        [TestMethod]
        public void StartRefresh_GeneralException_LogErrorMessage()
        {
            // Arrange
            const string ExpectedLogMessage = "";
            var expectedErrroMessage = $"Error: {DummyException}";
            var errorMessage = string.Empty;
            var resultsDataTable = new DataTable();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ =>
           {
               throw new Exception(DummyException);
           };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue(),
                () => LogStatus.Any(p => p.Contains(expectedErrroMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllIsReportingListNotFoundError_ExecuteCorrectly()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;List not present";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == DummyString ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) => DummyString;
            privateObject.SetFieldOrProperty("_sListNames", $"{DummyString},{DummyString}");
            CustomErrorMessageAddItemMethod = "does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllIsReportingListException_ExecuteCorrectly()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == DummyString ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) =>
            {
                throw new Exception(DummyException);
            };
            privateObject.SetFieldOrProperty("_sListNames", $"{DummyString},{DummyString}");

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllResourcesListError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyString}";
            const string ListName = "Resources";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = string.Empty;

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllResourcesListErrorAddError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = DummyString;
            var expectedErrorMessage = $"{DummyString}&nbsp;{DummyString}";
            const string ListName = "Resources";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = string.Empty;

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllResorucesListNotFoundError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;List not present";
            const string ListName = "Resources";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = "List does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllResorucesListNotFoundErrorAddMessage_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = DummyString;
            var expectedErrorMessage = $"{DummyString}&nbsp;List not present";
            const string ListName = "Resources";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsError;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemMethod = "List does not exist at site with url";

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllResorucesListException_ExecutesCorrectly()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            const string ListName = "Resources";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            ShimReportData.AllInstances.GetTableNameString = (_, name) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllResorucesListExceptionAddMessage_ExecutesCorrectly()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            var errorMessage = DummyString;
            var expectedErrorMessage = $"{DummyString}&nbsp;{DummyException}";
            const string ListName = "Resources";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == ListName ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            ShimReportData.AllInstances.GetTableNameString = (_, name) =>
            {
                throw new Exception(DummyException);
            };

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllListError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyString}";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => false;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkError;
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == DummyString ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            privateObject.SetFieldOrProperty("_sListNames", $"{DummyString},{DummyString}");
            CustomErrorMessageAddItemsMyWorkMethod = null;

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsMyWorkWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllNotFoundError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on refresh all for web";
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;List not present";
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => false;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkError;
            ShimGridGanttSettings.ConstructorSPList = null;

            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == DummyString ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemsMyWorkMethod = "List does not exist at site with url";
            privateObject.SetFieldOrProperty("_sListNames", $"{DummyString},{DummyString}");

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => AddItemsMyWorkWasCalled.ShouldBeTrue(),
                () => LogStatus.ShouldNotBeEmpty(),
                () => LogStatus.Any(p => p.Contains(ExpectedLogMessage)).ShouldBeTrue());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllListException_ExecutesCorrectly()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimRefreshLists.AllInstances.IsReportingListString = (_, name) => false;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkException;
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => name == DummyString ? new ShimSPList() : null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            ShimReportData.AllInstances.GetTableNameString = (_, name) =>
            {
                throw new Exception(DummyException);
            };
            privateObject.SetFieldOrProperty("_sListNames", $"{DummyString},{DummyString}");

            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, true);

            // Assert
            resultsDataTable.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldContain(expectedErrorMessage),
                () => resultsDataTable.ShouldNotBeNull(),
                () => LogStatus.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalseOnSuccess_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedLogMessage = "ProcessSecurity processed successfully on list";
            var insertAllItemsDBWasCalled = false;
            var resultsDataTable = new DataTable();
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
            CustomErrorMessageAddItemMethod = null;

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
            var insertAllItemsDBWasCalled = false;
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            var resultsDataTable = new DataTable();
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
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkError;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => string.IsNullOrEmpty(errorMessage) ? null : errorMessage,
                    ItemSetStringObject = (name, value) => errorMessage = value.ToString()
                }
            };
            CustomErrorMessageAddItemsMyWorkMethod = null;

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
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkError;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimCoreFunctions.getListSettingStringSPList = (name, list) => GetSettingsContent();

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
            var insertAllItemsDBWasCalled = false;
            var resultsDataTable = new DataTable();
            var errorMessage = string.Empty;
            var expectedErrorMessage = $"&nbsp;{DummyException}";
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkException;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimReportData.AllInstances.InsertAllItemsDBDataSetGuid = (_, dataSet, jobGuid) =>
            {
                insertAllItemsDBWasCalled = true;
                return true;
            };
            ShimGridGanttSettings.ConstructorSPList = null;
            ShimCoreFunctions.getListSettingStringSPList = (name, list) => GetSettingsContent();
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

        private string GetSettingsContent()
        {
            var settings = Enumerable.Range(1, 30)
                .Select(p => bool.TrueString);

            return string.Join("\n", settings);
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void AddItemsError(
            RefreshLists refreshList,
            Guid jobGuid,
            string listName,
            out bool error,
            out string errorMessage)
        {
            AddItemsWasCalled = true;
            error = true;
            errorMessage = string.IsNullOrEmpty(CustomErrorMessageAddItemMethod) ? DummyString : CustomErrorMessageAddItemMethod;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void AddItemsScuccess(
            RefreshLists refreshList,
            Guid jobGuid,
            string listName,
            out bool error,
            out string errorMessage)
        {
            AddItemsWasCalled = true;
            error = false;
            errorMessage = string.Empty;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void AddItemsMyWorkSuccess(
            RefreshLists refreshList,
            Guid jobGuid,
            string listName,
            Guid listId,
            out bool error,
            out string errorMessage)
        {
            error = false;
            errorMessage = string.Empty;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void AddItemsMyWorkError(
            RefreshLists refreshList,
            Guid jobGuid,
            string listName,
            Guid listId,
            out bool error,
            out string errorMessage)
        {
            AddItemsMyWorkWasCalled = true;
            error = true;
            errorMessage = string.IsNullOrEmpty(CustomErrorMessageAddItemsMyWorkMethod) ? DummyString : CustomErrorMessageAddItemsMyWorkMethod;
        }

        /// <summary>
        /// This method is fake. All the parameters are required, even though not all of them are used
        /// </summary>
        private void AddItemsMyWorkException(
            RefreshLists refreshList,
            Guid jobGuid,
            string listName,
            Guid listId,
            out bool error,
            out string errorMessage)
        {
            throw new Exception(DummyException);
        }
    }
}
