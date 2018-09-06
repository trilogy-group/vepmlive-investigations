using System;
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

namespace WorkEnginePPM.Events.DataSync
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Events.DataSync.TimeOffSyncEvent" />)
    ///     and namespace <see cref="WorkEnginePPM.Events.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TimeOffSyncEventTest : AbstractBaseSetupTypedTest<TimeOffSyncEvent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TimeOffSyncEvent) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemDeleting = "ItemDeleting";
        private const string MethodItemUpdated = "ItemUpdated";
        private const string MethodGetUserId = "GetUserId";
        private const string MethodSetHours = "SetHours";
        private const string MethodSynchronize = "Synchronize";
        private const string MethodValidateRequest = "ValidateRequest";
        private Type _timeOffSyncEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TimeOffSyncEvent _timeOffSyncEventInstance;
        private TimeOffSyncEvent _timeOffSyncEventInstanceFixture;

        #region General Initializer : Class (TimeOffSyncEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimeOffSyncEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timeOffSyncEventInstanceType = typeof(TimeOffSyncEvent);
            _timeOffSyncEventInstanceFixture = Create(true);
            _timeOffSyncEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimeOffSyncEvent)

        #region General Initializer : Class (TimeOffSyncEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TimeOffSyncEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemDeleting, 0)]
        [TestCase(MethodItemUpdated, 0)]
        [TestCase(MethodGetUserId, 0)]
        [TestCase(MethodSetHours, 0)]
        [TestCase(MethodSynchronize, 0)]
        [TestCase(MethodValidateRequest, 0)]
        public void AUT_TimeOffSyncEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timeOffSyncEventInstanceFixture, 
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
        ///     Class (<see cref="TimeOffSyncEvent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TimeOffSyncEvent_Is_Instance_Present_Test()
        {
            // Assert
            _timeOffSyncEventInstanceType.ShouldNotBeNull();
            _timeOffSyncEventInstance.ShouldNotBeNull();
            _timeOffSyncEventInstanceFixture.ShouldNotBeNull();
            _timeOffSyncEventInstance.ShouldBeAssignableTo<TimeOffSyncEvent>();
            _timeOffSyncEventInstanceFixture.ShouldBeAssignableTo<TimeOffSyncEvent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TimeOffSyncEvent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_TimeOffSyncEvent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TimeOffSyncEvent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _timeOffSyncEventInstanceType.ShouldNotBeNull();
            _timeOffSyncEventInstance.ShouldNotBeNull();
            _timeOffSyncEventInstanceFixture.ShouldNotBeNull();
            _timeOffSyncEventInstance.ShouldBeAssignableTo<TimeOffSyncEvent>();
            _timeOffSyncEventInstanceFixture.ShouldBeAssignableTo<TimeOffSyncEvent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="TimeOffSyncEvent" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetUserId)]
        [TestCase(MethodSetHours)]
        [TestCase(MethodSynchronize)]
        [TestCase(MethodValidateRequest)]
        public void AUT_TimeOffSyncEvent_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_timeOffSyncEventInstanceFixture,
                                                                              _timeOffSyncEventInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="TimeOffSyncEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemDeleting)]
        [TestCase(MethodItemUpdated)]
        public void AUT_TimeOffSyncEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TimeOffSyncEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffSyncEvent_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffSyncEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _timeOffSyncEventInstance.ItemAdded(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffSyncEventInstanceFixture, parametersOfItemAdded);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemAdded.ShouldNotBeNull();
            parametersOfItemAdded.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(parametersOfItemAdded.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeOffSyncEventInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

            // Assert
            parametersOfItemAdded.ShouldNotBeNull();
            parametersOfItemAdded.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(parametersOfItemAdded.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffSyncEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffSyncEvent_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffSyncEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemDeleting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _timeOffSyncEventInstance.ItemDeleting(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleting, methodItemDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffSyncEventInstanceFixture, parametersOfItemDeleting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemDeleting.ShouldNotBeNull();
            parametersOfItemDeleting.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(parametersOfItemDeleting.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeOffSyncEventInstance, MethodItemDeleting, parametersOfItemDeleting, methodItemDeletingPrametersTypes);

            // Assert
            parametersOfItemDeleting.ShouldNotBeNull();
            parametersOfItemDeleting.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            methodItemDeletingPrametersTypes.Length.ShouldBe(parametersOfItemDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemDeleting_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffSyncEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);

            // Assert
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffSyncEvent_ItemUpdated_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffSyncEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemUpdated_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _timeOffSyncEventInstance.ItemUpdated(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdated, methodItemUpdatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffSyncEventInstanceFixture, parametersOfItemUpdated);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemUpdated.ShouldNotBeNull();
            parametersOfItemUpdated.Length.ShouldBe(1);
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            methodItemUpdatedPrametersTypes.Length.ShouldBe(parametersOfItemUpdated.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeOffSyncEventInstance, MethodItemUpdated, parametersOfItemUpdated, methodItemUpdatedPrametersTypes);

            // Assert
            parametersOfItemUpdated.ShouldNotBeNull();
            parametersOfItemUpdated.Length.ShouldBe(1);
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            methodItemUpdatedPrametersTypes.Length.ShouldBe(parametersOfItemUpdated.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemUpdated_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemUpdated, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemUpdated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffSyncEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);

            // Assert
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ItemUpdated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffSyncEvent_GetUserId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUserIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodGetUserId, Fixture, methodGetUserIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_GetUserId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodGetUserIdPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfGetUserId = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodGetUserId, parametersOfGetUserId, methodGetUserIdPrametersTypes);

            // Assert
            parametersOfGetUserId.ShouldNotBeNull();
            parametersOfGetUserId.Length.ShouldBe(1);
            methodGetUserIdPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_GetUserId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserIdPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodGetUserId, Fixture, methodGetUserIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserId) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_GetUserId_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserId) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_GetUserId_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserId, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetHours) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffSyncEvent_SetHours_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetHoursPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodSetHours, Fixture, methodSetHoursPrametersTypes);
        }

        #endregion

        #region Method Call : (SetHours) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_SetHours_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodSetHoursPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfSetHours = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetHours, methodSetHoursPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffSyncEventInstanceFixture, parametersOfSetHours);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetHours.ShouldNotBeNull();
            parametersOfSetHours.Length.ShouldBe(1);
            methodSetHoursPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetHours) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_SetHours_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodSetHoursPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfSetHours = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodSetHours, parametersOfSetHours, methodSetHoursPrametersTypes);

            // Assert
            parametersOfSetHours.ShouldNotBeNull();
            parametersOfSetHours.Length.ShouldBe(1);
            methodSetHoursPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetHours) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_SetHours_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetHours, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetHours) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_SetHours_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetHoursPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodSetHours, Fixture, methodSetHoursPrametersTypes);

            // Assert
            methodSetHoursPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetHours) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_SetHours_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetHours, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffSyncEvent_Synchronize_Static_Method_Call_Internally(Type[] types)
        {
            var methodSynchronizePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_Synchronize_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfSynchronize = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSynchronize, methodSynchronizePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeOffSyncEventInstanceFixture, parametersOfSynchronize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_Synchronize_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfSynchronize = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_Synchronize_Static_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_TimeOffSyncEvent_Synchronize_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_Synchronize_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOffSyncEvent_ValidateRequest_Static_Method_Call_Internally(Type[] types)
        {
            var methodValidateRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ValidateRequest_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfValidateRequest = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

            // Assert
            parametersOfValidateRequest.ShouldNotBeNull();
            parametersOfValidateRequest.Length.ShouldBe(1);
            methodValidateRequestPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ValidateRequest_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timeOffSyncEventInstanceFixture, _timeOffSyncEventInstanceType, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidateRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ValidateRequest_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timeOffSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeOffSyncEvent_ValidateRequest_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateRequest, 0);
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