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
using System.Threading.Tasks;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.API;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using WorkspaceEvents = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WorkspaceEvents" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkspaceEventsTest : AbstractBaseSetupTypedTest<WorkspaceEvents>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceEvents) Initializer

        private const string MethodWebDeleting = "WebDeleting";
        private Type _workspaceEventsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkspaceEvents _workspaceEventsInstance;
        private WorkspaceEvents _workspaceEventsInstanceFixture;

        #region General Initializer : Class (WorkspaceEvents) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceEvents" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceEventsInstanceType = typeof(WorkspaceEvents);
            _workspaceEventsInstanceFixture = Create(true);
            _workspaceEventsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceEvents)

        #region General Initializer : Class (WorkspaceEvents) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkspaceEvents" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodWebDeleting, 0)]
        public void AUT_WorkspaceEvents_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workspaceEventsInstanceFixture, 
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
        ///     Class (<see cref="WorkspaceEvents" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkspaceEvents_Is_Instance_Present_Test()
        {
            // Assert
            _workspaceEventsInstanceType.ShouldNotBeNull();
            _workspaceEventsInstance.ShouldNotBeNull();
            _workspaceEventsInstanceFixture.ShouldNotBeNull();
            _workspaceEventsInstance.ShouldBeAssignableTo<WorkspaceEvents>();
            _workspaceEventsInstanceFixture.ShouldBeAssignableTo<WorkspaceEvents>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkspaceEvents) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkspaceEvents_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkspaceEvents instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workspaceEventsInstanceType.ShouldNotBeNull();
            _workspaceEventsInstance.ShouldNotBeNull();
            _workspaceEventsInstanceFixture.ShouldNotBeNull();
            _workspaceEventsInstance.ShouldBeAssignableTo<WorkspaceEvents>();
            _workspaceEventsInstanceFixture.ShouldBeAssignableTo<WorkspaceEvents>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WorkspaceEvents" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodWebDeleting)]
        public void AUT_WorkspaceEvents_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkspaceEvents>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceEvents_WebDeleting_Method_Call_Internally(Type[] types)
        {
            var methodWebDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceEventsInstance, MethodWebDeleting, Fixture, methodWebDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceEvents_WebDeleting_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _workspaceEventsInstance.WebDeleting(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceEvents_WebDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            var methodWebDeletingPrametersTypes = new Type[] { typeof(SPWebEventProperties) };
            object[] parametersOfWebDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebDeleting, methodWebDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workspaceEventsInstanceFixture, parametersOfWebDeleting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebDeleting.ShouldNotBeNull();
            parametersOfWebDeleting.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(parametersOfWebDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceEvents_WebDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            var methodWebDeletingPrametersTypes = new Type[] { typeof(SPWebEventProperties) };
            object[] parametersOfWebDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workspaceEventsInstance, MethodWebDeleting, parametersOfWebDeleting, methodWebDeletingPrametersTypes);

            // Assert
            parametersOfWebDeleting.ShouldNotBeNull();
            parametersOfWebDeleting.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(parametersOfWebDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceEvents_WebDeleting_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWebDeleting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceEvents_WebDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebDeletingPrametersTypes = new Type[] { typeof(SPWebEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceEventsInstance, MethodWebDeleting, Fixture, methodWebDeletingPrametersTypes);

            // Assert
            methodWebDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceEvents_WebDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}