using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataCacheAPI" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DataCacheAPITest : AbstractBaseSetupTypedTest<DataCacheAPI>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataCacheAPI) Initializer

        private const string MethodSerializeToBinary = "SerializeToBinary";
        private const string MethodBinaryToClass = "BinaryToClass";
        private const string MethodSaveCachedData = "SaveCachedData";
        private const string MethodGetCachedData = "GetCachedData";
        private Type _dataCacheAPIInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataCacheAPI _dataCacheAPIInstance;
        private DataCacheAPI _dataCacheAPIInstanceFixture;

        #region General Initializer : Class (DataCacheAPI) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataCacheAPI" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataCacheAPIInstanceType = typeof(DataCacheAPI);
            _dataCacheAPIInstanceFixture = Create(true);
            _dataCacheAPIInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataCacheAPI)

        #region General Initializer : Class (DataCacheAPI) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DataCacheAPI" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodSerializeToBinary, 0)]
        [TestCase(MethodBinaryToClass, 0)]
        [TestCase(MethodSaveCachedData, 0)]
        [TestCase(MethodGetCachedData, 0)]
        public void AUT_DataCacheAPI_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_dataCacheAPIInstanceFixture, 
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
        ///     Class (<see cref="DataCacheAPI" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DataCacheAPI_Is_Instance_Present_Test()
        {
            // Assert
            _dataCacheAPIInstanceType.ShouldNotBeNull();
            _dataCacheAPIInstance.ShouldNotBeNull();
            _dataCacheAPIInstanceFixture.ShouldNotBeNull();
            _dataCacheAPIInstance.ShouldBeAssignableTo<DataCacheAPI>();
            _dataCacheAPIInstanceFixture.ShouldBeAssignableTo<DataCacheAPI>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataCacheAPI) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DataCacheAPI_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataCacheAPI instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataCacheAPIInstanceType.ShouldNotBeNull();
            _dataCacheAPIInstance.ShouldNotBeNull();
            _dataCacheAPIInstanceFixture.ShouldNotBeNull();
            _dataCacheAPIInstance.ShouldBeAssignableTo<DataCacheAPI>();
            _dataCacheAPIInstanceFixture.ShouldBeAssignableTo<DataCacheAPI>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="DataCacheAPI" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSerializeToBinary)]
        [TestCase(MethodBinaryToClass)]
        [TestCase(MethodSaveCachedData)]
        [TestCase(MethodGetCachedData)]
        public void AUT_DataCacheAPI_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_dataCacheAPIInstanceFixture,
                                                                              _dataCacheAPIInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (SerializeToBinary) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataCacheAPI_SerializeToBinary_Static_Method_Call_Internally(Type[] types)
        {
            var methodSerializeToBinaryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodSerializeToBinary, Fixture, methodSerializeToBinaryPrametersTypes);
        }

        #endregion

        #region Method Call : (SerializeToBinary) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SerializeToBinary_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodSerializeToBinaryPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfSerializeToBinary = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSerializeToBinary, methodSerializeToBinaryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataCacheAPIInstanceFixture, parametersOfSerializeToBinary);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSerializeToBinary.ShouldNotBeNull();
            parametersOfSerializeToBinary.Length.ShouldBe(1);
            methodSerializeToBinaryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SerializeToBinary) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SerializeToBinary_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<object>();
            var methodSerializeToBinaryPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfSerializeToBinary = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodSerializeToBinary, parametersOfSerializeToBinary, methodSerializeToBinaryPrametersTypes);

            // Assert
            parametersOfSerializeToBinary.ShouldNotBeNull();
            parametersOfSerializeToBinary.Length.ShouldBe(1);
            methodSerializeToBinaryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SerializeToBinary) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SerializeToBinary_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSerializeToBinaryPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodSerializeToBinary, Fixture, methodSerializeToBinaryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSerializeToBinaryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SerializeToBinary) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SerializeToBinary_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSerializeToBinaryPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodSerializeToBinary, Fixture, methodSerializeToBinaryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSerializeToBinaryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SerializeToBinary) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SerializeToBinary_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSerializeToBinary, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dataCacheAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SerializeToBinary) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SerializeToBinary_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSerializeToBinary, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BinaryToClass) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataCacheAPI_BinaryToClass_Static_Method_Call_Internally(Type[] types)
        {
            var methodBinaryToClassPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodBinaryToClass, Fixture, methodBinaryToClassPrametersTypes);
        }

        #endregion

        #region Method Call : (BinaryToClass) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_BinaryToClass_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodBinaryToClassPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBinaryToClass = { str };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBinaryToClass, methodBinaryToClassPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodBinaryToClass, Fixture, methodBinaryToClassPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodBinaryToClass, parametersOfBinaryToClass, methodBinaryToClassPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_dataCacheAPIInstanceFixture, parametersOfBinaryToClass);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBinaryToClass.ShouldNotBeNull();
            parametersOfBinaryToClass.Length.ShouldBe(1);
            methodBinaryToClassPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BinaryToClass) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_BinaryToClass_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var str = CreateType<string>();
            var methodBinaryToClassPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBinaryToClass = { str };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodBinaryToClass, parametersOfBinaryToClass, methodBinaryToClassPrametersTypes);

            // Assert
            parametersOfBinaryToClass.ShouldNotBeNull();
            parametersOfBinaryToClass.Length.ShouldBe(1);
            methodBinaryToClassPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BinaryToClass) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_BinaryToClass_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBinaryToClassPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodBinaryToClass, Fixture, methodBinaryToClassPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBinaryToClassPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BinaryToClass) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_BinaryToClass_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBinaryToClassPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodBinaryToClass, Fixture, methodBinaryToClassPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBinaryToClassPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BinaryToClass) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_BinaryToClass_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBinaryToClass, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dataCacheAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BinaryToClass) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_BinaryToClass_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBinaryToClass, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataCacheAPI_SaveCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SaveCachedData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            Action executeAction = null;

            // Act
            executeAction = () => DataCacheAPI.SaveCachedData(Context, sKey, value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };
            object[] parametersOfSaveCachedData = { Context, sKey, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveCachedData, methodSaveCachedDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataCacheAPIInstanceFixture, parametersOfSaveCachedData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveCachedData.ShouldNotBeNull();
            parametersOfSaveCachedData.Length.ShouldBe(3);
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SaveCachedData_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var value = CreateType<object>();
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };
            object[] parametersOfSaveCachedData = { Context, sKey, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodSaveCachedData, parametersOfSaveCachedData, methodSaveCachedDataPrametersTypes);

            // Assert
            parametersOfSaveCachedData.ShouldNotBeNull();
            parametersOfSaveCachedData.Length.ShouldBe(3);
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SaveCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCachedData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SaveCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodSaveCachedData, Fixture, methodSaveCachedDataPrametersTypes);

            // Assert
            methodSaveCachedDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCachedData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_SaveCachedData_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCachedData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dataCacheAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataCacheAPI_GetCachedData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCachedDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_GetCachedData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DataCacheAPI.GetCachedData(Context, sKey);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_GetCachedData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, methodGetCachedDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<object>(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_dataCacheAPIInstanceFixture, parametersOfGetCachedData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCachedData.ShouldNotBeNull();
            parametersOfGetCachedData.Length.ShouldBe(2);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_GetCachedData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sKey = CreateType<string>();
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetCachedData = { Context, sKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<object>(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodGetCachedData, parametersOfGetCachedData, methodGetCachedDataPrametersTypes);

            // Assert
            parametersOfGetCachedData.ShouldNotBeNull();
            parametersOfGetCachedData.Length.ShouldBe(2);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_GetCachedData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCachedDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_GetCachedData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCachedDataPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_dataCacheAPIInstanceFixture, _dataCacheAPIInstanceType, MethodGetCachedData, Fixture, methodGetCachedDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCachedDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_GetCachedData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCachedData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dataCacheAPIInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCachedData) (Return Type : object) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataCacheAPI_GetCachedData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCachedData, 0);
            const int parametersCount = 2;

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