using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Web.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceValues;
using RPADataCache;
using RPADataCache.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RPADataTests
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
        private const int DummyCommitmentId15 = 15;
        private const int DummyCommitmentId25 = 25;
        private const int DummyCommitmentId35 = 35;
        private const int DummyPeriodId = 1;
        private const int DummyCostCastUid = 100;
        private const int DummyDepartamentId = 200;
        private const int DummyDepartamentId2 = 250;
        private const int DummyWResId = 300;
        private const int DummyPisProjectId = 400;
        private const int DummyCostCategoryId = 500;
        private const int DummyRoleUId = 600;
        private const int DummyRoleUId2 = 650;
        private const string SampleGuidString1 = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string SampleGuidString2 = "83e81819-0104-4c22-bb70-d8ba101e9e0c";
        private const string DummyString = "DummyString";
        private const string DummyRoleName = "DummyRoleName";
        private const string DummyNwItemName = "DummyNwItemName";
        private const string DummyDepartament = "DummyDepartament";
        private const string DummyResourceName = "DummyResourceName";
        private const string DummyMajorCategory = "DummyMajorCategory";
        private const string DummyRateType = "DummyRateType";
        private const string DummyGroup = "DummyGroup";
        private const string DummyCustomField = "DummyCustomField";
        private const string DummyCapacityTargetName = "DummyCapacityTargetName";
        private const string IDStringCaps = "ID";
        private const string SampleUrl = "http://www.sampleurl.com";
        private const string ResourceValuesFieldName = "m_cResVals";
        private const string RolesAllowedFieldName = "m_CSRoleAllowed";
        private const string CatLookupFieldName = "m_maj_Cat_lookup";
        private const string ResourceDataFieldName = "m_resdata";
        private const string ResourceAvailFieldName = "m_resavail";
        private const string DepartamentsFieldName = "m_cln_depts";
        private const string PisFieldName = "m_cln_pis";
        private const string ResourceListFieldName = "m_reslist";
        private const string CostCategoryRoleListFieldName = "m_ccrolelist";
        private const string RoleListFieldName = "m_rolelist";
        private const string RolesFieldName = "m_roles";
        private const string UserDeptsFieldName = "UserDepts";
        private const string CostCategoryRoleMappingFieldName = "m_CCR_Role_Mapping";
        private const string TotalMasterColumnFieldName = "m_totmastercln";
        private const string DetMasterColumnFieldName = "m_detmastercln";
        private const string TotalDisplayColumnFieldName = "m_totdispcln";
        private const string DetDisplayColumnFieldName = "m_detdispcln";
        private const string StashCSRoleModeMethodName = "StashCSRoleMode";
        private const string IsCSRoleAllowedMethodName = "IsCSRoleAllowed";
        private const string SetMajorCatListlookupMethodName = "SetMajorCatListlookup";
        private const string ItemListAddItemMethodName = "ItemListAddItem";
        private const string GrabRADataMethodName = "GrabRAData";
        private const string DoUserDeptsMethodName = "DoUserDepts";
        private const string BuileCCR2RoleMapMethodName = "BuileCCR2RoleMap";
        private const string MapCCR2RoleMethodName = "MapCCR2Role";
        private const string setupdispcolnsMethodName = "setupdispcolns";
        private const string PopulateInternalsMethodName = "PopulateInternals";
        private static readonly DateTime DummyStartDate = new DateTime(2018, 1, 1, 0, 0, 0);
        private static readonly DateTime DummyFinishDate = new DateTime(2018, 1, 2, 0, 0, 0);

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
            validations = 0;
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
                () => itemList[0].ID.ShouldBe(DummyInt),
                () => itemList[0].Name.ShouldBe(DummyString));
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
                CommitmentsOpMode = 0,
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
                () => resourceValues.CommitmentHours[0].UID.ShouldBe(100004));
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
                () => userDepts.Any(x => x.ID.Equals(0) && x.Name.Equals(expected)));
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
                () => mapping[Two].ShouldBe(0),
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
            actual.ShouldBe(0);
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
            actual.ShouldBe(0);
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
        public void PopulateInternals_Should_ReturnsErrorLogFillInternalsProperties()
        {
            // Arrange
            var totGeneral = new List<RPATGRow>();
            privateObject.SetField("TotGeneral", totGeneral);
            privateObject.SetField(ResourceValuesFieldName, CreateResourceValues());
            privateObject.SetField("m_firstperiod_data", 0);
            var expectedResult = "P016";

            object[] args = new object[] { string.Empty };

            // Act
            privateObject.Invoke(PopulateInternalsMethodName, args);

            // Assert
            var errorLog = (string)args[0];
            var resourceData = (Dictionary<int, clsResXData>)privateObject.GetField(ResourceDataFieldName);
            var resourceAvail = (Dictionary<int, clsResxAvail>)privateObject.GetField(ResourceAvailFieldName);
            var clnDetps = (Dictionary<int, clsRXDept>)privateObject.GetField(DepartamentsFieldName);
            var clnPis = (Dictionary<int, clsPIData>)privateObject.GetField(PisFieldName);
            var resourceList = (Dictionary<int, clsResFullDAta>)privateObject.GetField(ResourceListFieldName);
            var costCategoryRoleList = (Dictionary<int, clsResFullDAta>)privateObject.GetField(CostCategoryRoleListFieldName);
            var roleList = (Dictionary<int, clsResFullDAta>)privateObject.GetField(RoleListFieldName);
            var roles = (Dictionary<int, clsEPKItem>)privateObject.GetField(RolesFieldName);

            this.ShouldSatisfyAllConditions(
                () => errorLog.ShouldBe(expectedResult),
                () => resourceData.Count.ShouldBe(6),
                () => resourceData[DummyCommitmentId15].CostCat.ShouldBe(20),
                () => resourceData[DummyCommitmentId15].CostCatRole.ShouldBe(DummyCostCategoryId),
                () => resourceData[DummyCommitmentId15].DeptUID.ShouldBe(17),
                () => resourceData[DummyCommitmentId15].ID.ShouldBe(1),
                () => resourceData[DummyCommitmentId15].PlanGroup.ShouldBe(DummyGroup),
                () => resourceData[DummyCommitmentId15].PlanID.ShouldBe(DummyCommitmentId15.ToString().PadLeft(4, '0')),
                () => resourceData[DummyCommitmentId15].ProjectID.ShouldBe(DummyPisProjectId),
                () => resourceData[DummyCommitmentId15].RoleUID.ShouldBe(DummyRoleUId),
                () => resourceData[DummyCommitmentId15].Status.ShouldBe(RPConstants.CONST_Commitment),
                () => resourceData[DummyCommitmentId15].UID.ShouldBe(DummyCommitmentId15),
                () => resourceData[DummyCommitmentId15].WResID.ShouldBe(DummyWResId),
                () => resourceData[DummyCommitmentId15].cCost.ShouldBe(23),
                () => resourceData[DummyCommitmentId15].cFDate.ShouldBe(DummyFinishDate),
                () => resourceData[DummyCommitmentId15].cRate.ShouldBe(22),
                () => resourceData[DummyCommitmentId15].cRateType.ShouldBe(DummyRateType),
                () => resourceData[DummyCommitmentId15].cSDate.ShouldBe(DummyStartDate),
                () => resourceData[DummyCommitmentId15].majorcat.ShouldBe(DummyMajorCategory),
                () => resourceData[DummyCommitmentId25].CostCat.ShouldBe(30),
                () => resourceData[DummyCommitmentId25].CostCatRole.ShouldBe(31),
                () => resourceData[DummyCommitmentId25].DeptUID.ShouldBe(27),
                () => resourceData[DummyCommitmentId25].ID.ShouldBe(2),
                () => resourceData[DummyCommitmentId25].PlanGroup.ShouldBe(DummyGroup),
                () => resourceData[DummyCommitmentId25].PlanID.ShouldBe(DummyCommitmentId25.ToString().PadLeft(4, '0')),
                () => resourceData[DummyCommitmentId25].ProjectID.ShouldBe(DummyPisProjectId),
                () => resourceData[DummyCommitmentId25].RoleUID.ShouldBe(29),
                () => resourceData[DummyCommitmentId25].Status.ShouldBe(RPConstants.CONST_OPENREQUEST),
                () => resourceData[DummyCommitmentId25].UID.ShouldBe(DummyCommitmentId25),
                () => resourceData[DummyCommitmentId25].WResID.ShouldBe(DummyWResId),
                () => resourceData[DummyCommitmentId25].cCost.ShouldBe(33),
                () => resourceData[DummyCommitmentId25].cFDate.ShouldBe(DummyFinishDate),
                () => resourceData[DummyCommitmentId25].cRate.ShouldBe(32),
                () => resourceData[DummyCommitmentId25].cRateType.ShouldBe(DummyRateType),
                () => resourceData[DummyCommitmentId25].cSDate.ShouldBe(DummyStartDate),
                () => resourceData[DummyCommitmentId25].majorcat.ShouldBe(DummyMajorCategory),
                () => resourceData[DummyCommitmentId35].CostCat.ShouldBe(40),
                () => resourceData[DummyCommitmentId35].CostCatRole.ShouldBe(41),
                () => resourceData[DummyCommitmentId35].DeptUID.ShouldBe(37),
                () => resourceData[DummyCommitmentId35].ID.ShouldBe(3),
                () => resourceData[DummyCommitmentId35].PlanGroup.ShouldBe(DummyGroup),
                () => resourceData[DummyCommitmentId35].PlanID.ShouldBe(DummyCommitmentId35.ToString().PadLeft(4, '0')),
                () => resourceData[DummyCommitmentId35].ProjectID.ShouldBe(DummyPisProjectId),
                () => resourceData[DummyCommitmentId35].RoleUID.ShouldBe(39),
                () => resourceData[DummyCommitmentId35].Status.ShouldBe(RPConstants.CONST_REQUIRE),
                () => resourceData[DummyCommitmentId35].UID.ShouldBe(DummyCommitmentId35),
                () => resourceData[DummyCommitmentId35].WResID.ShouldBe(DummyWResId),
                () => resourceData[DummyCommitmentId35].cCost.ShouldBe(43),
                () => resourceData[DummyCommitmentId35].cFDate.ShouldBe(DummyFinishDate),
                () => resourceData[DummyCommitmentId35].cRate.ShouldBe(42),
                () => resourceData[DummyCommitmentId35].cRateType.ShouldBe(DummyRateType),
                () => resourceData[DummyCommitmentId35].cSDate.ShouldBe(DummyStartDate),
                () => resourceData[DummyCommitmentId35].majorcat.ShouldBe(DummyMajorCategory),
                () => resourceAvail[DummyWResId].CostCat.ShouldBe(DummyCostCastUid),
                () => resourceAvail[DummyWResId].CostCatRole.ShouldBe(DummyCostCategoryId),
                () => resourceAvail[DummyWResId].DeptID.ShouldBe(DummyDepartamentId2),
                () => resourceAvail[DummyWResId].Name.ShouldBe(DummyResourceName),
                () => resourceAvail[DummyWResId].RoleID.ShouldBe(DummyRoleUId),
                () => clnDetps[DummyDepartamentId].ID.ShouldBe(DummyDepartamentId),
                () => clnDetps[DummyDepartamentId].Name.ShouldBe(DummyDepartament),
                () => clnPis[DummyPisProjectId].ProjectID.ShouldBe(DummyPisProjectId),
                () => resourceList[DummyWResId].ResOrRole.ShouldBe(DummyResourceName),
                () => resourceList[DummyWResId].actual.Count.ShouldBe(1),
                () => resourceList[DummyWResId].avail.Count.ShouldBe(1),
                () => resourceList[DummyWResId].committed.Count.ShouldBe(1),
                () => resourceList[DummyWResId].openreq.Count.ShouldBe(1),
                () => resourceList[DummyWResId].personel.Count.ShouldBe(1),
                () => resourceList[DummyWResId].proposal.Count.ShouldBe(1),
                () => resourceList[DummyWResId].scheduled.Count.ShouldBe(1),
                () => costCategoryRoleList[DummyCostCategoryId].CapScen.Count.ShouldBe(1),
                () => costCategoryRoleList[DummyCostCategoryId].actual.Count.ShouldBe(1),
                () => costCategoryRoleList[DummyCostCategoryId].avail.Count.ShouldBe(1),
                () => costCategoryRoleList[DummyCostCategoryId].committed.Count.ShouldBe(1),
                () => costCategoryRoleList[DummyCostCategoryId].personel.Count.ShouldBe(1),
                () => costCategoryRoleList[DummyCostCategoryId].proposal.Count.ShouldBe(1),
                () => costCategoryRoleList[DummyCostCategoryId].scheduled.Count.ShouldBe(1),
                () => roleList[DummyRoleUId].CapScen.Count.ShouldBe(1),
                () => roleList[DummyRoleUId].actual.Count.ShouldBe(1),
                () => roleList[DummyRoleUId].avail.Count.ShouldBe(1),
                () => roleList[DummyRoleUId].committed.Count.ShouldBe(1),
                () => roleList[DummyRoleUId].personel.Count.ShouldBe(1),
                () => roleList[DummyRoleUId].proposal.Count.ShouldBe(1),
                () => roleList[DummyRoleUId].scheduled.Count.ShouldBe(1),
                () => roles[DummyRoleUId2].Name.ShouldBe(DummyRoleName),
                () => roles[DummyRoleUId2].Flag.ShouldBe(Zero));
        }

        private static clsResourceValues CreateResourceValues()
        {
            var resourceValues = new clsResourceValues();
            resourceValues.CostCategories = new Dictionary<int, clsCatItem>();
            resourceValues.CostCategories.Add(
                DummyCostCategoryId,
                new clsCatItem()
                {
                    ID = DummyCostCategoryId,
                    Role_UID = DummyRoleUId2,
                    RoleName = DummyRoleName,
                    UID = DummyCostCategoryId,
                    Name = DummyRoleName
                });
            resourceValues.Periods = new Dictionary<int, CPeriod>();
            resourceValues.Periods.Add(0, new CPeriod());
            resourceValues.FTEConvData = new List<clsFTEConv>()
            {
                new clsFTEConv()
                {
                    Cat_UID = Three,
                    PeriodID = DummyPeriodId,
                    FTEConv = Four
                }
            };
            resourceValues.PIs = new Dictionary<int, clsPIData>();
            resourceValues.PIs.Add(
                0,
                new clsPIData()
                {
                    ProjectID = DummyPisProjectId
                });
            resourceValues.NWItems = new Dictionary<int, clsEPKItem>();
            resourceValues.NWItems.Add(
                0,
                new clsEPKItem()
                {
                    ID = 6,
                    Name = DummyNwItemName
                });
            resourceValues.Departments = new Dictionary<int, clsEPKItem>();
            resourceValues.Departments.Add(
                0,
                new clsEPKItem()
                {
                    ID = DummyDepartamentId,
                    Name = DummyDepartament
                });
            resourceValues.Resources = new Dictionary<int, clsResCap>();
            resourceValues.Resources.Add(
                0,
                new clsResCap()
                {
                    ID = DummyWResId,
                    RoleUID = DummyRoleUId,
                    DeptUID = DummyDepartamentId2,
                    BC_UID_CC = DummyCostCastUid,
                    BC_UID_Role = DummyCostCategoryId,
                    IsResource = true,
                    CustomFields = new List<string>()
                    {
                        DummyString
                    },
                    Name = DummyResourceName
                });
            resourceValues.ResAvail = new List<clsResAvail>()
            {
                new clsResAvail()
                {
                    WResID = DummyWResId,
                    PeriodID = DummyPeriodId,
                    Hours = One,
                    FTES = Two
                }
            };
            resourceValues.Commitments = new Dictionary<int, clsCommitment>();
            resourceValues.Commitments.Add(
                0,
                new clsCommitment()
                {
                    UID = DummyCommitmentId15,
                    WResID = DummyWResId,
                    Status = RPConstants.CONST_Commitment,
                    DeptUID = 17,
                    Dragable = 1,
                    ProjectID = DummyPisProjectId,
                    RoleUID = DummyRoleUId,
                    BC_UID_CC = 20,
                    BC_UID_Role = DummyCostCategoryId,
                    MajorCategory = DummyMajorCategory,
                    StartDate = DummyStartDate,
                    FinishDate = DummyFinishDate,
                    Rate = 22,
                    cost = 23,
                    RateType = DummyRateType,
                    ID = DummyCommitmentId15,
                    Group = DummyGroup,
                    CustomFields = new List<string>()
                    {
                        DummyCustomField
                    }
                });
            resourceValues.Commitments.Add(
                1,
                new clsCommitment()
                {
                    UID = DummyCommitmentId25,
                    WResID = DummyWResId,
                    Status = RPConstants.CONST_OPENREQUEST,
                    DeptUID = 27,
                    Dragable = 0,
                    ProjectID = DummyPisProjectId,
                    RoleUID = 29,
                    BC_UID_CC = 30,
                    BC_UID_Role = 31,
                    MajorCategory = DummyMajorCategory,
                    StartDate = DummyStartDate,
                    FinishDate = DummyFinishDate,
                    Rate = 32,
                    cost = 33,
                    RateType = DummyRateType,
                    ID = DummyCommitmentId25,
                    Group = DummyGroup,
                    CustomFields = new List<string>()
                    {
                        DummyCustomField
                    }
                });
            resourceValues.Commitments.Add(
                2,
                new clsCommitment()
                {
                    UID = DummyCommitmentId35,
                    WResID = DummyWResId,
                    Status = RPConstants.CONST_REQUIRE,
                    DeptUID = 37,
                    Dragable = 1,
                    ProjectID = DummyPisProjectId,
                    RoleUID = 39,
                    BC_UID_CC = 40,
                    BC_UID_Role = 41,
                    MajorCategory = DummyMajorCategory,
                    StartDate = DummyStartDate,
                    FinishDate = DummyFinishDate,
                    Rate = 42,
                    cost = 43,
                    RateType = DummyRateType,
                    ID = DummyCommitmentId35,
                    Group = DummyGroup,
                    CustomFields = new List<string>()
                    {
                        DummyCustomField
                    }
                });
            resourceValues.CommitmentHours = new List<clsCommitmentHours>()
            {
                new clsCommitmentHours()
                {
                    UID = 15,
                    PeriodID = DummyPeriodId,
                    Hours = One,
                    FTES = Two
                }
            };
            resourceValues.ResNWValues = new List<clsNWValue>()
            {
                new clsNWValue()
                {
                    WResID = DummyWResId,
                    UID = 48,
                    PeriodID = DummyPeriodId,
                    Hours = Three,
                    FTES = Four
                }
            };
            resourceValues.FromPeriodID = DummyPeriodId;
            resourceValues.SchedWorkHours = new List<clsSchedWork>()
            {
                new clsSchedWork()
                {
                    WResID = DummyWResId,
                    ProjectID = DummyPisProjectId,
                    MajorCategory = DummyMajorCategory,
                    PeriodID = DummyPeriodId,
                    Hours = One,
                    FTES = Two
                }
            };
            resourceValues.ActualWorkHours = new List<clsSchedWork>()
            {
                new clsSchedWork()
                {
                    WResID = DummyWResId,
                    ProjectID = DummyPisProjectId,
                    MajorCategory = DummyMajorCategory,
                    PeriodID = DummyPeriodId,
                    Hours = Three,
                    FTES = Four
                }
            };
            resourceValues.Roles = new Dictionary<int, clsListItem>()
            {
                {
                    DummyRoleUId, new clsListItem()
                    {
                        UID = DummyRoleUId,
                        Name = DummyRoleName,
                        ID = DummyRoleUId
                    }
                }
            };
            resourceValues.CapacityTargets = new Dictionary<int, clsEPKItem>()
            {
                {
                    49, new clsEPKItem()
                    {
                        Name = DummyCapacityTargetName,
                        Flag = Two
                    }
                },
                {
                    50, new clsEPKItem()
                    {
                        Name = DummyCapacityTargetName,
                        Flag = Zero
                    }
                }
            };
            resourceValues.CapacityTargetValues = new List<clsCapacityValue>()
            {
                new clsCapacityValue()
                {
                    ID = 49,
                    RoleUID = DummyRoleUId,
                    PeriodID = DummyPeriodId,
                    Hours = Three,
                    FTES = Four
                },
                new clsCapacityValue()
                {
                    ID = 50,
                    RoleUID = DummyCostCategoryId,
                    PeriodID = DummyPeriodId,
                    Hours = Three,
                    FTES = Four
                }
            };
            return resourceValues;
        }
    }
}