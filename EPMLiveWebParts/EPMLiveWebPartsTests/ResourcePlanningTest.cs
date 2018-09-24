using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Xml.Fakes;
using EPMLive.TestFakes;
using EPMLiveCore;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using MicrosoftShimRibbon = Microsoft.Web.CommandUI.Fakes.ShimRibbon;
using SystemWebPart = System.Web.UI.WebControls.WebParts.WebPart;
using SystemWebPartCollection = System.Web.UI.WebControls.WebParts.WebPartCollection;
using SystemWebPartCollectionFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPartCollection;
using SystemWebPartManagerFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPartManager;
using SystemWebPartsFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPart;

namespace EPMLiveTimesheets.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ResourcePlanningTest : TestClassInitializer<ResourcePlanning>
    {
        private const string DummyUrl = "http://dummy.url";
        private HttpContext _httpContext;
        private HttpRequest _httpRequest;
        private HttpResponse _httpResponse;
        private static readonly NameValueCollection _queryString = new NameValueCollection();
        private static readonly HttpCookieCollection _cookies = new HttpCookieCollection();

        [TestInitialize]
        public new void TestInitialize()
        {
            ShimObject = ShimsContext.Create();
            ShimWebPart.AllInstances.ZoneIDGet = _ => DummyString;
            SystemWebPartsFakes.AllInstances.ZoneIndexGet = _ => DummyInt;
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            TestEntity = new ResourcePlanning();
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(ResourcePlanning));
            InitializeAllControls();
        }

        [TestMethod]
        public void RenderGrid_OnValidCall_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderGrid("100");
        }
        [TestMethod]
        public void RenderGrid_OnHeightIsEmpty_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderGrid(string.Empty);
        }

        [TestMethod]
        public void OnLoad_OnValidCall_SetsFullGridId()
        {
            // Arrange
            ShimWebPart.AllInstances.ZoneIDGet = _ => DummyString;
            SystemWebPartsFakes.AllInstances.ZoneIndexGet = _ => DummyInt;

            // Act
            PrivateObject.Invoke("OnLoad", EventArgs.Empty);

            // Assert
            Get<string>("sFullGridId").ShouldContain($"{DummyInt}{DummyString}");
        }

        [TestMethod]
        public void WebPartContextualInfo_OnGet_RegturnWebPartContextualInfo()
        {
            // Arrange
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            ShimSPRibbon.GetWebPartPageComponentIdWebPart = _ => DummyString;

            // Act
            var actualResult = TestEntity.WebPartContextualInfo;

            // Assert
            actualResult.ShouldSatisfyAllConditions(
            () => actualResult.ShouldBeOfType<WebPartContextualInfo>(),
            () => actualResult.PageComponentId.ShouldContain(DummyString));
        }

        [TestMethod]
        public void OnPreRender_OnValidCall_RegisterScripts()
        {
            // Arrange
            var registerScriptsInvoked = false;
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            SetupShimsForHttpRequest();
            _queryString.Add("FilterField1", DummyString);
            _queryString.Add("FilterValue1", DummyString);
            PrivateObject.SetField("rcList", new ShimSPList().Instance);
            PrivateObject.SetField("reslist", new ShimSPList().Instance);
            PrivateObject.SetField("sResourceList", DummyInt.ToString());


            ShimSPRibbon.GetCurrentPage = _ => new ShimSPRibbon();
            MicrosoftShimRibbon.AllInstances.RegisterDataExtensionXmlNodeString = (_, _2, _3) => { registerScriptsInvoked = true; };
            MicrosoftShimRibbon.AllInstances.TrimByIdString = (_, __) => { };
            ShimXmlDocument.AllInstances.LoadXmlString = (_, __) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlElement();
            ShimCssRegistration.RegisterString = _ => { };
            ShimScriptLink.RegisterPageStringBoolean = (_, _2, _3) => { };
            ShimSPPageContentManager.RegisterScriptFilePageStringBooleanBooleanStringString = (_, _2, _3, _4, _5, _6) => { };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) =>
            {
                if (name.Equals("EPMLiveTSAllowNotes") || name.Equals("EPMLiveTSDisableApprovals"))
                {
                    return bool.TrueString;
                }
                if (name.Equals("EPMLiveDaySettings"))
                {
                    return string.Join("|", Enumerable.Repeat<string>(bool.TrueString, 30));
                }
                return DummyString;
            };
            ShimWebPart.AllInstances.OnPreRenderEventArgs = (_, __) => { };
            ShimHttpUtility.HtmlEncodeString = str => str;
            ShimClientScriptManager.AllInstances.IsClientScriptBlockRegisteredTypeString = (_, _2, _3) => false;
            ShimClientScriptManager.AllInstances.RegisterClientScriptBlockTypeStringString = (_, _2, _3, _4) => { registerScriptsInvoked = true; };
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _2, _3) => { };
            ShimSPFieldUserValue.AllInstances.LookupValueGet = _ => DummyString;

            // Act
            PrivateObject.Invoke("OnPreRender", EventArgs.Empty);

            // Assert
            registerScriptsInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void Dispose_OnValidCall_InvokeBaseDispose()
        {
            // Arrange
            var disposeInvoked = true;
            PrivateObject.SetField("resWeb", new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid()
            }.Instance);
            ShimWebPart.AllInstances.Dispose = _ => { disposeInvoked = true; };

            // Act
            PrivateObject.Invoke("Dispose");

            // Assert
            disposeInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void CreateChildControls_OnValidCall_UpdateControls()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(DummyUrl);
        }

        [TestMethod]
        public void CreateChildControls_OnUrlNotEqual_UpdateControls()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(DummyString);
        }

        [TestMethod]
        public void CreateChildControls_OnUrlStartWithSlash_UpdateControls()
        {
            // Arrange, Act, Assert
            TestCreateChildControls("/");
        }

        [TestMethod]
        public void RenderWebPart_OnVCalidCall_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyString, DummyString, string.Empty, SPFieldType.Counter, "StartDate");
        }

        [TestMethod]
        public void RenderWebPart_OnHeightNotEmpty_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyString, DummyString, "100", SPFieldType.Counter, "StartDate");
        }

        [TestMethod]
        public void RenderWebPart_OnResourcesIsEmpty_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(string.Empty, DummyString, "100", SPFieldType.Counter, "StartDate");
        }

        [TestMethod]
        public void RenderWebPart_OnTypeCalculated_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyString, DummyString, "100", SPFieldType.Calculated, "DueDate");
        }

        [TestMethod]
        public void RenderWebPart_OnUrlIsEmpty_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyString, string.Empty, "100", SPFieldType.Calculated, "DueDate");
        }

        [TestMethod]
        public void RenderWebPart_OnTypeIsChoice_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyString, DummyString, string.Empty, SPFieldType.Choice, "DueDate");
        }

        [TestMethod]
        public void RenderWebPart_OnActivationsNotZero_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(string.Empty, DummyString, string.Empty, SPFieldType.Calculated, "DueDate", -1);
        }

        [TestMethod]
        public void Lnk_Click_OnValidCall_AddToCookies()
        {
            // Arrange
            SetupShimsForHttpRequest();
            _cookies.Add(new HttpCookie("EPMLiveResourcePlanResources", DummyString));
            _queryString.Add("resourceList", DummyString);

            // Act
            PrivateObject.Invoke("lnk_Click", new object(), EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _cookies.Count.ShouldBeGreaterThan(0),
                () => _cookies["EPMLiveResourcePlanResources"].ShouldNotBeNull(),
                () => _cookies["EPMLiveResourcePlanResources"]["resources"].ShouldNotBeNull(),
                () => _cookies["EPMLiveResourcePlanResources"]["resources"].ShouldContain(DummyString));
        }

        private void TestRenderWebPart(string resources, string resUrl, string height, SPFieldType type, string internalName, int activation = 0)
        {
            // Arrange
            var stringWriter = new StringWriter();
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            SetupShimsForHttpRequest();
            PrivateObject.SetField("activation", activation);
            PrivateObject.SetField("resWeb", new ShimSPWeb().Instance);
            PrivateObject.SetField("reslist", new ShimSPList().Instance);
            PrivateObject.SetField("rcList", new ShimSPList().Instance);
            PrivateObject.SetField("resUrl", resUrl);
            PrivateObject.SetField("sFullGridId", DummyString);
            PrivateObject.SetField("error", DummyString);
            PrivateObject.SetField("toolbar", new ViewToolBar());
            PrivateObject.SetField("act", new Act(new ShimSPWeb()));
            if (!string.IsNullOrEmpty(resources))
            {
                var cookie = new HttpCookie("EPMLiveResourcePlanResources", DummyString);
                cookie.Values.Add("resources", resources);
                _cookies.Add(cookie);
            }
            ShimWebPart.AllInstances.HeightGet = _ => height;
            ShimWebPart.AllInstances.ZoneIDGet = _ => DummyString;
            SystemWebPartsFakes.AllInstances.ZoneIndexGet = _ => DummyInt;
            PrivateObject.SetField("lnk", new LinkButton());
            ShimResourcePlanning.AllInstances.renderGridHtmlTextWriter = (_, __) => { };
            ShimHttpUtility.UrlEncodeString = str => str;
            ShimSPBaseCollection.AllInstances.GetEnumerator = instance =>
            {
                if (instance.GetType() == typeof(ShimSPFieldCollection)
                    || instance.GetType() == typeof(SPFieldCollection))
                {
                    return new List<SPField>
                    {
                        new ShimSPField()
                    }.GetEnumerator();
                }
                if (instance.GetType() == typeof(ShimSPViewFieldCollection)
                    || instance.GetType() == typeof(SPViewFieldCollection))
                {
                    return new List<string>
                    {
                        DummyString
                    }.GetEnumerator();
                }
                return new List<SPForm>
                {
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_DISPLAYFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_EDITFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_NEWFORM }
                }.GetEnumerator();
            };
            SystemWebPartsFakes.AllInstances.WebPartManagerGet = _ => new ShimSPWebPartManager();
            ShimWebPart.AllInstances.WebPartManagerGet = _ => new ShimSPWebPartManager();
            SystemWebPartManagerFakes.AllInstances.WebPartsGet = _ => new SystemWebPartCollection();
            ShimReadOnlyCollectionBase.AllInstances.GetEnumerator = _ => new List<SystemWebPart>
            {
                new ListViewWebPart()
            }.GetEnumerator();
            ShimSPField.AllInstances.TypeGet = _ => type;
            ShimSPField.AllInstances.InternalNameGet = _ => internalName;
            ShimWebPart.AllInstances.QualifierGet = _ => DummyString;
            ShimControl.AllInstances.RenderControlHtmlTextWriter = (_, __) => { };

            // Act
            using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
            {
                PrivateObject.Invoke("RenderWebPart", htmlTextWriter);
            }
            var actualResult = stringWriter.ToString();

            // Assert
            if (activation != 0)
            {
                actualResult.ShouldContain("Unable to retrieve activation status.");
            }
            else if (string.IsNullOrEmpty(resUrl))
            {
                actualResult.ShouldContain("The Resource Pool has not been configured.");
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldContain($"<B><font color=\"red\">{DummyString}</font></b>"),
                    () =>
                    {
                        if (!string.IsNullOrEmpty(resources))
                        {
                            actualResult.ShouldContain("LabelText='Default Display Form'");
                            actualResult.ShouldContain("LabelText='Default Edit Form'");
                            actualResult.ShouldContain("LabelText='Default New Form'");
                            actualResult.ShouldContain($"var wp = document.getElementById('MSOZoneCell_WebPart{DummyString}");
                            actualResult.ShouldContain($"loadPlan('{DummyUrl}')");
                        }
                    });
            }
        }

        private void TestCreateChildControls(string resUrl)
        {
            // Arrange
            SetupShimsForSharePoint();
            SetupShimsForSqlClient();
            SetupShimsForHttpRequest();
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable
            {
                {"EPMLiveKeys", $"{DummyString}\t{DummyString}"}
            };
            ShimAct.AllInstances.IsOnlineGet = _ => true;
            ShimAct.AllInstances.CheckOnlineFeatureLicenseActFeatureStringSPSite = (_, _2, _3, _4) => 0;
            _httpRequest.QueryString.Add("action", DummyString);
            PrivateObject.SetField("curWeb", new ShimSPWeb().Instance);
            PrivateObject.SetField("reslist", new ShimSPList().Instance);
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimSPWeb.AllInstances.ListsGet = _ => { throw new Exception(); };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPView>
            {
                new ShimSPView
                {
                    HiddenGet = () => false,
                    DefaultViewGet = () => true
                },
                new ShimSPView
                {
                    HiddenGet = () => false,
                    DefaultViewGet = () => false
                }
            }.GetEnumerator();
            ShimWebPart.AllInstances.ZoneIDGet = _ => DummyString;
            SystemWebPartsFakes.AllInstances.ZoneIndexGet = _ => DummyInt;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) =>
            {
                if (name.Equals("EPMLiveTSAllowNotes"))
                {
                    return bool.TrueString;
                }
                if (name.Equals("EPMLiveDaySettings"))
                {
                    return string.Join("|", Enumerable.Repeat<string>(bool.TrueString, 30));
                }
                if (name.Equals("EPMLiveResourceURL"))
                {
                    return resUrl;
                }
                return DummyString;
            };
            var firstTimeCall = true;
            ShimTemplateBasedControl.AllInstances.ControlsGet = _ =>
            {
                if (firstTimeCall)
                {
                    firstTimeCall = false;
                    return new ControlCollection(new Control())
                    {
                        new Control
                        {
                            Controls =
                            {
                                new HyperLink { ID = "hlGanttScrollTo" },
                                new NewMenu(),
                                new ActionsMenu(),
                                new Label { ID = "lblFilter" }
                            }
                        }
                    };
                }
                return new ControlCollection(new Control());
            };
            ShimToolBarMenuButton.AllInstances.AddMenuItemStringStringStringStringStringString =
                (_, _2, _3, _4, _5, _6, _7) => new MenuItemTemplate();
            ShimToolBarMenuButton.AllInstances.AddMenuItemSeparator = _ => { };
            ShimToolBarMenuButton.AllInstances.GetMenuItemString = (_, __) => new MenuItemTemplate();

            // Act
            PrivateObject.Invoke("CreateChildControls");

            // Assert
            if (resUrl.Equals(DummyString))
            {
                Get<string>("strAction").ShouldContain(DummyString);
            }
            else
            {
                this.ShouldSatisfyAllConditions(
                    () => Get<string>("strAction").ShouldContain(DummyString),
                    () => Get<string>("viewList").ShouldContain($"<option selected value=\"{DummyString}\">"),
                    () => Get<ViewToolBar>("toolbar").TemplateName.ShouldContain("GanttViewToolBar"));
            }
        }

        private void SetupShimsForSharePoint()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.GetContextHttpContextGuidGuidSPWeb = (_, _2, _3, _4) => new ShimSPContext();
            ShimSPContext.AllInstances.ListGet = _ => new ShimSPList();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.ViewContextGet = _ => new ShimSPViewContext();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPWeb.AllInstances.LocaleGet = _ => new CultureInfo(1033);
            ShimSPWeb.AllInstances.LanguageGet = _ => DummyInt;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPWeb.AllInstances.Close = _ => { };
            ShimSPWeb.AllInstances.RegionalSettingsGet = _ => new ShimSPRegionalSettings();
            ShimSPRegionalSettings.AllInstances.WorkDaysGet = _ => 5;
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = elevated => { elevated(); };
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPFarm.LocalGet = () => new ShimSPFarm();
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            ShimSPPersistedObject.AllInstances.NameGet = _ => DummyString;
            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimSPWebApplication.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (_, __) => new ShimSPFeature();
            ShimSPViewContext.AllInstances.ViewGet = _ => new ShimSPView();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPView.AllInstances.TitleGet = _ => DummyString;
            ShimSPView.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();
            ShimSPView.AllInstances.ViewsGet = _ => new ShimSPViewCollection();
            ShimSPFieldCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.DescriptionGet = _ => DummyString;
            ShimSPList.AllInstances.ItemsGet = _ => new ShimSPListItemCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DiscussionBoard;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView();
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>
            {
                new ShimSPListItem()
            }.GetEnumerator();
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;
            ShimSPListItem.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
        }

        private void SetupShimsForHttpRequest()
        {
            _queryString.Clear();
            _cookies.Clear();
            _httpRequest = new HttpRequest(DummyString, DummyUrl, DummyString);
            _httpResponse = new HttpResponse(TextWriter.Null);
            _httpContext = new HttpContext(_httpRequest, _httpResponse);
            ShimHttpContext.CurrentGet = () => _httpContext;
            ShimPage.AllInstances.RequestGet = _ => _httpRequest;
            ShimPage.AllInstances.ResponseGet = _ => _httpResponse;
            ShimHttpRequest.AllInstances.QueryStringGet = _ => _queryString;
            ShimHttpRequest.AllInstances.CookiesGet = _ => _cookies;
            ShimHttpResponse.AllInstances.CookiesGet = _ => _cookies;
        }

        private void TestRenderGrid(string height)
        {
            // Arrange
            var stringWriter = new StringWriter();
            TestEntity.ID = DummyString;
            TestEntity.ZoneID = DummyString;
            SetupShimsForSqlClient();
            PrivateObject.SetField("resWeb", new ShimSPWeb().Instance);
            PrivateObject.SetField("reslist", new ShimSPList().Instance);
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPForm.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPView.AllInstances.TitleGet = _ => DummyString;
            ShimSPView.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPView.AllInstances.ViewFieldsGet = _ => new ShimSPViewFieldCollection();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DiscussionBoard;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
            ShimSPList.AllInstances.DefaultViewGet = _ => new ShimSPView();
            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) =>
            {
                throw new Exception();
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = instance =>
            {
                if (instance.GetType() == typeof(ShimSPFieldCollection)
                || instance.GetType() == typeof(SPFieldCollection))
                {
                    return new List<SPField>
                    {
                        new ShimSPField()
                    }.GetEnumerator();
                }
                if (instance.GetType() == typeof(ShimSPViewFieldCollection)
                || instance.GetType() == typeof(SPViewFieldCollection))
                {
                    return new List<string>
                    {
                        DummyString
                    }.GetEnumerator();
                }
                return new List<SPForm>
                {
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_DISPLAYFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_EDITFORM },
                    new ShimSPForm { TypeGet = () => PAGETYPE.PAGE_NEWFORM }
                }.GetEnumerator();
            };
            ShimSPField.AllInstances.ReorderableGet = _ => true;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimHttpUtility.UrlEncodeString = str => str;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.LanguageGet = _ => DummyInt;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) =>
            {
                if (name.Equals("EPMLiveTSAllowNotes"))
                {
                    return bool.TrueString;
                }
                if (name.Equals("EPMLiveDaySettings"))
                {
                    return string.Join("|", Enumerable.Repeat<string>(bool.TrueString, 30));
                }
                return DummyString;
            };
            var request = new HttpRequest(DummyString, DummyUrl, DummyString);
            var response = new HttpResponse(TextWriter.Null);
            _httpContext = new HttpContext(request, response);
            ShimHttpContext.CurrentGet = () => _httpContext;
            ShimWebPart.AllInstances.HeightGet = _ => height;
            ShimWebPart.AllInstances.QualifierGet = _ => DummyString;

            // Act
            using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
            {
                PrivateObject.Invoke("renderGrid", htmlTextWriter);
            }
            var actualResult = stringWriter.ToString();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldContain("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css\"/>"),
                () => actualResult.ShouldContain(DummyString),
                () => actualResult.ShouldContain(DummyUrl),
                () =>
                {
                    if (string.IsNullOrEmpty(height))
                    {
                        actualResult.ShouldContain(".enableAutoHeigth(true)");
                    }
                    else
                    {
                        actualResult.ShouldContain(".enableAutoHeigth(true,70,true);");
                    }
                },
                () => actualResult.ShouldContain("<input type=\"hidden\" name=\"changeRes\" id=\"changeRes\" value=\"yes\">"));
        }

        private static void SetupShimsForSqlClient()
        {
            var readCount = 0;
            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ =>
            {
                readCount = 0;
                return new ShimSqlDataReader()
                {
                    Read = () =>
                    {
                        if (readCount == 0)
                        {
                            readCount++;
                            return true;
                        }
                        readCount = 0;
                        return false;
                    },
                    GetStringInt32 = p => DummyString,
                };
            };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => new ShimSqlCommand();
            ShimSqlDataReader.AllInstances.NextResult = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, __) => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => true;
            ShimSqlDataReader.AllInstances.NextResult = _ =>
            {
                readCount = 0;
                return true;
            };
        }
    }
}
