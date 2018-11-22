using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using ResourceValues;
using RPADataCache;
using RPADataCache.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public partial class RPADataTests
    {
        private RPAData testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private BindingFlags publicStatic;
        private BindingFlags publicInstance;
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
        private ShimSqlTransaction transaction;
        private Guid guid;
        private int validations;
        private const int DummyInt = 1;
        private const int Zero = 0;
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;
        private const int Four = 4;
        private const int Five = 5;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string ResourceValuesFieldName = "m_cResVals";
        private const string RolesAllowedFieldName = "m_CSRoleAllowed";
        private const string CatLookupFieldName = "m_maj_Cat_lookup";
        private const string UserDeptsFieldName = "UserDepts";
        private const string CostCategoryRoleMappingFieldName = "m_CCR_Role_Mapping";
        private const string TotalMasterColumnFieldName = "m_totmastercln";
        private const string DetMasterColumnFieldName = "m_detmastercln";
        private const string TotalDisplayColumnFieldName = "m_totdispcln";
        private const string DetDisplayColumnFieldName = "m_detdispcln";
        private const string ViewsXmlFieldName = "m_viewsxml";
        private const string ResDataFieldName = "m_resdata";
        private const string SortColumnFieldName = "m_clnsort";
        private const string UseHeatMapFieldName = "m_use_heatmap";
        private const string TotGeneralFieldName = "TotGeneral";
        private const string TotCapacityFieldName = "TotCapacity";
        private const string UseHeatMapIDFieldName = "m_use_heatmapID";
        private const string UseRoleFieldName = "m_use_role";
        private const string CostCategoryRoleListFieldName = "m_ccrolelist";
        private const string RoleListFieldName = "m_rolelist";
        private const string ResListFieldName = "m_reslist";
        private const string HeatMapTextFieldName = "m_heatmap_text";
        private const string DisplayModeFieldName = "m_DispMode";
        private const string PisColumnFieldName = "m_cln_pis";
        private const string TgStandardFieldName = "TGStandard";
        private const string VisibleString = "Visible";
        private const string ClassString = "Class";
        private const string DisplayTotDetailsFieldName = "m_DisplayTotDetails";
        private const string TotSelectedOrderFieldName = "TotSelectedOrder";
        private const string ValueString = "Value";
        private const string TotCapacityNonRoleFieldName = "TotCapacityNonRole";
        private const string RoleModeFieldName = "m_role_mode";
        private const string UseHeatMapColourFieldName = "m_use_heatmapColour";
        private const string DragStackFieldName = "m_drag_stack";
        private const string CheckActualFieldName = "chkActual";
        private const string CheckOpenRequireFieldName = "chkOpenRequire";
        private const string CheckMspfFieldName = "ckkMSPF";
        private const string CheckCommitFieldName = "chkCommit";
        private const string CheckNonWorkFieldName = "chkNonWork";
        private const string CheckOpenRequestFieldName = "chkOpenRequest";
        private const string HadOpenReqsFieldName = "m_hadopen_reqs";
        private const string UsedBottomColumn = "m_usedbottomcln";
        private const string FteConvFieldName = "m_fte_conv";
        private const string NumPerFieldName = "m_num_per";
        private const string StashCSRoleModeMethodName = "StashCSRoleMode";
        private const string IsCSRoleAllowedMethodName = "IsCSRoleAllowed";
        private const string SetMajorCatListlookupMethodName = "SetMajorCatListlookup";
        private const string ItemListAddItemMethodName = "ItemListAddItem";
        private const string GrabRADataMethodName = "GrabRAData";
        private const string DoUserDeptsMethodName = "DoUserDepts";
        private const string BuileCCR2RoleMapMethodName = "BuileCCR2RoleMap";
        private const string MapCCR2RoleMethodName = "MapCCR2Role";
        private const string setupdispcolnsMethodName = "setupdispcolns";
        private const string ConvFTEsMethodName = "ConvFTEs";
        private const string ConvHRsMethodName = "ConvHRs";
        private const string ExtractEmbeddedStringMethodName = "ExtractEmbeddedString";
        private const string GetCostCatStringsMethodName = "GetCostCatStrings";
        private const string GetRoleNameMethodName = "GetRoleName";
        private const string ReDrawGridMethodName = "ReDrawGrid";
        private const string GetMajorCatStringsMethodName = "GetMajorCatStrings";
        private const string NewRedrawTotalsMethodName = "NewRedrawTotals";
        private const string GetMajorCatMethodName = "GetMajorCat";
        private const string GetPeriodNameMethodName = "GetPeriodName";
        private const string GetTopGridMethodName = "GetTopGrid";
        private const string GetBottomGridMethodName = "GetBottomGrid";
        private const string GetTotalsDataMethodName = "GetTotalsData";
        private const string SetTotalsDataMethodName = "SetTotalsData";
        private const string GetDetailsDataMethodName = "GetDetailsData";
        private const string SetDetailsDataMethodName = "SetDetailsData";
        private const string SetDisplayModeMethodName = "SetDisplayMode";
        private const string GetDisplayModeMethodName = "GetDisplayMode";
        private const string SetSelectedForRowsMethodName = "SetSelectedForRows";
        private const string SetSelectedForTotalsMethodName = "SetSelectedForTotals";
        private const string SetRADragRowsMethodName = "SetRADragRows";
        private const string UndoRADragRowsMethodName = "UndoRADragRows";
        private const string SetFilteredForRowsMethodName = "SetFilteredForRows";
        private const string GetTargetRGBDataMethodName = "GetTargetRGBData";
        private const string CreateNewResFullDAtaMethodName = "CreateNewResFullDAta";
        private const string ApplyServerSideViewSettingsMethodName = "ApplyServerSideViewSettings";
        private const string RemoveCapacityScenarioMethodName = "RemoveCapacityScenario";
        private const string PrepareCSGridMethodName = "PrepareCSGrid";
        private const string GetCapacityScenarioGridMethodName = "GetCapacityScenarioGrid";
        private const string GetLegendGridMethodName = "GetLegendGrid";
        private const string RPASaveDraggedDataMethodName = "RPASaveDraggedData";
        private const string GetStartFinishDataPeriodsMethodName = "GetStartFinishDataPeriods";
        private const string ReplaceCSDataMethodName = "ReplaceCSData";
        private const string UpdateCSDataModeMethodName = "UpdateCSDataMode";
        private const string ResolvePINameMethodName = "ResolvePIName";
        private const string GetRoleScrenarioDataMethodName = "GetRoleScrenarioData";
        private const string GetCSDeptUIDsMethodName = "GetCSDeptUIDs";
        private const string GetCSDeptListMethodName = "GetCSDeptList";
        private const string SetAllChecksMethodName = "SetAllChecks";
        private const string GetEditResPlanPIListMethodName = "GetEditResPlanPIList";
        private const string GetEditResPlanResListMethodName = "GetEditResPlanResList";
        private const string GetEditResPlanTicketMethodName = "GetEditResPlanTicket";
        private const string AddElementMethodName = "AddElement";
        private const string PopulateInternalsMethodName = "PopulateInternals";

        [TestInitialize]
        public void Setup()
        {
            testObject = new RPAData();
            privateObject = new PrivateObject(testObject);

            SetupShims();
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();
            SetupVariables();

            ShimSqlConnection.ConstructorString = (_, __) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.BeginTransaction = _ => transaction;
            ShimDbTransaction.AllInstances.Dispose = _ => { };
            ShimSqlConnection.AllInstances.CreateCommand = _ => new SqlCommand();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimSqlCommand.AllInstances.TransactionSetSqlTransaction = (_, __) => { };
            ShimSPDatabase.AllInstances.DatabaseConnectionStringGet = _ => DummyString;
            ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
            ShimHttpUtility.HtmlEncodeString = input => input;
            ShimSPSite.ConstructorString = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuid = (_, __) => new ShimSPSite();
            ShimSPSite.ConstructorGuidSPUserToken = (_, _1, _2) => new ShimSPSite();
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
            ShimUnsecuredLayoutsPageBase.AllInstances.SiteGet = _ => spSite;
            ShimUnsecuredLayoutsPageBase.AllInstances.WebGet = _ => spWeb;
            ShimAct.ConstructorSPWeb = (_, __) => new ShimAct();
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => spWeb;
            ShimSPContext.AllInstances.SiteGet = _ => spSite;
            ShimSPFieldLookupValueCollection.ConstructorString = (_, __) => new ShimSPFieldLookupValueCollection();
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimDisabledItemEventScope.Constructor = _ => new ShimDisabledItemEventScope();
            ShimDisabledItemEventScope.AllInstances.Dispose = _ => { };
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => spUser;
            ShimSPSiteDataQuery.Constructor = _ => new ShimSPSiteDataQuery();
        }

        private void SetupVariables()
        {
            validations = Zero;
            publicStatic = BindingFlags.Static | BindingFlags.Public;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
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
                CurrentUserGet = () => spUser,
                ServerRelativeUrlGet = () => SampleUrl,
                AllUsersGet = () => new ShimSPUserCollection(),
                SiteUsersGet = () => new ShimSPUserCollection(),
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid,
                WebApplicationGet = () => new ShimSPWebApplication(),
                RootWebGet = () => spWeb,
                FeaturesGet = () => new ShimSPFeatureCollection()
                {
                    ItemGetGuid = _ => new ShimSPFeature()
                },
                ContentDatabaseGet = () => new ShimSPContentDatabase()
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
                TitleGet = () => DummyString,
                EventReceiversGet = () => new ShimSPEventReceiverDefinitionCollection(),
                DefaultViewUrlGet = () => SampleUrl
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
                ParentListGet = () => spList,
                NameGet = () => DummyString
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
                IsSiteAdminGet = () => true,
                UserTokenGet = () => new ShimSPUserToken()
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
                FilesGet = () => spFileCollection,
                UrlGet = () => SampleUrl,
                UniqueIdGet = () => guid,
                ParentWebGet = () => spWeb
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
                IdGet = () => default(SPContentTypeId),
                FieldLinksGet = () => spFieldLinkCollection
            };
            spFieldLinkCollection = new ShimSPFieldLinkCollection()
            {
                ItemGetGuid = _ => new ShimSPFieldLink()
            };
            transaction = new ShimSqlTransaction()
            {
                Commit = () => { },
                Rollback = () => { }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void StashCSRoleMode_WhenCalled_SetsRoleAllowedField()
        {
            // Arrange
            const bool expected = true;

            privateObject.SetFieldOrProperty(RolesAllowedFieldName, nonPublicInstance, false);

            // Act
            privateObject.Invoke(StashCSRoleModeMethodName, publicInstance, new object[] { expected });
            var roleAllowed = (bool)privateObject.GetFieldOrProperty(RolesAllowedFieldName, nonPublicInstance);

            // Assert
            roleAllowed.ShouldBe(expected);
        }

        [TestMethod]
        public void IsCSRoleAllowed_WhenCalled_SetsRoleAllowedField()
        {
            // Arrange
            const bool expected = true;

            privateObject.SetFieldOrProperty(RolesAllowedFieldName, nonPublicInstance, expected);

            // Act
            privateObject.Invoke(IsCSRoleAllowedMethodName, publicInstance, new object[] { });
            var roleAllowed = (bool)privateObject.GetFieldOrProperty(RolesAllowedFieldName, nonPublicInstance);

            // Assert
            roleAllowed.ShouldBe(expected);
        }

        [TestMethod]
        public void SetMajorCatListlookup_WhenCalled_SetsCatLookupField()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                MajorCategoryFieldID = Two,
                Lookups = new Dictionary<int, clsLookupList>()
                {
                    [One] = new clsLookupList()
                    {
                        FieldID = One
                    },
                    [Two] = new clsLookupList()
                    {
                        FieldID = Two
                    }
                }
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            privateObject.Invoke(SetMajorCatListlookupMethodName, nonPublicInstance, new object[] { });
            var actual = (clsLookupList)privateObject.GetFieldOrProperty(CatLookupFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldNotBeNull(),
                () => actual.FieldID.ShouldBe(Two));
        }

        [TestMethod]
        public void ItemListAddItem_WhenCalled_AddsNewItem()
        {
            // Arrange
            var itemList = new List<clsEPKItem>();

            // Act
            privateObject.Invoke(
                ItemListAddItemMethodName,
                nonPublicInstance,
                new object[]
                {
                    itemList,
                    DummyInt,
                    DummyString,
                    DummyString
                });

            // Assert
            itemList.ShouldSatisfyAllConditions(
                () => itemList.Count.ShouldBe(1),
                () => itemList[Zero].ID.ShouldBe(DummyInt),
                () => itemList[Zero].Name.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GrabRAData_WhenCalled_SetsResourceValuesAndOtherFields()
        {
            // Arrange
            const string xmlString = @"<xmlcfg/>";
            var resourceValues = new clsResourceValues()
            {
                MajorCategoryFieldID = Two,
                gpPMOAdmin = DummyInt,
                CommitmentsOpMode = Zero,
                CommitmentHours = new List<clsCommitmentHours>(),
                Lookups = new Dictionary<int, clsLookupList>()
                {
                    [One] = new clsLookupList()
                    {
                        FieldID = One
                    },
                    [Two] = new clsLookupList()
                    {
                        FieldID = Two
                    }
                },
                Commitments = new Dictionary<int, clsCommitment>()
                {
                    [One] = new clsCommitment()
                    {
                        UID = One
                    }
                },
                OpenReqs = new Dictionary<int, clsCommitment>()
                {
                    [Two] = new clsCommitment()
                    {
                        UID = Two
                    }
                },
                OpenReqHours = new List<clsCommitmentHours>()
                {
                    new clsCommitmentHours()
                    {
                        UID = Three
                    }
                }
            };

            ShimRPAData.AllInstances.SetMajorCatListlookup = _ =>
            {
                validations += 1;
            };
            ShimRPAData.AllInstances.PopulateInternalsStringOut = (RPAData instance, out string serrlog) =>
            {
                validations += 1;
                serrlog = DummyString;
            };
            ShimRPAData.AllInstances.setupdispcolnsStringOut = (RPAData instance, out string errlog) =>
            {
                validations += 1;
                errlog = DummyString;
            };
            ShimRPAData.AllInstances.DoUserDepts = _ =>
            {
                validations += 1;
            };
            ShimRPAData.AllInstances.ReDrawGrid = _ =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(
                GrabRADataMethodName,
                nonPublicInstance,
                new object[]
                {
                    resourceValues,
                    DummyString,
                    DummyString,
                    DummyInt,
                    DummyInt,
                    xmlString,
                    DummyString
                });
            resourceValues = (clsResourceValues)privateObject.GetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance);

            // Assert
            resourceValues.ShouldSatisfyAllConditions(
                () => resourceValues.Commitments.Count.ShouldBe(2),
                () => resourceValues.Commitments[100003].Status.ShouldBe(RPConstants.CONST_OPENREQUEST),
                () => resourceValues.Commitments[100003].UID.ShouldBe(100003),
                () => resourceValues.CommitmentHours.Count.ShouldBe(1),
                () => resourceValues.CommitmentHours[Zero].UID.ShouldBe(100004));
        }

        [TestMethod]
        public void DoUserDepts_WhenCalled_AddsUserDepts()
        {
            // Arrange
            const string expected = "All Departments";
            var resourceValues = new clsResourceValues()
            {
                UserDepartments = new List<int>()
                {
                    One,
                    Two,
                    Three
                },
                Departments = new Dictionary<int, clsEPKItem>()
                {
                    [Three] = new clsEPKItem()
                    {
                        Name = Three.ToString()
                    },
                    [One] = new clsEPKItem()
                    {
                        Name = One.ToString()
                    }
                }
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            privateObject.Invoke(DoUserDeptsMethodName, nonPublicInstance, new object[] { });
            var userDepts = (List<clsEPKItem>)privateObject.GetFieldOrProperty(UserDeptsFieldName, nonPublicInstance);

            // Assert
            userDepts.ShouldSatisfyAllConditions(
                () => userDepts.Count.ShouldBe(3),
                () => userDepts.Any(x => x.ID.Equals(One) && x.Name.Equals(One.ToString())),
                () => userDepts.Any(x => x.ID.Equals(Three) && x.Name.Equals(Three.ToString())),
                () => userDepts.Any(x => x.ID.Equals(Zero) && x.Name.Equals(expected)));
        }

        [TestMethod]
        public void BuileCCR2RoleMap_WhenCalled_AddsCostCategoryRoleMapping()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                CostCategories = new Dictionary<int, clsCatItem>()
                {
                    [One] = new clsCatItem()
                    {
                        UID = One,
                        Name = One.ToString()
                    },
                    [Two] = new clsCatItem()
                    {
                        UID = Two,
                        Name = Two.ToString()
                    },
                    [Three] = new clsCatItem()
                    {
                        UID = Three,
                        Name = Three.ToString()
                    }
                },
                Roles = new Dictionary<int, clsListItem>()
                {
                    [One] = new clsListItem()
                    {
                        ID = One,
                        Name = One.ToString()
                    },
                    [Three] = new clsListItem()
                    {
                        ID = Three,
                        Name = Three.ToString()
                    }
                }
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            privateObject.Invoke(BuileCCR2RoleMapMethodName, nonPublicInstance, new object[] { });
            var mapping = (Dictionary<int, int>)privateObject.GetFieldOrProperty(CostCategoryRoleMappingFieldName, nonPublicInstance);

            // Assert
            mapping.ShouldSatisfyAllConditions(
                () => mapping.Count.ShouldBe(3),
                () => mapping[One].ShouldBe(One),
                () => mapping[Two].ShouldBe(Zero),
                () => mapping[Three].ShouldBe(Three));
        }

        [TestMethod]
        public void MapCCR2Role_KeyPresent_ReturnsProperInteger()
        {
            // Arrange
            const int category = One;
            var mapping = new Dictionary<int, int>()
            {
                [One] = DummyInt
            };

            privateObject.SetFieldOrProperty(CostCategoryRoleMappingFieldName, nonPublicInstance, mapping);

            // Act
            var actual = (int)privateObject.Invoke(MapCCR2RoleMethodName, nonPublicInstance, new object[] { category });

            // Assert
            actual.ShouldBe(DummyInt);
        }

        [TestMethod]
        public void MapCCR2Role_KeyNotPresent_ReturnsZero()
        {
            // Arrange
            const int category = Two;
            var mapping = new Dictionary<int, int>()
            {
                [One] = DummyInt
            };

            privateObject.SetFieldOrProperty(CostCategoryRoleMappingFieldName, nonPublicInstance, mapping);

            // Act
            var actual = (int)privateObject.Invoke(MapCCR2RoleMethodName, nonPublicInstance, new object[] { category });

            // Assert
            actual.ShouldBe(Zero);
        }

        [TestMethod]
        public void MapCCR2Role_MappingNull_ReturnsZero()
        {
            // Arrange
            const int category = Two;
            var mapping = default(Dictionary<int, int>);

            privateObject.SetFieldOrProperty(CostCategoryRoleMappingFieldName, nonPublicInstance, mapping);

            // Act
            var actual = (int)privateObject.Invoke(MapCCR2RoleMethodName, nonPublicInstance, new object[] { category });

            // Assert
            actual.ShouldBe(Zero);
        }

        [TestMethod]
        public void setupdispcolns_WhenCalled_SetsColumns()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                ResFields = new List<clsPortField>()
                {
                    new clsPortField()
                    {
                        ID = 1111,
                        GivenName = One.ToString(),
                        Name = One.ToString()
                    },
                    new clsPortField()
                    {
                        ID = 1112,
                        GivenName = string.Empty,
                        Name = Two.ToString()
                    }
                },
                PlanFields = new List<clsPortField>()
                {
                    new clsPortField()
                    {
                        ID = 1113,
                        GivenName = One.ToString(),
                        Name = One.ToString()
                    },
                    new clsPortField()
                    {
                        ID = 1114,
                        GivenName = string.Empty,
                        Name = Two.ToString()
                    }
                },
                PIFields = new List<clsPortField>()
                {
                    new clsPortField()
                    {
                        ID = 1115,
                        GivenName = One.ToString(),
                        Name = One.ToString()
                    },
                    new clsPortField()
                    {
                        ID = 1116,
                        GivenName = string.Empty,
                        Name = Two.ToString()
                    }
                }
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            privateObject.Invoke(setupdispcolnsMethodName, nonPublicInstance, new object[] { DummyString });
            var totalMasterColumns = (List<clsRXDisp>)privateObject.GetFieldOrProperty(TotalMasterColumnFieldName, nonPublicInstance);
            var totalDispColumns = (List<clsRXDisp>)privateObject.GetFieldOrProperty(TotalDisplayColumnFieldName, nonPublicInstance);
            var detMasterColumns = (Dictionary<int, clsRXDisp>)privateObject.GetFieldOrProperty(DetMasterColumnFieldName, nonPublicInstance);
            var detDispColumns = (List<clsRXDisp>)privateObject.GetFieldOrProperty(DetDisplayColumnFieldName, nonPublicInstance);

            // Assert
            totalMasterColumns.ShouldSatisfyAllConditions(
                () => totalMasterColumns.Count.ShouldBe(8),
                () => totalMasterColumns.Count(x => x.m_dispname.Equals(One.ToString()) || x.m_dispname.Equals(Two.ToString())).ShouldBe(2),
                () => totalDispColumns.Count.ShouldBe(8),
                () => totalDispColumns.Count(x => x.m_dispname.Equals(One.ToString()) || x.m_dispname.Equals(Two.ToString())).ShouldBe(2),
                () => detMasterColumns.Count.ShouldBe(32),
                () => detMasterColumns.Count(x => x.Value.m_dispname.Equals(One.ToString()) || x.Value.m_dispname.Equals(Two.ToString())).ShouldBe(6),
                () => detDispColumns.Count.ShouldBe(32),
                () => detDispColumns.Count(x => x.m_dispname.Equals(One.ToString()) || x.m_dispname.Equals(Two.ToString())).ShouldBe(6));
        }

        [TestMethod]
        public void ConvFTEs_WhenCalled_ReturnsDouble()
        {
            // Arrange
            const double parameter = 111d;
            const double expected = 1.1d;

            // Act
            var actual = (double)privateObject.Invoke(ConvFTEsMethodName, nonPublicInstance, new object[] { parameter });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ConvHRs_WhenCalled_ReturnsDouble()
        {
            // Arrange
            const double parameter = 19.117589d;
            const double expected = 19.12d;

            // Act
            var actual = (double)privateObject.Invoke(ConvHRsMethodName, nonPublicInstance, new object[] { parameter });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ExtractEmbeddedString_StripNumberZero_ReturnsEmptyString()
        {
            // Arrange
            const string paramter = "some random string with trailing space       ";

            ShimRPConstants.StripNumStringRef = (ref string input) =>
            {
                if (input.Equals(paramter))
                {
                    validations += 1;
                }
                return Zero;
            };

            // Act
            var actual = (string)privateObject.Invoke(ExtractEmbeddedStringMethodName, nonPublicInstance, new object[] { paramter });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(string.Empty),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void ExtractEmbeddedString_StripNumberNotZero_ReturnsSubString()
        {
            // Arrange
            const int length = 10;
            const string paramter = "some random string with trailing space       ";

            ShimRPConstants.StripNumStringRef = (ref string input) =>
            {
                if (input.Equals(paramter))
                {
                    validations += 1;
                }
                return length;
            };

            // Act
            var actual = (string)privateObject.Invoke(ExtractEmbeddedStringMethodName, nonPublicInstance, new object[] { paramter });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(paramter.Substring(Zero, length)),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetCostCatStrings_WhenCalled_Returns()
        {
            // Arrange
            var parameters = new object[]
            {
                Two,
                string.Empty,
                string.Empty
            };
            var resourceValues = new clsResourceValues()
            {
                CostCategories = new Dictionary<int, clsCatItem>()
                {
                    [One] = new clsCatItem()
                    {
                        UID = One,
                        Name = One.ToString(),
                        FullName = One.ToString()
                    },
                    [Two] = new clsCatItem()
                    {
                        UID = Two,
                        Name = Two.ToString(),
                        FullName = Two.ToString(),
                    },
                    [Three] = new clsCatItem()
                    {
                        UID = Three,
                        Name = Three.ToString(),
                        FullName = Three.ToString()
                    }
                }
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            privateObject.Invoke(
                GetCostCatStringsMethodName,
                nonPublicInstance,
                parameters
                );

            // Assert
            parameters.ShouldSatisfyAllConditions(
                () => parameters[One].ShouldBe(Two.ToString()),
                () => parameters[Two].ShouldBe(Two.ToString()));
        }

        [TestMethod]
        public void GetRoleName_ItemFound_ReturnsItemName()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                Roles = new Dictionary<int, clsListItem>()
                {
                    [One] = new clsListItem()
                    {
                        ID = One,
                        Name = One.ToString()
                    },
                    [Three] = new clsListItem()
                    {
                        ID = Three,
                        Name = Three.ToString()
                    }
                }
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            var actual = (string)privateObject.Invoke(
                GetRoleNameMethodName,
                nonPublicInstance,
                new object[]
                {
                    Three
                });

            // Assert
            actual.ShouldBe(Three.ToString());
        }

        [TestMethod]
        public void GetRoleName_ItemNotFound_ReturnsUnknownString()
        {
            // Arrange
            const string expected = "Unknown";
            var resourceValues = new clsResourceValues()
            {
                Roles = new Dictionary<int, clsListItem>()
                {
                    [One] = new clsListItem()
                    {
                        ID = One,
                        Name = One.ToString()
                    },
                    [Three] = new clsListItem()
                    {
                        ID = Three,
                        Name = Three.ToString()
                    }
                }
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            var actual = (string)privateObject.Invoke(
                GetRoleNameMethodName,
                nonPublicInstance,
                new object[]
                {
                    Two
                });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void ReDrawGrid_WhenCalled_AddsListItems()
        {
            // Arrange
            var resData = new Dictionary<int, clsResXData>()
            {
                [One] = new clsResXData(),
                [Two] = new clsResXData(),
                [Three] = new clsResXData(),
            };

            ShimRPAData.AllInstances.DoIShowReqTypeInt32 = (_, __) =>
            {
                validations += 1;
                return true;
            };
            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(ResDataFieldName, nonPublicInstance, resData);

            // Act
            privateObject.Invoke(ReDrawGridMethodName, nonPublicInstance, new object[] { });
            var actual = (List<clsResXData>)privateObject.GetFieldOrProperty(SortColumnFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(Three),
                () => validations.ShouldBe(Four));
        }

        [TestMethod]
        public void GetMajorCatStrings_WhenCalled_ReturnsCategoryName()
        {
            // Arrange
            var parameters = new object[]
            {
                One,
                DummyString,
                DummyString
            };

            var resourceValues = new clsResourceValues()
            {
                CostCategories = new Dictionary<int, clsCatItem>()
                {
                    [One] = new clsCatItem()
                    {
                        UID = One,
                        MajorCategory = One,
                        Category = One,
                        Name = One.ToString(),
                        FullName = One.ToString()
                    },
                    [Three] = new clsCatItem()
                    {
                        UID = Three,
                        MajorCategory = Three,
                        Category = Three,
                        Name = Three.ToString(),
                        FullName = Three.ToString()
                    }
                }
            };

            ShimRPAData.AllInstances.GetMajorCatInt32 = (_, __) => DummyString;

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            privateObject.Invoke(GetMajorCatStringsMethodName, nonPublicInstance, parameters);

            // Assert
            parameters.ShouldSatisfyAllConditions(
                () => parameters[1].ShouldBe(DummyString),
                () => parameters[2].ShouldBe(One.ToString()));
        }

        [TestMethod]
        public void NewRedrawTotals_UseRoleTrue_CreatesTotals()
        {
            // Arrange
            var grow = new RPATGRow()
            {
                fid = One,
                Name = DummyString
            };
            var growList = new List<RPATGRow>()
            {
                grow
            };
            var columnList = new List<clsRXDisp>()
            {
                new clsRXDisp()
                {
                    m_id = RPConstants.TGRID_TOTRESRES_ID
                }
            };
            var fullData = new clsResFullDAta();
            var roleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = fullData,
                [Two] = fullData,
                [Three] = fullData
            };

            privateObject.SetFieldOrProperty(UseHeatMapFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(TotGeneralFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(TotCapacityFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(UseHeatMapIDFieldName, nonPublicInstance, One);
            privateObject.SetFieldOrProperty(TotalDisplayColumnFieldName, nonPublicInstance, columnList);
            privateObject.SetFieldOrProperty(UseRoleFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CostCategoryRoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(RoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(ResListFieldName, nonPublicInstance, roleList);

            // Act
            privateObject.Invoke(NewRedrawTotalsMethodName, nonPublicInstance, new object[] { });
            var heatMapText = (string)privateObject.GetFieldOrProperty(HeatMapTextFieldName, nonPublicInstance);

            // Assert
            heatMapText.ShouldBe(DummyString);
        }

        [TestMethod]
        public void NewRedrawTotals_UseRoleFalse_CreatesTotals()
        {
            // Arrange
            var grow = new RPATGRow()
            {
                fid = One,
                Name = DummyString
            };
            var growList = new List<RPATGRow>()
            {
                grow
            };
            var columnList = new List<clsRXDisp>()
            {
                new clsRXDisp()
                {
                    m_id = RPConstants.TGRID_TOTRESRES_ID
                }
            };
            var fullData = new clsResFullDAta();
            var roleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = fullData,
                [Two] = fullData,
                [Three] = fullData
            };

            privateObject.SetFieldOrProperty(UseHeatMapFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(TotGeneralFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(TotCapacityFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(UseHeatMapIDFieldName, nonPublicInstance, One);
            privateObject.SetFieldOrProperty(TotalDisplayColumnFieldName, nonPublicInstance, columnList);
            privateObject.SetFieldOrProperty(UseRoleFieldName, nonPublicInstance, false);
            privateObject.SetFieldOrProperty(CostCategoryRoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(RoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(ResListFieldName, nonPublicInstance, roleList);

            // Act
            privateObject.Invoke(NewRedrawTotalsMethodName, nonPublicInstance, new object[] { });
            var heatMapText = (string)privateObject.GetFieldOrProperty(HeatMapTextFieldName, nonPublicInstance);

            // Assert
            heatMapText.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetMajorCat_CategoryZero_ReturnsEmptyString()
        {
            // Arrange
            const int category = Zero;

            // Act
            var actual = (string)privateObject.Invoke(GetMajorCatMethodName, nonPublicInstance, new object[] { category });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetMajorCat_CategoryNonZeroItemFound_ReturnsItemName()
        {
            // Arrange
            const int category = One;
            var lookup = new clsLookupList()
            {
                ListItems = new Dictionary<int, clsListItem>()
                {
                    [One] = new clsListItem()
                    {
                        Name = DummyString
                    }
                }
            };

            privateObject.SetFieldOrProperty(CatLookupFieldName, nonPublicInstance, lookup);

            // Act
            var actual = (string)privateObject.Invoke(GetMajorCatMethodName, nonPublicInstance, new object[] { category });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetMajorCat_CategoryNonZeroItemNotFound_ReturnsItemName()
        {
            // Arrange
            const int category = Three;
            var lookup = new clsLookupList()
            {
                ListItems = new Dictionary<int, clsListItem>()
                {
                    [One] = new clsListItem()
                    {
                        Name = DummyString
                    }
                }
            };

            privateObject.SetFieldOrProperty(CatLookupFieldName, nonPublicInstance, lookup);

            // Act
            var actual = (string)privateObject.Invoke(GetMajorCatMethodName, nonPublicInstance, new object[] { category });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetPeriodName_WhenCalled_AppendsPercentage()
        {
            // Arrange
            const int displayMode = 2;
            var expected = $"{DummyString}(%)";

            // Act
            var actual = (string)privateObject.Invoke(GetPeriodNameMethodName, nonPublicInstance, new object[] { DummyString, displayMode });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetTopGrid_WhenCalled_ReturnsTopGridXml()
        {
            // Arrange
            var xmlString = $@"
                <View ViewGUID=""{SampleGuidString1}"">
                    <View ViewGUID=""{SampleGuidString1}""></View>
                    <g_1 Cols=""{DummyString}""></g_1>
                </View>";
            var colsList = new List<clsRXDisp>()
            {
                new clsRXDisp()
                {
                    m_id = RPConstants.TGRID_SDATE,
                    m_type = Two,
                    m_col_hidden = true,
                    m_realname = DummyString,
                    m_dispname = DummyString
                }
            };
            var resourceValues = new clsResourceValues()
            {
                Periods = new Dictionary<int, CPeriod>()
                {
                    [One] = new CPeriod()
                    {
                        PeriodID = One
                    },
                    [Two] = new CPeriod()
                    {
                        PeriodID = Two
                    }
                }
            };
            var pisColumns = new Dictionary<int, clsPIData>()
            {
                [One] = new clsPIData()
            };
            var grow = new RPATGRow()
            {
                fid = Zero,
                Name = DummyString,
                bUse = true
            };
            var growList = new List<RPATGRow>()
            {
                grow
            };
            var resxData = new clsResXData()
            {
                WrkHours = new double[]
                {
                    One,
                    Two,
                    Three
                },
                FTEVals = new double[]
                {
                    One,
                    Two,
                    Three
                },
                ProjectName = DummyString,
                ProjectID = One
            };
            var sortColumns = new List<clsResXData>()
            {
                resxData
            };
            var fullData = new clsResFullDAta()
            {
                tot_Totals = resxData,
                tot_avail = resxData,
                PerPItotals = new Dictionary<int, clsResXData>()
                {
                    [One] = resxData
                }
            };
            var roleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = fullData,
                [Two] = fullData,
                [Three] = fullData
            };
            var actual = new XmlDocument();

            ShimResourceAnalyzer.ConstructorStringStringStringStringStringSecurityLevelsBoolean =
                (_, _1, _2, _3, _4, _5, _6, _7) => new ShimResourceAnalyzer();
            ShimWebAdmin.CapturePFEBaseInfoStringOutStringOutStringOutStringOutStringOutSecurityLevelsOut =
                (out string basepath, out string username, out string ppmId, out string ppmCompany, out string ppmDbConn, out SecurityLevels secLevel) =>
                {
                    basepath = DummyString;
                    username = DummyString;
                    ppmId = DummyString;
                    ppmCompany = DummyString;
                    ppmDbConn = DummyString;
                    secLevel = SecurityLevels.AdminCalc;
                };
            ShimResourceAnalyzer.AllInstances.GetResourceAnalyzerViewXMLGuidStringOut =
                (ResourceAnalyzer instance, Guid guidView, out string sReply) =>
                {
                    sReply = xmlString;
                    return true;
                };

            privateObject.SetFieldOrProperty(DetDisplayColumnFieldName, nonPublicInstance, colsList);
            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);
            privateObject.SetFieldOrProperty(DisplayModeFieldName, nonPublicInstance, Two);
            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);
            privateObject.SetFieldOrProperty(PisColumnFieldName, nonPublicInstance, pisColumns);
            privateObject.SetFieldOrProperty(TgStandardFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(CostCategoryRoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(RoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(ResListFieldName, nonPublicInstance, roleList);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetTopGridMethodName, publicInstance, new object[] { xmlString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//Toolbar").Attributes[VisibleString].Value.ShouldBe(Zero.ToString()),
                () => actual.FirstChild.SelectSingleNode($"//Cols/C[@Name='{DummyString}']").Attributes[ClassString].Value.ShouldBe("GMCellMain"));
        }

        [TestMethod]
        public void GetBottomGrid_WhenCalled_ReturnsBottomGridXml()
        {
            // Arrange
            var colsList = new List<clsRXDisp>()
            {
                new clsRXDisp()
                {
                    m_id = RPConstants.TGRID_TOTITEM_ID,
                    m_type = Three,
                    m_col_hidden = true,
                    m_realname = DummyString,
                    m_dispname = DummyString
                }
            };
            var resourceValues = new clsResourceValues()
            {
                Periods = new Dictionary<int, CPeriod>()
                {
                    [One] = new CPeriod()
                    {
                        PeriodID = One,
                        PeriodName = DummyString
                    },
                    [Two] = new CPeriod()
                    {
                        PeriodID = Two,
                        PeriodName = DummyString
                    }
                }
            };
            var resxData1 = new clsResXData()
            {
                WrkHours = new double[]
                {
                    Three,
                    One,
                    Two
                },
                FTEVals = new double[]
                {
                    Three,
                    One,
                    Two
                },
                ProjectName = DummyString,
                ProjectID = One,
                bTotalize = true,
                bFilteredOut = false,
            };
            var resxData2 = new clsResXData()
            {
                WrkHours = new double[]
                {
                    One,
                    Two,
                    Three
                },
                FTEVals = new double[]
                {
                    One,
                    Two,
                    Three
                },
                ProjectName = DummyString,
                ProjectID = One,
                bTotalize = true,
                bFilteredOut = false,
            };
            var fullData = new clsResFullDAta()
            {
                tot_Totals = resxData1,
                tot_avail = resxData2,
                PerPItotals = new Dictionary<int, clsResXData>()
                {
                    [One] = resxData1
                },
                used4totals = new List<clsResXData>()
                {
                    resxData1
                }
            };
            var roleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = fullData,
                [Two] = fullData,
                [Three] = fullData
            };
            var grow = new RPATGRow()
            {
                fid = -8,
                Name = DummyString,
                bUse = true
            };
            var growList = new List<RPATGRow>()
            {
                grow
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(UseRoleFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);
            privateObject.SetFieldOrProperty(TotalDisplayColumnFieldName, nonPublicInstance, colsList);
            privateObject.SetFieldOrProperty(CostCategoryRoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(RoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(ResListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(DisplayTotDetailsFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(TotSelectedOrderFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(UseHeatMapFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(DisplayModeFieldName, nonPublicInstance, Three);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetBottomGridMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//Toolbar").Attributes[VisibleString].Value.ShouldBe(Zero.ToString()),
                () => actual.FirstChild.SelectSingleNode($"//Cols/C[@Name='{DummyString}']").Attributes[ClassString].Value.ShouldBe("GMCellMain"),
                () => actual.FirstChild.SelectNodes("//RightCols/C").Count.ShouldBe(8));
        }

        [TestMethod]
        public void GetTotalsData_WhenCalled_ReturnsXmlString()
        {
            // Arrange
            var grow = new RPATGRow()
            {
                fid = -8,
                Name = DummyString,
                DisplayName = DummyString,
                bUse = true
            };
            var growList = new List<RPATGRow>()
            {
                grow
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(TotGeneralFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(TotCapacityFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(TotCapacityNonRoleFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(TotSelectedOrderFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(UseRoleFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(RoleModeFieldName, nonPublicInstance, Three);
            privateObject.SetFieldOrProperty(UseHeatMapIDFieldName, nonPublicInstance, Three);
            privateObject.SetFieldOrProperty(UseHeatMapColourFieldName, nonPublicInstance, Three);
            privateObject.SetFieldOrProperty(UseHeatMapFieldName, nonPublicInstance, true);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetTotalsDataMethodName, publicInstance, new object[] { true }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//TotalByRole").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//RoleMode").Attributes[ValueString].Value.ShouldBe(Three.ToString()),
                () => actual.FirstChild.SelectSingleNode("//EnableHeatMap").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//EnableHeatField").Attributes[ValueString].Value.ShouldBe(Three.ToString()),
                () => actual.FirstChild.SelectSingleNode("//HeatFieldColour").Attributes[ValueString].Value.ShouldBe(Three.ToString()),
                () => actual.FirstChild.SelectSingleNode("//ColumnOptions").ChildNodes.Count.ShouldBe(Two),
                () => actual.FirstChild.SelectSingleNode("//ColumnNROptions").ChildNodes.Count.ShouldBe(Two),
                () => actual.FirstChild.SelectSingleNode("//SelectedOrderItems").ChildNodes.Count.ShouldBe(One));
        }

        [TestMethod]
        public void SetTotalsData_WhenCalled_ReturnsXmlString()
        {
            // Arrange
            const string dataXmlString = @"
                <TotalsConfiguration>
                    <TotalByRole Value=""1"" />
                    <RoleMode Value=""3"" />
                    <EnableHeatMap Value=""1"" />
                    <EnableHeatField Value=""-8"" />
                    <HeatFieldColour Value=""3"" />
                    <ColumnOptions>
                        <ColumnOption ColumnID=""-8"" Selected=""1"" Name=""DummyString"" />
                        <ColumnOption ColumnID=""-8"" Selected=""1"" Name=""DummyString"" />
                    </ColumnOptions>
                    <ColumnNROptions>
                        <ColumnOption ColumnID=""-8"" Selected=""1"" Name=""DummyString"" />
                        <ColumnOption ColumnID=""-8"" Selected=""1"" Name=""DummyString"" />
                    </ColumnNROptions>
                    <SelectedOrderItems>
                        <Item ItemID=""-8"" />
                    </SelectedOrderItems>
                </TotalsConfiguration>";
            var grow = new RPATGRow()
            {
                fid = -8,
                Name = DummyString,
                DisplayName = DummyString,
                bUse = true
            };
            var growList = new List<RPATGRow>()
            {
                grow
            };
            var xmlRoot = new CStruct();
            var actual = new XmlDocument();

            xmlRoot.LoadXML(dataXmlString);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(TotGeneralFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(TotCapacityFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(HeatMapTextFieldName, nonPublicInstance, DummyString);

            // Act
            actual.LoadXml((string)privateObject.Invoke(SetTotalsDataMethodName, publicInstance, new object[] { xmlRoot }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//HeatMap").Attributes["HeapMapTotalsCol"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//HeatMap").Attributes["HeatMapText"].Value.ShouldBe(DummyString),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetDetailsData_WhenCalled_ReturnsDetailsDataXmlString()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                CommitmentsOpMode = Two,
                lRequestNo = Two,
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(CheckActualFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckOpenRequireFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckMspfFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckCommitFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckNonWorkFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckOpenRequestFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(HadOpenReqsFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetDetailsDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//ActualWork").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//ProposedWork").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//ScheduledWork").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CommittedWork").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//PersonalWork").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//OpenRequestWork").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//NegMode").Attributes[ValueString].Value.ShouldBe(Two.ToString()),
                () => actual.FirstChild.SelectSingleNode("//ShowPersonal").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//ShowOpenReq").Attributes[ValueString].Value.ShouldBe(One.ToString()));
        }

        [TestMethod]
        public void SetDetailsData_WhenCalled_SetsDetailsData()
        {
            // Arrange
            const string dataXmlString = @"
                <WorkDetails>
                    <ActualWork Value=""1"" />
                    <ProposedWork Value=""1"" />
                    <ScheduledWork Value=""1"" />
                    <CommittedWork Value=""1"" />
                    <PersonalWork Value=""1"" />
                    <OpenRequestWork Value=""1"" />
                    <NegMode Value=""2"" />
                    <ShowPersonal Value=""1"" />
                    <ShowOpenReq Value=""1"" />
                </WorkDetails>";
            var xmlRoot = new CStruct();

            xmlRoot.LoadXML(dataXmlString);

            ShimRPAData.AllInstances.ReDrawGrid = _ =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(SetDetailsDataMethodName, publicInstance, new object[] { xmlRoot });
            var actual = (bool)privateObject.GetFieldOrProperty(CheckActualFieldName, nonPublicInstance);
            actual = actual && (bool)privateObject.GetFieldOrProperty(CheckOpenRequireFieldName, nonPublicInstance);
            actual = actual && (bool)privateObject.GetFieldOrProperty(CheckMspfFieldName, nonPublicInstance);
            actual = actual && (bool)privateObject.GetFieldOrProperty(CheckCommitFieldName, nonPublicInstance);
            actual = actual && (bool)privateObject.GetFieldOrProperty(CheckNonWorkFieldName, nonPublicInstance);
            actual = actual && (bool)privateObject.GetFieldOrProperty(CheckOpenRequestFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void SetDisplayMode_ModeAttributeNotZero_SetsDisplayModeNotZero()
        {
            // Arrange
            var dataXmlString = $@"<WorkDetails Mode=""{Three}""/>";
            var xmlRoot = new CStruct();

            xmlRoot.LoadXML(dataXmlString);

            ShimRPAData.AllInstances.ReDrawGrid = _ =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(SetDisplayModeMethodName, publicInstance, new object[] { xmlRoot });
            var actual = (int)privateObject.GetFieldOrProperty(DisplayModeFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Two),
                () => validations.ShouldBe(One));
        }

        [TestMethod]
        public void SetDisplayMode_ModeAttributeZero_SetsDisplayModeZero()
        {
            // Arrange
            var dataXmlString = $@"<WorkDetails Mode=""{Zero}""/>";
            var xmlRoot = new CStruct();

            xmlRoot.LoadXML(dataXmlString);

            ShimRPAData.AllInstances.ReDrawGrid = _ =>
            {
                validations += 1;
            };

            // Act
            privateObject.Invoke(SetDisplayModeMethodName, publicInstance, new object[] { xmlRoot });
            var actual = (int)privateObject.GetFieldOrProperty(DisplayModeFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(Zero),
                () => validations.ShouldBe(One));
        }

        [TestMethod]
        public void GetDisplayMode_WhenCalled_GetsDisplayMode()
        {
            // Arrange
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(DisplayModeFieldName, nonPublicInstance, One);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetDisplayModeMethodName, publicInstance, new object[] { }));

            // Assert
            actual.FirstChild.Attributes["Mode"].Value.ShouldBe(Two.ToString());
        }

        [TestMethod]
        public void SetSelectedForRows_WhenCalled_SetsSortColumns()
        {
            // Arrange
            const string xmlString = @"
                <Rows value=""1"">
                    <Row/>
                    <Row rowid=""R1""/>
                </Rows>";
            var resxData = new clsResXData()
            {
                bTotalize = false
            };
            var sortColumns = new List<clsResXData>()
            {
                resxData,
                resxData
            };
            var xmlRoot = new CStruct();

            xmlRoot.LoadXML(xmlString);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);

            // Act
            privateObject.Invoke(SetSelectedForRowsMethodName, publicInstance, new object[] { xmlRoot });
            var actual = (List<clsResXData>)privateObject.GetFieldOrProperty(SortColumnFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[Zero].bTotalize.ShouldBeTrue(),
                () => actual[1].bTotalize.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void SetSelectedForTotals_WhenCalled_SetsSortColumns()
        {
            // Arrange
            const string xmlString = @"
                <Rows value=""1"">
                    <Row/>
                    <Row rowid=""1""/>
                    <Row rowid=""2""/>
                </Rows>";
            var resFullData = new clsResFullDAta()
            {
                bSelected = false
            };
            var bottomColumns = new Dictionary<int, clsResFullDAta>()
            {
                [One] = resFullData,
                [Two] = resFullData
            };
            var xmlRoot = new CStruct();

            xmlRoot.LoadXML(xmlString);

            privateObject.SetFieldOrProperty(UsedBottomColumn, nonPublicInstance, bottomColumns);

            // Act
            privateObject.Invoke(SetSelectedForTotalsMethodName, publicInstance, new object[] { xmlRoot });
            var actual = (Dictionary<int, clsResFullDAta>)privateObject.GetFieldOrProperty(UsedBottomColumn, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[One].bSelected.ShouldBeTrue(),
                () => actual[Two].bSelected.ShouldBeTrue());
        }

        [TestMethod]
        public void SetRADragRows_FromGreaterThanToMode0_SetsDragRows()
        {
            // Arrange
            const string xmlString = @"
                <Rows fromCol=""1"" toCol=""2"">
                    <Row/>
                    <Row rowid=""R1""/>
                </Rows>";
            var data = new CStruct();
            var doubleArray = new double[]
            {
                One,
                Zero,
                Zero
            };
            var resxData = new clsResXData()
            {
                bTotalize = false,
                CostCat = One
            };
            resxData.SetUpPeriods(Two);
            resxData.WrkHours = doubleArray;
            resxData.FTEVals = doubleArray;
            var sortColumns = new List<clsResXData>()
            {
                resxData,
                resxData
            };
            var fteConv = new Dictionary<int, clsRPAFTEConv>()
            {
                [One] = new clsRPAFTEConv()
                {
                    FTEConv = new int[]
                    {
                        One,
                        Zero,
                        Zero
                    }
                }
            };
            var dragStack = new Stack<clsResXDragCloneList>();

            data.LoadXML(xmlString);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);
            privateObject.SetFieldOrProperty(FteConvFieldName, nonPublicInstance, fteConv);
            privateObject.SetFieldOrProperty(DragStackFieldName, nonPublicInstance, dragStack);
            privateObject.SetFieldOrProperty(DisplayModeFieldName, nonPublicInstance, Zero);

            // Act
            privateObject.Invoke(SetRADragRowsMethodName, publicInstance, new object[] { data });
            var actual = (Stack<clsResXDragCloneList>)privateObject.GetFieldOrProperty(DragStackFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual.ElementAt(Zero).m_cloneList.Count.ShouldBe(2),
                () => actual.ElementAt(Zero).m_cloneList[Zero].WrkHours.Length.ShouldBe(3),
                () => actual.ElementAt(Zero).m_cloneList[Zero].FTEVals.Length.ShouldBe(3),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void SetRADragRows_FromGreaterThanToModeNot0_SetsDragRows()
        {
            // Arrange
            const string xmlString = @"
                <Rows fromCol=""1"" toCol=""2"">
                    <Row/>
                    <Row rowid=""R1""/>
                </Rows>";
            var data = new CStruct();
            var doubleArray = new double[]
            {
                One,
                Zero,
                Zero
            };
            var resxData = new clsResXData()
            {
                bTotalize = false,
                CostCat = One
            };
            resxData.SetUpPeriods(Two);
            resxData.WrkHours = doubleArray;
            resxData.FTEVals = doubleArray;
            var sortColumns = new List<clsResXData>()
            {
                resxData,
                resxData
            };
            var fteConv = new Dictionary<int, clsRPAFTEConv>()
            {
                [One] = new clsRPAFTEConv()
                {
                    FTEConv = new int[]
                    {
                        One,
                        Zero,
                        Zero
                    }
                }
            };
            var dragStack = new Stack<clsResXDragCloneList>();

            data.LoadXML(xmlString);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);
            privateObject.SetFieldOrProperty(FteConvFieldName, nonPublicInstance, fteConv);
            privateObject.SetFieldOrProperty(DragStackFieldName, nonPublicInstance, dragStack);
            privateObject.SetFieldOrProperty(DisplayModeFieldName, nonPublicInstance, One);

            // Act
            privateObject.Invoke(SetRADragRowsMethodName, publicInstance, new object[] { data });
            var actual = (Stack<clsResXDragCloneList>)privateObject.GetFieldOrProperty(DragStackFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual.ElementAt(Zero).m_cloneList.Count.ShouldBe(2),
                () => actual.ElementAt(Zero).m_cloneList[Zero].WrkHours.Length.ShouldBe(3),
                () => actual.ElementAt(Zero).m_cloneList[Zero].FTEVals.Length.ShouldBe(3),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void SetRADragRows_FromLessThanToMode0_SetsDragRows()
        {
            // Arrange
            const string xmlString = @"
                <Rows fromCol=""2"" toCol=""1"">
                    <Row/>
                    <Row rowid=""R1""/>
                </Rows>";
            var data = new CStruct();
            var doubleArray = new double[]
            {
                One,
                Zero,
                Zero
            };
            var resxData = new clsResXData()
            {
                bTotalize = false,
                CostCat = One
            };
            resxData.SetUpPeriods(Two);
            resxData.WrkHours = doubleArray;
            resxData.FTEVals = doubleArray;
            var sortColumns = new List<clsResXData>()
            {
                resxData,
                resxData
            };
            var fteConv = new Dictionary<int, clsRPAFTEConv>()
            {
                [One] = new clsRPAFTEConv()
                {
                    FTEConv = new int[]
                    {
                        One,
                        Zero,
                        Zero
                    }
                }
            };
            var dragStack = new Stack<clsResXDragCloneList>();

            data.LoadXML(xmlString);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);
            privateObject.SetFieldOrProperty(FteConvFieldName, nonPublicInstance, fteConv);
            privateObject.SetFieldOrProperty(DragStackFieldName, nonPublicInstance, dragStack);
            privateObject.SetFieldOrProperty(DisplayModeFieldName, nonPublicInstance, Zero);

            // Act
            privateObject.Invoke(SetRADragRowsMethodName, publicInstance, new object[] { data });
            var actual = (Stack<clsResXDragCloneList>)privateObject.GetFieldOrProperty(DragStackFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual.ElementAt(Zero).m_cloneList.Count.ShouldBe(2),
                () => actual.ElementAt(Zero).m_cloneList[Zero].WrkHours.Length.ShouldBe(3),
                () => actual.ElementAt(Zero).m_cloneList[Zero].FTEVals.Length.ShouldBe(3),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void SetRADragRows_FromLessThanToModeNot0_SetsDragRows()
        {
            // Arrange
            const string xmlString = @"
                <Rows fromCol=""2"" toCol=""1"">
                    <Row/>
                    <Row rowid=""R1""/>
                </Rows>";
            var data = new CStruct();
            var doubleArray = new double[]
            {
                One,
                Zero,
                Zero
            };
            var resxData = new clsResXData()
            {
                bTotalize = false,
                CostCat = One
            };
            resxData.SetUpPeriods(Two);
            resxData.WrkHours = doubleArray;
            resxData.FTEVals = doubleArray;
            var sortColumns = new List<clsResXData>()
            {
                resxData,
                resxData
            };
            var fteConv = new Dictionary<int, clsRPAFTEConv>()
            {
                [One] = new clsRPAFTEConv()
                {
                    FTEConv = new int[]
                    {
                        One,
                        Zero,
                        Zero
                    }
                }
            };
            var dragStack = new Stack<clsResXDragCloneList>();

            data.LoadXML(xmlString);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);
            privateObject.SetFieldOrProperty(FteConvFieldName, nonPublicInstance, fteConv);
            privateObject.SetFieldOrProperty(DragStackFieldName, nonPublicInstance, dragStack);
            privateObject.SetFieldOrProperty(DisplayModeFieldName, nonPublicInstance, One);

            // Act
            privateObject.Invoke(SetRADragRowsMethodName, publicInstance, new object[] { data });
            var actual = (Stack<clsResXDragCloneList>)privateObject.GetFieldOrProperty(DragStackFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(1),
                () => actual.ElementAt(Zero).m_cloneList.Count.ShouldBe(2),
                () => actual.ElementAt(Zero).m_cloneList[Zero].WrkHours.Length.ShouldBe(3),
                () => actual.ElementAt(Zero).m_cloneList[Zero].FTEVals.Length.ShouldBe(3),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void UndoRADragRows_WhenCalled_UndoDragRows()
        {
            // Arrange
            var dragStack = new Stack<clsResXDragCloneList>();
            var doubleArray = new double[]
            {
                One,
                Zero,
                Zero
            };
            var resxData = new clsResXData()
            {
                iDragCnt = 1
            };
            resxData.SetUpPeriods(Two);
            resxData.WrkHours = doubleArray;
            resxData.FTEVals = doubleArray;
            var clonedlist = new clsResXDragCloneList()
            {
                m_cloneList = new List<clsResXDragClone>()
                {
                    new clsResXDragClone()
                    {
                        m_oDet = resxData,
                        WrkHours = doubleArray,
                        FTEVals = doubleArray
                    }
                }
            };
            dragStack.Push(clonedlist);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(DragStackFieldName, nonPublicInstance, dragStack);

            // Act
            privateObject.Invoke(UndoRADragRowsMethodName, publicInstance, new object[] { });
            var actual = (Stack<clsResXDragCloneList>)privateObject.GetFieldOrProperty(DragStackFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Count.ShouldBe(Zero),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void SetFilteredForRows_WhenCalled_SetsSortColumns()
        {
            // Arrange
            const string xmlString = @"
                <Rows value=""1"">
                    <Row/>
                    <Row rowid=""R1""/>
                </Rows>";
            var resxData = new clsResXData();
            var sortColumns = new List<clsResXData>()
            {
                resxData,
                resxData
            };
            var xmlRoot = new CStruct();

            xmlRoot.LoadXML(xmlString);

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);

            // Act
            privateObject.Invoke(SetFilteredForRowsMethodName, publicInstance, new object[] { xmlRoot });
            var actual = (List<clsResXData>)privateObject.GetFieldOrProperty(SortColumnFieldName, nonPublicInstance);

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual[Zero].bFilteredOut.ShouldBeTrue(),
                () => actual[1].bFilteredOut.ShouldBeTrue(),
                () => validations.ShouldBe(1));
        }

        [TestMethod]
        public void GetTargetRGBData_WhenCalled_ReturnsRGBDataXmlString()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                TargetColors = new Dictionary<int, clsViewTargetColours>()
                {
                    [One] = new clsViewTargetColours()
                    {
                        ID = One,
                        rgb_val = One,
                        low_val = One,
                        high_val = One
                    },
                    [Two] = new clsViewTargetColours()
                    {
                        ID = Two,
                        rgb_val = Two,
                        low_val = Two,
                        high_val = Two
                    }
                }
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetTargetRGBDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//MaxTargetID").Attributes[ValueString].Value.ShouldBe(Two.ToString()),
                () => actual.FirstChild.SelectNodes("//Target").Count.ShouldBe(2),
                () => actual.FirstChild.SelectSingleNode("//Target[@ID='1']").Attributes["RGB"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Target[@ID='2']").Attributes["RGB"].Value.ShouldBe(Two.ToString()));
        }

        [TestMethod]
        public void CreateNewResFullDAta_WhenCalled_ReturnsResFullData()
        {
            // Arrange
            privateObject.SetFieldOrProperty(NumPerFieldName, nonPublicInstance, Three);

            // Act
            var actual = (clsResFullDAta)privateObject.Invoke(CreateNewResFullDAtaMethodName, nonPublicInstance, new object[] { });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.tot_Totals.WrkHours.Length.ShouldBe(Four),
                () => actual.tot_Totals.FTEVals.Length.ShouldBe(Four),
                () => actual.tot_proposal.WrkHours.Length.ShouldBe(Four),
                () => actual.tot_proposal.FTEVals.Length.ShouldBe(Four),
                () => actual.tot_committed.WrkHours.Length.ShouldBe(Four),
                () => actual.tot_committed.FTEVals.Length.ShouldBe(Four));
        }

        [TestMethod]
        public void ApplyServerSideViewSettings_WhenCalled_Returns()
        {
            // Arrange
            const string returnXml = @"<xmlcfg Value=""1""/>";
            const string displayModeXml = @"<DisplayMode Value=""2""/>";
            const string detailsDataXml = @"<DetailsData Value=""3""/>";
            var viewsXml = $@"
                <Views>
                    <View ViewGUID=""{SampleGuidString1}"">
                        <OtherData>
                            <TotalsConfiguration/>
                            <WorkDetails/>
                            <WorkDisplayMode/>
                        </OtherData>
                        <ViewSettings ShowBotDet=""1""/>
                    </View>
                </Views>";
            var actual = new XmlDocument();

            ShimRPAData.AllInstances.SetTotalsDataCStruct = (_, __) =>
            {
                validations += 1;
                return returnXml;
            };
            ShimRPAData.AllInstances.SetDetailsDataCStruct = (_, __) =>
            {
                validations += 1;
            };
            ShimRPAData.AllInstances.SetDisplayModeCStruct = (_, __) =>
            {
                validations += 1;
            };
            ShimRPAData.AllInstances.GetDisplayMode = _ =>
            {
                validations += 1;
                return displayModeXml;
            };
            ShimRPAData.AllInstances.GetDetailsData = _ =>
            {
                validations += 1;
                return detailsDataXml;
            };

            privateObject.SetFieldOrProperty(ViewsXmlFieldName, nonPublicInstance, viewsXml);

            // Act
            actual.LoadXml((string)privateObject.Invoke(ApplyServerSideViewSettingsMethodName, publicInstance, new object[] { SampleGuidString1 }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//BottomDetailsState").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//xmlcfg").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//DisplayMode").Attributes[ValueString].Value.ShouldBe(Two.ToString()),
                () => actual.FirstChild.SelectSingleNode("//DetailsData").Attributes[ValueString].Value.ShouldBe(Three.ToString()),
                () => validations.ShouldBe(5));
        }

        [TestMethod]
        public void RemoveCapacityScenario_WhenCalled_Returns()
        {
            // Arrange
            var grow = new RPATGRow()
            {
                fid = One,
                Name = DummyString
            };
            var growList = new List<RPATGRow>()
            {
                new RPATGRow()
                {
                    fid = One
                },
                new RPATGRow()
                {
                    fid = Two
                }
            };
            var resourceValues = new clsResourceValues()
            {
                CapacityTargets = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        ID = One
                    },
                    [Two] = new clsEPKItem()
                    {
                        ID = Two
                    }
                },
                CapacityTargetValues = new List<clsCapacityValue>()
                {
                    new clsCapacityValue()
                    {
                        ID = One
                    },
                    new clsCapacityValue()
                    {
                        ID = Two
                    }
                }
            };

            ShimRPAData.AllInstances.PopulateInternalsStringOut = (RPAData instance, out string serrlog) =>
            {
                validations += 1;
                serrlog = DummyString;
            };
            ShimRPAData.AllInstances.ReDrawGrid = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);
            privateObject.SetFieldOrProperty(TotCapacityFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(TotSelectedOrderFieldName, nonPublicInstance, growList);
            privateObject.SetFieldOrProperty(UseHeatMapIDFieldName, nonPublicInstance, One);

            // Act
            privateObject.Invoke(RemoveCapacityScenarioMethodName, publicInstance, new object[] { One });
            var useHeatMapId = (int)privateObject.GetFieldOrProperty(UseHeatMapIDFieldName, nonPublicInstance);
            var totCapacity = (List<RPATGRow>)privateObject.GetFieldOrProperty(TotCapacityFieldName, nonPublicInstance);
            var totSelected = (List<RPATGRow>)privateObject.GetFieldOrProperty(TotSelectedOrderFieldName, nonPublicInstance);
            resourceValues = (clsResourceValues)privateObject.GetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance);

            // Assert
            useHeatMapId.ShouldSatisfyAllConditions(
                () => useHeatMapId.ShouldBe(Zero),
                () => totCapacity.Count.ShouldBe(One),
                () => totCapacity[Zero].fid.ShouldBe(Two),
                () => totSelected.Count.ShouldBe(One),
                () => totSelected[Zero].fid.ShouldBe(Two),
                () => resourceValues.CapacityTargets.Count.ShouldBe(One),
                () => resourceValues.CapacityTargets[Two].ID.ShouldBe(Two),
                () => resourceValues.CapacityTargetValues.Count.ShouldBe(One),
                () => resourceValues.CapacityTargetValues[Zero].ID.ShouldBe(Two),
                () => validations.ShouldBe(Two));
        }

        [TestMethod]
        public void PrepareCSGrid_CsModeNotZero_ReturnsCsDataXmlString()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Calendar CalID=""1"">
                        <Periods>
                            <Period ID=""1"" Name=""PeriodName""></Period>
                        </Periods>
                    </Calendar>
                    <CostCategoryRoles>
                        <CostCategoryRole RoleUID=""1"">
                            <Periods>DummyString</Periods>
                            <FTEToHours>DummyString</FTEToHours>
                        </CostCategoryRole>
                    </CostCategoryRoles>
                    <CS_Values>
                        <CS_Value Role_ID=""1"" Per_ID=""1"" Hours=""1"" FTEs=""1""/>
                    </CS_Values>
                </xmlcfg>";
            var roles = new Dictionary<int, clsEPKItem>()
            {
                [One] = new clsEPKItem()
                {
                    Name = DummyString
                }
            };
            var doubleArray = new double[]
            {
                One,
                Two,
                Three
            };
            var ccRoleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = new clsResFullDAta()
                {
                    tot_Totals = new clsResXData()
                    {
                        WrkHours = doubleArray,
                        FTEVals = doubleArray
                    }
                }
            };
            var actual = new XmlDocument();

            ShimRPConstants.StripNumStringRef = (ref string number) =>
            {
                validations += 1;
                number = string.Empty;
                return One;
            };

            privateObject.SetFieldOrProperty("m_roles", nonPublicInstance, roles);
            privateObject.SetFieldOrProperty("m_useingCal", nonPublicInstance, One);
            privateObject.SetFieldOrProperty("m_ccrolelist", nonPublicInstance, ccRoleList);
            privateObject.SetFieldOrProperty("m_rolelist", nonPublicInstance, ccRoleList);

            // Act
            actual.LoadXml((string)privateObject.Invoke(PrepareCSGridMethodName, publicInstance, new object[] { xmlString, One }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CostCategories/CostCategory").Attributes["Name"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//CostCategories/CostCategory/FTEs").Attributes[ValueString].Value.ShouldBe("0.01"),
                () => actual.FirstChild.SelectSingleNode("//CapScenRows/CapScenRow/FTEs").Attributes[ValueString].Value.ShouldBe("0.0001"),
                () => actual.FirstChild.SelectSingleNode("//CapScenRows/CapScenRow/Hours").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => validations.ShouldBe(Two));
        }

        [TestMethod]
        public void PrepareCSGrid_CsModeZero_ReturnsCsDataXmlString()
        {
            // Arrange
            const string xmlString = @"
                <xmlcfg>
                    <Calendar CalID=""1"">
                        <Periods>
                            <Period ID=""1"" Name=""PeriodName""></Period>
                        </Periods>
                    </Calendar>
                    <CostCategoryRoles>
                        <CostCategoryRole RoleUID=""1"" ID=""1"" Name=""DummyString"" Level=""1"">
                            <Periods>DummyString</Periods>
                            <FTEToHours>DummyString</FTEToHours>
                        </CostCategoryRole>
                    </CostCategoryRoles>
                    <CS_Values>
                        <CS_Value Role_ID=""1"" Per_ID=""1"" Hours=""1"" FTEs=""1""/>
                    </CS_Values>
                </xmlcfg>";
            var roles = new Dictionary<int, clsEPKItem>()
            {
                [One] = new clsEPKItem()
                {
                    Name = DummyString
                }
            };
            var doubleArray = new double[]
            {
                One,
                Two,
                Three
            };
            var ccRoleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = new clsResFullDAta()
                {
                    tot_Totals = new clsResXData()
                    {
                        WrkHours = doubleArray,
                        FTEVals = doubleArray
                    }
                }
            };
            var actual = new XmlDocument();

            ShimRPConstants.StripNumStringRef = (ref string number) =>
            {
                validations += 1;
                number = string.Empty;
                return One;
            };

            privateObject.SetFieldOrProperty("m_roles", nonPublicInstance, roles);
            privateObject.SetFieldOrProperty("m_useingCal", nonPublicInstance, One);
            privateObject.SetFieldOrProperty("m_ccrolelist", nonPublicInstance, ccRoleList);
            privateObject.SetFieldOrProperty("m_rolelist", nonPublicInstance, ccRoleList);

            // Act
            actual.LoadXml((string)privateObject.Invoke(PrepareCSGridMethodName, publicInstance, new object[] { xmlString, Zero }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//Periods/Period").Attributes["ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CostCategories/CostCategory").Attributes["Name"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//CostCategories/CostCategory/FTEs").Attributes[ValueString].Value.ShouldBe("0.01"),
                () => actual.FirstChild.SelectSingleNode("//CapScenRows/CapScenRow/FTEs").Attributes[ValueString].Value.ShouldBe("0.0001"),
                () => actual.FirstChild.SelectSingleNode("//CapScenRows/CapScenRow/Hours").Attributes[ValueString].Value.ShouldBe(One.ToString()),
                () => validations.ShouldBe(Two));
        }

        [TestMethod]
        public void GetCapacityScenarioGrid_WhenCalled_ReturnsScenarioGridXmlString()
        {
            // Arrange
            var periods = new List<CPeriod>()
            {
                new CPeriod()
                {
                    PeriodID = One,
                    PeriodName = DummyString
                }
            };
            var doubleArray = new double[]
            {
                One,
                Two,
                Three
            };
            var editData = new Dictionary<int, clsResxAvail>()
            {
                [One] = new clsResxAvail()
                {
                    DeptID = Two,
                    Name = DummyString,
                    AvailFTEs = doubleArray,
                    AvailHours = doubleArray
                }
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty("m_cs_perlist", nonPublicInstance, periods);
            privateObject.SetFieldOrProperty("m_cs_editdata", nonPublicInstance, editData);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetCapacityScenarioGridMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//Header").Attributes["P1V"].Value.ShouldBe(DummyString),
                () => actual.FirstChild.SelectSingleNode("//Body/I/I").Attributes["CostCategory"].Value.Trim().ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetLegendGrid_WhenCalled_Returns()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                TargetColors = new Dictionary<int, clsViewTargetColours>()
                {
                    [One] = new clsViewTargetColours()
                    {
                        rgb_val = One
                    },
                    [Two] = new clsViewTargetColours()
                    {
                        rgb_val = -1
                    }
                }
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetLegendGridMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//Toolbar").Attributes[VisibleString].Value.ShouldBe(Zero.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Header").Attributes[VisibleString].Value.ShouldBe(Zero.ToString()),
                () => actual.FirstChild.SelectSingleNode("//Panel").Attributes[VisibleString].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectNodes("//Body/I/I").Count.ShouldBe(Two));
        }

        [TestMethod]
        public void RPASaveDraggedData_WhenCalled_Returns()
        {
            // Arrange
            var resxData = new clsResXData()
            {
                WrkHours = new double[]
                {
                    One,
                    Two,
                    Three
                },
                FTEVals = new double[]
                {
                    One,
                    Two,
                    Three
                },
                ProjectName = DummyString,
                ProjectID = One,
                bDragged = true,
                UID = One
            };
            var sortColumns = new List<clsResXData>()
            {
                resxData
            };
            var resourceValues = new clsResourceValues()
            {
                Periods = new Dictionary<int, CPeriod>()
                {
                    [One] = new CPeriod()
                }
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);
            privateObject.SetFieldOrProperty("m_StartPerOffset", nonPublicInstance, One);
            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            actual.LoadXml((string)privateObject.Invoke(RPASaveDraggedDataMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//CMT").Attributes["CMT_UID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CMT/Period").Attributes["PeriodID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CMT/Period").Attributes["Hours"].Value.ShouldBe("200"),
                () => actual.FirstChild.SelectSingleNode("//CMT/Period").Attributes["FTES"].Value.ShouldBe("20000"));
        }

        [TestMethod]
        public void GetStartFinishDataPeriods_WhenCalled_ReturnsStartandFinishPeriod()
        {
            // Arrange
            var parameters = new object[]
            {
                One,
                Two
            };

            privateObject.SetFieldOrProperty("m_firstperiod_data", nonPublicInstance, Zero);
            privateObject.SetFieldOrProperty("m_lastperiod_data", nonPublicInstance, Zero);
            privateObject.SetFieldOrProperty("m_num_per", nonPublicInstance, Zero);

            // Act
            privateObject.Invoke(GetStartFinishDataPeriodsMethodName, publicInstance, parameters);

            // Assert
            parameters.ShouldSatisfyAllConditions(
                () => parameters[Zero].ShouldBe(Zero),
                () => parameters[One].ShouldBe(One));
        }

        [TestMethod]
        public void ReplaceCSData_WhenCalled_ReplacesDataLevels()
        {
            // Arrange
            var resourceValues = new clsResourceValues()
            {
                CapacityTargets = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        level = One
                    }
                },
                CapacityTargetValues = new List<clsCapacityValue>()
                {
                    new clsCapacityValue()
                }
            };

            ShimRPAData.AllInstances.PopulateInternalsStringOut = (RPAData instance, out string message) =>
            {
                validations += 1;
                message = DummyString;
            };
            ShimRPAData.AllInstances.ReDrawGrid = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, new clsResourceValues());

            // Act
            privateObject.Invoke(ReplaceCSDataMethodName, nonPublicInstance, new object[] { resourceValues });
            resourceValues = (clsResourceValues)privateObject.GetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance);

            // Assert
            resourceValues.ShouldSatisfyAllConditions(
                () => resourceValues.CapacityTargets.Count.ShouldBe(1),
                () => resourceValues.CapacityTargets[One].level.ShouldBe(Zero),
                () => resourceValues.CapacityTargetValues.Count.ShouldBe(1),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void UpdateCSDataMode_WhenCalled_UpdatesDataMode()
        {
            // Arrange
            const string xmlString = @"
                <CapacityScenarios>
                    <CapacityScenario ID=""1"" RMODE=""1""/>
                </CapacityScenarios>";
            var resourceValues = new clsResourceValues()
            {
                CapacityTargets = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        ID = One,
                        level = Three
                    }
                }
            };
            var roleModes = new CStruct();

            roleModes.LoadXML(xmlString);

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);

            // Act
            privateObject.Invoke(UpdateCSDataModeMethodName, publicInstance, new object[] { roleModes });
            resourceValues = (clsResourceValues)privateObject.GetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance);

            // Assert
            resourceValues.ShouldSatisfyAllConditions(
                () => resourceValues.CapacityTargets.Count.ShouldBe(One),
                () => resourceValues.CapacityTargets[One].level.ShouldBe(One));
        }

        [TestMethod]
        public void ResolvePIName_PIDataFound_ReturnsPIName()
        {
            // Arrange
            var pisColumns = new Dictionary<int, clsPIData>()
            {
                [One] = new clsPIData()
                {
                    PIName = DummyString
                }
            };

            privateObject.SetFieldOrProperty(PisColumnFieldName, nonPublicInstance, pisColumns);

            // Act
            var actual = (string)privateObject.Invoke(ResolvePINameMethodName, nonPublicInstance, new object[] { One });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ResolvePIName_PIDataFound_ReturnsEmptyString()
        {
            // Arrange
            var pisColumns = new Dictionary<int, clsPIData>()
            {
                [One] = new clsPIData()
                {
                    PIName = DummyString
                }
            };

            privateObject.SetFieldOrProperty(PisColumnFieldName, nonPublicInstance, pisColumns);

            // Act
            var actual = privateObject.Invoke(ResolvePINameMethodName, nonPublicInstance, new object[] { Three });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetRoleScrenarioData_RoleBasedTrue_Returns()
        {
            // Arrange
            const string xmlString = @"
                <data>
                    <CostCategoryRoles>
                        <CostCategoryRole ID=""1""/>
                    </CostCategoryRoles>
                </data>";
            var doubleArray = new double[]
            {
                One,
                Two,
                Three
            };
            var resxData = new clsResXData()
            {
                bTotalize = true,
                bFilteredOut = false,
                ProjectID = One,
                ProjectName = DummyString
            };
            resxData.SetUpPeriods(Two);
            var totalResxData = new clsResXData()
            {
                bTotalize = true,
                bFilteredOut = false,
                ProjectID = One,
                ProjectName = DummyString
            };
            totalResxData.SetUpPeriods(Two);
            var actualResxData = new clsResXData()
            {
                bTotalize = true,
                bFilteredOut = false,
                ProjectID = One,
                ProjectName = DummyString
            };
            actualResxData.SetUpPeriods(Two);
            actualResxData.WrkHours = doubleArray;
            actualResxData.FTEVals = doubleArray;
            var fullData = new clsResFullDAta()
            {
                tot_Totals = totalResxData,
                tot_actual = resxData,
                actual = new List<clsResXData>()
                {
                    actualResxData
                },
                PIList = new Dictionary<int, string>()
                {
                    [One] = DummyString
                }
            };
            var roleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = fullData
            };
            var resourceValues = new clsResourceValues()
            {
                CapacityTargets = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        ID = One,
                        Name = DummyString,
                        Flag = One
                    },
                    [Two] = new clsEPKItem()
                    {
                        ID = Two,
                        Name = DummyString,
                        Flag = Zero
                    }
                }
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(CostCategoryRoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(RoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);
            privateObject.SetFieldOrProperty(NumPerFieldName, nonPublicInstance, One);
            privateObject.SetFieldOrProperty(CheckCommitFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckNonWorkFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckMspfFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckActualFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckOpenRequestFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckOpenRequireFieldName, nonPublicInstance, true);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetRoleScrenarioDataMethodName, publicInstance, new object[] { xmlString, DummyString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["Per_ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["Role_ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["Hours"].Value.ShouldBe(Two.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["FTEs"].Value.ShouldBe("200"));
        }

        [TestMethod]
        public void GetRoleScrenarioData_RoleBasedFalse_Returns()
        {
            // Arrange
            const string xmlString = @"
                <data>
                    <CostCategoryRoles>
                        <CostCategoryRole ID=""1""/>
                    </CostCategoryRoles>
                </data>";
            var doubleArray = new double[]
            {
                One,
                Two,
                Three
            };
            var resxData = new clsResXData()
            {
                bTotalize = true,
                bFilteredOut = false,
                ProjectID = One,
                ProjectName = DummyString
            };
            resxData.SetUpPeriods(Two);
            var totalResxData = new clsResXData()
            {
                bTotalize = true,
                bFilteredOut = false,
                ProjectID = One,
                ProjectName = DummyString
            };
            totalResxData.SetUpPeriods(Two);
            var actualResxData = new clsResXData()
            {
                bTotalize = true,
                bFilteredOut = false,
                ProjectID = One,
                ProjectName = DummyString
            };
            actualResxData.SetUpPeriods(Two);
            actualResxData.WrkHours = doubleArray;
            actualResxData.FTEVals = doubleArray;
            var fullData = new clsResFullDAta()
            {
                tot_Totals = totalResxData,
                tot_actual = resxData,
                actual = new List<clsResXData>()
                {
                    actualResxData
                },
                PIList = new Dictionary<int, string>()
                {
                    [One] = DummyString
                }
            };
            var roleList = new Dictionary<int, clsResFullDAta>()
            {
                [One] = fullData
            };
            var resourceValues = new clsResourceValues()
            {
                CapacityTargets = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        ID = One,
                        Name = DummyString,
                        Flag = Zero
                    },
                    [Two] = new clsEPKItem()
                    {
                        ID = Two,
                        Name = DummyString,
                        Flag = Zero
                    }
                }
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(CostCategoryRoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(RoleListFieldName, nonPublicInstance, roleList);
            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);
            privateObject.SetFieldOrProperty(NumPerFieldName, nonPublicInstance, One);
            privateObject.SetFieldOrProperty(CheckCommitFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckNonWorkFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckMspfFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckActualFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckOpenRequestFieldName, nonPublicInstance, true);
            privateObject.SetFieldOrProperty(CheckOpenRequireFieldName, nonPublicInstance, true);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetRoleScrenarioDataMethodName, publicInstance, new object[] { xmlString, DummyString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["Per_ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["Role_ID"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["Hours"].Value.ShouldBe(Two.ToString()),
                () => actual.FirstChild.SelectSingleNode("//CS_Value").Attributes["FTEs"].Value.ShouldBe("200"));
        }

        [TestMethod]
        public void GetCSDeptUIDs_WhenCalled_ReturnsIDsSeparatedByCommas()
        {
            // Arrange
            const string expected = "1,2,3";
            var userDepts = new List<clsEPKItem>()
            {
                new clsEPKItem()
                {
                    ID = One
                },
                new clsEPKItem()
                {
                    ID = Two
                },
                new clsEPKItem()
                {
                    ID = Three
                }
            };

            privateObject.SetFieldOrProperty(UserDeptsFieldName, nonPublicInstance, userDepts);

            // Act
            var actual = (string)privateObject.Invoke(GetCSDeptUIDsMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetCSDeptList_WhenCalled_ReturnsDeptListXmlString()
        {
            // Arrange
            var userDepts = new List<clsEPKItem>()
            {
                new clsEPKItem()
                {
                    ID = One,
                    Name = One.ToString()
                },
                new clsEPKItem()
                {
                    ID = Two,
                    Name = Two.ToString()
                }
            };
            var actual = new XmlDocument();

            privateObject.SetFieldOrProperty(UserDeptsFieldName, nonPublicInstance, userDepts);

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetCSDeptListMethodName, publicInstance, new object[] { }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.SelectNodes("//CSDept").Count.ShouldBe(Two),
                () => actual.FirstChild.SelectSingleNode($"//CSDept[@DEPTUID='{One}']").Attributes["DEPTNAME"].Value.ShouldBe(One.ToString()),
                () => actual.FirstChild.SelectSingleNode($"//CSDept[@DEPTUID='{Two}']").Attributes["DEPTNAME"].Value.ShouldBe(Two.ToString()));
        }

        [TestMethod]
        public void SetAllChecks_WhenCalled_SetsAllChecks()
        {
            // Arrange
            var sortColumns = new List<clsResXData>()
            {
                new clsResXData()
                {
                    bTotalize = false
                },
                new clsResXData()
                {
                    bTotalize = false
                }
            };

            ShimRPAData.AllInstances.NewRedrawTotals = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);

            // Act
            privateObject.Invoke(SetAllChecksMethodName, publicInstance, new object[] { true });
            sortColumns = (List<clsResXData>)privateObject.GetFieldOrProperty(SortColumnFieldName, nonPublicInstance);

            // Assert
            sortColumns.ShouldSatisfyAllConditions(
                () => sortColumns.Count.ShouldBe(2),
                () => sortColumns.Count(x => x.bTotalize).ShouldBe(2),
                () => validations.ShouldBe(One));
        }

        [TestMethod]
        public void GetEditResPlanPIList_WhenCalled_ReturnsProjectIdsSeparatedByCommas()
        {
            // Arrange
            const string expected = "1,3";
            var sortColumns = new List<clsResXData>()
            {
                new clsResXData()
                {
                    bTotalize = true,
                    ProjectID = One
                },
                new clsResXData()
                {
                    bTotalize = false,
                    ProjectID = Two
                },
                new clsResXData()
                {
                    bTotalize = true,
                    ProjectID = Three
                }
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);

            // Act
            var actual = (string)privateObject.Invoke(GetEditResPlanPIListMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetEditResPlanResList_WhenCalled_ReturnsResIdsSeparatedByCommas()
        {
            // Arrange
            const string expected = "1,3";
            var sortColumns = new List<clsResXData>()
            {
                new clsResXData()
                {
                    bTotalize = true,
                    WResID = One
                },
                new clsResXData()
                {
                    bTotalize = false,
                    WResID = Two
                },
                new clsResXData()
                {
                    bTotalize = true,
                    WResID = Three
                }
            };

            privateObject.SetFieldOrProperty(SortColumnFieldName, nonPublicInstance, sortColumns);

            // Act
            var actual = (string)privateObject.Invoke(GetEditResPlanResListMethodName, publicInstance, new object[] { });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetEditResPlanTicket_WhenCalled_ReturnsTicketXmlString()
        {
            // Arrange
            const string expected = "Ticket";
            var actual = new XmlDocument();

            // Act
            actual.LoadXml((string)privateObject.Invoke(GetEditResPlanTicketMethodName, publicInstance, new object[] { DummyString }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.FirstChild.Name.ShouldBe(expected),
                () => actual.FirstChild.Attributes[ValueString].Value.ShouldBe(DummyString));
        }

        [TestMethod]
        public void AddElement_WhenCalled_AppendsElementToTheEnd()
        {
            // Arrange
            const string childNodeName = "childNodeName";
            const string childNodeValue = "childNodeValue";
            const string xmlString = @"
                <xmlcfg>
                    <Parent/>
                </xmlcfg>";
            var xmlDocument = new XmlDocument();
            var parentNode = default(XmlNode);

            xmlDocument.LoadXml(xmlString);
            parentNode = xmlDocument.FirstChild.SelectSingleNode("//Parent");

            var parameters = new object[]
            {
                xmlDocument,
                parentNode,
                childNodeName,
                childNodeValue
            };

            // Act
            privateObject.Invoke(AddElementMethodName, nonPublicInstance, parameters);
            var actual = (XmlNode)parameters[1];

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ChildNodes.Count.ShouldBe(1),
                () => actual.ChildNodes[0].Name.ShouldBe(childNodeName),
                () => actual.ChildNodes[0].InnerText.ShouldBe(childNodeValue));
        }

        [TestMethod]
        public void PopulateInternals_WhenCalled_Returns()
        {
            // Arrange
            var parameters = new object[]
            {
                DummyString
            };
            var resourceValues = new clsResourceValues()
            {
                CostCategories = new Dictionary<int, clsCatItem>()
                {
                    [One] = new clsCatItem()
                    {
                        UID = One,
                        Role_UID = One,
                        Name = One.ToString(),
                        RoleName = One.ToString(),
                    },
                    [Two] = new clsCatItem()
                    {
                        UID = Two,
                        Role_UID = Two,
                        Name = Two.ToString(),
                        RoleName = Two.ToString()
                    },
                    [Three] = new clsCatItem()
                    {
                        UID = Three,
                        Role_UID = Three,
                        Name = Three.ToString(),
                        RoleName = Three.ToString()
                    }
                },
                Periods = new Dictionary<int, CPeriod>()
                {
                    [One] = new CPeriod(),
                    [Two] = new CPeriod(),
                    [Three] = new CPeriod()
                },
                FTEConvData = new List<clsFTEConv>()
                {
                    new clsFTEConv()
                    {
                        Cat_UID = One,
                        PeriodID = One,
                        FTEConv = One
                    }
                },
                PIs = new Dictionary<int, clsPIData>()
                {
                    [One] = new clsPIData()
                    {
                        ProjectID = One
                    }
                },
                NWItems = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        ID = One,
                        Name = One.ToString()
                    }
                },
                Departments = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        ID = One,
                        Name = One.ToString()
                    }
                },
                Resources = new Dictionary<int, clsResCap>()
                {
                    [One] = new clsResCap()
                    {
                        ID = One,
                        Name = One.ToString(),
                        RoleUID = One,
                        DeptUID = One,
                        BC_UID_CC = One,
                        BC_UID_Role = One,
                        IsResource = true,
                        CustomFields = new List<string>()
                        {
                            DummyString
                        }
                    }
                },
                ResAvail = new List<clsResAvail>()
                {
                    new clsResAvail()
                    {
                        WResID = One,
                        PeriodID = One,
                        Hours = One,
                        FTES = One
                    }
                },
                Commitments = new Dictionary<int, clsCommitment>()
                {
                    [One] = new clsCommitment()
                    {
                        UID = One,
                        WResID = One,
                        DeptUID = One,
                        Dragable = One,
                        ProjectID = One,
                        RoleUID = One,
                        BC_UID_CC = One,
                        BC_UID_Role = One,
                        MajorCategory = DummyString,
                        Rate = One,
                        Status = RPConstants.CONST_Commitment,
                        CustomFields = new List<string>()
                        {
                            DummyString
                        }
                    }
                },
                CommitmentHours = new List<clsCommitmentHours>()
                {
                    new clsCommitmentHours()
                    {
                        UID = One,
                        PeriodID = One,
                        Hours = One,
                        FTES = One
                    }
                },
                ResNWValues = new List<clsNWValue>()
                {
                    new clsNWValue()
                    {
                        WResID = One,
                        UID = One,
                        PeriodID = One,
                        Hours = One,
                        FTES = One
                    }
                },
                SchedWorkHours = new List<clsSchedWork>()
                {
                    new clsSchedWork()
                    {
                        WResID = One,
                        PeriodID = One,
                        ProjectID = One,
                        MajorCategory = One.ToString(),
                    }
                },
                ActualWorkHours = new List<clsSchedWork>()
                {
                    new clsSchedWork()
                    {
                        WResID = One,
                        PeriodID = One,
                        ProjectID = One,
                        MajorCategory = One.ToString(),
                    }
                },
                Roles = new Dictionary<int, clsListItem>()
                {
                    [One] = new clsListItem()
                    {
                        ID = One,
                        Name = One.ToString()
                    }
                },
                CapacityTargets = new Dictionary<int, clsEPKItem>()
                {
                    [One] = new clsEPKItem()
                    {
                        ID = One,
                        Name = One.ToString(),
                        UID = One,
                        Flag = Zero
                    },
                    [Two] = new clsEPKItem()
                    {
                        ID = Two,
                        Name = Two.ToString(),
                        UID = Two,
                        Flag = One
                    }
                },
                CapacityTargetValues = new List<clsCapacityValue>()
                {
                    new clsCapacityValue()
                    {
                        ID = One,
                        RoleUID = One,
                        DeptUID = One,
                        PeriodID = One,
                        Hours = One,
                        FTES = One,
                    },
                    new clsCapacityValue()
                    {
                        ID = Two,
                        RoleUID = One,
                        DeptUID = Two,
                        PeriodID = Two,
                        Hours = Two,
                        FTES = Two,
                    }
                }
            };
            var grow = new RPATGRow()
            {
                fid = One,
                Name = DummyString
            };
            var growList = new List<RPATGRow>()
            {
                grow
            };

            ShimRPAData.AllInstances.BuileCCR2RoleMap = _ =>
            {
                validations += 1;
            };
            ShimRPAData.AllInstances.MapCCR2RoleInt32 = (_, __) =>
            {
                validations += 1;
                return One;
            };

            privateObject.SetFieldOrProperty(ResourceValuesFieldName, nonPublicInstance, resourceValues);
            privateObject.SetFieldOrProperty("m_firstperiod_data", nonPublicInstance, Zero);
            privateObject.SetFieldOrProperty(TotGeneralFieldName, nonPublicInstance, growList);

            // Act
            privateObject.Invoke(PopulateInternalsMethodName, nonPublicInstance, parameters);
            var roles = (Dictionary<int, clsEPKItem>)privateObject.GetFieldOrProperty("m_roles", nonPublicInstance);
            var pisColumns = (Dictionary<int, clsPIData>)privateObject.GetFieldOrProperty(PisColumnFieldName, nonPublicInstance);
            var deptColumns = (Dictionary<int, clsRXDept>)privateObject.GetFieldOrProperty("m_cln_depts", nonPublicInstance);
            var resAvail = (Dictionary<int, clsResxAvail>)privateObject.GetFieldOrProperty("m_resavail", nonPublicInstance);
            var resData = (Dictionary<int, clsResXData>)privateObject.GetFieldOrProperty(ResDataFieldName, nonPublicInstance);

            // Assert
            roles.ShouldSatisfyAllConditions(
                () => roles.Count.ShouldBe(3),
                () => roles[One].Name.ShouldBe(One.ToString()),
                () => pisColumns.Count.ShouldBe(2),
                () => pisColumns[One].ProjectID.ShouldBe(One),
                () => pisColumns[12].ProjectID.ShouldBe(12),
                () => deptColumns.Count.ShouldBe(2),
                () => deptColumns[One].ID.ShouldBe(One),
                () => deptColumns[Zero].ID.ShouldBe(Zero),
                () => resAvail.Count.ShouldBe(2),
                () => resAvail[One].ID.ShouldBe(One),
                () => resAvail[Zero].ID.ShouldBe(Zero),
                () => resData.Count.ShouldBe(4),
                () => resData[One].ID.ShouldBe(One),
                () => validations.ShouldBe(2));
        }
    }
}