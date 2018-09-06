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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DBALog" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DBALogTest : AbstractBaseSetupTypedTest<DBALog>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DBALog) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodPage_Reload = "Page_Reload";
        private const string MethodbtnRefresh_Click = "btnRefresh_Click";
        private const string MethodbtnPrevious_Click = "btnPrevious_Click";
        private const string MethodbtnNext_Click = "btnNext_Click";
        private const string FieldstrOutput = "strOutput";
        private const string FieldRPETitle = "RPETitle";
        private Type _dBALogInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DBALog _dBALogInstance;
        private DBALog _dBALogInstanceFixture;

        #region General Initializer : Class (DBALog) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DBALog" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dBALogInstanceType = typeof(DBALog);
            _dBALogInstanceFixture = Create(true);
            _dBALogInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DBALog)

        #region General Initializer : Class (DBALog) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DBALog" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodPage_Reload, 0)]
        [TestCase(MethodbtnRefresh_Click, 0)]
        [TestCase(MethodbtnPrevious_Click, 0)]
        [TestCase(MethodbtnNext_Click, 0)]
        public void AUT_DBALog_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_dBALogInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DBALog) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DBALog" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldstrOutput)]
        [TestCase(FieldRPETitle)]
        public void AUT_DBALog_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dBALogInstanceFixture, 
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
        ///     Class (<see cref="DBALog" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DBALog_Is_Instance_Present_Test()
        {
            // Assert
            _dBALogInstanceType.ShouldNotBeNull();
            _dBALogInstance.ShouldNotBeNull();
            _dBALogInstanceFixture.ShouldNotBeNull();
            _dBALogInstance.ShouldBeAssignableTo<DBALog>();
            _dBALogInstanceFixture.ShouldBeAssignableTo<DBALog>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DBALog) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DBALog_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DBALog instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dBALogInstanceType.ShouldNotBeNull();
            _dBALogInstance.ShouldNotBeNull();
            _dBALogInstanceFixture.ShouldNotBeNull();
            _dBALogInstance.ShouldBeAssignableTo<DBALog>();
            _dBALogInstanceFixture.ShouldBeAssignableTo<DBALog>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="DBALog" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodPage_Reload)]
        [TestCase(MethodbtnRefresh_Click)]
        [TestCase(MethodbtnPrevious_Click)]
        [TestCase(MethodbtnNext_Click)]
        public void AUT_DBALog_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DBALog>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBALog_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dBALogInstanceFixture, parametersOfPage_Load);

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
        public void AUT_DBALog_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dBALogInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_DBALog_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_DBALog_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dBALogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Reload) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBALog_Page_Reload_Method_Call_Internally(Type[] types)
        {
            var methodPage_ReloadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodPage_Reload, Fixture, methodPage_ReloadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Reload) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_Page_Reload_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_ReloadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Reload = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Reload, methodPage_ReloadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dBALogInstanceFixture, parametersOfPage_Reload);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Reload.ShouldNotBeNull();
            parametersOfPage_Reload.Length.ShouldBe(2);
            methodPage_ReloadPrametersTypes.Length.ShouldBe(2);
            methodPage_ReloadPrametersTypes.Length.ShouldBe(parametersOfPage_Reload.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Reload) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_Page_Reload_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_ReloadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Reload = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dBALogInstance, MethodPage_Reload, parametersOfPage_Reload, methodPage_ReloadPrametersTypes);

            // Assert
            parametersOfPage_Reload.ShouldNotBeNull();
            parametersOfPage_Reload.Length.ShouldBe(2);
            methodPage_ReloadPrametersTypes.Length.ShouldBe(2);
            methodPage_ReloadPrametersTypes.Length.ShouldBe(parametersOfPage_Reload.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Reload) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_Page_Reload_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Reload, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Reload) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_Page_Reload_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_ReloadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodPage_Reload, Fixture, methodPage_ReloadPrametersTypes);

            // Assert
            methodPage_ReloadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Reload) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_Page_Reload_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Reload, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dBALogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBALog_btnRefresh_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnRefresh_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodbtnRefresh_Click, Fixture, methodbtnRefresh_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnRefresh_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRefresh_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRefresh_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnRefresh_Click, methodbtnRefresh_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dBALogInstanceFixture, parametersOfbtnRefresh_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnRefresh_Click.ShouldNotBeNull();
            parametersOfbtnRefresh_Click.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRefresh_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnRefresh_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnRefresh_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnRefresh_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dBALogInstance, MethodbtnRefresh_Click, parametersOfbtnRefresh_Click, methodbtnRefresh_ClickPrametersTypes);

            // Assert
            parametersOfbtnRefresh_Click.ShouldNotBeNull();
            parametersOfbtnRefresh_Click.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnRefresh_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnRefresh_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnRefresh_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnRefresh_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnRefresh_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodbtnRefresh_Click, Fixture, methodbtnRefresh_ClickPrametersTypes);

            // Assert
            methodbtnRefresh_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnRefresh_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnRefresh_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnRefresh_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dBALogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnPrevious_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBALog_btnPrevious_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnPrevious_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodbtnPrevious_Click, Fixture, methodbtnPrevious_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnPrevious_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnPrevious_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnPrevious_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnPrevious_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnPrevious_Click, methodbtnPrevious_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dBALogInstanceFixture, parametersOfbtnPrevious_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnPrevious_Click.ShouldNotBeNull();
            parametersOfbtnPrevious_Click.Length.ShouldBe(2);
            methodbtnPrevious_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnPrevious_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnPrevious_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnPrevious_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnPrevious_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnPrevious_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnPrevious_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dBALogInstance, MethodbtnPrevious_Click, parametersOfbtnPrevious_Click, methodbtnPrevious_ClickPrametersTypes);

            // Assert
            parametersOfbtnPrevious_Click.ShouldNotBeNull();
            parametersOfbtnPrevious_Click.Length.ShouldBe(2);
            methodbtnPrevious_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnPrevious_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnPrevious_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnPrevious_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnPrevious_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnPrevious_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnPrevious_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnPrevious_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnPrevious_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodbtnPrevious_Click, Fixture, methodbtnPrevious_ClickPrametersTypes);

            // Assert
            methodbtnPrevious_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnPrevious_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnPrevious_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnPrevious_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dBALogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBALog_btnNext_Click_Method_Call_Internally(Type[] types)
        {
            var methodbtnNext_ClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodbtnNext_Click, Fixture, methodbtnNext_ClickPrametersTypes);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnNext_Click_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnNext_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnNext_Click = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbtnNext_Click, methodbtnNext_ClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dBALogInstanceFixture, parametersOfbtnNext_Click);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbtnNext_Click.ShouldNotBeNull();
            parametersOfbtnNext_Click.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnNext_Click.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnNext_Click_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodbtnNext_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfbtnNext_Click = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dBALogInstance, MethodbtnNext_Click, parametersOfbtnNext_Click, methodbtnNext_ClickPrametersTypes);

            // Assert
            parametersOfbtnNext_Click.ShouldNotBeNull();
            parametersOfbtnNext_Click.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(2);
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(parametersOfbtnNext_Click.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnNext_Click_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbtnNext_Click, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnNext_Click_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbtnNext_ClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBALogInstance, MethodbtnNext_Click, Fixture, methodbtnNext_ClickPrametersTypes);

            // Assert
            methodbtnNext_ClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (btnNext_Click) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DBALog_btnNext_Click_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbtnNext_Click, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dBALogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}