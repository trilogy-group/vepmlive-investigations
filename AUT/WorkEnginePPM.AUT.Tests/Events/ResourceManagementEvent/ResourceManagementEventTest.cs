using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.Events
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Events.ResourceManagementEvent" />)
    ///     and namespace <see cref="WorkEnginePPM.Events"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourceManagementEventTest : AbstractBaseSetupTypedTest<ResourceManagementEvent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourceManagementEvent) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemAdding = "ItemAdding";
        private const string MethodItemDeleting = "ItemDeleting";
        private const string MethodItemUpdating = "ItemUpdating";
        private const string MethodItemUpdated = "ItemUpdated";
        private const string MethodValidateRequest = "ValidateRequest";
        private const string MethodCalculateResourceAvailabilities = "CalculateResourceAvailabilities";
        private const string MethodUpdateUser = "UpdateUser";
        private Type _resourceManagementEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourceManagementEvent _resourceManagementEventInstance;
        private ResourceManagementEvent _resourceManagementEventInstanceFixture;

        #region General Initializer : Class (ResourceManagementEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourceManagementEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourceManagementEventInstanceType = typeof(ResourceManagementEvent);
            _resourceManagementEventInstanceFixture = Create(true);
            _resourceManagementEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourceManagementEvent)

        #region General Initializer : Class (ResourceManagementEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourceManagementEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemAdding, 0)]
        [TestCase(MethodItemDeleting, 0)]
        [TestCase(MethodItemUpdating, 0)]
        [TestCase(MethodItemUpdated, 0)]
        [TestCase(MethodValidateRequest, 0)]
        [TestCase(MethodCalculateResourceAvailabilities, 0)]
        [TestCase(MethodUpdateUser, 0)]
        public void AUT_ResourceManagementEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourceManagementEventInstanceFixture, 
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
        ///     Class (<see cref="ResourceManagementEvent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ResourceManagementEvent_Is_Instance_Present_Test()
        {
            // Assert
            _resourceManagementEventInstanceType.ShouldNotBeNull();
            _resourceManagementEventInstance.ShouldNotBeNull();
            _resourceManagementEventInstanceFixture.ShouldNotBeNull();
            _resourceManagementEventInstance.ShouldBeAssignableTo<ResourceManagementEvent>();
            _resourceManagementEventInstanceFixture.ShouldBeAssignableTo<ResourceManagementEvent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourceManagementEvent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ResourceManagementEvent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResourceManagementEvent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resourceManagementEventInstanceType.ShouldNotBeNull();
            _resourceManagementEventInstance.ShouldNotBeNull();
            _resourceManagementEventInstanceFixture.ShouldNotBeNull();
            _resourceManagementEventInstance.ShouldBeAssignableTo<ResourceManagementEvent>();
            _resourceManagementEventInstanceFixture.ShouldBeAssignableTo<ResourceManagementEvent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ResourceManagementEvent" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodUpdateUser)]
        public void AUT_ResourceManagementEvent_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_resourceManagementEventInstanceFixture,
                                                                              _resourceManagementEventInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ResourceManagementEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemAdding)]
        [TestCase(MethodItemDeleting)]
        [TestCase(MethodItemUpdating)]
        [TestCase(MethodItemUpdated)]
        [TestCase(MethodValidateRequest)]
        [TestCase(MethodCalculateResourceAvailabilities)]
        public void AUT_ResourceManagementEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourceManagementEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceManagementEventInstance.ItemAdded(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceManagementEventInstanceFixture, parametersOfItemAdded);

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
        public void AUT_ResourceManagementEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceManagementEventInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ResourceManagementEvent_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_ItemAdding_Method_Call_Internally(Type[] types)
        {
            var methodItemAddingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemAdding_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceManagementEventInstance.ItemAdding(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemAdding_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdding = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdding, methodItemAddingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceManagementEventInstanceFixture, parametersOfItemAdding);

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
        public void AUT_ResourceManagementEvent_ItemAdding_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdding = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceManagementEventInstance, MethodItemAdding, parametersOfItemAdding, methodItemAddingPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ItemAdding_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ResourceManagementEvent_ItemAdding_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemAdding, Fixture, methodItemAddingPrametersTypes);

            // Assert
            methodItemAddingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdding) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemAdding_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdding, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemDeleting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceManagementEventInstance.ItemDeleting(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleting, methodItemDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceManagementEventInstanceFixture, parametersOfItemDeleting);

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
        public void AUT_ResourceManagementEvent_ItemDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceManagementEventInstance, MethodItemDeleting, parametersOfItemDeleting, methodItemDeletingPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ItemDeleting_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ResourceManagementEvent_ItemDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);

            // Assert
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemUpdating_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceManagementEventInstance.ItemUpdating(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdating, methodItemUpdatingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceManagementEventInstanceFixture, parametersOfItemUpdating);

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
        public void AUT_ResourceManagementEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceManagementEventInstance, MethodItemUpdating, parametersOfItemUpdating, methodItemUpdatingPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ItemUpdating_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ResourceManagementEvent_ItemUpdating_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);

            // Assert
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemUpdating_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdating, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_ItemUpdated_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemUpdated_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourceManagementEventInstance.ItemUpdated(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdated, methodItemUpdatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceManagementEventInstanceFixture, parametersOfItemUpdated);

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
        public void AUT_ResourceManagementEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceManagementEventInstance, MethodItemUpdated, parametersOfItemUpdated, methodItemUpdatedPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ItemUpdated_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ResourceManagementEvent_ItemUpdated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);

            // Assert
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ItemUpdated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_ValidateRequest_Method_Call_Internally(Type[] types)
        {
            var methodValidateRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ValidateRequest_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfValidateRequest = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateRequest, methodValidateRequestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceManagementEvent, bool>(_resourceManagementEventInstanceFixture, out exception1, parametersOfValidateRequest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceManagementEvent, bool>(_resourceManagementEventInstance, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ValidateRequest_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfValidateRequest = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateRequest, methodValidateRequestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourceManagementEvent, bool>(_resourceManagementEventInstanceFixture, out exception1, parametersOfValidateRequest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourceManagementEvent, bool>(_resourceManagementEventInstance, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ValidateRequest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfValidateRequest = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourceManagementEvent, bool>(_resourceManagementEventInstance, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

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
        public void AUT_ResourceManagementEvent_ValidateRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateRequestPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidateRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ValidateRequest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_ValidateRequest_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (CalculateResourceAvailabilities) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_CalculateResourceAvailabilities_Method_Call_Internally(Type[] types)
        {
            var methodCalculateResourceAvailabilitiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodCalculateResourceAvailabilities, Fixture, methodCalculateResourceAvailabilitiesPrametersTypes);
        }

        #endregion

        #region Method Call : (CalculateResourceAvailabilities) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_CalculateResourceAvailabilities_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var pfeResourceId = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodCalculateResourceAvailabilitiesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfCalculateResourceAvailabilities = { pfeResourceId, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCalculateResourceAvailabilities, methodCalculateResourceAvailabilitiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceManagementEventInstanceFixture, parametersOfCalculateResourceAvailabilities);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCalculateResourceAvailabilities.ShouldNotBeNull();
            parametersOfCalculateResourceAvailabilities.Length.ShouldBe(2);
            methodCalculateResourceAvailabilitiesPrametersTypes.Length.ShouldBe(2);
            methodCalculateResourceAvailabilitiesPrametersTypes.Length.ShouldBe(parametersOfCalculateResourceAvailabilities.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateResourceAvailabilities) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_CalculateResourceAvailabilities_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var pfeResourceId = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodCalculateResourceAvailabilitiesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfCalculateResourceAvailabilities = { pfeResourceId, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_resourceManagementEventInstance, MethodCalculateResourceAvailabilities, parametersOfCalculateResourceAvailabilities, methodCalculateResourceAvailabilitiesPrametersTypes);

            // Assert
            parametersOfCalculateResourceAvailabilities.ShouldNotBeNull();
            parametersOfCalculateResourceAvailabilities.Length.ShouldBe(2);
            methodCalculateResourceAvailabilitiesPrametersTypes.Length.ShouldBe(2);
            methodCalculateResourceAvailabilitiesPrametersTypes.Length.ShouldBe(parametersOfCalculateResourceAvailabilities.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateResourceAvailabilities) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_CalculateResourceAvailabilities_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCalculateResourceAvailabilities, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CalculateResourceAvailabilities) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_CalculateResourceAvailabilities_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCalculateResourceAvailabilitiesPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourceManagementEventInstance, MethodCalculateResourceAvailabilities, Fixture, methodCalculateResourceAvailabilitiesPrametersTypes);

            // Assert
            methodCalculateResourceAvailabilitiesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CalculateResourceAvailabilities) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_CalculateResourceAvailabilities_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCalculateResourceAvailabilities, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourceManagementEvent_UpdateUser_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceManagementEventInstanceFixture, _resourceManagementEventInstanceType, MethodUpdateUser, Fixture, methodUpdateUserPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateUser) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_UpdateUser_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => ResourceManagementEvent.UpdateUser(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UpdateUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_UpdateUser_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodUpdateUserPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfUpdateUser = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateUser, methodUpdateUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_resourceManagementEventInstanceFixture, parametersOfUpdateUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateUser.ShouldNotBeNull();
            parametersOfUpdateUser.Length.ShouldBe(1);
            methodUpdateUserPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_UpdateUser_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodUpdateUserPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfUpdateUser = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_resourceManagementEventInstanceFixture, _resourceManagementEventInstanceType, MethodUpdateUser, parametersOfUpdateUser, methodUpdateUserPrametersTypes);

            // Assert
            parametersOfUpdateUser.ShouldNotBeNull();
            parametersOfUpdateUser.Length.ShouldBe(1);
            methodUpdateUserPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUser) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_UpdateUser_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateUser, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_UpdateUser_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateUserPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourceManagementEventInstanceFixture, _resourceManagementEventInstanceType, MethodUpdateUser, Fixture, methodUpdateUserPrametersTypes);

            // Assert
            methodUpdateUserPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourceManagementEvent_UpdateUser_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_resourceManagementEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}