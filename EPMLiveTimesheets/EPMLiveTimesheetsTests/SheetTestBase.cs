using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPMLive.TestFakes.Utility;

namespace EPMLiveTimesheets.Tests
{
    public class SheetTestBase
    {
        private IDisposable _shims;
        protected AdoShims _adoShims;
        protected SharepointShims _sharepointShims;

        [TestInitialize]
        public void Initialize()
        {
            _shims = ShimsContext.Create();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shims?.Dispose();
        }
    }
}
