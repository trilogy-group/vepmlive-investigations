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
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, listId, listName, shortMsg, LongMsg, level, type, timerJobGuid) =>
            {
                // log to list
                return true;
            };
            ShimReportData.AllInstances.Dispose = _ => { };
        }

        [TestMethod]
        public void StartRefresh_RefreshAllFalse()
        {
            // Arrange
            var resultsDataTable = new DataTable();
            ShimRefreshLists.AllInstances.InitializeResultsDTStringBoolean =
                (_, listsNames, refreshAll) => new ShimDataTable
                {

                };
            privateObject.SetFieldOrProperty("_ArrayListNames", new string[]
            {
                DummyString
            });
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = listName => new ShimSPList
                {

                }
            };
            ShimReportData.AllInstances.GetTableNameString = (_, tableName) => DummyString;
            ShimReportData.AllInstances.GetTableNameGuid = (_, guid) => DummyString;
            ShimReportData.AllInstances.DeleteMyWorkGuid = (_, guid) => true;
            ShimRefreshLists.AllInstances.AddItems_MyWorkGuidStringGuidBooleanOutStringOut = AddItemsMyWorkSuccess;
            ShimRefreshLists.AllInstances.AddItemsGuidStringBooleanOutStringOut = AddItemsScuccess;
            ShimProcessSecurity.ProcessSecurityOnListRefreshSPWebSPListSqlConnection = (web, list, connection) => { };
            ShimReportData.AllInstances.GetClientReportingConnection = _ => new SqlConnection();


            // Act
            refreshLists.StartRefresh(DummyGuid, out resultsDataTable, false);

            // Assert
            



        }

        private void AddItemsScuccess(RefreshLists refreshList, Guid jobGuid, string listName, out bool error, out string errorMessage)
        {
            error = false;
            errorMessage = string.Empty;
        }

        private void AddItemsMyWorkSuccess(RefreshLists refreshList, Guid jobGuid, string listName, Guid listId, out bool error, out string errorMessage)
        {
            error = false;
            errorMessage = string.Empty;
        }
    }
}
