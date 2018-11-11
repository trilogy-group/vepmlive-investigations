using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SetupTest
    {
        private IDisposable _shimsObject;
        private setup _testObj;
        private PrivateObject _privateObj;
        private StateBag _stateBag;
        private DataTable _dtGroupsPermissions;
        private ShimSPWeb _web;
        private ShimSPSite _site;
        private bool _siteFeatureAdded;
        private bool _webFeatureAdded;
        private bool _fieldDeleted;
        private bool _settingSaved;
        private bool _responseRedirected;
        private bool _sharePointRedirected;

        private const int DummyIntOne = 1;
        private const int DummyIntTwo = 2;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string TrueString = "true";
        private const string FalseString = "false";
        private const string RelativeUrl = "/";
        private const string WebGuid = "430c9e5d-dae2-445b-b4d0-4d4c6d57d214";

        private const string GroupsID = "GroupsID";
        private const string GroupsText = "GroupsText";
        private const string PermissionsID = "PermissionsID";
        private const string PermissionsText = "PermissionsText";
        private const string DtGroupsPermissions = "dtGroupsPermissions";
        private const string DdlGroups = "ddlGroups";
        private const string DdlSPPermissions = "ddlSPPermissions";
        private const string LstAllTemplates = "lstAllTemplates";
        private const string LstSelectedTemplates = "lstSelectedTemplates";
        private const string ChkCreateOptions = "chkCreateOptions";
        private const string PnlConfigUrls = "pnlConfigUrls";
        private const string ChkLockConfig = "chkLockConfig";
        private const string ChkUsePE = "chkUsePE";
        private const string ChkLiveTemplates = "chkLiveTemplates";
        private const string DdlDefaultCreate = "ddlDefaultCreate";
        private const string InputFormSectionCreateOptions = "InputFormSectionCreateOptions";
        private const string InputFormSectionGalleryUrl = "InputFormSectionGalleryUrl";
        private const string InputFormSectionGalleryLive = "InputFormSectionGalleryLive";
        private const string InputFormSection6 = "InputFormSection6";
        private const string EPMLiveGroupsPermAssignments = "EPMLiveGroupsPermAssignments";
        private const string EPMLiveUseWEPeoplePicker = "EPMLiveUseWEPeoplePicker";
        private const string EPMLiveUseLiveTemplates = "EPMLiveUseLiveTemplates";
        private const string EPMLiveCreateNewSettings = "EPMLiveCreateNewSettings";
        private const string Default = "Default";
        private const string Online = "Online";
        private const string Local = "Local";
        private const string Existing = "Existing";

        private const string BtnGrpPermAddOnClickMethod = "btnGrpPermAdd_OnClick";
        private const string LnkGrpPermDeleteOnClickMethod = "lnkGrpPermDelete_OnClick";
        private const string BtnAddClickMethod = "btnAdd_Click";
        private const string BtnRemoveClickMethod = "btnRemove_Click";
        private const string LnkButtonClickMethod = "lnkButton_Click";
        private const string BtnSynchClickMethod = "btnSynch_Click";
        private const string Button1Click = "Button1_Click";
        private const string PageLoadMethod = "Page_Load";

        [TestInitialize]
        public void TestInitialize()
        {
            _siteFeatureAdded = false;
            _webFeatureAdded = false;
            _fieldDeleted = false;
            _settingSaved = false;
            _responseRedirected = false;
            _sharePointRedirected = false;
            _shimsObject = ShimsContext.Create();
            _testObj = new setup();
            _privateObj = new PrivateObject(_testObj);
            _stateBag = new StateBag();

            SetupShims();

            InitializeUIControls();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsObject?.Dispose();
        }

        private void SetupShims()
        {
            _web = new ShimSPWeb
            {
                IDGet = () => Guid.Parse(WebGuid),
                ServerRelativeUrlGet = () => RelativeUrl,
                LanguageGet = () => DummyIntOne,
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    AddGuidBoolean = (_, __) =>
                    {
                        _webFeatureAdded = true;
                        return new ShimSPFeature();
                    },
                    ItemGetGuid = _ => new ShimSPFeature()
                },
                ListsGet = () => new ShimSPListCollection
                {
                    ItemGetString = _ => new ShimSPList
                    {
                        ItemsGet = () => new ShimSPListItemCollection()
                            .Bind(new SPListItem[]
                            {
                                new ShimSPListItem
                                {
                                    TitleGet = () => $"{DummyString}_"
                                }
                            }),
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            GetFieldByInternalNameString = __ => new ShimSPField
                            {
                                Delete = () => _fieldDeleted = true
                            }
                        }.Bind(new SPField[]
                        {
                            new ShimSPField
                            {
                                HiddenGet = () => false,
                                SealedGet = () => false,
                                TypeGet = () => SPFieldType.Number,
                                InternalNameGet = () => DummyString
                            }
                        })
                    }
                },
                SiteGet = () => _site,
                RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection
                {
                    GetByIdInt32 = _ => new ShimSPRoleDefinition
                    {
                        NameGet = () => DummyString
                    }
                }.Bind(new SPRoleDefinition[]
                {
                    new ShimSPRoleDefinition
                    {
                        NameGet = () => DummyString,
                        IdGet = () => DummyIntOne
                    }
                }),
                SiteGroupsGet = () => new ShimSPGroupCollection
                {
                    GetByIDInt32 = _ => new ShimSPGroup
                    {
                        NameGet = () => DummyString
                    }
                }.Bind(new SPGroup[]
                {
                    new ShimSPGroup
                    {
                        NameGet = () => DummyString,
                        IDGet = () => DummyIntOne
                    }
                }),
                GetAvailableWebTemplatesUInt32 = _ => new ShimSPWebTemplateCollection()
                    .Bind(new SPWebTemplate[]
                    {
                        new ShimSPWebTemplate
                        {
                            IsHiddenGet = () => false,
                            TitleGet = () => DummyString
                        },
                        new ShimSPWebTemplate
                        {
                            IsHiddenGet = () => false,
                            TitleGet = () => $"{DummyString}_"
                        }
                    })
            };

            _site = new ShimSPSite
            {
                UrlGet = () => DummyUrl,
                FeaturesGet = () => new ShimSPFeatureCollection
                {
                    AddGuidBoolean = (_, __) => 
                    {
                        _siteFeatureAdded = true;
                        return new ShimSPFeature();
                    }
                },
                RootWebGet = () => _web
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                SiteGet = () => _site,
                WebGet = () => _web
            };

            ShimSPSite.ConstructorString = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebString = (_, __) => _web;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _web;
            ShimSPSite.AllInstances.ServerRelativeUrlGet = _ => RelativeUrl;
            ShimSPSite.AllInstances.Dispose = _ => { };

            ShimSPWeb.AllInstances.Dispose = _ => { };

            ShimControl.AllInstances.Focus = _ => { };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();
        }

        private void InitializeUIControls()
        {
            var allFields = _testObj.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));
            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        [TestMethod]
        public void BtnGrpPermAdd_OnClick_ConfirmResult()
        {
            // Arrange
            var ddlGroups = (DropDownList)_privateObj.GetFieldOrProperty(DdlGroups);
            var ddlSPPermissions = (DropDownList)_privateObj.GetFieldOrProperty(DdlSPPermissions);

            ddlGroups.Items.Add(new ListItem(DummyString, DummyIntTwo.ToString()));
            ddlSPPermissions.Items.Add(new ListItem(DummyString, DummyIntTwo.ToString()));

            InitializeDataControls();
            InsertRow();

            // Act
            _privateObj.Invoke(BtnGrpPermAddOnClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _dtGroupsPermissions.ShouldNotBeNull(),
                () => _dtGroupsPermissions.Rows.Count.ShouldBe(DummyIntTwo));
        }

        private void InsertRow()
        {
            var row = _dtGroupsPermissions.NewRow();
            row[GroupsID] = DummyIntOne.ToString();
            row[PermissionsID] = DummyIntOne.ToString();

            _dtGroupsPermissions.Rows.Add(row);
        }

        private void InitializeDataControls()
        {
            ShimControl.AllInstances.ViewStateGet = _ => _stateBag;

            _dtGroupsPermissions = new DataTable();
            _dtGroupsPermissions.Columns.Add(GroupsID);
            _dtGroupsPermissions.Columns.Add(GroupsText);
            _dtGroupsPermissions.Columns.Add(PermissionsID);
            _dtGroupsPermissions.Columns.Add(PermissionsText);
            _stateBag[DtGroupsPermissions] = _dtGroupsPermissions;
        }

        [TestMethod]
        public void LnkGrpPermDelete_OnClick_ConfirmResult()
        {
            // Arrange
            var lnkButton = new LinkButton();
            lnkButton.CommandArgument = $"{DummyIntOne};{DummyIntOne}";

            InitializeDataControls();
            InsertRow();

            // Act
            _privateObj.Invoke(LnkGrpPermDeleteOnClickMethod, lnkButton, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _dtGroupsPermissions.ShouldNotBeNull(),
                () => _dtGroupsPermissions.Rows.Count.ShouldBe(0));
        }

        [TestMethod]
        public void BtnAddClick_OnValidCall_ConfirmResult()
        {
            // Arrange
            var lstAllTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstAllTemplates);
            var lstSelectedTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstSelectedTemplates);
            lstAllTemplates.Items.Add(new ListItem(DummyString, DummyString));
            lstAllTemplates.Items[0].Selected = true;

            // Act
            _privateObj.Invoke(BtnAddClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lstAllTemplates.Items.Count.ShouldBe(0),
                () => lstSelectedTemplates.Items.Count.ShouldBe(1));
        }

        [TestMethod]
        public void BtnRemoveClick_OnValidCall_ConfirmResult()
        {
            // Arrange
            var lstAllTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstAllTemplates);
            var lstSelectedTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstSelectedTemplates);
            lstSelectedTemplates.Items.Add(new ListItem(DummyString, DummyString));
            lstSelectedTemplates.Items[0].Selected = true;

            // Act
            _privateObj.Invoke(BtnRemoveClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => lstAllTemplates.Items.Count.ShouldBe(1),
                () => lstSelectedTemplates.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void LnkButtonClick_OnValidCall_ConfirmResult()
        {
            // Arrange
            var redirected = false;
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, __, ___) => redirected = true;

            // Act
            _privateObj.Invoke(LnkButtonClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _siteFeatureAdded.ShouldBeTrue(),
                () => _webFeatureAdded.ShouldBeTrue(),
                () => redirected.ShouldBeTrue());
        }

        [TestMethod]
        public void BtnSynchClick_OnValidCall_ConfirmResult()
        {
            // Arrange
            var scriptRegistered = false;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyUrl;
            ShimPage.AllInstances.RegisterStartupScriptStringString = (_, __, ___) => scriptRegistered = true;

            // Act
            _privateObj.Invoke(BtnSynchClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _fieldDeleted.ShouldBeTrue(),
                () => scriptRegistered.ShouldBeTrue());
        }

        [TestMethod]
        public void Button1Click_WhenLockedWebIsNotSameThanCurrentWeb_ConfirmResult()
        {
            // Arrange
            SetupForButton1Click(Guid.NewGuid(), TrueString, DummyString);

            // Act
            _privateObj.Invoke(Button1Click, this, EventArgs.Empty);

            // Assert
            var pnlConfigUrls = (Panel)_privateObj.GetFieldOrProperty(PnlConfigUrls);
            var chkLockConfig = (CheckBox)_privateObj.GetFieldOrProperty(ChkLockConfig);
            this.ShouldSatisfyAllConditions(
                () => _settingSaved.ShouldBeTrue(),
                () => _responseRedirected.ShouldBeTrue(),
                () => _sharePointRedirected.ShouldBeFalse(),
                () => pnlConfigUrls.Visible.ShouldBeFalse(),
                () => chkLockConfig.Checked.ShouldBeFalse());
        }

        [TestMethod]
        public void Button1Click_WhenLockedWebIsEmpty_ConfirmResult()
        {
            // Arrange
            SetupForButton1Click(Guid.Empty, TrueString, DummyString);

            // Act
            _privateObj.Invoke(Button1Click, this, EventArgs.Empty);

            // Assert
            var pnlConfigUrls = (Panel)_privateObj.GetFieldOrProperty(PnlConfigUrls);
            var chkLockConfig = (CheckBox)_privateObj.GetFieldOrProperty(ChkLockConfig);
            this.ShouldSatisfyAllConditions(
                () => _settingSaved.ShouldBeTrue(),
                () => _responseRedirected.ShouldBeTrue(),
                () => _sharePointRedirected.ShouldBeFalse(),
                () => pnlConfigUrls.Visible.ShouldBeTrue(),
                () => chkLockConfig.Checked.ShouldBeTrue());
        }

        [TestMethod]
        public void Button1Click_WhenLockedWebIsSameThanCurrentWeb_ConfirmResult()
        {
            // Arrange
            SetupForButton1Click(Guid.Parse(WebGuid), TrueString, DummyString);

            // Act
            _privateObj.Invoke(Button1Click, this, EventArgs.Empty);

            // Assert
            var pnlConfigUrls = (Panel)_privateObj.GetFieldOrProperty(PnlConfigUrls);
            var chkLockConfig = (CheckBox)_privateObj.GetFieldOrProperty(ChkLockConfig);
            this.ShouldSatisfyAllConditions(
                () => _settingSaved.ShouldBeTrue(),
                () => _responseRedirected.ShouldBeTrue(),
                () => _sharePointRedirected.ShouldBeFalse(),
                () => pnlConfigUrls.Visible.ShouldBeTrue(),
                () => chkLockConfig.Checked.ShouldBeTrue());
        }

        [TestMethod]
        public void Button1Click_WhenWebLockIsFalse_ConfirmResult()
        {
            // Arrange
            SetupForButton1Click(Guid.NewGuid(), FalseString, string.Empty);

            // Act
            _privateObj.Invoke(Button1Click, this, EventArgs.Empty);

            // Assert
            var pnlConfigUrls = (Panel)_privateObj.GetFieldOrProperty(PnlConfigUrls);
            var chkLockConfig = (CheckBox)_privateObj.GetFieldOrProperty(ChkLockConfig);
            this.ShouldSatisfyAllConditions(
                () => _settingSaved.ShouldBeTrue(),
                () => _responseRedirected.ShouldBeFalse(),
                () => _sharePointRedirected.ShouldBeTrue(),
                () => pnlConfigUrls.Visible.ShouldBeTrue(),
                () => chkLockConfig.Checked.ShouldBeFalse());
        }

        private void SetupForButton1Click(Guid lockedWebGuid, string configSetting, string requestItem)
        {
            var lstSelectedTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstSelectedTemplates);
            var chkCreateOptions = (CheckBoxList)_privateObj.GetFieldOrProperty(ChkCreateOptions);

            lstSelectedTemplates.Items.Add(new ListItem(DummyString, DummyString));
            lstSelectedTemplates.Items[0].Selected = true;

            chkCreateOptions.Items.Add(new ListItem(DummyString));
            chkCreateOptions.Items.Add(new ListItem(DummyString));
            chkCreateOptions.Items.Add(new ListItem(DummyString));

            InitializeDataControls();
            InsertRow();

            ShimCoreFunctions.setConfigSettingSPWebStringString = (_, __, ___) => _settingSaved = true;
            ShimCoreFunctions.getLockedWebSPWeb = _ => lockedWebGuid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => configSetting;
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = __ => requestItem
            };

            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse
            {
                RedirectString = __ => _responseRedirected = true
            };

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, __, ___) => _sharePointRedirected = true;
        }

        [TestMethod]
        public void PageLoad_WhenTemplateIsNull_ConfirmResult()
        {
            // Arrange
            var chkUsePE = (CheckBox)_privateObj.GetFieldOrProperty(ChkUsePE);
            var chkLiveTemplates = (CheckBox)_privateObj.GetFieldOrProperty(ChkLiveTemplates);
            var lstAllTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstAllTemplates);
            var lstSelectedTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstSelectedTemplates);
            var inputFormSectionCreateOptions = (UserControl)_privateObj.GetFieldOrProperty(InputFormSectionCreateOptions);
            var inputFormSectionGalleryUrl = (UserControl)_privateObj.GetFieldOrProperty(InputFormSectionGalleryUrl);
            var inputFormSectionGalleryLive = (UserControl)_privateObj.GetFieldOrProperty(InputFormSectionGalleryLive);

            SetupForPageLoad(null);

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chkUsePE.Checked.ShouldBeTrue(),
                () => chkLiveTemplates.Checked.ShouldBeTrue(),
                () => lstAllTemplates.Items.Count.ShouldBe(1),
                () => lstSelectedTemplates.Items.Count.ShouldBe(1),
                () => inputFormSectionCreateOptions.Visible.ShouldBeFalse(),
                () => inputFormSectionGalleryUrl.Visible.ShouldBeFalse(),
                () => inputFormSectionGalleryLive.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void PageLoad_WhenTemplateIsNotNull_ConfirmResult()
        {
            // Arrange
            var chkUsePE = (CheckBox)_privateObj.GetFieldOrProperty(ChkUsePE);
            var chkLiveTemplates = (CheckBox)_privateObj.GetFieldOrProperty(ChkLiveTemplates);
            var lstAllTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstAllTemplates);
            var lstSelectedTemplates = (ListBox)_privateObj.GetFieldOrProperty(LstSelectedTemplates);
            var chkCreateOptions = (CheckBoxList)_privateObj.GetFieldOrProperty(ChkCreateOptions);
            var ddlDefaultCreate = (DropDownList)_privateObj.GetFieldOrProperty(DdlDefaultCreate);
            var inputFormSection6 = (UserControl)_privateObj.GetFieldOrProperty(InputFormSection6);
            var inputFormSectionGalleryUrl = (UserControl)_privateObj.GetFieldOrProperty(InputFormSectionGalleryUrl);
            var inputFormSectionGalleryLive = (UserControl)_privateObj.GetFieldOrProperty(InputFormSectionGalleryLive);

            ddlDefaultCreate.Items.Add(new ListItem(DummyString));
            chkCreateOptions.Items.Add(new ListItem(DummyString));
            chkCreateOptions.Items.Add(new ListItem(DummyString));
            chkCreateOptions.Items.Add(new ListItem(DummyString));

            SetupForPageLoad(new ShimSPList());

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chkUsePE.Checked.ShouldBeTrue(),
                () => chkLiveTemplates.Checked.ShouldBeTrue(),
                () => lstAllTemplates.Items.Count.ShouldBe(0),
                () => lstSelectedTemplates.Items.Count.ShouldBe(0),
                () => ddlDefaultCreate.SelectedValue.ShouldBe(DummyString),
                () => chkCreateOptions.Items[0].Selected.ShouldBeTrue(),
                () => chkCreateOptions.Items[1].Selected.ShouldBeTrue(),
                () => chkCreateOptions.Items[2].Selected.ShouldBeTrue(),
                () => inputFormSection6.Visible.ShouldBeFalse(),
                () => inputFormSectionGalleryUrl.Visible.ShouldBeTrue(),
                () => inputFormSectionGalleryLive.Visible.ShouldBeTrue());
        }

        private static void SetupForPageLoad(ShimSPList templates)
        {
            ShimPage.AllInstances.IsPostBackGet = _ => false;

            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) =>
            {
                switch (setting)
                {
                    case EPMLiveGroupsPermAssignments:
                        return $"{DummyIntOne}~{DummyIntOne}";
                    case EPMLiveUseWEPeoplePicker:
                    case EPMLiveUseLiveTemplates:
                        return TrueString;
                    case EPMLiveCreateNewSettings:
                        return $"{Default}^{DummyString};#{Online}^{TrueString}|{Local}^{TrueString}|{Existing}^{TrueString}";
                    default:
                        return DummyString;
                }
            };

            ShimCoreFunctions.getConfigSettingSPWebStringBooleanBoolean = (_, __, ___, ____) => DummyString;

            ShimSPListCollection.AllInstances.TryGetListString = (_, __) => templates;
        }
    }
}
