using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets.Layouts.epmlive;

namespace EPMLiveTimesheets.Tests.Layouts
{
    [TestClass, ExcludeFromCodeCoverage]
    public class WorkLogTest
    {
        private IDisposable _shimsContext;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void Dispose_Always_DisposesHoursPlaceHolder()
        {
            // Arrange
            var isDisposeCalled = false;
            ShimControl.AllInstances.Dispose = _ =>
            {
                isDisposeCalled = true;
            };

            // Act
            using (var workLog = new WorkLog())
            { }

            // Assert
            isDisposeCalled.ShouldBeTrue();
        }
    }
}
