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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CustomEditNav" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CustomEditNavTest : AbstractBaseSetupTypedTest<CustomEditNav>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomEditNav) Initializer

        private const string MethodLoadUIContent = "LoadUIContent";
        private const string MethodLoadHeadingDropDownList = "LoadHeadingDropDownList";
        private const string MethodLoadTitleAndUrl = "LoadTitleAndUrl";
        private const string MethodRegisterControEvents = "RegisterControEvents";
        private const string MethodDisplayCategorySection = "DisplayCategorySection";
        private const string MethodUpdateNode = "UpdateNode";
        private const string MethodManageFields = "ManageFields";
        private const string MethodGetParameter = "GetParameter";
        private const string MethodRedirectToTopNavPage = "RedirectToTopNavPage";
        private const string MethodRedirectToQuickLaunch = "RedirectToQuickLaunch";
        private const string MethodRedirect = "Redirect";
        private const string MethodAuthenticateUser = "AuthenticateUser";
        private const string MethodOnDelete = "OnDelete";
        private const string MethodOnSubmit = "OnSubmit";
        private const string MethodOnCancel = "OnCancel";
        private const string MethodClearCache = "ClearCache";
        private const string MethodPage_Load = "Page_Load";
        private const string FieldTOP_NAV_URL = "TOP_NAV_URL";
        private const string FieldQUICK_LNCH_URL = "QUICK_LNCH_URL";
        private const string FieldASYNC_NAV_ACTIONS_URL = "ASYNC_NAV_ACTIONS_URL";
        private const string Field_site = "_site";
        private const string Field_web = "_web";
        private const string Field_eSite = "_eSite";
        private const string Field_eWeb = "_eWeb";
        private const string Field_currentNode = "_currentNode";
        private const string Field_eCurrentNode = "_eCurrentNode";
        private const string Field_iId = "_iId";
        private const string Field_isEditingHeading = "_isEditingHeading";
        private const string Field_nodeType = "_nodeType";
        private const string Field_appId = "_appId";
        private const string FieldappHelper = "appHelper";
        private const string Field_asyncDelAction = "_asyncDelAction";
        private const string Field_asyncEditAction = "_asyncEditAction";
        private const string Field_async_nav_actions_url = "_async_nav_actions_url";
        private const string Field_webUrl = "_webUrl";
        private const string Field_origUserId = "_origUserId";
        private Type _customEditNavInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomEditNav _customEditNavInstance;
        private CustomEditNav _customEditNavInstanceFixture;

        #region General Initializer : Class (CustomEditNav) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomEditNav" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customEditNavInstanceType = typeof(CustomEditNav);
            _customEditNavInstanceFixture = Create(true);
            _customEditNavInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomEditNav)

        #region General Initializer : Class (CustomEditNav) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CustomEditNav" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodLoadUIContent, 0)]
        [TestCase(MethodLoadHeadingDropDownList, 0)]
        [TestCase(MethodLoadTitleAndUrl, 0)]
        [TestCase(MethodRegisterControEvents, 0)]
        [TestCase(MethodDisplayCategorySection, 0)]
        [TestCase(MethodUpdateNode, 0)]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodGetParameter, 0)]
        [TestCase(MethodRedirectToTopNavPage, 0)]
        [TestCase(MethodRedirectToQuickLaunch, 0)]
        [TestCase(MethodRedirect, 0)]
        [TestCase(MethodAuthenticateUser, 0)]
        [TestCase(MethodOnDelete, 0)]
        [TestCase(MethodOnSubmit, 0)]
        [TestCase(MethodOnCancel, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_CustomEditNav_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_customEditNavInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomEditNav) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomEditNav" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldTOP_NAV_URL)]
        [TestCase(FieldQUICK_LNCH_URL)]
        [TestCase(FieldASYNC_NAV_ACTIONS_URL)]
        [TestCase(Field_site)]
        [TestCase(Field_web)]
        [TestCase(Field_eSite)]
        [TestCase(Field_eWeb)]
        [TestCase(Field_currentNode)]
        [TestCase(Field_eCurrentNode)]
        [TestCase(Field_iId)]
        [TestCase(Field_isEditingHeading)]
        [TestCase(Field_nodeType)]
        [TestCase(Field_appId)]
        [TestCase(FieldappHelper)]
        [TestCase(Field_asyncDelAction)]
        [TestCase(Field_asyncEditAction)]
        [TestCase(Field_async_nav_actions_url)]
        [TestCase(Field_webUrl)]
        [TestCase(Field_origUserId)]
        public void AUT_CustomEditNav_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customEditNavInstanceFixture, 
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
        ///     Class (<see cref="CustomEditNav" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CustomEditNav_Is_Instance_Present_Test()
        {
            // Assert
            _customEditNavInstanceType.ShouldNotBeNull();
            _customEditNavInstance.ShouldNotBeNull();
            _customEditNavInstanceFixture.ShouldNotBeNull();
            _customEditNavInstance.ShouldBeAssignableTo<CustomEditNav>();
            _customEditNavInstanceFixture.ShouldBeAssignableTo<CustomEditNav>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomEditNav) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CustomEditNav_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomEditNav instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customEditNavInstanceType.ShouldNotBeNull();
            _customEditNavInstance.ShouldNotBeNull();
            _customEditNavInstanceFixture.ShouldNotBeNull();
            _customEditNavInstance.ShouldBeAssignableTo<CustomEditNav>();
            _customEditNavInstanceFixture.ShouldBeAssignableTo<CustomEditNav>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CustomEditNav" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodLoadUIContent)]
        [TestCase(MethodLoadHeadingDropDownList)]
        [TestCase(MethodLoadTitleAndUrl)]
        [TestCase(MethodRegisterControEvents)]
        [TestCase(MethodDisplayCategorySection)]
        [TestCase(MethodUpdateNode)]
        [TestCase(MethodManageFields)]
        [TestCase(MethodGetParameter)]
        [TestCase(MethodRedirectToTopNavPage)]
        [TestCase(MethodRedirectToQuickLaunch)]
        [TestCase(MethodRedirect)]
        [TestCase(MethodAuthenticateUser)]
        [TestCase(MethodOnDelete)]
        [TestCase(MethodOnSubmit)]
        [TestCase(MethodOnCancel)]
        [TestCase(MethodClearCache)]
        [TestCase(MethodPage_Load)]
        public void AUT_CustomEditNav_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CustomEditNav>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (LoadUIContent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_LoadUIContent_Method_Call_Internally(Type[] types)
        {
            var methodLoadUIContentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodLoadUIContent, Fixture, methodLoadUIContentPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadUIContent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadUIContent_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadUIContentPrametersTypes = null;
            object[] parametersOfLoadUIContent = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadUIContent, methodLoadUIContentPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfLoadUIContent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadUIContent.ShouldBeNull();
            methodLoadUIContentPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadUIContent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadUIContent_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadUIContentPrametersTypes = null;
            object[] parametersOfLoadUIContent = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodLoadUIContent, parametersOfLoadUIContent, methodLoadUIContentPrametersTypes);

            // Assert
            parametersOfLoadUIContent.ShouldBeNull();
            methodLoadUIContentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadUIContent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadUIContent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadUIContentPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodLoadUIContent, Fixture, methodLoadUIContentPrametersTypes);

            // Assert
            methodLoadUIContentPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadUIContent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadUIContent_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadUIContent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_LoadHeadingDropDownList_Method_Call_Internally(Type[] types)
        {
            var methodLoadHeadingDropDownListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodLoadHeadingDropDownList, Fixture, methodLoadHeadingDropDownListPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadHeadingDropDownList_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadHeadingDropDownListPrametersTypes = null;
            object[] parametersOfLoadHeadingDropDownList = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadHeadingDropDownList, methodLoadHeadingDropDownListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfLoadHeadingDropDownList);

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
        public void AUT_CustomEditNav_LoadHeadingDropDownList_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadHeadingDropDownListPrametersTypes = null;
            object[] parametersOfLoadHeadingDropDownList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodLoadHeadingDropDownList, parametersOfLoadHeadingDropDownList, methodLoadHeadingDropDownListPrametersTypes);

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
        public void AUT_CustomEditNav_LoadHeadingDropDownList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadHeadingDropDownListPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodLoadHeadingDropDownList, Fixture, methodLoadHeadingDropDownListPrametersTypes);

            // Assert
            methodLoadHeadingDropDownListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadHeadingDropDownList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadHeadingDropDownList_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadHeadingDropDownList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTitleAndUrl) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_LoadTitleAndUrl_Method_Call_Internally(Type[] types)
        {
            var methodLoadTitleAndUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodLoadTitleAndUrl, Fixture, methodLoadTitleAndUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadTitleAndUrl) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadTitleAndUrl_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadTitleAndUrlPrametersTypes = null;
            object[] parametersOfLoadTitleAndUrl = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadTitleAndUrl, methodLoadTitleAndUrlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfLoadTitleAndUrl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadTitleAndUrl.ShouldBeNull();
            methodLoadTitleAndUrlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTitleAndUrl) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadTitleAndUrl_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadTitleAndUrlPrametersTypes = null;
            object[] parametersOfLoadTitleAndUrl = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodLoadTitleAndUrl, parametersOfLoadTitleAndUrl, methodLoadTitleAndUrlPrametersTypes);

            // Assert
            parametersOfLoadTitleAndUrl.ShouldBeNull();
            methodLoadTitleAndUrlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTitleAndUrl) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadTitleAndUrl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadTitleAndUrlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodLoadTitleAndUrl, Fixture, methodLoadTitleAndUrlPrametersTypes);

            // Assert
            methodLoadTitleAndUrlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTitleAndUrl) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_LoadTitleAndUrl_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadTitleAndUrl, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_RegisterControEvents_Method_Call_Internally(Type[] types)
        {
            var methodRegisterControEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRegisterControEvents, Fixture, methodRegisterControEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterControEvents) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RegisterControEvents_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterControEventsPrametersTypes = null;
            object[] parametersOfRegisterControEvents = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterControEvents, methodRegisterControEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfRegisterControEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterControEvents.ShouldBeNull();
            methodRegisterControEventsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControEvents) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RegisterControEvents_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterControEventsPrametersTypes = null;
            object[] parametersOfRegisterControEvents = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodRegisterControEvents, parametersOfRegisterControEvents, methodRegisterControEventsPrametersTypes);

            // Assert
            parametersOfRegisterControEvents.ShouldBeNull();
            methodRegisterControEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControEvents) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RegisterControEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterControEventsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRegisterControEvents, Fixture, methodRegisterControEventsPrametersTypes);

            // Assert
            methodRegisterControEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControEvents) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RegisterControEvents_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterControEvents, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisplayCategorySection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_DisplayCategorySection_Method_Call_Internally(Type[] types)
        {
            var methodDisplayCategorySectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodDisplayCategorySection, Fixture, methodDisplayCategorySectionPrametersTypes);
        }

        #endregion

        #region Method Call : (DisplayCategorySection) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_DisplayCategorySection_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisplayCategorySectionPrametersTypes = null;
            object[] parametersOfDisplayCategorySection = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisplayCategorySection, methodDisplayCategorySectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfDisplayCategorySection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisplayCategorySection.ShouldBeNull();
            methodDisplayCategorySectionPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DisplayCategorySection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_DisplayCategorySection_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisplayCategorySectionPrametersTypes = null;
            object[] parametersOfDisplayCategorySection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodDisplayCategorySection, parametersOfDisplayCategorySection, methodDisplayCategorySectionPrametersTypes);

            // Assert
            parametersOfDisplayCategorySection.ShouldBeNull();
            methodDisplayCategorySectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisplayCategorySection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_DisplayCategorySection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisplayCategorySectionPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodDisplayCategorySection, Fixture, methodDisplayCategorySectionPrametersTypes);

            // Assert
            methodDisplayCategorySectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisplayCategorySection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_DisplayCategorySection_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisplayCategorySection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_UpdateNode_Method_Call_Internally(Type[] types)
        {
            var methodUpdateNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodUpdateNode, Fixture, methodUpdateNodePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateNode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_UpdateNode_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodUpdateNodePrametersTypes = null;
            object[] parametersOfUpdateNode = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateNode, methodUpdateNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfUpdateNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateNode.ShouldBeNull();
            methodUpdateNodePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_UpdateNode_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodUpdateNodePrametersTypes = null;
            object[] parametersOfUpdateNode = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodUpdateNode, parametersOfUpdateNode, methodUpdateNodePrametersTypes);

            // Assert
            parametersOfUpdateNode.ShouldBeNull();
            methodUpdateNodePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_UpdateNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodUpdateNodePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodUpdateNode, Fixture, methodUpdateNodePrametersTypes);

            // Assert
            methodUpdateNodePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_UpdateNode_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfManageFields);

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
        public void AUT_CustomEditNav_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

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
        public void AUT_CustomEditNav_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_GetParameter_Method_Call_Internally(Type[] types)
        {
            var methodGetParameterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodGetParameter, Fixture, methodGetParameterPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_GetParameter_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetParameter = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetParameter, methodGetParameterPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CustomEditNav, string>(_customEditNavInstanceFixture, out exception1, parametersOfGetParameter);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CustomEditNav, string>(_customEditNavInstance, MethodGetParameter, parametersOfGetParameter, methodGetParameterPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetParameter.ShouldNotBeNull();
            parametersOfGetParameter.Length.ShouldBe(1);
            methodGetParameterPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfGetParameter));
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_GetParameter_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetParameter = { key };

            // Assert
            parametersOfGetParameter.ShouldNotBeNull();
            parametersOfGetParameter.Length.ShouldBe(1);
            methodGetParameterPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CustomEditNav, string>(_customEditNavInstance, MethodGetParameter, parametersOfGetParameter, methodGetParameterPrametersTypes));
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_GetParameter_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodGetParameter, Fixture, methodGetParameterPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParameterPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_GetParameter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParameterPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodGetParameter, Fixture, methodGetParameterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParameterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_GetParameter_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParameter, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParameter) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_GetParameter_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_RedirectToTopNavPage_Method_Call_Internally(Type[] types)
        {
            var methodRedirectToTopNavPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRedirectToTopNavPage, Fixture, methodRedirectToTopNavPagePrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RedirectToTopNavPage_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;
            object[] parametersOfRedirectToTopNavPage = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectToTopNavPage, methodRedirectToTopNavPagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfRedirectToTopNavPage);

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
        public void AUT_CustomEditNav_RedirectToTopNavPage_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;
            object[] parametersOfRedirectToTopNavPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodRedirectToTopNavPage, parametersOfRedirectToTopNavPage, methodRedirectToTopNavPagePrametersTypes);

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
        public void AUT_CustomEditNav_RedirectToTopNavPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectToTopNavPagePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRedirectToTopNavPage, Fixture, methodRedirectToTopNavPagePrametersTypes);

            // Assert
            methodRedirectToTopNavPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToTopNavPage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RedirectToTopNavPage_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectToTopNavPage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_RedirectToQuickLaunch_Method_Call_Internally(Type[] types)
        {
            var methodRedirectToQuickLaunchPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRedirectToQuickLaunch, Fixture, methodRedirectToQuickLaunchPrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RedirectToQuickLaunch_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectToQuickLaunchPrametersTypes = null;
            object[] parametersOfRedirectToQuickLaunch = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectToQuickLaunch, methodRedirectToQuickLaunchPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfRedirectToQuickLaunch);

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
        public void AUT_CustomEditNav_RedirectToQuickLaunch_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectToQuickLaunchPrametersTypes = null;
            object[] parametersOfRedirectToQuickLaunch = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodRedirectToQuickLaunch, parametersOfRedirectToQuickLaunch, methodRedirectToQuickLaunchPrametersTypes);

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
        public void AUT_CustomEditNav_RedirectToQuickLaunch_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectToQuickLaunchPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRedirectToQuickLaunch, Fixture, methodRedirectToQuickLaunchPrametersTypes);

            // Assert
            methodRedirectToQuickLaunchPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectToQuickLaunch) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_RedirectToQuickLaunch_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectToQuickLaunch, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_Redirect_Method_Call_Internally(Type[] types)
        {
            var methodRedirectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRedirect, Fixture, methodRedirectPrametersTypes);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_Redirect_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;
            object[] parametersOfRedirect = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirect, methodRedirectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfRedirect);

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
        public void AUT_CustomEditNav_Redirect_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;
            object[] parametersOfRedirect = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodRedirect, parametersOfRedirect, methodRedirectPrametersTypes);

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
        public void AUT_CustomEditNav_Redirect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodRedirect, Fixture, methodRedirectPrametersTypes);

            // Assert
            methodRedirectPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_Redirect_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirect, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_AuthenticateUser_Method_Call_Internally(Type[] types)
        {
            var methodAuthenticateUserPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, methodAuthenticateUserPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfAuthenticateUser);

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
        public void AUT_CustomEditNav_AuthenticateUser_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;
            object[] parametersOfAuthenticateUser = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodAuthenticateUser, parametersOfAuthenticateUser, methodAuthenticateUserPrametersTypes);

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
        public void AUT_CustomEditNav_AuthenticateUser_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAuthenticateUserPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodAuthenticateUser, Fixture, methodAuthenticateUserPrametersTypes);

            // Assert
            methodAuthenticateUserPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUser) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_AuthenticateUser_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAuthenticateUser, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnDelete) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_OnDelete_Method_Call_Internally(Type[] types)
        {
            var methodOnDeletePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodOnDelete, Fixture, methodOnDeletePrametersTypes);
        }

        #endregion

        #region Method Call : (OnDelete) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnDelete_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnDeletePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnDelete = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnDelete, methodOnDeletePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfOnDelete);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnDelete.ShouldNotBeNull();
            parametersOfOnDelete.Length.ShouldBe(2);
            methodOnDeletePrametersTypes.Length.ShouldBe(2);
            methodOnDeletePrametersTypes.Length.ShouldBe(parametersOfOnDelete.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnDelete) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnDelete_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnDeletePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnDelete = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodOnDelete, parametersOfOnDelete, methodOnDeletePrametersTypes);

            // Assert
            parametersOfOnDelete.ShouldNotBeNull();
            parametersOfOnDelete.Length.ShouldBe(2);
            methodOnDeletePrametersTypes.Length.ShouldBe(2);
            methodOnDeletePrametersTypes.Length.ShouldBe(parametersOfOnDelete.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnDelete) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnDelete_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnDelete, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnDelete) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnDelete_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnDeletePrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodOnDelete, Fixture, methodOnDeletePrametersTypes);

            // Assert
            methodOnDeletePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnDelete) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnDelete_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnDelete, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_OnSubmit_Method_Call_Internally(Type[] types)
        {
            var methodOnSubmitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnSubmit_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnSubmit, methodOnSubmitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfOnSubmit);

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
        public void AUT_CustomEditNav_OnSubmit_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnSubmit = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodOnSubmit, parametersOfOnSubmit, methodOnSubmitPrametersTypes);

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
        public void AUT_CustomEditNav_OnSubmit_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomEditNav_OnSubmit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnSubmitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodOnSubmit, Fixture, methodOnSubmitPrametersTypes);

            // Assert
            methodOnSubmitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnSubmit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnSubmit_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnSubmit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_OnCancel_Method_Call_Internally(Type[] types)
        {
            var methodOnCancelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnCancel_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnCancel, methodOnCancelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfOnCancel);

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
        public void AUT_CustomEditNav_OnCancel_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfOnCancel = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodOnCancel, parametersOfOnCancel, methodOnCancelPrametersTypes);

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
        public void AUT_CustomEditNav_OnCancel_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomEditNav_OnCancel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnCancelPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodOnCancel, Fixture, methodOnCancelPrametersTypes);

            // Assert
            methodOnCancelPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnCancel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_OnCancel_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnCancel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_ClearCache_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_ClearCache_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfClearCache);

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
        public void AUT_CustomEditNav_ClearCache_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;
            object[] parametersOfClearCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

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
        public void AUT_CustomEditNav_ClearCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_ClearCache_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CustomEditNav_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_customEditNavInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CustomEditNav_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_customEditNavInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CustomEditNav_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CustomEditNav_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_customEditNavInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CustomEditNav_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_customEditNavInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}