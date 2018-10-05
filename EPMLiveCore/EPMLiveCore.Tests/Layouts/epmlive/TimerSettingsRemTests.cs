using System;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TimerSettingsRemTests
    {
        private timersettings testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags nonPublicInstance;
        private object sender;
        private EventArgs eventArgs;
        private DateTime now;
        private Guid guid;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSqlDataReader dataReader;
        private const string DummyString = "DummyString";
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string PageLoadMethodName = "Page_Load";
        private const string LoadDataMethodName = "loadData";
        private const string Button1ClickMethodName = "Button1_Click";
        private const string MessagesLabelName = "lblMessages";
        private const string ListsTextBoxName = "Lists";
        private const string ResPlannerListsTextBoxName = "txtResPlannerLists";
        private const string FixTimesDropdownName = "FixTimes";
        private const string LastResResultLabelName = "lblLastResResult";
        private const string LastRunLabelName = "lblLastRun";
        private const string LastResRunLabelName = "lblLastResRun";
        private const string RunNowButtonName = "btnRunNow";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();

            testObject = new timersettings();
            privateObject = new PrivateObject(testObject);

            SetupProperties();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimHttpResponse.AllInstances.CacheGet = _ => new ShimHttpCachePolicy()
            {
                SetCacheabilityHttpCacheability = __ => { }
            };
            ShimHttpResponse.AllInstances.ExpiresSetInt32 = (_, __) => { };
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => spWeb,
                SiteGet = () => spSite
            };
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ => false;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, _1, _2) => { };
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.enqueueGuidInt32 = (_, __) => { };
            ShimPage.AllInstances.IsPostBackGet = _ => false;
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
        }

        private void SetupProperties()
        {
            privateObject.SetFieldOrProperty(ListsTextBoxName, nonPublicInstance, new TextBox());
            privateObject.SetFieldOrProperty(ResPlannerListsTextBoxName, nonPublicInstance, new TextBox());
            privateObject.SetFieldOrProperty(FixTimesDropdownName, nonPublicInstance, new DropDownList());
            privateObject.SetFieldOrProperty(MessagesLabelName, nonPublicInstance, new Label());
            privateObject.SetFieldOrProperty(LastResResultLabelName, nonPublicInstance, new Label());
            privateObject.SetFieldOrProperty(LastRunLabelName, nonPublicInstance, new Label());
            privateObject.SetFieldOrProperty(LastResRunLabelName, nonPublicInstance, new Label());
            privateObject.SetFieldOrProperty(RunNowButtonName, nonPublicInstance, new Button());
        }

        private void SetupVariables()
        {
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            sender = new object();
            eventArgs = EventArgs.Empty;
            now = DateTime.Now;
            guid = Guid.Parse(GuidString);
            dataReader = new ShimSqlDataReader()
            {
                Read = () => true,
                Close = () => { },
                IsDBNullInt32 = _ => false,
                GetInt32Int32 = _ => 1,
                GetStringInt32 = _ => DummyString,
                GetGuidInt32 = _ => guid,
                GetDateTimeInt32 = _ => now
            };
            spSite = new ShimSPSite()
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                IDGet = () => guid
            };
            spWeb = new ShimSPWeb()
            {
                SiteGet = () => spSite,
                ServerRelativeUrlGet = () => DummyString,
                IDGet = () => guid,
                AllowUnsafeUpdatesSetBoolean = _ => { }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void Page_Load_IsRootWebTrue_LoadsPage()
        {
            // Arrange
            var validation = 0;

            ShimSPUtility.TransferToErrorPageString = _ =>
            {
                validation = validation + 1;
            };
            Shimtimersettings.AllInstances.loadDataSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            spWeb.IsRootWebGet = () => true;

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { sender, eventArgs });
            var lists = (TextBox)privateObject.GetFieldOrProperty(ListsTextBoxName, nonPublicInstance);
            var plannerLists = (TextBox)privateObject.GetFieldOrProperty(ResPlannerListsTextBoxName, nonPublicInstance);

            // Assert
            validation.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(2),
                () => lists.Text.ShouldBe(DummyString),
                () => plannerLists.Text.ShouldBe(DummyString));
        }

        [TestMethod]
        public void Page_Load_IsRootWebFalse_LoadsPage()
        {
            // Arrange
            var validation = 0;

            ShimSPUtility.TransferToErrorPageString = _ =>
            {
                validation = validation + 1;
            };
            Shimtimersettings.AllInstances.loadDataSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            spWeb.IsRootWebGet = () => false;

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { sender, eventArgs });
            var lists = (TextBox)privateObject.GetFieldOrProperty(ListsTextBoxName, nonPublicInstance);
            var plannerLists = (TextBox)privateObject.GetFieldOrProperty(ResPlannerListsTextBoxName, nonPublicInstance);

            // Assert
            validation.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(1),
                () => lists.Text.ShouldBe(string.Empty),
                () => plannerLists.Text.ShouldBe(string.Empty));
        }

        [TestMethod]
        public void LoadData_Option0_LoadsData()
        {
            // Arrange
            var getIntHit = -1;
            var validation = 0;
            var getIntResult = new int[] { 0, 0, 0 };

            dataReader.GetInt32Int32 = _ =>
            {
                getIntHit = getIntHit + 1;
                return getIntResult[getIntHit];
            };
            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => "Run Timer Now";

            // Act
            privateObject.Invoke(LoadDataMethodName, nonPublicInstance, new object[] { spWeb.Instance });
            var messageLabel = (Label)privateObject.GetFieldOrProperty(MessagesLabelName, nonPublicInstance);
            var resultLabel = (Label)privateObject.GetFieldOrProperty(LastResResultLabelName, nonPublicInstance);
            var lastRunLabel = (Label)privateObject.GetFieldOrProperty(LastRunLabelName, nonPublicInstance);

            // Assert
            validation.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(0),
                () => getIntHit.ShouldBe(1),
                () => messageLabel.Text.ShouldBe("Queued"),
                () => resultLabel.Text.ShouldBe("Queued"),
                () => lastRunLabel.Text.ShouldBe(now.ToString()));
        }

        [TestMethod]
        public void LoadData_Option1_LoadsData()
        {
            // Arrange
            var getIntHit = -1;
            var validation = 0;
            var getIntResult = new int[] { 0, 1, 1, 5, 7 };

            dataReader.GetInt32Int32 = _ =>
            {
                getIntHit = getIntHit + 1;
                return getIntResult[getIntHit];
            };
            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => "Run Timer Now";

            // Act
            privateObject.Invoke(LoadDataMethodName, nonPublicInstance, new object[] { spWeb.Instance });
            var messageLabel = (Label)privateObject.GetFieldOrProperty(MessagesLabelName, nonPublicInstance);
            var resultLabel = (Label)privateObject.GetFieldOrProperty(LastResResultLabelName, nonPublicInstance);
            var lastRunLabel = (Label)privateObject.GetFieldOrProperty(LastRunLabelName, nonPublicInstance);

            // Assert
            validation.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(0),
                () => getIntHit.ShouldBe(4),
                () => messageLabel.Text.ShouldBe("Processing (5%)"),
                () => resultLabel.Text.ShouldBe("Processing (7%)"),
                () => lastRunLabel.Text.ShouldBe(now.ToString()));
        }

        [TestMethod]
        public void LoadData_Option5Option0_LoadsData()
        {
            // Arrange
            var getIntHit = -1;
            var validation = 0;
            var getIntResult = new int[] { 0, 5, 5, 0 };

            dataReader.GetInt32Int32 = _ =>
            {
                getIntHit = getIntHit + 1;
                return getIntResult[getIntHit];
            };
            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => "Run Timer Now";

            // Act
            privateObject.Invoke(LoadDataMethodName, nonPublicInstance, new object[] { spWeb.Instance });
            var messageLabel = (Label)privateObject.GetFieldOrProperty(MessagesLabelName, nonPublicInstance);
            var resultLabel = (Label)privateObject.GetFieldOrProperty(LastResResultLabelName, nonPublicInstance);
            var lastRunLabel = (Label)privateObject.GetFieldOrProperty(LastRunLabelName, nonPublicInstance);
            var lastResRunLabel = (Label)privateObject.GetFieldOrProperty(LastResRunLabelName, nonPublicInstance);

            // Assert
            validation.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(0),
                () => getIntHit.ShouldBe(3),
                () => messageLabel.Text.ShouldBe(DummyString),
                () => resultLabel.Text.ShouldBe("Queued"),
                () => lastRunLabel.Text.ShouldBe(now.ToString()),
                () => lastResRunLabel.Text.ShouldBe(now.ToString()));
        }

        [TestMethod]
        public void LoadData_Option5Option1_LoadsData()
        {
            // Arrange
            var getIntHit = -1;
            var validation = 0;
            var getIntResult = new int[] { 0, 5, 5, 1, 1, 9 };

            dataReader.GetInt32Int32 = _ =>
            {
                getIntHit = getIntHit + 1;
                return getIntResult[getIntHit];
            };
            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => "Run Timer Now";

            // Act
            privateObject.Invoke(LoadDataMethodName, nonPublicInstance, new object[] { spWeb.Instance });
            var messageLabel = (Label)privateObject.GetFieldOrProperty(MessagesLabelName, nonPublicInstance);
            var resultLabel = (Label)privateObject.GetFieldOrProperty(LastResResultLabelName, nonPublicInstance);
            var lastRunLabel = (Label)privateObject.GetFieldOrProperty(LastRunLabelName, nonPublicInstance);
            var lastResRunLabel = (Label)privateObject.GetFieldOrProperty(LastResRunLabelName, nonPublicInstance);

            // Assert
            validation.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(0),
                () => getIntHit.ShouldBe(5),
                () => messageLabel.Text.ShouldBe(DummyString),
                () => resultLabel.Text.ShouldBe("Processing (9%)"),
                () => lastRunLabel.Text.ShouldBe(now.ToString()),
                () => lastResRunLabel.Text.ShouldBe(now.ToString()));
        }

        [TestMethod]
        public void LoadData_Option5Option5_LoadsData()
        {
            // Arrange
            var getIntHit = -1;
            var validation = 0;
            var getIntResult = new int[] { 0, 5, 5, 5, 5, 9 };

            dataReader.GetInt32Int32 = _ =>
            {
                getIntHit = getIntHit + 1;
                return getIntResult[getIntHit];
            };
            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => "Run Timer Now";

            // Act
            privateObject.Invoke(LoadDataMethodName, nonPublicInstance, new object[] { spWeb.Instance });
            var messageLabel = (Label)privateObject.GetFieldOrProperty(MessagesLabelName, nonPublicInstance);
            var resultLabel = (Label)privateObject.GetFieldOrProperty(LastResResultLabelName, nonPublicInstance);
            var lastRunLabel = (Label)privateObject.GetFieldOrProperty(LastRunLabelName, nonPublicInstance);
            var lastResRunLabel = (Label)privateObject.GetFieldOrProperty(LastResRunLabelName, nonPublicInstance);

            // Assert
            validation.ShouldSatisfyAllConditions(
                () => validation.ShouldBe(1),
                () => getIntHit.ShouldBe(4),
                () => messageLabel.Text.ShouldBe(DummyString),
                () => resultLabel.Text.ShouldBe(DummyString),
                () => lastRunLabel.Text.ShouldBe(now.ToString()),
                () => lastResRunLabel.Text.ShouldBe(now.ToString()));
        }

        [TestMethod]
        public void Button1_Click_SourceEmpty_Redirects()
        {
            // Arrange
            var validation = 0;

            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => string.Empty;
            ShimHttpResponse.AllInstances.RedirectString = (_, path) =>
            {
                if (path.Equals(DummyString))
                {
                    validation = validation + 10;
                }
            };
            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, _1, _2) =>
            {
                validation = validation + 20;
                return true;
            };

            // Act
            privateObject.Invoke(Button1ClickMethodName, nonPublicInstance, new object[] { sender, eventArgs });

            // Assert
            validation.ShouldBe(21);
        }

        [TestMethod]
        public void Button1_Click_SourceNotEmpty_Redirects()
        {
            // Arrange
            var validation = 0;

            ShimHttpRequest.AllInstances.ItemGetString = (_, __) => DummyString;
            ShimHttpResponse.AllInstances.RedirectString = (_, path) =>
            {
                if (path.Equals(DummyString))
                {
                    validation = validation + 10;
                }
            };
            Shimtimersettings.AllInstances.saveSettingsSPWeb = (_, __) =>
            {
                validation = validation + 1;
            };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, _1, _2) =>
            {
                validation = validation + 20;
                return true;
            };

            // Act
            privateObject.Invoke(Button1ClickMethodName, nonPublicInstance, new object[] { sender, eventArgs });

            // Assert
            validation.ShouldBe(11);
        }
    }
}
