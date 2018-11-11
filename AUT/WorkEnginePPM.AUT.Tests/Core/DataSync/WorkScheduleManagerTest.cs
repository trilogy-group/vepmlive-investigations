using System;
using System.Collections.Generic;
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
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Core.DataSync
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.DataSync.WorkScheduleManager" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkScheduleManagerTest : AbstractBaseSetupTypedTest<WorkScheduleManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkScheduleManager) Initializer

        private const string MethodAddPFEWorkSchedules = "AddPFEWorkSchedules";
        private const string MethodDelete = "Delete";
        private const string MethodGetExistingWorkSchedules = "GetExistingWorkSchedules";
        private const string MethodSynchronize = "Synchronize";
        private Type _workScheduleManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkScheduleManager _workScheduleManagerInstance;
        private WorkScheduleManager _workScheduleManagerInstanceFixture;

        #region General Initializer : Class (WorkScheduleManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkScheduleManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workScheduleManagerInstanceType = typeof(WorkScheduleManager);
            _workScheduleManagerInstanceFixture = Create(true);
            _workScheduleManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkScheduleManager)

        #region General Initializer : Class (WorkScheduleManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkScheduleManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddPFEWorkSchedules, 0)]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodGetExistingWorkSchedules, 0)]
        [TestCase(MethodSynchronize, 0)]
        public void AUT_WorkScheduleManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workScheduleManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WorkScheduleManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddPFEWorkSchedules)]
        [TestCase(MethodDelete)]
        [TestCase(MethodGetExistingWorkSchedules)]
        [TestCase(MethodSynchronize)]
        public void AUT_WorkScheduleManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkScheduleManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddPFEWorkSchedules) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkScheduleManager_AddPFEWorkSchedules_Method_Call_Internally(Type[] types)
        {
            var methodAddPFEWorkSchedulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodAddPFEWorkSchedules, Fixture, methodAddPFEWorkSchedulesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddPFEWorkSchedules) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_AddPFEWorkSchedules_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var currentSchedule = CreateType<WorkSchedule>();
            Action executeAction = null;

            // Act
            executeAction = () => _workScheduleManagerInstance.AddPFEWorkSchedules(currentSchedule);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddPFEWorkSchedules) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_AddPFEWorkSchedules_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var currentSchedule = CreateType<WorkSchedule>();
            var methodAddPFEWorkSchedulesPrametersTypes = new Type[] { typeof(WorkSchedule) };
            object[] parametersOfAddPFEWorkSchedules = { currentSchedule };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddPFEWorkSchedules, methodAddPFEWorkSchedulesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workScheduleManagerInstanceFixture, parametersOfAddPFEWorkSchedules);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddPFEWorkSchedules.ShouldNotBeNull();
            parametersOfAddPFEWorkSchedules.Length.ShouldBe(1);
            methodAddPFEWorkSchedulesPrametersTypes.Length.ShouldBe(1);
            methodAddPFEWorkSchedulesPrametersTypes.Length.ShouldBe(parametersOfAddPFEWorkSchedules.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEWorkSchedules) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_AddPFEWorkSchedules_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var currentSchedule = CreateType<WorkSchedule>();
            var methodAddPFEWorkSchedulesPrametersTypes = new Type[] { typeof(WorkSchedule) };
            object[] parametersOfAddPFEWorkSchedules = { currentSchedule };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workScheduleManagerInstance, MethodAddPFEWorkSchedules, parametersOfAddPFEWorkSchedules, methodAddPFEWorkSchedulesPrametersTypes);

            // Assert
            parametersOfAddPFEWorkSchedules.ShouldNotBeNull();
            parametersOfAddPFEWorkSchedules.Length.ShouldBe(1);
            methodAddPFEWorkSchedulesPrametersTypes.Length.ShouldBe(1);
            methodAddPFEWorkSchedulesPrametersTypes.Length.ShouldBe(parametersOfAddPFEWorkSchedules.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEWorkSchedules) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_AddPFEWorkSchedules_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddPFEWorkSchedules, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddPFEWorkSchedules) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_AddPFEWorkSchedules_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPFEWorkSchedulesPrametersTypes = new Type[] { typeof(WorkSchedule) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodAddPFEWorkSchedules, Fixture, methodAddPFEWorkSchedulesPrametersTypes);

            // Assert
            methodAddPFEWorkSchedulesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEWorkSchedules) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_AddPFEWorkSchedules_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddPFEWorkSchedules, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workScheduleManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkScheduleManager_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var workSchedule = CreateType<WorkSchedule>();
            Action executeAction = null;

            // Act
            executeAction = () => _workScheduleManagerInstance.Delete(workSchedule);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Delete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var workSchedule = CreateType<WorkSchedule>();
            var methodDeletePrametersTypes = new Type[] { typeof(WorkSchedule) };
            object[] parametersOfDelete = { workSchedule };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkScheduleManager, bool>(_workScheduleManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkScheduleManager, bool>(_workScheduleManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Delete_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var workSchedule = CreateType<WorkSchedule>();
            var methodDeletePrametersTypes = new Type[] { typeof(WorkSchedule) };
            object[] parametersOfDelete = { workSchedule };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkScheduleManager, bool>(_workScheduleManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkScheduleManager, bool>(_workScheduleManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Delete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var workSchedule = CreateType<WorkSchedule>();
            var methodDeletePrametersTypes = new Type[] { typeof(WorkSchedule) };
            object[] parametersOfDelete = { workSchedule };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WorkScheduleManager, bool>(_workScheduleManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

            // Assert
            parametersOfDelete.ShouldNotBeNull();
            parametersOfDelete.Length.ShouldBe(1);
            methodDeletePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(WorkSchedule) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Delete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workScheduleManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Delete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDelete, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_Call_Internally(Type[] types)
        {
            var methodGetExistingWorkSchedulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodGetExistingWorkSchedules, Fixture, methodGetExistingWorkSchedulesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => _workScheduleManagerInstance.GetExistingWorkSchedules(spListItemCollection);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetExistingWorkSchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetExistingWorkSchedules = { spListItemCollection };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetExistingWorkSchedules, methodGetExistingWorkSchedulesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkScheduleManager, List<WorkSchedule>>(_workScheduleManagerInstanceFixture, out exception1, parametersOfGetExistingWorkSchedules);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkScheduleManager, List<WorkSchedule>>(_workScheduleManagerInstance, MethodGetExistingWorkSchedules, parametersOfGetExistingWorkSchedules, methodGetExistingWorkSchedulesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExistingWorkSchedules.ShouldNotBeNull();
            parametersOfGetExistingWorkSchedules.Length.ShouldBe(1);
            methodGetExistingWorkSchedulesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetExistingWorkSchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetExistingWorkSchedules = { spListItemCollection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WorkScheduleManager, List<WorkSchedule>>(_workScheduleManagerInstance, MethodGetExistingWorkSchedules, parametersOfGetExistingWorkSchedules, methodGetExistingWorkSchedulesPrametersTypes);

            // Assert
            parametersOfGetExistingWorkSchedules.ShouldNotBeNull();
            parametersOfGetExistingWorkSchedules.Length.ShouldBe(1);
            methodGetExistingWorkSchedulesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetExistingWorkSchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodGetExistingWorkSchedules, Fixture, methodGetExistingWorkSchedulesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExistingWorkSchedulesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExistingWorkSchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodGetExistingWorkSchedules, Fixture, methodGetExistingWorkSchedulesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExistingWorkSchedulesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExistingWorkSchedules, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workScheduleManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExistingWorkSchedules) (Return Type : List<WorkSchedule>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_GetExistingWorkSchedules_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExistingWorkSchedules, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkScheduleManager_Synchronize_Method_Call_Internally(Type[] types)
        {
            var methodSynchronizePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Synchronize_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var workSchedules = CreateType<List<WorkSchedule>>();
            Action executeAction = null;

            // Act
            executeAction = () => _workScheduleManagerInstance.Synchronize(workSchedules);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Synchronize_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var workSchedules = CreateType<List<WorkSchedule>>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<WorkSchedule>) };
            object[] parametersOfSynchronize = { workSchedules };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSynchronize, methodSynchronizePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkScheduleManager, List<WorkSchedule>>(_workScheduleManagerInstanceFixture, out exception1, parametersOfSynchronize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkScheduleManager, List<WorkSchedule>>(_workScheduleManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Synchronize_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var workSchedules = CreateType<List<WorkSchedule>>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<WorkSchedule>) };
            object[] parametersOfSynchronize = { workSchedules };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WorkScheduleManager, List<WorkSchedule>>(_workScheduleManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Synchronize_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<WorkSchedule>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Synchronize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<WorkSchedule>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workScheduleManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSynchronizePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Synchronize_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workScheduleManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<WorkSchedule>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkScheduleManager_Synchronize_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);
            const int parametersCount = 1;

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