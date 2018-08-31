using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using EPMLiveCore.Fakes;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.UserProfileDisplay
{
    [TestClass]
    public class DisplayProfilePicturesTests
    {
        private class TestClass
        {
            public string MySiteHostUrl { get { return ExampleUrl; } }
        }

        private const int Id = 1;
        private const string One = "1";
        private const string DummyString = "DummyString";
        private const string ExampleUrl = "http://example.com";
        private const string RenderMethod = "Render";
        private const string SharePointSystemUser = @"sharepoint\system";
        private const string FeatureNotActivatedMessage = "This feature has not been activated.";
        private DisplayProfilePictures _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringBuilder _htmlBuilder;
        private HtmlTextWriter _htmlWriter;
        private StringWriter _stringWriter;
        private StringWriter _responseWriter;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new DisplayProfilePictures();
            _privateObject = new PrivateObject(_testObject);

            _htmlBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_htmlBuilder);
            _htmlWriter = new HtmlTextWriter(_stringWriter);
            _responseWriter = new StringWriter();

            var user = new ShimSPUser
            {
                IDGet = () => Id,
                LoginNameGet = () => SharePointSystemUser
            };
            var list = new ShimSPList
            {
                GetItemByIdInt32 = _ => new ShimSPListItem
                {
                    ItemGetString = x => $"{DummyString},{DummyString}",
                    DisplayNameGet = () => DummyString
                }
            };
            var webApp = new ShimSPWebApplication
            {
                ApplicationPoolGet = () => new SPApplicationPool()
            }.Instance;
            var web = new ShimSPWeb
            {
                CurrentUserGet = () => user,
                EnsureUserString = _ => user,
                SiteUserInfoListGet = () => list.Instance
            };
            var site = new ShimSPSite
            {
                RootWebGet = () => web.Instance,
                WebApplicationGet = () => webApp
            };
            web.SiteGet = () => site.Instance;
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => web.Instance,
                SiteGet = () => site.Instance
            }.Instance;
            ShimSPProcessIdentity.AllInstances.UsernameGet = _ => DummyString;
            ShimAct.ConstructorSPWeb = (_, __) => { };

            HttpContext.Current = new HttpContext(
                new HttpRequest(string.Empty, ExampleUrl, string.Empty),
                new HttpResponse(_responseWriter));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _htmlWriter?.Dispose();
            _stringWriter?.Dispose();
            _responseWriter?.Dispose();
        }

        [TestMethod]
        public void Render_ActivationNonZero_WriteStatus()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => 1;

            // Act
            _privateObject.Invoke(RenderMethod, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldBe(FeatureNotActivatedMessage);
        }

        [TestMethod]
        public void Render_ActivationLargeImage_WritesJavascript()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => 0;
            ShimDisplayProfilePictures.AllInstances.GetUserProfileManagerClass = _ => typeof(TestClass);
            _testObject.LargeImage = true;

            // Act
            _privateObject.Invoke(RenderMethod, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain(@"<script type=""text/javascript"">"),
                () => result.ShouldContain(@"options.url = L_Menu_BaseUrl + ""/_layouts/epmlive/UploadProfilePicture.aspx"";"),
                () => result.ShouldContain(@"options.dialogReturnValueCallback = Function.createDelegate(null, modalDialogClosedCallback);"),
                () => result.ShouldContain(@"SP.UI.ModalDialog.showModalDialog(options);"),
                () => result.ShouldContain(@"$('#ProfileImage').attr(""src"","));
        }

        [TestMethod]
        public void Render_ActivationLargeImage_WritesLargeImage()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => 0;
            ShimDisplayProfilePictures.AllInstances.GetUserProfileManagerClass = _ => typeof(TestClass);
            _testObject.LargeImage = true;

            // Act
            _privateObject.Invoke(RenderMethod, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldContain("<div id=\"imgDivLarge\">"),
                () => result.ShouldContain("<div class=\"ms-profilepicture ms-contactcardpicture ms-largethumbnailimage\">"),
                () => result.ShouldContain($"<img id=\"ProfileImage\" src=\"{DummyString}\" width=\"144\" height=\"144\" onerror=\"this.src='_layouts/epmlive/images/DisplayProfilePicture/DefaultProfilePic.png';\"></img>"),
                () => result.ShouldContain($"<a href=\"/_layouts/userdisp.aspx?Source={ExampleUrl}/\">")
                );
        }

        [TestMethod]
        public void Render_ActivationSmallImage_WritesSmallImage()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) => 0;
            ShimDisplayProfilePictures.AllInstances.GetUserProfileManagerClass = _ => typeof(TestClass);
            _testObject.LargeImage = false;

            // Act
            _privateObject.Invoke(RenderMethod, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrWhiteSpace(),
                () => result.ShouldContain("<div id=\"imgDiv\">"),
                () => result.ShouldContain("<div class=\"ms-profilepicture ms-contactcardpicture ms-smallthumbnailimage\">"),
                () => result.ShouldContain($"<img id=\"ProfileImage\" src=\"{DummyString}\" width=\"93\" height=\"96\" onerror=\"this.src='_layouts/epmlive/images/DisplayProfilePicture/DefaultProfilePic.png';\"></img>"),
                () => result.ShouldContain($"<a href=\"/_layouts/userdisp.aspx?Source={ExampleUrl}/\">")
                );
        }
    }
}
