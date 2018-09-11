using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.WebControls;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ResourceGrid" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceGridTest : AbstractBaseSetupTypedTest<ResourceGrid>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceGrid) Initializer

        private const string PropertyDelayScript = "DelayScript";
        private const string PropertyWebPartContextualInfo = "WebPartContextualInfo";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodCheckRibbonBehavior = "CheckRibbonBehavior";
        private const string MethodAddContextualTab = "AddContextualTab";
        private const string FieldASCX_PATH = "ASCX_PATH";
        private const string FieldHIDE_TAB = "HIDE_TAB";
        private const string FieldPAGE_TAB = "PAGE_TAB";
        private const string FieldMANAGE_TAB = "MANAGE_TAB";
        private const string FieldVIEWS_TAB = "VIEWS_TAB";
        private const string FieldVISIBILITY_CONTEXT = "VISIBILITY_CONTEXT";
        private const string Field_contextualTab = "_contextualTab";
        private const string Field_contextualTabTemplate = "_contextualTabTemplate";
        private Type _resourceGridInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceGrid _resourceGridInstance;
        private ResourceGrid _resourceGridInstanceFixture;

        #region General Initializer : Class (ResourceGrid) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceGrid" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceGridInstanceType = typeof(ResourceGrid);
            _resourceGridInstanceFixture = Create(true);
            _resourceGridInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceGrid)

        #region General Initializer : Class (ResourceGrid) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourceGrid" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodCheckRibbonBehavior, 0)]
        [TestCase(MethodAddContextualTab, 0)]
        public void AUT_ResourceGrid_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceGridInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceGrid) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceGrid" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDelayScript)]
        [TestCase(PropertyWebPartContextualInfo)]
        public void AUT_ResourceGrid_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resourceGridInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourceGrid) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourceGrid" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldASCX_PATH)]
        [TestCase(FieldHIDE_TAB)]
        [TestCase(FieldPAGE_TAB)]
        [TestCase(FieldMANAGE_TAB)]
        [TestCase(FieldVIEWS_TAB)]
        [TestCase(FieldVISIBILITY_CONTEXT)]
        [TestCase(Field_contextualTab)]
        [TestCase(Field_contextualTabTemplate)]
        public void AUT_ResourceGrid_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourceGridInstanceFixture, 
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
        ///     Class (<see cref="ResourceGrid" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceGrid_Is_Instance_Present_Test()
        {
            // Assert
            _resourceGridInstanceType.ShouldNotBeNull();
            _resourceGridInstance.ShouldNotBeNull();
            _resourceGridInstanceFixture.ShouldNotBeNull();
            _resourceGridInstance.ShouldBeAssignableTo<ResourceGrid>();
            _resourceGridInstanceFixture.ShouldBeAssignableTo<ResourceGrid>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceGrid) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourceGrid_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourceGrid instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceGridInstanceType.ShouldNotBeNull();
            _resourceGridInstance.ShouldNotBeNull();
            _resourceGridInstanceFixture.ShouldNotBeNull();
            _resourceGridInstance.ShouldBeAssignableTo<ResourceGrid>();
            _resourceGridInstanceFixture.ShouldBeAssignableTo<ResourceGrid>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ResourceGrid) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDelayScript)]
        [TestCaseGeneric(typeof(WebPartContextualInfo) , PropertyWebPartContextualInfo)]
        public void AUT_ResourceGrid_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ResourceGrid, T>(_resourceGridInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceGrid) => Property (DelayScript) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceGrid_Public_Class_DelayScript_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDelayScript);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ResourceGrid) => Property (WebPartContextualInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceGrid_WebPartContextualInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartContextualInfo);
            Action currentAction = () => propertyInfo.SetValue(_resourceGridInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ResourceGrid) => Property (WebPartContextualInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ResourceGrid_Public_Class_WebPartContextualInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartContextualInfo);

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
        ///      Class (<see cref="ResourceGrid" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodCheckRibbonBehavior)]
        [TestCase(MethodAddContextualTab)]
        public void AUT_ResourceGrid_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourceGrid>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceGridInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfCreateChildControls);

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
        public void AUT_ResourceGrid_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceGridInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_ResourceGrid_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceGridInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckRibbonBehavior) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_CheckRibbonBehavior_Method_Call_Internally(Type[] types)
        {
            var methodCheckRibbonBehaviorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceGridInstance, MethodCheckRibbonBehavior, Fixture, methodCheckRibbonBehaviorPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckRibbonBehavior) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_CheckRibbonBehavior_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCheckRibbonBehaviorPrametersTypes = null;
            object[] parametersOfCheckRibbonBehavior = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCheckRibbonBehavior, methodCheckRibbonBehaviorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfCheckRibbonBehavior);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCheckRibbonBehavior.ShouldBeNull();
            methodCheckRibbonBehaviorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckRibbonBehavior) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_CheckRibbonBehavior_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCheckRibbonBehaviorPrametersTypes = null;
            object[] parametersOfCheckRibbonBehavior = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceGridInstance, MethodCheckRibbonBehavior, parametersOfCheckRibbonBehavior, methodCheckRibbonBehaviorPrametersTypes);

            // Assert
            parametersOfCheckRibbonBehavior.ShouldBeNull();
            methodCheckRibbonBehaviorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckRibbonBehavior) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_CheckRibbonBehavior_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCheckRibbonBehaviorPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceGridInstance, MethodCheckRibbonBehavior, Fixture, methodCheckRibbonBehaviorPrametersTypes);

            // Assert
            methodCheckRibbonBehaviorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckRibbonBehavior) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_CheckRibbonBehavior_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckRibbonBehavior, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceGrid_AddContextualTab_Method_Call_Internally(Type[] types)
        {
            var methodAddContextualTabPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceGridInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_AddContextualTab_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, methodAddContextualTabPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceGridInstanceFixture, parametersOfAddContextualTab);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_AddContextualTab_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;
            object[] parametersOfAddContextualTab = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceGridInstance, MethodAddContextualTab, parametersOfAddContextualTab, methodAddContextualTabPrametersTypes);

            // Assert
            parametersOfAddContextualTab.ShouldBeNull();
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_AddContextualTab_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddContextualTabPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceGridInstance, MethodAddContextualTab, Fixture, methodAddContextualTabPrametersTypes);

            // Assert
            methodAddContextualTabPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddContextualTab) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceGrid_AddContextualTab_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddContextualTab, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceGridInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}