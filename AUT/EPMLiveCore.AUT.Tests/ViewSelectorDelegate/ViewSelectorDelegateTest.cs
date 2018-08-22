using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ViewSelectorDelegate" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ViewSelectorDelegateTest : AbstractBaseSetupTypedTest<ViewSelectorDelegate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ViewSelectorDelegate) Initializer

        private const string MethodOnLoad = "OnLoad";
        private const string MethodisValidQS = "isValidQS";
        private const string MethodUserCanSeeView = "UserCanSeeView";
        private const string FieldroleProperties = "roleProperties";
        private const string FielddefaultViews = "defaultViews";
        private const string Fieldviews = "views";
        private const string FieldfeatureEnabled = "featureEnabled";
        private Type _viewSelectorDelegateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ViewSelectorDelegate _viewSelectorDelegateInstance;
        private ViewSelectorDelegate _viewSelectorDelegateInstanceFixture;

        #region General Initializer : Class (ViewSelectorDelegate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ViewSelectorDelegate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _viewSelectorDelegateInstanceType = typeof(ViewSelectorDelegate);
            _viewSelectorDelegateInstanceFixture = Create(true);
            _viewSelectorDelegateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ViewSelectorDelegate)

        #region General Initializer : Class (ViewSelectorDelegate) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ViewSelectorDelegate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodisValidQS, 0)]
        [TestCase(MethodUserCanSeeView, 0)]
        public void AUT_ViewSelectorDelegate_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_viewSelectorDelegateInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ViewSelectorDelegate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ViewSelectorDelegate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldroleProperties)]
        [TestCase(FielddefaultViews)]
        [TestCase(Fieldviews)]
        [TestCase(FieldfeatureEnabled)]
        public void AUT_ViewSelectorDelegate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_viewSelectorDelegateInstanceFixture, 
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
        ///     Class (<see cref="ViewSelectorDelegate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ViewSelectorDelegate_Is_Instance_Present_Test()
        {
            // Assert
            _viewSelectorDelegateInstanceType.ShouldNotBeNull();
            _viewSelectorDelegateInstance.ShouldNotBeNull();
            _viewSelectorDelegateInstanceFixture.ShouldNotBeNull();
            _viewSelectorDelegateInstance.ShouldBeAssignableTo<ViewSelectorDelegate>();
            _viewSelectorDelegateInstanceFixture.ShouldBeAssignableTo<ViewSelectorDelegate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ViewSelectorDelegate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ViewSelectorDelegate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ViewSelectorDelegate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _viewSelectorDelegateInstanceType.ShouldNotBeNull();
            _viewSelectorDelegateInstance.ShouldNotBeNull();
            _viewSelectorDelegateInstanceFixture.ShouldNotBeNull();
            _viewSelectorDelegateInstance.ShouldBeAssignableTo<ViewSelectorDelegate>();
            _viewSelectorDelegateInstanceFixture.ShouldBeAssignableTo<ViewSelectorDelegate>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ViewSelectorDelegate" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodisValidQS)]
        [TestCase(MethodUserCanSeeView)]
        public void AUT_ViewSelectorDelegate_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ViewSelectorDelegate>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewSelectorDelegate_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewSelectorDelegateInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewSelectorDelegateInstanceFixture, parametersOfOnLoad);

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
        public void AUT_ViewSelectorDelegate_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewSelectorDelegateInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

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
        public void AUT_ViewSelectorDelegate_OnLoad_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ViewSelectorDelegate_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewSelectorDelegateInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewSelectorDelegateInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidQS) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewSelectorDelegate_isValidQS_Method_Call_Internally(Type[] types)
        {
            var methodisValidQSPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewSelectorDelegateInstance, MethodisValidQS, Fixture, methodisValidQSPrametersTypes);
        }

        #endregion

        #region Method Call : (isValidQS) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_isValidQS_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodisValidQSPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisValidQS = { key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodisValidQS, methodisValidQSPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewSelectorDelegateInstanceFixture, parametersOfisValidQS);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisValidQS.ShouldNotBeNull();
            parametersOfisValidQS.Length.ShouldBe(1);
            methodisValidQSPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidQS) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_isValidQS_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodisValidQSPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfisValidQS = { key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewSelectorDelegate, bool>(_viewSelectorDelegateInstance, MethodisValidQS, parametersOfisValidQS, methodisValidQSPrametersTypes);

            // Assert
            parametersOfisValidQS.ShouldNotBeNull();
            parametersOfisValidQS.Length.ShouldBe(1);
            methodisValidQSPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isValidQS) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_isValidQS_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisValidQSPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewSelectorDelegateInstance, MethodisValidQS, Fixture, methodisValidQSPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisValidQSPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isValidQS) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_isValidQS_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisValidQS, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewSelectorDelegateInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isValidQS) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_isValidQS_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisValidQS, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewSelectorDelegate_UserCanSeeView_Method_Call_Internally(Type[] types)
        {
            var methodUserCanSeeViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewSelectorDelegateInstance, MethodUserCanSeeView, Fixture, methodUserCanSeeViewPrametersTypes);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_UserCanSeeView_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            object[] parametersOfUserCanSeeView = { viewId, roleProperties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserCanSeeView, methodUserCanSeeViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewSelectorDelegate, bool>(_viewSelectorDelegateInstanceFixture, out exception1, parametersOfUserCanSeeView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewSelectorDelegate, bool>(_viewSelectorDelegateInstance, MethodUserCanSeeView, parametersOfUserCanSeeView, methodUserCanSeeViewPrametersTypes);

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
        public void AUT_ViewSelectorDelegate_UserCanSeeView_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            object[] parametersOfUserCanSeeView = { viewId, roleProperties };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUserCanSeeView, methodUserCanSeeViewPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ViewSelectorDelegate, bool>(_viewSelectorDelegateInstanceFixture, out exception1, parametersOfUserCanSeeView);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ViewSelectorDelegate, bool>(_viewSelectorDelegateInstance, MethodUserCanSeeView, parametersOfUserCanSeeView, methodUserCanSeeViewPrametersTypes);

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
        public void AUT_ViewSelectorDelegate_UserCanSeeView_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var viewId = CreateType<string>();
            var roleProperties = CreateType<Dictionary<int, Dictionary<string, bool>>>();
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            object[] parametersOfUserCanSeeView = { viewId, roleProperties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ViewSelectorDelegate, bool>(_viewSelectorDelegateInstance, MethodUserCanSeeView, parametersOfUserCanSeeView, methodUserCanSeeViewPrametersTypes);

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
        public void AUT_ViewSelectorDelegate_UserCanSeeView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUserCanSeeViewPrametersTypes = new Type[] { typeof(string), typeof(Dictionary<int, Dictionary<string, bool>>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewSelectorDelegateInstance, MethodUserCanSeeView, Fixture, methodUserCanSeeViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUserCanSeeViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_UserCanSeeView_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUserCanSeeView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewSelectorDelegateInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UserCanSeeView) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewSelectorDelegate_UserCanSeeView_Method_Call_Parameters_Count_Verification_Test()
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

        #endregion

        #endregion
    }
}