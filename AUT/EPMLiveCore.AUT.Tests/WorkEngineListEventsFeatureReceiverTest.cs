using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using WorkEngineListEventsFeatureReceiver = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WorkEngineListEventsFeatureReceiver" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class WorkEngineListEventsFeatureReceiverTest : AbstractBaseSetupTypedTest<WorkEngineListEventsFeatureReceiver>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkEngineListEventsFeatureReceiver) Initializer

        private const string MethodFeatureActivated = "FeatureActivated";
        private const string MethodPullResourceFromTopSite = "PullResourceFromTopSite";
        private const string MethodAddEventHandlers = "AddEventHandlers";
        private const string MethodAddEventHandlersToLocalResourcesList = "AddEventHandlersToLocalResourcesList";
        private const string MethodGetListEvents = "GetListEvents";
        private const string MethodProcessEventHandlers = "ProcessEventHandlers";
        private const string MethodRegisterAssignToEvent = "RegisterAssignToEvent";
        private const string MethodGetReportingLists = "GetReportingLists";
        private const string MethodListExists = "ListExists";
        private const string MethodInitializeWebpartProperties = "InitializeWebpartProperties";
        private const string Field_listNames = "_listNames";
        private Type _workEngineListEventsFeatureReceiverInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkEngineListEventsFeatureReceiver _workEngineListEventsFeatureReceiverInstance;
        private WorkEngineListEventsFeatureReceiver _workEngineListEventsFeatureReceiverInstanceFixture;

        #region General Initializer : Class (WorkEngineListEventsFeatureReceiver) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkEngineListEventsFeatureReceiver" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workEngineListEventsFeatureReceiverInstanceType = typeof(WorkEngineListEventsFeatureReceiver);
            _workEngineListEventsFeatureReceiverInstanceFixture = Create(true);
            _workEngineListEventsFeatureReceiverInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkEngineListEventsFeatureReceiver)

        #region General Initializer : Class (WorkEngineListEventsFeatureReceiver) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkEngineListEventsFeatureReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodFeatureActivated, 0)]
        [TestCase(MethodPullResourceFromTopSite, 0)]
        [TestCase(MethodAddEventHandlers, 0)]
        [TestCase(MethodAddEventHandlersToLocalResourcesList, 0)]
        [TestCase(MethodGetListEvents, 0)]
        [TestCase(MethodProcessEventHandlers, 0)]
        [TestCase(MethodRegisterAssignToEvent, 0)]
        [TestCase(MethodGetReportingLists, 0)]
        [TestCase(MethodListExists, 0)]
        [TestCase(MethodInitializeWebpartProperties, 0)]
        public void AUT_WorkEngineListEventsFeatureReceiver_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workEngineListEventsFeatureReceiverInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkEngineListEventsFeatureReceiver) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkEngineListEventsFeatureReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_listNames)]
        public void AUT_WorkEngineListEventsFeatureReceiver_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workEngineListEventsFeatureReceiverInstanceFixture, 
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
        ///     Class (<see cref="WorkEngineListEventsFeatureReceiver" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkEngineListEventsFeatureReceiver_Is_Instance_Present_Test()
        {
            // Assert
            _workEngineListEventsFeatureReceiverInstanceType.ShouldNotBeNull();
            _workEngineListEventsFeatureReceiverInstance.ShouldNotBeNull();
            _workEngineListEventsFeatureReceiverInstanceFixture.ShouldNotBeNull();
            _workEngineListEventsFeatureReceiverInstance.ShouldBeAssignableTo<WorkEngineListEventsFeatureReceiver>();
            _workEngineListEventsFeatureReceiverInstanceFixture.ShouldBeAssignableTo<WorkEngineListEventsFeatureReceiver>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkEngineListEventsFeatureReceiver) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkEngineListEventsFeatureReceiver_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkEngineListEventsFeatureReceiver instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workEngineListEventsFeatureReceiverInstanceType.ShouldNotBeNull();
            _workEngineListEventsFeatureReceiverInstance.ShouldNotBeNull();
            _workEngineListEventsFeatureReceiverInstanceFixture.ShouldNotBeNull();
            _workEngineListEventsFeatureReceiverInstance.ShouldBeAssignableTo<WorkEngineListEventsFeatureReceiver>();
            _workEngineListEventsFeatureReceiverInstanceFixture.ShouldBeAssignableTo<WorkEngineListEventsFeatureReceiver>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WorkEngineListEventsFeatureReceiver" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFeatureActivated)]
        [TestCase(MethodPullResourceFromTopSite)]
        [TestCase(MethodAddEventHandlers)]
        [TestCase(MethodAddEventHandlersToLocalResourcesList)]
        [TestCase(MethodGetListEvents)]
        [TestCase(MethodProcessEventHandlers)]
        [TestCase(MethodRegisterAssignToEvent)]
        [TestCase(MethodGetReportingLists)]
        [TestCase(MethodListExists)]
        [TestCase(MethodInitializeWebpartProperties)]
        public void AUT_WorkEngineListEventsFeatureReceiver_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkEngineListEventsFeatureReceiver>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_FeatureActivated_Method_Call_Internally(Type[] types)
        {
            var methodFeatureActivatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_FeatureActivated_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _workEngineListEventsFeatureReceiverInstance.FeatureActivated(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_FeatureActivated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, methodFeatureActivatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfFeatureActivated);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFeatureActivated.ShouldNotBeNull();
            parametersOfFeatureActivated.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(parametersOfFeatureActivated.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_FeatureActivated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineListEventsFeatureReceiverInstance, MethodFeatureActivated, parametersOfFeatureActivated, methodFeatureActivatedPrametersTypes);

            // Assert
            parametersOfFeatureActivated.ShouldNotBeNull();
            parametersOfFeatureActivated.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(parametersOfFeatureActivated.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_FeatureActivated_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFeatureActivated, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_FeatureActivated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);

            // Assert
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_FeatureActivated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullResourceFromTopSite) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_PullResourceFromTopSite_Method_Call_Internally(Type[] types)
        {
            var methodPullResourceFromTopSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodPullResourceFromTopSite, Fixture, methodPullResourceFromTopSitePrametersTypes);
        }

        #endregion

        #region Method Call : (PullResourceFromTopSite) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_PullResourceFromTopSite_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodPullResourceFromTopSitePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfPullResourceFromTopSite = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPullResourceFromTopSite, methodPullResourceFromTopSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfPullResourceFromTopSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPullResourceFromTopSite.ShouldNotBeNull();
            parametersOfPullResourceFromTopSite.Length.ShouldBe(1);
            methodPullResourceFromTopSitePrametersTypes.Length.ShouldBe(1);
            methodPullResourceFromTopSitePrametersTypes.Length.ShouldBe(parametersOfPullResourceFromTopSite.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PullResourceFromTopSite) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_PullResourceFromTopSite_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodPullResourceFromTopSitePrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfPullResourceFromTopSite = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineListEventsFeatureReceiverInstance, MethodPullResourceFromTopSite, parametersOfPullResourceFromTopSite, methodPullResourceFromTopSitePrametersTypes);

            // Assert
            parametersOfPullResourceFromTopSite.ShouldNotBeNull();
            parametersOfPullResourceFromTopSite.Length.ShouldBe(1);
            methodPullResourceFromTopSitePrametersTypes.Length.ShouldBe(1);
            methodPullResourceFromTopSitePrametersTypes.Length.ShouldBe(parametersOfPullResourceFromTopSite.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullResourceFromTopSite) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_PullResourceFromTopSite_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPullResourceFromTopSite, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullResourceFromTopSite) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_PullResourceFromTopSite_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPullResourceFromTopSitePrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodPullResourceFromTopSite, Fixture, methodPullResourceFromTopSitePrametersTypes);

            // Assert
            methodPullResourceFromTopSitePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PullResourceFromTopSite) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_PullResourceFromTopSite_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPullResourceFromTopSite, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlers_Method_Call_Internally(Type[] types)
        {
            var methodAddEventHandlersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodAddEventHandlers, Fixture, methodAddEventHandlersPrametersTypes);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlers_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodAddEventHandlersPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfAddEventHandlers = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddEventHandlers, methodAddEventHandlersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfAddEventHandlers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddEventHandlers.ShouldNotBeNull();
            parametersOfAddEventHandlers.Length.ShouldBe(1);
            methodAddEventHandlersPrametersTypes.Length.ShouldBe(1);
            methodAddEventHandlersPrametersTypes.Length.ShouldBe(parametersOfAddEventHandlers.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlers_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodAddEventHandlersPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfAddEventHandlers = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineListEventsFeatureReceiverInstance, MethodAddEventHandlers, parametersOfAddEventHandlers, methodAddEventHandlersPrametersTypes);

            // Assert
            parametersOfAddEventHandlers.ShouldNotBeNull();
            parametersOfAddEventHandlers.Length.ShouldBe(1);
            methodAddEventHandlersPrametersTypes.Length.ShouldBe(1);
            methodAddEventHandlersPrametersTypes.Length.ShouldBe(parametersOfAddEventHandlers.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddEventHandlers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddEventHandlersPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodAddEventHandlers, Fixture, methodAddEventHandlersPrametersTypes);

            // Assert
            methodAddEventHandlersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlers_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddEventHandlers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlersToLocalResourcesList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlersToLocalResourcesList_Method_Call_Internally(Type[] types)
        {
            var methodAddEventHandlersToLocalResourcesListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodAddEventHandlersToLocalResourcesList, Fixture, methodAddEventHandlersToLocalResourcesListPrametersTypes);
        }

        #endregion

        #region Method Call : (AddEventHandlersToLocalResourcesList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlersToLocalResourcesList_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodAddEventHandlersToLocalResourcesListPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfAddEventHandlersToLocalResourcesList = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddEventHandlersToLocalResourcesList, methodAddEventHandlersToLocalResourcesListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfAddEventHandlersToLocalResourcesList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddEventHandlersToLocalResourcesList.ShouldNotBeNull();
            parametersOfAddEventHandlersToLocalResourcesList.Length.ShouldBe(1);
            methodAddEventHandlersToLocalResourcesListPrametersTypes.Length.ShouldBe(1);
            methodAddEventHandlersToLocalResourcesListPrametersTypes.Length.ShouldBe(parametersOfAddEventHandlersToLocalResourcesList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlersToLocalResourcesList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlersToLocalResourcesList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodAddEventHandlersToLocalResourcesListPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfAddEventHandlersToLocalResourcesList = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineListEventsFeatureReceiverInstance, MethodAddEventHandlersToLocalResourcesList, parametersOfAddEventHandlersToLocalResourcesList, methodAddEventHandlersToLocalResourcesListPrametersTypes);

            // Assert
            parametersOfAddEventHandlersToLocalResourcesList.ShouldNotBeNull();
            parametersOfAddEventHandlersToLocalResourcesList.Length.ShouldBe(1);
            methodAddEventHandlersToLocalResourcesListPrametersTypes.Length.ShouldBe(1);
            methodAddEventHandlersToLocalResourcesListPrametersTypes.Length.ShouldBe(parametersOfAddEventHandlersToLocalResourcesList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlersToLocalResourcesList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlersToLocalResourcesList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddEventHandlersToLocalResourcesList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddEventHandlersToLocalResourcesList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlersToLocalResourcesList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddEventHandlersToLocalResourcesListPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodAddEventHandlersToLocalResourcesList, Fixture, methodAddEventHandlersToLocalResourcesListPrametersTypes);

            // Assert
            methodAddEventHandlersToLocalResourcesListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddEventHandlersToLocalResourcesList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_AddEventHandlersToLocalResourcesList_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddEventHandlersToLocalResourcesList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_GetListEvents_Method_Call_Internally(Type[] types)
        {
            var methodGetListEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetListEvents_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListEvents, methodGetListEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfGetListEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetListEvents_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WorkEngineListEventsFeatureReceiver, List<SPEventReceiverDefinition>>(_workEngineListEventsFeatureReceiverInstance, MethodGetListEvents, parametersOfGetListEvents, methodGetListEventsPrametersTypes);

            // Assert
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetListEvents_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetListEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetListEvents_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : List<SPEventReceiverDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetListEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessEventHandlers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_ProcessEventHandlers_Method_Call_Internally(Type[] types)
        {
            var methodProcessEventHandlersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodProcessEventHandlers, Fixture, methodProcessEventHandlersPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessEventHandlers) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ProcessEventHandlers_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessEventHandlersPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessEventHandlers = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessEventHandlers, methodProcessEventHandlersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfProcessEventHandlers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessEventHandlers.ShouldNotBeNull();
            parametersOfProcessEventHandlers.Length.ShouldBe(1);
            methodProcessEventHandlersPrametersTypes.Length.ShouldBe(1);
            methodProcessEventHandlersPrametersTypes.Length.ShouldBe(parametersOfProcessEventHandlers.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessEventHandlers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ProcessEventHandlers_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodProcessEventHandlersPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfProcessEventHandlers = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineListEventsFeatureReceiverInstance, MethodProcessEventHandlers, parametersOfProcessEventHandlers, methodProcessEventHandlersPrametersTypes);

            // Assert
            parametersOfProcessEventHandlers.ShouldNotBeNull();
            parametersOfProcessEventHandlers.Length.ShouldBe(1);
            methodProcessEventHandlersPrametersTypes.Length.ShouldBe(1);
            methodProcessEventHandlersPrametersTypes.Length.ShouldBe(parametersOfProcessEventHandlers.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessEventHandlers) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ProcessEventHandlers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessEventHandlers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessEventHandlers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ProcessEventHandlers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessEventHandlersPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodProcessEventHandlers, Fixture, methodProcessEventHandlersPrametersTypes);

            // Assert
            methodProcessEventHandlersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessEventHandlers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ProcessEventHandlers_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessEventHandlers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterAssignToEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_RegisterAssignToEvent_Method_Call_Internally(Type[] types)
        {
            var methodRegisterAssignToEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodRegisterAssignToEvent, Fixture, methodRegisterAssignToEventPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterAssignToEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_RegisterAssignToEvent_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodRegisterAssignToEventPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfRegisterAssignToEvent = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterAssignToEvent, methodRegisterAssignToEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfRegisterAssignToEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterAssignToEvent.ShouldNotBeNull();
            parametersOfRegisterAssignToEvent.Length.ShouldBe(1);
            methodRegisterAssignToEventPrametersTypes.Length.ShouldBe(1);
            methodRegisterAssignToEventPrametersTypes.Length.ShouldBe(parametersOfRegisterAssignToEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterAssignToEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_RegisterAssignToEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodRegisterAssignToEventPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfRegisterAssignToEvent = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineListEventsFeatureReceiverInstance, MethodRegisterAssignToEvent, parametersOfRegisterAssignToEvent, methodRegisterAssignToEventPrametersTypes);

            // Assert
            parametersOfRegisterAssignToEvent.ShouldNotBeNull();
            parametersOfRegisterAssignToEvent.Length.ShouldBe(1);
            methodRegisterAssignToEventPrametersTypes.Length.ShouldBe(1);
            methodRegisterAssignToEventPrametersTypes.Length.ShouldBe(parametersOfRegisterAssignToEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterAssignToEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_RegisterAssignToEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterAssignToEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterAssignToEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_RegisterAssignToEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterAssignToEventPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodRegisterAssignToEvent, Fixture, methodRegisterAssignToEventPrametersTypes);

            // Assert
            methodRegisterAssignToEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterAssignToEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_RegisterAssignToEvent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterAssignToEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingLists) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_GetReportingLists_Method_Call_Internally(Type[] types)
        {
            var methodGetReportingListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodGetReportingLists, Fixture, methodGetReportingListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportingLists) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetReportingLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetReportingListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetReportingLists = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReportingLists, methodGetReportingListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkEngineListEventsFeatureReceiver, List<string>>(_workEngineListEventsFeatureReceiverInstanceFixture, out exception1, parametersOfGetReportingLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkEngineListEventsFeatureReceiver, List<string>>(_workEngineListEventsFeatureReceiverInstance, MethodGetReportingLists, parametersOfGetReportingLists, methodGetReportingListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReportingLists.ShouldNotBeNull();
            parametersOfGetReportingLists.Length.ShouldBe(1);
            methodGetReportingListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetReportingLists) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetReportingLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetReportingListsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetReportingLists = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WorkEngineListEventsFeatureReceiver, List<string>>(_workEngineListEventsFeatureReceiverInstance, MethodGetReportingLists, parametersOfGetReportingLists, methodGetReportingListsPrametersTypes);

            // Assert
            parametersOfGetReportingLists.ShouldNotBeNull();
            parametersOfGetReportingLists.Length.ShouldBe(1);
            methodGetReportingListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingLists) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetReportingLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReportingListsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodGetReportingLists, Fixture, methodGetReportingListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportingListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetReportingLists) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetReportingLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportingListsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodGetReportingLists, Fixture, methodGetReportingListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportingListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportingLists) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetReportingLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportingLists) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_GetReportingLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportingLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_Internally(Type[] types)
        {
            var methodListExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodListExists, Fixture, methodListExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listName = CreateType<string>();
            var methodListExistsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfListExists = { web, listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListExists, methodListExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkEngineListEventsFeatureReceiver, bool>(_workEngineListEventsFeatureReceiverInstanceFixture, out exception1, parametersOfListExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkEngineListEventsFeatureReceiver, bool>(_workEngineListEventsFeatureReceiverInstance, MethodListExists, parametersOfListExists, methodListExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListExists.ShouldNotBeNull();
            parametersOfListExists.Length.ShouldBe(2);
            methodListExistsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listName = CreateType<string>();
            var methodListExistsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfListExists = { web, listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodListExists, methodListExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkEngineListEventsFeatureReceiver, bool>(_workEngineListEventsFeatureReceiverInstanceFixture, out exception1, parametersOfListExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkEngineListEventsFeatureReceiver, bool>(_workEngineListEventsFeatureReceiverInstance, MethodListExists, parametersOfListExists, methodListExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfListExists.ShouldNotBeNull();
            parametersOfListExists.Length.ShouldBe(2);
            methodListExistsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listName = CreateType<string>();
            var methodListExistsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfListExists = { web, listName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListExists, methodListExistsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfListExists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListExists.ShouldNotBeNull();
            parametersOfListExists.Length.ShouldBe(2);
            methodListExistsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listName = CreateType<string>();
            var methodListExistsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfListExists = { web, listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WorkEngineListEventsFeatureReceiver, bool>(_workEngineListEventsFeatureReceiverInstance, MethodListExists, parametersOfListExists, methodListExistsPrametersTypes);

            // Assert
            parametersOfListExists.ShouldNotBeNull();
            parametersOfListExists.Length.ShouldBe(2);
            methodListExistsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListExistsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodListExists, Fixture, methodListExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodListExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ListExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_ListExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListExists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeWebpartProperties) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineListEventsFeatureReceiver_InitializeWebpartProperties_Method_Call_Internally(Type[] types)
        {
            var methodInitializeWebpartPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodInitializeWebpartProperties, Fixture, methodInitializeWebpartPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeWebpartProperties) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_InitializeWebpartProperties_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _workEngineListEventsFeatureReceiverInstance.InitializeWebpartProperties(web);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InitializeWebpartProperties) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_InitializeWebpartProperties_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodInitializeWebpartPropertiesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfInitializeWebpartProperties = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeWebpartProperties, methodInitializeWebpartPropertiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineListEventsFeatureReceiverInstanceFixture, parametersOfInitializeWebpartProperties);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeWebpartProperties.ShouldNotBeNull();
            parametersOfInitializeWebpartProperties.Length.ShouldBe(1);
            methodInitializeWebpartPropertiesPrametersTypes.Length.ShouldBe(1);
            methodInitializeWebpartPropertiesPrametersTypes.Length.ShouldBe(parametersOfInitializeWebpartProperties.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWebpartProperties) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_InitializeWebpartProperties_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodInitializeWebpartPropertiesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfInitializeWebpartProperties = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineListEventsFeatureReceiverInstance, MethodInitializeWebpartProperties, parametersOfInitializeWebpartProperties, methodInitializeWebpartPropertiesPrametersTypes);

            // Assert
            parametersOfInitializeWebpartProperties.ShouldNotBeNull();
            parametersOfInitializeWebpartProperties.Length.ShouldBe(1);
            methodInitializeWebpartPropertiesPrametersTypes.Length.ShouldBe(1);
            methodInitializeWebpartPropertiesPrametersTypes.Length.ShouldBe(parametersOfInitializeWebpartProperties.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWebpartProperties) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_InitializeWebpartProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitializeWebpartProperties, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitializeWebpartProperties) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_InitializeWebpartProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializeWebpartPropertiesPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineListEventsFeatureReceiverInstance, MethodInitializeWebpartProperties, Fixture, methodInitializeWebpartPropertiesPrametersTypes);

            // Assert
            methodInitializeWebpartPropertiesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeWebpartProperties) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineListEventsFeatureReceiver_InitializeWebpartProperties_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeWebpartProperties, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineListEventsFeatureReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}