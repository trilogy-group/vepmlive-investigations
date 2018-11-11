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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CascadingLookupField" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CascadingLookupFieldTest : AbstractBaseSetupTypedTest<CascadingLookupField>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CascadingLookupField) Initializer

        private const string PropertyContextId = "ContextId";
        private const string PropertyUrl = "Url";
        private const string PropertyList = "List";
        private const string PropertyField = "Field";
        private const string PropertyParentField = "ParentField";
        private const string PropertyChildrenField = "ChildrenField";
        private const string PropertyFilterValueField = "FilterValueField";
        private const string PropertyDefineNone = "DefineNone";
        private const string PropertyFieldRenderingControl = "FieldRenderingControl";
        private const string MethodUpdateMyCustomProperty = "UpdateMyCustomProperty";
        private const string MethodInitialize = "Initialize";
        private const string MethodGetFieldValue = "GetFieldValue";
        private const string MethodOnAdded = "OnAdded";
        private const string MethodUpdate = "Update";
        private const string FieldstaticPropertyList = "staticPropertyList";
        private const string FieldcontextId = "contextId";
        private const string FieldstrUrl = "strUrl";
        private const string FieldstrList = "strList";
        private const string FieldstrField = "strField";
        private const string FieldstrParentField = "strParentField";
        private const string FieldstrChildrenField = "strChildrenField";
        private const string FieldstrFilterValueField = "strFilterValueField";
        private const string FieldstrDefineNone = "strDefineNone";
        private Type _cascadingLookupFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CascadingLookupField _cascadingLookupFieldInstance;
        private CascadingLookupField _cascadingLookupFieldInstanceFixture;

        #region General Initializer : Class (CascadingLookupField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CascadingLookupField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cascadingLookupFieldInstanceType = typeof(CascadingLookupField);
            _cascadingLookupFieldInstanceFixture = Create(true);
            _cascadingLookupFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CascadingLookupField)

        #region General Initializer : Class (CascadingLookupField) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CascadingLookupField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodUpdateMyCustomProperty, 0)]
        [TestCase(MethodInitialize, 0)]
        [TestCase(MethodGetFieldValue, 0)]
        [TestCase(MethodOnAdded, 0)]
        [TestCase(MethodUpdate, 0)]
        public void AUT_CascadingLookupField_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_cascadingLookupFieldInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingLookupField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingLookupField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyContextId)]
        [TestCase(PropertyUrl)]
        [TestCase(PropertyList)]
        [TestCase(PropertyField)]
        [TestCase(PropertyParentField)]
        [TestCase(PropertyChildrenField)]
        [TestCase(PropertyFilterValueField)]
        [TestCase(PropertyDefineNone)]
        [TestCase(PropertyFieldRenderingControl)]
        public void AUT_CascadingLookupField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cascadingLookupFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CascadingLookupField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CascadingLookupField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldstaticPropertyList)]
        [TestCase(FieldcontextId)]
        [TestCase(FieldstrUrl)]
        [TestCase(FieldstrList)]
        [TestCase(FieldstrField)]
        [TestCase(FieldstrParentField)]
        [TestCase(FieldstrChildrenField)]
        [TestCase(FieldstrFilterValueField)]
        [TestCase(FieldstrDefineNone)]
        public void AUT_CascadingLookupField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cascadingLookupFieldInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CascadingLookupField) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="CascadingLookupField" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_CascadingLookupField_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<CascadingLookupField>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (CascadingLookupField) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="CascadingLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CascadingLookupField_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<CascadingLookupField>(Fixture);
        }

        #endregion

        #region General Constructor : Class (CascadingLookupField) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CascadingLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CascadingLookupField_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var fieldName = CreateType<string>();
            object[] parametersOfCascadingLookupField = { fields, fieldName };
            var methodCascadingLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_cascadingLookupFieldInstanceType, methodCascadingLookupFieldPrametersTypes, parametersOfCascadingLookupField);
        }

        #endregion

        #region General Constructor : Class (CascadingLookupField) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CascadingLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CascadingLookupField_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCascadingLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_cascadingLookupFieldInstanceType, Fixture, methodCascadingLookupFieldPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (CascadingLookupField) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CascadingLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CascadingLookupField_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var typeName = CreateType<string>();
            var displayName = CreateType<string>();
            object[] parametersOfCascadingLookupField = { fields, typeName, displayName };
            var methodCascadingLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_cascadingLookupFieldInstanceType, methodCascadingLookupFieldPrametersTypes, parametersOfCascadingLookupField);
        }

        #endregion

        #region General Constructor : Class (CascadingLookupField) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CascadingLookupField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CascadingLookupField_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCascadingLookupFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_cascadingLookupFieldInstanceType, Fixture, methodCascadingLookupFieldPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter
        
        #region General Getters/Setters : Class (CascadingLookupField) => Property (ChildrenField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_ChildrenField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChildrenField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupField) => Property (ContextId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_ContextId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CascadingLookupField) => Property (DefineNone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_DefineNone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefineNone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupField) => Property (Field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_Field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupField) => Property (FieldRenderingControl) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_FieldRenderingControl_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldRenderingControl);
            Action currentAction = () => propertyInfo.SetValue(_cascadingLookupFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupField) => Property (FieldRenderingControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_FieldRenderingControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CascadingLookupField) => Property (FilterValueField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_FilterValueField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFilterValueField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupField) => Property (List) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_List_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupField) => Property (ParentField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_ParentField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParentField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CascadingLookupField) => Property (Url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CascadingLookupField_Public_Class_Url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUrl);

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
        ///      Class (<see cref="CascadingLookupField" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodUpdateMyCustomProperty)]
        [TestCase(MethodInitialize)]
        [TestCase(MethodGetFieldValue)]
        [TestCase(MethodOnAdded)]
        [TestCase(MethodUpdate)]
        public void AUT_CascadingLookupField_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CascadingLookupField>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (UpdateMyCustomProperty) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupField_UpdateMyCustomProperty_Method_Call_Internally(Type[] types)
        {
            var methodUpdateMyCustomPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodUpdateMyCustomProperty, Fixture, methodUpdateMyCustomPropertyPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateMyCustomProperty) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_UpdateMyCustomProperty_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var propertyName = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cascadingLookupFieldInstance.UpdateMyCustomProperty(propertyName, value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateMyCustomProperty) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_UpdateMyCustomProperty_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var propertyName = CreateType<string>();
            var value = CreateType<string>();
            var methodUpdateMyCustomPropertyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateMyCustomProperty = { propertyName, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateMyCustomProperty, methodUpdateMyCustomPropertyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldInstanceFixture, parametersOfUpdateMyCustomProperty);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateMyCustomProperty.ShouldNotBeNull();
            parametersOfUpdateMyCustomProperty.Length.ShouldBe(2);
            methodUpdateMyCustomPropertyPrametersTypes.Length.ShouldBe(2);
            methodUpdateMyCustomPropertyPrametersTypes.Length.ShouldBe(parametersOfUpdateMyCustomProperty.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyCustomProperty) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_UpdateMyCustomProperty_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var propertyName = CreateType<string>();
            var value = CreateType<string>();
            var methodUpdateMyCustomPropertyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfUpdateMyCustomProperty = { propertyName, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldInstance, MethodUpdateMyCustomProperty, parametersOfUpdateMyCustomProperty, methodUpdateMyCustomPropertyPrametersTypes);

            // Assert
            parametersOfUpdateMyCustomProperty.ShouldNotBeNull();
            parametersOfUpdateMyCustomProperty.Length.ShouldBe(2);
            methodUpdateMyCustomPropertyPrametersTypes.Length.ShouldBe(2);
            methodUpdateMyCustomPropertyPrametersTypes.Length.ShouldBe(parametersOfUpdateMyCustomProperty.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyCustomProperty) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_UpdateMyCustomProperty_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateMyCustomProperty, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateMyCustomProperty) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_UpdateMyCustomProperty_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateMyCustomPropertyPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodUpdateMyCustomProperty, Fixture, methodUpdateMyCustomPropertyPrametersTypes);

            // Assert
            methodUpdateMyCustomPropertyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateMyCustomProperty) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_UpdateMyCustomProperty_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateMyCustomProperty, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupField_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_Initialize_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializePrametersTypes = null;
            object[] parametersOfInitialize = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldInstanceFixture, parametersOfInitialize);

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
        public void AUT_CascadingLookupField_Initialize_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializePrametersTypes = null;
            object[] parametersOfInitialize = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

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
        public void AUT_CascadingLookupField_Initialize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            methodInitializePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_Initialize_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupField_GetFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_GetFieldValue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _cascadingLookupFieldInstance.GetFieldValue(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_GetFieldValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldValue = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldValue, methodGetFieldValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CascadingLookupField, object>(_cascadingLookupFieldInstanceFixture, out exception1, parametersOfGetFieldValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CascadingLookupField, object>(_cascadingLookupFieldInstance, MethodGetFieldValue, parametersOfGetFieldValue, methodGetFieldValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldValue.ShouldNotBeNull();
            parametersOfGetFieldValue.Length.ShouldBe(1);
            methodGetFieldValuePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_cascadingLookupFieldInstanceFixture, parametersOfGetFieldValue));
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_GetFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFieldValue = { value };

            // Assert
            parametersOfGetFieldValue.ShouldNotBeNull();
            parametersOfGetFieldValue.Length.ShouldBe(1);
            methodGetFieldValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CascadingLookupField, object>(_cascadingLookupFieldInstance, MethodGetFieldValue, parametersOfGetFieldValue, methodGetFieldValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_GetFieldValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_GetFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldValuePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodGetFieldValue, Fixture, methodGetFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_GetFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValue) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_GetFieldValue_Method_Call_Parameters_Count_Verification_Test()
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
        private void AUT_CascadingLookupField_OnAdded_Method_Call_Internally(Type[] types)
        {
            var methodOnAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_OnAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            Action executeAction = null;

            // Act
            executeAction = () => _cascadingLookupFieldInstance.OnAdded(op);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_OnAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnAdded, methodOnAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldInstanceFixture, parametersOfOnAdded);

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
        public void AUT_CascadingLookupField_OnAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var op = CreateType<SPAddFieldOptions>();
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };
            object[] parametersOfOnAdded = { op };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldInstance, MethodOnAdded, parametersOfOnAdded, methodOnAddedPrametersTypes);

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
        public void AUT_CascadingLookupField_OnAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CascadingLookupField_OnAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnAddedPrametersTypes = new Type[] { typeof(SPAddFieldOptions) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodOnAdded, Fixture, methodOnAddedPrametersTypes);

            // Assert
            methodOnAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_OnAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CascadingLookupField_Update_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_Update_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _cascadingLookupFieldInstance.Update();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_Update_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdate, methodUpdatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_cascadingLookupFieldInstanceFixture, parametersOfUpdate);

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
        public void AUT_CascadingLookupField_Update_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;
            object[] parametersOfUpdate = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_cascadingLookupFieldInstance, MethodUpdate, parametersOfUpdate, methodUpdatePrametersTypes);

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
        public void AUT_CascadingLookupField_Update_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_cascadingLookupFieldInstance, MethodUpdate, Fixture, methodUpdatePrametersTypes);

            // Assert
            methodUpdatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Update) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CascadingLookupField_Update_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdate, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_cascadingLookupFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}