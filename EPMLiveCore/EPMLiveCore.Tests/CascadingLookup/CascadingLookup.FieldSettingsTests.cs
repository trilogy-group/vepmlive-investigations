using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.CascadingLookup
{
    [TestClass]
    public class CascadingLookup
    {
        private CascadingLookupFieldSettings cascadingLookupFieldSettings;
        private IDisposable shimsContext;
        private PrivateObject privateObject;

        [TestMethod]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            cascadingLookupFieldSettings = new CascadingLookupFieldSettings();
            privateObject = new PrivateObject(cascadingLookupFieldSettings);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }



    }
}
