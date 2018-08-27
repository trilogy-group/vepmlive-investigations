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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CustomNewNav" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CustomNewNavTest : AbstractBaseSetupTypedTest<CustomNewNav>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomNewNav) Initializer

        private const string MethodOnSubmit = "OnSubmit";
        private const string MethodOnCancel = "OnCancel";
        private const string MethodManageFields = "ManageFields";
        private const string MethodGetParameter = "GetParameter";
        private const string MethodCreateNodes = "CreateNodes";
        private const string MethodRedirectToTopNavPage = "RedirectToTopNavPage";
        private const string MethodRedirectToQuickLaunch = "RedirectToQuickLaunch";
        private const string MethodRedirect = "Redirect";
        private const string MethodClearCache = "ClearCache";
        private const string MethodRegisterControlEvents = "RegisterControlEvents";
        private const string MethodShowCategorySection = "ShowCategorySection";
        private const string MethodLoadHeadingDropDownList = "LoadHeadingDropDownList";
        private const string MethodAuthenticateUser = "AuthenticateUser";
        private const string MethodPage_Load = "Page_Load";
        private const string FieldTOP_NAV_URL = "TOP_NAV_URL";
        private const string FieldQUICK_LNCH_URL = "QUICK_LNCH_URL";
        private const string FieldASYNC_NAV_ACTIONS_URL = "ASYNC_NAV_ACTIONS_URL";
        private const string Field_site = "_site";
        private const string Field_web = "_web";
        private const string Field_parentNodeId = "_parentNodeId";
        private const string Field_isNewHeading = "_isNewHeading";
        private const string FieldappHelper = "appHelper";
        private const string Field_appId = "_appId";
        private const string Field_webUrl = "_webUrl";
        private const string Field_async_nav_actions_url = "_async_nav_actions_url";
        private const string Field_createAction = "_createAction";
        private const string Field_nodeType = "_nodeType";
        private const string Field_parentNode = "_parentNode";
        private const string Field_origUserId = "_origUserId";
        private Type _customNewNavInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomNewNav _customNewNavInstance;
        private CustomNewNav _customNewNavInstanceFixture;

        #region General Initializer : Class (CustomNewNav) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomNewNav" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customNewNavInstanceType = typeof(CustomNewNav);
            _customNewNavInstanceFixture = Create(true);
            _customNewNavInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomNewNav)

        #region General Initializer : Class (CustomNewNav) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CustomNewNav" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnSubmit, 0)]
        [TestCase(MethodOnCancel, 0)]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodGetParameter, 0)]
        [TestCase(MethodCreateNodes, 0)]
        [TestCase(MethodRedirectToTopNavPage, 0)]
        [TestCase(MethodRedirectToQuickLaunch, 0)]
        [TestCase(MethodRedirect, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodRegisterControlEvents, 0)]
        [TestCase(MethodShowCategorySection, 0)]
        [TestCase(MethodLoadHeadingDropDownList, 0)]
        [TestCase(MethodAuthenticateUser, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_CustomNewNav_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_customNewNavInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomNewNav) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomNewNav" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldTOP_NAV_URL)]
        [TestCase(FieldQUICK_LNCH_URL)]
        [TestCase(FieldASYNC_NAV_ACTIONS_URL)]
        [TestCase(Field_site)]
        [TestCase(Field_web)]
        [TestCase(Field_parentNodeId)]
        [TestCase(Field_isNewHeading)]
        [TestCase(FieldappHelper)]
        [TestCase(Field_appId)]
        [TestCase(Field_webUrl)]
        [TestCase(Field_async_nav_actions_url)]
        [TestCase(Field_createAction)]
        [TestCase(Field_nodeType)]
        [TestCase(Field_parentNode)]
        [TestCase(Field_origUserId)]
        public void AUT_CustomNewNav_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customNewNavInstanceFixture, 
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
        ///     Class (<see cref="CustomNewNav" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CustomNewNav_Is_Instance_Present_Test()
        {
            // Assert
            _customNewNavInstanceType.ShouldNotBeNull();
            _customNewNavInstance.ShouldNotBeNull();
            _customNewNavInstanceFixture.ShouldNotBeNull();
            _customNewNavInstance.ShouldBeAssignableTo<CustomNewNav>();
            _customNewNavInstanceFixture.ShouldBeAssignableTo<CustomNewNav>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomNewNav) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CustomNewNav_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomNewNav instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customNewNavInstanceType.ShouldNotBeNull();
            _customNewNavInstance.ShouldNotBeNull();
            _customNewNavInstanceFixture.ShouldNotBeNull();
            _customNewNavInstance.ShouldBeAssignableTo<CustomNewNav>();
            _customNewNavInstanceFixture.ShouldBeAssignableTo<CustomNewNav>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CustomNewNav" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnSubmit)]
        [TestCase(MethodOnCancel)]
        [TestCase(MethodManageFields)]
        [TestCase(MethodGetParameter)]
        [TestCase(MethodCreateNodes)]
        [TestCase(MethodRedirectToTopNavPage)]
        [TestCase(MethodRedirectToQuickLaunch)]
        [TestCase(MethodRedirect)]
        [TestCase(MethodClearCache)]
        [TestCase(MethodRegisterControlEvents)]
        [TestCase(MethodShowCategorySection)]
        [TestCase(MethodLoadHeadingDropDownList)]
        [TestCase(MethodAuthenticateUser)]
        [TestCase(MethodPage_Load)]
        public void AUT_CustomNewNav_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CustomNewNav>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_OnSubmit_Method_Call_Internally(Type[] types)
        {
            var methodOnSubmitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_OnSubmit_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSubmit, methodOnSubmitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfOnSubmit);

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
        public void AUT_CustomNewNav_OnSubmit_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodOnSubmit, parametersOfOnSubmit, methodOnSubmitPrametersTypes);

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
        public void AUT_CustomNewNav_OnSubmit_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomNewNav_OnSubmit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);

            // Assert
            methodOnSubmitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_OnSubmit_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSubmit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_OnCancel_Method_Call_Internally(Type[] types)
        {
            var methodOnCancelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_OnCancel_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnCancel, methodOnCancelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfOnCancel);

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
        public void AUT_CustomNewNav_OnCancel_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodOnCancel, parametersOfOnCancel, methodOnCancelPrametersTypes);

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
        public void AUT_CustomNewNav_OnCancel_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomNewNav_OnCancel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);

            // Assert
            methodOnCancelPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_OnCancel_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnCancel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfManageFields);

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
        public void AUT_CustomNewNav_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

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
        public void AUT_CustomNewNav_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_GetParameter_Method_Call_Internally(Type[] types)
        {
            var methodGetParameterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodGetParameter, Fixture, methodGetParameterPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_GetParameter_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetParameter = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetParameter, methodGetParameterPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CustomNewNav, string>(_customNewNavInstanceFixture, out exception1, parametersOfGetParameter);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CustomNewNav, string>(_customNewNavInstance, MethodGetParameter, parametersOfGetParameter, methodGetParameterPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetParameter.ShouldNotBeNull();
            parametersOfGetParameter.Length.ShouldBe(1);
            methodGetParameterPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfGetParameter));
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_GetParameter_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetParameter = { key };

            // Assert
            parametersOfGetParameter.ShouldNotBeNull();
            parametersOfGetParameter.Length.ShouldBe(1);
            methodGetParameterPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CustomNewNav, string>(_customNewNavInstance, MethodGetParameter, parametersOfGetParameter, methodGetParameterPrametersTypes));
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_GetParameter_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodGetParameter, Fixture, methodGetParameterPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParameterPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_GetParameter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodGetParameter, Fixture, methodGetParameterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParameterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_GetParameter_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParameter, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_GetParameter_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParameter, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateNodes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_CreateNodes_Method_Call_Internally(Type[] types)
        {
            var methodCreateNodesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodCreateNodes, Fixture, methodCreateNodesPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateNodes) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_CreateNodes_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateNodesPrametersTypes = null;
            object[] parametersOfCreateNodes = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateNodes, methodCreateNodesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfCreateNodes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateNodes.ShouldBeNull();
            methodCreateNodesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateNodes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_CreateNodes_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateNodesPrametersTypes = null;
            object[] parametersOfCreateNodes = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodCreateNodes, parametersOfCreateNodes, methodCreateNodesPrametersTypes);

            // Assert
            parametersOfCreateNodes.ShouldBeNull();
            methodCreateNodesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateNodes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_CreateNodes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateNodesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodCreateNodes, Fixture, methodCreateNodesPrametersTypes);

            // Assert
            methodCreateNodesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateNodes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_CreateNodes_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateNodes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_RedirectToTopNavPage_Method_Call_Internally(Type[] types)
        {
            var methodRedirectToTopNavPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRedirectToTopNavPage, Fixture, methodRedirectToTopNavPagePrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RedirectToTopNavPage_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;
            object[] parametersOfRedirectToTopNavPage = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectToTopNavPage, methodRedirectToTopNavPagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfRedirectToTopNavPage);

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
        public void AUT_CustomNewNav_RedirectToTopNavPage_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;
            object[] parametersOfRedirectToTopNavPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodRedirectToTopNavPage, parametersOfRedirectToTopNavPage, methodRedirectToTopNavPagePrametersTypes);

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
        public void AUT_CustomNewNav_RedirectToTopNavPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRedirectToTopNavPage, Fixture, methodRedirectToTopNavPagePrametersTypes);

            // Assert
            methodRedirectToTopNavPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RedirectToTopNavPage_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectToTopNavPage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_RedirectToQuickLaunch_Method_Call_Internally(Type[] types)
        {
            var methodRedirectToQuickLaunchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRedirectToQuickLaunch, Fixture, methodRedirectToQuickLaunchPrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RedirectToQuickLaunch_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectToQuickLaunchPrametersTypes = null;
            object[] parametersOfRedirectToQuickLaunch = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectToQuickLaunch, methodRedirectToQuickLaunchPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfRedirectToQuickLaunch);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirectToQuickLaunch.ShouldBeNull();
            methodRedirectToQuickLaunchPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RedirectToQuickLaunch_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectToQuickLaunchPrametersTypes = null;
            object[] parametersOfRedirectToQuickLaunch = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodRedirectToQuickLaunch, parametersOfRedirectToQuickLaunch, methodRedirectToQuickLaunchPrametersTypes);

            // Assert
            parametersOfRedirectToQuickLaunch.ShouldBeNull();
            methodRedirectToQuickLaunchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RedirectToQuickLaunch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectToQuickLaunchPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRedirectToQuickLaunch, Fixture, methodRedirectToQuickLaunchPrametersTypes);

            // Assert
            methodRedirectToQuickLaunchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RedirectToQuickLaunch_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectToQuickLaunch, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_Redirect_Method_Call_Internally(Type[] types)
        {
            var methodRedirectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRedirect, Fixture, methodRedirectPrametersTypes);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_Redirect_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;
            object[] parametersOfRedirect = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirect, methodRedirectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfRedirect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirect.ShouldBeNull();
            methodRedirectPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_Redirect_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;
            object[] parametersOfRedirect = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodRedirect, parametersOfRedirect, methodRedirectPrametersTypes);

            // Assert
            parametersOfRedirect.ShouldBeNull();
            methodRedirectPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_Redirect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRedirect, Fixture, methodRedirectPrametersTypes);

            // Assert
            methodRedirectPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_Redirect_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirect, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_ClearCache_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ClearCache_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfClearCache);

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
        public void AUT_CustomNewNav_ClearCache_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

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
        public void AUT_CustomNewNav_ClearCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ClearCache_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_RegisterControlEvents_Method_Call_Internally(Type[] types)
        {
            var methodRegisterControlEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, methodRegisterControlEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfRegisterControlEvents);

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
        public void AUT_CustomNewNav_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodRegisterControlEvents, parametersOfRegisterControlEvents, methodRegisterControlEventsPrametersTypes);

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
        public void AUT_CustomNewNav_RegisterControlEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);

            // Assert
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_RegisterControlEvents_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowCategorySection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_ShowCategorySection_Method_Call_Internally(Type[] types)
        {
            var methodShowCategorySectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodShowCategorySection, Fixture, methodShowCategorySectionPrametersTypes);
        }

        #endregion

        #region Method Call : (ShowCategorySection) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ShowCategorySection_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var isheading = CreateType<bool>();
            var methodShowCategorySectionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowCategorySection = { isheading };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodShowCategorySection, methodShowCategorySectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfShowCategorySection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfShowCategorySection.ShouldNotBeNull();
            parametersOfShowCategorySection.Length.ShouldBe(1);
            methodShowCategorySectionPrametersTypes.Length.ShouldBe(1);
            methodShowCategorySectionPrametersTypes.Length.ShouldBe(parametersOfShowCategorySection.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ShowCategorySection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ShowCategorySection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var isheading = CreateType<bool>();
            var methodShowCategorySectionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfShowCategorySection = { isheading };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodShowCategorySection, parametersOfShowCategorySection, methodShowCategorySectionPrametersTypes);

            // Assert
            parametersOfShowCategorySection.ShouldNotBeNull();
            parametersOfShowCategorySection.Length.ShouldBe(1);
            methodShowCategorySectionPrametersTypes.Length.ShouldBe(1);
            methodShowCategorySectionPrametersTypes.Length.ShouldBe(parametersOfShowCategorySection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowCategorySection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ShowCategorySection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodShowCategorySection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ShowCategorySection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ShowCategorySection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodShowCategorySectionPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodShowCategorySection, Fixture, methodShowCategorySectionPrametersTypes);

            // Assert
            methodShowCategorySectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShowCategorySection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_ShowCategorySection_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShowCategorySection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_LoadHeadingDropDownList_Method_Call_Internally(Type[] types)
        {
            var methodLoadHeadingDropDownListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodLoadHeadingDropDownList, Fixture, methodLoadHeadingDropDownListPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_LoadHeadingDropDownList_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadHeadingDropDownListPrametersTypes = null;
            object[] parametersOfLoadHeadingDropDownList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadHeadingDropDownList, methodLoadHeadingDropDownListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfLoadHeadingDropDownList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadHeadingDropDownList.ShouldBeNull();
            methodLoadHeadingDropDownListPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_LoadHeadingDropDownList_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadHeadingDropDownListPrametersTypes = null;
            object[] parametersOfLoadHeadingDropDownList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodLoadHeadingDropDownList, parametersOfLoadHeadingDropDownList, methodLoadHeadingDropDownListPrametersTypes);

            // Assert
            parametersOfLoadHeadingDropDownList.ShouldBeNull();
            methodLoadHeadingDropDownListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_LoadHeadingDropDownList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadHeadingDropDownListPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodLoadHeadingDropDownList, Fixture, methodLoadHeadingDropDownListPrametersTypes);

            // Assert
            methodLoadHeadingDropDownListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_LoadHeadingDropDownList_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadHeadingDropDownList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_AuthenticateUser_Method_Call_Internally(Type[] types)
        {
            var methodAuthenticateUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, methodAuthenticateUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfAuthenticateUser);

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
        public void AUT_CustomNewNav_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodAuthenticateUser, parametersOfAuthenticateUser, methodAuthenticateUserPrametersTypes);

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
        public void AUT_CustomNewNav_AuthenticateUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);

            // Assert
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_AuthenticateUser_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomNewNav_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customNewNavInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CustomNewNav_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customNewNavInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CustomNewNav_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomNewNav_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customNewNavInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomNewNav_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customNewNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}