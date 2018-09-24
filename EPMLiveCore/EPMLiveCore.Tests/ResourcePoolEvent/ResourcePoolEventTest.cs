using System;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.IO.Fakes;
using System.Reflection;
using System.Web.UI.WebControls.Fakes;
using EPMLive;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.ResourcePoolEvent
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ResourcePoolEventTest
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private EPMLiveCore.ResourcePoolEvent _resourcePoolEvent;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private const int LookUpId = -1;
        private const string AddUserCheck = "0;#";
        
        private const string ItemAdding = "ItemAdding";
        private const string GetProperty = "GetProperty";
        private const string ProcessItem = "processItem";
        private const string ProcessDepartment = "ProcessDepartment";
        private const string ProcessLevel = "ProcessLevel";
        private const string GetPropertyBeforeOrAfter = "GetPropertyBeforeOrAfter";
        private const string DisableAccount = "disableAccount";
        private const string AddUserToAccount = "addUserToAccount";
        private const string GetTempPassword = "getTempPassword";
        private const string SendRequestEmail = "sendRequestEmail";
        private const string SendOwnerEmail = "sendOwnerEmail";
        private const string AddUser = "addUser";
        private const string ItemUpdating = "ItemUpdating";
        private const string ItemDeleting = "ItemDeleting";
        private const string CreateGroup = "createGroup";
        private const string ProcessOnlineUser = "ProcessOnlineUser";

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();

            _resourcePoolEvent = new EPMLiveCore.ResourcePoolEvent();
            _privateObject = new PrivateObject(_resourcePoolEvent);
            _privateType = new PrivateType(typeof(EPMLiveCore.ResourcePoolEvent));
            InitializeSetUp();
        }

        private void InitializeSetUp()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimSPSite.ConstructorGuid = (_, _1) => new ShimSPSite();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPWebApplication.AllInstances.FeaturesGet = _ => new ShimSPFeatureCollection();
            ShimSPFeatureCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPFeature();
            ShimSqlConnection.ConstructorString = (_, _1) => new ShimSqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlCommand.ConstructorStringSqlConnection = (_, _1, _2) => new ShimSqlCommand();
            ShimSqlCommand.AllInstances.ParametersGet = _ => new ShimSqlParameterCollection()
            {
                AddWithValueStringObject = (_1,_2) =>new SqlParameter()
                {
                    Value = new object()
                }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => DummyInt;
            ShimDataSet.Constructor = _ => new ShimDataSet();
            ShimSqlDataAdapter.ConstructorSqlCommand = (_, _1) => new ShimSqlDataAdapter();
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, _1) => 1;
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader()
            {
                GetGuidInt32 = _1 => new Guid(),
                GetStringInt32 = _1 => DummyString,
                GetBooleanInt32 = _1 => false
            };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, _1) => DummyInt;
            ShimSPItemEventProperties.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection();
            ShimSPItemEventProperties.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPItemEventProperties.AllInstances.ListGet = _ => new ShimSPList();
            ShimSPEventPropertiesBase.AllInstances.SiteIdGet = _ => new Guid();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValue();
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.SiteGroupsGet = _ => new ShimSPGroupCollection()
            {
                ItemGetString = _1 => new ShimSPGroup()
                {
                    IDGet = () => DummyInt,
                    NameGet = () => DummyString
                }
            };
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection()
            {
                ItemGetString = x => new ShimSPList()
                {
                    GetItemByIdInt32 = y => new ShimSPListItem()
                    {
                        SystemUpdate = () => { }
                    }
                }
            };
            ShimSPWeb.AllInstances.EnsureUserString = (_, _1) => new ShimSPUser();
            ShimSPFieldLookupValue.ConstructorString = (_, _1) => new ShimSPFieldLookupValue();
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimSPEventPropertiesBase.AllInstances.SiteIdGet = _ => new Guid();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject?.Dispose();
        }
        
        [TestMethod]
        public void ItemAdding_SPItemEventPropertiesIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimDataTableCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataTable();
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataRow()
            {
                ItemGetInt32 = x => DummyInt
            };
            ShimCoreFunctions.getContractLevelSPSite = _ => DummyString;
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => "true";
            ShimSPListItem.AllInstances.ItemGetString = (_, _1) => "true";
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            ShimComponent.AllInstances.Dispose = _ => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                ItemAdding,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void GetProperty_SPItemEventPropertiesAndPropertyIsNotNull_ReturnProperty()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, DummyString };
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => null;
            ShimSPListItem.AllInstances.ItemGetString = (_, _1) => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                GetProperty,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ProcessItem_SPItemEventPropertiesAndIsTrueIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, true };
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => "false";
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimAPITeam.GetWebGroupsSPWeb = _ => new List<SPGroup>() { new ShimSPGroup() };
            ShimSPGroup.AllInstances.RemoveUserSPUser = (_, _1) => { };
            ShimSPGroup.AllInstances.AddUserSPUser = (_, _1) => { };

            // Act
            var actualResult = _privateObject.Invoke(
               ProcessItem,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        private void ProcessItemSetup()
        {
            _privateObject.SetFieldOrProperty("isOnline", true);
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => "false";
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            ShimComponent.AllInstances.Dispose = _ => { };
            ShimAPITeam.GetWebGroupsSPWeb = _ => new List<SPGroup>() { new ShimSPGroup() };
            ShimSPGroup.AllInstances.RemoveUserSPUser = (_, _1) => { };
            ShimSPGroup.AllInstances.AddUserSPUser = (_, _1) => { };
            var count = 0;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) =>
            {
                count++;
                if (count == 3)
                {
                    return null;
                }
                else
                {
                    return DummyString;
                }
            };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => LookUpId;
            ShimSPEventPropertiesBase.AllInstances.SiteIdGet = _ => new Guid();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimTimer.EnqueueGuidInt32SPSite = (_, _1, _2) => { };
        }

        [TestMethod]
        public void ProcessItem_SPItemEventPropertiesAndIsTrueIsNotNullAndAfterPropertiesAreNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, true };
            ProcessItemSetup();
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            
            // Act
            var actualResult = _privateObject.Invoke(
               ProcessItem,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessItem_SPItemEventPropertiesAndIsTrueIsNotNullAndLookupIdIsNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, true };
            ProcessItemSetup();
            ShimSPFieldUserValue.AllInstances.UserGet = _ => null;
            ShimTimer.AddTimerJobGuidGuidStringInt32StringStringInt32Int32String =
                (_, _1, _2, _3, _4, _5, _6, _7, _8) => new Guid();

            // Act
            var actualResult = _privateObject.Invoke(
               ProcessItem,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessDepartment_SPItemEventPropertiesIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance};
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection()
            {
                ItemGetString = x => DummyString
            };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            ShimSPItemEventProperties.AllInstances.WebGet = _ => new ShimSPWeb()
            {
                ListsGet = () => new ShimSPListCollection()
                {
                    ItemGetString = x => new ShimSPList()
                    {
                        GetItemByIdInt32 = y => new ShimSPListItem()
                        {
                            ItemGetString = z => DummyString
                        }
                    }
                }
            };
            ShimSPGroup.AllInstances.AddUserSPUser = (_, _1) => new ShimSPUser();
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();

            // Act
            var actualResult = _privateObject.Invoke(
               ProcessDepartment,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessLevel_SPItemEventPropertiesIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection()
            {
                ItemGetString = x => DummyInt.ToString()
            };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => LookUpId;
            ShimCoreFunctions.GetRealUserNameString = _ => DummyString;
            ShimSPFieldLookupValue.AllInstances.LookupValueGet = _ => DummyString;
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimAct.AllInstances.SetUserLevelV3StringInt32 = (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
               ProcessLevel,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessLevel_SPItemEventPropertiesIsNotNullAndIdNotMatched_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection()
            {
                ItemGetString = x => DummyInt.ToString()
            };
            ShimCoreFunctions.GetRealUserNameStringSPSite = (_, _1) => DummyString;
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimAct.AllInstances.SetUserLevelV3StringInt32 = (_, _1, _2) => { };
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValue();
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
               ProcessLevel,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void GetPropertyBeforeOrAfter_SPItemEventPropertiesAndFieldIsNotNull_ReturnProperty()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, DummyString };
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection()
            {
                ItemGetString = x => null
            };
            ShimSPItemEventProperties.AllInstances.ListItemGet = _ => new ShimSPListItem()
            {
                ItemGetString = x => DummyString
            };

            // Act
            var actualResult = _privateObject.Invoke(
               GetPropertyBeforeOrAfter,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void DisableAccount_SPItemEventPropertiesIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection()
            {
                ItemGetString = x => "true"
            };
            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ => true;
            ShimSPEventPropertiesBase.AllInstances.SiteIdGet = _ => new Guid();
            var listSpGroup = new List<SPGroup>() { new ShimSPGroup() };
            ShimSPWeb.AllInstances.SiteGroupsGet = _ => new ShimSPGroupCollection().Bind(listSpGroup);
            ShimSPGroup.AllInstances.RemoveUserSPUser = (_, _1) => new ShimSPUser();
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ => new ShimSPRoleAssignmentCollection();
            ShimSPRoleAssignmentCollection.AllInstances.RemoveSPPrincipal = (_, _1) => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
               DisableAccount,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void DisableAccount_SPItemEventPropertiesIsNotNullAndUserControlIsFalse_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection()
            {
                ItemGetString = x => "true"
            };
            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ => false;
            ShimSPItemEventProperties.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetGuid = (_, _1) => DummyString;
            ShimSPItemEventProperties.AllInstances.ListGet = _ => new ShimSPList()
            {
                FieldsGet = ()=> new ShimSPFieldCollection()
                {
                    GetFieldByInternalNameString = x => new ShimSPField()
                    {
                        IdGet = () => new Guid()
                    }
                }
            };
            
            // Act
            var actualResult = _privateObject.Invoke(
               DisableAccount,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void AddUserToAccount_FirstNameLastNameUsernameAndEmailIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { DummyString, DummyString, DummyString, DummyString };
            
            // Act
            var actualResult = _privateObject.Invoke(
               AddUserToAccount,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        private void GetTempPasswordSetup()
        {
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataRow()
            {
                ItemGetInt32 = x => DummyString
            };
            ShimDataSet.Constructor = _ => new ShimDataSet();
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection();
            ShimDataTableCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataTable();
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimDataRowCollection.AllInstances.CountGet = _ => DummyInt;
        }

        [TestMethod]
        public void GetTempPassword_UsernamelIsNotNull_ReturnPassword()
        {
            // Arrange
            var parameters = new object[] { DummyString };
            GetTempPasswordSetup();

            // Act
            var actualResult = _privateObject.Invoke(
               GetTempPassword,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void SendRequestEmail_SPItemEventPropertiesAndRequestorNameIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { typeof(string), new ShimSPItemEventProperties().Instance, DummyString };
            var listSPUser = new List<SPUser>() { new ShimSPUser() };
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection().Bind(listSPUser);
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimSPUser.AllInstances.EmailGet = _ => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
               SendRequestEmail,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        private void SendOwnerEmailSetup()
        {
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection();
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => DummyString;
            ShimCoreFunctions.getLockConfigSettingSPWebStringBoolean = (_, _1, _2) => DummyString;
            _privateObject.SetFieldOrProperty("owneremail", DummyString);
        }

        [TestMethod]
        public void SendOwnerEmail_SPItemEventPropertiesAndRequestorNameIsNotNull_ThrowException()
        {
            // Arrange
            var parameters = new object[] { typeof(string), new ShimSPItemEventProperties().Instance, DummyString };
            SendOwnerEmailSetup();

            // Act
            Action act = () => _privateObject.Invoke(
               SendOwnerEmail,
               parameters);

            // Assert
            Should.Throw<Exception>(act);
        }

        private void AdduserSetup()
        {
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimSPSite.AllInstances.OpenWebGuid = (_, _1) => new ShimSPWeb();
            ShimSPWeb.AllInstances.AllUsersGet = _ => new ShimSPUserCollection();
            var count = 0;
            ShimSPUserCollection.AllInstances.ItemGetString = (_, _1) =>
            {
                count++;
                if (count == 1)
                {
                    return null;
                }
                else
                {
                    return new ShimSPUser();
                }
            };
        }

        [TestMethod]
        public void AddUser_SPItemEventPropertiesUsernameAndEmailIsNotNull_ReturnAddedUser()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, DummyString, DummyString, DummyString, DummyString };
            AdduserSetup();

            // Act
            var actualResult = _privateObject.Invoke(
               AddUser,
               parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldNotBeNull(),
                () => actualResult.ShouldBe(AddUserCheck));
        }

        [TestMethod]
        public void ItemUpdating_SPItemEventPropertiesIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimDataTableCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataTable();
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, _1) => new ShimDataRow()
            {
                ItemGetInt32 = x => DummyInt
            };
            ShimCoreFunctions.getContractLevelSPSite = _ => DummyString;
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };

            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => "true";
            ShimSPListItem.AllInstances.ItemGetString = (_, _1) => "true";
            ShimExtensionMethods.ContainsFieldWithInternalNameSPFieldCollectionString = (_, _1) => true;
            ShimComponent.AllInstances.Dispose = _ => { };
            _privateObject.SetFieldOrProperty("isOnline", true);

            // Act
            var actualResult = _privateObject.Invoke(
                ItemUpdating,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ItemDeleting_SPItemEventPropertiesIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ => true;
            ShimCoreFunctions.GetCleanUserNameWithDomainSPWebString = (_, _1) => DummyString;
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSPItemEventProperties.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (_, _1) => DummyInt.ToString();
            ShimSPFieldUserValue.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValue();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.RemoveByIDInt32 = (_, _1) => { };
            ShimSPFieldLookupValue.AllInstances.LookupIdGet = _ => DummyInt;
            WorkEnginePPM.Core.ResourceManagement.Fakes.ShimUtilities.PerformDeleteResourceCheckInt32GuidSPWebStringOutStringOut =
                (int extId, 
                Guid dataId, 
                SPWeb spWeb,
                out string deleteResourceCheckStatus,
                out string deleteResourceCheckMessage) =>
                {
                    deleteResourceCheckMessage = DummyString;
                    deleteResourceCheckStatus = DummyString;
                    return true;
                };

            // Act
            var actualResult = _privateObject.Invoke(
                ItemDeleting,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ItemDeleting_SPItemEventPropertiesIsNotNullAndCurrentUserControlIsFalse_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            ShimCoreFunctions.DoesCurrentUserHaveFullControlSPWeb = _ => false;

            // Act
            var actualResult = _privateObject.Invoke(
                ItemDeleting,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void CreateGroup_SPItemEventPropertiesIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance };
            var count = 0;
            ShimSPWeb.AllInstances.SiteGroupsGet = _ =>
            {
                count++;
                if (count == 1)
                {
                    return null;
                }
                else
                {
                    return new ShimSPGroupCollection();
                }
            };
            ShimSPGroupCollection.AllInstances.AddStringSPMemberSPUserString = (_, _1, _2, _3, _4) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                CreateGroup,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessOnlineUser_SPItemEventPropertiesIsNotNullAndIsTrueAndExpiredIsTrue_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, true };
            ShimSPItemEventProperties.AllInstances.UserLoginNameGet = _ => DummyString;
            ShimSPItemEventProperties.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, _1) => new ShimSPUser();
            ShimSPItemEventProperties.AllInstances.CurrentUserIdGet = _ => DummyInt;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, _1) => "true";
            
            // Act
            var actualResult = _privateObject.Invoke(
                ProcessOnlineUser,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        private void ProcessOnlineUserSetup()
        {
            ShimSPItemEventProperties.AllInstances.UserLoginNameGet = _ => DummyString;
            ShimSPItemEventProperties.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection();
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, _1) => new ShimSPUser();
            ShimSPItemEventProperties.AllInstances.CurrentUserIdGet = _ => DummyInt;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, _1) => "true";

            _privateObject.SetFieldOrProperty("expired", false);
            _privateObject.SetFieldOrProperty("max", DummyInt);

            ShimCoreFunctions.getPrefixSPSite = _ => DummyString;
            ShimSPItemEventProperties.AllInstances.AfterPropertiesGet = _ => new ShimSPItemEventDataCollection();
            EPMLiveAccountManagement.Fakes.ShimFindOrCreateAccount.FindUserNameString = _ => string.Empty;
            EPMLiveAccountManagement.Fakes.ShimFindOrCreateAccount.CreateAccountStringStringStringGuidBoolean =
                (_, _1, _2, _3, _4) => "0: " + DummyString;
            EPMLiveAccountManagement.Fakes.ShimFindOrCreateAccount.sendEmailInt32StringStringArray =
                (_, _1, _2) => true;
            AdduserSetup();
            ShimSqlDataReader.AllInstances.Read = _ => true;
            ShimSqlDataReader.AllInstances.Close = _ => { };

            ShimSPFieldUserValue.ConstructorSPWebString = (_, _1, _2) => new ShimSPFieldUserValue();
            ShimSPFieldUserValue.AllInstances.UserGet = _ => new ShimSPUser();
            ShimAPITeam.GetWebGroupsSPWeb = _ => new List<SPGroup>() { new ShimSPGroup() };
            ShimSPGroup.AllInstances.RemoveUserSPUser = (_, _1) => { };
            ShimSPGroup.AllInstances.AddUserSPUser = (_, _1) => { };
        }

        [TestMethod]
        public void ProcessOnlineUser_SPItemEventPropertiesIsNotNullAndIsTrueAndExpiredIsFalse_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, true };
            ProcessOnlineUserSetup();
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessOnlineUser,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessOnlineUser_SPItemEventPropertiesIsNotNullAndIsTrueAndFoundUserIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, true };
            ProcessOnlineUserSetup();
            EPMLiveAccountManagement.Fakes.ShimFindOrCreateAccount.FindUserNameString = _ => DummyString;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, _1) => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessOnlineUser,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        private void ProcessOnlineUserCounterSetup()
        {
            ProcessOnlineUserSetup();
            GetTempPasswordSetup();
            EPMLiveAccountManagement.Fakes.ShimFindOrCreateAccount.FindUserNameString = _ => DummyString;
            ShimSPUser.AllInstances.IsSiteAdminGet = _ => true;
            ShimSPItemEventProperties.AllInstances.ListItemGet = _ => new ShimSPListItem();
            ShimSPListItem.AllInstances.ItemGetString = (_, _1) => DummyString;
            ShimSPItemEventDataCollection.AllInstances.ItemGetString = (_, strVal) =>
            {
                if (strVal == "Approved")
                {
                    return null;
                }
                else
                {
                    return DummyString;
                }
            };
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (_, _1) => 2;
        }

        [TestMethod]
        public void ProcessOnlineUser_SPItemEventPropertiesIsNotNullAndIsFalseAndFoundUserIsNotNull_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, false };
            ProcessOnlineUserCounterSetup();
            _privateObject.SetFieldOrProperty("count", -1);

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessOnlineUser,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessOnlineUser_SPItemEventPropertiesIsNotNullAndIsFalseAndFoundUserIsNotNullExceptionHandled_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, false };
            ProcessOnlineUserCounterSetup();
            _privateObject.SetFieldOrProperty("count", 2);

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessOnlineUser,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }

        [TestMethod]
        public void ProcessOnlineUser_SPItemEventPropertiesIsNotNullAndIsFalseAndFoundUserIsNotNullCounterIsGreater_ReturnNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPItemEventProperties().Instance, false };
            ProcessOnlineUserCounterSetup();
            SendOwnerEmailSetup();
            _privateObject.SetFieldOrProperty("count", 2);

            // Act
            var actualResult = _privateObject.Invoke(
                ProcessOnlineUser,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _privateObject.ShouldNotBeNull(),
                () => actualResult.ShouldBeNull());
        }
    }
}
