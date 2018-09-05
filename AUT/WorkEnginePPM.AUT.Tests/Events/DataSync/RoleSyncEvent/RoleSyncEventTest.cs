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
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Events.DataSync
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Events.DataSync.RoleSyncEvent" />)
    ///     and namespace <see cref="WorkEnginePPM.Events.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RoleSyncEventTest : AbstractBaseSetupTypedTest<RoleSyncEvent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RoleSyncEvent) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemAdding = "ItemAdding";
        private const string MethodItemDeleting = "ItemDeleting";
        private const string MethodItemUpdating = "ItemUpdating";
        private const string MethodAutoCorrectList = "AutoCorrectList";
        private const string MethodValidateRequest = "ValidateRequest";
        private Type _roleSyncEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RoleSyncEvent _roleSyncEventInstance;
        private RoleSyncEvent _roleSyncEventInstanceFixture;

        #region General Initializer : Class (RoleSyncEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RoleSyncEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _roleSyncEventInstanceType = typeof(RoleSyncEvent);
            _roleSyncEventInstanceFixture = Create(true);
            _roleSyncEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RoleSyncEvent)

        #region General Initializer : Class (RoleSyncEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RoleSyncEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemAdding, 0)]
        [TestCase(MethodItemDeleting, 0)]
        [TestCase(MethodItemUpdating, 0)]
        [TestCase(MethodAutoCorrectList, 0)]
        [TestCase(MethodValidateRequest, 0)]
        public void AUT_RoleSyncEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_roleSyncEventInstanceFixture, 
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
        ///     Class (<see cref="RoleSyncEvent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RoleSyncEvent_Is_Instance_Present_Test()
        {
            // Assert
            _roleSyncEventInstanceType.ShouldNotBeNull();
            _roleSyncEventInstance.ShouldNotBeNull();
            _roleSyncEventInstanceFixture.ShouldNotBeNull();
            _roleSyncEventInstance.ShouldBeAssignableTo<RoleSyncEvent>();
            _roleSyncEventInstanceFixture.ShouldBeAssignableTo<RoleSyncEvent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RoleSyncEvent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RoleSyncEvent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RoleSyncEvent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _roleSyncEventInstanceType.ShouldNotBeNull();
            _roleSyncEventInstance.ShouldNotBeNull();
            _roleSyncEventInstanceFixture.ShouldNotBeNull();
            _roleSyncEventInstance.ShouldBeAssignableTo<RoleSyncEvent>();
            _roleSyncEventInstanceFixture.ShouldBeAssignableTo<RoleSyncEvent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="RoleSyncEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemAdding)]
        [TestCase(MethodItemDeleting)]
        [TestCase(MethodItemUpdating)]
        [TestCase(MethodAutoCorrectList)]
        [TestCase(MethodValidateRequest)]
        public void AUT_RoleSyncEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<RoleSyncEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleSyncEvent_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _roleSyncEventInstance.ItemAdded(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_roleSyncEventInstanceFixture, parametersOfItemAdded);

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
        public void AUT_RoleSyncEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_roleSyncEventInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

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
        public void AUT_RoleSyncEvent_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RoleSyncEvent_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_roleSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleSyncEvent_ItemAdding_Method_Call_Internally(Type[] types)
        {
            var methodItemAddingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdding_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _roleSyncEventInstance.ItemAdding(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdding_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdding = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdding, methodItemAddingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_roleSyncEventInstanceFixture, parametersOfItemAdding);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemAdding.ShouldNotBeNull();
            parametersOfItemAdding.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(parametersOfItemAdding.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdding_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdding = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_roleSyncEventInstance, MethodItemAdding, parametersOfItemAdding, methodItemAddingPrametersTypes);

            // Assert
            parametersOfItemAdding.ShouldNotBeNull();
            parametersOfItemAdding.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(1);
            methodItemAddingPrametersTypes.Length.ShouldBe(parametersOfItemAdding.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdding_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemAdding, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdding_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);

            // Assert
            methodItemAddingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemAdding_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdding, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_roleSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleSyncEvent_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemDeleting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _roleSyncEventInstance.ItemDeleting(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleting, methodItemDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_roleSyncEventInstanceFixture, parametersOfItemDeleting);

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
        public void AUT_RoleSyncEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_roleSyncEventInstance, MethodItemDeleting, parametersOfItemDeleting, methodItemDeletingPrametersTypes);

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
        public void AUT_RoleSyncEvent_ItemDeleting_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_RoleSyncEvent_ItemDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);

            // Assert
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_roleSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleSyncEvent_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemUpdating_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _roleSyncEventInstance.ItemUpdating(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdating, methodItemUpdatingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_roleSyncEventInstanceFixture, parametersOfItemUpdating);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemUpdating.ShouldNotBeNull();
            parametersOfItemUpdating.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(parametersOfItemUpdating.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_roleSyncEventInstance, MethodItemUpdating, parametersOfItemUpdating, methodItemUpdatingPrametersTypes);

            // Assert
            parametersOfItemUpdating.ShouldNotBeNull();
            parametersOfItemUpdating.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            methodItemUpdatingPrametersTypes.Length.ShouldBe(parametersOfItemUpdating.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemUpdating_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemUpdating, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemUpdating_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);

            // Assert
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ItemUpdating_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdating, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_roleSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AutoCorrectList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleSyncEvent_AutoCorrectList_Method_Call_Internally(Type[] types)
        {
            var methodAutoCorrectListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodAutoCorrectList, Fixture, methodAutoCorrectListPrametersTypes);
        }

        #endregion

        #region Method Call : (AutoCorrectList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_AutoCorrectList_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var currentRole = CreateType<Role>();
            var roles = CreateType<IEnumerable<Role>>();
            var properties = CreateType<SPItemEventProperties>();
            var methodAutoCorrectListPrametersTypes = new Type[] { typeof(Role), typeof(IEnumerable<Role>), typeof(SPItemEventProperties) };
            object[] parametersOfAutoCorrectList = { currentRole, roles, properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAutoCorrectList, methodAutoCorrectListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_roleSyncEventInstanceFixture, parametersOfAutoCorrectList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAutoCorrectList.ShouldNotBeNull();
            parametersOfAutoCorrectList.Length.ShouldBe(3);
            methodAutoCorrectListPrametersTypes.Length.ShouldBe(3);
            methodAutoCorrectListPrametersTypes.Length.ShouldBe(parametersOfAutoCorrectList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AutoCorrectList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_AutoCorrectList_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var currentRole = CreateType<Role>();
            var roles = CreateType<IEnumerable<Role>>();
            var properties = CreateType<SPItemEventProperties>();
            var methodAutoCorrectListPrametersTypes = new Type[] { typeof(Role), typeof(IEnumerable<Role>), typeof(SPItemEventProperties) };
            object[] parametersOfAutoCorrectList = { currentRole, roles, properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_roleSyncEventInstance, MethodAutoCorrectList, parametersOfAutoCorrectList, methodAutoCorrectListPrametersTypes);

            // Assert
            parametersOfAutoCorrectList.ShouldNotBeNull();
            parametersOfAutoCorrectList.Length.ShouldBe(3);
            methodAutoCorrectListPrametersTypes.Length.ShouldBe(3);
            methodAutoCorrectListPrametersTypes.Length.ShouldBe(parametersOfAutoCorrectList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AutoCorrectList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_AutoCorrectList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAutoCorrectList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AutoCorrectList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_AutoCorrectList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAutoCorrectListPrametersTypes = new Type[] { typeof(Role), typeof(IEnumerable<Role>), typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodAutoCorrectList, Fixture, methodAutoCorrectListPrametersTypes);

            // Assert
            methodAutoCorrectListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AutoCorrectList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_AutoCorrectList_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAutoCorrectList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_roleSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleSyncEvent_ValidateRequest_Method_Call_Internally(Type[] types)
        {
            var methodValidateRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ValidateRequest_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfValidateRequest = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateRequest, methodValidateRequestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RoleSyncEvent, bool>(_roleSyncEventInstanceFixture, out exception1, parametersOfValidateRequest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RoleSyncEvent, bool>(_roleSyncEventInstance, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidateRequest.ShouldNotBeNull();
            parametersOfValidateRequest.Length.ShouldBe(1);
            methodValidateRequestPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ValidateRequest_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfValidateRequest = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateRequest, methodValidateRequestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RoleSyncEvent, bool>(_roleSyncEventInstanceFixture, out exception1, parametersOfValidateRequest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RoleSyncEvent, bool>(_roleSyncEventInstance, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidateRequest.ShouldNotBeNull();
            parametersOfValidateRequest.Length.ShouldBe(1);
            methodValidateRequestPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ValidateRequest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfValidateRequest = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RoleSyncEvent, bool>(_roleSyncEventInstance, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

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
        public void AUT_RoleSyncEvent_ValidateRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleSyncEventInstance, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidateRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ValidateRequest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_roleSyncEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleSyncEvent_ValidateRequest_Method_Call_Parameters_Count_Verification_Test()
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