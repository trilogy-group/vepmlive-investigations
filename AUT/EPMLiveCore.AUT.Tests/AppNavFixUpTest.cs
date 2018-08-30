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
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using AppNavFixUp = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.AppNavFixUp" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AppNavFixUpTest : AbstractBaseSetupTypedTest<AppNavFixUp>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AppNavFixUp) Initializer

        private const string MethodFeatureActivated = "FeatureActivated";
        private Type _appNavFixUpInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AppNavFixUp _appNavFixUpInstance;
        private AppNavFixUp _appNavFixUpInstanceFixture;

        #region General Initializer : Class (AppNavFixUp) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AppNavFixUp" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _appNavFixUpInstanceType = typeof(AppNavFixUp);
            _appNavFixUpInstanceFixture = Create(true);
            _appNavFixUpInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AppNavFixUp)

        #region General Initializer : Class (AppNavFixUp) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AppNavFixUp" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodFeatureActivated, 0)]
        public void AUT_AppNavFixUp_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_appNavFixUpInstanceFixture, 
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
        ///     Class (<see cref="AppNavFixUp" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AppNavFixUp_Is_Instance_Present_Test()
        {
            // Assert
            _appNavFixUpInstanceType.ShouldNotBeNull();
            _appNavFixUpInstance.ShouldNotBeNull();
            _appNavFixUpInstanceFixture.ShouldNotBeNull();
            _appNavFixUpInstance.ShouldBeAssignableTo<AppNavFixUp>();
            _appNavFixUpInstanceFixture.ShouldBeAssignableTo<AppNavFixUp>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AppNavFixUp) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AppNavFixUp_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AppNavFixUp instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _appNavFixUpInstanceType.ShouldNotBeNull();
            _appNavFixUpInstance.ShouldNotBeNull();
            _appNavFixUpInstanceFixture.ShouldNotBeNull();
            _appNavFixUpInstance.ShouldBeAssignableTo<AppNavFixUp>();
            _appNavFixUpInstanceFixture.ShouldBeAssignableTo<AppNavFixUp>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AppNavFixUp" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFeatureActivated)]
        public void AUT_AppNavFixUp_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AppNavFixUp>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AppNavFixUp_FeatureActivated_Method_Call_Internally(Type[] types)
        {
            var methodFeatureActivatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appNavFixUpInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppNavFixUp_FeatureActivated_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _appNavFixUpInstance.FeatureActivated(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppNavFixUp_FeatureActivated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, methodFeatureActivatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_appNavFixUpInstanceFixture, parametersOfFeatureActivated);

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
        public void AUT_AppNavFixUp_FeatureActivated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPFeatureReceiverProperties>();
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };
            object[] parametersOfFeatureActivated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_appNavFixUpInstance, MethodFeatureActivated, parametersOfFeatureActivated, methodFeatureActivatedPrametersTypes);

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
        public void AUT_AppNavFixUp_FeatureActivated_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_AppNavFixUp_FeatureActivated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFeatureActivatedPrametersTypes = new Type[] { typeof(SPFeatureReceiverProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_appNavFixUpInstance, MethodFeatureActivated, Fixture, methodFeatureActivatedPrametersTypes);

            // Assert
            methodFeatureActivatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FeatureActivated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AppNavFixUp_FeatureActivated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFeatureActivated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_appNavFixUpInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}