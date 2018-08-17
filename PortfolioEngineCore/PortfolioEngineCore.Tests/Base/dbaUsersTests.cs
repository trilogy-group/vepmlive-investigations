﻿using System;
﻿using System.Collections.Generic;
﻿using System.ComponentModel.Design;
﻿using System.Data;
﻿using System.Data.Common.Fakes;
﻿using System.Data.Fakes;
﻿using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
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
        private int[] intValues = { -1, 0, 1, 2, 3, 4, 5, 6};


        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _shimAdoNetCalls = AdoShims.ShimAdoNetCalls();

            _privateObject = new PrivateObject(typeof(dbaUsers));
            _readFirstCall = true;

            ArrangeShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void ExecuteSQLSelect_Should_Return_Reader()
        {
            // Arrange
            var command = new ShimSqlCommand();
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand => new ShimSqlDataReader();
            SqlDataReader reader;

            // Act
            var actual = dbaUsers.ExecuteSQLSelect(command, out reader);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.IsNotNull(reader);
        }

        [TestMethod]
        public void ExecuteSQLSelect_WhenFailed_Should_Return_Error()
        {
            // Arrange
            var command = new ShimSqlCommand();
            ShimSqlCommand.AllInstances.ExecuteReader = sqlCommand => { throw new Exception(); };
            SqlDataReader reader;

            // Act
            var actual = dbaUsers.ExecuteSQLSelect(command, out reader);

            // Assert
            Assert.AreEqual((StatusEnum)dbaUsers.ErrorCode, actual);
            Assert.IsNull(reader);
        }

        [TestMethod]
        public void ExportPIInfo_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_Program_Groups_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"11\"><Field ID=\"Team\" Value=\"12\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9960;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("Select pg.PROG_UID,PROJECT_ID,LV_FULLVALUE as GROUP_NAME From EPGP_PI_PROGS pg Join EPGP_LOOKUP_VALUES lv on lv.LV_UID=pg.PROG_UID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on PROJECT_ID=LT.TokenVal Order By PROJECT_ID,pg.FIELD_ID", list[4].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[5].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[6].CommandText);
            
            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(7, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("Select pg.PROG_UID,PROJECT_ID,LV_FULLVALUE as GROUP_NAME From EPGP_PI_PROGS pg Join EPGP_LOOKUP_VALUES lv on lv.LV_UID=pg.PROG_UID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on PROJECT_ID=LT.TokenVal Order By PROJECT_ID,pg.FIELD_ID", list[4].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[5].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[6].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_NeedResources_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[5] = 7;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("Select WRES_ID,RES_NAME From EPG_RESOURCES", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("Select WRES_ID,RES_NAME From EPG_RESOURCES", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_Linked_Scedule_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9224;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,ps.WPROJ_ID FROM EPGP_PROJECTS pi   Left Join EPGX_PROJECT_VERSIONS ps On ps.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,ps.WPROJ_ID FROM EPGP_PROJECTS pi   Left Join EPGX_PROJECT_VERSIONS ps On ps.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_Stage_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9911\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9911;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,sg.STAGE_NAME FROM EPGP_PROJECTS pi   Left Join EPGP_STAGES sg On sg.STAGE_ID=pi.PROJECT_STAGE_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,sg.STAGE_NAME FROM EPGP_PROJECTS pi   Left Join EPGP_STAGES sg On sg.STAGE_ID=pi.PROJECT_STAGE_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_Stage_Owner_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9922\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9922;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r1.RES_NAME as StageOwner FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r1 On r1.WRES_ID=pi.PROJECT_OWNER JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r1.RES_NAME as StageOwner FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r1 On r1.WRES_ID=pi.PROJECT_OWNER JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_Item_Manager_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9925\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9925;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r2.RES_NAME as ItemManager FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r2 On r2.WRES_ID=pi.PROJECT_MANAGER JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r2.RES_NAME as ItemManager FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r2 On r2.WRES_ID=pi.PROJECT_MANAGER JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_Schedule_Manager_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9930\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9930;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r3.RES_NAME as ScheduleManager FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r3 On r3.WRES_ID=pi.PROJECT_PLAN_OWNER JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r3.RES_NAME as ScheduleManager FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r3 On r3.WRES_ID=pi.PROJECT_PLAN_OWNER JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_CreatedBy_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9920\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9920;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r4.RES_NAME as CreatedBy FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r4 On r4.WRES_ID=pi.PROJECT_CREATEDBY JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,r4.RES_NAME as CreatedBy FROM EPGP_PROJECTS pi   Left Join EPG_RESOURCES r4 On r4.WRES_ID=pi.PROJECT_CREATEDBY JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_PROJECT_NAME_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9900\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9900;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_PROJECT_START_DATE_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9901\" Value=\"2018-01-02T03:04:05\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9901;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_PROJECT_FINISH_DATE_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9902\" Value=\"2018-01-02T03:04:05\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9902;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_PROJECT_CREATED_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9921\" Value=\"2018-01-02T03:04:05\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9921;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_PROJECT_PRIORITY_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9928\" Value=\"12\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9928;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_WORKITEM_START_DATE_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9936\" Value=\"2018-01-02T03:04:05\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9936;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_ProjectId_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"9903\" Value=\"10\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 9903;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_WPROJ_ID_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[0] = 99246;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE FROM EPGP_PROJECTS pi   JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_XmlType_String_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[6] = 201;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x1 ON x1.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x1 ON x1.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_XmlType_String2_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"3\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[6] = 202;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x2 ON x2.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x2 ON x2.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_XmlType_Double_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"3\" Value=\"11\" /></PortfolioItem></PortfolioItems>";
            intValues[6] = 203;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x3 ON x3.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x3 ON x3.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void ExportPIInfo_With_XmlType_Date_Should_Return_Success()
        {
            // Arrange
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            string sResult;
            const string expectedResult = "<PortfolioItems Key=\"EPK\"><PortfolioItem ItemID=\"10\"><Field ID=\"Team\" Value=\"11\" /><Field ID=\"3\" Value=\"2018-01-02T03:04:05\" /></PortfolioItem></PortfolioItems>";
            intValues[6] = 205;
            // Act
            var actual = dbaUsers.ExportPIInfo(dba, "1, 2", out sResult);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.AreEqual(expectedResult, sResult);

            var list = _shimAdoNetCalls.CommandsCreated;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x5 ON x5.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS Where FIELD_ID In(9900,9903) ORDER BY FIELD_ID", list[0].CommandText);
            Assert.AreEqual("SELECT FIELD_ID,FIELD_NAME,FIELD_NAME_SQL,FIELD_TABLE_ID,FIELD_FORMAT FROM EPGT_FIELDS f Where FIELD_EXPORT=1 ORDER BY FIELD_ID", list[1].CommandText);
            Assert.AreEqual("Select * From EPGC_FIELD_ATTRIBS f Where FA_TABLE_ID > 200 and FA_TABLE_ID < 260 ORDER BY FA_FIELD_ID", list[2].CommandText);
            Assert.AreEqual("PPM_SP_ReadLookupValuesByLookup", list[3].CommandText);
            Assert.AreEqual("SELECT pi.PROJECT_ID,PROJECT_NAME,PROJECT_START_DATE,PROJECT_FINISH_DATE,PROJECT_EXT_UID,PROJECT_CREATED,PROJECT_PRIORITY,WORKITEM_START_DATE,field FROM EPGP_PROJECTS pi   LEFT JOIN table x5 ON x5.PROJECT_ID=pi.PROJECT_ID JOIN dbo.EPG_FN_ConvertListToTable(N'1, 2') LT on pi.PROJECT_ID=LT.TokenVal Where PROJECT_MARKED_DELETION=0 Order By PROJECT_ID", list[4].CommandText);
            Assert.AreEqual("Select t.* From EPGP_TEAMS t Join EPG_RESOURCES r On r.WRES_ID = t.WRES_ID Where PROJECT_ID=@PROJECT_ID ", list[5].CommandText);

            //Assert.AreEqual(_shimAdoNetCalls.CommandsDisposed.Count, _shimAdoNetCalls.CommandsCreated.Count);
        }

        [TestMethod]
        public void SelectAvailCCs_Should_Return_Success()
        {
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            DataTable dataTable;

            // Act
            var actual = dbaUsers.SelectAvailCCs(dba, 1, out dataTable);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.IsNotNull(dataTable);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT cc.*,ac.BC_UID as BC_UID_incl From EPGP_COST_CATEGORIES cc Left Join EPGP_AVAIL_CATEGORIES ac On ac.BC_UID=cc.BC_UID and ac.CT_ID=@p1 Order by BC_ID", list[0].CommandText);
        }

        [TestMethod]
        public void SelectCTCalcs_Should_Return_Success()
        {
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            DataTable dataTable;

            // Act
            var actual = dbaUsers.SelectCTCalcs(dba, 1, out dataTable);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.IsNotNull(dataTable);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT * From EPGP_COST_CALC Where CT_ID=@p1 Order by CL_ID", list[0].CommandText);
        }

        [TestMethod]
        public void SelectGroupPermissions_Should_Return_Success()
        {
            var dba = new ShimDBAccess(new StubDBAccess(string.Empty)).Instance;
            DataTable dataTable;

            // Act
            var actual = dbaUsers.SelectGroupPermissions(dba, 1, out dataTable);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, actual);
            Assert.IsNotNull(dataTable);

            var list = _shimAdoNetCalls.CommandsExecuted;
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("SELECT distinct (p.PERM_UID), p.PERM_ID, p.PERM_LEVEL, p.PERM_NAME, CAST(p.PERM_NOTES AS NVARCHAR(MAX)), p.PERM_WEINCLUDE, gp.GROUP_ID From EPG_PERMISSIONS p Left Join EPG_GROUP_PERMISSIONS gp On gp.PERM_UID=p.PERM_UID and gp.GROUP_ID=@p1 Where p.PERM_WEINCLUDE=1 Order by PERM_ID", list[0].CommandText);
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

            var index = -1;
            ShimSqlDataReader.AllInstances.Close = reader => 
            {
                _readFirstCall = true;
            };
            ShimDbDataReader.AllInstances.Dispose = reader => 
            {
                _readFirstCall = true;
            };
            var date = new DateTime(2018, 1, 2, 3, 4, 5);

            ShimSqlDb.ReadIntValueObject = o => ++index < intValues.Length ? intValues[index] : index;
            ShimSqlDb.ReadStringValueObject = o => index < intValues.Length ? $"{intValues[index]}" : $"{index}";
            ShimSqlDb.ReadDoubleValueObject = o => index < intValues.Length ? intValues[index] : index;
            ShimSqlDb.ReadDateValueObject = o => date;

            ShimDataTable.AllInstances.RowsGet = table => new ShimDataRowCollection();

            ShimDataRowCollection.AllInstances.GetEnumerator = collection =>
            {
                var list = new List<DataRow> {new ShimDataRow()};

                return list.GetEnumerator();
            };
        }
    }
}