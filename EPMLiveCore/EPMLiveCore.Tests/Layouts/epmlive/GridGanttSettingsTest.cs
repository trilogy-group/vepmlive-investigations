using System;
using System.Collections.Fakes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks.Fakes;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls.WebParts.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Infrastructure.Fakes;
using EPMLiveCore.Layouts.epmlive;
using EPMLiveCore.Layouts.epmlive.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveCore.WebPartsHelper.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class GridGanttSettingsTest
    {
        private IDisposable _shimObject;
        private gridganttsettings _testObj;
        private PrivateObject _privateObj;
        private StateBag _stateBag;
        private DataTable _dtGroupsPermissions;

        private bool _unInstallAssigned;
        private bool _installAssigned;
        private bool _eventDeleted;
        private bool _eventAdded;
        private bool _eventUpdated;
        private bool _listUpdated;
        private bool _teamFeaturesEnabled;
        private bool _timeSheetsEnabled;
        private bool _timeSheetsDisabled;
        private bool _webPartSaved;
        private bool _webPartAdded;
        private bool _listBizCreated;
        private bool _listBizDeleted;
        private bool _categoryRemoved;
        private bool _redirected;

        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyUrl = "http://xyz.com";
        private const string DummyBool = "true";

        private const string DtGroupsPermissions = "dtGroupsPermissions";
        private const string GvGroupsPermissions = "GvGroupsPermissions";
        private const string GroupsID = "GroupsID";
        private const string GroupsText = "GroupsText";
        private const string PermissionsID = "PermissionsID";
        private const string PermissionsText = "PermissionsText";
        private const string ListId = "ff310424-faac-4f3a-a58c-e5b99c73c2e1";
        private const string FieldId = "D2DA5DF0-EB3A-4D9C-A3A4-2DA594A727E8";
        private const string DdlGroups = "ddlGroups";
        private const string DdlSPPermissions = "ddlSPPermissions";
        private const string DdlStartDate = "ddlStartDate";
        private const string DdlDueDate = "ddlDueDate";
        private const string DdlProgressBar = "ddlProgressBar";
        private const string DdlMilestone = "ddlMilestone";
        private const string DdlInformation = "ddlInformation";
        private const string DdlWBS = "ddlWBS";
        private const string DdlItemLink = "ddlItemLink";
        private const string SectionEmail = "SectionEmail";
        private const string ChkTimesheet = "chkTimesheet";
        private const string CbEnableReporting = "cbEnableReporting";
        private const string BtnAddEvt = "btnAddEvt";
        private const string ChkEnableTeam = "chkEnableTeam";
        private const string ChkEnableTeamSecurity = "chkEnableTeamSecurity";
        private const string ChkEmails = "chkEmails";
        private const string ChkAutoCreate = "chkAutoCreate";
        private const string ChkFancyForms = "chkFancyForms";
        private const string ChkAssociatedItems = "chkAssociatedItems";
        private const string ChkWorkListFeat = "chkWorkListFeat";
        private const string IfsEnableReporting = "ifsEnableReporting";
        private const string HTMLType = "HTML";
        private const string ContentType = "contenttype";
        private const string ExtId = "extid";
        private const string FancyDisplayForm = "Fancy Display Form";
        private const string ProjectCenter = "Project Center";
        private const string Project = "Project";
        private const string Today = "Today";
        private const string StartDate = "StartDate";
        private const string DueDate = "DueDate";
        private const string AssignedTo = "AssignedTo";
        private const string Priority = "Priority";
        private const string Status = "Status";
        private const string Work = "Work";
        private const string PercentComplete = "PercentComplete";
        private const string CommentCount = "CommentCount";
        private const string Body = "Body";
        private const string Commenters = "Commenters";
        private const string CommentersRead = "CommentersRead";
        private const string Complete = "Complete";
        private const string DaysOverdue = "DaysOverdue";
        private const string ScheduleStatus = "ScheduleStatus";
        private const string TodayYear = "TodayYear";
        private const string TodayWeek = "TodayWeek";
        private const string Year = "Year";
        private const string Week = "Week";
        private const string Due = "Due";
        private const string AssemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
        private const string ClassName = "EPMLiveCore.StatusingEvent";
        private const string ReportingV2 = "ReportingV2";
        private const string GeneralSettings = "GeneralSettings";
        private const string Workspace = "workspace";

        private const string LnkGrpPermDeleteOnClickMethod = "lnkGrpPermDelete_OnClick";
        private const string BtnGrpPermAddOnClickMethod = "btnGrpPermAdd_OnClick";
        private const string OnPreLoadMethod = "OnPreLoad";
        private const string PageLoadMethod = "Page_Load";
        private const string Button1ClickMethod = "Button1_Click";
        private const string AddFieldsAndFixLookupFieldsMethod = "AddFieldsAndFixLookupFields";

        [TestInitialize]
        public void TestInitialize()
        {
            ResetValues();
            _shimObject = ShimsContext.Create();
            _testObj = new gridganttsettings();
            _privateObj = new PrivateObject(_testObj);
            _stateBag = new StateBag();

            SetupShims();
            InitializeUiControls();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }

        private void ResetValues()
        {
            _unInstallAssigned = false;
            _installAssigned = false;
            _eventDeleted = false;
            _eventAdded = false;
            _eventUpdated = false;
            _listUpdated = false;
            _teamFeaturesEnabled = false;
            _timeSheetsEnabled = false;
            _timeSheetsDisabled = false;
            _webPartSaved = false;
            _webPartAdded = false;
            _listBizCreated = false;
            _listBizDeleted = false;
            _categoryRemoved = false;
            _redirected = false;
        }

        private void InitDataControls()
        {
            ShimControl.AllInstances.ViewStateGet = _ => _stateBag;
            SPGridView gvGroupsPermissions = new ShimSPGridView().Instance;

            _dtGroupsPermissions = new DataTable();
            _dtGroupsPermissions.Columns.Add(GroupsID);
            _dtGroupsPermissions.Columns.Add(GroupsText);
            _dtGroupsPermissions.Columns.Add(PermissionsID);
            _dtGroupsPermissions.Columns.Add(PermissionsText);
            _stateBag[DtGroupsPermissions] = _dtGroupsPermissions;

            _privateObj.SetFieldOrProperty(GvGroupsPermissions, gvGroupsPermissions);
        }

        private void InitializeUiControls()
        {
            var allFields = _testObj.GetType()
                                       .GetFields(BindingFlags.Instance |
                                                  BindingFlags.NonPublic)
                                       .Where(field => field.FieldType.IsSubclassOf(typeof(Control)));

            foreach (var control in allFields)
            {
                _privateObj.SetField(control.Name, Activator.CreateInstance(control.FieldType));
            }
        }

        private void SetupShims()
        {
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid()
                }
            };

            ShimSPField.AllInstances.SchemaXmlGet = _ => $"<Element List=\"{DummyString}\" WebId=\"{DummyString}\" />";

            ShimGridView.AllInstances.DataBind = _ => { };
            ShimControl.AllInstances.Focus = _ => { };

            ShimPage.AllInstances.IsPostBackGet = _ => false;
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest
            {
                ItemGetString = item => Guid.NewGuid().ToString()
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => new ShimSPWeb
                {
                    IDGet = () => Guid.NewGuid(),
                    UrlGet = () => DummyUrl,
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetGuid = _ => new ShimSPList
                        {
                            IDGet = () => Guid.Parse(ListId),
                            TitleGet = () => DummyString,
                        },
                        TryGetListString = _ => new ShimSPList
                        {
                            GetItemsSPQuery = query => new ShimSPListItemCollection().Bind(
                                new SPListItem[]
                                {
                                    new ShimSPListItem
                                    {
                                        ItemGetGuid = item => Workspace,
                                        ItemGetString = item => DummyString,
                                        IDGet = () => DummyInt
                                    }.Instance
                                }),
                            FieldsGet = () => new ShimSPFieldCollection
                            {
                                GetFieldByInternalNameString = name => new ShimSPField
                                {
                                    IdGet = () => Guid.NewGuid()
                                }
                            }
                        }
                    },
                    SiteGet = () => new ShimSPSite
                    {
                        IDGet = () => Guid.NewGuid(),
                        RootWebGet = () => new ShimSPWeb
                        {
                            RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection().Bind(
                                new SPRoleDefinition[]
                                {
                                    new ShimSPRoleDefinition
                                    {
                                        NameGet = () => DummyString,
                                        IdGet = () => DummyInt
                                    }.Instance
                                }),
                            SiteGroupsGet = () => new ShimSPGroupCollection().Bind(
                                new SPGroup[]
                                {
                                    new ShimSPGroup
                                    {
                                        NameGet = () => DummyString,
                                        IDGet = () => DummyInt
                                    }
                                })
                        }
                    },
                    SiteGroupsGet = () => new ShimSPGroupCollection
                    {
                        GetByIDInt32 = _ => new ShimSPGroup
                        {
                            NameGet = () => DummyString
                        }
                    },
                    RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection
                    {
                        GetByIdInt32 = _ => new ShimSPRoleDefinition
                        {
                            NameGet = () => DummyString
                        }
                    }
                },
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid()
                }
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action => action();

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection()
            };

            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_, __, ___) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (item, list) =>
            {
                if (item == GeneralSettings)
                {
                    return $"\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n{DummyString}\n\n\n\n\n\n\n{DummyInt}~{DummyInt}";
                }
                return DummyString;
            };
        }

        [TestMethod]
        public void ClearLookupReferences_OnValidCall_ConfirmResult()
        {
            // Arrange
            var updated = false;
            ShimSPField.AllInstances.UpdateBoolean = (_, __) => updated = true;

            // Act
            _testObj.ClearLookupReferences(new ShimSPFieldLookup().Instance);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateLookupReferences_WhenLookupListIsNull_ConfirmResult()
        {
            // Arrange
            var updated = false;
            var lookupField = new ShimSPFieldLookup
            {
                LookupListGet = () => string.Empty,
                LookupWebIdGet = () => Guid.Empty
            }.Instance;
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPField.AllInstances.UpdateBoolean = (_, __) => updated = true;

            // Act
            _testObj.UpdateLookupReferences(
                lookupField, 
                new ShimSPWeb().Instance, 
                new ShimSPList().Instance);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void UpdateLookupReferences_WhenLookupListIsNotNull_ConfirmResult()
        {
            // Arrange
            var updated = false;
            var lookupField = new ShimSPFieldLookup
            {
                LookupListGet = () => Guid.NewGuid().ToString(),
                LookupWebIdGet = () => Guid.Empty
            }.Instance;
            ShimSPWeb.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPList.AllInstances.IDGet = _ => Guid.NewGuid();
            ShimSPField.AllInstances.UpdateBoolean = (_, __) => updated = true;

            // Act
            _testObj.UpdateLookupReferences(
                lookupField,
                new ShimSPWeb().Instance,
                new ShimSPList().Instance);

            // Assert
            updated.ShouldBeTrue();
        }

        [TestMethod]
        public void FieldExistsInList_WhenFindField_ConfirmResult()
        {
            // Arrange
            var list = new ShimSPList
            {
                FieldsGet = () => new ShimSPFieldCollection
                {
                    GetFieldByInternalNameString = _ => new ShimSPField()
                }
            };

            // Act
            var result = _testObj.FieldExistsInList(list, DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void FieldExistsInList_WhenNotFindField_ConfirmResult()
        {
            // Arrange
            var list = new ShimSPList();

            // Act
            var result = _testObj.FieldExistsInList(list, DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void LnkGrpPermDeleteOnClick_OnValidCall_ConfirmResult()
        {
            // Arrange
            InitDataControls();
            var lnkDelete = new LinkButton();
            lnkDelete.CommandArgument = $"{DummyString};{DummyString}";

            var row = _dtGroupsPermissions.NewRow();
            row[GroupsID] = DummyString;
            row[PermissionsID] = DummyString;
            _dtGroupsPermissions.Rows.Add(row);

            // Act
            _privateObj.Invoke(LnkGrpPermDeleteOnClickMethod, lnkDelete, EventArgs.Empty);

            // Assert
            _dtGroupsPermissions.Rows.Count.ShouldBe(0);
        }

        [TestMethod]
        public void BtnGrpPermAddOnClick_WhenItemDoesNotExist_ConfirmResult()
        {
            // Arrange
            InitDataControls();
            var ddlGroups = (DropDownList)_privateObj.GetFieldOrProperty(DdlGroups);
            ddlGroups.Items.Add(DummyString);
            ddlGroups.SelectedIndex = 0;

            var ddlSPPermissions = (DropDownList)_privateObj.GetFieldOrProperty(DdlSPPermissions);
            ddlSPPermissions.Items.Add(DummyString);
            ddlSPPermissions.SelectedIndex = 0;

            // Act
            _privateObj.Invoke(BtnGrpPermAddOnClickMethod, this, EventArgs.Empty);

            // Assert
            _dtGroupsPermissions.Rows.Count.ShouldBe(1);
        }

        [TestMethod]
        public void BtnGrpPermAddOnClick_WhenItemExists_ConfirmResult()
        {
            // Arrange
            InitDataControls();
            var row = _dtGroupsPermissions.NewRow();
            row[GroupsID] = DummyString;
            row[PermissionsID] = DummyString;
            _dtGroupsPermissions.Rows.Add(row);

            var ddlGroups = (DropDownList)_privateObj.GetFieldOrProperty(DdlGroups);
            ddlGroups.Items.Add(DummyString);
            ddlGroups.SelectedIndex = 0;

            var ddlSPPermissions = (DropDownList)_privateObj.GetFieldOrProperty(DdlSPPermissions);
            ddlSPPermissions.Items.Add(DummyString);
            ddlSPPermissions.SelectedIndex = 0;

            // Act
            _privateObj.Invoke(BtnGrpPermAddOnClickMethod, this, EventArgs.Empty);

            // Assert
            _dtGroupsPermissions.Rows.Count.ShouldBe(1);
        }

        [TestMethod]
        public void OnPreLoad_OnValidCall_ConfirmResult()
        {
            // Arrange
            var scriptRegistered = false;
            ShimEPMLiveScriptManager.RegisterScriptPageStringArrayBoolean = (_, __, ___) => scriptRegistered = true;

            // Act
            _privateObj.Invoke(OnPreLoadMethod, EventArgs.Empty);

            // Assert
            scriptRegistered.ShouldBeTrue();
        }

        [TestMethod]
        public void PageLoad_OnLoad_ConfirmResult()
        {
            // Arrange
            InitDataControls();
            _stateBag[DtGroupsPermissions] = null;

            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPField()
            }.Bind(
                new SPField[] {
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.DateTime,
                        TitleGet = () => new DateTime(2018,1,1).ToString(),
                        InternalNameGet = () => new DateTime(2018,1,1).ToString()
                    },
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Number,
                        TitleGet = () => DummyInt.ToString(),
                        InternalNameGet = () => DummyInt.ToString()
                    },
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Text,
                        TitleGet = () => DummyString,
                        InternalNameGet = () => DummyString
                    },
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Boolean,
                        TitleGet = () => DummyBool,
                        InternalNameGet = () => DummyBool
                    },
                    new ShimSPField
                    {
                        TypeGet = () => SPFieldType.Guid,
                        TitleGet = () => FieldId,
                        InternalNameGet = () => FieldId
                    }
                });

            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) =>
            {
                if (setting == ReportingV2)
                {
                    return DummyBool;
                }
                return DummyString;
            };
            
            ShimSPQuery.Constructor = _ => { };

            ShimReportBiz.ConstructorGuidGuidBoolean = (_, __, ___, ____) => { };
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportBiz.AllInstances.GetMappedLists = _ => new Collection<string> { DummyString };
            ShimReportBiz.AllInstances.GetMappedListsIds = _ => new Collection<string> { ListId };

            // Act
            _privateObj.Invoke(PageLoadMethod, this, EventArgs.Empty);

            // Assert
            var ddlStartDate = (DropDownList)_privateObj.GetFieldOrProperty(DdlStartDate);
            var ddlDueDate = (DropDownList)_privateObj.GetFieldOrProperty(DdlDueDate);
            var ddlProgressBar = (DropDownList)_privateObj.GetFieldOrProperty(DdlProgressBar);
            var ddlMilestone = (DropDownList)_privateObj.GetFieldOrProperty(DdlMilestone);
            var ddlInformation = (DropDownList)_privateObj.GetFieldOrProperty(DdlInformation);
            var ddlWBS = (DropDownList)_privateObj.GetFieldOrProperty(DdlWBS);
            var ddlItemLink = (DropDownList)_privateObj.GetFieldOrProperty(DdlItemLink);
            var sectionEmail = (UserControl)_privateObj.GetFieldOrProperty(SectionEmail);
            var chkTimesheet = (CheckBox)_privateObj.GetFieldOrProperty(ChkTimesheet);
            var dataTable = (DataTable)_stateBag[DtGroupsPermissions];
            var cbEnableReporting = (CheckBox)_privateObj.GetFieldOrProperty(CbEnableReporting);
            var btnAddEvt = (Button)_privateObj.GetFieldOrProperty(BtnAddEvt);

            this.ShouldSatisfyAllConditions(
                () => ddlStartDate.Items.Count.ShouldBeGreaterThan(0),
                () => ddlDueDate.Items.Count.ShouldBeGreaterThan(0),
                () => ddlProgressBar.Items.Count.ShouldBeGreaterThan(0),
                () => ddlMilestone.Items.Count.ShouldBeGreaterThan(0),
                () => ddlInformation.Items.Count.ShouldBeGreaterThan(0),
                () => ddlWBS.Items.Count.ShouldBeGreaterThan(0),
                () => ddlItemLink.Items.Count.ShouldBeGreaterThan(0),
                () => sectionEmail.Visible.ShouldBeTrue(),
                () => chkTimesheet.Checked.ShouldBeTrue(),
                () => dataTable.Rows.Count.ShouldBeGreaterThan(0),
                () => cbEnableReporting.Checked.ShouldBeTrue(),
                () => cbEnableReporting.Enabled.ShouldBeFalse(),
                () => btnAddEvt.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void Button1Click_FirstSituation_ConfirmResult()
        {
            // Arrange
            CheckBox chkEnableTeam, chkEnableTeamSecurity, chkEmails, chkAutoCreate, chkTimesheet, chkFancyForms, chkAssociatedItems, chkWorkListFeat, cbEnableReporting;
            UserControl ifsEnableReporting;

            GetControlsForButton1Click(out chkEnableTeam, out chkEnableTeamSecurity, out chkEmails, out chkAutoCreate, out chkTimesheet, out chkFancyForms, out chkAssociatedItems, out chkWorkListFeat, out ifsEnableReporting, out cbEnableReporting);

            chkEnableTeam.Checked = true;
            chkEnableTeamSecurity.Checked = true;
            chkEmails.Checked = true;
            chkAutoCreate.Checked = true;
            chkTimesheet.Checked = true;
            chkFancyForms.Checked = true;
            chkAssociatedItems.Checked = true;
            chkWorkListFeat.Checked = true;
            ifsEnableReporting.Visible = true;
            cbEnableReporting.Checked = true;

            SetupShimForButton1Click();

            // Act
            _privateObj.Invoke(Button1ClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _unInstallAssigned.ShouldBe(!chkEmails.Checked),
                () => _installAssigned.ShouldBe(chkEmails.Checked),
                () => _eventDeleted.ShouldBeTrue(),
                () => _eventAdded.ShouldBe(chkEnableTeamSecurity.Checked),
                () => _eventUpdated.ShouldBe(chkEnableTeamSecurity.Checked),
                () => _listUpdated.ShouldBeTrue(),
                () => _teamFeaturesEnabled.ShouldBeTrue(),
                () => _timeSheetsEnabled.ShouldBe(chkTimesheet.Checked),
                () => _timeSheetsDisabled.ShouldBe(!chkTimesheet.Checked),
                () => _webPartSaved.ShouldBeTrue(),
                () => _webPartAdded.ShouldBe(chkAssociatedItems.Checked),
                () => _listBizCreated.ShouldBe(ifsEnableReporting.Visible && cbEnableReporting.Checked),
                () => _listBizDeleted.ShouldBe(ifsEnableReporting.Visible && !cbEnableReporting.Checked),
                () => _categoryRemoved.ShouldBeTrue(),
                () => _redirected.ShouldBeTrue());
        }

        [TestMethod]
        public void Button1Click_SecondSituation_ConfirmResult()
        {
            // Arrange
            CheckBox chkEnableTeam, chkEnableTeamSecurity, chkEmails, chkAutoCreate, chkTimesheet, chkFancyForms, chkAssociatedItems, chkWorkListFeat, cbEnableReporting;
            UserControl ifsEnableReporting;

            GetControlsForButton1Click(out chkEnableTeam, out chkEnableTeamSecurity, out chkEmails, out chkAutoCreate, out chkTimesheet, out chkFancyForms, out chkAssociatedItems, out chkWorkListFeat, out ifsEnableReporting, out cbEnableReporting);

            chkEnableTeam.Checked = true;
            chkEnableTeamSecurity.Checked = false;
            chkEmails.Checked = false;
            chkAutoCreate.Checked = false;
            chkTimesheet.Checked = false;
            chkFancyForms.Checked = false;
            chkAssociatedItems.Checked = false;
            chkWorkListFeat.Checked = false;
            ifsEnableReporting.Visible = true;
            cbEnableReporting.Checked = false;

            SetupShimForButton1Click();

            // Act
            _privateObj.Invoke(Button1ClickMethod, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _unInstallAssigned.ShouldBe(!chkEmails.Checked),
                () => _installAssigned.ShouldBe(chkEmails.Checked),
                () => _eventDeleted.ShouldBeTrue(),
                () => _eventAdded.ShouldBe(chkEnableTeamSecurity.Checked),
                () => _eventUpdated.ShouldBe(chkEnableTeamSecurity.Checked),
                () => _listUpdated.ShouldBeTrue(),
                () => _teamFeaturesEnabled.ShouldBeTrue(),
                () => _timeSheetsEnabled.ShouldBe(chkTimesheet.Checked),
                () => _timeSheetsDisabled.ShouldBe(!chkTimesheet.Checked),
                () => _webPartSaved.ShouldBeTrue(),
                () => _webPartAdded.ShouldBe(chkAssociatedItems.Checked),
                () => _listBizCreated.ShouldBe(ifsEnableReporting.Visible && cbEnableReporting.Checked),
                () => _listBizDeleted.ShouldBe(ifsEnableReporting.Visible && !cbEnableReporting.Checked),
                () => _categoryRemoved.ShouldBeTrue(),
                () => _redirected.ShouldBeTrue());
        }

        private void GetControlsForButton1Click(out CheckBox chkEnableTeam, out CheckBox chkEnableTeamSecurity, out CheckBox chkEmails, out CheckBox chkAutoCreate, out CheckBox chkTimesheet, out CheckBox chkFancyForms, out CheckBox chkAssociatedItems, out CheckBox chkWorkListFeat, out UserControl ifsEnableReporting, out CheckBox cbEnableReporting)
        {
            chkEnableTeam = (CheckBox)_privateObj.GetFieldOrProperty(ChkEnableTeam);
            chkEnableTeamSecurity = (CheckBox)_privateObj.GetFieldOrProperty(ChkEnableTeamSecurity);
            chkEmails = (CheckBox)_privateObj.GetFieldOrProperty(ChkEmails);
            chkAutoCreate = (CheckBox)_privateObj.GetFieldOrProperty(ChkAutoCreate);
            chkTimesheet = (CheckBox)_privateObj.GetFieldOrProperty(ChkTimesheet);
            chkFancyForms = (CheckBox)_privateObj.GetFieldOrProperty(ChkFancyForms);
            chkAssociatedItems = (CheckBox)_privateObj.GetFieldOrProperty(ChkAssociatedItems);
            chkWorkListFeat = (CheckBox)_privateObj.GetFieldOrProperty(ChkWorkListFeat);
            ifsEnableReporting = (UserControl)_privateObj.GetFieldOrProperty(IfsEnableReporting);
            cbEnableReporting = (CheckBox)_privateObj.GetFieldOrProperty(CbEnableReporting);
        }

        private void SetupShimForButton1Click()
        {
            ShimAPIEmail.UnInstallAssignedToEventSPList = _ => _unInstallAssigned = true;
            ShimAPIEmail.InstallAssignedToEventSPList = _ => _installAssigned = true;

            ShimCoreFunctions.GetListEventsSPListStringStringIListOfSPEventReceiverType = (_1, _2, _3, _4) =>
                new List<SPEventReceiverDefinition>
                {
                    new ShimSPEventReceiverDefinition
                    {
                        Delete = () => _eventDeleted = true,
                        Update = () => _eventUpdated = true
                    }
                };

            ShimSPList.AllInstances.EventReceiversGet = _ => new ShimSPEventReceiverDefinitionCollection
            {
                AddSPEventReceiverTypeStringString = (_1, _2, _3) => _eventAdded = true,
                Add = () => new ShimSPEventReceiverDefinition
                {
                    Update = () => { }
                }
            }.Bind(new SPEventReceiverDefinition[] 
            {
                new ShimSPEventReceiverDefinition
                {
                    AssemblyGet = () => AssemblyName,
                    ClassGet = () => ClassName,
                    TypeGet = () => SPEventReceiverType.ItemAdding
                }
            });
            ShimSPList.AllInstances.Update = _ => _listUpdated = true;
            ShimSPList.AllInstances.BaseTemplateGet = _ => SPListTemplateType.DocumentLibrary;
            ShimSPList.AllInstances.RootFolderGet = _ => new ShimSPFolder
            {
                UrlGet = () => DummyString
            };
            ShimSPList.AllInstances.ViewsGet = _ => new ShimSPViewCollection().Bind(
                new SPView[]
                {
                    new ShimSPView
                    {
                        TypeGet = () => HTMLType,
                        ServerRelativeUrlGet = () => DummyUrl
                    }
                });
            ShimSPList.AllInstances.IDGet = _ => new Guid(ListId);
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection().Bind
            (
                new SPField[]
                {
                    new ShimSPField()
                    {
                        InternalNameGet = () => ContentType,
                        TitleGet = () => DummyString,
                        IdGet = () => Guid.NewGuid(),
                        HiddenGet = () => true
                    },
                    new ShimSPField()
                    {
                        InternalNameGet = () => ExtId,
                        TitleGet = () => DummyString,
                        IdGet = () => Guid.NewGuid(),
                        HiddenGet = () => true
                    },
                    new ShimSPField()
                    {
                        InternalNameGet = () => DummyString,
                        TitleGet = () => DummyString,
                        IdGet = () => Guid.NewGuid(),
                        HiddenGet = () => false,
                        TypeGet = () => SPFieldType.Text
                    }
                }
            );
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid()
                }
            };
            ShimSPListCollection.AllInstances.GetListGuidBoolean = (_, __, ___) => new ShimSPList();

            ShimSPWeb.AllInstances.ServerRelativeUrlGet = _ => DummyUrl;
            ShimSPWeb.AllInstances.GetFileString = (_, __) => new ShimSPFile
            {
                GetLimitedWebPartManagerPersonalizationScope = x => new ShimSPLimitedWebPartManager
                {
                    WebPartsGet = () => new ShimSPLimitedWebPartCollection
                    {
                        ItemGetInt32 = y => new ShimFancyDisplayForm()
                    },
                    SaveChangesWebPart = y => _webPartSaved = true,
                    WebGet = () => new ShimSPWeb()
                }
            };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.GetLimitedWebPartManagerStringPersonalizationScope = (_, __, ___) =>
                new ShimSPLimitedWebPartManager
                {
                    WebPartsGet = () => new ShimSPLimitedWebPartCollection().Bind
                    (
                        new WebPart[]
                        {
                            new GridListView()
                        }
                    ),
                    AddWebPartWebPartStringInt32 = (x, y, z) => _webPartAdded = true,
                    SaveChangesWebPart = x => { }
                };
            ShimSPWeb.AllInstances.Update = _ => { };

            ShimWebPartsReflector.CreateGridListViewWebPart = () => new GridListView();
            ShimWebPartsReflector.IsWebPartGridListViewWebPart = _ => false;

            ShimReadOnlyCollectionBase.AllInstances.CountGet = _ => DummyInt;

            ShimWebPart.AllInstances.TitleGet = _ => FancyDisplayForm;

            ShimListCommands.EnableTeamFeaturesSPList = _ => _teamFeaturesEnabled = true;
            ShimListCommands.EnableTimesheetsSPListSPWeb = (_, __) => _timeSheetsEnabled = true;
            ShimListCommands.DisableTimesheetsSPListSPWeb = (_, __) => _timeSheetsDisabled = true;

            Shimgridganttsettings.AllInstances.AddFieldsAndFixLookupFieldsSPList = (_, __) => { };

            ShimWorkEngineAPI.EventReceiverManagerStringSPWeb = (_, __) => DummyString;

            ShimReportBiz.ConstructorGuid = (_, __) => { };
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportBiz.AllInstances.GetMappedListsIds = _ => new Collection<string> { Guid.NewGuid().ToString() };
            ShimReportBiz.AllInstances.CreateListBizGuidGuidListItemCollection = (_, _1, _2, _3) =>
            {
                _listBizCreated = true;
                return new ShimListBiz();
            };
            ShimReportBiz.AllInstances.UpdateForeignKeysEPMData = (_, __) => true;
            ShimReportBiz.AllInstances.GetReferencingTablesEPMDataString = (_, __, ___) => new DataTable();
            ShimReportBiz.AllInstances.GetListBizGuid = (_, __) => new ShimListBiz
            {
                Delete = () =>
                {
                    _listBizDeleted = true;
                    return true;
                }
            };

            ShimListBiz.ConstructorGuidGuid = (_, __, ___) => { };

            ShimEPMData.ConstructorGuid = (_, __) => { };
            ShimEPMData.AllInstances.Dispose = _ => { };
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, __) => 0;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, __) => true;
            ShimEPMData.AllInstances.AddParamStringObject = (_, __, ___) => { };

            ShimCacheStore.CurrentGet = () => new ShimCacheStore
            {
                RemoveCategoryString = _ => _categoryRemoved = true
            };

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, __, ___) => _redirected = true;
        }

        [TestMethod]
        public void AddFieldsAndFixLookupFields_OnValidCall_ConfirmResult()
        {
            // Arrange
            var fieldsUpdated = false;
            var lookupUpdated = false;
            var list = new ShimSPList
            {
                IDGet = () => Guid.NewGuid(),
                ParentWebGet = () => new ShimSPWeb
                {
                    IDGet = () => Guid.NewGuid(),
                    SiteGet = () => new ShimSPSite
                    {
                        IDGet = () => Guid.NewGuid()
                    },
                    CurrentUserGet = () => new ShimSPUser
                    {
                        UserTokenGet = () => new ShimSPUserToken()
                    }
                }
            }.Instance;

            ShimSPSite.ConstructorGuidSPUserToken = (_, __, ___) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => new ShimSPWeb
            {
                ListsGet = () => new ShimSPListCollection
                {
                    GetListGuidBoolean = (x, y) => new ShimSPList
                    {
                        FieldsGet = () => new ShimSPFieldCollection
                        {
                            AddStringSPFieldTypeBoolean = (name, type, required) => name,
                            AddStringSPFieldTypeBooleanBooleanStringCollection = (name, type, required, compactName, choices) => name,
                            GetFieldByInternalNameString = name =>
                            {
                                switch(name)
                                {
                                    case StartDate:
                                    case DueDate:
                                        return new ShimSPFieldDateTime();
                                    case AssignedTo:
                                        return new ShimSPFieldUser();
                                    case Priority:
                                    case Status:
                                        return new ShimSPFieldChoice();
                                    case Work:
                                    case PercentComplete:
                                    case CommentCount:
                                        return new ShimSPFieldNumber();
                                    case Body:
                                    case Commenters:
                                    case CommentersRead:
                                        return new ShimSPFieldMultiLineText();
                                    case Complete:
                                        return new ShimSPFieldBoolean();
                                    case DaysOverdue:
                                    case ScheduleStatus:
                                    case TodayYear:
                                    case TodayWeek:
                                    case Year:
                                    case Week:
                                    case Due:
                                        return new ShimSPFieldCalculated();
                                    default:
                                        return new ShimSPField();
                                }
                            },
                            DeleteString = name => { },
                            ItemGetInt32 = index => new ShimSPFieldLookup
                            {
                                LookupListGet = () => Guid.NewGuid().ToString(),
                            }
                        }.Bind(
                            new SPField[] 
                            {
                                new ShimSPFieldLookup()
                            }),
                        Update = () => fieldsUpdated = true,
                        ParentWebGet = () => new ShimSPWeb
                        {
                            ListsGet = () => new ShimSPListCollection
                            {
                                ItemGetGuid = guid => null,
                                TryGetListString = name =>
                                {
                                    if (name == ProjectCenter)
                                    {
                                        return new ShimSPList();
                                    }
                                    return null;
                                }
                            }
                        }
                    }
                }
            };

            ShimSPField.AllInstances.Update = _ => { };
            ShimSPField.AllInstances.InternalNameGet = _ => Project;

            ShimTaskFactory.AllInstances.StartNewAction = (_, action) => { action(); return null; };

            Shimgridganttsettings.AllInstances.FieldExistsInListSPListString = (_, __, name) =>
            {
                if (name == Today)
                {
                    return true;
                }
                return false;
            };
            Shimgridganttsettings.AllInstances.UpdateLookupReferencesSPFieldLookupSPWebSPList = (_, _1, _2, _3) => lookupUpdated = true;

            // Act
            _privateObj.Invoke(AddFieldsAndFixLookupFieldsMethod, list);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => fieldsUpdated.ShouldBeTrue(),
                () => lookupUpdated.ShouldBeTrue());
        }
    }
}
