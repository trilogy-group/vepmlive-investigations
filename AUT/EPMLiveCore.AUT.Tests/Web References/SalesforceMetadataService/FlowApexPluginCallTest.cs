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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowApexPluginCall" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowApexPluginCallTest : AbstractBaseSetupTypedTest<FlowApexPluginCall>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowApexPluginCall) Initializer

        private const string PropertyapexClass = "apexClass";
        private const string Propertyconnector = "connector";
        private const string PropertyfaultConnector = "faultConnector";
        private const string PropertyinputParameters = "inputParameters";
        private const string PropertyoutputParameters = "outputParameters";
        private const string FieldapexClassField = "apexClassField";
        private const string FieldconnectorField = "connectorField";
        private const string FieldfaultConnectorField = "faultConnectorField";
        private const string FieldinputParametersField = "inputParametersField";
        private const string FieldoutputParametersField = "outputParametersField";
        private Type _flowApexPluginCallInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowApexPluginCall _flowApexPluginCallInstance;
        private FlowApexPluginCall _flowApexPluginCallInstanceFixture;

        #region General Initializer : Class (FlowApexPluginCall) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowApexPluginCall" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowApexPluginCallInstanceType = typeof(FlowApexPluginCall);
            _flowApexPluginCallInstanceFixture = Create(true);
            _flowApexPluginCallInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowApexPluginCall)

        #region General Initializer : Class (FlowApexPluginCall) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowApexPluginCall" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapexClass)]
        [TestCase(Propertyconnector)]
        [TestCase(PropertyfaultConnector)]
        [TestCase(PropertyinputParameters)]
        [TestCase(PropertyoutputParameters)]
        public void AUT_FlowApexPluginCall_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowApexPluginCallInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowApexPluginCall) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowApexPluginCall" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapexClassField)]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldfaultConnectorField)]
        [TestCase(FieldinputParametersField)]
        [TestCase(FieldoutputParametersField)]
        public void AUT_FlowApexPluginCall_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowApexPluginCallInstanceFixture, 
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
        ///     Class (<see cref="FlowApexPluginCall" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowApexPluginCall_Is_Instance_Present_Test()
        {
            // Assert
            _flowApexPluginCallInstanceType.ShouldNotBeNull();
            _flowApexPluginCallInstance.ShouldNotBeNull();
            _flowApexPluginCallInstanceFixture.ShouldNotBeNull();
            _flowApexPluginCallInstance.ShouldBeAssignableTo<FlowApexPluginCall>();
            _flowApexPluginCallInstanceFixture.ShouldBeAssignableTo<FlowApexPluginCall>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowApexPluginCall) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowApexPluginCall_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowApexPluginCall instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowApexPluginCallInstanceType.ShouldNotBeNull();
            _flowApexPluginCallInstance.ShouldNotBeNull();
            _flowApexPluginCallInstanceFixture.ShouldNotBeNull();
            _flowApexPluginCallInstance.ShouldBeAssignableTo<FlowApexPluginCall>();
            _flowApexPluginCallInstanceFixture.ShouldBeAssignableTo<FlowApexPluginCall>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowApexPluginCall) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyapexClass)]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(FlowConnector) , PropertyfaultConnector)]
        [TestCaseGeneric(typeof(FlowApexPluginCallInputParameter[]) , PropertyinputParameters)]
        [TestCaseGeneric(typeof(FlowApexPluginCallOutputParameter[]) , PropertyoutputParameters)]
        public void AUT_FlowApexPluginCall_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowApexPluginCall, T>(_flowApexPluginCallInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (apexClass) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_Public_Class_apexClass_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapexClass);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowApexPluginCallInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (faultConnector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_faultConnector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfaultConnector);
            Action currentAction = () => propertyInfo.SetValue(_flowApexPluginCallInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (faultConnector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_Public_Class_faultConnector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfaultConnector);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (inputParameters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_inputParameters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyinputParameters);
            Action currentAction = () => propertyInfo.SetValue(_flowApexPluginCallInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (inputParameters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_Public_Class_inputParameters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinputParameters);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (outputParameters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_outputParameters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyoutputParameters);
            Action currentAction = () => propertyInfo.SetValue(_flowApexPluginCallInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCall) => Property (outputParameters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCall_Public_Class_outputParameters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoutputParameters);

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