using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportFiltering.DomainModel.CamlComparisonOperator" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportFiltering.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CamlComparisonOperatorTest : AbstractBaseSetupTypedTest<CamlComparisonOperator>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CamlComparisonOperator) Initializer

        private const string PropertyOperatorName = "OperatorName";
        private const string PropertyOperator = "Operator";
        private const string MethodGetCamlOperatorByValue = "GetCamlOperatorByValue";
        private const string FieldIn = "In";
        private const string FieldEqualTo = "EqualTo";
        private const string FieldNotEqualTo = "NotEqualTo";
        private const string FieldGreaterThan = "GreaterThan";
        private const string FieldGreaterThanOrEqualTo = "GreaterThanOrEqualTo";
        private const string FieldLessThan = "LessThan";
        private const string FieldLessThanOrEqualTo = "LessThanOrEqualTo";
        private const string FieldBeginsWith = "BeginsWith";
        private const string FieldContains = "Contains";
        private const string FieldDateRangesOverlap = "DateRangesOverlap";
        private const string FieldIncludes = "Includes";
        private const string FieldNotIncludes = "NotIncludes";
        private const string FieldIsNull = "IsNull";
        private const string FieldIsNotNull = "IsNotNull";
        private const string FieldEmpty = "Empty";
        private Type _camlComparisonOperatorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CamlComparisonOperator _camlComparisonOperatorInstance;
        private CamlComparisonOperator _camlComparisonOperatorInstanceFixture;

        #region General Initializer : Class (CamlComparisonOperator) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CamlComparisonOperator" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _camlComparisonOperatorInstanceType = typeof(CamlComparisonOperator);
            _camlComparisonOperatorInstanceFixture = Create(true);
            _camlComparisonOperatorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CamlComparisonOperator)

        #region General Initializer : Class (CamlComparisonOperator) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CamlComparisonOperator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetCamlOperatorByValue, 0)]
        public void AUT_CamlComparisonOperator_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_camlComparisonOperatorInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CamlComparisonOperator) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CamlComparisonOperator" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyOperatorName)]
        [TestCase(PropertyOperator)]
        public void AUT_CamlComparisonOperator_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_camlComparisonOperatorInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CamlComparisonOperator) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CamlComparisonOperator" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldIn)]
        [TestCase(FieldEqualTo)]
        [TestCase(FieldNotEqualTo)]
        [TestCase(FieldGreaterThan)]
        [TestCase(FieldGreaterThanOrEqualTo)]
        [TestCase(FieldLessThan)]
        [TestCase(FieldLessThanOrEqualTo)]
        [TestCase(FieldBeginsWith)]
        [TestCase(FieldContains)]
        [TestCase(FieldDateRangesOverlap)]
        [TestCase(FieldIncludes)]
        [TestCase(FieldNotIncludes)]
        [TestCase(FieldIsNull)]
        [TestCase(FieldIsNotNull)]
        [TestCase(FieldEmpty)]
        public void AUT_CamlComparisonOperator_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_camlComparisonOperatorInstanceFixture, 
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
        ///     Class (<see cref="CamlComparisonOperator" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CamlComparisonOperator_Is_Instance_Present_Test()
        {
            // Assert
            _camlComparisonOperatorInstanceType.ShouldNotBeNull();
            _camlComparisonOperatorInstance.ShouldNotBeNull();
            _camlComparisonOperatorInstanceFixture.ShouldNotBeNull();
            _camlComparisonOperatorInstance.ShouldBeAssignableTo<CamlComparisonOperator>();
            _camlComparisonOperatorInstanceFixture.ShouldBeAssignableTo<CamlComparisonOperator>();
        }

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CamlComparisonOperator) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyOperatorName)]
        [TestCaseGeneric(typeof(string) , PropertyOperator)]
        public void AUT_CamlComparisonOperator_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CamlComparisonOperator, T>(_camlComparisonOperatorInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CamlComparisonOperator) => Property (Operator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CamlComparisonOperator_Public_Class_Operator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOperator);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CamlComparisonOperator) => Property (OperatorName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CamlComparisonOperator_Public_Class_OperatorName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOperatorName);

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
        ///     Class (<see cref="CamlComparisonOperator" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetCamlOperatorByValue)]
        public void AUT_CamlComparisonOperator_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_camlComparisonOperatorInstanceFixture,
                                                                              _camlComparisonOperatorInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCamlOperatorByValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_camlComparisonOperatorInstanceFixture, _camlComparisonOperatorInstanceType, MethodGetCamlOperatorByValue, Fixture, methodGetCamlOperatorByValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CamlComparisonOperator.GetCamlOperatorByValue(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetCamlOperatorByValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCamlOperatorByValue = { value };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCamlOperatorByValue, methodGetCamlOperatorByValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_camlComparisonOperatorInstanceFixture, _camlComparisonOperatorInstanceType, MethodGetCamlOperatorByValue, Fixture, methodGetCamlOperatorByValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<CamlComparisonOperator>(_camlComparisonOperatorInstanceFixture, _camlComparisonOperatorInstanceType, MethodGetCamlOperatorByValue, parametersOfGetCamlOperatorByValue, methodGetCamlOperatorByValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCamlOperatorByValue.ShouldNotBeNull();
            parametersOfGetCamlOperatorByValue.Length.ShouldBe(1);
            methodGetCamlOperatorByValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<CamlComparisonOperator>(_camlComparisonOperatorInstanceFixture, _camlComparisonOperatorInstanceType, MethodGetCamlOperatorByValue, parametersOfGetCamlOperatorByValue, methodGetCamlOperatorByValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetCamlOperatorByValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCamlOperatorByValue = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCamlOperatorByValue, methodGetCamlOperatorByValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_camlComparisonOperatorInstanceFixture, parametersOfGetCamlOperatorByValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCamlOperatorByValue.ShouldNotBeNull();
            parametersOfGetCamlOperatorByValue.Length.ShouldBe(1);
            methodGetCamlOperatorByValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<string>();
            var methodGetCamlOperatorByValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCamlOperatorByValue = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<CamlComparisonOperator>(_camlComparisonOperatorInstanceFixture, _camlComparisonOperatorInstanceType, MethodGetCamlOperatorByValue, parametersOfGetCamlOperatorByValue, methodGetCamlOperatorByValuePrametersTypes);

            // Assert
            parametersOfGetCamlOperatorByValue.ShouldNotBeNull();
            parametersOfGetCamlOperatorByValue.Length.ShouldBe(1);
            methodGetCamlOperatorByValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCamlOperatorByValuePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_camlComparisonOperatorInstanceFixture, _camlComparisonOperatorInstanceType, MethodGetCamlOperatorByValue, Fixture, methodGetCamlOperatorByValuePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCamlOperatorByValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCamlOperatorByValuePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_camlComparisonOperatorInstanceFixture, _camlComparisonOperatorInstanceType, MethodGetCamlOperatorByValue, Fixture, methodGetCamlOperatorByValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCamlOperatorByValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCamlOperatorByValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_camlComparisonOperatorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCamlOperatorByValue) (Return Type : CamlComparisonOperator) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CamlComparisonOperator_GetCamlOperatorByValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCamlOperatorByValue, 0);
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