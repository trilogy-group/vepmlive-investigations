using System;
using System.Collections.Specialized.Fakes;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Fakes;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.Layouts.epmlive;
using EPMLiveWebParts.Layouts.epmlive.Fakes;
using EPMLiveWebParts.SSRS2006.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using DataSource = EPMLiveWebParts.SSRS2006.DataSource;

namespace EPMLiveWebParts.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class TlwizardTests
    {
        private IDisposable _shimsObject;
        private tlwizard _testObj;
        private PrivateObject _privateObj;
        private PrivateType _privateType;
        private ShimSPSite _site;
        private ShimSPWeb _web;
        private TextBox _txtReportDatabase;
        private TextBox _txtReportServer;
        private TextBox _txtReportPassword;
        private TextBox _txtReportUsername;
        private HiddenField _hdnSaveReportPassword;
        private HiddenField _hdnStep;
        private HiddenField _hdnReportPassword;
        private CheckBox _chkWindows;
        private Label _lblNoReporting;
        private Label _lblReportingError;
        private Panel _pnl1;
        private Panel _pnl2;
        private Panel _pnl3;
        private Panel _pnlDone;
        private Panel _pnlMessage;
        private Panel _pnlProcessing;
        private bool _navigationNodeUpdated;
        private bool _webUpdated;
        private bool _quickLaunchGenerated;
        private bool _webPropertyUpdated;
        private bool _nonQueryExecuted;
        private bool _listItemUpdated;
        private bool _odcFilesProcessed;
        private bool _excelFilesProcessed;
        private bool _listItemSystemUpdated;
        private bool _izendaReportsProcessed;
        private bool _categoryRemoved;
        private bool _scriptRegistered;

        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string DummyUser = "DummyDomain\\DummyUser";
        private const string DummyReportUrl = "/reportService";
        private const int IntValueOne = 1;
        private const int IntValueTwo = 2;
        private const int IntValueThree = 3;
        private const int IntValueFour = 4;
        private const int IntValueFive = 5;

        private const string PageLoadMethod = "Page_Load";
        private const string BtnBackClickMethod = "btnBack_Click";
        private const string BtnSkipClickMethod = "btnSkip_Click";
        private const string BtnNextClickMethod = "btnNext_Click";
        private const string BtnYesClickMethod = "btnYes_Click";
        private const string BtnCancelClickMethod = "btnCancel_Click";
        private const string GetSiteGroupMethod = "GetSiteGroup";
        private const string CheckConnectionMethod = "checkConnection";
        private const string Ssrsurl = "ssrsurl";
        private const string EPMLiveReportDB = "EPMLiveReportDB";
        private const string ReportingServicesURL = "ReportingServicesURL";
        private const string DataSources = "Data Sources";

        private const string NoReportingUrlEntered = "No reporting url has been entered in Central Admin.";
        private const string InvalidUserName = "Invalid username or password";

        private const string TxtReportDatabase = "txtReportDatabase";
        private const string TxtReportServer = "txtReportServer";
        private const string TxtReportPassword = "txtReportPassword";
        private const string TxtReportUsername = "txtReportUsername";
        private const string HdnSaveReportPassword = "hdnSaveReportPassword";
        private const string HdnStep = "hdnStep";
        private const string HdnReportPassword = "hdnReportPassword";
        private const string ChkWindows = "chkWindows";
        private const string LblNoReporting = "lblNoReporting";
        private const string LblReportingError = "lblReportingError";
        private const string Pnl1 = "pnl1";
        private const string Pnl2 = "pnl2";
        private const string Pnl3 = "pnl3";
        private const string PnlDone = "pnlDone";
        private const string PnlMessage = "pnlMessage";
        private const string PnlProcessing = "pnlProcessing";

        [TestInitialize]
        public void TestInitialize()
        {
            _navigationNodeUpdated = false;
            _webUpdated = false;
            _quickLaunchGenerated = false;
            _webPropertyUpdated = false;
            _nonQueryExecuted = false;
            _listItemUpdated = false;
            _odcFilesProcessed = false;
            _excelFilesProcessed = false;
            _listItemSystemUpdated = false;
            _izendaReportsProcessed = false;
            _categoryRemoved = false;
            _scriptRegistered = false;
            _shimsObject = ShimsContext.Create();
            _testObj = new tlwizard();
            _privateObj = new PrivateObject(_testObj);
            _privateType = new PrivateType(typeof(tlwizard));

            InitializeUiControls();

            SetupShims();
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

            _txtReportDatabase = (TextBox)_privateObj.GetFieldOrProperty(TxtReportDatabase);
            _txtReportServer = (TextBox)_privateObj.GetFieldOrProperty(TxtReportServer);
            _txtReportPassword = (TextBox)_privateObj.GetFieldOrProperty(TxtReportPassword);
            _txtReportUsername = (TextBox)_privateObj.GetFieldOrProperty(TxtReportUsername);
            _hdnSaveReportPassword = (HiddenField)_privateObj.GetFieldOrProperty(HdnSaveReportPassword);
            _hdnStep = (HiddenField)_privateObj.GetFieldOrProperty(HdnStep);
            _hdnReportPassword = (HiddenField)_privateObj.GetFieldOrProperty(HdnReportPassword);
            _chkWindows = (CheckBox)_privateObj.GetFieldOrProperty(ChkWindows);
            _lblNoReporting = (Label)_privateObj.GetFieldOrProperty(LblNoReporting);
            _lblReportingError = (Label)_privateObj.GetFieldOrProperty(LblReportingError);
            _pnl1 = (Panel)_privateObj.GetFieldOrProperty(Pnl1);
            _pnl2 = (Panel)_privateObj.GetFieldOrProperty(Pnl2);
            _pnl3 = (Panel)_privateObj.GetFieldOrProperty(Pnl3);
            _pnlDone = (Panel)_privateObj.GetFieldOrProperty(PnlDone);
            _pnlMessage = (Panel)_privateObj.GetFieldOrProperty(PnlMessage);
            _pnlProcessing = (Panel)_privateObj.GetFieldOrProperty(PnlProcessing);
        }

        private void SetupShims()
        {
            var count = 0;
            _site = new ShimSPSite
            {
                WebApplicationGet = () => new ShimSPWebApplication(),
                UrlGet = () => DummyUrl,
                IDGet = () => Guid.NewGuid(),
            };
            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => _web;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPSite.AllInstances.AllowUnsafeUpdatesSetBoolean = (_, __) => { };

            _web = new ShimSPWeb
            {
                ServerRelativeUrlGet = () => DummyUrl,
                IDGet = () => Guid.NewGuid(),
                UrlGet = () => DummyUrl,
                SiteGet = () => _site,
                NavigationGet = () => new ShimSPNavigation
                {
                    TopNavigationBarGet = () => new ShimSPNavigationNodeCollection().Bind(new SPNavigationNode[]
                    {
                        new ShimSPNavigationNode
                        {
                            Update = () => _navigationNodeUpdated = true
                        }
                    })
                },
                Update = () => _webUpdated = true,
                PropertiesGet = () => new ShimSPPropertyBag
                {
                    Update = () => _webPropertyUpdated = true
                },
                ListsGet = () => new ShimSPListCollection
                {
                    TryGetListString = _ => new ShimSPList
                    {
                        ItemsGet = () => new ShimSPListItemCollection
                        {
                            ItemGetInt32 = __ => new ShimSPListItem
                            {
                                Update = () => _listItemUpdated = true
                            }
                        },
                        GetItemsSPQuery = __ => new ShimSPListItemCollection().Bind(new SPListItem[]
                        {
                            new ShimSPListItem
                            {
                                SystemUpdate = () => _listItemSystemUpdated = true
                            }
                        })
                    },
                    ItemGetString = _ => new ShimSPDocumentLibrary
                    {
                        GetItemsInFolderSPViewSPFolder = (x, y) =>
                        {
                            count++;
                            if (count < 3)
                            {
                                return new ShimSPListItemCollection().Bind(new SPListItem[]
                                {
                                    new ShimSPListItem
                                    {
                                        FileSystemObjectTypeGet = () => SPFileSystemObjectType.Folder,
                                        NameGet = () => DataSources,
                                        UrlGet = () => DummyString
                                    }
                                });
                            }
                            else if (count < 4)
                            {
                                return new ShimSPListItemCollection().Bind(new SPListItem[]
                                {
                                    new ShimSPListItem
                                    {
                                        FileSystemObjectTypeGet = () => SPFileSystemObjectType.File,
                                        NameGet = () => DummyString,
                                        UrlGet = () => DummyString
                                    }
                                });
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                },
                CurrentUserGet = () => new ShimSPUser(),
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    AddGuid = _ => new ShimSPFeature()
                },
                SiteGroupsGet = () => new ShimSPGroupCollection().Bind(new SPGroup[]
                {
                    new ShimSPGroup
                    {
                        NameGet = () => DummyString
                    }
                })
            };
            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder
            {
                FilesGet = () => new ShimSPFileCollection
                {
                    AddStringByteArrayHashtableBoolean = (_1, _2, _3, _4) => new ShimSPFile()
                },
                UrlGet = () => DummyUrl
            };

            ShimSPPersistedObject.AllInstances.IdGet = _ => Guid.NewGuid();
            ShimSPPersistedObject.AllInstances.GetChildOf1String<ReportAuth>((_, __) => new ShimReportAuth
            {
                UsernameGet = () => DummyString,
                PasswordGet = () => DummyString
            });

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => _site,
                WebGet = () => _web
            };

            ShimCoreFunctions.getWebAppSettingGuidString = (guid, setting) =>
            {
                switch (setting)
                {
                    case ReportingServicesURL:
                        return DummyReportUrl;
                    default:
                        return DummyString;
                }
            };
            ShimCoreFunctions.DecryptStringString = (cipherText, passPhrase) => cipherText;

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimSqlConnection.ConstructorString = (_, __) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };

            ShimSqlCommand.ConstructorStringSqlConnection = (_, __, ___) => { };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                _nonQueryExecuted = true;
                return IntValueOne;
            };

            ShimSqlDataReader.AllInstances.Close = _ => { };

            ShimPage.AllInstances.IsPostBackGet = _ => false;
            ShimPage.AllInstances.ClientScriptGet = _ => new ShimClientScriptManager
            {
                RegisterStartupScriptTypeStringString = (_1, _2, _3) => _scriptRegistered = true
            };
            ShimPage.AllInstances.GetPostBackEventReferenceControl = (_, __) => DummyString;

            ShimWorkEngineAPI.GenerateQuickLaunchFromAppStringSPWeb = (_, __) =>
            {
                _quickLaunchGenerated = true;
                return string.Empty;
            };

            ShimCacheStore.CurrentGet = () => new ShimCacheStore
            {
                RemoveCategoryString = _ => _categoryRemoved = true
            };

            ShimCacheStoreCategory.ConstructorSPWeb = (_, __) => { };
            ShimCacheStoreCategory.AllInstances.NavigationGet = _ => DummyString;
        }

        [TestMethod]
        public void PageLoad_WhenExecuteReaderIsTrue_ConfirmResult()
        {
            // Arrange
            SetupForPageLoad(true, DummyString);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _txtReportDatabase.Text.ShouldBe(DummyString),
                () => _txtReportServer.Text.ShouldBe(DummyString),
                () => _txtReportPassword.Text.ShouldBe(DummyString),
                () => _txtReportUsername.Text.ShouldBe(DummyString),
                () => _txtReportPassword.Enabled.ShouldBeFalse(),
                () => _txtReportDatabase.Enabled.ShouldBeTrue(),
                () => _txtReportUsername.Enabled.ShouldBeFalse(),
                () => _txtReportServer.Enabled.ShouldBeTrue(),
                () => _hdnSaveReportPassword.Value.ShouldBe(DummyString),
                () => _chkWindows.Enabled.ShouldBeFalse());
        }

        [TestMethod]
        public void PageLoad_WhenExecuteReaderIsFalse_ConfirmResult()
        {
            // Arrange
            SetupForPageLoad(false, DummyString);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _txtReportDatabase.Text.ShouldBeEmpty(),
                () => _txtReportServer.Text.ShouldBeEmpty(),
                () => _chkWindows.Enabled.ShouldBeFalse(),
                () => _txtReportPassword.Enabled.ShouldBeFalse(),
                () => _txtReportDatabase.Enabled.ShouldBeFalse(),
                () => _txtReportUsername.Enabled.ShouldBeFalse(),
                () => _txtReportServer.Enabled.ShouldBeFalse(),
                () => _lblNoReporting.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void PageLoad_WhenConnectionStringIsEmpty_ConfirmResult()
        {
            // Arrange
            SetupForPageLoad(false, string.Empty);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _txtReportDatabase.Text.ShouldBeEmpty(),
                () => _txtReportServer.Text.ShouldBeEmpty(),
                () => _chkWindows.Enabled.ShouldBeFalse(),
                () => _txtReportPassword.Enabled.ShouldBeFalse(),
                () => _txtReportDatabase.Enabled.ShouldBeFalse(),
                () => _txtReportUsername.Enabled.ShouldBeFalse(),
                () => _txtReportServer.Enabled.ShouldBeFalse(),
                () => _lblNoReporting.Visible.ShouldBeTrue());
        }

        private static void SetupForPageLoad(bool reader, string connectionString)
        {
            ShimSqlDataReader.AllInstances.Read = _ => reader;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => connectionString;
        }

        [TestMethod]
        public void BtnBackClick_WhenHdnStepValueIs2_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueTwo.ToString();

            // Act
            _privateObj.Invoke(BtnBackClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueOne.ToString()),
                () => _pnl1.Visible.ShouldBeTrue(),
                () => _pnl2.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void BtnBackClick_WhenHdnStepValueIs3AndSsrUrlIsNotEmpty_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueThree.ToString();
            _privateType.SetStaticFieldOrProperty(Ssrsurl, DummyString);

            // Act
            _privateObj.Invoke(BtnBackClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueTwo.ToString()),
                () => _pnl2.Visible.ShouldBeTrue(),
                () => _pnl3.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void BtnBackClick_WhenHdnStepValueIs3AndSsrUrlIsEmpty_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueThree.ToString();
            _privateType.SetStaticFieldOrProperty(Ssrsurl, string.Empty);

            // Act
            _privateObj.Invoke(BtnBackClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueOne.ToString()),
                () => _pnl1.Visible.ShouldBeTrue(),
                () => _pnl3.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void BtnBackClick_WhenHdnStepValueIs4_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueFour.ToString();

            // Act
            _privateObj.Invoke(BtnBackClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueThree.ToString()),
                () => _pnl3.Visible.ShouldBeTrue(),
                () => _pnlDone.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void BtnSkipClick_OnValidCall_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueTwo.ToString();
            _privateType.SetStaticFieldOrProperty(Ssrsurl, DummyString);

            // Act
            _privateObj.Invoke(BtnSkipClickMethod, this, EventArgs.Empty);

            // Assert
            var ssrsurl = (string)_privateType.GetStaticFieldOrProperty(Ssrsurl);
            this.ShouldSatisfyAllConditions(
                () => ssrsurl.ShouldBeEmpty(),
                () => _pnl2.Visible.ShouldBeFalse(),
                () => _pnl3.Visible.ShouldBeTrue(),
                () => _hdnStep.Value.ShouldBe(IntValueThree.ToString()));
        }

        [TestMethod]
        public void BtnNextClick_WhenValueIs1AndSsrsUrlIsNotEmpty_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueOne.ToString();
            _privateType.SetStaticFieldOrProperty(Ssrsurl, DummyString);

            // Act
            _privateObj.Invoke(BtnNextClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueTwo.ToString()),
                () => _pnl1.Visible.ShouldBeFalse(),
                () => _pnl2.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnNextClick_WhenValueIs1AndSsrsUrlIsEmpty_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueOne.ToString();
            _privateType.SetStaticFieldOrProperty(Ssrsurl, string.Empty);

            // Act
            _privateObj.Invoke(BtnNextClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueThree.ToString()),
                () => _pnl1.Visible.ShouldBeFalse(),
                () => _pnl3.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnNextClick_WhenValueIs2AndConnectionIsEmpty_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueTwo.ToString();
            _txtReportPassword.Text = DummyString;
            _chkWindows.Checked = false;

            // Act
            _privateObj.Invoke(BtnNextClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueThree.ToString()),
                () => _pnl2.Visible.ShouldBeFalse(),
                () => _pnl3.Visible.ShouldBeTrue(),
                () => _lblReportingError.Visible.ShouldBeFalse(),
                () => _hdnReportPassword.Value.ShouldBe(DummyString));
        }

        [TestMethod]
        public void BtnNextClick_WhenValueIs2AndConnectionIsNotEmpty_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueTwo.ToString();

            Shimtlwizard.AllInstances.checkConnection = _ => DummyString;

            // Act
            _privateObj.Invoke(BtnNextClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueTwo.ToString()),
                () => _lblReportingError.Visible.ShouldBeTrue(),
                () => _lblReportingError.Text.ShouldBe(DummyString));
        }

        [TestMethod]
        public void BtnNextClick_WhenValueIs3_ConfirmResult()
        {
            // Arrange
            _hdnStep.Value = IntValueThree.ToString();

            // Act
            _privateObj.Invoke(BtnNextClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueFour.ToString()),
                () => _pnl3.Visible.ShouldBeFalse(),
                () => _pnlDone.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnNextClick_WhenValueIs4_ConfirmResult()
        {
            // Arrange
            var btnYesClicked = false;
            _hdnStep.Value = IntValueFour.ToString();
            Shimtlwizard.AllInstances.btnYes_ClickObjectEventArgs = (_, __, ___) => btnYesClicked = true;

            // Act
            _privateObj.Invoke(BtnNextClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _hdnStep.Value.ShouldBe(IntValueFive.ToString()),
                () => btnYesClicked.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnYesClick_FirstSituation_ConfirmResult()
        {
            // Arrange
            var invalidUrlMsgLabel = new Label();
            SetupForBtnYesClick(string.Empty, true, true, Guid.NewGuid(), invalidUrlMsgLabel, false);

            // Act
            _privateObj.Invoke(BtnYesClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _quickLaunchGenerated.ShouldBeTrue(),
                () => _navigationNodeUpdated.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue(),
                () => _webPropertyUpdated.ShouldBeTrue(),
                () => _pnlMessage.Visible.ShouldBeTrue(),
                () => _pnlProcessing.Visible.ShouldBeFalse(),
                () => invalidUrlMsgLabel.Text.ShouldBe(NoReportingUrlEntered),
                () => _nonQueryExecuted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _odcFilesProcessed.ShouldBeTrue(),
                () => _excelFilesProcessed.ShouldBeTrue(),
                () => _listItemSystemUpdated.ShouldBeTrue(),
                () => _izendaReportsProcessed.ShouldBeTrue(),
                () => _categoryRemoved.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnYesClick_SecondSituation_ConfirmResult()
        {
            // Arrange
            _pnlMessage.Visible = false;
            SetupForBtnYesClick(DummyString, false, false, null, null, false);

            // Act
            _privateObj.Invoke(BtnYesClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _quickLaunchGenerated.ShouldBeTrue(),
                () => _navigationNodeUpdated.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue(),
                () => _webPropertyUpdated.ShouldBeTrue(),
                () => _pnlMessage.Visible.ShouldBeFalse(),
                () => _pnlProcessing.Visible.ShouldBeFalse(),
                () => _nonQueryExecuted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _odcFilesProcessed.ShouldBeTrue(),
                () => _excelFilesProcessed.ShouldBeTrue(),
                () => _listItemSystemUpdated.ShouldBeTrue(),
                () => _izendaReportsProcessed.ShouldBeTrue(),
                () => _categoryRemoved.ShouldBeTrue(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnYesClick_ThirdSituation_ConfirmResult()
        {
            // Arrange
            _pnlMessage.Visible = false;
            _chkWindows.Checked = true;
            SetupForBtnYesClick(DummyUrl, false, false, null, null, true);

            // Act
            _privateObj.Invoke(BtnYesClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _quickLaunchGenerated.ShouldBeTrue(),
                () => _navigationNodeUpdated.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue(),
                () => _webPropertyUpdated.ShouldBeTrue(),
                () => _pnlMessage.Visible.ShouldBeFalse(),
                () => _pnlProcessing.Visible.ShouldBeFalse(),
                () => _nonQueryExecuted.ShouldBeTrue(),
                () => _listItemUpdated.ShouldBeTrue(),
                () => _odcFilesProcessed.ShouldBeTrue(),
                () => _excelFilesProcessed.ShouldBeTrue(),
                () => _listItemSystemUpdated.ShouldBeTrue(),
                () => _izendaReportsProcessed.ShouldBeTrue(),
                () => _categoryRemoved.ShouldBeTrue(),
                () => _scriptRegistered.ShouldBeTrue());
        }

        private void SetupForBtnYesClick(string ssrUrl, bool containsKey, bool dataReaderRead, object scalarValue, Control control, bool reportingIntegratedMode)
        {
            _privateType.SetStaticFieldOrProperty(Ssrsurl, ssrUrl);

            ShimStringDictionary.AllInstances.ContainsKeyString = (_, __) => containsKey;
            ShimSqlDataReader.AllInstances.Read = _ => dataReaderRead;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => scalarValue;
            ShimControl.AllInstances.FindControlString = (_, __) => control;
            ShimCoreFunctions.getWebAppSettingGuidString = (_, __) => reportingIntegratedMode.ToString();
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = x => IntValueOne.ToString()
            };

            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.enqueueGuidInt32 = (_, __) => { };
            Shimtlwizard.AllInstances.ProcessGroupsSPWebSPUser = (_, __, ___) => { };
            ShimExcelConnectionInfo.Constructor = _ => { };
            ShimExcelConnectionUpdatorService.ConstructorExcelConnectionInfoISharepointService = (_, __, ___) => { };
            ShimExcelConnectionUpdatorService.AllInstances.ProcessOdcFiles = _ => _odcFilesProcessed = true;
            ShimExcelConnectionUpdatorService.AllInstances.ProcessExcelFiles = _ => _excelFilesProcessed = true;
            ShimSharepointService.Constructor = _ => { };
            ShimSPQuery.Constructor = _ => { };
            ShimReporting.ProcessIzendaReportsFromListSPListStringOut = (SPList list, out string errors) =>
            {
                _izendaReportsProcessed = true;
                errors = string.Empty;
            };

            ShimReportingService2006.Constructor = _ => { };
            ShimReportingService2006.AllInstances.CreateDataSourceStringStringBooleanDataSourceDefinitionPropertyArray =
                (_1, _2, _3, _4, _5, _6) => null;
            ShimReportingService2006.AllInstances.GetItemDataSourcesString = (_, __) => new DataSource[] 
            {
                new ShimDataSource
                {
                    NameGet = () => EPMLiveReportDB,
                    ItemGet = () => new ShimDataSourceDefinitionOrReference()
                }
            };
            ShimReportingService2006.AllInstances.SetItemDataSourcesStringDataSourceArray = (_, __, ___) => { };

            ShimDataSourceDefinition.Constructor = _ => { };

            ShimDataSourceReference.Constructor = _ => { };

            ShimNetworkCredential.ConstructorStringString = (_, __, ___) => { };

            ShimCookie.ConstructorStringStringStringString = (_, _1, _2, _3, _4) => { };
            ShimCookieContainer.Constructor = _ => { };
            ShimCookieContainer.AllInstances.AddCookie = (_, __) => { };

            ShimHttpContext.CurrentGet = () => new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    CookiesGet = () => new ShimHttpCookieCollection
                    {
                        ItemGetString = _ => new ShimHttpCookie
                        {
                            NameGet = () => DummyString,
                            ValueGet = () => DummyString,
                            PathGet = () => DummyString
                        }
                    },
                    UrlGet = () => new Uri(DummyUrl)
                }
            };
        }

        [TestMethod]
        public void BtnCancelClick_OnValidCall_ConfirmResult()
        {
            // Arrange, Act
            _privateObj.Invoke(BtnCancelClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _pnlDone.Visible.ShouldBeFalse(),
                () => _pnl1.Visible.ShouldBeFalse(),
                () => _pnl2.Visible.ShouldBeFalse(),
                () => _navigationNodeUpdated.ShouldBeTrue(),
                () => _webUpdated.ShouldBeTrue(),
                () => _scriptRegistered.ShouldBeTrue(),
                () => _categoryRemoved.ShouldBeTrue());
        }

        [TestMethod]
        public void CheckConnection_OnValidCall_ConfirmResult()
        {
            // Arrange
            _chkWindows.Checked = true;
            _txtReportUsername.Text = DummyUser;

            // Act
            var result = (string)_privateObj.Invoke(CheckConnectionMethod);

            // Assert
            result.ShouldBe(InvalidUserName);
        }

        [TestMethod]
        public void GetSiteGroup_WhenNameIsTheSame_ConfirmResult()
        {
            // Arrange, Act
            var result = (SPGroup)_privateType.InvokeStatic(GetSiteGroupMethod, _web.Instance, DummyString);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Name.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetSiteGroup_WhenNameIsNotTheSame_ConfirmResult()
        {
            // Arrange, Act
            var result = (SPGroup)_privateType.InvokeStatic(GetSiteGroupMethod, _web.Instance, DummyUser);

            // Assert
            result.ShouldBeNull();
        }
    }
}
