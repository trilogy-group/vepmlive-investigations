using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using EPMLiveCore.Jobs.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.API;

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
                //Arrange
                int Openconnection = 0;
                int Closeconnection = 0;
                ResourceImportJob resourceimportjob = new ResourceImportJob();
              
                ShimSqlConnection.ConstructorString = (instance, _string) => { };
                
                ShimResourceImportJob.AllInstances.IsImportCancelledGuid = (ins, gid) => { };
                ShimSqlConnection.AllInstances.Open = (instance) => { Openconnection++; };
                ShimSqlConnection.AllInstances.DisposeBoolean = (instance, _bool) => { Closeconnection++; };
                ShimSqlCommand.AllInstances.ExecuteNonQuery = (instance) => { return 0; };
                ResourceImportResult res = new ResourceImportResult();
                res.TotalRecords = 0;
                ResourceImporter resimp = new ShimResourceImporter();
                new PrivateObject(resourceimportjob).SetField("resourceImporter", resimp);

                //Act
                new PrivateObject(resourceimportjob).Invoke("UpdateProgress", res);

                //Assert
                Assert.AreEqual(Openconnection, Closeconnection);
            }
        }

        [TestMethod()]
        public void UpdateProgressTest_Run_Catch_When_resourceImporter_Isnull()
        {
            using (new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                //Arrange
                int Openconnection = 0;
                int Closeconnection = 0;
                ResourceImportJob resourceimportjob = new ResourceImportJob();

                ShimSqlConnection.ConstructorString = (instance, _string) => { };
                ShimSqlConnection.AllInstances.DisposeBoolean = (instance, _bool) => { Closeconnection++; };
                ResourceImportResult res = new ResourceImportResult();
                res.TotalRecords = 1;
                
                //Act
                new PrivateObject(resourceimportjob).Invoke("UpdateProgress", res);

                //Assert
                //Connection open will not call exception will raise before this code
                Assert.AreNotEqual(Openconnection, Closeconnection);
            }
        }
    }
}