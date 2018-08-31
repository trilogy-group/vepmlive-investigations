using System;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;
using Moq;

namespace PortfolioEngineCore.Tests.Admininfos
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AdminFunctionsTests
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private AdminFunctions _adminFunctions;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const int DummyCalenderInt = -1;
        private const int DummyInt = 1;
        private const short DummyShort = 1;
        private const double DummyDouble = 1;
        private const string ReportingConnection = "ReportingConnection";
        private const string PEConnection = "PEConnection";
        private const string WEServerURL = "WEServerURL";
        private const string FieldMapping = "FieldMapping";

        private const string HandleRequest = "HandleRequest";
        private const string AddHeartBeat = "AddHeartBeat";
        private const string ManageTimedJobs = "ManageTimedJobs";
        private const string CalcCategoryRates = "CalcCategoryRates";
        private const string CalcAvailabilities = "CalcAvailabilities";
        private const string CalcRPAllAvailabilities = "CalcRPAllAvailabilities";
        private const string CalcInternalAvailabilities = "CalcInternalAvailabilities";
        private const string SaveReportingConnection = "SaveReportingConnection";
        private const string CalcAllDefaultFTEs = "CalcAllDefaultFTEs";
        private const string CalcDefaultFTEs = "CalcDefaultFTEs";
        private const string SavePEConnection = "SavePEConnection";
        private const string ImportReportingConnection = "ImportReportingConnection";
        private const string ImportPEConnection = "ImportPEConnection";
        private const string SubmitReportExtract = "SubmitReportExtract";
        private const string SubmitTimerJob = "SubmitTimerJob";
        private const string SubmitJobRequest = "SubmitJobRequest";
        private const string QueueJobRequest = "QueueJobRequest";
        private const string SaveWorkEngineURL = "SaveWorkEngineURL";
        private const string ImportWE_URL = "ImportWE_URL";
        private const string SaveWorkEngineFieldMappings = "SaveWorkEngineFieldMappings";
        private const string ImportWEFieldMappings = "ImportWE_FieldMappings";
        private const string GetTimerJobs = "GetTimerJobs";
        private const string GetTimerJobDetails = "GetTimerJobDetails";
        private const string SetTimerJobDetails = "SetTimerJobDetails";
        private const string DeleteTimerJob = "DeleteTimerJob";
        private const string CalcResourceRate = "CalcResourceRate";
        private const string BuildResultStruct = "BuildResultStruct";
        private const string HandleError = "HandleError";
        private const string HandleException = "HandleException";

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();
            SetupFakes();
            
            _adminFunctions = new AdminFunctions(DummyString, DummyString, DummyString, DummyString, DummyString, SecurityLevels.BaseAdmin, true);
            _privateObject = new PrivateObject(_adminFunctions);
            _privateType = new PrivateType(typeof(AdminFunctions));
            InitializeSetUp();
            _privateObject.SetFieldOrProperty("_dba", new DBAccess(DummyString));
            _privateObject.SetFieldOrProperty("debug", new Debugger(true));
        }

        private void InitializeSetUp()
        {
            ShimSqlDb.AllInstances.ConnectionGet = _ => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Closed;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, _1, _2) => new ShimSqlCommand();
            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection()
            {
                AddStringSqlDbType = (_1, _2) => new SqlParameter()
                {
                    Value = new object()
                },
                AddStringSqlDbTypeInt32 = (_1, _2, _3) => new SqlParameter()
                {
                    Value = new object()
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object obj, out bool isNull) =>
            {
                isNull = true;
                return DummyInt;
            };
            ShimSqlDb.ReadDateValueObjectBooleanOut = (object obj, out bool isNull) =>
            {
                isNull = true;
                return new DateTime();
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject.Dispose();
        }

        [TestMethod]
        public void AddHeartBeat_DBAccessIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance };

            // Act
            var actualResult = _privateType.InvokeStatic(
                AddHeartBeat,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ManageTimedJobs_DBAccessAndBasePathIsNotNull_ReturnJobTime()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyString };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, _1) => new object();
            var count = 0;
            ShimSqlDb.ReadStringValueObjectBooleanOut = (object obj, out bool isNull) =>
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = _ => false;
                }
                isNull = true;
                return DummyString;
            };
            ShimAdminFunctions.QueueJobRequestDBAccessInt32Int32StringStringStringString = (_, _1, _2, _3, _4, _5, _6) => true;

            // Act
            var actualResult = _privateType.InvokeStatic(
                ManageTimedJobs,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(0));
        }

        [TestMethod]
        public void CalcCategoryRates_DBAccessAndBasePathIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyString };
            var count = 0;
            ShimSqlDb.ReadIntValueObject = _ => 
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = _1 => false;
                }
                return DummyInt;
            };
            ShimSqlDb.ReadDateValueObject = _ => new DateTime();
            ShimSqlDb.ReadDoubleValueObject = _ => DummyDouble;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcCategoryRates,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void CalcAvailabilities_CalenderAndResListIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyInt, DummyString };
            ShimAdminFunctions.CalcInternalAvailabilitiesDBAccessInt32String = (_, _1, _2) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                CalcAvailabilities,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void CalcAvailabilities_CalenderAndResListIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyInt, string.Empty };
            ShimAdminFunctions.CalcInternalAvailabilitiesDBAccessInt32String = (_, _1, _2) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                CalcAvailabilities,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void CalcRPAllAvailabilities_DBAccessIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance };
            ShimAdminFunctions.CalcInternalAvailabilitiesDBAccessInt32String = (_, _1, _2) => true;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcRPAllAvailabilities,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void CalcInternalAvailabilities_DBAccessCalenderAndResListIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyCalenderInt, DummyString };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => { };
            var count = 0;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDateValueObject = _ =>
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = _1 => false;
                };
                return new DateTime();
            };

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcInternalAvailabilities,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveReportingConnection_CStructIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimCStruct().Instance };
            ShimCStruct.AllInstances.GetStringAttrString = (_,_1) => DummyString;
            ShimAdminFunctions.AllInstances.ImportReportingConnectionString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveReportingConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void CalcAllDefaultFTEs_DBAccessIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance };
            ShimAdminFunctions.CalcDefaultFTEsDBAccessInt32String = (_, _1, _2) => true;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcAllDefaultFTEs,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void CalcDefaultFTEs_DBAccessCalenderAndResListIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyCalenderInt, DummyString };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => { };
            var count = 0;
            ShimSqlDb.ReadIntValueObject = _ =>
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = _1 => false;
                };
                return DummyInt;
            };

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcDefaultFTEs,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveReportingConnection_DataStringIsNotNullAndIsFalse_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveReportingConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveReportingConnection_DataStringIsNotNullAndNameIsNotMatched_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveReportingConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveReportingConnection_DataStringIsNotNullAndisTrue_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => ReportingConnection;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => DummyString;
            ShimAdminFunctions.AllInstances.ImportReportingConnectionString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveReportingConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void SavePEConnection_DataStringIsNotNullAndIsFalse_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                SavePEConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SavePEConnection_DataStringIsNotNullAndNameIsNotMatched_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                SavePEConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SavePEConnection_DataStringIsNotNullAndisTrue_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => PEConnection;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => DummyString;
            ShimAdminFunctions.AllInstances.ImportReportingConnectionString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                SavePEConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void ImportReportingConnection_ConnectionStringIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                ImportReportingConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void ImportPEConnection_ConnectionStringIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                ImportPEConnection,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void SubmitReportExtract_DataStringIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.GetIntAttrString = (_, _1) => DummyInt;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _2) => new DateTime().ToString();
            ShimAdminFunctions.AllInstances.SubmitTimerJobInt32StringInt32DateTime = (_, _1, _2, _3, _4) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                SubmitReportExtract,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void SubmitReportExtract_DataStringIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;
            
            // Act
            var actualResult = _privateObject.Invoke(
                SubmitReportExtract,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SubmitTimerJob_JobCodeAndJobDescIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyInt, DummyString, DummyInt, new DateTime() };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.InitializeString = (_, _1) => { };
            ShimCStruct.AllInstances.CreateSubStructString = (_, _1) => new ShimCStruct();
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, _1, _2) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            
            // Act
            var actualResult = _privateObject.Invoke(
                SubmitTimerJob,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void SubmitJobRequest_DBAccessAndBasePathIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyInt, DummyString, DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsRequestInvalidParameter;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SubmitJobRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SubmitJobRequest_DBAccessAndBasePathIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyInt, DummyString, DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.GetIntStringInt32 = (_, _1, _2) => DummyInt;
            ShimCStruct.AllInstances.GetStringStringString = (_, _1, _2) => DummyString;
            ShimAdminFunctions.SubmitJobRequestDBAccessInt32Int32StringStringStringString =
                (_, _1, _2, _3, _4, _5, _6) => true;

            // Act
            var actualResult = _privateType.InvokeStatic(
                SubmitJobRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void SubmitJobRequest_DBAccessAndBasePathIsNotNullAndSessionIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] 
            {
                new ShimDBAccess().Instance,
                DummyInt,
                DummyInt,
                DummyString,
                DummyString,
                DummyString,
                DummyString
            };
            ShimPfeJob.Constructor = _ => new ShimPfeJob();
            ShimPfeJob.AllInstances.QueueIDbRepositoryIMessageQueueString = (_, _1, _2, _3) => DummyInt;
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                SubmitJobRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void QueueJobRequest_DBAccessAndBasePathIsNotNullAndSessionIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] 
            {
                new ShimDBAccess().Instance,
                DummyInt,
                DummyInt,
                DummyString,
                DummyString,
                DummyString,
                DummyString
            };
            ShimPfeJob.Constructor = _ => new ShimPfeJob();
            ShimDbRepository.ConstructorDBAccess = (_, _1) => new ShimDbRepository();
            ShimDbRepository.AllInstances.QueuePfeJobPfeJob = (_, _1) => DummyInt;

            // Act
            var actualResult = _privateType.InvokeStatic(
                QueueJobRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void SaveWorkEngineURL_DataStringIsNotNullAndIsFalse_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveWorkEngineURL,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveWorkEngineURL_DataStringIsNotNullAndNameIsNotMatched_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveWorkEngineURL,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveWorkEngineURL_DataStringIsNotNullAndisTrue_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => WEServerURL;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => DummyString;
            ShimAdminFunctions.AllInstances.ImportWE_URLString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveWorkEngineURL,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void ImportWE_URL_URLStringIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                ImportWE_URL,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void SaveWorkEngineFieldMappings_DataStringIsNotNullAndIsFalse_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveWorkEngineFieldMappings,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveWorkEngineFieldMappings_DataStringIsNotNullAndNameIsNotMatched_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                SaveWorkEngineFieldMappings,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveWorkEngineFieldMappings_DataStringIsNotNullAndisTrue_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => FieldMapping;
            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
            ShimCStruct.AllInstances.GetListString = (_, _1) => new List<CStruct>() { new ShimCStruct() };
            ShimAdminFunctions.AllInstances.ImportWE_FieldMappingsListOfCStructInt32 = (_, _1, _2) => false;
            ShimSqlDb.AllInstances.RollbackTransaction = _ => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                SaveWorkEngineFieldMappings,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SaveWorkEngineFieldMappings_DataStringIsNotNullAndisTrue_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.NameGet = _ => FieldMapping;
            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
            ShimCStruct.AllInstances.GetListString = (_, _1) => new List<CStruct>();
            ShimSqlDb.AllInstances.CommitTransaction = _ => { };

            // Act
            var actualResult = _privateObject.Invoke(
                SaveWorkEngineFieldMappings,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void ImportWEFieldMappings_ListOfCStructIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new List<CStruct>() { new ShimCStruct() }, DummyInt };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.AllInstances.GetIntAttrString = (_, _1) => DummyInt;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                ImportWEFieldMappings,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void GetTimerJobs_InputIsEmpty_ReturnJobString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.InitializeString = (_, _1) => { };
            ShimCStruct.AllInstances.CreateSubStructString = (_, _1) => new ShimCStruct();
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadDateValueObject = _ => new DateTime();
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, _1, _2) => { };
            var count = 0;
            ShimCStruct.AllInstances.CreateDateAttrStringDateTime = (_, _1, _2) => 
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = x => false;
                }
            };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetTimerJobs,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        private void HandleRequestSetup()
        {
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.GetSubStructString = (_, _1) => new ShimCStruct();
        }

        [TestMethod]
        public void HandleRequest_RequestAndReplyValueIsNotNotAndIsSetDefault_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            HandleRequestSetup();
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void HandleRequest_RequestAndReplyValueIsNotNotAndIsCalcCategoryRates_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            HandleRequestSetup();
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => "CalcCategoryRates";
            ShimAdminFunctions.CalcCategoryRatesDBAccessStringOut = (DBAccess Obj, out string sReply) =>
            {
                sReply = DummyString;
                return true;
            };

            // Act
            var actualResult = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void HandleRequest_RequestAndReplyValueIsNotNotAndIsCalcDefaultFTEs_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            HandleRequestSetup();
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => "CalcDefaultFTEs";
            ShimAdminFunctions.CalcAllDefaultFTEsDBAccess = _ => true;

            // Act
            var actualResult = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void HandleRequest_RequestAndReplyValueIsNotNotAndIsCalcRPAllAvailabilities_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            HandleRequestSetup();
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => "CalcRPAllAvailabilities";
            ShimAdminFunctions.CalcRPAllAvailabilitiesDBAccess = _ => true;

            // Act
            var actualResult = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void HandleRequest_RequestAndReplyValueIsNotNotAndIsSaveReportingConnection_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            HandleRequestSetup();
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => "SaveReportingConnection";
            ShimAdminFunctions.AllInstances.SaveReportingConnectionCStruct = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void HandleRequest_RequestAndReplyValueIsNotNotAndIsSubmitReportExtract_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            HandleRequestSetup();
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => "SubmitReportExtract";
            ShimAdminFunctions.AllInstances.SubmitReportExtractString = (_, _1) => true;

            // Act
            var actualResult = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void HandleRequest_RequestAndReplyValueIsNotNotAndLoadXMlIsFalse_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;
            ShimCStruct.AllInstances.GetSubStructString = (_, _1) => new ShimCStruct();
            ShimAdminFunctions.HandleErrorStringInt32String = (_, _1, _2) => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                HandleRequest,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetTimerJobDetails_JobsUIDIsNoTNull_ReturnUIDString()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.InitializeString = (_, _1) => { };
            ShimCStruct.AllInstances.CreateSubStructString = (_, _1) => new ShimCStruct();
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.ReadDateValueObject = _ => new DateTime();
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, _1, _2) => { };
            var count = 0;
            ShimCStruct.AllInstances.CreateDateAttrStringDateTime = (_, _1, _2) =>
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = x => false;
                }
            };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetTimerJobDetails,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void SetTimerJobDetails_XMLStringIsNoTNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                SetTimerJobDetails,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void SetTimerJobDetails_XMLStringIsNoTNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.LoadXMLString = (_, _1) => true;
            ShimCStruct.AllInstances.GetIntAttrString = (_, _1) => DummyInt;
            ShimCStruct.AllInstances.GetDateAttrString = (_,_1) => new DateTime();
            ShimCStruct.AllInstances.GetStringAttrString = (_, _1) => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;

            // Act
            var actualResult = _privateObject.Invoke(
                SetTimerJobDetails,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void DeleteTimerJob_JonUIDIsNoTNull_ReturnTimerString()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.InitializeString = (_, _1) => { };
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                DeleteTimerJob,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void CalcResourceRate_ResourceIdIsNoTNull_ReturnRateInDecimal()
        {
            // Arrange
            var parameters = new object[] { DummyInt };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            var count = 0;
            ShimSqlDb.ReadDoubleValueObject = _ => 
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = x => false;
                };
                return DummyDouble;
            };
            
            // Act
            var actualResult = _privateObject.Invoke(
                CalcResourceRate,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyDouble));
        }

        [TestMethod]
        public void CalcResourceRate_ResourceIdIsNoTNullAndValIsZero_ReturnZero()
        {
            // Arrange
            var parameters = new object[] { DummyInt };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, strVal) =>
            {
                if (strVal == "BC_UID")
                {
                    return DummyString;
                }
                else
                {
                    return null;
                }
            };
            ShimSqlDb.ReadIntValueObject = strVal =>
            {
                if (strVal == DummyString)
                {
                    return DummyInt;
                }
                else
                {
                    return 0;
                }
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object obj, out bool isNull) => 
            {
                isNull = true;
                return DummyInt;
            };
            var count = 0;
            ShimSqlDb.ReadDoubleValueObject = _ =>
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = x => false;
                };
                return DummyDouble;
            };

            // Act
            var actualResult = _privateObject.Invoke(
                CalcResourceRate,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(0));
        }

        [TestMethod]
        public void CalcResourceRate_ResourceIdIsNoTNullAndValIsZero_ReturnRateInDecimal()
        {
            // Arrange
            var parameters = new object[] { DummyInt };
            ShimSqlDb.AllInstances.Open = _ => StatusEnum.rsBasePathNotSet;
            ShimDebugger.AllInstances.AddMessageString = (_, _1) => { };
            ShimSqlDb.AllInstances.FormatErrorText = _ => DummyString;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, strVal) =>
            {
                if (strVal == "BC_UID")
                {
                    return DummyString;
                }
                else
                {
                    return null;
                }
            };
            ShimSqlDb.ReadIntValueObject = strVal =>
            {
                if (strVal == DummyString)
                {
                    return DummyInt;
                }
                else
                {
                    return 0;
                }
            };
            ShimSqlDb.ReadIntValueObjectBooleanOut = (object obj, out bool isNull) =>
            {
                isNull = false;
                return DummyInt;
            };
            var count = 0;
            ShimSqlDb.ReadDoubleValueObject = _ =>
            {
                count++;
                if (count == 2)
                {
                    ShimSqlDataReader.AllInstances.Read = x => false;
                };
                return DummyDouble;
            };

            // Act
            var actualResult = _privateObject.Invoke(
                CalcResourceRate,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyDouble));
        }

        [TestMethod]
        public void BuildResultStruct_FunctionAndStatusIsNotNull_ReturnCStruct()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyInt };
            ShimCStruct.Constructor = _ => new ShimCStruct();
            ShimCStruct.AllInstances.InitializeString = (_, _1) => { };
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                BuildResultStruct,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull());
        }

        [TestMethod]
        public void HandleError_FunctionAndStatusIsNotNull_ReturnErrorString()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyInt, DummyString };
            ShimAdminFunctions.BuildResultStructStringInt32 = (_, _1) => new ShimCStruct();
            ShimCStruct.AllInstances.CreateSubStructString = (_, _1) => new ShimCStruct();
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateSubStructString = (_, _1) => new ShimCStruct();
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (_, _1, _2) => { };
            ShimCStruct.AllInstances.CreateStringAttrStringString = (_, _1, _2) => { };
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                HandleError,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void HandleException_FunctionAndStatusIsNotNull_ReturnExceptionString()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyInt, new Exception() };
            ShimAdminFunctions.HandleErrorStringInt32String = (_, _1, _2) => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                HandleException,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void CalcInternalAvailabilities_DBAccessCalenderAndResListIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyCalenderInt, string.Empty };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => { };
            var count = 0;
            ShimSqlDb.ReadIntValueObject = _ => DummyInt;
            ShimSqlDb.ReadDateValueObject = _ =>
            {
                count++;
                if (count == 2 || count == 4 || count == 8)
                {
                    ShimSqlDataReader.AllInstances.Read = _1 => false;
                };
                return new DateTime();
            };
            ShimSqlDataReader.AllInstances.Close = _ =>
            {
                ShimSqlDataReader.AllInstances.Read = _1 => true;
            };

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcInternalAvailabilities,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        [TestMethod]
        public void CalcDefaultFTEs_DBAccessCalenderAndResListIsNotNullAndCatStringIsNotNull_ReturnFalse()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyCalenderInt, DummyString };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => { };
            var count = 0;
            ShimSqlDb.ReadIntValueObject = _ =>
            {
                count++;
                if (count == 2 || count == 4 || count == 6)
                {
                    ShimSqlDataReader.AllInstances.Read = _1 => false;
                };
                return DummyInt;
            };
            ShimSqlDataReader.AllInstances.Close = _ =>
            {
                ShimSqlDataReader.AllInstances.Read = _1 => true;
            };

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcDefaultFTEs,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(false));
        }

        [TestMethod]
        public void CalcDefaultFTEs_DBAccessCalenderAndResListIsNotNullAndCatStringIsNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimDBAccess().Instance, DummyCalenderInt, string.Empty };
            ShimSqlDb.AllInstances.DBTraceStatusEnumTraceChannelEnumStringStringStringStringBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => { };
            var count = 0;
            ShimSqlDb.ReadIntValueObject = _ =>
            {
                if (count == 1)
                {
                    count = 0;
                    ShimSqlDataReader.AllInstances.Read = _1 => false;
                    return DummyInt + 1;
                };
                count++;
                return DummyInt;
            };
            ShimSqlDb.ReadDateValueObject = _ => new DateTime();
            ShimSqlDataReader.AllInstances.Close = _ =>
            {
                ShimSqlDataReader.AllInstances.Read = _1 => true;
            };
            ShimDataRow.AllInstances.RowStateGet = _ => DataRowState.Modified;
            var listDataRow = new List<DataRow>() { new ShimDataRow() };
            var shmDataRowCollection = new ShimDataRowCollection();
            shmDataRowCollection.Bind(listDataRow);
            ShimDataTable.AllInstances.RowsGet = _ => shmDataRowCollection;
            ShimDataRowCollection.AllInstances.CountGet = _ => DummyInt;
            ShimAllWorkhours.Constructor = _ => new ShimAllWorkhours();
            ShimAllWorkhours.AllInstances.InitializeDataTableDataTable = (_, _1, _2) => { };
            ShimAllWorkhours.AllInstances.workhoursInt32Int32DateTimeDateTimeBoolean = (_, _1, _2, _3, _4, _5) => DummyInt;

            // Act
            var actualResult = _privateType.InvokeStatic(
                CalcDefaultFTEs,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(true));
        }

        private void SetupFakes()
        {
            ShimAdminFunctions.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => new ShimAdminFunctions();
            ShimPFEBase.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => new ShimPFEBase();
            ShimPFEBase.ConstructorStringSecurityLevelsBoolean =
                (_,_1,_2,_3) => new ShimPFEBase();
            ShimSqlDb.ConstructorString = (_,_1) => new ShimSqlDb();
        }
    }
}