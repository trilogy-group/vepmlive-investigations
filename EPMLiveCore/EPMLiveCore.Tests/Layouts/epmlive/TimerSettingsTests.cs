using System;
using System.ComponentModel.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TimerSettingsTests
    {
        private const string DummyUrl = "http://xyz.com";
        private const string LoadData = "loadData";
        private const string BtnRunNowClick = "btnRunNow_Click";
        private const string SaveSettings = "saveSettings";
        private const int DummyValue = 1;
        private IDisposable _shimsObject;
        private timersettings _testObj;
        private PrivateObject _privateObj;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new timersettings();
            _privateObj = new PrivateObject(_testObj);
            SetupShims();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
            _testObj?.Dispose();
            _privateObj = null;
        }

        private void SetupShims()
        {
            var allFields = _testObj.GetType()
               .GetFields(
                    BindingFlags.Instance |
                    BindingFlags.NonPublic)
               .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }

            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlReferrerGet = () => new Uri(DummyUrl)
                }
            };

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
        }

        [TestMethod]
        public void LoadData_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            const int ExpectedSqlCommandCount = 2;
            const int ExpectedSqlConnectionCount = 1;

            var sqlCommandCtorCallCount = 0;
            var sqlConnectionCtorCallCount = 0;
            var sqlConnectionDisposedCount = 0;
            var sqlCommandDisposedCount = 0;

            var spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite
                {
                    WebApplicationGet = () => new ShimSPWebApplication()
                }
            };
            spWeb.Instance.Site.WebApplication.Id = Guid.Empty;

            ShimSPSecurity.RunWithElevatedPrivilegesWaitCallbackObject = (_, __) => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };

            var shimSqlDataReader = new ShimSqlDataReader
            {
                FieldCountGet = () => DummyValue,
                GetGuidInt32 = columnIndex => Guid.Empty
            };

            var readMethodSwitcher = false;
            shimSqlDataReader.Read = () => readMethodSwitcher = !readMethodSwitcher;
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => sqlCommandCtorCallCount++;
            ShimSqlConnection.ConstructorString = (_, __) => sqlConnectionCtorCallCount++;
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is SqlConnection)
                {
                    sqlConnectionDisposedCount++;
                }

                if (component is SqlCommand)
                {
                    sqlCommandDisposedCount++;
                }
            };

            ShimSqlCommand.AllInstances.ExecuteReader = _ => shimSqlDataReader.Instance;

            // Act
            _privateObj.Invoke(LoadData, spWeb.Instance);
            _testObj?.Dispose();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCallCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlCommandDisposedCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlConnectionCtorCallCount.ShouldBe(ExpectedSqlConnectionCount),
                () => sqlConnectionDisposedCount.ShouldBe(ExpectedSqlConnectionCount));
        }

        [TestMethod]
        public void BtnRunNow_Click_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            const int ExpectedSqlCommandCount = 2;
            const int ExpectedSqlConnectionCount = 1;

            var sqlCommandCtorCallCount = 0;
            var sqlConnectionCtorCallCount = 0;
            var sqlConnectionDisposedCount = 0;
            var sqlCommandDisposedCount = 0;

            var spSite = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication()
            };

            spSite.Instance.WebApplication.Id = Guid.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => spSite.Instance,
                WebGet = () => new ShimSPWeb().Instance
            };

            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, __, ___) => true;

            var shimSqlDataReader = new ShimSqlDataReader
            {
                FieldCountGet = () => DummyValue,
                GetGuidInt32 = columnIndex => Guid.Empty
            };

            var readMethodSwitcher = false;
            shimSqlDataReader.Read = () => readMethodSwitcher = !readMethodSwitcher;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) => sqlCommandCtorCallCount++;
            ShimSqlConnection.ConstructorString = (connection, s) => sqlConnectionCtorCallCount++;
            ShimSqlConnection.AllInstances.Close = connection => { };
            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is SqlConnection)
                {
                    sqlConnectionDisposedCount++;
                }

                if (component is SqlCommand)
                {
                    sqlCommandDisposedCount++;
                }
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance => shimSqlDataReader.Instance;

            // Act
            _privateObj.Invoke(BtnRunNowClick, null, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCallCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlCommandDisposedCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlConnectionCtorCallCount.ShouldBe(ExpectedSqlConnectionCount),
                () => sqlConnectionDisposedCount.ShouldBe(ExpectedSqlConnectionCount));
        }

        [TestMethod]
        public void saveSettings_DataReaderRead_VerifyMemoryLeak()
        {
            // Arrange
            const int ExpectedSqlCommandCount = 2;
            const int ExpectedSqlConnectionCount = 1;

            var sqlCommandCtorCallCount = 0;
            var sqlConnectionCtorCallCount = 0;
            var expectedIntListId = Guid.Empty;
            var sqlConnectionDisposedCount = 0;
            var sqlCommandDisposedCount = 0;

            var spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite
                {
                    WebApplicationGet = () => new ShimSPWebApplication()
                }
            };

            spWeb.Instance.Site.WebApplication.Id = Guid.Empty;

            var spSite = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication()
            };

            spSite.Instance.WebApplication.Id = Guid.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => spSite.Instance,
                WebGet = () => spWeb.Instance
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, __, ___) => true;

            var shimSqlDataReader = new ShimSqlDataReader
            {
                FieldCountGet = () => DummyValue,
                GetGuidInt32 = columnIndex => expectedIntListId,
                Read = () => true
            };

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) => sqlCommandCtorCallCount++;
            ShimSqlConnection.ConstructorString = (connection, s) => sqlConnectionCtorCallCount++;
            ShimSqlConnection.AllInstances.Close = connection => { };
            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is SqlConnection)
                {
                    sqlConnectionDisposedCount++;
                }

                if (component is SqlCommand)
                {
                    sqlCommandDisposedCount++;
                }
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance => shimSqlDataReader.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => DummyValue;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, __, ___) => { };

            // Act
            _privateObj.Invoke(SaveSettings, spWeb.Instance);
            _testObj?.Dispose();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCallCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlCommandDisposedCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlConnectionCtorCallCount.ShouldBe(ExpectedSqlConnectionCount),
                () => sqlConnectionDisposedCount.ShouldBe(ExpectedSqlConnectionCount));
        }

        [TestMethod]
        public void saveSettings_DataReaderNoRead_VerifyMemoryLeak()
        {
            // Arrange
            const int ExpectedSqlCommandCount = 2;
            const int ExpectedSqlConnectionCount = 1;

            var sqlCommandCtorCallCount = 0;
            var sqlConnectionCtorCallCount = 0;
            var expectedIntListId = Guid.Empty;
            var sqlConnectionDisposedCount = 0;
            var sqlCommandDisposedCount = 0;

            var spWeb = new ShimSPWeb
            {
                SiteGet = () => new ShimSPSite
                {
                    WebApplicationGet = () => new ShimSPWebApplication()
                }
            };

            spWeb.Instance.Site.WebApplication.Id = Guid.Empty;

            var spSite = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication()
            };

            spSite.Instance.WebApplication.Id = Guid.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => spSite.Instance,
                WebGet = () => spWeb.Instance
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, __, ___) => true;

            var shimSqlDataReader = new ShimSqlDataReader
            {
                FieldCountGet = () => DummyValue,
                GetGuidInt32 = columnIndex => expectedIntListId,
                Read = () => false
            };

            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, connection) => sqlCommandCtorCallCount++;
            ShimSqlConnection.ConstructorString = (connection, s) => sqlConnectionCtorCallCount++;
            ShimSqlConnection.AllInstances.Close = connection => { };
            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is SqlConnection)
                {
                    sqlConnectionDisposedCount++;
                }

                if (component is SqlCommand)
                {
                    sqlCommandDisposedCount++;
                }
            };

            ShimSqlCommand.AllInstances.ExecuteReader = instance => shimSqlDataReader.Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => DummyValue;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, __, ___) => { };

            // Act
            _privateObj.Invoke(SaveSettings, spWeb.Instance);
            _testObj?.Dispose();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlCommandCtorCallCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlCommandDisposedCount.ShouldBe(ExpectedSqlCommandCount),
                () => sqlConnectionCtorCallCount.ShouldBe(ExpectedSqlConnectionCount),
                () => sqlConnectionDisposedCount.ShouldBe(ExpectedSqlConnectionCount));
        }
    }
}
