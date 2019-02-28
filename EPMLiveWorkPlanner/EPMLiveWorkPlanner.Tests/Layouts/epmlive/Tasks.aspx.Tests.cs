using System;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Globalization;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using EPMLiveWorkPlanner.Tests.HelperClasses;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWorkPlanner.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TasksTest
    {
        private IDisposable _shimContext;
        private PrivateObject _privateObject;
        private tasks _testEntity;
        private const string CreateToolbarMethod = "createToolbar";
        private const string GetRealFieldMethod = "getRealField";
        private const string LoadViewsMethod = "loadViews";

        private static readonly Guid CurrentWebId = Guid.NewGuid();
        private static readonly Guid AuthorGuid = Guid.NewGuid();
        private static readonly Guid BaselineSavedGuid = Guid.NewGuid();
        private static readonly Guid ProjectManagersGuid = Guid.NewGuid();
        private const string PageLoadMethod = "Page_Load";
        private const string DummyStatusOne = "This feature has not been activated.";
        private const string DummyServerRelativeUrl = "/server/relative/url/";
        private const string DummyDefaultViewUrl = "/Default/View/";
        private const string DummyTitle = "DummyTitle";
        private const string DummyGuidString = "edbf5f56-a952-42cd-bb4d-0cf0eab23f5e";
        private const string DummyString = "DummyString";
        private static readonly Guid DummyViewId = Guid.NewGuid();
        private static readonly Guid DummyWebSiteId = Guid.NewGuid();
        private static readonly Guid DummyId = new Guid("b1972cb7-a7aa-4364-a29d-dec581119894");
        private const string EpmLiveWpProjectCenter = "EPMLiveWPProjectCenter";
        private const string EpmLiveWpTaskCenter = "EPMLiveWPTaskCenter";
        private const string RequestId = "7";
        private const string RequestSource = "http://tempuri.org/resource/";
        private const int CurrentUserId = 6;
        private static readonly DateTime DummyDateTime = new DateTime(2018, 1, 1, 0, 0, 0);

        private const string ExpectedHtmlPanelResourceToolBar = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"90\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"ResourceToolsMenuControls\" largeIconMode=\"false\"><ie:menuitem id=\"zz25_FindResources\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_find.gif\" onMenuClick=\"javascript:window.open('/_layouts/epmlive/resourcecapacity.aspx','', config='height=600,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes'); return false\" text=\"Find Resource(s)\" description=\"Use this tool to find which resources are available for your work.\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz26_CheckResource\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_check.gif\" onMenuClick=\"javascript:showresgantt('/_layouts/epmlive/checkresgantt.aspx',''); return false\" text=\"Check Resource(s)\" description=\"Use this tool to check your assignment against all other work in the system.\" menuGroupId=\"100\"></ie:menuitem></menu></span><span title=\"Open Menu\"><div  id=\"ResourceToolsMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('ResourceToolsMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"ResourceToolsMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('ResourceToolsMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'), event);\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=ResourceToolsMenu,TEMPLATECLIENTID=ResourceToolsMenuControls\" serverclientid=\"ResourceToolsMenu\">Resource Tools<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>";
        private const string ExpectedHtmlFileToolBar = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"35\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"FileMenuControls\" largeIconMode=\"false\"><ie:menuitem id=\"zz24_Close\" type=\"option\" iconSrc=\"/_layouts/images/CLOSE.gif\" onMenuClick=\"javascript:closePage(); return false\" text=\"Close\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz25_Save\" type=\"option\" iconSrc=\"/_layouts/images/SAVEITEM.gif\" onMenuClick=\"javascript:saveData(); return false\" text=\"Save\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz26_SaveClose\" type=\"option\" iconSrc=\"/_layouts/images/SAVEITEM.gif\" onMenuClick=\"javascript:saveDataClose(); return false\" text=\"Save & Close\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz26_SaveClose\" type=\"option\" iconSrc=\"images/print.gif\" onMenuClick=\"javascript:mygrid.printView(); return false\" text=\"Print\" menuGroupId=\"100\"></ie:menuitem></menu></span><span title=\"Open Menu\"><div  id=\"FileMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('FileMenuControls'), MMU_GetMenuFromClientId('FileMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('FileMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"FileMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('FileMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('FileMenuControls'), MMU_GetMenuFromClientId('FileMenu'), event);\" onclick=\" MMU_Open(byid('FileMenuControls'), MMU_GetMenuFromClientId('FileMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=FileMenu,TEMPLATECLIENTID=FileMenuControls\" serverclientid=\"FileMenu\">File<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>";
        private const string ExpectedHtmlEditToolBar = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"35\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"EditMenuControls\" largeIconMode=\"false\"><ie:menuitem id=\"zz23_EditProject\" type=\"option\" iconSrc=\"/_layouts/images/DETAIL.gif\" onMenuClick=\"javascript:editProject('edbf5f56-a952-42cd-bb4d-0cf0eab23f5e','b1972cb7-a7aa-4364-a29d-dec581119894'); return false\" text=\"Edit Project Information\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz24_SaveBaseline\" type=\"option\" iconSrc=\"images/baseline.gif\" onMenuClick=\"javascript:saveBaseline(); return false\" text=\"Save Baseline\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz25_AutoCalculate\" type=\"option\" iconSrc=\"/_layouts/images/checkon.gif\" onMenuClick=\"javascript:autocalc(); return false\" text=\"Auto-Calculate\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz25_Calculate\" type=\"option\" iconSrc=\"images/calc.gif\" onMenuClick=\"javascript:calc(); return false\" text=\"Calculate\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz26_ViewInGantt\" type=\"option\" iconSrc=\"/_layouts/images/epmlivegantt.gif\" onMenuClick=\"javascript:showGantt('',''); return false\" text=\"View In Gantt\" menuGroupId=\"100\"></ie:menuitem></menu></span><span title=\"Open Menu\"><div  id=\"EditMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('EditMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"EditMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('EditMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'), event);\" onclick=\" MMU_Open(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=EditMenu,TEMPLATECLIENTID=EditMenuControls\" serverclientid=\"EditMenu\">Edit<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>";
        private const string ExpectedHtmlEditToolBarAutoCalcFalse = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"35\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"EditMenuControls\" largeIconMode=\"false\"><ie:menuitem id=\"zz23_EditProject\" type=\"option\" iconSrc=\"/_layouts/images/DETAIL.gif\" onMenuClick=\"javascript:editProject('edbf5f56-a952-42cd-bb4d-0cf0eab23f5e','b1972cb7-a7aa-4364-a29d-dec581119894'); return false\" text=\"Edit Project Information\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz24_SaveBaseline\" type=\"option\" iconSrc=\"images/baseline.gif\" onMenuClick=\"javascript:saveBaseline(); return false\" text=\"Save Baseline\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz25_AutoCalculate\" type=\"option\" iconSrc=\"\" onMenuClick=\"javascript:autocalc(); return false\" text=\"Auto-Calculate\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz25_Calculate\" type=\"option\" iconSrc=\"images/calc.gif\" onMenuClick=\"javascript:calc(); return false\" text=\"Calculate\" menuGroupId=\"100\"></ie:menuitem><ie:menuitem id=\"zz26_ViewInGantt\" type=\"option\" iconSrc=\"/_layouts/images/epmlivegantt.gif\" onMenuClick=\"javascript:showGantt('',''); return false\" text=\"View In Gantt\" menuGroupId=\"100\"></ie:menuitem></menu></span><span title=\"Open Menu\"><div  id=\"EditMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('EditMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"EditMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('EditMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'), event);\" onclick=\" MMU_Open(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=EditMenu,TEMPLATECLIENTID=EditMenuControls\" serverclientid=\"EditMenu\">Edit<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new tasks();
            _privateObject = new PrivateObject(_testEntity);

            _privateObject.SetField("pnlMain", new Panel() { Visible = false });
            _privateObject.SetField("pnlExpire", new Panel() { Visible = false });
            _privateObject.SetField("pnlProjectServer", new Panel() { Visible = false });
            _privateObject.SetField("lblExpire", new Label());
            _privateObject.SetField("pnlToolbar", new Panel() { Visible = false });
            _privateObject.SetField("pnlFileToolbar", new Panel() { Visible = false });
            _privateObject.SetField("pnlEditToolbar", new Panel() { Visible = false });
            _privateObject.SetField("pnlResourceToolbar", new Panel() { Visible = false });

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();

            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = sender => new ShimSPWeb();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void PageLoad_ActivationNotZero_PnlExpireShown()
        {
            // Arrange
            ShimAct.ConstructorSPWeb = (sender, webParam) => new ShimAct(sender)
            {
                CheckFeatureLicenseActFeature = feature => 1,
                translateStatusInt32 = status => DummyStatusOne
            };

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlMain = (Panel)_privateObject.GetField("pnlMain");
            var pnlExpire = (Panel)_privateObject.GetField("pnlExpire");
            var lblExpire = (Label)_privateObject.GetField("lblExpire");

            this.ShouldSatisfyAllConditions(
                () => pnlMain.Visible.ShouldBeFalse(),
                () => pnlExpire.Visible.ShouldBeTrue(),
                () => lblExpire.Text.ShouldBe(DummyStatusOne));
        }

        [TestMethod]
        public void PageLoad_ActivationZeroLockWebEmpty_FillProperties()
        {
            // Arrange
            var actualLoadViews = false;
            var actualCreateToolBar = false;

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "ID":
                            return RequestId;
                        case "source":
                            return RequestSource;
                        case "view":
                            return DummyGuidString;
                        default:
                            return null;
                    }
                }
            };

            ShimAct.ConstructorSPWeb = (sender, webParam) => new ShimAct(sender)
            {
                CheckFeatureLicenseActFeature = feature => 0
            };

            var lstProjectCenter = new ShimSPList()
            {
                GetItemByIdInt32 = itemId => new ShimSPListItem()
                {
                    ItemGetGuid = guidParam => guidParam.ToString(),
                    TitleGet = () => DummyTitle,
                    ItemGetString = itemName => bool.TrueString
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName =>
                    {
                        var currentGuid = Guid.Empty;

                        switch (internalName)
                        {
                            case "Author":
                                currentGuid = AuthorGuid;
                                break;
                            case "BaselineSaved":
                                currentGuid = BaselineSavedGuid;
                                break;
                            case "ProjectManagers":
                                currentGuid = ProjectManagersGuid;
                                break;
                            default:
                                break;
                        }

                        return new ShimSPField()
                        {
                            IdGet = () => currentGuid
                        };
                    }
                },
                FormsGet = () => new ShimSPFormCollection()
                {
                    ItemGetPAGETYPE = pageType => new ShimSPForm()
                    {
                        ServerRelativeUrlGet = () => DummyServerRelativeUrl
                    }
                }
            };

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;
            ShimSPFieldLookupValue.ConstructorString = (sender, fieldValue) => new ShimSPFieldLookupValue(sender)
            {
                LookupIdGet = () => CurrentUserId
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    IDGet = () => CurrentWebId,
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName =>
                        {
                            switch (itemName)
                            {
                                case EpmLiveWpProjectCenter:
                                    return lstProjectCenter;
                                case EpmLiveWpTaskCenter:
                                    return new ShimSPList();
                                default:
                                    break;
                            }

                            return null;
                        }
                    },
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        IsSiteAdminGet = () => true,
                        IDGet = () => CurrentUserId
                    },
                    LocaleGet = () => new CultureInfo("en-US"),
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummyWebSiteId
                    }
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        RegionalSettingsGet = () => new ShimSPRegionalSettings()
                        {
                            WorkDaysGet = () => 5
                        }
                    }
                }
            };

            ShimSPFieldLookupValueCollection.ConstructorString = (sender, fieldValue) => new ShimList<SPFieldLookupValue>(new ShimSPFieldLookupValueCollection(sender))
            {
                GetEnumerator = () => new List<SPFieldLookupValue>()
                {
                    new ShimSPFieldLookupValue
                    {
                        LookupIdGet = () => CurrentUserId
                    }
                }.GetEnumerator()
            };

            ShimCoreFunctions.getLockedWebSPWeb = webParam => Guid.Empty;
            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                switch (setting)
                {
                    case EpmLiveWpProjectCenter:
                        return EpmLiveWpProjectCenter;
                    case EpmLiveWpTaskCenter:
                        return EpmLiveWpTaskCenter;
                    case "EPMLiveWorkPlannerFields":
                        return string.Empty;
                    case "EPMLiveWPUseResPool":
                        return "true";
                    default:
                        break;
                }

                return null;
            };
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (webParam, setting, translateUrl, relative) =>
            {
                switch (setting)
                {
                    case "EPMLiveResourceURL":
                        return "/";
                    default:
                        break;
                }

                return null;
            };

            Shimtasks.AllInstances.loadViewsSPWeb = (sender, web) => actualLoadViews = true;
            Shimtasks.AllInstances.createToolbarSPWeb = (sender, web) => actualCreateToolBar = true;

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlMain = (Panel)_privateObject.GetField("pnlMain");
            var pnlProjectServer = (Panel)_privateObject.GetField("pnlProjectServer");
            var showPlanner = (bool)_privateObject.GetField("showPlanner");
            var siteUrl = (string)_privateObject.GetField("SiteUrl");
            var webId = (string)_privateObject.GetField("webId");
            var siteId = (string)_privateObject.GetField("siteId");
            var sUrl = (string)_privateObject.GetField("sUrl");
            var strDateFormat = (string)_privateObject.GetField("strDateFormat");
            var projectName = (string)_privateObject.GetField("projectName");
            var autoCalc = (string)_privateObject.GetField("autoCalc");
            var projectEditUrl = (string)_privateObject.GetField("projectEditUrl");
            var pcUrl = (string)_privateObject.GetField("pcURL");

            this.ShouldSatisfyAllConditions(
                () => pnlMain.Visible.ShouldBeFalse(),
                () => pnlProjectServer.Visible.ShouldBeTrue(),
                () => showPlanner.ShouldBeFalse(),
                () => siteUrl.ShouldBe("%2f_layouts%2fepmlive%2fedititem.aspx%3fclose%3d1%26ListId%3d"),
                () => webId.ShouldBe(CurrentWebId.ToString()),
                () => siteId.ShouldBe(DummyWebSiteId.ToString()),
                () => sUrl.ShouldBe($"/_layouts/epmlive/tasks.aspx?view=&disablefilters=true&ID={RequestId}"),
                () => strDateFormat.ShouldBe("%m/%d/%Y"),
                () => projectName.ShouldBe(DummyTitle),
                () => autoCalc.ShouldBe("true"),
                () => projectEditUrl.ShouldBe(DummyServerRelativeUrl),
                () => pcUrl.ShouldBe(RequestSource),
                () => actualLoadViews.ShouldBeTrue(),
                () => actualCreateToolBar.ShouldBeTrue());
        }

        [TestMethod]
        public void PageLoad_ActivationZeroLockWebDifferentGuid_FillProperties()
        {
            // Arrange
            var actualLoadViews = false;
            var actualCreateToolBar = false;

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "ID":
                            return RequestId;
                        case "view":
                            return DummyGuidString;
                        default:
                            break;
                    }

                    return null;
                }
            };

            ShimAct.ConstructorSPWeb = (sender, webParam) => new ShimAct(sender)
            {
                CheckFeatureLicenseActFeature = feature => 0
            };

            var lstProjectCenter = new ShimSPList()
            {
                GetItemByIdInt32 = itemId => new ShimSPListItem()
                {
                    ItemGetGuid = guidParam => guidParam.ToString(),
                    TitleGet = () => DummyTitle
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => null
                },
                FormsGet = () => new ShimSPFormCollection()
                {
                    ItemGetPAGETYPE = pageType => new ShimSPForm()
                    {
                        ServerRelativeUrlGet = () => DummyServerRelativeUrl
                    }
                }
            };

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    IDGet = () => CurrentWebId,
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName =>
                        {
                            switch (itemName)
                            {
                                case EpmLiveWpProjectCenter:
                                    return lstProjectCenter;
                                case EpmLiveWpTaskCenter:
                                    return new ShimSPList()
                                    {
                                        DefaultViewUrlGet = () => DummyDefaultViewUrl
                                    };
                                default:
                                    break;
                            }

                            return null;
                        }
                    },
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        IsSiteAdminGet = () => true,
                        IDGet = () => CurrentUserId
                    },
                    LocaleGet = () => new CultureInfo("en-US"),
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummyWebSiteId
                    }
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        RegionalSettingsGet = () => new ShimSPRegionalSettings()
                        {
                            WorkDaysGet = () => 5
                        }
                    }
                }
            };

            ShimCoreFunctions.getLockedWebSPWeb = webParam => Guid.NewGuid();
            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                switch (setting)
                {
                    case EpmLiveWpProjectCenter:
                        return EpmLiveWpProjectCenter;
                    case EpmLiveWpTaskCenter:
                        return EpmLiveWpTaskCenter;
                    case "EPMLiveWorkPlannerFields":
                        return string.Empty;
                    case "EPMLiveWPUseResPool":
                        return "true";
                    default:
                        break;
                }

                return null;
            };
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (webParam, setting, translateUrl, relative) =>
            {
                switch (setting)
                {
                    case "EPMLiveResourceURL":
                        return "/";
                    default:
                        break;
                }

                return null;
            };

            Shimtasks.AllInstances.loadViewsSPWeb = (sender, web) => actualLoadViews = true;
            Shimtasks.AllInstances.createToolbarSPWeb = (sender, web) => actualCreateToolBar = true;

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var pnlMain = (Panel)_privateObject.GetField("pnlMain");
            var pnlProjectServer = (Panel)_privateObject.GetField("pnlProjectServer");
            var showPlanner = (bool)_privateObject.GetField("showPlanner");
            var siteUrl = (string)_privateObject.GetField("SiteUrl");
            var webId = (string)_privateObject.GetField("webId");
            var siteId = (string)_privateObject.GetField("siteId");
            var sUrl = (string)_privateObject.GetField("sUrl");
            var strDateFormat = (string)_privateObject.GetField("strDateFormat");
            var projectName = (string)_privateObject.GetField("projectName");
            var autoCalc = (string)_privateObject.GetField("autoCalc");
            var projectEditUrl = (string)_privateObject.GetField("projectEditUrl");
            var pcUrl = (string)_privateObject.GetField("pcURL");

            this.ShouldSatisfyAllConditions(
                () => pnlMain.Visible.ShouldBeFalse(),
                () => pnlProjectServer.Visible.ShouldBeFalse(),
                () => showPlanner.ShouldBeTrue(),
                () => siteUrl.ShouldBe("%2f_layouts%2fepmlive%2fedititem.aspx%3fclose%3d1%26ListId%3d"),
                () => webId.ShouldBe(CurrentWebId.ToString()),
                () => siteId.ShouldBe(DummyWebSiteId.ToString()),
                () => sUrl.ShouldBe($"/_layouts/epmlive/tasks.aspx?view=&disablefilters=true&ID={RequestId}"),
                () => strDateFormat.ShouldBe("%m/%d/%Y"),
                () => projectName.ShouldBe(DummyTitle),
                () => autoCalc.ShouldBe("true"),
                () => projectEditUrl.ShouldBe(DummyServerRelativeUrl),
                () => pcUrl.ShouldBe(DummyDefaultViewUrl),
                () => actualLoadViews.ShouldBeTrue(),
                () => actualCreateToolBar.ShouldBeTrue());
        }

        [TestMethod]
        public void PageLoad_ActivationZeroCanEditFalse_Redirect()
        {
            // Arrange
            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName =>
                {
                    switch (itemName)
                    {
                        case "ID":
                            return RequestId;
                        case "view":
                            return DummyGuidString;
                        default:
                            break;
                    }

                    return null;
                }
            };

            ShimAct.ConstructorSPWeb = (sender, webParam) => new ShimAct(sender)
            {
                CheckFeatureLicenseActFeature = feature => 0
            };

            var lstProjectCenter = new ShimSPList()
            {
                GetItemByIdInt32 = itemId => new ShimSPListItem()
                {
                    ItemGetGuid = guidParam => guidParam.ToString(),
                    TitleGet = () => DummyTitle
                },
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => null
                },
                FormsGet = () => new ShimSPFormCollection()
                {
                    ItemGetPAGETYPE = pageType => new ShimSPForm()
                    {
                        ServerRelativeUrlGet = () => DummyServerRelativeUrl
                    }
                }
            };

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (sender, permissionMask) => true;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    IDGet = () => CurrentWebId,
                    ListsGet = () => new ShimSPListCollection()
                    {
                        ItemGetString = itemName =>
                        {
                            switch (itemName)
                            {
                                case EpmLiveWpProjectCenter:
                                    return lstProjectCenter;
                                case EpmLiveWpTaskCenter:
                                    return new ShimSPList()
                                    {
                                        DefaultViewUrlGet = () => DummyDefaultViewUrl
                                    };
                                default:
                                    break;
                            }

                            return null;
                        }
                    },
                    CurrentUserGet = () => new ShimSPUser()
                    {
                        IsSiteAdminGet = () => false,
                        IDGet = () => CurrentUserId
                    },
                    LocaleGet = () => new CultureInfo("en-US"),
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummyWebSiteId
                    }
                },
                SiteGet = () => new ShimSPSite()
                {
                    RootWebGet = () => new ShimSPWeb()
                    {
                        RegionalSettingsGet = () => new ShimSPRegionalSettings()
                        {
                            WorkDaysGet = () => 5
                        }
                    }
                }
            };

            ShimCoreFunctions.getLockedWebSPWeb = webParam => Guid.NewGuid();
            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) =>
            {
                switch (setting)
                {
                    case EpmLiveWpProjectCenter:
                        return EpmLiveWpProjectCenter;
                    case EpmLiveWpTaskCenter:
                        return EpmLiveWpTaskCenter;
                    case "EPMLiveWorkPlannerFields":
                        return string.Empty;
                    case "EPMLiveWPUseResPool":
                        return "true";
                    default:
                        break;
                }

                return null;
            };
            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (webParam, setting, translateUrl, relative) =>
            {
                switch (setting)
                {
                    case "EPMLiveResourceURL":
                        return "/";
                    default:
                        break;
                }

                return null;
            };

            var actualRedirectUrl = string.Empty;
            var actualRedirectFlags = SPRedirectFlags.AllowWebRelativeSource;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                actualRedirectUrl = url;
                actualRedirectFlags = flags;
                return true;
            };
            Shimtasks.AllInstances.loadViewsSPWeb = (sender, web) => { };
            Shimtasks.AllInstances.createToolbarSPWeb = (sender, web) => { };

            // Act
            _privateObject.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualRedirectUrl.ShouldBe("accessdenied.aspx"),
                () => actualRedirectFlags.ShouldBe(SPRedirectFlags.RelativeToLayoutsPage));
        }

        [TestMethod]
        public void CreateToolBar_AutoCalcTrueIntegratedTrue_FillProperties()
        {
            // Arrange
            var actualCountButtonsAdded = 0;
            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    WebApplicationGet = () => new ShimSPWebApplication()
                }
            };
            ShimSPPersistedObject.AllInstances.IdGet = sender => Guid.Empty;

            var buttonRepeatedControls = new ShimRepeatedControls();
            var buttonControl = new ShimControl(buttonRepeatedControls)
            {
                ControlsGet = () => new ShimControlCollection()
                {
                    AddControl = control => actualCountButtonsAdded++
                }
            };

            ShimTemplateControl.AllInstances.LoadControlString = (sender, controlName) =>
            {
                if (controlName == "~/_controltemplates/ToolBar.ascx")
                {
                    var toolBar = new ToolBarFake();
                    var shimToolBar = new ShimToolBar(toolBar)
                    {
                        ButtonsGet = () => buttonRepeatedControls
                    };
                    return toolBar;
                }

                return new ToolBarButtonFake();
            };

            var lstTaskCenter = new ShimSPList();

            ShimGridGanttSettings.ConstructorSPList = (sender, list) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.EnableResourcePlan = true;
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => string.Empty;
            ShimCoreFunctions.getWebAppSettingGuidString = (guid, setting) =>
            {
                if (setting == "ReportsUseIntegrated")
                {
                    return "true";
                }

                return string.Empty;
            };
            var lstProjectCenter = new ShimSPList()
            {
                IDGet = () => DummyId
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => DummyGuidString
            };

            _privateObject.SetField("autoCalc", "true");
            _privateObject.SetField("lstTaskCenter", lstTaskCenter.Instance);
            _privateObject.SetField("lstProjectCenter", lstProjectCenter.Instance);

            // Act
            _privateObject.Invoke(CreateToolbarMethod, web.Instance);

            // Assert
            var pnlToolbar = (Panel)_privateObject.GetField("pnlToolbar");
            var pnlFileToolbar = (Panel)_privateObject.GetField("pnlFileToolbar");
            var pnlEditToolbar = (Panel)_privateObject.GetField("pnlEditToolbar");
            var pnlResourceToolbar = (Panel)_privateObject.GetField("pnlResourceToolbar");

            this.ShouldSatisfyAllConditions(
                () => actualCountButtonsAdded.ShouldBe(10),
                () => ((LiteralControl)pnlFileToolbar.Controls[0]).Text.ShouldBe(ExpectedHtmlFileToolBar),
                () => ((LiteralControl)pnlEditToolbar.Controls[0]).Text.ShouldBe(ExpectedHtmlEditToolBar),
                () => ((LiteralControl)pnlResourceToolbar.Controls[0]).Text.ShouldBe(ExpectedHtmlPanelResourceToolBar));
        }

        [TestMethod]
        public void CreateToolBar_AutoCalcFalseIntegratedFalse_FillProperties()
        {
            // Arrange
            var actualCountButtonsAdded = 0;
            var web = new ShimSPWeb()
            {
                SiteGet = () => new ShimSPSite()
                {
                    WebApplicationGet = () => new ShimSPWebApplication()
                }
            };
            ShimSPPersistedObject.AllInstances.IdGet = sender => Guid.Empty;

            var buttonRepeatedControls = new ShimRepeatedControls();
            var buttonControl = new ShimControl(buttonRepeatedControls)
            {
                ControlsGet = () => new ShimControlCollection()
                {
                    AddControl = control => actualCountButtonsAdded++
                }
            };

            ShimTemplateControl.AllInstances.LoadControlString = (sender, controlName) =>
            {
                if (controlName == "~/_controltemplates/ToolBar.ascx")
                {
                    var toolBar = new ToolBarFake();
                    var shimToolBar = new ShimToolBar(toolBar)
                    {
                        ButtonsGet = () => buttonRepeatedControls
                    };
                    return toolBar;
                }

                return new ToolBarButtonFake();
            };

            var lstTaskCenter = new ShimSPList();

            ShimGridGanttSettings.ConstructorSPList = (sender, list) =>
            {
                var gridGantt = new ShimGridGanttSettings(sender);
                gridGantt.Instance.EnableResourcePlan = true;
            };

            ShimCoreFunctions.getConfigSettingSPWebString = (webParam, setting) => string.Empty;
            ShimCoreFunctions.getWebAppSettingGuidString = (guid, setting) => string.Empty;
            var lstProjectCenter = new ShimSPList()
            {
                IDGet = () => DummyId
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => DummyGuidString
            };

            _privateObject.SetField("autoCalc", "false");
            _privateObject.SetField("lstTaskCenter", lstTaskCenter.Instance);
            _privateObject.SetField("lstProjectCenter", lstProjectCenter.Instance);

            // Act
            _privateObject.Invoke(CreateToolbarMethod, web.Instance);

            // Assert
            var pnlToolbar = (Panel)_privateObject.GetField("pnlToolbar");
            var pnlFileToolbar = (Panel)_privateObject.GetField("pnlFileToolbar");
            var pnlEditToolbar = (Panel)_privateObject.GetField("pnlEditToolbar");
            var pnlResourceToolbar = (Panel)_privateObject.GetField("pnlResourceToolbar");

            this.ShouldSatisfyAllConditions(
                () => actualCountButtonsAdded.ShouldBe(10),
                () => ((LiteralControl)pnlFileToolbar.Controls[0]).Text.ShouldBe(ExpectedHtmlFileToolBar),
                () => ((LiteralControl)pnlEditToolbar.Controls[0]).Text.ShouldBe(ExpectedHtmlEditToolBarAutoCalcFalse),
                () => ((LiteralControl)pnlResourceToolbar.Controls[0]).Text.ShouldBe(ExpectedHtmlPanelResourceToolBar));
        }

        [TestMethod]
        public void LoadViews_DisableFiltersTrueFieldTitle_FillProperties()
        {
            // Arrange
            var web = new ShimSPWeb();

            var viewFields = new ShimSPViewFieldCollection().Bind(
                new[]
                {
                    "Title"
                });

            var lstTaskCenter = new ShimSPList()
            {
                IDGet = () => DummyId,
                DefaultViewGet = () => new ShimSPView(),
                ViewsGet = () => new ShimSPViewCollection()
                {
                    ItemGetGuid = guid => new ShimSPView()
                    {
                        TitleGet = () => DummyTitle,
                        IDGet = () => DummyViewId,
                        QueryGet = () => string.Empty,
                        ViewFieldsGet = () => viewFields
                    }
                }.Bind(
                    new SPView[]
                    {
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => DummyViewId,
                            TitleGet = () => $"{DummyTitle}2"
                        },
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => Guid.Empty,
                            TitleGet = () => $"{DummyTitle}3"
                        }
                    }),
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SchemaXmlGet = () => "<Node Min=\"10\" Max=\"100\" Percentage=\"TRUE\"></Node>",
                        TypeGet = () => SPFieldType.MultiChoice
                    }
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = requestName =>
                {
                    switch (requestName)
                    {
                        case "disablefilters":
                            return "true";
                        case "view":
                            return DummyGuidString;
                        default:
                            break;
                    }

                    return null;
                }
            };

            _privateObject.SetField("wpFields", "Title|Title");

            _privateObject.SetField("lstTaskCenter", lstTaskCenter.Instance);

            // Act
            _privateObject.Invoke(LoadViewsMethod, web.Instance);

            // Assert
            var minValues = _privateObject.GetField("minValues");
            var defaultValues = _privateObject.GetField("defaultValues");
            var maxValues = _privateObject.GetField("maxValues");
            var columnCalculations = _privateObject.GetField("columnCalculations");

            this.ShouldSatisfyAllConditions(
                () => minValues.ShouldBe("\"1000\""),
                () => defaultValues.ShouldBe("\" ;# \""),
                () => maxValues.ShouldBe("\"10000\""),
                () => columnCalculations.ShouldBe("\"Title\""));
        }

        [TestMethod]
        public void LoadViews_NoWhereFieldLinkTitle_FillProperties()
        {
            // Arrange
            var web = new ShimSPWeb();

            var viewFields = new ShimSPViewFieldCollection().Bind(
                new[]
                {
                    "LinkTitle"
                });

            var lstTaskCenter = new ShimSPList()
            {
                IDGet = () => DummyId,
                DefaultViewGet = () => new ShimSPView(),
                ViewsGet = () => new ShimSPViewCollection()
                {
                    ItemGetGuid = guid => new ShimSPView()
                    {
                        TitleGet = () => DummyTitle,
                        IDGet = () => DummyViewId,
                        QueryGet = () => string.Empty,
                        ViewFieldsGet = () => viewFields
                    }
                }.Bind(
                    new SPView[]
                    {
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => DummyViewId,
                            TitleGet = () => $"{DummyTitle}2"
                        },
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => Guid.Empty,
                            TitleGet = () => $"{DummyTitle}3"
                        }
                    }),
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SchemaXmlGet = () => "<Node></Node>",
                        TypeGet = () => SPFieldType.MultiChoice
                    }
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = requestName =>
                {
                    switch (requestName)
                    {
                        case "disablefilters":
                            return "false";
                        case "view":
                            return DummyGuidString;
                        default:
                            break;
                    }

                    return null;
                }
            };

            _privateObject.SetField("wpFields", "Title|Title");

            _privateObject.SetField("lstTaskCenter", lstTaskCenter.Instance);

            // Act
            _privateObject.Invoke(LoadViewsMethod, web.Instance);

            // Assert
            var minValues = _privateObject.GetField("minValues");
            var defaultValues = _privateObject.GetField("defaultValues");
            var maxValues = _privateObject.GetField("maxValues");
            var columnCalculations = _privateObject.GetField("columnCalculations");

            this.ShouldSatisfyAllConditions(
                () => minValues.ShouldBe("\"\""),
                () => defaultValues.ShouldBe("\" ;# \""),
                () => maxValues.ShouldBe("\"\""),
                () => columnCalculations.ShouldBe("\"\""));
        }

        [TestMethod]
        public void LoadViews_WithWhereFieldDateTimeType_FillProperties()
        {
            // Arrange
            var web = new ShimSPWeb();
            ShimDateTime.NowGet = () => DummyDateTime;

            var viewFields = new ShimSPViewFieldCollection().Bind(
                new[]
                {
                    "DateTimeToday"
                });

            var lstTaskCenter = new ShimSPList()
            {
                IDGet = () => DummyId,
                DefaultViewGet = () => new ShimSPView(),
                ViewsGet = () => new ShimSPViewCollection()
                {
                    ItemGetGuid = guid => new ShimSPView()
                    {
                        TitleGet = () => DummyTitle,
                        IDGet = () => DummyViewId,
                        QueryGet = () => "<Where><Eq><Title Name=\"IsAssignment\"> </Title></Eq></Where>",
                        ViewFieldsGet = () => viewFields
                    }
                }.Bind(
                    new SPView[]
                    {
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => DummyViewId,
                            TitleGet = () => $"{DummyTitle}2"
                        },
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => Guid.Empty,
                            TitleGet = () => $"{DummyTitle}3"
                        }
                    }),
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SchemaXmlGet = () => "<Node><Default>[today]</Default></Node>",
                        TypeGet = () => SPFieldType.DateTime
                    }
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = requestName =>
                {
                    switch (requestName)
                    {
                        case "disablefilters":
                            return "false";
                        case "view":
                            return DummyGuidString;
                        default:
                            break;
                    }

                    return null;
                }
            };

            _privateObject.SetField("wpFields", null);

            _privateObject.SetField("lstTaskCenter", lstTaskCenter.Instance);

            // Act
            _privateObject.Invoke(LoadViewsMethod, web.Instance);

            // Assert
            var minValues = _privateObject.GetField("minValues");
            var defaultValues = _privateObject.GetField("defaultValues");
            var maxValues = _privateObject.GetField("maxValues");
            var columnCalculations = _privateObject.GetField("columnCalculations");

            this.ShouldSatisfyAllConditions(
                () => minValues.ShouldBe("\"\""),
                () => defaultValues.ShouldBe($"\"{DummyDateTime.ToShortDateString()}\""),
                () => maxValues.ShouldBe("\"\""),
                () => columnCalculations.ShouldBe("\"\""));
        }

        [TestMethod]
        public void LoadViews_WithWhereFieldWithoutDefault_FillProperties()
        {
            // Arrange
            var web = new ShimSPWeb();

            var viewFields = new ShimSPViewFieldCollection().Bind(new[]
            {
                "Name"
            });

            var lstTaskCenter = new ShimSPList()
            {
                IDGet = () => DummyId,
                DefaultViewGet = () => new ShimSPView(),
                ViewsGet = () => new ShimSPViewCollection()
                {
                    ItemGetGuid = guid => new ShimSPView()
                    {
                        TitleGet = () => DummyTitle,
                        IDGet = () => DummyViewId,
                        QueryGet = () => "<Where><Eq><Title Name=\"Title\"></Title></Eq></Where>",
                        ViewFieldsGet = () => viewFields
                    }
                }.Bind(
                    new SPView[]
                    {
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => DummyViewId,
                            TitleGet = () => $"{DummyTitle}2"
                        },
                        new ShimSPView()
                        {
                            HiddenGet = () => false,
                            IDGet = () => Guid.Empty,
                            TitleGet = () => $"{DummyTitle}3"
                        }
                    }),
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = internalName => new ShimSPField()
                    {
                        SchemaXmlGet = () => "<Node></Node>",
                        TypeGet = () => SPFieldType.DateTime
                    }
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = requestName =>
                {
                    switch (requestName)
                    {
                        case "disablefilters":
                            return "false";
                        case "view":
                            return DummyGuidString;
                        default:
                            break;
                    }

                    return null;
                }
            };

            _privateObject.SetField("wpFields", string.Empty);
            _privateObject.SetField("lstTaskCenter", lstTaskCenter.Instance);

            // Act
            _privateObject.Invoke(LoadViewsMethod, web.Instance);

            // Assert
            var minValues = _privateObject.GetField("minValues");
            var defaultValues = _privateObject.GetField("defaultValues");
            var maxValues = _privateObject.GetField("maxValues");
            var columnCalculations = _privateObject.GetField("columnCalculations");

            this.ShouldSatisfyAllConditions(
                () => minValues.ShouldBe("\"\""),
                () => defaultValues.ShouldBe($"\"\""),
                () => maxValues.ShouldBe("\"\""),
                () => columnCalculations.ShouldBe("\"\""));
        }

        [TestMethod]
        public void GetRealField_FoundParentField_ReturnsParentField()
        {
            // Arrange
            var actualField = new ShimSPField();

            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Computed,
                SchemaXmlGet = () => $"<Node DisplayNameSrcField=\"{DummyString}\" />",
                ParentListGet = () => new ShimSPList()
                {
                    FieldsGet = () => new ShimSPFieldCollection()
                    {
                        GetFieldByInternalNameString = internalName =>
                        {
                            if (internalName == DummyString)
                            {
                                return actualField;
                            }

                            return null;
                        }
                    }
                }
            };

            // Act
            var actualResult = (SPField)_privateObject.Invoke(GetRealFieldMethod, field.Instance);

            // Assert
            actualResult.ShouldBe(actualField);
        }

        [TestMethod]
        public void GetRealField_GetFieldError_ReturnsSameField()
        {
            // Arrange
            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Computed,
                SchemaXmlGet = () => $"<Node DisplayNameSrcField=\"{DummyString}\" />",
                ParentListGet = () => new ShimSPList()
                {
                    FieldsGet = () => new ShimSPFieldCollection()
                    {
                        GetFieldByInternalNameString = internalName =>
                        {
                            throw new Exception();
                        }
                    }
                }
            };

            // Act
            var actualResult = (SPField)_privateObject.Invoke(GetRealFieldMethod, field.Instance);

            // Assert
            actualResult.ShouldBe(field.Instance);
        }

        [TestMethod]
        public void GetRealField_AttributeNotFound_ReturnsSameField()
        {
            // Arrange
            var actualField = new ShimSPField();

            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Computed,
                SchemaXmlGet = () => $"<Node />",
                ParentListGet = () => new ShimSPList()
                {
                    FieldsGet = () => new ShimSPFieldCollection()
                    {
                        GetFieldByInternalNameString = internalName =>
                        {
                            if (internalName == DummyString)
                            {
                                return actualField;
                            }

                            return null;
                        }
                    }
                }
            };

            // Act
            var actualResult = (SPField)_privateObject.Invoke(GetRealFieldMethod, field.Instance);

            // Assert
            actualResult.ShouldBe(field.Instance);
        }

        [TestMethod]
        public void GetRealField_ErrorLoadXml_ReturnsSameField()
        {
            // Arrange
            var actualField = new ShimSPField();

            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Computed,
                SchemaXmlGet = () => string.Empty,
                ParentListGet = () => new ShimSPList()
                {
                    FieldsGet = () => new ShimSPFieldCollection()
                    {
                        GetFieldByInternalNameString = internalName =>
                        {
                            if (internalName == DummyString)
                            {
                                return actualField;
                            }

                            return null;
                        }
                    }
                }
            };

            // Act
            var actualResult = (SPField)_privateObject.Invoke(GetRealFieldMethod, field.Instance);

            // Assert
            actualResult.ShouldBe(field.Instance);
        }
    }
}