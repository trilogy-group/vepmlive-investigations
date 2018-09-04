using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading;
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
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using AssignedToEvent = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.AssignedToEvent" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AssignedToEventTest : AbstractBaseSetupTypedTest<AssignedToEvent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssignedToEvent) Initializer

        private const string MethodItemUpdating = "ItemUpdating";
        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemUpdated = "ItemUpdated";
        private const string MethodprocessItem = "processItem";
        private const string MethodgetFieldVal = "getFieldVal";
        private const string Methodbw_DoWork = "bw_DoWork";
        private Type _assignedToEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssignedToEvent _assignedToEventInstance;
        private AssignedToEvent _assignedToEventInstanceFixture;

        #region General Initializer : Class (AssignedToEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssignedToEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assignedToEventInstanceType = typeof(AssignedToEvent);
            _assignedToEventInstanceFixture = Create(true);
            _assignedToEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssignedToEvent)

        #region General Initializer : Class (AssignedToEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AssignedToEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodItemUpdating, 0)]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemUpdated, 0)]
        [TestCase(MethodprocessItem, 0)]
        [TestCase(MethodgetFieldVal, 0)]
        [TestCase(Methodbw_DoWork, 0)]
        public void AUT_AssignedToEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_assignedToEventInstanceFixture, 
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
        ///     Class (<see cref="AssignedToEvent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AssignedToEvent_Is_Instance_Present_Test()
        {
            // Assert
            _assignedToEventInstanceType.ShouldNotBeNull();
            _assignedToEventInstance.ShouldNotBeNull();
            _assignedToEventInstanceFixture.ShouldNotBeNull();
            _assignedToEventInstance.ShouldBeAssignableTo<AssignedToEvent>();
            _assignedToEventInstanceFixture.ShouldBeAssignableTo<AssignedToEvent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AssignedToEvent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AssignedToEvent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AssignedToEvent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _assignedToEventInstanceType.ShouldNotBeNull();
            _assignedToEventInstance.ShouldNotBeNull();
            _assignedToEventInstanceFixture.ShouldNotBeNull();
            _assignedToEventInstance.ShouldBeAssignableTo<AssignedToEvent>();
            _assignedToEventInstanceFixture.ShouldBeAssignableTo<AssignedToEvent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AssignedToEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodItemUpdating)]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemUpdated)]
        [TestCase(MethodprocessItem)]
        [TestCase(MethodgetFieldVal)]
        [TestCase(Methodbw_DoWork)]
        public void AUT_AssignedToEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AssignedToEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignedToEvent_ItemUpdating_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdating_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _assignedToEventInstance.ItemUpdating(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdating, methodItemUpdatingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignedToEventInstanceFixture, parametersOfItemUpdating);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdating_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdating = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignedToEventInstance, MethodItemUpdating, parametersOfItemUpdating, methodItemUpdatingPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdating_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdating_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodItemUpdating, Fixture, methodItemUpdatingPrametersTypes);

            // Assert
            methodItemUpdatingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdating) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdating_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdating, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignedToEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignedToEvent_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _assignedToEventInstance.ItemAdded(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignedToEventInstanceFixture, parametersOfItemAdded);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignedToEventInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignedToEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignedToEvent_ItemUpdated_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdated_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _assignedToEventInstance.ItemUpdated(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdated, methodItemUpdatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignedToEventInstanceFixture, parametersOfItemUpdated);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignedToEventInstance, MethodItemUpdated, parametersOfItemUpdated, methodItemUpdatedPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdated_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);

            // Assert
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_ItemUpdated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignedToEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignedToEvent_processItem_Method_Call_Internally(Type[] types)
        {
            var methodprocessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_processItem_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfprocessItem = { properties, isAdd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodprocessItem, methodprocessItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignedToEventInstanceFixture, parametersOfprocessItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_processItem_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<bool>();
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };
            object[] parametersOfprocessItem = { properties, isAdd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignedToEventInstance, MethodprocessItem, parametersOfprocessItem, methodprocessItemPrametersTypes);

            // Assert
            parametersOfprocessItem.ShouldNotBeNull();
            parametersOfprocessItem.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(2);
            methodprocessItemPrametersTypes.Length.ShouldBe(parametersOfprocessItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_processItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_processItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodprocessItemPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodprocessItem, Fixture, methodprocessItemPrametersTypes);

            // Assert
            methodprocessItemPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (processItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_processItem_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodprocessItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignedToEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldVal) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignedToEvent_getFieldVal_Method_Call_Internally(Type[] types)
        {
            var methodgetFieldValPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodgetFieldVal, Fixture, methodgetFieldValPrametersTypes);
        }

        #endregion

        #region Method Call : (getFieldVal) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_getFieldVal_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<string>();
            var properties = CreateType<SPItemEventProperties>();
            var list = CreateType<SPList>();
            var methodgetFieldValPrametersTypes = new Type[] { typeof(string), typeof(SPItemEventProperties), typeof(SPList) };
            object[] parametersOfgetFieldVal = { field, properties, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetFieldVal, methodgetFieldValPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignedToEventInstanceFixture, parametersOfgetFieldVal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFieldVal.ShouldNotBeNull();
            parametersOfgetFieldVal.Length.ShouldBe(3);
            methodgetFieldValPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldVal) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_getFieldVal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<string>();
            var properties = CreateType<SPItemEventProperties>();
            var list = CreateType<SPList>();
            var methodgetFieldValPrametersTypes = new Type[] { typeof(string), typeof(SPItemEventProperties), typeof(SPList) };
            object[] parametersOfgetFieldVal = { field, properties, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AssignedToEvent, string>(_assignedToEventInstance, MethodgetFieldVal, parametersOfgetFieldVal, methodgetFieldValPrametersTypes);

            // Assert
            parametersOfgetFieldVal.ShouldNotBeNull();
            parametersOfgetFieldVal.Length.ShouldBe(3);
            methodgetFieldValPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFieldVal) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_getFieldVal_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFieldValPrametersTypes = new Type[] { typeof(string), typeof(SPItemEventProperties), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodgetFieldVal, Fixture, methodgetFieldValPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFieldValPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getFieldVal) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_getFieldVal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFieldValPrametersTypes = new Type[] { typeof(string), typeof(SPItemEventProperties), typeof(SPList) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, MethodgetFieldVal, Fixture, methodgetFieldValPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFieldValPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFieldVal) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_getFieldVal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFieldVal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_assignedToEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFieldVal) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_getFieldVal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFieldVal, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (bw_DoWork) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AssignedToEvent_bw_DoWork_Method_Call_Internally(Type[] types)
        {
            var methodbw_DoWorkPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, Methodbw_DoWork, Fixture, methodbw_DoWorkPrametersTypes);
        }

        #endregion

        #region Method Call : (bw_DoWork) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_bw_DoWork_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<DoWorkEventArgs>();
            var methodbw_DoWorkPrametersTypes = new Type[] { typeof(object), typeof(DoWorkEventArgs) };
            object[] parametersOfbw_DoWork = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodbw_DoWork, methodbw_DoWorkPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_assignedToEventInstanceFixture, parametersOfbw_DoWork);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbw_DoWork.ShouldNotBeNull();
            parametersOfbw_DoWork.Length.ShouldBe(2);
            methodbw_DoWorkPrametersTypes.Length.ShouldBe(2);
            methodbw_DoWorkPrametersTypes.Length.ShouldBe(parametersOfbw_DoWork.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (bw_DoWork) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_bw_DoWork_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<DoWorkEventArgs>();
            var methodbw_DoWorkPrametersTypes = new Type[] { typeof(object), typeof(DoWorkEventArgs) };
            object[] parametersOfbw_DoWork = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_assignedToEventInstance, Methodbw_DoWork, parametersOfbw_DoWork, methodbw_DoWorkPrametersTypes);

            // Assert
            parametersOfbw_DoWork.ShouldNotBeNull();
            parametersOfbw_DoWork.Length.ShouldBe(2);
            methodbw_DoWorkPrametersTypes.Length.ShouldBe(2);
            methodbw_DoWorkPrametersTypes.Length.ShouldBe(parametersOfbw_DoWork.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bw_DoWork) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_bw_DoWork_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodbw_DoWork, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (bw_DoWork) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_bw_DoWork_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbw_DoWorkPrametersTypes = new Type[] { typeof(object), typeof(DoWorkEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_assignedToEventInstance, Methodbw_DoWork, Fixture, methodbw_DoWorkPrametersTypes);

            // Assert
            methodbw_DoWorkPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bw_DoWork) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_AssignedToEvent_bw_DoWork_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodbw_DoWork, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_assignedToEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}