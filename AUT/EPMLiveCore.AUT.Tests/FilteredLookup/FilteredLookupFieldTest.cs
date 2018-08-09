using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Xml;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.FilteredLookupField" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class FilteredLookupFieldTest : AbstractBaseSetupTypedTest<FilteredLookupField>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FilteredLookupField) Initializer

        private const string PropertySortable = "Sortable";
        private const string PropertyAllowMultipleValues = "AllowMultipleValues";
        private const string PropertyIsFilterRecursive = "IsFilterRecursive";
        private const string PropertyListViewFilter = "ListViewFilter";
        private const string PropertyQueryFilterAsString = "QueryFilterAsString";
        private const string PropertyQueryFilter = "QueryFilter";
        private const string PropertyFieldRenderingControl = "FieldRenderingControl";
        private const string MethodOnAdded = "OnAdded";
        private const string MethodUpdate = "Update";
        private const string MethodUpdateFieldProperties = "UpdateFieldProperties";
        private const string MethodEnsureAttribute = "EnsureAttribute";
        private const string MethodGetValidatedString = "GetValidatedString";
        private const string MethodGetFieldThreadDataValue = "GetFieldThreadDataValue";
        private const string MethodSetFieldThreadDataValue = "SetFieldThreadDataValue";
        private const string MethodCleanUpThreadData = "CleanUpThreadData";
        private const string Field_listViewFilter = "_listViewFilter";
        private const string Field_queryFilter = "_queryFilter";
        private const string Field_allowMultiple = "_allowMultiple";
        private const string Field_isFilterRecursive = "_isFilterRecursive";
        private Type _filteredLookupFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FilteredLookupField _filteredLookupFieldInstance;
        private FilteredLookupField _filteredLookupFieldInstanceFixture;

        #region General Initializer : Class (FilteredLookupField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FilteredLookupField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _filteredLookupFieldInstanceType = typeof(FilteredLookupField);
            _filteredLookupFieldInstanceFixture = Create(true);
            _filteredLookupFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FilteredLookupField)

        #region General Initializer : Class (FilteredLookupField) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FilteredLookupField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnAdded, 0)]
        [TestCase(MethodUpdate, 0)]
        [TestCase(MethodUpdateFieldProperties, 0)]
        [TestCase(MethodEnsureAttribute, 0)]
        [TestCase(MethodGetValidatedString, 0)]
        public void AUT_FilteredLookupField_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_filteredLookupFieldInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FilteredLookupField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FilteredLookupField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertySortable)]
        [TestCase(PropertyAllowMultipleValues)]
        [TestCase(PropertyIsFilterRecursive)]
        [TestCase(PropertyListViewFilter)]
        [TestCase(PropertyQueryFilterAsString)]
        [TestCase(PropertyQueryFilter)]
        [TestCase(PropertyFieldRenderingControl)]
        public void AUT_FilteredLookupField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_filteredLookupFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FilteredLookupField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FilteredLookupField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_listViewFilter)]
        [TestCase(Field_queryFilter)]
        [TestCase(Field_allowMultiple)]
        [TestCase(Field_isFilterRecursive)]
        public void AUT_FilteredLookupField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_filteredLookupFieldInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FilteredLookupField) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="FilteredLookupField" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_FilteredLookupField_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<FilteredLookupField>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (FilteredLookupField) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="FilteredLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FilteredLookupField_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<FilteredLookupField>(Fixture);
        }

        #endregion

        #region General Constructor : Class (FilteredLookupField) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FilteredLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FilteredLookupField_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var fieldName = CreateType<string>();
            object[] parametersOfFilteredLookupField = { fields, fieldName };
            var methodFilteredLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_filteredLookupFieldInstanceType, methodFilteredLookupFieldPrametersTypes, parametersOfFilteredLookupField);
        }

        #endregion

        #region General Constructor : Class (FilteredLookupField) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FilteredLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FilteredLookupField_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodFilteredLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_filteredLookupFieldInstanceType, Fixture, methodFilteredLookupFieldPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (FilteredLookupField) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FilteredLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FilteredLookupField_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var typeName = CreateType<string>();
            var displayName = CreateType<string>();
            object[] parametersOfFilteredLookupField = { fields, typeName, displayName };
            var methodFilteredLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_filteredLookupFieldInstanceType, methodFilteredLookupFieldPrametersTypes, parametersOfFilteredLookupField);
        }

        #endregion

        #region General Constructor : Class (FilteredLookupField) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="FilteredLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_FilteredLookupField_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodFilteredLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_filteredLookupFieldInstanceType, Fixture, methodFilteredLookupFieldPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FilteredLookupField) => Property (AllowMultipleValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_Public_Class_AllowMultipleValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAllowMultipleValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupField) => Property (FieldRenderingControl) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_FieldRenderingControl_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldRenderingControl);
            Action currentAction = () => propertyInfo.SetValue(_filteredLookupFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupField) => Property (FieldRenderingControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_Public_Class_FieldRenderingControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FilteredLookupField) => Property (IsFilterRecursive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_Public_Class_IsFilterRecursive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsFilterRecursive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupField) => Property (ListViewFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_Public_Class_ListViewFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListViewFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupField) => Property (QueryFilter) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_QueryFilter_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyQueryFilter);
            Action currentAction = () => propertyInfo.SetValue(_filteredLookupFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupField) => Property (QueryFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_Public_Class_QueryFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyQueryFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupField) => Property (QueryFilterAsString) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_Public_Class_QueryFilterAsString_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyQueryFilterAsString);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilteredLookupField) => Property (Sortable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_FilteredLookupField_Public_Class_Sortable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySortable);

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
        ///      Class (<see cref="FilteredLookupField" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnAdded)]
        [TestCase(MethodUpdate)]
        [TestCase(MethodUpdateFieldProperties)]
        [TestCase(MethodEnsureAttribute)]
        [TestCase(MethodGetValidatedString)]
        public void AUT_FilteredLookupField_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<FilteredLookupField>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupField_OnAdded_Method_Call_Internally(Type[] types)
        {
            var methodOnAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_OnAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _filteredLookupFieldInstance.OnAdded(op);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_OnAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnAdded, methodOnAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldInstanceFixture, parametersOfOnAdded);

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
        public void AUT_FilteredLookupField_OnAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldInstance, MethodOnAdded, parametersOfOnAdded, methodOnAddedPrametersTypes);

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
        public void AUT_FilteredLookupField_OnAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_FilteredLookupField_OnAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);

            // Assert
            methodOnAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_OnAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupField_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_Update_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _filteredLookupFieldInstance.Update();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_Update_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldInstanceFixture, parametersOfUpdate);

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
        public void AUT_FilteredLookupField_Update_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

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
        public void AUT_FilteredLookupField_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            methodUpdatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_Update_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldProperties) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupField_UpdateFieldProperties_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFieldPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodUpdateFieldProperties, Fixture, methodUpdateFieldPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateFieldProperties) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_UpdateFieldProperties_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateFieldPropertiesPrametersTypes = null;
            object[] parametersOfUpdateFieldProperties = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateFieldProperties, methodUpdateFieldPropertiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldInstanceFixture, parametersOfUpdateFieldProperties);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateFieldProperties.ShouldBeNull();
            methodUpdateFieldPropertiesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldProperties) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_UpdateFieldProperties_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateFieldPropertiesPrametersTypes = null;
            object[] parametersOfUpdateFieldProperties = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldInstance, MethodUpdateFieldProperties, parametersOfUpdateFieldProperties, methodUpdateFieldPropertiesPrametersTypes);

            // Assert
            parametersOfUpdateFieldProperties.ShouldBeNull();
            methodUpdateFieldPropertiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldProperties) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_UpdateFieldProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateFieldPropertiesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodUpdateFieldProperties, Fixture, methodUpdateFieldPropertiesPrametersTypes);

            // Assert
            methodUpdateFieldPropertiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateFieldProperties) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_UpdateFieldProperties_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateFieldProperties, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureAttribute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupField_EnsureAttribute_Method_Call_Internally(Type[] types)
        {
            var methodEnsureAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodEnsureAttribute, Fixture, methodEnsureAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureAttribute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_EnsureAttribute_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var name = CreateType<string>();
            var value = CreateType<string>();
            var methodEnsureAttributePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfEnsureAttribute = { doc, name, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnsureAttribute, methodEnsureAttributePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_filteredLookupFieldInstanceFixture, parametersOfEnsureAttribute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnsureAttribute.ShouldNotBeNull();
            parametersOfEnsureAttribute.Length.ShouldBe(3);
            methodEnsureAttributePrametersTypes.Length.ShouldBe(3);
            methodEnsureAttributePrametersTypes.Length.ShouldBe(parametersOfEnsureAttribute.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnsureAttribute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_EnsureAttribute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var doc = CreateType<XmlDocument>();
            var name = CreateType<string>();
            var value = CreateType<string>();
            var methodEnsureAttributePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };
            object[] parametersOfEnsureAttribute = { doc, name, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_filteredLookupFieldInstance, MethodEnsureAttribute, parametersOfEnsureAttribute, methodEnsureAttributePrametersTypes);

            // Assert
            parametersOfEnsureAttribute.ShouldNotBeNull();
            parametersOfEnsureAttribute.Length.ShouldBe(3);
            methodEnsureAttributePrametersTypes.Length.ShouldBe(3);
            methodEnsureAttributePrametersTypes.Length.ShouldBe(parametersOfEnsureAttribute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureAttribute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_EnsureAttribute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnsureAttribute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnsureAttribute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_EnsureAttribute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnsureAttributePrametersTypes = new Type[] { typeof(XmlDocument), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodEnsureAttribute, Fixture, methodEnsureAttributePrametersTypes);

            // Assert
            methodEnsureAttributePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureAttribute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_EnsureAttribute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnsureAttribute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FilteredLookupField_GetValidatedString_Method_Call_Internally(Type[] types)
        {
            var methodGetValidatedStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodGetValidatedString, Fixture, methodGetValidatedStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_GetValidatedString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => _filteredLookupFieldInstance.GetValidatedString(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_GetValidatedString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetValidatedStringPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetValidatedString = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetValidatedString, methodGetValidatedStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<FilteredLookupField, string>(_filteredLookupFieldInstanceFixture, out exception1, parametersOfGetValidatedString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<FilteredLookupField, string>(_filteredLookupFieldInstance, MethodGetValidatedString, parametersOfGetValidatedString, methodGetValidatedStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetValidatedString.ShouldNotBeNull();
            parametersOfGetValidatedString.Length.ShouldBe(1);
            methodGetValidatedStringPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_filteredLookupFieldInstanceFixture, parametersOfGetValidatedString));
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_GetValidatedString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetValidatedStringPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetValidatedString = { value };

            // Assert
            parametersOfGetValidatedString.ShouldNotBeNull();
            parametersOfGetValidatedString.Length.ShouldBe(1);
            methodGetValidatedStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<FilteredLookupField, string>(_filteredLookupFieldInstance, MethodGetValidatedString, parametersOfGetValidatedString, methodGetValidatedStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_GetValidatedString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetValidatedStringPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodGetValidatedString, Fixture, methodGetValidatedStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetValidatedStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_GetValidatedString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetValidatedStringPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_filteredLookupFieldInstance, MethodGetValidatedString, Fixture, methodGetValidatedStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetValidatedStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_GetValidatedString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetValidatedString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_filteredLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetValidatedString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FilteredLookupField_GetValidatedString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetValidatedString, 0);
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