using System;
using System.Data.SqlClient.Fakes;
using System.Xml;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class ClientPriorizationTests
    {
        private IDisposable shimsContext;
        private const string PerformCustomFieldsCalculateMethodName = "PerformCustomFieldsCalculate";
        private ClientPrioritization clientPrioritization;
        private PrivateObject privateObject;
        private const string ClIdField = "CL_UID";
        private const string ClSeqField = "CL_SEQ";
        private const string ClOpField = "CL_OP";
        private const string ExprField = "Expr1";
        private const string ServerUrlField = "ADM_WE_SERVERURL";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            clientPrioritization = new ClientPrioritization();
            privateObject = new PrivateObject(clientPrioritization);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void PerformCustomFieldsCalculate_LoadXMLError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedMessage = "Invalid XML response from WorkEngine WebService";
            const StatusEnum ExpectedStatusEnum = (StatusEnum)99843;
            var errorMessage = string.Empty;
            var statusEnumError = StatusEnum.rsSuccess;
            var dba = new ShimDBAccess().Instance;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (++count <= 5)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                        return false;
                    }
                },
                ItemGetString = name =>
                {
                    switch (name)
                    {
                        case ClIdField:
                        case ClSeqField:
                        case ClOpField:
                        case ExprField:
                            return count;
                        case ServerUrlField:
                            return "DummyUrl";
                        default:
                            return DBNull.Value;
                    }
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = ExportPIInfo;
            ShimIntegration.AllInstances.executeStringString =
                (_, command, request) =>
                {
                    return new XmlDocument();
                };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean = 
                (_, status, channel, keyword, function, text, details, immediate) => { };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean = 
                (_, severity, function, status, text, skipDb) => 
                {
                    errorMessage = text;
                    statusEnumError = status;
                    return StatusEnum.rsRequestCannotBeCompleted;
                };
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => false;

            // Act
            privateObject.Invoke(PerformCustomFieldsCalculateMethodName, dba);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldNotBeNullOrEmpty(),
                () => errorMessage.ShouldBe(ExpectedMessage),
                () => statusEnumError.ShouldBe(ExpectedStatusEnum));
        }

        [TestMethod]
        public void PerformCustomFieldsCalculate_StructError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedMessage = "Invalid XML response from WorkEngine WebService\n\nStatus=DummyError";
            const StatusEnum ExpectedStatusEnum = (StatusEnum)99842;
            var errorMessage = string.Empty;
            var statusEnumError = StatusEnum.rsSuccess;
            var dba = new ShimDBAccess().Instance;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (++count <= 5)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                        return false;
                    }
                },
                ItemGetString = name =>
                {
                    switch (name)
                    {
                        case ClIdField:
                        case ClSeqField:
                        case ClOpField:
                        case ExprField:
                            return count;
                        case ServerUrlField:
                            return "DummyUrl";
                        default:
                            return DBNull.Value;
                    }
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = ExportPIInfo;
            ShimIntegration.AllInstances.executeStringString =
                (_, command, request) =>
                {
                    return new XmlDocument();
                };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean =
                (_, status, channel, keyword, function, text, details, immediate) => { };
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.GetIntAttrString = (_, attrName) => 1;
            ShimCStruct.AllInstances.GetStringAttrString = (_, attrName) => "DummyError";
            ShimCStruct.AllInstances.GetSubStructString = (_, attrName) => new CStruct();
            ShimCStruct.AllInstances.GetStringString = (_, attrName) => string.Empty;
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, function, status, text, skipDb) =>
                {
                    errorMessage = text;
                    statusEnumError = status;
                    return StatusEnum.rsRequestCannotBeCompleted;
                };

            // Act
            privateObject.Invoke(PerformCustomFieldsCalculateMethodName, dba);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldNotBeNullOrEmpty(),
                () => errorMessage.ShouldContain(ExpectedMessage),
                () => statusEnumError.ShouldBe(ExpectedStatusEnum));
        }

        [TestMethod]
        public void PerformCustomFieldsCalculate_StructItemError_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedMessage = "Invalid XML response from WorkEngine WebService\n\nStatus=DummyError";
            const StatusEnum ExpectedStatusEnum = (StatusEnum)99999;
            var errorMessage = string.Empty;
            var statusEnumError = StatusEnum.rsSuccess;
            var dba = new ShimDBAccess().Instance;
            var count = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (++count <= 5)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                        return false;
                    }
                },
                ItemGetString = name =>
                {
                    switch (name)
                    {
                        case ClIdField:
                        case ClSeqField:
                        case ClOpField:
                        case ExprField:
                            return count;
                        case ServerUrlField:
                            return "DummyUrl";
                        default:
                            return DBNull.Value;
                    }
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimdbaUsers.ExportPIInfoDBAccessStringStringOut = ExportPIInfo;
            ShimIntegration.AllInstances.executeStringString =
                (_, command, request) =>
                {
                    return new XmlDocument();
                };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean =
                (_, status, channel, keyword, function, text, details, immediate) => { };
            ShimCStruct.AllInstances.LoadXMLString = (_, content) => true;
            ShimCStruct.AllInstances.GetIntAttrString = (_, attrName) => 1;
            ShimCStruct.AllInstances.GetStringAttrString = (_, attrName) => "DummyError";
            ShimCStruct.AllInstances.GetSubStructString = (_, attrName) =>
            {
                return attrName == "Item"
                    ? new CStruct()
                    : null;
            };
            ShimCStruct.AllInstances.GetStringString = (_, attrName) => string.Empty;
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, function, status, text, skipDb) =>
                {
                    errorMessage = text;
                    statusEnumError = status;
                    return StatusEnum.rsRequestCannotBeCompleted;
                };

            // Act
            privateObject.Invoke(PerformCustomFieldsCalculateMethodName, dba);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => errorMessage.ShouldNotBeNullOrEmpty(),
                () => errorMessage.ShouldContain(ExpectedMessage),
                () => statusEnumError.ShouldBe(ExpectedStatusEnum));
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum ExportPIInfo(DBAccess sqlDb, string command, out string result)
        {
            result = string.Empty;
            return StatusEnum.rsSuccess;
        }
    }
}
