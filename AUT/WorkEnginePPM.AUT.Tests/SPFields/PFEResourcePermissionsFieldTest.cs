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

namespace WorkEnginePPM.SPFields
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.SPFields.PFEResourcePermissionsField" />)
    ///     and namespace <see cref="WorkEnginePPM.SPFields"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PFEResourcePermissionsFieldTest : AbstractBaseSetupTypedTest<PFEResourcePermissionsField>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEResourcePermissionsField) Initializer

        private const string PropertyFieldRenderingControl = "FieldRenderingControl";
        private const string MethodGetFieldValueAsHtml = "GetFieldValueAsHtml";
        private Type _pFEResourcePermissionsFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEResourcePermissionsField _pFEResourcePermissionsFieldInstance;
        private PFEResourcePermissionsField _pFEResourcePermissionsFieldInstanceFixture;

        #region General Initializer : Class (PFEResourcePermissionsField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEResourcePermissionsField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEResourcePermissionsFieldInstanceType = typeof(PFEResourcePermissionsField);
            _pFEResourcePermissionsFieldInstanceFixture = Create(true);
            _pFEResourcePermissionsFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEResourcePermissionsField)

        #region General Initializer : Class (PFEResourcePermissionsField) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PFEResourcePermissionsField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetFieldValueAsHtml, 0)]
        public void AUT_PFEResourcePermissionsField_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pFEResourcePermissionsFieldInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PFEResourcePermissionsField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PFEResourcePermissionsField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyFieldRenderingControl)]
        public void AUT_PFEResourcePermissionsField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_pFEResourcePermissionsFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PFEResourcePermissionsField) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="PFEResourcePermissionsField" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_PFEResourcePermissionsField_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<PFEResourcePermissionsField>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (PFEResourcePermissionsField) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="PFEResourcePermissionsField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEResourcePermissionsField_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<PFEResourcePermissionsField>(Fixture);
        }

        #endregion

        #region General Constructor : Class (PFEResourcePermissionsField) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEResourcePermissionsField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEResourcePermissionsField_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var typeName = CreateType<string>();
            var displayName = CreateType<string>();
            object[] parametersOfPFEResourcePermissionsField = { fields, typeName, displayName };
            var methodPFEResourcePermissionsFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_pFEResourcePermissionsFieldInstanceType, methodPFEResourcePermissionsFieldPrametersTypes, parametersOfPFEResourcePermissionsField);
        }

        #endregion

        #region General Constructor : Class (PFEResourcePermissionsField) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEResourcePermissionsField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEResourcePermissionsField_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodPFEResourcePermissionsFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_pFEResourcePermissionsFieldInstanceType, Fixture, methodPFEResourcePermissionsFieldPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (PFEResourcePermissionsField) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEResourcePermissionsField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEResourcePermissionsField_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var fields = CreateType<SPFieldCollection>();
            var fieldName = CreateType<string>();
            object[] parametersOfPFEResourcePermissionsField = { fields, fieldName };
            var methodPFEResourcePermissionsFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_pFEResourcePermissionsFieldInstanceType, methodPFEResourcePermissionsFieldPrametersTypes, parametersOfPFEResourcePermissionsField);
        }

        #endregion

        #region General Constructor : Class (PFEResourcePermissionsField) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="PFEResourcePermissionsField" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEResourcePermissionsField_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodPFEResourcePermissionsFieldPrametersTypes = new Type[] { typeof(SPFieldCollection), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_pFEResourcePermissionsFieldInstanceType, Fixture, methodPFEResourcePermissionsFieldPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PFEResourcePermissionsField) => Property (FieldRenderingControl) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEResourcePermissionsField_FieldRenderingControl_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldRenderingControl);
            Action currentAction = () => propertyInfo.SetValue(_pFEResourcePermissionsFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PFEResourcePermissionsField) => Property (FieldRenderingControl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEResourcePermissionsField_Public_Class_FieldRenderingControl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PFEResourcePermissionsField" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetFieldValueAsHtml)]
        public void AUT_PFEResourcePermissionsField_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PFEResourcePermissionsField>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldValueAsHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldInstance, MethodGetFieldValueAsHtml, Fixture, methodGetFieldValueAsHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var value = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => _pFEResourcePermissionsFieldInstance.GetFieldValueAsHtml(value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetFieldValueAsHtml = { value };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsHtml, methodGetFieldValueAsHtmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PFEResourcePermissionsField, string>(_pFEResourcePermissionsFieldInstanceFixture, out exception1, parametersOfGetFieldValueAsHtml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PFEResourcePermissionsField, string>(_pFEResourcePermissionsFieldInstance, MethodGetFieldValueAsHtml, parametersOfGetFieldValueAsHtml, methodGetFieldValueAsHtmlPrametersTypes);

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
        public void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfGetFieldValueAsHtml = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PFEResourcePermissionsField, string>(_pFEResourcePermissionsFieldInstance, MethodGetFieldValueAsHtml, parametersOfGetFieldValueAsHtml, methodGetFieldValueAsHtmlPrametersTypes);

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
        public void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldInstance, MethodGetFieldValueAsHtml, Fixture, methodGetFieldValueAsHtmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldValueAsHtmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldValueAsHtmlPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEResourcePermissionsFieldInstance, MethodGetFieldValueAsHtml, Fixture, methodGetFieldValueAsHtmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldValueAsHtmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldValueAsHtml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEResourcePermissionsFieldInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldValueAsHtml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEResourcePermissionsField_GetFieldValueAsHtml_Method_Call_Parameters_Count_Verification_Test()
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

        #endregion

        #endregion
    }
}