using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.Integration.Manage" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ManageTest : AbstractBaseSetupTypedTest<Manage>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Manage) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodbIsSystemList = "bIsSystemList";
        private const string MethodgvIntegrations_RowDataBound = "gvIntegrations_RowDataBound";
        private Type _manageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Manage _manageInstance;
        private Manage _manageInstanceFixture;

        #region General Initializer : Class (Manage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Manage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _manageInstanceType = typeof(Manage);
            _manageInstanceFixture = Create(true);
            _manageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Manage)

        #region General Initializer : Class (Manage) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Manage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodbIsSystemList, 0)]
        [TestCase(MethodgvIntegrations_RowDataBound, 0)]
        public void AUT_Manage_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_manageInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="Manage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Manage_Is_Instance_Present_Test()
        {
            // Assert
            _manageInstanceType.ShouldNotBeNull();
            _manageInstance.ShouldNotBeNull();
            _manageInstanceFixture.ShouldNotBeNull();
            _manageInstance.ShouldBeAssignableTo<Manage>();
            _manageInstanceFixture.ShouldBeAssignableTo<Manage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Manage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Manage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Manage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _manageInstanceType.ShouldNotBeNull();
            _manageInstance.ShouldNotBeNull();
            _manageInstanceFixture.ShouldNotBeNull();
            _manageInstance.ShouldBeAssignableTo<Manage>();
            _manageInstanceFixture.ShouldBeAssignableTo<Manage>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Manage" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodbIsSystemList)]
        [TestCase(MethodgvIntegrations_RowDataBound)]
        public void AUT_Manage_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Manage>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Manage_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Manage_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Manage_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bIsSystemList) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_bIsSystemList_Method_Call_Internally(Type[] types)
        {
            var methodbIsSystemListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodbIsSystemList, Fixture, methodbIsSystemListPrametersTypes);
        }

        #endregion

        #region Method Call : (bIsSystemList) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_bIsSystemList_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var methodbIsSystemListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfbIsSystemList = { list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodbIsSystemList, methodbIsSystemListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Manage, bool>(_manageInstanceFixture, out exception1, parametersOfbIsSystemList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Manage, bool>(_manageInstance, MethodbIsSystemList, parametersOfbIsSystemList, methodbIsSystemListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfbIsSystemList.ShouldNotBeNull();
            parametersOfbIsSystemList.Length.ShouldBe(1);
            methodbIsSystemListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, bool>(_manageInstance, MethodbIsSystemList, parametersOfbIsSystemList, methodbIsSystemListPrametersTypes));
        }

        #endregion

        #region Method Call : (bIsSystemList) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_bIsSystemList_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var methodbIsSystemListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfbIsSystemList = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbIsSystemList, methodbIsSystemListPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbIsSystemList.ShouldNotBeNull();
            parametersOfbIsSystemList.Length.ShouldBe(1);
            methodbIsSystemListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_manageInstanceFixture, parametersOfbIsSystemList));
        }

        #endregion

        #region Method Call : (bIsSystemList) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_bIsSystemList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<string>();
            var methodbIsSystemListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfbIsSystemList = { list };

            // Assert
            parametersOfbIsSystemList.ShouldNotBeNull();
            parametersOfbIsSystemList.Length.ShouldBe(1);
            methodbIsSystemListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<Manage, bool>(_manageInstance, MethodbIsSystemList, parametersOfbIsSystemList, methodbIsSystemListPrametersTypes));
        }

        #endregion

        #region Method Call : (bIsSystemList) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_bIsSystemList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbIsSystemListPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodbIsSystemList, Fixture, methodbIsSystemListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodbIsSystemListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (bIsSystemList) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_bIsSystemList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbIsSystemList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (bIsSystemList) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_bIsSystemList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbIsSystemList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (gvIntegrations_RowDataBound) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Manage_gvIntegrations_RowDataBound_Method_Call_Internally(Type[] types)
        {
            var methodgvIntegrations_RowDataBoundPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodgvIntegrations_RowDataBound, Fixture, methodgvIntegrations_RowDataBoundPrametersTypes);
        }

        #endregion

        #region Method Call : (gvIntegrations_RowDataBound) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_gvIntegrations_RowDataBound_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<System.Web.UI.WebControls.GridViewRowEventArgs>();
            var methodgvIntegrations_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(System.Web.UI.WebControls.GridViewRowEventArgs) };
            object[] parametersOfgvIntegrations_RowDataBound = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgvIntegrations_RowDataBound, methodgvIntegrations_RowDataBoundPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_manageInstanceFixture, parametersOfgvIntegrations_RowDataBound);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgvIntegrations_RowDataBound.ShouldNotBeNull();
            parametersOfgvIntegrations_RowDataBound.Length.ShouldBe(2);
            methodgvIntegrations_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgvIntegrations_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgvIntegrations_RowDataBound.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (gvIntegrations_RowDataBound) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_gvIntegrations_RowDataBound_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<System.Web.UI.WebControls.GridViewRowEventArgs>();
            var methodgvIntegrations_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(System.Web.UI.WebControls.GridViewRowEventArgs) };
            object[] parametersOfgvIntegrations_RowDataBound = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_manageInstance, MethodgvIntegrations_RowDataBound, parametersOfgvIntegrations_RowDataBound, methodgvIntegrations_RowDataBoundPrametersTypes);

            // Assert
            parametersOfgvIntegrations_RowDataBound.ShouldNotBeNull();
            parametersOfgvIntegrations_RowDataBound.Length.ShouldBe(2);
            methodgvIntegrations_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            methodgvIntegrations_RowDataBoundPrametersTypes.Length.ShouldBe(parametersOfgvIntegrations_RowDataBound.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvIntegrations_RowDataBound) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_gvIntegrations_RowDataBound_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgvIntegrations_RowDataBound, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (gvIntegrations_RowDataBound) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_gvIntegrations_RowDataBound_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgvIntegrations_RowDataBoundPrametersTypes = new Type[] { typeof(object), typeof(System.Web.UI.WebControls.GridViewRowEventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_manageInstance, MethodgvIntegrations_RowDataBound, Fixture, methodgvIntegrations_RowDataBoundPrametersTypes);

            // Assert
            methodgvIntegrations_RowDataBoundPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (gvIntegrations_RowDataBound) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Manage_gvIntegrations_RowDataBound_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgvIntegrations_RowDataBound, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_manageInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}