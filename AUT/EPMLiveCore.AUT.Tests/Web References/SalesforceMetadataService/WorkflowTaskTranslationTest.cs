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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowTaskTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowTaskTranslationTest : AbstractBaseSetupTypedTest<WorkflowTaskTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowTaskTranslation) Initializer

        private const string Propertydescription = "description";
        private const string Propertyname = "name";
        private const string Propertysubject = "subject";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldnameField = "nameField";
        private const string FieldsubjectField = "subjectField";
        private Type _workflowTaskTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowTaskTranslation _workflowTaskTranslationInstance;
        private WorkflowTaskTranslation _workflowTaskTranslationInstanceFixture;

        #region General Initializer : Class (WorkflowTaskTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowTaskTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowTaskTranslationInstanceType = typeof(WorkflowTaskTranslation);
            _workflowTaskTranslationInstanceFixture = Create(true);
            _workflowTaskTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowTaskTranslation)

        #region General Initializer : Class (WorkflowTaskTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowTaskTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(Propertyname)]
        [TestCase(Propertysubject)]
        public void AUT_WorkflowTaskTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowTaskTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowTaskTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowTaskTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldsubjectField)]
        public void AUT_WorkflowTaskTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowTaskTranslationInstanceFixture, 
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
        ///     Class (<see cref="WorkflowTaskTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowTaskTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _workflowTaskTranslationInstanceType.ShouldNotBeNull();
            _workflowTaskTranslationInstance.ShouldNotBeNull();
            _workflowTaskTranslationInstanceFixture.ShouldNotBeNull();
            _workflowTaskTranslationInstance.ShouldBeAssignableTo<WorkflowTaskTranslation>();
            _workflowTaskTranslationInstanceFixture.ShouldBeAssignableTo<WorkflowTaskTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowTaskTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowTaskTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowTaskTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowTaskTranslationInstanceType.ShouldNotBeNull();
            _workflowTaskTranslationInstance.ShouldNotBeNull();
            _workflowTaskTranslationInstanceFixture.ShouldNotBeNull();
            _workflowTaskTranslationInstance.ShouldBeAssignableTo<WorkflowTaskTranslation>();
            _workflowTaskTranslationInstanceFixture.ShouldBeAssignableTo<WorkflowTaskTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowTaskTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , Propertysubject)]
        public void AUT_WorkflowTaskTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowTaskTranslation, T>(_workflowTaskTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTaskTranslation) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTaskTranslation_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowTaskTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTaskTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowTaskTranslation) => Property (subject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowTaskTranslation_Public_Class_subject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysubject);

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