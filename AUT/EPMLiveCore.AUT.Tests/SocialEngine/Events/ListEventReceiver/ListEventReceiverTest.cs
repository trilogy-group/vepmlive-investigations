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

namespace EPMLiveCore.SocialEngine.Events.ListEventReceiver
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SocialEngine.Events.ListEventReceiver.ListEventReceiver" />)
    ///     and namespace <see cref="EPMLiveCore.SocialEngine.Events.ListEventReceiver"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ListEventReceiverTest : AbstractBaseSetupTypedTest<ListEventReceiver>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListEventReceiver) Initializer

        private const string MethodListAdded = "ListAdded";
        private const string MethodListDeleting = "ListDeleting";
        private Type _listEventReceiverInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListEventReceiver _listEventReceiverInstance;
        private ListEventReceiver _listEventReceiverInstanceFixture;

        #region General Initializer : Class (ListEventReceiver) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListEventReceiver" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listEventReceiverInstanceType = typeof(ListEventReceiver);
            _listEventReceiverInstanceFixture = Create(true);
            _listEventReceiverInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListEventReceiver)

        #region General Initializer : Class (ListEventReceiver) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ListEventReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodListAdded, 0)]
        [TestCase(MethodListDeleting, 0)]
        public void AUT_ListEventReceiver_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_listEventReceiverInstanceFixture, 
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
        ///     Class (<see cref="ListEventReceiver" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ListEventReceiver_Is_Instance_Present_Test()
        {
            // Assert
            _listEventReceiverInstanceType.ShouldNotBeNull();
            _listEventReceiverInstance.ShouldNotBeNull();
            _listEventReceiverInstanceFixture.ShouldNotBeNull();
            _listEventReceiverInstance.ShouldBeAssignableTo<ListEventReceiver>();
            _listEventReceiverInstanceFixture.ShouldBeAssignableTo<ListEventReceiver>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListEventReceiver) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ListEventReceiver_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListEventReceiver instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listEventReceiverInstanceType.ShouldNotBeNull();
            _listEventReceiverInstance.ShouldNotBeNull();
            _listEventReceiverInstanceFixture.ShouldNotBeNull();
            _listEventReceiverInstance.ShouldBeAssignableTo<ListEventReceiver>();
            _listEventReceiverInstanceFixture.ShouldBeAssignableTo<ListEventReceiver>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ListEventReceiver" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodListAdded)]
        [TestCase(MethodListDeleting)]
        public void AUT_ListEventReceiver_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ListEventReceiver>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ListAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListEventReceiver_ListAdded_Method_Call_Internally(Type[] types)
        {
            var methodListAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listEventReceiverInstance, MethodListAdded, Fixture, methodListAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ListAdded) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListAdded_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPListEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _listEventReceiverInstance.ListAdded(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ListAdded) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPListEventProperties>();
            var methodListAddedPrametersTypes = new Type[] { typeof(SPListEventProperties) };
            object[] parametersOfListAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListAdded, methodListAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listEventReceiverInstanceFixture, parametersOfListAdded);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListAdded.ShouldNotBeNull();
            parametersOfListAdded.Length.ShouldBe(1);
            methodListAddedPrametersTypes.Length.ShouldBe(1);
            methodListAddedPrametersTypes.Length.ShouldBe(parametersOfListAdded.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListAdded) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPListEventProperties>();
            var methodListAddedPrametersTypes = new Type[] { typeof(SPListEventProperties) };
            object[] parametersOfListAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listEventReceiverInstance, MethodListAdded, parametersOfListAdded, methodListAddedPrametersTypes);

            // Assert
            parametersOfListAdded.ShouldNotBeNull();
            parametersOfListAdded.Length.ShouldBe(1);
            methodListAddedPrametersTypes.Length.ShouldBe(1);
            methodListAddedPrametersTypes.Length.ShouldBe(parametersOfListAdded.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListAdded) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListAdded_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListAdded, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListAdded) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListAddedPrametersTypes = new Type[] { typeof(SPListEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listEventReceiverInstance, MethodListAdded, Fixture, methodListAddedPrametersTypes);

            // Assert
            methodListAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ListEventReceiver_ListDeleting_Method_Call_Internally(Type[] types)
        {
            var methodListDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listEventReceiverInstance, MethodListDeleting, Fixture, methodListDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ListDeleting) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListDeleting_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPListEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _listEventReceiverInstance.ListDeleting(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ListDeleting) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPListEventProperties>();
            var methodListDeletingPrametersTypes = new Type[] { typeof(SPListEventProperties) };
            object[] parametersOfListDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListDeleting, methodListDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_listEventReceiverInstanceFixture, parametersOfListDeleting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListDeleting.ShouldNotBeNull();
            parametersOfListDeleting.Length.ShouldBe(1);
            methodListDeletingPrametersTypes.Length.ShouldBe(1);
            methodListDeletingPrametersTypes.Length.ShouldBe(parametersOfListDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListDeleting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPListEventProperties>();
            var methodListDeletingPrametersTypes = new Type[] { typeof(SPListEventProperties) };
            object[] parametersOfListDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_listEventReceiverInstance, MethodListDeleting, parametersOfListDeleting, methodListDeletingPrametersTypes);

            // Assert
            parametersOfListDeleting.ShouldNotBeNull();
            parametersOfListDeleting.Length.ShouldBe(1);
            methodListDeletingPrametersTypes.Length.ShouldBe(1);
            methodListDeletingPrametersTypes.Length.ShouldBe(parametersOfListDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListDeleting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListDeleting_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListDeleting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListDeleting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListDeletingPrametersTypes = new Type[] { typeof(SPListEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_listEventReceiverInstance, MethodListDeleting, Fixture, methodListDeletingPrametersTypes);

            // Assert
            methodListDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ListEventReceiver_ListDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_listEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}