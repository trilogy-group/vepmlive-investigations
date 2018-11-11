using System;
using System.Collections.Generic;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ViewPermissionSelectorMenu" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ViewPermissionSelectorMenuTest : AbstractBaseSetupTypedTest<ViewPermissionSelectorMenu>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ViewPermissionSelectorMenu) Initializer

        private const string MethodOnLoad = "OnLoad";
        private const string MethodRender = "Render";
        private const string MethodUserCanSeeView = "UserCanSeeView";
        private const string MethodGoToDefaultView = "GoToDefaultView";
        private const string MethodComeFromView = "ComeFromView";
        private const string FieldroleProperties = "roleProperties";
        private const string FielddefaultViews = "defaultViews";
        private const string Fieldviews = "views";
        private const string FieldfeatureEnabled = "featureEnabled";
        private Type _viewPermissionSelectorMenuInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ViewPermissionSelectorMenu _viewPermissionSelectorMenuInstance;
        private ViewPermissionSelectorMenu _viewPermissionSelectorMenuInstanceFixture;

        #region General Initializer : Class (ViewPermissionSelectorMenu) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ViewPermissionSelectorMenu" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _viewPermissionSelectorMenuInstanceType = typeof(ViewPermissionSelectorMenu);
            _viewPermissionSelectorMenuInstanceFixture = Create(true);
            _viewPermissionSelectorMenuInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ViewPermissionSelectorMenu)

        #region General Initializer : Class (ViewPermissionSelectorMenu) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ViewPermissionSelectorMenu" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodRender, 0)]
        [TestCase(MethodUserCanSeeView, 0)]
        [TestCase(MethodGoToDefaultView, 0)]
        [TestCase(MethodComeFromView, 0)]
        public void AUT_ViewPermissionSelectorMenu_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_viewPermissionSelectorMenuInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ViewPermissionSelectorMenu) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ViewPermissionSelectorMenu" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldroleProperties)]
        [TestCase(FielddefaultViews)]
        [TestCase(Fieldviews)]
        [TestCase(FieldfeatureEnabled)]
        public void AUT_ViewPermissionSelectorMenu_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_viewPermissionSelectorMenuInstanceFixture, 
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
        ///     Class (<see cref="ViewPermissionSelectorMenu" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ViewPermissionSelectorMenu_Is_Instance_Present_Test()
        {
            // Assert
            _viewPermissionSelectorMenuInstanceType.ShouldNotBeNull();
            _viewPermissionSelectorMenuInstance.ShouldNotBeNull();
            _viewPermissionSelectorMenuInstanceFixture.ShouldNotBeNull();
            _viewPermissionSelectorMenuInstance.ShouldBeAssignableTo<ViewPermissionSelectorMenu>();
            _viewPermissionSelectorMenuInstanceFixture.ShouldBeAssignableTo<ViewPermissionSelectorMenu>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ViewPermissionSelectorMenu) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ViewPermissionSelectorMenu_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ViewPermissionSelectorMenu instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _viewPermissionSelectorMenuInstanceType.ShouldNotBeNull();
            _viewPermissionSelectorMenuInstance.ShouldNotBeNull();
            _viewPermissionSelectorMenuInstanceFixture.ShouldNotBeNull();
            _viewPermissionSelectorMenuInstance.ShouldBeAssignableTo<ViewPermissionSelectorMenu>();
            _viewPermissionSelectorMenuInstanceFixture.ShouldBeAssignableTo<ViewPermissionSelectorMenu>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ViewPermissionSelectorMenu" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodRender)]
        [TestCase(MethodUserCanSeeView)]
        [TestCase(MethodGoToDefaultView)]
        [TestCase(MethodComeFromView)]
        public void AUT_ViewPermissionSelectorMenu_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ViewPermissionSelectorMenu>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionSelectorMenu_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionSelectorMenuInstanceFixture, parametersOfOnLoad);

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
        public void AUT_ViewPermissionSelectorMenu_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionSelectorMenuInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

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
        public void AUT_ViewPermissionSelectorMenu_OnLoad_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ViewPermissionSelectorMenu_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionSelectorMenuInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionSelectorMenu_Render_Method_Call_Internally(Type[] types)
        {
            var methodRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodRender, Fixture, methodRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_Render_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<System.Web.UI.HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };
            object[] parametersOfRender = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRender, methodRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewPermissionSelectorMenuInstanceFixture, parametersOfRender);

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
        public void AUT_ViewPermissionSelectorMenu_Render_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<System.Web.UI.HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };
            object[] parametersOfRender = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewPermissionSelectorMenuInstance, MethodRender, parametersOfRender, methodRenderPrametersTypes);

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
        public void AUT_ViewPermissionSelectorMenu_Render_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ViewPermissionSelectorMenu_Render_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPrametersTypes = new Type[] { typeof(System.Web.UI.HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodRender, Fixture, methodRenderPrametersTypes);

            // Assert
            methodRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_Render_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionSelectorMenuInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionSelectorMenu_UserCanSeeView_Method_Call_Internally(Type[] types)
        {
            var methodUserCanSeeViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodUserCanSeeView, Fixture, methodUserCanSeeViewPrametersTypes);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_UserCanSeeView_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            object[] parametersOfUserCanSeeView = { viewId, roleProperties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserCanSeeView, methodUserCanSeeViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstanceFixture, out exception1, parametersOfUserCanSeeView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstance, MethodUserCanSeeView, parametersOfUserCanSeeView, methodUserCanSeeViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUserCanSeeView.ShouldNotBeNull();
            parametersOfUserCanSeeView.Length.ShouldBe(2);
            methodUserCanSeeViewPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_UserCanSeeView_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            object[] parametersOfUserCanSeeView = { viewId, roleProperties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserCanSeeView, methodUserCanSeeViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstanceFixture, out exception1, parametersOfUserCanSeeView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstance, MethodUserCanSeeView, parametersOfUserCanSeeView, methodUserCanSeeViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfUserCanSeeView.ShouldNotBeNull();
            parametersOfUserCanSeeView.Length.ShouldBe(2);
            methodUserCanSeeViewPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_UserCanSeeView_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            object[] parametersOfUserCanSeeView = { viewId, roleProperties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstance, MethodUserCanSeeView, parametersOfUserCanSeeView, methodUserCanSeeViewPrametersTypes);

            // Assert
            parametersOfUserCanSeeView.ShouldNotBeNull();
            parametersOfUserCanSeeView.Length.ShouldBe(2);
            methodUserCanSeeViewPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_UserCanSeeView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodUserCanSeeView, Fixture, methodUserCanSeeViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUserCanSeeViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_UserCanSeeView_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUserCanSeeView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionSelectorMenuInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_UserCanSeeView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUserCanSeeView, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GoToDefaultView) (Return Type : SPView) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionSelectorMenu_GoToDefaultView_Method_Call_Internally(Type[] types)
        {
            var methodGoToDefaultViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodGoToDefaultView, Fixture, methodGoToDefaultViewPrametersTypes);
        }

        #endregion

        #region Method Call : (GoToDefaultView) (Return Type : SPView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_GoToDefaultView_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var defaultViews = CreateType<Dictionary<int, string>>();
            var methodGoToDefaultViewPrametersTypes = new Type[] { typeof(Dictionary<int, string>) };
            object[] parametersOfGoToDefaultView = { defaultViews };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGoToDefaultView, methodGoToDefaultViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionSelectorMenu, SPView>(_viewPermissionSelectorMenuInstanceFixture, out exception1, parametersOfGoToDefaultView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, SPView>(_viewPermissionSelectorMenuInstance, MethodGoToDefaultView, parametersOfGoToDefaultView, methodGoToDefaultViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGoToDefaultView.ShouldNotBeNull();
            parametersOfGoToDefaultView.Length.ShouldBe(1);
            methodGoToDefaultViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GoToDefaultView) (Return Type : SPView) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_GoToDefaultView_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var defaultViews = CreateType<Dictionary<int, string>>();
            var methodGoToDefaultViewPrametersTypes = new Type[] { typeof(Dictionary<int, string>) };
            object[] parametersOfGoToDefaultView = { defaultViews };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, SPView>(_viewPermissionSelectorMenuInstance, MethodGoToDefaultView, parametersOfGoToDefaultView, methodGoToDefaultViewPrametersTypes);

            // Assert
            parametersOfGoToDefaultView.ShouldNotBeNull();
            parametersOfGoToDefaultView.Length.ShouldBe(1);
            methodGoToDefaultViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GoToDefaultView) (Return Type : SPView) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_GoToDefaultView_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGoToDefaultViewPrametersTypes = new Type[] { typeof(Dictionary<int, string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodGoToDefaultView, Fixture, methodGoToDefaultViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGoToDefaultViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GoToDefaultView) (Return Type : SPView) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_GoToDefaultView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGoToDefaultViewPrametersTypes = new Type[] { typeof(Dictionary<int, string>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodGoToDefaultView, Fixture, methodGoToDefaultViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGoToDefaultViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GoToDefaultView) (Return Type : SPView) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_GoToDefaultView_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGoToDefaultView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionSelectorMenuInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GoToDefaultView) (Return Type : SPView) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_GoToDefaultView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGoToDefaultView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ComeFromView) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewPermissionSelectorMenu_ComeFromView_Method_Call_Internally(Type[] types)
        {
            var methodComeFromViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodComeFromView, Fixture, methodComeFromViewPrametersTypes);
        }

        #endregion

        #region Method Call : (ComeFromView) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_ComeFromView_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodComeFromViewPrametersTypes = null;
            object[] parametersOfComeFromView = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodComeFromView, methodComeFromViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstanceFixture, out exception1, parametersOfComeFromView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstance, MethodComeFromView, parametersOfComeFromView, methodComeFromViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfComeFromView.ShouldBeNull();
            methodComeFromViewPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ComeFromView) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_ComeFromView_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodComeFromViewPrametersTypes = null;
            object[] parametersOfComeFromView = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodComeFromView, methodComeFromViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstanceFixture, out exception1, parametersOfComeFromView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstance, MethodComeFromView, parametersOfComeFromView, methodComeFromViewPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfComeFromView.ShouldBeNull();
            methodComeFromViewPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ComeFromView) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_ComeFromView_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodComeFromViewPrametersTypes = null;
            object[] parametersOfComeFromView = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewPermissionSelectorMenu, bool>(_viewPermissionSelectorMenuInstance, MethodComeFromView, parametersOfComeFromView, methodComeFromViewPrametersTypes);

            // Assert
            parametersOfComeFromView.ShouldBeNull();
            methodComeFromViewPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ComeFromView) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_ComeFromView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodComeFromViewPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewPermissionSelectorMenuInstance, MethodComeFromView, Fixture, methodComeFromViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodComeFromViewPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ComeFromView) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewPermissionSelectorMenu_ComeFromView_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodComeFromView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewPermissionSelectorMenuInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}