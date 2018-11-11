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

namespace EPMLiveCore.ActLicensing
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ActLicensing.Licensing" />)
    ///     and namespace <see cref="EPMLiveCore.ActLicensing"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LicensingTest : AbstractBaseSetupTypedTest<Licensing>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Licensing) Initializer

        private const string PropertyUrl = "Url";
        private const string PropertyUseDefaultCredentials = "UseDefaultCredentials";
        private const string MethodGetAdminUser = "GetAdminUser";
        private const string MethodGetAdminUserAsync = "GetAdminUserAsync";
        private const string MethodOnGetAdminUserOperationCompleted = "OnGetAdminUserOperationCompleted";
        private const string MethodSetUserLevel = "SetUserLevel";
        private const string MethodSetUserLevelAsync = "SetUserLevelAsync";
        private const string MethodOnSetUserLevelOperationCompleted = "OnSetUserLevelOperationCompleted";
        private const string MethodCancelAsync = "CancelAsync";
        private const string MethodIsLocalFileSystemWebService = "IsLocalFileSystemWebService";
        private const string FieldGetAdminUserOperationCompleted = "GetAdminUserOperationCompleted";
        private const string FieldSetUserLevelOperationCompleted = "SetUserLevelOperationCompleted";
        private const string FielduseDefaultCredentialsSetExplicitly = "useDefaultCredentialsSetExplicitly";
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
        [TestCase(MethodOnGetAdminUserOperationCompleted, 0)]
        [TestCase(MethodSetUserLevel, 0)]
        [TestCase(MethodOnSetUserLevelOperationCompleted, 0)]
        [TestCase(MethodIsLocalFileSystemWebService, 0)]
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

        #region General Initializer : Class (Licensing) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Licensing" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyUrl)]
        [TestCase(PropertyUseDefaultCredentials)]
        public void AUT_Licensing_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_licensingInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Licensing) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Licensing" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldGetAdminUserOperationCompleted)]
        [TestCase(FieldSetUserLevelOperationCompleted)]
        [TestCase(FielduseDefaultCredentialsSetExplicitly)]
        public void AUT_Licensing_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_licensingInstanceFixture, 
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

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Licensing) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyUrl)]
        [TestCaseGeneric(typeof(bool) , PropertyUseDefaultCredentials)]
        public void AUT_Licensing_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Licensing, T>(_licensingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Licensing) => Property (Url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Licensing_Public_Class_Url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Licensing) => Property (UseDefaultCredentials) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Licensing_Public_Class_UseDefaultCredentials_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseDefaultCredentials);

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
        ///      Class (<see cref="Licensing" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodGetAdminUser)]
        [TestCase(MethodOnGetAdminUserOperationCompleted)]
        [TestCase(MethodSetUserLevel)]
        [TestCase(MethodOnSetUserLevelOperationCompleted)]
        [TestCase(MethodIsLocalFileSystemWebService)]
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

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Licensing, string>(_licensingInstance, MethodGetAdminUser, parametersOfGetAdminUser, methodGetAdminUserPrametersTypes);

            // Assert
            parametersOfGetAdminUser.ShouldBeNull();
            methodGetAdminUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
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

        #region Method Call : (OnGetAdminUserOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Licensing_OnGetAdminUserOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnGetAdminUserOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodOnGetAdminUserOperationCompleted, Fixture, methodOnGetAdminUserOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnGetAdminUserOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnGetAdminUserOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnGetAdminUserOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnGetAdminUserOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnGetAdminUserOperationCompleted, methodOnGetAdminUserOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_licensingInstanceFixture, parametersOfOnGetAdminUserOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnGetAdminUserOperationCompleted.ShouldNotBeNull();
            parametersOfOnGetAdminUserOperationCompleted.Length.ShouldBe(1);
            methodOnGetAdminUserOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnGetAdminUserOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnGetAdminUserOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnGetAdminUserOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnGetAdminUserOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnGetAdminUserOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnGetAdminUserOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_licensingInstance, MethodOnGetAdminUserOperationCompleted, parametersOfOnGetAdminUserOperationCompleted, methodOnGetAdminUserOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnGetAdminUserOperationCompleted.ShouldNotBeNull();
            parametersOfOnGetAdminUserOperationCompleted.Length.ShouldBe(1);
            methodOnGetAdminUserOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnGetAdminUserOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnGetAdminUserOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnGetAdminUserOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnGetAdminUserOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnGetAdminUserOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnGetAdminUserOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnGetAdminUserOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnGetAdminUserOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodOnGetAdminUserOperationCompleted, Fixture, methodOnGetAdminUserOperationCompletedPrametersTypes);

            // Assert
            methodOnGetAdminUserOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnGetAdminUserOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnGetAdminUserOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnGetAdminUserOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_licensingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
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

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Licensing, int>(_licensingInstance, MethodSetUserLevel, parametersOfSetUserLevel, methodSetUserLevelPrametersTypes);

            // Assert
            parametersOfSetUserLevel.ShouldNotBeNull();
            parametersOfSetUserLevel.Length.ShouldBe(2);
            methodSetUserLevelPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
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

        #region Method Call : (OnSetUserLevelOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Licensing_OnSetUserLevelOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnSetUserLevelOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodOnSetUserLevelOperationCompleted, Fixture, methodOnSetUserLevelOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnSetUserLevelOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnSetUserLevelOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnSetUserLevelOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnSetUserLevelOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSetUserLevelOperationCompleted, methodOnSetUserLevelOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_licensingInstanceFixture, parametersOfOnSetUserLevelOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnSetUserLevelOperationCompleted.ShouldNotBeNull();
            parametersOfOnSetUserLevelOperationCompleted.Length.ShouldBe(1);
            methodOnSetUserLevelOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnSetUserLevelOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnSetUserLevelOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSetUserLevelOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnSetUserLevelOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnSetUserLevelOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnSetUserLevelOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_licensingInstance, MethodOnSetUserLevelOperationCompleted, parametersOfOnSetUserLevelOperationCompleted, methodOnSetUserLevelOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnSetUserLevelOperationCompleted.ShouldNotBeNull();
            parametersOfOnSetUserLevelOperationCompleted.Length.ShouldBe(1);
            methodOnSetUserLevelOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnSetUserLevelOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnSetUserLevelOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSetUserLevelOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnSetUserLevelOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnSetUserLevelOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnSetUserLevelOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnSetUserLevelOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSetUserLevelOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodOnSetUserLevelOperationCompleted, Fixture, methodOnSetUserLevelOperationCompletedPrametersTypes);

            // Assert
            methodOnSetUserLevelOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSetUserLevelOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_OnSetUserLevelOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSetUserLevelOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_licensingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Licensing_IsLocalFileSystemWebService_Method_Call_Internally(Type[] types)
        {
            var methodIsLocalFileSystemWebServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_IsLocalFileSystemWebService_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Licensing, bool>(_licensingInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Licensing, bool>(_licensingInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLocalFileSystemWebService.ShouldNotBeNull();
            parametersOfIsLocalFileSystemWebService.Length.ShouldBe(1);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_IsLocalFileSystemWebService_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Licensing, bool>(_licensingInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Licensing, bool>(_licensingInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLocalFileSystemWebService.ShouldNotBeNull();
            parametersOfIsLocalFileSystemWebService.Length.ShouldBe(1);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_IsLocalFileSystemWebService_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Licensing, bool>(_licensingInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            parametersOfIsLocalFileSystemWebService.ShouldNotBeNull();
            parametersOfIsLocalFileSystemWebService.Length.ShouldBe(1);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_licensingInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_licensingInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Licensing_IsLocalFileSystemWebService_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, 0);
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