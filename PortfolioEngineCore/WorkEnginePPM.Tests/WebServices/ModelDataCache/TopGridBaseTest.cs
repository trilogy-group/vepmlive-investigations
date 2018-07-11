using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Tests.TestDoubles;

namespace WorkEnginePPM.Tests.WebServices.ModelDataCache
{
    [TestClass]
    public class TopGridBaseTest
    {
        private IDisposable _shimsContext;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            ShimCStruct.AllInstances.CreateSubStructString = (instance, name) => new ShimCStruct();
        }

        private TopGridBaseTestDouble CreateGridBase()
        {
            return new TopGridBaseTestDouble();
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void RemoveNastyCharacters_InputNull_Throws()
        {
            // Arrange
            const string input = null;
            var gridBase = CreateGridBase();

            try
            {
                // Act
                gridBase.RemoveNastyCharacters(input);
            }
            // Assert
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void RemoveNastyCharacters_InputHasNastyCharacters_Removes()
        {
            // Arrange
            const string input = "valid" + "!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\";
            var gridBase = CreateGridBase();

            // Act
            var result = gridBase.RemoveNastyCharacters(input);

            // Assert
            Assert.AreEqual("valid", result);
        }
    }
}
