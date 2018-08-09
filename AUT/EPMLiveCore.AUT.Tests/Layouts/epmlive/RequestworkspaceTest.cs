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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.requestworkspace" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RequestworkspaceTest : AbstractBaseSetupTypedTest<requestworkspace>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (requestworkspace) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodcreateProject = "createProject";
        private const string MethodBtnOK_Click = "BtnOK_Click";
        private const string MethodIsAlphaNumeric = "IsAlphaNumeric";
        private const string Field_spProjectUtility = "_spProjectUtility";
        private const string FieldbaseURL = "baseURL";
        private const string FieldmetaDataString = "metaDataString";
        private const string FieldprocessString = "processString";
        private const string FieldrequiredOK = "requiredOK";
        private const string FieldbtnOK = "btnOK";
        private const string FieldDdlGroup = "DdlGroup";
        private const string FieldpnlTitle = "pnlTitle";
        private const string FieldpnlURL = "pnlURL";
        private const string FieldpnlURLBad = "pnlURLBad";
        private const string FieldtxtURL = "txtURL";
        private const string FieldtxtTitle = "txtTitle";
        private const string Fieldlabel1 = "label1";
        private const string FieldPanel2 = "Panel2";
        private const string FieldURL = "URL";
        private const string FieldrdoTopLinkYes = "rdoTopLinkYes";
        private const string FieldrdoTopLinkNo = "rdoTopLinkNo";
        private const string FieldrdoUnique = "rdoUnique";
        private const string FieldrdoInherit = "rdoInherit";
        private const string FieldwsTypeNew = "wsTypeNew";
        private const string FieldwsTypeExisting = "wsTypeExisting";
        private const string FieldlistName = "listName";
        private const string FieldstrName = "strName";
        private const string FieldinpName = "inpName";
        private Type _requestworkspaceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private requestworkspace _requestworkspaceInstance;
        private requestworkspace _requestworkspaceInstanceFixture;

        #region General Initializer : Class (requestworkspace) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="requestworkspace" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _requestworkspaceInstanceType = typeof(requestworkspace);
            _requestworkspaceInstanceFixture = Create(true);
            _requestworkspaceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (requestworkspace)

        #region General Initializer : Class (requestworkspace) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="requestworkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodcreateProject, 0)]
        [TestCase(MethodBtnOK_Click, 0)]
        [TestCase(MethodIsAlphaNumeric, 0)]
        public void AUT_Requestworkspace_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_requestworkspaceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (requestworkspace) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="requestworkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldbaseURL)]
        [TestCase(FieldmetaDataString)]
        [TestCase(FieldprocessString)]
        [TestCase(FieldrequiredOK)]
        [TestCase(FieldbtnOK)]
        [TestCase(FieldDdlGroup)]
        [TestCase(FieldpnlTitle)]
        [TestCase(FieldpnlURL)]
        [TestCase(FieldpnlURLBad)]
        [TestCase(FieldtxtURL)]
        [TestCase(FieldtxtTitle)]
        [TestCase(Fieldlabel1)]
        [TestCase(FieldPanel2)]
        [TestCase(FieldURL)]
        [TestCase(FieldrdoTopLinkYes)]
        [TestCase(FieldrdoTopLinkNo)]
        [TestCase(FieldrdoUnique)]
        [TestCase(FieldrdoInherit)]
        [TestCase(FieldwsTypeNew)]
        [TestCase(FieldwsTypeExisting)]
        [TestCase(FieldlistName)]
        [TestCase(FieldstrName)]
        [TestCase(FieldinpName)]
        public void AUT_Requestworkspace_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_requestworkspaceInstanceFixture, 
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
        ///     Class (<see cref="requestworkspace" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Requestworkspace_Is_Instance_Present_Test()
        {
            // Assert
            _requestworkspaceInstanceType.ShouldNotBeNull();
            _requestworkspaceInstance.ShouldNotBeNull();
            _requestworkspaceInstanceFixture.ShouldNotBeNull();
            _requestworkspaceInstance.ShouldBeAssignableTo<requestworkspace>();
            _requestworkspaceInstanceFixture.ShouldBeAssignableTo<requestworkspace>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (requestworkspace) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_requestworkspace_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            requestworkspace instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _requestworkspaceInstanceType.ShouldNotBeNull();
            _requestworkspaceInstance.ShouldNotBeNull();
            _requestworkspaceInstanceFixture.ShouldNotBeNull();
            _requestworkspaceInstance.ShouldBeAssignableTo<requestworkspace>();
            _requestworkspaceInstanceFixture.ShouldBeAssignableTo<requestworkspace>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="requestworkspace" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodcreateProject)]
        [TestCase(MethodBtnOK_Click)]
        [TestCase(MethodIsAlphaNumeric)]
        public void AUT_Requestworkspace_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<requestworkspace>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Requestworkspace_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_requestworkspaceInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Requestworkspace_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_requestworkspaceInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Requestworkspace_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Requestworkspace_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_requestworkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Requestworkspace_createProject_Method_Call_Internally(Type[] types)
        {
            var methodcreateProjectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodcreateProject, Fixture, methodcreateProjectPrametersTypes);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_createProject_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var newWeb = CreateType<SPWeb>();
            var curList = CreateType<SPList>();
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };
            object[] parametersOfcreateProject = { newWeb, curList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcreateProject, methodcreateProjectPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcreateProject.ShouldNotBeNull();
            parametersOfcreateProject.Length.ShouldBe(2);
            methodcreateProjectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_requestworkspaceInstanceFixture, parametersOfcreateProject));
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_createProject_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var newWeb = CreateType<SPWeb>();
            var curList = CreateType<SPList>();
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };
            object[] parametersOfcreateProject = { newWeb, curList };

            // Assert
            parametersOfcreateProject.ShouldNotBeNull();
            parametersOfcreateProject.Length.ShouldBe(2);
            methodcreateProjectPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<requestworkspace, string>(_requestworkspaceInstance, MethodcreateProject, parametersOfcreateProject, methodcreateProjectPrametersTypes));
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_createProject_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodcreateProject, Fixture, methodcreateProjectPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcreateProjectPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_createProject_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodcreateProject, Fixture, methodcreateProjectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcreateProjectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_createProject_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateProject, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_requestworkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_createProject_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateProject, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Requestworkspace_BtnOK_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnOK_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_BtnOK_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, methodBtnOK_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_requestworkspaceInstanceFixture, parametersOfBtnOK_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBtnOK_Click.ShouldNotBeNull();
            parametersOfBtnOK_Click.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnOK_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_BtnOK_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_requestworkspaceInstance, MethodBtnOK_Click, parametersOfBtnOK_Click, methodBtnOK_ClickPrametersTypes);

            // Assert
            parametersOfBtnOK_Click.ShouldNotBeNull();
            parametersOfBtnOK_Click.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(parametersOfBtnOK_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_BtnOK_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_BtnOK_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);

            // Assert
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_BtnOK_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_requestworkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_Internally(Type[] types)
        {
            var methodIsAlphaNumericPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _requestworkspaceInstance.IsAlphaNumeric(strToCheck);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, methodIsAlphaNumericPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<requestworkspace, bool>(_requestworkspaceInstanceFixture, out exception1, parametersOfIsAlphaNumeric);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<requestworkspace, bool>(_requestworkspaceInstance, MethodIsAlphaNumeric, parametersOfIsAlphaNumeric, methodIsAlphaNumericPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<requestworkspace, bool>(_requestworkspaceInstance, MethodIsAlphaNumeric, parametersOfIsAlphaNumeric, methodIsAlphaNumericPrametersTypes));
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, methodIsAlphaNumericPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_requestworkspaceInstanceFixture, parametersOfIsAlphaNumeric));
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };

            // Assert
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<requestworkspace, bool>(_requestworkspaceInstance, MethodIsAlphaNumeric, parametersOfIsAlphaNumeric, methodIsAlphaNumericPrametersTypes));
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_requestworkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_requestworkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Requestworkspace_IsAlphaNumeric_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, 0);
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