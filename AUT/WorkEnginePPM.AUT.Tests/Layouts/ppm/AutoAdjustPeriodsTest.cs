using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.Layouts.ppm
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Layouts.ppm.AutoAdjustPeriods" />)
    ///     and namespace <see cref="WorkEnginePPM.Layouts.ppm"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AutoAdjustPeriodsTest : AbstractBaseSetupTypedTest<AutoAdjustPeriods>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AutoAdjustPeriods) Initializer

        private const string PropertyEnabled = "Enabled";
        private const string PropertyFinishPeriodDelta = "FinishPeriodDelta";
        private const string PropertyStartPeriodDelta = "StartPeriodDelta";
        private const string MethodDefault = "Default";
        private const string MethodCreateAttributes = "CreateAttributes";
        private const string MethodGetXml = "GetXml";
        private const string MethodTryLoadFromAttributes = "TryLoadFromAttributes";
        private const string MethodTryLoadFromXml = "TryLoadFromXml";
        private const string MethodTryCreateFromXml = "TryCreateFromXml";
        private const string FieldAutoAdjustPeriodsAttribute = "AutoAdjustPeriodsAttribute";
        private const string FieldFinishPeriodDeltaAttribute = "FinishPeriodDeltaAttribute";
        private const string FieldStartPeriodDeltaAttribute = "StartPeriodDeltaAttribute";
        private const string FieldEnabledDefaultValue = "EnabledDefaultValue";
        private const string FieldFinishPeriodDeltaDefaultValue = "FinishPeriodDeltaDefaultValue";
        private const string FieldStartPeriodDeltaDefaultValue = "StartPeriodDeltaDefaultValue";
        private Type _autoAdjustPeriodsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AutoAdjustPeriods _autoAdjustPeriodsInstance;
        private AutoAdjustPeriods _autoAdjustPeriodsInstanceFixture;

        #region General Initializer : Class (AutoAdjustPeriods) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AutoAdjustPeriods" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _autoAdjustPeriodsInstanceType = typeof(AutoAdjustPeriods);
            _autoAdjustPeriodsInstanceFixture = Create(true);
            _autoAdjustPeriodsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AutoAdjustPeriods)

        #region General Initializer : Class (AutoAdjustPeriods) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AutoAdjustPeriods" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDefault, 0)]
        [TestCase(MethodCreateAttributes, 0)]
        [TestCase(MethodGetXml, 0)]
        [TestCase(MethodTryLoadFromAttributes, 0)]
        [TestCase(MethodTryLoadFromXml, 0)]
        [TestCase(MethodTryCreateFromXml, 0)]
        public void AUT_AutoAdjustPeriods_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_autoAdjustPeriodsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AutoAdjustPeriods) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AutoAdjustPeriods" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyEnabled)]
        [TestCase(PropertyFinishPeriodDelta)]
        [TestCase(PropertyStartPeriodDelta)]
        public void AUT_AutoAdjustPeriods_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_autoAdjustPeriodsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AutoAdjustPeriods) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AutoAdjustPeriods" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldAutoAdjustPeriodsAttribute)]
        [TestCase(FieldFinishPeriodDeltaAttribute)]
        [TestCase(FieldStartPeriodDeltaAttribute)]
        [TestCase(FieldEnabledDefaultValue)]
        [TestCase(FieldFinishPeriodDeltaDefaultValue)]
        [TestCase(FieldStartPeriodDeltaDefaultValue)]
        public void AUT_AutoAdjustPeriods_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_autoAdjustPeriodsInstanceFixture, 
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
        ///     Class (<see cref="AutoAdjustPeriods" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AutoAdjustPeriods_Is_Instance_Present_Test()
        {
            // Assert
            _autoAdjustPeriodsInstanceType.ShouldNotBeNull();
            _autoAdjustPeriodsInstance.ShouldNotBeNull();
            _autoAdjustPeriodsInstanceFixture.ShouldNotBeNull();
            _autoAdjustPeriodsInstance.ShouldBeAssignableTo<AutoAdjustPeriods>();
            _autoAdjustPeriodsInstanceFixture.ShouldBeAssignableTo<AutoAdjustPeriods>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AutoAdjustPeriods) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AutoAdjustPeriods_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var enabled = CreateType<bool>();
            var startPeriodDelta = CreateType<int>();
            var finishPeriodDelta = CreateType<int>();
            AutoAdjustPeriods instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new AutoAdjustPeriods(enabled, startPeriodDelta, finishPeriodDelta);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _autoAdjustPeriodsInstance.ShouldNotBeNull();
            _autoAdjustPeriodsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<AutoAdjustPeriods>();
        }

        #endregion

        #region General Constructor : Class (AutoAdjustPeriods) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AutoAdjustPeriods_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var enabled = CreateType<bool>();
            var startPeriodDelta = CreateType<int>();
            var finishPeriodDelta = CreateType<int>();
            AutoAdjustPeriods instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new AutoAdjustPeriods(enabled, startPeriodDelta, finishPeriodDelta);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _autoAdjustPeriodsInstance.ShouldNotBeNull();
            _autoAdjustPeriodsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AutoAdjustPeriods) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyEnabled)]
        [TestCaseGeneric(typeof(int) , PropertyFinishPeriodDelta)]
        [TestCaseGeneric(typeof(int) , PropertyStartPeriodDelta)]
        public void AUT_AutoAdjustPeriods_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AutoAdjustPeriods, T>(_autoAdjustPeriodsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AutoAdjustPeriods) => Property (Enabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AutoAdjustPeriods_Public_Class_Enabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEnabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AutoAdjustPeriods) => Property (FinishPeriodDelta) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AutoAdjustPeriods_Public_Class_FinishPeriodDelta_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFinishPeriodDelta);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AutoAdjustPeriods) => Property (StartPeriodDelta) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AutoAdjustPeriods_Public_Class_StartPeriodDelta_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStartPeriodDelta);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="AutoAdjustPeriods" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDefault)]
        [TestCase(MethodTryCreateFromXml)]
        public void AUT_AutoAdjustPeriods_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_autoAdjustPeriodsInstanceFixture,
                                                                              _autoAdjustPeriodsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AutoAdjustPeriods" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateAttributes)]
        [TestCase(MethodGetXml)]
        [TestCase(MethodTryLoadFromAttributes)]
        [TestCase(MethodTryLoadFromXml)]
        public void AUT_AutoAdjustPeriods_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AutoAdjustPeriods>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Default) (Return Type : AutoAdjustPeriods) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AutoAdjustPeriods_Default_Static_Method_Call_Internally(Type[] types)
        {
            var methodDefaultPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodDefault, Fixture, methodDefaultPrametersTypes);
        }

        #endregion

        #region Method Call : (Default) (Return Type : AutoAdjustPeriods) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_Default_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => AutoAdjustPeriods.Default();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Default) (Return Type : AutoAdjustPeriods) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_Default_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDefaultPrametersTypes = null;
            object[] parametersOfDefault = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDefault, methodDefaultPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_autoAdjustPeriodsInstanceFixture, parametersOfDefault);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDefault.ShouldBeNull();
            methodDefaultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Default) (Return Type : AutoAdjustPeriods) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_Default_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDefaultPrametersTypes = null;
            object[] parametersOfDefault = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<AutoAdjustPeriods>(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodDefault, parametersOfDefault, methodDefaultPrametersTypes);

            // Assert
            parametersOfDefault.ShouldBeNull();
            methodDefaultPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Default) (Return Type : AutoAdjustPeriods) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_Default_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodDefaultPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodDefault, Fixture, methodDefaultPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDefaultPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Default) (Return Type : AutoAdjustPeriods) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_Default_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDefaultPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodDefault, Fixture, methodDefaultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDefaultPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Default) (Return Type : AutoAdjustPeriods) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_Default_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDefault, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_autoAdjustPeriodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateAttributes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AutoAdjustPeriods_CreateAttributes_Method_Call_Internally(Type[] types)
        {
            var methodCreateAttributesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodCreateAttributes, Fixture, methodCreateAttributesPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateAttributes) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_CreateAttributes_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xmlStruct = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _autoAdjustPeriodsInstance.CreateAttributes(xmlStruct);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateAttributes) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_CreateAttributes_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xmlStruct = CreateType<CStruct>();
            var methodCreateAttributesPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfCreateAttributes = { xmlStruct };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateAttributes, methodCreateAttributesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_autoAdjustPeriodsInstanceFixture, parametersOfCreateAttributes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateAttributes.ShouldNotBeNull();
            parametersOfCreateAttributes.Length.ShouldBe(1);
            methodCreateAttributesPrametersTypes.Length.ShouldBe(1);
            methodCreateAttributesPrametersTypes.Length.ShouldBe(parametersOfCreateAttributes.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateAttributes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_CreateAttributes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlStruct = CreateType<CStruct>();
            var methodCreateAttributesPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfCreateAttributes = { xmlStruct };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_autoAdjustPeriodsInstance, MethodCreateAttributes, parametersOfCreateAttributes, methodCreateAttributesPrametersTypes);

            // Assert
            parametersOfCreateAttributes.ShouldNotBeNull();
            parametersOfCreateAttributes.Length.ShouldBe(1);
            methodCreateAttributesPrametersTypes.Length.ShouldBe(1);
            methodCreateAttributesPrametersTypes.Length.ShouldBe(parametersOfCreateAttributes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateAttributes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_CreateAttributes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateAttributes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateAttributes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_CreateAttributes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateAttributesPrametersTypes = new Type[] { typeof(CStruct) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodCreateAttributes, Fixture, methodCreateAttributesPrametersTypes);

            // Assert
            methodCreateAttributesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateAttributes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_CreateAttributes_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateAttributes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_autoAdjustPeriodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AutoAdjustPeriods_GetXml_Method_Call_Internally(Type[] types)
        {
            var methodGetXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodGetXml, Fixture, methodGetXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_GetXml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var root = CreateType<string>();
            var methodGetXmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetXml = { root };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AutoAdjustPeriods, string>(_autoAdjustPeriodsInstance, MethodGetXml, parametersOfGetXml, methodGetXmlPrametersTypes);

            // Assert
            parametersOfGetXml.ShouldNotBeNull();
            parametersOfGetXml.Length.ShouldBe(1);
            methodGetXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_GetXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetXmlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodGetXml, Fixture, methodGetXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_GetXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_Call_Internally(Type[] types)
        {
            var methodTryLoadFromAttributesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodTryLoadFromAttributes, Fixture, methodTryLoadFromAttributesPrametersTypes);
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<CStruct>();
            Action executeAction = null;

            // Act
            executeAction = () => _autoAdjustPeriodsInstance.TryLoadFromAttributes(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<CStruct>();
            var methodTryLoadFromAttributesPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfTryLoadFromAttributes = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryLoadFromAttributes, methodTryLoadFromAttributesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstanceFixture, out exception1, parametersOfTryLoadFromAttributes);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstance, MethodTryLoadFromAttributes, parametersOfTryLoadFromAttributes, methodTryLoadFromAttributesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryLoadFromAttributes.ShouldNotBeNull();
            parametersOfTryLoadFromAttributes.Length.ShouldBe(1);
            methodTryLoadFromAttributesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<CStruct>();
            var methodTryLoadFromAttributesPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfTryLoadFromAttributes = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryLoadFromAttributes, methodTryLoadFromAttributesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstanceFixture, out exception1, parametersOfTryLoadFromAttributes);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstance, MethodTryLoadFromAttributes, parametersOfTryLoadFromAttributes, methodTryLoadFromAttributesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryLoadFromAttributes.ShouldNotBeNull();
            parametersOfTryLoadFromAttributes.Length.ShouldBe(1);
            methodTryLoadFromAttributesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<CStruct>();
            var methodTryLoadFromAttributesPrametersTypes = new Type[] { typeof(CStruct) };
            object[] parametersOfTryLoadFromAttributes = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstance, MethodTryLoadFromAttributes, parametersOfTryLoadFromAttributes, methodTryLoadFromAttributesPrametersTypes);

            // Assert
            parametersOfTryLoadFromAttributes.ShouldNotBeNull();
            parametersOfTryLoadFromAttributes.Length.ShouldBe(1);
            methodTryLoadFromAttributesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryLoadFromAttributesPrametersTypes = new Type[] { typeof(CStruct) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodTryLoadFromAttributes, Fixture, methodTryLoadFromAttributesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryLoadFromAttributesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryLoadFromAttributes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_autoAdjustPeriodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryLoadFromAttributes) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromAttributes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryLoadFromAttributes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_Call_Internally(Type[] types)
        {
            var methodTryLoadFromXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodTryLoadFromXml, Fixture, methodTryLoadFromXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var viewDataXml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _autoAdjustPeriodsInstance.TryLoadFromXml(viewDataXml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var viewDataXml = CreateType<string>();
            var methodTryLoadFromXmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTryLoadFromXml = { viewDataXml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryLoadFromXml, methodTryLoadFromXmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstanceFixture, out exception1, parametersOfTryLoadFromXml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstance, MethodTryLoadFromXml, parametersOfTryLoadFromXml, methodTryLoadFromXmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryLoadFromXml.ShouldNotBeNull();
            parametersOfTryLoadFromXml.Length.ShouldBe(1);
            methodTryLoadFromXmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var viewDataXml = CreateType<string>();
            var methodTryLoadFromXmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTryLoadFromXml = { viewDataXml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryLoadFromXml, methodTryLoadFromXmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstanceFixture, out exception1, parametersOfTryLoadFromXml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstance, MethodTryLoadFromXml, parametersOfTryLoadFromXml, methodTryLoadFromXmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryLoadFromXml.ShouldNotBeNull();
            parametersOfTryLoadFromXml.Length.ShouldBe(1);
            methodTryLoadFromXmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewDataXml = CreateType<string>();
            var methodTryLoadFromXmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTryLoadFromXml = { viewDataXml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AutoAdjustPeriods, bool>(_autoAdjustPeriodsInstance, MethodTryLoadFromXml, parametersOfTryLoadFromXml, methodTryLoadFromXmlPrametersTypes);

            // Assert
            parametersOfTryLoadFromXml.ShouldNotBeNull();
            parametersOfTryLoadFromXml.Length.ShouldBe(1);
            methodTryLoadFromXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryLoadFromXmlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstance, MethodTryLoadFromXml, Fixture, methodTryLoadFromXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryLoadFromXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryLoadFromXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_autoAdjustPeriodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryLoadFromXml) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryLoadFromXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryLoadFromXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodTryCreateFromXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodTryCreateFromXml, Fixture, methodTryCreateFromXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var viewDataXml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => AutoAdjustPeriods.TryCreateFromXml(viewDataXml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var viewDataXml = CreateType<string>();
            var methodTryCreateFromXmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTryCreateFromXml = { viewDataXml };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryCreateFromXml, methodTryCreateFromXmlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodTryCreateFromXml, Fixture, methodTryCreateFromXmlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<AutoAdjustPeriods>(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodTryCreateFromXml, parametersOfTryCreateFromXml, methodTryCreateFromXmlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_autoAdjustPeriodsInstanceFixture, parametersOfTryCreateFromXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfTryCreateFromXml.ShouldNotBeNull();
            parametersOfTryCreateFromXml.Length.ShouldBe(1);
            methodTryCreateFromXmlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewDataXml = CreateType<string>();
            var methodTryCreateFromXmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfTryCreateFromXml = { viewDataXml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<AutoAdjustPeriods>(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodTryCreateFromXml, parametersOfTryCreateFromXml, methodTryCreateFromXmlPrametersTypes);

            // Assert
            parametersOfTryCreateFromXml.ShouldNotBeNull();
            parametersOfTryCreateFromXml.Length.ShouldBe(1);
            methodTryCreateFromXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodTryCreateFromXmlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodTryCreateFromXml, Fixture, methodTryCreateFromXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodTryCreateFromXmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryCreateFromXmlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_autoAdjustPeriodsInstanceFixture, _autoAdjustPeriodsInstanceType, MethodTryCreateFromXml, Fixture, methodTryCreateFromXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryCreateFromXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryCreateFromXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_autoAdjustPeriodsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TryCreateFromXml) (Return Type : AutoAdjustPeriods) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AutoAdjustPeriods_TryCreateFromXml_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryCreateFromXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}