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
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ItemSecurityEventReceiver = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ItemSecurityEventReceiver" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ItemSecurityEventReceiverTest : AbstractBaseSetupTypedTest<ItemSecurityEventReceiver>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemSecurityEventReceiver) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemUpdated = "ItemUpdated";
        private const string MethodAddTimerJob = "AddTimerJob";
        private const string MethodGetSafeGroupTitle = "GetSafeGroupTitle";
        private const string MethodItemDeleting = "ItemDeleting";
        private Type _itemSecurityEventReceiverInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemSecurityEventReceiver _itemSecurityEventReceiverInstance;
        private ItemSecurityEventReceiver _itemSecurityEventReceiverInstanceFixture;

        #region General Initializer : Class (ItemSecurityEventReceiver) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemSecurityEventReceiver" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemSecurityEventReceiverInstanceType = typeof(ItemSecurityEventReceiver);
            _itemSecurityEventReceiverInstanceFixture = Create(true);
            _itemSecurityEventReceiverInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemSecurityEventReceiver)

        #region General Initializer : Class (ItemSecurityEventReceiver) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ItemSecurityEventReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemUpdated, 0)]
        [TestCase(MethodAddTimerJob, 0)]
        [TestCase(MethodGetSafeGroupTitle, 0)]
        [TestCase(MethodItemDeleting, 0)]
        public void AUT_ItemSecurityEventReceiver_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_itemSecurityEventReceiverInstanceFixture, 
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
        ///     Class (<see cref="ItemSecurityEventReceiver" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ItemSecurityEventReceiver_Is_Instance_Present_Test()
        {
            // Assert
            _itemSecurityEventReceiverInstanceType.ShouldNotBeNull();
            _itemSecurityEventReceiverInstance.ShouldNotBeNull();
            _itemSecurityEventReceiverInstanceFixture.ShouldNotBeNull();
            _itemSecurityEventReceiverInstance.ShouldBeAssignableTo<ItemSecurityEventReceiver>();
            _itemSecurityEventReceiverInstanceFixture.ShouldBeAssignableTo<ItemSecurityEventReceiver>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemSecurityEventReceiver) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ItemSecurityEventReceiver_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemSecurityEventReceiver instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemSecurityEventReceiverInstanceType.ShouldNotBeNull();
            _itemSecurityEventReceiverInstance.ShouldNotBeNull();
            _itemSecurityEventReceiverInstanceFixture.ShouldNotBeNull();
            _itemSecurityEventReceiverInstance.ShouldBeAssignableTo<ItemSecurityEventReceiver>();
            _itemSecurityEventReceiverInstanceFixture.ShouldBeAssignableTo<ItemSecurityEventReceiver>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ItemSecurityEventReceiver" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemUpdated)]
        [TestCase(MethodAddTimerJob)]
        [TestCase(MethodGetSafeGroupTitle)]
        [TestCase(MethodItemDeleting)]
        public void AUT_ItemSecurityEventReceiver_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ItemSecurityEventReceiver>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemSecurityEventReceiver_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemAdded_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _itemSecurityEventReceiverInstance.ItemAdded(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemAdded_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemSecurityEventReceiverInstanceFixture, parametersOfItemAdded);

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
        public void AUT_ItemSecurityEventReceiver_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_itemSecurityEventReceiverInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

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
        public void AUT_ItemSecurityEventReceiver_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ItemSecurityEventReceiver_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_itemSecurityEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemSecurityEventReceiver_ItemUpdated_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemUpdated_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _itemSecurityEventReceiverInstance.ItemUpdated(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemUpdated_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemUpdated, methodItemUpdatedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemSecurityEventReceiverInstanceFixture, parametersOfItemUpdated);

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
        public void AUT_ItemSecurityEventReceiver_ItemUpdated_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemUpdated = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_itemSecurityEventReceiverInstance, MethodItemUpdated, parametersOfItemUpdated, methodItemUpdatedPrametersTypes);

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
        public void AUT_ItemSecurityEventReceiver_ItemUpdated_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ItemSecurityEventReceiver_ItemUpdated_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemUpdatedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);

            // Assert
            methodItemUpdatedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemUpdated_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemUpdated, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_itemSecurityEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemSecurityEventReceiver_AddTimerJob_Method_Call_Internally(Type[] types)
        {
            var methodAddTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_AddTimerJob_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfAddTimerJob = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTimerJob, methodAddTimerJobPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemSecurityEventReceiverInstanceFixture, parametersOfAddTimerJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTimerJob.ShouldNotBeNull();
            parametersOfAddTimerJob.Length.ShouldBe(1);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(1);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(parametersOfAddTimerJob.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_AddTimerJob_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfAddTimerJob = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_itemSecurityEventReceiverInstance, MethodAddTimerJob, parametersOfAddTimerJob, methodAddTimerJobPrametersTypes);

            // Assert
            parametersOfAddTimerJob.ShouldNotBeNull();
            parametersOfAddTimerJob.Length.ShouldBe(1);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(1);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(parametersOfAddTimerJob.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_AddTimerJob_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTimerJob, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_AddTimerJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            methodAddTimerJobPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_AddTimerJob_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTimerJob, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_itemSecurityEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemSecurityEventReceiver_GetSafeGroupTitle_Method_Call_Internally(Type[] types)
        {
            var methodGetSafeGroupTitlePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodGetSafeGroupTitle, Fixture, methodGetSafeGroupTitlePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_GetSafeGroupTitle_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var grpName = CreateType<string>();
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeGroupTitle = { grpName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSafeGroupTitle, methodGetSafeGroupTitlePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemSecurityEventReceiverInstanceFixture, parametersOfGetSafeGroupTitle);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSafeGroupTitle.ShouldNotBeNull();
            parametersOfGetSafeGroupTitle.Length.ShouldBe(1);
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_GetSafeGroupTitle_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var grpName = CreateType<string>();
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeGroupTitle = { grpName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ItemSecurityEventReceiver, string>(_itemSecurityEventReceiverInstance, MethodGetSafeGroupTitle, parametersOfGetSafeGroupTitle, methodGetSafeGroupTitlePrametersTypes);

            // Assert
            parametersOfGetSafeGroupTitle.ShouldNotBeNull();
            parametersOfGetSafeGroupTitle.Length.ShouldBe(1);
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_GetSafeGroupTitle_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodGetSafeGroupTitle, Fixture, methodGetSafeGroupTitlePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_GetSafeGroupTitle_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodGetSafeGroupTitle, Fixture, methodGetSafeGroupTitlePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_GetSafeGroupTitle_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSafeGroupTitle, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_itemSecurityEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_GetSafeGroupTitle_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSafeGroupTitle, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemSecurityEventReceiver_ItemDeleting_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemDeleting_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _itemSecurityEventReceiverInstance.ItemDeleting(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemDeleting_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemDeleting, methodItemDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemSecurityEventReceiverInstanceFixture, parametersOfItemDeleting);

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
        public void AUT_ItemSecurityEventReceiver_ItemDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_itemSecurityEventReceiverInstance, MethodItemDeleting, parametersOfItemDeleting, methodItemDeletingPrametersTypes);

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
        public void AUT_ItemSecurityEventReceiver_ItemDeleting_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ItemSecurityEventReceiver_ItemDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemDeletingPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemSecurityEventReceiverInstance, MethodItemDeleting, Fixture, methodItemDeletingPrametersTypes);

            // Assert
            methodItemDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemSecurityEventReceiver_ItemDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_itemSecurityEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}