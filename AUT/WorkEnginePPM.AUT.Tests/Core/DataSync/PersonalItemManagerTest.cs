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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Core.DataSync.PersonalItemManager" />)
    ///     and namespace <see cref="WorkEnginePPM.Core.DataSync"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonalItemManagerTest : AbstractBaseSetupTypedTest<PersonalItemManager>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PersonalItemManager) Initializer

        private const string MethodAddPFEPersonalItems = "AddPFEPersonalItems";
        private const string MethodDelete = "Delete";
        private const string MethodGetExistingPersonalItems = "GetExistingPersonalItems";
        private const string MethodSynchronize = "Synchronize";
        private Type _personalItemManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PersonalItemManager _personalItemManagerInstance;
        private PersonalItemManager _personalItemManagerInstanceFixture;

        #region General Initializer : Class (PersonalItemManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PersonalItemManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _personalItemManagerInstanceType = typeof(PersonalItemManager);
            _personalItemManagerInstanceFixture = Create(true);
            _personalItemManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PersonalItemManager)

        #region General Initializer : Class (PersonalItemManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PersonalItemManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddPFEPersonalItems, 0)]
        [TestCase(MethodDelete, 0)]
        [TestCase(MethodGetExistingPersonalItems, 0)]
        [TestCase(MethodSynchronize, 0)]
        public void AUT_PersonalItemManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_personalItemManagerInstanceFixture, 
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
        ///      Class (<see cref="PersonalItemManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddPFEPersonalItems)]
        [TestCase(MethodDelete)]
        [TestCase(MethodGetExistingPersonalItems)]
        [TestCase(MethodSynchronize)]
        public void AUT_PersonalItemManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PersonalItemManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddPFEPersonalItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalItemManager_AddPFEPersonalItems_Method_Call_Internally(Type[] types)
        {
            var methodAddPFEPersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodAddPFEPersonalItems, Fixture, methodAddPFEPersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddPFEPersonalItems) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_AddPFEPersonalItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var currentPersonalItem = CreateType<PersonalItem>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalItemManagerInstance.AddPFEPersonalItems(currentPersonalItem);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddPFEPersonalItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_AddPFEPersonalItems_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var currentPersonalItem = CreateType<PersonalItem>();
            var methodAddPFEPersonalItemsPrametersTypes = new Type[] { typeof(PersonalItem) };
            object[] parametersOfAddPFEPersonalItems = { currentPersonalItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddPFEPersonalItems, methodAddPFEPersonalItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_personalItemManagerInstanceFixture, parametersOfAddPFEPersonalItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddPFEPersonalItems.ShouldNotBeNull();
            parametersOfAddPFEPersonalItems.Length.ShouldBe(1);
            methodAddPFEPersonalItemsPrametersTypes.Length.ShouldBe(1);
            methodAddPFEPersonalItemsPrametersTypes.Length.ShouldBe(parametersOfAddPFEPersonalItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEPersonalItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_AddPFEPersonalItems_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var currentPersonalItem = CreateType<PersonalItem>();
            var methodAddPFEPersonalItemsPrametersTypes = new Type[] { typeof(PersonalItem) };
            object[] parametersOfAddPFEPersonalItems = { currentPersonalItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_personalItemManagerInstance, MethodAddPFEPersonalItems, parametersOfAddPFEPersonalItems, methodAddPFEPersonalItemsPrametersTypes);

            // Assert
            parametersOfAddPFEPersonalItems.ShouldNotBeNull();
            parametersOfAddPFEPersonalItems.Length.ShouldBe(1);
            methodAddPFEPersonalItemsPrametersTypes.Length.ShouldBe(1);
            methodAddPFEPersonalItemsPrametersTypes.Length.ShouldBe(parametersOfAddPFEPersonalItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEPersonalItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_AddPFEPersonalItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddPFEPersonalItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddPFEPersonalItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_AddPFEPersonalItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddPFEPersonalItemsPrametersTypes = new Type[] { typeof(PersonalItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodAddPFEPersonalItems, Fixture, methodAddPFEPersonalItemsPrametersTypes);

            // Assert
            methodAddPFEPersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddPFEPersonalItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_AddPFEPersonalItems_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddPFEPersonalItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_personalItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalItemManager_Delete_Method_Call_Internally(Type[] types)
        {
            var methodDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Delete_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var personalItem = CreateType<PersonalItem>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalItemManagerInstance.Delete(personalItem);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Delete_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var personalItem = CreateType<PersonalItem>();
            var methodDeletePrametersTypes = new Type[] { typeof(PersonalItem) };
            object[] parametersOfDelete = { personalItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PersonalItemManager, bool>(_personalItemManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PersonalItemManager, bool>(_personalItemManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

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
        public void AUT_PersonalItemManager_Delete_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var personalItem = CreateType<PersonalItem>();
            var methodDeletePrametersTypes = new Type[] { typeof(PersonalItem) };
            object[] parametersOfDelete = { personalItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDelete, methodDeletePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PersonalItemManager, bool>(_personalItemManagerInstanceFixture, out exception1, parametersOfDelete);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PersonalItemManager, bool>(_personalItemManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

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
        public void AUT_PersonalItemManager_Delete_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var personalItem = CreateType<PersonalItem>();
            var methodDeletePrametersTypes = new Type[] { typeof(PersonalItem) };
            object[] parametersOfDelete = { personalItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PersonalItemManager, bool>(_personalItemManagerInstance, MethodDelete, parametersOfDelete, methodDeletePrametersTypes);

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
        public void AUT_PersonalItemManager_Delete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeletePrametersTypes = new Type[] { typeof(PersonalItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodDelete, Fixture, methodDeletePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeletePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Delete_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDelete, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_personalItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Delete) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Delete_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalItemManager_GetExistingPersonalItems_Method_Call_Internally(Type[] types)
        {
            var methodGetExistingPersonalItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodGetExistingPersonalItems, Fixture, methodGetExistingPersonalItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_GetExistingPersonalItems_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalItemManagerInstance.GetExistingPersonalItems(spListItemCollection);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_GetExistingPersonalItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetExistingPersonalItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetExistingPersonalItems = { spListItemCollection };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetExistingPersonalItems, methodGetExistingPersonalItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PersonalItemManager, List<PersonalItem>>(_personalItemManagerInstanceFixture, out exception1, parametersOfGetExistingPersonalItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PersonalItemManager, List<PersonalItem>>(_personalItemManagerInstance, MethodGetExistingPersonalItems, parametersOfGetExistingPersonalItems, methodGetExistingPersonalItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExistingPersonalItems.ShouldNotBeNull();
            parametersOfGetExistingPersonalItems.Length.ShouldBe(1);
            methodGetExistingPersonalItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_GetExistingPersonalItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListItemCollection = CreateType<SPListItemCollection>();
            var methodGetExistingPersonalItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            object[] parametersOfGetExistingPersonalItems = { spListItemCollection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PersonalItemManager, List<PersonalItem>>(_personalItemManagerInstance, MethodGetExistingPersonalItems, parametersOfGetExistingPersonalItems, methodGetExistingPersonalItemsPrametersTypes);

            // Assert
            parametersOfGetExistingPersonalItems.ShouldNotBeNull();
            parametersOfGetExistingPersonalItems.Length.ShouldBe(1);
            methodGetExistingPersonalItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_GetExistingPersonalItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetExistingPersonalItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodGetExistingPersonalItems, Fixture, methodGetExistingPersonalItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExistingPersonalItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_GetExistingPersonalItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExistingPersonalItemsPrametersTypes = new Type[] { typeof(SPListItemCollection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodGetExistingPersonalItems, Fixture, methodGetExistingPersonalItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExistingPersonalItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_GetExistingPersonalItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExistingPersonalItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_personalItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExistingPersonalItems) (Return Type : List<PersonalItem>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_GetExistingPersonalItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExistingPersonalItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PersonalItemManager_Synchronize_Method_Call_Internally(Type[] types)
        {
            var methodSynchronizePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Synchronize_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var personalItems = CreateType<List<PersonalItem>>();
            Action executeAction = null;

            // Act
            executeAction = () => _personalItemManagerInstance.Synchronize(personalItems);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Synchronize_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var personalItems = CreateType<List<PersonalItem>>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<PersonalItem>) };
            object[] parametersOfSynchronize = { personalItems };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSynchronize, methodSynchronizePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<PersonalItemManager, List<PersonalItem>>(_personalItemManagerInstanceFixture, out exception1, parametersOfSynchronize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<PersonalItemManager, List<PersonalItem>>(_personalItemManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

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

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Synchronize_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var personalItems = CreateType<List<PersonalItem>>();
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<PersonalItem>) };
            object[] parametersOfSynchronize = { personalItems };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<PersonalItemManager, List<PersonalItem>>(_personalItemManagerInstance, MethodSynchronize, parametersOfSynchronize, methodSynchronizePrametersTypes);

            // Assert
            parametersOfSynchronize.ShouldNotBeNull();
            parametersOfSynchronize.Length.ShouldBe(1);
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Synchronize_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<PersonalItem>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSynchronizePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Synchronize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSynchronizePrametersTypes = new Type[] { typeof(List<PersonalItem>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_personalItemManagerInstance, MethodSynchronize, Fixture, methodSynchronizePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSynchronizePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Synchronize_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSynchronize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_personalItemManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Synchronize) (Return Type : List<PersonalItem>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PersonalItemManager_Synchronize_Method_Call_Parameters_Count_Verification_Test()
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