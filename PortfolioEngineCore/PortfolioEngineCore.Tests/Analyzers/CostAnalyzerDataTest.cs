using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Analyzers
{
    [TestClass]
    public class CostAnalyzerDataTest
    {
        private IDisposable _shimsContext;
        private ShimSqlConnection _sqlConnectionShim;
        private int _readsCountTotal;
        private int _currentReadNumber;
        private HashSet<string> _sqlCommandsRun;

        private string _ticket;
        private string _projectIdsStringOut;
        private bool _projectsExistOut;
        private int _projectsCountOut;

        private IList<Guid> _projectGuids;
        private int _projectIdDb;

        private string ProjectGuidsString => string.Join(",", _projectGuids);

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _ticket = "test-ticket";
            _projectGuids = new [] { Guid.NewGuid(), Guid.NewGuid() };
            _projectIdDb = 10;

            _readsCountTotal = 1;
            _sqlConnectionShim = new ShimSqlConnection();
            _sqlCommandsRun = new HashSet<string>();

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, sqlConnection) =>
            {
                if (_sqlCommandsRun.Add(commandText))
                {
                    _currentReadNumber = 0;
                }
            };

            ShimSqlCommand.AllInstances.ExecuteReader = (instance) => new ShimSqlDataReader
            {
                Read = () => 
                {
                    return _currentReadNumber++ < _readsCountTotal;
                },

                ItemGetString = columnName =>
                                    columnName == "DC_DATA" ? (object)ProjectGuidsString :
                                    columnName == "PROJECT_ID" ? (object)_projectIdDb :
                                    
                                    DBNull.Value
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void GrabPidsFromTickect_Always_AttemptsToRetrieveTicketFromDb()
        {
            // Arrange

            // Act
            var result = CostAnalyzerData.GrabPidsFromTickect(
                _sqlConnectionShim.Instance,
                _ticket,
                out _projectIdsStringOut,
                out _projectsExistOut,
                out _projectsCountOut);

            // Assert
            Assert.IsTrue(_sqlCommandsRun.Contains(string.Format("SELECT DC_DATA FROM EPG_DATA_CACHE WHERE DC_TICKET = '{0}'", _ticket)));
        }

        [TestMethod]
        public void GrabPidsFromTickect_MultipleGuidsFromCache_FetchesProjectIdsFromDbForEachGuid()
        {
            // Arrange
            var guids = ProjectGuidsString.Split(',');

            // Act
            var result = CostAnalyzerData.GrabPidsFromTickect(
                _sqlConnectionShim.Instance,
                _ticket,
                out _projectIdsStringOut,
                out _projectsExistOut,
                out _projectsCountOut);

            // Assert
            Assert.IsTrue(guids.All(guid => _sqlCommandsRun.Contains(string.Format(
                "SELECT PROJECT_ID FROM EPGP_PROJECTS WHERE {{ fn UCASE(PROJECT_EXT_UID) }}  = '{0}'",
                guid.ToString().ToUpper())
            )));
        }

        [TestMethod]
        public void GrabPidsFromTickect_LastProjectIdIsNot0_ProjectsExistSetTrue()
        {
            // Arrange
            _projectIdDb = 1;

            // Act
            var result = CostAnalyzerData.GrabPidsFromTickect(
                _sqlConnectionShim.Instance,
                _ticket,
                out _projectIdsStringOut,
                out _projectsExistOut,
                out _projectsCountOut);

            // Assert
            Assert.IsTrue(_projectsExistOut);
        }

        [TestMethod]
        public void GrabPidsFromTickect_LastProjectIdIs0_ProjectsExistSetFalse()
        {
            // Arrange
            _projectIdDb = 0;

            // Act
            var result = CostAnalyzerData.GrabPidsFromTickect(
                _sqlConnectionShim.Instance,
                _ticket,
                out _projectIdsStringOut,
                out _projectsExistOut,
                out _projectsCountOut);

            // Assert
            Assert.IsFalse(_projectsExistOut);
        }

        [TestMethod]
        public void GrabPidsFromTickect_MultipleProjects_ProjectIdsStringConcatenated()
        {
            // Arrange
            _projectIdDb = 1;

            // Act
            var result = CostAnalyzerData.GrabPidsFromTickect(
                _sqlConnectionShim.Instance,
                _ticket,
                out _projectIdsStringOut,
                out _projectsExistOut,
                out _projectsCountOut);

            // Assert
            Assert.AreEqual(string.Join(",", Enumerable.Repeat(1, _projectGuids.Count)), _projectIdsStringOut);
        }

        [TestMethod]
        public void GrabPidsFromTickect_MultipleProjectsNonZeroId_ProjectIdsCountedCorrectly()
        {
            // Arrange
            _projectIdDb = 1;

            // Act
            var result = CostAnalyzerData.GrabPidsFromTickect(
                _sqlConnectionShim.Instance,
                _ticket,
                out _projectIdsStringOut,
                out _projectsExistOut,
                out _projectsCountOut);

            // Assert
            Assert.AreEqual(_projectGuids.Count, _projectsCountOut);
        }

        [TestMethod]
        public void GrabPidsFromTickect_MultipleProjectsZeroId_ProjectIdsCountedCorrectly()
        {
            // Arrange
            _projectIdDb = 0;

            // Act
            var result = CostAnalyzerData.GrabPidsFromTickect(
                _sqlConnectionShim.Instance,
                _ticket,
                out _projectIdsStringOut,
                out _projectsExistOut,
                out _projectsCountOut);

            // Assert
            Assert.AreEqual(0, _projectsCountOut);
        }
    }
}
