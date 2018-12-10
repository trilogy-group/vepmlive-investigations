using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.HtmlControls.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using Workspacecenter = EPMLiveWebParts.WorkSpaceCenter.WorkSpaceCenter;

namespace EPMLiveWebParts.Tests.WorkSpaceCenter
{
    [TestClass]
    public class WorkSpaceCenterTests
    {
        //private const int Id = 1;
        //private const string One = "1";
        //private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodPageLoad = "Page_Load";
        private Workspacecenter _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private bool _didRegisterStyleFile;
        private bool _didRegisterScript;
        private StringBuilder _responseBuilder;
        private StringWriter _stringWriter;
        private HtmlTextWriter _responseWriter;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            _didRegisterStyleFile = false;
            _didRegisterScript = false;
            PrepareSpContext();
            ShimPageMethods();

            _responseBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_responseBuilder);
            _responseWriter = new HtmlTextWriter(_stringWriter);

            _testObject = new Workspacecenter { Page = new Page() };
            _privateObject = new PrivateObject(_testObject);

            _privateObject.Invoke(MethodOnInit, new object[] { EventArgs.Empty });
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _responseWriter?.Dispose();
            _stringWriter?.Dispose();
        }

        [TestMethod]
        public void RenderControl_Invoke_WritesContent()
        {
            // Arrange
            _privateObject.Invoke(MethodPageLoad, new object[] { new object(), EventArgs.Empty });

            // Act
            _testObject.RenderControl(_responseWriter);

            // Assert
            var result = _responseBuilder.ToString();
            result.ShouldNotBeNull();
            this.ShouldSatisfyAllConditions(
                () => _didRegisterStyleFile.ShouldBeTrue(),
                () => _didRegisterScript.ShouldBeTrue(),
                () => result.ShouldContainWithoutWhitespace("<div><style type=\"text/css\">#EPMWorkspaceCenterGrid {"),
                () => result.ShouldContainWithoutWhitespace("<script type=\"text/javascript\">$(function () {ExecuteOrDelayUntilScriptLoaded(WorkspaceCenterClient.init, 'EPMLive.js');});"),
                () => result.ShouldContainWithoutWhitespace($"var changeView = function (currentView) {{ EPM.UI.Loader.current().startLoading({{ id: 'EPMWorkspaceCenterLoadingDiv' }}); var source = Grids[\"gridWorkSpaceCenter\"].Source; source.Data.url = '{ExampleUrl}/_vti_bin/WorkEngine.asmx';"),
                () => result.ShouldContainWithoutWhitespace($"var createNewWorkspace = function () {{ var createNewWorkspaceUrl = \"{ExampleUrl}/_layouts/epmlive/QueueCreateWorkspace.aspx\";"),
                () => result.ShouldContainWithoutWhitespace($"window.TreeGrid('<treegrid data_url=\"{ExampleUrl}/_vti_bin/WorkEngine.asmx\" data_timeout=\"0\" data_method=\"Soap\""),
                () => result.ShouldContainWithoutWhitespace("<div id=\"EPMWorkspaceCenter\"><div id=\"EPMWorkspaceCenterLoadingDiv\"><div id=\"WorkSpacecenterToolbarMenu\" style=\"width: 99%\"></div>"),
                () => result.ShouldContainWithoutWhitespace("<div id=\"EPMWorkspaceCenterGrid\" style=\"width: 100%; height: 400px;\"></div></div></div></div>"));
        }

        private void PrepareSpContext()
        {
            ShimEPMLiveScriptManager.RegisterScriptPageStringArrayBoolean = (a, b, c) => _didRegisterScript = true;
            ShimSPPageContentManager.RegisterStyleFileString = _ => _didRegisterStyleFile = true;

            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();

            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => "/";
            ShimSPWeb.AllInstances.UrlGet = _ => ExampleUrl;
        }

        private static void ShimPageMethods()
        {
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimPage.AllInstances.FormGet = _ => new HtmlForm();
            ShimHttpRequest.AllInstances.ParamsGet = _ => new NameValueCollection { { "epmdebug", "all" } };
        }
    }
}
