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
    public class PsSubSettingsButton1ClickTest
    {
        private MethodInfo _buttoClick1Method;
        private pspubsettings _pspubsettings;
        private EventArgs _args;
        private IDisposable _shimsContext;
        protected AdoShims _adoShims;
        protected SharepointShims _sharepointShims;

        [SetUp]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            _buttoClick1Method = typeof(pspubsettings).GetMethod("Button1_Click", BindingFlags.Instance | BindingFlags.NonPublic);
            _pspubsettings = new pspubsettings();
            _args = new EventArgs();
            _adoShims = AdoShims.ShimAdoNetCalls();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
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
            _buttoClick1Method.Invoke(_pspubsettings, new object[] {null, _args});

            // Assert
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
            Assert.AreEqual(
                "select pubType,weburl from publishercheck where projectguid=@projectguid",
                _adoShims.CommandsExecuted[0].CommandText);
            Assert.AreEqual(
                "UPDATE publishercheck set pubtype=@pubtype where projectguid=@projectguid",
                _adoShims.CommandsExecuted[1].CommandText);
        }

        [Test]
        public void PageLoad_NoRead_AdoDisposed()
        {
            // Arrange
            SetupShims(false, _pspubsettings);

            // Act
            _buttoClick1Method.Invoke(_pspubsettings, new object[] { null, _args });

            // Assert
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
            Assert.AreEqual(
                "select pubType,weburl from publishercheck where projectguid=@projectguid",
                _adoShims.CommandsExecuted[0].CommandText);
            Assert.AreEqual(
                "INSERT INTO publishercheck (projectguid,checkbit,pubType,weburl, projectname) " +
                "VALUES (@projectguid,1,@pubtype,@weburl,@projectname)",
                _adoShims.CommandsExecuted[1].CommandText);
        }

        private void SetupShims(bool read, pspubsettings page)
        {
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) =>
            {
                var result = string.Empty;
                return result;
            };
            ShimSqlDataReader.AllInstances.Read = _ => read;
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
