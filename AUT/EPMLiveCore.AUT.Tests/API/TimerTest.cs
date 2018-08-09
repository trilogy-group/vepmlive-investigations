using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Timer" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TimerTest : AbstractBaseSetupTypedTest<Timer>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Timer) Initializer

        private const string MethodGetTimerJobStatus = "GetTimerJobStatus";
        private const string MethodEnqueue = "Enqueue";
        private const string MethodAddTimerJob = "AddTimerJob";
        private const string MethodUpdateTimerJob = "UpdateTimerJob";
        private const string MethodCancelTimerJob = "CancelTimerJob";
        private const string MethodIsImportResourceAlreadyRunning = "IsImportResourceAlreadyRunning";
        private const string MethodIsSecurityJobAlreadyRunning = "IsSecurityJobAlreadyRunning";
        private Type _timerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Timer _timerInstance;
        private Timer _timerInstanceFixture;

        #region General Initializer : Class (Timer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Timer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timerInstanceType = typeof(Timer);
            _timerInstanceFixture = Create(true);
            _timerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Timer)

        #region General Initializer : Class (Timer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Timer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetTimerJobStatus, 0)]
        [TestCase(MethodGetTimerJobStatus, 1)]
        [TestCase(MethodGetTimerJobStatus, 2)]
        [TestCase(MethodEnqueue, 0)]
        [TestCase(MethodAddTimerJob, 0)]
        [TestCase(MethodUpdateTimerJob, 0)]
        [TestCase(MethodAddTimerJob, 1)]
        [TestCase(MethodAddTimerJob, 2)]
        [TestCase(MethodAddTimerJob, 3)]
        [TestCase(MethodCancelTimerJob, 0)]
        [TestCase(MethodIsImportResourceAlreadyRunning, 0)]
        [TestCase(MethodIsSecurityJobAlreadyRunning, 0)]
        public void AUT_Timer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timerInstanceFixture, 
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
        ///     Class (<see cref="Timer" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Timer_Is_Instance_Present_Test()
        {
            // Assert
            _timerInstanceType.ShouldNotBeNull();
            _timerInstance.ShouldNotBeNull();
            _timerInstanceFixture.ShouldNotBeNull();
            _timerInstance.ShouldBeAssignableTo<Timer>();
            _timerInstanceFixture.ShouldBeAssignableTo<Timer>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Timer) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Timer_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Timer instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _timerInstanceType.ShouldNotBeNull();
            _timerInstance.ShouldNotBeNull();
            _timerInstanceFixture.ShouldNotBeNull();
            _timerInstance.ShouldBeAssignableTo<Timer>();
            _timerInstanceFixture.ShouldBeAssignableTo<Timer>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Timer" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetTimerJobStatus)]
        [TestCase(MethodEnqueue)]
        [TestCase(MethodAddTimerJob)]
        [TestCase(MethodUpdateTimerJob)]
        [TestCase(MethodCancelTimerJob)]
        [TestCase(MethodIsImportResourceAlreadyRunning)]
        [TestCase(MethodIsSecurityJobAlreadyRunning)]
        public void AUT_Timer_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_timerInstanceFixture,
                                                                              _timerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTimerJobStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var jobtype = CreateType<int>();
            var getResultText = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.GetTimerJobStatus(siteid, webid, jobtype, getResultText);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var jobtype = CreateType<int>();
            var getResultText = CreateType<bool>();
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(bool) };
            object[] parametersOfGetTimerJobStatus = { siteid, webid, jobtype, getResultText };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, parametersOfGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfGetTimerJobStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTimerJobStatus.ShouldNotBeNull();
            parametersOfGetTimerJobStatus.Length.ShouldBe(4);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var jobtype = CreateType<int>();
            var getResultText = CreateType<bool>();
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(bool) };
            object[] parametersOfGetTimerJobStatus = { siteid, webid, jobtype, getResultText };

            // Assert
            parametersOfGetTimerJobStatus.ShouldNotBeNull();
            parametersOfGetTimerJobStatus.Length.ShouldBe(4);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, parametersOfGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(int), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_GetTimerJobStatus_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetTimerJobStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid?>();
            var listid = CreateType<Guid?>();
            var itemid = CreateType<int?>();
            var jobtype = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.GetTimerJobStatus(siteid, webid, listid, itemid, jobtype);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid?>();
            var listid = CreateType<Guid?>();
            var itemid = CreateType<int?>();
            var jobtype = CreateType<int>();
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid?), typeof(Guid?), typeof(int?), typeof(int) };
            object[] parametersOfGetTimerJobStatus = { siteid, webid, listid, itemid, jobtype };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, parametersOfGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfGetTimerJobStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTimerJobStatus.ShouldNotBeNull();
            parametersOfGetTimerJobStatus.Length.ShouldBe(5);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid?>();
            var listid = CreateType<Guid?>();
            var itemid = CreateType<int?>();
            var jobtype = CreateType<int>();
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid?), typeof(Guid?), typeof(int?), typeof(int) };
            object[] parametersOfGetTimerJobStatus = { siteid, webid, listid, itemid, jobtype };

            // Assert
            parametersOfGetTimerJobStatus.ShouldNotBeNull();
            parametersOfGetTimerJobStatus.Length.ShouldBe(5);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, parametersOfGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid?), typeof(Guid?), typeof(int?), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid?), typeof(Guid?), typeof(int?), typeof(int) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, 1);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_GetTimerJobStatus_Static_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodGetTimerJobStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var timerjobuid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.GetTimerJobStatus(web, timerjobuid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_2_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var timerjobuid = CreateType<Guid>();
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            object[] parametersOfGetTimerJobStatus = { web, timerjobuid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, parametersOfGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfGetTimerJobStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTimerJobStatus.ShouldNotBeNull();
            parametersOfGetTimerJobStatus.Length.ShouldBe(2);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var timerjobuid = CreateType<Guid>();
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            object[] parametersOfGetTimerJobStatus = { web, timerjobuid };

            // Assert
            parametersOfGetTimerJobStatus.ShouldNotBeNull();
            parametersOfGetTimerJobStatus.Length.ShouldBe(2);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<XmlNode>(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, parametersOfGetTimerJobStatus, methodGetTimerJobStatusPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTimerJobStatusPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodGetTimerJobStatus, Fixture, methodGetTimerJobStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTimerJobStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTimerJobStatus) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_GetTimerJobStatus_Static_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTimerJobStatus, 2);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Enqueue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_Enqueue_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnqueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodEnqueue, Fixture, methodEnqueuePrametersTypes);
        }

        #endregion

        #region Method Call : (Enqueue) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_Enqueue_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.Enqueue(timerjobuid, defaultstatus, site);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Enqueue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_Enqueue_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            var methodEnqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };
            object[] parametersOfEnqueue = { timerjobuid, defaultstatus, site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnqueue, methodEnqueuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfEnqueue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnqueue.ShouldNotBeNull();
            parametersOfEnqueue.Length.ShouldBe(3);
            methodEnqueuePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Enqueue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_Enqueue_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            var methodEnqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };
            object[] parametersOfEnqueue = { timerjobuid, defaultstatus, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_timerInstanceFixture, _timerInstanceType, MethodEnqueue, parametersOfEnqueue, methodEnqueuePrametersTypes);

            // Assert
            parametersOfEnqueue.ShouldNotBeNull();
            parametersOfEnqueue.Length.ShouldBe(3);
            methodEnqueuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Enqueue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_Enqueue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnqueue, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Enqueue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_Enqueue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodEnqueue, Fixture, methodEnqueuePrametersTypes);

            // Assert
            methodEnqueuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Enqueue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_Enqueue_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnqueue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_AddTimerJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var jobname = CreateType<string>();
            var jobtype = CreateType<int>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.AddTimerJob(siteid, webid, listid, itemid, jobname, jobtype, data, key, runtime, scheduletype, days);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var jobname = CreateType<string>();
            var jobtype = CreateType<int>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfAddTimerJob = { siteid, webid, listid, itemid, jobname, jobtype, data, key, runtime, scheduletype, days };

            // Assert
            parametersOfAddTimerJob.ShouldNotBeNull();
            parametersOfAddTimerJob.Length.ShouldBe(11);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(11);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, parametersOfAddTimerJob, methodAddTimerJobPrametersTypes));
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddTimerJobPrametersTypes.Length.ShouldBe(11);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 11;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTimerJob, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTimerJob, 0);
            const int parametersCount = 11;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateTimerJob) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_UpdateTimerJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodUpdateTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodUpdateTimerJob, Fixture, methodUpdateTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateTimerJob) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_UpdateTimerJob_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var cn = CreateType<SqlConnection>();
            var timerjobuid = CreateType<Guid>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            var methodUpdateTimerJobPrametersTypes = new Type[] { typeof(SqlConnection), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfUpdateTimerJob = { cn, timerjobuid, data, key, runtime, scheduletype, days };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateTimerJob, methodUpdateTimerJobPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfUpdateTimerJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateTimerJob.ShouldNotBeNull();
            parametersOfUpdateTimerJob.Length.ShouldBe(7);
            methodUpdateTimerJobPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTimerJob) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_UpdateTimerJob_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cn = CreateType<SqlConnection>();
            var timerjobuid = CreateType<Guid>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            var methodUpdateTimerJobPrametersTypes = new Type[] { typeof(SqlConnection), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfUpdateTimerJob = { cn, timerjobuid, data, key, runtime, scheduletype, days };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_timerInstanceFixture, _timerInstanceType, MethodUpdateTimerJob, parametersOfUpdateTimerJob, methodUpdateTimerJobPrametersTypes);

            // Assert
            parametersOfUpdateTimerJob.ShouldNotBeNull();
            parametersOfUpdateTimerJob.Length.ShouldBe(7);
            methodUpdateTimerJobPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTimerJob) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_UpdateTimerJob_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateTimerJob, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateTimerJob) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_UpdateTimerJob_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateTimerJobPrametersTypes = new Type[] { typeof(SqlConnection), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodUpdateTimerJob, Fixture, methodUpdateTimerJobPrametersTypes);

            // Assert
            methodUpdateTimerJobPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTimerJob) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_UpdateTimerJob_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateTimerJob, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_AddTimerJob_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cn = CreateType<SqlConnection>();
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid?>();
            var listid = CreateType<Guid?>();
            var itemid = CreateType<int?>();
            var jobname = CreateType<string>();
            var jobtype = CreateType<int>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int?>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(SqlConnection), typeof(Guid), typeof(Guid?), typeof(Guid?), typeof(int?), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int?), typeof(int), typeof(string) };
            object[] parametersOfAddTimerJob = { cn, siteid, webid, listid, itemid, jobname, jobtype, data, key, runtime, scheduletype, days };

            // Assert
            parametersOfAddTimerJob.ShouldNotBeNull();
            parametersOfAddTimerJob.Length.ShouldBe(12);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(12);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, parametersOfAddTimerJob, methodAddTimerJobPrametersTypes));
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(SqlConnection), typeof(Guid), typeof(Guid?), typeof(Guid?), typeof(int?), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int?), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddTimerJobPrametersTypes.Length.ShouldBe(12);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(SqlConnection), typeof(Guid), typeof(Guid?), typeof(Guid?), typeof(int?), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int?), typeof(int), typeof(string) };
            const int parametersCount = 12;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTimerJob, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_AddTimerJob_Static_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodAddTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var jobname = CreateType<string>();
            var jobtype = CreateType<int>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.AddTimerJob(siteid, webid, listid, jobname, jobtype, data, key, runtime, scheduletype, days);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var jobname = CreateType<string>();
            var jobtype = CreateType<int>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfAddTimerJob = { siteid, webid, listid, jobname, jobtype, data, key, runtime, scheduletype, days };

            // Assert
            parametersOfAddTimerJob.ShouldNotBeNull();
            parametersOfAddTimerJob.Length.ShouldBe(10);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, parametersOfAddTimerJob, methodAddTimerJobPrametersTypes));
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddTimerJobPrametersTypes.Length.ShouldBe(10);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 10;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTimerJob, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_AddTimerJob_Static_Method_Overloading_Of_3_Call_Internally(Type[] types)
        {
            var methodAddTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_DirectCall_Overloading_Of_3_Throw_Exception_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var jobname = CreateType<string>();
            var jobtype = CreateType<int>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.AddTimerJob(siteid, webid, jobname, jobtype, data, key, runtime, scheduletype, days);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_3_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var jobname = CreateType<string>();
            var jobtype = CreateType<int>();
            var data = CreateType<string>();
            var key = CreateType<string>();
            var runtime = CreateType<int>();
            var scheduletype = CreateType<int>();
            var days = CreateType<string>();
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            object[] parametersOfAddTimerJob = { siteid, webid, jobname, jobtype, data, key, runtime, scheduletype, days };

            // Assert
            parametersOfAddTimerJob.ShouldNotBeNull();
            parametersOfAddTimerJob.Length.ShouldBe(9);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(9);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, parametersOfAddTimerJob, methodAddTimerJobPrametersTypes));
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_3_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddTimerJobPrametersTypes.Length.ShouldBe(9);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_3_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTimerJobPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int), typeof(string) };
            const int parametersCount = 9;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodAddTimerJob, Fixture, methodAddTimerJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddTimerJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTimerJob) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_AddTimerJob_Static_Method_Call_Overloading_Of_3_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTimerJob, 3);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_CancelTimerJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodCancelTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodCancelTimerJob, Fixture, methodCancelTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_CancelTimerJob_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var timerjobuid = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.CancelTimerJob(web, timerjobuid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_CancelTimerJob_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var timerjobuid = CreateType<Guid>();
            var methodCancelTimerJobPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            object[] parametersOfCancelTimerJob = { web, timerjobuid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCancelTimerJob, methodCancelTimerJobPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfCancelTimerJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCancelTimerJob.ShouldNotBeNull();
            parametersOfCancelTimerJob.Length.ShouldBe(2);
            methodCancelTimerJobPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_CancelTimerJob_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var timerjobuid = CreateType<Guid>();
            var methodCancelTimerJobPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };
            object[] parametersOfCancelTimerJob = { web, timerjobuid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_timerInstanceFixture, _timerInstanceType, MethodCancelTimerJob, parametersOfCancelTimerJob, methodCancelTimerJobPrametersTypes);

            // Assert
            parametersOfCancelTimerJob.ShouldNotBeNull();
            parametersOfCancelTimerJob.Length.ShouldBe(2);
            methodCancelTimerJobPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_CancelTimerJob_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCancelTimerJob, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_CancelTimerJob_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCancelTimerJobPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodCancelTimerJob, Fixture, methodCancelTimerJobPrametersTypes);

            // Assert
            methodCancelTimerJobPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CancelTimerJob) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_CancelTimerJob_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCancelTimerJob, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsImportResourceAlreadyRunningPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsImportResourceAlreadyRunning, Fixture, methodIsImportResourceAlreadyRunningPrametersTypes);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.IsImportResourceAlreadyRunning(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodIsImportResourceAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfIsImportResourceAlreadyRunning = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsImportResourceAlreadyRunning, methodIsImportResourceAlreadyRunningPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsImportResourceAlreadyRunning, Fixture, methodIsImportResourceAlreadyRunningPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_timerInstanceFixture, _timerInstanceType, MethodIsImportResourceAlreadyRunning, parametersOfIsImportResourceAlreadyRunning, methodIsImportResourceAlreadyRunningPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfIsImportResourceAlreadyRunning);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfIsImportResourceAlreadyRunning.ShouldNotBeNull();
            parametersOfIsImportResourceAlreadyRunning.Length.ShouldBe(1);
            methodIsImportResourceAlreadyRunningPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodIsImportResourceAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfIsImportResourceAlreadyRunning = { web };

            // Assert
            parametersOfIsImportResourceAlreadyRunning.ShouldNotBeNull();
            parametersOfIsImportResourceAlreadyRunning.Length.ShouldBe(1);
            methodIsImportResourceAlreadyRunningPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_timerInstanceFixture, _timerInstanceType, MethodIsImportResourceAlreadyRunning, parametersOfIsImportResourceAlreadyRunning, methodIsImportResourceAlreadyRunningPrametersTypes));
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsImportResourceAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsImportResourceAlreadyRunning, Fixture, methodIsImportResourceAlreadyRunningPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodIsImportResourceAlreadyRunningPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsImportResourceAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsImportResourceAlreadyRunning, Fixture, methodIsImportResourceAlreadyRunningPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsImportResourceAlreadyRunningPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsImportResourceAlreadyRunning, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsImportResourceAlreadyRunning) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsImportResourceAlreadyRunning_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsImportResourceAlreadyRunning, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsSecurityJobAlreadyRunningPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsSecurityJobAlreadyRunning, Fixture, methodIsSecurityJobAlreadyRunningPrametersTypes);
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => Timer.IsSecurityJobAlreadyRunning(web, listId, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodIsSecurityJobAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(int) };
            object[] parametersOfIsSecurityJobAlreadyRunning = { web, listId, itemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsSecurityJobAlreadyRunning, methodIsSecurityJobAlreadyRunningPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsSecurityJobAlreadyRunning, Fixture, methodIsSecurityJobAlreadyRunningPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_timerInstanceFixture, _timerInstanceType, MethodIsSecurityJobAlreadyRunning, parametersOfIsSecurityJobAlreadyRunning, methodIsSecurityJobAlreadyRunningPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_timerInstanceFixture, parametersOfIsSecurityJobAlreadyRunning);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfIsSecurityJobAlreadyRunning.ShouldNotBeNull();
            parametersOfIsSecurityJobAlreadyRunning.Length.ShouldBe(3);
            methodIsSecurityJobAlreadyRunningPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodIsSecurityJobAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(int) };
            object[] parametersOfIsSecurityJobAlreadyRunning = { web, listId, itemId };

            // Assert
            parametersOfIsSecurityJobAlreadyRunning.ShouldNotBeNull();
            parametersOfIsSecurityJobAlreadyRunning.Length.ShouldBe(3);
            methodIsSecurityJobAlreadyRunningPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_timerInstanceFixture, _timerInstanceType, MethodIsSecurityJobAlreadyRunning, parametersOfIsSecurityJobAlreadyRunning, methodIsSecurityJobAlreadyRunningPrametersTypes));
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsSecurityJobAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsSecurityJobAlreadyRunning, Fixture, methodIsSecurityJobAlreadyRunningPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodIsSecurityJobAlreadyRunningPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsSecurityJobAlreadyRunningPrametersTypes = new Type[] { typeof(SPWeb), typeof(Guid), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_timerInstanceFixture, _timerInstanceType, MethodIsSecurityJobAlreadyRunning, Fixture, methodIsSecurityJobAlreadyRunningPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsSecurityJobAlreadyRunningPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsSecurityJobAlreadyRunning, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_timerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsSecurityJobAlreadyRunning) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Timer_IsSecurityJobAlreadyRunning_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsSecurityJobAlreadyRunning, 0);
            const int parametersCount = 3;

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