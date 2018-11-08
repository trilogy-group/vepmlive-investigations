using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveWebParts.Tests.WebPageCode
{
    [TestClass]
    public class GetGanttItemsTests
    {
        private IDisposable shimsContext;
        private getganttitems getganttitems;

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
