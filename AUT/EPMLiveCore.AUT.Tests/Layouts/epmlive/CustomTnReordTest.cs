using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CustomTnReord" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomTnReordTest : AbstractBaseSetupTypedTest<CustomTnReord>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomTnReord) Initializer

        private const string MethodManageFields = "ManageFields";
        private const string MethodRedirectToTopNavPage = "RedirectToTopNavPage";
        private const string MethodRegisterControlEvents = "RegisterControlEvents";
        private const string MethodOnSubmit = "OnSubmit";
        private const string MethodOnCancel = "OnCancel";
        private const string MethodClearCache = "ClearCache";
        private const string MethodUpdateNodeOrder = "UpdateNodeOrder";
        private const string MethodMoveNode = "MoveNode";
        private const string MethodPage_Load = "Page_Load";
        private const string FieldTOP_NAV_URL = "TOP_NAV_URL";
        private const string FieldASYNC_NAV_ACTIONS_URL = "ASYNC_NAV_ACTIONS_URL";
        private const string Field_site = "_site";
        private const string Field_web = "_web";
        private const string Field_spNavCollTopNav = "_spNavCollTopNav";
        private const string Field_appId = "_appId";
        private const string Field_nodeType = "_nodeType";
        private const string Field_actionMoveNode = "_actionMoveNode";
        private const string Field_async_nav_actions_url = "_async_nav_actions_url";
        private const string FieldappHelper = "appHelper";
        private const string Field_origUserId = "_origUserId";
        private Type _customTnReordInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomTnReord _customTnReordInstance;
        private CustomTnReord _customTnReordInstanceFixture;

        #region General Initializer : Class (CustomTnReord) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomTnReord" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customTnReordInstanceType = typeof(CustomTnReord);
            _customTnReordInstanceFixture = Create(true);
            _customTnReordInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomTnReord)

        #region General Initializer : Class (CustomTnReord) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CustomTnReord" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodRedirectToTopNavPage, 0)]
        [TestCase(MethodRegisterControlEvents, 0)]
        [TestCase(MethodOnSubmit, 0)]
        [TestCase(MethodOnCancel, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodUpdateNodeOrder, 0)]
        [TestCase(MethodMoveNode, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_CustomTnReord_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_customTnReordInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomTnReord) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomTnReord" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldTOP_NAV_URL)]
        [TestCase(FieldASYNC_NAV_ACTIONS_URL)]
        [TestCase(Field_site)]
        [TestCase(Field_web)]
        [TestCase(Field_spNavCollTopNav)]
        [TestCase(Field_appId)]
        [TestCase(Field_nodeType)]
        [TestCase(Field_actionMoveNode)]
        [TestCase(Field_async_nav_actions_url)]
        [TestCase(FieldappHelper)]
        [TestCase(Field_origUserId)]
        public void AUT_CustomTnReord_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customTnReordInstanceFixture, 
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
        ///     Class (<see cref="CustomTnReord" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CustomTnReord_Is_Instance_Present_Test()
        {
            // Assert
            _customTnReordInstanceType.ShouldNotBeNull();
            _customTnReordInstance.ShouldNotBeNull();
            _customTnReordInstanceFixture.ShouldNotBeNull();
            _customTnReordInstance.ShouldBeAssignableTo<CustomTnReord>();
            _customTnReordInstanceFixture.ShouldBeAssignableTo<CustomTnReord>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomTnReord) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CustomTnReord_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomTnReord instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customTnReordInstanceType.ShouldNotBeNull();
            _customTnReordInstance.ShouldNotBeNull();
            _customTnReordInstanceFixture.ShouldNotBeNull();
            _customTnReordInstance.ShouldBeAssignableTo<CustomTnReord>();
            _customTnReordInstanceFixture.ShouldBeAssignableTo<CustomTnReord>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CustomTnReord" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodManageFields)]
        [TestCase(MethodRedirectToTopNavPage)]
        [TestCase(MethodRegisterControlEvents)]
        [TestCase(MethodOnSubmit)]
        [TestCase(MethodOnCancel)]
        [TestCase(MethodClearCache)]
        [TestCase(MethodUpdateNodeOrder)]
        [TestCase(MethodMoveNode)]
        [TestCase(MethodPage_Load)]
        public void AUT_CustomTnReord_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CustomTnReord>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfManageFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageFields.ShouldBeNull();
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

            // Assert
            parametersOfManageFields.ShouldBeNull();
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_RedirectToTopNavPage_Method_Call_Internally(Type[] types)
        {
            var methodRedirectToTopNavPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodRedirectToTopNavPage, Fixture, methodRedirectToTopNavPagePrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RedirectToTopNavPage_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;
            object[] parametersOfRedirectToTopNavPage = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectToTopNavPage, methodRedirectToTopNavPagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfRedirectToTopNavPage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirectToTopNavPage.ShouldBeNull();
            methodRedirectToTopNavPagePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RedirectToTopNavPage_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;
            object[] parametersOfRedirectToTopNavPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodRedirectToTopNavPage, parametersOfRedirectToTopNavPage, methodRedirectToTopNavPagePrametersTypes);

            // Assert
            parametersOfRedirectToTopNavPage.ShouldBeNull();
            methodRedirectToTopNavPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RedirectToTopNavPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodRedirectToTopNavPage, Fixture, methodRedirectToTopNavPagePrametersTypes);

            // Assert
            methodRedirectToTopNavPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RedirectToTopNavPage_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectToTopNavPage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_RegisterControlEvents_Method_Call_Internally(Type[] types)
        {
            var methodRegisterControlEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, methodRegisterControlEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfRegisterControlEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterControlEvents.ShouldBeNull();
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodRegisterControlEvents, parametersOfRegisterControlEvents, methodRegisterControlEventsPrametersTypes);

            // Assert
            parametersOfRegisterControlEvents.ShouldBeNull();
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RegisterControlEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);

            // Assert
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_RegisterControlEvents_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_OnSubmit_Method_Call_Internally(Type[] types)
        {
            var methodOnSubmitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnSubmit_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSubmit, methodOnSubmitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfOnSubmit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnSubmit.ShouldNotBeNull();
            parametersOfOnSubmit.Length.ShouldBe(2);
            methodOnSubmitPrametersTypes.Length.ShouldBe(2);
            methodOnSubmitPrametersTypes.Length.ShouldBe(parametersOfOnSubmit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnSubmit_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodOnSubmit, parametersOfOnSubmit, methodOnSubmitPrametersTypes);

            // Assert
            parametersOfOnSubmit.ShouldNotBeNull();
            parametersOfOnSubmit.Length.ShouldBe(2);
            methodOnSubmitPrametersTypes.Length.ShouldBe(2);
            methodOnSubmitPrametersTypes.Length.ShouldBe(parametersOfOnSubmit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnSubmit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnSubmit, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnSubmit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);

            // Assert
            methodOnSubmitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnSubmit_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSubmit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_OnCancel_Method_Call_Internally(Type[] types)
        {
            var methodOnCancelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnCancel_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnCancel, methodOnCancelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfOnCancel);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnCancel.ShouldNotBeNull();
            parametersOfOnCancel.Length.ShouldBe(2);
            methodOnCancelPrametersTypes.Length.ShouldBe(2);
            methodOnCancelPrametersTypes.Length.ShouldBe(parametersOfOnCancel.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnCancel_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodOnCancel, parametersOfOnCancel, methodOnCancelPrametersTypes);

            // Assert
            parametersOfOnCancel.ShouldNotBeNull();
            parametersOfOnCancel.Length.ShouldBe(2);
            methodOnCancelPrametersTypes.Length.ShouldBe(2);
            methodOnCancelPrametersTypes.Length.ShouldBe(parametersOfOnCancel.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnCancel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnCancel, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnCancel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);

            // Assert
            methodOnCancelPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_OnCancel_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnCancel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_ClearCache_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ClearCache_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfClearCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearCache.ShouldBeNull();
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ClearCache_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

            // Assert
            parametersOfClearCache.ShouldBeNull();
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ClearCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_ClearCache_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_UpdateNodeOrder_Method_Call_Internally(Type[] types)
        {
            var methodUpdateNodeOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodUpdateNodeOrder, Fixture, methodUpdateNodeOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_UpdateNodeOrder_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateNodeOrderPrametersTypes = null;
            object[] parametersOfUpdateNodeOrder = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateNodeOrder, methodUpdateNodeOrderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfUpdateNodeOrder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateNodeOrder.ShouldBeNull();
            methodUpdateNodeOrderPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_UpdateNodeOrder_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateNodeOrderPrametersTypes = null;
            object[] parametersOfUpdateNodeOrder = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodUpdateNodeOrder, parametersOfUpdateNodeOrder, methodUpdateNodeOrderPrametersTypes);

            // Assert
            parametersOfUpdateNodeOrder.ShouldBeNull();
            methodUpdateNodeOrderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_UpdateNodeOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateNodeOrderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodUpdateNodeOrder, Fixture, methodUpdateNodeOrderPrametersTypes);

            // Assert
            methodUpdateNodeOrderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_UpdateNodeOrder_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateNodeOrder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_MoveNode_Method_Call_Internally(Type[] types)
        {
            var methodMoveNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodMoveNode, Fixture, methodMoveNodePrametersTypes);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_MoveNode_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var movementInfo = CreateType<string[]>();
            var methodMoveNodePrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfMoveNode = { movementInfo };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMoveNode, methodMoveNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfMoveNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfMoveNode.ShouldNotBeNull();
            parametersOfMoveNode.Length.ShouldBe(1);
            methodMoveNodePrametersTypes.Length.ShouldBe(1);
            methodMoveNodePrametersTypes.Length.ShouldBe(parametersOfMoveNode.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_MoveNode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var movementInfo = CreateType<string[]>();
            var methodMoveNodePrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfMoveNode = { movementInfo };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodMoveNode, parametersOfMoveNode, methodMoveNodePrametersTypes);

            // Assert
            parametersOfMoveNode.ShouldNotBeNull();
            parametersOfMoveNode.Length.ShouldBe(1);
            methodMoveNodePrametersTypes.Length.ShouldBe(1);
            methodMoveNodePrametersTypes.Length.ShouldBe(parametersOfMoveNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_MoveNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMoveNode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_MoveNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMoveNodePrametersTypes = new Type[] { typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodMoveNode, Fixture, methodMoveNodePrametersTypes);

            // Assert
            methodMoveNodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_MoveNode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMoveNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomTnReord_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customTnReordInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customTnReordInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customTnReordInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomTnReord_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customTnReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}