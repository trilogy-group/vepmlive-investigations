using System;
using System.Collections;
using System.Data;
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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.ConfigFunctions" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ConfigFunctionsTest : AbstractBaseSetupTypedTest<ConfigFunctions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ConfigFunctions) Initializer

        private const string MethodGetCleanUsername = "GetCleanUsername";
        private const string MethodgetDomain = "getDomain";
        private const string MethodgetUserFromAD = "getUserFromAD";
        private const string MethodgetUserString = "getUserString";
        private const string MethodgetRealField = "getRealField";
        private const string MethodgetSiteItems = "getSiteItems";
        private const string MethodaddTeam = "addTeam";
        private const string MethodgetItemXml = "getItemXml";
        private const string MethodgetMenuFromAssembly = "getMenuFromAssembly";
        private const string MethodgetFarmSetting = "getFarmSetting";
        private const string MethodsetFarmSetting = "setFarmSetting";
        private const string MethodgetWebAppSetting = "getWebAppSetting";
        private const string MethodsetWebAppSetting = "setWebAppSetting";
        private const string MethodgetListSetting = "getListSetting";
        private const string MethodgetConnectionString = "getConnectionString";
        private const string MethodsetConnectionString = "setConnectionString";
        private const string MethodsetConfigSetting = "setConfigSetting";
        private const string MethodiGetLockedWeb = "iGetLockedWeb";
        private const string MethodgetLockedWeb = "getLockedWeb";
        private const string MethodgetConfigSetting = "getConfigSetting";
        private const string MethodgetLockConfigSetting = "getLockConfigSetting";
        private const string MethodiGetConfigSetting = "iGetConfigSetting";
        private const string MethodfarmEncode = "farmEncode";
        private const string MethodcomputerCode = "computerCode";
        private const string MethodEncrypt = "Encrypt";
        private const string MethodDecrypt = "Decrypt";
        private const string MethoddeleteKey = "deleteKey";
        private const string MethodfeatureList = "featureList";
        private const string Methodenqueue = "enqueue";
        private const string FieldsaltValue = "saltValue";
        private const string FieldhashAlgorithm = "hashAlgorithm";
        private const string FieldpasswordIterations = "passwordIterations";
        private const string FieldinitVector = "initVector";
        private const string FieldkeySize = "keySize";
        private Type _configFunctionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ConfigFunctions _configFunctionsInstance;
        private ConfigFunctions _configFunctionsInstanceFixture;

        #region General Initializer : Class (ConfigFunctions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ConfigFunctions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _configFunctionsInstanceType = typeof(ConfigFunctions);
            _configFunctionsInstanceFixture = Create(true);
            _configFunctionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ConfigFunctions)

        #region General Initializer : Class (ConfigFunctions) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ConfigFunctions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetCleanUsername, 0)]
        [TestCase(MethodGetCleanUsername, 1)]
        [TestCase(MethodgetDomain, 0)]
        [TestCase(MethodgetUserFromAD, 0)]
        [TestCase(MethodgetUserString, 0)]
        [TestCase(MethodgetRealField, 0)]
        [TestCase(MethodgetSiteItems, 0)]
        [TestCase(MethodaddTeam, 0)]
        [TestCase(MethodgetItemXml, 0)]
        [TestCase(MethodgetMenuFromAssembly, 0)]
        [TestCase(MethodgetFarmSetting, 0)]
        [TestCase(MethodsetFarmSetting, 0)]
        [TestCase(MethodgetWebAppSetting, 0)]
        [TestCase(MethodsetWebAppSetting, 0)]
        [TestCase(MethodgetListSetting, 0)]
        [TestCase(MethodgetConnectionString, 0)]
        [TestCase(MethodsetConnectionString, 0)]
        [TestCase(MethodsetConfigSetting, 0)]
        [TestCase(MethodiGetLockedWeb, 0)]
        [TestCase(MethodgetLockedWeb, 0)]
        [TestCase(MethodgetConfigSetting, 0)]
        [TestCase(MethodgetConfigSetting, 1)]
        [TestCase(MethodgetLockConfigSetting, 0)]
        [TestCase(MethodiGetConfigSetting, 0)]
        [TestCase(MethodfarmEncode, 0)]
        [TestCase(MethodcomputerCode, 0)]
        [TestCase(MethodEncrypt, 0)]
        [TestCase(MethodDecrypt, 0)]
        [TestCase(MethoddeleteKey, 0)]
        [TestCase(MethodfeatureList, 0)]
        [TestCase(Methodenqueue, 0)]
        [TestCase(Methodenqueue, 1)]
        public void AUT_ConfigFunctions_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_configFunctionsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ConfigFunctions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ConfigFunctions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsaltValue)]
        [TestCase(FieldhashAlgorithm)]
        [TestCase(FieldpasswordIterations)]
        [TestCase(FieldinitVector)]
        [TestCase(FieldkeySize)]
        public void AUT_ConfigFunctions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_configFunctionsInstanceFixture, 
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
        ///     Class (<see cref="ConfigFunctions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ConfigFunctions_Is_Instance_Present_Test()
        {
            // Assert
            _configFunctionsInstanceType.ShouldNotBeNull();
            _configFunctionsInstance.ShouldNotBeNull();
            _configFunctionsInstanceFixture.ShouldNotBeNull();
            _configFunctionsInstance.ShouldBeAssignableTo<ConfigFunctions>();
            _configFunctionsInstanceFixture.ShouldBeAssignableTo<ConfigFunctions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ConfigFunctions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ConfigFunctions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ConfigFunctions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _configFunctionsInstanceType.ShouldNotBeNull();
            _configFunctionsInstance.ShouldNotBeNull();
            _configFunctionsInstanceFixture.ShouldNotBeNull();
            _configFunctionsInstance.ShouldBeAssignableTo<ConfigFunctions>();
            _configFunctionsInstanceFixture.ShouldBeAssignableTo<ConfigFunctions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ConfigFunctions" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetCleanUsername)]
        [TestCase(MethodgetDomain)]
        [TestCase(MethodgetUserFromAD)]
        [TestCase(MethodgetUserString)]
        [TestCase(MethodgetRealField)]
        [TestCase(MethodgetSiteItems)]
        [TestCase(MethodaddTeam)]
        [TestCase(MethodgetItemXml)]
        [TestCase(MethodgetMenuFromAssembly)]
        [TestCase(MethodgetFarmSetting)]
        [TestCase(MethodsetFarmSetting)]
        [TestCase(MethodgetWebAppSetting)]
        [TestCase(MethodsetWebAppSetting)]
        [TestCase(MethodgetListSetting)]
        [TestCase(MethodgetConnectionString)]
        [TestCase(MethodsetConnectionString)]
        [TestCase(MethodsetConfigSetting)]
        [TestCase(MethodiGetLockedWeb)]
        [TestCase(MethodgetLockedWeb)]
        [TestCase(MethodgetConfigSetting)]
        [TestCase(MethodgetLockConfigSetting)]
        [TestCase(MethodiGetConfigSetting)]
        [TestCase(MethodfarmEncode)]
        [TestCase(MethodcomputerCode)]
        [TestCase(MethodEncrypt)]
        [TestCase(MethodDecrypt)]
        [TestCase(MethoddeleteKey)]
        [TestCase(MethodfeatureList)]
        [TestCase(Methodenqueue)]
        public void AUT_ConfigFunctions_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_configFunctionsInstanceFixture,
                                                                              _configFunctionsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanUsernamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.GetCleanUsername(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetCleanUsername = { web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUsername, methodGetCleanUsernamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, parametersOfGetCleanUsername, methodGetCleanUsernamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfGetCleanUsername);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCleanUsername.ShouldNotBeNull();
            parametersOfGetCleanUsername.Length.ShouldBe(1);
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetCleanUsername = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, parametersOfGetCleanUsername, methodGetCleanUsernamePrametersTypes);

            // Assert
            parametersOfGetCleanUsername.ShouldNotBeNull();
            parametersOfGetCleanUsername.Length.ShouldBe(1);
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUsername, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanUsername, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetCleanUsernamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.GetCleanUsername(web, username);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var username = CreateType<string>();
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetCleanUsername = { web, username };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUsername, methodGetCleanUsernamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, parametersOfGetCleanUsername, methodGetCleanUsernamePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfGetCleanUsername);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCleanUsername.ShouldNotBeNull();
            parametersOfGetCleanUsername.Length.ShouldBe(2);
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var username = CreateType<string>();
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetCleanUsername = { web, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, parametersOfGetCleanUsername, methodGetCleanUsernamePrametersTypes);

            // Assert
            parametersOfGetCleanUsername.ShouldNotBeNull();
            parametersOfGetCleanUsername.Length.ShouldBe(2);
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanUsernamePrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodGetCleanUsername, Fixture, methodGetCleanUsernamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanUsernamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUsername, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCleanUsername) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_GetCleanUsername_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanUsername, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getDomain_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetDomainPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetDomain, Fixture, methodgetDomainPrametersTypes);
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getDomain_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetDomainPrametersTypes = null;
            object[] parametersOfgetDomain = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetDomain, methodgetDomainPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetDomain);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetDomain.ShouldBeNull();
            methodgetDomainPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getDomain_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetDomainPrametersTypes = null;
            object[] parametersOfgetDomain = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetDomain, parametersOfgetDomain, methodgetDomainPrametersTypes);

            // Assert
            parametersOfgetDomain.ShouldBeNull();
            methodgetDomainPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getDomain_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetDomainPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetDomain, Fixture, methodgetDomainPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetDomainPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getDomain_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetDomainPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetDomain, Fixture, methodgetDomainPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetDomainPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getDomain_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetDomain, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getUserFromAD_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetUserFromADPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserFromAD, Fixture, methodgetUserFromADPrametersTypes);
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserFromAD_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetUserFromADPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserFromAD, Fixture, methodgetUserFromADPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetUserFromADPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserFromAD_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetUserFromADPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserFromAD, Fixture, methodgetUserFromADPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetUserFromADPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserFromAD_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetUserFromAD, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserFromAD_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetUserFromAD, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getUserString_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetUserStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var usernames = CreateType<string>();
            var web = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getUserString(usernames, web, sPrefix);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var usernames = CreateType<string>();
            var web = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            object[] parametersOfgetUserString = { usernames, web, sPrefix };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetUserString, methodgetUserStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserString, parametersOfgetUserString, methodgetUserStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetUserString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetUserString.ShouldNotBeNull();
            parametersOfgetUserString.Length.ShouldBe(3);
            methodgetUserStringPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var usernames = CreateType<string>();
            var web = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            object[] parametersOfgetUserString = { usernames, web, sPrefix };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserString, parametersOfgetUserString, methodgetUserStringPrametersTypes);

            // Assert
            parametersOfgetUserString.ShouldNotBeNull();
            parametersOfgetUserString.Length.ShouldBe(3);
            methodgetUserStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetUserStringPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetUserStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetUserString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getUserString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetUserString, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getRealField_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getRealField_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getRealField(field);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getRealField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getRealField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPField>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getRealField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getRealField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getRealField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getRealField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getSiteItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetSiteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getSiteItems_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var view = CreateType<SPView>();
            var spquery = CreateType<string>();
            var filterfield = CreateType<string>();
            var usewbs = CreateType<string>();
            var rlist = CreateType<string>();
            var arrGroupFields = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getSiteItems(web, view, spquery, filterfield, usewbs, rlist, arrGroupFields);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getSiteItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var view = CreateType<SPView>();
            var spquery = CreateType<string>();
            var filterfield = CreateType<string>();
            var usewbs = CreateType<string>();
            var rlist = CreateType<string>();
            var arrGroupFields = CreateType<string[]>();
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string[]) };
            object[] parametersOfgetSiteItems = { web, view, spquery, filterfield, usewbs, rlist, arrGroupFields };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSiteItems, methodgetSiteItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetSiteItems, parametersOfgetSiteItems, methodgetSiteItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetSiteItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetSiteItems.ShouldNotBeNull();
            parametersOfgetSiteItems.Length.ShouldBe(7);
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getSiteItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var view = CreateType<SPView>();
            var spquery = CreateType<string>();
            var filterfield = CreateType<string>();
            var usewbs = CreateType<string>();
            var rlist = CreateType<string>();
            var arrGroupFields = CreateType<string[]>();
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string[]) };
            object[] parametersOfgetSiteItems = { web, view, spquery, filterfield, usewbs, rlist, arrGroupFields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetSiteItems, parametersOfgetSiteItems, methodgetSiteItemsPrametersTypes);

            // Assert
            parametersOfgetSiteItems.ShouldNotBeNull();
            parametersOfgetSiteItems.Length.ShouldBe(7);
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getSiteItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getSiteItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string[]) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getSiteItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSiteItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getSiteItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetSiteItems, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addTeam) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_addTeam_Static_Method_Call_Internally(Type[] types)
        {
            var methodaddTeamPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodaddTeam, Fixture, methodaddTeamPrametersTypes);
        }

        #endregion

        #region Method Call : (addTeam) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_addTeam_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var properties = CreateType<SPItemEventDataCollection>();
            var dtResources = CreateType<DataTable>();
            var methodaddTeamPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPItemEventDataCollection), typeof(DataTable) };
            object[] parametersOfaddTeam = { li, properties, dtResources };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodaddTeam, methodaddTeamPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfaddTeam);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfaddTeam.ShouldNotBeNull();
            parametersOfaddTeam.Length.ShouldBe(3);
            methodaddTeamPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addTeam) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_addTeam_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var properties = CreateType<SPItemEventDataCollection>();
            var dtResources = CreateType<DataTable>();
            var methodaddTeamPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPItemEventDataCollection), typeof(DataTable) };
            object[] parametersOfaddTeam = { li, properties, dtResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodaddTeam, parametersOfaddTeam, methodaddTeamPrametersTypes);

            // Assert
            parametersOfaddTeam.ShouldNotBeNull();
            parametersOfaddTeam.Length.ShouldBe(3);
            methodaddTeamPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (addTeam) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_addTeam_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodaddTeamPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPItemEventDataCollection), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodaddTeam, Fixture, methodaddTeamPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodaddTeamPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (addTeam) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_addTeam_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddTeamPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPItemEventDataCollection), typeof(DataTable) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodaddTeam, Fixture, methodaddTeamPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddTeamPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addTeam) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_addTeam_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddTeam, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addTeam) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_addTeam_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddTeam, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getItemXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetItemXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getItemXml_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var hshFields = CreateType<Hashtable>();
            var properties = CreateType<SPItemEventDataCollection>();
            var web = CreateType<SPWeb>();
            var dtResources = CreateType<DataTable>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getItemXml(li, hshFields, properties, web, dtResources);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getItemXml_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var hshFields = CreateType<Hashtable>();
            var properties = CreateType<SPItemEventDataCollection>();
            var web = CreateType<SPWeb>();
            var dtResources = CreateType<DataTable>();
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb), typeof(DataTable) };
            object[] parametersOfgetItemXml = { li, hshFields, properties, web, dtResources };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetItemXml, methodgetItemXmlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetItemXml, parametersOfgetItemXml, methodgetItemXmlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetItemXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetItemXml.ShouldNotBeNull();
            parametersOfgetItemXml.Length.ShouldBe(5);
            methodgetItemXmlPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getItemXml_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var hshFields = CreateType<Hashtable>();
            var properties = CreateType<SPItemEventDataCollection>();
            var web = CreateType<SPWeb>();
            var dtResources = CreateType<DataTable>();
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb), typeof(DataTable) };
            object[] parametersOfgetItemXml = { li, hshFields, properties, web, dtResources };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetItemXml, parametersOfgetItemXml, methodgetItemXmlPrametersTypes);

            // Assert
            parametersOfgetItemXml.ShouldNotBeNull();
            parametersOfgetItemXml.Length.ShouldBe(5);
            methodgetItemXmlPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getItemXml_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetItemXmlPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getItemXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb), typeof(DataTable) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetItemXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getItemXml_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetItemXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getItemXml_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetItemXml, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getMenuFromAssembly_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetMenuFromAssemblyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getMenuFromAssembly_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var assembly = CreateType<string>();
            var aclass = CreateType<string>();
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetMenuFromAssembly = { assembly, aclass };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMenuFromAssembly, methodgetMenuFromAssemblyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetMenuFromAssembly, parametersOfgetMenuFromAssembly, methodgetMenuFromAssemblyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetMenuFromAssembly);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetMenuFromAssembly.ShouldNotBeNull();
            parametersOfgetMenuFromAssembly.Length.ShouldBe(2);
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getMenuFromAssembly_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var assembly = CreateType<string>();
            var aclass = CreateType<string>();
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetMenuFromAssembly = { assembly, aclass };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetMenuFromAssembly, parametersOfgetMenuFromAssembly, methodgetMenuFromAssemblyPrametersTypes);

            // Assert
            parametersOfgetMenuFromAssembly.ShouldNotBeNull();
            parametersOfgetMenuFromAssembly.Length.ShouldBe(2);
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getMenuFromAssembly_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getMenuFromAssembly_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getMenuFromAssembly_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMenuFromAssembly, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getMenuFromAssembly_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetMenuFromAssembly, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getFarmSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFarmSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getFarmSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getFarmSetting(setting);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getFarmSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetFarmSetting = { setting };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFarmSetting, methodgetFarmSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetFarmSetting, parametersOfgetFarmSetting, methodgetFarmSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetFarmSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetFarmSetting.ShouldNotBeNull();
            parametersOfgetFarmSetting.Length.ShouldBe(1);
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getFarmSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetFarmSetting = { setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetFarmSetting, parametersOfgetFarmSetting, methodgetFarmSettingPrametersTypes);

            // Assert
            parametersOfgetFarmSetting.ShouldNotBeNull();
            parametersOfgetFarmSetting.Length.ShouldBe(1);
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getFarmSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getFarmSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getFarmSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFarmSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getFarmSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFarmSetting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetFarmSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.setFarmSetting(setting, value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfsetFarmSetting = { setting, value };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, methodsetFarmSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetFarmSetting, parametersOfsetFarmSetting, methodsetFarmSettingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfsetFarmSetting.ShouldNotBeNull();
            parametersOfsetFarmSetting.Length.ShouldBe(2);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetFarmSetting, parametersOfsetFarmSetting, methodsetFarmSettingPrametersTypes));
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfsetFarmSetting = { setting, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, methodsetFarmSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfsetFarmSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetFarmSetting.ShouldNotBeNull();
            parametersOfsetFarmSetting.Length.ShouldBe(2);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfsetFarmSetting = { setting, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetFarmSetting, parametersOfsetFarmSetting, methodsetFarmSettingPrametersTypes);

            // Assert
            parametersOfsetFarmSetting.ShouldNotBeNull();
            parametersOfsetFarmSetting.Length.ShouldBe(2);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setFarmSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getWebAppSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetWebAppSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getWebAppSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getWebAppSetting(gWebApp, setting);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getWebAppSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfgetWebAppSetting = { gWebApp, setting };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetWebAppSetting, methodgetWebAppSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetWebAppSetting, parametersOfgetWebAppSetting, methodgetWebAppSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetWebAppSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetWebAppSetting.ShouldNotBeNull();
            parametersOfgetWebAppSetting.Length.ShouldBe(2);
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getWebAppSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfgetWebAppSetting = { gWebApp, setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetWebAppSetting, parametersOfgetWebAppSetting, methodgetWebAppSettingPrametersTypes);

            // Assert
            parametersOfgetWebAppSetting.ShouldNotBeNull();
            parametersOfgetWebAppSetting.Length.ShouldBe(2);
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getWebAppSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getWebAppSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getWebAppSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetWebAppSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getWebAppSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetWebAppSetting, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_setWebAppSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetWebAppSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetWebAppSetting, Fixture, methodsetWebAppSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setWebAppSetting_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.setWebAppSetting(gWebApp, setting, value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setWebAppSetting_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetWebAppSetting = { gWebApp, setting, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetWebAppSetting, methodsetWebAppSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfsetWebAppSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetWebAppSetting.ShouldNotBeNull();
            parametersOfsetWebAppSetting.Length.ShouldBe(3);
            methodsetWebAppSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setWebAppSetting_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetWebAppSetting = { gWebApp, setting, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetWebAppSetting, parametersOfsetWebAppSetting, methodsetWebAppSettingPrametersTypes);

            // Assert
            parametersOfsetWebAppSetting.ShouldNotBeNull();
            parametersOfsetWebAppSetting.Length.ShouldBe(3);
            methodsetWebAppSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setWebAppSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetWebAppSetting, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setWebAppSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetWebAppSetting, Fixture, methodsetWebAppSettingPrametersTypes);

            // Assert
            methodsetWebAppSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setWebAppSetting_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetWebAppSetting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getListSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetListSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getListSetting(list, setting);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var setting = CreateType<string>();
            var methodgetListSettingPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfgetListSetting = { list, setting };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetListSetting, methodgetListSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetListSetting, parametersOfgetListSetting, methodgetListSettingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetListSetting.ShouldNotBeNull();
            parametersOfgetListSetting.Length.ShouldBe(2);
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetListSetting, parametersOfgetListSetting, methodgetListSettingPrametersTypes));
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var setting = CreateType<string>();
            var methodgetListSettingPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfgetListSetting = { list, setting };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetListSetting, methodgetListSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetListSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetListSetting.ShouldNotBeNull();
            parametersOfgetListSetting.Length.ShouldBe(2);
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var setting = CreateType<string>();
            var methodgetListSettingPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfgetListSetting = { list, setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetListSetting, parametersOfgetListSetting, methodgetListSettingPrametersTypes);

            // Assert
            parametersOfgetListSetting.ShouldNotBeNull();
            parametersOfgetListSetting.Length.ShouldBe(2);
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetListSettingPrametersTypes = new Type[] { typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetListSettingPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetListSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetListSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getListSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetListSetting, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConnectionString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getConnectionString(gWebApp);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConnectionString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfgetConnectionString = { gWebApp };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConnectionString, methodgetConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConnectionString, parametersOfgetConnectionString, methodgetConnectionStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetConnectionString.ShouldNotBeNull();
            parametersOfgetConnectionString.Length.ShouldBe(1);
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfgetConnectionString = { gWebApp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConnectionString, parametersOfgetConnectionString, methodgetConnectionStringPrametersTypes);

            // Assert
            parametersOfgetConnectionString.ShouldNotBeNull();
            parametersOfgetConnectionString.Length.ShouldBe(1);
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConnectionString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetConnectionString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_setConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetConnectionString, Fixture, methodsetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConnectionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var cn = CreateType<string>();
            var sError = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.setConnectionString(gWebApp, cn, out sError);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConnectionString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var cn = CreateType<string>();
            var sError = CreateType<string>();
            var methodsetConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetConnectionString = { gWebApp, cn, sError };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetConnectionString, methodsetConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfsetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetConnectionString.ShouldNotBeNull();
            parametersOfsetConnectionString.Length.ShouldBe(3);
            methodsetConnectionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var cn = CreateType<string>();
            var sError = CreateType<string>();
            var methodsetConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetConnectionString = { gWebApp, cn, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetConnectionString, parametersOfsetConnectionString, methodsetConnectionStringPrametersTypes);

            // Assert
            parametersOfsetConnectionString.ShouldNotBeNull();
            parametersOfsetConnectionString.Length.ShouldBe(3);
            methodsetConnectionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetConnectionString, Fixture, methodsetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodsetConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetConnectionString, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_setConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetConfigSetting, Fixture, methodsetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConfigSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.setConfigSetting(web, setting, value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConfigSetting_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfsetConfigSetting = { web, setting, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetConfigSetting, methodsetConfigSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfsetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetConfigSetting.ShouldNotBeNull();
            parametersOfsetConfigSetting.Length.ShouldBe(3);
            methodsetConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConfigSetting_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfsetConfigSetting = { web, setting, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetConfigSetting, parametersOfsetConfigSetting, methodsetConfigSettingPrametersTypes);

            // Assert
            parametersOfsetConfigSetting.ShouldNotBeNull();
            parametersOfsetConfigSetting.Length.ShouldBe(3);
            methodsetConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetConfigSetting, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodsetConfigSetting, Fixture, methodsetConfigSettingPrametersTypes);

            // Assert
            methodsetConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_setConfigSetting_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetConfigSetting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_iGetLockedWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetLockedWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetLockedWeb, Fixture, methodiGetLockedWebPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetLockedWeb_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetLockedWeb = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetLockedWeb, methodiGetLockedWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfiGetLockedWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetLockedWeb.ShouldNotBeNull();
            parametersOfiGetLockedWeb.Length.ShouldBe(1);
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetLockedWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetLockedWeb = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetLockedWeb, parametersOfiGetLockedWeb, methodiGetLockedWebPrametersTypes);

            // Assert
            parametersOfiGetLockedWeb.ShouldNotBeNull();
            parametersOfiGetLockedWeb.Length.ShouldBe(1);
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetLockedWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetLockedWeb, Fixture, methodiGetLockedWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetLockedWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetLockedWeb, Fixture, methodiGetLockedWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetLockedWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetLockedWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetLockedWeb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetLockedWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getLockedWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetLockedWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockedWeb, Fixture, methodgetLockedWebPrametersTypes);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockedWeb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getLockedWeb(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockedWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetLockedWeb = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockedWeb, parametersOfgetLockedWeb, methodgetLockedWebPrametersTypes);

            // Assert
            parametersOfgetLockedWeb.ShouldNotBeNull();
            parametersOfgetLockedWeb.Length.ShouldBe(1);
            methodgetLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockedWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockedWeb, Fixture, methodgetLockedWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLockedWebPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockedWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockedWeb, Fixture, methodgetLockedWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLockedWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockedWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLockedWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockedWeb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetLockedWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getConfigSetting(web, setting, translateUrl, isRelative);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfgetConfigSetting = { web, setting, translateUrl, isRelative };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, methodgetConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(4);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfgetConfigSetting = { web, setting, translateUrl, isRelative };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);

            // Assert
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(4);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getConfigSetting_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getConfigSetting(web, setting);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetConfigSetting = { web, setting };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, methodgetConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(2);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetConfigSetting = { web, setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);

            // Assert
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(2);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetLockConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var isRelative = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.getLockConfigSetting(web, setting, isRelative);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var isRelative = CreateType<bool>();
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };
            object[] parametersOfgetLockConfigSetting = { web, setting, isRelative };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLockConfigSetting, methodgetLockConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockConfigSetting, parametersOfgetLockConfigSetting, methodgetLockConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfgetLockConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetLockConfigSetting.ShouldNotBeNull();
            parametersOfgetLockConfigSetting.Length.ShouldBe(3);
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var isRelative = CreateType<bool>();
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };
            object[] parametersOfgetLockConfigSetting = { web, setting, isRelative };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockConfigSetting, parametersOfgetLockConfigSetting, methodgetLockConfigSettingPrametersTypes);

            // Assert
            parametersOfgetLockConfigSetting.ShouldNotBeNull();
            parametersOfgetLockConfigSetting.Length.ShouldBe(3);
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLockConfigSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_getLockConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetLockConfigSetting, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_iGetConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetConfigSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfiGetConfigSetting = { web, setting, translateUrl, isRelative };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetConfigSetting, methodiGetConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetConfigSetting, parametersOfiGetConfigSetting, methodiGetConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfiGetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetConfigSetting.ShouldNotBeNull();
            parametersOfiGetConfigSetting.Length.ShouldBe(4);
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetConfigSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfiGetConfigSetting = { web, setting, translateUrl, isRelative };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetConfigSetting, parametersOfiGetConfigSetting, methodiGetConfigSettingPrametersTypes);

            // Assert
            parametersOfiGetConfigSetting.ShouldNotBeNull();
            parametersOfiGetConfigSetting.Length.ShouldBe(4);
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetConfigSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetConfigSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetConfigSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_iGetConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetConfigSetting, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_farmEncode_Static_Method_Call_Internally(Type[] types)
        {
            var methodfarmEncodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_farmEncode_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var code = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.farmEncode(code);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_farmEncode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOffarmEncode = { code };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfarmEncode, methodfarmEncodePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfarmEncode, parametersOffarmEncode, methodfarmEncodePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOffarmEncode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOffarmEncode.ShouldNotBeNull();
            parametersOffarmEncode.Length.ShouldBe(1);
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_farmEncode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOffarmEncode = { code };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfarmEncode, parametersOffarmEncode, methodfarmEncodePrametersTypes);

            // Assert
            parametersOffarmEncode.ShouldNotBeNull();
            parametersOffarmEncode.Length.ShouldBe(1);
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_farmEncode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_farmEncode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodfarmEncodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_farmEncode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfarmEncode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_farmEncode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodfarmEncode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_computerCode_Static_Method_Call_Internally(Type[] types)
        {
            var methodcomputerCodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodcomputerCode, Fixture, methodcomputerCodePrametersTypes);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_computerCode_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var code = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.computerCode(code);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_computerCode_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcomputerCode = { code };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcomputerCode, methodcomputerCodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfcomputerCode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcomputerCode.ShouldNotBeNull();
            parametersOfcomputerCode.Length.ShouldBe(1);
            methodcomputerCodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_computerCode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcomputerCode = { code };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodcomputerCode, parametersOfcomputerCode, methodcomputerCodePrametersTypes);

            // Assert
            parametersOfcomputerCode.ShouldNotBeNull();
            parametersOfcomputerCode.Length.ShouldBe(1);
            methodcomputerCodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_computerCode_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodcomputerCode, Fixture, methodcomputerCodePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodcomputerCodePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_computerCode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodcomputerCode, Fixture, methodcomputerCodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcomputerCodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_computerCode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcomputerCode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_computerCode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcomputerCode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_Encrypt_Static_Method_Call_Internally(Type[] types)
        {
            var methodEncryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var plainText = CreateType<string>();
            var passPhrase = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.Encrypt(plainText, passPhrase);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var plainText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfEncrypt = { plainText, passPhrase };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEncrypt, methodEncryptPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodEncrypt, parametersOfEncrypt, methodEncryptPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfEncrypt.ShouldNotBeNull();
            parametersOfEncrypt.Length.ShouldBe(2);
            methodEncryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodEncrypt, parametersOfEncrypt, methodEncryptPrametersTypes));
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var plainText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfEncrypt = { plainText, passPhrase };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEncrypt, methodEncryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfEncrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEncrypt.ShouldNotBeNull();
            parametersOfEncrypt.Length.ShouldBe(2);
            methodEncryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var plainText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfEncrypt = { plainText, passPhrase };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodEncrypt, parametersOfEncrypt, methodEncryptPrametersTypes);

            // Assert
            parametersOfEncrypt.ShouldNotBeNull();
            parametersOfEncrypt.Length.ShouldBe(2);
            methodEncryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodEncryptPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEncryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEncrypt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Encrypt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEncrypt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_Decrypt_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.Decrypt(cipherText, passPhrase);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDecrypt = { cipherText, passPhrase };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecrypt, methodDecryptPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(2);
            methodDecryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes));
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDecrypt = { cipherText, passPhrase };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecrypt, methodDecryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfDecrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(2);
            methodDecryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDecrypt = { cipherText, passPhrase };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes);

            // Assert
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(2);
            methodDecryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecryptPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_Decrypt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_deleteKey_Static_Method_Call_Internally(Type[] types)
        {
            var methoddeleteKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethoddeleteKey, Fixture, methoddeleteKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_deleteKey_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var key = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.deleteKey(key);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_deleteKey_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methoddeleteKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfdeleteKey = { key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethoddeleteKey, methoddeleteKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfdeleteKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfdeleteKey.ShouldNotBeNull();
            parametersOfdeleteKey.Length.ShouldBe(1);
            methoddeleteKeyPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_deleteKey_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methoddeleteKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfdeleteKey = { key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethoddeleteKey, parametersOfdeleteKey, methoddeleteKeyPrametersTypes);

            // Assert
            parametersOfdeleteKey.ShouldNotBeNull();
            parametersOfdeleteKey.Length.ShouldBe(1);
            methoddeleteKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_deleteKey_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethoddeleteKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_deleteKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methoddeleteKeyPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethoddeleteKey, Fixture, methoddeleteKeyPrametersTypes);

            // Assert
            methoddeleteKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_deleteKey_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethoddeleteKey, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_featureList_Static_Method_Call_Internally(Type[] types)
        {
            var methodfeatureListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_featureList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.featureList();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_featureList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;
            object[] parametersOffeatureList = null; // no parameter present
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfeatureList, methodfeatureListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string[]>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfeatureList, parametersOffeatureList, methodfeatureListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOffeatureList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOffeatureList.ShouldBeNull();
            methodfeatureListPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_featureList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;
            object[] parametersOffeatureList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string[]>(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfeatureList, parametersOffeatureList, methodfeatureListPrametersTypes);

            // Assert
            parametersOffeatureList.ShouldBeNull();
            methodfeatureListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_featureList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodfeatureListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_featureList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodfeatureListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_featureList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfeatureList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_enqueue_Static_Method_Call_Internally(Type[] types)
        {
            var methodenqueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.enqueue(timerjobuid, defaultstatus);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodenqueue, methodenqueuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfenqueue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(2);
            methodenqueuePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_configFunctionsInstanceFixture, _configFunctionsInstanceType, Methodenqueue, parametersOfenqueue, methodenqueuePrametersTypes);

            // Assert
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(2);
            methodenqueuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodenqueue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);

            // Assert
            methodenqueuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodenqueue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ConfigFunctions_enqueue_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodenqueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => ConfigFunctions.enqueue(timerjobuid, defaultstatus, site);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus, site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodenqueue, methodenqueuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_configFunctionsInstanceFixture, parametersOfenqueue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(3);
            methodenqueuePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_configFunctionsInstanceFixture, _configFunctionsInstanceType, Methodenqueue, parametersOfenqueue, methodenqueuePrametersTypes);

            // Assert
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(3);
            methodenqueuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodenqueue, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_configFunctionsInstanceFixture, _configFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);

            // Assert
            methodenqueuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ConfigFunctions_enqueue_Static_Method_Call_Overloading_Of_1_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodenqueue, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_configFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}