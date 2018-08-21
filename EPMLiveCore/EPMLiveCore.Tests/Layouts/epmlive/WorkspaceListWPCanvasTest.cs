using System;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLive.TestFakes.Utility;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass]
    public class WorkspaceListWPCanvasTest
    {
        private const string ServerRelativeUrl = "/";
        private const string FieldMainPanel = "mainPanel";
        private const string MethodPageLoad = "Page_Load";

        private IDisposable _shimsContext;
        private WorkspaceListWPCanvas _testEntity;
        private PrivateObject _testEntityPrivate;
        private SharepointShims _sharepointShims;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _sharepointShims = SharepointShims.ShimSharepointCalls();
            InitializeSharePoint();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void Dispose_WhenCalled_DisposesSubControls()
        {
            // Arrange
            var disposeCountOfLiteralControls = 0;
            var disposeCountOfPanel = 0;
            ShimControl.AllInstances.Dispose = instance =>
            {
                try
                {
                    if (instance is LiteralControl)
                    {
                        disposeCountOfLiteralControls++;
                    }
                    else if (instance is Panel)
                    {
                        disposeCountOfPanel++;
                    }
                }
                finally
                {
                    ShimsContext.ExecuteWithoutShims(() => instance.Dispose());
                }
            };

            var subControlsCountOfMainPanel = 0;

            // Act
            using (_testEntity = new WorkspaceListWPCanvas())
            {
                _testEntityPrivate = new PrivateObject(_testEntity);

                var mainPanel = new Panel();
                _testEntityPrivate.SetField(FieldMainPanel, mainPanel);
                _testEntityPrivate.Invoke(MethodPageLoad, this, EventArgs.Empty);

                subControlsCountOfMainPanel = mainPanel.Controls.Count;
            }

            // Assert
            _testEntity.ShouldSatisfyAllConditions(
                () => disposeCountOfLiteralControls.ShouldBe(subControlsCountOfMainPanel),
                () => disposeCountOfPanel.ShouldBe(1));
        }

        private void InitializeSharePoint()
        {
            var shimSpWeb = new ShimSPWeb()
            {
                ServerRelativeUrlGet = () => ServerRelativeUrl
            };

            var shimSpContext = new ShimSPContext()
            {
                WebGet = () => shimSpWeb
            };

            ShimSPContext.CurrentGet = () => shimSpContext;
        }
    }
}
