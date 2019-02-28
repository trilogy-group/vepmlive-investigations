using System;
using System.ComponentModel.Fakes;
using System.Diagnostics.Fakes;
using EPMLiveReportsAdmin;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.QualityTools.Testing.Fakes.Shims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests
{
    [TestClass]
    public class LstEventsTests
    {
        private const string LogEntryMethodName = "LogEntry";
        private const string ExceptionMessage = "DummyExceptionMessage";
        private const string Source = "Tests";
        private string _actualExceptionMessage;

        private IDisposable _context;
        private bool _disposeWasCalled;
        private LstEvents _lstEvents;
        private PrivateObject _privateObject;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();
            _lstEvents = new LstEvents();
            _privateObject = new PrivateObject(_lstEvents);
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void LogEntry_Disposes()
        {
            // Arrange
            ArrangeLogEntry();

            // Act
            Action action = () => _privateObject.Invoke(LogEntryMethodName, new InvalidOperationException(ExceptionMessage), Source);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldNotThrow(),
                () => _disposeWasCalled.ShouldBeTrue(),
                () => _actualExceptionMessage.ShouldContain(ExceptionMessage));
        }

        private void ArrangeLogEntry()
        {
            ShimEventLog.Behavior = ShimBehaviors.DefaultValue;
            ShimEventLog.ConstructorStringStringString = (_1, _2, _3, _4) => new ShimComponent(new ShimEventLog());
            ShimEventLog.AllInstances.WriteEntryStringEventLogEntryTypeInt32 = (_1, str, _3, _4) => _actualExceptionMessage = str;

            _disposeWasCalled = false;
            ShimComponent.AllInstances.Dispose = _ => _disposeWasCalled = true;
        }

        [TestMethod]
        public void LogEntry_Throws_StillDisposes()
        {
            // Arrange
            ArrangeLogEntry();
            Exception exception = null;

            // Act
            Action action = () => _privateObject.Invoke(LogEntryMethodName, exception, Source);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => action.ShouldThrow<NullReferenceException>(),
                () => _disposeWasCalled.ShouldBeTrue(),
                () => _actualExceptionMessage.ShouldBeNullOrEmpty());
        }
    }
}