using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Base.DBAccess;
using PortfolioEngineCore.Base.DBAccess.Fakes;
using PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests.Base
{
    [TestClass]
    public class CostValuesTests
    {
        private const string PfEPeriodTypeFullName = "PortfolioEngineCore.dbaCostValues+PfEPeriod";
        private const string PfENamedRatesTypeFullName = "PortfolioEngineCore.dbaCostValues+PfENamedRates";
        private const string PfENamedRateTypeFullName = "PortfolioEngineCore.dbaCostValues+PfENamedRate";
        private const string PfEAdminTypeFullName = "PortfolioEngineCore.dbaCostValues+PfEAdmin";
        private const string GetAutoPostsMethodName = "GetAutoPosts";
        private const string CopyCostValuesMethodName = "CopyCostValues";
        private const string PortfolioEngineCoreDll = "PortfolioEngineCore.dll";
        private const string GetPeriodStartDateMethodName = "GetPeriodStartDate";
        private const string GetCostCategoryRatesMethodName = "GetCostCategoryRates";
        private const string GetXrefsMethodName = "GetXrefs";
        private const string GetRateMethodName = "GetRate";
        private const string UpdateCostTotalMethodName = "UpdateCostTotal";
        private const string GetAdminInfoMethodName = "GetAdminInfo";
        private const string DummyString = "DummyString";
        private readonly DateTime DummyDate = DateTime.Now;
        private IDisposable shimContext;
        private DBAccess dbAccess;
        private int count;
        private PrivateType privateType;

        private static Type PfEPeriodType
        {
            get
            {
                var assembly = GetPortifolioEngineCoreAssembly();
                var type = assembly.GetTypes().FirstOrDefault(p => p.FullName == PfEPeriodTypeFullName);
                return type;
            }
        }

        private static Type PfENamedRatesType
        {
            get
            {
                var assembly = GetPortifolioEngineCoreAssembly();
                var type = assembly.GetTypes().FirstOrDefault(p => p.FullName == PfENamedRatesTypeFullName);
                return type;
            }
        }

        public static  Type PfEAdminType
        {
            get
            {
                var assembly = GetPortifolioEngineCoreAssembly();
                var type = assembly.GetTypes().FirstOrDefault(p => p.FullName == PfEAdminTypeFullName);
                return type;
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            dbAccess = new ShimDBAccess();
            privateType = new PrivateType(typeof(dbaCostValues));
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlDb.ReadIntValueObject = valueObject => 1;
            ShimSqlDb.ReadDateValueObject = valueObject => DummyDate;
            ShimSqlDb.ReadDoubleValueObject = valueObject => 1;
            ShimSqlDb.AllInstances.WriteImmTraceStringStringStringString = (_, key, function, text, details) => { };
            ShimCStruct.AllInstances.LoadXMLString = (_, xmlString) => true;
            ShimCStruct.AllInstances.GetSubStructString = (_, name) => new CStruct();
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => 1;
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>()
            {
                new CStruct()
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimdbaUsers.ExecuteSQLSelectSqlCommandSqlDataReaderOut = ExecuteSQLSelectSuccess;
            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 2)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
        }

        [TestMethod]
        [ExpectedException(typeof(PFEException))]
        public void PostCostValues_OnException_ThrowsPFEException()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            // Expect an Exception
        }

        [TestMethod]
        public void PostCostValues_CTIDEqualsZero_ReturnsFalse()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => 0;
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>();

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_PIListEmpty_ReturnsFalse()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => false,
                ItemGetString = name => DummyString,
                Close = () => { }
            };
            ShimSqlDataReader.AllInstances.Read = _ => false;
            ShimdbaUsers.ExecuteSQLSelectSqlCommandSqlDataReaderOut = ExecuteSQLSelectSuccess;
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>();

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeDisplayAndGetPeriodsError_ReturnsFalse()
        {
            // Arrange
            const string PrdId = "PRD_ID";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>();
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == PrdId)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimdbaUsers.ExecuteSQLSelectSqlCommandSqlDataReaderOut = ExecuteSQLSelectSuccess;
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctDisplay;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeDisplayAndCopyCostValuesError_ReturnsFalse()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctDisplay;
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeDisplayAndCopyCostValuesSuccess_ReturnsTrue()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctDisplay;
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 10;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => name
                    }
                }.GetEnumerator()
            };
            ShimSqlDb.ReadDecimalValueObject = objetcValue => 1.0M;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeTSActualsToDate_ReturnsTrue()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctTSActualsToDate;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModectWEActualsAndGetPeriodsError_ReturnsFalse()
        {
            // Arrange
            const string PrdId = "PRD_ID";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == PrdId)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 2)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            ShimCStruct.AllInstances.GetListString = (_, name) => new List<CStruct>()
            {
                new CStruct()
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModectWEActualsAndGetXrefsError_ReturnsFalse()
        {
            // Arrange
            const string WresId = "WRES_ID";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == WresId)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsError;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModectWEActualsAndGetCostCategoriesError_ReturnsFalse()
        {
            // Arrange
            const string McUid = "MC_UID";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == McUid)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModectWEActualsAndGetCostCategoryRatesError_ReturnsFalse()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesError;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModectWEActualsAndGetNamedRatesError_ReturnsFalse()
        {
            // Arrange
            const string OvertimeRate = "RT_OVERTIME_RATE";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == OvertimeRate)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModectWEActualsAndPostWETimesheetsError_ReturnsFalse()
        {
            // Arrange
            const string OvertimeRate = "WEH_OVERTIMEHOURS";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == OvertimeRate)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            ShimProjectResourceRates.GetRatesDBAccessInt32 = (db, id) => new List<ProjectResourceRate>();
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
            ShimProjectResourceRates.GetRatesDBAccessInt32 = (db, projectId) =>
            {
                throw new Exception();
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModectWEActualsSuccess_ReturnsTrue()
        {
            // Arrange
            const string CommandText = "EPG_SP_PCTReadWEActuals";
            var command = string.Empty;
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                command = instance.CommandText;
                return new ShimSqlDataReader();
            };
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
            ShimProjectResourceRates.GetRatesDBAccessInt32 = (db, projectId) => new List<ProjectResourceRate>();
            ShimSqlDataReader.AllInstances.Read = instance =>
            {
                if (count < 1 || command == CommandText)
                {
                    count++;
                    command = string.Empty;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsAndGetPeriodsError_ReturnsFalse()
        {
            // Arrange
            const string PrdId = "PRD_ID";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == PrdId)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 2)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsAndGetXRefsError_ReturnsFalse()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsError;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsAndGetCostCategoriesError_ReturnsFalse()
        {
            // Arrange
            const string McUid = "MC_UID";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == McUid)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsAndGetCostCategoryRatesError_ReturnsFalse()
        {
            // Arrange
            //const string McUid = "MC_UID";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesError;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsAndGetNamedRatesError_ReturnsFalse()
        {
            // Arrange
            const string EffectiveDate = "RT_EFFECTIVE_DATE";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == EffectiveDate)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsAndPostCommitmentsError_ReturnsFalse()
        {
            // Arrange
            const string PrdFinishDate = "PRD_FINISH_DATE";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) =>
            {
                if (name == PrdFinishDate)
                {
                    throw new Exception();
                }
                else
                {
                    return 1;
                }
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsSuccess_ReturnsTrue()
        {
            // Arrange
            const string CommandText = "EPG_SP_PCTReadCommitments";
            const string GetPeriodsCommand = "SELECT PRD_ID,PRD_NAME,PRD_START_DATE,PRD_FINISH_DATE FROM EPG_PERIODS";
            var command = string.Empty;
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = instance =>
            {
                command = instance.CommandText;
                if (instance.CommandText.Contains(GetPeriodsCommand))
                {
                    var count = 0;
                    return new ShimSqlDataReader
                    {
                        Read = () => ++count <= 10
                    };
                }
                else if (command == CommandText)
                {
                    var count = 0;
                    return new ShimSqlDataReader
                    {
                        Read = () => ++count <=2
                    };
                }
                else
                {
                    return new ShimSqlDataReader();
                }
            };
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
            ShimProjectResourceRates.GetRatesDBAccessInt32 = (db, projectId) => new List<ProjectResourceRate>();
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1 )
                {
                    count++;
                    command = string.Empty;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostValues_CTEditModeCommitmentsSuccessAndPostToWE_ReturnsTrue()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlDb.ReadIntValueObject = valueObject => SwitchValue(valueObject.ToString(), 20000, (int)CTEditMode.ctCommitments);
            ShimCStruct.AllInstances.GetIntAttrString = (_, name) => 20000;
            ShimDataRow.AllInstances.ItemGetString = (_, name) => SwitchValue(name, name, "1");
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => SwitchValue(name, name, "1");
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
            ShimProjectResourceRates.GetRatesDBAccessInt32 = (db, projectId) => new List<ProjectResourceRate>();
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow().Instance
                }.GetEnumerator()
            };
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(string.IsNullOrEmpty(stringResult));
            Assert.IsFalse(string.IsNullOrEmpty(postInstruction));
        }

        [TestMethod]
        public void GetAutoPosts_OnSucess_ReturnsTrue()
        {
            // Arrange
            var privatetype = new PrivateType(typeof(dbaCostValues));
            var autoposts = new int[,] { { 1, 3 } };

            // Act
            var result = privatetype.InvokeStatic(GetAutoPostsMethodName, dbAccess, "Timesheets", autoposts) as bool?;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public void CopyCostValues_InputCalendarNegative_ReturnsFalse()
        {
            // Arrange
            var assembly = GetPortifolioEngineCoreAssembly();
            var pfEPeriodType = assembly.GetTypes().FirstOrDefault(p => p.FullName == PfEPeriodTypeFullName);
            var privateType = new PrivateType(typeof(dbaCostValues));
            var piList = new List<int>();
            var reply = string.Empty;
            var periods = CreateGenericListOfType(pfEPeriodType);

            // Act
            var result = privateType.InvokeStatic(CopyCostValuesMethodName, dbAccess, 1, 1, -1, piList, periods, reply) as bool?;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Value);
        }

        [TestMethod]
        public void MapToPeriod_WithPEriod_ReturnInteger()
        {
            // Arrange
            var assembly = GetPortifolioEngineCoreAssembly();
            var pfEPeriodType = assembly.GetTypes().FirstOrDefault(p => p.FullName == PfEPeriodTypeFullName);
            var date = DateTime.Now;
            var periods = CreateGenericListOfType(pfEPeriodType);
            var period = CreatePfEPeriodInstance(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(2));
            periods.GetType()
                .GetMethod("Add")?
                .Invoke(periods, new[] { period });

            // Act
            var result = privateType.InvokeStatic("MapToPeriod", date, periods) as int?;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Value);
        }

        [TestMethod]
        public void CopyCostValues_CalculateCostValuesError_ReturnsFalse()
        {
            // Arrange
            var count = 1;
            var assembly = GetPortifolioEngineCoreAssembly();
            var pfEPeriodType = assembly.GetTypes().FirstOrDefault(p => p.FullName == PfEPeriodTypeFullName);
            var privateType = new PrivateType(typeof(dbaCostValues));
            var piList = new List<int> { 1 };
            var reply = string.Empty;
            var periods = CreateGenericListOfType(pfEPeriodType);
            var period = CreatePfEPeriodInstance(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            periods.GetType()
                .GetMethod("Add")
                .Invoke(periods, new[] { period });
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow(),
                    new ShimDataRow()
                }.GetEnumerator()
            };
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
            ShimSqlDb.ReadDecimalValueObject = objetcValue => 1.0M;
            ShimSqlDb.ReadIntValueObject = valueObject => ++count;
            ShimdbaCCV.CalculateCostValuesDBAccessInt32Int32Int32StringOut = CalculateCostValuesError;

            // Act
            var result = privateType.InvokeStatic(CopyCostValuesMethodName, dbAccess, 1, 1, 1, piList, periods, reply) as bool?;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Value);
        }

        [TestMethod]
        public void GetPeriodStartDate_PeriodList_ReturnsPeriodStartDate()
        {
            // Arrange
            var periods = CreateGenericListOfType(PfEPeriodType);
            var newPeriod = CreatePfEPeriodInstance(DateTime.Now, DateTime.Now.AddDays(1));
            periods.GetType()
                .GetMethod("Add")
                .Invoke(periods, new object[] { newPeriod });
            periods.GetType()
                .GetMethod("Add")
                .Invoke(periods, new object[] { newPeriod });

            // Act
            var result = privateType.InvokeStatic(GetPeriodStartDateMethodName, 1, periods) as DateTime?;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetPeriodStartDate_PeriodListEmpty_ReturnsDateTimeMinValue()
        {
            // Arrange
            var periods = CreateGenericListOfType(PfEPeriodType);

            // Act
            var result = privateType.InvokeStatic(GetPeriodStartDateMethodName, 1, periods) as DateTime?;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(DateTime.MinValue, result);
        }

        [TestMethod]
        public void GetCostCategoryRates_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var rates = new Dictionary<int, Dictionary<int, double>>();
            var message = string.Empty;
            var count = 1;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = null;
            ShimSqlDb.ReadIntValueObject = valueObject => ++count;

            // Act
            var result = privateType.InvokeStatic(GetCostCategoryRatesMethodName, dbAccess, 1, rates, message) as StatusEnum?;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result.Value);
            Assert.AreNotEqual(0, rates.Count);
        }

        [TestMethod]
        public void GetCostCategoryRates_OnException_ReturnsStatusServerError()
        {
            // Arrange
            var rates = new Dictionary<int, Dictionary<int, double>>();
            var message = string.Empty;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = null;
            ShimSqlDb.ReadIntValueObject = valueObject =>
            {
                throw new Exception();
            };

            // Act
            var result = privateType.InvokeStatic(GetCostCategoryRatesMethodName, dbAccess, 1, rates, message) as StatusEnum?;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result.Value);
        }

        [TestMethod]
        public void GetRate_GetValuesFromProjectRate_ShouldUpdateValues()
        {
            // Arrange
            var namedRates = Activator.CreateInstance(PfENamedRatesType);
            namedRates.GetType()
                .GetField("resourcerates")
                .SetValue(namedRates, new Dictionary<int, int>());
            var projectRates = new List<ProjectResourceRate>
            {
                new ProjectResourceRate
                {
                    EffectiveDate = DateTime.Now.AddDays(-1),
                    ResourceId = 1,
                    Rate = 1.3M
                }
            };
            var categoryRates = new Dictionary<int, Dictionary<int, double>>();
            var args = new object[] { namedRates, projectRates, categoryRates, 1, 1, 1, DateTime.Now, 0D, 0D};

            // Act
            var result = privateType.InvokeStatic(GetRateMethodName, args) as bool?;
            var rate = args[args.Length - 2] as double?;
            var overtimeRate = args[args.Length - 1] as double?;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value);
            Assert.IsNotNull(rate);
            Assert.AreNotEqual(0D, rate);
            Assert.IsNotNull(overtimeRate);
            Assert.AreNotEqual(0D, overtimeRate);
        }

        [TestMethod]
        public void GetRate_GetValuesFromCostCategoryRates_ShouldUpdateValues()
        {
            // Arrange
            var namedRates = Activator.CreateInstance(PfENamedRatesType);
            var resourceRates = new Dictionary<int, int>();
            namedRates.GetType()
                .GetField("resourcerates")
                .SetValue(namedRates, resourceRates);
            var projectRates = new List<ProjectResourceRate>();

            var categoryRates = new Dictionary<int, Dictionary<int, double>>
            {
                [1] = new Dictionary<int, double>
                {
                    [1] = 3.4D
                }
            };
            var args = new object[] { namedRates, projectRates, categoryRates, 1, 1, 1, DateTime.Now, 0D, 0D };

            // Act
            var result = privateType.InvokeStatic(GetRateMethodName, args) as bool?;
            var rate = args[args.Length - 2] as double?;
            var overtimeRate = args[args.Length - 1] as double?;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value);
            Assert.IsNotNull(rate);
            Assert.AreNotEqual(0D, rate);
            Assert.IsNotNull(overtimeRate);
            Assert.AreNotEqual(0D, overtimeRate);
        }

        [TestMethod]
        public void GetAdminInfo_OnException_ReturnsStatusServerError()
        {
            // Arrange
            var pfeAdmin = Activator.CreateInstance(PfEAdminType);
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = privateType.InvokeStatic(GetAdminInfoMethodName, dbAccess, pfeAdmin) as StatusEnum?;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result.Value);
        }

        [TestMethod]
        public void GetXrefs_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            var message = string.Empty;
            var xrefs = new Dictionary<int, int>();
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                if (count < 1)
                {
                    count++;
                    return true;
                }
                else
                {
                    count = 0;
                    return false;
                }
            };

            // Act
            var result = privateType.InvokeStatic(GetXrefsMethodName, dbAccess, xrefs, message) as StatusEnum?;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
            Assert.AreNotEqual(0, xrefs.Count);
        }

        [TestMethod]
        public void GetXrefs_OnException_ReturnsStatusServerError()
        {
            // Arrange
            var message = string.Empty;
            var xrefs = new Dictionary<int, int>();
            ShimSqlDataReader.AllInstances.Read = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = privateType.InvokeStatic(GetXrefsMethodName, dbAccess, xrefs, message) as StatusEnum?;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void UpdateCostTotal_ProjectIDZeroAndEditMode101_ReturnsTrue()
        {
            // Arrange
            const int ProjectId = 0;
            const string ExpectedParameter = "BD_IS_SUMMARY";
            var commandText = string.Empty;
            ShimSqlDb.ReadIntValueObject = valueObject => 101;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, text, connection) =>
            {
                commandText = text;
            };
            
            // Act
            var result = privateType.InvokeStatic(UpdateCostTotalMethodName, dbAccess, ProjectId, 1, 1, 20000) as bool?;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value);
            Assert.IsTrue(commandText.Contains(ExpectedParameter));
        }

        [TestMethod]
        public void UpdateCostTotal_ProjectIDZeroAndEditMode2_ReturnsTrue()
        {
            // Arrange
            const int ProjectId = 0;
            const string ExpectedParameter = "BC_UID";
            var commandText = string.Empty;
            ShimSqlDb.ReadIntValueObject = valueObject => 2;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, text, connection) =>
            {
                commandText = text;
            };

            // Act
            var result = privateType.InvokeStatic(UpdateCostTotalMethodName, dbAccess, ProjectId, 1, 1, 20000) as bool?;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Value);
            Assert.IsTrue(commandText.Contains(ExpectedParameter));
        }
      
        private object CreatePfEPeriodInstance(DateTime? startDate , DateTime? finishDate)
        {
            var instance = Activator.CreateInstance(PfEPeriodType);

            if (startDate != null)
            {
                instance.GetType()
                    .GetField("StartDate")
                    .SetValue(instance, startDate.Value);
            }

            if (finishDate != null)
            {
                instance.GetType()
                    .GetField("FinishDate")
                    .SetValue(instance, finishDate.Value);
            }

            return instance;
        }

        private static Assembly GetPortifolioEngineCoreAssembly()
        {
            return Assembly.LoadFrom(PortfolioEngineCoreDll);
        }

        private object CreateGenericListOfType(Type type)
        {
            var listType = typeof(List<>);
            var constructor = listType.MakeGenericType(type);
            var instance = Activator.CreateInstance(constructor);
            return instance;
        }

        private T SwitchValue<T>(string switchValue, T returnValue, T defaultValue)
        {
            const string CbId = "CB_ID";
            const string CtId = "CT_ID";
            const string BudgetTotalField = "BUDGET_TOTAL_FIELD";
            switch (switchValue)
            {
                case CbId:
                case CtId:
                case BudgetTotalField:
                    return returnValue;
                default:
                    return defaultValue;
            }
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum CalculateCostValuesError(DBAccess dbAccess, int ctId, int cbId, int projectId, out string result)
        {
            result = DummyString;
            return StatusEnum.rsServerError;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum GetCostCategoryRatesError(DBAccess dba, int CbId, Dictionary<int, Dictionary<int, double>> rates, ref string reply)
        {
            reply = DummyString;
            return StatusEnum.rsServerError;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum GetCostCategoryRatesSuccess(DBAccess dba, int CbId, Dictionary<int, Dictionary<int, double>> rates, ref string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum GetXrefsSuccess(DBAccess dbAccess, Dictionary<int, int> xrefs, ref string reply)
        {
            reply = string.Empty;
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum GetXrefsError(DBAccess dbAccess, Dictionary<int, int> xrefs, ref string reply)
        {
            reply = DummyString;
            return StatusEnum.rsServerError;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used
        /// </summary>
        private StatusEnum ExecuteSQLSelectSuccess(SqlCommand sqlCommand, out SqlDataReader dataReader)
        {
            dataReader = new ShimSqlDataReader();
            return StatusEnum.rsSuccess;
        }
    }
}
