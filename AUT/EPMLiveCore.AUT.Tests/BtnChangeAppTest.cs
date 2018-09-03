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
using EPMLiveCore.GlobalResources;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using BtnChangeApp = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.BtnChangeApp" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BtnChangeAppTest : AbstractBaseSetupTypedTest<BtnChangeApp>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (BtnChangeApp) Initializer

        private const string MethodGetWelcomePage = "GetWelcomePage";
        private const string MethodRender = "Render";
        private const string MethodUrlIsHomePage = "UrlIsHomePage";
        private const string Field_changeAppDataHostPageUrl = "_changeAppDataHostPageUrl";
        private const string FieldappHelper = "appHelper";
        private Type _btnChangeAppInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private BtnChangeApp _btnChangeAppInstance;
        private BtnChangeApp _btnChangeAppInstanceFixture;

        #region General Initializer : Class (BtnChangeApp) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BtnChangeApp" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _btnChangeAppInstanceType = typeof(BtnChangeApp);
            _btnChangeAppInstanceFixture = Create(true);
            _btnChangeAppInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BtnChangeApp)

        #region General Initializer : Class (BtnChangeApp) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="BtnChangeApp" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetWelcomePage, 0)]
        [TestCase(MethodRender, 0)]
        [TestCase(MethodUrlIsHomePage, 0)]
        public void AUT_BtnChangeApp_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_btnChangeAppInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (BtnChangeApp) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="BtnChangeApp" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_changeAppDataHostPageUrl)]
        [TestCase(FieldappHelper)]
        public void AUT_BtnChangeApp_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_btnChangeAppInstanceFixture, 
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
        ///     Class (<see cref="BtnChangeApp" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BtnChangeApp_Is_Instance_Present_Test()
        {
            // Assert
            _btnChangeAppInstanceType.ShouldNotBeNull();
            _btnChangeAppInstance.ShouldNotBeNull();
            _btnChangeAppInstanceFixture.ShouldNotBeNull();
            _btnChangeAppInstance.ShouldBeAssignableTo<BtnChangeApp>();
            _btnChangeAppInstanceFixture.ShouldBeAssignableTo<BtnChangeApp>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BtnChangeApp) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BtnChangeApp_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BtnChangeApp instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _btnChangeAppInstanceType.ShouldNotBeNull();
            _btnChangeAppInstance.ShouldNotBeNull();
            _btnChangeAppInstanceFixture.ShouldNotBeNull();
            _btnChangeAppInstance.ShouldBeAssignableTo<BtnChangeApp>();
            _btnChangeAppInstanceFixture.ShouldBeAssignableTo<BtnChangeApp>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="BtnChangeApp" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetWelcomePage)]
        [TestCase(MethodRender)]
        [TestCase(MethodUrlIsHomePage)]
        public void AUT_BtnChangeApp_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<BtnChangeApp>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetWelcomePage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BtnChangeApp_GetWelcomePage_Method_Call_Internally(Type[] types)
        {
            var methodGetWelcomePagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_btnChangeAppInstance, MethodGetWelcomePage, Fixture, methodGetWelcomePagePrametersTypes);
        }

        #endregion

        #region Method Call : (GetWelcomePage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_GetWelcomePage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetWelcomePagePrametersTypes = null;
            object[] parametersOfGetWelcomePage = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWelcomePage, methodGetWelcomePagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<BtnChangeApp, string>(_btnChangeAppInstanceFixture, out exception1, parametersOfGetWelcomePage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<BtnChangeApp, string>(_btnChangeAppInstance, MethodGetWelcomePage, parametersOfGetWelcomePage, methodGetWelcomePagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWelcomePage.ShouldBeNull();
            methodGetWelcomePagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWelcomePage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_GetWelcomePage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetWelcomePagePrametersTypes = null;
            object[] parametersOfGetWelcomePage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<BtnChangeApp, string>(_btnChangeAppInstance, MethodGetWelcomePage, parametersOfGetWelcomePage, methodGetWelcomePagePrametersTypes);

            // Assert
            parametersOfGetWelcomePage.ShouldBeNull();
            methodGetWelcomePagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWelcomePage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_GetWelcomePage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetWelcomePagePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_btnChangeAppInstance, MethodGetWelcomePage, Fixture, methodGetWelcomePagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWelcomePagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWelcomePage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_GetWelcomePage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetWelcomePagePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_btnChangeAppInstance, MethodGetWelcomePage, Fixture, methodGetWelcomePagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWelcomePagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWelcomePage) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_GetWelcomePage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWelcomePage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_btnChangeAppInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BtnChangeApp_Render_Method_Call_Internally(Type[] types)
        {
            var methodRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_btnChangeAppInstance, MethodRender, Fixture, methodRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_Render_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRender, methodRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_btnChangeAppInstanceFixture, parametersOfRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_Render_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_btnChangeAppInstance, MethodRender, parametersOfRender, methodRenderPrametersTypes);

            // Assert
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_Render_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_Render_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_btnChangeAppInstance, MethodRender, Fixture, methodRenderPrametersTypes);

            // Assert
            methodRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_Render_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_btnChangeAppInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UrlIsHomePage) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BtnChangeApp_UrlIsHomePage_Method_Call_Internally(Type[] types)
        {
            var methodUrlIsHomePagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_btnChangeAppInstance, MethodUrlIsHomePage, Fixture, methodUrlIsHomePagePrametersTypes);
        }

        #endregion

        #region Method Call : (UrlIsHomePage) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_UrlIsHomePage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var appId = CreateType<int>();
            var methodUrlIsHomePagePrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfUrlIsHomePage = { url, appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUrlIsHomePage, methodUrlIsHomePagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<BtnChangeApp, bool>(_btnChangeAppInstanceFixture, out exception1, parametersOfUrlIsHomePage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<BtnChangeApp, bool>(_btnChangeAppInstance, MethodUrlIsHomePage, parametersOfUrlIsHomePage, methodUrlIsHomePagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUrlIsHomePage.ShouldNotBeNull();
            parametersOfUrlIsHomePage.Length.ShouldBe(2);
            methodUrlIsHomePagePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UrlIsHomePage) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_UrlIsHomePage_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var appId = CreateType<int>();
            var methodUrlIsHomePagePrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfUrlIsHomePage = { url, appId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUrlIsHomePage, methodUrlIsHomePagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<BtnChangeApp, bool>(_btnChangeAppInstanceFixture, out exception1, parametersOfUrlIsHomePage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<BtnChangeApp, bool>(_btnChangeAppInstance, MethodUrlIsHomePage, parametersOfUrlIsHomePage, methodUrlIsHomePagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUrlIsHomePage.ShouldNotBeNull();
            parametersOfUrlIsHomePage.Length.ShouldBe(2);
            methodUrlIsHomePagePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UrlIsHomePage) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_UrlIsHomePage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var appId = CreateType<int>();
            var methodUrlIsHomePagePrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfUrlIsHomePage = { url, appId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<BtnChangeApp, bool>(_btnChangeAppInstance, MethodUrlIsHomePage, parametersOfUrlIsHomePage, methodUrlIsHomePagePrametersTypes);

            // Assert
            parametersOfUrlIsHomePage.ShouldNotBeNull();
            parametersOfUrlIsHomePage.Length.ShouldBe(2);
            methodUrlIsHomePagePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UrlIsHomePage) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_UrlIsHomePage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUrlIsHomePagePrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_btnChangeAppInstance, MethodUrlIsHomePage, Fixture, methodUrlIsHomePagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUrlIsHomePagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UrlIsHomePage) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_UrlIsHomePage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUrlIsHomePage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_btnChangeAppInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UrlIsHomePage) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BtnChangeApp_UrlIsHomePage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUrlIsHomePage, 0);
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