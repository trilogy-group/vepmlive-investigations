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

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainModel.EpmChartYaxisFormat" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartYaxisFormatTest : AbstractBaseSetupTypedTest<EpmChartYaxisFormat>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartYaxisFormat) Initializer

        private const string PropertyName = "Name";
        private const string PropertyDescription = "Description";
        private const string MethodGetByName = "GetByName";
        private const string FieldCurrency = "Currency";
        private const string FieldPercent = "Percent";
        private const string FieldNone = "None";
        private Type _epmChartYaxisFormatInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChartYaxisFormat _epmChartYaxisFormatInstance;
        private EpmChartYaxisFormat _epmChartYaxisFormatInstanceFixture;

        #region General Initializer : Class (EpmChartYaxisFormat) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartYaxisFormat" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartYaxisFormatInstanceType = typeof(EpmChartYaxisFormat);
            _epmChartYaxisFormatInstanceFixture = Create(true);
            _epmChartYaxisFormatInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartYaxisFormat)

        #region General Initializer : Class (EpmChartYaxisFormat) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartYaxisFormat" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetByName, 0)]
        public void AUT_EpmChartYaxisFormat_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartYaxisFormatInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChartYaxisFormat) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChartYaxisFormat" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyDescription)]
        public void AUT_EpmChartYaxisFormat_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_epmChartYaxisFormatInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChartYaxisFormat) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChartYaxisFormat" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCurrency)]
        [TestCase(FieldPercent)]
        [TestCase(FieldNone)]
        public void AUT_EpmChartYaxisFormat_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_epmChartYaxisFormatInstanceFixture, 
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
        ///     Class (<see cref="EpmChartYaxisFormat" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChartYaxisFormat_Is_Instance_Present_Test()
        {
            // Assert
            _epmChartYaxisFormatInstanceType.ShouldNotBeNull();
            _epmChartYaxisFormatInstance.ShouldNotBeNull();
            _epmChartYaxisFormatInstanceFixture.ShouldNotBeNull();
            _epmChartYaxisFormatInstance.ShouldBeAssignableTo<EpmChartYaxisFormat>();
            _epmChartYaxisFormatInstanceFixture.ShouldBeAssignableTo<EpmChartYaxisFormat>();
        }

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EpmChartYaxisFormat) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        public void AUT_EpmChartYaxisFormat_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EpmChartYaxisFormat, T>(_epmChartYaxisFormatInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartYaxisFormat) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartYaxisFormat_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartYaxisFormat) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartYaxisFormat_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

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
        ///     Class (<see cref="EpmChartYaxisFormat" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetByName)]
        public void AUT_EpmChartYaxisFormat_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_epmChartYaxisFormatInstanceFixture,
                                                                              _epmChartYaxisFormatInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetByNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartYaxisFormatInstanceFixture, _epmChartYaxisFormatInstanceType, MethodGetByName, Fixture, methodGetByNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => EpmChartYaxisFormat.GetByName(name);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetByNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetByName = { name };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetByName, methodGetByNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartYaxisFormatInstanceFixture, _epmChartYaxisFormatInstanceType, MethodGetByName, Fixture, methodGetByNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<EpmChartYaxisFormat>(_epmChartYaxisFormatInstanceFixture, _epmChartYaxisFormatInstanceType, MethodGetByName, parametersOfGetByName, methodGetByNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetByName.ShouldNotBeNull();
            parametersOfGetByName.Length.ShouldBe(1);
            methodGetByNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<EpmChartYaxisFormat>(_epmChartYaxisFormatInstanceFixture, _epmChartYaxisFormatInstanceType, MethodGetByName, parametersOfGetByName, methodGetByNamePrametersTypes));
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetByNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetByName = { name };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetByName, methodGetByNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartYaxisFormatInstanceFixture, parametersOfGetByName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetByName.ShouldNotBeNull();
            parametersOfGetByName.Length.ShouldBe(1);
            methodGetByNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetByNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetByName = { name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<EpmChartYaxisFormat>(_epmChartYaxisFormatInstanceFixture, _epmChartYaxisFormatInstanceType, MethodGetByName, parametersOfGetByName, methodGetByNamePrametersTypes);

            // Assert
            parametersOfGetByName.ShouldNotBeNull();
            parametersOfGetByName.Length.ShouldBe(1);
            methodGetByNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetByNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartYaxisFormatInstanceFixture, _epmChartYaxisFormatInstanceType, MethodGetByName, Fixture, methodGetByNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetByNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetByNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartYaxisFormatInstanceFixture, _epmChartYaxisFormatInstanceType, MethodGetByName, Fixture, methodGetByNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetByNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetByName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartYaxisFormatInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetByName) (Return Type : EpmChartYaxisFormat) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartYaxisFormat_GetByName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetByName, 0);
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