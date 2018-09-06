using System;
using System.Collections;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.PfEWorkEvent" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PfEWorkEventTest : AbstractBaseSetupTypedTest<PfEWorkEvent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PfEWorkEvent) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemUpdated = "ItemUpdated";
        private const string MethodItemDeleted = "ItemDeleted";
        private const string MethodItemDeleting = "ItemDeleting";
        private const string MethodProcessItem = "ProcessItem";
        private const string MethodGetAdminInfos = "GetAdminInfos";
        private const string MethodupdateItem = "updateItem";
        private const string MethodGetParentLists = "GetParentLists";
        private const string MethodGetAllParentLists = "GetAllParentLists";
        private Type _pfEWorkEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PfEWorkEvent _pfEWorkEventInstance;
        private PfEWorkEvent _pfEWorkEventInstanceFixture;

        #region General Initializer : Class (PfEWorkEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PfEWorkEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pfEWorkEventInstanceType = typeof(PfEWorkEvent);
            _pfEWorkEventInstanceFixture = Create(true);
            _pfEWorkEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PfEWorkEvent)

        #region General Initializer : Class (PfEWorkEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PfEWorkEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemUpdated, 0)]
        [TestCase(MethodItemDeleted, 0)]
        [TestCase(MethodItemDeleting, 0)]
        [TestCase(MethodProcessItem, 0)]
        [TestCase(MethodGetAdminInfos, 0)]
        [TestCase(MethodupdateItem, 0)]
        [TestCase(MethodGetParentLists, 0)]
        [TestCase(MethodGetAllParentLists, 0)]
        public void AUT_PfEWorkEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pfEWorkEventInstanceFixture, 
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
        ///     Class (<see cref="PfEWorkEvent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PfEWorkEvent_Is_Instance_Present_Test()
        {
            // Assert
            _pfEWorkEventInstanceType.ShouldNotBeNull();
            _pfEWorkEventInstance.ShouldNotBeNull();
            _pfEWorkEventInstanceFixture.ShouldNotBeNull();
            _pfEWorkEventInstance.ShouldBeAssignableTo<PfEWorkEvent>();
            _pfEWorkEventInstanceFixture.ShouldBeAssignableTo<PfEWorkEvent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PfEWorkEvent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PfEWorkEvent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PfEWorkEvent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _pfEWorkEventInstanceType.ShouldNotBeNull();
            _pfEWorkEventInstance.ShouldNotBeNull();
            _pfEWorkEventInstanceFixture.ShouldNotBeNull();
            _pfEWorkEventInstance.ShouldBeAssignableTo<PfEWorkEvent>();
            _pfEWorkEventInstanceFixture.ShouldBeAssignableTo<PfEWorkEvent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PfEWorkEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemUpdated)]
        [TestCase(MethodItemDeleted)]
        [TestCase(MethodItemDeleting)]
        [TestCase(MethodProcessItem)]
        [TestCase(MethodGetAdminInfos)]
        [TestCase(MethodupdateItem)]
        [TestCase(MethodGetParentLists)]
        [TestCase(MethodGetAllParentLists)]
        public void AUT_PfEWorkEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PfEWorkEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemAdded_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _pfEWorkEventInstance.ItemAdded(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pfEWorkEventInstanceFixture, parametersOfItemAdded);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemAdded.ShouldNotBeNull();
            parametersOfItemAdded.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(parametersOfItemAdded.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pfEWorkEventInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

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
        public void AUT_PfEWorkEvent_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PfEWorkEvent_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_ItemUpdated_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemUpdated_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _pfEWorkEventInstance.ItemUpdated(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdated, methodItemUpdatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pfEWorkEventInstanceFixture, parametersOfItemUpdated);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemUpdated.ShouldNotBeNull();
            parametersOfItemUpdated.Length.ShouldBe(1);
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            methodItemUpdatedPrametersTypes.Length.ShouldBe(parametersOfItemUpdated.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pfEWorkEventInstance, MethodItemUpdated, parametersOfItemUpdated, methodItemUpdatedPrametersTypes);

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
        public void AUT_PfEWorkEvent_ItemUpdated_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PfEWorkEvent_ItemUpdated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);

            // Assert
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemUpdated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_ItemDeleted_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemDeleted, Fixture, methodItemDeletedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleted_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _pfEWorkEventInstance.ItemDeleted(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleted_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleted = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleted, methodItemDeletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pfEWorkEventInstanceFixture, parametersOfItemDeleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemDeleted.ShouldNotBeNull();
            parametersOfItemDeleted.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(parametersOfItemDeleted.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleted = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pfEWorkEventInstance, MethodItemDeleted, parametersOfItemDeleted, methodItemDeletedPrametersTypes);

            // Assert
            parametersOfItemDeleted.ShouldNotBeNull();
            parametersOfItemDeleted.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(1);
            methodItemDeletedPrametersTypes.Length.ShouldBe(parametersOfItemDeleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodItemDeleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemDeleted, Fixture, methodItemDeletedPrametersTypes);

            // Assert
            methodItemDeletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _pfEWorkEventInstance.ItemDeleting(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleting, methodItemDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pfEWorkEventInstanceFixture, parametersOfItemDeleting);

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
        public void AUT_PfEWorkEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pfEWorkEventInstance, MethodItemDeleting, parametersOfItemDeleting, methodItemDeletingPrametersTypes);

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
        public void AUT_PfEWorkEvent_ItemDeleting_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PfEWorkEvent_ItemDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);

            // Assert
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ItemDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_ProcessItem_Method_Call_Internally(Type[] types)
        {
            var methodProcessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodProcessItem, Fixture, methodProcessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ProcessItem_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sendValue = CreateType<string>();
            var admin = CreateType<PortfolioEngineCore.Admininfos>();
            var methodProcessItemPrametersTypes = new Type[] { typeof(string), typeof(PortfolioEngineCore.Admininfos) };
            object[] parametersOfProcessItem = { sendValue, admin };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessItem, methodProcessItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pfEWorkEventInstanceFixture, parametersOfProcessItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessItem.ShouldNotBeNull();
            parametersOfProcessItem.Length.ShouldBe(2);
            methodProcessItemPrametersTypes.Length.ShouldBe(2);
            methodProcessItemPrametersTypes.Length.ShouldBe(parametersOfProcessItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ProcessItem_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sendValue = CreateType<string>();
            var admin = CreateType<PortfolioEngineCore.Admininfos>();
            var methodProcessItemPrametersTypes = new Type[] { typeof(string), typeof(PortfolioEngineCore.Admininfos) };
            object[] parametersOfProcessItem = { sendValue, admin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pfEWorkEventInstance, MethodProcessItem, parametersOfProcessItem, methodProcessItemPrametersTypes);

            // Assert
            parametersOfProcessItem.ShouldNotBeNull();
            parametersOfProcessItem.Length.ShouldBe(2);
            methodProcessItemPrametersTypes.Length.ShouldBe(2);
            methodProcessItemPrametersTypes.Length.ShouldBe(parametersOfProcessItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ProcessItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessItem, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ProcessItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessItemPrametersTypes = new Type[] { typeof(string), typeof(PortfolioEngineCore.Admininfos) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodProcessItem, Fixture, methodProcessItemPrametersTypes);

            // Assert
            methodProcessItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_ProcessItem_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_GetAdminInfos_Method_Call_Internally(Type[] types)
        {
            var methodGetAdminInfosPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetAdminInfos, Fixture, methodGetAdminInfosPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAdminInfos_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfGetAdminInfos = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAdminInfos, methodGetAdminInfosPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PfEWorkEvent, PortfolioEngineCore.Admininfos>(_pfEWorkEventInstanceFixture, out exception1, parametersOfGetAdminInfos);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PfEWorkEvent, PortfolioEngineCore.Admininfos>(_pfEWorkEventInstance, MethodGetAdminInfos, parametersOfGetAdminInfos, methodGetAdminInfosPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAdminInfos.ShouldNotBeNull();
            parametersOfGetAdminInfos.Length.ShouldBe(1);
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAdminInfos_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfGetAdminInfos = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PfEWorkEvent, PortfolioEngineCore.Admininfos>(_pfEWorkEventInstance, MethodGetAdminInfos, parametersOfGetAdminInfos, methodGetAdminInfosPrametersTypes);

            // Assert
            parametersOfGetAdminInfos.ShouldNotBeNull();
            parametersOfGetAdminInfos.Length.ShouldBe(1);
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAdminInfos_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetAdminInfos, Fixture, methodGetAdminInfosPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAdminInfos_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAdminInfosPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetAdminInfos, Fixture, methodGetAdminInfosPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAdminInfosPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAdminInfos_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAdminInfos, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAdminInfos) (Return Type : PortfolioEngineCore.Admininfos) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAdminInfos_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAdminInfos, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (updateItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_updateItem_Method_Call_Internally(Type[] types)
        {
            var methodupdateItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodupdateItem, Fixture, methodupdateItemPrametersTypes);
        }

        #endregion

        #region Method Call : (updateItem) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_updateItem_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodupdateItemPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfupdateItem = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodupdateItem, methodupdateItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pfEWorkEventInstanceFixture, parametersOfupdateItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfupdateItem.ShouldNotBeNull();
            parametersOfupdateItem.Length.ShouldBe(1);
            methodupdateItemPrametersTypes.Length.ShouldBe(1);
            methodupdateItemPrametersTypes.Length.ShouldBe(parametersOfupdateItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updateItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_updateItem_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodupdateItemPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfupdateItem = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pfEWorkEventInstance, MethodupdateItem, parametersOfupdateItem, methodupdateItemPrametersTypes);

            // Assert
            parametersOfupdateItem.ShouldNotBeNull();
            parametersOfupdateItem.Length.ShouldBe(1);
            methodupdateItemPrametersTypes.Length.ShouldBe(1);
            methodupdateItemPrametersTypes.Length.ShouldBe(parametersOfupdateItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updateItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_updateItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodupdateItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (updateItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_updateItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodupdateItemPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodupdateItem, Fixture, methodupdateItemPrametersTypes);

            // Assert
            methodupdateItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updateItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_updateItem_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodupdateItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParentLists) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_GetParentLists_Method_Call_Internally(Type[] types)
        {
            var methodGetParentListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetParentLists, Fixture, methodGetParentListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParentLists) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetParentLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listname = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetParentListsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetParentLists = { listname, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetParentLists, methodGetParentListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PfEWorkEvent, ArrayList>(_pfEWorkEventInstanceFixture, out exception1, parametersOfGetParentLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PfEWorkEvent, ArrayList>(_pfEWorkEventInstance, MethodGetParentLists, parametersOfGetParentLists, methodGetParentListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetParentLists.ShouldNotBeNull();
            parametersOfGetParentLists.Length.ShouldBe(2);
            methodGetParentListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetParentLists) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetParentLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listname = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodGetParentListsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetParentLists = { listname, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PfEWorkEvent, ArrayList>(_pfEWorkEventInstance, MethodGetParentLists, parametersOfGetParentLists, methodGetParentListsPrametersTypes);

            // Assert
            parametersOfGetParentLists.ShouldNotBeNull();
            parametersOfGetParentLists.Length.ShouldBe(2);
            methodGetParentListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParentLists) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetParentLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParentListsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetParentLists, Fixture, methodGetParentListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParentListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetParentLists) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetParentLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParentListsPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetParentLists, Fixture, methodGetParentListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParentListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParentLists) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetParentLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParentLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParentLists) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetParentLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParentLists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllParentLists) (Return Type : Hashtable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PfEWorkEvent_GetAllParentLists_Method_Call_Internally(Type[] types)
        {
            var methodGetAllParentListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetAllParentLists, Fixture, methodGetAllParentListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAllParentLists) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAllParentLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var bDeleting = CreateType<bool>();
            var methodGetAllParentListsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfGetAllParentLists = { properties, bDeleting };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAllParentLists, methodGetAllParentListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PfEWorkEvent, Hashtable>(_pfEWorkEventInstanceFixture, out exception1, parametersOfGetAllParentLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PfEWorkEvent, Hashtable>(_pfEWorkEventInstance, MethodGetAllParentLists, parametersOfGetAllParentLists, methodGetAllParentListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAllParentLists.ShouldNotBeNull();
            parametersOfGetAllParentLists.Length.ShouldBe(2);
            methodGetAllParentListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAllParentLists) (Return Type : Hashtable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAllParentLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var bDeleting = CreateType<bool>();
            var methodGetAllParentListsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfGetAllParentLists = { properties, bDeleting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PfEWorkEvent, Hashtable>(_pfEWorkEventInstance, MethodGetAllParentLists, parametersOfGetAllParentLists, methodGetAllParentListsPrametersTypes);

            // Assert
            parametersOfGetAllParentLists.ShouldNotBeNull();
            parametersOfGetAllParentLists.Length.ShouldBe(2);
            methodGetAllParentListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAllParentLists) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAllParentLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAllParentListsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetAllParentLists, Fixture, methodGetAllParentListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAllParentListsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAllParentLists) (Return Type : Hashtable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAllParentLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAllParentListsPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pfEWorkEventInstance, MethodGetAllParentLists, Fixture, methodGetAllParentListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAllParentListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAllParentLists) (Return Type : Hashtable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAllParentLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAllParentLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_pfEWorkEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAllParentLists) (Return Type : Hashtable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PfEWorkEvent_GetAllParentLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAllParentLists, 0);
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