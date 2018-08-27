using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests
{
    [TestClass]
    public class OptimizerDataTest
    {
        const string _columnName1 = "TEST-1";
        const string _columnName2 = "TEST-2";
        const string _columnName3 = "TEST-3";

        private IList<string> _columnsRead;

        private ShimSqlDataReader _readerShim;
        private IDisposable _shimsContext;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _columnsRead = new List<string>();

            _readerShim = new ShimSqlDataReader();
            _readerShim.ItemGetString = (name) =>
            {
                _columnsRead.Add(name);
                return DBNull.Value;
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void ReadFieldDataFieldId_ReaderNull_Throws()
        {
            // Arrange
            SqlDataReader reader = null;

            // Act
            Action action = () => OptimizerData.ReadFieldDataFieldId(reader, _columnName1);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentNullException ex)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void ReadFieldDataFieldId_ValidColumnName_ReadsColumnFromReader()
        {
            // Arrange, Act
            OptimizerData.ReadFieldDataFieldId(_readerShim.Instance, _columnName1);

            // Assert
            Assert.IsTrue(_columnsRead.Contains(_columnName1));
        }

        [TestMethod]
        public void ReadFieldDataFieldName_ReaderNull_Throws()
        {
            // Arrange
            SqlDataReader reader = null;

            // Act
            Action action = () => OptimizerData.ReadFieldDataFieldName(reader, _columnName1);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentNullException ex)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void ReadFieldDataFieldName_ValidColumnName_ReadsColumnFromReader()
        {
            // Arrange, Act
            OptimizerData.ReadFieldDataFieldName(_readerShim.Instance, _columnName1, _columnName2);

            // Assert
            Assert.IsTrue(_columnsRead.Contains(_columnName1));
            Assert.IsTrue(_columnsRead.Contains(_columnName2));
        }

        [TestMethod]
        public void ReadFieldDataFieldName_ReadsNonEmptyValue_PercentEncoded()
        {
            // Arrange
            const string valueBeforeEncoding = "%test%";
            var valueEncodedExpected = valueBeforeEncoding.Replace("%", "Percent");

            _readerShim.ItemGetString = (name) =>
            {
                _columnsRead.Add(name);
                return valueBeforeEncoding;
            };

            // Act
            var result = OptimizerData.ReadFieldDataFieldName(_readerShim.Instance, _columnName1, _columnName2);

            // Assert
            Assert.AreEqual(valueEncodedExpected, result);
        }

        [TestMethod]
        public void ReadFieldDataFieldFormat_ReaderNull_Throws()
        {
            // Arrange
            SqlDataReader reader = null;

            // Act
            Action action = () => OptimizerData.ReadFieldDataFieldFormat(reader, 1, _columnName1);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentNullException ex)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void ReadFieldDataFieldFormat_ValidColumnNameFieldExtraIdPredefined_ReturnsPredefined()
        {
            // Arrange
            const int predefinedId = 9911;

            // Act
            var result = OptimizerData.ReadFieldDataFieldFormat(_readerShim.Instance, predefinedId, _columnName1);

            // Assert
            Assert.AreEqual(predefinedId, result);
            Assert.AreEqual(0, _columnsRead.Count);
        }

        [TestMethod]
        public void ReadFieldDataFieldFormat_ValidColumnNameFieldExtraIdNotPredefined_ReadsColumnsFromReader()
        {
            // Arrange
            const int fieldExtraId = 1;

            // Act
            var result = OptimizerData.ReadFieldDataFieldFormat(_readerShim.Instance, fieldExtraId, _columnName1, _columnName2, _columnName3);

            // Assert
            Assert.AreEqual(3, _columnsRead.Count);
            Assert.IsTrue(_columnsRead.Contains(_columnName1));
            Assert.IsTrue(_columnsRead.Contains(_columnName2));
            Assert.IsTrue(_columnsRead.Contains(_columnName3));
        }

        [TestMethod]
        public void ReadFieldDataSExtra_ReaderNull_Throws()
        {
            // Arrange
            SqlDataReader reader = null;

            // Act
            Action action = () => OptimizerData.ReadFieldDataSExtra(reader, _columnName1);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentNullException ex)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void ReadFieldDataSExtra_Column1Empty_RetrievesDataFromColumns2And3()
        {
            // Arrange, Act
            var result = OptimizerData.ReadFieldDataSExtra(_readerShim.Instance, _columnName1, _columnName2, _columnName3);

            // Assert
            Assert.AreEqual(3, _columnsRead.Count);
            Assert.IsTrue(_columnsRead.Contains(_columnName1));
            Assert.IsTrue(_columnsRead.Contains(_columnName2));
            Assert.IsTrue(_columnsRead.Contains(_columnName3));
        }
    }
}
