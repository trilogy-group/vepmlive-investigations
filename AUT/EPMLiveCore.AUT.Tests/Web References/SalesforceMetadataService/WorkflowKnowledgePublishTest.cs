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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowKnowledgePublish" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowKnowledgePublishTest : AbstractBaseSetupTypedTest<WorkflowKnowledgePublish>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowKnowledgePublish) Initializer

        private const string Propertyaction = "action";
        private const string Propertydescription = "description";
        private const string Propertylabel = "label";
        private const string Propertylanguage = "language";
        private const string FieldactionField = "actionField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldlabelField = "labelField";
        private const string FieldlanguageField = "languageField";
        private const string FieldprotectedField = "protectedField";
        private Type _workflowKnowledgePublishInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowKnowledgePublish _workflowKnowledgePublishInstance;
        private WorkflowKnowledgePublish _workflowKnowledgePublishInstanceFixture;

        #region General Initializer : Class (WorkflowKnowledgePublish) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowKnowledgePublish" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowKnowledgePublishInstanceType = typeof(WorkflowKnowledgePublish);
            _workflowKnowledgePublishInstanceFixture = Create(true);
            _workflowKnowledgePublishInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowKnowledgePublish)

        #region General Initializer : Class (WorkflowKnowledgePublish) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowKnowledgePublish" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyaction)]
        [TestCase(Propertydescription)]
        [TestCase(Propertylabel)]
        [TestCase(Propertylanguage)]
        public void AUT_WorkflowKnowledgePublish_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowKnowledgePublishInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowKnowledgePublish) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowKnowledgePublish" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactionField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlanguageField)]
        [TestCase(FieldprotectedField)]
        public void AUT_WorkflowKnowledgePublish_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowKnowledgePublishInstanceFixture, 
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
        ///     Class (<see cref="WorkflowKnowledgePublish" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowKnowledgePublish_Is_Instance_Present_Test()
        {
            // Assert
            _workflowKnowledgePublishInstanceType.ShouldNotBeNull();
            _workflowKnowledgePublishInstance.ShouldNotBeNull();
            _workflowKnowledgePublishInstanceFixture.ShouldNotBeNull();
            _workflowKnowledgePublishInstance.ShouldBeAssignableTo<WorkflowKnowledgePublish>();
            _workflowKnowledgePublishInstanceFixture.ShouldBeAssignableTo<WorkflowKnowledgePublish>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowKnowledgePublish) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowKnowledgePublish_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowKnowledgePublish instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowKnowledgePublishInstanceType.ShouldNotBeNull();
            _workflowKnowledgePublishInstance.ShouldNotBeNull();
            _workflowKnowledgePublishInstanceFixture.ShouldNotBeNull();
            _workflowKnowledgePublishInstance.ShouldBeAssignableTo<WorkflowKnowledgePublish>();
            _workflowKnowledgePublishInstanceFixture.ShouldBeAssignableTo<WorkflowKnowledgePublish>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowKnowledgePublish) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(KnowledgeWorkflowAction) , Propertyaction)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertylanguage)]
        public void AUT_WorkflowKnowledgePublish_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowKnowledgePublish, T>(_workflowKnowledgePublishInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (WorkflowKnowledgePublish) => Property (action) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowKnowledgePublish_action_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyaction);
            Action currentAction = () => propertyInfo.SetValue(_workflowKnowledgePublishInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowKnowledgePublish) => Property (action) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowKnowledgePublish_Public_Class_action_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyaction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowKnowledgePublish) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowKnowledgePublish_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowKnowledgePublish) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowKnowledgePublish_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowKnowledgePublish) => Property (language) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowKnowledgePublish_Public_Class_language_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylanguage);

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