using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;

namespace PortfolioEngineCore.Tests.Base
{
    using System.Data.Fakes;
    using System.Data.SqlClient;
    using System.Data.SqlClient.Fakes;
    using PortfolioEngineCore;

    [TestClass]
    public class AdminPagesTests
    {
        private IDisposable shimContext;
        private DBAccess dbAccess;
        private PrivateType privateType;
        private string UpdateCalcsMethodName = "UpdateCalcs";

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
            ShimSqlDb.ReadIntValueObject = valueObject => 1;
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
                    GetEnumerator = () => new List<DataRow>
                    {
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

        private StatusEnum SelectFormulasSuccess(DBAccess dbAccess, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectComponentsSuccess(DBAccess dbAccess, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

        private StatusEnum SelectDataSuccess(SqlDb sqlDb, string command, StatusEnum statusEnum, out DataTable dataTable)
        {
            dataTable = new DataTable();
            return StatusEnum.rsSuccess;
        }

    }
}
