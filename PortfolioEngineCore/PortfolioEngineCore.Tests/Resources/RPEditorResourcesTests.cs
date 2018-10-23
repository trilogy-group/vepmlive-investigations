using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Resources
{
    using Fakes;
    using PortfolioEngineCore;

    [TestClass]
    public class RPEditorResourcesTests
    {
        private IDisposable shimsContext;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
        }

        [TestMethod]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void BuildPlanResourcesGridXML()
        {
            // Arrange
            var resultStruct = new CStruct();
            resultStruct.Initialize("Main");
            var planResources = new ShimCStruct
            {
                GetSubStructString = name => new ShimCStruct
                {
                    GetSubStructString = structName => new ShimCStruct
                    {
                        GetListString = attr => new List<CStruct>
                        {

                        }
                    }
                }
            };

            // Act
            var result = RPEditorResources.BuildPlanResourcesGridXML(resultStruct, planResources);

            // Assert

        }
    }
}
