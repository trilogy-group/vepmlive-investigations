using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Tests.Testables;

namespace PortfolioEngineCore.Tests.Analyzers
{
    [TestClass]
    public class BaseDetailRowDataTest
    {
        private const int _arraySize = 10;
        private BaseDetailRowDataTestable _testable;

        [TestInitialize]
        public void SetUp()
        {
            _testable = new BaseDetailRowDataTestable(_arraySize);
        }

        [TestCleanup]
        public void TearDown()
        {

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
    }
}
