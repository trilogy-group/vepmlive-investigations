using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
        private const string DummyString = "DummyString";
        private readonly DateTime DummyDate = DateTime.Now;
        private IDisposable shimContext;
        private DBAccess dbAccess;
        private int count = 0;
        private const string PfEPeriodTypeFullName = "PortfolioEngineCore.dbaCostValues+PfEPeriod";

        private const string GetAutoPostsMethodName = "GetAutoPosts";
        private string CopyCostValuesMethodName = "CopyCostValues";
        private const string PortfolioEngineCoreDll = "PortfolioEngineCore.dll";

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            dbAccess = new ShimDBAccess();


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
            //ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            //{
            //    Read = () => ++count < 2,
            //    ItemGetString = name => DummyString,
            //    Close = () => { }
            //};
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
            ShimSqlDb.ReadIntValueObject = valueObject => 1;

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
        public void PostCostVal_CTEditModectWEActualsAndGetPeriodsError_ReturnsFalse()
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

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModectWEActualsAndGetXrefsError_ReturnsFalse()
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
        public void PostCostVal_CTEditModectWEActualsAndGetCostCategoriesError_ReturnsFalse()
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
        public void PostCostVal_CTEditModectWEActualsAndGetCostCategoryRatesError_ReturnsFalse()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesError;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModectWEActualsAndGetNamedRatesError_ReturnsFalse()
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
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModectWEActualsAndPostWETimesheetsError_ReturnsFalse()
        {
            // Arrange
            const string OvertimeRate = "RT_OVERTIME_RATE";
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            //{
            //    if (name == OvertimeRate)
            //    {
            //        throw new Exception();
            //    }
            //    else
            //    {
            //        return 1;
            //    }
            //};
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
        public void PostCostVal_CTEditModectWEActualsSuccess_ReturnsTrue()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctWEActuals;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
            ShimProjectResourceRates.GetRatesDBAccessInt32 = (db, projectId) => new List<ProjectResourceRate>();

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModeCommitmentsAndGetPeriodsError_ReturnsFalse()
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

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModeCommitmentsAndGetXRefsError_ReturnsFalse()
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
        public void PostCostVal_CTEditModeCommitmentsAndGetCostCategoriesError_ReturnsFalse()
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
        public void PostCostVal_CTEditModeCommitmentsAndGetCostCategoryRatesError_ReturnsFalse()
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

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModeCommitmentsAndGetNamedRatesError_ReturnsFalse()
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
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModeCommitmentsAndPostCommitmentsError_ReturnsFalse()
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
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(string.IsNullOrEmpty(stringResult));
        }

        [TestMethod]
        public void PostCostVal_CTEditModeCommitmentsSuccess_ReturnsTrue()
        {
            // Arrange
            var stringResult = string.Empty;
            var postInstruction = string.Empty;
            ShimSqlDb.ReadIntValueObject = valueObject => (int)CTEditMode.ctCommitments;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, name) => 1;
            ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
            ShimProjectResourceRates.GetRatesDBAccessInt32 = (db, projectId) => new List<ProjectResourceRate>();
            ShimdbaCostValues.GetCostCategoryRatesDBAccessInt32DictionaryOfInt32DictionaryOfInt32DoubleStringRef = GetCostCategoryRatesSuccess;
            ShimdbaCostValues.GetXrefsDBAccessDictionaryOfInt32Int32StringRef = GetXrefsSuccess;

            // Act
            var result = dbaCostValues.PostCostValues(dbAccess, DummyString, out stringResult, out postInstruction);

            // Assert
            Assert.IsTrue(result);
            Assert.IsTrue(string.IsNullOrEmpty(stringResult));
        }


        [TestMethod]
        public void PostCostVal_CTEditModeCommitmentsSuccess_RetudfgdfgdfgdfdfgrnsTrue()
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
            Assert.IsNotNull(autoposts);
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

        //[TestMethod]
        //public void CopyCostValues_InputCalendar_ReturnsFalse()
        //{
        //    // Arrange
        //    var assembly = GetPortifolioEngineCoreAssembly();
        //    var pfEPeriodType = assembly.GetTypes().FirstOrDefault(p => p.FullName == PfEPeriodTypeFullName);
        //    var privateType = new PrivateType(typeof(dbaCostValues));
        //    var piList = new List<int> { 1 };
        //    var reply = string.Empty;
        //    var periods = CreateGenericListOfType(pfEPeriodType);
        //    ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
        //    {
        //        GetEnumerator = () => new List<DataRow>
        //        {
        //            new ShimDataRow()
        //        }.GetEnumerator()
        //    };
        //    ShimProjectDiscountRates.GetProjectDiscountRateDBAccessInt32 = (db, projectId) => 1;
        //    ShimSqlDb.ReadDecimalValueObject = objetcValue => 1.0M;


        //    // Act
        //    var result = privateType.InvokeStatic(CopyCostValuesMethodName, dbAccess, 1, 1, 1, piList, periods, reply) as bool?;

        //    // Assert
        //    Assert.IsNotNull(result);
        //    Assert.IsFalse(result.Value);
        //}

        private Assembly GetPortifolioEngineCoreAssembly()
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
