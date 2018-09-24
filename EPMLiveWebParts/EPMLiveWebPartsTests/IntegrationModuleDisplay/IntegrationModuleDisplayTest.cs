using System;
using System.Data.SqlClient.Fakes;
using System.Text;
using System.Web.UI;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPMLiveWebParts.Tests.IntegrationModuleDisplay
{
    using EPMLiveCore.Fakes;
    using EPMLiveWebParts;

    [TestClass]
    public class IntegrationModuleDisplayTest
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyUrl = "https://duymy.org/";
        private const string RenderWebPartMethodName = "RenderWebPart";
        private static int Count;
        private IntegrationModuleDisplay integrationModuleDisplay;
        private IDisposable shimContext;
        private PrivateObject privateObject;
        private HtmlTextWriter textWriter;
        private StringBuilder stringBuilder;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            integrationModuleDisplay = new IntegrationModuleDisplay();
            privateObject = new PrivateObject(integrationModuleDisplay);
            textWriter = new ShimHtmlTextWriter();
            stringBuilder = new StringBuilder();
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
            integrationModuleDisplay?.Dispose();
            textWriter?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.ListIdGet = _ => DummyGuid;
            ShimSPContext.AllInstances.ItemGet = _ => new ShimSPListItem();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPPersistedObject.AllInstances.IdGet = _ => DummyGuid;
            ShimSqlConnection.ConstructorString = (_, connectionString) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => ++Count <= 2,
                GetStringInt32 = index => DummyUrl,
                GetGuidInt32 = index => DummyGuid
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyUrl;
            ShimHtmlTextWriter.AllInstances.WriteLineString = (_, content) => stringBuilder.Append(content);
        }

        [TestMethod]
        public void RenderWebPart_OnSuccess_ShouldWriteContent()
        {
            // Arrange, Act
            privateObject.Invoke(RenderWebPartMethodName, textWriter);
            var outputContent = stringBuilder.ToString();

            // Assert
            Assert.IsNotNull(outputContent);
            Assert.IsTrue(outputContent.Contains(DummyGuid.ToString()));
            Assert.IsTrue(outputContent.Contains(DummyUrl));
        }

        [TestMethod]
        public void RenderWebPart_OnException_ShouldWriteContent()
        {
            // Arrange
            const string DummyMessage = "Dummy Message for Exception";
            ShimSPContext.AllInstances.ItemGet = _ =>
            {
                throw new Exception(DummyMessage);
            };

            // Act
            privateObject.Invoke(RenderWebPartMethodName, textWriter);
            var outputContent = stringBuilder.ToString();

            // Assert
            Assert.IsNotNull(outputContent);
            Assert.IsTrue(outputContent.Contains(DummyMessage));
        }

        [TestMethod]
        public void RenderWebPart_CurrentSPContextItemNull_ShouldWriteContentMethod()
        {
            // Arrange
            const string ExpectedContent = "This web part must be used on a display form";
            ShimSPContext.AllInstances.ItemGet = _ => null;

            // Act
            privateObject.Invoke(RenderWebPartMethodName, textWriter);
            var outputContent = stringBuilder.ToString();

            // Assert
            Assert.IsNotNull(outputContent);
            Assert.AreEqual(ExpectedContent, outputContent);
        }
    }
}
