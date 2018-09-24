using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.UplandPlatformAPI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass]
    public class PlatformIntegrationEventTest
    {
        private const string FieldUrl = "url";
        private const string ValidUrl = "http://epmlive.com";

        private PlatformIntegrationEvent _platformIntegrationEvent;
        private PrivateObject _privateObject;
        private IDisposable _context;
        private int _connectionOpenedCallCount;
        private int _executeReaderCallCount;
        private int _executeNonQueryCallCount;
        private int _connectionDisposeCallCount;
        private int _sqlCommandDisposeCallCount;

        [TestInitialize]
        public void Setup()
        {
            _connectionOpenedCallCount = 0;
            _executeReaderCallCount = 0;
            _executeNonQueryCallCount = 0;
            _connectionDisposeCallCount = 0;
            _sqlCommandDisposeCallCount = 0;

            _context = ShimsContext.Create();
            _platformIntegrationEvent = new PlatformIntegrationEvent();
            _privateObject = new PrivateObject(_platformIntegrationEvent);
        }

        [TestCleanup]
        public void TearDown()
        {
            _context?.Dispose();
        }

        [TestMethod]
        public void ItemUpdated_EmptyUrl_SqlConnectionAndCommandDisposed()
        {
            // Arrange
            var properties = SetupShimsAndCreateProperties();

            // Act
            _platformIntegrationEvent.ItemUpdated(properties.Instance);

            // Assert
            _connectionDisposeCallCount.ShouldSatisfyAllConditions(
                () => _connectionOpenedCallCount.ShouldBe(1),
                () => _executeNonQueryCallCount.ShouldBe(1),
                () => _executeReaderCallCount.ShouldBe(1),
                () => _connectionDisposeCallCount.ShouldBe(1),
                () => _sqlCommandDisposeCallCount.ShouldBe(1));
        }

        [TestMethod]
        public void ItemUpdated_NonEmptyUrlWithException_SqlConnectionAndCommandDisposed()
        {
            // Arrange
            var properties = InitializeUrlAndSetupShims();
            ShimIntegrationAPI.AllInstances.PostItemSimpleStringString = (_, __, ___) =>
            {
                throw new InvalidOperationException();
            };

            // Act
            _platformIntegrationEvent.ItemUpdated(properties.Instance);

            // Assert
            _connectionDisposeCallCount.ShouldSatisfyAllConditions(
                () => _connectionOpenedCallCount.ShouldBe(2),
                () => _executeNonQueryCallCount.ShouldBe(2),
                () => _executeReaderCallCount.ShouldBe(1),
                () => _connectionDisposeCallCount.ShouldBe(2),
                () => _sqlCommandDisposeCallCount.ShouldBe(2));
        }

        [TestMethod]
        public void ItemUpdated_NonEmptyUrl_SqlConnectionAndCommandDisposed()
        {
            // Arrange
            var properties = InitializeUrlAndSetupShims();

            // Act
            _platformIntegrationEvent.ItemUpdated(properties.Instance);

            // Assert
            _connectionDisposeCallCount.ShouldSatisfyAllConditions(
                () => _connectionOpenedCallCount.ShouldBe(2),
                () => _executeNonQueryCallCount.ShouldBe(2),
                () => _executeReaderCallCount.ShouldBe(1),
                () => _connectionDisposeCallCount.ShouldBe(2),
                () => _sqlCommandDisposeCallCount.ShouldBe(2));
        }

        [TestMethod]
        public void ItemDeleting_NonEmptyUrlWithException_SqlConnectionAndCommandDisposed()
        {
            // Arrange
            var properties = InitializeUrlAndSetupShims();
            ShimIntegrationAPI.AllInstances.DeleteItemStringString = (_, __, ___) =>
            {
                throw new InvalidOperationException();
            };

            // Act
            _platformIntegrationEvent.ItemDeleting(properties.Instance);

            // Assert
            _connectionDisposeCallCount.ShouldSatisfyAllConditions(
                () => _connectionOpenedCallCount.ShouldBe(2),
                () => _executeNonQueryCallCount.ShouldBe(2),
                () => _executeReaderCallCount.ShouldBe(1),
                () => _connectionDisposeCallCount.ShouldBe(2),
                () => _sqlCommandDisposeCallCount.ShouldBe(2));
        }

        [TestMethod]
        public void ItemDeleting_NonEmptyUrl_SqlConnectionAndCommandDisposed()
        {
            // Arrange
            var properties = InitializeUrlAndSetupShims();

            // Act
            _platformIntegrationEvent.ItemDeleting(properties.Instance);

            // Assert
            _connectionDisposeCallCount.ShouldSatisfyAllConditions(
                () => _connectionOpenedCallCount.ShouldBe(2),
                () => _executeNonQueryCallCount.ShouldBe(2),
                () => _executeReaderCallCount.ShouldBe(1),
                () => _connectionDisposeCallCount.ShouldBe(2),
                () => _sqlCommandDisposeCallCount.ShouldBe(2));
        }

        private ShimSPItemEventProperties InitializeUrlAndSetupShims()
        {
            _privateObject.SetFieldOrProperty(FieldUrl, ValidUrl);
            return SetupShimsAndCreateProperties();
        }

        private ShimSPItemEventProperties SetupShimsAndCreateProperties()
        {            
            SetupShims();
            return CreateProperties();
        }

        private void SetupShims()
        {
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                _connectionOpenedCallCount++;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                _executeReaderCallCount++;
                return new ShimSqlDataReader();
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                _executeNonQueryCallCount++;
                return 0;
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ =>
            {
                _.Invoke();
            };
            ShimSqlConnection.AllInstances.DisposeBoolean = (_, __) =>
            {
                _connectionDisposeCallCount++;
            };
            ShimSqlCommand.AllInstances.DisposeBoolean = (_, __) =>
            {
                _sqlCommandDisposeCallCount++;
            };
            ShimIntegrationAPI.AllInstances.PostItemSimpleStringString = (_, __, ___) => null;
            ShimIntegrationAPI.AllInstances.DeleteItemStringString = (_, __, ___) => null;
        }

        private static ShimSPItemEventProperties CreateProperties()
        {
            var webApplication = new SPWebApplication()
            {
                Id = Guid.Empty
            };
            var shimSPSite = new ShimSPSite()
            {
                WebApplicationGet = () => webApplication
            };
            return new ShimSPItemEventProperties()
            {
                SiteGet = () => shimSPSite
            };
        }
    }
}
