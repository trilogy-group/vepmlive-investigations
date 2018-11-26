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
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RPADataCache;
using Shouldly;

namespace EPMLiveCore.Tests.Jobs
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class SecurityUpdateRemTests
    {
        private SecurityUpdate testObject;
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
        private ShimSqlDataReader dataReader;
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
        private const string ExecuteMethodName = "execute";
        private const string GetIdenticalGroupNameMethodName = "GetIdenticalGroupName";
        private const string ProcessSecurityMethodName = "ProcessSecurity";
        private const string AddBuildTeamSecurityGroupsMethodName = "AddBuildTeamSecurityGroups";
        private const string AddNewItemLvlPermMethodName = "AddNewItemLvlPerm";
        private const string GetSafeGroupTitleMethodName = "GetSafeGroupTitle";

        [TestInitialize]
        public void Setup()
        {
            testObject = new SecurityUpdate();
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
            //ShimGridGanttSettings.ConstructorSPList = (_, __) => new ShimGridGanttSettings();
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
            ShimEnhancedLookupConfigValuesHelper.ConstructorString = (_, __) => new ShimEnhancedLookupConfigValuesHelper();
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ => new ShimSPRoleAssignmentCollection();
            ShimSPRoleAssignment.ConstructorSPPrincipal = (_, __) => new ShimSPRoleAssignment();
            ShimSPRoleDefinition.Constructor = _ => new ShimSPRoleDefinition();
            ShimSPRoleDefinitionCollection.AllInstances.GetByTypeSPRoleType = (_, __) => new ShimSPRoleDefinition();
            ShimSPRoleDefinitionCollection.AllInstances.ItemGetString = (_, __) => new ShimSPRoleDefinition();
            ShimSPRoleAssignment.AllInstances.RoleDefinitionBindingsGet = _ => new ShimSPRoleDefinitionBindingCollection();
            ShimSPRoleDefinitionBindingCollection.AllInstances.AddSPRoleDefinition = (_, __) => { };
            ShimReportData.ConstructorGuid = (_, __) => new ShimReportData();
            ShimReportData.AllInstances.Dispose = _ => { };
            ShimReportData.AllInstances.GetClientReportingConnection = _ => new ShimSqlConnection();
            ShimSqlCommand.ConstructorStringSqlConnection = (_, query, _2) => new SqlCommand(query);
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimSPPrincipal.AllInstances.IDGet = _ => DummyInt;
            ShimSPRoleDefinitionCollection.AllInstances.GetByIdInt32 = (_, __) => new ShimSPRoleDefinition();
            ShimSPGroupCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPGroup();
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
                AllowUnsafeUpdatesSetBoolean = _ => { },
                AllUsersGet = () => new ShimSPUserCollection(),
                SiteUsersGet = () => new ShimSPUserCollection(),
                SiteGroupsGet = () => new ShimSPGroupCollection(),
                RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection()
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
            dataReader = new ShimSqlDataReader()
            {
                Read = () => true,
                Close = () => { }
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void Execute_WhenCalled_ExecutesActivities()
        {
            // Arrange
            const bool buildTeamSecurity = true;
            const string lookups = "1^2^3^4^true";
            var methodHit = 0;
            var lookupField = new ShimSPFieldLookup()
            {
                LookupListGet = () => SampleGuidString1
            };

            spListItem.HasUniqueRoleAssignmentsGet = () =>
            {
                methodHit += 1;
                return methodHit > 1;
            };
            spWeb.AllowUnsafeUpdatesSetBoolean = _ => { };
            spFieldCollection.GetFieldByInternalNameString = _ => lookupField;

            ShimSPSecurableObject.AllInstances.BreakRoleInheritanceBoolean = (_, input) =>
            {
                if (!input)
                {
                    validations += 1;
                }
            };
            ShimCoreFunctions.getListSettingStringSPList = (_, __) =>
            {
                var settings = string.Empty;
                for (var i = 0; i <= 50; i++)
                {
                    if (i.Equals(32))
                    {
                        settings += $"{buildTeamSecurity};";
                    }
                    else if (i.Equals(26))
                    {
                        settings += $"{lookups};";
                    }
                    else
                    {
                        settings += $"{DummyString};";
                    }
                }
                return settings.Replace(";", "\n");
            };
            ShimSecurityUpdate.AllInstances.GetSafeGroupTitleString = (_, __) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimSecurityUpdate.AllInstances.GetIdenticalGroupNameGuidGuidStringInt32 = (_, _1, _2, _3, _4) =>
            {
                validations += 1;
                return DummyString;
            };
            ShimSecurityUpdate.AllInstances.AddBasicSecurityGroupsSPWebStringSPUserSPListItem = (_, _1, _2, _3, _4) =>
            {
                validations += 1;
                var newGroups = new Dictionary<string, SPRoleType>()
                {
                    [DummyString] = SPRoleType.Administrator
                };
                return newGroups;
            };
            ShimSecurityUpdate.AllInstances.AddNewItemLvlPermSPListItemSPWebSPRoleTypeSPPrincipal = (_, _1, _2, _3, _4) =>
            {
                validations += 1;
            };
            ShimSecurityUpdate.AllInstances.AddBuildTeamSecurityGroupsSPWebGridGanttSettingsSPListItem = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimEnhancedLookupConfigValuesHelper.AllInstances.GetSecuredFields = _ =>
            {
                validations += 1;
                return new List<string>()
                {
                    DummyString
                };
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPRoleAssignment>().GetEnumerator();
            ShimSPRoleDefinitionBindingCollection.AllInstances.AddSPRoleDefinition = (_, __) =>
            {
                validations += 1;
            };
            ShimSPRoleAssignmentCollection.AllInstances.AddSPRoleAssignment = (_, __) =>
            {
                validations += 1;
            };
            ShimSecurityUpdate.AllInstances.ProcessSecuritySPSiteSPListSPListItemInt32 = (_, _1, _2, _3, _4) =>
            {
                validations += 1;
            };
            ShimWorkspaceTimerjobAgent.QueueWorkspaceJobOnHoldForSecurityGuidGuidGuidInt32 = (_1, _2, _3, _4) =>
            {
                validations += 1;
                return DummyString;
            };

            // Act
            privateObject.Invoke(
                ExecuteMethodName,
                publicInstance,
                new object[]
                {
                    spSite.Instance,
                    spWeb.Instance,
                    guid,
                    One,
                    One,
                    DummyString
                });

            // Assert
            validations.ShouldSatisfyAllConditions(
                () => methodHit.ShouldBe(2),
                () => validations.ShouldBe(10));
        }

        [TestMethod]
        public void GetIdenticalGroupName_WhenCalled_ReturnsUniqueGroupName()
        {
            // Arrange
            var readHit = 0;
            var expected = $"{DummyString}{Two}";

            dataReader.Read = () =>
            {
                readHit += 1;
                return readHit == One;
            };

            ShimReportData.AllInstances.Dispose = _ =>
            {
                validations += 1;
            };

            privateObject.SetFieldOrProperty("safeGroupTitle", nonPublicInstance, DummyString);

            // Act
            var actual = (string)privateObject.Invoke(
                GetIdenticalGroupNameMethodName,
                nonPublicInstance,
                new object[]
                {
                    guid,
                    guid,
                    DummyString,
                    One
                });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(2));
        }

        [TestMethod]
        public void ProcessSecurity_WhenCalled_ProcessesSecurity()
        {
            // Arrange
            dataReader.Read = () => false;

            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPRoleAssignment>()
            {
                new ShimSPRoleAssignment()
                {
                    MemberGet = () => new ShimSPGroup(),
                    RoleDefinitionBindingsGet = () => new ShimSPRoleDefinitionBindingCollection()
                    {
                        ItemGetInt32 = __ => new ShimSPRoleDefinition()
                        {
                            BasePermissionsGet = () => SPBasePermissions.ViewListItems
                        }
                    }
                }
            }.GetEnumerator();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ =>
            {
                validations += 1;
                return DummyInt;
            };

            // Act
            privateObject.Invoke(
                ProcessSecurityMethodName,
                nonPublicInstance,
                new object[]
                {
                    spSite.Instance,
                    spList.Instance,
                    spListItem.Instance,
                    One
                });

            // Assert
            validations.ShouldBe(4);
        }

        [TestMethod]
        public void AddBuildTeamSecurityGroups_TypeNotGuest_UpdatesSecurityGroups()
        {
            // Arrange
            const SPRoleType type = SPRoleType.Administrator;
            var buildTeamPermissions = "1~2~3|1~2~3";
            var methodHit = 0;
            var settingsDictionary = new Dictionary<int, string>()
            {
                [33] = buildTeamPermissions
            };

            ShimCoreFunctions.getListSettingStringSPList = (_, __) =>
            {
                var settings = string.Empty;

                for (var index = 0; index <= 50; index++)
                {
                    if (settingsDictionary.ContainsKey(index))
                    {
                        settings += $"{settingsDictionary[index]};";
                    }
                    else
                    {
                        settings += $"{DummyString};";
                    }
                }
                return settings.Replace(";", "\n");
            };
            ShimSPRoleDefinition.AllInstances.TypeGet = _ => type;
            ShimSPRoleDefinitionBindingCollection.AllInstances.AddSPRoleDefinition = (_, __) =>
            {
                validations += 1;
            };
            ShimSecurityUpdate.AllInstances.AddNewItemLvlPermSPListItemSPWebSPRoleAssignment = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimSPGroup.AllInstances.UsersGet = _ => new ShimSPUserCollection();
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ =>
            {
                methodHit += 1;
                if (methodHit.Equals(One))
                {
                    var roleAssignments = new List<SPRoleAssignment>()
                    {
                        new ShimSPRoleAssignment()
                        {
                            MemberGet = () => new ShimSPGroup()
                            {
                                NameGet = () => "Owner",
                                AddUserSPUser = __ =>
                                {
                                    validations += 1;
                                },
                                Update = () =>
                                {
                                    validations += 1;
                                }
                            }.Instance
                        }
                    }.GetEnumerator();
                    return roleAssignments;
                }
                var users = new List<SPUser>()
                {
                }.GetEnumerator();
                return users;
            };

            var ganttSettings = new GridGanttSettings(spList);

            // Act
            privateObject.Invoke(
                AddBuildTeamSecurityGroupsMethodName,
                publicInstance,
                new object[]
                {
                    spWeb.Instance,
                    ganttSettings,
                    spListItem.Instance
                });

            // Assert
            validations.ShouldBe(3);
        }

        [TestMethod]
        public void AddBuildTeamSecurityGroups_TypeGuest_UpdatesSecurityGroups()
        {
            // Arrange
            const SPRoleType type = SPRoleType.Guest;
            var buildTeamPermissions = "1~2~3|1~2~3";
            var settingsDictionary = new Dictionary<int, string>()
            {
                [33] = buildTeamPermissions
            };

            ShimCoreFunctions.getListSettingStringSPList = (_, __) =>
            {
                var settings = string.Empty;

                for (var index = 0; index <= 50; index++)
                {
                    if (settingsDictionary.ContainsKey(index))
                    {
                        settings += $"{settingsDictionary[index]};";
                    }
                    else
                    {
                        settings += $"{DummyString};";
                    }
                }
                return settings.Replace(";", "\n");
            };
            ShimSPRoleDefinition.AllInstances.TypeGet = _ => type;
            ShimSPRoleDefinitionBindingCollection.AllInstances.AddSPRoleDefinition = (_, __) =>
            {
                validations += 1;
            };
            ShimSecurityUpdate.AllInstances.AddNewItemLvlPermSPListItemSPWebSPRoleAssignment = (_, _1, _2, _3) =>
            {
                validations += 1;
            };
            ShimSPGroup.AllInstances.UsersGet = _ => new ShimSPUserCollection();
            ShimSPRoleDefinitionCollection.AllInstances.ItemGetString = (_, __) =>
            {
                validations += 1;
                throw new SPException(DummyString);
            };

            var ganttSettings = new GridGanttSettings(spList);

            // Act
            privateObject.Invoke(
                AddBuildTeamSecurityGroupsMethodName,
                publicInstance,
                new object[]
                {
                    spWeb.Instance,
                    ganttSettings,
                    spListItem.Instance
                });

            // Assert
            validations.ShouldBe(3);
        }

        [TestMethod]
        public void AddNewItemLvlPerm_WhenCalled_AddsNewRoleItem()
        {
            // Arrange
            ShimSPRoleDefinitionBindingCollection.AllInstances.AddSPRoleDefinition = (_, input) =>
            {
                if (input != null)
                {
                    validations += 1;
                }
            };
            ShimSPRoleAssignmentCollection.AllInstances.AddSPRoleAssignment = (_, input) =>
            {
                if (input != null)
                {
                    validations += 1;
                }
            };

            // Act
            privateObject.Invoke(
                AddNewItemLvlPermMethodName,
                publicInstance,
                new object[]
                {
                    spListItem.Instance,
                    spWeb.Instance,
                    SPRoleType.Administrator,
                    spUser.Instance
                });

            // Assert
            validations.ShouldBe(2);
        }

        [TestMethod]
        public void GetSafeGroupTitle_WhenCalled_ReturnsSafeGroupTitle()
        {
            // Arrange
            const string expected = "safe title to be tested";

            ShimCoreFunctions.GetSafeGroupTitleString = _ =>
            {
                validations += 1;
                return expected;
            };

            // Act
            var actual = (string)privateObject.Invoke(GetSafeGroupTitleMethodName, nonPublicInstance, new object[] { DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(expected),
                () => validations.ShouldBe(1));
        }
    }
}