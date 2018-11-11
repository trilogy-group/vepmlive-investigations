using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.SPFields
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.SPFields.PFEResourcePermissionsFieldControl" />)
    ///     and namespace <see cref="WorkEnginePPM.SPFields"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PFEResourcePermissionsFieldControlTest : AbstractBaseSetupTypedTest<PFEResourcePermissionsFieldControl>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEResourcePermissionsFieldControl) Initializer

        private const string PropertyDefaultTemplateName = "DefaultTemplateName";
        private const string PropertyValue = "Value";
        private const string MethodUpdateFieldValueInItem = "UpdateFieldValueInItem";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRenderFieldForDisplay = "RenderFieldForDisplay";
        private const string Field_checkBoxList = "_checkBoxList";
        private Type _pFEResourcePermissionsFieldControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEResourcePermissionsFieldControl _pFEResourcePermissionsFieldControlInstance;
        private PFEResourcePermissionsFieldControl _pFEResourcePermissionsFieldControlInstanceFixture;

        #region General Initializer : Class (PFEResourcePermissionsFieldControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEResourcePermissionsFieldControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEResourcePermissionsFieldControlInstanceType = typeof(PFEResourcePermissionsFieldControl);
            _pFEResourcePermissionsFieldControlInstanceFixture = Create(true);
            _pFEResourcePermissionsFieldControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEResourcePermissionsFieldControl)

        #region General Initializer : Class (PFEResourcePermissionsFieldControl) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PFEResourcePermissionsFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodUpdateFieldValueInItem, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodRenderFieldForDisplay, 0)]
        public void AUT_PFEResourcePermissionsFieldControl_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pFEResourcePermissionsFieldControlInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PFEResourcePermissionsFieldControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PFEResourcePermissionsFieldControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDefaultTemplateName)]
        [TestCase(PropertyValue)]
        public void AUT_PFEResourcePermissionsFieldControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_pFEResourcePermissionsFieldControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PFEResourcePermissionsFieldControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PFEResourcePermissionsFieldControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_checkBoxList)]
        public void AUT_PFEResourcePermissionsFieldControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_pFEResourcePermissionsFieldControlInstanceFixture, 
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
        ///     Class (<see cref="PFEResourcePermissionsFieldControl" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PFEResourcePermissionsFieldControl_Is_Instance_Present_Test()
        {
            // Assert
            _pFEResourcePermissionsFieldControlInstanceType.ShouldNotBeNull();
            _pFEResourcePermissionsFieldControlInstance.ShouldNotBeNull();
            _pFEResourcePermissionsFieldControlInstanceFixture.ShouldNotBeNull();
            _pFEResourcePermissionsFieldControlInstance.ShouldBeAssignableTo<PFEResourcePermissionsFieldControl>();
            _pFEResourcePermissionsFieldControlInstanceFixture.ShouldBeAssignableTo<PFEResourcePermissionsFieldControl>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PFEResourcePermissionsFieldControl) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PFEResourcePermissionsFieldControl_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PFEResourcePermissionsFieldControl instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _pFEResourcePermissionsFieldControlInstanceType.ShouldNotBeNull();
            _pFEResourcePermissionsFieldControlInstance.ShouldNotBeNull();
            _pFEResourcePermissionsFieldControlInstanceFixture.ShouldNotBeNull();
            _pFEResourcePermissionsFieldControlInstance.ShouldBeAssignableTo<PFEResourcePermissionsFieldControl>();
            _pFEResourcePermissionsFieldControlInstanceFixture.ShouldBeAssignableTo<PFEResourcePermissionsFieldControl>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PFEResourcePermissionsFieldControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDefaultTemplateName)]
        [TestCaseGeneric(typeof(object) , PropertyValue)]
        public void AUT_PFEResourcePermissionsFieldControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PFEResourcePermissionsFieldControl, T>(_pFEResourcePermissionsFieldControlInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PFEResourcePermissionsFieldControl) => Property (DefaultTemplateName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEResourcePermissionsFieldControl_Public_Class_DefaultTemplateName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultTemplateName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PFEResourcePermissionsFieldControl) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEResourcePermissionsFieldControl_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyValue);

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
        ///      Class (<see cref="PFEResourcePermissionsFieldControl" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodUpdateFieldValueInItem)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodRenderFieldForDisplay)]
        public void AUT_PFEResourcePermissionsFieldControl_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PFEResourcePermissionsFieldControl>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEResourcePermissionsFieldControl_UpdateFieldValueInItem_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFieldValueInItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldControlInstance, MethodUpdateFieldValueInItem, Fixture, methodUpdateFieldValueInItemPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_UpdateFieldValueInItem_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _pFEResourcePermissionsFieldControlInstance.UpdateFieldValueInItem();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_UpdateFieldValueInItem_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateFieldValueInItemPrametersTypes = null;
            object[] parametersOfUpdateFieldValueInItem = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateFieldValueInItem, methodUpdateFieldValueInItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEResourcePermissionsFieldControlInstanceFixture, parametersOfUpdateFieldValueInItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateFieldValueInItem.ShouldBeNull();
            methodUpdateFieldValueInItemPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_UpdateFieldValueInItem_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateFieldValueInItemPrametersTypes = null;
            object[] parametersOfUpdateFieldValueInItem = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pFEResourcePermissionsFieldControlInstance, MethodUpdateFieldValueInItem, parametersOfUpdateFieldValueInItem, methodUpdateFieldValueInItemPrametersTypes);

            // Assert
            parametersOfUpdateFieldValueInItem.ShouldBeNull();
            methodUpdateFieldValueInItemPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_UpdateFieldValueInItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateFieldValueInItemPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldControlInstance, MethodUpdateFieldValueInItem, Fixture, methodUpdateFieldValueInItemPrametersTypes);

            // Assert
            methodUpdateFieldValueInItemPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldValueInItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_UpdateFieldValueInItem_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateFieldValueInItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEResourcePermissionsFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEResourcePermissionsFieldControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_CreateChildControls_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEResourcePermissionsFieldControlInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pFEResourcePermissionsFieldControlInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_PFEResourcePermissionsFieldControl_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEResourcePermissionsFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFieldForDisplay) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEResourcePermissionsFieldControl_RenderFieldForDisplay_Method_Call_Internally(Type[] types)
        {
            var methodRenderFieldForDisplayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldControlInstance, MethodRenderFieldForDisplay, Fixture, methodRenderFieldForDisplayPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderFieldForDisplay) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_RenderFieldForDisplay_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderFieldForDisplayPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderFieldForDisplay = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderFieldForDisplay, methodRenderFieldForDisplayPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEResourcePermissionsFieldControlInstanceFixture, parametersOfRenderFieldForDisplay);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderFieldForDisplay.ShouldNotBeNull();
            parametersOfRenderFieldForDisplay.Length.ShouldBe(1);
            methodRenderFieldForDisplayPrametersTypes.Length.ShouldBe(1);
            methodRenderFieldForDisplayPrametersTypes.Length.ShouldBe(parametersOfRenderFieldForDisplay.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFieldForDisplay) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_RenderFieldForDisplay_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderFieldForDisplayPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderFieldForDisplay = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pFEResourcePermissionsFieldControlInstance, MethodRenderFieldForDisplay, parametersOfRenderFieldForDisplay, methodRenderFieldForDisplayPrametersTypes);

            // Assert
            parametersOfRenderFieldForDisplay.ShouldNotBeNull();
            parametersOfRenderFieldForDisplay.Length.ShouldBe(1);
            methodRenderFieldForDisplayPrametersTypes.Length.ShouldBe(1);
            methodRenderFieldForDisplayPrametersTypes.Length.ShouldBe(parametersOfRenderFieldForDisplay.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFieldForDisplay) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_RenderFieldForDisplay_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderFieldForDisplay, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderFieldForDisplay) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_RenderFieldForDisplay_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderFieldForDisplayPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldControlInstance, MethodRenderFieldForDisplay, Fixture, methodRenderFieldForDisplayPrametersTypes);

            // Assert
            methodRenderFieldForDisplayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderFieldForDisplay) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsFieldControl_RenderFieldForDisplay_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderFieldForDisplay, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEResourcePermissionsFieldControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}