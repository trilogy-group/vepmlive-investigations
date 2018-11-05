using System;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveReportsAdmin.Layouts.EPMLive.Tests
{
    [TestClass]
    public class ViewLogDetailTests
    {
        private IDisposable _context;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void RaisePostBackEventTest()
        {
            // Arrange
            var isDisposeCalled = false;
            ShimControl.AllInstances.Dispose = _ => { isDisposeCalled = true; };

            // Act
            using (new ViewLogDetail())
            {
            }

            // Assert
            Assert.IsTrue(isDisposeCalled);
        }
    }
}