using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass]
    public class CostTypesTests
    {
        private IDisposable shimsContext;
        private CostTypes costTypes;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            costTypes = new CostTypes();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        

    }
}
