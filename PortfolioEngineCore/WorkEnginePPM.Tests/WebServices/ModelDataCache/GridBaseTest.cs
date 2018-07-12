using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Tests.TestDoubles;

namespace WorkEnginePPM.Tests.WebServices.ModelDataCache
{
    [TestClass]
    public class GridBaseTest
    {
        private IDisposable _shimsContext;

        private ShimCStruct _header1Shim;
        private ShimCStruct _header2Shim;
        private ShimCStruct _periodColsShim;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _header1Shim = new ShimCStruct();
            _header2Shim = new ShimCStruct();
            _periodColsShim = new ShimCStruct();

            ShimCStruct.AllInstances.CreateSubStructString = (instance, name) => new ShimCStruct();
        }

        private GridBaseTestDouble CreateGridBase()
        {
            return new GridBaseTestDouble(_header1Shim, _header2Shim, _periodColsShim);
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void GetString_Always_ReturnsGeneratedConstructorXml()
        {
            // Arrange
            const string expectedResult = "test-xml";
            ShimCStruct.AllInstances.XML = (instance) => expectedResult;
            var gridBase = CreateGridBase();

            // Act
            var result = gridBase.GetString();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AddPeriodColumn_UseQuantity_Header1AttributesAdded()
        {
            // Arrange
            const string idParameter = "test-id";
            const string nameParameter = "test-name";
            const bool showFTEParameter = false;
            const bool useQuantityParameter = true;
            const bool useCostParameter = false;
            const bool showCostsDescendingParameter = false;

            var attributes = new Dictionary<string, string>();

            _header1Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumn(idParameter, nameParameter, showFTEParameter, useQuantityParameter, useCostParameter, showCostsDescendingParameter);

            // Assert
            Assert.AreEqual(1, attributes.Count);
            Assert.AreEqual(nameParameter, attributes["P" + idParameter + "V"]);
        }

        [TestMethod]
        public void AddPeriodColumn_NotUseQuantity_Header1AttributesAdded()
        {
            // Arrange
            const string idParameter = "test-id";
            const string nameParameter = "test-name";
            const bool showFTEParameter = false;
            const bool useQuantityParameter = false;
            const bool useCostParameter = false;
            const bool showCostsDescendingParameter = false;

            var attributes = new Dictionary<string, string>();

            _header1Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumn(idParameter, nameParameter, showFTEParameter, useQuantityParameter, useCostParameter, showCostsDescendingParameter);

            // Assert
            Assert.AreEqual(1, attributes.Count);
            Assert.AreEqual(nameParameter, attributes["P" + idParameter + "C"]);
        }

        [TestMethod]
        public void AddPeriodColumn_UseQuantity_Header2AttributesAdded()
        {
            // Arrange
            const string idParameter = "test-id";
            const string nameParameter = "test-name";
            const bool showFTEParameter = false;
            const bool useQuantityParameter = true;
            const bool useCostParameter = false;
            const bool showCostsDescendingParameter = false;

            var attributes = new Dictionary<string, string>();

            _header2Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumn(idParameter, nameParameter, showFTEParameter, useQuantityParameter, useCostParameter, showCostsDescendingParameter);

            // Assert
            Assert.AreEqual(1, attributes.Count);
            Assert.AreEqual(" Qty ", attributes["P" + idParameter + "V"]);
        }

        [TestMethod]
        public void AddPeriodColumn_NotUseQuantity_Header2AttributesAdded()
        {
            // Arrange
            const string idParameter = "test-id";
            const string nameParameter = "test-name";
            const bool showFTEParameter = false;
            const bool useQuantityParameter = false;
            const bool useCostParameter = false;
            const bool showCostsDescendingParameter = false;

            var attributes = new Dictionary<string, string>();

            _header2Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumn(idParameter, nameParameter, showFTEParameter, useQuantityParameter, useCostParameter, showCostsDescendingParameter);

            // Assert
            Assert.AreEqual(0, attributes.Count);
        }
    }
}
