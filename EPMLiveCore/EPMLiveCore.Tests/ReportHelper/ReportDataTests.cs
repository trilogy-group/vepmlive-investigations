using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.ReportHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using System.Data;
using EPMLiveCore.ReportHelper.Fakes;
using System.Data.SqlClient;
using Microsoft.QualityTools.Testing.Fakes;
using System.Collections;

namespace EPMLiveCore.ReportHelper.Tests
{
    [TestClass()]
    public class ReportDataTests
    {
        private IDisposable shimsContext;
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
             

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod()]
        public void CreateTableTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {

                ColumnDefCollection columns = ColumnDef.GetDefaultColumns();

                columns.AddColumn(new DataColumn("PeriodId"));
                columns.AddColumn(new DataColumn("WebId"));
                columns.AddColumn(new DataColumn("ItemId"));

                string message = string.Empty;
                ShimEPMData.ConstructorGuidStringStringBooleanStringString = (gid, n, s, use, uname, pwd, str) => { };
                ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (instance, sqlcon) => { return true; };
                ShimEPMData.AllInstances.GetClientReportingConnectionGet = (instane) => { return new SqlConnection(); };
                ReportData rd = new ReportData(new Guid(), "RD", "server", false, "username", "password");
                ShimReportData.AllInstances.TableExistsString = (ins, str) => { return false; };
                //when _when_tablename_rpttsdata
                //Arrange 
                string name = "rpttsdata";
                //Act

                bool result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);

                //when _when_tablename_lstmyworksnapshot
                //Arrange 
                name = "lstmyworksnapshot";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);



                //when _when_tablename_Snapshot
                //Arrange 
                name = "Create workspace1_LSTWikisSnapshot_dba1432e40a2432394ea3462f8097f14";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);


                //when _when_tablename_lstmywork
                //Arrange 
                name = "lstmywork";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);

                //when _when_tablename_test
                //Arrange 
                name = "test";
                //Act

                result = rd.CreateTable(name, columns, true, out message);

                //Assert
                Assert.AreEqual(string.Format("Table [{0}] successfully created.", name), message);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void MyWorkListItemsDataTable()
        {
            // Arrange
            var web = new ShimSPWeb();
            var list = new ArrayList();
            var error = false;
            var errorMessage = string.Empty;
            ShimEPMData.ConstructorGuidStringStringBooleanStringString = (_, siteId, dbName, serverName, useSAccount, username, password) => { };
            ShimReportData.AllInstances.GetListColumnsString = (_, name) => new DataTable();

            // Act
            ReportData report = new ReportData(DummyGuid, DummyString, DummyString, true, DummyString, DummyString);
            var result = report.MyWorkListItemsDataTable(DummyGuid, DummyString, web, DummyString, list, DummyGuid, out error, out errorMessage);

            // Assert




        }

    }
}