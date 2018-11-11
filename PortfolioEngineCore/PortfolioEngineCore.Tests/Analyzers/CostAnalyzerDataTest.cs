using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CostDataValues;
using EPMLive.TestFakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace PortfolioEngineCore.Tests.Analyzers
{
    [TestClass, ExcludeFromCodeCoverage]
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
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private SqlConnection _sqlConnection = new SqlConnection();

        private string ProjectGuidsString => string.Join(",", _projectGuids);

        private PrivateObject PrivateObject { get; set; }
        private PrivateType PrivateType { get; set; }
        private CostAnalyzerData TestEntity { get; set; }

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
            ShimCostAnalyzerData.ConstructorString = (_, _2) => { };
            TestEntity = new CostAnalyzerData(DummyString);
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(CostAnalyzerData));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
            _sqlConnection?.Dispose();
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

        [TestMethod]
        public void InitalLoadData_OnValidCall_ReturnclsCostData()
        {
            // Arrange, Act, Assert
            TestInitalLoadData(DummyInt, "1", DummyInt, "1");
        }

        [TestMethod]
        public void InitalLoadData_OnUserWResIDIsTwo_ReturnclsCostData()
        {
            // Arrange, Act, Assert
            TestInitalLoadData(2, "1", DummyInt, "1,2");
        }

        [TestMethod]
        public void InitalLoadData_OnCBIdIsMinusOne_ReturnclsCostData()
        {
            // Arrange, Act, Assert
            TestInitalLoadData(2, "1", -1, "1");
        }

        [TestMethod]
        public void InitalLoadData_OnCostTypesIsEmpty_ReturnclsCostData()
        {
            // Arrange, Act, Assert
            TestInitalLoadData(2, "-1", DummyInt, string.Empty);
        }

        [TestMethod]
        public void ReadCatItems_OnLookupIDIsOne_UpdateObject()
        {
            // Arrange
            var costData = new clsCostData();
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("BC_LEVEL"))
                {
                    return 2;
                }

                if (str.Equals("BC_ROLE"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;

            // Act
            PrivateObject.Invoke("ReadCatItems", _sqlConnection, costData);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => costData.m_CostCat.ShouldNotBeNull(),
                () => costData.m_CostCat.ShouldNotBeEmpty(),
                () => costData.m_CostCat.ShouldContainKey(0),
                () => costData.m_CostCat[0].ShouldNotBeNull(),
                () => costData.m_CostCat[0].Role_Name.ShouldBe(DummyString),
                () => costData.m_CostCat[0].Level.ShouldBe(2));
        }

        [TestMethod]
        public void ReadCustomFields_OnLevelIdIsTwo_UpdateObject()
        {
            // Arrange
            var costData = new clsCostData();
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("FA_LOOKUP_UID"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadBoolValueObject = _ => true;

            // Act
            PrivateObject.Invoke("ReadCustomFields", _sqlConnection, costData);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => costData.m_CustFields.ShouldNotBeNull(),
                () => costData.m_CustFields.ShouldNotBeEmpty(),
                () => costData.m_CustFields.ShouldContainKey(0),
                () => costData.m_CustFields[0].ShouldNotBeNull(),
                () => costData.m_CustFields[0].LookupID.ShouldBe(DummyInt),
                () => costData.m_CustFields[0].ListItems.ShouldNotBeNull(),
                () => costData.m_CustFields[0].ListItems.ShouldNotBeEmpty(),
                () => costData.m_CustFields[0].ListItems[0].ShouldNotBeNull(),
                () => costData.m_CustFields[0].ListItems[0].Name.ShouldContain(DummyString));
        }

        [TestMethod]
        public void ReadExtraPifields_OnStringExtraIsEmpty_UpdateObject()
        {
            // Arrange
            var costData = new clsCostData();
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("FIELD_ID"))
                {
                    return 9911;
                }

                if (str.Equals("FIELD_NAME_SQL"))
                {
                    return string.Empty;
                }

                return DummyString;
            };
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimCostAnalyzerData.AllInstances.GetCFFieldNameInt32Int32StringOutStringOut =
                (CostAnalyzerData data, int i, int arg3, out string out1, out string fname) =>
                {
                    fname = DummyString;
                    out1 = DummyString;
                };

            // Act
            PrivateObject.Invoke("ReadExtraPifields", _sqlConnection, costData);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => costData.m_ExtraFieldTypes.ShouldNotBeNull(),
                () => costData.m_ExtraFieldTypes.Length.ShouldBe(257),
                () => costData.m_ExtraFieldTypes[1].ShouldBe(9911),
                () => costData.m_ExtraFieldTypes[2].ShouldBe(9911),
                () => costData.m_sextra.ShouldNotBeNull(),
                () => costData.m_sextra.Length.ShouldBe(257),
                () => costData.m_sextra[1].ShouldBeNullOrEmpty(),
                () => costData.m_sextra[2].ShouldContain(DummyString));
        }

        [TestMethod]
        public void ReadPILevelData_OnCodesNotEmpty_UpdateObject()
        {
            // Arrange
            var dateTimeNow = DateTime.Now;
            var costData = new clsCostData
            {
                m_SelFID = DummyInt,
                m_dtMin = dateTimeNow.AddDays(1),
                m_dtMax = dateTimeNow.AddDays(-1),
                m_Use_extra = 3,
                m_stages = new Dictionary<int, clsDataItem>
                {
                    {DummyInt, new clsDataItem {UID = DummyInt}}
                }
            };
            costData.m_fidextra[1] = 9911;
            costData.m_fidextra[2] = DummyInt;
            costData.m_fidextra[3] = 9911;
            var startFinishDate = DateTime.Now;
            var args = new object[]
            {
                _sqlConnection,
                costData,
                startFinishDate,
                startFinishDate,
            };
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("ADM_STATUS_DATE")
                    || str.Equals("PRD_START_DATE")
                    || str.Equals("PRD_FINISH_DATE")
                    || str.Equals("PROJECT_START_DATE")
                    || str.Equals("PROJECT_FINISH_DATE")
                    || str.Equals("RT_EFFECTIVE_DATE"))
                {
                    return dateTimeNow;
                }

                if (str.Equals("XYZZY"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimSqlDataReader.AllInstances.ItemGetInt32 = (_, indx) =>
            {
                if (indx.Equals(5))
                {
                    return DBNull.Value;
                }
                return DummyInt;
            };
            ShimCostAnalyzerData.AllInstances.MyFormatObjectInt32StringRefStringRef =
                (CostAnalyzerData data, object o, int arg3, ref string codes, ref string res) =>
                {
                    codes = DummyString;
                    res = DummyString;
                    return DummyString;
                };

            // Act
            PrivateObject.Invoke("ReadPILevelData", args);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => costData.m_dtMin.ShouldBe(dateTimeNow),
                () => costData.m_dtMax.ShouldBe(dateTimeNow),
                () => costData.m_PIs.ShouldNotBeNull(),
                () => costData.m_PIs.ShouldNotBeEmpty(),
                () => costData.m_PIs["0 -1"].ShouldNotBeNull(),
                () => costData.m_PIs["0 -1"].PI_Name.ShouldContain(DummyString),
                () => costData.m_PIs["0 -1"].PISelected.ShouldBe(1),
                () => costData.m_codes.ShouldNotBeNull(),
                () => costData.m_codes.ShouldNotBeEmpty(),
                () => costData.m_codes[0].ShouldNotBeNull(),
                () => costData.m_codes[0].Name.ShouldContain(DummyString),
                () => costData.m_reses.ShouldNotBeNull(),
                () => costData.m_reses.ShouldNotBeEmpty(),
                () => costData.m_reses[0].ShouldNotBeNull(),
                () => costData.m_reses[0].Name.ShouldContain(DummyString));
        }

        [TestMethod]
        public void ReadCostCustomFieldsAndData_OnValidCall_UpdateObject()
        {
            // Arrange
            var costData = new clsCostData
            {
                m_sCostTypes = DummyString,
                m_sCalcCostTypes = DummyString,
                m_sOtherCostTypes = DummyString,
                m_PIs = new Dictionary<string, clsPIData>(),
                m_CostTypes = new Dictionary<int, clsDataItem>(),
                m_max_period = DummyInt,
                m_lastperiod_data = -1,
                m_CostCat = new Dictionary<int, clsCatItemData>()
            };
            var cbId = 0;
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("CT_ID"))
                {
                    cbId++;
                    return cbId;
                }

                if (str.Equals("FIELD_NAME_SQL"))
                {
                    return string.Empty;
                }

                return DummyString;
            };
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            var firstTimeCall = true;
            ShimCostAnalyzerData.AllInstances.StripNumStringRef = (CostAnalyzerData data, ref string scalc) =>
            {
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                    scalc = DummyString;
                }
                else
                {
                    scalc = string.Empty;
                }

                return DummyInt;
            };
            
            // Act
            PrivateObject.Invoke("ReadCostCustomFieldsAndData", _sqlConnection, costData);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => costData.m_firstperiod_data.ShouldBe(0),
                () => costData.m_lastperiod_data.ShouldNotBe(DummyInt),
                () => costData.m_detaildata.ShouldNotBeNull(),
                () => costData.m_detaildata.Count.ShouldBe(5));
        }

        [TestMethod]
        public void ReadBudgetBands_OnTargetColoursIsZero_UpdateObject()
        {
            // Arrange
            var costData = new clsCostData();
            SetupShimsForSqlClient();
            ShimSqlDataReader.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("BAND_ID"))
                {
                    return DummyInt;
                }

                return DummyString;
            };
            ShimSqlDb.ReadDoubleValueObject = _ => DummyInt;
            ShimSqlDb.ReadBoolValueObject = _ => true;
            ShimCostAnalyzerData.AllInstances.GetCFFieldNameInt32Int32StringOutStringOut =
                (CostAnalyzerData data, int i, int arg3, out string out1, out string fname) =>
                {
                    fname = DummyString;
                    out1 = DummyString;
                };
            var firstTimeCall = true;
            var readCount = 0;
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (firstTimeCall)
                        {
                            firstTimeCall = false;
                            return false;
                        }

                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }

                        readCount = 0;
                        return false;
                    }
                };
            };

            // Act
            PrivateObject.Invoke("ReadBudgetBands", _sqlConnection, costData);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => costData.m_clsTargetColours.ShouldNotBeNull(),
                () => costData.m_clsTargetColours.ShouldNotBeEmpty(),
                () => costData.m_clsTargetColours[0].Desc.ShouldContain(DummyString),
                () => costData.m_clsTargetColours[0].ID.ShouldBe(DummyInt));
        }

        [TestMethod]
        public void PerformCalcs_OnValidCall_UpdateObject()
        {
            // Arrange
            var costData = new clsCostData
            {
                m_max_period = DummyInt,
                m_ratecache = new Dictionary<string, clsRateFTECache>(),
                m_CostCat = new Dictionary<int, clsCatItemData>
                {
                    {
                        DummyInt, new clsCatItemData(DummyInt)
                        {
                            FTEConv = new double[] {0, DummyInt, 0}
                        }
                    }
                }
            };
            var detailRowData = new clsDetailRowData(DummyInt)
            {
                sUoM = string.Empty,
                BC_UID = DummyInt,
                zValue = new double[3],
                zFTE = new double[3]
            };
            
            // Act
            PrivateObject.Invoke("PerformCalcs", detailRowData, costData);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => detailRowData.zFTE[0].ShouldBe(0),
                () => detailRowData.zFTE[1].ShouldBe(0),
                () => detailRowData.zFTE[2].ShouldBe(0));
        }

        [TestMethod]
        public void PerformCalcs_OnUoMIsNotEmpty_UpdateObject()
        {
            // Arrange
            var costData = new clsCostData
            {
                m_max_period = 2,
                m_ratecache = new Dictionary<string, clsRateFTECache>(),
                m_CostCat = new Dictionary<int, clsCatItemData>
                {
                    {
                        DummyInt, new clsCatItemData(DummyInt)
                        {
                            FTEConv = new double[] {0, DummyInt, 0}
                        }
                    }
                }
            };
            var detailRowData = new clsDetailRowData(DummyInt)
            {
                sUoM = DummyString,
                BC_UID = DummyInt,
                zValue = new double[3],
                zFTE = new double[3]
            };

            // Act
            PrivateObject.Invoke("PerformCalcs", detailRowData, costData);

            // Assert
            costData.ShouldSatisfyAllConditions(
                () => detailRowData.zFTE[0].ShouldBe(0),
                () => detailRowData.zFTE[1].ShouldBe(0),
                () => detailRowData.zFTE[2].ShouldBe(0));
        }

        [TestMethod]
        public void GetCFFieldName_OnResourceINT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(101, "EPGC_RESOURCE_INT_VALUES", "RI_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnResourceTEXT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(102, "EPGC_RESOURCE_TEXT_VALUES", "RT_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnResourceDEC_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(103, "EPGC_RESOURCE_DEC_VALUES", "RC_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnResourceNTEXT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(104, "EPGC_RESOURCE_NTEXT_VALUES", "RN_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnResourceDATE_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(105, "EPGC_RESOURCE_DATE_VALUES", "RD_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnResourceMV_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(151, "EPGC_RESOURCE_MV_VALUES", "MVR_UID");
        }

        [TestMethod]
        public void GetCFFieldName_OnPortfolioINT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(201, "EPGP_PROJECT_INT_VALUES", "PI_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnPortfolioTEXT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(202, "EPGP_PROJECT_TEXT_VALUES", "PT_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnPortfolioDEC_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(203, "EPGP_PROJECT_DEC_VALUES", "PC_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnPortfolioNTEXT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(204, "EPGP_PROJECT_NTEXT_VALUES", "PN_001");
        }
        [TestMethod]
        public void GetCFFieldName_OnPortfolioDATE_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(205, "EPGP_PROJECT_DATE_VALUES", "PD_001");
        }
        [TestMethod]
        public void GetCFFieldName_OnProgram_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(251, "EPGP_PI_PROGS", "PROG_UID");
        }

        [TestMethod]
        public void GetCFFieldName_OnProjectINT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(301, "EPGX_PROJ_INT_VALUES", "XI_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnProjectTEXT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(302, "EPGX_PROJ_TEXT_VALUES", "XT_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnProjectDEC_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(303, "EPGX_PROJ_DEC_VALUES", "XC_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnProjectNTEXT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(304, "EPGX_PROJ_NTEXT_VALUES", "XN_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnProjectDATE_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(305, "EPGX_PROJ_DATE_VALUES", "XD_001");
        }

        [TestMethod]
        public void GetCFFieldName_OnProgramText_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(402, "EPGP_PI_PROGS", "PROG_PI_TEXT1");
        }

        [TestMethod]
        public void GetCFFieldName_OnTaskWIINT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(801, "EPGP_PI_WORKITEMS", "WORKITEM_FLAG1");
        }

        [TestMethod]
        public void GetCFFieldName_OnTaskWITEXT_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(802, "EPGP_PI_WORKITEMS", "WORKITEM_CTEXT1");
        }

        [TestMethod]
        public void GetCFFieldName_OnTaskWIDEC_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(803, "EPGP_PI_WORKITEMS", "WORKITEM_NUMBER1");
        }

        [TestMethod]
        public void GetCFFieldName_OnDefault_UpdateObject()
        {
            // Arrange, Act, Assert
            TestGetCFFieldName(0, "Unknown Table", string.Empty);
        }

        [TestMethod]
        public void MyFormat_OnDateTime_ReturnString()
        {
            // Arrange, Act, Assert
            TestMyFormat(new DateTime(2018, 10, 10, 12, 12, 0), 1, "201810101212");
        }

        [TestMethod]
        public void MyFormat_OnDecimal_ReturnString()
        {
            // Arrange, Act, Assert
            TestMyFormat(DummyInt, 2, "1");
        }

        [TestMethod]
        public void MyFormat_OnString_ReturnString()
        {
            // Arrange, Act, Assert
            TestMyFormat(DummyString, 9, DummyString);
        }

        [TestMethod]
        public void MyFormat_OnInt_ReturnString()
        {
            // Arrange, Act, Assert
            TestMyFormat(DummyInt, 4, "1");
        }

        [TestMethod]
        public void MyFormat_OnIntAndTypeRes_ReturnString()
        {
            // Arrange, Act, Assert
            TestMyFormat(DummyInt, 7, "1");
        }

        [TestMethod]
        public void GetCostAnalyzerViewsXML_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var reply = string.Empty;
            SetupShimsForSqlClient();
            PrivateObject.SetField("_sqlConnection", _sqlConnection);
            ShimCStruct.Constructor = _ => { };
            ShimCStruct.AllInstances.InitializeString = (_, _2) => { };
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, _2) => new ShimCStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var actualResult = TestEntity.GetCostAnalyzerViewsXML(out reply);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => reply.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetCostAnalyzerViewXML_OnValidCall_ReturnBoolean()
        {
            // Arrange
            var reply = string.Empty;
            SetupShimsForSqlClient();
            PrivateObject.SetField("_sqlConnection", _sqlConnection);
            ShimCStruct.Constructor = _ => { };
            ShimCStruct.AllInstances.InitializeString = (_, _2) => { };
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, _2) => new ShimCStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var actualResult = TestEntity.GetCostAnalyzerViewXML(Guid.NewGuid(), out reply);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeTrue(),
                () => reply.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GSaveCostAnalyzerViewXML_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSqlClient();
            PrivateObject.SetField("_sqlConnection", _sqlConnection);
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 0;

            // Act
            var actualResult = TestEntity.SaveCostAnalyzerViewXML(
                Guid.NewGuid(),
                DummyString,
                true,
                true,
                DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteCostAnalyzerViewXML_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSqlClient();
            PrivateObject.SetField("_sqlConnection", _sqlConnection);

            // Act
            var actualResult = TestEntity.DeleteCostAnalyzerViewXML(Guid.NewGuid());

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void RenameCostAnalyzerViewXML_OnValidCall_ReturnBoolean()
        {
            // Arrange
            SetupShimsForSqlClient();
            PrivateObject.SetField("_sqlConnection", _sqlConnection);
            ShimCStruct.Constructor = _ => { };
            ShimCStruct.AllInstances.InitializeString = (_, _2) => { };
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, _2, _3, _4) => { };
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, _2) => new ShimCStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;

            // Act
            var actualResult = TestEntity.RenameCostAnalyzerViewXML(Guid.NewGuid(), DummyString);

            // Assert
            actualResult.ShouldBeTrue();
        }

        [TestMethod]
        public void RenameCostAnalyzerViewXML_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            var executeNonQueryInvoked = false;
            SetupShimsForSqlClient();
            PrivateObject.SetField("_sqlConnection", _sqlConnection);
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                executeNonQueryInvoked = true;
                return DummyInt;
            };

            // Act
            TestEntity.DeleteTarget(DummyInt);

            // Assert
            executeNonQueryInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void SaveTargetData_OnValidCall_ExecuteNonQuery()
        {
            // Arrange
            var targetId = 0;
            var targetName = string.Empty;
            var newTarget = true;
            var executeNonQueryInvoked = false;
            SetupShimsForSqlClient();
            PrivateObject.SetField("_sqlConnection", _sqlConnection);
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                executeNonQueryInvoked = true;
                return DummyInt;
            };
            ShimCStruct.Constructor = _ => { };
            ShimCStruct.AllInstances.InitializeString = (_, _2) => { };
            ShimCStruct.AllInstances.SetStringAttrStringStringBoolean = (_, _2, _3, _4) => { };
            ShimCStruct.AllInstances.LoadXMLString = (_, _2) => true;
            ShimCStruct.AllInstances.AppendSubStructCStruct = (_, _2) => new ShimCStruct();
            ShimCStruct.AllInstances.XML = _ => DummyString;
            ShimCStruct.AllInstances.GetIntAttrString = (_, _2) => 0;
            ShimCStruct.AllInstances.GetStringAttrString = (_, _2) => DummyString;
            ShimCStruct.AllInstances.GetListString = (_, _2) => new List<CStruct> {new ShimCStruct()};

            // Act
            TestEntity.SaveTargetData(DummyString, DummyInt, out targetId, out targetName, out newTarget);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => executeNonQueryInvoked.ShouldBeTrue(),
                () => targetId.ShouldBe(DummyInt),
                () => targetName.ShouldBe(DummyString),
                () => newTarget.ShouldBeTrue());
        }

        [TestMethod]
        public void ReloadTargets_OnValidCall_ReturnclsCostData()
        {
            // Arrange
            ShimCostAnalyzerData.AllInstances.LoadTargetsclsCostData = (_, _2) => DummyInt;

            // Act
            var actualResult = TestEntity.ReloadTargets(DummyInt, DummyInt);

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.m_CB_ID.ShouldBe(DummyInt),
                () => actualResult.m_max_period.ShouldBe(DummyInt));
        }

        private void TestMyFormat(object obj, int lt, string expectedFormat)
        {
            // Arrange
            var args = new[]
            {
                obj,
                lt,
                string.Empty,
                string.Empty
            };

            // Act
            var actualResult = PrivateObject.Invoke("MyFormat", args) as string;

            // Assert
            actualResult.ShouldBe(expectedFormat);
        }

        private void TestGetCFFieldName(int tableId, string expectedTable, string expectedField)
        {
            // Arrange
            var args = new object[]
            {
                tableId,
                DummyInt,
                string.Empty,
                string.Empty
            };

            // Act
            PrivateObject.Invoke("GetCFFieldName", args);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => args[2].ShouldBe(expectedTable),
                () => args[3].ShouldBe(expectedField));
        }

        private void TestInitalLoadData(int userWResID, string viewID, int cbId, string costTypes)
        {
            // Arrange
            var loadMsg = string.Empty;
            var loadDataReturn = 0;
            var dateTimeNow = DateTime.Now;
            SetupShimsForSqlClient();
            PrivateObject.SetField("_userWResID", userWResID);
            PrivateObject.SetField("_sqlConnection", _sqlConnection);
            PrivateObject.SetField("_dba", new DBAccess(DummyString));
            ShimSecurity.CheckUserGlobalPermissionDBAccessInt32GlobalPermissionsEnum = (_, _2, _3) => false;
            ShimCostAnalyzerData.GrabPidsFromTickectSqlConnectionStringStringOutBooleanOutInt32Out = (SqlConnection connection, string ticket,
                out string idsString, out bool exist, out int count) =>
            {
                idsString = DummyString;
                exist = true;
                count = DummyInt;
                return DummyInt;
            };
            ShimCostAnalyzerData.CheckIfCostViewsExistSqlConnection = _ => false;
            ShimCostAnalyzerData
                .GrabCostViewInfoSqlConnectionStringStringRefInt32OutStringOutStringOutInt32OutInt32Out = (SqlConnection connection, string idString,
                ref string typesString, out int id, out string costTypesString, out string otherCostTypesString, out int period,
                out int lastPeriod) =>
                {
                    typesString = DummyString;
                    id = cbId;
                    costTypesString = costTypes;
                    otherCostTypesString = costTypes;
                    period = DummyInt;
                    lastPeriod = DummyInt;
                    return DummyInt;
                };
            ShimSqlDataReader.AllInstances.ItemGetString = (_, str) =>
            {
                if (str.Equals("ADM_STATUS_DATE")
                    || str.Equals("PRD_START_DATE")
                    || str.Equals("PRD_FINISH_DATE")
                    || str.Equals("PROJECT_START_DATE")
                    || str.Equals("PROJECT_FINISH_DATE")
                    || str.Equals("RT_EFFECTIVE_DATE"))
                {
                    return dateTimeNow;
                }
                if (str.Equals("CT_ID")
                    || str.Equals("STAGE_ID")
                    || str.Equals("BAND_ID")
                    || str.Equals("CT_ALLOW_NAMED_RATES")
                    || str.Equals("BA_FTE_CONV")
                    || str.Equals("BA_RATE")
                    || str.Equals("BD_Cost")
                    || str.Equals("BD_VALUE")
                    || str.Equals("BAND_BOT")
                    || str.Equals("BAND_TOP")
                    || str.Equals("RT_RATE"))
                {
                    return DummyInt;
                }
                return DummyString;
            };

            // Act
            var actualResult = TestEntity.InitalLoadData(DummyString, viewID, out loadMsg, out loadDataReturn);

            // Assert
            if (cbId.Equals(-1))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeNull(),
                    () => loadMsg.ShouldContain("No Cost Breakdown (CB_IB) specified"),
                    () => loadDataReturn.ShouldBe(1));
            }
            else if (string.IsNullOrEmpty(costTypes))
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldBeNull(),
                    () => loadMsg.ShouldContain("No Cost Types specified"),
                    () => loadDataReturn.ShouldBe(2));
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldNotBeNull(),
                    () => loadMsg.ShouldBeNullOrEmpty(),
                    () => loadDataReturn.ShouldBe(40),
                    () => actualResult.m_gPOPerm.ShouldBe(userWResID.Equals(DummyInt) ? 1 : 0),
                    () => actualResult.m_sPids.ShouldContain(DummyString),
                    () => actualResult.m_GotAllPIs.ShouldBeTrue(),
                    () => actualResult.m_PI_Count.ShouldBe(DummyInt),
                    () => actualResult.m_sCalcCostTypes.ShouldContain(DummyString),
                    () => actualResult.m_CB_ID.ShouldBe(DummyInt),
                    () => actualResult.m_sCostTypes.ShouldBe(costTypes),
                    () => actualResult.m_sOtherCostTypes.ShouldBe(costTypes),
                    () => actualResult.m_statdate.ShouldBe(dateTimeNow),
                    () => actualResult.m_CostTypes.ShouldNotBeNull(),
                    () => actualResult.m_CostTypes.ShouldNotBeEmpty(),
                    () => actualResult.m_CostTypes.ContainsKey(DummyInt).ShouldBeTrue(),
                    () => actualResult.m_CostTypes[DummyInt].Name.ShouldContain(DummyString),
                    () => actualResult.m_stages.ShouldNotBeNull(),
                    () => actualResult.m_stages.ShouldNotBeEmpty(),
                    () => actualResult.m_stages.ContainsKey(DummyInt).ShouldBeTrue(),
                    () => actualResult.m_stages[DummyInt].Name.ShouldContain(DummyString),
                    () => actualResult.m_clsTargetColours.ShouldNotBeNull(),
                    () => actualResult.m_clsTargetColours.ShouldNotBeEmpty());
            }
        }

        private static void SetupShimsForSqlClient()
        {
            var readCount = 0;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }

                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => new ShimSqlCommand();
            ShimSqlDataReader.AllInstances.NextResult = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.Now;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, __) => true;
            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid.NewGuid();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlDataReader.AllInstances.ItemGetString = (_, _2) => DummyString;
            ShimSqlDataReader.AllInstances.NextResult = _ =>
            {
                readCount = 0;
                return true;
            };
            ShimSqlTransaction.AllInstances.Commit = _ => { };
            ShimSqlTransaction.AllInstances.Rollback = _ => { };
            ShimSqlConnection.AllInstances.BeginTransaction = _ => new ShimSqlTransaction();
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
        }
    }
}