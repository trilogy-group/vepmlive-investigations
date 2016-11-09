using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using EPMLiveCore.Fakes;
using System.Data.SqlClient.Fakes;
using System.Data;


namespace EPMLiveCore.Tests.ReportHelper
{
    [TestClass]
    public class EPMDataTest
    {
        [TestMethod]
        public void BulkInsertTest()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                int Openconnection = 0;
                int Closeconnection = 0;
               
                ShimEPMData.ConstructorGuid = (instance, _guid) =>
                {
                };
                ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (String1, String2, String3, String4, Int321, Int322, String5, _bool) => { return true; };
                ShimSqlConnection.ConstructorString = (instance, _string) => { };
                ShimSqlConnection.AllInstances.Open = (instance) => { Openconnection++; };
                ShimSqlConnection.AllInstances.BeginTransaction = (instance) => { return new ShimSqlTransaction() { Commit = () => { }, DisposeBoolean = (_bool) => { }, Rollback = () => { } }; };
                ShimSqlConnection.AllInstances.DisposeBoolean = (instance, _bool) => { Closeconnection++; };
                ShimSqlBulkCopy.ConstructorSqlConnectionSqlBulkCopyOptionsSqlTransaction = (_a, _b, _c, _d) =>
                {

                };
                ShimSqlBulkCopy.AllInstances.Close = (instance) => { };
                ShimSqlBulkCopy.AllInstances.NotifyAfterGet = (instance) => { return 0; };
                ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (instance, _dt) => { };
                ShimSqlBulkCopy.AllInstances.ColumnMappingsGet = (instance) => { return new ShimSqlBulkCopyColumnMappingCollection() { AddStringString = (_string, str) => { return new ShimSqlBulkCopyColumnMapping(); } }; };
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("TestColumn");
                ds.Tables.Add(dt);
                EPMData epmdata = new EPMData(Guid.NewGuid());
                string message = string.Empty;

                //Act
                var result = epmdata.BulkInsert(ds, true, out message);
                //Assert
                Assert.AreEqual(true, result);
                Assert.AreEqual(Openconnection, Closeconnection);

                //Act
                result = epmdata.BulkInsert(ds, Guid.NewGuid());

                //Assert
                Assert.AreEqual(true, result);
                Assert.AreEqual(Openconnection, Closeconnection);
            }

        }

        [TestMethod]
        public void BulkInsertTest_ExecuteCatch()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                int Openconnection = 0;
                int Closeconnection = 0;
                
                ShimEPMData.ConstructorGuid = (instance, _guid) =>
                {
                };
                ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (String1, String2, String3, String4, Int321, Int322, String5, _bool) => { return true; };
                ShimSqlConnection.ConstructorString = (instance, _string) => { };
                ShimSqlConnection.AllInstances.Open = (instance) => { Openconnection++; };
                ShimSqlConnection.AllInstances.BeginTransaction = (instance) => { return new ShimSqlTransaction() { Commit = () => { }, DisposeBoolean = (_bool) => { }, Rollback = () => { } }; };
                ShimSqlConnection.AllInstances.DisposeBoolean = (instance, _bool) => { Closeconnection++; };
                ShimSqlBulkCopy.ConstructorSqlConnectionSqlBulkCopyOptionsSqlTransaction = (_a, _b, _c, _d) =>
                {

                };
                ShimSqlBulkCopy.AllInstances.Close = (instance) => { };
                
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("TestColumn");
                ds.Tables.Add(dt);
                EPMData epmdata = new EPMData(Guid.NewGuid());
                string message = string.Empty;
                //Act
                var result = epmdata.BulkInsert(ds, true, out message);
                //Assert
                Assert.AreEqual(false, result);
                Assert.AreEqual(Openconnection, Closeconnection);

                //Act
                result = epmdata.BulkInsert(ds, Guid.NewGuid());
                //Assert
                Assert.AreEqual(false, result);
                Assert.AreEqual(Openconnection, Closeconnection);
            }
        }
        [TestMethod]
        public void BulkInsertTest_ExecuteCatch_2()
        {
            using (SPEmulators.SPEmulationContext ctx = new SPEmulators.SPEmulationContext(SPEmulators.IsolationLevel.Fake))
            {
                int Openconnection = 0;
                int Closeconnection = 0;
                
                ShimEPMData.ConstructorGuid = (instance, _guid) =>
                {
                };
                ShimSqlConnection.ConstructorString = (instance, _string) => { };
                
                ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (String1, String2, String3, String4, Int321, Int322, String5, _bool) => { return true; };
                ShimSqlConnection.AllInstances.DisposeBoolean = (instance, _bool) => { Closeconnection++; };
              
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("TestColumn");
                ds.Tables.Add(dt);
                EPMData epmdata = new EPMData(Guid.NewGuid());
                string message = string.Empty;
                //Act
                var result = epmdata.BulkInsert(ds, true, out message);
                
                //Assert
                Assert.AreEqual(false, result);
                Assert.AreNotEqual(Openconnection, Closeconnection);

                //Act
                result = epmdata.BulkInsert(ds, Guid.NewGuid());

                //Assert
                Assert.AreEqual(false, result);
                Assert.AreNotEqual(Openconnection, Closeconnection);
            }
        }

        


        
    }
}