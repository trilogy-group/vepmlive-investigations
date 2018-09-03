using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
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
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using getproject = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.getproject" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetprojectTest : AbstractBaseSetupTypedTest<getproject>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (getproject) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string Methodredirect = "redirect";
        private const string MethodloadFile = "loadFile";
        private const string MethodbtnOk_Click = "btnOk_Click";
        private const string FieldfilePath = "filePath";
        private const string FieldddlTemplates = "ddlTemplates";
        private const string FieldbtnOk = "btnOk";
        private const string FieldsDocTmpltURL = "sDocTmpltURL";
        private const string FieldnewFile = "newFile";
        private const string Fieldprojectname = "projectname";
        private Type _getprojectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private getproject _getprojectInstance;
        private getproject _getprojectInstanceFixture;

        #region General Initializer : Class (getproject) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="getproject" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getprojectInstanceType = typeof(getproject);
            _getprojectInstanceFixture = Create(true);
            _getprojectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (getproject)

        #region General Initializer : Class (getproject) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="getproject" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(Methodredirect, 0)]
        [TestCase(MethodloadFile, 0)]
        [TestCase(MethodbtnOk_Click, 0)]
        public void AUT_Getproject_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_getprojectInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (getproject) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="getproject" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldfilePath)]
        [TestCase(FieldddlTemplates)]
        [TestCase(FieldbtnOk)]
        [TestCase(FieldsDocTmpltURL)]
        [TestCase(FieldnewFile)]
        [TestCase(Fieldprojectname)]
        public void AUT_Getproject_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getprojectInstanceFixture, 
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
        ///     Class (<see cref="getproject" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Getproject_Is_Instance_Present_Test()
        {
            // Assert
            _getprojectInstanceType.ShouldNotBeNull();
            _getprojectInstance.ShouldNotBeNull();
            _getprojectInstanceFixture.ShouldNotBeNull();
            _getprojectInstance.ShouldBeAssignableTo<getproject>();
            _getprojectInstanceFixture.ShouldBeAssignableTo<getproject>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (getproject) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_getproject_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            getproject instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getprojectInstanceType.ShouldNotBeNull();
            _getprojectInstance.ShouldNotBeNull();
            _getprojectInstanceFixture.ShouldNotBeNull();
            _getprojectInstance.ShouldBeAssignableTo<getproject>();
            _getprojectInstanceFixture.ShouldBeAssignableTo<getproject>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="getproject" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(Methodredirect)]
        [TestCase(MethodloadFile)]
        [TestCase(MethodbtnOk_Click)]
        public void AUT_Getproject_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<getproject>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getproject_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getprojectInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Getproject_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getprojectInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Getproject_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Getproject_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getprojectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (redirect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getproject_redirect_Method_Call_Internally(Type[] types)
        {
            var methodredirectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, Methodredirect, Fixture, methodredirectPrametersTypes);
        }

        #endregion

        #region Method Call : (redirect) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_redirect_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var filePath = CreateType<string>();
            var methodredirectPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfredirect = { filePath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodredirect, methodredirectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getprojectInstanceFixture, parametersOfredirect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfredirect.ShouldNotBeNull();
            parametersOfredirect.Length.ShouldBe(1);
            methodredirectPrametersTypes.Length.ShouldBe(1);
            methodredirectPrametersTypes.Length.ShouldBe(parametersOfredirect.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (redirect) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_redirect_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var filePath = CreateType<string>();
            var methodredirectPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfredirect = { filePath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getprojectInstance, Methodredirect, parametersOfredirect, methodredirectPrametersTypes);

            // Assert
            parametersOfredirect.ShouldNotBeNull();
            parametersOfredirect.Length.ShouldBe(1);
            methodredirectPrametersTypes.Length.ShouldBe(1);
            methodredirectPrametersTypes.Length.ShouldBe(parametersOfredirect.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (redirect) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_redirect_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodredirect, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (redirect) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_redirect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodredirectPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, Methodredirect, Fixture, methodredirectPrametersTypes);

            // Assert
            methodredirectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (redirect) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_redirect_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodredirect, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getprojectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadFile) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getproject_loadFile_Method_Call_Internally(Type[] types)
        {
            var methodloadFilePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, MethodloadFile, Fixture, methodloadFilePrametersTypes);
        }

        #endregion

        #region Method Call : (loadFile) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_loadFile_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDocLib = CreateType<SPDocumentLibrary>();
            var sDocTmpltURL = CreateType<string>();
            var sNewFileName = CreateType<string>();
            var methodloadFilePrametersTypes = new Type[] { typeof(SPDocumentLibrary), typeof(string), typeof(string) };
            object[] parametersOfloadFile = { oDocLib, sDocTmpltURL, sNewFileName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodloadFile, methodloadFilePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getprojectInstanceFixture, parametersOfloadFile);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfloadFile.ShouldNotBeNull();
            parametersOfloadFile.Length.ShouldBe(3);
            methodloadFilePrametersTypes.Length.ShouldBe(3);
            methodloadFilePrametersTypes.Length.ShouldBe(parametersOfloadFile.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (loadFile) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_loadFile_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDocLib = CreateType<SPDocumentLibrary>();
            var sDocTmpltURL = CreateType<string>();
            var sNewFileName = CreateType<string>();
            var methodloadFilePrametersTypes = new Type[] { typeof(SPDocumentLibrary), typeof(string), typeof(string) };
            object[] parametersOfloadFile = { oDocLib, sDocTmpltURL, sNewFileName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getprojectInstance, MethodloadFile, parametersOfloadFile, methodloadFilePrametersTypes);

            // Assert
            parametersOfloadFile.ShouldNotBeNull();
            parametersOfloadFile.Length.ShouldBe(3);
            methodloadFilePrametersTypes.Length.ShouldBe(3);
            methodloadFilePrametersTypes.Length.ShouldBe(parametersOfloadFile.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadFile) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_loadFile_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodloadFile, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (loadFile) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_loadFile_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodloadFilePrametersTypes = new Type[] { typeof(SPDocumentLibrary), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, MethodloadFile, Fixture, methodloadFilePrametersTypes);

            // Assert
            methodloadFilePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (loadFile) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_loadFile_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodloadFile, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getprojectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnOk_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Getproject_btnOk_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnOk_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, MethodbtnOk_Click, Fixture, methodbtnOk_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnOk_Click) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_btnOk_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnOk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnOk_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnOk_Click, methodbtnOk_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_getprojectInstanceFixture, parametersOfbtnOk_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnOk_Click.ShouldNotBeNull();
            parametersOfbtnOk_Click.Length.ShouldBe(2);
            methodbtnOk_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnOk_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnOk_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnOk_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_btnOk_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnOk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnOk_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_getprojectInstance, MethodbtnOk_Click, parametersOfbtnOk_Click, methodbtnOk_ClickPrametersTypes);

            // Assert
            parametersOfbtnOk_Click.ShouldNotBeNull();
            parametersOfbtnOk_Click.Length.ShouldBe(2);
            methodbtnOk_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnOk_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnOk_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnOk_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_btnOk_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnOk_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnOk_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_btnOk_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnOk_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_getprojectInstance, MethodbtnOk_Click, Fixture, methodbtnOk_ClickPrametersTypes);

            // Assert
            methodbtnOk_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnOk_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Getproject_btnOk_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnOk_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_getprojectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}