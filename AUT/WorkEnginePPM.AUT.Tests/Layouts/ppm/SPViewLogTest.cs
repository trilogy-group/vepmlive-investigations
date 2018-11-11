using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.SPViewLog" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SPViewLogTest : AbstractBaseSetupTypedTest<SPViewLog>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SPViewLog) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodExecuteProcess = "ExecuteProcess";
        private const string MethodExecuteProcessEx = "ExecuteProcessEx";
        private const string MethodpopulateStatus = "populateStatus";
        private const string Fieldurl = "url";
        private const string FielddtFields = "dtFields";
        private Type _sPViewLogInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SPViewLog _sPViewLogInstance;
        private SPViewLog _sPViewLogInstanceFixture;

        #region General Initializer : Class (SPViewLog) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SPViewLog" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sPViewLogInstanceType = typeof(SPViewLog);
            _sPViewLogInstanceFixture = Create(true);
            _sPViewLogInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SPViewLog)

        #region General Initializer : Class (SPViewLog) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SPViewLog" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodExecuteProcess, 0)]
        [TestCase(MethodExecuteProcessEx, 0)]
        [TestCase(MethodpopulateStatus, 0)]
        public void AUT_SPViewLog_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sPViewLogInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SPViewLog) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SPViewLog" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldurl)]
        [TestCase(FielddtFields)]
        public void AUT_SPViewLog_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sPViewLogInstanceFixture, 
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
        ///     Class (<see cref="SPViewLog" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SPViewLog_Is_Instance_Present_Test()
        {
            // Assert
            _sPViewLogInstanceType.ShouldNotBeNull();
            _sPViewLogInstance.ShouldNotBeNull();
            _sPViewLogInstanceFixture.ShouldNotBeNull();
            _sPViewLogInstance.ShouldBeAssignableTo<SPViewLog>();
            _sPViewLogInstanceFixture.ShouldBeAssignableTo<SPViewLog>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SPViewLog) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SPViewLog_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SPViewLog instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sPViewLogInstanceType.ShouldNotBeNull();
            _sPViewLogInstance.ShouldNotBeNull();
            _sPViewLogInstanceFixture.ShouldNotBeNull();
            _sPViewLogInstance.ShouldBeAssignableTo<SPViewLog>();
            _sPViewLogInstanceFixture.ShouldBeAssignableTo<SPViewLog>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="SPViewLog" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodExecuteProcess)]
        [TestCase(MethodExecuteProcessEx)]
        public void AUT_SPViewLog_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_sPViewLogInstanceFixture,
                                                                              _sPViewLogInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SPViewLog" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodpopulateStatus)]
        public void AUT_SPViewLog_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SPViewLog>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPViewLog_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPViewLogInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPViewLogInstanceFixture, parametersOfPage_Load);

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
        public void AUT_SPViewLog_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sPViewLogInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_SPViewLog_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_SPViewLog_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPViewLogInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sPViewLogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteProcess) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPViewLog_ExecuteProcess_Static_Method_Call_Internally(Type[] types)
        {
            var methodExecuteProcessPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPViewLogInstanceFixture, _sPViewLogInstanceType, MethodExecuteProcess, Fixture, methodExecuteProcessPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteProcess) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcess_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sXMLRequest = CreateType<string>();
            var xNode = CreateType<XmlNode>();
            var methodExecuteProcessPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(XmlNode) };
            object[] parametersOfExecuteProcess = { sContext, sXMLRequest, xNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteProcess, methodExecuteProcessPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPViewLogInstanceFixture, parametersOfExecuteProcess);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteProcess.ShouldNotBeNull();
            parametersOfExecuteProcess.Length.ShouldBe(3);
            methodExecuteProcessPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteProcess) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcess_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sXMLRequest = CreateType<string>();
            var xNode = CreateType<XmlNode>();
            var methodExecuteProcessPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(XmlNode) };
            object[] parametersOfExecuteProcess = { sContext, sXMLRequest, xNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_sPViewLogInstanceFixture, _sPViewLogInstanceType, MethodExecuteProcess, parametersOfExecuteProcess, methodExecuteProcessPrametersTypes);

            // Assert
            parametersOfExecuteProcess.ShouldNotBeNull();
            parametersOfExecuteProcess.Length.ShouldBe(3);
            methodExecuteProcessPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteProcess) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcess_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteProcessPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(XmlNode) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPViewLogInstanceFixture, _sPViewLogInstanceType, MethodExecuteProcess, Fixture, methodExecuteProcessPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteProcessPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteProcess) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcess_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteProcess, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPViewLogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExecuteProcess) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcess_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteProcess, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteProcessEx) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPViewLog_ExecuteProcessEx_Static_Method_Call_Internally(Type[] types)
        {
            var methodExecuteProcessExPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPViewLogInstanceFixture, _sPViewLogInstanceType, MethodExecuteProcessEx, Fixture, methodExecuteProcessExPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteProcessEx) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcessEx_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sURL = CreateType<string>();
            var sContext = CreateType<string>();
            var sXMLRequest = CreateType<string>();
            var xNode = CreateType<XmlNode>();
            var methodExecuteProcessExPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(XmlNode) };
            object[] parametersOfExecuteProcessEx = { sURL, sContext, sXMLRequest, xNode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteProcessEx, methodExecuteProcessExPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPViewLogInstanceFixture, parametersOfExecuteProcessEx);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteProcessEx.ShouldNotBeNull();
            parametersOfExecuteProcessEx.Length.ShouldBe(4);
            methodExecuteProcessExPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteProcessEx) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcessEx_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sURL = CreateType<string>();
            var sContext = CreateType<string>();
            var sXMLRequest = CreateType<string>();
            var xNode = CreateType<XmlNode>();
            var methodExecuteProcessExPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(XmlNode) };
            object[] parametersOfExecuteProcessEx = { sURL, sContext, sXMLRequest, xNode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_sPViewLogInstanceFixture, _sPViewLogInstanceType, MethodExecuteProcessEx, parametersOfExecuteProcessEx, methodExecuteProcessExPrametersTypes);

            // Assert
            parametersOfExecuteProcessEx.ShouldNotBeNull();
            parametersOfExecuteProcessEx.Length.ShouldBe(4);
            methodExecuteProcessExPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteProcessEx) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcessEx_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteProcessExPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(XmlNode) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sPViewLogInstanceFixture, _sPViewLogInstanceType, MethodExecuteProcessEx, Fixture, methodExecuteProcessExPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteProcessExPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteProcessEx) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcessEx_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteProcessEx, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sPViewLogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ExecuteProcessEx) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_ExecuteProcessEx_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteProcessEx, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (populateStatus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SPViewLog_populateStatus_Method_Call_Internally(Type[] types)
        {
            var methodpopulateStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPViewLogInstance, MethodpopulateStatus, Fixture, methodpopulateStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (populateStatus) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_populateStatus_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodpopulateStatusPrametersTypes = null;
            object[] parametersOfpopulateStatus = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodpopulateStatus, methodpopulateStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sPViewLogInstanceFixture, parametersOfpopulateStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfpopulateStatus.ShouldBeNull();
            methodpopulateStatusPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (populateStatus) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_populateStatus_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodpopulateStatusPrametersTypes = null;
            object[] parametersOfpopulateStatus = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sPViewLogInstance, MethodpopulateStatus, parametersOfpopulateStatus, methodpopulateStatusPrametersTypes);

            // Assert
            parametersOfpopulateStatus.ShouldBeNull();
            methodpopulateStatusPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateStatus) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_populateStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodpopulateStatusPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sPViewLogInstance, MethodpopulateStatus, Fixture, methodpopulateStatusPrametersTypes);

            // Assert
            methodpopulateStatusPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (populateStatus) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SPViewLog_populateStatus_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodpopulateStatus, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sPViewLogInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}