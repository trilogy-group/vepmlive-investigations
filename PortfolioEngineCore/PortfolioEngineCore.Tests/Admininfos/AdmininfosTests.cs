using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using AdmininfosCore = PortfolioEngineCore.Admininfos;

namespace PortfolioEngineCore.Tests.Admininfos
{
    [TestClass]
    public class AdmininfosTests
    {
        private const string DummyString = "Dummy String";
        private const string InitializeIdMethod = "InitializeId";
        private const string InsertOrUpdateEpgGroupsMethod = "InsertOrUpdateEpgGroups";
        private const string SampleCommand = "SELECT ADM_DEF_FTE_WH,ADM_DEF_FTE_HOL FROM EPG_ADMIN";
        private const int SampleId = 100;

        private int _id;
        private string _sCommand;
        private string _sTitle;
        private SqlTransaction _transaction;

        private PrivateObject _privateObject;
        private AdmininfosCore _admininfos;
        private IDisposable _context;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();

            _id = 10;
            _sCommand = SampleCommand;
            _sTitle = DummyString;
            _transaction = new ShimSqlTransaction
            {
                Commit = () => { },
                DisposeBoolean = _bool => { },
                Rollback = () => { }
            };

            _admininfos = new ShimAdmininfos();
            _privateObject = new PrivateObject(_admininfos);

            SetupFakes();
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeId_WhenSqlTransactionIsNull_ThrowsException()
        {
            // Arrange
            _transaction = null;

            // Act
            _privateObject.Invoke(InitializeIdMethod, _transaction, _sCommand, _id);

            // Assert
            // Expected ArgumentNullException
        }

        [TestMethod]
        public void InitializeId_ShouldGetNextIdValue_CloseConnection()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => false,
                Close = () => { }
            };

            ShimAdmininfos.AllInstances.GetNextIdValueIDataReader = (_, reader) => SampleId;

            var parameters = new object[]
            {
                _transaction,
                _sCommand,
                _id
            };

            // Act
            _privateObject.Invoke(InitializeIdMethod, parameters);

            // Assert
            Assert.AreEqual(SampleId, parameters[2]);
        }

        private static void SetupFakes()
        {
            ShimSqlConnection.ConstructorString = (instance, _string) => { };
            ShimSqlDataReader.AllInstances.Close = reader => { };
        }
    }
}
