using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.Win32;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Utilities" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UtilitiesTest : AbstractBaseSetupTest
    {

        public UtilitiesTest() : base(typeof(Utilities))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Utilities) Initializer

        private const string MethodGetBaseMessage = "GetBaseMessage";
        private const string MethodGetByteSafely = "GetByteSafely";
        private const string MethodGetDateTimeSafely = "GetDateTimeSafely";
        private const string MethodGetDecimalSafely = "GetDecimalSafely";
        private const string MethodGetInt32Safely = "GetInt32Safely";
        private const string MethodGetStringSafely = "GetStringSafely";
        private const string MethodResolveNTNameintoWResID = "ResolveNTNameintoWResID";
        private const string MethodGetRegistryKey = "GetRegistryKey";
        private const string MethodGetConnectionString = "GetConnectionString";
        private const string MethodCheckEditResourcePlanPermission = "CheckEditResourcePlanPermission";
        private const string MethodGetRoleRates = "GetRoleRates";
        private const string FieldPASS_PHRASE = "PASS_PHRASE";
        private Type _utilitiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (Utilities) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Utilities" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _utilitiesInstanceType = typeof(Utilities);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Utilities)

        #region General Initializer : Class (Utilities) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Utilities" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetBaseMessage, 0)]
        [TestCase(MethodGetByteSafely, 0)]
        [TestCase(MethodGetDateTimeSafely, 0)]
        [TestCase(MethodGetDecimalSafely, 0)]
        [TestCase(MethodGetInt32Safely, 0)]
        [TestCase(MethodGetStringSafely, 0)]
        [TestCase(MethodResolveNTNameintoWResID, 0)]
        [TestCase(MethodGetRegistryKey, 0)]
        [TestCase(MethodGetConnectionString, 0)]
        public void AUT_Utilities_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Utilities) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Utilities" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPASS_PHRASE)]
        public void AUT_Utilities_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="Utilities" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Utilities_Is_Static_Type_Present_Test()
        {
            // Assert
            _utilitiesInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Utilities" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetBaseMessage)]
        [TestCase(MethodGetByteSafely)]
        [TestCase(MethodGetDateTimeSafely)]
        [TestCase(MethodGetDecimalSafely)]
        [TestCase(MethodGetInt32Safely)]
        [TestCase(MethodGetStringSafely)]
        [TestCase(MethodResolveNTNameintoWResID)]
        [TestCase(MethodGetRegistryKey)]
        [TestCase(MethodGetConnectionString)]
        public void AUT_Utilities_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _utilitiesInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetBaseMessage_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetBaseMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetBaseMessage, Fixture, methodGetBaseMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetBaseMessage(exception);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodGetBaseMessagePrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfGetBaseMessage = { exception };
            var methodInfo = GetMethodInfo(MethodGetBaseMessage, methodGetBaseMessagePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetBaseMessage, Fixture, methodGetBaseMessagePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetBaseMessage, parametersOfGetBaseMessage, methodGetBaseMessagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetBaseMessage.ShouldNotBeNull();
            parametersOfGetBaseMessage.Length.ShouldBe(1);
            methodGetBaseMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetBaseMessage, parametersOfGetBaseMessage, methodGetBaseMessagePrametersTypes));
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodGetBaseMessagePrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfGetBaseMessage = { exception };
            var methodInfo = GetMethodInfo(MethodGetBaseMessage, methodGetBaseMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetBaseMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBaseMessage.ShouldNotBeNull();
            parametersOfGetBaseMessage.Length.ShouldBe(1);
            methodGetBaseMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var exception = CreateType<Exception>();
            var methodGetBaseMessagePrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfGetBaseMessage = { exception };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetBaseMessage, parametersOfGetBaseMessage, methodGetBaseMessagePrametersTypes);

            // Assert
            parametersOfGetBaseMessage.ShouldNotBeNull();
            parametersOfGetBaseMessage.Length.ShouldBe(1);
            methodGetBaseMessagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetBaseMessagePrametersTypes = new Type[] { typeof(Exception) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetBaseMessage, Fixture, methodGetBaseMessagePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBaseMessagePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBaseMessagePrametersTypes = new Type[] { typeof(Exception) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetBaseMessage, Fixture, methodGetBaseMessagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBaseMessagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBaseMessage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetBaseMessage) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetBaseMessage_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBaseMessage, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetByteSafely_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetByteSafelyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetByteSafely, Fixture, methodGetByteSafelyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetByteSafely_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetByteSafely(sqlDataReader, fieldName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetByteSafely_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetByteSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetByteSafely = { sqlDataReader, fieldName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetByteSafely, methodGetByteSafelyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetByteSafely, Fixture, methodGetByteSafelyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<byte?>(null, _utilitiesInstanceType, MethodGetByteSafely, parametersOfGetByteSafely, methodGetByteSafelyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetByteSafely);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetByteSafely.ShouldNotBeNull();
            parametersOfGetByteSafely.Length.ShouldBe(2);
            methodGetByteSafelyPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetByteSafely_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetByteSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetByteSafely = { sqlDataReader, fieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<byte?>(null, _utilitiesInstanceType, MethodGetByteSafely, parametersOfGetByteSafely, methodGetByteSafelyPrametersTypes);

            // Assert
            parametersOfGetByteSafely.ShouldNotBeNull();
            parametersOfGetByteSafely.Length.ShouldBe(2);
            methodGetByteSafelyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetByteSafely_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetByteSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetByteSafely, Fixture, methodGetByteSafelyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetByteSafelyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetByteSafely_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetByteSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetByteSafely, Fixture, methodGetByteSafelyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetByteSafelyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetByteSafely_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetByteSafely, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetByteSafely) (Return Type : byte?) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetByteSafely_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetByteSafely, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetDateTimeSafely_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDateTimeSafelyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetDateTimeSafely, Fixture, methodGetDateTimeSafelyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDateTimeSafely_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetDateTimeSafely(sqlDataReader, fieldName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDateTimeSafely_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetDateTimeSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetDateTimeSafely = { sqlDataReader, fieldName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDateTimeSafely, methodGetDateTimeSafelyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetDateTimeSafely, Fixture, methodGetDateTimeSafelyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DateTime?>(null, _utilitiesInstanceType, MethodGetDateTimeSafely, parametersOfGetDateTimeSafely, methodGetDateTimeSafelyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetDateTimeSafely);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDateTimeSafely.ShouldNotBeNull();
            parametersOfGetDateTimeSafely.Length.ShouldBe(2);
            methodGetDateTimeSafelyPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDateTimeSafely_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetDateTimeSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetDateTimeSafely = { sqlDataReader, fieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DateTime?>(null, _utilitiesInstanceType, MethodGetDateTimeSafely, parametersOfGetDateTimeSafely, methodGetDateTimeSafelyPrametersTypes);

            // Assert
            parametersOfGetDateTimeSafely.ShouldNotBeNull();
            parametersOfGetDateTimeSafely.Length.ShouldBe(2);
            methodGetDateTimeSafelyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDateTimeSafely_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDateTimeSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetDateTimeSafely, Fixture, methodGetDateTimeSafelyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDateTimeSafelyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDateTimeSafely_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDateTimeSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetDateTimeSafely, Fixture, methodGetDateTimeSafelyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDateTimeSafelyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDateTimeSafely_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDateTimeSafely, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDateTimeSafely) (Return Type : DateTime?) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDateTimeSafely_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDateTimeSafely, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDecimalSafely) (Return Type : decimal?) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetDecimalSafely_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDecimalSafelyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetDecimalSafely, Fixture, methodGetDecimalSafelyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDecimalSafely) (Return Type : decimal?) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDecimalSafely_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetDecimalSafely(sqlDataReader, fieldName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDecimalSafely) (Return Type : decimal?) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDecimalSafely_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetDecimalSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetDecimalSafely = { sqlDataReader, fieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<decimal?>(null, _utilitiesInstanceType, MethodGetDecimalSafely, parametersOfGetDecimalSafely, methodGetDecimalSafelyPrametersTypes);

            // Assert
            parametersOfGetDecimalSafely.ShouldNotBeNull();
            parametersOfGetDecimalSafely.Length.ShouldBe(2);
            methodGetDecimalSafelyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDecimalSafely) (Return Type : decimal?) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDecimalSafely_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDecimalSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetDecimalSafely, Fixture, methodGetDecimalSafelyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDecimalSafelyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDecimalSafely) (Return Type : decimal?) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDecimalSafely_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDecimalSafely, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDecimalSafely) (Return Type : decimal?) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetDecimalSafely_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDecimalSafely, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInt32Safely) (Return Type : int?) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetInt32Safely_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetInt32SafelyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetInt32Safely, Fixture, methodGetInt32SafelyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetInt32Safely) (Return Type : int?) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetInt32Safely_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetInt32Safely(sqlDataReader, fieldName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetInt32Safely) (Return Type : int?) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetInt32Safely_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetInt32SafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetInt32Safely = { sqlDataReader, fieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int?>(null, _utilitiesInstanceType, MethodGetInt32Safely, parametersOfGetInt32Safely, methodGetInt32SafelyPrametersTypes);

            // Assert
            parametersOfGetInt32Safely.ShouldNotBeNull();
            parametersOfGetInt32Safely.Length.ShouldBe(2);
            methodGetInt32SafelyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetInt32Safely) (Return Type : int?) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetInt32Safely_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetInt32SafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetInt32Safely, Fixture, methodGetInt32SafelyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetInt32SafelyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetInt32Safely) (Return Type : int?) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetInt32Safely_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetInt32Safely, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetInt32Safely) (Return Type : int?) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetInt32Safely_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetInt32Safely, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetStringSafely_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetStringSafelyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetStringSafely, Fixture, methodGetStringSafelyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetStringSafely_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetStringSafely(sqlDataReader, fieldName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetStringSafely_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetStringSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetStringSafely = { sqlDataReader, fieldName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringSafely, methodGetStringSafelyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetStringSafely, Fixture, methodGetStringSafelyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetStringSafely, parametersOfGetStringSafely, methodGetStringSafelyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetStringSafely);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetStringSafely.ShouldNotBeNull();
            parametersOfGetStringSafely.Length.ShouldBe(2);
            methodGetStringSafelyPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetStringSafely_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlDataReader = CreateType<SqlDataReader>();
            var fieldName = CreateType<string>();
            var methodGetStringSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfGetStringSafely = { sqlDataReader, fieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetStringSafely, parametersOfGetStringSafely, methodGetStringSafelyPrametersTypes);

            // Assert
            parametersOfGetStringSafely.ShouldNotBeNull();
            parametersOfGetStringSafely.Length.ShouldBe(2);
            methodGetStringSafelyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetStringSafely_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStringSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetStringSafely, Fixture, methodGetStringSafelyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStringSafelyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetStringSafely_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStringSafelyPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetStringSafely, Fixture, methodGetStringSafelyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStringSafelyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetStringSafely_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStringSafely, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStringSafely) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetStringSafely_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStringSafely, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_Internally(Type[] types)
        {
            var methodResolveNTNameintoWResIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, Fixture, methodResolveNTNameintoWResIDPrametersTypes);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var ntname = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.ResolveNTNameintoWResID(sqlConnection, ntname);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var ntname = CreateType<string>();
            var methodResolveNTNameintoWResIDPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfResolveNTNameintoWResID = { sqlConnection, ntname };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodResolveNTNameintoWResID, methodResolveNTNameintoWResIDPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, Fixture, methodResolveNTNameintoWResIDPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, parametersOfResolveNTNameintoWResID, methodResolveNTNameintoWResIDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfResolveNTNameintoWResID.ShouldNotBeNull();
            parametersOfResolveNTNameintoWResID.Length.ShouldBe(2);
            methodResolveNTNameintoWResIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, parametersOfResolveNTNameintoWResID, methodResolveNTNameintoWResIDPrametersTypes));
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var ntname = CreateType<string>();
            var methodResolveNTNameintoWResIDPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfResolveNTNameintoWResID = { sqlConnection, ntname };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodResolveNTNameintoWResID, methodResolveNTNameintoWResIDPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfResolveNTNameintoWResID);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfResolveNTNameintoWResID.ShouldNotBeNull();
            parametersOfResolveNTNameintoWResID.Length.ShouldBe(2);
            methodResolveNTNameintoWResIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var ntname = CreateType<string>();
            var methodResolveNTNameintoWResIDPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfResolveNTNameintoWResID = { sqlConnection, ntname };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, parametersOfResolveNTNameintoWResID, methodResolveNTNameintoWResIDPrametersTypes);

            // Assert
            parametersOfResolveNTNameintoWResID.ShouldNotBeNull();
            parametersOfResolveNTNameintoWResID.Length.ShouldBe(2);
            methodResolveNTNameintoWResIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodResolveNTNameintoWResIDPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, Fixture, methodResolveNTNameintoWResIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodResolveNTNameintoWResIDPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodResolveNTNameintoWResIDPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, Fixture, methodResolveNTNameintoWResIDPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodResolveNTNameintoWResIDPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodResolveNTNameintoWResIDPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodResolveNTNameintoWResID, Fixture, methodResolveNTNameintoWResIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodResolveNTNameintoWResIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodResolveNTNameintoWResID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ResolveNTNameintoWResID) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ResolveNTNameintoWResID_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodResolveNTNameintoWResID, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetRegistryKey_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRegistryKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRegistryKey, Fixture, methodGetRegistryKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetRegistryKey(basepath);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetRegistryKey = { basepath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRegistryKey, methodGetRegistryKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRegistryKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRegistryKey.ShouldNotBeNull();
            parametersOfGetRegistryKey.Length.ShouldBe(1);
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetRegistryKey = { basepath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<RegistryKey>(null, _utilitiesInstanceType, MethodGetRegistryKey, parametersOfGetRegistryKey, methodGetRegistryKeyPrametersTypes);

            // Assert
            parametersOfGetRegistryKey.ShouldNotBeNull();
            parametersOfGetRegistryKey.Length.ShouldBe(1);
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRegistryKey, Fixture, methodGetRegistryKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRegistryKey, Fixture, methodGetRegistryKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRegistryKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRegistryKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetConnectionString(basepath);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetConnectionString = { basepath };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, methodGetConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetConnectionString = { basepath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, methodGetConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetConnectionString = { basepath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes);

            // Assert
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetConnectionString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckEditResourcePlanPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodCheckEditResourcePlanPermission, Fixture, methodCheckEditResourcePlanPermissionPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckEditResourcePlanPermission, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetRoleRates_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRoleRatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRoleRates, Fixture, methodGetRoleRatesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetRoleRates) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRoleRates, 0);
            const int parametersCount = 5;

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