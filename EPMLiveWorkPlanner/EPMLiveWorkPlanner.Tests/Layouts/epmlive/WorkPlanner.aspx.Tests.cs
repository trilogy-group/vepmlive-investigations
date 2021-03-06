﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Fakes;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources.Fakes;
using System.Text;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using EPMLiveWorkPlanner.Fakes;
using EPMLiveWorkPlanner.Layouts.epmlive;
using EPMLiveWorkPlanner.Layouts.epmlive.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.CommandUI.Fakes;
using Shouldly;
using static EPMLiveWorkPlanner.WorkPlannerAPI;

namespace EPMLiveWorkPlanner.Tests.Layouts.epmlive
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class WorkPlannerTests
    {
        private WorkPlanner testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags nonPublicInstance;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPListCollection spListCollection;
        private ShimSPList spList;
        private ShimSPListItemCollection spListItemCollection;
        private ShimSPListItem spListItem;
        private ShimSPFieldCollection spFieldCollection;
        private ShimSPField spField;
        private ShimSPUser spUser;
        private ShimSPFolderCollection spFolderCollection;
        private ShimSPFolder spFolder;
        private ShimSPFileCollection spFileCollection;
        private ShimSPFile spFile;
        private ShimSPViewCollection spViewCollection;
        private ShimSPView spView;
        private ShimSPViewFieldCollection spViewFieldCollection;
        private ShimSPFieldLinkCollection spFieldLinkCollection;
        private ShimSPContentTypeCollection spContentTypeCollection;
        private ShimSPContentType spContentType;
        private Dictionary<string, string> requestDictionary;
        private Guid guid;
        private int validations;
        private const int DummyInt = 1;
        private const int One = 1;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string AgileString = "bAgile";
        private const string ChildParentDDLName = "ddlChildParent";
        private const string PlannerNameFieldName = "sPlannerName";
        private const string MainPanelFieldName = "pnlMain";
        private const string PopupPanelFieldName = "pnlPopup";
        private const string PlannerIdFieldName = "sPlannerID";
        private const string ProjectTypeFieldName = "sProjectType";
        private const string ProjectListIdFieldName = "sProjectListId";
        private const string ItemIdFieldName = "sItemID";
        private const string TaskListIdFieldName = "sTaskListId";
        private const string PlannerKeyString = "Planner";
        private const string ResourceListFieldName = "sResourceList";
        private const string ActLabelName = "lblAct";
        private const string ActPanelName = "pnlAct";
        private const string SetDefaultKeyString = "setdefault";
        private const string ListProjectCenterFieldName = "sListProjectCenter";
        private const string ProjectNameFieldName = "sProjectName";
        private const string ProjectPanelName = "pnlProject";
        private const string SourceFieldName = "sSource";
        private const string MSProjectPanelName = "pnlMSProject";
        private const string OldUrlFieldName = "OldUrl";
        private const string OldPlannerPanelName = "pnlOldPlanner";
        private const string PermsLabelName = "lblPerms";
        private const string PermsPanelName = "pnlPerms";
        private const string SummaryRollupFieldName = "sSummaryRollup";
        private const string ViewObjectFieldName = "sViewObject";
        private const string ActivationFieldName = "activation";
        private const string OnInitMethodName = "OnInit";
        private const string GetFieldsMethodName = "getFields";
        private const string GetAttachedListsMethodName = "getAttachedLists";
        private const string SetDefaultMethodName = "setDefault";
        private const string HasChildParentMethodName = "hasChildParent";
        private const string CheckParentChildMethodName = "checkParentChild";
        private const string ShowPlannerPopupMethodName = "showPlannerPopup";
        private const string LoadDefaultsMethodName = "LoadDefaults";
        private const string ICheckParamsMethodName = "iCheckParams";
        private const string PopulateTemplatesMethodName = "PopulateTemplates";
        private const string CheckParamsMethodName = "checkParams";
        private const string GetResourceListMethodName = "GetResourceList";
        private const string PageLoadMethodName = "Page_Load";
        private const string AddTabEventsMethodName = "AddTabEvents";
        private const string OnPreRenderMethodName = "OnPreRender";
        private const string AddRibbonTabMethodName = "AddRibbonTab";
        private const string CreateOrGetPlannerFragmentListMethodName = "CreateOrGetPlannerFragmentList";

        [TestInitialize]
        public void Setup()
        {
            testObject = new WorkPlanner();
            privateObject = new PrivateObject(testObject);

            SetupShims();
            privateObject.Invoke(
                OnInitMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { EventArgs.Empty });
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest()
            {
                ItemGetString = input =>
                {
                    if (requestDictionary.ContainsKey(input))
                    {
                        return requestDictionary[input];
                    }
                    return input;
                }
            };
            ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => spWeb;
            ShimSPSite.AllInstances.OpenWebString = (_, __) => spWeb;
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => spWeb;
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimCoreFunctions.getLockedWebSPWeb = _ => guid;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => DummyString;
            ShimCoreFunctions.getListSettingStringSPList = (_, __) => DummyString;
            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => DummyString;
            ShimSPList.AllInstances.GetItemsSPQuery = (_, __) => spListItemCollection;
            ShimSPPersistedObject.AllInstances.IdGet = _ => guid;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimUnsecuredLayoutsPageBase.AllInstances.SiteGet = _ => spSite;
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => spWeb;
            ShimAct.ConstructorSPWeb = (_, __) => new ShimAct();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSPContext.AllInstances.SiteGet = _ => spSite;
            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => new ShimSPFieldLookupValueCollection();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimSPRibbonCommand.ConstructorStringStringString = (_, _1, _2, _3) => new ShimSPRibbonCommand();
            ShimSPRibbonScriptManager.Constructor = _ => new ShimSPRibbonScriptManager();
            ShimSPRibbon.GetCurrentPage = _ => new ShimSPRibbon();
        }

        private void SetupVariables()
        {
            validations = 0;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                SiteGet = () => spSite,
                ListsGet = () => spListCollection,
                GetFolderString = _ => spFolder,
                GetFileString = _ => spFile,
                FoldersGet = () => spFolderCollection,
                CurrentUserGet = () => spUser
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => spWeb,
                FeaturesGet = () => new ShimSPFeatureCollection()
                {
                    ItemGetGuid = _ => new ShimSPFeature()
                }
            };
            spListCollection = new ShimSPListCollection()
            {
                TryGetListString = _ => spList,
                ItemGetString = _ => spList,
                ItemGetGuid = _ => spList
            };
            spList = new ShimSPList()
            {
                IDGet = () => guid,
                FieldsGet = () => spFieldCollection,
                GetItemByIdInt32 = _ => spListItem,
                ItemsGet = () => spListItemCollection,
                GetItemsSPQuery = _ => spListItemCollection,
                RootFolderGet = () => spFolder,
                ParentWebGet = () => spWeb,
                DefaultViewGet = () => spView,
                ViewsGet = () => spViewCollection,
                ContentTypesGet = () => spContentTypeCollection,
                TitleGet = () => DummyString
            };
            spListItemCollection = new ShimSPListItemCollection()
            {
                CountGet = () => DummyInt,
                ItemGetInt32 = _ => spListItem
            };
            spListItem = new ShimSPListItem()
            {
                IDGet = () => DummyInt,
                TitleGet = () => DummyString,
                ItemGetString = _ => DummyString,
                ItemGetGuid = _ => DummyString,
                ItemSetGuidObject = (_, __) => { },
                Update = () => { },
                FileGet = () => spFile,
                ParentListGet = () => spList
            };
            spFieldCollection = new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = _ => spField,
                ContainsFieldString = _ => false,
                GetFieldString = _ => spField,
                ItemGetString = _ => spField
            };
            spField = new ShimSPField()
            {
                IdGet = () => guid,
                TitleGet = () => DummyString,
                InternalNameGet = () => DummyString,
                ReadOnlyFieldGet = () => false,
                HiddenGet = () => false,
                ReorderableGet = () => true,
                TypeAsStringGet = () => DummyString
            };
            spUser = new ShimSPUser()
            {
                IDGet = () => DummyInt,
                IsSiteAdminGet = () => true
            };
            spFolderCollection = new ShimSPFolderCollection()
            {
                ItemGetString = _ => spFolder,
                AddString = _ => spFolder
            };
            spFolder = new ShimSPFolder()
            {
                ExistsGet = () => false,
                SubFoldersGet = () => spFolderCollection,
                FilesGet = () => spFileCollection
            };
            spFileCollection = new ShimSPFileCollection()
            {
                CountGet = () => DummyInt,
                AddStringByteArrayBoolean = (_1, _2, _3) => spFile,
                AddStringStream = (_1, _2) => spFile,
                ItemGetString = _ => spFile
            };
            spFile = new ShimSPFile()
            {
                Delete = () => { },
                OpenBinaryStream = () => null,
                NameGet = () => DummyString,
                GetListItemStringArray = _ => spListItem
            };
            spViewCollection = new ShimSPViewCollection()
            {
                ItemGetString = _ => spView
            };
            spView = new ShimSPView()
            {
                ViewFieldsGet = () => spViewFieldCollection,
                ServerRelativeUrlGet = () => SampleUrl
            };
            spViewFieldCollection = new ShimSPViewFieldCollection();
            spContentTypeCollection = new ShimSPContentTypeCollection()
            {
                ItemGetString = _ => spContentType
            };
            spContentType = new ShimSPContentType()
            {
                FieldLinksGet = () => spFieldLinkCollection
            };
            spFieldLinkCollection = new ShimSPFieldLinkCollection()
            {
                ItemGetGuid = _ => new ShimSPFieldLink()
            };
            requestDictionary = new Dictionary<string, string>()
            {
                ["debug"] = bool.FalseString,
                ["listid"] = SampleGuidString1,
                ["id"] = DummyInt.ToString(),
                ["PCSelected"] = string.Empty,
                [PlannerKeyString] = string.Empty
            };

            privateObject.SetFieldOrProperty(ChildParentDDLName, new DropDownList());
            privateObject.SetFieldOrProperty(MainPanelFieldName, new Panel());
            privateObject.SetFieldOrProperty(PopupPanelFieldName, new Panel());
            privateObject.SetFieldOrProperty(ActPanelName, new Panel());
            privateObject.SetFieldOrProperty(ProjectPanelName, new Panel());
            privateObject.SetFieldOrProperty(MSProjectPanelName, new Panel());
            privateObject.SetFieldOrProperty(OldPlannerPanelName, new Panel());
            privateObject.SetFieldOrProperty(PermsPanelName, new Panel());
            privateObject.SetFieldOrProperty("pnlParentChild", new Panel());
            privateObject.SetFieldOrProperty(PlannerNameFieldName, DummyString);
            privateObject.SetFieldOrProperty(ItemIdFieldName, nonPublicInstance, DummyInt.ToString());
            privateObject.SetFieldOrProperty(ProjectListIdFieldName, nonPublicInstance, SampleGuidString1);
            privateObject.SetFieldOrProperty(TaskListIdFieldName, nonPublicInstance, SampleGuidString1);
            privateObject.SetFieldOrProperty(PlannerIdFieldName, nonPublicInstance, DummyString);
            privateObject.SetFieldOrProperty(ActLabelName, nonPublicInstance, new Label());
            privateObject.SetFieldOrProperty(PermsLabelName, nonPublicInstance, new Label());
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetFields_WhenCalled_GetsData()
        {
            // Arrange
            const string schemaXml = @"<Default>Default</Default>";

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPField>()
            {
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.User,
                    InternalNameGet = () => "User"
                },
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.Attachments,
                    InternalNameGet = () => "Attachment",
                    ReadOnlyFieldGet = () => false,
                    SchemaXmlGet = () => schemaXml
                },
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.Number,
                    InternalNameGet = () => "StartDate",
                    ReadOnlyFieldGet = () => false,
                    HiddenGet = () => false,
                    ReorderableGet = () => true,
                    SchemaXmlGet = () => schemaXml
                },
                new ShimSPField()
                {
                    TypeGet = () => SPFieldType.Boolean,
                    InternalNameGet = () => "DueDate",
                    ReadOnlyFieldGet = () => false,
                    HiddenGet = () => false,
                    ReorderableGet = () => true,
                    SchemaXmlGet = () => schemaXml
                }
            }.GetEnumerator();

            spField.InternalNameGet = () => DummyString;

            privateObject.SetFieldOrProperty("sTaskUserFields", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sDefaults", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sProjectUserFields", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);

            // Act
            privateObject.Invoke(
                GetFieldsMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { spWeb.Instance });

            // Assert
            var taskUserFields = privateObject.GetFieldOrProperty("sTaskUserFields", BindingFlags.Instance | BindingFlags.NonPublic);
            var defaults = privateObject.GetFieldOrProperty("sDefaults", BindingFlags.Instance | BindingFlags.NonPublic);
            var projectUserFields = privateObject.GetFieldOrProperty("sProjectUserFields", BindingFlags.Instance | BindingFlags.NonPublic);
            var baselineFields = privateObject.GetFieldOrProperty("sBaselineFields", BindingFlags.Instance | BindingFlags.NonPublic);

            taskUserFields.ShouldSatisfyAllConditions(
                () => taskUserFields.ShouldBe($"{DummyString},'User'"),
                () => defaults.ShouldBe($"{DummyString}Attachment:\"Default\",StartDate:\"Default\",DueDate:\"Default\""),
                () => projectUserFields.ShouldBe($"{DummyString},'User'"),
                () => baselineFields.ShouldBe($"StartDate:\"{DummyString}\",DueDate:\"{DummyString}\""));
        }

        [TestMethod]
        public void GetAttachedLists_WhenCalled_GetsAttachedLists()
        {
            // Arrange
            const string listid = "listid";

            var title = $"Not{DummyString}";
            var schemaXml = string.Format(@"<Child List=""{0}""/>", listid);
            var getEnumeratorCount = 0;

            spList.HiddenGet = () => false;
            spList.TitleGet = () => title;
            spList.BaseTypeGet = () => (SPBaseType)1;
            spField.TypeGet = () => SPFieldType.Lookup;
            spField.SchemaXmlGet = () => schemaXml;
            spField.InternalNameGet = () => DummyString;

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ =>
            {
                getEnumeratorCount = getEnumeratorCount + 1;
                if (getEnumeratorCount == 1)
                {
                    return new List<SPList>()
                    {
                        spList
                    }.GetEnumerator();
                }
                return new List<SPField>()
                    {
                        spField
                    }.GetEnumerator();
            };

            privateObject.SetFieldOrProperty(ListProjectCenterFieldName, BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sListTaskCenter", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sAttachedDocLibs", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);
            privateObject.SetFieldOrProperty("sAttachedLists", BindingFlags.Instance | BindingFlags.NonPublic, DummyString);

            // Act
            privateObject.Invoke(
                GetAttachedListsMethodName,
                BindingFlags.Instance | BindingFlags.NonPublic,
                new object[] { spWeb.Instance, listid });

            // Assert
            var docLibs = privateObject.GetFieldOrProperty("sAttachedDocLibs", BindingFlags.Instance | BindingFlags.NonPublic);
            var lists = privateObject.GetFieldOrProperty("sAttachedLists", BindingFlags.Instance | BindingFlags.NonPublic);

            docLibs.ShouldSatisfyAllConditions(
                () => docLibs.ShouldBe(DummyString),
                () => lists.ShouldBe(DummyString));
        }

        [TestMethod]
        public void SetDefault_WhenCalled_SetsDefaultValues()
        {
            // Arrange
            const string expectedTitle = "DefaultPlanner";

            spWeb.AllowUnsafeUpdatesSetBoolean = _ =>
            {
                validations += 1;
            };
            spFieldCollection.AddStringSPFieldTypeBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };
            spField.TitleSetString = input =>
            {
                if (input.Equals(expectedTitle))
                {
                    validations += 1;
                }
            };
            spField.HiddenSetBoolean = input =>
            {
                if (input.Equals(true))
                {
                    validations += 1;
                }
            };
            spField.SealedSetBoolean = input =>
            {
                if (input.Equals(true))
                {
                    validations += 1;
                }
            };
            spField.Update = () =>
            {
                validations += 1;
            };
            spList.Update = () =>
            {
                validations += 1;
            };
            spListItem.SystemUpdate = () =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(SetDefaultMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            validations.ShouldBe(8);
        }

        [TestMethod]
        public void HasChildParent_ChildItemNotEmpty_ReturnsTrue()
        {
            // Arrange
            const string expected = "ChildItem";

            spListItem.ItemGetString = input =>
            {
                validations += 1;
                if (input.Equals(expected))
                {
                    return DummyString;
                }
                return string.Empty;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                HasChildParentMethodName,
                nonPublicInstance,
                new object[]
                {
                    spWeb.Instance,
                    SampleGuidString1,
                    DummyInt.ToString()
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void HasChildParent_ParentItemNotEmpty_ReturnsTrue()
        {
            // Arrange
            const string expected = "ParentItem";

            spListItem.ItemGetString = input =>
            {
                validations += 1;
                if (input.Equals(expected))
                {
                    return DummyString;
                }
                return string.Empty;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                HasChildParentMethodName,
                nonPublicInstance,
                new object[]
                {
                    spWeb.Instance,
                    SampleGuidString1,
                    DummyInt.ToString()
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void HasChildParent_ItemEmpty_ReturnsFalse()
        {
            // Arrange
            spListItem.ItemGetString = input =>
            {
                validations += 1;
                return string.Empty;
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                HasChildParentMethodName,
                nonPublicInstance,
                new object[]
                {
                    spWeb.Instance,
                    SampleGuidString1,
                    DummyInt.ToString()
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void CheckParentChild_WhenCalled_ReturnsTrue()
        {
            // Arrange
            const string expected = "Choose Item";
            var configSetting = $"{DummyString},{DummyString}";

            spListItem.ItemGetString = input => input;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) => bool.FalseString;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => configSetting;

            // Act
            var actual = (bool)privateObject.Invoke(
                CheckParentChildMethodName,
                nonPublicInstance,
                new object[]
                {
                    spWeb.Instance,
                    SampleGuidString1,
                    DummyInt.ToString()
                });
            var dropDownList = (DropDownList)privateObject.GetFieldOrProperty(ChildParentDDLName, nonPublicInstance);
            var plannerName = (string)privateObject.GetFieldOrProperty(PlannerNameFieldName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => dropDownList.Items.Count.ShouldBe(2),
                () => plannerName.ShouldBe(expected));
        }

        [TestMethod]
        public void ShowPlannerPopup_WhenCalled_ReturnsFalse()
        {
            // Arrange and Act
            privateObject.Invoke(ShowPlannerPopupMethodName, nonPublicInstance, new object[] { });
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName, nonPublicInstance);
            var popupPanel = (Panel)privateObject.GetFieldOrProperty(PopupPanelFieldName, nonPublicInstance);

            // Assert
            mainPanel.ShouldSatisfyAllConditions(
                () => mainPanel.Visible.ShouldBeFalse(),
                () => popupPanel.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void LoadDefaults_WhenCalled_LoadsDefaults()
        {
            // Arrange
            const string expectedPlannerId = "expectedPlannerId";
            const string expectedProjectType = "expectedProjectType";

            spListItem.ItemGetString = _ => $"{expectedPlannerId}|{expectedProjectType}";

            // Act
            privateObject.Invoke(LoadDefaultsMethodName, nonPublicInstance, new object[] { spList.Instance });
            var plannerId = (string)privateObject.GetFieldOrProperty(PlannerIdFieldName, nonPublicInstance);
            var projectType = (string)privateObject.GetFieldOrProperty(ProjectTypeFieldName, nonPublicInstance);

            // Assert
            plannerId.ShouldBe(expectedPlannerId);
        }

        [TestMethod]
        public void ICheckParams_Case1_ReturnsTrue()
        {
            // Arrange
            const string plannerId = "MPP";

            spListItemCollection.CountGet = () => One;

            ShimWorkPlanner.AllInstances.LoadDefaultsSPList = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.PopulateTemplatesSPWeb = (_, __) =>
            {
                validations += 1;
                return false;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) => string.Empty;
            ShimWorkPlannerAPI.GetTaskFileSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return spFile;
            };

            privateObject.SetFieldOrProperty(ProjectListIdFieldName, nonPublicInstance, string.Empty);
            privateObject.SetFieldOrProperty(PlannerIdFieldName, nonPublicInstance, plannerId);
            privateObject.SetFieldOrProperty(ProjectTypeFieldName, nonPublicInstance, string.Empty);
            privateObject.SetFieldOrProperty(ItemIdFieldName, nonPublicInstance, string.Empty);
            privateObject.SetFieldOrProperty(TaskListIdFieldName, nonPublicInstance, string.Empty);

            // Act
            var actual = (bool)privateObject.Invoke(ICheckParamsMethodName, nonPublicInstance, new object[] { spWeb.Instance, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void ICheckParams_Case2_ReturnsTrue()
        {
            // Arrange
            var methodHit = 0;
            var sortedList = new SortedList()
            {
                [DummyString] = DummyString
            };

            spListItemCollection.CountGet = () => One;

            ShimWorkPlanner.AllInstances.LoadDefaultsSPList = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlannerAPI.GetPlannersByProjectListStringSPWeb = (_, __) =>
            {
                validations += 1;
                return sortedList;
            };
            ShimWorkPlannerAPI.GetPlannersByTaskListSPWebString = (_, __) =>
            {
                validations += 1;
                return sortedList;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) =>
            {
                methodHit += 1;
                if (methodHit.Equals(5))
                {
                    return bool.FalseString;
                }
                return bool.TrueString;
            };
            ShimWorkPlanner.AllInstances.PopulateTemplatesSPWeb = (_, __) =>
            {
                validations += 1;
                return false;
            };

            privateObject.SetFieldOrProperty(ProjectListIdFieldName, nonPublicInstance, SampleGuidString1);
            privateObject.SetFieldOrProperty(TaskListIdFieldName, nonPublicInstance, SampleGuidString1);
            privateObject.SetFieldOrProperty(PlannerIdFieldName, nonPublicInstance, string.Empty);
            privateObject.SetFieldOrProperty(ProjectTypeFieldName, nonPublicInstance, string.Empty);
            privateObject.SetFieldOrProperty(ItemIdFieldName, nonPublicInstance, string.Empty);

            // Act
            var actual = (bool)privateObject.Invoke(ICheckParamsMethodName, nonPublicInstance, new object[] { spWeb.Instance, spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(4),
                () => methodHit.ShouldBe(7));
        }

        [TestMethod]
        public void PopulateTemplates_Count0_ReturnsFalse()
        {
            // Arrange
            const string projectType = "Project";
            var templates = new DataTable();

            ShimWorkPlannerAPI.GetTemplatesSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return templates;
            };
            ShimWorkPlannerAPI.ApplyNewTemplateSPWebStringStringStringStringString = (_1, plannerId, templateId, _4, _5, _6) =>
            {
                if (string.IsNullOrEmpty(plannerId) && string.IsNullOrEmpty(templateId))
                {
                    validations += 1;
                }
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, nonPublicInstance, projectType);

            // Act
            var actual = (bool)privateObject.Invoke(PopulateTemplatesMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void PopulateTemplates_Count1_ReturnsFalse()
        {
            // Arrange
            const string projectType = "Project";
            var templates = new DataTable();
            var row = default(DataRow);

            templates.Columns.Add(IDStringCaps);
            row = templates.NewRow();
            row[IDStringCaps] = DummyInt;
            templates.Rows.Add(row);

            ShimWorkPlannerAPI.GetTemplatesSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return templates;
            };
            ShimWorkPlannerAPI.ApplyNewTemplateSPWebStringStringStringStringString = (_1, plannerId, templateId, _4, _5, _6) =>
            {
                if (plannerId.Equals(projectType) && templateId.Equals(DummyInt.ToString()))
                {
                    validations += 1;
                }
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, nonPublicInstance, projectType);
            privateObject.SetFieldOrProperty(PlannerIdFieldName, nonPublicInstance, projectType);

            // Act
            var actual = (bool)privateObject.Invoke(PopulateTemplatesMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void PopulateTemplates_CountGreaterThan1_ReturnsTrue()
        {
            // Arrange
            const string projectType = "Project";
            var templates = new DataTable();
            var row = default(DataRow);

            templates.Columns.Add(IDStringCaps);
            row = templates.NewRow();
            row[IDStringCaps] = DummyInt;
            templates.Rows.Add(row);
            row = templates.NewRow();
            row[IDStringCaps] = DummyInt;
            templates.Rows.Add(row);

            ShimWorkPlannerAPI.GetTemplatesSPWebStringString = (_1, _2, _3) =>
            {
                validations += 1;
                return templates;
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, nonPublicInstance, projectType);
            privateObject.SetFieldOrProperty(PlannerIdFieldName, nonPublicInstance, projectType);

            // Act
            var actual = (bool)privateObject.Invoke(PopulateTemplatesMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void CheckParams_Case1_ReturnsTrue()
        {
            // Arrange
            const string plannerString = "MPP";
            requestDictionary[PlannerKeyString] = plannerString;

            // Act
            var actual = (bool)privateObject.Invoke(CheckParamsMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void CheckParams_Case2_ReturnsFalse()
        {
            // Arrange
            requestDictionary[PlannerKeyString] = DummyString;

            ShimWorkPlanner.AllInstances.hasChildParentSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (bool)privateObject.Invoke(CheckParamsMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeFalse(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void CheckParams_Case3_ReturnsTrue()
        {
            // Arrange
            requestDictionary[PlannerKeyString] = DummyString;

            ShimWorkPlanner.AllInstances.hasChildParentSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimCoreFunctions.getLockedWebSPWeb = _ =>
            {
                validations += 1;
                return Guid.Empty;
            };
            ShimWorkPlanner.AllInstances.iCheckParamsSPWebSPWeb = (_, _1, _2) =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (bool)privateObject.Invoke(CheckParamsMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void CheckParams_Case4_ReturnsTrue()
        {
            // Arrange
            requestDictionary[PlannerKeyString] = DummyString;

            ShimWorkPlanner.AllInstances.hasChildParentSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimCoreFunctions.getLockedWebSPWeb = _ =>
            {
                validations += 1;
                return Guid.Parse(SampleGuidString2);
            };
            ShimWorkPlanner.AllInstances.iCheckParamsSPWebSPWeb = (_, _1, _2) =>
            {
                validations += 1;
                return true;
            };

            // Act
            var actual = (bool)privateObject.Invoke(CheckParamsMethodName, nonPublicInstance, new object[] { spWeb.Instance });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(3));
        }

        [TestMethod]
        public void GetResourceList_WhenCalled_SetsResourceList()
        {
            // Arrange
            const string expected = "expectedString";

            ShimPlannerCore.getResourceListStringSPWeb = (_, __) =>
            {
                validations += 1;
                return expected;
            };

            privateObject.SetFieldOrProperty(ResourceListFieldName, DummyString);
            privateObject.SetFieldOrProperty(ProjectListIdFieldName, DummyString);
            privateObject.SetFieldOrProperty(ItemIdFieldName, DummyString);

            // Act
            privateObject.Invoke(GetResourceListMethodName, nonPublicInstance, new object[] { spWeb.Instance });
            var actual = (string)privateObject.GetFieldOrProperty(ResourceListFieldName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void PageLoad_Case1_SetsFieldsAndProperties()
        {
            // Arrange
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return One;
            };
            ShimAct.AllInstances.translateStatusInt32 = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var actual = (Label)privateObject.GetFieldOrProperty(ActLabelName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var actPanel = (Panel)privateObject.GetFieldOrProperty(ActPanelName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Text.ShouldBe(DummyString),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => actPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void PageLoad_Case2_SetsFieldsAndProperties()
        {
            // Arrange
            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);

            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.showPlannerPopup = _ =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var plannerId = (string)privateObject.GetFieldOrProperty(PlannerIdFieldName);
            var plannerName = (string)privateObject.GetFieldOrProperty(PlannerNameFieldName);

            // Assert
            plannerId.ShouldSatisfyAllConditions(
                () => plannerId.ShouldBe(string.Empty),
                () => plannerName.ShouldBe(PlannerKeyString),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void PageLoad_Case3_SetsFieldsAndProperties()
        {
            // Arrange
            var planners = $"{DummyString}|{DummyString}";
            var plannerProps = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };

            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);

            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return planners;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return plannerProps;
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, "Project");
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);
            privateObject.SetFieldOrProperty(ItemIdFieldName, DummyInt.ToString());

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var plannerId = (string)privateObject.GetFieldOrProperty(PlannerIdFieldName);
            var plannerName = (string)privateObject.GetFieldOrProperty(PlannerNameFieldName);
            var projectCenter = (string)privateObject.GetFieldOrProperty(ListProjectCenterFieldName);
            var projectName = (string)privateObject.GetFieldOrProperty(ProjectNameFieldName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var projectPanel = (Panel)privateObject.GetFieldOrProperty(ProjectPanelName);

            // Assert
            plannerId.ShouldSatisfyAllConditions(
                () => plannerId.ShouldBe(DummyString),
                () => plannerName.ShouldBe(DummyString),
                () => projectCenter.ShouldBe(DummyString),
                () => projectName.ShouldBe(DummyString),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => projectPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void PageLoad_Case4_SetsFieldsAndProperties()
        {
            // Arrange
            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);
            requestDictionary.Add("Source", string.Empty);
            requestDictionary.Add("ID", DummyInt.ToString());
            requestDictionary[PlannerKeyString] = "MSProject";

            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, "NotProject");
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var projectListId = (string)privateObject.GetFieldOrProperty(ProjectListIdFieldName);
            var source = (string)privateObject.GetFieldOrProperty(SourceFieldName);
            var itemId = (string)privateObject.GetFieldOrProperty(ItemIdFieldName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var msProjectPanel = (Panel)privateObject.GetFieldOrProperty(MSProjectPanelName);

            // Assert
            projectListId.ShouldSatisfyAllConditions(
                () => projectListId.ShouldBe(guid.ToString().ToUpper()),
                () => source.ShouldBe(SampleUrl),
                () => itemId.ShouldBe(DummyInt.ToString()),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => msProjectPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void PageLoad_Case5_SetsFieldsAndProperties()
        {
            // Arrange
            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);
            requestDictionary.Add(IDStringCaps, DummyInt.ToString());
            requestDictionary[PlannerKeyString] = "WEWorkPlanner";

            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return true;
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, "NotProject");
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var oldUrl = (string)privateObject.GetFieldOrProperty(OldUrlFieldName);
            var itemId = (string)privateObject.GetFieldOrProperty(ItemIdFieldName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var oldPlannerPanel = (Panel)privateObject.GetFieldOrProperty(OldPlannerPanelName);

            // Assert
            oldUrl.ShouldSatisfyAllConditions(
                () => oldUrl.ShouldBe("tasks"),
                () => itemId.ShouldBe(DummyInt.ToString()),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => oldPlannerPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void PageLoad_Case6_SetsFieldsAndProperties()
        {
            // Arrange
            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);
            requestDictionary.Add("ID", DummyInt.ToString());
            requestDictionary[PlannerKeyString] = "WEAgilePlanner";

            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return true;
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, "NotProject");
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var oldUrl = (string)privateObject.GetFieldOrProperty(OldUrlFieldName);
            var itemId = (string)privateObject.GetFieldOrProperty(ItemIdFieldName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var oldPlannerPanel = (Panel)privateObject.GetFieldOrProperty(OldPlannerPanelName);

            // Assert
            oldUrl.ShouldSatisfyAllConditions(
                () => oldUrl.ShouldBe("agile/tasks"),
                () => itemId.ShouldBe(DummyInt.ToString()),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => oldPlannerPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void PageLoad_Case7_SetsFieldsAndProperties()
        {
            // Arrange
            var plannerProps = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };

            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);
            requestDictionary.Add("ID", DummyInt.ToString());
            requestDictionary[PlannerKeyString] = DummyString;

            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return string.Empty;
            };
            ShimWorkPlanner.AllInstances.showPlannerPopup = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, "NotProject");
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });

            // Assert
            validations.ShouldBe(6);
        }

        private void PageLoadCase8Setup()
        {
            var menus = "costs|resplan";
            var planners = $"{DummyString}|{DummyString}";
            var plannerProps = new PlannerProps()
            {
                sListProjectCenter = DummyString
            };
            var configDictionary = new Dictionary<string, string>()
            {
                ["EPKMenus"] = menus,
                ["epknonactivexs"] = menus
            };

            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);
            requestDictionary.Add(IDStringCaps, DummyInt.ToString());
            requestDictionary[PlannerKeyString] = DummyString;

            spListItem.ItemGetString = _ => string.Empty;
            spListItem.ItemGetGuid = _ => string.Empty;
            spUser.IsSiteAdminGet = () => false;
            spUser.IDGet = () => DummyInt + 10;

            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return planners;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) =>
            {
                if (input.EndsWith("_menus") || input.EndsWith("_nonactivexs"))
                {
                    return string.Empty;
                }
                else if (configDictionary.ContainsKey(input))
                {
                    return configDictionary[input];
                }
                return DummyString;
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, "NotProject");
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);
            privateObject.SetFieldOrProperty(ItemIdFieldName, DummyInt.ToString());
        }

        [TestMethod]
        public void PageLoad_Case81_SetsFieldsAndProperties()
        {
            // Arrange
            const string expected = "You do not have permissions to edit the project.";

            PageLoadCase8Setup();

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => false;

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var actual = (Label)privateObject.GetFieldOrProperty(PermsLabelName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var permsPanel = (Panel)privateObject.GetFieldOrProperty(PermsPanelName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Text.ShouldBe(expected),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => permsPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void PageLoad_Case82_SetsFieldsAndProperties()
        {
            // Arrange
            const string expected = "You do not have permissions to edit the Project Schedules library.";
            var methodHit = 0;

            PageLoadCase8Setup();

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) =>
            {
                methodHit += 1;
                if (methodHit > 2)
                {
                    return false;
                }
                return true;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var actual = (Label)privateObject.GetFieldOrProperty(PermsLabelName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var permsPanel = (Panel)privateObject.GetFieldOrProperty(PermsPanelName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Text.ShouldBe(expected),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => permsPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void PageLoad_Case83_SetsFieldsAndProperties()
        {
            // Arrange
            const string expected = "You do not have permissions to edit task center items.";
            var methodHit = 0;

            PageLoadCase8Setup();

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) =>
            {
                methodHit += 1;
                if (methodHit > 1)
                {
                    return false;
                }
                return true;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var actual = (Label)privateObject.GetFieldOrProperty(PermsLabelName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var permsPanel = (Panel)privateObject.GetFieldOrProperty(PermsPanelName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Text.ShouldBe(expected),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => permsPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void PageLoad_Case91_SetsFieldsAndProperties()
        {
            // Arrange
            const string expected = "You do not have permissions to edit the project.";
            var lookupList = new List<SPFieldLookupValue>()
            {
                new ShimSPFieldLookupValue()
                {
                    LookupIdGet = () => (DummyInt + 10)
                }
            };

            PageLoadCase8Setup();

            spListItem.ItemGetString = _ => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => false;

            ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = _ =>
            {
                var result = default(List<SPFieldLookupValue>.Enumerator);
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = lookupList.GetEnumerator();
                });
                return result;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var actual = (Label)privateObject.GetFieldOrProperty(PermsLabelName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var permsPanel = (Panel)privateObject.GetFieldOrProperty(PermsPanelName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Text.ShouldBe(expected),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => permsPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void PageLoad_Case92_SetsFieldsAndProperties()
        {
            // Arrange
            const string expected = "You do not have permissions to edit task center items.";
            var methodHit = 0;
            var lookupList = new List<SPFieldLookupValue>()
            {
                new ShimSPFieldLookupValue()
                {
                    LookupIdGet = () => (DummyInt + 10)
                }
            };

            PageLoadCase8Setup();

            spListItem.ItemGetString = _ => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) =>
            {
                methodHit += 1;
                if (methodHit > 1)
                {
                    return false;
                }
                return true;
            };

            ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = _ =>
            {
                var result = default(List<SPFieldLookupValue>.Enumerator);
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = lookupList.GetEnumerator();
                });
                return result;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var actual = (Label)privateObject.GetFieldOrProperty(PermsLabelName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var permsPanel = (Panel)privateObject.GetFieldOrProperty(PermsPanelName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Text.ShouldBe(expected),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => permsPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void PageLoad_Case93_SetsFieldsAndProperties()
        {
            // Arrange
            const string expected = "You do not have permissions to edit the Project Schedules library.";
            var methodHit = 0;
            var lookupList = new List<SPFieldLookupValue>()
            {
                new ShimSPFieldLookupValue()
                {
                    LookupIdGet = () => (DummyInt + 10)
                }
            };

            PageLoadCase8Setup();

            spListItem.ItemGetString = _ => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) =>
            {
                methodHit += 1;
                if (methodHit > 2)
                {
                    return false;
                }
                return true;
            };

            ShimList<SPFieldLookupValue>.AllInstances.GetEnumerator = _ =>
            {
                var result = default(List<SPFieldLookupValue>.Enumerator);
                ShimsContext.ExecuteWithoutShims(() =>
                {
                    result = lookupList.GetEnumerator();
                });
                return result;
            };

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var actual = (Label)privateObject.GetFieldOrProperty(PermsLabelName);
            var mainPanel = (Panel)privateObject.GetFieldOrProperty(MainPanelFieldName);
            var permsPanel = (Panel)privateObject.GetFieldOrProperty(PermsPanelName);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Text.ShouldBe(expected),
                () => mainPanel.Visible.ShouldBeFalse(),
                () => permsPanel.Visible.ShouldBeTrue(),
                () => validations.ShouldBe(6));
        }

        [TestMethod]
        public void AddTabEvents_WhenCalled_AddsTabEvents()
        {
            // Arrange
            var actual = new List<IRibbonCommand>();

            ShimWorkPlanner.AllInstances.CreateOrGetPlannerFragmentList = _ => spList.Instance;
            ShimSPList.AllInstances.DoesUserHavePermissionsSPUserSPBasePermissions = (_, _1, _2) => true;
            ShimSPRibbonScriptManager.AllInstances.RegisterInitializeFunctionControlStringStringBooleanString = (_, _1, _2, _3, _4, _5) =>
            {
                validations += 1;
            };
            ShimSPRibbonScriptManager.AllInstances.RegisterGetCommandsFunctionControlStringIEnumerableOfIRibbonCommand = (_, _1, _2, commands) =>
            {
                validations += 1;
            };
            ShimSPRibbonScriptManager.AllInstances.RegisterCommandEnabledFunctionControlStringIEnumerableOfIRibbonCommand = (_, _1, _2, commands) =>
            {
                validations += 1;
            };
            ShimSPRibbonScriptManager.AllInstances.RegisterHandleCommandFunctionControlStringIEnumerableOfIRibbonCommand = (_, _1, _2, commands) =>
            {
                actual.AddRange(commands);
                validations += 1;
            };

            // Act
            privateObject.Invoke(AddTabEventsMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(79),
                () => validations.ShouldBe(4));
        }

        [TestMethod]
        public void PageLoad_Case10_SetsFieldsAndProperties()
        {
            // Arrange
            const string plannerId = "DummyString";
            const string menus = "costs|resplan";
            const string dataXmlString = @"
                <xmlcfg>
                    <%=sPlannerLayoutParam%>
                    <%=sPlannerDataParam%>
                </xmlcfg>";
            const string defaultView = "defaultView";
            var viewList = $"{defaultView}|`|;#{DummyString}|`|";
            var now = DateTime.Now;
            var planners = $"{plannerId}|{DummyString}";
            var plannerProps = new PlannerProps()
            {
                sListProjectCenter = DummyString,
                bAgile = true
            };
            var configDictionary = new Dictionary<string, string>()
            {
                ["EPKMenus"] = menus,
                ["epknonactivexs"] = menus,
                [$"EPMLivePlanner{plannerId}Views"] = viewList
            };

            requestDictionary.Add(SetDefaultKeyString, bool.TrueString);
            requestDictionary.Add(IDStringCaps, DummyInt.ToString());
            requestDictionary.Add("isDlg", One.ToString());
            requestDictionary[PlannerKeyString] = DummyString;

            spUser.IsSiteAdminGet = () => true;
            spListItem.ItemGetString = input =>
            {
                if (input.Equals($"{plannerId}BD"))
                {
                    return now;
                }
                return DummyString;
            };
            spFieldCollection.ContainsFieldString = _ => true;

            ShimSPSecurableObject.AllInstances.DoesUserHavePermissionsSPBasePermissions = (_, __) => true;
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) =>
            {
                validations += 1;
                return dataXmlString;
            };
            ShimAct.AllInstances.CheckFeatureLicenseActFeature = (_, __) =>
            {
                validations += 1;
                return 0;
            };
            ShimWorkPlanner.AllInstances.setDefaultSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.checkParentChildSPWebStringString = (_, _1, _2, _3) =>
            {
                validations += 1;
                return false;
            };
            ShimWorkPlanner.AllInstances.checkParamsSPWeb = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimWorkPlannerAPI.getSettingsSPWebString = (_1, _2) =>
            {
                validations += 1;
                return plannerProps;
            };
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return planners;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, input) =>
            {
                if (input.EndsWith("_menus") || input.EndsWith("_nonactivexs"))
                {
                    return string.Empty;
                }
                else if (configDictionary.ContainsKey(input))
                {
                    return configDictionary[input];
                }
                return DummyString;
            };
            ShimWorkPlanner.AllInstances.GetResourceListSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.getFieldsSPWeb = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.processRollupsWorkPlannerAPIPlannerProps = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.getAttachedListsSPWebString = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.GetViewStringStringArrayStringArray = (_, _1, _2) =>
            {
                validations += 1;
                return new StringBuilder(DummyString);
            };

            privateObject.SetFieldOrProperty(ProjectTypeFieldName, "NotProject");
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);
            privateObject.SetFieldOrProperty(ItemIdFieldName, DummyInt.ToString());

            // Act
            privateObject.Invoke(PageLoadMethodName, nonPublicInstance, new object[] { default(object), EventArgs.Empty });
            var summaryRollup = (string)privateObject.GetFieldOrProperty(SummaryRollupFieldName);
            var viewObject = (string)privateObject.GetFieldOrProperty(ViewObjectFieldName);

            // Assert
            summaryRollup.ShouldSatisfyAllConditions(
                () => summaryRollup.ShouldBe("true"),
                () => viewObject.ShouldBe($"{DummyString},{DummyString}"),
                () => validations.ShouldBe(13));
        }

        [TestMethod]
        public void OnPreRender_WhenCalled_AddsRibbonTabsAndTabEvents()
        {
            // Arrange
            var mainPanel = new Panel()
            {
                Visible = true
            };

            ShimUnsecuredLayoutsPageBase.AllInstances.OnPreRenderEventArgs = (_, __) =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.AddRibbonTab = _ =>
            {
                validations += 1;
            };
            ShimWorkPlanner.AllInstances.AddTabEvents = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(ActivationFieldName, 0);
            privateObject.SetFieldOrProperty(ItemIdFieldName, One.ToString());
            privateObject.SetFieldOrProperty(PlannerIdFieldName, DummyString);
            privateObject.SetFieldOrProperty(MainPanelFieldName, mainPanel);

            // Act
            privateObject.Invoke(OnPreRenderMethodName, nonPublicInstance, new object[] { EventArgs.Empty });

            // Assert
            validations.ShouldBe(3);
        }

        [TestMethod]
        public void AddRibbonTab_WhenCalled_AddsRibbons()
        {
            // Arrange
            const string expected = "Ribbon.WorkPlanner";
            const string dataXmlString = @"<xmlcfg/>";
            var spRibbon = new ShimSPRibbon()
            {
                CommandUIVisibleSetBoolean = input =>
                {
                    if (input)
                    {
                        validations += 1;
                    }
                }
            };

            ShimSPRibbon.GetCurrentPage = _ =>
            {
                validations += 1;
                return spRibbon;
            };
            ShimResourceManager.AllInstances.GetStringStringCultureInfo = (_, _1, _2) =>
            {
                validations += 1;
                return dataXmlString;
            };
            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ =>
            {
                validations += 1;
                return false;
            };
            ShimRibbon.AllInstances.RegisterDataExtensionXmlNodeString = (_, _1, _2) =>
            {
                validations += 1;
            };
            ShimRibbon.AllInstances.MinimizedSetBoolean = (_, input) =>
            {
                if (!input)
                {
                    validations += 1;
                }
            };
            ShimRibbon.AllInstances.IsTabAvailableString = (_, __) =>
            {
                validations += 1;
                return false;
            };
            ShimRibbon.AllInstances.MakeTabAvailableString = (_, __) =>
            {
                validations += 1;
            };
            ShimRibbon.AllInstances.TrimByIdString = (_, __) =>
            {
                validations += 1;
            };
            ShimRibbon.AllInstances.InitialTabIdSetString = (_, input) =>
            {
                if (input.Equals(expected))
                {
                    validations += 1;
                }
            };

            privateObject.SetFieldOrProperty(AgileString, true);

            // Act
            privateObject.Invoke(AddRibbonTabMethodName, nonPublicInstance, new object[] { });

            // Assert
            validations.ShouldBe(28);
        }

        [TestMethod]
        public void CreateOrGetPlannerFragmentList_WhenCalled_ReturnsSPList()
        {
            // Arrange
            const string expected = "Private";
            var fieldChoice = new ShimSPFieldChoice();

            spWeb.AllowUnsafeUpdatesSetBoolean = input =>
            {
                if (input)
                {
                    validations += 1;
                }
            };
            spListCollection.TryGetListString = _ =>
            {
                validations += 1;
                return null;
            };
            spListCollection.AddStringStringSPListTemplateType = (_1, _2, _3) =>
            {
                validations += 1;
                return guid;
            };
            spFieldCollection.AddStringSPFieldTypeBoolean = (_1, _2, _3) =>
            {
                validations += 1;
                return DummyString;
            };
            spFieldCollection.ItemGetString = _ =>
            {
                validations += 1;
                return fieldChoice;
            };
            spViewFieldCollection.AddString = _ =>
            {
                validations += 1;
            };
            spList.Update = () =>
            {
                validations += 1;
            };
            spView.Update = () =>
            {
                validations += 1;
            };
            spWeb.Update = () =>
            {
                validations += 1;
            };

            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection();
            ShimSPField.AllInstances.DefaultValueSetString = (_, input) =>
            {
                if (input.Equals(expected))
                {
                    validations += 1;
                }
            };
            ShimSPFieldMultiChoice.AllInstances.Update = _ =>
            {
                validations += 1;
            };

            // Act
            var actual = (SPList)privateObject.Invoke(CreateOrGetPlannerFragmentListMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => validations.ShouldBe(19));
        }
    }
}