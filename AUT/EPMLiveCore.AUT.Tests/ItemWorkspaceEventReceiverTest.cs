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
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ItemWorkspaceEventReceiver = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ItemWorkspaceEventReceiver" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ItemWorkspaceEventReceiverTest : AbstractBaseSetupTypedTest<ItemWorkspaceEventReceiver>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemWorkspaceEventReceiver) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodFieldExistsInList = "FieldExistsInList";
        private const string MethodInitialize = "Initialize";
        private const string Field_siteId = "_siteId";
        private const string Field_webId = "_webId";
        private const string Field_listId = "_listId";
        private const string Field_itemTitle = "_itemTitle";
        private const string Field_itemId = "_itemId";
        private const string Field_createFromLiveTemp = "_createFromLiveTemp";
        private const string Field_creationParams = "_creationParams";
        private const string Field_templateId = "_templateId";
        private const string Field_settings = "_settings";
        private Type _itemWorkspaceEventReceiverInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemWorkspaceEventReceiver _itemWorkspaceEventReceiverInstance;
        private ItemWorkspaceEventReceiver _itemWorkspaceEventReceiverInstanceFixture;

        #region General Initializer : Class (ItemWorkspaceEventReceiver) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemWorkspaceEventReceiver" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemWorkspaceEventReceiverInstanceType = typeof(ItemWorkspaceEventReceiver);
            _itemWorkspaceEventReceiverInstanceFixture = Create(true);
            _itemWorkspaceEventReceiverInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemWorkspaceEventReceiver)

        #region General Initializer : Class (ItemWorkspaceEventReceiver) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ItemWorkspaceEventReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodFieldExistsInList, 0)]
        [TestCase(MethodInitialize, 0)]
        public void AUT_ItemWorkspaceEventReceiver_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_itemWorkspaceEventReceiverInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ItemWorkspaceEventReceiver) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemWorkspaceEventReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_siteId)]
        [TestCase(Field_webId)]
        [TestCase(Field_listId)]
        [TestCase(Field_itemTitle)]
        [TestCase(Field_itemId)]
        [TestCase(Field_createFromLiveTemp)]
        [TestCase(Field_creationParams)]
        [TestCase(Field_templateId)]
        [TestCase(Field_settings)]
        public void AUT_ItemWorkspaceEventReceiver_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemWorkspaceEventReceiverInstanceFixture, 
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
        ///     Class (<see cref="ItemWorkspaceEventReceiver" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ItemWorkspaceEventReceiver_Is_Instance_Present_Test()
        {
            // Assert
            _itemWorkspaceEventReceiverInstanceType.ShouldNotBeNull();
            _itemWorkspaceEventReceiverInstance.ShouldNotBeNull();
            _itemWorkspaceEventReceiverInstanceFixture.ShouldNotBeNull();
            _itemWorkspaceEventReceiverInstance.ShouldBeAssignableTo<ItemWorkspaceEventReceiver>();
            _itemWorkspaceEventReceiverInstanceFixture.ShouldBeAssignableTo<ItemWorkspaceEventReceiver>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemWorkspaceEventReceiver) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ItemWorkspaceEventReceiver_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemWorkspaceEventReceiver instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemWorkspaceEventReceiverInstanceType.ShouldNotBeNull();
            _itemWorkspaceEventReceiverInstance.ShouldNotBeNull();
            _itemWorkspaceEventReceiverInstanceFixture.ShouldNotBeNull();
            _itemWorkspaceEventReceiverInstance.ShouldBeAssignableTo<ItemWorkspaceEventReceiver>();
            _itemWorkspaceEventReceiverInstanceFixture.ShouldBeAssignableTo<ItemWorkspaceEventReceiver>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ItemWorkspaceEventReceiver" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodFieldExistsInList)]
        [TestCase(MethodInitialize)]
        public void AUT_ItemWorkspaceEventReceiver_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ItemWorkspaceEventReceiver>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemWorkspaceEventReceiver_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemWorkspaceEventReceiverInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_ItemAdded_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _itemWorkspaceEventReceiverInstance.ItemAdded(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemWorkspaceEventReceiverInstanceFixture, parametersOfItemAdded);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfItemAdded.ShouldNotBeNull();
            parametersOfItemAdded.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            methodItemAddedPrametersTypes.Length.ShouldBe(parametersOfItemAdded.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_itemWorkspaceEventReceiverInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

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
        public void AUT_ItemWorkspaceEventReceiver_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ItemWorkspaceEventReceiver_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemWorkspaceEventReceiverInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_itemWorkspaceEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_Internally(Type[] types)
        {
            var methodFieldExistsInListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemWorkspaceEventReceiverInstance, MethodFieldExistsInList, Fixture, methodFieldExistsInListPrametersTypes);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fieldInternalName = CreateType<string>();
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfFieldExistsInList = { list, fieldInternalName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, methodFieldExistsInListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstanceFixture, out exception1, parametersOfFieldExistsInList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstance, MethodFieldExistsInList, parametersOfFieldExistsInList, methodFieldExistsInListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFieldExistsInList.ShouldNotBeNull();
            parametersOfFieldExistsInList.Length.ShouldBe(2);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fieldInternalName = CreateType<string>();
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfFieldExistsInList = { list, fieldInternalName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, methodFieldExistsInListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstanceFixture, out exception1, parametersOfFieldExistsInList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstance, MethodFieldExistsInList, parametersOfFieldExistsInList, methodFieldExistsInListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFieldExistsInList.ShouldNotBeNull();
            parametersOfFieldExistsInList.Length.ShouldBe(2);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fieldInternalName = CreateType<string>();
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfFieldExistsInList = { list, fieldInternalName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, methodFieldExistsInListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemWorkspaceEventReceiverInstanceFixture, parametersOfFieldExistsInList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFieldExistsInList.ShouldNotBeNull();
            parametersOfFieldExistsInList.Length.ShouldBe(2);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var fieldInternalName = CreateType<string>();
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            object[] parametersOfFieldExistsInList = { list, fieldInternalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstance, MethodFieldExistsInList, parametersOfFieldExistsInList, methodFieldExistsInListPrametersTypes);

            // Assert
            parametersOfFieldExistsInList.ShouldNotBeNull();
            parametersOfFieldExistsInList.Length.ShouldBe(2);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFieldExistsInListPrametersTypes = new Type[] { typeof(SPList), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemWorkspaceEventReceiverInstance, MethodFieldExistsInList, Fixture, methodFieldExistsInListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFieldExistsInListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_itemWorkspaceEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FieldExistsInList) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_FieldExistsInList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFieldExistsInList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemWorkspaceEventReceiverInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstanceFixture, out exception1, parametersOfInitialize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstanceFixture, out exception1, parametersOfInitialize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemWorkspaceEventReceiverInstanceFixture, parametersOfInitialize);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ItemWorkspaceEventReceiver, bool>(_itemWorkspaceEventReceiverInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

            // Assert
            parametersOfInitialize.ShouldNotBeNull();
            parametersOfInitialize.Length.ShouldBe(1);
            methodInitializePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemWorkspaceEventReceiverInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInitializePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_itemWorkspaceEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemWorkspaceEventReceiver_Initialize_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitialize, 0);
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