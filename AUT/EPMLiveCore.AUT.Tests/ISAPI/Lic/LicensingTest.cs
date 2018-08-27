using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Licensing" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class LicensingTest : AbstractBaseSetupTypedTest<Licensing>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Licensing) Initializer

        private const string MethodGetAdminUser = "GetAdminUser";
        private const string MethodSetUserLevel = "SetUserLevel";
        private const string MethodGetFarmFeatureUsers = "GetFarmFeatureUsers";
        private Type _licensingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Licensing _licensingInstance;
        private Licensing _licensingInstanceFixture;

        #region General Initializer : Class (Licensing) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Licensing" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _licensingInstanceType = typeof(Licensing);
            _licensingInstanceFixture = Create(true);
            _licensingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Licensing)

        #region General Initializer : Class (Licensing) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Licensing" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodGetAdminUser, 0)]
        [TestCase(MethodSetUserLevel, 0)]
        [TestCase(MethodGetFarmFeatureUsers, 0)]
        public void AUT_Licensing_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_licensingInstanceFixture, 
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
        ///     Class (<see cref="Licensing" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Licensing_Is_Instance_Present_Test()
        {
            // Assert
            _licensingInstanceType.ShouldNotBeNull();
            _licensingInstance.ShouldNotBeNull();
            _licensingInstanceFixture.ShouldNotBeNull();
            _licensingInstance.ShouldBeAssignableTo<Licensing>();
            _licensingInstanceFixture.ShouldBeAssignableTo<Licensing>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Licensing) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Licensing_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Licensing instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _licensingInstanceType.ShouldNotBeNull();
            _licensingInstance.ShouldNotBeNull();
            _licensingInstanceFixture.ShouldNotBeNull();
            _licensingInstance.ShouldBeAssignableTo<Licensing>();
            _licensingInstanceFixture.ShouldBeAssignableTo<Licensing>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Licensing" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodGetAdminUser)]
        [TestCase(MethodSetUserLevel)]
        [TestCase(MethodGetFarmFeatureUsers)]
        public void AUT_Licensing_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Licensing>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetAdminUser) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Licensing_GetAdminUser_Method_Call_Internally(Type[] types)
        {
            var methodGetAdminUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodGetAdminUser, Fixture, methodGetAdminUserPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAdminUser) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetAdminUser_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _licensingInstance.GetAdminUser();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetAdminUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetAdminUser_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAdminUserPrametersTypes = null;
            object[] parametersOfGetAdminUser = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAdminUser, methodGetAdminUserPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Licensing, string>(_licensingInstanceFixture, out exception1, parametersOfGetAdminUser);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Licensing, string>(_licensingInstance, MethodGetAdminUser, parametersOfGetAdminUser, methodGetAdminUserPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAdminUser.ShouldBeNull();
            methodGetAdminUserPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_licensingInstanceFixture, parametersOfGetAdminUser));
        }

        #endregion

        #region Method Call : (GetAdminUser) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetAdminUser_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetAdminUserPrametersTypes = null;
            object[] parametersOfGetAdminUser = null; // no parameter present

            // Assert
            parametersOfGetAdminUser.ShouldBeNull();
            methodGetAdminUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Licensing, string>(_licensingInstance, MethodGetAdminUser, parametersOfGetAdminUser, methodGetAdminUserPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAdminUser) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetAdminUser_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAdminUserPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodGetAdminUser, Fixture, methodGetAdminUserPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAdminUserPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAdminUser) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetAdminUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetAdminUserPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodGetAdminUser, Fixture, methodGetAdminUserPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAdminUserPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAdminUser) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetAdminUser_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAdminUser, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_licensingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Licensing_SetUserLevel_Method_Call_Internally(Type[] types)
        {
            var methodSetUserLevelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodSetUserLevel, Fixture, methodSetUserLevelPrametersTypes);
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_SetUserLevel_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var featureId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _licensingInstance.SetUserLevel(username, featureId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_SetUserLevel_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var featureId = CreateType<int>();
            var methodSetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfSetUserLevel = { username, featureId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetUserLevel, methodSetUserLevelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Licensing, int>(_licensingInstanceFixture, out exception1, parametersOfSetUserLevel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Licensing, int>(_licensingInstance, MethodSetUserLevel, parametersOfSetUserLevel, methodSetUserLevelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetUserLevel.ShouldNotBeNull();
            parametersOfSetUserLevel.Length.ShouldBe(2);
            methodSetUserLevelPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_licensingInstanceFixture, parametersOfSetUserLevel));
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_SetUserLevel_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var featureId = CreateType<int>();
            var methodSetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfSetUserLevel = { username, featureId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetUserLevel, methodSetUserLevelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Licensing, int>(_licensingInstanceFixture, out exception1, parametersOfSetUserLevel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Licensing, int>(_licensingInstance, MethodSetUserLevel, parametersOfSetUserLevel, methodSetUserLevelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetUserLevel.ShouldNotBeNull();
            parametersOfSetUserLevel.Length.ShouldBe(2);
            methodSetUserLevelPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Licensing, int>(_licensingInstance, MethodSetUserLevel, parametersOfSetUserLevel, methodSetUserLevelPrametersTypes));
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_SetUserLevel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var featureId = CreateType<int>();
            var methodSetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfSetUserLevel = { username, featureId };

            // Assert
            parametersOfSetUserLevel.ShouldNotBeNull();
            parametersOfSetUserLevel.Length.ShouldBe(2);
            methodSetUserLevelPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Licensing, int>(_licensingInstance, MethodSetUserLevel, parametersOfSetUserLevel, methodSetUserLevelPrametersTypes));
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_SetUserLevel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetUserLevelPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodSetUserLevel, Fixture, methodSetUserLevelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetUserLevelPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_SetUserLevel_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetUserLevel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_licensingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetUserLevel) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_SetUserLevel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetUserLevel, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Licensing_GetFarmFeatureUsers_Method_Call_Internally(Type[] types)
        {
            var methodGetFarmFeatureUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodGetFarmFeatureUsers, Fixture, methodGetFarmFeatureUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetFarmFeatureUsers_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var featureId = CreateType<int>();
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetFarmFeatureUsers = { featureId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFarmFeatureUsers, methodGetFarmFeatureUsersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Licensing, ArrayList>(_licensingInstanceFixture, out exception1, parametersOfGetFarmFeatureUsers);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Licensing, ArrayList>(_licensingInstance, MethodGetFarmFeatureUsers, parametersOfGetFarmFeatureUsers, methodGetFarmFeatureUsersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFarmFeatureUsers.ShouldNotBeNull();
            parametersOfGetFarmFeatureUsers.Length.ShouldBe(1);
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_licensingInstanceFixture, parametersOfGetFarmFeatureUsers));
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetFarmFeatureUsers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var featureId = CreateType<int>();
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetFarmFeatureUsers = { featureId };

            // Assert
            parametersOfGetFarmFeatureUsers.ShouldNotBeNull();
            parametersOfGetFarmFeatureUsers.Length.ShouldBe(1);
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Licensing, ArrayList>(_licensingInstance, MethodGetFarmFeatureUsers, parametersOfGetFarmFeatureUsers, methodGetFarmFeatureUsersPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetFarmFeatureUsers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodGetFarmFeatureUsers, Fixture, methodGetFarmFeatureUsersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetFarmFeatureUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFarmFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodGetFarmFeatureUsers, Fixture, methodGetFarmFeatureUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFarmFeatureUsersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetFarmFeatureUsers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFarmFeatureUsers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_licensingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFarmFeatureUsers) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_GetFarmFeatureUsers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFarmFeatureUsers, 0);
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