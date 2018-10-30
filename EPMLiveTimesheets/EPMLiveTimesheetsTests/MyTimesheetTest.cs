using System;
using System.Collections;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Xml.Fakes;
using EPMLive.TestFakes;
using EPMLiveCore;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using TimeSheets;
using MicrosoftShimRibbon = Microsoft.Web.CommandUI.Fakes.ShimRibbon;
using SystemWebPart = System.Web.UI.WebControls.WebParts.WebPart;
using SystemWebPartCollection = System.Web.UI.WebControls.WebParts.WebPartCollection;
using SystemWebPartManagerFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPartManager;
using SystemWebPartsFakes = System.Web.UI.WebControls.WebParts.Fakes.ShimWebPart;

namespace EPMLiveTimesheets.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public class MyTimesheetTest : TestClassInitializer<MyTimesheet>
    {
        private const string DummyUrl = "http://dummy.url";
        private HttpContext _httpContext;
        private HttpRequest _httpRequest;
        private HttpResponse _httpResponse;
        private static readonly NameValueCollection _queryString = new NameValueCollection();

        [TestInitialize]
        public void TestInitializeSub()
        {
            InitializeAllControls();
        }

        [TestMethod]
        public void CreateChildControls_OnValidCall_UpdateControls()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(DummyInt.ToString(), false, DummyInt, false);
        }

        [TestMethod]
        public void CreateChildControls_OnValidCallAndDtPeriodsHasRows_UpdateControls()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(DummyInt.ToString(), true, 0, true);
        }

        [TestMethod]
        public void CreateChildControls_OnPeriodIdEmpty_UpdateControls()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(string.Empty, false, DummyInt, true);
        }

        [TestMethod]
        public void CreateChildControls_OnPeriodIdEmptyAndDtPeriodsHasRows_UpdateControls()
        {
            // Arrange, Act, Assert
            TestCreateChildControls(string.Empty, true, 0, true);
        }

        [TestMethod]
        public void OnInit_OnValidCall_SetGridType()
        {
            // Arrange
            SetupShimsForHttpRequest();
            _queryString.Add("debug", bool.TrueString.ToLower());
            _queryString.Add("Approvals", bool.TrueString.ToLower());

            //Act
            PrivateObject.Invoke("OnInit", EventArgs.Empty);

            // Assert
            Get<MyTimesheetProperties>("properties").GridType.ShouldBe(1);
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
            Get<MyTimesheetProperties>("properties").FullGridId.ShouldContain($"{DummyInt}{DummyString}");
        }

        [TestMethod]
        public void GetViews_OnValidCall_ReturnString()
        {
            // Arrange
            var properties = new MyTimesheetProperties()
            {
                Views = new ViewManager($"Default View")
            };
            PrivateObject.SetField("properties", properties);

            // Act
            var actualResult = PrivateObject.Invoke("GetViews") as string;

            // Assert
            actualResult.ShouldContain("{'iconClass': '','text': 'My Timesheet','events': [{'eventName': 'click','function': function () { location.href=window.epmLive.currentWebUrl + '/_layouts/15/epmlive/mytimesheet.aspx?Approvals=true'; }}]}");
        }

        [TestMethod]
        public void GetViews_OnNotDefaultView_ReturnString()
        {
            // Arrange
            var properties = new MyTimesheetProperties()
            {
                Views = new ViewManager($"{DummyString}^{DummyString}`{DummyString}^{DummyString};#")
            };
            PrivateObject.SetField("properties", properties);

            // Act
            var actualResult = PrivateObject.Invoke("GetViews") as string;

            // Assert
            actualResult.ShouldBeNullOrEmpty();
        }

        [TestMethod]
        public void RenderWebPart_OnVCalidCall_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyInt, bool.TrueString.ToLower(), DummyInt, DummyInt);
        }

        [TestMethod]
        public void RenderWebPart_OnVCalidCallAndNextPeriodIsZero_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(DummyInt, bool.TrueString.ToLower(), 0, 0);
        }

        [TestMethod]
        public void RenderWebPart_OnDefaultIsFalse_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(0, bool.FalseString.ToLower(), DummyInt, DummyInt);
        }

        [TestMethod]
        public void RenderWebPart_OnDefaultIsFalseAndNextPeriodIsZero_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(0, bool.FalseString.ToLower(), 0, 0);
        }

        [TestMethod]
        public void RenderWebPart_OnActivationsNotZero_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(0, bool.FalseString.ToLower(), 0, 0, 2);
        }

        [TestMethod]
        public void RenderWebPart_OnHasPeriodsIsFalse_WriteToHtmlTextWriter()
        {
            // Arrange, Act, Assert
            TestRenderWebPart(0, bool.FalseString.ToLower(), 0, 0, 0, false);
        }

        [TestMethod]
        public void OnPreRender_OnValidCall_RegisterScripts()
        {
            // Arrange
            var registerScriptsInvoked = false;
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            SetupShimsForHttpRequest();
            PrivateObject.SetField("timeDebug", new TimeDebug(DummyString, bool.TrueString));
            var properties = new MyTimesheetProperties()
            {
                GridType = 0,
                HasPeriods = true,
                Delegates = string.Empty,
                CurrentDelegate = DummyString
            };
            PrivateObject.SetField("properties", properties);
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
                    return string.Join("|", Enumerable.Repeat<string>(bool.TrueString, 30));
                }
                return DummyString;
            };
            ShimCssRegistration.RegisterString = _ => { };
            ShimScriptLink.RegisterPageStringBoolean = (_, _2, _3) => { };
            ShimSPPageContentManager.RegisterScriptFilePageStringBooleanBooleanStringString = (_, _2, _3, _4, _5, _6) => { };
            ShimWebPart.AllInstances.OnPreRenderEventArgs = (_, __) => { };

            // Act
            PrivateObject.Invoke("OnPreRender", EventArgs.Empty);

            // Assert
            registerScriptsInvoked.ShouldBeTrue();
        }

        [TestMethod]
        public void WebPartContextualInfo_OnGet_RegturnWebPartContextualInfo()
        {
            // Arrange
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            var properties = new MyTimesheetProperties()
            {
                GridType = 0
            };
            PrivateObject.SetField("properties", properties);
            ShimSPRibbon.GetWebPartPageComponentIdWebPart = _ => DummyString;

            // Act
            var actualResult = TestEntity.WebPartContextualInfo;

            // Assert
            actualResult.ShouldSatisfyAllConditions(
            () => actualResult.ShouldBeOfType<WebPartContextualInfo>(),
            () => actualResult.PageComponentId.ShouldContain(DummyString));
        }

        private void TestRenderWebPart(int gridType, string isDefault, int previousPeriod, int nextPeriod, int activation = 0, bool bHasPeriods = true)
        {
            // Arrange
            var stringWriter = new StringWriter();
            var viewManager = new ViewManager(DummyString);
            viewManager.Views = new Dictionary<string, Dictionary<string, string>>
            {
                { DummyString, new Dictionary<string, string> { { "Default", isDefault } } }
            };
            SetupShimsForSqlClient();
            SetupShimsForSharePoint();
            SetupShimsForHttpRequest();
            PrivateObject.SetField("timeDebug", new TimeDebug(DummyString, bool.TrueString));
            _queryString.Add("Delegate", DummyInt.ToString());
            _queryString.Add(DummyString, DummyString);
            ShimWebPart.AllInstances.QualifierGet = _ => DummyString;
            SystemWebPartsFakes.AllInstances.WebPartManagerGet = _ => new ShimSPWebPartManager();
            ShimWebPart.AllInstances.WebPartManagerGet = _ => new ShimSPWebPartManager();
            SystemWebPartManagerFakes.AllInstances.WebPartsGet = _ => new SystemWebPartCollection();
            ShimReadOnlyCollectionBase.AllInstances.GetEnumerator = _ => new List<SystemWebPart>
            {
                new ListViewWebPart()
            }.GetEnumerator();
            ShimSPWeb.AllInstances.UrlGet = _ => "/";
            ShimHttpRequest.AllInstances.RawUrlGet = _ => $"{DummyUrl}?test=test";
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
            var properties = new MyTimesheetProperties()
            {
                Activation = activation,
                HasPeriods = bHasPeriods,
                IsLocked = true,
                FullGridId = DummyString,
                PeriodName = DummyString,
                DataParam = DummyString,
                PeriodList = $"{DummyString}|{DummyString},{DummyString}|{DummyString}{DummyString}",
                GridType = gridType,
                PreviousPeriodId = previousPeriod,
                NextPeriodId = nextPeriod,
                Act = new Act(new ShimSPWeb()),
                Views = viewManager,
                Settings = new TimesheetSettings(new ShimSPWeb())
            };
            PrivateObject.SetField("properties", properties);

            // Act
            using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
            {
                PrivateObject.Invoke("RenderWebPart", htmlTextWriter);
            }
            var actualResult = stringWriter.ToString();

            // Assert
            if (activation != 0)
            {
                actualResult.ShouldContain("Too many users activated for this feature.");
            }
            else if (!bHasPeriods)
            {
                actualResult.ShouldContain("There are no periods setup for this TimeSheet. Please contact your system administrator");
            }
            else
            {
                actualResult.ShouldSatisfyAllConditions(
                   () => actualResult.ShouldContain("CanEditViews = true"),
                   () => actualResult.ShouldContain($"var TSObject{DummyString} = new Object()"),
                   () => actualResult.ShouldContain($"<option value={DummyString}>"),
                   () => actualResult.ShouldContain($"disabled='disabled'"),
                   () => actualResult.ShouldContain(@"var viewNameDiv = document.getElementById(""viewNameDiv"");"));
            }
        }

        private void TestCreateChildControls(string periodId, bool dtPeriodsHasRows, int gridType, bool scriptManagerIsNull)
        {
            // Arrange
            SetupShimsForSharePoint();
            SetupShimsForSqlClient();
            SetupShimsForHttpRequest();
            PrivateObject.SetField("timeDebug", new TimeDebug(DummyString, bool.TrueString));
            var properties = new MyTimesheetProperties()
            {
                GridType = gridType
            };
            PrivateObject.SetField("properties", properties);
            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable
            {
                {"EPMLiveKeys", $"{DummyString}\t{DummyString}"}
            };
            ShimAct.AllInstances.CheckOnlineFeatureLicenseActFeatureStringSPSite = (_, _2, _3, _4) => 0;
            if (!string.IsNullOrEmpty(periodId))
            {
                _queryString.Add("NewPeriod", periodId);
            }
            _httpRequest.QueryString.Add("Delegate", DummyInt.ToString());
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, ds) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("CurPeriod", typeof(string));
                dataTable.Columns.Add("period_id", typeof(int));
                dataTable.Columns.Add("period_start", typeof(DateTime));
                dataTable.Columns.Add("period_end", typeof(DateTime));
                dataTable.Rows.Add("2", 2, DateTime.Now, DateTime.Now);
                if (dtPeriodsHasRows)
                {
                    dataTable.Rows.Add("1", DummyInt, DateTime.Now, DateTime.Now);
                }
                ds.Tables.Add(dataTable);
                return DummyInt;
            };
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, indx) =>
            {
                if (indx == 0)
                {
                    return DateTime.Now.AddDays(-2);
                }
                return DateTime.Now;
            };
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
            ShimAPITeam.GetResourcePoolStringSPWebXmlNodeListBoolean = (_, _2, _3, _4) =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("SPID", typeof(string));
                dataTable.Columns.Add("Title", typeof(string));
                dataTable.Rows.Add(DummyInt.ToString(), DummyString);
                return dataTable;
            };
            ShimScriptManager.GetCurrentPage = _ => scriptManagerIsNull ? null : new ScriptManager();
            ShimServiceReference.ConstructorString = (_, __) => { };
            ShimHttpUtility.HtmlEncodeString = str => str;
            ShimPage.AllInstances.FormGet = _ => new HtmlForm();

            // Act
            PrivateObject.Invoke("CreateChildControls");

            // Assert
            this.ShouldSatisfyAllConditions(
                () => properties.Delegates.ShouldContain(DummyString),
                () => properties.Views.ShouldNotBeNull(),
                () => properties.DataParam.ShouldContain("UserId=\"1\"/>"),
                () => properties.Columns.ShouldContain(bool.TrueString),
                () => properties.DataColumns.ShouldContain(bool.TrueString),
                () => properties.LayoutParam.ShouldContain("UserId=\"1\""));
        }

        private void SetupShimsForSharePoint()
        {
            ShimSPContext.CurrentGet = () => new ShimSPContext();
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
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = elevated => { elevated(); };
            ShimSPSite.AllInstances.IDGet = _=> Guid.NewGuid();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPSite.ConstructorGuid = (_, __) => { };
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
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.CountGet = _ => DummyInt;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, __) => new ShimSPField();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.BaseTypeGet = _ => SPBaseType.DiscussionBoard;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DiscussionBoard;
            ShimSPList.AllInstances.FormsGet = _ => new ShimSPFormCollection();
        }

        private void SetupShimsForHttpRequest()
        {
            _queryString.Clear();
            _httpRequest = new HttpRequest(DummyString, DummyUrl, DummyString);
            _httpResponse = new HttpResponse(TextWriter.Null);
            _httpContext = new HttpContext(_httpRequest, _httpResponse);
            ShimHttpContext.CurrentGet = () => _httpContext;
            ShimPage.AllInstances.RequestGet = _ => _httpRequest;
            ShimHttpRequest.AllInstances.QueryStringGet = _ => _queryString;
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
