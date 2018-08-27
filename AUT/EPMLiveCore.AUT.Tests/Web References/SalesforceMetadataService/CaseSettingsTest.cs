using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CaseSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CaseSettingsTest : AbstractBaseSetupTypedTest<CaseSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CaseSettings) Initializer

        private const string PropertycaseAssignNotificationTemplate = "caseAssignNotificationTemplate";
        private const string PropertycaseCloseNotificationTemplate = "caseCloseNotificationTemplate";
        private const string PropertycaseCommentNotificationTemplate = "caseCommentNotificationTemplate";
        private const string PropertycaseCreateNotificationTemplate = "caseCreateNotificationTemplate";
        private const string PropertycloseCaseThroughStatusChange = "closeCaseThroughStatusChange";
        private const string PropertycloseCaseThroughStatusChangeSpecified = "closeCaseThroughStatusChangeSpecified";
        private const string PropertydefaultCaseOwner = "defaultCaseOwner";
        private const string PropertydefaultCaseOwnerType = "defaultCaseOwnerType";
        private const string PropertydefaultCaseUser = "defaultCaseUser";
        private const string PropertyemailToCase = "emailToCase";
        private const string PropertyenableCaseFeed = "enableCaseFeed";
        private const string PropertyenableCaseFeedSpecified = "enableCaseFeedSpecified";
        private const string PropertyenableDraftEmails = "enableDraftEmails";
        private const string PropertyenableDraftEmailsSpecified = "enableDraftEmailsSpecified";
        private const string PropertyenableEarlyEscalationRuleTriggers = "enableEarlyEscalationRuleTriggers";
        private const string PropertyenableEarlyEscalationRuleTriggersSpecified = "enableEarlyEscalationRuleTriggersSpecified";
        private const string PropertyenableNewEmailDefaultTemplate = "enableNewEmailDefaultTemplate";
        private const string PropertyenableNewEmailDefaultTemplateSpecified = "enableNewEmailDefaultTemplateSpecified";
        private const string PropertyenableSuggestedArticlesApplication = "enableSuggestedArticlesApplication";
        private const string PropertyenableSuggestedArticlesApplicationSpecified = "enableSuggestedArticlesApplicationSpecified";
        private const string PropertyenableSuggestedArticlesCustomerPortal = "enableSuggestedArticlesCustomerPortal";
        private const string PropertyenableSuggestedArticlesCustomerPortalSpecified = "enableSuggestedArticlesCustomerPortalSpecified";
        private const string PropertyenableSuggestedArticlesPartnerPortal = "enableSuggestedArticlesPartnerPortal";
        private const string PropertyenableSuggestedArticlesPartnerPortalSpecified = "enableSuggestedArticlesPartnerPortalSpecified";
        private const string PropertyenableSuggestedSolutions = "enableSuggestedSolutions";
        private const string PropertyenableSuggestedSolutionsSpecified = "enableSuggestedSolutionsSpecified";
        private const string PropertykeepRecordTypeOnAssignmentRule = "keepRecordTypeOnAssignmentRule";
        private const string PropertykeepRecordTypeOnAssignmentRuleSpecified = "keepRecordTypeOnAssignmentRuleSpecified";
        private const string PropertynewEmailDefaultTemplateClass = "newEmailDefaultTemplateClass";
        private const string PropertynotifyContactOnCaseComment = "notifyContactOnCaseComment";
        private const string PropertynotifyContactOnCaseCommentSpecified = "notifyContactOnCaseCommentSpecified";
        private const string PropertynotifyDefaultCaseOwner = "notifyDefaultCaseOwner";
        private const string PropertynotifyDefaultCaseOwnerSpecified = "notifyDefaultCaseOwnerSpecified";
        private const string PropertynotifyOwnerOnCaseComment = "notifyOwnerOnCaseComment";
        private const string PropertynotifyOwnerOnCaseCommentSpecified = "notifyOwnerOnCaseCommentSpecified";
        private const string PropertynotifyOwnerOnCaseOwnerChange = "notifyOwnerOnCaseOwnerChange";
        private const string PropertynotifyOwnerOnCaseOwnerChangeSpecified = "notifyOwnerOnCaseOwnerChangeSpecified";
        private const string PropertyshowFewerCloseActions = "showFewerCloseActions";
        private const string PropertyshowFewerCloseActionsSpecified = "showFewerCloseActionsSpecified";
        private const string PropertyuseSystemEmailAddress = "useSystemEmailAddress";
        private const string PropertyuseSystemEmailAddressSpecified = "useSystemEmailAddressSpecified";
        private const string PropertywebToCase = "webToCase";
        private const string FieldcaseAssignNotificationTemplateField = "caseAssignNotificationTemplateField";
        private const string FieldcaseCloseNotificationTemplateField = "caseCloseNotificationTemplateField";
        private const string FieldcaseCommentNotificationTemplateField = "caseCommentNotificationTemplateField";
        private const string FieldcaseCreateNotificationTemplateField = "caseCreateNotificationTemplateField";
        private const string FieldcloseCaseThroughStatusChangeField = "closeCaseThroughStatusChangeField";
        private const string FieldcloseCaseThroughStatusChangeFieldSpecified = "closeCaseThroughStatusChangeFieldSpecified";
        private const string FielddefaultCaseOwnerField = "defaultCaseOwnerField";
        private const string FielddefaultCaseOwnerTypeField = "defaultCaseOwnerTypeField";
        private const string FielddefaultCaseUserField = "defaultCaseUserField";
        private const string FieldemailToCaseField = "emailToCaseField";
        private const string FieldenableCaseFeedField = "enableCaseFeedField";
        private const string FieldenableCaseFeedFieldSpecified = "enableCaseFeedFieldSpecified";
        private const string FieldenableDraftEmailsField = "enableDraftEmailsField";
        private const string FieldenableDraftEmailsFieldSpecified = "enableDraftEmailsFieldSpecified";
        private const string FieldenableEarlyEscalationRuleTriggersField = "enableEarlyEscalationRuleTriggersField";
        private const string FieldenableEarlyEscalationRuleTriggersFieldSpecified = "enableEarlyEscalationRuleTriggersFieldSpecified";
        private const string FieldenableNewEmailDefaultTemplateField = "enableNewEmailDefaultTemplateField";
        private const string FieldenableNewEmailDefaultTemplateFieldSpecified = "enableNewEmailDefaultTemplateFieldSpecified";
        private const string FieldenableSuggestedArticlesApplicationField = "enableSuggestedArticlesApplicationField";
        private const string FieldenableSuggestedArticlesApplicationFieldSpecified = "enableSuggestedArticlesApplicationFieldSpecified";
        private const string FieldenableSuggestedArticlesCustomerPortalField = "enableSuggestedArticlesCustomerPortalField";
        private const string FieldenableSuggestedArticlesCustomerPortalFieldSpecified = "enableSuggestedArticlesCustomerPortalFieldSpecified";
        private const string FieldenableSuggestedArticlesPartnerPortalField = "enableSuggestedArticlesPartnerPortalField";
        private const string FieldenableSuggestedArticlesPartnerPortalFieldSpecified = "enableSuggestedArticlesPartnerPortalFieldSpecified";
        private const string FieldenableSuggestedSolutionsField = "enableSuggestedSolutionsField";
        private const string FieldenableSuggestedSolutionsFieldSpecified = "enableSuggestedSolutionsFieldSpecified";
        private const string FieldkeepRecordTypeOnAssignmentRuleField = "keepRecordTypeOnAssignmentRuleField";
        private const string FieldkeepRecordTypeOnAssignmentRuleFieldSpecified = "keepRecordTypeOnAssignmentRuleFieldSpecified";
        private const string FieldnewEmailDefaultTemplateClassField = "newEmailDefaultTemplateClassField";
        private const string FieldnotifyContactOnCaseCommentField = "notifyContactOnCaseCommentField";
        private const string FieldnotifyContactOnCaseCommentFieldSpecified = "notifyContactOnCaseCommentFieldSpecified";
        private const string FieldnotifyDefaultCaseOwnerField = "notifyDefaultCaseOwnerField";
        private const string FieldnotifyDefaultCaseOwnerFieldSpecified = "notifyDefaultCaseOwnerFieldSpecified";
        private const string FieldnotifyOwnerOnCaseCommentField = "notifyOwnerOnCaseCommentField";
        private const string FieldnotifyOwnerOnCaseCommentFieldSpecified = "notifyOwnerOnCaseCommentFieldSpecified";
        private const string FieldnotifyOwnerOnCaseOwnerChangeField = "notifyOwnerOnCaseOwnerChangeField";
        private const string FieldnotifyOwnerOnCaseOwnerChangeFieldSpecified = "notifyOwnerOnCaseOwnerChangeFieldSpecified";
        private const string FieldshowFewerCloseActionsField = "showFewerCloseActionsField";
        private const string FieldshowFewerCloseActionsFieldSpecified = "showFewerCloseActionsFieldSpecified";
        private const string FielduseSystemEmailAddressField = "useSystemEmailAddressField";
        private const string FielduseSystemEmailAddressFieldSpecified = "useSystemEmailAddressFieldSpecified";
        private const string FieldwebToCaseField = "webToCaseField";
        private Type _caseSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CaseSettings _caseSettingsInstance;
        private CaseSettings _caseSettingsInstanceFixture;

        #region General Initializer : Class (CaseSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CaseSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _caseSettingsInstanceType = typeof(CaseSettings);
            _caseSettingsInstanceFixture = Create(true);
            _caseSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CaseSettings)

        #region General Initializer : Class (CaseSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CaseSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycaseAssignNotificationTemplate)]
        [TestCase(PropertycaseCloseNotificationTemplate)]
        [TestCase(PropertycaseCommentNotificationTemplate)]
        [TestCase(PropertycaseCreateNotificationTemplate)]
        [TestCase(PropertycloseCaseThroughStatusChange)]
        [TestCase(PropertycloseCaseThroughStatusChangeSpecified)]
        [TestCase(PropertydefaultCaseOwner)]
        [TestCase(PropertydefaultCaseOwnerType)]
        [TestCase(PropertydefaultCaseUser)]
        [TestCase(PropertyemailToCase)]
        [TestCase(PropertyenableCaseFeed)]
        [TestCase(PropertyenableCaseFeedSpecified)]
        [TestCase(PropertyenableDraftEmails)]
        [TestCase(PropertyenableDraftEmailsSpecified)]
        [TestCase(PropertyenableEarlyEscalationRuleTriggers)]
        [TestCase(PropertyenableEarlyEscalationRuleTriggersSpecified)]
        [TestCase(PropertyenableNewEmailDefaultTemplate)]
        [TestCase(PropertyenableNewEmailDefaultTemplateSpecified)]
        [TestCase(PropertyenableSuggestedArticlesApplication)]
        [TestCase(PropertyenableSuggestedArticlesApplicationSpecified)]
        [TestCase(PropertyenableSuggestedArticlesCustomerPortal)]
        [TestCase(PropertyenableSuggestedArticlesCustomerPortalSpecified)]
        [TestCase(PropertyenableSuggestedArticlesPartnerPortal)]
        [TestCase(PropertyenableSuggestedArticlesPartnerPortalSpecified)]
        [TestCase(PropertyenableSuggestedSolutions)]
        [TestCase(PropertyenableSuggestedSolutionsSpecified)]
        [TestCase(PropertykeepRecordTypeOnAssignmentRule)]
        [TestCase(PropertykeepRecordTypeOnAssignmentRuleSpecified)]
        [TestCase(PropertynewEmailDefaultTemplateClass)]
        [TestCase(PropertynotifyContactOnCaseComment)]
        [TestCase(PropertynotifyContactOnCaseCommentSpecified)]
        [TestCase(PropertynotifyDefaultCaseOwner)]
        [TestCase(PropertynotifyDefaultCaseOwnerSpecified)]
        [TestCase(PropertynotifyOwnerOnCaseComment)]
        [TestCase(PropertynotifyOwnerOnCaseCommentSpecified)]
        [TestCase(PropertynotifyOwnerOnCaseOwnerChange)]
        [TestCase(PropertynotifyOwnerOnCaseOwnerChangeSpecified)]
        [TestCase(PropertyshowFewerCloseActions)]
        [TestCase(PropertyshowFewerCloseActionsSpecified)]
        [TestCase(PropertyuseSystemEmailAddress)]
        [TestCase(PropertyuseSystemEmailAddressSpecified)]
        [TestCase(PropertywebToCase)]
        public void AUT_CaseSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_caseSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CaseSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CaseSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcaseAssignNotificationTemplateField)]
        [TestCase(FieldcaseCloseNotificationTemplateField)]
        [TestCase(FieldcaseCommentNotificationTemplateField)]
        [TestCase(FieldcaseCreateNotificationTemplateField)]
        [TestCase(FieldcloseCaseThroughStatusChangeField)]
        [TestCase(FieldcloseCaseThroughStatusChangeFieldSpecified)]
        [TestCase(FielddefaultCaseOwnerField)]
        [TestCase(FielddefaultCaseOwnerTypeField)]
        [TestCase(FielddefaultCaseUserField)]
        [TestCase(FieldemailToCaseField)]
        [TestCase(FieldenableCaseFeedField)]
        [TestCase(FieldenableCaseFeedFieldSpecified)]
        [TestCase(FieldenableDraftEmailsField)]
        [TestCase(FieldenableDraftEmailsFieldSpecified)]
        [TestCase(FieldenableEarlyEscalationRuleTriggersField)]
        [TestCase(FieldenableEarlyEscalationRuleTriggersFieldSpecified)]
        [TestCase(FieldenableNewEmailDefaultTemplateField)]
        [TestCase(FieldenableNewEmailDefaultTemplateFieldSpecified)]
        [TestCase(FieldenableSuggestedArticlesApplicationField)]
        [TestCase(FieldenableSuggestedArticlesApplicationFieldSpecified)]
        [TestCase(FieldenableSuggestedArticlesCustomerPortalField)]
        [TestCase(FieldenableSuggestedArticlesCustomerPortalFieldSpecified)]
        [TestCase(FieldenableSuggestedArticlesPartnerPortalField)]
        [TestCase(FieldenableSuggestedArticlesPartnerPortalFieldSpecified)]
        [TestCase(FieldenableSuggestedSolutionsField)]
        [TestCase(FieldenableSuggestedSolutionsFieldSpecified)]
        [TestCase(FieldkeepRecordTypeOnAssignmentRuleField)]
        [TestCase(FieldkeepRecordTypeOnAssignmentRuleFieldSpecified)]
        [TestCase(FieldnewEmailDefaultTemplateClassField)]
        [TestCase(FieldnotifyContactOnCaseCommentField)]
        [TestCase(FieldnotifyContactOnCaseCommentFieldSpecified)]
        [TestCase(FieldnotifyDefaultCaseOwnerField)]
        [TestCase(FieldnotifyDefaultCaseOwnerFieldSpecified)]
        [TestCase(FieldnotifyOwnerOnCaseCommentField)]
        [TestCase(FieldnotifyOwnerOnCaseCommentFieldSpecified)]
        [TestCase(FieldnotifyOwnerOnCaseOwnerChangeField)]
        [TestCase(FieldnotifyOwnerOnCaseOwnerChangeFieldSpecified)]
        [TestCase(FieldshowFewerCloseActionsField)]
        [TestCase(FieldshowFewerCloseActionsFieldSpecified)]
        [TestCase(FielduseSystemEmailAddressField)]
        [TestCase(FielduseSystemEmailAddressFieldSpecified)]
        [TestCase(FieldwebToCaseField)]
        public void AUT_CaseSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_caseSettingsInstanceFixture, 
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
        ///     Class (<see cref="CaseSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CaseSettings_Is_Instance_Present_Test()
        {
            // Assert
            _caseSettingsInstanceType.ShouldNotBeNull();
            _caseSettingsInstance.ShouldNotBeNull();
            _caseSettingsInstanceFixture.ShouldNotBeNull();
            _caseSettingsInstance.ShouldBeAssignableTo<CaseSettings>();
            _caseSettingsInstanceFixture.ShouldBeAssignableTo<CaseSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CaseSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CaseSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CaseSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _caseSettingsInstanceType.ShouldNotBeNull();
            _caseSettingsInstance.ShouldNotBeNull();
            _caseSettingsInstanceFixture.ShouldNotBeNull();
            _caseSettingsInstance.ShouldBeAssignableTo<CaseSettings>();
            _caseSettingsInstanceFixture.ShouldBeAssignableTo<CaseSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CaseSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycaseAssignNotificationTemplate)]
        [TestCaseGeneric(typeof(string) , PropertycaseCloseNotificationTemplate)]
        [TestCaseGeneric(typeof(string) , PropertycaseCommentNotificationTemplate)]
        [TestCaseGeneric(typeof(string) , PropertycaseCreateNotificationTemplate)]
        [TestCaseGeneric(typeof(bool) , PropertycloseCaseThroughStatusChange)]
        [TestCaseGeneric(typeof(bool) , PropertycloseCaseThroughStatusChangeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertydefaultCaseOwner)]
        [TestCaseGeneric(typeof(string) , PropertydefaultCaseOwnerType)]
        [TestCaseGeneric(typeof(string) , PropertydefaultCaseUser)]
        [TestCaseGeneric(typeof(EmailToCaseSettings) , PropertyemailToCase)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCaseFeed)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCaseFeedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableDraftEmails)]
        [TestCaseGeneric(typeof(bool) , PropertyenableDraftEmailsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableEarlyEscalationRuleTriggers)]
        [TestCaseGeneric(typeof(bool) , PropertyenableEarlyEscalationRuleTriggersSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableNewEmailDefaultTemplate)]
        [TestCaseGeneric(typeof(bool) , PropertyenableNewEmailDefaultTemplateSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedArticlesApplication)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedArticlesApplicationSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedArticlesCustomerPortal)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedArticlesCustomerPortalSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedArticlesPartnerPortal)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedArticlesPartnerPortalSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedSolutions)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSuggestedSolutionsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertykeepRecordTypeOnAssignmentRule)]
        [TestCaseGeneric(typeof(bool) , PropertykeepRecordTypeOnAssignmentRuleSpecified)]
        [TestCaseGeneric(typeof(string) , PropertynewEmailDefaultTemplateClass)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyContactOnCaseComment)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyContactOnCaseCommentSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyDefaultCaseOwner)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyDefaultCaseOwnerSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnerOnCaseComment)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnerOnCaseCommentSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnerOnCaseOwnerChange)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnerOnCaseOwnerChangeSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowFewerCloseActions)]
        [TestCaseGeneric(typeof(bool) , PropertyshowFewerCloseActionsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyuseSystemEmailAddress)]
        [TestCaseGeneric(typeof(bool) , PropertyuseSystemEmailAddressSpecified)]
        [TestCaseGeneric(typeof(WebToCaseSettings) , PropertywebToCase)]
        public void AUT_CaseSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CaseSettings, T>(_caseSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (caseAssignNotificationTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_caseAssignNotificationTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseAssignNotificationTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (caseCloseNotificationTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_caseCloseNotificationTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseCloseNotificationTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (caseCommentNotificationTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_caseCommentNotificationTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseCommentNotificationTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (caseCreateNotificationTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_caseCreateNotificationTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseCreateNotificationTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (closeCaseThroughStatusChange) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_closeCaseThroughStatusChange_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycloseCaseThroughStatusChange);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (closeCaseThroughStatusChangeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_closeCaseThroughStatusChangeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycloseCaseThroughStatusChangeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (defaultCaseOwner) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_defaultCaseOwner_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultCaseOwner);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (defaultCaseOwnerType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_defaultCaseOwnerType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultCaseOwnerType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (defaultCaseUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_defaultCaseUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultCaseUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (emailToCase) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_emailToCase_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyemailToCase);
            Action currentAction = () => propertyInfo.SetValue(_caseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (emailToCase) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_emailToCase_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailToCase);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableCaseFeed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableCaseFeed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCaseFeed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableCaseFeedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableCaseFeedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCaseFeedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableDraftEmails) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableDraftEmails_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableDraftEmails);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableDraftEmailsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableDraftEmailsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableDraftEmailsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableEarlyEscalationRuleTriggers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableEarlyEscalationRuleTriggers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableEarlyEscalationRuleTriggers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableEarlyEscalationRuleTriggersSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableEarlyEscalationRuleTriggersSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableEarlyEscalationRuleTriggersSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableNewEmailDefaultTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableNewEmailDefaultTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableNewEmailDefaultTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableNewEmailDefaultTemplateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableNewEmailDefaultTemplateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableNewEmailDefaultTemplateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedArticlesApplication) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedArticlesApplication_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedArticlesApplication);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedArticlesApplicationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedArticlesApplicationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedArticlesApplicationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedArticlesCustomerPortal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedArticlesCustomerPortal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedArticlesCustomerPortal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedArticlesCustomerPortalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedArticlesCustomerPortalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedArticlesCustomerPortalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedArticlesPartnerPortal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedArticlesPartnerPortal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedArticlesPartnerPortal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedArticlesPartnerPortalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedArticlesPartnerPortalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedArticlesPartnerPortalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedSolutions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedSolutions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedSolutions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (enableSuggestedSolutionsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_enableSuggestedSolutionsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSuggestedSolutionsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (keepRecordTypeOnAssignmentRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_keepRecordTypeOnAssignmentRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertykeepRecordTypeOnAssignmentRule);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (keepRecordTypeOnAssignmentRuleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_keepRecordTypeOnAssignmentRuleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertykeepRecordTypeOnAssignmentRuleSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (newEmailDefaultTemplateClass) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_newEmailDefaultTemplateClass_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynewEmailDefaultTemplateClass);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyContactOnCaseComment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyContactOnCaseComment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyContactOnCaseComment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyContactOnCaseCommentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyContactOnCaseCommentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyContactOnCaseCommentSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyDefaultCaseOwner) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyDefaultCaseOwner_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyDefaultCaseOwner);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyDefaultCaseOwnerSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyDefaultCaseOwnerSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyDefaultCaseOwnerSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyOwnerOnCaseComment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyOwnerOnCaseComment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnerOnCaseComment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyOwnerOnCaseCommentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyOwnerOnCaseCommentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnerOnCaseCommentSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyOwnerOnCaseOwnerChange) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyOwnerOnCaseOwnerChange_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnerOnCaseOwnerChange);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (notifyOwnerOnCaseOwnerChangeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_notifyOwnerOnCaseOwnerChangeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnerOnCaseOwnerChangeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (showFewerCloseActions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_showFewerCloseActions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowFewerCloseActions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (showFewerCloseActionsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_showFewerCloseActionsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowFewerCloseActionsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (useSystemEmailAddress) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_useSystemEmailAddress_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseSystemEmailAddress);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (useSystemEmailAddressSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_useSystemEmailAddressSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseSystemEmailAddressSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (webToCase) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_webToCase_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertywebToCase);
            Action currentAction = () => propertyInfo.SetValue(_caseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CaseSettings) => Property (webToCase) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CaseSettings_Public_Class_webToCase_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywebToCase);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}