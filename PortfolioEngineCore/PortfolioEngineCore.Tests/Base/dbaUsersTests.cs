using System;
using System.Collections.Generic;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class dbaUsersTests
    {
        private IDisposable _shimContext;
        private bool _readFirstCall;
        private PrivateObject _privateObject;
        private AdoShims _shimAdoNetCalls;

        [TestInitialize]
        public void TestInitialize()
        {
             _shimContext = ShimsContext.Create();
            _shimAdoNetCalls = AdoShims.ShimAdoNetCalls();

            _privateObject = new PrivateObject(typeof(dbaCCV));
            _readFirstCall = true;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void CalculateCostValues_Without_ProjectId_Should_Succeed()
        {
            // Arrange
            ArrangeShims();
            ShimdbaCCV.SetCostTotalsDBAccessInt32Int32IListOfInt32Boolean = (a, b, c, d, e) => StatusEnum.rsSuccess;

            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;

            // Act 
            var actualStatus = dbaCCV.CalculateCostValues(dba, 1, 2, 0, out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);
            Assert.AreEqual("CCV Complete",  sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION = 0", list[0].CommandText);
            Assert.AreEqual("Select MAX(PRD_ID) as PeriodCount From EPG_PERIODS Where CB_ID=2", list[1].CommandText);
            Assert.AreEqual("SELECT cc.BC_UID,BC_ID,BC_LEVEL,BC_UOM,ac.BC_UID as Avail_BC_UID FROM EPGP_COST_CATEGORIES cc Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID = cc.BC_UID And ac.CT_ID=1 ORDER BY cc.BC_ID", list[2].CommandText);
            Assert.AreEqual("SELECT BD_VALUE,BD_COST,BD_PERIOD,BC_UID FROM EPGP_DETAIL_VALUES  WHERE PROJECT_ID=1 AND CB_ID=2 AND CT_ID=1", list[3].CommandText);
            Assert.AreEqual("DELETE FROM  EPGP_COST_VALUES WHERE CB_ID=2 AND CT_ID=1", list[4].CommandText);
            Assert.AreEqual("INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY) VALUES(2,1,1,@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)", list[5].CommandText);
            
            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE PROJECT_MARKED_DELETION = 0", list[0].CommandText);
            Assert.AreEqual("Select MAX(PRD_ID) as PeriodCount From EPG_PERIODS Where CB_ID=2", list[1].CommandText);
            Assert.AreEqual("SELECT cc.BC_UID,BC_ID,BC_LEVEL,BC_UOM,ac.BC_UID as Avail_BC_UID FROM EPGP_COST_CATEGORIES cc Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID = cc.BC_UID And ac.CT_ID=1 ORDER BY cc.BC_ID", list[2].CommandText);
            Assert.AreEqual("SELECT BD_VALUE,BD_COST,BD_PERIOD,BC_UID FROM EPGP_DETAIL_VALUES  WHERE PROJECT_ID=1 AND CB_ID=2 AND CT_ID=1", list[3].CommandText);
            Assert.AreEqual("DELETE FROM  EPGP_COST_VALUES WHERE CB_ID=2 AND CT_ID=1", list[4].CommandText);
            Assert.AreEqual("INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY) VALUES(2,1,1,@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)", list[5].CommandText);
            Assert.AreEqual("INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY) VALUES(2,1,1,@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)", list[6].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
            //Assert.AreEqual(_shimAdoNetCalls.DataReadersDisposed.Count, _shimAdoNetCalls.DataReadersCreated.Count);
        }

        [TestMethod]
        public void CalculateCostValues_With_ProjectId_Should_Succeed()
        {
            // Arrange
            ArrangeShims();
            ShimdbaCCV.SetCostTotalsDBAccessInt32Int32IListOfInt32Boolean = (a, b, c, d, e) => StatusEnum.rsSuccess;

            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;

            // Act 
            var actualStatus = dbaCCV.CalculateCostValues(dba, 1, 2, 3, out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);
            Assert.AreEqual("CCV Complete", sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("Select MAX(PRD_ID) as PeriodCount From EPG_PERIODS Where CB_ID=2", list[0].CommandText);
            Assert.AreEqual("SELECT cc.BC_UID,BC_ID,BC_LEVEL,BC_UOM,ac.BC_UID as Avail_BC_UID FROM EPGP_COST_CATEGORIES cc Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID = cc.BC_UID And ac.CT_ID=1 ORDER BY cc.BC_ID", list[1].CommandText);
            Assert.AreEqual("SELECT BD_VALUE,BD_COST,BD_PERIOD,BC_UID FROM EPGP_DETAIL_VALUES  WHERE PROJECT_ID=3 AND CB_ID=2 AND CT_ID=1", list[2].CommandText);
            Assert.AreEqual("DELETE FROM  EPGP_COST_VALUES WHERE CB_ID=2 AND CT_ID=1 AND PROJECT_ID=3", list[3].CommandText);
            Assert.AreEqual("INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY) VALUES(2,1,3,@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)", list[4].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("Select MAX(PRD_ID) as PeriodCount From EPG_PERIODS Where CB_ID=2", list[0].CommandText);
            Assert.AreEqual("SELECT cc.BC_UID,BC_ID,BC_LEVEL,BC_UOM,ac.BC_UID as Avail_BC_UID FROM EPGP_COST_CATEGORIES cc Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID = cc.BC_UID And ac.CT_ID=1 ORDER BY cc.BC_ID", list[1].CommandText);
            Assert.AreEqual("SELECT BD_VALUE,BD_COST,BD_PERIOD,BC_UID FROM EPGP_DETAIL_VALUES  WHERE PROJECT_ID=3 AND CB_ID=2 AND CT_ID=1", list[2].CommandText);
            Assert.AreEqual("DELETE FROM  EPGP_COST_VALUES WHERE CB_ID=2 AND CT_ID=1 AND PROJECT_ID=3", list[3].CommandText);
            Assert.AreEqual("INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY) VALUES(2,1,3,@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)", list[4].CommandText);
            Assert.AreEqual("INSERT INTO EPGP_COST_VALUES (CB_ID,CT_ID,PROJECT_ID,BC_UID, BD_PERIOD,BD_VALUE,BD_COST,BD_IS_SUMMARY) VALUES(2,1,3,@BC_UID,@BD_PERIOD,@BD_VALUE,@BD_COST,@BD_IS_SUMMARY)", list[5].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
            //Assert.AreEqual(_shimAdoNetCalls.DataReadersDisposed.Count, _shimAdoNetCalls.DataReadersCreated.Count);
        }

        [TestMethod]
        public void SetCostTotals_With_AllProjects_And_With_EditMode_Should_Succeed()
        {
            // Arrange
            ArrangeShims();
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var listPIs = new List<int> { 11, 22 };

            // Act 
            var actualStatus = _privateObject.Invoke("SetCostTotals", BindingFlags.Static | BindingFlags.NonPublic, dba, 1, 1, listPIs, true);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=1", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=1", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=1 AND CT_ID =1 AND BC_UID=0) AND (table.PROJECT_ID=PROJECT_ID))", list[4].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=1", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=1", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=1 AND CT_ID =1 AND BC_UID=0) AND (table.PROJECT_ID=PROJECT_ID))", list[4].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
            //Assert.AreEqual(_shimAdoNetCalls.DataReadersDisposed.Count, _shimAdoNetCalls.DataReadersCreated.Count);
        }

        [TestMethod]
        public void SetCostTotals_With_AllProjects_And_Without_EditMode_Should_Succeed()
        {
            // Arrange
            ArrangeShims();
            var index = 5;
            ShimSqlDb.ReadIntValueObject = o => index--;
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var listPIs = new List<int> { 11, 22 };

            // Act 
            var actualStatus = _privateObject.Invoke("SetCostTotals", BindingFlags.Static | BindingFlags.NonPublic, dba, 5, 4, listPIs, true);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=3", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=5", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=4 AND CT_ID =5 AND BD_IS_SUMMARY=0) AND (table.PROJECT_ID=PROJECT_ID))", list[4].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=3", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=5", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=4 AND CT_ID =5 AND BD_IS_SUMMARY=0) AND (table.PROJECT_ID=PROJECT_ID))", list[4].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
            //Assert.AreEqual(_shimAdoNetCalls.DataReadersDisposed.Count, _shimAdoNetCalls.DataReadersCreated.Count);
        }

        [TestMethod]
        public void SetCostTotals_Without_AllProjects_And_With_EditMode_Should_Succeed()
        {
            // Arrange
            ArrangeShims();
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var listPIs = new List<int> { 11, 22 };

            // Act 
            var actualStatus = _privateObject.Invoke("SetCostTotals", BindingFlags.Static | BindingFlags.NonPublic, dba, 1, 1, listPIs, false);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=1", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=1", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=11", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=1 AND CT_ID =1 AND BC_UID=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=11", list[4].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=22", list[5].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=1 AND CT_ID =1 AND BC_UID=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=22", list[6].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=1", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=1", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=11", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=1 AND CT_ID =1 AND BC_UID=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=11", list[4].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=22", list[5].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=1 AND CT_ID =1 AND BC_UID=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=22", list[6].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
            //Assert.AreEqual(_shimAdoNetCalls.DataReadersDisposed.Count, _shimAdoNetCalls.DataReadersCreated.Count);
        }

        [TestMethod]
        public void SetCostTotals_Without_AllProjects_And_Without_EditMode_Should_Succeed()
        {
            // Arrange
            ArrangeShims();
            var index = 5;
            ShimSqlDb.ReadIntValueObject = o => index--;
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            var listPIs = new List<int> { 11, 22 };

            // Act 
            var actualStatus = _privateObject.Invoke("SetCostTotals", BindingFlags.Static | BindingFlags.NonPublic, dba, 5, 4, listPIs, false);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actualStatus);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=3", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=5", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=11", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=4 AND CT_ID =5 AND BD_IS_SUMMARY=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=11", list[4].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=22", list[5].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=4 AND CT_ID =5 AND BD_IS_SUMMARY=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=22", list[6].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual("EPG_SP_ReadCostTotals", list[0].CommandText);
            Assert.AreEqual("SELECT * FROM EPGC_FIELD_ATTRIBS Where FA_FIELD_ID=3", list[1].CommandText);
            Assert.AreEqual("SELECT CT_EDIT_MODE From EPGP_COST_TYPES Where CT_ID=5", list[2].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=11", list[3].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=4 AND CT_ID =5 AND BD_IS_SUMMARY=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=11", list[4].CommandText);
            Assert.AreEqual("Update table SET field=0 Where PROJECT_ID=22", list[5].CommandText);
            Assert.AreEqual("Update table SET field=(SELECT  SUM(BD_COST) AS Expr1 FROM  EPGP_COST_VALUES WHERE  (CB_ID=4 AND CT_ID =5 AND BD_IS_SUMMARY=0) AND (table.PROJECT_ID=PROJECT_ID)) Where PROJECT_ID=22", list[6].CommandText);

            Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
            //Assert.AreEqual(_shimAdoNetCalls.DataReadersDisposed.Count, _shimAdoNetCalls.DataReadersCreated.Count);
        }

        private void ArrangeShims()
        {
            ShimEPKClass01.GetTableAndFieldInt32Int32StringOutStringOut = (int a, int b, out string c, out string d) =>
            {
                c = "table";
                d = "field";
                return true;
            };

            ShimSqlDataReader.AllInstances.Read = reader =>
            {
                if (_readFirstCall)
                {
                    _readFirstCall = false;
                    return true;
                }
                return false;
            };
            ShimSqlDataReader.AllInstances.Close = reader => { _readFirstCall = true; };
            ShimDbDataReader.AllInstances.Dispose = reader => { _readFirstCall = true; };

            ShimSqlDb.ReadIntValueObject = o => 1;
            ShimSqlDb.ReadStringValueObject = o => "string";
            ShimSqlDb.ReadDoubleValueObject = o => 1.0;
        }
    }
}
