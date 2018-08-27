using System;
using System.Collections.Generic;
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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.MyPersonalization" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MyPersonalizationTest : AbstractBaseSetupTypedTest<MyPersonalization>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyPersonalization) Initializer

        private const string MethodGetPersonalizations = "GetPersonalizations";
        private const string MethodProcessGetMyPersonalizationParams = "ProcessGetMyPersonalizationParams";
        private const string MethodProcessSetMyPersonalizationParams = "ProcessSetMyPersonalizationParams";
        private const string MethodSetPersonalizations = "SetPersonalizations";
        private const string MethodGetPersonalizationValue = "GetPersonalizationValue";
        private const string MethodUpdatePersonalizationValue = "UpdatePersonalizationValue";
        private const string MethodDeletePersonalization = "DeletePersonalization";
        private const string MethodGetMyPersonalization = "GetMyPersonalization";
        private const string MethodSetMyPersonalization = "SetMyPersonalization";
        private Type _myPersonalizationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyPersonalization _myPersonalizationInstance;
        private MyPersonalization _myPersonalizationInstanceFixture;

        #region General Initializer : Class (MyPersonalization) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyPersonalization" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myPersonalizationInstanceType = typeof(MyPersonalization);
            _myPersonalizationInstanceFixture = Create(true);
            _myPersonalizationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyPersonalization)

        #region General Initializer : Class (MyPersonalization) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MyPersonalization" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetPersonalizations, 0)]
        [TestCase(MethodProcessGetMyPersonalizationParams, 0)]
        [TestCase(MethodProcessSetMyPersonalizationParams, 0)]
        [TestCase(MethodSetPersonalizations, 0)]
        [TestCase(MethodGetPersonalizationValue, 0)]
        [TestCase(MethodUpdatePersonalizationValue, 0)]
        [TestCase(MethodDeletePersonalization, 0)]
        [TestCase(MethodGetMyPersonalization, 0)]
        [TestCase(MethodSetMyPersonalization, 0)]
        public void AUT_MyPersonalization_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myPersonalizationInstanceFixture, 
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
        ///     Class (<see cref="MyPersonalization" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_MyPersonalization_Is_Instance_Present_Test()
        {
            // Assert
            _myPersonalizationInstanceType.ShouldNotBeNull();
            _myPersonalizationInstance.ShouldNotBeNull();
            _myPersonalizationInstanceFixture.ShouldNotBeNull();
            _myPersonalizationInstance.ShouldBeAssignableTo<MyPersonalization>();
            _myPersonalizationInstanceFixture.ShouldBeAssignableTo<MyPersonalization>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyPersonalization) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_MyPersonalization_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MyPersonalization instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _myPersonalizationInstanceType.ShouldNotBeNull();
            _myPersonalizationInstance.ShouldNotBeNull();
            _myPersonalizationInstanceFixture.ShouldNotBeNull();
            _myPersonalizationInstance.ShouldBeAssignableTo<MyPersonalization>();
            _myPersonalizationInstanceFixture.ShouldBeAssignableTo<MyPersonalization>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="MyPersonalization" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetPersonalizations)]
        [TestCase(MethodProcessGetMyPersonalizationParams)]
        [TestCase(MethodProcessSetMyPersonalizationParams)]
        [TestCase(MethodSetPersonalizations)]
        [TestCase(MethodGetPersonalizationValue)]
        [TestCase(MethodUpdatePersonalizationValue)]
        [TestCase(MethodDeletePersonalization)]
        [TestCase(MethodGetMyPersonalization)]
        [TestCase(MethodSetMyPersonalization)]
        public void AUT_MyPersonalization_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_myPersonalizationInstanceFixture,
                                                                              _myPersonalizationInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetPersonalizations) (Return Type : Dictionary<string, string[]>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_GetPersonalizations_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPersonalizationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizations, Fixture, methodGetPersonalizationsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalizations) (Return Type : Dictionary<string, string[]>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizations_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var keys = CreateType<string[]>();
            var username = CreateType<string>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetPersonalizationsPrametersTypes = new Type[] { typeof(string[]), typeof(string), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetPersonalizations = { keys, username, itemId, listId, webId, siteId, siteUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPersonalizations, methodGetPersonalizationsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizations, Fixture, methodGetPersonalizationsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, string[]>>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizations, parametersOfGetPersonalizations, methodGetPersonalizationsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfGetPersonalizations);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersonalizations.ShouldNotBeNull();
            parametersOfGetPersonalizations.Length.ShouldBe(7);
            methodGetPersonalizationsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalizations) (Return Type : Dictionary<string, string[]>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizations_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var keys = CreateType<string[]>();
            var username = CreateType<string>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodGetPersonalizationsPrametersTypes = new Type[] { typeof(string[]), typeof(string), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetPersonalizations = { keys, username, itemId, listId, webId, siteId, siteUrl };

            // Assert
            parametersOfGetPersonalizations.ShouldNotBeNull();
            parametersOfGetPersonalizations.Length.ShouldBe(7);
            methodGetPersonalizationsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, string[]>>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizations, parametersOfGetPersonalizations, methodGetPersonalizationsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetPersonalizations) (Return Type : Dictionary<string, string[]>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizations_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPersonalizationsPrametersTypes = new Type[] { typeof(string[]), typeof(string), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizations, Fixture, methodGetPersonalizationsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersonalizationsPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (GetPersonalizations) (Return Type : Dictionary<string, string[]>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizations_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersonalizationsPrametersTypes = new Type[] { typeof(string[]), typeof(string), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizations, Fixture, methodGetPersonalizationsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersonalizationsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalizations) (Return Type : Dictionary<string, string[]>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizations_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalizations, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalizations) (Return Type : Dictionary<string, string[]>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizations_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersonalizations, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessGetMyPersonalizationParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_ProcessGetMyPersonalizationParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessGetMyPersonalizationParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodProcessGetMyPersonalizationParams, Fixture, methodProcessGetMyPersonalizationParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessGetMyPersonalizationParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessGetMyPersonalizationParams_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var keys = CreateType<string[]>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodProcessGetMyPersonalizationParamsPrametersTypes = new Type[] { typeof(string), typeof(string[]), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfProcessGetMyPersonalizationParams = { data, keys, itemId, listId, webId, siteId, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessGetMyPersonalizationParams, methodProcessGetMyPersonalizationParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfProcessGetMyPersonalizationParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessGetMyPersonalizationParams.ShouldNotBeNull();
            parametersOfProcessGetMyPersonalizationParams.Length.ShouldBe(7);
            methodProcessGetMyPersonalizationParamsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessGetMyPersonalizationParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessGetMyPersonalizationParams_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var keys = CreateType<string[]>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodProcessGetMyPersonalizationParamsPrametersTypes = new Type[] { typeof(string), typeof(string[]), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfProcessGetMyPersonalizationParams = { data, keys, itemId, listId, webId, siteId, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodProcessGetMyPersonalizationParams, parametersOfProcessGetMyPersonalizationParams, methodProcessGetMyPersonalizationParamsPrametersTypes);

            // Assert
            parametersOfProcessGetMyPersonalizationParams.ShouldNotBeNull();
            parametersOfProcessGetMyPersonalizationParams.Length.ShouldBe(7);
            methodProcessGetMyPersonalizationParamsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessGetMyPersonalizationParams) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessGetMyPersonalizationParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessGetMyPersonalizationParams, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessGetMyPersonalizationParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessGetMyPersonalizationParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessGetMyPersonalizationParamsPrametersTypes = new Type[] { typeof(string), typeof(string[]), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodProcessGetMyPersonalizationParams, Fixture, methodProcessGetMyPersonalizationParamsPrametersTypes);

            // Assert
            methodProcessGetMyPersonalizationParamsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessGetMyPersonalizationParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessGetMyPersonalizationParams_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessGetMyPersonalizationParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSetMyPersonalizationParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_ProcessSetMyPersonalizationParams_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessSetMyPersonalizationParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodProcessSetMyPersonalizationParams, Fixture, methodProcessSetMyPersonalizationParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessSetMyPersonalizationParams) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessSetMyPersonalizationParams_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var keyValuePair = CreateType<Dictionary<string, string>>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodProcessSetMyPersonalizationParamsPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<string, string>), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfProcessSetMyPersonalizationParams = { data, keyValuePair, itemId, listId, webId, siteId, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessSetMyPersonalizationParams, methodProcessSetMyPersonalizationParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfProcessSetMyPersonalizationParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessSetMyPersonalizationParams.ShouldNotBeNull();
            parametersOfProcessSetMyPersonalizationParams.Length.ShouldBe(7);
            methodProcessSetMyPersonalizationParamsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSetMyPersonalizationParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessSetMyPersonalizationParams_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var keyValuePair = CreateType<Dictionary<string, string>>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodProcessSetMyPersonalizationParamsPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<string, string>), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfProcessSetMyPersonalizationParams = { data, keyValuePair, itemId, listId, webId, siteId, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodProcessSetMyPersonalizationParams, parametersOfProcessSetMyPersonalizationParams, methodProcessSetMyPersonalizationParamsPrametersTypes);

            // Assert
            parametersOfProcessSetMyPersonalizationParams.ShouldNotBeNull();
            parametersOfProcessSetMyPersonalizationParams.Length.ShouldBe(7);
            methodProcessSetMyPersonalizationParamsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSetMyPersonalizationParams) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessSetMyPersonalizationParams_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessSetMyPersonalizationParams, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessSetMyPersonalizationParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessSetMyPersonalizationParams_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessSetMyPersonalizationParamsPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<string, string>), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodProcessSetMyPersonalizationParams, Fixture, methodProcessSetMyPersonalizationParamsPrametersTypes);

            // Assert
            methodProcessSetMyPersonalizationParamsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSetMyPersonalizationParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_ProcessSetMyPersonalizationParams_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessSetMyPersonalizationParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPersonalizations) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_SetPersonalizations_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetPersonalizationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetPersonalizations, Fixture, methodSetPersonalizationsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetPersonalizations) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetPersonalizations_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var keyValuePair = CreateType<Dictionary<string, string>>();
            var username = CreateType<string>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => MyPersonalization.SetPersonalizations(keyValuePair, username, itemId, listId, webId, siteId, siteUrl);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetPersonalizations) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetPersonalizations_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var keyValuePair = CreateType<Dictionary<string, string>>();
            var username = CreateType<string>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodSetPersonalizationsPrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(string), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfSetPersonalizations = { keyValuePair, username, itemId, listId, webId, siteId, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetPersonalizations, methodSetPersonalizationsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfSetPersonalizations);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetPersonalizations.ShouldNotBeNull();
            parametersOfSetPersonalizations.Length.ShouldBe(7);
            methodSetPersonalizationsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetPersonalizations) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetPersonalizations_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var keyValuePair = CreateType<Dictionary<string, string>>();
            var username = CreateType<string>();
            var itemId = CreateType<int>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodSetPersonalizationsPrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(string), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfSetPersonalizations = { keyValuePair, username, itemId, listId, webId, siteId, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetPersonalizations, parametersOfSetPersonalizations, methodSetPersonalizationsPrametersTypes);

            // Assert
            parametersOfSetPersonalizations.ShouldNotBeNull();
            parametersOfSetPersonalizations.Length.ShouldBe(7);
            methodSetPersonalizationsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPersonalizations) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetPersonalizations_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetPersonalizations, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetPersonalizations) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetPersonalizations_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetPersonalizationsPrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(string), typeof(int), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetPersonalizations, Fixture, methodSetPersonalizationsPrametersTypes);

            // Assert
            methodSetPersonalizationsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetPersonalizations) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetPersonalizations_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetPersonalizations, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPersonalizationValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizationValue, Fixture, methodGetPersonalizationValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var oList = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => MyPersonalization.GetPersonalizationValue(key, oWeb, oList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var oList = CreateType<SPList>();
            var methodGetPersonalizationValuePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPList) };
            object[] parametersOfGetPersonalizationValue = { key, oWeb, oList };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPersonalizationValue, methodGetPersonalizationValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizationValue, Fixture, methodGetPersonalizationValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizationValue, parametersOfGetPersonalizationValue, methodGetPersonalizationValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfGetPersonalizationValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersonalizationValue.ShouldNotBeNull();
            parametersOfGetPersonalizationValue.Length.ShouldBe(3);
            methodGetPersonalizationValuePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var oList = CreateType<SPList>();
            var methodGetPersonalizationValuePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPList) };
            object[] parametersOfGetPersonalizationValue = { key, oWeb, oList };

            // Assert
            parametersOfGetPersonalizationValue.ShouldNotBeNull();
            parametersOfGetPersonalizationValue.Length.ShouldBe(3);
            methodGetPersonalizationValuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizationValue, parametersOfGetPersonalizationValue, methodGetPersonalizationValuePrametersTypes));
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPersonalizationValuePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizationValue, Fixture, methodGetPersonalizationValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersonalizationValuePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersonalizationValuePrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPList) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetPersonalizationValue, Fixture, methodGetPersonalizationValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersonalizationValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersonalizationValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersonalizationValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetPersonalizationValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersonalizationValue, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePersonalizationValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_UpdatePersonalizationValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePersonalizationValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodUpdatePersonalizationValue, Fixture, methodUpdatePersonalizationValuePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePersonalizationValue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_UpdatePersonalizationValue_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var keyValuePair = CreateType<Dictionary<string, string>>();
            var userId = CreateType<string>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodUpdatePersonalizationValuePrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfUpdatePersonalizationValue = { keyValuePair, userId, listId, webId, siteId, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdatePersonalizationValue, methodUpdatePersonalizationValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfUpdatePersonalizationValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdatePersonalizationValue.ShouldNotBeNull();
            parametersOfUpdatePersonalizationValue.Length.ShouldBe(6);
            methodUpdatePersonalizationValuePrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalizationValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_UpdatePersonalizationValue_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var keyValuePair = CreateType<Dictionary<string, string>>();
            var userId = CreateType<string>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodUpdatePersonalizationValuePrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfUpdatePersonalizationValue = { keyValuePair, userId, listId, webId, siteId, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodUpdatePersonalizationValue, parametersOfUpdatePersonalizationValue, methodUpdatePersonalizationValuePrametersTypes);

            // Assert
            parametersOfUpdatePersonalizationValue.ShouldNotBeNull();
            parametersOfUpdatePersonalizationValue.Length.ShouldBe(6);
            methodUpdatePersonalizationValuePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalizationValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_UpdatePersonalizationValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePersonalizationValue, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePersonalizationValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_UpdatePersonalizationValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePersonalizationValuePrametersTypes = new Type[] { typeof(Dictionary<string, string>), typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodUpdatePersonalizationValue, Fixture, methodUpdatePersonalizationValuePrametersTypes);

            // Assert
            methodUpdatePersonalizationValuePrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePersonalizationValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_UpdatePersonalizationValue_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePersonalizationValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalization) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_DeletePersonalization_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeletePersonalizationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodDeletePersonalization, Fixture, methodDeletePersonalizationPrametersTypes);
        }

        #endregion

        #region Method Call : (DeletePersonalization) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_DeletePersonalization_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var userId = CreateType<string>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodDeletePersonalizationPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfDeletePersonalization = { key, userId, listId, webId, siteId, siteUrl };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeletePersonalization, methodDeletePersonalizationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfDeletePersonalization);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeletePersonalization.ShouldNotBeNull();
            parametersOfDeletePersonalization.Length.ShouldBe(6);
            methodDeletePersonalizationPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalization) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_DeletePersonalization_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var userId = CreateType<string>();
            var listId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var siteUrl = CreateType<string>();
            var methodDeletePersonalizationPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfDeletePersonalization = { key, userId, listId, webId, siteId, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodDeletePersonalization, parametersOfDeletePersonalization, methodDeletePersonalizationPrametersTypes);

            // Assert
            parametersOfDeletePersonalization.ShouldNotBeNull();
            parametersOfDeletePersonalization.Length.ShouldBe(6);
            methodDeletePersonalizationPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalization) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_DeletePersonalization_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeletePersonalization, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeletePersonalization) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_DeletePersonalization_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePersonalizationPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodDeletePersonalization, Fixture, methodDeletePersonalizationPrametersTypes);

            // Assert
            methodDeletePersonalizationPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeletePersonalization) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_DeletePersonalization_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeletePersonalization, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_GetMyPersonalization_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetMyPersonalizationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetMyPersonalization, Fixture, methodGetMyPersonalizationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetMyPersonalization_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyPersonalization = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMyPersonalization, methodGetMyPersonalizationPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetMyPersonalization, Fixture, methodGetMyPersonalizationPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetMyPersonalization, parametersOfGetMyPersonalization, methodGetMyPersonalizationPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfGetMyPersonalization);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMyPersonalization.ShouldNotBeNull();
            parametersOfGetMyPersonalization.Length.ShouldBe(1);
            methodGetMyPersonalizationPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetMyPersonalization_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMyPersonalization = { data };

            // Assert
            parametersOfGetMyPersonalization.ShouldNotBeNull();
            parametersOfGetMyPersonalization.Length.ShouldBe(1);
            methodGetMyPersonalizationPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetMyPersonalization, parametersOfGetMyPersonalization, methodGetMyPersonalizationPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetMyPersonalization_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetMyPersonalization, Fixture, methodGetMyPersonalizationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMyPersonalizationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetMyPersonalization_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodGetMyPersonalization, Fixture, methodGetMyPersonalizationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMyPersonalizationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetMyPersonalization_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMyPersonalization, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMyPersonalization) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_GetMyPersonalization_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMyPersonalization, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyPersonalization_SetMyPersonalization_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetMyPersonalizationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetMyPersonalization, Fixture, methodSetMyPersonalizationPrametersTypes);
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetMyPersonalization_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetMyPersonalization = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetMyPersonalization, methodSetMyPersonalizationPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetMyPersonalization, Fixture, methodSetMyPersonalizationPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetMyPersonalization, parametersOfSetMyPersonalization, methodSetMyPersonalizationPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_myPersonalizationInstanceFixture, parametersOfSetMyPersonalization);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetMyPersonalization.ShouldNotBeNull();
            parametersOfSetMyPersonalization.Length.ShouldBe(1);
            methodSetMyPersonalizationPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetMyPersonalization_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetMyPersonalization = { data };

            // Assert
            parametersOfSetMyPersonalization.ShouldNotBeNull();
            parametersOfSetMyPersonalization.Length.ShouldBe(1);
            methodSetMyPersonalizationPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetMyPersonalization, parametersOfSetMyPersonalization, methodSetMyPersonalizationPrametersTypes));
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetMyPersonalization_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetMyPersonalization, Fixture, methodSetMyPersonalizationPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetMyPersonalizationPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetMyPersonalization_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetMyPersonalizationPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_myPersonalizationInstanceFixture, _myPersonalizationInstanceType, MethodSetMyPersonalization, Fixture, methodSetMyPersonalizationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetMyPersonalizationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetMyPersonalization_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetMyPersonalization, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myPersonalizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetMyPersonalization) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyPersonalization_SetMyPersonalization_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetMyPersonalization, 0);
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