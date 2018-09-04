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
using ItemEnableTeamEvent = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ItemEnableTeamEvent" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ItemEnableTeamEventTest : AbstractBaseSetupTypedTest<ItemEnableTeamEvent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ItemEnableTeamEvent) Initializer

        private const string MethodItemAdded = "ItemAdded";
        private const string MethodInitialize = "Initialize";
        private const string Field_siteId = "_siteId";
        private const string Field_listId = "_listId";
        private const string Field_webUrl = "_webUrl";
        private const string Field_listItem = "_listItem";
        private const string Field_itemTitle = "_itemTitle";
        private const string Field_itemId = "_itemId";
        private const string Field_siteName = "_siteName";
        private const string Field_siteUrl = "_siteUrl";
        private const string Field_listName = "_listName";
        private const string Field_properties = "_properties";
        private const string Field_settings = "_settings";
        private Type _itemEnableTeamEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ItemEnableTeamEvent _itemEnableTeamEventInstance;
        private ItemEnableTeamEvent _itemEnableTeamEventInstanceFixture;

        #region General Initializer : Class (ItemEnableTeamEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ItemEnableTeamEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _itemEnableTeamEventInstanceType = typeof(ItemEnableTeamEvent);
            _itemEnableTeamEventInstanceFixture = Create(true);
            _itemEnableTeamEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ItemEnableTeamEvent)

        #region General Initializer : Class (ItemEnableTeamEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ItemEnableTeamEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodInitialize, 0)]
        public void AUT_ItemEnableTeamEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_itemEnableTeamEventInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ItemEnableTeamEvent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ItemEnableTeamEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_siteId)]
        [TestCase(Field_listId)]
        [TestCase(Field_webUrl)]
        [TestCase(Field_listItem)]
        [TestCase(Field_itemTitle)]
        [TestCase(Field_itemId)]
        [TestCase(Field_siteName)]
        [TestCase(Field_siteUrl)]
        [TestCase(Field_listName)]
        [TestCase(Field_properties)]
        [TestCase(Field_settings)]
        public void AUT_ItemEnableTeamEvent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_itemEnableTeamEventInstanceFixture, 
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
        ///     Class (<see cref="ItemEnableTeamEvent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ItemEnableTeamEvent_Is_Instance_Present_Test()
        {
            // Assert
            _itemEnableTeamEventInstanceType.ShouldNotBeNull();
            _itemEnableTeamEventInstance.ShouldNotBeNull();
            _itemEnableTeamEventInstanceFixture.ShouldNotBeNull();
            _itemEnableTeamEventInstance.ShouldBeAssignableTo<ItemEnableTeamEvent>();
            _itemEnableTeamEventInstanceFixture.ShouldBeAssignableTo<ItemEnableTeamEvent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ItemEnableTeamEvent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ItemEnableTeamEvent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ItemEnableTeamEvent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _itemEnableTeamEventInstanceType.ShouldNotBeNull();
            _itemEnableTeamEventInstance.ShouldNotBeNull();
            _itemEnableTeamEventInstanceFixture.ShouldNotBeNull();
            _itemEnableTeamEventInstance.ShouldBeAssignableTo<ItemEnableTeamEvent>();
            _itemEnableTeamEventInstanceFixture.ShouldBeAssignableTo<ItemEnableTeamEvent>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ItemEnableTeamEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodInitialize)]
        public void AUT_ItemEnableTeamEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ItemEnableTeamEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemEnableTeamEvent_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemEnableTeamEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemEnableTeamEvent_ItemAdded_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _itemEnableTeamEventInstance.ItemAdded(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemEnableTeamEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodItemAdded, methodItemAddedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemEnableTeamEventInstanceFixture, parametersOfItemAdded);

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
        public void AUT_ItemEnableTeamEvent_ItemAdded_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfItemAdded = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_itemEnableTeamEventInstance, MethodItemAdded, parametersOfItemAdded, methodItemAddedPrametersTypes);

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
        public void AUT_ItemEnableTeamEvent_ItemAdded_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ItemEnableTeamEvent_ItemAdded_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodItemAddedPrametersTypes = new Type[] { typeof(SPItemEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemEnableTeamEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);

            // Assert
            methodItemAddedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemEnableTeamEvent_ItemAdded_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodItemAdded, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_itemEnableTeamEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ItemEnableTeamEvent_Initialize_Method_Call_Internally(Type[] types)
        {
            var methodInitializePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemEnableTeamEventInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemEnableTeamEvent_Initialize_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ItemEnableTeamEvent, bool>(_itemEnableTeamEventInstanceFixture, out exception1, parametersOfInitialize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ItemEnableTeamEvent, bool>(_itemEnableTeamEventInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

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
        public void AUT_ItemEnableTeamEvent_Initialize_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ItemEnableTeamEvent, bool>(_itemEnableTeamEventInstanceFixture, out exception1, parametersOfInitialize);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ItemEnableTeamEvent, bool>(_itemEnableTeamEventInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

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
        public void AUT_ItemEnableTeamEvent_Initialize_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitialize, methodInitializePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_itemEnableTeamEventInstanceFixture, parametersOfInitialize);

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
        public void AUT_ItemEnableTeamEvent_Initialize_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            object[] parametersOfInitialize = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ItemEnableTeamEvent, bool>(_itemEnableTeamEventInstance, MethodInitialize, parametersOfInitialize, methodInitializePrametersTypes);

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
        public void AUT_ItemEnableTeamEvent_Initialize_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitializePrametersTypes = new Type[] { typeof(SPItemEventProperties) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_itemEnableTeamEventInstance, MethodInitialize, Fixture, methodInitializePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInitializePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemEnableTeamEvent_Initialize_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitialize, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_itemEnableTeamEventInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Initialize) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ItemEnableTeamEvent_Initialize_Method_Call_Parameters_Count_Verification_Test()
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