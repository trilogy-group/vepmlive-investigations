using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ChatterAnswersSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ChatterAnswersSettingsTest : AbstractBaseSetupTypedTest<ChatterAnswersSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChatterAnswersSettings) Initializer

        private const string PropertyemailFollowersOnBestAnswer = "emailFollowersOnBestAnswer";
        private const string PropertyemailFollowersOnBestAnswerSpecified = "emailFollowersOnBestAnswerSpecified";
        private const string PropertyemailFollowersOnReply = "emailFollowersOnReply";
        private const string PropertyemailFollowersOnReplySpecified = "emailFollowersOnReplySpecified";
        private const string PropertyemailOwnerOnPrivateReply = "emailOwnerOnPrivateReply";
        private const string PropertyemailOwnerOnPrivateReplySpecified = "emailOwnerOnPrivateReplySpecified";
        private const string PropertyemailOwnerOnReply = "emailOwnerOnReply";
        private const string PropertyemailOwnerOnReplySpecified = "emailOwnerOnReplySpecified";
        private const string PropertyenableChatterAnswers = "enableChatterAnswers";
        private const string PropertyenableFacebookSSO = "enableFacebookSSO";
        private const string PropertyenableFacebookSSOSpecified = "enableFacebookSSOSpecified";
        private const string PropertyenableOptimizeQuestionFlow = "enableOptimizeQuestionFlow";
        private const string PropertyenableOptimizeQuestionFlowSpecified = "enableOptimizeQuestionFlowSpecified";
        private const string PropertyenableReputation = "enableReputation";
        private const string PropertyenableReputationSpecified = "enableReputationSpecified";
        private const string PropertyenableRichTextEditor = "enableRichTextEditor";
        private const string PropertyenableRichTextEditorSpecified = "enableRichTextEditorSpecified";
        private const string PropertyfacebookAuthProvider = "facebookAuthProvider";
        private const string PropertyshowInPortals = "showInPortals";
        private const string PropertyshowInPortalsSpecified = "showInPortalsSpecified";
        private const string FieldemailFollowersOnBestAnswerField = "emailFollowersOnBestAnswerField";
        private const string FieldemailFollowersOnBestAnswerFieldSpecified = "emailFollowersOnBestAnswerFieldSpecified";
        private const string FieldemailFollowersOnReplyField = "emailFollowersOnReplyField";
        private const string FieldemailFollowersOnReplyFieldSpecified = "emailFollowersOnReplyFieldSpecified";
        private const string FieldemailOwnerOnPrivateReplyField = "emailOwnerOnPrivateReplyField";
        private const string FieldemailOwnerOnPrivateReplyFieldSpecified = "emailOwnerOnPrivateReplyFieldSpecified";
        private const string FieldemailOwnerOnReplyField = "emailOwnerOnReplyField";
        private const string FieldemailOwnerOnReplyFieldSpecified = "emailOwnerOnReplyFieldSpecified";
        private const string FieldenableChatterAnswersField = "enableChatterAnswersField";
        private const string FieldenableFacebookSSOField = "enableFacebookSSOField";
        private const string FieldenableFacebookSSOFieldSpecified = "enableFacebookSSOFieldSpecified";
        private const string FieldenableOptimizeQuestionFlowField = "enableOptimizeQuestionFlowField";
        private const string FieldenableOptimizeQuestionFlowFieldSpecified = "enableOptimizeQuestionFlowFieldSpecified";
        private const string FieldenableReputationField = "enableReputationField";
        private const string FieldenableReputationFieldSpecified = "enableReputationFieldSpecified";
        private const string FieldenableRichTextEditorField = "enableRichTextEditorField";
        private const string FieldenableRichTextEditorFieldSpecified = "enableRichTextEditorFieldSpecified";
        private const string FieldfacebookAuthProviderField = "facebookAuthProviderField";
        private const string FieldshowInPortalsField = "showInPortalsField";
        private const string FieldshowInPortalsFieldSpecified = "showInPortalsFieldSpecified";
        private Type _chatterAnswersSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChatterAnswersSettings _chatterAnswersSettingsInstance;
        private ChatterAnswersSettings _chatterAnswersSettingsInstanceFixture;

        #region General Initializer : Class (ChatterAnswersSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChatterAnswersSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chatterAnswersSettingsInstanceType = typeof(ChatterAnswersSettings);
            _chatterAnswersSettingsInstanceFixture = Create(true);
            _chatterAnswersSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChatterAnswersSettings)

        #region General Initializer : Class (ChatterAnswersSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChatterAnswersSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyemailFollowersOnBestAnswer)]
        [TestCase(PropertyemailFollowersOnBestAnswerSpecified)]
        [TestCase(PropertyemailFollowersOnReply)]
        [TestCase(PropertyemailFollowersOnReplySpecified)]
        [TestCase(PropertyemailOwnerOnPrivateReply)]
        [TestCase(PropertyemailOwnerOnPrivateReplySpecified)]
        [TestCase(PropertyemailOwnerOnReply)]
        [TestCase(PropertyemailOwnerOnReplySpecified)]
        [TestCase(PropertyenableChatterAnswers)]
        [TestCase(PropertyenableFacebookSSO)]
        [TestCase(PropertyenableFacebookSSOSpecified)]
        [TestCase(PropertyenableOptimizeQuestionFlow)]
        [TestCase(PropertyenableOptimizeQuestionFlowSpecified)]
        [TestCase(PropertyenableReputation)]
        [TestCase(PropertyenableReputationSpecified)]
        [TestCase(PropertyenableRichTextEditor)]
        [TestCase(PropertyenableRichTextEditorSpecified)]
        [TestCase(PropertyfacebookAuthProvider)]
        [TestCase(PropertyshowInPortals)]
        [TestCase(PropertyshowInPortalsSpecified)]
        public void AUT_ChatterAnswersSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_chatterAnswersSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChatterAnswersSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChatterAnswersSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldemailFollowersOnBestAnswerField)]
        [TestCase(FieldemailFollowersOnBestAnswerFieldSpecified)]
        [TestCase(FieldemailFollowersOnReplyField)]
        [TestCase(FieldemailFollowersOnReplyFieldSpecified)]
        [TestCase(FieldemailOwnerOnPrivateReplyField)]
        [TestCase(FieldemailOwnerOnPrivateReplyFieldSpecified)]
        [TestCase(FieldemailOwnerOnReplyField)]
        [TestCase(FieldemailOwnerOnReplyFieldSpecified)]
        [TestCase(FieldenableChatterAnswersField)]
        [TestCase(FieldenableFacebookSSOField)]
        [TestCase(FieldenableFacebookSSOFieldSpecified)]
        [TestCase(FieldenableOptimizeQuestionFlowField)]
        [TestCase(FieldenableOptimizeQuestionFlowFieldSpecified)]
        [TestCase(FieldenableReputationField)]
        [TestCase(FieldenableReputationFieldSpecified)]
        [TestCase(FieldenableRichTextEditorField)]
        [TestCase(FieldenableRichTextEditorFieldSpecified)]
        [TestCase(FieldfacebookAuthProviderField)]
        [TestCase(FieldshowInPortalsField)]
        [TestCase(FieldshowInPortalsFieldSpecified)]
        public void AUT_ChatterAnswersSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chatterAnswersSettingsInstanceFixture, 
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
        ///     Class (<see cref="ChatterAnswersSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ChatterAnswersSettings_Is_Instance_Present_Test()
        {
            // Assert
            _chatterAnswersSettingsInstanceType.ShouldNotBeNull();
            _chatterAnswersSettingsInstance.ShouldNotBeNull();
            _chatterAnswersSettingsInstanceFixture.ShouldNotBeNull();
            _chatterAnswersSettingsInstance.ShouldBeAssignableTo<ChatterAnswersSettings>();
            _chatterAnswersSettingsInstanceFixture.ShouldBeAssignableTo<ChatterAnswersSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChatterAnswersSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ChatterAnswersSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChatterAnswersSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chatterAnswersSettingsInstanceType.ShouldNotBeNull();
            _chatterAnswersSettingsInstance.ShouldNotBeNull();
            _chatterAnswersSettingsInstanceFixture.ShouldNotBeNull();
            _chatterAnswersSettingsInstance.ShouldBeAssignableTo<ChatterAnswersSettings>();
            _chatterAnswersSettingsInstanceFixture.ShouldBeAssignableTo<ChatterAnswersSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChatterAnswersSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyemailFollowersOnBestAnswer)]
        [TestCaseGeneric(typeof(bool) , PropertyemailFollowersOnBestAnswerSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyemailFollowersOnReply)]
        [TestCaseGeneric(typeof(bool) , PropertyemailFollowersOnReplySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyemailOwnerOnPrivateReply)]
        [TestCaseGeneric(typeof(bool) , PropertyemailOwnerOnPrivateReplySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyemailOwnerOnReply)]
        [TestCaseGeneric(typeof(bool) , PropertyemailOwnerOnReplySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableChatterAnswers)]
        [TestCaseGeneric(typeof(bool) , PropertyenableFacebookSSO)]
        [TestCaseGeneric(typeof(bool) , PropertyenableFacebookSSOSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableOptimizeQuestionFlow)]
        [TestCaseGeneric(typeof(bool) , PropertyenableOptimizeQuestionFlowSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableReputation)]
        [TestCaseGeneric(typeof(bool) , PropertyenableReputationSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableRichTextEditor)]
        [TestCaseGeneric(typeof(bool) , PropertyenableRichTextEditorSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyfacebookAuthProvider)]
        [TestCaseGeneric(typeof(bool) , PropertyshowInPortals)]
        [TestCaseGeneric(typeof(bool) , PropertyshowInPortalsSpecified)]
        public void AUT_ChatterAnswersSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ChatterAnswersSettings, T>(_chatterAnswersSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailFollowersOnBestAnswer) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailFollowersOnBestAnswer_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailFollowersOnBestAnswer);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailFollowersOnBestAnswerSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailFollowersOnBestAnswerSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailFollowersOnBestAnswerSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailFollowersOnReply) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailFollowersOnReply_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailFollowersOnReply);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailFollowersOnReplySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailFollowersOnReplySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailFollowersOnReplySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailOwnerOnPrivateReply) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailOwnerOnPrivateReply_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailOwnerOnPrivateReply);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailOwnerOnPrivateReplySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailOwnerOnPrivateReplySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailOwnerOnPrivateReplySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailOwnerOnReply) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailOwnerOnReply_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailOwnerOnReply);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (emailOwnerOnReplySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_emailOwnerOnReplySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailOwnerOnReplySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableChatterAnswers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableChatterAnswers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableFacebookSSO) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableFacebookSSO_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableFacebookSSO);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableFacebookSSOSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableFacebookSSOSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableFacebookSSOSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableOptimizeQuestionFlow) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableOptimizeQuestionFlow_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableOptimizeQuestionFlow);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableOptimizeQuestionFlowSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableOptimizeQuestionFlowSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableOptimizeQuestionFlowSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableReputation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableReputation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableReputation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableReputationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableReputationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableReputationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableRichTextEditor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableRichTextEditor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableRichTextEditor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (enableRichTextEditorSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_enableRichTextEditorSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableRichTextEditorSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (facebookAuthProvider) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_facebookAuthProvider_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfacebookAuthProvider);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (showInPortals) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_showInPortals_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowInPortals);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterAnswersSettings) => Property (showInPortalsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterAnswersSettings_Public_Class_showInPortalsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowInPortalsSpecified);

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