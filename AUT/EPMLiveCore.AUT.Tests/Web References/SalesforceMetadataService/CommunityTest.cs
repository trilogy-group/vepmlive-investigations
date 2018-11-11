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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Community" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CommunityTest : AbstractBaseSetupTypedTest<Community>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Community) Initializer

        private const string Propertyactive = "active";
        private const string PropertyactiveSpecified = "activeSpecified";
        private const string PropertycommunityFeedPage = "communityFeedPage";
        private const string Propertydescription = "description";
        private const string PropertyemailFooterDocument = "emailFooterDocument";
        private const string PropertyemailHeaderDocument = "emailHeaderDocument";
        private const string PropertyenableChatterAnswers = "enableChatterAnswers";
        private const string PropertyenableChatterAnswersSpecified = "enableChatterAnswersSpecified";
        private const string PropertyenablePrivateQuestions = "enablePrivateQuestions";
        private const string PropertyenablePrivateQuestionsSpecified = "enablePrivateQuestionsSpecified";
        private const string PropertyexpertsGroup = "expertsGroup";
        private const string Propertyportal = "portal";
        private const string PropertyportalEmailNotificationUrl = "portalEmailNotificationUrl";
        private const string PropertyreputationLevels = "reputationLevels";
        private const string PropertyshowInPortal = "showInPortal";
        private const string PropertyshowInPortalSpecified = "showInPortalSpecified";
        private const string Propertysite = "site";
        private const string FieldactiveField = "activeField";
        private const string FieldactiveFieldSpecified = "activeFieldSpecified";
        private const string FieldcommunityFeedPageField = "communityFeedPageField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldemailFooterDocumentField = "emailFooterDocumentField";
        private const string FieldemailHeaderDocumentField = "emailHeaderDocumentField";
        private const string FieldenableChatterAnswersField = "enableChatterAnswersField";
        private const string FieldenableChatterAnswersFieldSpecified = "enableChatterAnswersFieldSpecified";
        private const string FieldenablePrivateQuestionsField = "enablePrivateQuestionsField";
        private const string FieldenablePrivateQuestionsFieldSpecified = "enablePrivateQuestionsFieldSpecified";
        private const string FieldexpertsGroupField = "expertsGroupField";
        private const string FieldportalField = "portalField";
        private const string FieldportalEmailNotificationUrlField = "portalEmailNotificationUrlField";
        private const string FieldreputationLevelsField = "reputationLevelsField";
        private const string FieldshowInPortalField = "showInPortalField";
        private const string FieldshowInPortalFieldSpecified = "showInPortalFieldSpecified";
        private const string FieldsiteField = "siteField";
        private Type _communityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Community _communityInstance;
        private Community _communityInstanceFixture;

        #region General Initializer : Class (Community) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Community" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _communityInstanceType = typeof(Community);
            _communityInstanceFixture = Create(true);
            _communityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Community)

        #region General Initializer : Class (Community) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Community" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(PropertyactiveSpecified)]
        [TestCase(PropertycommunityFeedPage)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyemailFooterDocument)]
        [TestCase(PropertyemailHeaderDocument)]
        [TestCase(PropertyenableChatterAnswers)]
        [TestCase(PropertyenableChatterAnswersSpecified)]
        [TestCase(PropertyenablePrivateQuestions)]
        [TestCase(PropertyenablePrivateQuestionsSpecified)]
        [TestCase(PropertyexpertsGroup)]
        [TestCase(Propertyportal)]
        [TestCase(PropertyportalEmailNotificationUrl)]
        [TestCase(PropertyreputationLevels)]
        [TestCase(PropertyshowInPortal)]
        [TestCase(PropertyshowInPortalSpecified)]
        [TestCase(Propertysite)]
        public void AUT_Community_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_communityInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Community) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Community" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FieldactiveFieldSpecified)]
        [TestCase(FieldcommunityFeedPageField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldemailFooterDocumentField)]
        [TestCase(FieldemailHeaderDocumentField)]
        [TestCase(FieldenableChatterAnswersField)]
        [TestCase(FieldenableChatterAnswersFieldSpecified)]
        [TestCase(FieldenablePrivateQuestionsField)]
        [TestCase(FieldenablePrivateQuestionsFieldSpecified)]
        [TestCase(FieldexpertsGroupField)]
        [TestCase(FieldportalField)]
        [TestCase(FieldportalEmailNotificationUrlField)]
        [TestCase(FieldreputationLevelsField)]
        [TestCase(FieldshowInPortalField)]
        [TestCase(FieldshowInPortalFieldSpecified)]
        [TestCase(FieldsiteField)]
        public void AUT_Community_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_communityInstanceFixture, 
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
        ///     Class (<see cref="Community" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Community_Is_Instance_Present_Test()
        {
            // Assert
            _communityInstanceType.ShouldNotBeNull();
            _communityInstance.ShouldNotBeNull();
            _communityInstanceFixture.ShouldNotBeNull();
            _communityInstance.ShouldBeAssignableTo<Community>();
            _communityInstanceFixture.ShouldBeAssignableTo<Community>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Community) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Community_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Community instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _communityInstanceType.ShouldNotBeNull();
            _communityInstance.ShouldNotBeNull();
            _communityInstanceFixture.ShouldNotBeNull();
            _communityInstance.ShouldBeAssignableTo<Community>();
            _communityInstanceFixture.ShouldBeAssignableTo<Community>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Community) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(bool) , PropertyactiveSpecified)]
        [TestCaseGeneric(typeof(string) , PropertycommunityFeedPage)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertyemailFooterDocument)]
        [TestCaseGeneric(typeof(string) , PropertyemailHeaderDocument)]
        [TestCaseGeneric(typeof(bool) , PropertyenableChatterAnswers)]
        [TestCaseGeneric(typeof(bool) , PropertyenableChatterAnswersSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenablePrivateQuestions)]
        [TestCaseGeneric(typeof(bool) , PropertyenablePrivateQuestionsSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyexpertsGroup)]
        [TestCaseGeneric(typeof(string) , Propertyportal)]
        [TestCaseGeneric(typeof(string) , PropertyportalEmailNotificationUrl)]
        [TestCaseGeneric(typeof(ChatterAnswersReputationLevel[]) , PropertyreputationLevels)]
        [TestCaseGeneric(typeof(bool) , PropertyshowInPortal)]
        [TestCaseGeneric(typeof(bool) , PropertyshowInPortalSpecified)]
        [TestCaseGeneric(typeof(string) , Propertysite)]
        public void AUT_Community_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Community, T>(_communityInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (activeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_activeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyactiveSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (communityFeedPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_communityFeedPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycommunityFeedPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (emailFooterDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_emailFooterDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailFooterDocument);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (emailHeaderDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_emailHeaderDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailHeaderDocument);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (enableChatterAnswers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_enableChatterAnswers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableChatterAnswers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (enableChatterAnswersSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_enableChatterAnswersSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableChatterAnswersSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (enablePrivateQuestions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_enablePrivateQuestions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenablePrivateQuestions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (enablePrivateQuestionsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_enablePrivateQuestionsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenablePrivateQuestionsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (expertsGroup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_expertsGroup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexpertsGroup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (portal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_portal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyportal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (portalEmailNotificationUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_portalEmailNotificationUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyportalEmailNotificationUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (reputationLevels) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_reputationLevels_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyreputationLevels);
            Action currentAction = () => propertyInfo.SetValue(_communityInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (reputationLevels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_reputationLevels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreputationLevels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (showInPortal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_showInPortal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowInPortal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (showInPortalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_showInPortalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowInPortalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Community) => Property (site) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Community_Public_Class_site_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysite);

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