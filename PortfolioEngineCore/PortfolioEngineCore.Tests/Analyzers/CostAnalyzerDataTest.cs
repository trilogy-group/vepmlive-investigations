using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Linq;
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
        private int _viewId;
        private string _costViewIdString;
        private string _calculatedCostTypesString;
        private string _costTypesString;
        private string _otherCostTypesString;
        private int _costBreakdownIdOut;
        private int _firstPeriodOut;
        private int _lastPeriodOut;
        private int _costBreakdownIdDb;
        private int _firstPeriodDb;
        private int _lastPeriodDb;
        private int _costTypeId;
        private int _costTypeEditMode;
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

            _readsCountTotal = 1;
            _sqlConnectionShim = new ShimSqlConnection();
            _viewId = 2;
            _costViewIdString = "10";
            _calculatedCostTypesString = "15";
            _costBreakdownIdDb = 11;
            _firstPeriodDb = 12;
            _lastPeriodDb = 13;
            _costTypeId = 21;
            _costTypeEditMode = 1;
            _sqlCommandsRun = new HashSet<string>();

            _ticket = "test-ticket";
            _projectGuids = new[] { Guid.NewGuid(), Guid.NewGuid() };
            _projectIdDb = 10;

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
                                    columnName == "VIEW_UID" ? (object)_viewId :
                                    columnName == "VIEW_COST_BREAKDOWN" ? (object) _costBreakdownIdDb :
                                    columnName == "VIEW_FIRST_PERIOD" ? (object) _firstPeriodDb :
                                    columnName == "VIEW_LAST_PERIOD" ? (object) _lastPeriodDb :                                    
                                    columnName == "CT_ID" ? (object) _costTypeId :                                    
                                    columnName == "CT_EDIT_MODE" ? (object) _costTypeEditMode:                                    
                                    DBNull.Value
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void CheckIfCostViewsExist_Always_CorrectSqlExecuted()
        {
            // Arrange

            // Act
            CostAnalyzerData.CheckIfCostViewsExist(_sqlConnectionShim.Instance);

            // Assert
            Assert.IsTrue(_sqlCommandsRun.Contains("SELECT * FROM EPGT_COSTVIEW_DISPLAY"));
        }

        [TestMethod]
        public void CheckIfCostViewsExist_RowsExist_ReturnsTrue()
        {
            // Arrange
            _readsCountTotal = 1;

            // Act
            var result = CostAnalyzerData.CheckIfCostViewsExist(_sqlConnectionShim.Instance);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfCostViewsExist_NoRowsExist_ReturnsFalse()
        {
            // Arrange
            _readsCountTotal = 0;

            // Act
            var result = CostAnalyzerData.CheckIfCostViewsExist(_sqlConnectionShim.Instance);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GrabCostViewInfo_CostViewIdUnparsable_Returns1()
        {
            // Arrange
            _costViewIdString = "test";

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GrabCostViewInfo_CostViewId0_Returns1()
        {
            // Arrange
            _costViewIdString = "0";

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GrabCostViewInfo_CostViewIdValid_ReadsCostViewDisplayFromDb()
        {
            // Arrange
            _costBreakdownIdDb = 0;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.IsTrue(_sqlCommandsRun.Contains("SELECT * FROM EPGT_COSTVIEW_DISPLAY WHERE VIEW_UID = " + _costViewIdString));
        }

        [TestMethod]
        public void GrabCostViewInfo_CostViewIdValid_ReadsValuesFromDb()
        {
            // Arrange
            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(_costBreakdownIdDb, _costBreakdownIdOut);
            Assert.AreEqual(_firstPeriodDb, _firstPeriodOut);
            Assert.AreEqual(_lastPeriodDb, _lastPeriodOut);
        }

        [TestMethod]
        public void GrabCostViewInfo_CostBreakdownId0_Returns1()
        {
            // Arrange
            _costBreakdownIdDb = 0;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GrabCostViewInfo_CostBreakdownIdNot0_ReadsCostTypesFromDb()
        {
            // Arrange
            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.IsTrue(_sqlCommandsRun.Contains(@"
                SELECT 
                    EPGT_COSTVIEW_COST_TYPES.CT_ID, 
                    EPGP_COST_TYPES.CT_EDIT_MODE 
                FROM EPGT_COSTVIEW_COST_TYPES 
                     INNER JOIN EPGP_COST_TYPES ON EPGT_COSTVIEW_COST_TYPES.CT_ID = EPGP_COST_TYPES.CT_ID 
                WHERE VIEW_UID = " + _costViewIdString));
        }

        [TestMethod]
        public void GrabCostViewInfo_EditMode1RunsOnce_AssignsIdToCostTypes()
        {
            // Arrange
            _costTypeEditMode = 1;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(_costTypeId.ToString(), _costTypesString);
        }


        [TestMethod]
        public void GrabCostViewInfo_EditMode1RunsMultiple_AppendsIdToCostTypes()
        {
            // Arrange
            _costTypeEditMode = 1;
            _readsCountTotal = 2;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(_costTypeId + "," + _costTypeId, _costTypesString);
        }

        [TestMethod]
        public void GrabCostViewInfo_EditModeNon1Or3RunsOnce_AssignsIdToOtherCostTypes()
        {
            // Arrange
            _costTypeEditMode = 2;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(_costTypeId.ToString(), _otherCostTypesString);
        }

        [TestMethod]
        public void GrabCostViewInfo_EditModeNon1Or3RunsMultiple_AppendsIdToOtherCostTypes()
        {
            // Arrange
            _costTypeEditMode = 2;
            _readsCountTotal = 2;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(_costTypeId + "," + _costTypeId, _otherCostTypesString);
        }

        [TestMethod]
        public void GrabCostViewInfo_EditMode3RunsOnce_AssignsIdToCalculatedCostTypesAndOtherCostTypes()
        {
            // Arrange
            _costTypeEditMode = 3;
            var calculatedCostTypesInitialState = _calculatedCostTypesString;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(_costTypeId.ToString(), _otherCostTypesString);
            Assert.AreEqual(calculatedCostTypesInitialState + "," + _costTypeId, _calculatedCostTypesString);
        }


        [TestMethod]
        public void GrabCostViewInfo_EditMode3RunsMultiple_AppendsIdToCostTypesAndCalculatedCostTypes()
        {
            // Arrange
            _costTypeEditMode = 3;
            _readsCountTotal = 2;
            var calculatedCostTypesInitialState = _calculatedCostTypesString;

            // Act
            var result = CostAnalyzerData.GrabCostViewInfo(
                _sqlConnectionShim.Instance,
                _costViewIdString,
                ref _calculatedCostTypesString,
                out _costBreakdownIdOut,
                out _costTypesString,
                out _otherCostTypesString,
                out _firstPeriodOut,
                out _lastPeriodOut
            );

            // Assert
            Assert.AreEqual(_costTypeId + "," + _costTypeId, _otherCostTypesString);
            Assert.AreEqual(calculatedCostTypesInitialState + "," + _costTypeId + "," + _costTypeId, _calculatedCostTypesString);
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