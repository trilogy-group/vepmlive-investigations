using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls.WebParts;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ContextualHelpSlideOut" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ContextualHelpSlideOutTest : AbstractBaseSetupTypedTest<ContextualHelpSlideOut>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ContextualHelpSlideOut) Initializer

        private const string PropertyChromeType = "ChromeType";
        private const string PropertyContentLocation = "ContentLocation";
        private const string PropertySlideOutOffSet = "SlideOutOffSet";
        private const string PropertySlideOutTitle = "SlideOutTitle";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string Field_contentLocation = "_contentLocation";
        private const string Field_slideOutOffset = "_slideOutOffset";
        private const string Field_slideOutTitle = "_slideOutTitle";
        private Type _contextualHelpSlideOutInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ContextualHelpSlideOut _contextualHelpSlideOutInstance;
        private ContextualHelpSlideOut _contextualHelpSlideOutInstanceFixture;

        #region General Initializer : Class (ContextualHelpSlideOut) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ContextualHelpSlideOut" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _contextualHelpSlideOutInstanceType = typeof(ContextualHelpSlideOut);
            _contextualHelpSlideOutInstanceFixture = Create(true);
            _contextualHelpSlideOutInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ContextualHelpSlideOut)

        #region General Initializer : Class (ContextualHelpSlideOut) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ContextualHelpSlideOut" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        public void AUT_ContextualHelpSlideOut_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_contextualHelpSlideOutInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ContextualHelpSlideOut) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ContextualHelpSlideOut" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyChromeType)]
        [TestCase(PropertyContentLocation)]
        [TestCase(PropertySlideOutOffSet)]
        [TestCase(PropertySlideOutTitle)]
        public void AUT_ContextualHelpSlideOut_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_contextualHelpSlideOutInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ContextualHelpSlideOut) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ContextualHelpSlideOut" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Field_contentLocation)]
        [TestCase(Field_slideOutOffset)]
        [TestCase(Field_slideOutTitle)]
        public void AUT_ContextualHelpSlideOut_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_contextualHelpSlideOutInstanceFixture, 
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
        ///     Class (<see cref="ContextualHelpSlideOut" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ContextualHelpSlideOut_Is_Instance_Present_Test()
        {
            // Assert
            _contextualHelpSlideOutInstanceType.ShouldNotBeNull();
            _contextualHelpSlideOutInstance.ShouldNotBeNull();
            _contextualHelpSlideOutInstanceFixture.ShouldNotBeNull();
            _contextualHelpSlideOutInstance.ShouldBeAssignableTo<ContextualHelpSlideOut>();
            _contextualHelpSlideOutInstanceFixture.ShouldBeAssignableTo<ContextualHelpSlideOut>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ContextualHelpSlideOut) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ContextualHelpSlideOut_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ContextualHelpSlideOut instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _contextualHelpSlideOutInstanceType.ShouldNotBeNull();
            _contextualHelpSlideOutInstance.ShouldNotBeNull();
            _contextualHelpSlideOutInstanceFixture.ShouldNotBeNull();
            _contextualHelpSlideOutInstance.ShouldBeAssignableTo<ContextualHelpSlideOut>();
            _contextualHelpSlideOutInstanceFixture.ShouldBeAssignableTo<ContextualHelpSlideOut>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ContextualHelpSlideOut) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(PartChromeType) , PropertyChromeType)]
        [TestCaseGeneric(typeof(string) , PropertyContentLocation)]
        [TestCaseGeneric(typeof(int) , PropertySlideOutOffSet)]
        [TestCaseGeneric(typeof(string) , PropertySlideOutTitle)]
        public void AUT_ContextualHelpSlideOut_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ContextualHelpSlideOut, T>(_contextualHelpSlideOutInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ContextualHelpSlideOut) => Property (ChromeType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContextualHelpSlideOut_ChromeType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyChromeType);
            Action currentAction = () => propertyInfo.SetValue(_contextualHelpSlideOutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ContextualHelpSlideOut) => Property (ChromeType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContextualHelpSlideOut_Public_Class_ChromeType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChromeType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContextualHelpSlideOut) => Property (ContentLocation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContextualHelpSlideOut_Public_Class_ContentLocation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyContentLocation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContextualHelpSlideOut) => Property (SlideOutOffSet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContextualHelpSlideOut_Public_Class_SlideOutOffSet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySlideOutOffSet);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContextualHelpSlideOut) => Property (SlideOutTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContextualHelpSlideOut_Public_Class_SlideOutTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySlideOutTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ContextualHelpSlideOut" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        public void AUT_ContextualHelpSlideOut_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ContextualHelpSlideOut>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ContextualHelpSlideOut_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_contextualHelpSlideOutInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ContextualHelpSlideOut_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_contextualHelpSlideOutInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ContextualHelpSlideOut_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_contextualHelpSlideOutInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ContextualHelpSlideOut_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_contextualHelpSlideOutInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ContextualHelpSlideOut_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_contextualHelpSlideOutInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}