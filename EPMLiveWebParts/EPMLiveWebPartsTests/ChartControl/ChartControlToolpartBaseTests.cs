using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveWebParts.Tests.ChartControl
{
    [TestClass]
    public class ChartControlToolpartBaseTests
    {
        private IDisposable shimsContext;
        private ChartControlToolpartBase chartControlToolpartBase;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }



    }
}
