using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CreateNewWorkspaceTest
    {
        private IDisposable _shimsObject;
        private CreateNewWorkspace _testObj;
        private PrivateObject _privateObj;
        private ShimSPWeb _web;
        private ShimSPSite _site;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string ListId = "7aeaf8ee-5d29-43c7-b3f3-5a9aded12a28";
        private const string RelativeUrl = "/";
        private const string PageInitMethod = "Page_Init";
        private const string PageUnloadMethod = "Page_Unload";
        private const string PageLoadMethod = "Page_Load";
        private const string CompLevel = "CompLevel";
        private const string TimeOutField = "_timeOut";
        private const string SolutionTypeField = "_solutionType";
        private const string LstGuidField = "_lstGuid";
        private const string CopyFromField = "_copyFrom";
        private const string PnlWorkspaceTypeField = "pnlWorkspaceType";
        private const string PnlCreateNewWorkspaceFromField = "pnlCreateNewWorkspaceFrom";
        private const string NavField = "_nav";
        private const string PermsField = "_perms";
        private const string TrueString = "True";
        private const string UniqueString = "Unique";
        private const string SiteString = "{Site}";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new CreateNewWorkspace();
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

            ShimSPSite.ConstructorGuid = (instance, guid) => { instance = _site.Instance; };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => _web;
            ShimUnsecuredLayoutsPageBase.AllInstances.SiteGet = _ => _site;
        }

        [TestMethod]
        public void PageInit_OnValidCall_ConfirmResult()
        {
            // Arrange
            ShimPage.AllInstances.ServerGet = _ => new ShimHttpServerUtility
            {
                ScriptTimeoutGet = () => DummyInt
            };

            // Act
            _privateObj.Invoke(PageInitMethod, this, EventArgs.Empty);

            // Assert
            var timeOut = (int)_privateObj.GetFieldOrProperty(TimeOutField);
            timeOut.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void PageUnload_OnValidCall_ConfirmResult()
        {
            // Arrange
            var timeOutSaved = false;
            ShimPage.AllInstances.ServerGet = _ => new ShimHttpServerUtility
            {
                ScriptTimeoutSetInt32 = value => timeOutSaved = true
            };

            // Act
            _privateObj.Invoke(PageUnloadMethod, this, EventArgs.Empty);

            // Assert
            timeOutSaved.ShouldBeTrue();
        }

        [TestMethod]
        public void PageLoad_FirstSituation_ConfirmResult()
        {
            // Arrange
            const string templateName = "project";

            SetupForPageLoad(templateName);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var solutionType = _privateObj.GetFieldOrProperty(SolutionTypeField);
            var lstGuid = _privateObj.GetFieldOrProperty(LstGuidField);
            var copyFrom = _privateObj.GetFieldOrProperty(CopyFromField);
            var pnlWorkspaceType = (Panel)_privateObj.GetFieldOrProperty(PnlWorkspaceTypeField);
            var pnlCreateNewWorkspaceFrom = (Panel)_privateObj.GetFieldOrProperty(PnlCreateNewWorkspaceFromField);
            var nav = _privateObj.GetFieldOrProperty(NavField);
            var perms = _privateObj.GetFieldOrProperty(PermsField);

            this.ShouldSatisfyAllConditions(
                () => solutionType.ShouldBe(DummyString),
                () => lstGuid.ShouldBe(ListId),
                () => copyFrom.ShouldBe(DummyInt.ToString()),
                () => pnlWorkspaceType.Controls.Count.ShouldBeGreaterThan(0),
                () => pnlCreateNewWorkspaceFrom.Controls.Count.ShouldBeGreaterThan(0),
                () => nav.ShouldBe(TrueString),
                () => perms.ShouldBe(UniqueString));
        }

        [TestMethod]
        public void PageLoad_SecondSituation_ConfirmResult()
        {
            // Arrange
            const string templateName = "template";

            SetupForPageLoad(templateName);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var solutionType = _privateObj.GetFieldOrProperty(SolutionTypeField);
            var lstGuid = _privateObj.GetFieldOrProperty(LstGuidField);
            var copyFrom = _privateObj.GetFieldOrProperty(CopyFromField);
            var pnlWorkspaceType = (Panel)_privateObj.GetFieldOrProperty(PnlWorkspaceTypeField);
            var pnlCreateNewWorkspaceFrom = (Panel)_privateObj.GetFieldOrProperty(PnlCreateNewWorkspaceFromField);
            var nav = _privateObj.GetFieldOrProperty(NavField);
            var perms = _privateObj.GetFieldOrProperty(PermsField);

            this.ShouldSatisfyAllConditions(
                () => solutionType.ShouldBe(DummyString),
                () => lstGuid.ShouldBe(ListId),
                () => copyFrom.ShouldBe(DummyInt.ToString()),
                () => pnlWorkspaceType.Controls.Count.ShouldBe(0),
                () => pnlCreateNewWorkspaceFrom.Controls.Count.ShouldBeGreaterThan(0),
                () => nav.ShouldBe(TrueString),
                () => perms.ShouldBe(UniqueString));
        }

        [TestMethod]
        public void PageLoad_ThirdSituation_ConfirmResult()
        {
            // Arrange
            const string templateName = "workspace";

            SetupForPageLoad(templateName);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var solutionType = _privateObj.GetFieldOrProperty(SolutionTypeField);
            var lstGuid = _privateObj.GetFieldOrProperty(LstGuidField);
            var copyFrom = _privateObj.GetFieldOrProperty(CopyFromField);
            var pnlWorkspaceType = (Panel)_privateObj.GetFieldOrProperty(PnlWorkspaceTypeField);
            var pnlCreateNewWorkspaceFrom = (Panel)_privateObj.GetFieldOrProperty(PnlCreateNewWorkspaceFromField);
            var nav = _privateObj.GetFieldOrProperty(NavField);
            var perms = _privateObj.GetFieldOrProperty(PermsField);

            this.ShouldSatisfyAllConditions(
                () => solutionType.ShouldBe(DummyString),
                () => lstGuid.ShouldBe(ListId),
                () => copyFrom.ShouldBe(DummyInt.ToString()),
                () => pnlWorkspaceType.Controls.Count.ShouldBeGreaterThan(0),
                () => pnlCreateNewWorkspaceFrom.Controls.Count.ShouldBeGreaterThan(0),
                () => nav.ShouldBe(TrueString),
                () => perms.ShouldBe(UniqueString));
        }

        [TestMethod]
        public void PageLoad_ForthSituation_ConfirmResult()
        {
            // Arrange
            const string templateName = "otherTemplate";

            SetupForPageLoad(templateName);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var solutionType = _privateObj.GetFieldOrProperty(SolutionTypeField);
            var lstGuid = _privateObj.GetFieldOrProperty(LstGuidField);
            var copyFrom = _privateObj.GetFieldOrProperty(CopyFromField);
            var pnlWorkspaceType = (Panel)_privateObj.GetFieldOrProperty(PnlWorkspaceTypeField);
            var pnlCreateNewWorkspaceFrom = (Panel)_privateObj.GetFieldOrProperty(PnlCreateNewWorkspaceFromField);
            var nav = _privateObj.GetFieldOrProperty(NavField);
            var perms = _privateObj.GetFieldOrProperty(PermsField);

            this.ShouldSatisfyAllConditions(
                () => solutionType.ShouldBe(DummyString),
                () => lstGuid.ShouldBe(ListId),
                () => copyFrom.ShouldBe(DummyInt.ToString()),
                () => pnlWorkspaceType.Controls.Count.ShouldBeGreaterThan(0),
                () => pnlCreateNewWorkspaceFrom.Controls.Count.ShouldBeGreaterThan(0),
                () => nav.ShouldBe(TrueString),
                () => perms.ShouldBe(UniqueString));
        }

        private void SetupForPageLoad(string templateName)
        {
            const string Type = "type";
            const string List = "list";
            const string Copyfrom = "copyfrom";
            const string GeneralSettings = "GeneralSettings";
            const string Default = "Default";
            const string Online = "Online";
            const string Local = "Local";
            const string Existing = "Existing";
            const string EPMLiveNewProjectWorkspaceType = "EPMLiveNewProjectWorkspaceType";
            const string EPMLiveNewProjectNavigation = "EPMLiveNewProjectNavigation";
            const string EPMLiveNewProjectPermissions = "EPMLiveNewProjectPermissions";

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ParamsGet = () => new NameValueCollection
                {
                    [Type] = DummyString,
                    [List] = ListId,
                    [Copyfrom] = DummyInt.ToString()
                }
            };

            ShimAct.ConstructorSPWeb = (_, __) => { };
            ShimAct.AllInstances.GetActivatedLevels = _ => new ArrayList { DummyString };

            ShimCoreFunctions.getLockedWebSPWeb = _ => Guid.NewGuid();
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_, __, ___, ____) => SiteString;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, item) =>
            {
                switch (item)
                {
                    case EPMLiveNewProjectWorkspaceType:
                        return string.Empty;
                    case EPMLiveNewProjectNavigation:
                        return TrueString;
                    case EPMLiveNewProjectPermissions:
                        return UniqueString;
                    default:
                        return DummyString;
                }
            };
            ShimCoreFunctions.getListSettingStringSPList = (setting, list) =>
            {
                if (setting == GeneralSettings)
                {
                    return $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{templateName}";
                }
                return DummyString;
            };

            ShimPropertyHash.ConstructorStringStringCharChar = (_, _1, _2, _3, _4) => { };
            ShimPropertyHash.AllInstances.ItemGetInt32 = (_, item) =>
            {
                if (item == 0)
                {
                    return new Dictionary<object, object>
                    {
                        [Default] = DummyString
                    };
                }
                return new Dictionary<object, object>
                {
                    [Online] = true,
                    [Local] = true,
                    [Existing] = true
                };
            };
        }
    }
}
