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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowScreen" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowScreenTest : AbstractBaseSetupTypedTest<FlowScreen>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowScreen) Initializer

        private const string PropertyallowBack = "allowBack";
        private const string PropertyallowBackSpecified = "allowBackSpecified";
        private const string PropertyallowFinish = "allowFinish";
        private const string PropertyallowFinishSpecified = "allowFinishSpecified";
        private const string Propertyconnector = "connector";
        private const string Propertyfields = "fields";
        private const string PropertyhelpText = "helpText";
        private const string FieldallowBackField = "allowBackField";
        private const string FieldallowBackFieldSpecified = "allowBackFieldSpecified";
        private const string FieldallowFinishField = "allowFinishField";
        private const string FieldallowFinishFieldSpecified = "allowFinishFieldSpecified";
        private const string FieldconnectorField = "connectorField";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldhelpTextField = "helpTextField";
        private Type _flowScreenInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowScreen _flowScreenInstance;
        private FlowScreen _flowScreenInstanceFixture;

        #region General Initializer : Class (FlowScreen) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowScreen" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowScreenInstanceType = typeof(FlowScreen);
            _flowScreenInstanceFixture = Create(true);
            _flowScreenInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowScreen)

        #region General Initializer : Class (FlowScreen) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowScreen" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallowBack)]
        [TestCase(PropertyallowBackSpecified)]
        [TestCase(PropertyallowFinish)]
        [TestCase(PropertyallowFinishSpecified)]
        [TestCase(Propertyconnector)]
        [TestCase(Propertyfields)]
        [TestCase(PropertyhelpText)]
        public void AUT_FlowScreen_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowScreenInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowScreen) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowScreen" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallowBackField)]
        [TestCase(FieldallowBackFieldSpecified)]
        [TestCase(FieldallowFinishField)]
        [TestCase(FieldallowFinishFieldSpecified)]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldhelpTextField)]
        public void AUT_FlowScreen_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowScreenInstanceFixture, 
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
        ///     Class (<see cref="FlowScreen" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowScreen_Is_Instance_Present_Test()
        {
            // Assert
            _flowScreenInstanceType.ShouldNotBeNull();
            _flowScreenInstance.ShouldNotBeNull();
            _flowScreenInstanceFixture.ShouldNotBeNull();
            _flowScreenInstance.ShouldBeAssignableTo<FlowScreen>();
            _flowScreenInstanceFixture.ShouldBeAssignableTo<FlowScreen>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowScreen) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowScreen_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowScreen instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowScreenInstanceType.ShouldNotBeNull();
            _flowScreenInstance.ShouldNotBeNull();
            _flowScreenInstanceFixture.ShouldNotBeNull();
            _flowScreenInstance.ShouldBeAssignableTo<FlowScreen>();
            _flowScreenInstanceFixture.ShouldBeAssignableTo<FlowScreen>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowScreen) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyallowBack)]
        [TestCaseGeneric(typeof(bool) , PropertyallowBackSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyallowFinish)]
        [TestCaseGeneric(typeof(bool) , PropertyallowFinishSpecified)]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(FlowScreenField[]) , Propertyfields)]
        [TestCaseGeneric(typeof(string) , PropertyhelpText)]
        public void AUT_FlowScreen_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowScreen, T>(_flowScreenInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (allowBack) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_Public_Class_allowBack_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowBack);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (allowBackSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_Public_Class_allowBackSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowBackSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (allowFinish) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_Public_Class_allowFinish_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowFinish);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (allowFinishSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_Public_Class_allowFinishSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowFinishSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowScreenInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyconnector);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_flowScreenInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreen) => Property (helpText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreen_Public_Class_helpText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhelpText);

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