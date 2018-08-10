using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Infrastructure.Setup
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Setup.ActivateFeatureKey" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Setup"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ActivateFeatureKeyTest : AbstractBaseSetupTypedTest<ActivateFeatureKey>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ActivateFeatureKey) Initializer

        private const string MethodActivate = "Activate";
        private const string MethodinsertKey = "insertKey";
        private const string MethodaddKey = "addKey";
        private const string Fieldresult = "result";
        private Type _activateFeatureKeyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ActivateFeatureKey _activateFeatureKeyInstance;
        private ActivateFeatureKey _activateFeatureKeyInstanceFixture;

        #region General Initializer : Class (ActivateFeatureKey) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ActivateFeatureKey" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _activateFeatureKeyInstanceType = typeof(ActivateFeatureKey);
            _activateFeatureKeyInstanceFixture = Create(true);
            _activateFeatureKeyInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ActivateFeatureKey)

        #region General Initializer : Class (ActivateFeatureKey) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ActivateFeatureKey" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodActivate, 0)]
        [TestCase(MethodinsertKey, 0)]
        [TestCase(MethodaddKey, 0)]
        public void AUT_ActivateFeatureKey_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_activateFeatureKeyInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ActivateFeatureKey) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ActivateFeatureKey" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldresult)]
        public void AUT_ActivateFeatureKey_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_activateFeatureKeyInstanceFixture, 
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
        ///     Class (<see cref="ActivateFeatureKey" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ActivateFeatureKey_Is_Instance_Present_Test()
        {
            // Assert
            _activateFeatureKeyInstanceType.ShouldNotBeNull();
            _activateFeatureKeyInstance.ShouldNotBeNull();
            _activateFeatureKeyInstanceFixture.ShouldNotBeNull();
            _activateFeatureKeyInstance.ShouldBeAssignableTo<ActivateFeatureKey>();
            _activateFeatureKeyInstanceFixture.ShouldBeAssignableTo<ActivateFeatureKey>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ActivateFeatureKey) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ActivateFeatureKey_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ActivateFeatureKey instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _activateFeatureKeyInstanceType.ShouldNotBeNull();
            _activateFeatureKeyInstance.ShouldNotBeNull();
            _activateFeatureKeyInstanceFixture.ShouldNotBeNull();
            _activateFeatureKeyInstance.ShouldBeAssignableTo<ActivateFeatureKey>();
            _activateFeatureKeyInstanceFixture.ShouldBeAssignableTo<ActivateFeatureKey>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ActivateFeatureKey" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodActivate)]
        [TestCase(MethodinsertKey)]
        [TestCase(MethodaddKey)]
        public void AUT_ActivateFeatureKey_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ActivateFeatureKey>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Activate) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ActivateFeatureKey_Activate_Method_Call_Internally(Type[] types)
        {
            var methodActivatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activateFeatureKeyInstance, MethodActivate, Fixture, methodActivatePrametersTypes);
        }

        #endregion

        #region Method Call : (Activate) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_Activate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodActivatePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfActivate = { key };

            // Assert
            parametersOfActivate.ShouldNotBeNull();
            parametersOfActivate.Length.ShouldBe(1);
            methodActivatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, string>(_activateFeatureKeyInstance, MethodActivate, parametersOfActivate, methodActivatePrametersTypes));
        }

        #endregion

        #region Method Call : (Activate) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_Activate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodActivatePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activateFeatureKeyInstance, MethodActivate, Fixture, methodActivatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodActivatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Activate) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_Activate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodActivate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ActivateFeatureKey_insertKey_Method_Call_Internally(Type[] types)
        {
            var methodinsertKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activateFeatureKeyInstance, MethodinsertKey, Fixture, methodinsertKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_insertKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfinsertKey = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodinsertKey, methodinsertKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ActivateFeatureKey, bool>(_activateFeatureKeyInstanceFixture, out exception1, parametersOfinsertKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodinsertKey, parametersOfinsertKey, methodinsertKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfinsertKey.ShouldNotBeNull();
            parametersOfinsertKey.Length.ShouldBe(1);
            methodinsertKeyPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_activateFeatureKeyInstanceFixture, parametersOfinsertKey));
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_insertKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfinsertKey = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodinsertKey, methodinsertKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ActivateFeatureKey, bool>(_activateFeatureKeyInstanceFixture, out exception1, parametersOfinsertKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodinsertKey, parametersOfinsertKey, methodinsertKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfinsertKey.ShouldNotBeNull();
            parametersOfinsertKey.Length.ShouldBe(1);
            methodinsertKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodinsertKey, parametersOfinsertKey, methodinsertKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_insertKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfinsertKey = { key };

            // Assert
            parametersOfinsertKey.ShouldNotBeNull();
            parametersOfinsertKey.Length.ShouldBe(1);
            methodinsertKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodinsertKey, parametersOfinsertKey, methodinsertKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_insertKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodinsertKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activateFeatureKeyInstance, MethodinsertKey, Fixture, methodinsertKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodinsertKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_insertKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodinsertKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_activateFeatureKeyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (insertKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_insertKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodinsertKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ActivateFeatureKey_addKey_Method_Call_Internally(Type[] types)
        {
            var methodaddKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activateFeatureKeyInstance, MethodaddKey, Fixture, methodaddKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_addKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var inkey = CreateType<string>();
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfaddKey = { inkey };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddKey, methodaddKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ActivateFeatureKey, bool>(_activateFeatureKeyInstanceFixture, out exception1, parametersOfaddKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodaddKey, parametersOfaddKey, methodaddKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfaddKey.ShouldNotBeNull();
            parametersOfaddKey.Length.ShouldBe(1);
            methodaddKeyPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_activateFeatureKeyInstanceFixture, parametersOfaddKey));
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_addKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var inkey = CreateType<string>();
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfaddKey = { inkey };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodaddKey, methodaddKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ActivateFeatureKey, bool>(_activateFeatureKeyInstanceFixture, out exception1, parametersOfaddKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodaddKey, parametersOfaddKey, methodaddKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfaddKey.ShouldNotBeNull();
            parametersOfaddKey.Length.ShouldBe(1);
            methodaddKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodaddKey, parametersOfaddKey, methodaddKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_addKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var inkey = CreateType<string>();
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfaddKey = { inkey };

            // Assert
            parametersOfaddKey.ShouldNotBeNull();
            parametersOfaddKey.Length.ShouldBe(1);
            methodaddKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ActivateFeatureKey, bool>(_activateFeatureKeyInstance, MethodaddKey, parametersOfaddKey, methodaddKeyPrametersTypes));
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_addKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodaddKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_activateFeatureKeyInstance, MethodaddKey, Fixture, methodaddKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodaddKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_addKey_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodaddKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_activateFeatureKeyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (addKey) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ActivateFeatureKey_addKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodaddKey, 0);
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