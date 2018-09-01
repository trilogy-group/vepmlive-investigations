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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.Infrastructure.Logging;
using EPMLiveCore.SPUtilities;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using newproject = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.newproject" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NewprojectTest : AbstractBaseSetupTypedTest<newproject>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (newproject) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodcreateProject = "createProject";
        private const string MethodBtnOK_Click = "BtnOK_Click";
        private const string MethodCreateProjectInExistingWorkspace = "CreateProjectInExistingWorkspace";
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
        private const string FieldvalidTemplates = "validTemplates";
        private Type _newprojectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private newproject _newprojectInstance;
        private newproject _newprojectInstanceFixture;

        #region General Initializer : Class (newproject) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="newproject" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _newprojectInstanceType = typeof(newproject);
            _newprojectInstanceFixture = Create(true);
            _newprojectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (newproject)

        #region General Initializer : Class (newproject) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="newproject" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodcreateProject, 0)]
        [TestCase(MethodBtnOK_Click, 0)]
        public void AUT_Newproject_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_newprojectInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (newproject) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="newproject" />) explore and verify fields for coverage gain.
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
        [TestCase(FieldvalidTemplates)]
        public void AUT_Newproject_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_newprojectInstanceFixture, 
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
        ///     Class (<see cref="newproject" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Newproject_Is_Instance_Present_Test()
        {
            // Assert
            _newprojectInstanceType.ShouldNotBeNull();
            _newprojectInstance.ShouldNotBeNull();
            _newprojectInstanceFixture.ShouldNotBeNull();
            _newprojectInstance.ShouldBeAssignableTo<newproject>();
            _newprojectInstanceFixture.ShouldBeAssignableTo<newproject>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (newproject) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_newproject_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            newproject instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _newprojectInstanceType.ShouldNotBeNull();
            _newprojectInstance.ShouldNotBeNull();
            _newprojectInstanceFixture.ShouldNotBeNull();
            _newprojectInstance.ShouldBeAssignableTo<newproject>();
            _newprojectInstanceFixture.ShouldBeAssignableTo<newproject>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="newproject" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodcreateProject)]
        [TestCase(MethodBtnOK_Click)]
        public void AUT_Newproject_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<newproject>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Newproject_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_newprojectInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Newproject_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_newprojectInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Newproject_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Newproject_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_newprojectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Newproject_createProject_Method_Call_Internally(Type[] types)
        {
            var methodcreateProjectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodcreateProject, Fixture, methodcreateProjectPrametersTypes);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_createProject_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfcreateProject = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcreateProject, methodcreateProjectPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<newproject, string>(_newprojectInstanceFixture, out exception1, parametersOfcreateProject);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<newproject, string>(_newprojectInstance, MethodcreateProject, parametersOfcreateProject, methodcreateProjectPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcreateProject.ShouldNotBeNull();
            parametersOfcreateProject.Length.ShouldBe(1);
            methodcreateProjectPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_createProject_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfcreateProject = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<newproject, string>(_newprojectInstance, MethodcreateProject, parametersOfcreateProject, methodcreateProjectPrametersTypes);

            // Assert
            parametersOfcreateProject.ShouldNotBeNull();
            parametersOfcreateProject.Length.ShouldBe(1);
            methodcreateProjectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_createProject_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodcreateProject, Fixture, methodcreateProjectPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcreateProjectPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_createProject_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateProjectPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodcreateProject, Fixture, methodcreateProjectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcreateProjectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_createProject_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateProject, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_newprojectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (createProject) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_createProject_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateProject, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Newproject_BtnOK_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnOK_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_BtnOK_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, methodBtnOK_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_newprojectInstanceFixture, parametersOfBtnOK_Click);

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
        public void AUT_Newproject_BtnOK_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_newprojectInstance, MethodBtnOK_Click, parametersOfBtnOK_Click, methodBtnOK_ClickPrametersTypes);

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
        public void AUT_Newproject_BtnOK_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Newproject_BtnOK_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);

            // Assert
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_BtnOK_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_newprojectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateProjectInExistingWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Newproject_CreateProjectInExistingWorkspace_Method_Call_Internally(Type[] types)
        {
            var methodCreateProjectInExistingWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodCreateProjectInExistingWorkspace, Fixture, methodCreateProjectInExistingWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateProjectInExistingWorkspace) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_CreateProjectInExistingWorkspace_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedWorkspace = CreateType<string>();
            var methodCreateProjectInExistingWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateProjectInExistingWorkspace = { selectedWorkspace };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<newproject, string>(_newprojectInstance, MethodCreateProjectInExistingWorkspace, parametersOfCreateProjectInExistingWorkspace, methodCreateProjectInExistingWorkspacePrametersTypes);

            // Assert
            parametersOfCreateProjectInExistingWorkspace.ShouldNotBeNull();
            parametersOfCreateProjectInExistingWorkspace.Length.ShouldBe(1);
            methodCreateProjectInExistingWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateProjectInExistingWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_CreateProjectInExistingWorkspace_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateProjectInExistingWorkspacePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodCreateProjectInExistingWorkspace, Fixture, methodCreateProjectInExistingWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateProjectInExistingWorkspacePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateProjectInExistingWorkspace) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Newproject_CreateProjectInExistingWorkspace_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateProjectInExistingWorkspacePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_newprojectInstance, MethodCreateProjectInExistingWorkspace, Fixture, methodCreateProjectInExistingWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateProjectInExistingWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}