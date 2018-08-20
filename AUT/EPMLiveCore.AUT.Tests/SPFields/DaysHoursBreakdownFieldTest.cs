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

namespace EPMLiveCore.SPFields
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SPFields.DaysHoursBreakdownField" />)
    ///     and namespace <see cref="EPMLiveCore.SPFields"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DaysHoursBreakdownFieldTest : AbstractBaseSetupTypedTest<DaysHoursBreakdownField>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DaysHoursBreakdownField) Initializer

        private const string PropertyContextId = "ContextId";
        private const string PropertyFieldRenderingControl = "FieldRenderingControl";
        private const string PropertyFinishDateField = "FinishDateField";
        private const string PropertyHolidaySchedulesField = "HolidaySchedulesField";
        private const string PropertyHolidaysList = "HolidaysList";
        private const string PropertyHoursField = "HoursField";
        private const string PropertyResourcePoolList = "ResourcePoolList";
        private const string PropertyStartDateField = "StartDateField";
        private const string PropertyWorkHoursList = "WorkHoursList";
        private const string MethodGetFieldValue = "GetFieldValue";
        private const string MethodOnAdded = "OnAdded";
        private const string MethodUpdate = "Update";
        private const string MethodUpdateCustomProperty = "UpdateCustomProperty";
        private const string MethodInitialize = "Initialize";
        private const string FieldPropertyDictionary = "PropertyDictionary";
        private const string Field_contextId = "_contextId";
        private const string Field_finishDateField = "_finishDateField";
        private const string Field_holidaySchedulesField = "_holidaySchedulesField";
        private const string Field_holidaysList = "_holidaysList";
        private const string Field_hoursField = "_hoursField";
        private const string Field_resourcePoolList = "_resourcePoolList";
        private const string Field_startDateField = "_startDateField";
        private const string Field_workHoursList = "_workHoursList";
        private Type _daysHoursBreakdownFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DaysHoursBreakdownField _daysHoursBreakdownFieldInstance;
        private DaysHoursBreakdownField _daysHoursBreakdownFieldInstanceFixture;

        #region General Initializer : Class (DaysHoursBreakdownField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DaysHoursBreakdownField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _daysHoursBreakdownFieldInstanceType = typeof(DaysHoursBreakdownField);
            _daysHoursBreakdownFieldInstanceFixture = Create(true);
            _daysHoursBreakdownFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DaysHoursBreakdownField)

        #region General Initializer : Class (DaysHoursBreakdownField) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetFieldValue, 0)]
        [TestCase(MethodOnAdded, 0)]
        [TestCase(MethodUpdate, 0)]
        [TestCase(MethodUpdateCustomProperty, 0)]
        [TestCase(MethodInitialize, 0)]
        public void AUT_DaysHoursBreakdownField_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_daysHoursBreakdownFieldInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DaysHoursBreakdownField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyContextId)]
        [TestCase(PropertyFieldRenderingControl)]
        [TestCase(PropertyFinishDateField)]
        [TestCase(PropertyHolidaySchedulesField)]
        [TestCase(PropertyHolidaysList)]
        [TestCase(PropertyHoursField)]
        [TestCase(PropertyResourcePoolList)]
        [TestCase(PropertyStartDateField)]
        [TestCase(PropertyWorkHoursList)]
        public void AUT_DaysHoursBreakdownField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_daysHoursBreakdownFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DaysHoursBreakdownField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPropertyDictionary)]
        [TestCase(Field_contextId)]
        [TestCase(Field_finishDateField)]
        [TestCase(Field_holidaySchedulesField)]
        [TestCase(Field_holidaysList)]
        [TestCase(Field_hoursField)]
        [TestCase(Field_resourcePoolList)]
        [TestCase(Field_startDateField)]
        [TestCase(Field_workHoursList)]
        public void AUT_DaysHoursBreakdownField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_daysHoursBreakdownFieldInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DaysHoursBreakdownField) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="DaysHoursBreakdownField" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_DaysHoursBreakdownField_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<DaysHoursBreakdownField>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (DaysHoursBreakdownField) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="DaysHoursBreakdownField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DaysHoursBreakdownField_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<DaysHoursBreakdownField>(Fixture);
        }

        #endregion

        #region General Constructor : Class (DaysHoursBreakdownField) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DaysHoursBreakdownField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DaysHoursBreakdownField_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var typeName = CreateType<string>();
            var displayName = CreateType<string>();
            object[] parametersOfDaysHoursBreakdownField = { fields, typeName, displayName };
            var methodDaysHoursBreakdownFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_daysHoursBreakdownFieldInstanceType, methodDaysHoursBreakdownFieldPrametersTypes, parametersOfDaysHoursBreakdownField);
        }

        #endregion

        #region General Constructor : Class (DaysHoursBreakdownField) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DaysHoursBreakdownField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DaysHoursBreakdownField_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodDaysHoursBreakdownFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_daysHoursBreakdownFieldInstanceType, Fixture, methodDaysHoursBreakdownFieldPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (DaysHoursBreakdownField) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DaysHoursBreakdownField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DaysHoursBreakdownField_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var fieldName = CreateType<string>();
            object[] parametersOfDaysHoursBreakdownField = { fields, fieldName };
            var methodDaysHoursBreakdownFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_daysHoursBreakdownFieldInstanceType, methodDaysHoursBreakdownFieldPrametersTypes, parametersOfDaysHoursBreakdownField);
        }

        #endregion

        #region General Constructor : Class (DaysHoursBreakdownField) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DaysHoursBreakdownField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DaysHoursBreakdownField_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodDaysHoursBreakdownFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_daysHoursBreakdownFieldInstanceType, Fixture, methodDaysHoursBreakdownFieldPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (ContextId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_ContextId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (FieldRenderingControl) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_FieldRenderingControl_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldRenderingControl);
            Action currentAction = () => propertyInfo.SetValue(_daysHoursBreakdownFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (FieldRenderingControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_FieldRenderingControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (FinishDateField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_FinishDateField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFinishDateField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (HolidaySchedulesField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_HolidaySchedulesField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHolidaySchedulesField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (HolidaysList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_HolidaysList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHolidaysList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (HoursField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_HoursField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHoursField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (ResourcePoolList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_ResourcePoolList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResourcePoolList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (StartDateField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_StartDateField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStartDateField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DaysHoursBreakdownField) => Property (WorkHoursList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_DaysHoursBreakdownField_Public_Class_WorkHoursList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWorkHoursList);

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
        ///      Class (<see cref="DaysHoursBreakdownField" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetFieldValue)]
        [TestCase(MethodOnAdded)]
        [TestCase(MethodUpdate)]
        [TestCase(MethodUpdateCustomProperty)]
        [TestCase(MethodInitialize)]
        public void AUT_DaysHoursBreakdownField_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DaysHoursBreakdownField>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownField_GetFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_GetFieldValue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _daysHoursBreakdownFieldInstance.GetFieldValue(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_GetFieldValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldValue = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldValue, methodGetFieldValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<DaysHoursBreakdownField, object>(_daysHoursBreakdownFieldInstanceFixture, out exception1, parametersOfGetFieldValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<DaysHoursBreakdownField, object>(_daysHoursBreakdownFieldInstance, MethodGetFieldValue, parametersOfGetFieldValue, methodGetFieldValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldValue.ShouldNotBeNull();
            parametersOfGetFieldValue.Length.ShouldBe(1);
            methodGetFieldValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_GetFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldValue = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DaysHoursBreakdownField, object>(_daysHoursBreakdownFieldInstance, MethodGetFieldValue, parametersOfGetFieldValue, methodGetFieldValuePrametersTypes);

            // Assert
            parametersOfGetFieldValue.ShouldNotBeNull();
            parametersOfGetFieldValue.Length.ShouldBe(1);
            methodGetFieldValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_GetFieldValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_GetFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_GetFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_GetFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownField_OnAdded_Method_Call_Internally(Type[] types)
        {
            var methodOnAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_OnAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _daysHoursBreakdownFieldInstance.OnAdded(op);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_OnAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnAdded, methodOnAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldInstanceFixture, parametersOfOnAdded);

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
        public void AUT_DaysHoursBreakdownField_OnAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldInstance, MethodOnAdded, parametersOfOnAdded, methodOnAddedPrametersTypes);

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
        public void AUT_DaysHoursBreakdownField_OnAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_DaysHoursBreakdownField_OnAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);

            // Assert
            methodOnAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (Update) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownField_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_Update_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _daysHoursBreakdownFieldInstance.Update();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_Update_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldInstanceFixture, parametersOfUpdate);

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
        public void AUT_DaysHoursBreakdownField_Update_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

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
        public void AUT_DaysHoursBreakdownField_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            methodUpdatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_Update_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCustomProperty) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownField_UpdateCustomProperty_Method_Call_Internally(Type[] types)
        {
            var methodUpdateCustomPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodUpdateCustomProperty, Fixture, methodUpdateCustomPropertyPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateCustomProperty) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_UpdateCustomProperty_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var propertyName = CreateType<string>();
            var propertyValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _daysHoursBreakdownFieldInstance.UpdateCustomProperty(propertyName, propertyValue);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateCustomProperty) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_UpdateCustomProperty_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var propertyName = CreateType<string>();
            var propertyValue = CreateType<string>();
            var methodUpdateCustomPropertyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateCustomProperty = { propertyName, propertyValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateCustomProperty, methodUpdateCustomPropertyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldInstanceFixture, parametersOfUpdateCustomProperty);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateCustomProperty.ShouldNotBeNull();
            parametersOfUpdateCustomProperty.Length.ShouldBe(2);
            methodUpdateCustomPropertyPrametersTypes.Length.ShouldBe(2);
            methodUpdateCustomPropertyPrametersTypes.Length.ShouldBe(parametersOfUpdateCustomProperty.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCustomProperty) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_UpdateCustomProperty_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var propertyName = CreateType<string>();
            var propertyValue = CreateType<string>();
            var methodUpdateCustomPropertyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateCustomProperty = { propertyName, propertyValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldInstance, MethodUpdateCustomProperty, parametersOfUpdateCustomProperty, methodUpdateCustomPropertyPrametersTypes);

            // Assert
            parametersOfUpdateCustomProperty.ShouldNotBeNull();
            parametersOfUpdateCustomProperty.Length.ShouldBe(2);
            methodUpdateCustomPropertyPrametersTypes.Length.ShouldBe(2);
            methodUpdateCustomPropertyPrametersTypes.Length.ShouldBe(parametersOfUpdateCustomProperty.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCustomProperty) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_UpdateCustomProperty_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateCustomProperty, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateCustomProperty) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_UpdateCustomProperty_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateCustomPropertyPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodUpdateCustomProperty, Fixture, methodUpdateCustomPropertyPrametersTypes);

            // Assert
            methodUpdateCustomPropertyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCustomProperty) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_UpdateCustomProperty_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateCustomProperty, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DaysHoursBreakdownField_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_Initialize_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializePrametersTypes = null;
            object[] parametersOfInitialize = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_daysHoursBreakdownFieldInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldBeNull();
            methodInitializePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_Initialize_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializePrametersTypes = null;
            object[] parametersOfInitialize = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_daysHoursBreakdownFieldInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            parametersOfInitialize.ShouldBeNull();
            methodInitializePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_Initialize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_daysHoursBreakdownFieldInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            methodInitializePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DaysHoursBreakdownField_Initialize_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_daysHoursBreakdownFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}