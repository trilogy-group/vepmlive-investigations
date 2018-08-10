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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ChangeAppAjaxDataHost" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class ChangeAppAjaxDataHostTest : AbstractBaseSetupTypedTest<ChangeAppAjaxDataHost>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChangeAppAjaxDataHost) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodBuildListItemHTML = "BuildListItemHTML";
        private const string MethodBuildListSection = "BuildListSection";
        private const string MethodisCurrentUserRolesGreaterOrEqualThan = "isCurrentUserRolesGreaterOrEqualThan";
        private const string MethodGetCommOnClick = "GetCommOnClick";
        private const string MethodConstructOnClick = "ConstructOnClick";
        private const string MethodTryListSettingByIndex = "TryListSettingByIndex";
        private const string MethodGetItemFieldValueInString = "GetItemFieldValueInString";
        private const string MethodGetUrlFieldValueInString = "GetUrlFieldValueInString";
        private const string Field_requestUrl = "_requestUrl";
        private const string Field_btnChangeAppCurrentAppId = "_btnChangeAppCurrentAppId";
        private const string FieldLIST_ITEM_HTML = "LIST_ITEM_HTML";
        private const string FieldLIST_ITEM_HTML_NEW_WIN = "LIST_ITEM_HTML_NEW_WIN";
        private Type _changeAppAjaxDataHostInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChangeAppAjaxDataHost _changeAppAjaxDataHostInstance;
        private ChangeAppAjaxDataHost _changeAppAjaxDataHostInstanceFixture;

        #region General Initializer : Class (ChangeAppAjaxDataHost) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChangeAppAjaxDataHost" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _changeAppAjaxDataHostInstanceType = typeof(ChangeAppAjaxDataHost);
            _changeAppAjaxDataHostInstanceFixture = Create(true);
            _changeAppAjaxDataHostInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChangeAppAjaxDataHost)

        #region General Initializer : Class (ChangeAppAjaxDataHost) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ChangeAppAjaxDataHost" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBuildListItemHTML, 0)]
        [TestCase(MethodBuildListSection, 0)]
        [TestCase(MethodisCurrentUserRolesGreaterOrEqualThan, 0)]
        [TestCase(MethodGetCommOnClick, 0)]
        [TestCase(MethodConstructOnClick, 0)]
        [TestCase(MethodTryListSettingByIndex, 0)]
        [TestCase(MethodGetItemFieldValueInString, 0)]
        [TestCase(MethodGetUrlFieldValueInString, 0)]
        public void AUT_ChangeAppAjaxDataHost_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_changeAppAjaxDataHostInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChangeAppAjaxDataHost) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChangeAppAjaxDataHost" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_requestUrl)]
        [TestCase(Field_btnChangeAppCurrentAppId)]
        [TestCase(FieldLIST_ITEM_HTML)]
        [TestCase(FieldLIST_ITEM_HTML_NEW_WIN)]
        public void AUT_ChangeAppAjaxDataHost_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_changeAppAjaxDataHostInstanceFixture, 
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
        ///     Class (<see cref="ChangeAppAjaxDataHost" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ChangeAppAjaxDataHost_Is_Instance_Present_Test()
        {
            // Assert
            _changeAppAjaxDataHostInstanceType.ShouldNotBeNull();
            _changeAppAjaxDataHostInstance.ShouldNotBeNull();
            _changeAppAjaxDataHostInstanceFixture.ShouldNotBeNull();
            _changeAppAjaxDataHostInstance.ShouldBeAssignableTo<ChangeAppAjaxDataHost>();
            _changeAppAjaxDataHostInstanceFixture.ShouldBeAssignableTo<ChangeAppAjaxDataHost>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChangeAppAjaxDataHost) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ChangeAppAjaxDataHost_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChangeAppAjaxDataHost instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _changeAppAjaxDataHostInstanceType.ShouldNotBeNull();
            _changeAppAjaxDataHostInstance.ShouldNotBeNull();
            _changeAppAjaxDataHostInstanceFixture.ShouldNotBeNull();
            _changeAppAjaxDataHostInstance.ShouldBeAssignableTo<ChangeAppAjaxDataHost>();
            _changeAppAjaxDataHostInstanceFixture.ShouldBeAssignableTo<ChangeAppAjaxDataHost>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ChangeAppAjaxDataHost" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBuildListItemHTML)]
        [TestCase(MethodBuildListSection)]
        [TestCase(MethodisCurrentUserRolesGreaterOrEqualThan)]
        [TestCase(MethodGetCommOnClick)]
        [TestCase(MethodConstructOnClick)]
        [TestCase(MethodTryListSettingByIndex)]
        [TestCase(MethodGetItemFieldValueInString)]
        [TestCase(MethodGetUrlFieldValueInString)]
        public void AUT_ChangeAppAjaxDataHost_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ChangeAppAjaxDataHost>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfPage_Load);

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
        public void AUT_ChangeAppAjaxDataHost_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_changeAppAjaxDataHostInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_ChangeAppAjaxDataHost_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ChangeAppAjaxDataHost_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_BuildListItemHTML_Method_Call_Internally(Type[] types)
        {
            var methodBuildListItemHTMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListItemHTML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            object[] parametersOfBuildListItemHTML = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildListItemHTML, methodBuildListItemHTMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstanceFixture, out exception1, parametersOfBuildListItemHTML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodBuildListItemHTML, parametersOfBuildListItemHTML, methodBuildListItemHTMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildListItemHTML.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfBuildListItemHTML));
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListItemHTML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            object[] parametersOfBuildListItemHTML = null; // no parameter present

            // Assert
            parametersOfBuildListItemHTML.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodBuildListItemHTML, parametersOfBuildListItemHTML, methodBuildListItemHTMLPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildListItemHTMLPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodBuildListItemHTML, Fixture, methodBuildListItemHTMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildListItemHTMLPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListItemHTML) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListItemHTML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildListItemHTML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_BuildListSection_Method_Call_Internally(Type[] types)
        {
            var methodBuildListSectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodBuildListSection, Fixture, methodBuildListSectionPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListSection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;
            object[] parametersOfBuildListSection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildListSection, methodBuildListSectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstanceFixture, out exception1, parametersOfBuildListSection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodBuildListSection, parametersOfBuildListSection, methodBuildListSectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildListSection.ShouldBeNull();
            methodBuildListSectionPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfBuildListSection));
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListSection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;
            object[] parametersOfBuildListSection = null; // no parameter present

            // Assert
            parametersOfBuildListSection.ShouldBeNull();
            methodBuildListSectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodBuildListSection, parametersOfBuildListSection, methodBuildListSectionPrametersTypes));
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListSection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodBuildListSection, Fixture, methodBuildListSectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildListSectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListSection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildListSectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodBuildListSection, Fixture, methodBuildListSectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildListSectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildListSection) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_BuildListSection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildListSection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (isCurrentUserRolesGreaterOrEqualThan) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_isCurrentUserRolesGreaterOrEqualThan_Method_Call_Internally(Type[] types)
        {
            var methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodisCurrentUserRolesGreaterOrEqualThan, Fixture, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes);
        }

        #endregion

        #region Method Call : (isCurrentUserRolesGreaterOrEqualThan) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_isCurrentUserRolesGreaterOrEqualThan_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var role = CreateType<string>();
            var methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisCurrentUserRolesGreaterOrEqualThan = { role };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodisCurrentUserRolesGreaterOrEqualThan, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstanceFixture, out exception1, parametersOfisCurrentUserRolesGreaterOrEqualThan);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstance, MethodisCurrentUserRolesGreaterOrEqualThan, parametersOfisCurrentUserRolesGreaterOrEqualThan, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfisCurrentUserRolesGreaterOrEqualThan.ShouldNotBeNull();
            parametersOfisCurrentUserRolesGreaterOrEqualThan.Length.ShouldBe(1);
            methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfisCurrentUserRolesGreaterOrEqualThan));
        }

        #endregion

        #region Method Call : (isCurrentUserRolesGreaterOrEqualThan) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_isCurrentUserRolesGreaterOrEqualThan_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var role = CreateType<string>();
            var methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisCurrentUserRolesGreaterOrEqualThan = { role };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodisCurrentUserRolesGreaterOrEqualThan, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstanceFixture, out exception1, parametersOfisCurrentUserRolesGreaterOrEqualThan);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstance, MethodisCurrentUserRolesGreaterOrEqualThan, parametersOfisCurrentUserRolesGreaterOrEqualThan, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfisCurrentUserRolesGreaterOrEqualThan.ShouldNotBeNull();
            parametersOfisCurrentUserRolesGreaterOrEqualThan.Length.ShouldBe(1);
            methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstance, MethodisCurrentUserRolesGreaterOrEqualThan, parametersOfisCurrentUserRolesGreaterOrEqualThan, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes));
        }

        #endregion

        #region Method Call : (isCurrentUserRolesGreaterOrEqualThan) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_isCurrentUserRolesGreaterOrEqualThan_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var role = CreateType<string>();
            var methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisCurrentUserRolesGreaterOrEqualThan = { role };

            // Assert
            parametersOfisCurrentUserRolesGreaterOrEqualThan.ShouldNotBeNull();
            parametersOfisCurrentUserRolesGreaterOrEqualThan.Length.ShouldBe(1);
            methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstance, MethodisCurrentUserRolesGreaterOrEqualThan, parametersOfisCurrentUserRolesGreaterOrEqualThan, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes));
        }

        #endregion

        #region Method Call : (isCurrentUserRolesGreaterOrEqualThan) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_isCurrentUserRolesGreaterOrEqualThan_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodisCurrentUserRolesGreaterOrEqualThan, Fixture, methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisCurrentUserRolesGreaterOrEqualThanPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isCurrentUserRolesGreaterOrEqualThan) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_isCurrentUserRolesGreaterOrEqualThan_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisCurrentUserRolesGreaterOrEqualThan, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (isCurrentUserRolesGreaterOrEqualThan) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_isCurrentUserRolesGreaterOrEqualThan_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisCurrentUserRolesGreaterOrEqualThan, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCommOnClick) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_GetCommOnClick_Method_Call_Internally(Type[] types)
        {
            var methodGetCommOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetCommOnClick, Fixture, methodGetCommOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCommOnClick) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetCommOnClick_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCommOnClickPrametersTypes = null;
            object[] parametersOfGetCommOnClick = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCommOnClick, methodGetCommOnClickPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstanceFixture, out exception1, parametersOfGetCommOnClick);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodGetCommOnClick, parametersOfGetCommOnClick, methodGetCommOnClickPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCommOnClick.ShouldBeNull();
            methodGetCommOnClickPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfGetCommOnClick));
        }

        #endregion

        #region Method Call : (GetCommOnClick) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetCommOnClick_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCommOnClickPrametersTypes = null;
            object[] parametersOfGetCommOnClick = null; // no parameter present

            // Assert
            parametersOfGetCommOnClick.ShouldBeNull();
            methodGetCommOnClickPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodGetCommOnClick, parametersOfGetCommOnClick, methodGetCommOnClickPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCommOnClick) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetCommOnClick_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetCommOnClickPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetCommOnClick, Fixture, methodGetCommOnClickPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCommOnClickPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCommOnClick) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetCommOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCommOnClickPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetCommOnClick, Fixture, methodGetCommOnClickPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCommOnClickPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCommOnClick) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetCommOnClick_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCommOnClick, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ConstructOnClick) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_ConstructOnClick_Method_Call_Internally(Type[] types)
        {
            var methodConstructOnClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodConstructOnClick, Fixture, methodConstructOnClickPrametersTypes);
        }

        #endregion

        #region Method Call : (ConstructOnClick) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_ConstructOnClick_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var homePageUrl = CreateType<string>();
            var itemId = CreateType<string>();
            var methodConstructOnClickPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfConstructOnClick = { homePageUrl, itemId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConstructOnClick, methodConstructOnClickPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConstructOnClick.ShouldNotBeNull();
            parametersOfConstructOnClick.Length.ShouldBe(2);
            methodConstructOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfConstructOnClick));
        }

        #endregion

        #region Method Call : (ConstructOnClick) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_ConstructOnClick_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var homePageUrl = CreateType<string>();
            var itemId = CreateType<string>();
            var methodConstructOnClickPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfConstructOnClick = { homePageUrl, itemId };

            // Assert
            parametersOfConstructOnClick.ShouldNotBeNull();
            parametersOfConstructOnClick.Length.ShouldBe(2);
            methodConstructOnClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodConstructOnClick, parametersOfConstructOnClick, methodConstructOnClickPrametersTypes));
        }

        #endregion

        #region Method Call : (ConstructOnClick) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_ConstructOnClick_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodConstructOnClickPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodConstructOnClick, Fixture, methodConstructOnClickPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodConstructOnClickPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ConstructOnClick) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_ConstructOnClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodConstructOnClickPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodConstructOnClick, Fixture, methodConstructOnClickPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodConstructOnClickPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ConstructOnClick) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_ConstructOnClick_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConstructOnClick, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConstructOnClick) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_ConstructOnClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodConstructOnClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_TryListSettingByIndex_Method_Call_Internally(Type[] types)
        {
            var methodTryListSettingByIndexPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodTryListSettingByIndex, Fixture, methodTryListSettingByIndexPrametersTypes);
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_TryListSettingByIndex_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var properties = CreateType<string>();
            var propIndex = CreateType<int>();
            var returnVal = CreateType<string>();
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfTryListSettingByIndex = { properties, propIndex, returnVal };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstanceFixture, out exception1, parametersOfTryListSettingByIndex);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstance, MethodTryListSettingByIndex, parametersOfTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfTryListSettingByIndex.ShouldNotBeNull();
            parametersOfTryListSettingByIndex.Length.ShouldBe(3);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstance, MethodTryListSettingByIndex, parametersOfTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes));
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_TryListSettingByIndex_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<string>();
            var propIndex = CreateType<int>();
            var returnVal = CreateType<string>();
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfTryListSettingByIndex = { properties, propIndex, returnVal };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTryListSettingByIndex.ShouldNotBeNull();
            parametersOfTryListSettingByIndex.Length.ShouldBe(3);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfTryListSettingByIndex));
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_TryListSettingByIndex_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<string>();
            var propIndex = CreateType<int>();
            var returnVal = CreateType<string>();
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            object[] parametersOfTryListSettingByIndex = { properties, propIndex, returnVal };

            // Assert
            parametersOfTryListSettingByIndex.ShouldNotBeNull();
            parametersOfTryListSettingByIndex.Length.ShouldBe(3);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, bool>(_changeAppAjaxDataHostInstance, MethodTryListSettingByIndex, parametersOfTryListSettingByIndex, methodTryListSettingByIndexPrametersTypes));
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_TryListSettingByIndex_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTryListSettingByIndexPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodTryListSettingByIndex, Fixture, methodTryListSettingByIndexPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTryListSettingByIndexPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_TryListSettingByIndex_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (TryListSettingByIndex) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_TryListSettingByIndex_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTryListSettingByIndex, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemFieldValueInString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_GetItemFieldValueInString_Method_Call_Internally(Type[] types)
        {
            var methodGetItemFieldValueInStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetItemFieldValueInString, Fixture, methodGetItemFieldValueInStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemFieldValueInString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetItemFieldValueInString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var fieldId = CreateType<Guid>();
            var methodGetItemFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };
            object[] parametersOfGetItemFieldValueInString = { item, fieldId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetItemFieldValueInString, methodGetItemFieldValueInStringPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetItemFieldValueInString.ShouldNotBeNull();
            parametersOfGetItemFieldValueInString.Length.ShouldBe(2);
            methodGetItemFieldValueInStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfGetItemFieldValueInString));
        }

        #endregion

        #region Method Call : (GetItemFieldValueInString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetItemFieldValueInString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var fieldId = CreateType<Guid>();
            var methodGetItemFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };
            object[] parametersOfGetItemFieldValueInString = { item, fieldId };

            // Assert
            parametersOfGetItemFieldValueInString.ShouldNotBeNull();
            parametersOfGetItemFieldValueInString.Length.ShouldBe(2);
            methodGetItemFieldValueInStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodGetItemFieldValueInString, parametersOfGetItemFieldValueInString, methodGetItemFieldValueInStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItemFieldValueInString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetItemFieldValueInString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetItemFieldValueInString, Fixture, methodGetItemFieldValueInStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemFieldValueInStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetItemFieldValueInString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetItemFieldValueInString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetItemFieldValueInString, Fixture, methodGetItemFieldValueInStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemFieldValueInStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemFieldValueInString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetItemFieldValueInString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemFieldValueInString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetItemFieldValueInString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetItemFieldValueInString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemFieldValueInString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUrlFieldValueInString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChangeAppAjaxDataHost_GetUrlFieldValueInString_Method_Call_Internally(Type[] types)
        {
            var methodGetUrlFieldValueInStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetUrlFieldValueInString, Fixture, methodGetUrlFieldValueInStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUrlFieldValueInString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetUrlFieldValueInString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var fieldId = CreateType<Guid>();
            var methodGetUrlFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };
            object[] parametersOfGetUrlFieldValueInString = { item, fieldId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetUrlFieldValueInString, methodGetUrlFieldValueInStringPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetUrlFieldValueInString.ShouldNotBeNull();
            parametersOfGetUrlFieldValueInString.Length.ShouldBe(2);
            methodGetUrlFieldValueInStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_changeAppAjaxDataHostInstanceFixture, parametersOfGetUrlFieldValueInString));
        }

        #endregion

        #region Method Call : (GetUrlFieldValueInString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetUrlFieldValueInString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var fieldId = CreateType<Guid>();
            var methodGetUrlFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };
            object[] parametersOfGetUrlFieldValueInString = { item, fieldId };

            // Assert
            parametersOfGetUrlFieldValueInString.ShouldNotBeNull();
            parametersOfGetUrlFieldValueInString.Length.ShouldBe(2);
            methodGetUrlFieldValueInStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ChangeAppAjaxDataHost, string>(_changeAppAjaxDataHostInstance, MethodGetUrlFieldValueInString, parametersOfGetUrlFieldValueInString, methodGetUrlFieldValueInStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetUrlFieldValueInString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetUrlFieldValueInString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUrlFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetUrlFieldValueInString, Fixture, methodGetUrlFieldValueInStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUrlFieldValueInStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetUrlFieldValueInString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetUrlFieldValueInString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUrlFieldValueInStringPrametersTypes = new Type[] { typeof(SPListItem), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_changeAppAjaxDataHostInstance, MethodGetUrlFieldValueInString, Fixture, methodGetUrlFieldValueInStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUrlFieldValueInStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUrlFieldValueInString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetUrlFieldValueInString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUrlFieldValueInString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_changeAppAjaxDataHostInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetUrlFieldValueInString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChangeAppAjaxDataHost_GetUrlFieldValueInString_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUrlFieldValueInString, 0);
            const int parametersCount = 2;

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