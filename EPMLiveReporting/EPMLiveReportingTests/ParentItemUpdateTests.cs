using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Fakes;
using EPMLiveReportsAdmin;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ParentItemUpdateTests
    {
        private IDisposable _shimsContext;
        private bool _isConnectionOpenedCalled;
        private bool _isConnectionDisposeCalled;
        private int _isExecuteNonQueryCallCount;
        private int _sqlCommandDisposeCallCount;

        [TestInitialize]
        public void Setup()
        {
            _isConnectionOpenedCalled = false;
            _isConnectionDisposeCalled = false;
            _isExecuteNonQueryCallCount = 0;
            _sqlCommandDisposeCallCount = 0;
            _shimsContext = ShimsContext.Create();
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void UpdateParent_Update_ConnectionAndCommandsDisposed()
        {
            // Arrange
            SetupShims(true);
            var properties = CreateSPItemEventProperties();

            // Act
            ParentItemUpdate.UpdateParent(properties);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _isConnectionOpenedCalled.ShouldBeTrue(),
                () => _isExecuteNonQueryCallCount.ShouldBe(2),
                () => _isConnectionDisposeCalled.ShouldBeTrue(),
                () => _sqlCommandDisposeCallCount.ShouldBe(2));
        }

        [TestMethod]
        public void UpdateParent_Insert_ConnectionAndCommandsDisposed()
        {
            // Arrange
            SetupShims(false);
            var properties = CreateSPItemEventProperties();

            // Act
            ParentItemUpdate.UpdateParent(properties);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _isConnectionOpenedCalled.ShouldBeTrue(),
                () => _isExecuteNonQueryCallCount.ShouldBe(2),
                () => _isConnectionDisposeCalled.ShouldBeTrue(),
                () => _sqlCommandDisposeCallCount.ShouldBe(2));
        }

        private void SetupShims(bool canRead)
        {
            var fields = new SPFieldLookup[1];
            fields[0] = new ShimSPFieldLookup()
            {
                LookupListGet = () => Guid.Empty.ToString()
            };

            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => fields.GetEnumerator();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => "DummyString";
            ShimCoreFunctions.getConnectionStringGuid = _ => string.Empty;
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => 0;
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();

            ShimSqlConnection.AllInstances.Open = _ =>
            {
                _isConnectionOpenedCalled = true;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                _isExecuteNonQueryCallCount++;
                return 0;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                _isExecuteNonQueryCallCount++;
                return new ShimSqlDataReader();
            };
            ShimSqlConnection.AllInstances.DisposeBoolean = (_, __) =>
            {
                _isConnectionDisposeCalled = true;
            };
            ShimSqlCommand.AllInstances.DisposeBoolean = (_, __) =>
            {
                _sqlCommandDisposeCallCount++;
            };
            ShimSqlDataReader.AllInstances.Read = _ => canRead;
        }

        private static ShimSPItemEventProperties CreateSPItemEventProperties()
        {
            return new ShimSPItemEventProperties()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        WebApplicationGet = () => new ShimSPWebApplication()
                    },
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetGuid = _ => new ShimSPList()
                        {
                            TitleGet = () => "DummyString",
                            IDGet = () => Guid.Empty
                        }
                    }
                },
                SiteGet = () => new ShimSPSite(),
                ListGet = () => new ShimSPList()
                {
                    FieldsGet = () => new ShimSPFieldCollection()
                },
                ListItemGet = () => new ShimSPListItem()
                {
                    ItemGetGuid = guid => guid
                }
            };
        }
    }
}
