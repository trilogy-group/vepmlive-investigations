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

namespace WorkEnginePPM.Core.DataSync
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.DataSync.TimeOffManager" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TimeOffManagerTest : AbstractBaseSetupTypedTest<TimeOffManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TimeOffManager) Initializer

        private const string MethodDelete = "Delete";
        private const string MethodSynchronize = "Synchronize";
        private const string MethodGetTimeOff = "GetTimeOff";
        private const string MethodFixIds = "FixIds";
        private const string MethodValidateGetTimeOffResponse = "ValidateGetTimeOffResponse";
        private Type _timeOffManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TimeOffManager _timeOffManagerInstance;
        private TimeOffManager _timeOffManagerInstanceFixture;

        #region General Initializer : Class (TimeOffManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimeOffManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timeOffManagerInstanceType = typeof(TimeOffManager);
            _timeOffManagerInstanceFixture = Create(true);
            _timeOffManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimeOffManager)

        #region General Initializer : Class (TimeOffManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TimeOffManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodSynchronize, 0)]
        [TestCase(MethodGetTimeOff, 0)]
        [TestCase(MethodFixIds, 0)]
        [TestCase(MethodValidateGetTimeOffResponse, 0)]
        public void AUT_TimeOffManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timeOffManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="TimeOffManager" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFixIds)]
        public void AUT_TimeOffManager_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_timeOffManagerInstanceFixture,
                                                                              _timeOffManagerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="TimeOffManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDelete)]
        [TestCase(MethodSynchronize)]
        [TestCase(MethodGetTimeOff)]
        [TestCase(MethodValidateGetTimeOffResponse)]
        public void AUT_TimeOffManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TimeOffManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffManager_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var userId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _timeOffManagerInstance.Delete(id, userId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Delete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var userId = CreateType<int>();
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfDelete = { id, userId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TimeOffManager, bool>(_timeOffManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TimeOffManager, bool>(_timeOffManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Delete_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var userId = CreateType<int>();
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfDelete = { id, userId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TimeOffManager, bool>(_timeOffManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TimeOffManager, bool>(_timeOffManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Delete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<int>();
            var userId = CreateType<int>();
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfDelete = { id, userId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TimeOffManager, bool>(_timeOffManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(2);
            methodDeletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Delete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Delete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelete, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffManager_Synchronize_Method_Call_Internally(Type[] types)
        {
            var methodSynchronizePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Synchronize_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var userId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _timeOffManagerInstance.Synchronize(userId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Synchronize_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userId = CreateType<int>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSynchronize = { userId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSynchronize, methodSynchronizePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffManagerInstanceFixture, parametersOfSynchronize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(parametersOfSynchronize.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Synchronize_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userId = CreateType<int>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfSynchronize = { userId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeOffManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(parametersOfSynchronize.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Synchronize_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Synchronize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_Synchronize_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTimeOff) (Return Type : XElement) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffManager_GetTimeOff_Method_Call_Internally(Type[] types)
        {
            var methodGetTimeOffPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodGetTimeOff, Fixture, methodGetTimeOffPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTimeOff) (Return Type : XElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_GetTimeOff_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var userId = CreateType<int>();
            var methodGetTimeOffPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetTimeOff = { userId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTimeOff, methodGetTimeOffPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<TimeOffManager, XElement>(_timeOffManagerInstanceFixture, out exception1, parametersOfGetTimeOff);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<TimeOffManager, XElement>(_timeOffManagerInstance, MethodGetTimeOff, parametersOfGetTimeOff, methodGetTimeOffPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTimeOff.ShouldNotBeNull();
            parametersOfGetTimeOff.Length.ShouldBe(1);
            methodGetTimeOffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTimeOff) (Return Type : XElement) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_GetTimeOff_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userId = CreateType<int>();
            var methodGetTimeOffPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetTimeOff = { userId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<TimeOffManager, XElement>(_timeOffManagerInstance, MethodGetTimeOff, parametersOfGetTimeOff, methodGetTimeOffPrametersTypes);

            // Assert
            parametersOfGetTimeOff.ShouldNotBeNull();
            parametersOfGetTimeOff.Length.ShouldBe(1);
            methodGetTimeOffPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTimeOff) (Return Type : XElement) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_GetTimeOff_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTimeOffPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodGetTimeOff, Fixture, methodGetTimeOffPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTimeOffPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTimeOff) (Return Type : XElement) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_GetTimeOff_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTimeOffPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodGetTimeOff, Fixture, methodGetTimeOffPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTimeOffPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimeOff) (Return Type : XElement) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_GetTimeOff_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTimeOff, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTimeOff) (Return Type : XElement) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_GetTimeOff_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTimeOff, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FixIds) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffManager_FixIds_Static_Method_Call_Internally(Type[] types)
        {
            var methodFixIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffManagerInstanceFixture, _timeOffManagerInstanceType, MethodFixIds, Fixture, methodFixIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (FixIds) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_FixIds_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xElement = CreateType<XElement>();
            var methodFixIdsPrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfFixIds = { xElement };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFixIds, methodFixIdsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffManagerInstanceFixture, parametersOfFixIds);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFixIds.ShouldNotBeNull();
            parametersOfFixIds.Length.ShouldBe(1);
            methodFixIdsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FixIds) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_FixIds_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xElement = CreateType<XElement>();
            var methodFixIdsPrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfFixIds = { xElement };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_timeOffManagerInstanceFixture, _timeOffManagerInstanceType, MethodFixIds, parametersOfFixIds, methodFixIdsPrametersTypes);

            // Assert
            parametersOfFixIds.ShouldNotBeNull();
            parametersOfFixIds.Length.ShouldBe(1);
            methodFixIdsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FixIds) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_FixIds_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFixIds, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FixIds) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_FixIds_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFixIdsPrametersTypes = new Type[] { typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffManagerInstanceFixture, _timeOffManagerInstanceType, MethodFixIds, Fixture, methodFixIdsPrametersTypes);

            // Assert
            methodFixIdsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FixIds) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_FixIds_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFixIds, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateGetTimeOffResponse) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffManager_ValidateGetTimeOffResponse_Method_Call_Internally(Type[] types)
        {
            var methodValidateGetTimeOffResponsePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodValidateGetTimeOffResponse, Fixture, methodValidateGetTimeOffResponsePrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateGetTimeOffResponse) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_ValidateGetTimeOffResponse_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var resultElement = CreateType<XElement>();
            var methodValidateGetTimeOffResponsePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateGetTimeOffResponse = { resultElement };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateGetTimeOffResponse, methodValidateGetTimeOffResponsePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffManagerInstanceFixture, parametersOfValidateGetTimeOffResponse);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateGetTimeOffResponse.ShouldNotBeNull();
            parametersOfValidateGetTimeOffResponse.Length.ShouldBe(1);
            methodValidateGetTimeOffResponsePrametersTypes.Length.ShouldBe(1);
            methodValidateGetTimeOffResponsePrametersTypes.Length.ShouldBe(parametersOfValidateGetTimeOffResponse.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ValidateGetTimeOffResponse) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_ValidateGetTimeOffResponse_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resultElement = CreateType<XElement>();
            var methodValidateGetTimeOffResponsePrametersTypes = new Type[] { typeof(XElement) };
            object[] parametersOfValidateGetTimeOffResponse = { resultElement };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeOffManagerInstance, MethodValidateGetTimeOffResponse, parametersOfValidateGetTimeOffResponse, methodValidateGetTimeOffResponsePrametersTypes);

            // Assert
            parametersOfValidateGetTimeOffResponse.ShouldNotBeNull();
            parametersOfValidateGetTimeOffResponse.Length.ShouldBe(1);
            methodValidateGetTimeOffResponsePrametersTypes.Length.ShouldBe(1);
            methodValidateGetTimeOffResponsePrametersTypes.Length.ShouldBe(parametersOfValidateGetTimeOffResponse.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateGetTimeOffResponse) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_ValidateGetTimeOffResponse_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateGetTimeOffResponse, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateGetTimeOffResponse) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_ValidateGetTimeOffResponse_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateGetTimeOffResponsePrametersTypes = new Type[] { typeof(XElement) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffManagerInstance, MethodValidateGetTimeOffResponse, Fixture, methodValidateGetTimeOffResponsePrametersTypes);

            // Assert
            methodValidateGetTimeOffResponsePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateGetTimeOffResponse) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffManager_ValidateGetTimeOffResponse_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateGetTimeOffResponse, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}