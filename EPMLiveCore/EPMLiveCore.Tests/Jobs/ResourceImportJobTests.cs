using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient.Fakes;
using EPMLiveCore.Jobs.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.API;
using EPMLive.TestFakes;

namespace EPMLiveCore.Jobs.Tests
{
    [TestClass()]
    public class ResourceImportJobTests
    {
        [TestMethod()]
        public void UpdateProgressTest()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ResourceImportJob resourceimportjob = new ResourceImportJob();

                using (TestCheck.OpenCloseConnections)
                {

                    ShimResourceImportJob.AllInstances.IsImportCancelledGuid = (ins, gid) => { };
                    ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) => { return 0; };
                    ResourceImportResult res = new ResourceImportResult();
                    res.TotalRecords = 0;
                    ResourceImporter resimp = new ShimResourceImporter();
                    new PrivateObject(resourceimportjob).SetField("resourceImporter", resimp);

                    //Act
                    new PrivateObject(resourceimportjob).Invoke("UpdateProgress", res);
                }
            }
        }

       
        [TestMethod()]
        public void UpdateProgressTest_Run_Catch_When_resourceImporter_Isnull()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                ResourceImportJob resourceimportjob = new ResourceImportJob();

                using (TestCheck.OpenCloseConnections)
                {
                    ResourceImportResult res = new ResourceImportResult();
                    res.TotalRecords = 1;

                    //Act
                    new PrivateObject(resourceimportjob).Invoke("UpdateProgress", res);                   
                }
            }
        }
    }
}