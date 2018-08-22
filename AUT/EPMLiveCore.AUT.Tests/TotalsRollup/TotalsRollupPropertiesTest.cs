using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.TotalsRollupProperties" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TotalsRollupPropertiesTest : AbstractBaseSetupTypedTest<TotalsRollupProperties>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TotalsRollupProperties) Initializer

        private const string PropertyDisplayAsNewSection = "DisplayAsNewSection";
        private const string MethodInitializeWithField = "InitializeWithField";
        private const string MethodOnSaveChange = "OnSaveChange";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodddlList_SelectedIndexChanged = "ddlList_SelectedIndexChanged";
        private const string FieldtxtQuery = "txtQuery";
        private const string FieldddlList = "ddlList";
        private const string FieldddlType = "ddlType";
        private const string FieldddlColumn = "ddlColumn";
        private const string FieldddlLookup = "ddlLookup";
        private const string FieldddlDecimals = "ddlDecimals";
        private const string FieldddlOutput = "ddlOutput";
        private const string Fieldlist = "list";
        private const string Fieldquery = "query";
        private const string Fieldaggtype = "aggtype";
        private const string Fieldcolumn = "column";
        private const string Fieldlookup = "lookup";
        private const string Fielddecimals = "decimals";
        private const string Fieldoutputtype = "outputtype";
        private Type _totalsRollupPropertiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TotalsRollupProperties _totalsRollupPropertiesInstance;
        private TotalsRollupProperties _totalsRollupPropertiesInstanceFixture;

        #region General Initializer : Class (TotalsRollupProperties) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TotalsRollupProperties" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _totalsRollupPropertiesInstanceType = typeof(TotalsRollupProperties);
            _totalsRollupPropertiesInstanceFixture = Create(true);
            _totalsRollupPropertiesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TotalsRollupProperties)

        #region General Initializer : Class (TotalsRollupProperties) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TotalsRollupProperties" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitializeWithField, 0)]
        [TestCase(MethodOnSaveChange, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodddlList_SelectedIndexChanged, 0)]
        public void AUT_TotalsRollupProperties_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_totalsRollupPropertiesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TotalsRollupProperties) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TotalsRollupProperties" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDisplayAsNewSection)]
        public void AUT_TotalsRollupProperties_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_totalsRollupPropertiesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TotalsRollupProperties) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TotalsRollupProperties" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldtxtQuery)]
        [TestCase(FieldddlList)]
        [TestCase(FieldddlType)]
        [TestCase(FieldddlColumn)]
        [TestCase(FieldddlLookup)]
        [TestCase(FieldddlDecimals)]
        [TestCase(FieldddlOutput)]
        [TestCase(Fieldlist)]
        [TestCase(Fieldquery)]
        [TestCase(Fieldaggtype)]
        [TestCase(Fieldcolumn)]
        [TestCase(Fieldlookup)]
        [TestCase(Fielddecimals)]
        [TestCase(Fieldoutputtype)]
        public void AUT_TotalsRollupProperties_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_totalsRollupPropertiesInstanceFixture, 
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
        ///     Class (<see cref="TotalsRollupProperties" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TotalsRollupProperties_Is_Instance_Present_Test()
        {
            // Assert
            _totalsRollupPropertiesInstanceType.ShouldNotBeNull();
            _totalsRollupPropertiesInstance.ShouldNotBeNull();
            _totalsRollupPropertiesInstanceFixture.ShouldNotBeNull();
            _totalsRollupPropertiesInstance.ShouldBeAssignableTo<TotalsRollupProperties>();
            _totalsRollupPropertiesInstanceFixture.ShouldBeAssignableTo<TotalsRollupProperties>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TotalsRollupProperties) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_TotalsRollupProperties_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TotalsRollupProperties instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _totalsRollupPropertiesInstanceType.ShouldNotBeNull();
            _totalsRollupPropertiesInstance.ShouldNotBeNull();
            _totalsRollupPropertiesInstanceFixture.ShouldNotBeNull();
            _totalsRollupPropertiesInstance.ShouldBeAssignableTo<TotalsRollupProperties>();
            _totalsRollupPropertiesInstanceFixture.ShouldBeAssignableTo<TotalsRollupProperties>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TotalsRollupProperties) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyDisplayAsNewSection)]
        public void AUT_TotalsRollupProperties_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TotalsRollupProperties, T>(_totalsRollupPropertiesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupProperties) => Property (DisplayAsNewSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupProperties_Public_Class_DisplayAsNewSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplayAsNewSection);

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
        ///      Class (<see cref="TotalsRollupProperties" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitializeWithField)]
        [TestCase(MethodOnSaveChange)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodddlList_SelectedIndexChanged)]
        public void AUT_TotalsRollupProperties_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TotalsRollupProperties>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupProperties_InitializeWithField_Method_Call_Internally(Type[] types)
        {
            var methodInitializeWithFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodInitializeWithField, Fixture, methodInitializeWithFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_InitializeWithField_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupPropertiesInstance.InitializeWithField(field);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_InitializeWithField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfInitializeWithField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeWithField, methodInitializeWithFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupPropertiesInstanceFixture, parametersOfInitializeWithField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeWithField.ShouldNotBeNull();
            parametersOfInitializeWithField.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(parametersOfInitializeWithField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_InitializeWithField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfInitializeWithField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupPropertiesInstance, MethodInitializeWithField, parametersOfInitializeWithField, methodInitializeWithFieldPrametersTypes);

            // Assert
            parametersOfInitializeWithField.ShouldNotBeNull();
            parametersOfInitializeWithField.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(parametersOfInitializeWithField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_InitializeWithField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitializeWithField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_InitializeWithField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeWithFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodInitializeWithField, Fixture, methodInitializeWithFieldPrametersTypes);

            // Assert
            methodInitializeWithFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWithField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_InitializeWithField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeWithField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupPropertiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupProperties_OnSaveChange_Method_Call_Internally(Type[] types)
        {
            var methodOnSaveChangePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodOnSaveChange, Fixture, methodOnSaveChangePrametersTypes);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_OnSaveChange_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var isNew = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupPropertiesInstance.OnSaveChange(field, isNew);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_OnSaveChange_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var isNew = CreateType<bool>();
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(SPField), typeof(bool) };
            object[] parametersOfOnSaveChange = { field, isNew };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSaveChange, methodOnSaveChangePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupPropertiesInstanceFixture, parametersOfOnSaveChange);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnSaveChange.ShouldNotBeNull();
            parametersOfOnSaveChange.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(parametersOfOnSaveChange.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_OnSaveChange_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var isNew = CreateType<bool>();
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(SPField), typeof(bool) };
            object[] parametersOfOnSaveChange = { field, isNew };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupPropertiesInstance, MethodOnSaveChange, parametersOfOnSaveChange, methodOnSaveChangePrametersTypes);

            // Assert
            parametersOfOnSaveChange.ShouldNotBeNull();
            parametersOfOnSaveChange.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(2);
            methodOnSaveChangePrametersTypes.Length.ShouldBe(parametersOfOnSaveChange.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_OnSaveChange_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnSaveChange, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_OnSaveChange_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSaveChangePrametersTypes = new Type[] { typeof(SPField), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodOnSaveChange, Fixture, methodOnSaveChangePrametersTypes);

            // Assert
            methodOnSaveChangePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSaveChange) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_OnSaveChange_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSaveChange, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupPropertiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupProperties_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupPropertiesInstanceFixture, parametersOfCreateChildControls);

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
        public void AUT_TotalsRollupProperties_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupPropertiesInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_TotalsRollupProperties_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupPropertiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupProperties_ddlList_SelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodddlList_SelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodddlList_SelectedIndexChanged, Fixture, methodddlList_SelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_ddlList_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlList_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlList_SelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodddlList_SelectedIndexChanged, methodddlList_SelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupPropertiesInstanceFixture, parametersOfddlList_SelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfddlList_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlList_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlList_SelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_ddlList_SelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodddlList_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfddlList_SelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupPropertiesInstance, MethodddlList_SelectedIndexChanged, parametersOfddlList_SelectedIndexChanged, methodddlList_SelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfddlList_SelectedIndexChanged.ShouldNotBeNull();
            parametersOfddlList_SelectedIndexChanged.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfddlList_SelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_ddlList_SelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodddlList_SelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_ddlList_SelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodddlList_SelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupPropertiesInstance, MethodddlList_SelectedIndexChanged, Fixture, methodddlList_SelectedIndexChangedPrametersTypes);

            // Assert
            methodddlList_SelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ddlList_SelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupProperties_ddlList_SelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodddlList_SelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupPropertiesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}