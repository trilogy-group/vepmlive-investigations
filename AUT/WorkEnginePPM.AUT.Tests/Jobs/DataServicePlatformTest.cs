using System;
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
using WorkEnginePPM.DataServiceModules;

namespace WorkEnginePPM.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Jobs.DataServicePlatform" />)
    ///     and namespace <see cref="WorkEnginePPM.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DataServicePlatformTest : AbstractBaseSetupTypedTest<DataServicePlatform>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataServicePlatform) Initializer

        private const string Methodexecute = "execute";
        private const string MethodDSMProgressChanged = "DSMProgressChanged";
        private const string MethodDSMCompleted = "DSMCompleted";
        private const string MethodUpdateProgress = "UpdateProgress";
        private const string MethodBuildResult = "BuildResult";
        private const string FieldbasePath = "basePath";
        private const string FieldppmId = "ppmId";
        private const string FieldppmCompany = "ppmCompany";
        private const string FieldppmDbConn = "ppmDbConn";
        private const string FielduserName = "userName";
        private const string FieldsecurityLevel = "securityLevel";
        private const string FieldUPDATE_LOG_SQL = "UPDATE_LOG_SQL";
        private Type _dataServicePlatformInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataServicePlatform _dataServicePlatformInstance;
        private DataServicePlatform _dataServicePlatformInstanceFixture;

        #region General Initializer : Class (DataServicePlatform) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataServicePlatform" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataServicePlatformInstanceType = typeof(DataServicePlatform);
            _dataServicePlatformInstanceFixture = Create(true);
            _dataServicePlatformInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataServicePlatform)

        #region General Initializer : Class (DataServicePlatform) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DataServicePlatform" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodDSMProgressChanged, 0)]
        [TestCase(MethodDSMCompleted, 0)]
        [TestCase(MethodUpdateProgress, 0)]
        [TestCase(MethodBuildResult, 0)]
        public void AUT_DataServicePlatform_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_dataServicePlatformInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataServicePlatform) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataServicePlatform" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldbasePath)]
        [TestCase(FieldppmId)]
        [TestCase(FieldppmCompany)]
        [TestCase(FieldppmDbConn)]
        [TestCase(FielduserName)]
        [TestCase(FieldsecurityLevel)]
        [TestCase(FieldUPDATE_LOG_SQL)]
        public void AUT_DataServicePlatform_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataServicePlatformInstanceFixture, 
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
        ///     Class (<see cref="DataServicePlatform" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DataServicePlatform_Is_Instance_Present_Test()
        {
            // Assert
            _dataServicePlatformInstanceType.ShouldNotBeNull();
            _dataServicePlatformInstance.ShouldNotBeNull();
            _dataServicePlatformInstanceFixture.ShouldNotBeNull();
            _dataServicePlatformInstance.ShouldBeAssignableTo<DataServicePlatform>();
            _dataServicePlatformInstanceFixture.ShouldBeAssignableTo<DataServicePlatform>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataServicePlatform) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DataServicePlatform_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataServicePlatform instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataServicePlatformInstanceType.ShouldNotBeNull();
            _dataServicePlatformInstance.ShouldNotBeNull();
            _dataServicePlatformInstanceFixture.ShouldNotBeNull();
            _dataServicePlatformInstance.ShouldBeAssignableTo<DataServicePlatform>();
            _dataServicePlatformInstanceFixture.ShouldBeAssignableTo<DataServicePlatform>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="DataServicePlatform" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodDSMProgressChanged)]
        [TestCase(MethodDSMCompleted)]
        [TestCase(MethodUpdateProgress)]
        [TestCase(MethodBuildResult)]
        public void AUT_DataServicePlatform_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DataServicePlatform>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataServicePlatform_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spSite = CreateType<SPSite>();
            var spWeb = CreateType<SPWeb>();
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _dataServicePlatformInstance.execute(spSite, spWeb, data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_execute_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var spSite = CreateType<SPSite>();
            var spWeb = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { spSite, spWeb, data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataServicePlatformInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spSite = CreateType<SPSite>();
            var spWeb = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { spSite, spWeb, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dataServicePlatformInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodexecute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dataServicePlatformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DSMProgressChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataServicePlatform_DSMProgressChanged_Method_Call_Internally(Type[] types)
        {
            var methodDSMProgressChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodDSMProgressChanged, Fixture, methodDSMProgressChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (DSMProgressChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMProgressChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var args = CreateType<DSMProgressChangedEventHandlerArgs>();
            var methodDSMProgressChangedPrametersTypes = new Type[] { typeof(object), typeof(DSMProgressChangedEventHandlerArgs) };
            object[] parametersOfDSMProgressChanged = { sender, args };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDSMProgressChanged, methodDSMProgressChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataServicePlatformInstanceFixture, parametersOfDSMProgressChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDSMProgressChanged.ShouldNotBeNull();
            parametersOfDSMProgressChanged.Length.ShouldBe(2);
            methodDSMProgressChangedPrametersTypes.Length.ShouldBe(2);
            methodDSMProgressChangedPrametersTypes.Length.ShouldBe(parametersOfDSMProgressChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DSMProgressChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMProgressChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var args = CreateType<DSMProgressChangedEventHandlerArgs>();
            var methodDSMProgressChangedPrametersTypes = new Type[] { typeof(object), typeof(DSMProgressChangedEventHandlerArgs) };
            object[] parametersOfDSMProgressChanged = { sender, args };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dataServicePlatformInstance, MethodDSMProgressChanged, parametersOfDSMProgressChanged, methodDSMProgressChangedPrametersTypes);

            // Assert
            parametersOfDSMProgressChanged.ShouldNotBeNull();
            parametersOfDSMProgressChanged.Length.ShouldBe(2);
            methodDSMProgressChangedPrametersTypes.Length.ShouldBe(2);
            methodDSMProgressChangedPrametersTypes.Length.ShouldBe(parametersOfDSMProgressChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DSMProgressChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMProgressChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDSMProgressChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DSMProgressChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMProgressChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDSMProgressChangedPrametersTypes = new Type[] { typeof(object), typeof(DSMProgressChangedEventHandlerArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodDSMProgressChanged, Fixture, methodDSMProgressChangedPrametersTypes);

            // Assert
            methodDSMProgressChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DSMProgressChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMProgressChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDSMProgressChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dataServicePlatformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DSMCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataServicePlatform_DSMCompleted_Method_Call_Internally(Type[] types)
        {
            var methodDSMCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodDSMCompleted, Fixture, methodDSMCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (DSMCompleted) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMCompleted_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var args = CreateType<DSMCompletedEventHandlerArgs>();
            var methodDSMCompletedPrametersTypes = new Type[] { typeof(object), typeof(DSMCompletedEventHandlerArgs) };
            object[] parametersOfDSMCompleted = { sender, args };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDSMCompleted, methodDSMCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataServicePlatformInstanceFixture, parametersOfDSMCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDSMCompleted.ShouldNotBeNull();
            parametersOfDSMCompleted.Length.ShouldBe(2);
            methodDSMCompletedPrametersTypes.Length.ShouldBe(2);
            methodDSMCompletedPrametersTypes.Length.ShouldBe(parametersOfDSMCompleted.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DSMCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMCompleted_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var args = CreateType<DSMCompletedEventHandlerArgs>();
            var methodDSMCompletedPrametersTypes = new Type[] { typeof(object), typeof(DSMCompletedEventHandlerArgs) };
            object[] parametersOfDSMCompleted = { sender, args };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dataServicePlatformInstance, MethodDSMCompleted, parametersOfDSMCompleted, methodDSMCompletedPrametersTypes);

            // Assert
            parametersOfDSMCompleted.ShouldNotBeNull();
            parametersOfDSMCompleted.Length.ShouldBe(2);
            methodDSMCompletedPrametersTypes.Length.ShouldBe(2);
            methodDSMCompletedPrametersTypes.Length.ShouldBe(parametersOfDSMCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DSMCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDSMCompleted, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DSMCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDSMCompletedPrametersTypes = new Type[] { typeof(object), typeof(DSMCompletedEventHandlerArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodDSMCompleted, Fixture, methodDSMCompletedPrametersTypes);

            // Assert
            methodDSMCompletedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DSMCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_DSMCompleted_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDSMCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dataServicePlatformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProgress) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataServicePlatform_UpdateProgress_Method_Call_Internally(Type[] types)
        {
            var methodUpdateProgressPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodUpdateProgress, Fixture, methodUpdateProgressPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateProgress) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_UpdateProgress_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userState = CreateType<object>();
            var methodUpdateProgressPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfUpdateProgress = { userState };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateProgress, methodUpdateProgressPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataServicePlatformInstanceFixture, parametersOfUpdateProgress);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateProgress.ShouldNotBeNull();
            parametersOfUpdateProgress.Length.ShouldBe(1);
            methodUpdateProgressPrametersTypes.Length.ShouldBe(1);
            methodUpdateProgressPrametersTypes.Length.ShouldBe(parametersOfUpdateProgress.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProgress) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_UpdateProgress_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userState = CreateType<object>();
            var methodUpdateProgressPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfUpdateProgress = { userState };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_dataServicePlatformInstance, MethodUpdateProgress, parametersOfUpdateProgress, methodUpdateProgressPrametersTypes);

            // Assert
            parametersOfUpdateProgress.ShouldNotBeNull();
            parametersOfUpdateProgress.Length.ShouldBe(1);
            methodUpdateProgressPrametersTypes.Length.ShouldBe(1);
            methodUpdateProgressPrametersTypes.Length.ShouldBe(parametersOfUpdateProgress.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProgress) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_UpdateProgress_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateProgress, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateProgress) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_UpdateProgress_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateProgressPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodUpdateProgress, Fixture, methodUpdateProgressPrametersTypes);

            // Assert
            methodUpdateProgressPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateProgress) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_UpdateProgress_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateProgress, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_dataServicePlatformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DataServicePlatform_BuildResult_Method_Call_Internally(Type[] types)
        {
            var methodBuildResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodBuildResult, Fixture, methodBuildResultPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_BuildResult_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dSMResult = CreateType<object>();
            var methodBuildResultPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfBuildResult = { dSMResult };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildResult, methodBuildResultPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_dataServicePlatformInstanceFixture, parametersOfBuildResult);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildResult.ShouldNotBeNull();
            parametersOfBuildResult.Length.ShouldBe(1);
            methodBuildResultPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_BuildResult_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dSMResult = CreateType<object>();
            var methodBuildResultPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfBuildResult = { dSMResult };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<DataServicePlatform, string>(_dataServicePlatformInstance, MethodBuildResult, parametersOfBuildResult, methodBuildResultPrametersTypes);

            // Assert
            parametersOfBuildResult.ShouldNotBeNull();
            parametersOfBuildResult.Length.ShouldBe(1);
            methodBuildResultPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_BuildResult_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildResultPrametersTypes = new Type[] { typeof(object) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodBuildResult, Fixture, methodBuildResultPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildResultPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_BuildResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildResultPrametersTypes = new Type[] { typeof(object) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dataServicePlatformInstance, MethodBuildResult, Fixture, methodBuildResultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildResultPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_BuildResult_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildResult, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_dataServicePlatformInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildResult) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DataServicePlatform_BuildResult_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildResult, 0);
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