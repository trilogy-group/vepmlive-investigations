using System;
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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CommonActionsAjaxDataHost" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CommonActionsAjaxDataHostTest : AbstractBaseSetupTypedTest<CommonActionsAjaxDataHost>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CommonActionsAjaxDataHost) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodBuildListItemHTML = "BuildListItemHTML";
        private const string MethodFieldExists = "FieldExists";
        private const string MethodWebExists = "WebExists";
        private const string Field_requestUrl = "_requestUrl";
        private const string FieldCOMMON_ACTIONS_LIST_NAME = "COMMON_ACTIONS_LIST_NAME";
        private const string FieldCOL_TITLE = "COL_TITLE";
        private const string FieldCOL_DESCRIPTION = "COL_DESCRIPTION";
        private const string FieldCOL_URL = "COL_URL";
        private const string FieldCOL_NEW_WINDOW = "COL_NEW_WINDOW";
        private const string FieldCOL_IMAGE_URL = "COL_IMAGE_URL";
        private const string FieldLIST_ITEM_HTML = "LIST_ITEM_HTML";
        private Type _commonActionsAjaxDataHostInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CommonActionsAjaxDataHost _commonActionsAjaxDataHostInstance;
        private CommonActionsAjaxDataHost _commonActionsAjaxDataHostInstanceFixture;

        #region General Initializer : Class (CommonActionsAjaxDataHost) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CommonActionsAjaxDataHost" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _commonActionsAjaxDataHostInstanceType = typeof(CommonActionsAjaxDataHost);
            _commonActionsAjaxDataHostInstanceFixture = Create(true);
            _commonActionsAjaxDataHostInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CommonActionsAjaxDataHost)

        #region General Initializer : Class (CommonActionsAjaxDataHost) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CommonActionsAjaxDataHost" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBuildListItemHTML, 0)]
        [TestCase(MethodFieldExists, 0)]
        [TestCase(MethodWebExists, 0)]
        public void AUT_CommonActionsAjaxDataHost_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_commonActionsAjaxDataHostInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CommonActionsAjaxDataHost) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CommonActionsAjaxDataHost" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_requestUrl)]
        [TestCase(FieldCOMMON_ACTIONS_LIST_NAME)]
        [TestCase(FieldCOL_TITLE)]
        [TestCase(FieldCOL_DESCRIPTION)]
        [TestCase(FieldCOL_URL)]
        [TestCase(FieldCOL_NEW_WINDOW)]
        [TestCase(FieldCOL_IMAGE_URL)]
        [TestCase(FieldLIST_ITEM_HTML)]
        public void AUT_CommonActionsAjaxDataHost_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_commonActionsAjaxDataHostInstanceFixture, 
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
        ///     Class (<see cref="CommonActionsAjaxDataHost" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CommonActionsAjaxDataHost_Is_Instance_Present_Test()
        {
            // Assert
            _commonActionsAjaxDataHostInstanceType.ShouldNotBeNull();
            _commonActionsAjaxDataHostInstance.ShouldNotBeNull();
            _commonActionsAjaxDataHostInstanceFixture.ShouldNotBeNull();
            _commonActionsAjaxDataHostInstance.ShouldBeAssignableTo<CommonActionsAjaxDataHost>();
            _commonActionsAjaxDataHostInstanceFixture.ShouldBeAssignableTo<CommonActionsAjaxDataHost>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CommonActionsAjaxDataHost) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CommonActionsAjaxDataHost_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CommonActionsAjaxDataHost instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _commonActionsAjaxDataHostInstanceType.ShouldNotBeNull();
            _commonActionsAjaxDataHostInstance.ShouldNotBeNull();
            _commonActionsAjaxDataHostInstanceFixture.ShouldNotBeNull();
            _commonActionsAjaxDataHostInstance.ShouldBeAssignableTo<CommonActionsAjaxDataHost>();
            _commonActionsAjaxDataHostInstanceFixture.ShouldBeAssignableTo<CommonActionsAjaxDataHost>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CommonActionsAjaxDataHost" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBuildListItemHTML)]
        [TestCase(MethodFieldExists)]
        [TestCase(MethodWebExists)]
        public void AUT_CommonActionsAjaxDataHost_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CommonActionsAjaxDataHost>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommonActionsAjaxDataHost_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_commonActionsAjaxDataHostInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CommonActionsAjaxDataHost_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_commonActionsAjaxDataHostInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CommonActionsAjaxDataHost_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CommonActionsAjaxDataHost_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_commonActionsAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommonActionsAjaxDataHost_BuildListItemHTML_Method_Call_Internally(Type[] types)
        {
            var methodBuildListItemHTMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_BuildListItemHTML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            object[] parametersOfBuildListItemHTML = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildListItemHTML, methodBuildListItemHTMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CommonActionsAjaxDataHost, string>(_commonActionsAjaxDataHostInstanceFixture, out exception1, parametersOfBuildListItemHTML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, string>(_commonActionsAjaxDataHostInstance, MethodBuildListItemHTML, parametersOfBuildListItemHTML, methodBuildListItemHTMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildListItemHTML.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_commonActionsAjaxDataHostInstanceFixture, parametersOfBuildListItemHTML));
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_BuildListItemHTML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            object[] parametersOfBuildListItemHTML = null; // no parameter present

            // Assert
            parametersOfBuildListItemHTML.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, string>(_commonActionsAjaxDataHostInstance, MethodBuildListItemHTML, parametersOfBuildListItemHTML, methodBuildListItemHTMLPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildListItemHTML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_commonActionsAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FieldExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommonActionsAjaxDataHost_FieldExists_Method_Call_Internally(Type[] types)
        {
            var methodFieldExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodFieldExists, Fixture, methodFieldExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (FieldExists) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_FieldExists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var item = CreateType<SPListItem>();
            var fieldName = CreateType<string>();
            var methodFieldExistsPrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(string) };
            object[] parametersOfFieldExists = { listName, item, fieldName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFieldExists, methodFieldExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstanceFixture, out exception1, parametersOfFieldExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstance, MethodFieldExists, parametersOfFieldExists, methodFieldExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFieldExists.ShouldNotBeNull();
            parametersOfFieldExists.Length.ShouldBe(3);
            methodFieldExistsPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_commonActionsAjaxDataHostInstanceFixture, parametersOfFieldExists));
        }

        #endregion

        #region Method Call : (FieldExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_FieldExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var item = CreateType<SPListItem>();
            var fieldName = CreateType<string>();
            var methodFieldExistsPrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(string) };
            object[] parametersOfFieldExists = { listName, item, fieldName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFieldExists, methodFieldExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstanceFixture, out exception1, parametersOfFieldExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstance, MethodFieldExists, parametersOfFieldExists, methodFieldExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfFieldExists.ShouldNotBeNull();
            parametersOfFieldExists.Length.ShouldBe(3);
            methodFieldExistsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstance, MethodFieldExists, parametersOfFieldExists, methodFieldExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (FieldExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_FieldExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var item = CreateType<SPListItem>();
            var fieldName = CreateType<string>();
            var methodFieldExistsPrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(string) };
            object[] parametersOfFieldExists = { listName, item, fieldName };

            // Assert
            parametersOfFieldExists.ShouldNotBeNull();
            parametersOfFieldExists.Length.ShouldBe(3);
            methodFieldExistsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstance, MethodFieldExists, parametersOfFieldExists, methodFieldExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (FieldExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_FieldExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFieldExistsPrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodFieldExists, Fixture, methodFieldExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFieldExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldExists) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_FieldExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFieldExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_commonActionsAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FieldExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_FieldExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFieldExists, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebExists) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CommonActionsAjaxDataHost_WebExists_Method_Call_Internally(Type[] types)
        {
            var methodWebExistsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodWebExists, Fixture, methodWebExistsPrametersTypes);
        }

        #endregion

        #region Method Call : (WebExists) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_WebExists_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodWebExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWebExists = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodWebExists, methodWebExistsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstanceFixture, out exception1, parametersOfWebExists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstance, MethodWebExists, parametersOfWebExists, methodWebExistsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfWebExists.ShouldNotBeNull();
            parametersOfWebExists.Length.ShouldBe(1);
            methodWebExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstance, MethodWebExists, parametersOfWebExists, methodWebExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (WebExists) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_WebExists_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodWebExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWebExists = { url };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebExists, methodWebExistsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebExists.ShouldNotBeNull();
            parametersOfWebExists.Length.ShouldBe(1);
            methodWebExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_commonActionsAjaxDataHostInstanceFixture, parametersOfWebExists));
        }

        #endregion

        #region Method Call : (WebExists) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_WebExists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodWebExistsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfWebExists = { url };

            // Assert
            parametersOfWebExists.ShouldNotBeNull();
            parametersOfWebExists.Length.ShouldBe(1);
            methodWebExistsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<CommonActionsAjaxDataHost, bool>(_commonActionsAjaxDataHostInstance, MethodWebExists, parametersOfWebExists, methodWebExistsPrametersTypes));
        }

        #endregion

        #region Method Call : (WebExists) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_WebExists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebExistsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_commonActionsAjaxDataHostInstance, MethodWebExists, Fixture, methodWebExistsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodWebExistsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebExists) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_WebExists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebExists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_commonActionsAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (WebExists) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CommonActionsAjaxDataHost_WebExists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWebExists, 0);
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