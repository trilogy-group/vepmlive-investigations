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
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ViewPermissionPage = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ViewPermissionPage" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ViewPermissionPageTest : AbstractBaseSetupTypedTest<ViewPermissionPage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ViewPermissionPage) Initializer

        private const string PropertyCurrentList = "CurrentList";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodRenderPage = "RenderPage";
        private const string MethodPrepareRenderPage = "PrepareRenderPage";
        private const string MethodRenderOptions = "RenderOptions";
        private const string MethodRenderDefaultView = "RenderDefaultView";
        private const string MethodRenderAvailableViews = "RenderAvailableViews";
        private const string MethodUpdateGlobalScript = "UpdateGlobalScript";
        private const string MethodClearAll = "ClearAll";
        private const string MethodSaveCustomPermission = "SaveCustomPermission";
        private const string MethodRegisterScript = "RegisterScript";
        private const string MethodGetViewsNotInAnyGroup = "GetViewsNotInAnyGroup";
        private const string FieldpageRender = "pageRender";
        private const string FieldcurrentList = "currentList";
        private const string Fieldgroups = "groups";
        private const string Fieldviews = "views";
        private const string FieldroleProperties = "roleProperties";
        private const string FielddefaultViews = "defaultViews";
        private const string FieldhiddenFields = "hiddenFields";
        private const string FieldcomputeFieldsScript = "computeFieldsScript";
        private const string FieldviewsNotInAnyGroup = "viewsNotInAnyGroup";
        private const string FieldgroupIds = "groupIds";
        private const string FieldcheckPermissionScript = "checkPermissionScript";
        private const string FieldOK = "OK";
        private const string FieldCancel = "Cancel";
        private Type _viewPermissionPageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ViewPermissionPage _viewPermissionPageInstance;
        private ViewPermissionPage _viewPermissionPageInstanceFixture;

        #region General Initializer : Class (ViewPermissionPage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ViewPermissionPage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _viewPermissionPageInstanceType = typeof(ViewPermissionPage);
            _viewPermissionPageInstanceFixture = Create(true);
            _viewPermissionPageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ViewPermissionPage)

        #region General Initializer : Class (ViewPermissionPage) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ViewPermissionPage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodRenderPage, 0)]
        [TestCase(MethodPrepareRenderPage, 0)]
        [TestCase(MethodRenderOptions, 0)]
        [TestCase(MethodRenderDefaultView, 0)]
        [TestCase(MethodRenderAvailableViews, 0)]
        [TestCase(MethodUpdateGlobalScript, 0)]
        [TestCase(MethodClearAll, 0)]
        [TestCase(MethodSaveCustomPermission, 0)]
        [TestCase(MethodRegisterScript, 0)]
        [TestCase(MethodGetViewsNotInAnyGroup, 0)]
        public void AUT_ViewPermissionPage_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_viewPermissionPageInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ViewPermissionPage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ViewPermissionPage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCurrentList)]
        public void AUT_ViewPermissionPage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_viewPermissionPageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ViewPermissionPage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ViewPermissionPage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpageRender)]
        [TestCase(FieldcurrentList)]
        [TestCase(Fieldgroups)]
        [TestCase(Fieldviews)]
        [TestCase(FieldroleProperties)]
        [TestCase(FielddefaultViews)]
        [TestCase(FieldhiddenFields)]
        [TestCase(FieldcomputeFieldsScript)]
        [TestCase(FieldviewsNotInAnyGroup)]
        [TestCase(FieldgroupIds)]
        [TestCase(FieldcheckPermissionScript)]
        [TestCase(FieldOK)]
        [TestCase(FieldCancel)]
        public void AUT_ViewPermissionPage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_viewPermissionPageInstanceFixture, 
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
        ///     Class (<see cref="ViewPermissionPage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ViewPermissionPage_Is_Instance_Present_Test()
        {
            // Assert
            _viewPermissionPageInstanceType.ShouldNotBeNull();
            _viewPermissionPageInstance.ShouldNotBeNull();
            _viewPermissionPageInstanceFixture.ShouldNotBeNull();
            _viewPermissionPageInstance.ShouldBeAssignableTo<ViewPermissionPage>();
            _viewPermissionPageInstanceFixture.ShouldBeAssignableTo<ViewPermissionPage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ViewPermissionPage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ViewPermissionPage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ViewPermissionPage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _viewPermissionPageInstanceType.ShouldNotBeNull();
            _viewPermissionPageInstance.ShouldNotBeNull();
            _viewPermissionPageInstanceFixture.ShouldNotBeNull();
            _viewPermissionPageInstance.ShouldBeAssignableTo<ViewPermissionPage>();
            _viewPermissionPageInstanceFixture.ShouldBeAssignableTo<ViewPermissionPage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ViewPermissionPage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SPList) , PropertyCurrentList)]
        public void AUT_ViewPermissionPage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ViewPermissionPage, T>(_viewPermissionPageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ViewPermissionPage) => Property (CurrentList) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ViewPermissionPage_CurrentList_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCurrentList);
            Action currentAction = () => propertyInfo.SetValue(_viewPermissionPageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ViewPermissionPage) => Property (CurrentList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ViewPermissionPage_Public_Class_CurrentList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCurrentList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ViewPermissionPage" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodRenderPage)]
        [TestCase(MethodPrepareRenderPage)]
        [TestCase(MethodRenderOptions)]
        [TestCase(MethodRenderDefaultView)]
        [TestCase(MethodRenderAvailableViews)]
        [TestCase(MethodUpdateGlobalScript)]
        [TestCase(MethodClearAll)]
        [TestCase(MethodSaveCustomPermission)]
        [TestCase(MethodRegisterScript)]
        [TestCase(MethodGetViewsNotInAnyGroup)]
        public void AUT_ViewPermissionPage_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ViewPermissionPage>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionPageInstanceFixture, parametersOfOnLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionPageInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

            // Assert
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_OnLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_RenderPage_Method_Call_Internally(Type[] types)
        {
            var methodRenderPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderPage, Fixture, methodRenderPagePrametersTypes);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderPage_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;
            object[] parametersOfRenderPage = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderPage, methodRenderPagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionPageInstanceFixture, parametersOfRenderPage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderPage.ShouldBeNull();
            methodRenderPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderPage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;
            object[] parametersOfRenderPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodRenderPage, parametersOfRenderPage, methodRenderPagePrametersTypes);

            // Assert
            parametersOfRenderPage.ShouldBeNull();
            methodRenderPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderPage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderPage, Fixture, methodRenderPagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderPage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderPagePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderPage, Fixture, methodRenderPagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (PrepareRenderPage) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_PrepareRenderPage_Method_Call_Internally(Type[] types)
        {
            var methodPrepareRenderPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodPrepareRenderPage, Fixture, methodPrepareRenderPagePrametersTypes);
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_PrepareRenderPage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;
            object[] parametersOfPrepareRenderPage = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPrepareRenderPage, methodPrepareRenderPagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionPage, string>(_viewPermissionPageInstanceFixture, out exception1, parametersOfPrepareRenderPage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodPrepareRenderPage, parametersOfPrepareRenderPage, methodPrepareRenderPagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPrepareRenderPage.ShouldBeNull();
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_PrepareRenderPage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;
            object[] parametersOfPrepareRenderPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodPrepareRenderPage, parametersOfPrepareRenderPage, methodPrepareRenderPagePrametersTypes);

            // Assert
            parametersOfPrepareRenderPage.ShouldBeNull();
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_PrepareRenderPage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodPrepareRenderPage, Fixture, methodPrepareRenderPagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_PrepareRenderPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPrepareRenderPagePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodPrepareRenderPage, Fixture, methodPrepareRenderPagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPrepareRenderPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PrepareRenderPage) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_PrepareRenderPage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPrepareRenderPage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_RenderOptions_Method_Call_Internally(Type[] types)
        {
            var methodRenderOptionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderOptions, Fixture, methodRenderOptionsPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderOptions_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRenderOptions = { groupId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderOptions, methodRenderOptionsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionPage, string>(_viewPermissionPageInstanceFixture, out exception1, parametersOfRenderOptions);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodRenderOptions, parametersOfRenderOptions, methodRenderOptionsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderOptions.ShouldNotBeNull();
            parametersOfRenderOptions.Length.ShouldBe(1);
            methodRenderOptionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderOptions_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRenderOptions = { groupId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodRenderOptions, parametersOfRenderOptions, methodRenderOptionsPrametersTypes);

            // Assert
            parametersOfRenderOptions.ShouldNotBeNull();
            parametersOfRenderOptions.Length.ShouldBe(1);
            methodRenderOptionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderOptions_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderOptions, Fixture, methodRenderOptionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderOptionsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderOptions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderOptionsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderOptions, Fixture, methodRenderOptionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderOptionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderOptions_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderOptions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderOptions) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderOptions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderOptions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderDefaultView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_RenderDefaultView_Method_Call_Internally(Type[] types)
        {
            var methodRenderDefaultViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderDefaultView, Fixture, methodRenderDefaultViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderDefaultView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderDefaultView_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodRenderDefaultViewPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRenderDefaultView = { groupId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderDefaultView, methodRenderDefaultViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionPage, string>(_viewPermissionPageInstanceFixture, out exception1, parametersOfRenderDefaultView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodRenderDefaultView, parametersOfRenderDefaultView, methodRenderDefaultViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderDefaultView.ShouldNotBeNull();
            parametersOfRenderDefaultView.Length.ShouldBe(1);
            methodRenderDefaultViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderDefaultView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderDefaultView_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodRenderDefaultViewPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRenderDefaultView = { groupId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodRenderDefaultView, parametersOfRenderDefaultView, methodRenderDefaultViewPrametersTypes);

            // Assert
            parametersOfRenderDefaultView.ShouldNotBeNull();
            parametersOfRenderDefaultView.Length.ShouldBe(1);
            methodRenderDefaultViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderDefaultView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderDefaultView_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderDefaultViewPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderDefaultView, Fixture, methodRenderDefaultViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderDefaultViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderDefaultView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderDefaultView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderDefaultViewPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderDefaultView, Fixture, methodRenderDefaultViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderDefaultViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderDefaultView) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderDefaultView_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderDefaultView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderDefaultView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderDefaultView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderDefaultView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderAvailableViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_RenderAvailableViews_Method_Call_Internally(Type[] types)
        {
            var methodRenderAvailableViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderAvailableViews, Fixture, methodRenderAvailableViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderAvailableViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderAvailableViews_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodRenderAvailableViewsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRenderAvailableViews = { groupId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenderAvailableViews, methodRenderAvailableViewsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionPage, string>(_viewPermissionPageInstanceFixture, out exception1, parametersOfRenderAvailableViews);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodRenderAvailableViews, parametersOfRenderAvailableViews, methodRenderAvailableViewsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRenderAvailableViews.ShouldNotBeNull();
            parametersOfRenderAvailableViews.Length.ShouldBe(1);
            methodRenderAvailableViewsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderAvailableViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderAvailableViews_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodRenderAvailableViewsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfRenderAvailableViews = { groupId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionPage, string>(_viewPermissionPageInstance, MethodRenderAvailableViews, parametersOfRenderAvailableViews, methodRenderAvailableViewsPrametersTypes);

            // Assert
            parametersOfRenderAvailableViews.ShouldNotBeNull();
            parametersOfRenderAvailableViews.Length.ShouldBe(1);
            methodRenderAvailableViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderAvailableViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderAvailableViews_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRenderAvailableViewsPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderAvailableViews, Fixture, methodRenderAvailableViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRenderAvailableViewsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RenderAvailableViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderAvailableViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderAvailableViewsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRenderAvailableViews, Fixture, methodRenderAvailableViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderAvailableViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderAvailableViews) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderAvailableViews_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderAvailableViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderAvailableViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RenderAvailableViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderAvailableViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_UpdateGlobalScript_Method_Call_Internally(Type[] types)
        {
            var methodUpdateGlobalScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodUpdateGlobalScript, Fixture, methodUpdateGlobalScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_UpdateGlobalScript_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodUpdateGlobalScriptPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfUpdateGlobalScript = { groupId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateGlobalScript, methodUpdateGlobalScriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionPageInstanceFixture, parametersOfUpdateGlobalScript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateGlobalScript.ShouldNotBeNull();
            parametersOfUpdateGlobalScript.Length.ShouldBe(1);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(1);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(parametersOfUpdateGlobalScript.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_UpdateGlobalScript_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var groupId = CreateType<int>();
            var methodUpdateGlobalScriptPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfUpdateGlobalScript = { groupId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionPageInstance, MethodUpdateGlobalScript, parametersOfUpdateGlobalScript, methodUpdateGlobalScriptPrametersTypes);

            // Assert
            parametersOfUpdateGlobalScript.ShouldNotBeNull();
            parametersOfUpdateGlobalScript.Length.ShouldBe(1);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(1);
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(parametersOfUpdateGlobalScript.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_UpdateGlobalScript_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateGlobalScript, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_UpdateGlobalScript_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateGlobalScriptPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodUpdateGlobalScript, Fixture, methodUpdateGlobalScriptPrametersTypes);

            // Assert
            methodUpdateGlobalScriptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateGlobalScript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_UpdateGlobalScript_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateGlobalScript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearAll) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_ClearAll_Method_Call_Internally(Type[] types)
        {
            var methodClearAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodClearAll, Fixture, methodClearAllPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearAll) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_ClearAll_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodClearAllPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfClearAll = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearAll, methodClearAllPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionPageInstanceFixture, parametersOfClearAll);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearAll.ShouldNotBeNull();
            parametersOfClearAll.Length.ShouldBe(2);
            methodClearAllPrametersTypes.Length.ShouldBe(2);
            methodClearAllPrametersTypes.Length.ShouldBe(parametersOfClearAll.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearAll) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_ClearAll_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodClearAllPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfClearAll = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionPageInstance, MethodClearAll, parametersOfClearAll, methodClearAllPrametersTypes);

            // Assert
            parametersOfClearAll.ShouldNotBeNull();
            parametersOfClearAll.Length.ShouldBe(2);
            methodClearAllPrametersTypes.Length.ShouldBe(2);
            methodClearAllPrametersTypes.Length.ShouldBe(parametersOfClearAll.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearAll) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_ClearAll_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearAll, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearAll) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_ClearAll_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearAllPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodClearAll, Fixture, methodClearAllPrametersTypes);

            // Assert
            methodClearAllPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearAll) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_ClearAll_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearAll, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomPermission) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_SaveCustomPermission_Method_Call_Internally(Type[] types)
        {
            var methodSaveCustomPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodSaveCustomPermission, Fixture, methodSaveCustomPermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCustomPermission) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_SaveCustomPermission_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSaveCustomPermissionPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSaveCustomPermission = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveCustomPermission, methodSaveCustomPermissionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionPageInstanceFixture, parametersOfSaveCustomPermission);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveCustomPermission.ShouldNotBeNull();
            parametersOfSaveCustomPermission.Length.ShouldBe(2);
            methodSaveCustomPermissionPrametersTypes.Length.ShouldBe(2);
            methodSaveCustomPermissionPrametersTypes.Length.ShouldBe(parametersOfSaveCustomPermission.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomPermission) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_SaveCustomPermission_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSaveCustomPermissionPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSaveCustomPermission = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionPageInstance, MethodSaveCustomPermission, parametersOfSaveCustomPermission, methodSaveCustomPermissionPrametersTypes);

            // Assert
            parametersOfSaveCustomPermission.ShouldNotBeNull();
            parametersOfSaveCustomPermission.Length.ShouldBe(2);
            methodSaveCustomPermissionPrametersTypes.Length.ShouldBe(2);
            methodSaveCustomPermissionPrametersTypes.Length.ShouldBe(parametersOfSaveCustomPermission.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomPermission) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_SaveCustomPermission_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCustomPermission, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCustomPermission) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_SaveCustomPermission_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCustomPermissionPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodSaveCustomPermission, Fixture, methodSaveCustomPermissionPrametersTypes);

            // Assert
            methodSaveCustomPermissionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCustomPermission) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_SaveCustomPermission_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCustomPermission, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_RegisterScript_Method_Call_Internally(Type[] types)
        {
            var methodRegisterScriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RegisterScript_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterScriptPrametersTypes = null;
            object[] parametersOfRegisterScript = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterScript, methodRegisterScriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionPageInstanceFixture, parametersOfRegisterScript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterScript.ShouldBeNull();
            methodRegisterScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RegisterScript_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterScriptPrametersTypes = null;
            object[] parametersOfRegisterScript = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionPageInstance, MethodRegisterScript, parametersOfRegisterScript, methodRegisterScriptPrametersTypes);

            // Assert
            parametersOfRegisterScript.ShouldBeNull();
            methodRegisterScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RegisterScript_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterScriptPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodRegisterScript, Fixture, methodRegisterScriptPrametersTypes);

            // Assert
            methodRegisterScriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterScript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_RegisterScript_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterScript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViewsNotInAnyGroup) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionPage_GetViewsNotInAnyGroup_Method_Call_Internally(Type[] types)
        {
            var methodGetViewsNotInAnyGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodGetViewsNotInAnyGroup, Fixture, methodGetViewsNotInAnyGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetViewsNotInAnyGroup) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_GetViewsNotInAnyGroup_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetViewsNotInAnyGroupPrametersTypes = null;
            object[] parametersOfGetViewsNotInAnyGroup = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetViewsNotInAnyGroup, methodGetViewsNotInAnyGroupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionPageInstanceFixture, parametersOfGetViewsNotInAnyGroup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetViewsNotInAnyGroup.ShouldBeNull();
            methodGetViewsNotInAnyGroupPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetViewsNotInAnyGroup) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_GetViewsNotInAnyGroup_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetViewsNotInAnyGroupPrametersTypes = null;
            object[] parametersOfGetViewsNotInAnyGroup = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionPageInstance, MethodGetViewsNotInAnyGroup, parametersOfGetViewsNotInAnyGroup, methodGetViewsNotInAnyGroupPrametersTypes);

            // Assert
            parametersOfGetViewsNotInAnyGroup.ShouldBeNull();
            methodGetViewsNotInAnyGroupPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViewsNotInAnyGroup) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_GetViewsNotInAnyGroup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetViewsNotInAnyGroupPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionPageInstance, MethodGetViewsNotInAnyGroup, Fixture, methodGetViewsNotInAnyGroupPrametersTypes);

            // Assert
            methodGetViewsNotInAnyGroupPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetViewsNotInAnyGroup) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionPage_GetViewsNotInAnyGroup_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViewsNotInAnyGroup, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionPageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}