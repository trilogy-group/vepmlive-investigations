using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
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

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Integration" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class IntegrationTest : AbstractBaseSetupTypedTest<Integration>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Integration) Initializer

        private const string Methodexecute = "execute";
        private const string MethodsetupPublishList = "setupPublishList";
        private const string MethodPublishTasks = "PublishTasks";
        private const string MethodPublishStatus = "PublishStatus";
        private const string MethodGetUpdateCount = "GetUpdateCount";
        private const string MethodbuildTasks = "buildTasks";
        private const string MethodisEditable = "isEditable";
        private const string MethodGetUpdates = "GetUpdates";
        private const string MethodProcessUpdates = "ProcessUpdates";
        private const string Methodgetresourcepoolurl = "getresourcepoolurl";
        private const string MethodGetMappedView = "GetMappedView";
        private const string MethodGetProjectIdFromName = "GetProjectIdFromName";
        private const string MethodGetTimesheetTypes = "GetTimesheetTypes";
        private const string MethodiGetResPool = "iGetResPool";
        private const string MethodUpdateResources = "UpdateResources";
        private const string MethodDisableResources = "DisableResources";
        private const string MethodUpdateItems = "UpdateItems";
        private const string MethodclearTimerJob = "clearTimerJob";
        private const string MethodgetTimerJob = "getTimerJob";
        private const string MethodsetTimerJob = "setTimerJob";
        private const string MethodsetTimesheetMap = "setTimesheetMap";
        private const string MethodSetSettings = "SetSettings";
        private const string MethodGetSettings = "GetSettings";
        private const string MethodClearSettings = "ClearSettings";
        private const string MethodRunTimer = "RunTimer";
        private const string MethodGetTimerStatus = "GetTimerStatus";
        private const string MethodGetAvailableLists = "GetAvailableLists";
        private const string MethodGetAvailableFields = "GetAvailableFields";
        private const string MethodGetAvailableViews = "GetAvailableViews";
        private const string MethodGetMissingEventHandlers = "GetMissingEventHandlers";
        private const string MethodEnableEvents = "EnableEvents";
        private const string MethodDisableEvents = "DisableEvents";
        private const string MethodDisableAllListsEvents = "DisableAllListsEvents";
        private const string MethodEnableFeatures = "EnableFeatures";
        private const string MethodDisableFeatures = "DisableFeatures";
        private Type _integrationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Integration _integrationInstance;
        private Integration _integrationInstanceFixture;

        #region General Initializer : Class (Integration) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Integration" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integrationInstanceType = typeof(Integration);
            _integrationInstanceFixture = Create(true);
            _integrationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Integration)

        #region General Initializer : Class (Integration) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Integration" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodsetupPublishList, 0)]
        [TestCase(MethodPublishTasks, 0)]
        [TestCase(MethodPublishStatus, 0)]
        [TestCase(MethodGetUpdateCount, 0)]
        [TestCase(MethodbuildTasks, 0)]
        [TestCase(MethodisEditable, 0)]
        [TestCase(MethodGetUpdates, 0)]
        [TestCase(MethodProcessUpdates, 0)]
        [TestCase(Methodgetresourcepoolurl, 0)]
        [TestCase(MethodGetMappedView, 0)]
        [TestCase(MethodGetProjectIdFromName, 0)]
        [TestCase(MethodGetTimesheetTypes, 0)]
        [TestCase(MethodiGetResPool, 0)]
        [TestCase(MethodUpdateResources, 0)]
        [TestCase(MethodDisableResources, 0)]
        [TestCase(MethodUpdateItems, 0)]
        [TestCase(MethodclearTimerJob, 0)]
        [TestCase(MethodgetTimerJob, 0)]
        [TestCase(MethodsetTimerJob, 0)]
        [TestCase(MethodsetTimesheetMap, 0)]
        [TestCase(MethodSetSettings, 0)]
        [TestCase(MethodGetSettings, 0)]
        [TestCase(MethodClearSettings, 0)]
        [TestCase(MethodRunTimer, 0)]
        [TestCase(MethodGetTimerStatus, 0)]
        [TestCase(MethodGetAvailableLists, 0)]
        [TestCase(MethodGetAvailableFields, 0)]
        [TestCase(MethodGetAvailableViews, 0)]
        [TestCase(MethodGetMissingEventHandlers, 0)]
        [TestCase(MethodEnableEvents, 0)]
        [TestCase(MethodDisableEvents, 0)]
        [TestCase(MethodDisableAllListsEvents, 0)]
        [TestCase(MethodEnableFeatures, 0)]
        [TestCase(MethodDisableFeatures, 0)]
        public void AUT_Integration_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_integrationInstanceFixture, 
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
        ///     Class (<see cref="Integration" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Integration_Is_Instance_Present_Test()
        {
            // Assert
            _integrationInstanceType.ShouldNotBeNull();
            _integrationInstance.ShouldNotBeNull();
            _integrationInstanceFixture.ShouldNotBeNull();
            _integrationInstance.ShouldBeAssignableTo<Integration>();
            _integrationInstanceFixture.ShouldBeAssignableTo<Integration>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Integration) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Integration_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Integration instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _integrationInstanceType.ShouldNotBeNull();
            _integrationInstance.ShouldNotBeNull();
            _integrationInstanceFixture.ShouldNotBeNull();
            _integrationInstance.ShouldBeAssignableTo<Integration>();
            _integrationInstanceFixture.ShouldBeAssignableTo<Integration>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Integration" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodsetupPublishList)]
        [TestCase(MethodPublishTasks)]
        [TestCase(MethodPublishStatus)]
        [TestCase(MethodGetUpdateCount)]
        [TestCase(MethodbuildTasks)]
        [TestCase(MethodisEditable)]
        [TestCase(MethodGetUpdates)]
        [TestCase(MethodProcessUpdates)]
        [TestCase(Methodgetresourcepoolurl)]
        [TestCase(MethodGetMappedView)]
        [TestCase(MethodGetProjectIdFromName)]
        [TestCase(MethodGetTimesheetTypes)]
        [TestCase(MethodiGetResPool)]
        [TestCase(MethodUpdateResources)]
        [TestCase(MethodDisableResources)]
        [TestCase(MethodUpdateItems)]
        [TestCase(MethodclearTimerJob)]
        [TestCase(MethodgetTimerJob)]
        [TestCase(MethodsetTimerJob)]
        [TestCase(MethodsetTimesheetMap)]
        [TestCase(MethodSetSettings)]
        [TestCase(MethodGetSettings)]
        [TestCase(MethodClearSettings)]
        [TestCase(MethodRunTimer)]
        [TestCase(MethodGetTimerStatus)]
        [TestCase(MethodGetAvailableLists)]
        [TestCase(MethodGetAvailableFields)]
        [TestCase(MethodGetAvailableViews)]
        [TestCase(MethodGetMissingEventHandlers)]
        [TestCase(MethodEnableEvents)]
        [TestCase(MethodDisableEvents)]
        [TestCase(MethodDisableAllListsEvents)]
        [TestCase(MethodEnableFeatures)]
        [TestCase(MethodDisableFeatures)]
        public void AUT_Integration_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Integration>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var commandMethod = CreateType<string>();
            var commandText = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationInstance.execute(commandMethod, commandText);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var commandMethod = CreateType<string>();
            var commandText = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfexecute = { commandMethod, commandText };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integration, XmlNode>(_integrationInstanceFixture, out exception1, parametersOfexecute);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integration, XmlNode>(_integrationInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(2);
            methodexecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var commandMethod = CreateType<string>();
            var commandText = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfexecute = { commandMethod, commandText };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(2);
            methodexecutePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var commandMethod = CreateType<string>();
            var commandText = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfexecute = { commandMethod, commandText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, XmlNode>(_integrationInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(2);
            methodexecutePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodexecutePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodexecutePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodexecutePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodexecutePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodexecute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (execute) (Return Type : XmlNode) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodexecute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setupPublishList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_setupPublishList_Method_Call_Internally(Type[] types)
        {
            var methodsetupPublishListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodsetupPublishList, Fixture, methodsetupPublishListPrametersTypes);
        }

        #endregion

        #region Method Call : (setupPublishList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setupPublishList_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodsetupPublishListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfsetupPublishList = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetupPublishList, methodsetupPublishListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfsetupPublishList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetupPublishList.ShouldNotBeNull();
            parametersOfsetupPublishList.Length.ShouldBe(1);
            methodsetupPublishListPrametersTypes.Length.ShouldBe(1);
            methodsetupPublishListPrametersTypes.Length.ShouldBe(parametersOfsetupPublishList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setupPublishList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setupPublishList_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodsetupPublishListPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfsetupPublishList = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationInstance, MethodsetupPublishList, parametersOfsetupPublishList, methodsetupPublishListPrametersTypes);

            // Assert
            parametersOfsetupPublishList.ShouldNotBeNull();
            parametersOfsetupPublishList.Length.ShouldBe(1);
            methodsetupPublishListPrametersTypes.Length.ShouldBe(1);
            methodsetupPublishListPrametersTypes.Length.ShouldBe(parametersOfsetupPublishList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupPublishList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setupPublishList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetupPublishList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setupPublishList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setupPublishList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetupPublishListPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodsetupPublishList, Fixture, methodsetupPublishListPrametersTypes);

            // Assert
            methodsetupPublishListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setupPublishList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setupPublishList_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetupPublishList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishTasks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_PublishTasks_Method_Call_Internally(Type[] types)
        {
            var methodPublishTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodPublishTasks, Fixture, methodPublishTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishTasks) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishTasks_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodPublishTasksPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishTasks = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPublishTasks, methodPublishTasksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfPublishTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishTasks.ShouldNotBeNull();
            parametersOfPublishTasks.Length.ShouldBe(1);
            methodPublishTasksPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishTasks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishTasks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodPublishTasksPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishTasks = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodPublishTasks, parametersOfPublishTasks, methodPublishTasksPrametersTypes);

            // Assert
            parametersOfPublishTasks.ShouldNotBeNull();
            parametersOfPublishTasks.Length.ShouldBe(1);
            methodPublishTasksPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishTasks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPublishTasksPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodPublishTasks, Fixture, methodPublishTasksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPublishTasksPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PublishTasks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishTasks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPublishTasksPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodPublishTasks, Fixture, methodPublishTasksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPublishTasksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishTasks) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishTasks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPublishTasks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PublishTasks) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishTasks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPublishTasks, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_PublishStatus_Method_Call_Internally(Type[] types)
        {
            var methodPublishStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodPublishStatus, Fixture, methodPublishStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishStatus_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodPublishStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishStatus = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPublishStatus, methodPublishStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfPublishStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPublishStatus.ShouldNotBeNull();
            parametersOfPublishStatus.Length.ShouldBe(1);
            methodPublishStatusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodPublishStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPublishStatus = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodPublishStatus, parametersOfPublishStatus, methodPublishStatusPrametersTypes);

            // Assert
            parametersOfPublishStatus.ShouldNotBeNull();
            parametersOfPublishStatus.Length.ShouldBe(1);
            methodPublishStatusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishStatus_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPublishStatusPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodPublishStatus, Fixture, methodPublishStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPublishStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPublishStatusPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodPublishStatus, Fixture, methodPublishStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPublishStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPublishStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PublishStatus) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_PublishStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPublishStatus, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetUpdateCount_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdateCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetUpdateCount, Fixture, methodGetUpdateCountPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdateCount_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetUpdateCountPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUpdateCount = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetUpdateCount, methodGetUpdateCountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetUpdateCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetUpdateCount.ShouldNotBeNull();
            parametersOfGetUpdateCount.Length.ShouldBe(1);
            methodGetUpdateCountPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdateCount_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetUpdateCountPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUpdateCount = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetUpdateCount, parametersOfGetUpdateCount, methodGetUpdateCountPrametersTypes);

            // Assert
            parametersOfGetUpdateCount.ShouldNotBeNull();
            parametersOfGetUpdateCount.Length.ShouldBe(1);
            methodGetUpdateCountPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdateCount_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUpdateCountPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetUpdateCount, Fixture, methodGetUpdateCountPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUpdateCountPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdateCount_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUpdateCountPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetUpdateCount, Fixture, methodGetUpdateCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUpdateCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdateCount_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUpdateCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetUpdateCount) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdateCount_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUpdateCount, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (buildTasks) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_buildTasks_Method_Call_Internally(Type[] types)
        {
            var methodbuildTasksPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodbuildTasks, Fixture, methodbuildTasksPrametersTypes);
        }

        #endregion

        #region Method Call : (buildTasks) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_buildTasks_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var hshTaskCenterFields = CreateType<Hashtable>();
            var oTaskCenter = CreateType<SPList>();
            var methodbuildTasksPrametersTypes = new Type[] { typeof(DataTable), typeof(Hashtable), typeof(SPList) };
            object[] parametersOfbuildTasks = { dt, hshTaskCenterFields, oTaskCenter };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodbuildTasks, methodbuildTasksPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfbuildTasks);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfbuildTasks.ShouldNotBeNull();
            parametersOfbuildTasks.Length.ShouldBe(3);
            methodbuildTasksPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildTasks) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_buildTasks_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var hshTaskCenterFields = CreateType<Hashtable>();
            var oTaskCenter = CreateType<SPList>();
            var methodbuildTasksPrametersTypes = new Type[] { typeof(DataTable), typeof(Hashtable), typeof(SPList) };
            object[] parametersOfbuildTasks = { dt, hshTaskCenterFields, oTaskCenter };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodbuildTasks, parametersOfbuildTasks, methodbuildTasksPrametersTypes);

            // Assert
            parametersOfbuildTasks.ShouldNotBeNull();
            parametersOfbuildTasks.Length.ShouldBe(3);
            methodbuildTasksPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (buildTasks) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_buildTasks_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodbuildTasksPrametersTypes = new Type[] { typeof(DataTable), typeof(Hashtable), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodbuildTasks, Fixture, methodbuildTasksPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodbuildTasksPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (buildTasks) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_buildTasks_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbuildTasksPrametersTypes = new Type[] { typeof(DataTable), typeof(Hashtable), typeof(SPList) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodbuildTasks, Fixture, methodbuildTasksPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodbuildTasksPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (buildTasks) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_buildTasks_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbuildTasks, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (buildTasks) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_buildTasks_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbuildTasks, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_isEditable_Method_Call_Internally(Type[] types)
        {
            var methodisEditablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodisEditable, Fixture, methodisEditablePrametersTypes);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_isEditable_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<SPField>();
            var fieldProperties = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var methodisEditablePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>) };
            object[] parametersOfisEditable = { li, field, fieldProperties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodisEditable, methodisEditablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfisEditable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfisEditable.ShouldNotBeNull();
            parametersOfisEditable.Length.ShouldBe(3);
            methodisEditablePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_isEditable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var field = CreateType<SPField>();
            var fieldProperties = CreateType<Dictionary<string, Dictionary<string, string>>>();
            var methodisEditablePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>) };
            object[] parametersOfisEditable = { li, field, fieldProperties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, bool>(_integrationInstance, MethodisEditable, parametersOfisEditable, methodisEditablePrametersTypes);

            // Assert
            parametersOfisEditable.ShouldNotBeNull();
            parametersOfisEditable.Length.ShouldBe(3);
            methodisEditablePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_isEditable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodisEditablePrametersTypes = new Type[] { typeof(SPListItem), typeof(SPField), typeof(Dictionary<string, Dictionary<string, string>>) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodisEditable, Fixture, methodisEditablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodisEditablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_isEditable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodisEditable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (isEditable) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_isEditable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodisEditable, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetUpdates_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdates_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUpdates = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetUpdates, methodGetUpdatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetUpdates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetUpdates.ShouldNotBeNull();
            parametersOfGetUpdates.Length.ShouldBe(1);
            methodGetUpdatesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdates_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUpdates = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetUpdates, parametersOfGetUpdates, methodGetUpdatesPrametersTypes);

            // Assert
            parametersOfGetUpdates.ShouldNotBeNull();
            parametersOfGetUpdates.Length.ShouldBe(1);
            methodGetUpdatesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdates_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUpdatesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdates_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUpdatesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetUpdates, Fixture, methodGetUpdatesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUpdatesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdates_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUpdates, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetUpdates) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetUpdates_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUpdates, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_ProcessUpdates_Method_Call_Internally(Type[] types)
        {
            var methodProcessUpdatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodProcessUpdates, Fixture, methodProcessUpdatesPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ProcessUpdates_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodProcessUpdatesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfProcessUpdates = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessUpdates, methodProcessUpdatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfProcessUpdates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessUpdates.ShouldNotBeNull();
            parametersOfProcessUpdates.Length.ShouldBe(1);
            methodProcessUpdatesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ProcessUpdates_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodProcessUpdatesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfProcessUpdates = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodProcessUpdates, parametersOfProcessUpdates, methodProcessUpdatesPrametersTypes);

            // Assert
            parametersOfProcessUpdates.ShouldNotBeNull();
            parametersOfProcessUpdates.Length.ShouldBe(1);
            methodProcessUpdatesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ProcessUpdates_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodProcessUpdatesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodProcessUpdates, Fixture, methodProcessUpdatesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessUpdatesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ProcessUpdates_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessUpdatesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodProcessUpdates, Fixture, methodProcessUpdatesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessUpdatesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ProcessUpdates_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessUpdates, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ProcessUpdates) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ProcessUpdates_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessUpdates, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getresourcepoolurl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_getresourcepoolurl_Method_Call_Internally(Type[] types)
        {
            var methodgetresourcepoolurlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, Methodgetresourcepoolurl, Fixture, methodgetresourcepoolurlPrametersTypes);
        }

        #endregion

        #region Method Call : (getresourcepoolurl) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getresourcepoolurl_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodgetresourcepoolurlPrametersTypes = null;
            object[] parametersOfgetresourcepoolurl = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(Methodgetresourcepoolurl, methodgetresourcepoolurlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integration, string>(_integrationInstanceFixture, out exception1, parametersOfgetresourcepoolurl);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, Methodgetresourcepoolurl, parametersOfgetresourcepoolurl, methodgetresourcepoolurlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetresourcepoolurl.ShouldBeNull();
            methodgetresourcepoolurlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getresourcepoolurl) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getresourcepoolurl_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetresourcepoolurlPrametersTypes = null;
            object[] parametersOfgetresourcepoolurl = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodgetresourcepoolurl, methodgetresourcepoolurlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfgetresourcepoolurl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetresourcepoolurl.ShouldBeNull();
            methodgetresourcepoolurlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getresourcepoolurl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getresourcepoolurl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetresourcepoolurlPrametersTypes = null;
            object[] parametersOfgetresourcepoolurl = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, Methodgetresourcepoolurl, parametersOfgetresourcepoolurl, methodgetresourcepoolurlPrametersTypes);

            // Assert
            parametersOfgetresourcepoolurl.ShouldBeNull();
            methodgetresourcepoolurlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getresourcepoolurl) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getresourcepoolurl_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodgetresourcepoolurlPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, Methodgetresourcepoolurl, Fixture, methodgetresourcepoolurlPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetresourcepoolurlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getresourcepoolurl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getresourcepoolurl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetresourcepoolurlPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, Methodgetresourcepoolurl, Fixture, methodgetresourcepoolurlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetresourcepoolurlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getresourcepoolurl) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getresourcepoolurl_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodgetresourcepoolurl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetMappedView) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetMappedView_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetMappedView, Fixture, methodGetMappedViewPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedView) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMappedView_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetMappedViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMappedView = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMappedView, methodGetMappedViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetMappedView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMappedView.ShouldNotBeNull();
            parametersOfGetMappedView.Length.ShouldBe(1);
            methodGetMappedViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedView) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMappedView_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetMappedViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMappedView = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetMappedView, parametersOfGetMappedView, methodGetMappedViewPrametersTypes);

            // Assert
            parametersOfGetMappedView.ShouldNotBeNull();
            parametersOfGetMappedView.Length.ShouldBe(1);
            methodGetMappedViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedView) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMappedView_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMappedViewPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetMappedView, Fixture, methodGetMappedViewPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMappedViewPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMappedView) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMappedView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMappedViewPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetMappedView, Fixture, methodGetMappedViewPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMappedViewPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMappedView) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMappedView_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedView, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetMappedView) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMappedView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMappedView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProjectIdFromName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetProjectIdFromName_Method_Call_Internally(Type[] types)
        {
            var methodGetProjectIdFromNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetProjectIdFromName, Fixture, methodGetProjectIdFromNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetProjectIdFromName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetProjectIdFromName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetProjectIdFromNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetProjectIdFromName = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetProjectIdFromName, methodGetProjectIdFromNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetProjectIdFromName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetProjectIdFromName.ShouldNotBeNull();
            parametersOfGetProjectIdFromName.Length.ShouldBe(1);
            methodGetProjectIdFromNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectIdFromName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetProjectIdFromName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetProjectIdFromNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetProjectIdFromName = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetProjectIdFromName, parametersOfGetProjectIdFromName, methodGetProjectIdFromNamePrametersTypes);

            // Assert
            parametersOfGetProjectIdFromName.ShouldNotBeNull();
            parametersOfGetProjectIdFromName.Length.ShouldBe(1);
            methodGetProjectIdFromNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetProjectIdFromName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetProjectIdFromName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetProjectIdFromNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetProjectIdFromName, Fixture, methodGetProjectIdFromNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetProjectIdFromNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetProjectIdFromName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetProjectIdFromName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetProjectIdFromNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetProjectIdFromName, Fixture, methodGetProjectIdFromNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProjectIdFromNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProjectIdFromName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetProjectIdFromName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProjectIdFromName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetProjectIdFromName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetProjectIdFromName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProjectIdFromName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimesheetTypes) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetTimesheetTypes_Method_Call_Internally(Type[] types)
        {
            var methodGetTimesheetTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetTimesheetTypes, Fixture, methodGetTimesheetTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTimesheetTypes) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimesheetTypes_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetTimesheetTypesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTimesheetTypes = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTimesheetTypes, methodGetTimesheetTypesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetTimesheetTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTimesheetTypes.ShouldNotBeNull();
            parametersOfGetTimesheetTypes.Length.ShouldBe(1);
            methodGetTimesheetTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTimesheetTypes) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimesheetTypes_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetTimesheetTypesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTimesheetTypes = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetTimesheetTypes, parametersOfGetTimesheetTypes, methodGetTimesheetTypesPrametersTypes);

            // Assert
            parametersOfGetTimesheetTypes.ShouldNotBeNull();
            parametersOfGetTimesheetTypes.Length.ShouldBe(1);
            methodGetTimesheetTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTimesheetTypes) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimesheetTypes_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTimesheetTypesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetTimesheetTypes, Fixture, methodGetTimesheetTypesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTimesheetTypesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTimesheetTypes) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimesheetTypes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTimesheetTypesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetTimesheetTypes, Fixture, methodGetTimesheetTypesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTimesheetTypesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimesheetTypes) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimesheetTypes_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTimesheetTypes, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTimesheetTypes) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimesheetTypes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTimesheetTypes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetResPool) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_iGetResPool_Method_Call_Internally(Type[] types)
        {
            var methodiGetResPoolPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodiGetResPool, Fixture, methodiGetResPoolPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetResPool) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_iGetResPool_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetResPoolPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetResPool = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiGetResPool, methodiGetResPoolPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integration, string>(_integrationInstanceFixture, out exception1, parametersOfiGetResPool);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodiGetResPool, parametersOfiGetResPool, methodiGetResPoolPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetResPool.ShouldNotBeNull();
            parametersOfiGetResPool.Length.ShouldBe(1);
            methodiGetResPoolPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetResPool) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_iGetResPool_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetResPoolPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetResPool = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodiGetResPool, parametersOfiGetResPool, methodiGetResPoolPrametersTypes);

            // Assert
            parametersOfiGetResPool.ShouldNotBeNull();
            parametersOfiGetResPool.Length.ShouldBe(1);
            methodiGetResPoolPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetResPool) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_iGetResPool_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetResPoolPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodiGetResPool, Fixture, methodiGetResPoolPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetResPoolPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetResPool) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_iGetResPool_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetResPoolPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodiGetResPool, Fixture, methodiGetResPoolPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetResPoolPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetResPool) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_iGetResPool_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetResPool, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetResPool) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_iGetResPool_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetResPool, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_UpdateResources_Method_Call_Internally(Type[] types)
        {
            var methodUpdateResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodUpdateResources, Fixture, methodUpdateResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateResources_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateResources = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateResources, methodUpdateResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfUpdateResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateResources.ShouldNotBeNull();
            parametersOfUpdateResources.Length.ShouldBe(1);
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateResources_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateResources = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodUpdateResources, parametersOfUpdateResources, methodUpdateResourcesPrametersTypes);

            // Assert
            parametersOfUpdateResources.ShouldNotBeNull();
            parametersOfUpdateResources.Length.ShouldBe(1);
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateResources_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodUpdateResources, Fixture, methodUpdateResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateResourcesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodUpdateResources, Fixture, methodUpdateResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateResources_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UpdateResources) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateResources_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableResources) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_DisableResources_Method_Call_Internally(Type[] types)
        {
            var methodDisableResourcesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableResources, Fixture, methodDisableResourcesPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableResources) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableResources_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableResources = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableResources, methodDisableResourcesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfDisableResources);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableResources.ShouldNotBeNull();
            parametersOfDisableResources.Length.ShouldBe(1);
            methodDisableResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableResources) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableResources_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableResourcesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableResources = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodDisableResources, parametersOfDisableResources, methodDisableResourcesPrametersTypes);

            // Assert
            parametersOfDisableResources.ShouldNotBeNull();
            parametersOfDisableResources.Length.ShouldBe(1);
            methodDisableResourcesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableResources) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableResources_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDisableResourcesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableResources, Fixture, methodDisableResourcesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDisableResourcesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DisableResources) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableResources_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisableResourcesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableResources, Fixture, methodDisableResourcesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDisableResourcesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableResources) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableResources_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableResources, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DisableResources) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableResources_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisableResources, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_UpdateItems_Method_Call_Internally(Type[] types)
        {
            var methodUpdateItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateItems_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateItems = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateItems, methodUpdateItemsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integration, string>(_integrationInstanceFixture, out exception1, parametersOfUpdateItems);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(1);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfUpdateItems = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodUpdateItems, parametersOfUpdateItems, methodUpdateItemsPrametersTypes);

            // Assert
            parametersOfUpdateItems.ShouldNotBeNull();
            parametersOfUpdateItems.Length.ShouldBe(1);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateItems_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateItemsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateItemsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodUpdateItems, Fixture, methodUpdateItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateItems_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateItems) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_UpdateItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (clearTimerJob) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_clearTimerJob_Method_Call_Internally(Type[] types)
        {
            var methodclearTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodclearTimerJob, Fixture, methodclearTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (clearTimerJob) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_clearTimerJob_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var jobtype = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodclearTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfclearTimerJob = { jobtype, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodclearTimerJob, methodclearTimerJobPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfclearTimerJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfclearTimerJob.ShouldNotBeNull();
            parametersOfclearTimerJob.Length.ShouldBe(2);
            methodclearTimerJobPrametersTypes.Length.ShouldBe(2);
            methodclearTimerJobPrametersTypes.Length.ShouldBe(parametersOfclearTimerJob.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (clearTimerJob) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_clearTimerJob_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var jobtype = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodclearTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfclearTimerJob = { jobtype, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationInstance, MethodclearTimerJob, parametersOfclearTimerJob, methodclearTimerJobPrametersTypes);

            // Assert
            parametersOfclearTimerJob.ShouldNotBeNull();
            parametersOfclearTimerJob.Length.ShouldBe(2);
            methodclearTimerJobPrametersTypes.Length.ShouldBe(2);
            methodclearTimerJobPrametersTypes.Length.ShouldBe(parametersOfclearTimerJob.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (clearTimerJob) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_clearTimerJob_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodclearTimerJob, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (clearTimerJob) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_clearTimerJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodclearTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodclearTimerJob, Fixture, methodclearTimerJobPrametersTypes);

            // Assert
            methodclearTimerJobPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (clearTimerJob) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_clearTimerJob_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodclearTimerJob, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getTimerJob) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_getTimerJob_Method_Call_Internally(Type[] types)
        {
            var methodgetTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodgetTimerJob, Fixture, methodgetTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (getTimerJob) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getTimerJob_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var jobtype = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodgetTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetTimerJob = { jobtype, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetTimerJob, methodgetTimerJobPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Integration, string>(_integrationInstanceFixture, out exception1, parametersOfgetTimerJob);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodgetTimerJob, parametersOfgetTimerJob, methodgetTimerJobPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetTimerJob.ShouldNotBeNull();
            parametersOfgetTimerJob.Length.ShouldBe(2);
            methodgetTimerJobPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getTimerJob) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getTimerJob_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var jobtype = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodgetTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfgetTimerJob = { jobtype, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodgetTimerJob, parametersOfgetTimerJob, methodgetTimerJobPrametersTypes);

            // Assert
            parametersOfgetTimerJob.ShouldNotBeNull();
            parametersOfgetTimerJob.Length.ShouldBe(2);
            methodgetTimerJobPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getTimerJob) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getTimerJob_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodgetTimerJob, Fixture, methodgetTimerJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetTimerJobPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getTimerJob) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getTimerJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodgetTimerJob, Fixture, methodgetTimerJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetTimerJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getTimerJob) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getTimerJob_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetTimerJob, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getTimerJob) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_getTimerJob_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetTimerJob, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setTimerJob) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_setTimerJob_Method_Call_Internally(Type[] types)
        {
            var methodsetTimerJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodsetTimerJob, Fixture, methodsetTimerJobPrametersTypes);
        }

        #endregion

        #region Method Call : (setTimerJob) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimerJob_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var settings = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodsetTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfsetTimerJob = { settings, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetTimerJob, methodsetTimerJobPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfsetTimerJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetTimerJob.ShouldNotBeNull();
            parametersOfsetTimerJob.Length.ShouldBe(2);
            methodsetTimerJobPrametersTypes.Length.ShouldBe(2);
            methodsetTimerJobPrametersTypes.Length.ShouldBe(parametersOfsetTimerJob.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setTimerJob) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimerJob_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var settings = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodsetTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfsetTimerJob = { settings, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationInstance, MethodsetTimerJob, parametersOfsetTimerJob, methodsetTimerJobPrametersTypes);

            // Assert
            parametersOfsetTimerJob.ShouldNotBeNull();
            parametersOfsetTimerJob.Length.ShouldBe(2);
            methodsetTimerJobPrametersTypes.Length.ShouldBe(2);
            methodsetTimerJobPrametersTypes.Length.ShouldBe(parametersOfsetTimerJob.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setTimerJob) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimerJob_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetTimerJob, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setTimerJob) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimerJob_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetTimerJobPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodsetTimerJob, Fixture, methodsetTimerJobPrametersTypes);

            // Assert
            methodsetTimerJobPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setTimerJob) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimerJob_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetTimerJob, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setTimesheetMap) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_setTimesheetMap_Method_Call_Internally(Type[] types)
        {
            var methodsetTimesheetMapPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodsetTimesheetMap, Fixture, methodsetTimesheetMapPrametersTypes);
        }

        #endregion

        #region Method Call : (setTimesheetMap) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimesheetMap_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var map = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodsetTimesheetMapPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfsetTimesheetMap = { map, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetTimesheetMap, methodsetTimesheetMapPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfsetTimesheetMap);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetTimesheetMap.ShouldNotBeNull();
            parametersOfsetTimesheetMap.Length.ShouldBe(2);
            methodsetTimesheetMapPrametersTypes.Length.ShouldBe(2);
            methodsetTimesheetMapPrametersTypes.Length.ShouldBe(parametersOfsetTimesheetMap.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setTimesheetMap) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimesheetMap_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var map = CreateType<string>();
            var web = CreateType<SPWeb>();
            var methodsetTimesheetMapPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfsetTimesheetMap = { map, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationInstance, MethodsetTimesheetMap, parametersOfsetTimesheetMap, methodsetTimesheetMapPrametersTypes);

            // Assert
            parametersOfsetTimesheetMap.ShouldNotBeNull();
            parametersOfsetTimesheetMap.Length.ShouldBe(2);
            methodsetTimesheetMapPrametersTypes.Length.ShouldBe(2);
            methodsetTimesheetMapPrametersTypes.Length.ShouldBe(parametersOfsetTimesheetMap.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setTimesheetMap) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimesheetMap_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetTimesheetMap, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setTimesheetMap) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimesheetMap_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetTimesheetMapPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodsetTimesheetMap, Fixture, methodsetTimesheetMapPrametersTypes);

            // Assert
            methodsetTimesheetMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setTimesheetMap) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_setTimesheetMap_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetTimesheetMap, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_SetSettings_Method_Call_Internally(Type[] types)
        {
            var methodSetSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodSetSettings, Fixture, methodSetSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSettings) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_SetSettings_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodSetSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetSettings = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSettings, methodSetSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfSetSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSettings.ShouldNotBeNull();
            parametersOfSetSettings.Length.ShouldBe(1);
            methodSetSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_SetSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodSetSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetSettings = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodSetSettings, parametersOfSetSettings, methodSetSettingsPrametersTypes);

            // Assert
            parametersOfSetSettings.ShouldNotBeNull();
            parametersOfSetSettings.Length.ShouldBe(1);
            methodSetSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSettings) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_SetSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetSettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodSetSettings, Fixture, methodSetSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_SetSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSettingsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodSetSettings, Fixture, methodSetSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSettings) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_SetSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SetSettings) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_SetSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetSettings_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSettings = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSettings, methodGetSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSettings.ShouldNotBeNull();
            parametersOfGetSettings.Length.ShouldBe(1);
            methodGetSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSettings = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetSettings, parametersOfGetSettings, methodGetSettingsPrametersTypes);

            // Assert
            parametersOfGetSettings.ShouldNotBeNull();
            parametersOfGetSettings.Length.ShouldBe(1);
            methodGetSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSettingsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetSettings, Fixture, methodGetSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSettings) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearSettings) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_ClearSettings_Method_Call_Internally(Type[] types)
        {
            var methodClearSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodClearSettings, Fixture, methodClearSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearSettings) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ClearSettings_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodClearSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfClearSettings = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearSettings, methodClearSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfClearSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearSettings.ShouldNotBeNull();
            parametersOfClearSettings.Length.ShouldBe(1);
            methodClearSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearSettings) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ClearSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodClearSettingsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfClearSettings = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodClearSettings, parametersOfClearSettings, methodClearSettingsPrametersTypes);

            // Assert
            parametersOfClearSettings.ShouldNotBeNull();
            parametersOfClearSettings.Length.ShouldBe(1);
            methodClearSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearSettings) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ClearSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodClearSettingsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodClearSettings, Fixture, methodClearSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodClearSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ClearSettings) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ClearSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearSettingsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodClearSettings, Fixture, methodClearSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodClearSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearSettings) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ClearSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ClearSettings) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_ClearSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RunTimer) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_RunTimer_Method_Call_Internally(Type[] types)
        {
            var methodRunTimerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodRunTimer, Fixture, methodRunTimerPrametersTypes);
        }

        #endregion

        #region Method Call : (RunTimer) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_RunTimer_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodRunTimerPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRunTimer = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRunTimer, methodRunTimerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfRunTimer);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRunTimer.ShouldNotBeNull();
            parametersOfRunTimer.Length.ShouldBe(1);
            methodRunTimerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RunTimer) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_RunTimer_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodRunTimerPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRunTimer = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodRunTimer, parametersOfRunTimer, methodRunTimerPrametersTypes);

            // Assert
            parametersOfRunTimer.ShouldNotBeNull();
            parametersOfRunTimer.Length.ShouldBe(1);
            methodRunTimerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RunTimer) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_RunTimer_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRunTimerPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodRunTimer, Fixture, methodRunTimerPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRunTimerPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RunTimer) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_RunTimer_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRunTimerPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodRunTimer, Fixture, methodRunTimerPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRunTimerPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RunTimer) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_RunTimer_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRunTimer, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RunTimer) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_RunTimer_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRunTimer, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimerStatus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetTimerStatus_Method_Call_Internally(Type[] types)
        {
            var methodGetTimerStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetTimerStatus, Fixture, methodGetTimerStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTimerStatus) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimerStatus_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetTimerStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTimerStatus = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTimerStatus, methodGetTimerStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetTimerStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTimerStatus.ShouldNotBeNull();
            parametersOfGetTimerStatus.Length.ShouldBe(1);
            methodGetTimerStatusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTimerStatus) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimerStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetTimerStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTimerStatus = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetTimerStatus, parametersOfGetTimerStatus, methodGetTimerStatusPrametersTypes);

            // Assert
            parametersOfGetTimerStatus.ShouldNotBeNull();
            parametersOfGetTimerStatus.Length.ShouldBe(1);
            methodGetTimerStatusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTimerStatus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimerStatus_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTimerStatusPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetTimerStatus, Fixture, methodGetTimerStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTimerStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTimerStatus) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimerStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTimerStatusPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetTimerStatus, Fixture, methodGetTimerStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTimerStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTimerStatus) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimerStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTimerStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTimerStatus) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetTimerStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTimerStatus, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvailableLists) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetAvailableLists_Method_Call_Internally(Type[] types)
        {
            var methodGetAvailableListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableLists, Fixture, methodGetAvailableListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvailableLists) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableLists_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetAvailableListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAvailableLists = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAvailableLists, methodGetAvailableListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetAvailableLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAvailableLists.ShouldNotBeNull();
            parametersOfGetAvailableLists.Length.ShouldBe(1);
            methodGetAvailableListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvailableLists) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetAvailableListsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAvailableLists = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetAvailableLists, parametersOfGetAvailableLists, methodGetAvailableListsPrametersTypes);

            // Assert
            parametersOfGetAvailableLists.ShouldNotBeNull();
            parametersOfGetAvailableLists.Length.ShouldBe(1);
            methodGetAvailableListsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvailableLists) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAvailableListsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableLists, Fixture, methodGetAvailableListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAvailableListsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAvailableLists) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAvailableListsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableLists, Fixture, methodGetAvailableListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvailableListsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvailableLists) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAvailableLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetAvailableLists) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAvailableLists, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvailableFields) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetAvailableFields_Method_Call_Internally(Type[] types)
        {
            var methodGetAvailableFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableFields, Fixture, methodGetAvailableFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvailableFields) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableFields_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetAvailableFieldsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAvailableFields = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAvailableFields, methodGetAvailableFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetAvailableFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAvailableFields.ShouldNotBeNull();
            parametersOfGetAvailableFields.Length.ShouldBe(1);
            methodGetAvailableFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvailableFields) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetAvailableFieldsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAvailableFields = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetAvailableFields, parametersOfGetAvailableFields, methodGetAvailableFieldsPrametersTypes);

            // Assert
            parametersOfGetAvailableFields.ShouldNotBeNull();
            parametersOfGetAvailableFields.Length.ShouldBe(1);
            methodGetAvailableFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvailableFields) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAvailableFieldsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableFields, Fixture, methodGetAvailableFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAvailableFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAvailableFields) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAvailableFieldsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableFields, Fixture, methodGetAvailableFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvailableFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvailableFields) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAvailableFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetAvailableFields) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAvailableFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvailableViews) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetAvailableViews_Method_Call_Internally(Type[] types)
        {
            var methodGetAvailableViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableViews, Fixture, methodGetAvailableViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvailableViews) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableViews_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetAvailableViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAvailableViews = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAvailableViews, methodGetAvailableViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetAvailableViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAvailableViews.ShouldNotBeNull();
            parametersOfGetAvailableViews.Length.ShouldBe(1);
            methodGetAvailableViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvailableViews) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableViews_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetAvailableViewsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetAvailableViews = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetAvailableViews, parametersOfGetAvailableViews, methodGetAvailableViewsPrametersTypes);

            // Assert
            parametersOfGetAvailableViews.ShouldNotBeNull();
            parametersOfGetAvailableViews.Length.ShouldBe(1);
            methodGetAvailableViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvailableViews) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableViews_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAvailableViewsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableViews, Fixture, methodGetAvailableViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAvailableViewsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAvailableViews) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAvailableViewsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetAvailableViews, Fixture, methodGetAvailableViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvailableViewsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvailableViews) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableViews_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAvailableViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetAvailableViews) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetAvailableViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAvailableViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMissingEventHandlers) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_GetMissingEventHandlers_Method_Call_Internally(Type[] types)
        {
            var methodGetMissingEventHandlersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetMissingEventHandlers, Fixture, methodGetMissingEventHandlersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMissingEventHandlers) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMissingEventHandlers_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetMissingEventHandlersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMissingEventHandlers = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetMissingEventHandlers, methodGetMissingEventHandlersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfGetMissingEventHandlers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetMissingEventHandlers.ShouldNotBeNull();
            parametersOfGetMissingEventHandlers.Length.ShouldBe(1);
            methodGetMissingEventHandlersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMissingEventHandlers) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMissingEventHandlers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodGetMissingEventHandlersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetMissingEventHandlers = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodGetMissingEventHandlers, parametersOfGetMissingEventHandlers, methodGetMissingEventHandlersPrametersTypes);

            // Assert
            parametersOfGetMissingEventHandlers.ShouldNotBeNull();
            parametersOfGetMissingEventHandlers.Length.ShouldBe(1);
            methodGetMissingEventHandlersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMissingEventHandlers) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMissingEventHandlers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetMissingEventHandlersPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetMissingEventHandlers, Fixture, methodGetMissingEventHandlersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMissingEventHandlersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetMissingEventHandlers) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMissingEventHandlers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetMissingEventHandlersPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodGetMissingEventHandlers, Fixture, methodGetMissingEventHandlersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMissingEventHandlersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMissingEventHandlers) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMissingEventHandlers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMissingEventHandlers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetMissingEventHandlers) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_GetMissingEventHandlers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetMissingEventHandlers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableEvents) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_EnableEvents_Method_Call_Internally(Type[] types)
        {
            var methodEnableEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodEnableEvents, Fixture, methodEnableEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableEvents) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableEvents_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodEnableEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEnableEvents = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableEvents, methodEnableEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfEnableEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableEvents.ShouldNotBeNull();
            parametersOfEnableEvents.Length.ShouldBe(1);
            methodEnableEventsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableEvents) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableEvents_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodEnableEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEnableEvents = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodEnableEvents, parametersOfEnableEvents, methodEnableEventsPrametersTypes);

            // Assert
            parametersOfEnableEvents.ShouldNotBeNull();
            parametersOfEnableEvents.Length.ShouldBe(1);
            methodEnableEventsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableEvents) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableEvents_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodEnableEventsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodEnableEvents, Fixture, methodEnableEventsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodEnableEventsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EnableEvents) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableEventsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodEnableEvents, Fixture, methodEnableEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEnableEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableEvents) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableEvents_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EnableEvents) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableEvents, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableEvents) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_DisableEvents_Method_Call_Internally(Type[] types)
        {
            var methodDisableEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableEvents, Fixture, methodDisableEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableEvents) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableEvents_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableEvents = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableEvents, methodDisableEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfDisableEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableEvents.ShouldNotBeNull();
            parametersOfDisableEvents.Length.ShouldBe(1);
            methodDisableEventsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableEvents) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableEvents_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableEvents = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodDisableEvents, parametersOfDisableEvents, methodDisableEventsPrametersTypes);

            // Assert
            parametersOfDisableEvents.ShouldNotBeNull();
            parametersOfDisableEvents.Length.ShouldBe(1);
            methodDisableEventsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableEvents) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableEvents_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDisableEventsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableEvents, Fixture, methodDisableEventsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDisableEventsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DisableEvents) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisableEventsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableEvents, Fixture, methodDisableEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDisableEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableEvents) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableEvents_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DisableEvents) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisableEvents, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableAllListsEvents) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_DisableAllListsEvents_Method_Call_Internally(Type[] types)
        {
            var methodDisableAllListsEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableAllListsEvents, Fixture, methodDisableAllListsEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableAllListsEvents) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableAllListsEvents_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableAllListsEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableAllListsEvents = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableAllListsEvents, methodDisableAllListsEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfDisableAllListsEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableAllListsEvents.ShouldNotBeNull();
            parametersOfDisableAllListsEvents.Length.ShouldBe(1);
            methodDisableAllListsEventsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableAllListsEvents) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableAllListsEvents_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableAllListsEventsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableAllListsEvents = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodDisableAllListsEvents, parametersOfDisableAllListsEvents, methodDisableAllListsEventsPrametersTypes);

            // Assert
            parametersOfDisableAllListsEvents.ShouldNotBeNull();
            parametersOfDisableAllListsEvents.Length.ShouldBe(1);
            methodDisableAllListsEventsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableAllListsEvents) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableAllListsEvents_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDisableAllListsEventsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableAllListsEvents, Fixture, methodDisableAllListsEventsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDisableAllListsEventsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DisableAllListsEvents) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableAllListsEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisableAllListsEventsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableAllListsEvents, Fixture, methodDisableAllListsEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDisableAllListsEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableAllListsEvents) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableAllListsEvents_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableAllListsEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DisableAllListsEvents) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableAllListsEvents_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisableAllListsEvents, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableFeatures) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_EnableFeatures_Method_Call_Internally(Type[] types)
        {
            var methodEnableFeaturesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodEnableFeatures, Fixture, methodEnableFeaturesPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableFeatures) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableFeatures_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodEnableFeaturesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEnableFeatures = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableFeatures, methodEnableFeaturesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfEnableFeatures);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableFeatures.ShouldNotBeNull();
            parametersOfEnableFeatures.Length.ShouldBe(1);
            methodEnableFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFeatures) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableFeatures_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodEnableFeaturesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfEnableFeatures = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodEnableFeatures, parametersOfEnableFeatures, methodEnableFeaturesPrametersTypes);

            // Assert
            parametersOfEnableFeatures.ShouldNotBeNull();
            parametersOfEnableFeatures.Length.ShouldBe(1);
            methodEnableFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableFeatures) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableFeatures_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodEnableFeaturesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodEnableFeatures, Fixture, methodEnableFeaturesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodEnableFeaturesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (EnableFeatures) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableFeatures_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableFeaturesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodEnableFeatures, Fixture, methodEnableFeaturesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEnableFeaturesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableFeatures) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableFeatures_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableFeatures, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EnableFeatures) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_EnableFeatures_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableFeatures, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableFeatures) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Integration_DisableFeatures_Method_Call_Internally(Type[] types)
        {
            var methodDisableFeaturesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableFeatures, Fixture, methodDisableFeaturesPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableFeatures) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableFeatures_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableFeaturesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableFeatures = { xml };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableFeatures, methodDisableFeaturesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationInstanceFixture, parametersOfDisableFeatures);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableFeatures.ShouldNotBeNull();
            parametersOfDisableFeatures.Length.ShouldBe(1);
            methodDisableFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableFeatures) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableFeatures_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodDisableFeaturesPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisableFeatures = { xml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Integration, string>(_integrationInstance, MethodDisableFeatures, parametersOfDisableFeatures, methodDisableFeaturesPrametersTypes);

            // Assert
            parametersOfDisableFeatures.ShouldNotBeNull();
            parametersOfDisableFeatures.Length.ShouldBe(1);
            methodDisableFeaturesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableFeatures) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableFeatures_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDisableFeaturesPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableFeatures, Fixture, methodDisableFeaturesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDisableFeaturesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DisableFeatures) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableFeatures_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisableFeaturesPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationInstance, MethodDisableFeatures, Fixture, methodDisableFeaturesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDisableFeaturesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisableFeatures) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableFeatures_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableFeatures, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DisableFeatures) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Integration_DisableFeatures_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisableFeatures, 0);
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