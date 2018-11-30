using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using EPMLiveCore.Jobs;
using EPMLiveCore.Jobs.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            
            ShimComponent.AllInstances.Dispose = _ => { };            
            ShimSPSite.AllInstances.Dispose = _ => { };
            ShimSPWeb.AllInstances.Dispose = _ => { };
            ShimSPFieldLookupValue.ConstructorString = (_, __) => new ShimSPFieldLookupValue();
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, __) => spUser;
            ShimEnhancedLookupConfigValuesHelper.ConstructorString = (_, __) => new ShimEnhancedLookupConfigValuesHelper();
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ => new ShimSPRoleAssignmentCollection();
            ShimSPRoleAssignment.ConstructorSPPrincipal = (_, __) => new ShimSPRoleAssignment();
            ShimSPRoleDefinition.Constructor = _ => new ShimSPRoleDefinition();
            ShimSPRoleDefinitionCollection.AllInstances.GetByTypeSPRoleType = (_, __) => new ShimSPRoleDefinition();
            ShimSPRoleAssignment.AllInstances.RoleDefinitionBindingsGet = _ => new ShimSPRoleDefinitionBindingCollection();
            ShimReportData.ConstructorGuid = (_, __) => new ShimReportData();
            ShimReportData.AllInstances.Dispose = _ => { };
            ShimReportData.AllInstances.GetClientReportingConnection = _ => new ShimSqlConnection();
            ShimSqlCommand.ConstructorStringSqlConnection = (_, query, _2) => new SqlCommand(query);
            ShimSqlCommand.AllInstances.ExecuteReader = _ => dataReader;
            ShimSPRoleDefinitionCollection.AllInstances.GetByIdInt32 = (_, __) => new ShimSPRoleDefinition();
            ShimSPGroupCollection.AllInstances.GetByIDInt32 = (_, __) => new ShimSPGroup();
        }

        private void SetupVariables()
        {
            validations = 0;
            publicInstance = BindingFlags.Instance | BindingFlags.Public;
            nonPublicInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            guid = Guid.Parse(SampleGuidString1);
            spWeb = new ShimSPWeb()
            {
                IDGet = () => guid,
                ListsGet = () => spListCollection,
                AllowUnsafeUpdatesSetBoolean = _ => { },
                AllUsersGet = () => new ShimSPUserCollection(),
                SiteGroupsGet = () => new ShimSPGroupCollection(),
                RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection()
            };
            spSite = new ShimSPSite()
            {
                IDGet = () => guid
            };
            spListCollection = new ShimSPListCollection()
            {
                ItemGetGuid = _ => spList
            };
            spList = new ShimSPList()
            {
                IDGet = () => guid,
                FieldsGet = () => spFieldCollection,
                GetItemByIdInt32 = _ => spListItem
            };
            spListItemCollection = new ShimSPListItemCollection();
            spListItem = new ShimSPListItem()
            {
                IDGet = () => DummyInt,
                TitleGet = () => DummyString,
                ItemGetString = _ => DummyString
            };
            spFieldCollection = new ShimSPFieldCollection();
            spField = new ShimSPField();
            spUser = new ShimSPUser();
            dataReader = new ShimSqlDataReader()
            {
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