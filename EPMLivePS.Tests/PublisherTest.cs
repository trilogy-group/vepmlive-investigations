using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveEnterprise;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLivePS.Tests
{
    [TestClass]
    public class PublisherTest
    {
        private static readonly Guid DummyGuid = new Guid();
        private const string DummyCommand = "Dummy Command";
        private const string DummyName = "Dummy Name";
        private const string DummyString = "Dummy String";

        private const string CreateWindowsEventMethod = "CreateWindowsEvent";

        private PrivateObject _privateObject;
        private Publisher _publisher;
        private IDisposable _context;

        [TestInitialize]
        public void Setup()
        {
            _context = ShimsContext.Create();

            //ShimPublisher.ConstructorPSContextInfoProjectPostPublishEventArgs = (publisher, info, arg3) => new ShimPublisher(publisher);
            //_publisher = new Publisher(null, null);
            _privateObject = new PrivateObject(_publisher);
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void CreateWindowsEvent_ShouldCreateEventLog_ReturnsEventLog()
        {
            // Arrange
            ShimEventLog.ConstructorString = (_, logName) => new ShimEventLog();
            ShimEventLog.SourceExistsString = source => false;
            ShimEventLog.AllInstances.SourceSetString = (_, source) => { };
            ShimEventLog.AllInstances.MachineNameSetString = (_, machineName) => { };

            // Act
            var result = _privateObject.Invoke(CreateWindowsEventMethod, DummyName, DummyCommand);

            // Assert
            Assert.IsInstanceOfType(result, typeof(EventLog));
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void InitializeId_WhenSqlTransactionIsNull_ThrowsException()
        //{
        //    // Arrange
        //    _transaction = null;

        //    // Act
        //    _privateObject.Invoke(InitializeIdMethod, _transaction, _sCommand, _id);

        //    // Assert
        //    // Expected ArgumentNullException
        //}
    }
}
