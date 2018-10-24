using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveCore.Tests.API.Notification
{
    [TestClass]
    public class NotificationTests
    {
        private IDisposable shimsContext;

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
