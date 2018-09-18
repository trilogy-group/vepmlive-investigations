using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests.Base
{
    using PortfolioEngineCore;

    [TestClass]
    public class AdminPagesTests
    {
        private IDisposable shimContext;
        private DBAccess dbAccess;
        private PrivateType privateType;
        private string UpdateCalcsMethodName = "UpdateCalcs";
        private string GetCustFieldValMethodName = "GetCustFieldVal";
        private string PerformCustomFieldsCalculateMethodName = "PerformCustomFieldsCalculate";
        private const string DummyString = "DummyString";

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            dbAccess = new ShimDBAccess();
            SetupShims();
            privateType = new PrivateType(typeof(dbaPrioritz));
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSqlDb.ReadIntValueObject = _ => 1;
            ShimSqlDb.ReadStringValueObject = _ => DummyString;
            ShimSqlDb.AllInstances.BeginTransaction = _ => { };
            ShimSqlDb.AllInstances.CommitTransaction = _ => { };
            ShimSqlDb.AllInstances.HandleStatusErrorSeverityEnumStringStatusEnumStringBoolean =
                (_, severity, function, status, text, skipDbLog) => StatusEnum.rsServerError;
        }

        [TestMethod]
        public void SelectFields_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            var dataTable = new DataTable();

            // Act
            var result = dbaPrioritz.SelectFields(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectComponents_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            var dataTable = new DataTable();

            // Act
            var result = dbaPrioritz.SelectComponents(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectFormulas_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            var dataTable = new DataTable();

            // Act
            var result = dbaPrioritz.SelectFormulas(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectWeights_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            var dataTable = new DataTable();

            // Act
            var result = dbaPrioritz.SelectWeights(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectComponentFields_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            var dataTable = new DataTable();

            // Act
            var result = dbaPrioritz.SelectComponentFields(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void SelectFormulaFields_OnSuccess_ReturnStatusEnumSuccess()
        {
            // Arrange
            ShimSqlDb.AllInstances.SelectDataStringStatusEnumDataTableOut = SelectDataSuccess;
            var dataTable = new DataTable();

            // Act
            var result = dbaPrioritz.SelectFormulaFields(dbAccess, out dataTable);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateComponents_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => 1
                        }
                    }.GetEnumerator()
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimdbaPrioritz.UpdateCalcsDBAccess = _ => StatusEnum.rsSuccess;
            var rowsAffected = 0;

            // Act
            var result = dbaPrioritz.UpdateComponents(dbAccess, dataTable, out rowsAffected);

            // Assert
            Assert.AreNotEqual(0, rowsAffected);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateComponents_OnException_ReturnsStautsError()
        {
            // Arrange
            var rowsAffected = 0;
            var rollbackWasCalled = false;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0,
                    GetEnumerator = () => new List<DataRow>().GetEnumerator()
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.RollbackTransaction = _ =>
            {
                rollbackWasCalled = true;
            };
            // Act
            var result = dbaPrioritz.UpdateComponents(dbAccess, dataTable, out rowsAffected);

            // Assert
            Assert.IsTrue(rollbackWasCalled);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void UpdateWeights_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var rowsAffected = 0;
            var formulas = new List<EPKPriFormula>
            {
                new EPKPriFormula
                {
                    components = new List<ComponentWeight>
                    {
                        new ComponentWeight
                        {
                            ComponentId = 1,
                            Weight = 1
                        }
                    }
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimdbaPrioritz.UpdateCalcsDBAccess = _ => StatusEnum.rsSuccess;
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsSuccess;
            ShimdbaPrioritz.PerformCustomFieldsCalculateDBAccess = _ => StatusEnum.rsSuccess;

            // Act
            var result = dbaPrioritz.UpdateWeights(dbAccess, formulas, out rowsAffected);

            // Assert
            Assert.AreNotEqual(0, rowsAffected);
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateWeights_OnException_ReturnsStautsError()
        {
            // Arrange
            var rowsAffected = 0;
            var rollbackWasCalled = false;
            var formulas = new List<EPKPriFormula>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.RollbackTransaction = _ =>
            {
                rollbackWasCalled = true;
            };
            ShimSqlDb.AllInstances.StatusGet = _ => StatusEnum.rsServerError;

            // Act
            var result = dbaPrioritz.UpdateWeights(dbAccess, formulas, out rowsAffected);

            // Assert
            Assert.IsTrue(rollbackWasCalled);
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void UpdateCalcs_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { }
            };
            ShimdbaPrioritz.SelectComponentsDBAccessDataTableOut = SelectComponentsSuccess;
            ShimdbaPrioritz.SelectFormulasDBAccessDataTableOut = SelectFormulasSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };

            // Act
            var result = privateType.InvokeStatic(UpdateCalcsMethodName, dbAccess);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateCalcs_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                throw new Exception();
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { }
            };
            ShimdbaPrioritz.SelectComponentsDBAccessDataTableOut = SelectComponentsSuccess;
            ShimdbaPrioritz.SelectFormulasDBAccessDataTableOut = SelectFormulasSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };

            // Act
            var result = privateType.InvokeStatic(UpdateCalcsMethodName, dbAccess);

            // Assert
            Assert.AreEqual(StatusEnum.rsServerError, result);
        }

        [TestMethod]
        public void UpdateFormulas_OnSuccess_ReturnsStatusSuccess()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { }
            };
            ShimdbaPrioritz.SelectComponentsDBAccessDataTableOut = SelectComponentsSuccess;
            ShimdbaPrioritz.SelectFormulasDBAccessDataTableOut = SelectFormulasSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            var rowsAffected = 0;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => 1
                        },
                        new ShimDataRow
                        {
                            ItemGetString = name => 1
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = dbaPrioritz.UpdateFormulas(dbAccess, dataTable, out rowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        [TestMethod]
        public void UpdateFormulas_OnException_ReturnsStatusEnumError()
        {
            // Arrange
            var rollBackWasCalled = false;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                Close = () => { }
            };
            ShimdbaPrioritz.SelectComponentsDBAccessDataTableOut = SelectComponentsSuccess;
            ShimdbaPrioritz.SelectFormulasDBAccessDataTableOut = SelectFormulasSuccess;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => 1
                    }
                }.GetEnumerator()
            };
            var rowsAffected = 0;
            var dataTable = new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0,
                    GetEnumerator = () => new List<DataRow>().GetEnumerator()
                }
            };
            ShimSqlDb.AllInstances.CommitTransaction = _ =>
            {
                throw new Exception();
            };
            ShimSqlDb.AllInstances.RollbackTransaction = _ =>
            {
                rollBackWasCalled = true;
            };

            // Act
            var result = dbaPrioritz.UpdateFormulas(dbAccess, dataTable, out rowsAffected);

            // Assert
            Assert.AreEqual(StatusEnum.rsServerError, result);
            Assert.IsTrue(rollBackWasCalled);
        }

        [TestMethod]
        public void GetCustFieldVal_LFat203_ReturnsExpectedValue()
        {
            // Arrange
            const int LFit = 1;
            const int LFat = 203;
            var expectedValue = $"PC_{LFit.ToString("000")}";

            // Act
            var result = privateType.InvokeStatic(GetCustFieldValMethodName, LFit, LFat) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void GetCustFieldVal_LFat202_ReturnsExpectedValue()
        {
            // Arrange
            const int LFit = 1;
            const int LFat = 202;
            var expectedValue = "IsNull(cast(Left(PT_" + LFit.ToString("000") + 
                ", PatIndex('%[^0-9]%', PT_" + LFit.ToString("000") + "+'x' ) - 1 ) as int),0)";

            // Act
            var result = privateType.InvokeStatic(GetCustFieldValMethodName, LFit, LFat) as string;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedValue, result);
        }

        [TestMethod]
        public void PerformCustomFieldsCalculate_OnSuccess_ReturnsStatusEnumSuccess()
        {
            // Arrange
            var count = 0;
            ShimdbaPrioritz.PerformCustomFieldsCalculateDBAccess = null;
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () =>
                {
                    if (count++ <= 4)
                    {
                        return true;
                    }
                    else
                    {
                        count = 0;
                        return false;
                    }
                },
                ItemGetString = name => 1
            };
            ShimSqlDb.ReadIntValueObject = _ => count;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSqlDataReader.AllInstances.Close = _ => { };

            // Act
            var result = privateType.InvokeStatic(PerformCustomFieldsCalculateMethodName, dbAccess);

            // Assert
            Assert.AreEqual(StatusEnum.rsSuccess, result);
        }

        /// <summary> 
        /// This method is fake and these parameters are required, even though not all of them are used 
        /// </summary> 
        private StatusEnum SelectFormulasSuccess(DBAccess dbAccess, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used 
        /// </summary>
        private StatusEnum SelectComponentsSuccess(DBAccess dbAccess, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        /// <summary>
        /// This method is fake and these parameters are required, even though not all of them are used 
        /// </summary>
        private StatusEnum SelectDataSuccess(SqlDb sqlDb, string command, StatusEnum statusEnum, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }
    }
}
