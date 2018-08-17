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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowEmailRecipient" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowEmailRecipientTest : AbstractBaseSetupTypedTest<WorkflowEmailRecipient>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowEmailRecipient) Initializer

        private const string Propertyfield = "field";
        private const string Propertyrecipient = "recipient";
        private const string Propertytype = "type";
        private const string FieldfieldField = "fieldField";
        private const string FieldrecipientField = "recipientField";
        private const string FieldtypeField = "typeField";
        private Type _workflowEmailRecipientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowEmailRecipient _workflowEmailRecipientInstance;
        private WorkflowEmailRecipient _workflowEmailRecipientInstanceFixture;

        #region General Initializer : Class (WorkflowEmailRecipient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowEmailRecipient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowEmailRecipientInstanceType = typeof(WorkflowEmailRecipient);
            _workflowEmailRecipientInstanceFixture = Create(true);
            _workflowEmailRecipientInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowEmailRecipient)

        #region General Initializer : Class (WorkflowEmailRecipient) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowEmailRecipient" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfield)]
        [TestCase(Propertyrecipient)]
        [TestCase(Propertytype)]
        public void AUT_WorkflowEmailRecipient_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowEmailRecipientInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowEmailRecipient) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowEmailRecipient" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldField)]
        [TestCase(FieldrecipientField)]
        [TestCase(FieldtypeField)]
        public void AUT_WorkflowEmailRecipient_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowEmailRecipientInstanceFixture, 
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
        ///     Class (<see cref="WorkflowEmailRecipient" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowEmailRecipient_Is_Instance_Present_Test()
        {
            // Assert
            _workflowEmailRecipientInstanceType.ShouldNotBeNull();
            _workflowEmailRecipientInstance.ShouldNotBeNull();
            _workflowEmailRecipientInstanceFixture.ShouldNotBeNull();
            _workflowEmailRecipientInstance.ShouldBeAssignableTo<WorkflowEmailRecipient>();
            _workflowEmailRecipientInstanceFixture.ShouldBeAssignableTo<WorkflowEmailRecipient>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowEmailRecipient) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowEmailRecipient_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowEmailRecipient instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowEmailRecipientInstanceType.ShouldNotBeNull();
            _workflowEmailRecipientInstance.ShouldNotBeNull();
            _workflowEmailRecipientInstanceFixture.ShouldNotBeNull();
            _workflowEmailRecipientInstance.ShouldBeAssignableTo<WorkflowEmailRecipient>();
            _workflowEmailRecipientInstanceFixture.ShouldBeAssignableTo<WorkflowEmailRecipient>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowEmailRecipient) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(string) , Propertyrecipient)]
        [TestCaseGeneric(typeof(ActionEmailRecipientTypes) , Propertytype)]
        public void AUT_WorkflowEmailRecipient_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowEmailRecipient, T>(_workflowEmailRecipientInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEmailRecipient) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowEmailRecipient_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEmailRecipient) => Property (recipient) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowEmailRecipient_Public_Class_recipient_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrecipient);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEmailRecipient) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowEmailRecipient_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_workflowEmailRecipientInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowEmailRecipient) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowEmailRecipient_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

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