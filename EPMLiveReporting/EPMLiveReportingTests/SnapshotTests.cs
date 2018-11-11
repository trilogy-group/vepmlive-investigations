using System;
using System.Collections;
using System.Collections.Specialized.Fakes;
using System.ComponentModel.Fakes;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Fakes;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveReportsAdmin.Layouts.EPMLive;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SnapshotTests
    {
        private IDisposable _shimsObject;
        private Snapshot _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private ShimSPSite _site;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string RelativeUrl = "/";
        private const string PageInitMethod = "Page_Init";
        private const string CompLevel = "CompLevel";
        private const string TimeOutField = "_timeOut";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new Snapshot();
            _privateObj = new PrivateObject(_testObj);

            SetupShims();
            InitializeUiControls();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void InitializeUiControls()
        {
            var allFields = _testObj.GetType()
               .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
               .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        private void SetupShims()
        {
            _web = new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => _site,
                ServerRelativeUrlGet = () => RelativeUrl,
                UrlGet = () => DummyUrl,
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetGuid = guid => new ShimSPList
                    {
                        TitleGet = () => DummyString,
                        GetItemByIdInt32 = id => new ShimSPListItem
                        {
                            ItemGetString = item => DummyString
                        }
                    }
                },
                CurrentUserGet = () => new ShimSPUser
                {
                    LoginNameGet = () => DummyString
                },
                DoesUserHavePermissionsStringSPBasePermissions = (_, __) => true,
                AllPropertiesGet = () => new Hashtable { [CompLevel] = DummyString }
            };

            _site = new ShimSPSite
            {
                IDGet = () => Guid.NewGuid(),
                UrlGet = () => DummyUrl,
                HostNameGet = () => DummyString,
                AllWebsGet = () => new ShimSPWebCollection
                {
                    ItemGetString = item => _web
                }
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => _site,
                WebGet = () => _web
            };

            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPSite.ConstructorGuid = (instance, guid) => instance = _site.Instance;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => _web;
            ShimUnsecuredLayoutsPageBase.AllInstances.SiteGet = _ => _site;
        }

        [TestMethod]
        public void PageInit_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            ShimPage.AllInstances.ServerGet = _ => new ShimHttpServerUtility
            {
                ScriptTimeoutGet = () => DummyInt
            };
            ShimPage.AllInstances.ResponseGet = context => new ShimHttpResponse
            {
                CacheGet = () => new ShimHttpCachePolicy
                {
                    SetCacheabilityHttpCacheability = cacheability => { }
                }
            };
            ShimPage.AllInstances.RequestGet = page => new ShimHttpRequest
            {
                QueryStringGet = () => new ShimNameValueCollection
                {
                    ItemGetString = s => s
                }
            };

            var eventLogDisposeCount = 0;
            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is EventLog)
                {
                    eventLogDisposeCount++;
                }
            };

            // Act
            _privateObj.Invoke(PageInitMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(() => eventLogDisposeCount.ShouldBe(1));
        }
    }
}
