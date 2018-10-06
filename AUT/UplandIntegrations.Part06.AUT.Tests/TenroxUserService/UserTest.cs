using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using UplandIntegrations.TenroxUserService;
using User = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.User" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class UserTest : AbstractBaseSetupV3Test
    {
        public UserTest() : base(typeof(User))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (User) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccountSetId = "AccountSetId";
        private const string PropertyActiveSite = "ActiveSite";
        private const string PropertyActiveSiteId = "ActiveSiteId";
        private const string PropertyActualGroupManagers = "ActualGroupManagers";
        private const string PropertyAddressLine1 = "AddressLine1";
        private const string PropertyAddressLine2 = "AddressLine2";
        private const string PropertyAlternateGroupManagers = "AlternateGroupManagers";
        private const string PropertyAlternatePhoneNumber = "AlternatePhoneNumber";
        private const string PropertyApprovalGroup = "ApprovalGroup";
        private const string PropertyApprovalGroupId = "ApprovalGroupId";
        private const string PropertyAssignments = "Assignments";
        private const string PropertyBadgeNumber = "BadgeNumber";
        private const string PropertyCanEnterTimeUsingPunch = "CanEnterTimeUsingPunch";
        private const string PropertyCanFilterActivities = "CanFilterActivities";
        private const string PropertyCanReportOnAnyClient = "CanReportOnAnyClient";
        private const string PropertyCanReportOnAnyGroup = "CanReportOnAnyGroup";
        private const string PropertyCanReportOnAnyProject = "CanReportOnAnyProject";
        private const string PropertyCanReportOnAnyUser = "CanReportOnAnyUser";
        private const string PropertyCity = "City";
        private const string PropertyClients = "Clients";
        private const string PropertyComponentId = "ComponentId";
        private const string PropertyCountry = "Country";
        private const string PropertyDateHired = "DateHired";
        private const string PropertyDateOfBirth = "DateOfBirth";
        private const string PropertyDefaultClientId = "DefaultClientId";
        private const string PropertyDefaultProjectId = "DefaultProjectId";
        private const string PropertyDefaultTaskId = "DefaultTaskId";
        private const string PropertyDefaultWorktypeId = "DefaultWorktypeId";
        private const string PropertyDescription = "Description";
        private const string PropertyEmail = "Email";
        private const string PropertyExpenseEntries = "ExpenseEntries";
        private const string PropertyExpenseReports = "ExpenseReports";
        private const string PropertyExpenseReportsCreated = "ExpenseReportsCreated";
        private const string PropertyExpenseWorkflowId = "ExpenseWorkflowId";
        private const string PropertyFaxNumber = "FaxNumber";
        private const string PropertyFirstName = "FirstName";
        private const string PropertyForcastBillable = "ForcastBillable";
        private const string PropertyForcastCosted = "ForcastCosted";
        private const string PropertyFullName = "FullName";
        private const string PropertyFunctionalGroup = "FunctionalGroup";
        private const string PropertyFunctionalGroupId = "FunctionalGroupId";
        private const string PropertyFunctionalGroupManagers = "FunctionalGroupManagers";
        private const string PropertyGender = "Gender";
        private const string PropertyHasProjectScheduling = "HasProjectScheduling";
        private const string PropertyHolidaySet = "HolidaySet";
        private const string PropertyHolidaySetId = "HolidaySetId";
        private const string PropertyIMPassword = "IMPassword";
        private const string PropertyIMSignin = "IMSignin";
        private const string PropertyId = "Id";
        private const string PropertyIsDefaultUser = "IsDefaultUser";
        private const string PropertyIsFirstLogin = "IsFirstLogin";
        private const string PropertyLanguage = "Language";
        private const string PropertyLastEvaluationDate = "LastEvaluationDate";
        private const string PropertyLastName = "LastName";
        private const string PropertyLastNavigationPage = "LastNavigationPage";
        private const string PropertyLastVisitedLeftId = "LastVisitedLeftId";
        private const string PropertyLastVisitedRootId = "LastVisitedRootId";
        private const string PropertyLastVisitedURLSect = "LastVisitedURLSect";
        private const string PropertyLeaveTimeUserHistory = "LeaveTimeUserHistory";
        private const string PropertyLoginName = "LoginName";
        private const string PropertyManagedBusinessUnits = "ManagedBusinessUnits";
        private const string PropertyMaritalStatus = "MaritalStatus";
        private const string PropertyMasterSite = "MasterSite";
        private const string PropertyMasterSiteId = "MasterSiteId";
        private const string PropertyMenuOptions = "MenuOptions";
        private const string PropertyMobileNumber = "MobileNumber";
        private const string PropertyNextEvaluationDate = "NextEvaluationDate";
        private const string PropertyOfflinePermissions = "OfflinePermissions";
        private const string PropertyOutOfOffice = "OutOfOffice";
        private const string PropertyOverrideGlobalSettings = "OverrideGlobalSettings";
        private const string PropertyPagerNumber = "PagerNumber";
        private const string PropertyPassword = "Password";
        private const string PropertyPasswordLastChangedOn = "PasswordLastChangedOn";
        private const string PropertyPasswordNumberOfRetries = "PasswordNumberOfRetries";
        private const string PropertyPlanningRoles = "PlanningRoles";
        private const string PropertyPostalCode = "PostalCode";
        private const string PropertyProjectActualManagerId = "ProjectActualManagerId";
        private const string PropertyProjectAlternateManager = "ProjectAlternateManager";
        private const string PropertyProjectManager = "ProjectManager";
        private const string PropertyProjectSchedulingId = "ProjectSchedulingId";
        private const string PropertyPurchasingWorkflowId = "PurchasingWorkflowId";
        private const string PropertyQuickLinksOptions = "QuickLinksOptions";
        private const string PropertyRequisitionWorkflowId = "RequisitionWorkflowId";
        private const string PropertyResourceGroup = "ResourceGroup";
        private const string PropertyResourceGroupId = "ResourceGroupId";
        private const string PropertyResourceType = "ResourceType";
        private const string PropertyResourceTypeHistory = "ResourceTypeHistory";
        private const string PropertySecurity = "Security";
        private const string PropertyServiceDate = "ServiceDate";
        private const string PropertySocialInsuranceNumber = "SocialInsuranceNumber";
        private const string PropertyState = "State";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTagAssociation = "TagAssociation";
        private const string PropertyTelephoneNumber = "TelephoneNumber";
        private const string PropertyTerminationDate = "TerminationDate";
        private const string PropertyTimesheetWorkflowId = "TimesheetWorkflowId";
        private const string PropertyTitle = "Title";
        private const string PropertyTitleId = "TitleId";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUserAccessStatus = "UserAccessStatus";
        private const string PropertyUserBusinessUnits = "UserBusinessUnits";
        private const string PropertyUserGroup = "UserGroup";
        private const string PropertyUserLeaveTime = "UserLeaveTime";
        private const string PropertyUserResourceType = "UserResourceType";
        private const string PropertyUserSkills = "UserSkills";
        private const string PropertyUserType = "UserType";
        private const string PropertyViewAllActivities = "ViewAllActivities";
        private const string PropertyWebSite = "WebSite";
        private const string PropertyWillRelocate = "WillRelocate";
        private const string PropertyWillRelocateIfInterested = "WillRelocateIfInterested";
        private const string PropertyWillTravel = "WillTravel";
        private const string PropertyWillTravelIfInterested = "WillTravelIfInterested";
        private const string PropertyWorkflowId = "WorkflowId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccountSetIdField = "AccountSetIdField";
        private const string FieldActiveSiteField = "ActiveSiteField";
        private const string FieldActiveSiteIdField = "ActiveSiteIdField";
        private const string FieldActualGroupManagersField = "ActualGroupManagersField";
        private const string FieldAddressLine1Field = "AddressLine1Field";
        private const string FieldAddressLine2Field = "AddressLine2Field";
        private const string FieldAlternateGroupManagersField = "AlternateGroupManagersField";
        private const string FieldAlternatePhoneNumberField = "AlternatePhoneNumberField";
        private const string FieldApprovalGroupField = "ApprovalGroupField";
        private const string FieldApprovalGroupIdField = "ApprovalGroupIdField";
        private const string FieldAssignmentsField = "AssignmentsField";
        private const string FieldBadgeNumberField = "BadgeNumberField";
        private const string FieldCanEnterTimeUsingPunchField = "CanEnterTimeUsingPunchField";
        private const string FieldCanFilterActivitiesField = "CanFilterActivitiesField";
        private const string FieldCanReportOnAnyClientField = "CanReportOnAnyClientField";
        private const string FieldCanReportOnAnyGroupField = "CanReportOnAnyGroupField";
        private const string FieldCanReportOnAnyProjectField = "CanReportOnAnyProjectField";
        private const string FieldCanReportOnAnyUserField = "CanReportOnAnyUserField";
        private const string FieldCityField = "CityField";
        private const string FieldClientsField = "ClientsField";
        private const string FieldComponentIdField = "ComponentIdField";
        private const string FieldCountryField = "CountryField";
        private const string FieldDateHiredField = "DateHiredField";
        private const string FieldDateOfBirthField = "DateOfBirthField";
        private const string FieldDefaultClientIdField = "DefaultClientIdField";
        private const string FieldDefaultProjectIdField = "DefaultProjectIdField";
        private const string FieldDefaultTaskIdField = "DefaultTaskIdField";
        private const string FieldDefaultWorktypeIdField = "DefaultWorktypeIdField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldEmailField = "EmailField";
        private const string FieldExpenseEntriesField = "ExpenseEntriesField";
        private const string FieldExpenseReportsField = "ExpenseReportsField";
        private const string FieldExpenseReportsCreatedField = "ExpenseReportsCreatedField";
        private const string FieldExpenseWorkflowIdField = "ExpenseWorkflowIdField";
        private const string FieldFaxNumberField = "FaxNumberField";
        private const string FieldFirstNameField = "FirstNameField";
        private const string FieldForcastBillableField = "ForcastBillableField";
        private const string FieldForcastCostedField = "ForcastCostedField";
        private const string FieldFullNameField = "FullNameField";
        private const string FieldFunctionalGroupField = "FunctionalGroupField";
        private const string FieldFunctionalGroupIdField = "FunctionalGroupIdField";
        private const string FieldFunctionalGroupManagersField = "FunctionalGroupManagersField";
        private const string FieldGenderField = "GenderField";
        private const string FieldHasProjectSchedulingField = "HasProjectSchedulingField";
        private const string FieldHolidaySetField = "HolidaySetField";
        private const string FieldHolidaySetIdField = "HolidaySetIdField";
        private const string FieldIMPasswordField = "IMPasswordField";
        private const string FieldIMSigninField = "IMSigninField";
        private const string FieldIdField = "IdField";
        private const string FieldIsDefaultUserField = "IsDefaultUserField";
        private const string FieldIsFirstLoginField = "IsFirstLoginField";
        private const string FieldLanguageField = "LanguageField";
        private const string FieldLastEvaluationDateField = "LastEvaluationDateField";
        private const string FieldLastNameField = "LastNameField";
        private const string FieldLastNavigationPageField = "LastNavigationPageField";
        private const string FieldLastVisitedLeftIdField = "LastVisitedLeftIdField";
        private const string FieldLastVisitedRootIdField = "LastVisitedRootIdField";
        private const string FieldLastVisitedURLSectField = "LastVisitedURLSectField";
        private const string FieldLeaveTimeUserHistoryField = "LeaveTimeUserHistoryField";
        private const string FieldLoginNameField = "LoginNameField";
        private const string FieldManagedBusinessUnitsField = "ManagedBusinessUnitsField";
        private const string FieldMaritalStatusField = "MaritalStatusField";
        private const string FieldMasterSiteField = "MasterSiteField";
        private const string FieldMasterSiteIdField = "MasterSiteIdField";
        private const string FieldMenuOptionsField = "MenuOptionsField";
        private const string FieldMobileNumberField = "MobileNumberField";
        private const string FieldNextEvaluationDateField = "NextEvaluationDateField";
        private const string FieldOfflinePermissionsField = "OfflinePermissionsField";
        private const string FieldOutOfOfficeField = "OutOfOfficeField";
        private const string FieldOverrideGlobalSettingsField = "OverrideGlobalSettingsField";
        private const string FieldPagerNumberField = "PagerNumberField";
        private const string FieldPasswordField = "PasswordField";
        private const string FieldPasswordLastChangedOnField = "PasswordLastChangedOnField";
        private const string FieldPasswordNumberOfRetriesField = "PasswordNumberOfRetriesField";
        private const string FieldPlanningRolesField = "PlanningRolesField";
        private const string FieldPostalCodeField = "PostalCodeField";
        private const string FieldProjectActualManagerIdField = "ProjectActualManagerIdField";
        private const string FieldProjectAlternateManagerField = "ProjectAlternateManagerField";
        private const string FieldProjectManagerField = "ProjectManagerField";
        private const string FieldProjectSchedulingIdField = "ProjectSchedulingIdField";
        private const string FieldPurchasingWorkflowIdField = "PurchasingWorkflowIdField";
        private const string FieldQuickLinksOptionsField = "QuickLinksOptionsField";
        private const string FieldRequisitionWorkflowIdField = "RequisitionWorkflowIdField";
        private const string FieldResourceGroupField = "ResourceGroupField";
        private const string FieldResourceGroupIdField = "ResourceGroupIdField";
        private const string FieldResourceTypeField = "ResourceTypeField";
        private const string FieldResourceTypeHistoryField = "ResourceTypeHistoryField";
        private const string FieldSecurityField = "SecurityField";
        private const string FieldServiceDateField = "ServiceDateField";
        private const string FieldSocialInsuranceNumberField = "SocialInsuranceNumberField";
        private const string FieldStateField = "StateField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTagAssociationField = "TagAssociationField";
        private const string FieldTelephoneNumberField = "TelephoneNumberField";
        private const string FieldTerminationDateField = "TerminationDateField";
        private const string FieldTimesheetWorkflowIdField = "TimesheetWorkflowIdField";
        private const string FieldTitleField = "TitleField";
        private const string FieldTitleIdField = "TitleIdField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUserAccessStatusField = "UserAccessStatusField";
        private const string FieldUserBusinessUnitsField = "UserBusinessUnitsField";
        private const string FieldUserGroupField = "UserGroupField";
        private const string FieldUserLeaveTimeField = "UserLeaveTimeField";
        private const string FieldUserResourceTypeField = "UserResourceTypeField";
        private const string FieldUserSkillsField = "UserSkillsField";
        private const string FieldUserTypeField = "UserTypeField";
        private const string FieldViewAllActivitiesField = "ViewAllActivitiesField";
        private const string FieldWebSiteField = "WebSiteField";
        private const string FieldWillRelocateField = "WillRelocateField";
        private const string FieldWillRelocateIfInterestedField = "WillRelocateIfInterestedField";
        private const string FieldWillTravelField = "WillTravelField";
        private const string FieldWillTravelIfInterestedField = "WillTravelIfInterestedField";
        private const string FieldWorkflowIdField = "WorkflowIdField";

        #endregion

        private Type _userInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private User _userInstance;
        private User _userInstanceFixture;

        #region General Initializer : Class (User) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="User" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _userInstanceType = typeof(User);
            _userInstanceFixture = this.Create<User>(true);
            _userInstance = _userInstanceFixture ?? this.Create<User>(false);
            CurrentInstance = _userInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (User)

        #region General Initializer : Class (User) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="User" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_User_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_userInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (User) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="User" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccountSetId)]
        [TestCase(PropertyActiveSite)]
        [TestCase(PropertyActiveSiteId)]
        [TestCase(PropertyActualGroupManagers)]
        [TestCase(PropertyAddressLine1)]
        [TestCase(PropertyAddressLine2)]
        [TestCase(PropertyAlternateGroupManagers)]
        [TestCase(PropertyAlternatePhoneNumber)]
        [TestCase(PropertyApprovalGroup)]
        [TestCase(PropertyApprovalGroupId)]
        [TestCase(PropertyAssignments)]
        [TestCase(PropertyBadgeNumber)]
        [TestCase(PropertyCanEnterTimeUsingPunch)]
        [TestCase(PropertyCanFilterActivities)]
        [TestCase(PropertyCanReportOnAnyClient)]
        [TestCase(PropertyCanReportOnAnyGroup)]
        [TestCase(PropertyCanReportOnAnyProject)]
        [TestCase(PropertyCanReportOnAnyUser)]
        [TestCase(PropertyCity)]
        [TestCase(PropertyClients)]
        [TestCase(PropertyComponentId)]
        [TestCase(PropertyCountry)]
        [TestCase(PropertyDateHired)]
        [TestCase(PropertyDateOfBirth)]
        [TestCase(PropertyDefaultClientId)]
        [TestCase(PropertyDefaultProjectId)]
        [TestCase(PropertyDefaultTaskId)]
        [TestCase(PropertyDefaultWorktypeId)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyEmail)]
        [TestCase(PropertyExpenseEntries)]
        [TestCase(PropertyExpenseReports)]
        [TestCase(PropertyExpenseReportsCreated)]
        [TestCase(PropertyExpenseWorkflowId)]
        [TestCase(PropertyFaxNumber)]
        [TestCase(PropertyFirstName)]
        [TestCase(PropertyForcastBillable)]
        [TestCase(PropertyForcastCosted)]
        [TestCase(PropertyFullName)]
        [TestCase(PropertyFunctionalGroup)]
        [TestCase(PropertyFunctionalGroupId)]
        [TestCase(PropertyFunctionalGroupManagers)]
        [TestCase(PropertyGender)]
        [TestCase(PropertyHasProjectScheduling)]
        [TestCase(PropertyHolidaySet)]
        [TestCase(PropertyHolidaySetId)]
        [TestCase(PropertyIMPassword)]
        [TestCase(PropertyIMSignin)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsDefaultUser)]
        [TestCase(PropertyIsFirstLogin)]
        [TestCase(PropertyLanguage)]
        [TestCase(PropertyLastEvaluationDate)]
        [TestCase(PropertyLastName)]
        [TestCase(PropertyLastNavigationPage)]
        [TestCase(PropertyLastVisitedLeftId)]
        [TestCase(PropertyLastVisitedRootId)]
        [TestCase(PropertyLastVisitedURLSect)]
        [TestCase(PropertyLeaveTimeUserHistory)]
        [TestCase(PropertyLoginName)]
        [TestCase(PropertyManagedBusinessUnits)]
        [TestCase(PropertyMaritalStatus)]
        [TestCase(PropertyMasterSite)]
        [TestCase(PropertyMasterSiteId)]
        [TestCase(PropertyMenuOptions)]
        [TestCase(PropertyMobileNumber)]
        [TestCase(PropertyNextEvaluationDate)]
        [TestCase(PropertyOfflinePermissions)]
        [TestCase(PropertyOutOfOffice)]
        [TestCase(PropertyOverrideGlobalSettings)]
        [TestCase(PropertyPagerNumber)]
        [TestCase(PropertyPassword)]
        [TestCase(PropertyPasswordLastChangedOn)]
        [TestCase(PropertyPasswordNumberOfRetries)]
        [TestCase(PropertyPlanningRoles)]
        [TestCase(PropertyPostalCode)]
        [TestCase(PropertyProjectActualManagerId)]
        [TestCase(PropertyProjectAlternateManager)]
        [TestCase(PropertyProjectManager)]
        [TestCase(PropertyProjectSchedulingId)]
        [TestCase(PropertyPurchasingWorkflowId)]
        [TestCase(PropertyQuickLinksOptions)]
        [TestCase(PropertyRequisitionWorkflowId)]
        [TestCase(PropertyResourceGroup)]
        [TestCase(PropertyResourceGroupId)]
        [TestCase(PropertyResourceType)]
        [TestCase(PropertyResourceTypeHistory)]
        [TestCase(PropertySecurity)]
        [TestCase(PropertyServiceDate)]
        [TestCase(PropertySocialInsuranceNumber)]
        [TestCase(PropertyState)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTagAssociation)]
        [TestCase(PropertyTelephoneNumber)]
        [TestCase(PropertyTerminationDate)]
        [TestCase(PropertyTimesheetWorkflowId)]
        [TestCase(PropertyTitle)]
        [TestCase(PropertyTitleId)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUserAccessStatus)]
        [TestCase(PropertyUserBusinessUnits)]
        [TestCase(PropertyUserGroup)]
        [TestCase(PropertyUserLeaveTime)]
        [TestCase(PropertyUserResourceType)]
        [TestCase(PropertyUserSkills)]
        [TestCase(PropertyUserType)]
        [TestCase(PropertyViewAllActivities)]
        [TestCase(PropertyWebSite)]
        [TestCase(PropertyWillRelocate)]
        [TestCase(PropertyWillRelocateIfInterested)]
        [TestCase(PropertyWillTravel)]
        [TestCase(PropertyWillTravelIfInterested)]
        [TestCase(PropertyWorkflowId)]
        public void AUT_User_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_userInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (User) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="User" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccountSetIdField)]
        [TestCase(FieldActiveSiteField)]
        [TestCase(FieldActiveSiteIdField)]
        [TestCase(FieldActualGroupManagersField)]
        [TestCase(FieldAddressLine1Field)]
        [TestCase(FieldAddressLine2Field)]
        [TestCase(FieldAlternateGroupManagersField)]
        [TestCase(FieldAlternatePhoneNumberField)]
        [TestCase(FieldApprovalGroupField)]
        [TestCase(FieldApprovalGroupIdField)]
        [TestCase(FieldAssignmentsField)]
        [TestCase(FieldBadgeNumberField)]
        [TestCase(FieldCanEnterTimeUsingPunchField)]
        [TestCase(FieldCanFilterActivitiesField)]
        [TestCase(FieldCanReportOnAnyClientField)]
        [TestCase(FieldCanReportOnAnyGroupField)]
        [TestCase(FieldCanReportOnAnyProjectField)]
        [TestCase(FieldCanReportOnAnyUserField)]
        [TestCase(FieldCityField)]
        [TestCase(FieldClientsField)]
        [TestCase(FieldComponentIdField)]
        [TestCase(FieldCountryField)]
        [TestCase(FieldDateHiredField)]
        [TestCase(FieldDateOfBirthField)]
        [TestCase(FieldDefaultClientIdField)]
        [TestCase(FieldDefaultProjectIdField)]
        [TestCase(FieldDefaultTaskIdField)]
        [TestCase(FieldDefaultWorktypeIdField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldEmailField)]
        [TestCase(FieldExpenseEntriesField)]
        [TestCase(FieldExpenseReportsField)]
        [TestCase(FieldExpenseReportsCreatedField)]
        [TestCase(FieldExpenseWorkflowIdField)]
        [TestCase(FieldFaxNumberField)]
        [TestCase(FieldFirstNameField)]
        [TestCase(FieldForcastBillableField)]
        [TestCase(FieldForcastCostedField)]
        [TestCase(FieldFullNameField)]
        [TestCase(FieldFunctionalGroupField)]
        [TestCase(FieldFunctionalGroupIdField)]
        [TestCase(FieldFunctionalGroupManagersField)]
        [TestCase(FieldGenderField)]
        [TestCase(FieldHasProjectSchedulingField)]
        [TestCase(FieldHolidaySetField)]
        [TestCase(FieldHolidaySetIdField)]
        [TestCase(FieldIMPasswordField)]
        [TestCase(FieldIMSigninField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIsDefaultUserField)]
        [TestCase(FieldIsFirstLoginField)]
        [TestCase(FieldLanguageField)]
        [TestCase(FieldLastEvaluationDateField)]
        [TestCase(FieldLastNameField)]
        [TestCase(FieldLastNavigationPageField)]
        [TestCase(FieldLastVisitedLeftIdField)]
        [TestCase(FieldLastVisitedRootIdField)]
        [TestCase(FieldLastVisitedURLSectField)]
        [TestCase(FieldLeaveTimeUserHistoryField)]
        [TestCase(FieldLoginNameField)]
        [TestCase(FieldManagedBusinessUnitsField)]
        [TestCase(FieldMaritalStatusField)]
        [TestCase(FieldMasterSiteField)]
        [TestCase(FieldMasterSiteIdField)]
        [TestCase(FieldMenuOptionsField)]
        [TestCase(FieldMobileNumberField)]
        [TestCase(FieldNextEvaluationDateField)]
        [TestCase(FieldOfflinePermissionsField)]
        [TestCase(FieldOutOfOfficeField)]
        [TestCase(FieldOverrideGlobalSettingsField)]
        [TestCase(FieldPagerNumberField)]
        [TestCase(FieldPasswordField)]
        [TestCase(FieldPasswordLastChangedOnField)]
        [TestCase(FieldPasswordNumberOfRetriesField)]
        [TestCase(FieldPlanningRolesField)]
        [TestCase(FieldPostalCodeField)]
        [TestCase(FieldProjectActualManagerIdField)]
        [TestCase(FieldProjectAlternateManagerField)]
        [TestCase(FieldProjectManagerField)]
        [TestCase(FieldProjectSchedulingIdField)]
        [TestCase(FieldPurchasingWorkflowIdField)]
        [TestCase(FieldQuickLinksOptionsField)]
        [TestCase(FieldRequisitionWorkflowIdField)]
        [TestCase(FieldResourceGroupField)]
        [TestCase(FieldResourceGroupIdField)]
        [TestCase(FieldResourceTypeField)]
        [TestCase(FieldResourceTypeHistoryField)]
        [TestCase(FieldSecurityField)]
        [TestCase(FieldServiceDateField)]
        [TestCase(FieldSocialInsuranceNumberField)]
        [TestCase(FieldStateField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTagAssociationField)]
        [TestCase(FieldTelephoneNumberField)]
        [TestCase(FieldTerminationDateField)]
        [TestCase(FieldTimesheetWorkflowIdField)]
        [TestCase(FieldTitleField)]
        [TestCase(FieldTitleIdField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUserAccessStatusField)]
        [TestCase(FieldUserBusinessUnitsField)]
        [TestCase(FieldUserGroupField)]
        [TestCase(FieldUserLeaveTimeField)]
        [TestCase(FieldUserResourceTypeField)]
        [TestCase(FieldUserSkillsField)]
        [TestCase(FieldUserTypeField)]
        [TestCase(FieldViewAllActivitiesField)]
        [TestCase(FieldWebSiteField)]
        [TestCase(FieldWillRelocateField)]
        [TestCase(FieldWillRelocateIfInterestedField)]
        [TestCase(FieldWillTravelField)]
        [TestCase(FieldWillTravelIfInterestedField)]
        [TestCase(FieldWorkflowIdField)]
        public void AUT_User_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_userInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="User" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_User_Is_Instance_Present_Test()
        {
            // Assert
            _userInstanceType.ShouldNotBeNull();
            _userInstance.ShouldNotBeNull();
            _userInstanceFixture.ShouldNotBeNull();
            _userInstance.ShouldBeAssignableTo<User>();
            _userInstanceFixture.ShouldBeAssignableTo<User>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (User) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_User_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            User instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _userInstanceType.ShouldNotBeNull();
            _userInstance.ShouldNotBeNull();
            _userInstanceFixture.ShouldNotBeNull();
            _userInstance.ShouldBeAssignableTo<User>();
            _userInstanceFixture.ShouldBeAssignableTo<User>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (User) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyAccountSetId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Site) , PropertyActiveSite)]
        [TestCaseGeneric(typeof(int) , PropertyActiveSiteId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Group[]) , PropertyActualGroupManagers)]
        [TestCaseGeneric(typeof(string) , PropertyAddressLine1)]
        [TestCaseGeneric(typeof(string) , PropertyAddressLine2)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Group[]) , PropertyAlternateGroupManagers)]
        [TestCaseGeneric(typeof(string) , PropertyAlternatePhoneNumber)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Group) , PropertyApprovalGroup)]
        [TestCaseGeneric(typeof(int) , PropertyApprovalGroupId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Assignment[]) , PropertyAssignments)]
        [TestCaseGeneric(typeof(string) , PropertyBadgeNumber)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanEnterTimeUsingPunch)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanFilterActivities)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanReportOnAnyClient)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanReportOnAnyGroup)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanReportOnAnyProject)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanReportOnAnyUser)]
        [TestCaseGeneric(typeof(string) , PropertyCity)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Client[]) , PropertyClients)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyComponentId)]
        [TestCaseGeneric(typeof(string) , PropertyCountry)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDateHired)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyDateOfBirth)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultClientId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultProjectId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultTaskId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultWorktypeId)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(string) , PropertyEmail)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ExpenseEntry[]) , PropertyExpenseEntries)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ExpenseReport[]) , PropertyExpenseReports)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ExpenseReport[]) , PropertyExpenseReportsCreated)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyExpenseWorkflowId)]
        [TestCaseGeneric(typeof(string) , PropertyFaxNumber)]
        [TestCaseGeneric(typeof(string) , PropertyFirstName)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyForcastBillable)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyForcastCosted)]
        [TestCaseGeneric(typeof(string) , PropertyFullName)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Group) , PropertyFunctionalGroup)]
        [TestCaseGeneric(typeof(int) , PropertyFunctionalGroupId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Group[]) , PropertyFunctionalGroupManagers)]
        [TestCaseGeneric(typeof(short) , PropertyGender)]
        [TestCaseGeneric(typeof(short) , PropertyHasProjectScheduling)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.HolidaySet) , PropertyHolidaySet)]
        [TestCaseGeneric(typeof(int) , PropertyHolidaySetId)]
        [TestCaseGeneric(typeof(string) , PropertyIMPassword)]
        [TestCaseGeneric(typeof(string) , PropertyIMSignin)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsDefaultUser)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyIsFirstLogin)]
        [TestCaseGeneric(typeof(string) , PropertyLanguage)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyLastEvaluationDate)]
        [TestCaseGeneric(typeof(string) , PropertyLastName)]
        [TestCaseGeneric(typeof(string) , PropertyLastNavigationPage)]
        [TestCaseGeneric(typeof(int) , PropertyLastVisitedLeftId)]
        [TestCaseGeneric(typeof(int) , PropertyLastVisitedRootId)]
        [TestCaseGeneric(typeof(int) , PropertyLastVisitedURLSect)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.LeaveTimeUserHistory[]) , PropertyLeaveTimeUserHistory)]
        [TestCaseGeneric(typeof(string) , PropertyLoginName)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.BusinessUnit[]) , PropertyManagedBusinessUnits)]
        [TestCaseGeneric(typeof(string) , PropertyMaritalStatus)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Site) , PropertyMasterSite)]
        [TestCaseGeneric(typeof(int) , PropertyMasterSiteId)]
        [TestCaseGeneric(typeof(string) , PropertyMenuOptions)]
        [TestCaseGeneric(typeof(string) , PropertyMobileNumber)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyNextEvaluationDate)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.OfflineUserPermissions) , PropertyOfflinePermissions)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOutOfOffice)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOverrideGlobalSettings)]
        [TestCaseGeneric(typeof(string) , PropertyPagerNumber)]
        [TestCaseGeneric(typeof(string) , PropertyPassword)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyPasswordLastChangedOn)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPasswordNumberOfRetries)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.UserPlanningRole[]) , PropertyPlanningRoles)]
        [TestCaseGeneric(typeof(string) , PropertyPostalCode)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Project[]) , PropertyProjectActualManagerId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Project[]) , PropertyProjectAlternateManager)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Project[]) , PropertyProjectManager)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyProjectSchedulingId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPurchasingWorkflowId)]
        [TestCaseGeneric(typeof(int) , PropertyQuickLinksOptions)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRequisitionWorkflowId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Group) , PropertyResourceGroup)]
        [TestCaseGeneric(typeof(int) , PropertyResourceGroupId)]
        [TestCaseGeneric(typeof(int) , PropertyResourceType)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ResourceTypeHistory[]) , PropertyResourceTypeHistory)]
        [TestCaseGeneric(typeof(string) , PropertySecurity)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyServiceDate)]
        [TestCaseGeneric(typeof(string) , PropertySocialInsuranceNumber)]
        [TestCaseGeneric(typeof(string) , PropertyState)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.TagAssociation[]) , PropertyTagAssociation)]
        [TestCaseGeneric(typeof(string) , PropertyTelephoneNumber)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyTerminationDate)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimesheetWorkflowId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Title) , PropertyTitle)]
        [TestCaseGeneric(typeof(int) , PropertyTitleId)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyUserAccessStatus)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.UsersBusinessUnits[]) , PropertyUserBusinessUnits)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.UserGroup[]) , PropertyUserGroup)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.UserLeaveTime[]) , PropertyUserLeaveTime)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ResourceType) , PropertyUserResourceType)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.UserSkill[]) , PropertyUserSkills)]
        [TestCaseGeneric(typeof(string) , PropertyUserType)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyViewAllActivities)]
        [TestCaseGeneric(typeof(string) , PropertyWebSite)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyWillRelocate)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyWillRelocateIfInterested)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyWillTravel)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyWillTravelIfInterested)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowId)]
        public void AUT_User_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<User, T>(_userInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (AccountSetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_AccountSetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccountSetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccountSetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ActiveSite) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ActiveSite_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActiveSite);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyActiveSite);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ActiveSite) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ActiveSite_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActiveSite);
            var propertyInfo  = this.GetPropertyInfo(PropertyActiveSite);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ActiveSiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ActiveSiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActiveSiteId);
            var propertyInfo  = this.GetPropertyInfo(PropertyActiveSiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ActualGroupManagers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ActualGroupManagers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActualGroupManagers);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyActualGroupManagers);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ActualGroupManagers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ActualGroupManagers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyActualGroupManagers);
            var propertyInfo  = this.GetPropertyInfo(PropertyActualGroupManagers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (AddressLine1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_AddressLine1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAddressLine1);
            var propertyInfo  = this.GetPropertyInfo(PropertyAddressLine1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (AddressLine2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_AddressLine2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAddressLine2);
            var propertyInfo  = this.GetPropertyInfo(PropertyAddressLine2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (AlternateGroupManagers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_AlternateGroupManagers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAlternateGroupManagers);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyAlternateGroupManagers);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (AlternateGroupManagers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_AlternateGroupManagers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAlternateGroupManagers);
            var propertyInfo  = this.GetPropertyInfo(PropertyAlternateGroupManagers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (AlternatePhoneNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_AlternatePhoneNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAlternatePhoneNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyAlternatePhoneNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ApprovalGroup) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ApprovalGroup_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApprovalGroup);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyApprovalGroup);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ApprovalGroup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ApprovalGroup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApprovalGroup);
            var propertyInfo  = this.GetPropertyInfo(PropertyApprovalGroup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ApprovalGroupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ApprovalGroupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApprovalGroupId);
            var propertyInfo  = this.GetPropertyInfo(PropertyApprovalGroupId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Assignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Assignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAssignments);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyAssignments);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Assignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Assignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAssignments);
            var propertyInfo  = this.GetPropertyInfo(PropertyAssignments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (BadgeNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_BadgeNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBadgeNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyBadgeNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (CanEnterTimeUsingPunch) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_CanEnterTimeUsingPunch_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanEnterTimeUsingPunch);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanEnterTimeUsingPunch);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (CanFilterActivities) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_CanFilterActivities_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanFilterActivities);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanFilterActivities);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (CanReportOnAnyClient) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_CanReportOnAnyClient_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanReportOnAnyClient);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanReportOnAnyClient);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (CanReportOnAnyGroup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_CanReportOnAnyGroup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanReportOnAnyGroup);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanReportOnAnyGroup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (CanReportOnAnyProject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_CanReportOnAnyProject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanReportOnAnyProject);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanReportOnAnyProject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (CanReportOnAnyUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_CanReportOnAnyUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanReportOnAnyUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanReportOnAnyUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (City) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_City_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCity);
            var propertyInfo  = this.GetPropertyInfo(PropertyCity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Clients) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Clients_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClients);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyClients);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Clients) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Clients_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClients);
            var propertyInfo  = this.GetPropertyInfo(PropertyClients);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ComponentId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ComponentId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyComponentId);
            var propertyInfo  = this.GetPropertyInfo(PropertyComponentId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Country) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Country_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCountry);
            var propertyInfo  = this.GetPropertyInfo(PropertyCountry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (DateHired) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_DateHired_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateHired);
            var propertyInfo  = this.GetPropertyInfo(PropertyDateHired);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (DateOfBirth) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_DateOfBirth_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateOfBirth);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDateOfBirth);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (DateOfBirth) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_DateOfBirth_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateOfBirth);
            var propertyInfo  = this.GetPropertyInfo(PropertyDateOfBirth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (DefaultClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_DefaultClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultClientId);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultClientId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (DefaultProjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_DefaultProjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultProjectId);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultProjectId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (DefaultTaskId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_DefaultTaskId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultTaskId);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultTaskId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (DefaultWorktypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_DefaultWorktypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultWorktypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultWorktypeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDescription);
            var propertyInfo  = this.GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Email) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Email_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEmail);
            var propertyInfo  = this.GetPropertyInfo(PropertyEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExpenseEntries) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ExpenseEntries_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseEntries);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExpenseEntries);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExpenseEntries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ExpenseEntries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseEntries);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseEntries);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExpenseReports) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ExpenseReports_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReports);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExpenseReports);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExpenseReports) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ExpenseReports_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReports);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseReports);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExpenseReportsCreated) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ExpenseReportsCreated_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReportsCreated);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExpenseReportsCreated);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExpenseReportsCreated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ExpenseReportsCreated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseReportsCreated);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseReportsCreated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExpenseWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ExpenseWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExpenseWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyExpenseWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var propertyInfo  = this.GetPropertyInfo(PropertyExtensionData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FaxNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_FaxNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFaxNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyFaxNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FirstName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_FirstName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFirstName);
            var propertyInfo  = this.GetPropertyInfo(PropertyFirstName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ForcastBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ForcastBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyForcastBillable);
            var propertyInfo  = this.GetPropertyInfo(PropertyForcastBillable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ForcastCosted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ForcastCosted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyForcastCosted);
            var propertyInfo  = this.GetPropertyInfo(PropertyForcastCosted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FullName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_FullName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFullName);
            var propertyInfo  = this.GetPropertyInfo(PropertyFullName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FunctionalGroup) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_FunctionalGroup_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFunctionalGroup);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyFunctionalGroup);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FunctionalGroup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_FunctionalGroup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFunctionalGroup);
            var propertyInfo  = this.GetPropertyInfo(PropertyFunctionalGroup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FunctionalGroupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_FunctionalGroupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFunctionalGroupId);
            var propertyInfo  = this.GetPropertyInfo(PropertyFunctionalGroupId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FunctionalGroupManagers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_FunctionalGroupManagers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFunctionalGroupManagers);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyFunctionalGroupManagers);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (FunctionalGroupManagers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_FunctionalGroupManagers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFunctionalGroupManagers);
            var propertyInfo  = this.GetPropertyInfo(PropertyFunctionalGroupManagers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Gender) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Gender_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyGender);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyGender);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Gender) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Gender_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyGender);
            var propertyInfo  = this.GetPropertyInfo(PropertyGender);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (HasProjectScheduling) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_HasProjectScheduling_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHasProjectScheduling);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyHasProjectScheduling);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (HasProjectScheduling) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_HasProjectScheduling_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHasProjectScheduling);
            var propertyInfo  = this.GetPropertyInfo(PropertyHasProjectScheduling);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (HolidaySet) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_HolidaySet_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHolidaySet);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyHolidaySet);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (HolidaySet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_HolidaySet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHolidaySet);
            var propertyInfo  = this.GetPropertyInfo(PropertyHolidaySet);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (HolidaySetId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_HolidaySetId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHolidaySetId);
            var propertyInfo  = this.GetPropertyInfo(PropertyHolidaySetId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (IMPassword) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_IMPassword_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIMPassword);
            var propertyInfo  = this.GetPropertyInfo(PropertyIMPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (IMSignin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_IMSignin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIMSignin);
            var propertyInfo  = this.GetPropertyInfo(PropertyIMSignin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (IsDefaultUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_IsDefaultUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsDefaultUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsDefaultUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (IsFirstLogin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_IsFirstLogin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsFirstLogin);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsFirstLogin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Language) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Language_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLanguage);
            var propertyInfo  = this.GetPropertyInfo(PropertyLanguage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LastEvaluationDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LastEvaluationDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastEvaluationDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastEvaluationDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LastName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LastName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastName);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LastNavigationPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LastNavigationPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastNavigationPage);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastNavigationPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LastVisitedLeftId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LastVisitedLeftId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastVisitedLeftId);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastVisitedLeftId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LastVisitedRootId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LastVisitedRootId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastVisitedRootId);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastVisitedRootId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LastVisitedURLSect) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LastVisitedURLSect_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLastVisitedURLSect);
            var propertyInfo  = this.GetPropertyInfo(PropertyLastVisitedURLSect);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LeaveTimeUserHistory) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_LeaveTimeUserHistory_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLeaveTimeUserHistory);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyLeaveTimeUserHistory);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LeaveTimeUserHistory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LeaveTimeUserHistory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLeaveTimeUserHistory);
            var propertyInfo  = this.GetPropertyInfo(PropertyLeaveTimeUserHistory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (LoginName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_LoginName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLoginName);
            var propertyInfo  = this.GetPropertyInfo(PropertyLoginName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ManagedBusinessUnits) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ManagedBusinessUnits_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManagedBusinessUnits);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyManagedBusinessUnits);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ManagedBusinessUnits) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ManagedBusinessUnits_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManagedBusinessUnits);
            var propertyInfo  = this.GetPropertyInfo(PropertyManagedBusinessUnits);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (MaritalStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_MaritalStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMaritalStatus);
            var propertyInfo  = this.GetPropertyInfo(PropertyMaritalStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (MasterSite) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_MasterSite_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMasterSite);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyMasterSite);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (MasterSite) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_MasterSite_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMasterSite);
            var propertyInfo  = this.GetPropertyInfo(PropertyMasterSite);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (MasterSiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_MasterSiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMasterSiteId);
            var propertyInfo  = this.GetPropertyInfo(PropertyMasterSiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (MenuOptions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_MenuOptions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMenuOptions);
            var propertyInfo  = this.GetPropertyInfo(PropertyMenuOptions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (MobileNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_MobileNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMobileNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyMobileNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (NextEvaluationDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_NextEvaluationDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNextEvaluationDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyNextEvaluationDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (OfflinePermissions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_OfflinePermissions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOfflinePermissions);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyOfflinePermissions);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (OfflinePermissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_OfflinePermissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOfflinePermissions);
            var propertyInfo  = this.GetPropertyInfo(PropertyOfflinePermissions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (OutOfOffice) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_OutOfOffice_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOutOfOffice);
            var propertyInfo  = this.GetPropertyInfo(PropertyOutOfOffice);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (OverrideGlobalSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_OverrideGlobalSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverrideGlobalSettings);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverrideGlobalSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (PagerNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_PagerNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPagerNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyPagerNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPassword);
            var propertyInfo  = this.GetPropertyInfo(PropertyPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (PasswordLastChangedOn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_PasswordLastChangedOn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPasswordLastChangedOn);
            var propertyInfo  = this.GetPropertyInfo(PropertyPasswordLastChangedOn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (PasswordNumberOfRetries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_PasswordNumberOfRetries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPasswordNumberOfRetries);
            var propertyInfo  = this.GetPropertyInfo(PropertyPasswordNumberOfRetries);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (PlanningRoles) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_PlanningRoles_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPlanningRoles);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPlanningRoles);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (PlanningRoles) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_PlanningRoles_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPlanningRoles);
            var propertyInfo  = this.GetPropertyInfo(PropertyPlanningRoles);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (PostalCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_PostalCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPostalCode);
            var propertyInfo  = this.GetPropertyInfo(PropertyPostalCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ProjectActualManagerId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ProjectActualManagerId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectActualManagerId);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectActualManagerId);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ProjectActualManagerId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ProjectActualManagerId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectActualManagerId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectActualManagerId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ProjectAlternateManager) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ProjectAlternateManager_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectAlternateManager);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectAlternateManager);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ProjectAlternateManager) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ProjectAlternateManager_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectAlternateManager);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectAlternateManager);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ProjectManager) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ProjectManager_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectManager);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectManager);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ProjectManager) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ProjectManager_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectManager);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectManager);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ProjectSchedulingId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ProjectSchedulingId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectSchedulingId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectSchedulingId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (PurchasingWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_PurchasingWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPurchasingWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPurchasingWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (QuickLinksOptions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_QuickLinksOptions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyQuickLinksOptions);
            var propertyInfo  = this.GetPropertyInfo(PropertyQuickLinksOptions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (RequisitionWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_RequisitionWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRequisitionWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyRequisitionWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ResourceGroup) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ResourceGroup_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyResourceGroup);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyResourceGroup);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ResourceGroup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ResourceGroup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyResourceGroup);
            var propertyInfo  = this.GetPropertyInfo(PropertyResourceGroup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ResourceGroupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ResourceGroupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyResourceGroupId);
            var propertyInfo  = this.GetPropertyInfo(PropertyResourceGroupId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ResourceType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ResourceType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyResourceType);
            var propertyInfo  = this.GetPropertyInfo(PropertyResourceType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ResourceTypeHistory) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_ResourceTypeHistory_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyResourceTypeHistory);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyResourceTypeHistory);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ResourceTypeHistory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ResourceTypeHistory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyResourceTypeHistory);
            var propertyInfo  = this.GetPropertyInfo(PropertyResourceTypeHistory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Security) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Security_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySecurity);
            var propertyInfo  = this.GetPropertyInfo(PropertySecurity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ServiceDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ServiceDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyServiceDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyServiceDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (SocialInsuranceNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_SocialInsuranceNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySocialInsuranceNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertySocialInsuranceNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (State) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_State_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyState);
            var propertyInfo  = this.GetPropertyInfo(PropertyState);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var propertyInfo  = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (TagAssociation) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_TagAssociation_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTagAssociation);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTagAssociation);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (TagAssociation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_TagAssociation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTagAssociation);
            var propertyInfo  = this.GetPropertyInfo(PropertyTagAssociation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (TelephoneNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_TelephoneNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTelephoneNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyTelephoneNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (TerminationDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_TerminationDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTerminationDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyTerminationDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (TimesheetWorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_TimesheetWorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimesheetWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimesheetWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Title) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Title_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTitle);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTitle);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTitle);
            var propertyInfo  = this.GetPropertyInfo(PropertyTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (TitleId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_TitleId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTitleId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTitleId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUniqueId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUniqueId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserAccessStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UserAccessStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserAccessStatus);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserAccessStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserBusinessUnits) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_UserBusinessUnits_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserBusinessUnits);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUserBusinessUnits);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserBusinessUnits) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UserBusinessUnits_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserBusinessUnits);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserBusinessUnits);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserGroup) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_UserGroup_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserGroup);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUserGroup);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserGroup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UserGroup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserGroup);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserGroup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserLeaveTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_UserLeaveTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserLeaveTime);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUserLeaveTime);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserLeaveTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UserLeaveTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserLeaveTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserLeaveTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserResourceType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_UserResourceType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserResourceType);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUserResourceType);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserResourceType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UserResourceType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserResourceType);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserResourceType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserSkills) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_UserSkills_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserSkills);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUserSkills);
            Action currentAction = () => propertyInfo.SetValue(_userInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserSkills) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UserSkills_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserSkills);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserSkills);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (UserType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_UserType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserType);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (ViewAllActivities) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_ViewAllActivities_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyViewAllActivities);
            var propertyInfo  = this.GetPropertyInfo(PropertyViewAllActivities);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (WebSite) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_WebSite_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWebSite);
            var propertyInfo  = this.GetPropertyInfo(PropertyWebSite);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (WillRelocate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_WillRelocate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWillRelocate);
            var propertyInfo  = this.GetPropertyInfo(PropertyWillRelocate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (WillRelocateIfInterested) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_WillRelocateIfInterested_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWillRelocateIfInterested);
            var propertyInfo  = this.GetPropertyInfo(PropertyWillRelocateIfInterested);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (WillTravel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_WillTravel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWillTravel);
            var propertyInfo  = this.GetPropertyInfo(PropertyWillTravel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (WillTravelIfInterested) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_WillTravelIfInterested_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWillTravelIfInterested);
            var propertyInfo  = this.GetPropertyInfo(PropertyWillTravelIfInterested);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (User) => Property (WorkflowId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_User_Public_Class_WorkflowId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (RaisePropertyChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_User_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_User_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_userInstanceFixture, parametersOfRaisePropertyChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaisePropertyChanged.ShouldNotBeNull();
            parametersOfRaisePropertyChanged.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(parametersOfRaisePropertyChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_User_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_userInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

            // Assert
            parametersOfRaisePropertyChanged.ShouldNotBeNull();
            parametersOfRaisePropertyChanged.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(parametersOfRaisePropertyChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_User_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_User_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_userInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_User_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_userInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}