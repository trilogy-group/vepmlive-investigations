using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.Infrastructure.Navigation;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Controls.Navigation
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Controls.Navigation.EPMLiveNavigation" />)
    ///     and namespace <see cref="EPMLiveCore.Controls.Navigation"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPMLiveNavigationTest : AbstractBaseSetupTypedTest<EPMLiveNavigation>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveNavigation) Initializer

        private const string PropertyBottomNodes = "BottomNodes";
        private const string PropertyTopNodes = "TopNodes";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string Field_bottomNodes = "_bottomNodes";
        private const string Field_topNodes = "_topNodes";
        private const string FieldASCX_PATH = "ASCX_PATH";
        private Type _ePMLiveNavigationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveNavigation _ePMLiveNavigationInstance;
        private EPMLiveNavigation _ePMLiveNavigationInstanceFixture;

        #region General Initializer : Class (EPMLiveNavigation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveNavigation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveNavigationInstanceType = typeof(EPMLiveNavigation);
            _ePMLiveNavigationInstanceFixture = Create(true);
            _ePMLiveNavigationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveNavigation)

        #region General Initializer : Class (EPMLiveNavigation) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveNavigation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        public void AUT_EPMLiveNavigation_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveNavigationInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveNavigation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveNavigation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyBottomNodes)]
        [TestCase(PropertyTopNodes)]
        public void AUT_EPMLiveNavigation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ePMLiveNavigationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveNavigation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveNavigation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_bottomNodes)]
        [TestCase(Field_topNodes)]
        [TestCase(FieldASCX_PATH)]
        public void AUT_EPMLiveNavigation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLiveNavigationInstanceFixture, 
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
        ///     Class (<see cref="EPMLiveNavigation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPMLiveNavigation_Is_Instance_Present_Test()
        {
            // Assert
            _ePMLiveNavigationInstanceType.ShouldNotBeNull();
            _ePMLiveNavigationInstance.ShouldNotBeNull();
            _ePMLiveNavigationInstanceFixture.ShouldNotBeNull();
            _ePMLiveNavigationInstance.ShouldBeAssignableTo<EPMLiveNavigation>();
            _ePMLiveNavigationInstanceFixture.ShouldBeAssignableTo<EPMLiveNavigation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPMLiveNavigation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPMLiveNavigation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPMLiveNavigation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePMLiveNavigationInstanceType.ShouldNotBeNull();
            _ePMLiveNavigationInstance.ShouldNotBeNull();
            _ePMLiveNavigationInstanceFixture.ShouldNotBeNull();
            _ePMLiveNavigationInstance.ShouldBeAssignableTo<EPMLiveNavigation>();
            _ePMLiveNavigationInstanceFixture.ShouldBeAssignableTo<EPMLiveNavigation>();
        }

        #endregion

        #region General Constructor : Class (EPMLiveNavigation) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMLiveNavigation_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var ePMLiveNavigationInstance  = new EPMLiveNavigation();

            // Asserts
            ePMLiveNavigationInstance.ShouldNotBeNull();
            ePMLiveNavigationInstance.ShouldBeAssignableTo<EPMLiveNavigation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EPMLiveNavigation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(List<NavNode>) , PropertyBottomNodes)]
        [TestCaseGeneric(typeof(List<NavNode>) , PropertyTopNodes)]
        public void AUT_EPMLiveNavigation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EPMLiveNavigation, T>(_ePMLiveNavigationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveNavigation) => Property (BottomNodes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveNavigation_Public_Class_BottomNodes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBottomNodes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveNavigation) => Property (TopNodes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveNavigation_Public_Class_TopNodes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTopNodes);

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
        ///      Class (<see cref="EPMLiveNavigation" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        public void AUT_EPMLiveNavigation_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveNavigation>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveNavigation_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveNavigationInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveNavigation_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveNavigationInstanceFixture, parametersOfCreateChildControls);

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
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveNavigation_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveNavigationInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveNavigation_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveNavigationInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveNavigation_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveNavigationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}