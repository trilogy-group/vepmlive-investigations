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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.TotalsRollupField" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TotalsRollupFieldTest : AbstractBaseSetupTypedTest<TotalsRollupField>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TotalsRollupField) Initializer

        private const string PropertyListName = "ListName";
        private const string PropertyListQuery = "ListQuery";
        private const string PropertyAggType = "AggType";
        private const string PropertyAggColumn = "AggColumn";
        private const string PropertyLookupColumn = "LookupColumn";
        private const string PropertyDecimals = "Decimals";
        private const string PropertyOutputType = "OutputType";
        private const string PropertyContextId = "ContextId";
        private const string PropertyFieldRenderingControl = "FieldRenderingControl";
        private const string MethodInit = "Init";
        private const string MethodGetFieldValue = "GetFieldValue";
        private const string MethodUpdateListName = "UpdateListName";
        private const string MethodUpdateListQuery = "UpdateListQuery";
        private const string MethodUpdateAggType = "UpdateAggType";
        private const string MethodUpdateAggColumn = "UpdateAggColumn";
        private const string MethodUpdateLookupColumn = "UpdateLookupColumn";
        private const string MethodUpdateDecimals = "UpdateDecimals";
        private const string MethodUpdateOutputType = "UpdateOutputType";
        private const string MethodUpdate = "Update";
        private const string MethodGetFieldValueAsText = "GetFieldValueAsText";
        private const string MethodGetFieldValueAsHtml = "GetFieldValueAsHtml";
        private const string MethodOnAdded = "OnAdded";
        private const string FieldupdatedListName = "updatedListName";
        private const string FieldupdatedListQuery = "updatedListQuery";
        private const string FieldupdatedAggType = "updatedAggType";
        private const string FieldupdatedAggColumn = "updatedAggColumn";
        private const string FieldupdatedLookupColumn = "updatedLookupColumn";
        private const string FieldupdatedDecimals = "updatedDecimals";
        private const string FieldupdatedOutputType = "updatedOutputType";
        private const string FieldlistName = "listName";
        private const string FieldlistQuery = "listQuery";
        private const string FieldaggColumn = "aggColumn";
        private const string FieldaggType = "aggType";
        private const string FieldlookupColumn = "lookupColumn";
        private const string Fielddecimals = "decimals";
        private const string FieldoutputType = "outputType";
        private const string FieldcontextId = "contextId";
        private Type _totalsRollupFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TotalsRollupField _totalsRollupFieldInstance;
        private TotalsRollupField _totalsRollupFieldInstanceFixture;

        #region General Initializer : Class (TotalsRollupField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TotalsRollupField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _totalsRollupFieldInstanceType = typeof(TotalsRollupField);
            _totalsRollupFieldInstanceFixture = Create(true);
            _totalsRollupFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TotalsRollupField)

        #region General Initializer : Class (TotalsRollupField) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TotalsRollupField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInit, 0)]
        [TestCase(MethodGetFieldValue, 0)]
        [TestCase(MethodUpdateListName, 0)]
        [TestCase(MethodUpdateListQuery, 0)]
        [TestCase(MethodUpdateAggType, 0)]
        [TestCase(MethodUpdateAggColumn, 0)]
        [TestCase(MethodUpdateLookupColumn, 0)]
        [TestCase(MethodUpdateDecimals, 0)]
        [TestCase(MethodUpdateOutputType, 0)]
        [TestCase(MethodUpdate, 0)]
        [TestCase(MethodGetFieldValueAsText, 0)]
        [TestCase(MethodGetFieldValueAsHtml, 0)]
        [TestCase(MethodOnAdded, 0)]
        public void AUT_TotalsRollupField_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_totalsRollupFieldInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TotalsRollupField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TotalsRollupField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyListName)]
        [TestCase(PropertyListQuery)]
        [TestCase(PropertyAggType)]
        [TestCase(PropertyAggColumn)]
        [TestCase(PropertyLookupColumn)]
        [TestCase(PropertyDecimals)]
        [TestCase(PropertyOutputType)]
        [TestCase(PropertyContextId)]
        [TestCase(PropertyFieldRenderingControl)]
        public void AUT_TotalsRollupField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_totalsRollupFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TotalsRollupField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TotalsRollupField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldupdatedListName)]
        [TestCase(FieldupdatedListQuery)]
        [TestCase(FieldupdatedAggType)]
        [TestCase(FieldupdatedAggColumn)]
        [TestCase(FieldupdatedLookupColumn)]
        [TestCase(FieldupdatedDecimals)]
        [TestCase(FieldupdatedOutputType)]
        [TestCase(FieldlistName)]
        [TestCase(FieldlistQuery)]
        [TestCase(FieldaggColumn)]
        [TestCase(FieldaggType)]
        [TestCase(FieldlookupColumn)]
        [TestCase(Fielddecimals)]
        [TestCase(FieldoutputType)]
        [TestCase(FieldcontextId)]
        public void AUT_TotalsRollupField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_totalsRollupFieldInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TotalsRollupField) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="TotalsRollupField" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_TotalsRollupField_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<TotalsRollupField>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (TotalsRollupField) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="TotalsRollupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TotalsRollupField_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<TotalsRollupField>(Fixture);
        }

        #endregion

        #region General Constructor : Class (TotalsRollupField) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="TotalsRollupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TotalsRollupField_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var fieldName = CreateType<string>();
            object[] parametersOfTotalsRollupField = { fields, fieldName };
            var methodTotalsRollupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_totalsRollupFieldInstanceType, methodTotalsRollupFieldPrametersTypes, parametersOfTotalsRollupField);
        }

        #endregion

        #region General Constructor : Class (TotalsRollupField) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="TotalsRollupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TotalsRollupField_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodTotalsRollupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_totalsRollupFieldInstanceType, Fixture, methodTotalsRollupFieldPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (TotalsRollupField) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="TotalsRollupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TotalsRollupField_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var typeName = CreateType<string>();
            var displayName = CreateType<string>();
            object[] parametersOfTotalsRollupField = { fields, typeName, displayName };
            var methodTotalsRollupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_totalsRollupFieldInstanceType, methodTotalsRollupFieldPrametersTypes, parametersOfTotalsRollupField);
        }

        #endregion

        #region General Constructor : Class (TotalsRollupField) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="TotalsRollupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_TotalsRollupField_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodTotalsRollupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_totalsRollupFieldInstanceType, Fixture, methodTotalsRollupFieldPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TotalsRollupField) => Property (AggColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_AggColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAggColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupField) => Property (AggType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_AggType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAggType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupField) => Property (ContextId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_ContextId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TotalsRollupField) => Property (Decimals) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_Decimals_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDecimals);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupField) => Property (FieldRenderingControl) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_FieldRenderingControl_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldRenderingControl);
            Action currentAction = () => propertyInfo.SetValue(_totalsRollupFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupField) => Property (FieldRenderingControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_FieldRenderingControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TotalsRollupField) => Property (ListName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_ListName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupField) => Property (ListQuery) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_ListQuery_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListQuery);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupField) => Property (LookupColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_LookupColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLookupColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TotalsRollupField) => Property (OutputType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TotalsRollupField_Public_Class_OutputType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOutputType);

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
        ///      Class (<see cref="TotalsRollupField" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInit)]
        [TestCase(MethodGetFieldValue)]
        [TestCase(MethodUpdateListName)]
        [TestCase(MethodUpdateListQuery)]
        [TestCase(MethodUpdateAggType)]
        [TestCase(MethodUpdateAggColumn)]
        [TestCase(MethodUpdateLookupColumn)]
        [TestCase(MethodUpdateDecimals)]
        [TestCase(MethodUpdateOutputType)]
        [TestCase(MethodUpdate)]
        [TestCase(MethodGetFieldValueAsText)]
        [TestCase(MethodGetFieldValueAsHtml)]
        [TestCase(MethodOnAdded)]
        public void AUT_TotalsRollupField_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TotalsRollupField>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_Init_Method_Call_Internally(Type[] types)
        {
            var methodInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodInit, Fixture, methodInitPrametersTypes);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_Init_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitPrametersTypes = null;
            object[] parametersOfInit = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInit, methodInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfInit);

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
        public void AUT_TotalsRollupField_Init_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitPrametersTypes = null;
            object[] parametersOfInit = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodInit, parametersOfInit, methodInitPrametersTypes);

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
        public void AUT_TotalsRollupField_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodInit, Fixture, methodInitPrametersTypes);

            // Assert
            methodInitPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_Init_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_GetFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.GetFieldValue(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldValue = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldValue, methodGetFieldValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TotalsRollupField, object>(_totalsRollupFieldInstanceFixture, out exception1, parametersOfGetFieldValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TotalsRollupField, object>(_totalsRollupFieldInstance, MethodGetFieldValue, parametersOfGetFieldValue, methodGetFieldValuePrametersTypes);

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
        public void AUT_TotalsRollupField_GetFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldValue = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TotalsRollupField, object>(_totalsRollupFieldInstance, MethodGetFieldValue, parametersOfGetFieldValue, methodGetFieldValuePrametersTypes);

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
        public void AUT_TotalsRollupField_GetFieldValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValue_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (UpdateListName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_UpdateListName_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateListName, Fixture, methodUpdateListNamePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListName_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.UpdateListName(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListName_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateListNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListName = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateListName, methodUpdateListNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdateListName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateListName.ShouldNotBeNull();
            parametersOfUpdateListName.Length.ShouldBe(1);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(1);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(parametersOfUpdateListName.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListName_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateListNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListName = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdateListName, parametersOfUpdateListName, methodUpdateListNamePrametersTypes);

            // Assert
            parametersOfUpdateListName.ShouldNotBeNull();
            parametersOfUpdateListName.Length.ShouldBe(1);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(1);
            methodUpdateListNamePrametersTypes.Length.ShouldBe(parametersOfUpdateListName.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateListName, Fixture, methodUpdateListNamePrametersTypes);

            // Assert
            methodUpdateListNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListName_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_UpdateListQuery_Method_Call_Internally(Type[] types)
        {
            var methodUpdateListQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateListQuery, Fixture, methodUpdateListQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateListQuery) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.UpdateListQuery(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateListQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListQuery_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateListQueryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListQuery = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateListQuery, methodUpdateListQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdateListQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateListQuery.ShouldNotBeNull();
            parametersOfUpdateListQuery.Length.ShouldBe(1);
            methodUpdateListQueryPrametersTypes.Length.ShouldBe(1);
            methodUpdateListQueryPrametersTypes.Length.ShouldBe(parametersOfUpdateListQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListQuery_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateListQueryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateListQuery = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdateListQuery, parametersOfUpdateListQuery, methodUpdateListQueryPrametersTypes);

            // Assert
            parametersOfUpdateListQuery.ShouldNotBeNull();
            parametersOfUpdateListQuery.Length.ShouldBe(1);
            methodUpdateListQueryPrametersTypes.Length.ShouldBe(1);
            methodUpdateListQueryPrametersTypes.Length.ShouldBe(parametersOfUpdateListQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateListQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateListQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateListQueryPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateListQuery, Fixture, methodUpdateListQueryPrametersTypes);

            // Assert
            methodUpdateListQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateListQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateListQuery_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateListQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_UpdateAggType_Method_Call_Internally(Type[] types)
        {
            var methodUpdateAggTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateAggType, Fixture, methodUpdateAggTypePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateAggType) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggType_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.UpdateAggType(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateAggType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggType_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateAggTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateAggType = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateAggType, methodUpdateAggTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdateAggType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateAggType.ShouldNotBeNull();
            parametersOfUpdateAggType.Length.ShouldBe(1);
            methodUpdateAggTypePrametersTypes.Length.ShouldBe(1);
            methodUpdateAggTypePrametersTypes.Length.ShouldBe(parametersOfUpdateAggType.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggType_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateAggTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateAggType = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdateAggType, parametersOfUpdateAggType, methodUpdateAggTypePrametersTypes);

            // Assert
            parametersOfUpdateAggType.ShouldNotBeNull();
            parametersOfUpdateAggType.Length.ShouldBe(1);
            methodUpdateAggTypePrametersTypes.Length.ShouldBe(1);
            methodUpdateAggTypePrametersTypes.Length.ShouldBe(parametersOfUpdateAggType.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggType) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateAggType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateAggType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateAggTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateAggType, Fixture, methodUpdateAggTypePrametersTypes);

            // Assert
            methodUpdateAggTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggType_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateAggType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_UpdateAggColumn_Method_Call_Internally(Type[] types)
        {
            var methodUpdateAggColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateAggColumn, Fixture, methodUpdateAggColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateAggColumn) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggColumn_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.UpdateAggColumn(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateAggColumn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggColumn_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateAggColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateAggColumn = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateAggColumn, methodUpdateAggColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdateAggColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateAggColumn.ShouldNotBeNull();
            parametersOfUpdateAggColumn.Length.ShouldBe(1);
            methodUpdateAggColumnPrametersTypes.Length.ShouldBe(1);
            methodUpdateAggColumnPrametersTypes.Length.ShouldBe(parametersOfUpdateAggColumn.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggColumn_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateAggColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateAggColumn = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdateAggColumn, parametersOfUpdateAggColumn, methodUpdateAggColumnPrametersTypes);

            // Assert
            parametersOfUpdateAggColumn.ShouldNotBeNull();
            parametersOfUpdateAggColumn.Length.ShouldBe(1);
            methodUpdateAggColumnPrametersTypes.Length.ShouldBe(1);
            methodUpdateAggColumnPrametersTypes.Length.ShouldBe(parametersOfUpdateAggColumn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggColumn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateAggColumn, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateAggColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggColumn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateAggColumnPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateAggColumn, Fixture, methodUpdateAggColumnPrametersTypes);

            // Assert
            methodUpdateAggColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateAggColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateAggColumn_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateAggColumn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_UpdateLookupColumn_Method_Call_Internally(Type[] types)
        {
            var methodUpdateLookupColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateLookupColumn, Fixture, methodUpdateLookupColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateLookupColumn) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateLookupColumn_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.UpdateLookupColumn(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateLookupColumn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateLookupColumn_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateLookupColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateLookupColumn = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateLookupColumn, methodUpdateLookupColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdateLookupColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateLookupColumn.ShouldNotBeNull();
            parametersOfUpdateLookupColumn.Length.ShouldBe(1);
            methodUpdateLookupColumnPrametersTypes.Length.ShouldBe(1);
            methodUpdateLookupColumnPrametersTypes.Length.ShouldBe(parametersOfUpdateLookupColumn.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateLookupColumn_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateLookupColumnPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateLookupColumn = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdateLookupColumn, parametersOfUpdateLookupColumn, methodUpdateLookupColumnPrametersTypes);

            // Assert
            parametersOfUpdateLookupColumn.ShouldNotBeNull();
            parametersOfUpdateLookupColumn.Length.ShouldBe(1);
            methodUpdateLookupColumnPrametersTypes.Length.ShouldBe(1);
            methodUpdateLookupColumnPrametersTypes.Length.ShouldBe(parametersOfUpdateLookupColumn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateLookupColumn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateLookupColumn, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateLookupColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateLookupColumn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateLookupColumnPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateLookupColumn, Fixture, methodUpdateLookupColumnPrametersTypes);

            // Assert
            methodUpdateLookupColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateLookupColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateLookupColumn_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateLookupColumn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDecimals) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_UpdateDecimals_Method_Call_Internally(Type[] types)
        {
            var methodUpdateDecimalsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateDecimals, Fixture, methodUpdateDecimalsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateDecimals) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateDecimals_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.UpdateDecimals(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateDecimals) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateDecimals_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateDecimalsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateDecimals = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateDecimals, methodUpdateDecimalsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdateDecimals);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateDecimals.ShouldNotBeNull();
            parametersOfUpdateDecimals.Length.ShouldBe(1);
            methodUpdateDecimalsPrametersTypes.Length.ShouldBe(1);
            methodUpdateDecimalsPrametersTypes.Length.ShouldBe(parametersOfUpdateDecimals.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDecimals) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateDecimals_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateDecimalsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateDecimals = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdateDecimals, parametersOfUpdateDecimals, methodUpdateDecimalsPrametersTypes);

            // Assert
            parametersOfUpdateDecimals.ShouldNotBeNull();
            parametersOfUpdateDecimals.Length.ShouldBe(1);
            methodUpdateDecimalsPrametersTypes.Length.ShouldBe(1);
            methodUpdateDecimalsPrametersTypes.Length.ShouldBe(parametersOfUpdateDecimals.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDecimals) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateDecimals_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateDecimals, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateDecimals) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateDecimals_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateDecimalsPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateDecimals, Fixture, methodUpdateDecimalsPrametersTypes);

            // Assert
            methodUpdateDecimalsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateDecimals) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateDecimals_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateDecimals, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateOutputType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_UpdateOutputType_Method_Call_Internally(Type[] types)
        {
            var methodUpdateOutputTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateOutputType, Fixture, methodUpdateOutputTypePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateOutputType) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateOutputType_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.UpdateOutputType(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateOutputType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateOutputType_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateOutputTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateOutputType = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateOutputType, methodUpdateOutputTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdateOutputType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateOutputType.ShouldNotBeNull();
            parametersOfUpdateOutputType.Length.ShouldBe(1);
            methodUpdateOutputTypePrametersTypes.Length.ShouldBe(1);
            methodUpdateOutputTypePrametersTypes.Length.ShouldBe(parametersOfUpdateOutputType.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateOutputType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateOutputType_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodUpdateOutputTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateOutputType = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdateOutputType, parametersOfUpdateOutputType, methodUpdateOutputTypePrametersTypes);

            // Assert
            parametersOfUpdateOutputType.ShouldNotBeNull();
            parametersOfUpdateOutputType.Length.ShouldBe(1);
            methodUpdateOutputTypePrametersTypes.Length.ShouldBe(1);
            methodUpdateOutputTypePrametersTypes.Length.ShouldBe(parametersOfUpdateOutputType.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateOutputType) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateOutputType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateOutputType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateOutputType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateOutputType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateOutputTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdateOutputType, Fixture, methodUpdateOutputTypePrametersTypes);

            // Assert
            methodUpdateOutputTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateOutputType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_UpdateOutputType_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateOutputType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_Update_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.Update();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_Update_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfUpdate);

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
        public void AUT_TotalsRollupField_Update_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

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
        public void AUT_TotalsRollupField_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            methodUpdatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_Update_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_GetFieldValueAsText_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldValueAsTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValueAsText, Fixture, methodGetFieldValueAsTextPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsText_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.GetFieldValueAsText(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsText_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetFieldValueAsTextPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetFieldValueAsText = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsText, methodGetFieldValueAsTextPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TotalsRollupField, string>(_totalsRollupFieldInstanceFixture, out exception1, parametersOfGetFieldValueAsText);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TotalsRollupField, string>(_totalsRollupFieldInstance, MethodGetFieldValueAsText, parametersOfGetFieldValueAsText, methodGetFieldValueAsTextPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldValueAsText.ShouldNotBeNull();
            parametersOfGetFieldValueAsText.Length.ShouldBe(1);
            methodGetFieldValueAsTextPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetFieldValueAsTextPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetFieldValueAsText = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TotalsRollupField, string>(_totalsRollupFieldInstance, MethodGetFieldValueAsText, parametersOfGetFieldValueAsText, methodGetFieldValueAsTextPrametersTypes);

            // Assert
            parametersOfGetFieldValueAsText.ShouldNotBeNull();
            parametersOfGetFieldValueAsText.Length.ShouldBe(1);
            methodGetFieldValueAsTextPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsText_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldValueAsTextPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValueAsText, Fixture, methodGetFieldValueAsTextPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldValueAsTextPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldValueAsTextPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValueAsText, Fixture, methodGetFieldValueAsTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldValueAsTextPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsText_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsText, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValueAsText) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsText_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsText, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldValueAsHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValueAsHtml, Fixture, methodGetFieldValueAsHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.GetFieldValueAsHtml(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetFieldValueAsHtml = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsHtml, methodGetFieldValueAsHtmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TotalsRollupField, string>(_totalsRollupFieldInstanceFixture, out exception1, parametersOfGetFieldValueAsHtml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TotalsRollupField, string>(_totalsRollupFieldInstance, MethodGetFieldValueAsHtml, parametersOfGetFieldValueAsHtml, methodGetFieldValueAsHtmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldValueAsHtml.ShouldNotBeNull();
            parametersOfGetFieldValueAsHtml.Length.ShouldBe(1);
            methodGetFieldValueAsHtmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetFieldValueAsHtml = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TotalsRollupField, string>(_totalsRollupFieldInstance, MethodGetFieldValueAsHtml, parametersOfGetFieldValueAsHtml, methodGetFieldValueAsHtmlPrametersTypes);

            // Assert
            parametersOfGetFieldValueAsHtml.ShouldNotBeNull();
            parametersOfGetFieldValueAsHtml.Length.ShouldBe(1);
            methodGetFieldValueAsHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValueAsHtml, Fixture, methodGetFieldValueAsHtmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldValueAsHtmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodGetFieldValueAsHtml, Fixture, methodGetFieldValueAsHtmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldValueAsHtmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsHtml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_GetFieldValueAsHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TotalsRollupField_OnAdded_Method_Call_Internally(Type[] types)
        {
            var methodOnAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_OnAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _totalsRollupFieldInstance.OnAdded(op);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_OnAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnAdded, methodOnAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_totalsRollupFieldInstanceFixture, parametersOfOnAdded);

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
        public void AUT_TotalsRollupField_OnAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_totalsRollupFieldInstance, MethodOnAdded, parametersOfOnAdded, methodOnAddedPrametersTypes);

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
        public void AUT_TotalsRollupField_OnAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_TotalsRollupField_OnAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_totalsRollupFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);

            // Assert
            methodOnAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TotalsRollupField_OnAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_totalsRollupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}