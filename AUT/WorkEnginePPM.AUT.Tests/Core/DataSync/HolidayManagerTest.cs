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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.DataSync.HolidayManager" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class HolidayManagerTest : AbstractBaseSetupTypedTest<HolidayManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (HolidayManager) Initializer

        private const string MethodAddPFEHolidays = "AddPFEHolidays";
        private const string MethodDeleteSchedule = "DeleteSchedule";
        private const string MethodGetExistingHolidaySchedules = "GetExistingHolidaySchedules";
        private const string MethodSynchronize = "Synchronize";
        private Type _holidayManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private HolidayManager _holidayManagerInstance;
        private HolidayManager _holidayManagerInstanceFixture;

        #region General Initializer : Class (HolidayManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="HolidayManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _holidayManagerInstanceType = typeof(HolidayManager);
            _holidayManagerInstanceFixture = Create(true);
            _holidayManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (HolidayManager)

        #region General Initializer : Class (HolidayManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="HolidayManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddPFEHolidays, 0)]
        [TestCase(MethodDeleteSchedule, 0)]
        [TestCase(MethodGetExistingHolidaySchedules, 0)]
        [TestCase(MethodSynchronize, 0)]
        public void AUT_HolidayManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_holidayManagerInstanceFixture, 
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
        ///      Class (<see cref="HolidayManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddPFEHolidays)]
        [TestCase(MethodDeleteSchedule)]
        [TestCase(MethodGetExistingHolidaySchedules)]
        [TestCase(MethodSynchronize)]
        public void AUT_HolidayManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<HolidayManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddPFEHolidays) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HolidayManager_AddPFEHolidays_Method_Call_Internally(Type[] types)
        {
            var methodAddPFEHolidaysPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodAddPFEHolidays, Fixture, methodAddPFEHolidaysPrametersTypes);
        }

        #endregion

        #region Method Call : (AddPFEHolidays) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_AddPFEHolidays_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _holidayManagerInstance.AddPFEHolidays(properties);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddPFEHolidays) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_AddPFEHolidays_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodAddPFEHolidaysPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfAddPFEHolidays = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddPFEHolidays, methodAddPFEHolidaysPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_holidayManagerInstanceFixture, parametersOfAddPFEHolidays);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddPFEHolidays.ShouldNotBeNull();
            parametersOfAddPFEHolidays.Length.ShouldBe(1);
            methodAddPFEHolidaysPrametersTypes.Length.ShouldBe(1);
            methodAddPFEHolidaysPrametersTypes.Length.ShouldBe(parametersOfAddPFEHolidays.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEHolidays) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_AddPFEHolidays_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodAddPFEHolidaysPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfAddPFEHolidays = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_holidayManagerInstance, MethodAddPFEHolidays, parametersOfAddPFEHolidays, methodAddPFEHolidaysPrametersTypes);

            // Assert
            parametersOfAddPFEHolidays.ShouldNotBeNull();
            parametersOfAddPFEHolidays.Length.ShouldBe(1);
            methodAddPFEHolidaysPrametersTypes.Length.ShouldBe(1);
            methodAddPFEHolidaysPrametersTypes.Length.ShouldBe(parametersOfAddPFEHolidays.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEHolidays) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_AddPFEHolidays_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddPFEHolidays, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddPFEHolidays) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_AddPFEHolidays_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPFEHolidaysPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodAddPFEHolidays, Fixture, methodAddPFEHolidaysPrametersTypes);

            // Assert
            methodAddPFEHolidaysPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEHolidays) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_AddPFEHolidays_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddPFEHolidays, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_holidayManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HolidayManager_DeleteSchedule_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSchedulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodDeleteSchedule, Fixture, methodDeleteSchedulePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_DeleteSchedule_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var holidaySchedule = CreateType<HolidaySchedule>();
            Action executeAction = null;

            // Act
            executeAction = () => _holidayManagerInstance.DeleteSchedule(holidaySchedule);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_DeleteSchedule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var holidaySchedule = CreateType<HolidaySchedule>();
            var methodDeleteSchedulePrametersTypes = new Type[] { typeof(HolidaySchedule) };
            object[] parametersOfDeleteSchedule = { holidaySchedule };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteSchedule, methodDeleteSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<HolidayManager, bool>(_holidayManagerInstanceFixture, out exception1, parametersOfDeleteSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<HolidayManager, bool>(_holidayManagerInstance, MethodDeleteSchedule, parametersOfDeleteSchedule, methodDeleteSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteSchedule.ShouldNotBeNull();
            parametersOfDeleteSchedule.Length.ShouldBe(1);
            methodDeleteSchedulePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_DeleteSchedule_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var holidaySchedule = CreateType<HolidaySchedule>();
            var methodDeleteSchedulePrametersTypes = new Type[] { typeof(HolidaySchedule) };
            object[] parametersOfDeleteSchedule = { holidaySchedule };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteSchedule, methodDeleteSchedulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<HolidayManager, bool>(_holidayManagerInstanceFixture, out exception1, parametersOfDeleteSchedule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<HolidayManager, bool>(_holidayManagerInstance, MethodDeleteSchedule, parametersOfDeleteSchedule, methodDeleteSchedulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteSchedule.ShouldNotBeNull();
            parametersOfDeleteSchedule.Length.ShouldBe(1);
            methodDeleteSchedulePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_DeleteSchedule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var holidaySchedule = CreateType<HolidaySchedule>();
            var methodDeleteSchedulePrametersTypes = new Type[] { typeof(HolidaySchedule) };
            object[] parametersOfDeleteSchedule = { holidaySchedule };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<HolidayManager, bool>(_holidayManagerInstance, MethodDeleteSchedule, parametersOfDeleteSchedule, methodDeleteSchedulePrametersTypes);

            // Assert
            parametersOfDeleteSchedule.ShouldNotBeNull();
            parametersOfDeleteSchedule.Length.ShouldBe(1);
            methodDeleteSchedulePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_DeleteSchedule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteSchedulePrametersTypes = new Type[] { typeof(HolidaySchedule) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodDeleteSchedule, Fixture, methodDeleteSchedulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteSchedulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_DeleteSchedule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteSchedule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_holidayManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteSchedule) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_DeleteSchedule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteSchedule, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HolidayManager_GetExistingHolidaySchedules_Method_Call_Internally(Type[] types)
        {
            var methodGetExistingHolidaySchedulesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodGetExistingHolidaySchedules, Fixture, methodGetExistingHolidaySchedulesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_GetExistingHolidaySchedules_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => _holidayManagerInstance.GetExistingHolidaySchedules(spListItemCollection);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_GetExistingHolidaySchedules_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetExistingHolidaySchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetExistingHolidaySchedules = { spListItemCollection };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetExistingHolidaySchedules, methodGetExistingHolidaySchedulesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<HolidayManager, List<HolidaySchedule>>(_holidayManagerInstanceFixture, out exception1, parametersOfGetExistingHolidaySchedules);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<HolidayManager, List<HolidaySchedule>>(_holidayManagerInstance, MethodGetExistingHolidaySchedules, parametersOfGetExistingHolidaySchedules, methodGetExistingHolidaySchedulesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExistingHolidaySchedules.ShouldNotBeNull();
            parametersOfGetExistingHolidaySchedules.Length.ShouldBe(1);
            methodGetExistingHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_GetExistingHolidaySchedules_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetExistingHolidaySchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetExistingHolidaySchedules = { spListItemCollection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<HolidayManager, List<HolidaySchedule>>(_holidayManagerInstance, MethodGetExistingHolidaySchedules, parametersOfGetExistingHolidaySchedules, methodGetExistingHolidaySchedulesPrametersTypes);

            // Assert
            parametersOfGetExistingHolidaySchedules.ShouldNotBeNull();
            parametersOfGetExistingHolidaySchedules.Length.ShouldBe(1);
            methodGetExistingHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_GetExistingHolidaySchedules_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetExistingHolidaySchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodGetExistingHolidaySchedules, Fixture, methodGetExistingHolidaySchedulesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExistingHolidaySchedulesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_GetExistingHolidaySchedules_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExistingHolidaySchedulesPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodGetExistingHolidaySchedules, Fixture, methodGetExistingHolidaySchedulesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExistingHolidaySchedulesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_GetExistingHolidaySchedules_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExistingHolidaySchedules, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_holidayManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExistingHolidaySchedules) (Return Type : List<HolidaySchedule>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_GetExistingHolidaySchedules_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExistingHolidaySchedules, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_HolidayManager_Synchronize_Method_Call_Internally(Type[] types)
        {
            var methodSynchronizePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_Synchronize_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var holidaySchedules = CreateType<List<HolidaySchedule>>();
            Action executeAction = null;

            // Act
            executeAction = () => _holidayManagerInstance.Synchronize(holidaySchedules);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_Synchronize_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var holidaySchedules = CreateType<List<HolidaySchedule>>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<HolidaySchedule>) };
            object[] parametersOfSynchronize = { holidaySchedules };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSynchronize, methodSynchronizePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<HolidayManager, List<HolidaySchedule>>(_holidayManagerInstanceFixture, out exception1, parametersOfSynchronize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<HolidayManager, List<HolidaySchedule>>(_holidayManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

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

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_Synchronize_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var holidaySchedules = CreateType<List<HolidaySchedule>>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<HolidaySchedule>) };
            object[] parametersOfSynchronize = { holidaySchedules };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<HolidayManager, List<HolidaySchedule>>(_holidayManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_Synchronize_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<HolidaySchedule>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_Synchronize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<HolidaySchedule>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_holidayManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSynchronizePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_Synchronize_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_holidayManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<HolidaySchedule>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_HolidayManager_Synchronize_Method_Call_Parameters_Count_Verification_Test()
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