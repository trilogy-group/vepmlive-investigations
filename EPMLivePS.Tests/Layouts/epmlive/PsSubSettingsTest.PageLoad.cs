using System;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Fakes;
using EPMLiveEnterprise.Layouts.epmlive;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using NUnit.Framework;

namespace EPMLivePS.Tests.Layouts.epmlive
{
    [TestFixture]
    public class PsSubSettingsPageLoadTest
    {
        private MethodInfo _pageLoadMethod;
        private pspubsettings _pspubsettings;
        private EventArgs _args;
        private IDisposable _shimsContext;
        protected AdoShims _adoShims;
        protected SharepointShims _sharepointShims;
        private bool _getInt32Called;

        [SetUp]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _pageLoadMethod = typeof(pspubsettings).GetMethod("Page_Load", BindingFlags.Instance | BindingFlags.NonPublic);
            _pspubsettings = new pspubsettings();
            _args = new EventArgs();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
            _getInt32Called = false;
        }

        [TearDown]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [Test]
        public void PageLoad_Read_AdoDisposed()
        {
            // Arrange
            SetupShims(true, _pspubsettings);

            // Act
            _pageLoadMethod.Invoke(_pspubsettings, new object[] {null, _args});

            // Assert
            Assert.IsTrue(_getInt32Called);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(1, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
            Assert.AreEqual(
                "select pubType,weburl from publishercheck where projectguid=@projectguid",
                _adoShims.CommandsDisposed[0].CommandText);
        }

        [Test]
        public void PageLoad_NoRead_AdoDisposed()
        {
            // Arrange
            SetupShims(false, _pspubsettings);

            // Act
            _pageLoadMethod.Invoke(_pspubsettings, new object[] { null, _args });

            // Assert
            Assert.IsFalse(_getInt32Called);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(1, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
            Assert.AreEqual(
                "select pubType,weburl from publishercheck where projectguid=@projectguid",
                _adoShims.CommandsDisposed[0].CommandText);
        }

        private void SetupShims(bool read, pspubsettings page)
        {
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) =>
            {
                var result = string.Empty;
                return result;
            };
            ShimSqlDataReader.AllInstances.Read = _ => read;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) =>
            {
                _getInt32Called = true;
                return 123;
            };
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimCoreFunctions.getConnectionStringGuid = guid => string.Empty;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, key) =>
            {
                var result = string.Empty;
                if (key == "epmlivepub-lock")
                {
                    result = "1";
                }
                else if (key == "EPMLivePub-Type")
                {
                    result = "SampleValue";
                }
                return result;
            };

            ShimSPContext.AllInstances.SiteGet = context => _sharepointShims.SiteShim;
            _sharepointShims.SiteShim.WebApplicationGet = () => _sharepointShims.ApplicationShim;

             
            var field = typeof(pspubsettings).GetField("ddlPubType", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(page, new System.Web.UI.WebControls.DropDownList());
        }
    }
}
