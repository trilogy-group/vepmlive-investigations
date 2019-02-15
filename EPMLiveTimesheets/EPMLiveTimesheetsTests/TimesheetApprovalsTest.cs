using System;
using System.Collections;
using System.Collections.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Web.UI;
using EPMLive.TestFakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets;
using Shouldly;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Web.UI.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using System.Web.Fakes;
using EPMLiveCore.Fakes;
using System.Web;
using Microsoft.SharePoint.WebPartPages.Fakes;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Fakes;
using EPMLiveCore;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.WebPartPages;
using TimeSheets.Fakes;
using MicrosoftShimRibbon = Microsoft.Web.CommandUI.Fakes.ShimRibbon;
using SystemWebPart = System.Web.UI.WebControls.WebParts.WebPart;
using SystemWebPartCollection = System.Web.UI.WebControls.WebParts.WebPartCollection;
using SystemWebPartCollectionFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPartCollection;
using SystemWebPartManagerFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPartManager;
using SystemWebPartsFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPart;

namespace EPMLiveTimesheets.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TimesheetApprovalsTest : TestClassInitializer<TimesheetApprovals>
    {
        private const string DummyUrl = "http://dummy.url";
        private const string SpList = "SpList";
        private const string View = "View";
        private const string Status = "Status";
        private const string Periods = "Periods";
        private const string Disabled = "_disabled";
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
            TestEntity = new TimesheetApprovals();
            PrivateObject = new PrivateObject(TestEntity);
            PrivateType = new PrivateType(typeof(TimesheetApprovals));
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
            PrivateObject.SetField(Disabled, false);
            PrivateObject.SetFieldOrProperty("FullGridId", DummyString);
            _queryString.Add("FilterField1", DummyString);
            _queryString.Add("FilterValue1", DummyString);
            ShimSPRibbon.GetCurrentPage = _ => new ShimSPRibbon();
            MicrosoftShimRibbon.AllInstances.RegisterDataExtensionXmlNodeString = (_, _2, _3) => { registerScriptsInvoked = true; };
            MicrosoftShimRibbon.AllInstances.TrimByIdString = (_, __) => { };
            ShimXmlDocument.AllInstances.LoadXmlString = (_, __) => { };
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlElement();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) =>
            {
                if (name.Equals("EPMLiveTSAllowNotes") || name.Equals("EPMLiveTSDisableApprovals"))
                {
                    return bool.TrueString;
                }
                if (name.Equals("EPMLiveDaySettings"))
                {
                    return string.Join("|", Enumerable.Repeat(bool.TrueString, 30));
                }
                return DummyString;
            };
            ShimCssRegistration.RegisterString = _ => { };
            ShimScriptLink.RegisterPageStringBoolean = (_, _2, _3) => { };
            ShimSPPageContentManager.RegisterScriptFilePageStringBooleanBooleanStringString = (_, _2, _3, _4, _5, _6) => { };
            ShimWebPart.AllInstances.OnPreRenderEventArgs = (_, __) => { };
            ShimSPRibbon.GetWebPartPageComponentIdWebPart = _ => DummyString;
            ShimHttpUtility.HtmlEncodeString = str => str;
            ShimClientScriptManager.AllInstances.IsClientScriptBlockRegisteredTypeString = (_, _2, _3) => false;
            ShimClientScriptManager.AllInstances.RegisterClientScriptBlockTypeStringString = (_, _2, _3, _4) => { registerScriptsInvoked = true; };

            // Act
            PrivateObject.Invoke("OnPreRender", EventArgs.Empty);

            // Assert
            registerScriptsInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void CreateChildControls_OnValidCall_SetArrPeriods()
        {
            // Arrange, Act, Assert
            TestCreateChildControls();
        }

        [TestMethod]
        public void CreateChildControls_OnActivationNotZero_SetArrPeriods()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(2);
        }

        [TestMethod]
        public void CreateChildControls_OnDisableApprovalsIsTrue_SetArrPeriods()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(0, true);
        }

        private void TestCreateChildControls(int activation = 0, bool disableApprovals = false)
        {
            // Arrange
            SetupShimsForHttpRequest();
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            ShimCoreFunctions.getConfigSettingSPWebString = (_, name) =>
            {
                if (name.Equals("EPMLiveTSDisableApprovals"))
                {
                    return disableApprovals.ToString();
                }
                if (name.Equals("EPMLiveDaySettings"))
                {
                    return string.Join("|", Enumerable.Repeat(bool.TrueString, 30));
                }
                return DummyString;
            };
            ShimAct.AllInstances.CheckOnlineFeatureLicenseActFeatureStringSPSite = (_, _2, _3, _4) => activation;

            // Act
            PrivateObject.Invoke("CreateChildControls");
            var arrPeriods = Get<SortedList>("Periods");

            // Assert
            if (!activation.Equals(0) || disableApprovals)
            {
                arrPeriods.Count.ShouldBe(0);
            }
            else
            {
                arrPeriods.ShouldSatisfyAllConditions(
                    () => arrPeriods.Count.ShouldBe(1),
                    () => arrPeriods.ContainsKey(DummyInt).ShouldBeTrue());
            }
        }

        [TestMethod]
        public void ProcessControls_OnValidCall_UpdateControls()
        {
            // Arrange
            var menuItemTemplateAdded = false;
            var control = new Control();
            var lblFilter = new Label {ID = "lblFilter"};
            var lblFilterText = new Label {ID = "lblFilterText"};
            var newMenu = new NewMenu();
            ShimTemplateBasedControl.AllInstances.ControlsGet = _ => new ControlCollection(new Control());
            var actionsMenu = new ActionsMenu();
            control.Controls.Add(lblFilter);
            control.Controls.Add(lblFilterText);
            control.Controls.Add(newMenu);
            control.Controls.Add(actionsMenu);
            ShimToolBarMenuButton.AllInstances.AddMenuItemStringStringStringStringStringString =
                (_, _2, _3, _4, _5, _6, _7) =>
                {
                    menuItemTemplateAdded = true;
                    return new MenuItemTemplate();
                };
            ShimToolBarMenuButton.AllInstances.AddMenuItemSeparator = _ => { };
            ShimToolBarMenuButton.AllInstances.GetMenuItemString = (_, __) => new MenuItemTemplate();
            ShimControl.AllInstances.FindControlString = (_, __) => lblFilterText;

            // Act
            PrivateObject.Invoke("ProcessControls", control, DummyString, DummyString, new ShimSPWeb().Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lblFilter.Text.ShouldContain(DummyString),
                () => menuItemTemplateAdded.ShouldBeTrue());
        }

        [TestMethod]
        public void RenderWebPart_OnValidCall_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyInt.ToString());
        }

        [TestMethod]
        public void RenderWebPart_OnNewPeriodIsEmpty_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(string.Empty);
        }

        [TestMethod]
        public void RenderWebPart_OnActivationsNotZero_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyInt.ToString(), 5);
        }

        [TestMethod]
        public void RenderWebPart_OnDisabled_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyInt.ToString(), 0, true);
        }

        [TestMethod]
        public void RenderWebPart_OneriodsCountIsZero_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyInt.ToString(), 0, false, 0);
        }

        private void TestRenderWebPart(string newPeriod, int activation = 0, bool disabled= false, int arrPeriodsCount = 1)
        {
            // Arrange
            var stringWriter = new StringWriter();
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            SetupShimsForHttpRequest();
            PrivateObject.SetFieldOrProperty("Activation", activation);
            PrivateObject.SetFieldOrProperty(Disabled, disabled);
            PrivateObject.SetFieldOrProperty("Error", DummyString);
            PrivateObject.SetFieldOrProperty("Act", new Act(new ShimSPWeb()));
            var sortedList = new SortedList();
            if (arrPeriodsCount > 0)
            {
                sortedList.Add(DummyInt, DummyInt);
            }
            PrivateObject.SetFieldOrProperty(Periods, sortedList);
            _queryString.Add("NewPeriod", newPeriod);
            ShimApprovalsBase.AllInstances.RenderGridHtmlTextWriterSPWebStringStringStringStringStringStringBoolean =
                (arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10) => { };
            SystemWebPartsFakes.AllInstances.WebPartManagerGet = _ => new ShimSPWebPartManager();
            ShimWebPart.AllInstances.WebPartManagerGet = _ => new ShimSPWebPartManager();
            SystemWebPartManagerFakes.AllInstances.WebPartsGet = _ => new SystemWebPartCollection();
            ShimReadOnlyCollectionBase.AllInstances.GetEnumerator = _ => new List<SystemWebPart>
            {
                new ListViewWebPart()
            }.GetEnumerator();

            // Act
            using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
            {
                PrivateObject.Invoke("RenderWebPart", htmlTextWriter);
            }
            var actualResult = stringWriter.ToString();

            // Assert
            if (activation != 0)
            {
                actualResult.ShouldContain("You have not purchased this feature");
            }
            else if (disabled)
            {
                actualResult.ShouldContain("Timesheet approvals are disabled.");
            }
            else if (arrPeriodsCount.Equals(0))
            {
                actualResult.ShouldContain("No Periods Defined.");
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                    () => actualResult.ShouldContain(DummyString),
                    () =>
                    {
                        if (!string.IsNullOrEmpty(newPeriod))
                        {
                            _cookies["EPMLiveTSPeriod"].ShouldNotBeNull();
                            _cookies["EPMLiveTSPeriod"]["period"].ShouldNotBeNull();
                            _cookies["EPMLiveTSPeriod"]["period"].ShouldContain(DummyInt.ToString());
                        }
                    });
            }
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
            PrivateObject.SetFieldOrProperty(SpList, new ShimSPList().Instance);
            PrivateObject.SetFieldOrProperty(View, new ShimSPView().Instance);
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
            PrivateObject.SetFieldOrProperty(Status, "New");
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
                PrivateObject.Invoke("RenderGrid", htmlTextWriter, new ShimSPWeb().Instance);
            }
            var actualResult = stringWriter.ToString();

            // Assert
            actualResult.ShouldSatisfyAllConditions(
                () => actualResult.ShouldContain("<link rel=\"stylesheet\" href=\"/_layouts/epmlive/modal/modalmain.css\" type=\"text/css\" />"),
                () => actualResult.ShouldContain(DummyString),
                () => actualResult.ShouldContain(DummyUrl),
                () => actualResult.ShouldContain("attachEvent(\"onXLE\",hideCol"),
                () => actualResult.ShouldContain("_listperms = false;"),
                () => actualResult.ShouldContain("LabelText='Default Display Form'"),
                () => actualResult.ShouldContain("LabelText='Default Edit Form'"),
                () => actualResult.ShouldContain("LabelText='Default New Form'"),
                () => actualResult.ShouldContain("<input type=\"hidden\" name=\"changeRes\" value=\"yes\">"),
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
                });
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
            ShimSPFormCollection.AllInstances.ItemGetString = (_, __) => new ShimSPForm();
            ShimSPFormCollection.AllInstances.ItemGetPAGETYPE = (_, __) => new ShimSPForm();
            ShimSPForm.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPListItemCollection.AllInstances.GetEnumerator = _ => new List<SPListItem>
            {
                new ShimSPListItem()
            }.GetEnumerator();
            ShimSPListItem.AllInstances.IDGet = _ => DummyInt;
            ShimSPListItem.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPListItem.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, __) => new ShimSPList();
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
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, __) => DateTime.Now;
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (_, __) => true;
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
