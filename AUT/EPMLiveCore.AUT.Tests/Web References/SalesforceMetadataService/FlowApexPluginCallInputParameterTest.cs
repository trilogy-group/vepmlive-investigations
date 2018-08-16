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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowApexPluginCallInputParameter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowApexPluginCallInputParameterTest : AbstractBaseSetupTypedTest<FlowApexPluginCallInputParameter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowApexPluginCallInputParameter) Initializer

        private const string Propertyname = "name";
        private const string Propertyvalue = "value";
        private const string FieldnameField = "nameField";
        private const string FieldvalueField = "valueField";
        private Type _flowApexPluginCallInputParameterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowApexPluginCallInputParameter _flowApexPluginCallInputParameterInstance;
        private FlowApexPluginCallInputParameter _flowApexPluginCallInputParameterInstanceFixture;

        #region General Initializer : Class (FlowApexPluginCallInputParameter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowApexPluginCallInputParameter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowApexPluginCallInputParameterInstanceType = typeof(FlowApexPluginCallInputParameter);
            _flowApexPluginCallInputParameterInstanceFixture = Create(true);
            _flowApexPluginCallInputParameterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowApexPluginCallInputParameter)

        #region General Initializer : Class (FlowApexPluginCallInputParameter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowApexPluginCallInputParameter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyname)]
        [TestCase(Propertyvalue)]
        public void AUT_FlowApexPluginCallInputParameter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowApexPluginCallInputParameterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowApexPluginCallInputParameter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowApexPluginCallInputParameter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FieldvalueField)]
        public void AUT_FlowApexPluginCallInputParameter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowApexPluginCallInputParameterInstanceFixture, 
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
        ///     Class (<see cref="FlowApexPluginCallInputParameter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowApexPluginCallInputParameter_Is_Instance_Present_Test()
        {
            // Assert
            _flowApexPluginCallInputParameterInstanceType.ShouldNotBeNull();
            _flowApexPluginCallInputParameterInstance.ShouldNotBeNull();
            _flowApexPluginCallInputParameterInstanceFixture.ShouldNotBeNull();
            _flowApexPluginCallInputParameterInstance.ShouldBeAssignableTo<FlowApexPluginCallInputParameter>();
            _flowApexPluginCallInputParameterInstanceFixture.ShouldBeAssignableTo<FlowApexPluginCallInputParameter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowApexPluginCallInputParameter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowApexPluginCallInputParameter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowApexPluginCallInputParameter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowApexPluginCallInputParameterInstanceType.ShouldNotBeNull();
            _flowApexPluginCallInputParameterInstance.ShouldNotBeNull();
            _flowApexPluginCallInputParameterInstanceFixture.ShouldNotBeNull();
            _flowApexPluginCallInputParameterInstance.ShouldBeAssignableTo<FlowApexPluginCallInputParameter>();
            _flowApexPluginCallInputParameterInstanceFixture.ShouldBeAssignableTo<FlowApexPluginCallInputParameter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowApexPluginCallInputParameter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , Propertyvalue)]
        public void AUT_FlowApexPluginCallInputParameter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowApexPluginCallInputParameter, T>(_flowApexPluginCallInputParameterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCallInputParameter) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCallInputParameter_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowApexPluginCallInputParameter) => Property (value) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCallInputParameter_value_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalue);
            Action currentAction = () => propertyInfo.SetValue(_flowApexPluginCallInputParameterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowApexPluginCallInputParameter) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowApexPluginCallInputParameter_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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