using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using WorkEnginePPM.Core.Entities;

namespace WorkEnginePPM.Core.DataSync
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.DataSync.RoleManager" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RoleManagerTest : AbstractBaseSetupTypedTest<RoleManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RoleManager) Initializer

        private const string MethodAddOrUpdate = "AddOrUpdate";
        private const string MethodDelete = "Delete";
        private const string MethodRunRefresh = "RunRefresh";
        private Type _roleManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RoleManager _roleManagerInstance;
        private RoleManager _roleManagerInstanceFixture;

        #region General Initializer : Class (RoleManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RoleManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _roleManagerInstanceType = typeof(RoleManager);
            _roleManagerInstanceFixture = Create(true);
            _roleManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RoleManager)

        #region General Initializer : Class (RoleManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RoleManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddOrUpdate, 0)]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodRunRefresh, 0)]
        public void AUT_RoleManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_roleManagerInstanceFixture, 
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
        ///      Class (<see cref="RoleManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddOrUpdate)]
        [TestCase(MethodDelete)]
        [TestCase(MethodRunRefresh)]
        public void AUT_RoleManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<RoleManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleManager_AddOrUpdate_Method_Call_Internally(Type[] types)
        {
            var methodAddOrUpdatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodAddOrUpdate, Fixture, methodAddOrUpdatePrametersTypes);
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_AddOrUpdate_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var role = CreateType<Role>();
            Action executeAction = null;

            // Act
            executeAction = () => _roleManagerInstance.AddOrUpdate(role);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_AddOrUpdate_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var role = CreateType<Role>();
            var methodAddOrUpdatePrametersTypes = new Type[] { typeof(Role) };
            object[] parametersOfAddOrUpdate = { role };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddOrUpdate, methodAddOrUpdatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RoleManager, List<Role>>(_roleManagerInstanceFixture, out exception1, parametersOfAddOrUpdate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RoleManager, List<Role>>(_roleManagerInstance, MethodAddOrUpdate, parametersOfAddOrUpdate, methodAddOrUpdatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddOrUpdate.ShouldNotBeNull();
            parametersOfAddOrUpdate.Length.ShouldBe(1);
            methodAddOrUpdatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_AddOrUpdate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var role = CreateType<Role>();
            var methodAddOrUpdatePrametersTypes = new Type[] { typeof(Role) };
            object[] parametersOfAddOrUpdate = { role };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RoleManager, List<Role>>(_roleManagerInstance, MethodAddOrUpdate, parametersOfAddOrUpdate, methodAddOrUpdatePrametersTypes);

            // Assert
            parametersOfAddOrUpdate.ShouldNotBeNull();
            parametersOfAddOrUpdate.Length.ShouldBe(1);
            methodAddOrUpdatePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_AddOrUpdate_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddOrUpdatePrametersTypes = new Type[] { typeof(Role) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodAddOrUpdate, Fixture, methodAddOrUpdatePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddOrUpdatePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_AddOrUpdate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddOrUpdatePrametersTypes = new Type[] { typeof(Role) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodAddOrUpdate, Fixture, methodAddOrUpdatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddOrUpdatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_AddOrUpdate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddOrUpdate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_roleManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddOrUpdate) (Return Type : List<Role>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_AddOrUpdate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddOrUpdate, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleManager_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var role = CreateType<Role>();
            Action executeAction = null;

            // Act
            executeAction = () => _roleManagerInstance.Delete(role);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_Delete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var role = CreateType<Role>();
            var methodDeletePrametersTypes = new Type[] { typeof(Role) };
            object[] parametersOfDelete = { role };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RoleManager, bool>(_roleManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RoleManager, bool>(_roleManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

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
        public void AUT_RoleManager_Delete_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var role = CreateType<Role>();
            var methodDeletePrametersTypes = new Type[] { typeof(Role) };
            object[] parametersOfDelete = { role };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RoleManager, bool>(_roleManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RoleManager, bool>(_roleManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

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
        public void AUT_RoleManager_Delete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var role = CreateType<Role>();
            var methodDeletePrametersTypes = new Type[] { typeof(Role) };
            object[] parametersOfDelete = { role };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RoleManager, bool>(_roleManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

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
        public void AUT_RoleManager_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(Role) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_Delete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_roleManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_Delete_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (RunRefresh) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RoleManager_RunRefresh_Method_Call_Internally(Type[] types)
        {
            var methodRunRefreshPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodRunRefresh, Fixture, methodRunRefreshPrametersTypes);
        }

        #endregion

        #region Method Call : (RunRefresh) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_RunRefresh_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _roleManagerInstance.RunRefresh();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RunRefresh) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_RunRefresh_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodRunRefreshPrametersTypes = null;
            object[] parametersOfRunRefresh = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRunRefresh, methodRunRefreshPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<RoleManager, string>(_roleManagerInstanceFixture, out exception1, parametersOfRunRefresh);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<RoleManager, string>(_roleManagerInstance, MethodRunRefresh, parametersOfRunRefresh, methodRunRefreshPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRunRefresh.ShouldBeNull();
            methodRunRefreshPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RunRefresh) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_RunRefresh_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRunRefreshPrametersTypes = null;
            object[] parametersOfRunRefresh = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<RoleManager, string>(_roleManagerInstance, MethodRunRefresh, parametersOfRunRefresh, methodRunRefreshPrametersTypes);

            // Assert
            parametersOfRunRefresh.ShouldBeNull();
            methodRunRefreshPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RunRefresh) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_RunRefresh_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodRunRefreshPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodRunRefresh, Fixture, methodRunRefreshPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRunRefreshPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RunRefresh) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_RunRefresh_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRunRefreshPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_roleManagerInstance, MethodRunRefresh, Fixture, methodRunRefreshPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRunRefreshPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RunRefresh) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RoleManager_RunRefresh_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRunRefresh, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_roleManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}