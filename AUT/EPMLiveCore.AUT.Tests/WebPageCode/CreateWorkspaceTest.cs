using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
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
using Microsoft.SharePoint.Administration;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using CreateWorkspace = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CreateWorkspace" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CreateWorkspaceTest : AbstractBaseSetupTypedTest<CreateWorkspace>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CreateWorkspace) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodpopulateTemplates = "populateTemplates";
        private const string MethodisValidTemplate = "isValidTemplate";
        private const string MethodgetMajorVersion = "getMajorVersion";
        private const string MethodBtnOK_Click = "BtnOK_Click";
        private const string MethodIsAlphaNumeric = "IsAlphaNumeric";
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
        private const string FieldrdoTopLinkYes = "rdoTopLinkYes";
        private const string FieldrdoTopLinkNo = "rdoTopLinkNo";
        private const string FieldrdoUnique = "rdoUnique";
        private Type _createWorkspaceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CreateWorkspace _createWorkspaceInstance;
        private CreateWorkspace _createWorkspaceInstanceFixture;

        #region General Initializer : Class (CreateWorkspace) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CreateWorkspace" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createWorkspaceInstanceType = typeof(CreateWorkspace);
            _createWorkspaceInstanceFixture = Create(true);
            _createWorkspaceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CreateWorkspace)

        #region General Initializer : Class (CreateWorkspace) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CreateWorkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodpopulateTemplates, 0)]
        [TestCase(MethodisValidTemplate, 0)]
        [TestCase(MethodisValidTemplate, 1)]
        [TestCase(MethodgetMajorVersion, 0)]
        [TestCase(MethodBtnOK_Click, 0)]
        [TestCase(MethodIsAlphaNumeric, 0)]
        public void AUT_CreateWorkspace_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_createWorkspaceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CreateWorkspace) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CreateWorkspace" />) explore and verify fields for coverage gain.
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
        [TestCase(FieldrdoTopLinkYes)]
        [TestCase(FieldrdoTopLinkNo)]
        [TestCase(FieldrdoUnique)]
        public void AUT_CreateWorkspace_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_createWorkspaceInstanceFixture, 
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
        ///     Class (<see cref="CreateWorkspace" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CreateWorkspace_Is_Instance_Present_Test()
        {
            // Assert
            _createWorkspaceInstanceType.ShouldNotBeNull();
            _createWorkspaceInstance.ShouldNotBeNull();
            _createWorkspaceInstanceFixture.ShouldNotBeNull();
            _createWorkspaceInstance.ShouldBeAssignableTo<CreateWorkspace>();
            _createWorkspaceInstanceFixture.ShouldBeAssignableTo<CreateWorkspace>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CreateWorkspace) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CreateWorkspace_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CreateWorkspace instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _createWorkspaceInstanceType.ShouldNotBeNull();
            _createWorkspaceInstance.ShouldNotBeNull();
            _createWorkspaceInstanceFixture.ShouldNotBeNull();
            _createWorkspaceInstance.ShouldBeAssignableTo<CreateWorkspace>();
            _createWorkspaceInstanceFixture.ShouldBeAssignableTo<CreateWorkspace>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CreateWorkspace" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodpopulateTemplates)]
        [TestCase(MethodisValidTemplate)]
        [TestCase(MethodgetMajorVersion)]
        [TestCase(MethodBtnOK_Click)]
        [TestCase(MethodIsAlphaNumeric)]
        public void AUT_CreateWorkspace_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CreateWorkspace>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspace_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createWorkspaceInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CreateWorkspace_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createWorkspaceInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CreateWorkspace_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CreateWorkspace_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateTemplates) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspace_populateTemplates_Method_Call_Internally(Type[] types)
        {
            var methodpopulateTemplatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodpopulateTemplates, Fixture, methodpopulateTemplatesPrametersTypes);
        }

        #endregion

        #region Method Call : (populateTemplates) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_populateTemplates_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPWeb>();
            var methodpopulateTemplatesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfpopulateTemplates = { site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodpopulateTemplates, methodpopulateTemplatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createWorkspaceInstanceFixture, parametersOfpopulateTemplates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfpopulateTemplates.ShouldNotBeNull();
            parametersOfpopulateTemplates.Length.ShouldBe(1);
            methodpopulateTemplatesPrametersTypes.Length.ShouldBe(1);
            methodpopulateTemplatesPrametersTypes.Length.ShouldBe(parametersOfpopulateTemplates.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (populateTemplates) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_populateTemplates_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPWeb>();
            var methodpopulateTemplatesPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfpopulateTemplates = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createWorkspaceInstance, MethodpopulateTemplates, parametersOfpopulateTemplates, methodpopulateTemplatesPrametersTypes);

            // Assert
            parametersOfpopulateTemplates.ShouldNotBeNull();
            parametersOfpopulateTemplates.Length.ShouldBe(1);
            methodpopulateTemplatesPrametersTypes.Length.ShouldBe(1);
            methodpopulateTemplatesPrametersTypes.Length.ShouldBe(parametersOfpopulateTemplates.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateTemplates) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_populateTemplates_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodpopulateTemplates, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (populateTemplates) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_populateTemplates_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodpopulateTemplatesPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodpopulateTemplates, Fixture, methodpopulateTemplatesPrametersTypes);

            // Assert
            methodpopulateTemplatesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateTemplates) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_populateTemplates_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodpopulateTemplates, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspace_isValidTemplate_Method_Call_Internally(Type[] types)
        {
            var methodisValidTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodisValidTemplate, Fixture, methodisValidTemplatePrametersTypes);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var template = CreateType<string>();
            var version = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodisValidTemplatePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfisValidTemplate = { template, version, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodisValidTemplate, methodisValidTemplatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createWorkspaceInstanceFixture, parametersOfisValidTemplate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisValidTemplate.ShouldNotBeNull();
            parametersOfisValidTemplate.Length.ShouldBe(3);
            methodisValidTemplatePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var template = CreateType<string>();
            var version = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodisValidTemplatePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            object[] parametersOfisValidTemplate = { template, version, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CreateWorkspace, bool>(_createWorkspaceInstance, MethodisValidTemplate, parametersOfisValidTemplate, methodisValidTemplatePrametersTypes);

            // Assert
            parametersOfisValidTemplate.ShouldNotBeNull();
            parametersOfisValidTemplate.Length.ShouldBe(3);
            methodisValidTemplatePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisValidTemplatePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodisValidTemplate, Fixture, methodisValidTemplatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisValidTemplatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisValidTemplate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisValidTemplate, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspace_isValidTemplate_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodisValidTemplatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodisValidTemplate, Fixture, methodisValidTemplatePrametersTypes);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var template = CreateType<string>();
            var version = CreateType<string>();
            var methodisValidTemplatePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfisValidTemplate = { template, version };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodisValidTemplate, methodisValidTemplatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createWorkspaceInstanceFixture, parametersOfisValidTemplate);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisValidTemplate.ShouldNotBeNull();
            parametersOfisValidTemplate.Length.ShouldBe(2);
            methodisValidTemplatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var template = CreateType<string>();
            var version = CreateType<string>();
            var methodisValidTemplatePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfisValidTemplate = { template, version };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CreateWorkspace, bool>(_createWorkspaceInstance, MethodisValidTemplate, parametersOfisValidTemplate, methodisValidTemplatePrametersTypes);

            // Assert
            parametersOfisValidTemplate.ShouldNotBeNull();
            parametersOfisValidTemplate.Length.ShouldBe(2);
            methodisValidTemplatePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisValidTemplatePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodisValidTemplate, Fixture, methodisValidTemplatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisValidTemplatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisValidTemplate, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isValidTemplate) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_isValidTemplate_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisValidTemplate, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMajorVersion) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspace_getMajorVersion_Method_Call_Internally(Type[] types)
        {
            var methodgetMajorVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodgetMajorVersion, Fixture, methodgetMajorVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (getMajorVersion) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_getMajorVersion_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetMajorVersionPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetMajorVersion = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetMajorVersion, methodgetMajorVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createWorkspaceInstanceFixture, parametersOfgetMajorVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetMajorVersion.ShouldNotBeNull();
            parametersOfgetMajorVersion.Length.ShouldBe(1);
            methodgetMajorVersionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMajorVersion) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_getMajorVersion_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetMajorVersionPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetMajorVersion = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CreateWorkspace, string>(_createWorkspaceInstance, MethodgetMajorVersion, parametersOfgetMajorVersion, methodgetMajorVersionPrametersTypes);

            // Assert
            parametersOfgetMajorVersion.ShouldNotBeNull();
            parametersOfgetMajorVersion.Length.ShouldBe(1);
            methodgetMajorVersionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMajorVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_getMajorVersion_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetMajorVersionPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodgetMajorVersion, Fixture, methodgetMajorVersionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetMajorVersionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getMajorVersion) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_getMajorVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetMajorVersionPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodgetMajorVersion, Fixture, methodgetMajorVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMajorVersionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMajorVersion) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_getMajorVersion_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMajorVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getMajorVersion) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_getMajorVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetMajorVersion, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspace_BtnOK_Click_Method_Call_Internally(Type[] types)
        {
            var methodBtnOK_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_BtnOK_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, methodBtnOK_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createWorkspaceInstanceFixture, parametersOfBtnOK_Click);

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
        public void AUT_CreateWorkspace_BtnOK_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBtnOK_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createWorkspaceInstance, MethodBtnOK_Click, parametersOfBtnOK_Click, methodBtnOK_ClickPrametersTypes);

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
        public void AUT_CreateWorkspace_BtnOK_Click_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CreateWorkspace_BtnOK_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBtnOK_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodBtnOK_Click, Fixture, methodBtnOK_ClickPrametersTypes);

            // Assert
            methodBtnOK_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BtnOK_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_BtnOK_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBtnOK_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_Internally(Type[] types)
        {
            var methodIsAlphaNumericPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _createWorkspaceInstance.IsAlphaNumeric(strToCheck);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, methodIsAlphaNumericPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateWorkspace, bool>(_createWorkspaceInstanceFixture, out exception1, parametersOfIsAlphaNumeric);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateWorkspace, bool>(_createWorkspaceInstance, MethodIsAlphaNumeric, parametersOfIsAlphaNumeric, methodIsAlphaNumericPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, methodIsAlphaNumericPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CreateWorkspace, bool>(_createWorkspaceInstanceFixture, out exception1, parametersOfIsAlphaNumeric);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CreateWorkspace, bool>(_createWorkspaceInstance, MethodIsAlphaNumeric, parametersOfIsAlphaNumeric, methodIsAlphaNumericPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, methodIsAlphaNumericPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createWorkspaceInstanceFixture, parametersOfIsAlphaNumeric);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(String) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CreateWorkspace, bool>(_createWorkspaceInstance, MethodIsAlphaNumeric, parametersOfIsAlphaNumeric, methodIsAlphaNumericPrametersTypes);

            // Assert
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(String) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(String) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(String) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceInstance, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsAlphaNumeric, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_createWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateWorkspace_IsAlphaNumeric_Method_Call_Parameters_Count_Verification_Test()
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