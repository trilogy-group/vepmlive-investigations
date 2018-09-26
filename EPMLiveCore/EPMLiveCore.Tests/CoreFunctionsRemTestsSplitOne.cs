using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory.Fakes;
using System.DirectoryServices.Fakes;
using System.Fakes;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Navigation.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests
{
    [TestClass, ExcludeFromCodeCoverage]
    public partial class CoreFunctionsRemTests
    {
        private CoreFunctions testObject;
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private ShimSPWeb spWeb;
        private ShimSPSite spSite;
        private ShimSPList spList;
        private ShimSPListItem spListItem;
        private ShimSPField spField;
        private ShimSPUser spUser;
        private ShimSPFarm spFarm;
        private Guid guid;
        private const string DummyString = "DummyString";
        private const string SystemUserName = "Sharepoint\\System";
        private const string Username = "Domain\\User";
        private const string GuidString = "83e81819-0112-4c22-bb70-d8ba101e9e0c";
        private const string GetCleanUserNameWithDomainMethodName = "GetCleanUserNameWithDomain";
        private const string GetCleanUserNameMethodName = "GetCleanUserName";
        private const string GetRealUserNameMethodName = "GetRealUserName";
        private const string GetUserNameWithDomainMethodName = "GetUserNameWithDomain";
        private const string GetSafeUserTitleMethodName = "GetSafeUserTitle";
        private const string GetDomainMethodName = "getDomain";
        private const string GetScheduleStatusFieldMethodName = "GetScheduleStatusField";
        private const string GetDaysOverdueFieldMethodName = "GetDaysOverdueField";
        private const string GetDueFieldMethodName = "GetDueField";
        private const string GetUserStringMethodName = "getUserString";
        private const string DoesCurrentUserHaveFullControlMethodName = "DoesCurrentUserHaveFullControl";
        private const string CurrentUserIsInRoleMethodName = "CurrentUserIsInRole";
        private const string GetRealFieldMethodName = "getRealField";
        private const string GetItemXmlMethodName = "getItemXml";
        private const string SetFarmSettingMethodName = "setFarmSetting";

        [TestInitialize]
        public void Setup()
        {
            SetupShims();
            SetupShimsSplitTwo();

            testObject = new CoreFunctions();
            privateObject = new PrivateObject(testObject);
        }

        private void SetupShims()
        {
            shimsContext = ShimsContext.Create();

            SetupVariables();

            ShimSPFarm.LocalGet = () => spFarm;
            ShimSPProcessIdentity.AllInstances.UsernameGet = _ => Username;
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                ListItemVersionGet = () => new ShimSPListItemVersion()
            };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
        }

        private void SetupVariables()
        {
            guid = new Guid(GuidString);
            spFarm = new ShimSPFarm();
            spField = new ShimSPField();
            spList = new ShimSPList()
            {
                FieldsGet = () => new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = _ => spField
                },
                IDGet = () => guid
            };
            spListItem = new ShimSPListItem()
            {
                ParentListGet = () => spList,
                FieldsGet = () => new ShimSPFieldCollection(),
                IDGet = () => 1
            };
            spSite = new ShimSPSite()
            {
                WebApplicationGet = () => new ShimSPWebApplication()
                {
                    ApplicationPoolGet = () => new ShimSPApplicationPool()
                }
            };
            spUser = new ShimSPUser()
            {
                LoginNameGet = () => DummyString
            };
            spWeb = new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = _ => spList
                },
                SiteGet = () => spSite,
                CurrentUserGet = () => spUser,
                AllUsersGet = () => new ShimSPUserCollection()
                {
                    GetByIDInt32 = _ => spUser
                },
                IDGet = () => guid,
                WebsGet = () => new ShimSPWebCollection()
                {
                    AddStringStringStringUInt32StringBooleanBoolean = (_, _1, _2, _3, _4, _5, _6) => spWeb
                },
                NavigationGet = () => new ShimSPNavigation()
                {
                    TopNavigationBarGet = () => new ShimSPNavigationNodeCollection()
                    {
                        NavigationGet = () => new ShimSPNavigation()
                    }
                },
                SiteGroupsGet = () => new ShimSPGroupCollection()
                {
                    GetByIDInt32 = _ => new ShimSPGroup()
                },
                UrlGet = () => DummyString,
                ServerRelativeUrlGet = () => DummyString,
                TitleGet = () => DummyString
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void GetCleanUserNameWithDomain_SystemUser_ReturnsString()
        {
            // Arrange and Act
            var actual = (string)privateObject.Invoke(
                GetCleanUserNameWithDomainMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spWeb.Instance, SystemUserName });

            // Assert
            actual.ShouldBe(Username);
        }

        [TestMethod]
        public void GetCleanUserNameWithDomain_OtherUser_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.GetJustUsernameString = input => input;

            // Act
            var actual = (string)privateObject.Invoke(
                GetCleanUserNameWithDomainMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spWeb.Instance, Username });

            // Assert
            actual.ShouldBe(Username);
        }

        [TestMethod]
        public void GetCleanUserName_PrefixNotEmpty_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getPrefix = () => Username;
            ShimCoreFunctions.getMainDomain = () => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetCleanUserNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { Username });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetCleanUserName_PrefixEmpty_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getPrefix = () => string.Empty;
            ShimCoreFunctions.getMainDomain = () => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetCleanUserNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { Username });

            // Assert
            actual.ShouldBe(Username);
        }

        [TestMethod]
        public void GetRealUserName_WhenCalled_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getPrefix = () => Username;
            ShimCoreFunctions.getMainDomain = () => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetRealUserNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { Username });

            // Assert
            actual.ShouldBe($"{DummyString}\\");
        }

        [TestMethod]
        public void GetUserNameWithDomain_WhenCalled_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.GetJustUsernameString = input => input;
            ShimCoreFunctions.getMainDomain = () => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetUserNameWithDomainMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { DummyString });

            // Assert
            actual.ShouldBe($"{DummyString}\\{DummyString}");
        }

        [TestMethod]
        public void GetSafeUserTitle_WhenCalled_ReturnsString()
        {
            // Arrange

            // Act
            var actual = (string)privateObject.Invoke(
                GetSafeUserTitleMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { $"'''''''{DummyString}'''''''''{DummyString}" });

            // Assert
            actual.ShouldBe($"{DummyString}{DummyString}");
        }

        [TestMethod]
        public void GetCleanUserName_OverLoadPrefixNotEmpty_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getPrefixSPSite = _ => Username;
            ShimCoreFunctions.getMainDomain = () => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetCleanUserNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { Username, spSite.Instance });

            // Assert
            actual.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetCleanUserName_OverLoadPrefixEmpty_ReturnsString()
        {
            // Arrange
            ShimCoreFunctions.getPrefixSPSite = _ => string.Empty;
            ShimCoreFunctions.getMainDomain = () => DummyString;

            // Act
            var actual = (string)privateObject.Invoke(
                GetCleanUserNameMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { Username, spSite.Instance });

            // Assert
            actual.ShouldBe(Username);
        }

        [TestMethod]
        public void GetDomain_WhenCalled_ReturnsString()
        {
            // Arrange
            var expected = $"DC={DummyString},DC={DummyString}";

            ShimActiveDirectoryPartition.AllInstances.ToString01 = _ => $"{DummyString}.{DummyString}";
            ShimDomain.GetComputerDomain = () => new ShimDomain();

            // Act
            var actual = (string)privateObject.Invoke(
                GetDomainMethodName,
                BindingFlags.Static | BindingFlags.NonPublic,
                new object[] { });

            // Assert
            actual.ShouldBe(expected);
        }

        [TestMethod]
        public void GetScheduleStatusField_LatestVersionTrue_ReturnsString()
        {
            // Arrange
            spList.EnableVersioningGet = () => false;
            spListItem.ItemGetString = _ => $";#{DummyString}";
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, key) => true;

            // Act
            var actual = (string)privateObject.Invoke(
                GetScheduleStatusFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spListItem.Instance });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetScheduleStatusField_LatestVersionFalse_ReturnsString()
        {
            // Arrange
            spList.EnableVersioningGet = () => true;
            spListItem.VersionsGet = () => new ShimSPListItemVersionCollection();
            ShimSPListItemVersion.AllInstances.VersionIdGet = _ => 111;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, key) => true;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPListItemVersion>()
            {
                new ShimSPListItemVersion()
                {
                    ItemGetString = __ => $";#{DummyString}"
                }.Instance
            }.GetEnumerator();

            // Act
            var actual = (string)privateObject.Invoke(
                GetScheduleStatusFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spListItem.Instance });

            // Assert
            actual.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetDaysOverdueField_LatestVersionTrue_ReturnsString()
        {
            // Arrange
            const string dueDateString = "2018-09-20 16:55:00";
            const string todayString = "2018-09-24 16:55:00";

            var dueDate = DateTime.Parse(dueDateString);
            var today = DateTime.Parse(todayString);

            spList.EnableVersioningGet = () => false;
            spListItem.ItemGetString = _ => dueDate.ToString();
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, key) => true;
            ShimDateTime.NowGet = () => today;

            // Act
            var actual = (string)privateObject.Invoke(
                GetDaysOverdueFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spListItem.Instance });

            // Assert
            actual.ShouldBe("4");
        }

        [TestMethod]
        public void GetDaysOverdueField_LatestVersionFalse_ReturnsString()
        {
            // Arrange
            const string dueDateString = "2018-09-20 16:55:00";
            const string todayString = "2018-09-24 16:55:00";

            var dueDate = DateTime.Parse(dueDateString);
            var today = DateTime.Parse(todayString);

            spList.EnableVersioningGet = () => true;
            spListItem.VersionsGet = () => new ShimSPListItemVersionCollection();
            ShimSPListItemVersion.AllInstances.VersionIdGet = _ => 111;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, key) => true;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPListItemVersion>()
            {
                new ShimSPListItemVersion()
                {
                    ItemGetString = __ => dueDate.ToString()
                }.Instance
            }.GetEnumerator();
            ShimDateTime.NowGet = () => today;

            // Act
            var actual = (string)privateObject.Invoke(
                GetDaysOverdueFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spListItem.Instance });

            // Assert
            actual.ShouldBe("4");
        }

        [TestMethod]
        public void GetDueField_LatestVersionTrue_ReturnsString()
        {
            // Arrange
            const string dueDateString = "2018-12-20 16:55:00";
            const string todayString = "2018-09-24 16:55:00";

            var dueDate = DateTime.Parse(dueDateString);
            var today = DateTime.Parse(todayString);

            spList.EnableVersioningGet = () => false;
            spListItem.ItemGetString = _ => dueDate.ToString();
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, key) => true;
            ShimDateTime.NowGet = () => today;

            // Act
            var actual = (string)privateObject.Invoke(
                GetDueFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spListItem.Instance });

            // Assert
            actual.ShouldBe("(7) Future");
        }

        [TestMethod]
        public void GetDueField_LatestVersionFalse_ReturnsString()
        {
            // Arrange
            const string dueDateString = "2018-12-20 16:55:00";
            const string todayString = "2018-09-24 16:55:00";

            var dueDate = DateTime.Parse(dueDateString);
            var today = DateTime.Parse(todayString);

            spList.EnableVersioningGet = () => true;
            spListItem.VersionsGet = () => new ShimSPListItemVersionCollection();
            ShimSPListItemVersion.AllInstances.VersionIdGet = _ => 111;
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, key) => true;
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => new List<SPListItemVersion>()
            {
                new ShimSPListItemVersion()
                {
                    ItemGetString = __ => dueDate.ToString()
                }.Instance
            }.GetEnumerator();
            ShimDateTime.NowGet = () => today;

            // Act
            var actual = (string)privateObject.Invoke(
                GetDueFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spListItem.Instance });

            // Assert
            actual.ShouldBe("(7) Future");
        }

        [TestMethod]
        public void GetUserString_WhenCalled_ReturnsString()
        {
            // Arrange
            var methodHit = 0;

            spWeb.SiteUsersGet = () => new ShimSPUserCollection()
            {
                ItemGetString = _ =>
                {
                    methodHit = methodHit + 1;
                    if (methodHit > 1)
                    {
                        return new ShimSPUser()
                        {
                            IDGet = () => 111,
                            NameGet = () => DummyString
                        };
                    }

                    return null;
                },
                AddStringStringStringString = (_, _1, _2, _3) => { }
            };
            ShimCoreFunctions.getUserFromADString = _ => new ShimDirectoryEntry()
            {
                PropertiesGet = () => new ShimPropertyCollection()
                {
                    ItemGetString = __ => new ShimPropertyValueCollection()
                    {
                        ValueGet = () => DummyString
                    }
                }
            };

            // Act
            var actual = (string)privateObject.Invoke(
                GetUserStringMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { DummyString, spWeb.Instance, DummyString });

            // Assert
            actual.ShouldBe($"111;#{DummyString}");
        }

        [TestMethod]
        public void DoesCurrentUserHaveFullControl_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            spWeb.RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection()
            {
                ItemGetString = _ => new ShimSPRoleDefinition()
            };
            ShimSPSecurableObject.AllInstances.AllRolesForCurrentUserGet = _ => new ShimSPRoleDefinitionBindingCollection()
            {
                ContainsSPRoleDefinition = __ => true
            };
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;

            // Act
            var actual = (bool)privateObject.Invoke(
                DoesCurrentUserHaveFullControlMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spWeb.Instance });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void CurrentUserIsInRole_WhenCalled_ReturnsBoolean()
        {
            // Arrange
            spWeb.RoleDefinitionsGet = () => new ShimSPRoleDefinitionCollection()
            {
                ItemGetString = _ => new ShimSPRoleDefinition()
            };
            ShimSPSecurableObject.AllInstances.AllRolesForCurrentUserGet = _ => new ShimSPRoleDefinitionBindingCollection()
            {
                ContainsSPRoleDefinition = __ => true
            };

            // Act
            var actual = (bool)privateObject.Invoke(
                CurrentUserIsInRoleMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spWeb.Instance, string.Empty });

            // Assert
            actual.ShouldBeTrue();
        }

        [TestMethod]
        public void GetRealField_WhenCalled_ReturnsSPField()
        {
            // Arrange
            const string schemaXml = @"<child DisplayNameSrcField=""ParentField""/>";

            var field = new ShimSPField()
            {
                TypeGet = () => SPFieldType.Computed,
                SchemaXmlGet = () => schemaXml,
                ParentListGet = () => spList
            };

            spField.InternalNameGet = () => DummyString;

            // Act
            var actual = (SPField)privateObject.Invoke(
                GetRealFieldMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { field.Instance });

            // Assert
            actual.InternalName.ShouldBe(DummyString);
        }

        [TestMethod]
        public void GetItemXml_WhenCalled_ReturnsString()
        {
            // Arrange
            const string dateInput = "2018-09-24 10:10:10";

            var hashFields = new Hashtable()
            {
                ["DateTime"] = "DateTime",
                ["User"] = "User",
                ["Number"] = "Number",
                ["Boolean"] = "Boolean",
                ["Calculated"] = "Calculated",
                [DummyString] = DummyString
            };
            var properties = new ShimSPItemEventDataCollection()
            {
                ItemGetString = key =>
                {
                    if (key == "User")
                    {
                        return 1;
                    }
                    return dateInput;
                }
            };
            var customFields = new Dictionary<string, SPFieldType>()
            {
                ["DateTime"] = SPFieldType.DateTime,
                ["User"] = SPFieldType.User,
                ["Number"] = SPFieldType.Number,
                ["Boolean"] = SPFieldType.Boolean,
                ["Calculated"] = SPFieldType.Calculated,
                [DummyString] = SPFieldType.Attachments
            };

            spListItem.ParentListGet = () => spList;
            spListItem.TitleGet = () => DummyString;
            spListItem.ItemGetString = _ => DummyString;
            spListItem.ItemGetGuid = _ => DummyString;
            spList.ParentWebGet = () => spWeb;
            spList.FieldsGet = () => new ShimSPFieldCollection()
            {
                GetFieldByInternalNameString = key =>
                {
                    spField.TypeGet = () => customFields[key];
                    return spField;
                }
            };
            spField.IdGet = () => guid;
            spField.GetFieldValueString = _ => DummyString;
            spField.GetFieldValueAsTextObject = _ => DummyString;
            spField.GetFieldValueString = _ => DummyString;

            // Act
            var actual = XDocument.Parse((string)privateObject.Invoke(
                GetItemXmlMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { spListItem.Instance, hashFields, properties.Instance, spWeb.Instance }));

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.Element("Item").Attribute("ItemId").Value.ShouldBe($"{guid}.{guid}.1"),
                () => actual.Element("Item").Element("Title").Value.ShouldBe(dateInput),
                () => actual.Element("Item").Elements("Field").Count().ShouldBe(6),
                () => actual.Element("Item").Elements("Field").Where(x => x.Attribute("Name").Value.Equals("Boolean")).FirstOrDefault().Value.ShouldBe("0"));
        }

        [TestMethod]
        public void SetFarmSetting_SettingPresent_ReturnsString()
        {
            // Arrange
            var methodHit = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable()
            {
                [DummyString] = DummyString
            };
            spFarm.Update = () =>
            {
                methodHit = true;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                SetFarmSettingMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(string.Empty),
                () => methodHit.ShouldBeTrue());
        }

        [TestMethod]
        public void SetFarmSetting_SettingNotPresent_ReturnsString()
        {
            // Arrange
            var methodHit = false;

            ShimSPPersistedObject.AllInstances.PropertiesGet = _ => new Hashtable();
            spFarm.Update = () =>
            {
                methodHit = true;
            };

            // Act
            var actual = (string)privateObject.Invoke(
                SetFarmSettingMethodName,
                BindingFlags.Static | BindingFlags.Public,
                new object[] { DummyString, DummyString });

            // Assert
            actual.ShouldSatisfyAllConditions(
                () => actual.ShouldBe(string.Empty),
                () => methodHit.ShouldBeTrue());
        }
    }
}