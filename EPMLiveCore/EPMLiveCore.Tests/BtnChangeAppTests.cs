using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    using EPMLiveCore;
    using Fakes;

    [TestClass]
    public class BtnChangeAppTests
    {
        private const string RenderMethodName = "Render";
        private const string DummyUrl = "http://www.dummy.org/url/";
        private static bool UrlIsHomeMethodReturn;
        private static int CommunityId;
        private IDisposable shimsContext;
        private BtnChangeApp btnChangeApp;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            btnChangeApp = new BtnChangeApp();
            privateObject = new PrivateObject(btnChangeApp);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimAppSettingsHelper.Constructor = _ => { };
            ShimSPFieldUrlValue.ConstructorString = (_, url) => { };
            ShimSPRequestContext.CurrentGet = () => new ShimSPRequestContext();
            ShimAppSettingsHelper.AllInstances.SetCurrentAppIdInt32 = (_, id) => { };
            ShimSPHttpUtility.UrlKeyValueDecodeString = content => content;
        }

        [TestMethod]
        public void Render_Should_ExecuteCorrectly()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimSPHttpUtility.UrlKeyValueDecodeString = content => content;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlGet = () => new Uri(DummyUrl)
                }
            };
            ShimAppSettingsHelper.AllInstances.GetCurrentAppTitle = _ => string.Empty;
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>
                {
                    new ShimSPList
                    {
                        HiddenGet = () => false
                    }
                };
                return new ShimSPListCollection().Bind(list);
            };
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => new ShimSPList
            {
                GetItemByIdInt32 = id => new ShimSPListItem
                {
                    ItemGetString = itemName => "DummyValue"
                }
            };
            ShimBtnChangeApp.AllInstances.GetWelcomePage = _ => "Dummyurl";
            CommunityId = -1;
            UrlIsHomeMethodReturn = false;
            ShimBtnChangeApp.AllInstances.UrlIsHomePageStringInt32Out = UrlIsHomePage;
            var expectedContent = new List<string>
            {
                "<script type=\"text/javascript\" src=\"/_layouts/epmlive/javascripts/BtnChangeApp.js\"></script>",
                "<div id=\"divChangeAppMenu\" style=\"z-index: 103; position: absolute; width: 159px; display:none; top: 28px; left: -86px\"",
                "dir=\"ltr\" class=\"ms-core-menu-box ms-core-defaultFont ms-shadow\" title=\"\" ismenu=\"true\" level=\"0\"",
                "_backgroundframeid=\"msomenuid4\" flipped=\"false\" LeftForBackIframe=\"13\" TopForBackIframe=\"30\">",
                "<span onlick=\"document.getElementById('lnkChangeApp').click()\">",
                $"<span onlick=\"document.getElementById('lnkChangeApp').click()\" id=\"spnChangeAppText\" >No Community</span>"
            };

            // Act
            privateObject.Invoke(RenderMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(content => result.ShouldContain(content)));
        }

        [TestMethod]
        public void Render_UrlIsHomePage_ShouldRedirect()
        {
            // Arrange
            var redirectUrl = string.Empty;
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            CommunityId = 1;
            UrlIsHomeMethodReturn = true;
            ShimBtnChangeApp.AllInstances.UrlIsHomePageStringInt32Out = UrlIsHomePage;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                redirectUrl = url;
                return true;
            };
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlGet = () => new Uri(DummyUrl)
                },
            };
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>();
                return new ShimSPListCollection().Bind(list);
            };
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => null;

            // Act
            privateObject.Invoke(RenderMethodName, writer);

            // Assert
            redirectUrl.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe(DummyUrl));
        }

        [TestMethod]
        public void Render_CurrentUrlDifferentFromSPFieldUrl_ShouldRedirect()
        {
            // Arrange
            var redirectUrl = string.Empty;
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimSPHttpUtility.UrlKeyValueDecodeString = content => content;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlGet = () => new Uri(DummyUrl)
                }
            };
            ShimAppSettingsHelper.AllInstances.GetCurrentAppTitle = _ => string.Empty;
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>();
                return new ShimSPListCollection().Bind(list);
            };
            ShimSPListCollection.AllInstances.TryGetListString = (_, name) => new ShimSPList
            {
                GetItemByIdInt32 = id => new ShimSPListItem
                {
                    ItemGetString = itemName => "DummyValue"
                }
            };
            ShimBtnChangeApp.AllInstances.GetWelcomePage = _ => DummyUrl;
            ShimSPFieldUrlValue.AllInstances.UrlGet = _ => "dummy/url";
            UrlIsHomeMethodReturn = false;
            ShimBtnChangeApp.AllInstances.UrlIsHomePageStringInt32Out = UrlIsHomePage;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                redirectUrl = url;
                return true;
            };

            // Act
            privateObject.Invoke(RenderMethodName, writer);

            // Assert
            redirectUrl.ShouldSatisfyAllConditions(
                () => redirectUrl.ShouldNotBeNullOrEmpty(),
                () => redirectUrl.ShouldBe("dummy/url"));
        }

        private bool UrlIsHomePage(BtnChangeApp btn, string url, out int communityId)
        {
            communityId = CommunityId;
            return UrlIsHomeMethodReturn;
        }
    }
}
