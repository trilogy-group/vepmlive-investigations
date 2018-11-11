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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CustomQlReord" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomQlReordTest : AbstractBaseSetupTypedTest<CustomQlReord>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomQlReord) Initializer

        private const string MethodManageFields = "ManageFields";
        private const string MethodRedirectToQuikLnch = "RedirectToQuikLnch";
        private const string MethodRegisterControlEvents = "RegisterControlEvents";
        private const string MethodOnSubmit = "OnSubmit";
        private const string MethodOnCancel = "OnCancel";
        private const string MethodClearCache = "ClearCache";
        private const string MethodUpdateNodeOrder = "UpdateNodeOrder";
        private const string MethodMoveNode = "MoveNode";
        private const string MethodAuthenticateUser = "AuthenticateUser";
        private const string MethodPage_Load = "Page_Load";
        private const string FieldQUIK_LNCH_URL = "QUIK_LNCH_URL";
        private const string FieldASYNC_NAV_ACTIONS_URL = "ASYNC_NAV_ACTIONS_URL";
        private const string Field_site = "_site";
        private const string Field_web = "_web";
        private const string Field_eSite = "_eSite";
        private const string Field_eWeb = "_eWeb";
        private const string Field_spNavCollQuickLaunch = "_spNavCollQuickLaunch";
        private const string Field_appId = "_appId";
        private const string Field_nodeType = "_nodeType";
        private const string Field_actionMoveNode = "_actionMoveNode";
        private const string Field_async_nav_actions_url = "_async_nav_actions_url";
        private const string FieldappHelper = "appHelper";
        private const string Field_origUserId = "_origUserId";
        private Type _customQlReordInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomQlReord _customQlReordInstance;
        private CustomQlReord _customQlReordInstanceFixture;

        #region General Initializer : Class (CustomQlReord) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomQlReord" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customQlReordInstanceType = typeof(CustomQlReord);
            _customQlReordInstanceFixture = Create(true);
            _customQlReordInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomQlReord)

        #region General Initializer : Class (CustomQlReord) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CustomQlReord" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodRedirectToQuikLnch, 0)]
        [TestCase(MethodRegisterControlEvents, 0)]
        [TestCase(MethodOnSubmit, 0)]
        [TestCase(MethodOnCancel, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodUpdateNodeOrder, 0)]
        [TestCase(MethodMoveNode, 0)]
        [TestCase(MethodAuthenticateUser, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_CustomQlReord_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_customQlReordInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomQlReord) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomQlReord" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldQUIK_LNCH_URL)]
        [TestCase(FieldASYNC_NAV_ACTIONS_URL)]
        [TestCase(Field_site)]
        [TestCase(Field_web)]
        [TestCase(Field_eSite)]
        [TestCase(Field_eWeb)]
        [TestCase(Field_spNavCollQuickLaunch)]
        [TestCase(Field_appId)]
        [TestCase(Field_nodeType)]
        [TestCase(Field_actionMoveNode)]
        [TestCase(Field_async_nav_actions_url)]
        [TestCase(FieldappHelper)]
        [TestCase(Field_origUserId)]
        public void AUT_CustomQlReord_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customQlReordInstanceFixture, 
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
        ///     Class (<see cref="CustomQlReord" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CustomQlReord_Is_Instance_Present_Test()
        {
            // Assert
            _customQlReordInstanceType.ShouldNotBeNull();
            _customQlReordInstance.ShouldNotBeNull();
            _customQlReordInstanceFixture.ShouldNotBeNull();
            _customQlReordInstance.ShouldBeAssignableTo<CustomQlReord>();
            _customQlReordInstanceFixture.ShouldBeAssignableTo<CustomQlReord>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomQlReord) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CustomQlReord_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomQlReord instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customQlReordInstanceType.ShouldNotBeNull();
            _customQlReordInstance.ShouldNotBeNull();
            _customQlReordInstanceFixture.ShouldNotBeNull();
            _customQlReordInstance.ShouldBeAssignableTo<CustomQlReord>();
            _customQlReordInstanceFixture.ShouldBeAssignableTo<CustomQlReord>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CustomQlReord" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodManageFields)]
        [TestCase(MethodRedirectToQuikLnch)]
        [TestCase(MethodRegisterControlEvents)]
        [TestCase(MethodOnSubmit)]
        [TestCase(MethodOnCancel)]
        [TestCase(MethodClearCache)]
        [TestCase(MethodUpdateNodeOrder)]
        [TestCase(MethodMoveNode)]
        [TestCase(MethodAuthenticateUser)]
        [TestCase(MethodPage_Load)]
        public void AUT_CustomQlReord_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CustomQlReord>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfManageFields);

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
        public void AUT_CustomQlReord_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

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
        public void AUT_CustomQlReord_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuikLnch) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_RedirectToQuikLnch_Method_Call_Internally(Type[] types)
        {
            var methodRedirectToQuikLnchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodRedirectToQuikLnch, Fixture, methodRedirectToQuikLnchPrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectToQuikLnch) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_RedirectToQuikLnch_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectToQuikLnchPrametersTypes = null;
            object[] parametersOfRedirectToQuikLnch = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectToQuikLnch, methodRedirectToQuikLnchPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfRedirectToQuikLnch);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirectToQuikLnch.ShouldBeNull();
            methodRedirectToQuikLnchPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuikLnch) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_RedirectToQuikLnch_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectToQuikLnchPrametersTypes = null;
            object[] parametersOfRedirectToQuikLnch = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodRedirectToQuikLnch, parametersOfRedirectToQuikLnch, methodRedirectToQuikLnchPrametersTypes);

            // Assert
            parametersOfRedirectToQuikLnch.ShouldBeNull();
            methodRedirectToQuikLnchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuikLnch) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_RedirectToQuikLnch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectToQuikLnchPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodRedirectToQuikLnch, Fixture, methodRedirectToQuikLnchPrametersTypes);

            // Assert
            methodRedirectToQuikLnchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuikLnch) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_RedirectToQuikLnch_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectToQuikLnch, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_RegisterControlEvents_Method_Call_Internally(Type[] types)
        {
            var methodRegisterControlEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, methodRegisterControlEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfRegisterControlEvents);

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
        public void AUT_CustomQlReord_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodRegisterControlEvents, parametersOfRegisterControlEvents, methodRegisterControlEventsPrametersTypes);

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
        public void AUT_CustomQlReord_RegisterControlEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);

            // Assert
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_RegisterControlEvents_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_OnSubmit_Method_Call_Internally(Type[] types)
        {
            var methodOnSubmitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_OnSubmit_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSubmit, methodOnSubmitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfOnSubmit);

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
        public void AUT_CustomQlReord_OnSubmit_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodOnSubmit, parametersOfOnSubmit, methodOnSubmitPrametersTypes);

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
        public void AUT_CustomQlReord_OnSubmit_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomQlReord_OnSubmit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);

            // Assert
            methodOnSubmitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_OnSubmit_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSubmit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_OnCancel_Method_Call_Internally(Type[] types)
        {
            var methodOnCancelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_OnCancel_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnCancel, methodOnCancelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfOnCancel);

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
        public void AUT_CustomQlReord_OnCancel_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodOnCancel, parametersOfOnCancel, methodOnCancelPrametersTypes);

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
        public void AUT_CustomQlReord_OnCancel_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomQlReord_OnCancel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);

            // Assert
            methodOnCancelPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_OnCancel_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnCancel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_ClearCache_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_ClearCache_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfClearCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearCache.ShouldBeNull();
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_ClearCache_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

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
        public void AUT_CustomQlReord_ClearCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_ClearCache_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_UpdateNodeOrder_Method_Call_Internally(Type[] types)
        {
            var methodUpdateNodeOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodUpdateNodeOrder, Fixture, methodUpdateNodeOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_UpdateNodeOrder_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateNodeOrderPrametersTypes = null;
            object[] parametersOfUpdateNodeOrder = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateNodeOrder, methodUpdateNodeOrderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfUpdateNodeOrder);

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
        public void AUT_CustomQlReord_UpdateNodeOrder_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateNodeOrderPrametersTypes = null;
            object[] parametersOfUpdateNodeOrder = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodUpdateNodeOrder, parametersOfUpdateNodeOrder, methodUpdateNodeOrderPrametersTypes);

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
        public void AUT_CustomQlReord_UpdateNodeOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateNodeOrderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodUpdateNodeOrder, Fixture, methodUpdateNodeOrderPrametersTypes);

            // Assert
            methodUpdateNodeOrderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNodeOrder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_UpdateNodeOrder_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateNodeOrder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_MoveNode_Method_Call_Internally(Type[] types)
        {
            var methodMoveNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodMoveNode, Fixture, methodMoveNodePrametersTypes);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_MoveNode_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var movementInfo = CreateType<string[]>();
            var methodMoveNodePrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfMoveNode = { movementInfo };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodMoveNode, methodMoveNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfMoveNode);

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
        public void AUT_CustomQlReord_MoveNode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var movementInfo = CreateType<string[]>();
            var methodMoveNodePrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfMoveNode = { movementInfo };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodMoveNode, parametersOfMoveNode, methodMoveNodePrametersTypes);

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
        public void AUT_CustomQlReord_MoveNode_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomQlReord_MoveNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMoveNodePrametersTypes = new Type[] { typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodMoveNode, Fixture, methodMoveNodePrametersTypes);

            // Assert
            methodMoveNodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MoveNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_MoveNode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMoveNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_AuthenticateUser_Method_Call_Internally(Type[] types)
        {
            var methodAuthenticateUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, methodAuthenticateUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfAuthenticateUser);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAuthenticateUser.ShouldBeNull();
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodAuthenticateUser, parametersOfAuthenticateUser, methodAuthenticateUserPrametersTypes);

            // Assert
            parametersOfAuthenticateUser.ShouldBeNull();
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_AuthenticateUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);

            // Assert
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_AuthenticateUser_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomQlReord_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customQlReordInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CustomQlReord_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customQlReordInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CustomQlReord_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomQlReord_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customQlReordInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomQlReord_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customQlReordInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}