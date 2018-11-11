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
using DisabledItemEventScope = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.DisabledItemEventScope" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DisabledItemEventScopeTest : AbstractBaseSetupTypedTest<DisabledItemEventScope>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DisabledItemEventScope) Initializer

        private const string MethodDispose = "Dispose";
        private const string Field_oldValue = "_oldValue";
        private Type _disabledItemEventScopeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DisabledItemEventScope _disabledItemEventScopeInstance;
        private DisabledItemEventScope _disabledItemEventScopeInstanceFixture;

        #region General Initializer : Class (DisabledItemEventScope) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DisabledItemEventScope" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _disabledItemEventScopeInstanceType = typeof(DisabledItemEventScope);
            _disabledItemEventScopeInstanceFixture = Create(true);
            _disabledItemEventScopeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DisabledItemEventScope)

        #region General Initializer : Class (DisabledItemEventScope) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DisabledItemEventScope" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodDispose, 0)]
        public void AUT_DisabledItemEventScope_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_disabledItemEventScopeInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DisabledItemEventScope) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DisabledItemEventScope" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_oldValue)]
        public void AUT_DisabledItemEventScope_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_disabledItemEventScopeInstanceFixture, 
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
        ///     Class (<see cref="DisabledItemEventScope" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DisabledItemEventScope_Is_Instance_Present_Test()
        {
            // Assert
            _disabledItemEventScopeInstanceType.ShouldNotBeNull();
            _disabledItemEventScopeInstance.ShouldNotBeNull();
            _disabledItemEventScopeInstanceFixture.ShouldNotBeNull();
            _disabledItemEventScopeInstance.ShouldBeAssignableTo<DisabledItemEventScope>();
            _disabledItemEventScopeInstanceFixture.ShouldBeAssignableTo<DisabledItemEventScope>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DisabledItemEventScope) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DisabledItemEventScope_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DisabledItemEventScope instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _disabledItemEventScopeInstanceType.ShouldNotBeNull();
            _disabledItemEventScopeInstance.ShouldNotBeNull();
            _disabledItemEventScopeInstanceFixture.ShouldNotBeNull();
            _disabledItemEventScopeInstance.ShouldBeAssignableTo<DisabledItemEventScope>();
            _disabledItemEventScopeInstanceFixture.ShouldBeAssignableTo<DisabledItemEventScope>();
        }

        #endregion

        #region General Constructor : Class (DisabledItemEventScope) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DisabledItemEventScope_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var disabledItemEventScopeInstance  = new DisabledItemEventScope();

            // Asserts
            disabledItemEventScopeInstance.ShouldNotBeNull();
            disabledItemEventScopeInstance.ShouldBeAssignableTo<DisabledItemEventScope>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="DisabledItemEventScope" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDispose)]
        public void AUT_DisabledItemEventScope_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DisabledItemEventScope>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DisabledItemEventScope_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_disabledItemEventScopeInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DisabledItemEventScope_Dispose_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _disabledItemEventScopeInstance.Dispose();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DisabledItemEventScope_Dispose_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_disabledItemEventScopeInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DisabledItemEventScope_Dispose_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_disabledItemEventScopeInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DisabledItemEventScope_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_disabledItemEventScopeInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DisabledItemEventScope_Dispose_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_disabledItemEventScopeInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}