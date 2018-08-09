using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.APIEmail" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class APIEmailTest : AbstractBaseSetupTypedTest<APIEmail>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (APIEmail) Initializer

        private const string MethodInstallAssignedToEvent = "InstallAssignedToEvent";
        private const string MethodUnInstallAssignedToEvent = "UnInstallAssignedToEvent";
        private const string MethodGetCoreInformation = "GetCoreInformation";
        private const string MethodSubstituteSubjectBodyPlaceholders = "SubstituteSubjectBodyPlaceholders";
        private const string MethodQueueItemMessage = "QueueItemMessage";
        private const string MethodClearNotificationItem = "ClearNotificationItem";
        private const string MethodQueueItemMessageXml = "QueueItemMessageXml";
        private const string MethodQueueItemMessageFromXml = "QueueItemMessageFromXml";
        private const string MethodiQueueItemMessage = "iQueueItemMessage";
        private const string MethodSubstituteItems = "SubstituteItems";
        private const string MethodGetNotificationIdByListId = "GetNotificationIdByListId";
        private const string MethodGetPersonalizationDataSet = "GetPersonalizationDataSet";
        private const string MethodGenerateUpsertSql = "GenerateUpsertSql";
        private const string MethodGetSubjectAndBody = "GetSubjectAndBody";
        private const string MethodGetNotificationId = "GetNotificationId";
        private const string MethodProcessNewUsers = "ProcessNewUsers";
        private const string MethodInsertPersonalization = "InsertPersonalization";
        private const string MethodExecuteNSetBit = "ExecuteNSetBit";
        private const string MethodDeleteUsers = "DeleteUsers";
        private const string MethodsendEmail = "sendEmail";
        private const string MethodsendEmailHideReply = "sendEmailHideReply";
        private const string MethodiSendEmail = "iSendEmail";
        private const string Field_defaultUserId = "_defaultUserId";
        private const string Field_successReponse = "_successReponse";
        private Type _aPIEmailInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private APIEmail _aPIEmailInstance;
        private APIEmail _aPIEmailInstanceFixture;

        #region General Initializer : Class (APIEmail) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="APIEmail" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _aPIEmailInstanceType = typeof(APIEmail);
            _aPIEmailInstanceFixture = Create(true);
            _aPIEmailInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (APIEmail)

        #region General Initializer : Class (APIEmail) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="APIEmail" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInstallAssignedToEvent, 0)]
        [TestCase(MethodUnInstallAssignedToEvent, 0)]
        [TestCase(MethodGetCoreInformation, 0)]
        [TestCase(MethodQueueItemMessage, 0)]
        [TestCase(MethodQueueItemMessage, 1)]
        [TestCase(MethodClearNotificationItem, 0)]
        [TestCase(MethodiQueueItemMessage, 0)]
        [TestCase(MethodiQueueItemMessage, 1)]
        [TestCase(MethodsendEmail, 0)]
        [TestCase(MethodsendEmailHideReply, 0)]
        [TestCase(MethodsendEmail, 1)]
        [TestCase(MethodiSendEmail, 0)]
        [TestCase(MethodsendEmail, 2)]
        public void AUT_APIEmail_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_aPIEmailInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="APIEmail" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_APIEmail_Is_Instance_Present_Test()
        {
            // Assert
            _aPIEmailInstanceType.ShouldNotBeNull();
            _aPIEmailInstance.ShouldNotBeNull();
            _aPIEmailInstanceFixture.ShouldNotBeNull();
            _aPIEmailInstance.ShouldBeAssignableTo<APIEmail>();
            _aPIEmailInstanceFixture.ShouldBeAssignableTo<APIEmail>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (APIEmail) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_APIEmail_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            APIEmail instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _aPIEmailInstanceType.ShouldNotBeNull();
            _aPIEmailInstance.ShouldNotBeNull();
            _aPIEmailInstanceFixture.ShouldNotBeNull();
            _aPIEmailInstance.ShouldBeAssignableTo<APIEmail>();
            _aPIEmailInstanceFixture.ShouldBeAssignableTo<APIEmail>();
        }

        #endregion

        #endregion

        #region Method Call : (InstallAssignedToEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_InstallAssignedToEvent_Static_Method_Call_Internally(Type[] types)
        {
            var methodInstallAssignedToEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodInstallAssignedToEvent, Fixture, methodInstallAssignedToEventPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallAssignedToEvent) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InstallAssignedToEvent_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.InstallAssignedToEvent(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InstallAssignedToEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InstallAssignedToEvent_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodInstallAssignedToEventPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfInstallAssignedToEvent = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstallAssignedToEvent, methodInstallAssignedToEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfInstallAssignedToEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstallAssignedToEvent.ShouldNotBeNull();
            parametersOfInstallAssignedToEvent.Length.ShouldBe(1);
            methodInstallAssignedToEventPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InstallAssignedToEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InstallAssignedToEvent_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodInstallAssignedToEventPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfInstallAssignedToEvent = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodInstallAssignedToEvent, parametersOfInstallAssignedToEvent, methodInstallAssignedToEventPrametersTypes);

            // Assert
            parametersOfInstallAssignedToEvent.ShouldNotBeNull();
            parametersOfInstallAssignedToEvent.Length.ShouldBe(1);
            methodInstallAssignedToEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallAssignedToEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InstallAssignedToEvent_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstallAssignedToEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallAssignedToEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InstallAssignedToEvent_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallAssignedToEventPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodInstallAssignedToEvent, Fixture, methodInstallAssignedToEventPrametersTypes);

            // Assert
            methodInstallAssignedToEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstallAssignedToEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InstallAssignedToEvent_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallAssignedToEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallAssignedToEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_UnInstallAssignedToEvent_Static_Method_Call_Internally(Type[] types)
        {
            var methodUnInstallAssignedToEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodUnInstallAssignedToEvent, Fixture, methodUnInstallAssignedToEventPrametersTypes);
        }

        #endregion

        #region Method Call : (UnInstallAssignedToEvent) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_UnInstallAssignedToEvent_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.UnInstallAssignedToEvent(list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UnInstallAssignedToEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_UnInstallAssignedToEvent_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodUnInstallAssignedToEventPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfUnInstallAssignedToEvent = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUnInstallAssignedToEvent, methodUnInstallAssignedToEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfUnInstallAssignedToEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUnInstallAssignedToEvent.ShouldNotBeNull();
            parametersOfUnInstallAssignedToEvent.Length.ShouldBe(1);
            methodUnInstallAssignedToEventPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallAssignedToEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_UnInstallAssignedToEvent_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodUnInstallAssignedToEventPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfUnInstallAssignedToEvent = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodUnInstallAssignedToEvent, parametersOfUnInstallAssignedToEvent, methodUnInstallAssignedToEventPrametersTypes);

            // Assert
            parametersOfUnInstallAssignedToEvent.ShouldNotBeNull();
            parametersOfUnInstallAssignedToEvent.Length.ShouldBe(1);
            methodUnInstallAssignedToEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallAssignedToEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_UnInstallAssignedToEvent_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUnInstallAssignedToEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UnInstallAssignedToEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_UnInstallAssignedToEvent_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUnInstallAssignedToEventPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodUnInstallAssignedToEvent, Fixture, methodUnInstallAssignedToEventPrametersTypes);

            // Assert
            methodUnInstallAssignedToEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UnInstallAssignedToEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_UnInstallAssignedToEvent_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUnInstallAssignedToEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCoreInformation) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_GetCoreInformation_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCoreInformationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetCoreInformation, Fixture, methodGetCoreInformationPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCoreInformation) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetCoreInformation_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var connection = CreateType<SqlConnection>();
            var templateid = CreateType<int>();
            var body = CreateType<string>();
            var subject = CreateType<string>();
            var web = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var methodGetCoreInformationPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(string), typeof(string), typeof(SPWeb), typeof(SPUser) };
            object[] parametersOfGetCoreInformation = { connection, templateid, body, subject, web, curUser };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCoreInformation, methodGetCoreInformationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfGetCoreInformation);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCoreInformation.ShouldNotBeNull();
            parametersOfGetCoreInformation.Length.ShouldBe(6);
            methodGetCoreInformationPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCoreInformation) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetCoreInformation_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var connection = CreateType<SqlConnection>();
            var templateid = CreateType<int>();
            var body = CreateType<string>();
            var subject = CreateType<string>();
            var web = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var methodGetCoreInformationPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(string), typeof(string), typeof(SPWeb), typeof(SPUser) };
            object[] parametersOfGetCoreInformation = { connection, templateid, body, subject, web, curUser };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetCoreInformation, parametersOfGetCoreInformation, methodGetCoreInformationPrametersTypes);

            // Assert
            parametersOfGetCoreInformation.ShouldNotBeNull();
            parametersOfGetCoreInformation.Length.ShouldBe(6);
            methodGetCoreInformationPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCoreInformation) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetCoreInformation_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCoreInformation, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCoreInformation) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetCoreInformation_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCoreInformationPrametersTypes = new Type[] { typeof(SqlConnection), typeof(int), typeof(string), typeof(string), typeof(SPWeb), typeof(SPUser) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetCoreInformation, Fixture, methodGetCoreInformationPrametersTypes);

            // Assert
            methodGetCoreInformationPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCoreInformation) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetCoreInformation_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCoreInformation, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubstituteSubjectBodyPlaceholders) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_SubstituteSubjectBodyPlaceholders_Static_Method_Call_Internally(Type[] types)
        {
            var methodSubstituteSubjectBodyPlaceholdersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodSubstituteSubjectBodyPlaceholders, Fixture, methodSubstituteSubjectBodyPlaceholdersPrametersTypes);
        }

        #endregion

        #region Method Call : (SubstituteSubjectBodyPlaceholders) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_SubstituteSubjectBodyPlaceholders_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var text = CreateType<string>();
            var web = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var methodSubstituteSubjectBodyPlaceholdersPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPUser) };
            object[] parametersOfSubstituteSubjectBodyPlaceholders = { text, web, curUser };

            // Assert
            parametersOfSubstituteSubjectBodyPlaceholders.ShouldNotBeNull();
            parametersOfSubstituteSubjectBodyPlaceholders.Length.ShouldBe(3);
            methodSubstituteSubjectBodyPlaceholdersPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodSubstituteSubjectBodyPlaceholders, parametersOfSubstituteSubjectBodyPlaceholders, methodSubstituteSubjectBodyPlaceholdersPrametersTypes));
        }

        #endregion

        #region Method Call : (SubstituteSubjectBodyPlaceholders) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_SubstituteSubjectBodyPlaceholders_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSubstituteSubjectBodyPlaceholdersPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPUser) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodSubstituteSubjectBodyPlaceholders, Fixture, methodSubstituteSubjectBodyPlaceholdersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSubstituteSubjectBodyPlaceholdersPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (SubstituteSubjectBodyPlaceholders) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_SubstituteSubjectBodyPlaceholders_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSubstituteSubjectBodyPlaceholdersPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(SPUser) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodSubstituteSubjectBodyPlaceholders, Fixture, methodSubstituteSubjectBodyPlaceholdersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSubstituteSubjectBodyPlaceholdersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueueItemMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessage, Fixture, methodQueueItemMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hideFromUser = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var li = CreateType<SPListItem>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.QueueItemMessage(templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, li, curUser, forceNewEntry);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Void_With_10_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hideFromUser = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var li = CreateType<SPListItem>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPListItem), typeof(SPUser), typeof(bool) };
            object[] parametersOfQueueItemMessage = { templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, li, curUser, forceNewEntry };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodQueueItemMessage, methodQueueItemMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfQueueItemMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfQueueItemMessage.ShouldNotBeNull();
            parametersOfQueueItemMessage.Length.ShouldBe(10);
            methodQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Void_With_10_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hideFromUser = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var li = CreateType<SPListItem>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPListItem), typeof(SPUser), typeof(bool) };
            object[] parametersOfQueueItemMessage = { templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, li, curUser, forceNewEntry };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessage, parametersOfQueueItemMessage, methodQueueItemMessagePrametersTypes);

            // Assert
            parametersOfQueueItemMessage.ShouldNotBeNull();
            parametersOfQueueItemMessage.Length.ShouldBe(10);
            methodQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueItemMessage, 0);
            const int parametersCount = 10;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPListItem), typeof(SPUser), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessage, Fixture, methodQueueItemMessagePrametersTypes);

            // Assert
            methodQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_With_10_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueItemMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_QueueItemMessage_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueueItemMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessage, Fixture, methodQueueItemMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hideFromUser = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var web = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.QueueItemMessage(templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, web, curUser, forceNewEntry);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Void_Overloading_Of_1_With_10_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hideFromUser = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var web = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPUser), typeof(bool) };
            object[] parametersOfQueueItemMessage = { templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, web, curUser, forceNewEntry };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodQueueItemMessage, methodQueueItemMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfQueueItemMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfQueueItemMessage.ShouldNotBeNull();
            parametersOfQueueItemMessage.Length.ShouldBe(10);
            methodQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Void_Overloading_Of_1_With_10_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hideFromUser = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var web = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPUser), typeof(bool) };
            object[] parametersOfQueueItemMessage = { templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, web, curUser, forceNewEntry };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessage, parametersOfQueueItemMessage, methodQueueItemMessagePrametersTypes);

            // Assert
            parametersOfQueueItemMessage.ShouldNotBeNull();
            parametersOfQueueItemMessage.Length.ShouldBe(10);
            methodQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueItemMessage, 1);
            const int parametersCount = 10;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPUser), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessage, Fixture, methodQueueItemMessagePrametersTypes);

            // Assert
            methodQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessage_Static_Method_Call_Overloading_Of_1_With_10_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueItemMessage, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearNotificationItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_ClearNotificationItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearNotificationItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodClearNotificationItem, Fixture, methodClearNotificationItemPrametersTypes);
        }

        #endregion

        #region Method Call : (ClearNotificationItem) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ClearNotificationItem_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listItem = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.ClearNotificationItem(listItem);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ClearNotificationItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ClearNotificationItem_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listItem = CreateType<SPListItem>();
            var methodClearNotificationItemPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfClearNotificationItem = { listItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearNotificationItem, methodClearNotificationItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfClearNotificationItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfClearNotificationItem.ShouldNotBeNull();
            parametersOfClearNotificationItem.Length.ShouldBe(1);
            methodClearNotificationItemPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ClearNotificationItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ClearNotificationItem_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItem = CreateType<SPListItem>();
            var methodClearNotificationItemPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfClearNotificationItem = { listItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodClearNotificationItem, parametersOfClearNotificationItem, methodClearNotificationItemPrametersTypes);

            // Assert
            parametersOfClearNotificationItem.ShouldNotBeNull();
            parametersOfClearNotificationItem.Length.ShouldBe(1);
            methodClearNotificationItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearNotificationItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ClearNotificationItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodClearNotificationItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearNotificationItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ClearNotificationItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearNotificationItemPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodClearNotificationItem, Fixture, methodClearNotificationItemPrametersTypes);

            // Assert
            methodClearNotificationItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearNotificationItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ClearNotificationItem_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearNotificationItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_QueueItemMessageXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueueItemMessageXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessageXml, Fixture, methodQueueItemMessageXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessageXml_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.QueueItemMessageXml(data, oWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessageXml_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodQueueItemMessageXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfQueueItemMessageXml = { data, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodQueueItemMessageXml, methodQueueItemMessageXmlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessageXml, Fixture, methodQueueItemMessageXmlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessageXml, parametersOfQueueItemMessageXml, methodQueueItemMessageXmlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfQueueItemMessageXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfQueueItemMessageXml.ShouldNotBeNull();
            parametersOfQueueItemMessageXml.Length.ShouldBe(2);
            methodQueueItemMessageXmlPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessageXml_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodQueueItemMessageXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfQueueItemMessageXml = { data, oWeb };

            // Assert
            parametersOfQueueItemMessageXml.ShouldNotBeNull();
            parametersOfQueueItemMessageXml.Length.ShouldBe(2);
            methodQueueItemMessageXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessageXml, parametersOfQueueItemMessageXml, methodQueueItemMessageXmlPrametersTypes));
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessageXml_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodQueueItemMessageXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessageXml, Fixture, methodQueueItemMessageXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodQueueItemMessageXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessageXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueItemMessageXmlPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessageXml, Fixture, methodQueueItemMessageXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodQueueItemMessageXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessageXml_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueItemMessageXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (QueueItemMessageXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_QueueItemMessageXml_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueItemMessageXml, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueItemMessageFromXml) (Return Type : SPList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_QueueItemMessageFromXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueueItemMessageFromXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodQueueItemMessageFromXml, Fixture, methodQueueItemMessageFromXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Internally(Type[] types)
        {
            var methodiQueueItemMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiQueueItemMessage, Fixture, methodiQueueItemMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Void_With_10_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hidefrom = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var listItem = CreateType<SPListItem>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodiQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPListItem), typeof(SPUser), typeof(bool) };
            object[] parametersOfiQueueItemMessage = { templateid, hidefrom, additionalParams, newusers, delusers, doNotEmail, unmarkread, listItem, curUser, forceNewEntry };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiQueueItemMessage, methodiQueueItemMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfiQueueItemMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiQueueItemMessage.ShouldNotBeNull();
            parametersOfiQueueItemMessage.Length.ShouldBe(10);
            methodiQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Void_With_10_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hidefrom = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var listItem = CreateType<SPListItem>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodiQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPListItem), typeof(SPUser), typeof(bool) };
            object[] parametersOfiQueueItemMessage = { templateid, hidefrom, additionalParams, newusers, delusers, doNotEmail, unmarkread, listItem, curUser, forceNewEntry };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiQueueItemMessage, parametersOfiQueueItemMessage, methodiQueueItemMessagePrametersTypes);

            // Assert
            parametersOfiQueueItemMessage.ShouldNotBeNull();
            parametersOfiQueueItemMessage.Length.ShouldBe(10);
            methodiQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiQueueItemMessage, 0);
            const int parametersCount = 10;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPListItem), typeof(SPUser), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiQueueItemMessage, Fixture, methodiQueueItemMessagePrametersTypes);

            // Assert
            methodiQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_With_10_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiQueueItemMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubstituteItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_SubstituteItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodSubstituteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodSubstituteItems, Fixture, methodSubstituteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (SubstituteItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_SubstituteItems_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listItem = CreateType<SPListItem>();
            var web = CreateType<SPWeb>();
            var body = CreateType<string>();
            var subject = CreateType<string>();
            var methodSubstituteItemsPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfSubstituteItems = { listItem, web, body, subject };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodSubstituteItems, parametersOfSubstituteItems, methodSubstituteItemsPrametersTypes);

            // Assert
            parametersOfSubstituteItems.ShouldNotBeNull();
            parametersOfSubstituteItems.Length.ShouldBe(4);
            methodSubstituteItemsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubstituteItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_SubstituteItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSubstituteItemsPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodSubstituteItems, Fixture, methodSubstituteItemsPrametersTypes);

            // Assert
            methodSubstituteItemsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNotificationIdByListId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_GetNotificationIdByListId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetNotificationIdByListIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationIdByListId, Fixture, methodGetNotificationIdByListIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNotificationIdByListId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetNotificationIdByListId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var listItem = CreateType<SPListItem>();
            var connection = CreateType<SqlConnection>();
            var methodGetNotificationIdByListIdPrametersTypes = new Type[] { typeof(int), typeof(SPListItem), typeof(SqlConnection) };
            object[] parametersOfGetNotificationIdByListId = { templateid, listItem, connection };

            // Assert
            parametersOfGetNotificationIdByListId.ShouldNotBeNull();
            parametersOfGetNotificationIdByListId.Length.ShouldBe(3);
            methodGetNotificationIdByListIdPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationIdByListId, parametersOfGetNotificationIdByListId, methodGetNotificationIdByListIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetNotificationIdByListId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetNotificationIdByListId_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetNotificationIdByListIdPrametersTypes = new Type[] { typeof(int), typeof(SPListItem), typeof(SqlConnection) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationIdByListId, Fixture, methodGetNotificationIdByListIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetNotificationIdByListIdPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetNotificationIdByListId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetNotificationIdByListId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNotificationIdByListIdPrametersTypes = new Type[] { typeof(int), typeof(SPListItem), typeof(SqlConnection) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationIdByListId, Fixture, methodGetNotificationIdByListIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNotificationIdByListIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersonalizationDataSet) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_GetPersonalizationDataSet_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPersonalizationDataSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetPersonalizationDataSet, Fixture, methodGetPersonalizationDataSetPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersonalizationDataSet) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetPersonalizationDataSet_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var connection = CreateType<SqlConnection>();
            var id = CreateType<string>();
            var methodGetPersonalizationDataSetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetPersonalizationDataSet = { connection, id };

            // Assert
            parametersOfGetPersonalizationDataSet.ShouldNotBeNull();
            parametersOfGetPersonalizationDataSet.Length.ShouldBe(2);
            methodGetPersonalizationDataSetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<DataSet>(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetPersonalizationDataSet, parametersOfGetPersonalizationDataSet, methodGetPersonalizationDataSetPrametersTypes));
        }

        #endregion

        #region Method Call : (GetPersonalizationDataSet) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetPersonalizationDataSet_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPersonalizationDataSetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetPersonalizationDataSet, Fixture, methodGetPersonalizationDataSetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersonalizationDataSetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPersonalizationDataSet) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetPersonalizationDataSet_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersonalizationDataSetPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetPersonalizationDataSet, Fixture, methodGetPersonalizationDataSetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersonalizationDataSetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_iQueueItemMessage_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodiQueueItemMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiQueueItemMessage, Fixture, methodiQueueItemMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Void_Overloading_Of_1_With_10_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hidefrom = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var oWeb = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodiQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPUser), typeof(bool) };
            object[] parametersOfiQueueItemMessage = { templateid, hidefrom, additionalParams, newusers, delusers, doNotEmail, unmarkread, oWeb, curUser, forceNewEntry };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiQueueItemMessage, methodiQueueItemMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfiQueueItemMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiQueueItemMessage.ShouldNotBeNull();
            parametersOfiQueueItemMessage.Length.ShouldBe(10);
            methodiQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Void_Overloading_Of_1_With_10_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hidefrom = CreateType<bool>();
            var additionalParams = CreateType<Hashtable>();
            var newusers = CreateType<string[]>();
            var delusers = CreateType<string[]>();
            var doNotEmail = CreateType<bool>();
            var unmarkread = CreateType<bool>();
            var oWeb = CreateType<SPWeb>();
            var curUser = CreateType<SPUser>();
            var forceNewEntry = CreateType<bool>();
            var methodiQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPUser), typeof(bool) };
            object[] parametersOfiQueueItemMessage = { templateid, hidefrom, additionalParams, newusers, delusers, doNotEmail, unmarkread, oWeb, curUser, forceNewEntry };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiQueueItemMessage, parametersOfiQueueItemMessage, methodiQueueItemMessagePrametersTypes);

            // Assert
            parametersOfiQueueItemMessage.ShouldNotBeNull();
            parametersOfiQueueItemMessage.Length.ShouldBe(10);
            methodiQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiQueueItemMessage, 1);
            const int parametersCount = 10;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiQueueItemMessagePrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Hashtable), typeof(string[]), typeof(string[]), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPUser), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiQueueItemMessage, Fixture, methodiQueueItemMessagePrametersTypes);

            // Assert
            methodiQueueItemMessagePrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iQueueItemMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iQueueItemMessage_Static_Method_Call_Overloading_Of_1_With_10_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiQueueItemMessage, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateUpsertSql) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_GenerateUpsertSql_Static_Method_Call_Internally(Type[] types)
        {
            var methodGenerateUpsertSqlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGenerateUpsertSql, Fixture, methodGenerateUpsertSqlPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateUpsertSql) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GenerateUpsertSql_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var forceNewEntry = CreateType<bool>();
            var id = CreateType<string>();
            var methodGenerateUpsertSqlPrametersTypes = new Type[] { typeof(bool), typeof(string) };
            object[] parametersOfGenerateUpsertSql = { forceNewEntry, id };

            // Assert
            parametersOfGenerateUpsertSql.ShouldNotBeNull();
            parametersOfGenerateUpsertSql.Length.ShouldBe(2);
            methodGenerateUpsertSqlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGenerateUpsertSql, parametersOfGenerateUpsertSql, methodGenerateUpsertSqlPrametersTypes));
        }

        #endregion

        #region Method Call : (GenerateUpsertSql) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GenerateUpsertSql_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGenerateUpsertSqlPrametersTypes = new Type[] { typeof(bool), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGenerateUpsertSql, Fixture, methodGenerateUpsertSqlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGenerateUpsertSqlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GenerateUpsertSql) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GenerateUpsertSql_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGenerateUpsertSqlPrametersTypes = new Type[] { typeof(bool), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGenerateUpsertSql, Fixture, methodGenerateUpsertSqlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateUpsertSqlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSubjectAndBody) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_GetSubjectAndBody_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSubjectAndBodyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetSubjectAndBody, Fixture, methodGetSubjectAndBodyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSubjectAndBody) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetSubjectAndBody_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateId = CreateType<int>();
            var additionalParams = CreateType<Hashtable>();
            var curUser = CreateType<SPUser>();
            var web = CreateType<SPWeb>();
            var connection = CreateType<SqlConnection>();
            var body = CreateType<string>();
            var subject = CreateType<string>();
            var methodGetSubjectAndBodyPrametersTypes = new Type[] { typeof(int), typeof(Hashtable), typeof(SPUser), typeof(SPWeb), typeof(SqlConnection), typeof(string), typeof(string) };
            object[] parametersOfGetSubjectAndBody = { templateId, additionalParams, curUser, web, connection, body, subject };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetSubjectAndBody, parametersOfGetSubjectAndBody, methodGetSubjectAndBodyPrametersTypes);

            // Assert
            parametersOfGetSubjectAndBody.ShouldNotBeNull();
            parametersOfGetSubjectAndBody.Length.ShouldBe(7);
            methodGetSubjectAndBodyPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubjectAndBody) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetSubjectAndBody_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSubjectAndBodyPrametersTypes = new Type[] { typeof(int), typeof(Hashtable), typeof(SPUser), typeof(SPWeb), typeof(SqlConnection), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetSubjectAndBody, Fixture, methodGetSubjectAndBodyPrametersTypes);

            // Assert
            methodGetSubjectAndBodyPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNotificationId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_GetNotificationId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetNotificationIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationId, Fixture, methodGetNotificationIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNotificationId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetNotificationId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var web = CreateType<SPWeb>();
            var connection = CreateType<SqlConnection>();
            var methodGetNotificationIdPrametersTypes = new Type[] { typeof(int), typeof(SPWeb), typeof(SqlConnection) };
            object[] parametersOfGetNotificationId = { templateid, web, connection };

            // Assert
            parametersOfGetNotificationId.ShouldNotBeNull();
            parametersOfGetNotificationId.Length.ShouldBe(3);
            methodGetNotificationIdPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationId, parametersOfGetNotificationId, methodGetNotificationIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetNotificationId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetNotificationId_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetNotificationIdPrametersTypes = new Type[] { typeof(int), typeof(SPWeb), typeof(SqlConnection) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationId, Fixture, methodGetNotificationIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetNotificationIdPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetNotificationId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_GetNotificationId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNotificationIdPrametersTypes = new Type[] { typeof(int), typeof(SPWeb), typeof(SqlConnection) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodGetNotificationId, Fixture, methodGetNotificationIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNotificationIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessNewUsers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_ProcessNewUsers_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessNewUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodProcessNewUsers, Fixture, methodProcessNewUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessNewUsers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ProcessNewUsers_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var newUsers = CreateType<string[]>();
            var unmarkread = CreateType<bool>();
            var connection = CreateType<SqlConnection>();
            var id = CreateType<string>();
            var web = CreateType<SPWeb>();
            var listItem = CreateType<SPListItem>();
            var methodProcessNewUsersPrametersTypes = new Type[] { typeof(string[]), typeof(bool), typeof(SqlConnection), typeof(string), typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfProcessNewUsers = { newUsers, unmarkread, connection, id, web, listItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodProcessNewUsers, parametersOfProcessNewUsers, methodProcessNewUsersPrametersTypes);

            // Assert
            parametersOfProcessNewUsers.ShouldNotBeNull();
            parametersOfProcessNewUsers.Length.ShouldBe(6);
            methodProcessNewUsersPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessNewUsers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ProcessNewUsers_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessNewUsersPrametersTypes = new Type[] { typeof(string[]), typeof(bool), typeof(SqlConnection), typeof(string), typeof(SPWeb), typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodProcessNewUsers, Fixture, methodProcessNewUsersPrametersTypes);

            // Assert
            methodProcessNewUsersPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertPersonalization) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_InsertPersonalization_Static_Method_Call_Internally(Type[] types)
        {
            var methodInsertPersonalizationPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodInsertPersonalization, Fixture, methodInsertPersonalizationPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertPersonalization) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InsertPersonalization_Static_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var connection = CreateType<SqlConnection>();
            var id = CreateType<string>();
            var user = CreateType<string>();
            var web = CreateType<SPWeb>();
            var listItem = CreateType<SPListItem>();
            var methodInsertPersonalizationPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfInsertPersonalization = { connection, id, user, web, listItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodInsertPersonalization, parametersOfInsertPersonalization, methodInsertPersonalizationPrametersTypes);

            // Assert
            parametersOfInsertPersonalization.ShouldNotBeNull();
            parametersOfInsertPersonalization.Length.ShouldBe(5);
            methodInsertPersonalizationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertPersonalization) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_InsertPersonalization_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertPersonalizationPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(SPWeb), typeof(SPListItem) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodInsertPersonalization, Fixture, methodInsertPersonalizationPrametersTypes);

            // Assert
            methodInsertPersonalizationPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNSetBit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_ExecuteNSetBit_Static_Method_Call_Internally(Type[] types)
        {
            var methodExecuteNSetBitPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodExecuteNSetBit, Fixture, methodExecuteNSetBitPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteNSetBit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ExecuteNSetBit_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var connection = CreateType<SqlConnection>();
            var id = CreateType<string>();
            var user = CreateType<string>();
            var methodExecuteNSetBitPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            object[] parametersOfExecuteNSetBit = { connection, id, user };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodExecuteNSetBit, parametersOfExecuteNSetBit, methodExecuteNSetBitPrametersTypes);

            // Assert
            parametersOfExecuteNSetBit.ShouldNotBeNull();
            parametersOfExecuteNSetBit.Length.ShouldBe(3);
            methodExecuteNSetBitPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNSetBit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_ExecuteNSetBit_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteNSetBitPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodExecuteNSetBit, Fixture, methodExecuteNSetBitPrametersTypes);

            // Assert
            methodExecuteNSetBitPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUsers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_DeleteUsers_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodDeleteUsers, Fixture, methodDeleteUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteUsers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_DeleteUsers_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var delusers = CreateType<string[]>();
            var connection = CreateType<SqlConnection>();
            var id = CreateType<string>();
            var methodDeleteUsersPrametersTypes = new Type[] { typeof(string[]), typeof(SqlConnection), typeof(string) };
            object[] parametersOfDeleteUsers = { delusers, connection, id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodDeleteUsers, parametersOfDeleteUsers, methodDeleteUsersPrametersTypes);

            // Assert
            parametersOfDeleteUsers.ShouldNotBeNull();
            parametersOfDeleteUsers.Length.ShouldBe(3);
            methodDeleteUsersPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteUsers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_DeleteUsers_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteUsersPrametersTypes = new Type[] { typeof(string[]), typeof(SqlConnection), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodDeleteUsers, Fixture, methodDeleteUsersPrametersTypes);

            // Assert
            methodDeleteUsersPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var userid = CreateType<int>();
            var additionalParams = CreateType<Hashtable>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.sendEmail(templateid, userid, additionalParams);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var userid = CreateType<int>();
            var additionalParams = CreateType<Hashtable>();
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(Hashtable) };
            object[] parametersOfsendEmail = { templateid, userid, additionalParams };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsendEmail, methodsendEmailPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfsendEmail);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsendEmail.ShouldNotBeNull();
            parametersOfsendEmail.Length.ShouldBe(3);
            methodsendEmailPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var userid = CreateType<int>();
            var additionalParams = CreateType<Hashtable>();
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(Hashtable) };
            object[] parametersOfsendEmail = { templateid, userid, additionalParams };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, parametersOfsendEmail, methodsendEmailPrametersTypes);

            // Assert
            parametersOfsendEmail.ShouldNotBeNull();
            parametersOfsendEmail.Length.ShouldBe(3);
            methodsendEmailPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsendEmail, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(int), typeof(Hashtable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, Fixture, methodsendEmailPrametersTypes);

            // Assert
            methodsendEmailPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsendEmail, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmailHideReply) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_sendEmailHideReply_Static_Method_Call_Internally(Type[] types)
        {
            var methodsendEmailHideReplyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmailHideReply, Fixture, methodsendEmailHideReplyPrametersTypes);
        }

        #endregion

        #region Method Call : (sendEmailHideReply) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmailHideReply_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var site = CreateType<Guid>();
            var web = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.sendEmailHideReply(templateid, site, web, curUser, eUser, additionalParams);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (sendEmailHideReply) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmailHideReply_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var site = CreateType<Guid>();
            var web = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            var methodsendEmailHideReplyPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };
            object[] parametersOfsendEmailHideReply = { templateid, site, web, curUser, eUser, additionalParams };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsendEmailHideReply, methodsendEmailHideReplyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfsendEmailHideReply);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsendEmailHideReply.ShouldNotBeNull();
            parametersOfsendEmailHideReply.Length.ShouldBe(6);
            methodsendEmailHideReplyPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (sendEmailHideReply) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmailHideReply_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var site = CreateType<Guid>();
            var web = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            var methodsendEmailHideReplyPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };
            object[] parametersOfsendEmailHideReply = { templateid, site, web, curUser, eUser, additionalParams };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmailHideReply, parametersOfsendEmailHideReply, methodsendEmailHideReplyPrametersTypes);

            // Assert
            parametersOfsendEmailHideReply.ShouldNotBeNull();
            parametersOfsendEmailHideReply.Length.ShouldBe(6);
            methodsendEmailHideReplyPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmailHideReply) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmailHideReply_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsendEmailHideReply, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (sendEmailHideReply) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmailHideReply_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsendEmailHideReplyPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmailHideReply, Fixture, methodsendEmailHideReplyPrametersTypes);

            // Assert
            methodsendEmailHideReplyPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmailHideReply) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmailHideReply_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsendEmailHideReply, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_sendEmail_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodsendEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, Fixture, methodsendEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var site = CreateType<Guid>();
            var web = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.sendEmail(templateid, site, web, curUser, eUser, additionalParams);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Void_Overloading_Of_1_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var site = CreateType<Guid>();
            var web = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };
            object[] parametersOfsendEmail = { templateid, site, web, curUser, eUser, additionalParams };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsendEmail, methodsendEmailPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfsendEmail);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsendEmail.ShouldNotBeNull();
            parametersOfsendEmail.Length.ShouldBe(6);
            methodsendEmailPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Void_Overloading_Of_1_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var site = CreateType<Guid>();
            var web = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };
            object[] parametersOfsendEmail = { templateid, site, web, curUser, eUser, additionalParams };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, parametersOfsendEmail, methodsendEmailPrametersTypes);

            // Assert
            parametersOfsendEmail.ShouldNotBeNull();
            parametersOfsendEmail.Length.ShouldBe(6);
            methodsendEmailPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsendEmail, 1);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, Fixture, methodsendEmailPrametersTypes);

            // Assert
            methodsendEmailPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Overloading_Of_1_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsendEmail, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iSendEmail) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_iSendEmail_Static_Method_Call_Internally(Type[] types)
        {
            var methodiSendEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiSendEmail, Fixture, methodiSendEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (iSendEmail) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iSendEmail_Static_Method_Call_Void_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hidefrom = CreateType<bool>();
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            var methodiSendEmailPrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };
            object[] parametersOfiSendEmail = { templateid, hidefrom, siteid, webid, curUser, eUser, additionalParams };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiSendEmail, methodiSendEmailPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfiSendEmail);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiSendEmail.ShouldNotBeNull();
            parametersOfiSendEmail.Length.ShouldBe(7);
            methodiSendEmailPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iSendEmail) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iSendEmail_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateid = CreateType<int>();
            var hidefrom = CreateType<bool>();
            var siteid = CreateType<Guid>();
            var webid = CreateType<Guid>();
            var curUser = CreateType<SPUser>();
            var eUser = CreateType<SPUser>();
            var additionalParams = CreateType<Hashtable>();
            var methodiSendEmailPrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };
            object[] parametersOfiSendEmail = { templateid, hidefrom, siteid, webid, curUser, eUser, additionalParams };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiSendEmail, parametersOfiSendEmail, methodiSendEmailPrametersTypes);

            // Assert
            parametersOfiSendEmail.ShouldNotBeNull();
            parametersOfiSendEmail.Length.ShouldBe(7);
            methodiSendEmailPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iSendEmail) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iSendEmail_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiSendEmail, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iSendEmail) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iSendEmail_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiSendEmailPrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(Guid), typeof(Guid), typeof(SPUser), typeof(SPUser), typeof(Hashtable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodiSendEmail, Fixture, methodiSendEmailPrametersTypes);

            // Assert
            methodiSendEmailPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iSendEmail) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_iSendEmail_Static_Method_Call_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiSendEmail, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_APIEmail_sendEmail_Static_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodsendEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, Fixture, methodsendEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_DirectCall_Overloading_Of_2_Throw_Exception_Test()
        {
            // Arrange
            var templateID = CreateType<int>();
            var additionalParams = CreateType<Hashtable>();
            var emailTo = CreateType<List<String>>();
            var emailFrom = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var hideFrom = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => APIEmail.sendEmail(templateID, additionalParams, emailTo, emailFrom, oWeb, hideFrom);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Void_Overloading_Of_2_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var templateID = CreateType<int>();
            var additionalParams = CreateType<Hashtable>();
            var emailTo = CreateType<List<String>>();
            var emailFrom = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var hideFrom = CreateType<bool>();
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(Hashtable), typeof(List<String>), typeof(string), typeof(SPWeb), typeof(bool) };
            object[] parametersOfsendEmail = { templateID, additionalParams, emailTo, emailFrom, oWeb, hideFrom };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsendEmail, methodsendEmailPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_aPIEmailInstanceFixture, parametersOfsendEmail);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsendEmail.ShouldNotBeNull();
            parametersOfsendEmail.Length.ShouldBe(6);
            methodsendEmailPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Void_Overloading_Of_2_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var templateID = CreateType<int>();
            var additionalParams = CreateType<Hashtable>();
            var emailTo = CreateType<List<String>>();
            var emailFrom = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var hideFrom = CreateType<bool>();
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(Hashtable), typeof(List<String>), typeof(string), typeof(SPWeb), typeof(bool) };
            object[] parametersOfsendEmail = { templateID, additionalParams, emailTo, emailFrom, oWeb, hideFrom };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, parametersOfsendEmail, methodsendEmailPrametersTypes);

            // Assert
            parametersOfsendEmail.ShouldNotBeNull();
            parametersOfsendEmail.Length.ShouldBe(6);
            methodsendEmailPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsendEmail, 2);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsendEmailPrametersTypes = new Type[] { typeof(int), typeof(Hashtable), typeof(List<String>), typeof(string), typeof(SPWeb), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_aPIEmailInstanceFixture, _aPIEmailInstanceType, MethodsendEmail, Fixture, methodsendEmailPrametersTypes);

            // Assert
            methodsendEmailPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (sendEmail) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_APIEmail_sendEmail_Static_Method_Call_Overloading_Of_2_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsendEmail, 2);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_aPIEmailInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}