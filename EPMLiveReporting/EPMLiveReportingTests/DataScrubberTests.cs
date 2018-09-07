using System;
using System.Collections.Generic;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EPMLiveReporting.Tests
{
    [TestClass]
    public class DataScrubberTests
    {
        private IDisposable shimContext;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        [TestMethod]
        public void MyTestMethod()
        {
            // Arrange
            var site = new ShimSPSite();
            var epmData = new ShimEPMData
            {
                LogStatusStringStringStringStringInt32Int32String = (listId, listName, shortMsg, longMsg, level, type, guid) => true
            };

            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSPSecurity.RunWithElevatedPrivilegesWaitCallbackObject = (callback, args) => 
            {
                callback(args);
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code =>
            {
                try
                {
                    code();
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            };
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.DefaultPageUrlGet = _ => "https://server.org/dummy";
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();

            ShimDbDataAdapter.AllInstances.FillDataSet = (_, ds) => 1;
            ShimDbDataAdapter.AllInstances.FillDataTableArrayInt32Int32IDbCommandCommandBehavior = (_, dataTables, start, maxRecords, command, behavior) => 1;
            ShimSPWebCollection.AllInstances.Undirty = _ => { };
            //ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPBase>


            
            // Act
            //DataScrubber.CleanTables(site, epmData);

            // Assert

        }

    }
}
