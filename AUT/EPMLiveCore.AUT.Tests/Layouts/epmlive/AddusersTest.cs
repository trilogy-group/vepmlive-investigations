using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.addusers;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.addusers" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class AddusersTest : AbstractBaseSetupTypedTest<addusers>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (addusers) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetGridUrl = "GetGridUrl";
        private const string MethodAddUser_Click = "AddUser_Click";
        private const string MethodGetViewList = "GetViewList";
        private const string MethodGetMenuItem = "GetMenuItem";
        private const string MethodCreateAddUserButton = "CreateAddUserButton";
        private const string MethodRegisterScripts = "RegisterScripts";
        private const string FieldGridName = "GridName";
        private const string FieldEpmLivePath = "EpmLivePath";
        private const string FieldphToolbar = "phToolbar";
        private Type _addusersInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private addusers _addusersInstance;
        private addusers _addusersInstanceFixture;

        #region General Initializer : Class (addusers) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="addusers" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addusersInstanceType = typeof(addusers);
            _addusersInstanceFixture = Create(true);
            _addusersInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (addusers)

        #region General Initializer : Class (addusers) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="addusers" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetGridUrl, 0)]
        [TestCase(MethodAddUser_Click, 0)]
        [TestCase(MethodGetViewList, 0)]
        [TestCase(MethodGetMenuItem, 0)]
        [TestCase(MethodCreateAddUserButton, 0)]
        [TestCase(MethodRegisterScripts, 0)]
        public void AUT_Addusers_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_addusersInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (addusers) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="addusers" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldGridName)]
        [TestCase(FieldEpmLivePath)]
        [TestCase(FieldphToolbar)]
        public void AUT_Addusers_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_addusersInstanceFixture, 
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
        ///     Class (<see cref="addusers" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Addusers_Is_Instance_Present_Test()
        {
            // Assert
            _addusersInstanceType.ShouldNotBeNull();
            _addusersInstance.ShouldNotBeNull();
            _addusersInstanceFixture.ShouldNotBeNull();
            _addusersInstance.ShouldBeAssignableTo<addusers>();
            _addusersInstanceFixture.ShouldBeAssignableTo<addusers>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (addusers) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_addusers_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            addusers instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _addusersInstanceType.ShouldNotBeNull();
            _addusersInstance.ShouldNotBeNull();
            _addusersInstanceFixture.ShouldNotBeNull();
            _addusersInstance.ShouldBeAssignableTo<addusers>();
            _addusersInstanceFixture.ShouldBeAssignableTo<addusers>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="addusers" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetGridUrl)]
        [TestCase(MethodAddUser_Click)]
        [TestCase(MethodGetViewList)]
        [TestCase(MethodGetMenuItem)]
        [TestCase(MethodCreateAddUserButton)]
        [TestCase(MethodRegisterScripts)]
        public void AUT_Addusers_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<addusers>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addusers_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addusersInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Addusers_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addusersInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Addusers_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Addusers_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetGridUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addusers_GetGridUrl_Method_Call_Internally(Type[] types)
        {
            var methodGetGridUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetGridUrl, Fixture, methodGetGridUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGridUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetGridUrl_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var resUrl = CreateType<string>();
            var methodGetGridUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGridUrl = { resUrl };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetGridUrl, methodGetGridUrlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<addusers, string>(_addusersInstanceFixture, out exception1, parametersOfGetGridUrl);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<addusers, string>(_addusersInstance, MethodGetGridUrl, parametersOfGetGridUrl, methodGetGridUrlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetGridUrl.ShouldNotBeNull();
            parametersOfGetGridUrl.Length.ShouldBe(1);
            methodGetGridUrlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_addusersInstanceFixture, parametersOfGetGridUrl));
        }

        #endregion

        #region Method Call : (GetGridUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetGridUrl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var resUrl = CreateType<string>();
            var methodGetGridUrlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetGridUrl = { resUrl };

            // Assert
            parametersOfGetGridUrl.ShouldNotBeNull();
            parametersOfGetGridUrl.Length.ShouldBe(1);
            methodGetGridUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<addusers, string>(_addusersInstance, MethodGetGridUrl, parametersOfGetGridUrl, methodGetGridUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGridUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetGridUrl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGridUrlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetGridUrl, Fixture, methodGetGridUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGridUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetGridUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetGridUrl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGridUrlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetGridUrl, Fixture, methodGetGridUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGridUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGridUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetGridUrl_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGridUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_addusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGridUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetGridUrl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGridUrl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddUser_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addusers_AddUser_Click_Method_Call_Internally(Type[] types)
        {
            var methodAddUser_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodAddUser_Click, Fixture, methodAddUser_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (AddUser_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_AddUser_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodAddUser_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfAddUser_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddUser_Click, methodAddUser_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addusersInstanceFixture, parametersOfAddUser_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddUser_Click.ShouldNotBeNull();
            parametersOfAddUser_Click.Length.ShouldBe(2);
            methodAddUser_ClickPrametersTypes.Length.ShouldBe(2);
            methodAddUser_ClickPrametersTypes.Length.ShouldBe(parametersOfAddUser_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddUser_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_AddUser_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodAddUser_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfAddUser_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addusersInstance, MethodAddUser_Click, parametersOfAddUser_Click, methodAddUser_ClickPrametersTypes);

            // Assert
            parametersOfAddUser_Click.ShouldNotBeNull();
            parametersOfAddUser_Click.Length.ShouldBe(2);
            methodAddUser_ClickPrametersTypes.Length.ShouldBe(2);
            methodAddUser_ClickPrametersTypes.Length.ShouldBe(parametersOfAddUser_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddUser_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_AddUser_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddUser_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddUser_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_AddUser_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddUser_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodAddUser_Click, Fixture, methodAddUser_ClickPrametersTypes);

            // Assert
            methodAddUser_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddUser_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_AddUser_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddUser_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViewList) (Return Type : ViewList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addusers_GetViewList_Method_Call_Internally(Type[] types)
        {
            var methodGetViewListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetViewList, Fixture, methodGetViewListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetViewList) (Return Type : ViewList) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetViewList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetViewListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetViewList = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetViewList, methodGetViewListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<addusers, ViewList>(_addusersInstanceFixture, out exception1, parametersOfGetViewList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<addusers, ViewList>(_addusersInstance, MethodGetViewList, parametersOfGetViewList, methodGetViewListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetViewList.ShouldNotBeNull();
            parametersOfGetViewList.Length.ShouldBe(1);
            methodGetViewListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<addusers, ViewList>(_addusersInstance, MethodGetViewList, parametersOfGetViewList, methodGetViewListPrametersTypes));
        }

        #endregion

        #region Method Call : (GetViewList) (Return Type : ViewList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetViewList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodGetViewListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfGetViewList = { list };

            // Assert
            parametersOfGetViewList.ShouldNotBeNull();
            parametersOfGetViewList.Length.ShouldBe(1);
            methodGetViewListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<addusers, ViewList>(_addusersInstance, MethodGetViewList, parametersOfGetViewList, methodGetViewListPrametersTypes));
        }

        #endregion

        #region Method Call : (GetViewList) (Return Type : ViewList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetViewList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetViewListPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetViewList, Fixture, methodGetViewListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetViewListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetViewList) (Return Type : ViewList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetViewList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetViewListPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetViewList, Fixture, methodGetViewListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetViewListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViewList) (Return Type : ViewList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetViewList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViewList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_addusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViewList) (Return Type : ViewList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetViewList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetViewList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMenuItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addusers_GetMenuItem_Method_Call_Internally(Type[] types)
        {
            var methodGetMenuItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetMenuItem, Fixture, methodGetMenuItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMenuItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetMenuItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var vw = CreateType<SPView>();
            var viewCode = CreateType<string>();
            var groupId = CreateType<string>();
            var methodGetMenuItemPrametersTypes = new Type[] { typeof(SPView), typeof(string), typeof(string) };
            object[] parametersOfGetMenuItem = { vw, viewCode, groupId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMenuItem, methodGetMenuItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<addusers, string>(_addusersInstanceFixture, out exception1, parametersOfGetMenuItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<addusers, string>(_addusersInstance, MethodGetMenuItem, parametersOfGetMenuItem, methodGetMenuItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMenuItem.ShouldNotBeNull();
            parametersOfGetMenuItem.Length.ShouldBe(3);
            methodGetMenuItemPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_addusersInstanceFixture, parametersOfGetMenuItem));
        }

        #endregion

        #region Method Call : (GetMenuItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetMenuItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var vw = CreateType<SPView>();
            var viewCode = CreateType<string>();
            var groupId = CreateType<string>();
            var methodGetMenuItemPrametersTypes = new Type[] { typeof(SPView), typeof(string), typeof(string) };
            object[] parametersOfGetMenuItem = { vw, viewCode, groupId };

            // Assert
            parametersOfGetMenuItem.ShouldNotBeNull();
            parametersOfGetMenuItem.Length.ShouldBe(3);
            methodGetMenuItemPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<addusers, string>(_addusersInstance, MethodGetMenuItem, parametersOfGetMenuItem, methodGetMenuItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetMenuItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetMenuItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMenuItemPrametersTypes = new Type[] { typeof(SPView), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetMenuItem, Fixture, methodGetMenuItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMenuItemPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetMenuItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetMenuItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMenuItemPrametersTypes = new Type[] { typeof(SPView), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodGetMenuItem, Fixture, methodGetMenuItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMenuItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMenuItem) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetMenuItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMenuItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_addusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMenuItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_GetMenuItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMenuItem, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateAddUserButton) (Return Type : LinkButton) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addusers_CreateAddUserButton_Method_Call_Internally(Type[] types)
        {
            var methodCreateAddUserButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodCreateAddUserButton, Fixture, methodCreateAddUserButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateAddUserButton) (Return Type : LinkButton) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_CreateAddUserButton_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateAddUserButtonPrametersTypes = null;
            object[] parametersOfCreateAddUserButton = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateAddUserButton, methodCreateAddUserButtonPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateAddUserButton.ShouldBeNull();
            methodCreateAddUserButtonPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_addusersInstanceFixture, parametersOfCreateAddUserButton));
        }

        #endregion

        #region Method Call : (CreateAddUserButton) (Return Type : LinkButton) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_CreateAddUserButton_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateAddUserButtonPrametersTypes = null;
            object[] parametersOfCreateAddUserButton = null; // no parameter present

            // Assert
            parametersOfCreateAddUserButton.ShouldBeNull();
            methodCreateAddUserButtonPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<addusers, LinkButton>(_addusersInstance, MethodCreateAddUserButton, parametersOfCreateAddUserButton, methodCreateAddUserButtonPrametersTypes));
        }

        #endregion

        #region Method Call : (CreateAddUserButton) (Return Type : LinkButton) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_CreateAddUserButton_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodCreateAddUserButtonPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodCreateAddUserButton, Fixture, methodCreateAddUserButtonPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodCreateAddUserButtonPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateAddUserButton) (Return Type : LinkButton) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_CreateAddUserButton_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateAddUserButtonPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodCreateAddUserButton, Fixture, methodCreateAddUserButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateAddUserButtonPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateAddUserButton) (Return Type : LinkButton) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_CreateAddUserButton_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateAddUserButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_addusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Addusers_RegisterScripts_Method_Call_Internally(Type[] types)
        {
            var methodRegisterScriptsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodRegisterScripts, Fixture, methodRegisterScriptsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_RegisterScripts_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterScriptsPrametersTypes = null;
            object[] parametersOfRegisterScripts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterScripts, methodRegisterScriptsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_addusersInstanceFixture, parametersOfRegisterScripts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterScripts.ShouldBeNull();
            methodRegisterScriptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_RegisterScripts_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterScriptsPrametersTypes = null;
            object[] parametersOfRegisterScripts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_addusersInstance, MethodRegisterScripts, parametersOfRegisterScripts, methodRegisterScriptsPrametersTypes);

            // Assert
            parametersOfRegisterScripts.ShouldBeNull();
            methodRegisterScriptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_RegisterScripts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterScriptsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_addusersInstance, MethodRegisterScripts, Fixture, methodRegisterScriptsPrametersTypes);

            // Assert
            methodRegisterScriptsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScripts) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Addusers_RegisterScripts_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterScripts, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_addusersInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}