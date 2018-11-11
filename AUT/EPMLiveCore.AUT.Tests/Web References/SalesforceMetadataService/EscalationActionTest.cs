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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EscalationAction" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EscalationActionTest : AbstractBaseSetupTypedTest<EscalationAction>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EscalationAction) Initializer

        private const string PropertyassignedTo = "assignedTo";
        private const string PropertyassignedToTemplate = "assignedToTemplate";
        private const string PropertyassignedToType = "assignedToType";
        private const string PropertyassignedToTypeSpecified = "assignedToTypeSpecified";
        private const string PropertyminutesToEscalation = "minutesToEscalation";
        private const string PropertyminutesToEscalationSpecified = "minutesToEscalationSpecified";
        private const string PropertynotifyCaseOwner = "notifyCaseOwner";
        private const string PropertynotifyCaseOwnerSpecified = "notifyCaseOwnerSpecified";
        private const string PropertynotifyEmail = "notifyEmail";
        private const string PropertynotifyTo = "notifyTo";
        private const string PropertynotifyToTemplate = "notifyToTemplate";
        private const string FieldassignedToField = "assignedToField";
        private const string FieldassignedToTemplateField = "assignedToTemplateField";
        private const string FieldassignedToTypeField = "assignedToTypeField";
        private const string FieldassignedToTypeFieldSpecified = "assignedToTypeFieldSpecified";
        private const string FieldminutesToEscalationField = "minutesToEscalationField";
        private const string FieldminutesToEscalationFieldSpecified = "minutesToEscalationFieldSpecified";
        private const string FieldnotifyCaseOwnerField = "notifyCaseOwnerField";
        private const string FieldnotifyCaseOwnerFieldSpecified = "notifyCaseOwnerFieldSpecified";
        private const string FieldnotifyEmailField = "notifyEmailField";
        private const string FieldnotifyToField = "notifyToField";
        private const string FieldnotifyToTemplateField = "notifyToTemplateField";
        private Type _escalationActionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EscalationAction _escalationActionInstance;
        private EscalationAction _escalationActionInstanceFixture;

        #region General Initializer : Class (EscalationAction) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EscalationAction" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _escalationActionInstanceType = typeof(EscalationAction);
            _escalationActionInstanceFixture = Create(true);
            _escalationActionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EscalationAction)

        #region General Initializer : Class (EscalationAction) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EscalationAction" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignedTo)]
        [TestCase(PropertyassignedToTemplate)]
        [TestCase(PropertyassignedToType)]
        [TestCase(PropertyassignedToTypeSpecified)]
        [TestCase(PropertyminutesToEscalation)]
        [TestCase(PropertyminutesToEscalationSpecified)]
        [TestCase(PropertynotifyCaseOwner)]
        [TestCase(PropertynotifyCaseOwnerSpecified)]
        [TestCase(PropertynotifyEmail)]
        [TestCase(PropertynotifyTo)]
        [TestCase(PropertynotifyToTemplate)]
        public void AUT_EscalationAction_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_escalationActionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EscalationAction) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EscalationAction" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignedToField)]
        [TestCase(FieldassignedToTemplateField)]
        [TestCase(FieldassignedToTypeField)]
        [TestCase(FieldassignedToTypeFieldSpecified)]
        [TestCase(FieldminutesToEscalationField)]
        [TestCase(FieldminutesToEscalationFieldSpecified)]
        [TestCase(FieldnotifyCaseOwnerField)]
        [TestCase(FieldnotifyCaseOwnerFieldSpecified)]
        [TestCase(FieldnotifyEmailField)]
        [TestCase(FieldnotifyToField)]
        [TestCase(FieldnotifyToTemplateField)]
        public void AUT_EscalationAction_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_escalationActionInstanceFixture, 
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
        ///     Class (<see cref="EscalationAction" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EscalationAction_Is_Instance_Present_Test()
        {
            // Assert
            _escalationActionInstanceType.ShouldNotBeNull();
            _escalationActionInstance.ShouldNotBeNull();
            _escalationActionInstanceFixture.ShouldNotBeNull();
            _escalationActionInstance.ShouldBeAssignableTo<EscalationAction>();
            _escalationActionInstanceFixture.ShouldBeAssignableTo<EscalationAction>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EscalationAction) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EscalationAction_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EscalationAction instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _escalationActionInstanceType.ShouldNotBeNull();
            _escalationActionInstance.ShouldNotBeNull();
            _escalationActionInstanceFixture.ShouldNotBeNull();
            _escalationActionInstance.ShouldBeAssignableTo<EscalationAction>();
            _escalationActionInstanceFixture.ShouldBeAssignableTo<EscalationAction>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EscalationAction) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignedTo)]
        [TestCaseGeneric(typeof(string) , PropertyassignedToTemplate)]
        [TestCaseGeneric(typeof(AssignToLookupValueType) , PropertyassignedToType)]
        [TestCaseGeneric(typeof(bool) , PropertyassignedToTypeSpecified)]
        [TestCaseGeneric(typeof(int) , PropertyminutesToEscalation)]
        [TestCaseGeneric(typeof(bool) , PropertyminutesToEscalationSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyCaseOwner)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyCaseOwnerSpecified)]
        [TestCaseGeneric(typeof(string[]) , PropertynotifyEmail)]
        [TestCaseGeneric(typeof(string) , PropertynotifyTo)]
        [TestCaseGeneric(typeof(string) , PropertynotifyToTemplate)]
        public void AUT_EscalationAction_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EscalationAction, T>(_escalationActionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (assignedTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_assignedTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (assignedToTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_assignedToTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedToTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (assignedToType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_assignedToType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyassignedToType);
            Action currentAction = () => propertyInfo.SetValue(_escalationActionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (assignedToType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_assignedToType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedToType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (assignedToTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_assignedToTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignedToTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (minutesToEscalation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_minutesToEscalation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminutesToEscalation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (minutesToEscalationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_minutesToEscalationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminutesToEscalationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (notifyCaseOwner) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_notifyCaseOwner_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyCaseOwner);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (notifyCaseOwnerSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_notifyCaseOwnerSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyCaseOwnerSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (notifyEmail) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_notifyEmail_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynotifyEmail);
            Action currentAction = () => propertyInfo.SetValue(_escalationActionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (notifyEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_notifyEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (notifyTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_notifyTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EscalationAction) => Property (notifyToTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EscalationAction_Public_Class_notifyToTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyToTemplate);

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