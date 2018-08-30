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
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using WorkEngineActivationInstaller = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.WorkEngineActivationInstaller" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkEngineActivationInstallerTest : AbstractBaseSetupTypedTest<WorkEngineActivationInstaller>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkEngineActivationInstaller) Initializer

        private const string MethodFeatureInstalled = "FeatureInstalled";
        private const string MethodFeatureUninstalling = "FeatureUninstalling";
        private const string MethodFeatureActivated = "FeatureActivated";
        private const string MethodFeatureDeactivating = "FeatureDeactivating";
        private const string FieldTASK_LOGGER_JOB_NAME = "TASK_LOGGER_JOB_NAME";
        private Type _workEngineActivationInstallerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkEngineActivationInstaller _workEngineActivationInstallerInstance;
        private WorkEngineActivationInstaller _workEngineActivationInstallerInstanceFixture;

        #region General Initializer : Class (WorkEngineActivationInstaller) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkEngineActivationInstaller" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workEngineActivationInstallerInstanceType = typeof(WorkEngineActivationInstaller);
            _workEngineActivationInstallerInstanceFixture = Create(true);
            _workEngineActivationInstallerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkEngineActivationInstaller)

        #region General Initializer : Class (WorkEngineActivationInstaller) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkEngineActivationInstaller" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodFeatureInstalled, 0)]
        [TestCase(MethodFeatureUninstalling, 0)]
        [TestCase(MethodFeatureActivated, 0)]
        [TestCase(MethodFeatureDeactivating, 0)]
        public void AUT_WorkEngineActivationInstaller_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workEngineActivationInstallerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkEngineActivationInstaller) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkEngineActivationInstaller" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldTASK_LOGGER_JOB_NAME)]
        public void AUT_WorkEngineActivationInstaller_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workEngineActivationInstallerInstanceFixture, 
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
        ///     Class (<see cref="WorkEngineActivationInstaller" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkEngineActivationInstaller_Is_Instance_Present_Test()
        {
            // Assert
            _workEngineActivationInstallerInstanceType.ShouldNotBeNull();
            _workEngineActivationInstallerInstance.ShouldNotBeNull();
            _workEngineActivationInstallerInstanceFixture.ShouldNotBeNull();
            _workEngineActivationInstallerInstance.ShouldBeAssignableTo<WorkEngineActivationInstaller>();
            _workEngineActivationInstallerInstanceFixture.ShouldBeAssignableTo<WorkEngineActivationInstaller>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkEngineActivationInstaller) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkEngineActivationInstaller_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkEngineActivationInstaller instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workEngineActivationInstallerInstanceType.ShouldNotBeNull();
            _workEngineActivationInstallerInstance.ShouldNotBeNull();
            _workEngineActivationInstallerInstanceFixture.ShouldNotBeNull();
            _workEngineActivationInstallerInstance.ShouldBeAssignableTo<WorkEngineActivationInstaller>();
            _workEngineActivationInstallerInstanceFixture.ShouldBeAssignableTo<WorkEngineActivationInstaller>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WorkEngineActivationInstaller" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFeatureInstalled)]
        [TestCase(MethodFeatureUninstalling)]
        [TestCase(MethodFeatureActivated)]
        [TestCase(MethodFeatureDeactivating)]
        public void AUT_WorkEngineActivationInstaller_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkEngineActivationInstaller>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (FeatureInstalled) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineActivationInstaller_FeatureInstalled_Method_Call_Internally(Type[] types)
        {
            var methodFeatureInstalledPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureInstalled, Fixture, methodFeatureInstalledPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureInstalled) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureInstalled_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _workEngineActivationInstallerInstance.FeatureInstalled(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FeatureInstalled) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureInstalled_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureInstalledPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureInstalled = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureInstalled, methodFeatureInstalledPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineActivationInstallerInstanceFixture, parametersOfFeatureInstalled);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFeatureInstalled.ShouldNotBeNull();
            parametersOfFeatureInstalled.Length.ShouldBe(1);
            methodFeatureInstalledPrametersTypes.Length.ShouldBe(1);
            methodFeatureInstalledPrametersTypes.Length.ShouldBe(parametersOfFeatureInstalled.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureInstalled) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureInstalled_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureInstalledPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureInstalled = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineActivationInstallerInstance, MethodFeatureInstalled, parametersOfFeatureInstalled, methodFeatureInstalledPrametersTypes);

            // Assert
            parametersOfFeatureInstalled.ShouldNotBeNull();
            parametersOfFeatureInstalled.Length.ShouldBe(1);
            methodFeatureInstalledPrametersTypes.Length.ShouldBe(1);
            methodFeatureInstalledPrametersTypes.Length.ShouldBe(parametersOfFeatureInstalled.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureInstalled) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureInstalled_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFeatureInstalled, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FeatureInstalled) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureInstalled_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureInstalledPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureInstalled, Fixture, methodFeatureInstalledPrametersTypes);

            // Assert
            methodFeatureInstalledPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureInstalled) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureInstalled_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureInstalled, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineActivationInstallerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureUninstalling) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineActivationInstaller_FeatureUninstalling_Method_Call_Internally(Type[] types)
        {
            var methodFeatureUninstallingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureUninstalling, Fixture, methodFeatureUninstallingPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureUninstalling) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureUninstalling_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _workEngineActivationInstallerInstance.FeatureUninstalling(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FeatureUninstalling) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureUninstalling_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureUninstallingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureUninstalling = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureUninstalling, methodFeatureUninstallingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineActivationInstallerInstanceFixture, parametersOfFeatureUninstalling);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFeatureUninstalling.ShouldNotBeNull();
            parametersOfFeatureUninstalling.Length.ShouldBe(1);
            methodFeatureUninstallingPrametersTypes.Length.ShouldBe(1);
            methodFeatureUninstallingPrametersTypes.Length.ShouldBe(parametersOfFeatureUninstalling.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureUninstalling) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureUninstalling_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureUninstallingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureUninstalling = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineActivationInstallerInstance, MethodFeatureUninstalling, parametersOfFeatureUninstalling, methodFeatureUninstallingPrametersTypes);

            // Assert
            parametersOfFeatureUninstalling.ShouldNotBeNull();
            parametersOfFeatureUninstalling.Length.ShouldBe(1);
            methodFeatureUninstallingPrametersTypes.Length.ShouldBe(1);
            methodFeatureUninstallingPrametersTypes.Length.ShouldBe(parametersOfFeatureUninstalling.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureUninstalling) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureUninstalling_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFeatureUninstalling, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FeatureUninstalling) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureUninstalling_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureUninstallingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureUninstalling, Fixture, methodFeatureUninstallingPrametersTypes);

            // Assert
            methodFeatureUninstallingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureUninstalling) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureUninstalling_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureUninstalling, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineActivationInstallerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineActivationInstaller_FeatureActivated_Method_Call_Internally(Type[] types)
        {
            var methodFeatureActivatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureActivated_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _workEngineActivationInstallerInstance.FeatureActivated(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureActivated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, methodFeatureActivatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineActivationInstallerInstanceFixture, parametersOfFeatureActivated);

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
        public void AUT_WorkEngineActivationInstaller_FeatureActivated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineActivationInstallerInstance, MethodFeatureActivated, parametersOfFeatureActivated, methodFeatureActivatedPrametersTypes);

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
        public void AUT_WorkEngineActivationInstaller_FeatureActivated_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_WorkEngineActivationInstaller_FeatureActivated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);

            // Assert
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureActivated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineActivationInstallerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineActivationInstaller_FeatureDeactivating_Method_Call_Internally(Type[] types)
        {
            var methodFeatureDeactivatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureDeactivating, Fixture, methodFeatureDeactivatingPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureDeactivating_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _workEngineActivationInstallerInstance.FeatureDeactivating(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureDeactivating_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureDeactivatingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureDeactivating = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureDeactivating, methodFeatureDeactivatingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineActivationInstallerInstanceFixture, parametersOfFeatureDeactivating);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFeatureDeactivating.ShouldNotBeNull();
            parametersOfFeatureDeactivating.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(parametersOfFeatureDeactivating.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureDeactivating_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureDeactivatingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureDeactivating = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineActivationInstallerInstance, MethodFeatureDeactivating, parametersOfFeatureDeactivating, methodFeatureDeactivatingPrametersTypes);

            // Assert
            parametersOfFeatureDeactivating.ShouldNotBeNull();
            parametersOfFeatureDeactivating.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(1);
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(parametersOfFeatureDeactivating.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureDeactivating_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFeatureDeactivating, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureDeactivating_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureDeactivatingPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineActivationInstallerInstance, MethodFeatureDeactivating, Fixture, methodFeatureDeactivatingPrametersTypes);

            // Assert
            methodFeatureDeactivatingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureDeactivating) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkEngineActivationInstaller_FeatureDeactivating_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureDeactivating, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineActivationInstallerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}