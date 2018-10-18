using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Resources
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ResourceRepositoryTests
    {
        private IDisposable shimsContext;

        [TestMethod]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
        }

        [TestMethod]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }


    }
}
