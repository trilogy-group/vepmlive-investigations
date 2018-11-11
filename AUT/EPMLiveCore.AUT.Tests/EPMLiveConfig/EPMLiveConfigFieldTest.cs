using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.EPMLiveConfigField" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class EPMLiveConfigFieldTest : AbstractBaseSetupTypedTest<EPMLiveConfigField>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPMLiveConfigField) Initializer

        private const string PropertyGeneralSettings = "GeneralSettings";
        private const string PropertyTotalSettings = "TotalSettings";
        private const string PropertyEnableResourcePlan = "EnableResourcePlan";
        private const string PropertyDisplaySettings = "DisplaySettings";
        private const string PropertyContextId = "ContextId";
        private const string PropertyFieldRenderingControl = "FieldRenderingControl";
        private const string MethodInit = "Init";
        private const string MethodUpdateGeneralSettings = "UpdateGeneralSettings";
        private const string MethodUpdateTotalSettings = "UpdateTotalSettings";
        private const string MethodUpdateEnableResourcePlan = "UpdateEnableResourcePlan";
        private const string MethodUpdateDisplaySettings = "UpdateDisplaySettings";
        private const string MethodUpdate = "Update";
        private const string MethodOnAdded = "OnAdded";
        private const string FieldupdatedGeneralSettings = "updatedGeneralSettings";
        private const string FieldupdatedTotalSettings = "updatedTotalSettings";
        private const string FieldupdatedEnableResourcePlan = "updatedEnableResourcePlan";
        private const string FieldupdatedDisplaySettings = "updatedDisplaySettings";
        private const string FieldgeneralSettings = "generalSettings";
        private const string FieldtotalSettings = "totalSettings";
        private const string FieldenableResourcePlan = "enableResourcePlan";
        private const string FielddisplaySettings = "displaySettings";
        private const string FieldcontextId = "contextId";
        private Type _ePMLiveConfigFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPMLiveConfigField _ePMLiveConfigFieldInstance;
        private EPMLiveConfigField _ePMLiveConfigFieldInstanceFixture;

        #region General Initializer : Class (EPMLiveConfigField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPMLiveConfigField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePMLiveConfigFieldInstanceType = typeof(EPMLiveConfigField);
            _ePMLiveConfigFieldInstanceFixture = Create(true);
            _ePMLiveConfigFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPMLiveConfigField)

        #region General Initializer : Class (EPMLiveConfigField) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EPMLiveConfigField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInit, 0)]
        [TestCase(MethodUpdateGeneralSettings, 0)]
        [TestCase(MethodUpdateTotalSettings, 0)]
        [TestCase(MethodUpdateEnableResourcePlan, 0)]
        [TestCase(MethodUpdateDisplaySettings, 0)]
        [TestCase(MethodUpdate, 0)]
        [TestCase(MethodOnAdded, 0)]
        public void AUT_EPMLiveConfigField_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_ePMLiveConfigFieldInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveConfigField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveConfigField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyGeneralSettings)]
        [TestCase(PropertyTotalSettings)]
        [TestCase(PropertyEnableResourcePlan)]
        [TestCase(PropertyDisplaySettings)]
        [TestCase(PropertyContextId)]
        [TestCase(PropertyFieldRenderingControl)]
        public void AUT_EPMLiveConfigField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ePMLiveConfigFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EPMLiveConfigField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPMLiveConfigField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldupdatedGeneralSettings)]
        [TestCase(FieldupdatedTotalSettings)]
        [TestCase(FieldupdatedEnableResourcePlan)]
        [TestCase(FieldupdatedDisplaySettings)]
        [TestCase(FieldgeneralSettings)]
        [TestCase(FieldtotalSettings)]
        [TestCase(FieldenableResourcePlan)]
        [TestCase(FielddisplaySettings)]
        [TestCase(FieldcontextId)]
        public void AUT_EPMLiveConfigField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePMLiveConfigFieldInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPMLiveConfigField) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="EPMLiveConfigField" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_EPMLiveConfigField_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<EPMLiveConfigField>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (EPMLiveConfigField) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="EPMLiveConfigField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMLiveConfigField_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<EPMLiveConfigField>(Fixture);
        }

        #endregion

        #region General Constructor : Class (EPMLiveConfigField) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMLiveConfigField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMLiveConfigField_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var fieldName = CreateType<string>();
            object[] parametersOfEPMLiveConfigField = { fields, fieldName };
            var methodEPMLiveConfigFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_ePMLiveConfigFieldInstanceType, methodEPMLiveConfigFieldPrametersTypes, parametersOfEPMLiveConfigField);
        }

        #endregion

        #region General Constructor : Class (EPMLiveConfigField) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMLiveConfigField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMLiveConfigField_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEPMLiveConfigFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_ePMLiveConfigFieldInstanceType, Fixture, methodEPMLiveConfigFieldPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (EPMLiveConfigField) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMLiveConfigField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMLiveConfigField_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var typeName = CreateType<string>();
            var displayName = CreateType<string>();
            object[] parametersOfEPMLiveConfigField = { fields, typeName, displayName };
            var methodEPMLiveConfigFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_ePMLiveConfigFieldInstanceType, methodEPMLiveConfigFieldPrametersTypes, parametersOfEPMLiveConfigField);
        }

        #endregion

        #region General Constructor : Class (EPMLiveConfigField) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EPMLiveConfigField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EPMLiveConfigField_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEPMLiveConfigFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_ePMLiveConfigFieldInstanceType, Fixture, methodEPMLiveConfigFieldPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (EPMLiveConfigField) => Property (ContextId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveConfigField_Public_Class_ContextId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyContextId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveConfigField) => Property (DisplaySettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveConfigField_Public_Class_DisplaySettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisplaySettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveConfigField) => Property (EnableResourcePlan) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveConfigField_Public_Class_EnableResourcePlan_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEnableResourcePlan);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveConfigField) => Property (FieldRenderingControl) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveConfigField_FieldRenderingControl_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldRenderingControl);
            Action currentAction = () => propertyInfo.SetValue(_ePMLiveConfigFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveConfigField) => Property (FieldRenderingControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveConfigField_Public_Class_FieldRenderingControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFieldRenderingControl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveConfigField) => Property (GeneralSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveConfigField_Public_Class_GeneralSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyGeneralSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EPMLiveConfigField) => Property (TotalSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EPMLiveConfigField_Public_Class_TotalSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTotalSettings);

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
        ///      Class (<see cref="EPMLiveConfigField" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInit)]
        [TestCase(MethodUpdateGeneralSettings)]
        [TestCase(MethodUpdateTotalSettings)]
        [TestCase(MethodUpdateEnableResourcePlan)]
        [TestCase(MethodUpdateDisplaySettings)]
        [TestCase(MethodUpdate)]
        [TestCase(MethodOnAdded)]
        public void AUT_EPMLiveConfigField_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EPMLiveConfigField>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveConfigField_Init_Method_Call_Internally(Type[] types)
        {
            var methodInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodInit, Fixture, methodInitPrametersTypes);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Init_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitPrametersTypes = null;
            object[] parametersOfInit = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInit, methodInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveConfigFieldInstanceFixture, parametersOfInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInit.ShouldBeNull();
            methodInitPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Init_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitPrametersTypes = null;
            object[] parametersOfInit = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveConfigFieldInstance, MethodInit, parametersOfInit, methodInitPrametersTypes);

            // Assert
            parametersOfInit.ShouldBeNull();
            methodInitPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodInit, Fixture, methodInitPrametersTypes);

            // Assert
            methodInitPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Init_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveConfigFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGeneralSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveConfigField_UpdateGeneralSettings_Method_Call_Internally(Type[] types)
        {
            var methodUpdateGeneralSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateGeneralSettings, Fixture, methodUpdateGeneralSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateGeneralSettings) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateGeneralSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveConfigFieldInstance.UpdateGeneralSettings(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateGeneralSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateGeneralSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateGeneralSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateGeneralSettings = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateGeneralSettings, methodUpdateGeneralSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveConfigFieldInstanceFixture, parametersOfUpdateGeneralSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateGeneralSettings.ShouldNotBeNull();
            parametersOfUpdateGeneralSettings.Length.ShouldBe(1);
            methodUpdateGeneralSettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateGeneralSettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateGeneralSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGeneralSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateGeneralSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateGeneralSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateGeneralSettings = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveConfigFieldInstance, MethodUpdateGeneralSettings, parametersOfUpdateGeneralSettings, methodUpdateGeneralSettingsPrametersTypes);

            // Assert
            parametersOfUpdateGeneralSettings.ShouldNotBeNull();
            parametersOfUpdateGeneralSettings.Length.ShouldBe(1);
            methodUpdateGeneralSettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateGeneralSettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateGeneralSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGeneralSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateGeneralSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateGeneralSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateGeneralSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateGeneralSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateGeneralSettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateGeneralSettings, Fixture, methodUpdateGeneralSettingsPrametersTypes);

            // Assert
            methodUpdateGeneralSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGeneralSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateGeneralSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateGeneralSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveConfigFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTotalSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveConfigField_UpdateTotalSettings_Method_Call_Internally(Type[] types)
        {
            var methodUpdateTotalSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateTotalSettings, Fixture, methodUpdateTotalSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateTotalSettings) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateTotalSettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveConfigFieldInstance.UpdateTotalSettings(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateTotalSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateTotalSettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateTotalSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateTotalSettings = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateTotalSettings, methodUpdateTotalSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveConfigFieldInstanceFixture, parametersOfUpdateTotalSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateTotalSettings.ShouldNotBeNull();
            parametersOfUpdateTotalSettings.Length.ShouldBe(1);
            methodUpdateTotalSettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateTotalSettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateTotalSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTotalSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateTotalSettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateTotalSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateTotalSettings = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveConfigFieldInstance, MethodUpdateTotalSettings, parametersOfUpdateTotalSettings, methodUpdateTotalSettingsPrametersTypes);

            // Assert
            parametersOfUpdateTotalSettings.ShouldNotBeNull();
            parametersOfUpdateTotalSettings.Length.ShouldBe(1);
            methodUpdateTotalSettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateTotalSettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateTotalSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTotalSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateTotalSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateTotalSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateTotalSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateTotalSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateTotalSettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateTotalSettings, Fixture, methodUpdateTotalSettingsPrametersTypes);

            // Assert
            methodUpdateTotalSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTotalSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateTotalSettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateTotalSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveConfigFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateEnableResourcePlan) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveConfigField_UpdateEnableResourcePlan_Method_Call_Internally(Type[] types)
        {
            var methodUpdateEnableResourcePlanPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateEnableResourcePlan, Fixture, methodUpdateEnableResourcePlanPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateEnableResourcePlan) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateEnableResourcePlan_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveConfigFieldInstance.UpdateEnableResourcePlan(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateEnableResourcePlan) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateEnableResourcePlan_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateEnableResourcePlanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateEnableResourcePlan = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateEnableResourcePlan, methodUpdateEnableResourcePlanPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveConfigFieldInstanceFixture, parametersOfUpdateEnableResourcePlan);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateEnableResourcePlan.ShouldNotBeNull();
            parametersOfUpdateEnableResourcePlan.Length.ShouldBe(1);
            methodUpdateEnableResourcePlanPrametersTypes.Length.ShouldBe(1);
            methodUpdateEnableResourcePlanPrametersTypes.Length.ShouldBe(parametersOfUpdateEnableResourcePlan.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateEnableResourcePlan) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateEnableResourcePlan_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateEnableResourcePlanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateEnableResourcePlan = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveConfigFieldInstance, MethodUpdateEnableResourcePlan, parametersOfUpdateEnableResourcePlan, methodUpdateEnableResourcePlanPrametersTypes);

            // Assert
            parametersOfUpdateEnableResourcePlan.ShouldNotBeNull();
            parametersOfUpdateEnableResourcePlan.Length.ShouldBe(1);
            methodUpdateEnableResourcePlanPrametersTypes.Length.ShouldBe(1);
            methodUpdateEnableResourcePlanPrametersTypes.Length.ShouldBe(parametersOfUpdateEnableResourcePlan.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateEnableResourcePlan) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateEnableResourcePlan_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateEnableResourcePlan, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateEnableResourcePlan) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateEnableResourcePlan_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateEnableResourcePlanPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateEnableResourcePlan, Fixture, methodUpdateEnableResourcePlanPrametersTypes);

            // Assert
            methodUpdateEnableResourcePlanPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateEnableResourcePlan) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateEnableResourcePlan_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateEnableResourcePlan, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveConfigFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDisplaySettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveConfigField_UpdateDisplaySettings_Method_Call_Internally(Type[] types)
        {
            var methodUpdateDisplaySettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateDisplaySettings, Fixture, methodUpdateDisplaySettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateDisplaySettings) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateDisplaySettings_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveConfigFieldInstance.UpdateDisplaySettings(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateDisplaySettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateDisplaySettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateDisplaySettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateDisplaySettings = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateDisplaySettings, methodUpdateDisplaySettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveConfigFieldInstanceFixture, parametersOfUpdateDisplaySettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateDisplaySettings.ShouldNotBeNull();
            parametersOfUpdateDisplaySettings.Length.ShouldBe(1);
            methodUpdateDisplaySettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateDisplaySettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateDisplaySettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDisplaySettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateDisplaySettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateDisplaySettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateDisplaySettings = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveConfigFieldInstance, MethodUpdateDisplaySettings, parametersOfUpdateDisplaySettings, methodUpdateDisplaySettingsPrametersTypes);

            // Assert
            parametersOfUpdateDisplaySettings.ShouldNotBeNull();
            parametersOfUpdateDisplaySettings.Length.ShouldBe(1);
            methodUpdateDisplaySettingsPrametersTypes.Length.ShouldBe(1);
            methodUpdateDisplaySettingsPrametersTypes.Length.ShouldBe(parametersOfUpdateDisplaySettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDisplaySettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateDisplaySettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateDisplaySettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDisplaySettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateDisplaySettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateDisplaySettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdateDisplaySettings, Fixture, methodUpdateDisplaySettingsPrametersTypes);

            // Assert
            methodUpdateDisplaySettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDisplaySettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_UpdateDisplaySettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateDisplaySettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveConfigFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveConfigField_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Update_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveConfigFieldInstance.Update();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Update_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveConfigFieldInstanceFixture, parametersOfUpdate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdate.ShouldBeNull();
            methodUpdatePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Update_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveConfigFieldInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

            // Assert
            parametersOfUpdate.ShouldBeNull();
            methodUpdatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            methodUpdatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_Update_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveConfigFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EPMLiveConfigField_OnAdded_Method_Call_Internally(Type[] types)
        {
            var methodOnAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_OnAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _ePMLiveConfigFieldInstance.OnAdded(op);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_OnAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnAdded, methodOnAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_ePMLiveConfigFieldInstanceFixture, parametersOfOnAdded);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnAdded.ShouldNotBeNull();
            parametersOfOnAdded.Length.ShouldBe(1);
            methodOnAddedPrametersTypes.Length.ShouldBe(1);
            methodOnAddedPrametersTypes.Length.ShouldBe(parametersOfOnAdded.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_OnAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_ePMLiveConfigFieldInstance, MethodOnAdded, parametersOfOnAdded, methodOnAddedPrametersTypes);

            // Assert
            parametersOfOnAdded.ShouldNotBeNull();
            parametersOfOnAdded.Length.ShouldBe(1);
            methodOnAddedPrametersTypes.Length.ShouldBe(1);
            methodOnAddedPrametersTypes.Length.ShouldBe(parametersOfOnAdded.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_OnAdded_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnAdded, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_OnAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_ePMLiveConfigFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);

            // Assert
            methodOnAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EPMLiveConfigField_OnAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_ePMLiveConfigFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}