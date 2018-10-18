using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class DBCommonTests
    {
        private IDisposable shimsContext;
        private DBAccess dbAccess;
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            dbAccess = new ShimDBAccess();

            ShimSqlDb.AllInstances.HandleExceptionStringStatusEnumExceptionBoolean = 
                (_, function, status, exception, log) => StatusEnum.rsRequestCannotBeCompleted;
            

        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void ReadUserInfo_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            const string InfData = "UINF_DATA";
            var data = 0;
            var xml = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name =>
                {
                    return name == InfData ? 1.ToString() : DummyString;
                }
            };

            // Act
            var result = DBCommon.ReadUserInfo(dbAccess, 1, UserInfoContextsEnum.siEVEditorPISettings, out data, out xml);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => data.ShouldBe(1),
                () => xml.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ReadSystemInfo_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var xml = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                ItemGetString = name => DummyString
            };

            // Act
            var result = DBCommon.ReadSystemInfo(dbAccess, 1, UserInfoContextsEnum.siEVEditorPISettings, out xml);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => xml.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetUserButtonsStruct_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            const string BtnPage = "BTN_PAGE";
            var userButtons = new CStruct();
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                HasRowsGet = () => true,
                Read = () => ++count <= 1,
                ItemGetString = name =>
                {
                    return name == BtnPage ? 1.ToString() : DummyString;
                }
            };
            // Act
            var result = DBCommon.GetUserButtonsStruct(dbAccess, DummyString, out userButtons);
            var subStruct = userButtons.GetSubStruct("USRBUT");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => subStruct.ShouldNotBeNull(),
                () => subStruct.GetIntAttr("PageID").ShouldNotBeNull(),
                () => subStruct.GetIntAttr("PageID").ShouldBe(1),
                () => subStruct.GetString("Key").ShouldNotBeNullOrEmpty(),
                () => subStruct.GetString("Key").ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetUserButtonsStruct_OnException_ReturnsStatusError()
        {
            // Arrange
            var userButtons = new CStruct();
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                HasRowsGet = () => true,
                Read = () => ++count <= 1,
                ItemGetString = name =>
                {
                    throw new Exception();
                }
            };
            // Act
            var result = DBCommon.GetUserButtonsStruct(dbAccess, DummyString, out userButtons);
            var subStruct = userButtons.GetSubStruct("USRBUT");

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted));
        }

        [TestMethod]
        public void ReadPlanViewFields_OnSuccess_ShouldExecuteCorrectly()
        {
            // Arrange
            var fields = new List<CTSFieldDefinition>();
            fields = null;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                HasRowsGet = () => true,
                Read = () => ++count <= 1,
            };
            ShimDBCommon.CopyRSToRPFieldDefinitionDBAccessSqlDataReaderCTSFieldDefinitionOut = CopyRSToRPFieldDefinitionSuccess;

            // Act
            var result = DBCommon.ReadPlanViewFields(dbAccess, 1, out fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsSuccess),
                () => fields.ShouldNotBeNull());
        }

        [TestMethod]
        public void ReadPlanViewFields_OnException_ReturnsRequestCannotBeCompleted()
        {
            // Arrange
            var fields = new List<CTSFieldDefinition>();
            fields = null;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => 
            {
                throw new Exception();
            };
            ShimDBCommon.CopyRSToRPFieldDefinitionDBAccessSqlDataReaderCTSFieldDefinitionOut = CopyRSToRPFieldDefinitionSuccess;

            // Act
            var result = DBCommon.ReadPlanViewFields(dbAccess, 1, out fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBe(StatusEnum.rsRequestCannotBeCompleted),
                () => fields.ShouldBeNull());
        }

        private StatusEnum CopyRSToRPFieldDefinitionSuccess(DBAccess db, SqlDataReader reader, out CTSFieldDefinition fields)
        {
            fields = new CTSFieldDefinition();
            return StatusEnum.rsSuccess;
        }
    }
}
