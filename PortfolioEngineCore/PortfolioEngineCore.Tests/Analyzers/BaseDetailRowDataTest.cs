using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CostDataValues;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Tests.Testables;

namespace PortfolioEngineCore.Tests.Analyzers
{
    [TestClass]
    public class BaseDetailRowDataTest
    {
        private const int _arraySize = 2;
        private const int _periodOverlapForDefaultValues = 10;
        private BaseDetailRowDataTestable _testable;

        private IList<DateTime> _periodsStartDates;
        private IList<DateTime> _periodsEndDates;
        private IList<int> _periodsModes;
        private IList<IPeriodData> _periods;
        private int _minP;
        private int _maxP;

        [TestInitialize]
        public void SetUp()
        {
            var baseDate = new DateTime(2018, 01, 01);
            
            _minP = 0;
            _maxP = _arraySize - 1;
            _periodsStartDates = new List<DateTime>();
            _periodsEndDates = new List<DateTime>();
            _periods = new List<IPeriodData>();
            _periodsModes = new List<int>();

            for (var i = 0; i < _arraySize; i++)
            {
                var startDate = baseDate.AddDays(i * 5);
                var endDate = baseDate.AddDays(9).AddDays(i * 3);
                
                _periodsModes.Add(i + 1);
                _periodsStartDates.Add(startDate);
                _periodsEndDates.Add(endDate);
                _periods.Add(new clsPeriodData
                {
                    StartDate = startDate,
                    FinishDate = endDate
                });
            }

            _testable = new BaseDetailRowDataTestable(_arraySize)
            {
                mxdim = _periods.Count - 1,
                bCapture = true,
                BC_ROLE_UID = 1,
                BC_SEQ = 2,
                BC_UID = 3,
                bGotChildren = true,
                bHadPData = true,
                bRealone = true,
                bRollupTouched = true,
                bSelected = true,
                bUseCosts = true,
                b_PIOver = true,
                Cat_Name = "test",
                CAT_UID = 1,
                CB_ID = 2,
                CC_Name = "test-2",
                CT_ID = 3,
                CT_Name = "test-3",
                Det_Finish = new DateTime(2018, 02, 01),
                Det_Start = new DateTime(2018, 01, 01),
                oDet_Finish = new DateTime(2018, 01, 05),
                oDet_Start = new DateTime(2018, 01, 01),
                FullCatName = "test-4",
                FullCCName = "test-5",
                HasValues = true,
                Internal_ID = 1,
                LinkedToPI = true,
                lUoM = 2,
                MC_Name = "test-6",
                MC_Val = "test-7"
            };
        }

        [TestMethod]
        public void Constructor_Always_InitializesStringFieldsToEmptyString()
        {
            // Arrange, Act
            _testable = new BaseDetailRowDataTestable(_arraySize);

            // Assert
            Assert.AreEqual(string.Empty, _testable.PI_Name);
            Assert.AreEqual(string.Empty, _testable.CT_Name);
            Assert.AreEqual(string.Empty, _testable.Scen_Name);
            Assert.AreEqual(string.Empty, _testable.Cat_Name);
            Assert.AreEqual(string.Empty, _testable.Role_Name);
            Assert.AreEqual(string.Empty, _testable.MC_Name);
            Assert.AreEqual(string.Empty, _testable.FullCatName);
            Assert.AreEqual(string.Empty, _testable.FullCCName);
            Assert.AreEqual(string.Empty, _testable.CC_Name);
            Assert.AreEqual(string.Empty, _testable.m_rt_name);
        }

        [TestMethod]
        public void Constructor_Always_InitializesArrayFieldsBasedOnArraySize()
        {
            // Arrange
            const int expectedArraySize = _arraySize + 1;

            // Act
            _testable = new BaseDetailRowDataTestable(_arraySize);

            // Assert
            Assert.AreEqual(_arraySize, _testable.mxdim);
            Assert.IsNotNull(_testable.zCost);
            Assert.AreEqual(expectedArraySize, _testable.zCost.Length);
            Assert.IsNotNull(_testable.zValue);
            Assert.AreEqual(expectedArraySize, _testable.zValue.Length);
            Assert.IsNotNull(_testable.zFTE);
            Assert.AreEqual(expectedArraySize, _testable.zFTE.Length);
            Assert.IsNotNull(_testable.oCosts);
            Assert.AreEqual(expectedArraySize, _testable.oCosts.Length);
            Assert.IsNotNull(_testable.oUnits);
            Assert.AreEqual(expectedArraySize, _testable.oUnits.Length);
            Assert.IsNotNull(_testable.oFTE);
            Assert.AreEqual(expectedArraySize, _testable.oFTE.Length);
            Assert.IsNotNull(_testable.BurnDuration);
            Assert.AreEqual(expectedArraySize, _testable.BurnDuration.Length);
            Assert.IsNotNull(_testable.Burnrate);
            Assert.AreEqual(expectedArraySize, _testable.Burnrate.Length);
            Assert.IsNotNull(_testable.UseBurnrate);
            Assert.AreEqual(expectedArraySize, _testable.UseBurnrate.Length);
            Assert.IsNotNull(_testable.OutsideAdj);
            Assert.AreEqual(expectedArraySize, _testable.OutsideAdj.Length);
            Assert.IsNotNull(_testable.Budget);
            Assert.AreEqual(expectedArraySize, _testable.Budget.Length);
        }

        [TestMethod]
        public void Constructor_Always_InitializesArrayFieldsNotBasedOnArraySize()
        {
            // Arrange
            const int expectedArraySize = 6;

            // Act
            _testable = new BaseDetailRowDataTestable(_arraySize);

            // Assert
            Assert.IsNotNull(_testable.OCVal);
            Assert.AreEqual(expectedArraySize, _testable.OCVal.Length);
            Assert.IsNotNull(_testable.Text_OCVal);
            Assert.AreEqual(expectedArraySize, _testable.Text_OCVal.Length);
            Assert.IsNotNull(_testable.TXVal);
            Assert.AreEqual(expectedArraySize, _testable.TXVal.Length);
        }

        [TestMethod]
        public void Constructor_Always_InitializesArrayFieldValues()
        {
            // Arrange, Act
            _testable = new BaseDetailRowDataTestable(_arraySize);

            // Assert
            for (int i = 0; i <= _arraySize; i++)
            {
                Assert.AreEqual(0, _testable.zCost[i]);
                Assert.AreEqual(0, _testable.zValue[i]);
            }
        }

        [TestMethod]
        public void CopyData_SourceNull_Throws()
        {
            // Arrange
            BaseDetailRowDataTestable source = null;

            // Act
            Action action = () => _testable.CopyData(source);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentNullException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void CopyData_SourceNotNull_CopiesServiceDataFields()
        {
            // Arrange
            var destination = new BaseDetailRowDataTestable(_arraySize);

            // Act
            destination.CopyData(_testable);

            // Assert
            Assert.AreEqual(_testable.CB_ID, destination.CB_ID);
            Assert.AreEqual(_testable.CT_ID, destination.CT_ID);
            Assert.AreEqual(_testable.PROJECT_ID, destination.PROJECT_ID);
            Assert.AreEqual(_testable.BC_UID, destination.BC_UID);
            Assert.AreEqual(_testable.BC_ROLE_UID, destination.BC_ROLE_UID);
            Assert.AreEqual(_testable.BC_SEQ, destination.BC_SEQ);
            Assert.AreEqual(_testable.MC_Val, destination.MC_Val);
            Assert.AreEqual(_testable.CAT_UID, destination.CAT_UID);
            Assert.AreEqual(_testable.PI_Name, destination.PI_Name);
            Assert.AreEqual(_testable.CT_Name, destination.CT_Name);
            Assert.AreEqual(_testable.CB_ID, destination.CB_ID);
            Assert.AreEqual(_testable.Cat_Name, destination.Cat_Name);
            Assert.AreEqual(_testable.Role_Name, destination.Role_Name);
            Assert.AreEqual(_testable.MC_Name, destination.MC_Name);
            Assert.AreEqual(_testable.FullCatName, destination.FullCatName);
            Assert.AreEqual(_testable.Scenario_ID, destination.Scenario_ID);
            Assert.AreEqual(_testable.CC_Name, destination.CC_Name);
            Assert.AreEqual(_testable.FullCCName, destination.FullCCName);

        }

        [TestMethod]
        public void CopyData_SourceNotNull_CopiesLogicDataFields()
        {
            // Arrange
            var destination = new BaseDetailRowDataTestable(_arraySize);

            // Act
            destination.CopyData(_testable);

            // Assert
            Assert.AreEqual(_testable.Det_Start, destination.Det_Start);
            Assert.AreEqual(_testable.Det_Finish, destination.Det_Finish);
            Assert.AreEqual(_testable.oDet_Start, destination.oDet_Start);
            Assert.AreEqual(_testable.oDet_Finish, destination.oDet_Finish);
            Assert.AreEqual(_testable.bHadPData, destination.bHadPData);
            Assert.AreEqual(_testable.b_PIOver, destination.b_PIOver);
            Assert.AreEqual(_testable.LinkedToPI, destination.LinkedToPI);
            Assert.AreEqual(_testable.m_mode, destination.m_mode);
            Assert.AreEqual(_testable.m_PI_Format_Extra_data, destination.m_PI_Format_Extra_data);
            Assert.AreEqual(_testable.m_tot1, destination.m_tot1);
            Assert.AreEqual(_testable.m_tot2, destination.m_tot2);
            Assert.AreEqual(_testable.m_tot3, destination.m_tot3);
            Assert.AreEqual(_testable.m_rt, destination.m_rt);
            Assert.AreEqual(_testable.m_rt_name, destination.m_rt_name);
            Assert.AreEqual(_testable.bSelected, destination.bSelected);
            Assert.AreEqual(_testable.bRealone, destination.bRealone);
            Assert.AreEqual(_testable.lUoM, destination.lUoM);
            Assert.AreEqual(_testable.HasValues, destination.HasValues);
            Assert.AreEqual(_testable.bUseCosts, destination.bUseCosts);
        }

        [TestMethod]
        public void CopyData_SourceNotNull_CopiesArrays()
        {
            // Arrange
            var destination = new BaseDetailRowDataTestable(_arraySize);

            // Act
            destination.CopyData(_testable);

            // Assert
            for (int i = 1; i <= _arraySize; i++)
            {
                Assert.AreEqual(_testable.zCost[i], destination.zCost[i]);
                Assert.AreEqual(_testable.zValue[i], destination.zValue[i]);
                Assert.AreEqual(_testable.zFTE[i], destination.zFTE[i]);
                Assert.AreEqual(_testable.oCosts[i], destination.oCosts[i]);
                Assert.AreEqual(_testable.oUnits[i], destination.oUnits[i]);
                Assert.AreEqual(_testable.oFTE[i], destination.oFTE[i]);
                Assert.AreEqual(_testable.BurnDuration[i], destination.BurnDuration[i]);
                Assert.AreEqual(_testable.Burnrate[i], destination.Burnrate[i]);
                Assert.AreEqual(_testable.UseBurnrate[i], destination.UseBurnrate[i]);
                Assert.AreEqual(_testable.OutsideAdj[i], destination.OutsideAdj[i]);
                Assert.AreEqual(_testable.oUnits[i], destination.oUnits[i]);
                Assert.AreEqual(_testable.Budget[i], destination.Budget[i]);
            }
        }

        [TestMethod]
        public void DragBar_PeriodsInconsistent_Throws()
        {
            // Arrange
            _periodsStartDates.Clear();

            // Act
            Action action = () => _testable.DragBar(_periodsStartDates, _periodsEndDates, _periodsModes, _minP, _maxP);

            // Assert
            try
            {
                action();
            }
            catch(ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void DragBar_PeriodsNotTheSameLentghAsArrayCount_Throws()
        {
            // Arrange
            _periodsStartDates.Clear();
            _periodsEndDates.Clear();
            _periodsModes.Clear();

            // Act
            Action action = () => _testable.DragBar(_periodsStartDates, _periodsEndDates, _periodsModes, _minP, _maxP);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void DragBar_PeriodNotSetForBudgetBurn_NotProcessed()
        {
            // Arrange
            const int indexUnderTest = 1;

            _testable.BurnDuration[indexUnderTest] = 3;
            _testable.Burnrate[indexUnderTest] = 0.5;

            _periodsModes[indexUnderTest] = 0;

            // Act
            _testable.DragBar(_periodsStartDates, _periodsEndDates, _periodsModes, _minP, _maxP);

            // Assert
            Assert.AreEqual(0, _testable.Budget[indexUnderTest]);
        }

        [TestMethod]
        public void DragBar_PeriodtSetForBudgetBurn_BudgetCalculated()
        {
            // Arrange
            const int indexUnderTest = 1;

            _testable.zCost[indexUnderTest] = 10;
            _testable.BurnDuration[indexUnderTest] = 3;
            _testable.Burnrate[indexUnderTest] = 0.5;
            _periodsModes[indexUnderTest] = 1;

            // Act
            _testable.DragBar(_periodsStartDates, _periodsEndDates, _periodsModes, _minP, _maxP);

            // Assert
            Assert.AreEqual(_testable.zCost[indexUnderTest], _testable.Budget[indexUnderTest]);
        }

        // (CC-77750, 2018-07-23) Sadly, the DragBar logic is very difficult to understand. 
        // Not clear what it calculates and following which logic. 
        // Therefore it's difficult to create meaningful comprehandable tests for it's calculations

        [TestMethod]
        public void CaptureBurnRates_NoPeriods_DoesNotAffectBurnData()
        {
            // Arrange
            var periods = Enumerable.Empty<IPeriodData>();

            // Act
            _testable.CaptureBurnRates(periods);

            // Assert
            Assert.IsTrue(_testable.Burnrate.All(pred => pred == 0));
            Assert.IsTrue(_testable.BurnDuration.All(pred => pred == 0));
        }

        [TestMethod]
        public void CaptureBurnRates_NoOverlap_ZeroBurnrate()
        {
            // Arrange
            _testable.Det_Start = _periods.Max(pred => pred.FinishDate).AddDays(1);
            _testable.bUseCosts = true;
            _testable.zCost[1] = 5;

            // Act
            _testable.CaptureBurnRates(_periods);

            // Assert
            Assert.AreEqual(0, _testable.Burnrate[1]);
        }

        [TestMethod]
        public void CaptureBurnRates_UseCost_SetsCostAsBurnRate()
        {
            // Arrange
            _testable.bUseCosts = true;
            _testable.zCost[1] = 5;

            // Act
            _testable.CaptureBurnRates(_periods);

            // Assert
            Assert.AreEqual(_testable.zCost[1] / _periodOverlapForDefaultValues, _testable.Burnrate[1]);
        }

        [TestMethod]
        public void CaptureBurnRates_NotUseCost_SetsValueAsBurnRate()
        {
            // Arrange
            _testable.bUseCosts = false;
            _testable.zValue[1] = 5;

            // Act
            _testable.CaptureBurnRates(_periods);

            // Assert
            Assert.AreEqual(_testable.zValue[1] / _periodOverlapForDefaultValues, _testable.Burnrate[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToTargetData_DestinationNull_Throws()
        {
            // Arrange
            clsTargetRowData destination = null;

            // Act
            _testable.CopyToTargetData(destination);

            // Assert
            // ExpectedException - ArgumentNullException
        }

        [TestMethod]
        public void CopyToTargetData_DestinationNotNull_ShallowCoppiesFields()
        {
            // Arrange
            var destination = new clsTargetRowData();
            _testable.CT_ID = 1;
            _testable.BC_UID = 2;
            _testable.BC_ROLE_UID = 3;
            _testable.BC_SEQ = 4;
            _testable.MC_Val = "5";
            _testable.CAT_UID = 6;
            _testable.CT_Name = "6-1";
            _testable.Cat_Name = "6-2";
            _testable.Role_Name = "7";
            _testable.MC_Name = "5-1";
            _testable.FullCatName = "6-3";
            _testable.OCVal = new[] { 1, 2, 3};
            _testable.Text_OCVal = new[] { "11", "12", "13" };
            _testable.TXVal = new[] { "21", "22", "23" };

            // Act
            _testable.CopyToTargetData(destination);

            // Assert
            Assert.AreEqual(_testable.CT_ID, destination.CT_ID);
            Assert.AreEqual(_testable.BC_UID, destination.BC_UID);
            Assert.AreEqual(_testable.BC_ROLE_UID, destination.BC_ROLE_UID);
            Assert.AreEqual(_testable.BC_SEQ, destination.BC_SEQ);
            Assert.AreEqual(_testable.MC_Val, destination.MC_Val);
            Assert.AreEqual(_testable.CAT_UID, destination.CAT_UID);
            Assert.AreEqual(_testable.CT_Name, destination.CT_Name);
            Assert.AreEqual(_testable.Cat_Name, destination.Cat_Name);
            Assert.AreEqual(_testable.Role_Name, destination.Role_Name);
            Assert.AreEqual(_testable.MC_Name, destination.MC_Name);
            Assert.AreEqual(_testable.FullCatName, destination.FullCatName);
            Assert.AreEqual(_testable.CC_Name, destination.CC_Name);
            Assert.AreEqual(_testable.FullCCName, destination.FullCCName);
            Assert.AreEqual(false, destination.bGroupRow);
            Assert.AreEqual(string.Empty, destination.Grouping);
            Assert.AreEqual(_testable.OCVal, destination.OCVal);
            Assert.AreEqual(_testable.Text_OCVal, destination.Text_OCVal);
            Assert.AreEqual(_testable.TXVal, destination.TXVal);
        }


        [TestMethod]
        public void CopyToTargetData_DestinationNotNull_DeepCoppiesFields()
        {
            // Arrange
            var destination = new clsTargetRowData();
            _testable.zCost[0] = 18;
            _testable.zValue[1] = 24;
            _testable.zFTE[1] = 11;

            // Act
            _testable.CopyToTargetData(destination);

            // Assert
            Assert.AreNotSame(_testable.zCost, destination.zCost);
            Assert.AreNotSame(_testable.zValue, destination.zValue);
            Assert.AreNotSame(_testable.zFTE, destination.zFTE);
        }
    }
}