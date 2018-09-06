using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.Core.PFEDataServiceManager
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.PFEDataServiceManager.PFEDataServiceUtils" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.PFEDataServiceManager"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PFEDataServiceUtilsTest : AbstractBaseSetupTypedTest<PFEDataServiceUtils>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEDataServiceUtils) Initializer

        private const string MethodJsonSerializer = "JsonSerializer";
        private const string MethodJsonDeserialize = "JsonDeserialize";
        private const string MethodConvertJsonDateToDateString = "ConvertJsonDateToDateString";
        private const string MethodConvertDateStringToJsonDate = "ConvertDateStringToJsonDate";
        private const string MethodValidateResponse = "ValidateResponse";
        private Type _pFEDataServiceUtilsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEDataServiceUtils _pFEDataServiceUtilsInstance;
        private PFEDataServiceUtils _pFEDataServiceUtilsInstanceFixture;

        #region General Initializer : Class (PFEDataServiceUtils) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEDataServiceUtils" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEDataServiceUtilsInstanceType = typeof(PFEDataServiceUtils);
            _pFEDataServiceUtilsInstanceFixture = Create(true);
            _pFEDataServiceUtilsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEDataServiceUtils)

        #region General Initializer : Class (PFEDataServiceUtils) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PFEDataServiceUtils" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConvertJsonDateToDateString, 0)]
        [TestCase(MethodConvertDateStringToJsonDate, 0)]
        [TestCase(MethodValidateResponse, 0)]
        public void AUT_PFEDataServiceUtils_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pFEDataServiceUtilsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="PFEDataServiceUtils" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PFEDataServiceUtils_Is_Instance_Present_Test()
        {
            // Assert
            _pFEDataServiceUtilsInstanceType.ShouldNotBeNull();
            _pFEDataServiceUtilsInstance.ShouldNotBeNull();
            _pFEDataServiceUtilsInstanceFixture.ShouldNotBeNull();
            _pFEDataServiceUtilsInstance.ShouldBeAssignableTo<PFEDataServiceUtils>();
            _pFEDataServiceUtilsInstanceFixture.ShouldBeAssignableTo<PFEDataServiceUtils>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PFEDataServiceUtils) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PFEDataServiceUtils_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PFEDataServiceUtils instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _pFEDataServiceUtilsInstanceType.ShouldNotBeNull();
            _pFEDataServiceUtilsInstance.ShouldNotBeNull();
            _pFEDataServiceUtilsInstanceFixture.ShouldNotBeNull();
            _pFEDataServiceUtilsInstance.ShouldBeAssignableTo<PFEDataServiceUtils>();
            _pFEDataServiceUtilsInstanceFixture.ShouldBeAssignableTo<PFEDataServiceUtils>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="PFEDataServiceUtils" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConvertJsonDateToDateString)]
        [TestCase(MethodConvertDateStringToJsonDate)]
        [TestCase(MethodValidateResponse)]
        public void AUT_PFEDataServiceUtils_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_pFEDataServiceUtilsInstanceFixture,
                                                                              _pFEDataServiceUtilsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ConvertJsonDateToDateString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEDataServiceUtils_ConvertJsonDateToDateString_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertJsonDateToDateStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertJsonDateToDateString, Fixture, methodConvertJsonDateToDateStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertJsonDateToDateString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertJsonDateToDateString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var m = CreateType<System.Text.RegularExpressions.Match>();
            var methodConvertJsonDateToDateStringPrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };
            object[] parametersOfConvertJsonDateToDateString = { m };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertJsonDateToDateString, methodConvertJsonDateToDateStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertJsonDateToDateString, Fixture, methodConvertJsonDateToDateStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertJsonDateToDateString, parametersOfConvertJsonDateToDateString, methodConvertJsonDateToDateStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_pFEDataServiceUtilsInstanceFixture, parametersOfConvertJsonDateToDateString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfConvertJsonDateToDateString.ShouldNotBeNull();
            parametersOfConvertJsonDateToDateString.Length.ShouldBe(1);
            methodConvertJsonDateToDateStringPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConvertJsonDateToDateString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertJsonDateToDateString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var m = CreateType<System.Text.RegularExpressions.Match>();
            var methodConvertJsonDateToDateStringPrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };
            object[] parametersOfConvertJsonDateToDateString = { m };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertJsonDateToDateString, parametersOfConvertJsonDateToDateString, methodConvertJsonDateToDateStringPrametersTypes);

            // Assert
            parametersOfConvertJsonDateToDateString.ShouldNotBeNull();
            parametersOfConvertJsonDateToDateString.Length.ShouldBe(1);
            methodConvertJsonDateToDateStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertJsonDateToDateString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertJsonDateToDateString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertJsonDateToDateStringPrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertJsonDateToDateString, Fixture, methodConvertJsonDateToDateStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertJsonDateToDateStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertJsonDateToDateString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertJsonDateToDateString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertJsonDateToDateStringPrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertJsonDateToDateString, Fixture, methodConvertJsonDateToDateStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertJsonDateToDateStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertJsonDateToDateString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertJsonDateToDateString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertJsonDateToDateString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEDataServiceUtilsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertJsonDateToDateString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertJsonDateToDateString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertJsonDateToDateString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertDateStringToJsonDate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEDataServiceUtils_ConvertDateStringToJsonDate_Static_Method_Call_Internally(Type[] types)
        {
            var methodConvertDateStringToJsonDatePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertDateStringToJsonDate, Fixture, methodConvertDateStringToJsonDatePrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertDateStringToJsonDate) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertDateStringToJsonDate_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var m = CreateType<System.Text.RegularExpressions.Match>();
            var methodConvertDateStringToJsonDatePrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };
            object[] parametersOfConvertDateStringToJsonDate = { m };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertDateStringToJsonDate, methodConvertDateStringToJsonDatePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertDateStringToJsonDate, Fixture, methodConvertDateStringToJsonDatePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertDateStringToJsonDate, parametersOfConvertDateStringToJsonDate, methodConvertDateStringToJsonDatePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_pFEDataServiceUtilsInstanceFixture, parametersOfConvertDateStringToJsonDate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfConvertDateStringToJsonDate.ShouldNotBeNull();
            parametersOfConvertDateStringToJsonDate.Length.ShouldBe(1);
            methodConvertDateStringToJsonDatePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ConvertDateStringToJsonDate) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertDateStringToJsonDate_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var m = CreateType<System.Text.RegularExpressions.Match>();
            var methodConvertDateStringToJsonDatePrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };
            object[] parametersOfConvertDateStringToJsonDate = { m };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertDateStringToJsonDate, parametersOfConvertDateStringToJsonDate, methodConvertDateStringToJsonDatePrametersTypes);

            // Assert
            parametersOfConvertDateStringToJsonDate.ShouldNotBeNull();
            parametersOfConvertDateStringToJsonDate.Length.ShouldBe(1);
            methodConvertDateStringToJsonDatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertDateStringToJsonDate) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertDateStringToJsonDate_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConvertDateStringToJsonDatePrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertDateStringToJsonDate, Fixture, methodConvertDateStringToJsonDatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConvertDateStringToJsonDatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ConvertDateStringToJsonDate) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertDateStringToJsonDate_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConvertDateStringToJsonDatePrametersTypes = new Type[] { typeof(System.Text.RegularExpressions.Match) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodConvertDateStringToJsonDate, Fixture, methodConvertDateStringToJsonDatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConvertDateStringToJsonDatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConvertDateStringToJsonDate) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertDateStringToJsonDate_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertDateStringToJsonDate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEDataServiceUtilsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConvertDateStringToJsonDate) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ConvertDateStringToJsonDate_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConvertDateStringToJsonDate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateResponse) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEDataServiceUtils_ValidateResponse_Static_Method_Call_Internally(Type[] types)
        {
            var methodValidateResponsePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodValidateResponse, Fixture, methodValidateResponsePrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateResponse) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ValidateResponse_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var element = CreateType<XElement>();
            Action executeAction = null;

            // Act
            executeAction = () => PFEDataServiceUtils.ValidateResponse(element);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ValidateResponse) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ValidateResponse_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var element = CreateType<XElement>();
            var methodValidateResponsePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateResponse = { element };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateResponse, methodValidateResponsePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pFEDataServiceUtilsInstanceFixture, parametersOfValidateResponse);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateResponse.ShouldNotBeNull();
            parametersOfValidateResponse.Length.ShouldBe(1);
            methodValidateResponsePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateResponse) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ValidateResponse_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var element = CreateType<XElement>();
            var methodValidateResponsePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateResponse = { element };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodValidateResponse, parametersOfValidateResponse, methodValidateResponsePrametersTypes);

            // Assert
            parametersOfValidateResponse.ShouldNotBeNull();
            parametersOfValidateResponse.Length.ShouldBe(1);
            methodValidateResponsePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateResponse) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ValidateResponse_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateResponse, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateResponse) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ValidateResponse_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateResponsePrametersTypes = new Type[] { typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_pFEDataServiceUtilsInstanceFixture, _pFEDataServiceUtilsInstanceType, MethodValidateResponse, Fixture, methodValidateResponsePrametersTypes);

            // Assert
            methodValidateResponsePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateResponse) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PFEDataServiceUtils_ValidateResponse_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateResponse, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pFEDataServiceUtilsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}