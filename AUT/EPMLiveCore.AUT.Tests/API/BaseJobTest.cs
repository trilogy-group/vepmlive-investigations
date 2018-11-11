using System;
using System.Data.SqlClient;
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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.BaseJob" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class BaseJobTest : AbstractBaseSetupTypedTest<BaseJob>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (BaseJob) Initializer

        private const string MethodCreateConnection = "CreateConnection";
        private const string MethodfinishJob = "finishJob";
        private const string MethodupdateProgress = "updateProgress";
        private const string MethodinitJob = "initJob";
        private const string FieldsErrors = "sErrors";
        private const string FieldbErrors = "bErrors";
        private const string Fieldqueuetype = "queuetype";
        private const string FieldtotalCount = "totalCount";
        private const string FieldlastPercent = "lastPercent";
        private const string FieldpercentInterval = "percentInterval";
        private const string FieldJobUid = "JobUid";
        private const string FieldQueueUid = "QueueUid";
        private const string Fielduserid = "userid";
        private const string FieldWebAppId = "WebAppId";
        private const string FieldListUid = "ListUid";
        private const string FieldItemID = "ItemID";
        private const string Fieldkey = "key";
        private const string FieldDocData = "DocData";
        private Type _baseJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private BaseJob _baseJobInstance;
        private BaseJob _baseJobInstanceFixture;

        #region General Initializer : Class (BaseJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BaseJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _baseJobInstanceType = typeof(BaseJob);
            _baseJobInstanceFixture = Create(true);
            _baseJobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BaseJob)

        #region General Initializer : Class (BaseJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="BaseJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateConnection, 0)]
        [TestCase(MethodfinishJob, 0)]
        [TestCase(MethodupdateProgress, 0)]
        [TestCase(MethodinitJob, 0)]
        public void AUT_BaseJob_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_baseJobInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (BaseJob) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="BaseJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldsErrors)]
        [TestCase(FieldbErrors)]
        [TestCase(Fieldqueuetype)]
        [TestCase(FieldtotalCount)]
        [TestCase(FieldlastPercent)]
        [TestCase(FieldpercentInterval)]
        [TestCase(FieldJobUid)]
        [TestCase(FieldQueueUid)]
        [TestCase(Fielduserid)]
        [TestCase(FieldWebAppId)]
        [TestCase(FieldListUid)]
        [TestCase(FieldItemID)]
        [TestCase(Fieldkey)]
        [TestCase(FieldDocData)]
        public void AUT_BaseJob_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_baseJobInstanceFixture, 
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
        ///     Class (<see cref="BaseJob" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BaseJob_Is_Instance_Present_Test()
        {
            // Assert
            _baseJobInstanceType.ShouldNotBeNull();
            _baseJobInstance.ShouldNotBeNull();
            _baseJobInstanceFixture.ShouldNotBeNull();
            _baseJobInstance.ShouldBeAssignableTo<BaseJob>();
            _baseJobInstanceFixture.ShouldBeAssignableTo<BaseJob>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BaseJob) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BaseJob_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BaseJob instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _baseJobInstanceType.ShouldNotBeNull();
            _baseJobInstance.ShouldNotBeNull();
            _baseJobInstanceFixture.ShouldNotBeNull();
            _baseJobInstance.ShouldBeAssignableTo<BaseJob>();
            _baseJobInstanceFixture.ShouldBeAssignableTo<BaseJob>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="BaseJob" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateConnection)]
        [TestCase(MethodfinishJob)]
        [TestCase(MethodupdateProgress)]
        [TestCase(MethodinitJob)]
        public void AUT_BaseJob_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<BaseJob>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BaseJob_CreateConnection_Method_Call_Internally(Type[] types)
        {
            var methodCreateConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodCreateConnection, Fixture, methodCreateConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_CreateConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateConnectionPrametersTypes = null;
            object[] parametersOfCreateConnection = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateConnection, methodCreateConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<BaseJob, SqlConnection>(_baseJobInstanceFixture, out exception1, parametersOfCreateConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<BaseJob, SqlConnection>(_baseJobInstance, MethodCreateConnection, parametersOfCreateConnection, methodCreateConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateConnection.ShouldBeNull();
            methodCreateConnectionPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_baseJobInstanceFixture, parametersOfCreateConnection));
        }

        #endregion

        #region Method Call : (CreateConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_CreateConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateConnectionPrametersTypes = null;
            object[] parametersOfCreateConnection = null; // no parameter present

            // Assert
            parametersOfCreateConnection.ShouldBeNull();
            methodCreateConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<BaseJob, SqlConnection>(_baseJobInstance, MethodCreateConnection, parametersOfCreateConnection, methodCreateConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (CreateConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_CreateConnection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateConnectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodCreateConnection, Fixture, methodCreateConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_CreateConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateConnectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodCreateConnection, Fixture, methodCreateConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateConnectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateConnection) (Return Type : SqlConnection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_CreateConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_baseJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (finishJob) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BaseJob_finishJob_Method_Call_Internally(Type[] types)
        {
            var methodfinishJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodfinishJob, Fixture, methodfinishJobPrametersTypes);
        }

        #endregion

        #region Method Call : (finishJob) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _baseJobInstance.finishJob();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (finishJob) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodfinishJobPrametersTypes = null;
            object[] parametersOffinishJob = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodfinishJob, methodfinishJobPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_baseJobInstanceFixture, parametersOffinishJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOffinishJob.ShouldBeNull();
            methodfinishJobPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (finishJob) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodfinishJobPrametersTypes = null;
            object[] parametersOffinishJob = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_baseJobInstance, MethodfinishJob, parametersOffinishJob, methodfinishJobPrametersTypes);

            // Assert
            parametersOffinishJob.ShouldBeNull();
            methodfinishJobPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (finishJob) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodfinishJobPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodfinishJob, Fixture, methodfinishJobPrametersTypes);

            // Assert
            methodfinishJobPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (finishJob) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_finishJob_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfinishJob, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_baseJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updateProgress) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BaseJob_updateProgress_Method_Call_Internally(Type[] types)
        {
            var methodupdateProgressPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodupdateProgress, Fixture, methodupdateProgressPrametersTypes);
        }

        #endregion

        #region Method Call : (updateProgress) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_updateProgress_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var newCount = CreateType<float>();
            var methodupdateProgressPrametersTypes = new Type[] { typeof(float) };
            object[] parametersOfupdateProgress = { newCount };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_baseJobInstance, MethodupdateProgress, parametersOfupdateProgress, methodupdateProgressPrametersTypes);

            // Assert
            parametersOfupdateProgress.ShouldNotBeNull();
            parametersOfupdateProgress.Length.ShouldBe(1);
            methodupdateProgressPrametersTypes.Length.ShouldBe(1);
            methodupdateProgressPrametersTypes.Length.ShouldBe(parametersOfupdateProgress.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updateProgress) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_updateProgress_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodupdateProgress, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (updateProgress) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_updateProgress_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodupdateProgressPrametersTypes = new Type[] { typeof(float) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodupdateProgress, Fixture, methodupdateProgressPrametersTypes);

            // Assert
            methodupdateProgressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updateProgress) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_updateProgress_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodupdateProgress, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_baseJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_BaseJob_initJob_Method_Call_Internally(Type[] types)
        {
            var methodinitJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodinitJob, Fixture, methodinitJobPrametersTypes);
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => _baseJobInstance.initJob(site);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodinitJobPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfinitJob = { site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodinitJob, methodinitJobPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<BaseJob, bool>(_baseJobInstanceFixture, out exception1, parametersOfinitJob);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<BaseJob, bool>(_baseJobInstance, MethodinitJob, parametersOfinitJob, methodinitJobPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfinitJob.ShouldNotBeNull();
            parametersOfinitJob.Length.ShouldBe(1);
            methodinitJobPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_baseJobInstanceFixture, parametersOfinitJob));
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodinitJobPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfinitJob = { site };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodinitJob, methodinitJobPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<BaseJob, bool>(_baseJobInstanceFixture, out exception1, parametersOfinitJob);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<BaseJob, bool>(_baseJobInstance, MethodinitJob, parametersOfinitJob, methodinitJobPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfinitJob.ShouldNotBeNull();
            parametersOfinitJob.Length.ShouldBe(1);
            methodinitJobPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<BaseJob, bool>(_baseJobInstance, MethodinitJob, parametersOfinitJob, methodinitJobPrametersTypes));
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodinitJobPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfinitJob = { site };

            // Assert
            parametersOfinitJob.ShouldNotBeNull();
            parametersOfinitJob.Length.ShouldBe(1);
            methodinitJobPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<BaseJob, bool>(_baseJobInstance, MethodinitJob, parametersOfinitJob, methodinitJobPrametersTypes));
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodinitJobPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_baseJobInstance, MethodinitJob, Fixture, methodinitJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodinitJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodinitJob, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_baseJobInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (initJob) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_BaseJob_initJob_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodinitJob, 0);
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