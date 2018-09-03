using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.Infrastructure.Logging;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.Win32;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using EPMLiveCore;
using CoreFunctions = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CoreFunctions" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class CoreFunctionsTest : AbstractBaseSetupTypedTest<CoreFunctions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CoreFunctions) Initializer

        private const string MethodCreatePlannerDef = "CreatePlannerDef";
        private const string MethodiGetListEventType = "iGetListEventType";
        private const string MethodiGetPlannerList = "iGetPlannerList";
        private const string MethodGetPlannerList = "GetPlannerList";
        private const string MethodGetJustUsername = "GetJustUsername";
        private const string MethodGetCleanUserNameWithDomain = "GetCleanUserNameWithDomain";
        private const string MethodGetCleanUserName = "GetCleanUserName";
        private const string MethodGetRealUserName = "GetRealUserName";
        private const string MethodGetUserNameWithDomain = "GetUserNameWithDomain";
        private const string MethodGetSafeGroupTitle = "GetSafeGroupTitle";
        private const string MethodGetSafeUserTitle = "GetSafeUserTitle";
        private const string MethodgetMainDomain = "getMainDomain";
        private const string MethodgetContractLevel = "getContractLevel";
        private const string MethodgetPrefix = "getPrefix";
        private const string MethodgetDomain = "getDomain";
        private const string MethodgetUserFromAD = "getUserFromAD";
        private const string MethodGetScheduleStatusField = "GetScheduleStatusField";
        private const string MethodGetDaysOverdueField = "GetDaysOverdueField";
        private const string MethodGetDueField = "GetDueField";
        private const string MethodgetUserString = "getUserString";
        private const string MethodDoesCurrentUserHaveFullControl = "DoesCurrentUserHaveFullControl";
        private const string MethodCurrentUserIsInRole = "CurrentUserIsInRole";
        private const string MethodUserIsInRole = "UserIsInRole";
        private const string MethodGetListEvents = "GetListEvents";
        private const string MethodGetWebEvents = "GetWebEvents";
        private const string MethodgetRealField = "getRealField";
        private const string MethodgetSiteItems = "getSiteItems";
        private const string MethodGetSiteItemsData = "GetSiteItemsData";
        private const string MethodGetSiteItemsListIds = "GetSiteItemsListIds";
        private const string MethodGenerateSiteItemFields = "GenerateSiteItemFields";
        private const string MethodGenerateFieldRefXml = "GenerateFieldRefXml";
        private const string MethodAddFieldsXmlIfNotInternal = "AddFieldsXmlIfNotInternal";
        private const string MethodgetItemXml = "getItemXml";
        private const string MethodgetMenuFromAssembly = "getMenuFromAssembly";
        private const string MethodgetFarmSetting = "getFarmSetting";
        private const string MethodsetFarmSetting = "setFarmSetting";
        private const string MethodgetWebAppSetting = "getWebAppSetting";
        private const string MethodsetWebAppSetting = "setWebAppSetting";
        private const string MethodgetConnectionString = "getConnectionString";
        private const string MethodgetReportingConnectionString = "getReportingConnectionString";
        private const string MethodGetTable = "GetTable";
        private const string MethodDecrypt = "Decrypt";
        private const string MethodsetConnectionString = "setConnectionString";
        private const string MethodsetListSetting = "setListSetting";
        private const string MethodgetListSetting = "getListSetting";
        private const string MethodcreateSite = "createSite";
        private const string MethodWebExistsUnderParentWeb = "WebExistsUnderParentWeb";
        private const string MethodCreateSiteFromItem = "CreateSiteFromItem";
        private const string MethodAddGroup = "AddGroup";
        private const string MethodGetSiteGroup = "GetSiteGroup";
        private const string MethodsetConfigSetting = "setConfigSetting";
        private const string MethodiGetLockedWeb = "iGetLockedWeb";
        private const string MethodgetLockedWeb = "getLockedWeb";
        private const string MethodgetConfigSetting = "getConfigSetting";
        private const string MethodgetLockConfigSetting = "getLockConfigSetting";
        private const string MethodiGetConfigSetting = "iGetConfigSetting";
        private const string MethodtranslateVariables = "translateVariables";
        private const string MethodgetLicenseCount = "getLicenseCount";
        private const string MethodcheckServerCount = "checkServerCount";
        private const string MethodfarmEncode = "farmEncode";
        private const string MethodgetFeatureLicenseUserCount = "getFeatureLicenseUserCount";
        private const string MethodgetFeatureUsers = "getFeatureUsers";
        private const string MethodgetUserCount = "getUserCount";
        private const string MethodcomputerCode = "computerCode";
        private const string MethodEncrypt = "Encrypt";
        private const string MethoddeleteKey = "deleteKey";
        private const string MethodGetStoreCreds = "GetStoreCreds";
        private const string MethodgetFeatureName = "getFeatureName";
        private const string MethodfeatureList = "featureList";
        private const string Methodenqueue = "enqueue";
        private const string MethodGetAssemblyVersion = "GetAssemblyVersion";
        private const string MethodGetFullAssemblyVersion = "GetFullAssemblyVersion";
        private const string MethodEnsureNoDuplicates = "EnsureNoDuplicates";
        private const string MethodGetResourceWithDuplicateEmail = "GetResourceWithDuplicateEmail";
        private const string MethodScheduleReportingRefreshJob = "ScheduleReportingRefreshJob";
        private const string MethodCreateProjectInNewWorkspace = "CreateProjectInNewWorkspace";
        private const string MethodIsAlphaNumeric = "IsAlphaNumeric";
        private const string FieldSharepointSystemAccountLowercase = "SharepointSystemAccountLowercase";
        private const string FieldInitVector = "InitVector";
        private const string FieldSaltValue = "SaltValue";
        private const string FieldHashAlgorithm = "HashAlgorithm";
        private const string FieldPasswordIterations = "PasswordIterations";
        private const string FieldKeySize = "KeySize";
        private const string Field_initVectorBytes = "_initVectorBytes";
        private const string Field_saltValueBytes = "_saltValueBytes";
        private const string Field_alphaNumericRegex = "_alphaNumericRegex";
        private Type _coreFunctionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CoreFunctions _coreFunctionsInstance;
        private CoreFunctions _coreFunctionsInstanceFixture;

        #region General Initializer : Class (CoreFunctions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CoreFunctions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _coreFunctionsInstanceType = typeof(CoreFunctions);
            _coreFunctionsInstanceFixture = Create(true);
            _coreFunctionsInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="CoreFunctions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CoreFunctions_Is_Instance_Present_Test()
        {
            // Assert
            _coreFunctionsInstanceType.ShouldNotBeNull();
            _coreFunctionsInstance.ShouldNotBeNull();
            _coreFunctionsInstanceFixture.ShouldNotBeNull();
            _coreFunctionsInstance.ShouldBeAssignableTo<CoreFunctions>();
            _coreFunctionsInstanceFixture.ShouldBeAssignableTo<CoreFunctions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CoreFunctions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CoreFunctions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CoreFunctions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _coreFunctionsInstanceType.ShouldNotBeNull();
            _coreFunctionsInstance.ShouldNotBeNull();
            _coreFunctionsInstanceFixture.ShouldNotBeNull();
            _coreFunctionsInstance.ShouldBeAssignableTo<CoreFunctions>();
            _coreFunctionsInstanceFixture.ShouldBeAssignableTo<CoreFunctions>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (CreatePlannerDef) (Return Type : PlannerDefinition) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_CreatePlannerDef_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreatePlannerDefPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreatePlannerDef, Fixture, methodCreatePlannerDefPrametersTypes);
        }

        #endregion

        #region Method Call : (CreatePlannerDef) (Return Type : PlannerDefinition) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreatePlannerDef_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var image = CreateType<string>();
            var enabled = CreateType<bool>();
            var command = CreateType<string>();
            var description = CreateType<string>();
            var displaytype = CreateType<int>();
            var commandPrefix = CreateType<string>();
            var methodCreatePlannerDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(string) };
            object[] parametersOfCreatePlannerDef = { title, image, enabled, command, description, displaytype, commandPrefix };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreatePlannerDef, methodCreatePlannerDefPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfCreatePlannerDef);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreatePlannerDef.ShouldNotBeNull();
            parametersOfCreatePlannerDef.Length.ShouldBe(7);
            methodCreatePlannerDefPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePlannerDef) (Return Type : PlannerDefinition) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreatePlannerDef_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var image = CreateType<string>();
            var enabled = CreateType<bool>();
            var command = CreateType<string>();
            var description = CreateType<string>();
            var displaytype = CreateType<int>();
            var commandPrefix = CreateType<string>();
            var methodCreatePlannerDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(string) };
            object[] parametersOfCreatePlannerDef = { title, image, enabled, command, description, displaytype, commandPrefix };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<PlannerDefinition>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreatePlannerDef, parametersOfCreatePlannerDef, methodCreatePlannerDefPrametersTypes);

            // Assert
            parametersOfCreatePlannerDef.ShouldNotBeNull();
            parametersOfCreatePlannerDef.Length.ShouldBe(7);
            methodCreatePlannerDefPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreatePlannerDef) (Return Type : PlannerDefinition) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreatePlannerDef_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreatePlannerDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreatePlannerDef, Fixture, methodCreatePlannerDefPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreatePlannerDefPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (CreatePlannerDef) (Return Type : PlannerDefinition) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreatePlannerDef_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreatePlannerDefPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(string) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreatePlannerDef, Fixture, methodCreatePlannerDefPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreatePlannerDefPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreatePlannerDef) (Return Type : PlannerDefinition) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreatePlannerDef_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreatePlannerDef, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreatePlannerDef) (Return Type : PlannerDefinition) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreatePlannerDef_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreatePlannerDef, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetListEventTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetListEventType, Fixture, methodiGetListEventTypePrametersTypes);
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var type = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.iGetListEventType(type);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var type = CreateType<string>();
            var methodiGetListEventTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfiGetListEventType = { type };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetListEventType, methodiGetListEventTypePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetListEventType, Fixture, methodiGetListEventTypePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPEventReceiverType>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetListEventType, parametersOfiGetListEventType, methodiGetListEventTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfiGetListEventType.ShouldNotBeNull();
            parametersOfiGetListEventType.Length.ShouldBe(1);
            methodiGetListEventTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SPEventReceiverType>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetListEventType, parametersOfiGetListEventType, methodiGetListEventTypePrametersTypes));
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var type = CreateType<string>();
            var methodiGetListEventTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfiGetListEventType = { type };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetListEventType, methodiGetListEventTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfiGetListEventType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetListEventType.ShouldNotBeNull();
            parametersOfiGetListEventType.Length.ShouldBe(1);
            methodiGetListEventTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var type = CreateType<string>();
            var methodiGetListEventTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfiGetListEventType = { type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPEventReceiverType>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetListEventType, parametersOfiGetListEventType, methodiGetListEventTypePrametersTypes);

            // Assert
            parametersOfiGetListEventType.ShouldNotBeNull();
            parametersOfiGetListEventType.Length.ShouldBe(1);
            methodiGetListEventTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodiGetListEventTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetListEventType, Fixture, methodiGetListEventTypePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodiGetListEventTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetListEventTypePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetListEventType, Fixture, methodiGetListEventTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetListEventTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetListEventType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (iGetListEventType) (Return Type : SPEventReceiverType) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetListEventType_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetListEventType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_iGetPlannerList_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetPlannerListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetPlannerList, Fixture, methodiGetPlannerListPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetPlannerList_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var lweb = CreateType<SPWeb>();
            var web = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var methodiGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfiGetPlannerList = { lweb, web, li };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetPlannerList, methodiGetPlannerListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfiGetPlannerList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetPlannerList.ShouldNotBeNull();
            parametersOfiGetPlannerList.Length.ShouldBe(3);
            methodiGetPlannerListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetPlannerList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lweb = CreateType<SPWeb>();
            var web = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var methodiGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfiGetPlannerList = { lweb, web, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, PlannerDefinition>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetPlannerList, parametersOfiGetPlannerList, methodiGetPlannerListPrametersTypes);

            // Assert
            parametersOfiGetPlannerList.ShouldNotBeNull();
            parametersOfiGetPlannerList.Length.ShouldBe(3);
            methodiGetPlannerListPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetPlannerList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetPlannerList, Fixture, methodiGetPlannerListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetPlannerListPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (iGetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetPlannerList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPWeb), typeof(SPListItem) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetPlannerList, Fixture, methodiGetPlannerListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetPlannerListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetPlannerList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetPlannerList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (iGetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetPlannerList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetPlannerList, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetPlannerList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPlannerListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetPlannerList, Fixture, methodGetPlannerListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetPlannerList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var inweb = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetPlannerList(inweb, li);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetPlannerList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var inweb = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var methodGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfGetPlannerList = { inweb, li };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPlannerList, methodGetPlannerListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetPlannerList, Fixture, methodGetPlannerListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, PlannerDefinition>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetPlannerList, parametersOfGetPlannerList, methodGetPlannerListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetPlannerList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPlannerList.ShouldNotBeNull();
            parametersOfGetPlannerList.Length.ShouldBe(2);
            methodGetPlannerListPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetPlannerList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var inweb = CreateType<SPWeb>();
            var li = CreateType<SPListItem>();
            var methodGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };
            object[] parametersOfGetPlannerList = { inweb, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, PlannerDefinition>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetPlannerList, parametersOfGetPlannerList, methodGetPlannerListPrametersTypes);

            // Assert
            parametersOfGetPlannerList.ShouldNotBeNull();
            parametersOfGetPlannerList.Length.ShouldBe(2);
            methodGetPlannerListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetPlannerList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetPlannerList, Fixture, methodGetPlannerListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPlannerListPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetPlannerList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPlannerListPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPListItem) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetPlannerList, Fixture, methodGetPlannerListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPlannerListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetPlannerList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPlannerList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPlannerList) (Return Type : Dictionary<string, PlannerDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetPlannerList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPlannerList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetJustUsername_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetJustUsernamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetJustUsername, Fixture, methodGetJustUsernamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetJustUsername_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetJustUsername(username);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetJustUsername_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetJustUsernamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetJustUsername = { username };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetJustUsername, methodGetJustUsernamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetJustUsername);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetJustUsername.ShouldNotBeNull();
            parametersOfGetJustUsername.Length.ShouldBe(1);
            methodGetJustUsernamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetJustUsername_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetJustUsernamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetJustUsername = { username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetJustUsername, parametersOfGetJustUsername, methodGetJustUsernamePrametersTypes);

            // Assert
            parametersOfGetJustUsername.ShouldNotBeNull();
            parametersOfGetJustUsername.Length.ShouldBe(1);
            methodGetJustUsernamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetJustUsername_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetJustUsernamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetJustUsername, Fixture, methodGetJustUsernamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetJustUsernamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetJustUsername_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetJustUsernamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetJustUsername, Fixture, methodGetJustUsernamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetJustUsernamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetJustUsername_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetJustUsername, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetJustUsername) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetJustUsername_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetJustUsername, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUserNameWithDomain) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetCleanUserNameWithDomain_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanUserNameWithDomainPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserNameWithDomain, Fixture, methodGetCleanUserNameWithDomainPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanUserNameWithDomain) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserNameWithDomain_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetCleanUserNameWithDomain(web, username);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanUserNameWithDomain) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserNameWithDomain_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var username = CreateType<string>();
            var methodGetCleanUserNameWithDomainPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetCleanUserNameWithDomain = { web, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserNameWithDomain, parametersOfGetCleanUserNameWithDomain, methodGetCleanUserNameWithDomainPrametersTypes);

            // Assert
            parametersOfGetCleanUserNameWithDomain.ShouldNotBeNull();
            parametersOfGetCleanUserNameWithDomain.Length.ShouldBe(2);
            methodGetCleanUserNameWithDomainPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserNameWithDomain) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserNameWithDomain_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCleanUserNameWithDomainPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserNameWithDomain, Fixture, methodGetCleanUserNameWithDomainPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCleanUserNameWithDomainPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCleanUserNameWithDomain) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserNameWithDomain_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanUserNameWithDomainPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserNameWithDomain, Fixture, methodGetCleanUserNameWithDomainPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanUserNameWithDomainPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanUserNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetCleanUserName(username);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanUserName = { username };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, methodGetCleanUserNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetCleanUserName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCleanUserName.ShouldNotBeNull();
            parametersOfGetCleanUserName.Length.ShouldBe(1);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanUserName = { username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, parametersOfGetCleanUserName, methodGetCleanUserNamePrametersTypes);

            // Assert
            parametersOfGetCleanUserName.ShouldNotBeNull();
            parametersOfGetCleanUserName.Length.ShouldBe(1);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRealUserNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, Fixture, methodGetRealUserNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetRealUserName(username);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetRealUserName = { username };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRealUserName, methodGetRealUserNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetRealUserName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRealUserName.ShouldNotBeNull();
            parametersOfGetRealUserName.Length.ShouldBe(1);
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetRealUserName = { username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, parametersOfGetRealUserName, methodGetRealUserNamePrametersTypes);

            // Assert
            parametersOfGetRealUserName.ShouldNotBeNull();
            parametersOfGetRealUserName.Length.ShouldBe(1);
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, Fixture, methodGetRealUserNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, Fixture, methodGetRealUserNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRealUserName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRealUserName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUserNameWithDomainPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetUserNameWithDomain, Fixture, methodGetUserNameWithDomainPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetUserNameWithDomain(username);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetUserNameWithDomainPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUserNameWithDomain = { username };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetUserNameWithDomain, methodGetUserNameWithDomainPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetUserNameWithDomain);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetUserNameWithDomain.ShouldNotBeNull();
            parametersOfGetUserNameWithDomain.Length.ShouldBe(1);
            methodGetUserNameWithDomainPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var methodGetUserNameWithDomainPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetUserNameWithDomain = { username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetUserNameWithDomain, parametersOfGetUserNameWithDomain, methodGetUserNameWithDomainPrametersTypes);

            // Assert
            parametersOfGetUserNameWithDomain.ShouldNotBeNull();
            parametersOfGetUserNameWithDomain.Length.ShouldBe(1);
            methodGetUserNameWithDomainPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetUserNameWithDomainPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetUserNameWithDomain, Fixture, methodGetUserNameWithDomainPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetUserNameWithDomainPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserNameWithDomainPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetUserNameWithDomain, Fixture, methodGetUserNameWithDomainPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserNameWithDomainPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserNameWithDomain, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetUserNameWithDomain) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetUserNameWithDomain_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserNameWithDomain, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSafeGroupTitlePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeGroupTitle, Fixture, methodGetSafeGroupTitlePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sRawGrpName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetSafeGroupTitle(sRawGrpName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sRawGrpName = CreateType<string>();
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeGroupTitle = { sRawGrpName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSafeGroupTitle, methodGetSafeGroupTitlePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetSafeGroupTitle);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSafeGroupTitle.ShouldNotBeNull();
            parametersOfGetSafeGroupTitle.Length.ShouldBe(1);
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sRawGrpName = CreateType<string>();
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeGroupTitle = { sRawGrpName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeGroupTitle, parametersOfGetSafeGroupTitle, methodGetSafeGroupTitlePrametersTypes);

            // Assert
            parametersOfGetSafeGroupTitle.ShouldNotBeNull();
            parametersOfGetSafeGroupTitle.Length.ShouldBe(1);
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeGroupTitle, Fixture, methodGetSafeGroupTitlePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSafeGroupTitlePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeGroupTitle, Fixture, methodGetSafeGroupTitlePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSafeGroupTitlePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSafeGroupTitle, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSafeGroupTitle) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeGroupTitle_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSafeGroupTitle, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSafeUserTitlePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeUserTitle, Fixture, methodGetSafeUserTitlePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sUsrName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetSafeUserTitle(sUsrName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sUsrName = CreateType<string>();
            var methodGetSafeUserTitlePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeUserTitle = { sUsrName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSafeUserTitle, methodGetSafeUserTitlePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetSafeUserTitle);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSafeUserTitle.ShouldNotBeNull();
            parametersOfGetSafeUserTitle.Length.ShouldBe(1);
            methodGetSafeUserTitlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sUsrName = CreateType<string>();
            var methodGetSafeUserTitlePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSafeUserTitle = { sUsrName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeUserTitle, parametersOfGetSafeUserTitle, methodGetSafeUserTitlePrametersTypes);

            // Assert
            parametersOfGetSafeUserTitle.ShouldNotBeNull();
            parametersOfGetSafeUserTitle.Length.ShouldBe(1);
            methodGetSafeUserTitlePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSafeUserTitlePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeUserTitle, Fixture, methodGetSafeUserTitlePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSafeUserTitlePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSafeUserTitlePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSafeUserTitle, Fixture, methodGetSafeUserTitlePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSafeUserTitlePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSafeUserTitle, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSafeUserTitle) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSafeUserTitle_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSafeUserTitle, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetMainDomainPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, Fixture, methodgetMainDomainPrametersTypes);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getMainDomain();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetMainDomainPrametersTypes = null;
            object[] parametersOfgetMainDomain = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetMainDomain, methodgetMainDomainPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetMainDomain);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetMainDomain.ShouldBeNull();
            methodgetMainDomainPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetMainDomainPrametersTypes = null;
            object[] parametersOfgetMainDomain = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, parametersOfgetMainDomain, methodgetMainDomainPrametersTypes);

            // Assert
            parametersOfgetMainDomain.ShouldBeNull();
            methodgetMainDomainPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetMainDomainPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, Fixture, methodgetMainDomainPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetMainDomainPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetMainDomainPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, Fixture, methodgetMainDomainPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMainDomainPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMainDomain, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getMainDomain_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetMainDomainPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, Fixture, methodgetMainDomainPrametersTypes);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getMainDomain(site);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Overloading_Of_1_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetMainDomainPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetMainDomain = { site };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMainDomain, methodgetMainDomainPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, Fixture, methodgetMainDomainPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, parametersOfgetMainDomain, methodgetMainDomainPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetMainDomain.ShouldNotBeNull();
            parametersOfgetMainDomain.Length.ShouldBe(1);
            methodgetMainDomainPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, parametersOfgetMainDomain, methodgetMainDomainPrametersTypes));
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetMainDomainPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetMainDomain = { site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetMainDomain, methodgetMainDomainPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetMainDomain);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetMainDomain.ShouldNotBeNull();
            parametersOfgetMainDomain.Length.ShouldBe(1);
            methodgetMainDomainPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetMainDomainPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetMainDomain = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, parametersOfgetMainDomain, methodgetMainDomainPrametersTypes);

            // Assert
            parametersOfgetMainDomain.ShouldNotBeNull();
            parametersOfgetMainDomain.Length.ShouldBe(1);
            methodgetMainDomainPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetMainDomainPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, Fixture, methodgetMainDomainPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetMainDomainPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetMainDomainPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMainDomain, Fixture, methodgetMainDomainPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMainDomainPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMainDomain, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getMainDomain) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMainDomain_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetMainDomain, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetContractLevelPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, Fixture, methodgetContractLevelPrametersTypes);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getContractLevel();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetContractLevelPrametersTypes = null;
            object[] parametersOfgetContractLevel = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetContractLevel, methodgetContractLevelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetContractLevel);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetContractLevel.ShouldBeNull();
            methodgetContractLevelPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetContractLevelPrametersTypes = null;
            object[] parametersOfgetContractLevel = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, parametersOfgetContractLevel, methodgetContractLevelPrametersTypes);

            // Assert
            parametersOfgetContractLevel.ShouldBeNull();
            methodgetContractLevelPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetContractLevelPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, Fixture, methodgetContractLevelPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetContractLevelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetContractLevelPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, Fixture, methodgetContractLevelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetContractLevelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetContractLevel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getPrefix_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetPrefixPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getPrefix();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodgetPrefixPrametersTypes = null;
            object[] parametersOfgetPrefix = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetPrefix, methodgetPrefixPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetPrefix);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetPrefix.ShouldBeNull();
            methodgetPrefixPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetPrefixPrametersTypes = null;
            object[] parametersOfgetPrefix = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, parametersOfgetPrefix, methodgetPrefixPrametersTypes);

            // Assert
            parametersOfgetPrefix.ShouldBeNull();
            methodgetPrefixPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetPrefixPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetPrefixPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetPrefixPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPrefixPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetPrefix, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetCleanUserName_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetCleanUserNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetCleanUserName(username, site);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };
            object[] parametersOfGetCleanUserName = { username, site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, methodGetCleanUserNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetCleanUserName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCleanUserName.ShouldNotBeNull();
            parametersOfGetCleanUserName.Length.ShouldBe(2);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };
            object[] parametersOfGetCleanUserName = { username, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, parametersOfGetCleanUserName, methodGetCleanUserNamePrametersTypes);

            // Assert
            parametersOfGetCleanUserName.ShouldNotBeNull();
            parametersOfGetCleanUserName.Length.ShouldBe(2);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetCleanUserName, Fixture, methodGetCleanUserNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanUserNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanUserName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetCleanUserName_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanUserName, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getContractLevel_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetContractLevelPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, Fixture, methodgetContractLevelPrametersTypes);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getContractLevel(site);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Overloading_Of_1_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetContractLevelPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetContractLevel = { site };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetContractLevel, methodgetContractLevelPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, Fixture, methodgetContractLevelPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, parametersOfgetContractLevel, methodgetContractLevelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetContractLevel.ShouldNotBeNull();
            parametersOfgetContractLevel.Length.ShouldBe(1);
            methodgetContractLevelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, parametersOfgetContractLevel, methodgetContractLevelPrametersTypes));
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetContractLevelPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetContractLevel = { site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetContractLevel, methodgetContractLevelPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetContractLevel);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetContractLevel.ShouldNotBeNull();
            parametersOfgetContractLevel.Length.ShouldBe(1);
            methodgetContractLevelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetContractLevelPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetContractLevel = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, parametersOfgetContractLevel, methodgetContractLevelPrametersTypes);

            // Assert
            parametersOfgetContractLevel.ShouldNotBeNull();
            parametersOfgetContractLevel.Length.ShouldBe(1);
            methodgetContractLevelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetContractLevelPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, Fixture, methodgetContractLevelPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetContractLevelPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetContractLevelPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetContractLevel, Fixture, methodgetContractLevelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetContractLevelPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetContractLevel, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getContractLevel) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getContractLevel_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetContractLevel, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetRealUserName_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetRealUserNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, Fixture, methodGetRealUserNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetRealUserName(username, site);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };
            object[] parametersOfGetRealUserName = { username, site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRealUserName, methodGetRealUserNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetRealUserName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRealUserName.ShouldNotBeNull();
            parametersOfGetRealUserName.Length.ShouldBe(2);
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var username = CreateType<string>();
            var site = CreateType<SPSite>();
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };
            object[] parametersOfGetRealUserName = { username, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, parametersOfGetRealUserName, methodGetRealUserNamePrametersTypes);

            // Assert
            parametersOfGetRealUserName.ShouldNotBeNull();
            parametersOfGetRealUserName.Length.ShouldBe(2);
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, Fixture, methodGetRealUserNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRealUserNamePrametersTypes = new Type[] { typeof(string), typeof(SPSite) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetRealUserName, Fixture, methodGetRealUserNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRealUserNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRealUserName, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetRealUserName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetRealUserName_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRealUserName, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getPrefix_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetPrefixPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getPrefix(site);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Overloading_Of_1_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetPrefix = { site };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetPrefix, methodgetPrefixPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, parametersOfgetPrefix, methodgetPrefixPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetPrefix.ShouldNotBeNull();
            parametersOfgetPrefix.Length.ShouldBe(1);
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, parametersOfgetPrefix, methodgetPrefixPrametersTypes));
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetPrefix = { site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetPrefix, methodgetPrefixPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetPrefix);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetPrefix.ShouldNotBeNull();
            parametersOfgetPrefix.Length.ShouldBe(1);
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            object[] parametersOfgetPrefix = { site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, parametersOfgetPrefix, methodgetPrefixPrametersTypes);

            // Assert
            parametersOfgetPrefix.ShouldNotBeNull();
            parametersOfgetPrefix.Length.ShouldBe(1);
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetPrefixPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetPrefixPrametersTypes = new Type[] { typeof(SPSite) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetPrefix, Fixture, methodgetPrefixPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetPrefixPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetPrefix, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getPrefix) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getPrefix_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetPrefix, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getDomain_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetDomainPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetDomain, Fixture, methodgetDomainPrametersTypes);
        }

        #endregion
        
        #region Method Call : (getDomain) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getDomain_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodgetDomainPrametersTypes = null;
            object[] parametersOfgetDomain = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetDomain, parametersOfgetDomain, methodgetDomainPrametersTypes);

            // Assert
            parametersOfgetDomain.ShouldBeNull();
            methodgetDomainPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getDomain_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodgetDomainPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetDomain, Fixture, methodgetDomainPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetDomainPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getDomain) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getDomain_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodgetDomainPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetDomain, Fixture, methodgetDomainPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetDomainPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getUserFromAD_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetUserFromADPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserFromAD, Fixture, methodgetUserFromADPrametersTypes);
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserFromAD_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetUserFromADPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserFromAD, Fixture, methodgetUserFromADPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetUserFromADPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserFromAD_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetUserFromADPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserFromAD, Fixture, methodgetUserFromADPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetUserFromADPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserFromAD_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetUserFromAD, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getUserFromAD) (Return Type : DirectoryEntry) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserFromAD_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetUserFromAD, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetScheduleStatusFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetScheduleStatusField, Fixture, methodGetScheduleStatusFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetScheduleStatusField(ListItem);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            var methodGetScheduleStatusFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetScheduleStatusField = { ListItem };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetScheduleStatusField, methodGetScheduleStatusFieldPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetScheduleStatusField, Fixture, methodGetScheduleStatusFieldPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetScheduleStatusField, parametersOfGetScheduleStatusField, methodGetScheduleStatusFieldPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetScheduleStatusField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetScheduleStatusField.ShouldNotBeNull();
            parametersOfGetScheduleStatusField.Length.ShouldBe(1);
            methodGetScheduleStatusFieldPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            var methodGetScheduleStatusFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetScheduleStatusField = { ListItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetScheduleStatusField, parametersOfGetScheduleStatusField, methodGetScheduleStatusFieldPrametersTypes);

            // Assert
            parametersOfGetScheduleStatusField.ShouldNotBeNull();
            parametersOfGetScheduleStatusField.Length.ShouldBe(1);
            methodGetScheduleStatusFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetScheduleStatusFieldPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetScheduleStatusField, Fixture, methodGetScheduleStatusFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetScheduleStatusFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetScheduleStatusFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetScheduleStatusField, Fixture, methodGetScheduleStatusFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetScheduleStatusFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetScheduleStatusField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScheduleStatusField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetScheduleStatusField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetScheduleStatusField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDaysOverdueFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDaysOverdueField, Fixture, methodGetDaysOverdueFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetDaysOverdueField(ListItem);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            var methodGetDaysOverdueFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetDaysOverdueField = { ListItem };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDaysOverdueField, methodGetDaysOverdueFieldPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDaysOverdueField, Fixture, methodGetDaysOverdueFieldPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDaysOverdueField, parametersOfGetDaysOverdueField, methodGetDaysOverdueFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetDaysOverdueField.ShouldNotBeNull();
            parametersOfGetDaysOverdueField.Length.ShouldBe(1);
            methodGetDaysOverdueFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDaysOverdueField, parametersOfGetDaysOverdueField, methodGetDaysOverdueFieldPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            var methodGetDaysOverdueFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetDaysOverdueField = { ListItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDaysOverdueField, methodGetDaysOverdueFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetDaysOverdueField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDaysOverdueField.ShouldNotBeNull();
            parametersOfGetDaysOverdueField.Length.ShouldBe(1);
            methodGetDaysOverdueFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            var methodGetDaysOverdueFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetDaysOverdueField = { ListItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDaysOverdueField, parametersOfGetDaysOverdueField, methodGetDaysOverdueFieldPrametersTypes);

            // Assert
            parametersOfGetDaysOverdueField.ShouldNotBeNull();
            parametersOfGetDaysOverdueField.Length.ShouldBe(1);
            methodGetDaysOverdueFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetDaysOverdueFieldPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDaysOverdueField, Fixture, methodGetDaysOverdueFieldPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDaysOverdueFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDaysOverdueFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDaysOverdueField, Fixture, methodGetDaysOverdueFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDaysOverdueFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDaysOverdueField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetDaysOverdueField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDaysOverdueField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDaysOverdueField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetDueField_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDueFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDueField, Fixture, methodGetDueFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDueField_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetDueField(ListItem);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDueField_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            var methodGetDueFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetDueField = { ListItem };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDueField, methodGetDueFieldPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDueField, Fixture, methodGetDueFieldPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDueField, parametersOfGetDueField, methodGetDueFieldPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetDueField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDueField.ShouldNotBeNull();
            parametersOfGetDueField.Length.ShouldBe(1);
            methodGetDueFieldPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDueField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ListItem = CreateType<SPListItem>();
            var methodGetDueFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfGetDueField = { ListItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDueField, parametersOfGetDueField, methodGetDueFieldPrametersTypes);

            // Assert
            parametersOfGetDueField.ShouldNotBeNull();
            parametersOfGetDueField.Length.ShouldBe(1);
            methodGetDueFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDueField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDueFieldPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDueField, Fixture, methodGetDueFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDueFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDueField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDueFieldPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetDueField, Fixture, methodGetDueFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDueFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDueField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDueField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDueField) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetDueField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDueField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getUserString_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetUserStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var usernames = CreateType<string>();
            var web = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getUserString(usernames, web, sPrefix);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var usernames = CreateType<string>();
            var web = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            object[] parametersOfgetUserString = { usernames, web, sPrefix };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetUserString, methodgetUserStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserString, parametersOfgetUserString, methodgetUserStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetUserString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetUserString.ShouldNotBeNull();
            parametersOfgetUserString.Length.ShouldBe(3);
            methodgetUserStringPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var usernames = CreateType<string>();
            var web = CreateType<SPWeb>();
            var sPrefix = CreateType<string>();
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            object[] parametersOfgetUserString = { usernames, web, sPrefix };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserString, parametersOfgetUserString, methodgetUserStringPrametersTypes);

            // Assert
            parametersOfgetUserString.ShouldNotBeNull();
            parametersOfgetUserString.Length.ShouldBe(3);
            methodgetUserStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetUserStringPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetUserStringPrametersTypes = new Type[] { typeof(string), typeof(SPWeb), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserString, Fixture, methodgetUserStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetUserStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetUserString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getUserString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetUserString, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoesCurrentUserHaveFullControl) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_DoesCurrentUserHaveFullControl_Static_Method_Call_Internally(Type[] types)
        {
            var methodDoesCurrentUserHaveFullControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDoesCurrentUserHaveFullControl, Fixture, methodDoesCurrentUserHaveFullControlPrametersTypes);
        }

        #endregion

        #region Method Call : (DoesCurrentUserHaveFullControl) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_DoesCurrentUserHaveFullControl_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.DoesCurrentUserHaveFullControl(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoesCurrentUserHaveFullControl) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_DoesCurrentUserHaveFullControl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodDoesCurrentUserHaveFullControlPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfDoesCurrentUserHaveFullControl = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDoesCurrentUserHaveFullControl, parametersOfDoesCurrentUserHaveFullControl, methodDoesCurrentUserHaveFullControlPrametersTypes);

            // Assert
            parametersOfDoesCurrentUserHaveFullControl.ShouldNotBeNull();
            parametersOfDoesCurrentUserHaveFullControl.Length.ShouldBe(1);
            methodDoesCurrentUserHaveFullControlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoesCurrentUserHaveFullControl) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_DoesCurrentUserHaveFullControl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoesCurrentUserHaveFullControlPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDoesCurrentUserHaveFullControl, Fixture, methodDoesCurrentUserHaveFullControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoesCurrentUserHaveFullControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoesCurrentUserHaveFullControl) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_DoesCurrentUserHaveFullControl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoesCurrentUserHaveFullControl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoesCurrentUserHaveFullControl) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_DoesCurrentUserHaveFullControl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoesCurrentUserHaveFullControl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CurrentUserIsInRole) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_CurrentUserIsInRole_Static_Method_Call_Internally(Type[] types)
        {
            var methodCurrentUserIsInRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCurrentUserIsInRole, Fixture, methodCurrentUserIsInRolePrametersTypes);
        }

        #endregion

        #region Method Call : (CurrentUserIsInRole) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CurrentUserIsInRole_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var role = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.CurrentUserIsInRole(web, role);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CurrentUserIsInRole) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CurrentUserIsInRole_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var role = CreateType<string>();
            var methodCurrentUserIsInRolePrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfCurrentUserIsInRole = { web, role };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCurrentUserIsInRole, parametersOfCurrentUserIsInRole, methodCurrentUserIsInRolePrametersTypes);

            // Assert
            parametersOfCurrentUserIsInRole.ShouldNotBeNull();
            parametersOfCurrentUserIsInRole.Length.ShouldBe(2);
            methodCurrentUserIsInRolePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CurrentUserIsInRole) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CurrentUserIsInRole_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCurrentUserIsInRolePrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCurrentUserIsInRole, Fixture, methodCurrentUserIsInRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCurrentUserIsInRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CurrentUserIsInRole) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CurrentUserIsInRole_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCurrentUserIsInRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CurrentUserIsInRole) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CurrentUserIsInRole_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCurrentUserIsInRole, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserIsInRole) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_UserIsInRole_Static_Method_Call_Internally(Type[] types)
        {
            var methodUserIsInRolePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodUserIsInRole, Fixture, methodUserIsInRolePrametersTypes);
        }

        #endregion

        #region Method Call : (UserIsInRole) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_UserIsInRole_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var loginName = CreateType<string>();
            var role = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.UserIsInRole(web, loginName, role);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (UserIsInRole) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_UserIsInRole_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var loginName = CreateType<string>();
            var role = CreateType<string>();
            var methodUserIsInRolePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfUserIsInRole = { web, loginName, role };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodUserIsInRole, parametersOfUserIsInRole, methodUserIsInRolePrametersTypes);

            // Assert
            parametersOfUserIsInRole.ShouldNotBeNull();
            parametersOfUserIsInRole.Length.ShouldBe(3);
            methodUserIsInRolePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserIsInRole) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_UserIsInRole_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUserIsInRolePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodUserIsInRole, Fixture, methodUserIsInRolePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUserIsInRolePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserIsInRole) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_UserIsInRole_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUserIsInRole, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UserIsInRole) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_UserIsInRole_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUserIsInRole, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : IList<SPEventReceiverDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetListEvents_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetListEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetListEvents) (Return Type : IList<SPEventReceiverDefinition>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetListEvents_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<IList<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(IList<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListEvents, methodGetListEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetListEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : IList<SPEventReceiverDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetListEvents_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<IList<SPEventReceiverType>>();
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(IList<SPEventReceiverType>) };
            object[] parametersOfGetListEvents = { list, assemblyName, className, types };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<IList<SPEventReceiverDefinition>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetListEvents, parametersOfGetListEvents, methodGetListEventsPrametersTypes);

            // Assert
            parametersOfGetListEvents.ShouldNotBeNull();
            parametersOfGetListEvents.Length.ShouldBe(4);
            methodGetListEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (GetListEvents) (Return Type : IList<SPEventReceiverDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetListEvents_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListEventsPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string), typeof(IList<SPEventReceiverType>) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetListEvents, Fixture, methodGetListEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : IList<SPEventReceiverDefinition>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetListEvents_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetListEvents) (Return Type : IList<SPEventReceiverDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetListEvents_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListEvents, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWebEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetWebEvents, Fixture, methodGetWebEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetWebEvents(web, assemblyName, className, types);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetWebEventsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetWebEvents = { web, assemblyName, className, types };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebEvents, methodGetWebEventsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetWebEvents, Fixture, methodGetWebEventsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<SPEventReceiverDefinition>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetWebEvents, parametersOfGetWebEvents, methodGetWebEventsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetWebEvents.ShouldNotBeNull();
            parametersOfGetWebEvents.Length.ShouldBe(4);
            methodGetWebEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<List<SPEventReceiverDefinition>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetWebEvents, parametersOfGetWebEvents, methodGetWebEventsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetWebEventsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetWebEvents = { web, assemblyName, className, types };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetWebEvents, methodGetWebEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetWebEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetWebEvents.ShouldNotBeNull();
            parametersOfGetWebEvents.Length.ShouldBe(4);
            methodGetWebEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var assemblyName = CreateType<string>();
            var className = CreateType<string>();
            var types = CreateType<List<SPEventReceiverType>>();
            var methodGetWebEventsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            object[] parametersOfGetWebEvents = { web, assemblyName, className, types };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<SPEventReceiverDefinition>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetWebEvents, parametersOfGetWebEvents, methodGetWebEventsPrametersTypes);

            // Assert
            parametersOfGetWebEvents.ShouldNotBeNull();
            parametersOfGetWebEvents.Length.ShouldBe(4);
            methodGetWebEventsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetWebEventsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetWebEvents, Fixture, methodGetWebEventsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetWebEventsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebEventsPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(List<SPEventReceiverType>) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetWebEvents, Fixture, methodGetWebEventsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebEventsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebEvents, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetWebEvents) (Return Type : List<SPEventReceiverDefinition>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetWebEvents_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebEvents, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getRealField_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetRealFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getRealField_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getRealField(field);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getRealField_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetRealField, methodgetRealFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetRealField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getRealField_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfgetRealField = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPField>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetRealField, parametersOfgetRealField, methodgetRealFieldPrametersTypes);

            // Assert
            parametersOfgetRealField.ShouldNotBeNull();
            parametersOfgetRealField.Length.ShouldBe(1);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getRealField_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetRealFieldPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getRealField_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetRealFieldPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetRealField, Fixture, methodgetRealFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetRealFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getRealField_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getRealField) (Return Type : SPField) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getRealField_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetRealField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getSiteItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetSiteItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getSiteItems_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var view = CreateType<SPView>();
            var spQuery = CreateType<string>();
            var filterFieldName = CreateType<string>();
            var useWbs = CreateType<string>();
            var listTitlePattern = CreateType<string>();
            var groupByFieldNames = CreateType<IList<string>>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getSiteItems(web, view, spQuery, filterFieldName, useWbs, listTitlePattern, groupByFieldNames);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getSiteItems_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var view = CreateType<SPView>();
            var spQuery = CreateType<string>();
            var filterFieldName = CreateType<string>();
            var useWbs = CreateType<string>();
            var listTitlePattern = CreateType<string>();
            var groupByFieldNames = CreateType<IList<string>>();
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IList<string>) };
            object[] parametersOfgetSiteItems = { web, view, spQuery, filterFieldName, useWbs, listTitlePattern, groupByFieldNames };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSiteItems, methodgetSiteItemsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetSiteItems, parametersOfgetSiteItems, methodgetSiteItemsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetSiteItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetSiteItems.ShouldNotBeNull();
            parametersOfgetSiteItems.Length.ShouldBe(7);
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getSiteItems_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var view = CreateType<SPView>();
            var spQuery = CreateType<string>();
            var filterFieldName = CreateType<string>();
            var useWbs = CreateType<string>();
            var listTitlePattern = CreateType<string>();
            var groupByFieldNames = CreateType<IList<string>>();
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IList<string>) };
            object[] parametersOfgetSiteItems = { web, view, spQuery, filterFieldName, useWbs, listTitlePattern, groupByFieldNames };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetSiteItems, parametersOfgetSiteItems, methodgetSiteItemsPrametersTypes);

            // Assert
            parametersOfgetSiteItems.ShouldNotBeNull();
            parametersOfgetSiteItems.Length.ShouldBe(7);
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getSiteItems_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IList<string>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getSiteItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetSiteItemsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(string), typeof(IList<string>) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetSiteItems, Fixture, methodgetSiteItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetSiteItemsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getSiteItems_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetSiteItems, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getSiteItems) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getSiteItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetSiteItems, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteItemsData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetSiteItemsData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSiteItemsDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsData, Fixture, methodGetSiteItemsDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSiteItemsData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteItemsData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var spQuery = CreateType<string>();
            var listTitlePattern = CreateType<string>();
            var dataTable = CreateType<DataTable>();
            var fieldsXml = CreateType<IList<string>>();
            var listIds = CreateType<IList<Guid>>();
            var methodGetSiteItemsDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(DataTable), typeof(IList<string>), typeof(IList<Guid>) };
            object[] parametersOfGetSiteItemsData = { web, spQuery, listTitlePattern, dataTable, fieldsXml, listIds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsData, parametersOfGetSiteItemsData, methodGetSiteItemsDataPrametersTypes);

            // Assert
            parametersOfGetSiteItemsData.ShouldNotBeNull();
            parametersOfGetSiteItemsData.Length.ShouldBe(6);
            methodGetSiteItemsDataPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteItemsData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteItemsData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSiteItemsDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(DataTable), typeof(IList<string>), typeof(IList<Guid>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsData, Fixture, methodGetSiteItemsDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSiteItemsDataPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (GetSiteItemsData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteItemsData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSiteItemsDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(DataTable), typeof(IList<string>), typeof(IList<Guid>) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsData, Fixture, methodGetSiteItemsDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSiteItemsDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteItemsListIds) (Return Type : IList<Guid>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetSiteItemsListIds_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSiteItemsListIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsListIds, Fixture, methodGetSiteItemsListIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSiteItemsListIds) (Return Type : IList<Guid>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteItemsListIds_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var view = CreateType<SPView>();
            var listTitlePattern = CreateType<string>();
            var sqlConnection = CreateType<SqlConnection>();
            var siteUrl = CreateType<string>();
            var methodGetSiteItemsListIdsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetSiteItemsListIds = { web, view, listTitlePattern, sqlConnection, siteUrl };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<IList<Guid>>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsListIds, parametersOfGetSiteItemsListIds, methodGetSiteItemsListIdsPrametersTypes);

            // Assert
            parametersOfGetSiteItemsListIds.ShouldNotBeNull();
            parametersOfGetSiteItemsListIds.Length.ShouldBe(5);
            methodGetSiteItemsListIdsPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteItemsListIds) (Return Type : IList<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteItemsListIds_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSiteItemsListIdsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsListIds, Fixture, methodGetSiteItemsListIdsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSiteItemsListIdsPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetSiteItemsListIds) (Return Type : IList<Guid>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteItemsListIds_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSiteItemsListIdsPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPView), typeof(string), typeof(SqlConnection), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteItemsListIds, Fixture, methodGetSiteItemsListIdsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSiteItemsListIdsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GenerateSiteItemFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GenerateSiteItemFields_Static_Method_Call_Internally(Type[] types)
        {
            var methodGenerateSiteItemFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGenerateSiteItemFields, Fixture, methodGenerateSiteItemFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateSiteItemFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GenerateSiteItemFields_Static_Method_Call_Void_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var view = CreateType<SPView>();
            var spQuery = CreateType<string>();
            var filterFieldName = CreateType<string>();
            var useWbs = CreateType<string>();
            var groupByFieldNames = CreateType<IList<string>>();
            var fieldInternalNames = CreateType<ArrayList>();
            var fieldsXml = CreateType<IList<string>>();
            var methodGenerateSiteItemFieldsPrametersTypes = new Type[] { typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(IList<string>), typeof(ArrayList), typeof(IList<string>) };
            object[] parametersOfGenerateSiteItemFields = { view, spQuery, filterFieldName, useWbs, groupByFieldNames, fieldInternalNames, fieldsXml };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGenerateSiteItemFields, parametersOfGenerateSiteItemFields, methodGenerateSiteItemFieldsPrametersTypes);

            // Assert
            parametersOfGenerateSiteItemFields.ShouldNotBeNull();
            parametersOfGenerateSiteItemFields.Length.ShouldBe(7);
            methodGenerateSiteItemFieldsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateSiteItemFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GenerateSiteItemFields_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGenerateSiteItemFieldsPrametersTypes = new Type[] { typeof(SPView), typeof(string), typeof(string), typeof(string), typeof(IList<string>), typeof(ArrayList), typeof(IList<string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGenerateSiteItemFields, Fixture, methodGenerateSiteItemFieldsPrametersTypes);

            // Assert
            methodGenerateSiteItemFieldsPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateFieldRefXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GenerateFieldRefXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodGenerateFieldRefXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGenerateFieldRefXml, Fixture, methodGenerateFieldRefXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateFieldRefXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GenerateFieldRefXml_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var isNullable = CreateType<bool>();
            var methodGenerateFieldRefXmlPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGenerateFieldRefXml = { name, isNullable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGenerateFieldRefXml, parametersOfGenerateFieldRefXml, methodGenerateFieldRefXmlPrametersTypes);

            // Assert
            parametersOfGenerateFieldRefXml.ShouldNotBeNull();
            parametersOfGenerateFieldRefXml.Length.ShouldBe(2);
            methodGenerateFieldRefXmlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateFieldRefXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GenerateFieldRefXml_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGenerateFieldRefXmlPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGenerateFieldRefXml, Fixture, methodGenerateFieldRefXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGenerateFieldRefXmlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GenerateFieldRefXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GenerateFieldRefXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGenerateFieldRefXmlPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGenerateFieldRefXml, Fixture, methodGenerateFieldRefXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGenerateFieldRefXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFieldsXmlIfNotInternal) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_AddFieldsXmlIfNotInternal_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldsXmlIfNotInternalPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddFieldsXmlIfNotInternal, Fixture, methodAddFieldsXmlIfNotInternalPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFieldsXmlIfNotInternal) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddFieldsXmlIfNotInternal_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fieldsXml = CreateType<IList<string>>();
            var internalFieldNames = CreateType<ArrayList>();
            var name = CreateType<string>();
            var isNullable = CreateType<bool>();
            var methodAddFieldsXmlIfNotInternalPrametersTypes = new Type[] { typeof(IList<string>), typeof(ArrayList), typeof(string), typeof(bool) };
            object[] parametersOfAddFieldsXmlIfNotInternal = { fieldsXml, internalFieldNames, name, isNullable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddFieldsXmlIfNotInternal, parametersOfAddFieldsXmlIfNotInternal, methodAddFieldsXmlIfNotInternalPrametersTypes);

            // Assert
            parametersOfAddFieldsXmlIfNotInternal.ShouldNotBeNull();
            parametersOfAddFieldsXmlIfNotInternal.Length.ShouldBe(4);
            methodAddFieldsXmlIfNotInternalPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldsXmlIfNotInternal) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddFieldsXmlIfNotInternal_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldsXmlIfNotInternalPrametersTypes = new Type[] { typeof(IList<string>), typeof(ArrayList), typeof(string), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddFieldsXmlIfNotInternal, Fixture, methodAddFieldsXmlIfNotInternalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddFieldsXmlIfNotInternalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getItemXml_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetItemXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getItemXml_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var hshFields = CreateType<Hashtable>();
            var properties = CreateType<SPItemEventDataCollection>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getItemXml(li, hshFields, properties, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getItemXml_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var hshFields = CreateType<Hashtable>();
            var properties = CreateType<SPItemEventDataCollection>();
            var web = CreateType<SPWeb>();
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb) };
            object[] parametersOfgetItemXml = { li, hshFields, properties, web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetItemXml, methodgetItemXmlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetItemXml, parametersOfgetItemXml, methodgetItemXmlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetItemXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetItemXml.ShouldNotBeNull();
            parametersOfgetItemXml.Length.ShouldBe(4);
            methodgetItemXmlPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getItemXml_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var hshFields = CreateType<Hashtable>();
            var properties = CreateType<SPItemEventDataCollection>();
            var web = CreateType<SPWeb>();
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb) };
            object[] parametersOfgetItemXml = { li, hshFields, properties, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetItemXml, parametersOfgetItemXml, methodgetItemXmlPrametersTypes);

            // Assert
            parametersOfgetItemXml.ShouldNotBeNull();
            parametersOfgetItemXml.Length.ShouldBe(4);
            methodgetItemXmlPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getItemXml_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetItemXmlPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getItemXml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetItemXmlPrametersTypes = new Type[] { typeof(SPListItem), typeof(Hashtable), typeof(SPItemEventDataCollection), typeof(SPWeb) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetItemXml, Fixture, methodgetItemXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetItemXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getItemXml_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetItemXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getItemXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getItemXml_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetItemXml, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getMenuFromAssembly_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetMenuFromAssemblyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMenuFromAssembly_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var assembly = CreateType<string>();
            var aclass = CreateType<string>();
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetMenuFromAssembly = { assembly, aclass };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMenuFromAssembly, methodgetMenuFromAssemblyPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMenuFromAssembly, parametersOfgetMenuFromAssembly, methodgetMenuFromAssemblyPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetMenuFromAssembly);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetMenuFromAssembly.ShouldNotBeNull();
            parametersOfgetMenuFromAssembly.Length.ShouldBe(2);
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMenuFromAssembly_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var assembly = CreateType<string>();
            var aclass = CreateType<string>();
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfgetMenuFromAssembly = { assembly, aclass };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMenuFromAssembly, parametersOfgetMenuFromAssembly, methodgetMenuFromAssemblyPrametersTypes);

            // Assert
            parametersOfgetMenuFromAssembly.ShouldNotBeNull();
            parametersOfgetMenuFromAssembly.Length.ShouldBe(2);
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMenuFromAssembly_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMenuFromAssembly_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetMenuFromAssemblyPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetMenuFromAssembly, Fixture, methodgetMenuFromAssemblyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetMenuFromAssemblyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMenuFromAssembly_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetMenuFromAssembly, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getMenuFromAssembly) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getMenuFromAssembly_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetMenuFromAssembly, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getFarmSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFarmSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFarmSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getFarmSetting(setting);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFarmSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetFarmSetting = { setting };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFarmSetting, methodgetFarmSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFarmSetting, parametersOfgetFarmSetting, methodgetFarmSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetFarmSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetFarmSetting.ShouldNotBeNull();
            parametersOfgetFarmSetting.Length.ShouldBe(1);
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFarmSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetFarmSetting = { setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFarmSetting, parametersOfgetFarmSetting, methodgetFarmSettingPrametersTypes);

            // Assert
            parametersOfgetFarmSetting.ShouldNotBeNull();
            parametersOfgetFarmSetting.Length.ShouldBe(1);
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFarmSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFarmSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFarmSettingPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFarmSetting, Fixture, methodgetFarmSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFarmSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFarmSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFarmSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getFarmSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFarmSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFarmSetting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetFarmSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.setFarmSetting(setting, value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfsetFarmSetting = { setting, value };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, methodsetFarmSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetFarmSetting, parametersOfsetFarmSetting, methodsetFarmSettingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfsetFarmSetting.ShouldNotBeNull();
            parametersOfsetFarmSetting.Length.ShouldBe(2);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetFarmSetting, parametersOfsetFarmSetting, methodsetFarmSettingPrametersTypes));
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfsetFarmSetting = { setting, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, methodsetFarmSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfsetFarmSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetFarmSetting.ShouldNotBeNull();
            parametersOfsetFarmSetting.Length.ShouldBe(2);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfsetFarmSetting = { setting, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetFarmSetting, parametersOfsetFarmSetting, methodsetFarmSettingPrametersTypes);

            // Assert
            parametersOfsetFarmSetting.ShouldNotBeNull();
            parametersOfsetFarmSetting.Length.ShouldBe(2);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetFarmSettingPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetFarmSetting, Fixture, methodsetFarmSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodsetFarmSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (setFarmSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setFarmSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetFarmSetting, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getWebAppSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetWebAppSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getWebAppSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getWebAppSetting(gWebApp, setting);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getWebAppSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfgetWebAppSetting = { gWebApp, setting };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetWebAppSetting, methodgetWebAppSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetWebAppSetting, parametersOfgetWebAppSetting, methodgetWebAppSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetWebAppSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetWebAppSetting.ShouldNotBeNull();
            parametersOfgetWebAppSetting.Length.ShouldBe(2);
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getWebAppSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfgetWebAppSetting = { gWebApp, setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetWebAppSetting, parametersOfgetWebAppSetting, methodgetWebAppSettingPrametersTypes);

            // Assert
            parametersOfgetWebAppSetting.ShouldNotBeNull();
            parametersOfgetWebAppSetting.Length.ShouldBe(2);
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getWebAppSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getWebAppSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetWebAppSetting, Fixture, methodgetWebAppSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetWebAppSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getWebAppSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetWebAppSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getWebAppSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getWebAppSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetWebAppSetting, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_setWebAppSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetWebAppSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetWebAppSetting, Fixture, methodsetWebAppSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setWebAppSetting_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.setWebAppSetting(gWebApp, setting, value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setWebAppSetting_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetWebAppSetting = { gWebApp, setting, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetWebAppSetting, methodsetWebAppSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfsetWebAppSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetWebAppSetting.ShouldNotBeNull();
            parametersOfsetWebAppSetting.Length.ShouldBe(3);
            methodsetWebAppSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setWebAppSetting_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetWebAppSetting = { gWebApp, setting, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetWebAppSetting, parametersOfsetWebAppSetting, methodsetWebAppSettingPrametersTypes);

            // Assert
            parametersOfsetWebAppSetting.ShouldNotBeNull();
            parametersOfsetWebAppSetting.Length.ShouldBe(3);
            methodsetWebAppSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setWebAppSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetWebAppSetting, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setWebAppSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetWebAppSettingPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetWebAppSetting, Fixture, methodsetWebAppSettingPrametersTypes);

            // Assert
            methodsetWebAppSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setWebAppSetting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setWebAppSetting_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetWebAppSetting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConnectionString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getConnectionString(gWebApp);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConnectionString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfgetConnectionString = { gWebApp };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConnectionString, methodgetConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConnectionString, parametersOfgetConnectionString, methodgetConnectionStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetConnectionString.ShouldNotBeNull();
            parametersOfgetConnectionString.Length.ShouldBe(1);
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfgetConnectionString = { gWebApp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConnectionString, parametersOfgetConnectionString, methodgetConnectionStringPrametersTypes);

            // Assert
            parametersOfgetConnectionString.ShouldNotBeNull();
            parametersOfgetConnectionString.Length.ShouldBe(1);
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConnectionString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetConnectionStringPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConnectionString, Fixture, methodgetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetConnectionString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getReportingConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetReportingConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetReportingConnectionString, Fixture, methodgetReportingConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getReportingConnectionString_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getReportingConnectionString(gWebApp, siteId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getReportingConnectionString_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var methodgetReportingConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            object[] parametersOfgetReportingConnectionString = { gWebApp, siteId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetReportingConnectionString, methodgetReportingConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetReportingConnectionString, Fixture, methodgetReportingConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetReportingConnectionString, parametersOfgetReportingConnectionString, methodgetReportingConnectionStringPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetReportingConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetReportingConnectionString.ShouldNotBeNull();
            parametersOfgetReportingConnectionString.Length.ShouldBe(2);
            methodgetReportingConnectionStringPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getReportingConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var siteId = CreateType<Guid>();
            var methodgetReportingConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            object[] parametersOfgetReportingConnectionString = { gWebApp, siteId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetReportingConnectionString, parametersOfgetReportingConnectionString, methodgetReportingConnectionStringPrametersTypes);

            // Assert
            parametersOfgetReportingConnectionString.ShouldNotBeNull();
            parametersOfgetReportingConnectionString.Length.ShouldBe(2);
            methodgetReportingConnectionStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getReportingConnectionString_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetReportingConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetReportingConnectionString, Fixture, methodgetReportingConnectionStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetReportingConnectionStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getReportingConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetReportingConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetReportingConnectionString, Fixture, methodgetReportingConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetReportingConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getReportingConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetReportingConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getReportingConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getReportingConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetReportingConnectionString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetTable_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetTable, Fixture, methodGetTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetTable_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var cmd = CreateType<SqlCommand>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };
            object[] parametersOfGetTable = { cmd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTable, methodGetTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(1);
            methodGetTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetTable_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cmd = CreateType<SqlCommand>();
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };
            object[] parametersOfGetTable = { cmd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetTable, parametersOfGetTable, methodGetTablePrametersTypes);

            // Assert
            parametersOfGetTable.ShouldNotBeNull();
            parametersOfGetTable.Length.ShouldBe(1);
            methodGetTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetTable_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetTable_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTablePrametersTypes = new Type[] { typeof(SqlCommand) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetTable, Fixture, methodGetTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetTable_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTable) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetTable_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_Decrypt_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.Decrypt(base64Text);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecrypt = { base64Text };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecrypt, methodDecryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfDecrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(1);
            methodDecryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecrypt = { base64Text };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes);

            // Assert
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(1);
            methodDecryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecryptPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_setConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetConnectionString, Fixture, methodsetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConnectionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var cn = CreateType<string>();
            var sError = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.setConnectionString(gWebApp, cn, out sError);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConnectionString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var cn = CreateType<string>();
            var sError = CreateType<string>();
            var methodsetConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetConnectionString = { gWebApp, cn, sError };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetConnectionString, methodsetConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfsetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetConnectionString.ShouldNotBeNull();
            parametersOfsetConnectionString.Length.ShouldBe(3);
            methodsetConnectionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var gWebApp = CreateType<Guid>();
            var cn = CreateType<string>();
            var sError = CreateType<string>();
            var methodsetConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfsetConnectionString = { gWebApp, cn, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetConnectionString, parametersOfsetConnectionString, methodsetConnectionStringPrametersTypes);

            // Assert
            parametersOfsetConnectionString.ShouldNotBeNull();
            parametersOfsetConnectionString.Length.ShouldBe(3);
            methodsetConnectionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetConnectionStringPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetConnectionString, Fixture, methodsetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodsetConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (setConnectionString) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetConnectionString, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setListSetting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_setListSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetListSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetListSetting, Fixture, methodsetListSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (setListSetting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setListSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var val = CreateType<string>();
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.setListSetting(setting, val, list);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (setListSetting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setListSetting_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var val = CreateType<string>();
            var list = CreateType<SPList>();
            var methodsetListSettingPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPList) };
            object[] parametersOfsetListSetting = { setting, val, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetListSetting, methodsetListSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfsetListSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetListSetting.ShouldNotBeNull();
            parametersOfsetListSetting.Length.ShouldBe(3);
            methodsetListSettingPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setListSetting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setListSetting_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var val = CreateType<string>();
            var list = CreateType<SPList>();
            var methodsetListSettingPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPList) };
            object[] parametersOfsetListSetting = { setting, val, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetListSetting, parametersOfsetListSetting, methodsetListSettingPrametersTypes);

            // Assert
            parametersOfsetListSetting.ShouldNotBeNull();
            parametersOfsetListSetting.Length.ShouldBe(3);
            methodsetListSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setListSetting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setListSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetListSetting, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setListSetting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setListSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetListSettingPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetListSetting, Fixture, methodsetListSettingPrametersTypes);

            // Assert
            methodsetListSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setListSetting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setListSetting_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetListSetting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getListSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetListSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var list = CreateType<SPList>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getListSetting(setting, list);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var list = CreateType<SPList>();
            var methodgetListSettingPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            object[] parametersOfgetListSetting = { setting, list };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetListSetting, methodgetListSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetListSetting, parametersOfgetListSetting, methodgetListSettingPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetListSetting.ShouldNotBeNull();
            parametersOfgetListSetting.Length.ShouldBe(2);
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetListSetting, parametersOfgetListSetting, methodgetListSettingPrametersTypes));
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var list = CreateType<SPList>();
            var methodgetListSettingPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            object[] parametersOfgetListSetting = { setting, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetListSetting, methodgetListSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetListSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetListSetting.ShouldNotBeNull();
            parametersOfgetListSetting.Length.ShouldBe(2);
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var setting = CreateType<string>();
            var list = CreateType<SPList>();
            var methodgetListSettingPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            object[] parametersOfgetListSetting = { setting, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetListSetting, parametersOfgetListSetting, methodgetListSettingPrametersTypes);

            // Assert
            parametersOfgetListSetting.ShouldNotBeNull();
            parametersOfgetListSetting.Length.ShouldBe(2);
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetListSettingPrametersTypes = new Type[] { typeof(string), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetListSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetListSettingPrametersTypes = new Type[] { typeof(string), typeof(SPList) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetListSetting, Fixture, methodgetListSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetListSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetListSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getListSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getListSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetListSetting, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_createSite_Static_Method_Call_Internally(Type[] types)
        {
            var methodcreateSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var mySite = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.createSite(title, url, template, user, unique, toplink, mySite);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var mySite = CreateType<SPWeb>();
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb) };
            object[] parametersOfcreateSite = { title, url, template, user, unique, toplink, mySite };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateSite, methodcreateSitePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, parametersOfcreateSite, methodcreateSitePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfcreateSite.ShouldNotBeNull();
            parametersOfcreateSite.Length.ShouldBe(7);
            methodcreateSitePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, parametersOfcreateSite, methodcreateSitePrametersTypes));
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var mySite = CreateType<SPWeb>();
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb) };
            object[] parametersOfcreateSite = { title, url, template, user, unique, toplink, mySite };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcreateSite, methodcreateSitePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfcreateSite);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcreateSite.ShouldNotBeNull();
            parametersOfcreateSite.Length.ShouldBe(7);
            methodcreateSitePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var mySite = CreateType<SPWeb>();
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb) };
            object[] parametersOfcreateSite = { title, url, template, user, unique, toplink, mySite };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, parametersOfcreateSite, methodcreateSitePrametersTypes);

            // Assert
            parametersOfcreateSite.ShouldNotBeNull();
            parametersOfcreateSite.Length.ShouldBe(7);
            methodcreateSitePrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodcreateSitePrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcreateSitePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateSite, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateSite, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_createSite_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodcreateSitePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var description = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var parentWeb = CreateType<SPWeb>();
            var createdWebId = CreateType<Guid>();
            var createdWebUrl = CreateType<string>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.createSite(title, description, url, template, user, unique, toplink, parentWeb, out createdWebId, out createdWebUrl, out createdWebServerRelativeUrl, out createdWebTitle);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var description = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var parentWeb = CreateType<SPWeb>();
            var createdWebId = CreateType<Guid>();
            var createdWebUrl = CreateType<string>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb), typeof(Guid), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfcreateSite = { title, description, url, template, user, unique, toplink, parentWeb, createdWebId, createdWebUrl, createdWebServerRelativeUrl, createdWebTitle };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, parametersOfcreateSite, methodcreateSitePrametersTypes);

            // Assert
            parametersOfcreateSite.ShouldNotBeNull();
            parametersOfcreateSite.Length.ShouldBe(12);
            methodcreateSitePrametersTypes.Length.ShouldBe(12);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb), typeof(Guid), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcreateSitePrametersTypes.Length.ShouldBe(12);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcreateSitePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb), typeof(Guid), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 12;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcreateSite, Fixture, methodcreateSitePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcreateSitePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcreateSite, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (createSite) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_createSite_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcreateSite, 1);
            const int parametersCount = 12;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodWebExistsUnderParentWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, Fixture, methodWebExistsUnderParentWebPrametersTypes);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var parentWeb = CreateType<SPWeb>();
            var webName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.WebExistsUnderParentWeb(parentWeb, webName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var parentWeb = CreateType<SPWeb>();
            var webName = CreateType<string>();
            var methodWebExistsUnderParentWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfWebExistsUnderParentWeb = { parentWeb, webName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebExistsUnderParentWeb, methodWebExistsUnderParentWebPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, Fixture, methodWebExistsUnderParentWebPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, parametersOfWebExistsUnderParentWeb, methodWebExistsUnderParentWebPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfWebExistsUnderParentWeb.ShouldNotBeNull();
            parametersOfWebExistsUnderParentWeb.Length.ShouldBe(2);
            methodWebExistsUnderParentWebPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, parametersOfWebExistsUnderParentWeb, methodWebExistsUnderParentWebPrametersTypes));
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var parentWeb = CreateType<SPWeb>();
            var webName = CreateType<string>();
            var methodWebExistsUnderParentWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfWebExistsUnderParentWeb = { parentWeb, webName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebExistsUnderParentWeb, methodWebExistsUnderParentWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfWebExistsUnderParentWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebExistsUnderParentWeb.ShouldNotBeNull();
            parametersOfWebExistsUnderParentWeb.Length.ShouldBe(2);
            methodWebExistsUnderParentWebPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var parentWeb = CreateType<SPWeb>();
            var webName = CreateType<string>();
            var methodWebExistsUnderParentWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfWebExistsUnderParentWeb = { parentWeb, webName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, parametersOfWebExistsUnderParentWeb, methodWebExistsUnderParentWebPrametersTypes);

            // Assert
            parametersOfWebExistsUnderParentWeb.ShouldNotBeNull();
            parametersOfWebExistsUnderParentWeb.Length.ShouldBe(2);
            methodWebExistsUnderParentWebPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodWebExistsUnderParentWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, Fixture, methodWebExistsUnderParentWebPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodWebExistsUnderParentWebPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodWebExistsUnderParentWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, Fixture, methodWebExistsUnderParentWebPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodWebExistsUnderParentWebPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebExistsUnderParentWebPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodWebExistsUnderParentWeb, Fixture, methodWebExistsUnderParentWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodWebExistsUnderParentWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebExistsUnderParentWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (WebExistsUnderParentWeb) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_WebExistsUnderParentWeb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWebExistsUnderParentWeb, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateSiteFromItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateSiteFromItem, Fixture, methodCreateSiteFromItemPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var description = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var parentWeb = CreateType<SPWeb>();
            var itemWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var createdSiteId = CreateType<Guid>();
            var createdWebUrl = CreateType<string>();
            var createdWebRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.CreateSiteFromItem(title, description, url, template, user, unique, toplink, parentWeb, itemWeb, listId, itemId, out createdSiteId, out createdWebUrl, out createdWebRelativeUrl, out createdWebTitle);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var description = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var parentWeb = CreateType<SPWeb>();
            var itemWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var createdSiteId = CreateType<Guid>();
            var createdWebUrl = CreateType<string>();
            var createdWebRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var methodCreateSiteFromItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPWeb), typeof(Guid), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCreateSiteFromItem = { title, description, url, template, user, unique, toplink, parentWeb, itemWeb, listId, itemId, createdSiteId, createdWebUrl, createdWebRelativeUrl, createdWebTitle };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateSiteFromItem, methodCreateSiteFromItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfCreateSiteFromItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateSiteFromItem.ShouldNotBeNull();
            parametersOfCreateSiteFromItem.Length.ShouldBe(15);
            methodCreateSiteFromItemPrametersTypes.Length.ShouldBe(15);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var title = CreateType<string>();
            var description = CreateType<string>();
            var url = CreateType<string>();
            var template = CreateType<string>();
            var user = CreateType<string>();
            var unique = CreateType<bool>();
            var toplink = CreateType<bool>();
            var parentWeb = CreateType<SPWeb>();
            var itemWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var createdSiteId = CreateType<Guid>();
            var createdWebUrl = CreateType<string>();
            var createdWebRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var methodCreateSiteFromItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPWeb), typeof(Guid), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCreateSiteFromItem = { title, description, url, template, user, unique, toplink, parentWeb, itemWeb, listId, itemId, createdSiteId, createdWebUrl, createdWebRelativeUrl, createdWebTitle };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateSiteFromItem, parametersOfCreateSiteFromItem, methodCreateSiteFromItemPrametersTypes);

            // Assert
            parametersOfCreateSiteFromItem.ShouldNotBeNull();
            parametersOfCreateSiteFromItem.Length.ShouldBe(15);
            methodCreateSiteFromItemPrametersTypes.Length.ShouldBe(15);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateSiteFromItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPWeb), typeof(Guid), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateSiteFromItem, Fixture, methodCreateSiteFromItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateSiteFromItemPrametersTypes.Length.ShouldBe(15);
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateSiteFromItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(bool), typeof(SPWeb), typeof(SPWeb), typeof(Guid), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 15;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateSiteFromItem, Fixture, methodCreateSiteFromItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateSiteFromItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateSiteFromItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CreateSiteFromItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateSiteFromItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateSiteFromItem, 0);
            const int parametersCount = 15;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_AddGroup_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddGroup, Fixture, methodAddGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddGroup_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var safeSiteTitle = CreateType<string>();
            var roleName = CreateType<string>();
            var owner = CreateType<SPMember>();
            var defaultUser = CreateType<SPUser>();
            var groupDescription = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.AddGroup(web, safeSiteTitle, roleName, owner, defaultUser, groupDescription);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddGroup_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var safeSiteTitle = CreateType<string>();
            var roleName = CreateType<string>();
            var owner = CreateType<SPMember>();
            var defaultUser = CreateType<SPUser>();
            var groupDescription = CreateType<string>();
            var methodAddGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPMember), typeof(SPUser), typeof(string) };
            object[] parametersOfAddGroup = { web, safeSiteTitle, roleName, owner, defaultUser, groupDescription };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddGroup, methodAddGroupPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddGroup, Fixture, methodAddGroupPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddGroup, parametersOfAddGroup, methodAddGroupPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfAddGroup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddGroup.ShouldNotBeNull();
            parametersOfAddGroup.Length.ShouldBe(6);
            methodAddGroupPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddGroup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var safeSiteTitle = CreateType<string>();
            var roleName = CreateType<string>();
            var owner = CreateType<SPMember>();
            var defaultUser = CreateType<SPUser>();
            var groupDescription = CreateType<string>();
            var methodAddGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPMember), typeof(SPUser), typeof(string) };
            object[] parametersOfAddGroup = { web, safeSiteTitle, roleName, owner, defaultUser, groupDescription };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddGroup, parametersOfAddGroup, methodAddGroupPrametersTypes);

            // Assert
            parametersOfAddGroup.ShouldNotBeNull();
            parametersOfAddGroup.Length.ShouldBe(6);
            methodAddGroupPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddGroup_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPMember), typeof(SPUser), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddGroup, Fixture, methodAddGroupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddGroupPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddGroup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(SPMember), typeof(SPUser), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodAddGroup, Fixture, methodAddGroupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddGroupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddGroup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddGroup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddGroup) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_AddGroup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddGroup, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetSiteGroup_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSiteGroupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteGroup_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetSiteGroup(web, name);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteGroup_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var name = CreateType<string>();
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetSiteGroup = { web, name };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, methodGetSiteGroupPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPGroup>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteGroup, parametersOfGetSiteGroup, methodGetSiteGroupPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetSiteGroup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSiteGroup.ShouldNotBeNull();
            parametersOfGetSiteGroup.Length.ShouldBe(2);
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteGroup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var name = CreateType<string>();
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfGetSiteGroup = { web, name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPGroup>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteGroup, parametersOfGetSiteGroup, methodGetSiteGroupPrametersTypes);

            // Assert
            parametersOfGetSiteGroup.ShouldNotBeNull();
            parametersOfGetSiteGroup.Length.ShouldBe(2);
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSiteGroupPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetSiteGroup, Fixture, methodGetSiteGroupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSiteGroupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteGroup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSiteGroup) (Return Type : SPGroup) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetSiteGroup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSiteGroup, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_setConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodsetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetConfigSetting, Fixture, methodsetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConfigSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.setConfigSetting(web, setting, value);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConfigSetting_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfsetConfigSetting = { web, setting, value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodsetConfigSetting, methodsetConfigSettingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfsetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfsetConfigSetting.ShouldNotBeNull();
            parametersOfsetConfigSetting.Length.ShouldBe(3);
            methodsetConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConfigSetting_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var value = CreateType<string>();
            var methodsetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfsetConfigSetting = { web, setting, value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetConfigSetting, parametersOfsetConfigSetting, methodsetConfigSettingPrametersTypes);

            // Assert
            parametersOfsetConfigSetting.ShouldNotBeNull();
            parametersOfsetConfigSetting.Length.ShouldBe(3);
            methodsetConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodsetConfigSetting, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodsetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodsetConfigSetting, Fixture, methodsetConfigSettingPrametersTypes);

            // Assert
            methodsetConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (setConfigSetting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_setConfigSetting_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodsetConfigSetting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_iGetLockedWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetLockedWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetLockedWeb, Fixture, methodiGetLockedWebPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetLockedWeb_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetLockedWeb = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodiGetLockedWeb, methodiGetLockedWebPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfiGetLockedWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfiGetLockedWeb.ShouldNotBeNull();
            parametersOfiGetLockedWeb.Length.ShouldBe(1);
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetLockedWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfiGetLockedWeb = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetLockedWeb, parametersOfiGetLockedWeb, methodiGetLockedWebPrametersTypes);

            // Assert
            parametersOfiGetLockedWeb.ShouldNotBeNull();
            parametersOfiGetLockedWeb.Length.ShouldBe(1);
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetLockedWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetLockedWeb, Fixture, methodiGetLockedWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetLockedWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetLockedWeb, Fixture, methodiGetLockedWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetLockedWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetLockedWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetLockedWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (iGetLockedWeb) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetLockedWeb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetLockedWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getLockedWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetLockedWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockedWeb, Fixture, methodgetLockedWebPrametersTypes);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockedWeb_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getLockedWeb(web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockedWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodgetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfgetLockedWeb = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockedWeb, parametersOfgetLockedWeb, methodgetLockedWebPrametersTypes);

            // Assert
            parametersOfgetLockedWeb.ShouldNotBeNull();
            parametersOfgetLockedWeb.Length.ShouldBe(1);
            methodgetLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockedWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockedWeb, Fixture, methodgetLockedWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLockedWebPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockedWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockedWeb, Fixture, methodgetLockedWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLockedWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockedWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLockedWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getLockedWeb) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockedWeb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetLockedWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getConfigSetting(web, setting, translateUrl, isRelative);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfgetConfigSetting = { web, setting, translateUrl, isRelative };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, methodgetConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(4);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfgetConfigSetting = { web, setting, translateUrl, isRelative };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);

            // Assert
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(4);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getConfigSetting_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodgetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getConfigSetting(web, setting);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetConfigSetting = { web, setting };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, methodgetConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(2);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            object[] parametersOfgetConfigSetting = { web, setting };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, parametersOfgetConfigSetting, methodgetConfigSettingPrametersTypes);

            // Assert
            parametersOfgetConfigSetting.ShouldNotBeNull();
            parametersOfgetConfigSetting.Length.ShouldBe(2);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetConfigSetting, Fixture, methodgetConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getConfigSetting_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetConfigSetting, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getLockConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetLockConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockConfigSetting_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var isRelative = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getLockConfigSetting(web, setting, isRelative);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockConfigSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var isRelative = CreateType<bool>();
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };
            object[] parametersOfgetLockConfigSetting = { web, setting, isRelative };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLockConfigSetting, methodgetLockConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockConfigSetting, parametersOfgetLockConfigSetting, methodgetLockConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetLockConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetLockConfigSetting.ShouldNotBeNull();
            parametersOfgetLockConfigSetting.Length.ShouldBe(3);
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockConfigSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var isRelative = CreateType<bool>();
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };
            object[] parametersOfgetLockConfigSetting = { web, setting, isRelative };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockConfigSetting, parametersOfgetLockConfigSetting, methodgetLockConfigSettingPrametersTypes);

            // Assert
            parametersOfgetLockConfigSetting.ShouldNotBeNull();
            parametersOfgetLockConfigSetting.Length.ShouldBe(3);
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockConfigSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetLockConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLockConfigSetting, Fixture, methodgetLockConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLockConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockConfigSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLockConfigSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getLockConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLockConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetLockConfigSetting, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_iGetConfigSetting_Static_Method_Call_Internally(Type[] types)
        {
            var methodiGetConfigSettingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetConfigSetting_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfiGetConfigSetting = { web, setting, translateUrl, isRelative };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetConfigSetting, methodiGetConfigSettingPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetConfigSetting, parametersOfiGetConfigSetting, methodiGetConfigSettingPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfiGetConfigSetting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfiGetConfigSetting.ShouldNotBeNull();
            parametersOfiGetConfigSetting.Length.ShouldBe(4);
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetConfigSetting_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var setting = CreateType<string>();
            var translateUrl = CreateType<bool>();
            var isRelative = CreateType<bool>();
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            object[] parametersOfiGetConfigSetting = { web, setting, translateUrl, isRelative };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetConfigSetting, parametersOfiGetConfigSetting, methodiGetConfigSettingPrametersTypes);

            // Assert
            parametersOfiGetConfigSetting.ShouldNotBeNull();
            parametersOfiGetConfigSetting.Length.ShouldBe(4);
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetConfigSetting_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetConfigSetting_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiGetConfigSettingPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(bool) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodiGetConfigSetting, Fixture, methodiGetConfigSettingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiGetConfigSettingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetConfigSetting_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiGetConfigSetting, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iGetConfigSetting) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_iGetConfigSetting_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiGetConfigSetting, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (translateVariables) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_translateVariables_Static_Method_Call_Internally(Type[] types)
        {
            var methodtranslateVariablesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodtranslateVariables, Fixture, methodtranslateVariablesPrametersTypes);
        }

        #endregion

        #region Method Call : (translateVariables) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_translateVariables_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var prop = CreateType<string>();
            var isRelative = CreateType<bool>();
            var web = CreateType<SPWeb>();
            var site = CreateType<SPSite>();
            var methodtranslateVariablesPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(SPWeb), typeof(SPSite) };
            object[] parametersOftranslateVariables = { prop, isRelative, web, site };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodtranslateVariables, methodtranslateVariablesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodtranslateVariables, Fixture, methodtranslateVariablesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodtranslateVariables, parametersOftranslateVariables, methodtranslateVariablesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOftranslateVariables);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOftranslateVariables.ShouldNotBeNull();
            parametersOftranslateVariables.Length.ShouldBe(4);
            methodtranslateVariablesPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (translateVariables) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_translateVariables_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var prop = CreateType<string>();
            var isRelative = CreateType<bool>();
            var web = CreateType<SPWeb>();
            var site = CreateType<SPSite>();
            var methodtranslateVariablesPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(SPWeb), typeof(SPSite) };
            object[] parametersOftranslateVariables = { prop, isRelative, web, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodtranslateVariables, parametersOftranslateVariables, methodtranslateVariablesPrametersTypes);

            // Assert
            parametersOftranslateVariables.ShouldNotBeNull();
            parametersOftranslateVariables.Length.ShouldBe(4);
            methodtranslateVariablesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (translateVariables) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_translateVariables_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodtranslateVariablesPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(SPWeb), typeof(SPSite) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodtranslateVariables, Fixture, methodtranslateVariablesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodtranslateVariablesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (translateVariables) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_translateVariables_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodtranslateVariablesPrametersTypes = new Type[] { typeof(string), typeof(bool), typeof(SPWeb), typeof(SPSite) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodtranslateVariables, Fixture, methodtranslateVariablesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodtranslateVariablesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (translateVariables) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_translateVariables_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodtranslateVariables, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (translateVariables) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_translateVariables_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodtranslateVariables, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLicenseCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getLicenseCount_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetLicenseCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLicenseCount, Fixture, methodgetLicenseCountPrametersTypes);
        }

        #endregion

        #region Method Call : (getLicenseCount) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLicenseCount_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var checkFeatureId = CreateType<int>();
            var foundFeature = CreateType<bool>();
            var badservers = CreateType<bool>();
            var methodgetLicenseCountPrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(bool) };
            object[] parametersOfgetLicenseCount = { checkFeatureId, foundFeature, badservers };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetLicenseCount, methodgetLicenseCountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetLicenseCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetLicenseCount.ShouldNotBeNull();
            parametersOfgetLicenseCount.Length.ShouldBe(3);
            methodgetLicenseCountPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLicenseCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLicenseCount_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkFeatureId = CreateType<int>();
            var foundFeature = CreateType<bool>();
            var badservers = CreateType<bool>();
            var methodgetLicenseCountPrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(bool) };
            object[] parametersOfgetLicenseCount = { checkFeatureId, foundFeature, badservers };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLicenseCount, parametersOfgetLicenseCount, methodgetLicenseCountPrametersTypes);

            // Assert
            parametersOfgetLicenseCount.ShouldNotBeNull();
            parametersOfgetLicenseCount.Length.ShouldBe(3);
            methodgetLicenseCountPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getLicenseCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLicenseCount_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetLicenseCountPrametersTypes = new Type[] { typeof(int), typeof(bool), typeof(bool) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetLicenseCount, Fixture, methodgetLicenseCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetLicenseCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getLicenseCount) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLicenseCount_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetLicenseCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getLicenseCount) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getLicenseCount_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetLicenseCount, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (checkServerCount) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_checkServerCount_Static_Method_Call_Internally(Type[] types)
        {
            var methodcheckServerCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcheckServerCount, Fixture, methodcheckServerCountPrametersTypes);
        }

        #endregion

        #region Method Call : (checkServerCount) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_checkServerCount_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var serverCount = CreateType<int>();
            var badservers = CreateType<bool>();
            var methodcheckServerCountPrametersTypes = new Type[] { typeof(int), typeof(bool) };
            object[] parametersOfcheckServerCount = { serverCount, badservers };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcheckServerCount, parametersOfcheckServerCount, methodcheckServerCountPrametersTypes);

            // Assert
            parametersOfcheckServerCount.ShouldNotBeNull();
            parametersOfcheckServerCount.Length.ShouldBe(2);
            methodcheckServerCountPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkServerCount) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_checkServerCount_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcheckServerCountPrametersTypes = new Type[] { typeof(int), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcheckServerCount, Fixture, methodcheckServerCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcheckServerCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (checkServerCount) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_checkServerCount_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcheckServerCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (checkServerCount) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_checkServerCount_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcheckServerCount, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_farmEncode_Static_Method_Call_Internally(Type[] types)
        {
            var methodfarmEncodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_farmEncode_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var code = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.farmEncode(code);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_farmEncode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOffarmEncode = { code };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfarmEncode, methodfarmEncodePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfarmEncode, parametersOffarmEncode, methodfarmEncodePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOffarmEncode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOffarmEncode.ShouldNotBeNull();
            parametersOffarmEncode.Length.ShouldBe(1);
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_farmEncode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOffarmEncode = { code };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfarmEncode, parametersOffarmEncode, methodfarmEncodePrametersTypes);

            // Assert
            parametersOffarmEncode.ShouldNotBeNull();
            parametersOffarmEncode.Length.ShouldBe(1);
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_farmEncode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodfarmEncodePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_farmEncode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodfarmEncodePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfarmEncode, Fixture, methodfarmEncodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodfarmEncodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_farmEncode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfarmEncode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (farmEncode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_farmEncode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodfarmEncode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFeatureLicenseUserCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureLicenseUserCount, Fixture, methodgetFeatureLicenseUserCountPrametersTypes);
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var checkFeatureId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getFeatureLicenseUserCount(checkFeatureId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var checkFeatureId = CreateType<int>();
            var methodgetFeatureLicenseUserCountPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfgetFeatureLicenseUserCount = { checkFeatureId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFeatureLicenseUserCount, methodgetFeatureLicenseUserCountPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureLicenseUserCount, Fixture, methodgetFeatureLicenseUserCountPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureLicenseUserCount, parametersOfgetFeatureLicenseUserCount, methodgetFeatureLicenseUserCountPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetFeatureLicenseUserCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetFeatureLicenseUserCount.ShouldNotBeNull();
            parametersOfgetFeatureLicenseUserCount.Length.ShouldBe(1);
            methodgetFeatureLicenseUserCountPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkFeatureId = CreateType<int>();
            var methodgetFeatureLicenseUserCountPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfgetFeatureLicenseUserCount = { checkFeatureId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureLicenseUserCount, parametersOfgetFeatureLicenseUserCount, methodgetFeatureLicenseUserCountPrametersTypes);

            // Assert
            parametersOfgetFeatureLicenseUserCount.ShouldNotBeNull();
            parametersOfgetFeatureLicenseUserCount.Length.ShouldBe(1);
            methodgetFeatureLicenseUserCountPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFeatureLicenseUserCountPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureLicenseUserCount, Fixture, methodgetFeatureLicenseUserCountPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFeatureLicenseUserCountPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFeatureLicenseUserCountPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureLicenseUserCount, Fixture, methodgetFeatureLicenseUserCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFeatureLicenseUserCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFeatureLicenseUserCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getFeatureLicenseUserCount) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureLicenseUserCount_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFeatureLicenseUserCount, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getFeatureUsers_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFeatureUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureUsers, Fixture, methodgetFeatureUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureUsers_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var featureId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getFeatureUsers(featureId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureUsers_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var featureId = CreateType<int>();
            var methodgetFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfgetFeatureUsers = { featureId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFeatureUsers, methodgetFeatureUsersPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureUsers, Fixture, methodgetFeatureUsersPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<ArrayList>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureUsers, parametersOfgetFeatureUsers, methodgetFeatureUsersPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetFeatureUsers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetFeatureUsers.ShouldNotBeNull();
            parametersOfgetFeatureUsers.Length.ShouldBe(1);
            methodgetFeatureUsersPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureUsers_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var featureId = CreateType<int>();
            var methodgetFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfgetFeatureUsers = { featureId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ArrayList>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureUsers, parametersOfgetFeatureUsers, methodgetFeatureUsersPrametersTypes);

            // Assert
            parametersOfgetFeatureUsers.ShouldNotBeNull();
            parametersOfgetFeatureUsers.Length.ShouldBe(1);
            methodgetFeatureUsersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureUsers_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetFeatureUsersPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureUsers, Fixture, methodgetFeatureUsersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetFeatureUsersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureUsers_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFeatureUsersPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureUsers, Fixture, methodgetFeatureUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFeatureUsersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureUsers_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFeatureUsers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getFeatureUsers) (Return Type : ArrayList) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureUsers_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFeatureUsers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserCount) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getUserCount_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetUserCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserCount, Fixture, methodgetUserCountPrametersTypes);
        }

        #endregion

        #region Method Call : (getUserCount) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserCount_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var checkFeatureId = CreateType<int>();
            var username = CreateType<string>();
            var totalAvailableUserCount = CreateType<int>();
            var methodgetUserCountPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfgetUserCount = { checkFeatureId, username, totalAvailableUserCount };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetUserCount, methodgetUserCountPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetUserCount);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetUserCount.ShouldNotBeNull();
            parametersOfgetUserCount.Length.ShouldBe(3);
            methodgetUserCountPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getUserCount) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserCount_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var checkFeatureId = CreateType<int>();
            var username = CreateType<string>();
            var totalAvailableUserCount = CreateType<int>();
            var methodgetUserCountPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            object[] parametersOfgetUserCount = { checkFeatureId, username, totalAvailableUserCount };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserCount, parametersOfgetUserCount, methodgetUserCountPrametersTypes);

            // Assert
            parametersOfgetUserCount.ShouldNotBeNull();
            parametersOfgetUserCount.Length.ShouldBe(3);
            methodgetUserCountPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getUserCount) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserCount_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetUserCountPrametersTypes = new Type[] { typeof(int), typeof(string), typeof(int) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetUserCount, Fixture, methodgetUserCountPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetUserCountPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getUserCount) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserCount_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetUserCount, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getUserCount) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getUserCount_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetUserCount, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_computerCode_Static_Method_Call_Internally(Type[] types)
        {
            var methodcomputerCodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcomputerCode, Fixture, methodcomputerCodePrametersTypes);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_computerCode_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var code = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.computerCode(code);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_computerCode_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcomputerCode = { code };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodcomputerCode, methodcomputerCodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfcomputerCode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfcomputerCode.ShouldNotBeNull();
            parametersOfcomputerCode.Length.ShouldBe(1);
            methodcomputerCodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_computerCode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var code = CreateType<string>();
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcomputerCode = { code };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcomputerCode, parametersOfcomputerCode, methodcomputerCodePrametersTypes);

            // Assert
            parametersOfcomputerCode.ShouldNotBeNull();
            parametersOfcomputerCode.Length.ShouldBe(1);
            methodcomputerCodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_computerCode_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcomputerCode, Fixture, methodcomputerCodePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodcomputerCodePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_computerCode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcomputerCodePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodcomputerCode, Fixture, methodcomputerCodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcomputerCodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_computerCode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcomputerCode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (computerCode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_computerCode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcomputerCode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_Encrypt_Static_Method_Call_Internally(Type[] types)
        {
            var methodEncryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Encrypt_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var plainText = CreateType<string>();
            var passPhrase = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.Encrypt(plainText, passPhrase);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Encrypt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var plainText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfEncrypt = { plainText, passPhrase };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEncrypt, methodEncryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfEncrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEncrypt.ShouldNotBeNull();
            parametersOfEncrypt.Length.ShouldBe(2);
            methodEncryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Encrypt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var plainText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfEncrypt = { plainText, passPhrase };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodEncrypt, parametersOfEncrypt, methodEncryptPrametersTypes);

            // Assert
            parametersOfEncrypt.ShouldNotBeNull();
            parametersOfEncrypt.Length.ShouldBe(2);
            methodEncryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Encrypt_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodEncryptPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Encrypt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEncryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodEncrypt, Fixture, methodEncryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodEncryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Encrypt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEncrypt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Encrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Encrypt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEncrypt, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_Decrypt_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDecryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.Decrypt(cipherText, passPhrase);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Overloading_Of_1_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDecrypt = { cipherText, passPhrase };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecrypt, methodDecryptPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(2);
            methodDecryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes));
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDecrypt = { cipherText, passPhrase };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecrypt, methodDecryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfDecrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(2);
            methodDecryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cipherText = CreateType<string>();
            var passPhrase = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfDecrypt = { cipherText, passPhrase };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes);

            // Assert
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(2);
            methodDecryptPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecryptPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecrypt, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_Decrypt_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecrypt, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_deleteKey_Static_Method_Call_Internally(Type[] types)
        {
            var methoddeleteKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethoddeleteKey, Fixture, methoddeleteKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_deleteKey_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var key = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.deleteKey(key);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_deleteKey_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methoddeleteKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfdeleteKey = { key };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethoddeleteKey, methoddeleteKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfdeleteKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfdeleteKey.ShouldNotBeNull();
            parametersOfdeleteKey.Length.ShouldBe(1);
            methoddeleteKeyPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_deleteKey_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methoddeleteKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfdeleteKey = { key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethoddeleteKey, parametersOfdeleteKey, methoddeleteKeyPrametersTypes);

            // Assert
            parametersOfdeleteKey.ShouldNotBeNull();
            parametersOfdeleteKey.Length.ShouldBe(1);
            methoddeleteKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_deleteKey_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethoddeleteKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_deleteKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methoddeleteKeyPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethoddeleteKey, Fixture, methoddeleteKeyPrametersTypes);

            // Assert
            methoddeleteKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (deleteKey) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_deleteKey_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethoddeleteKey, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStoreCreds) (Return Type : System.Net.NetworkCredential) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetStoreCreds_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetStoreCredsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetStoreCreds, Fixture, methodGetStoreCredsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStoreCreds) (Return Type : System.Net.NetworkCredential) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetStoreCreds_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetStoreCredsPrametersTypes = null;
            object[] parametersOfGetStoreCreds = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetStoreCreds, methodGetStoreCredsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetStoreCreds);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetStoreCreds.ShouldBeNull();
            methodGetStoreCredsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStoreCreds) (Return Type : System.Net.NetworkCredential) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetStoreCreds_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetStoreCredsPrametersTypes = null;
            object[] parametersOfGetStoreCreds = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<System.Net.NetworkCredential>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetStoreCreds, parametersOfGetStoreCreds, methodGetStoreCredsPrametersTypes);

            // Assert
            parametersOfGetStoreCreds.ShouldBeNull();
            methodGetStoreCredsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStoreCreds) (Return Type : System.Net.NetworkCredential) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetStoreCreds_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetStoreCredsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetStoreCreds, Fixture, methodGetStoreCredsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStoreCredsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStoreCreds) (Return Type : System.Net.NetworkCredential) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetStoreCreds_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetStoreCredsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetStoreCreds, Fixture, methodGetStoreCredsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStoreCredsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStoreCreds) (Return Type : System.Net.NetworkCredential) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetStoreCreds_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStoreCreds, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_getFeatureName_Static_Method_Call_Internally(Type[] types)
        {
            var methodgetFeatureNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureName, Fixture, methodgetFeatureNamePrametersTypes);
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.getFeatureName(featureid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodgetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetFeatureName = { featureid };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFeatureName, methodgetFeatureNamePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureName, Fixture, methodgetFeatureNamePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureName, parametersOfgetFeatureName, methodgetFeatureNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfgetFeatureName.ShouldNotBeNull();
            parametersOfgetFeatureName.Length.ShouldBe(1);
            methodgetFeatureNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureName, parametersOfgetFeatureName, methodgetFeatureNamePrametersTypes));
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodgetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetFeatureName = { featureid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodgetFeatureName, methodgetFeatureNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfgetFeatureName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfgetFeatureName.ShouldNotBeNull();
            parametersOfgetFeatureName.Length.ShouldBe(1);
            methodgetFeatureNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var featureid = CreateType<string>();
            var methodgetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetFeatureName = { featureid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureName, parametersOfgetFeatureName, methodgetFeatureNamePrametersTypes);

            // Assert
            parametersOfgetFeatureName.ShouldNotBeNull();
            parametersOfgetFeatureName.Length.ShouldBe(1);
            methodgetFeatureNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodgetFeatureNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureName, Fixture, methodgetFeatureNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodgetFeatureNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetFeatureNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodgetFeatureName, Fixture, methodgetFeatureNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetFeatureNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetFeatureName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (getFeatureName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_getFeatureName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetFeatureName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_featureList_Static_Method_Call_Internally(Type[] types)
        {
            var methodfeatureListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_featureList_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.featureList();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_featureList_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;
            object[] parametersOffeatureList = null; // no parameter present
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfeatureList, methodfeatureListPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string[]>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfeatureList, parametersOffeatureList, methodfeatureListPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOffeatureList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOffeatureList.ShouldBeNull();
            methodfeatureListPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_featureList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;
            object[] parametersOffeatureList = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string[]>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfeatureList, parametersOffeatureList, methodfeatureListPrametersTypes);

            // Assert
            parametersOffeatureList.ShouldBeNull();
            methodfeatureListPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_featureList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodfeatureListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_featureList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodfeatureListPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodfeatureList, Fixture, methodfeatureListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodfeatureListPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (featureList) (Return Type : string[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_featureList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodfeatureList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_enqueue_Static_Method_Call_Internally(Type[] types)
        {
            var methodenqueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.enqueue(timerjobuid, defaultstatus);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodenqueue, methodenqueuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfenqueue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(2);
            methodenqueuePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, Methodenqueue, parametersOfenqueue, methodenqueuePrametersTypes);

            // Assert
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(2);
            methodenqueuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodenqueue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);

            // Assert
            methodenqueuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodenqueue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_enqueue_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodenqueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.enqueue(timerjobuid, defaultstatus, site);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus, site };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodenqueue, methodenqueuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfenqueue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(3);
            methodenqueuePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var timerjobuid = CreateType<Guid>();
            var defaultstatus = CreateType<int>();
            var site = CreateType<SPSite>();
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };
            object[] parametersOfenqueue = { timerjobuid, defaultstatus, site };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, Methodenqueue, parametersOfenqueue, methodenqueuePrametersTypes);

            // Assert
            parametersOfenqueue.ShouldNotBeNull();
            parametersOfenqueue.Length.ShouldBe(3);
            methodenqueuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodenqueue, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodenqueuePrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(SPSite) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, Methodenqueue, Fixture, methodenqueuePrametersTypes);

            // Assert
            methodenqueuePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (enqueue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_enqueue_Static_Method_Call_Overloading_Of_1_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodenqueue, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAssemblyVersion) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetAssemblyVersion_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetAssemblyVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetAssemblyVersion, Fixture, methodGetAssemblyVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAssemblyVersion) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetAssemblyVersion_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetAssemblyVersion();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetAssemblyVersion) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetAssemblyVersion_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetAssemblyVersionPrametersTypes = null;
            object[] parametersOfGetAssemblyVersion = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAssemblyVersion, methodGetAssemblyVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetAssemblyVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAssemblyVersion.ShouldBeNull();
            methodGetAssemblyVersionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAssemblyVersion) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetAssemblyVersion_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetAssemblyVersionPrametersTypes = null;
            object[] parametersOfGetAssemblyVersion = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetAssemblyVersion, parametersOfGetAssemblyVersion, methodGetAssemblyVersionPrametersTypes);

            // Assert
            parametersOfGetAssemblyVersion.ShouldBeNull();
            methodGetAssemblyVersionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAssemblyVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetAssemblyVersion_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetAssemblyVersionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetAssemblyVersion, Fixture, methodGetAssemblyVersionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAssemblyVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAssemblyVersion) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetAssemblyVersion_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetAssemblyVersionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetAssemblyVersion, Fixture, methodGetAssemblyVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAssemblyVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAssemblyVersion) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetAssemblyVersion_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAssemblyVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetFullAssemblyVersion) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetFullAssemblyVersion_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFullAssemblyVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetFullAssemblyVersion, Fixture, methodGetFullAssemblyVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFullAssemblyVersion) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetFullAssemblyVersion_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.GetFullAssemblyVersion();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetFullAssemblyVersion) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetFullAssemblyVersion_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFullAssemblyVersionPrametersTypes = null;
            object[] parametersOfGetFullAssemblyVersion = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFullAssemblyVersion, methodGetFullAssemblyVersionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetFullAssemblyVersion);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFullAssemblyVersion.ShouldBeNull();
            methodGetFullAssemblyVersionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFullAssemblyVersion) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetFullAssemblyVersion_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFullAssemblyVersionPrametersTypes = null;
            object[] parametersOfGetFullAssemblyVersion = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetFullAssemblyVersion, parametersOfGetFullAssemblyVersion, methodGetFullAssemblyVersionPrametersTypes);

            // Assert
            parametersOfGetFullAssemblyVersion.ShouldBeNull();
            methodGetFullAssemblyVersionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFullAssemblyVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetFullAssemblyVersion_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFullAssemblyVersionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetFullAssemblyVersion, Fixture, methodGetFullAssemblyVersionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFullAssemblyVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFullAssemblyVersion) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetFullAssemblyVersion_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFullAssemblyVersionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetFullAssemblyVersion, Fixture, methodGetFullAssemblyVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFullAssemblyVersionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFullAssemblyVersion) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetFullAssemblyVersion_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFullAssemblyVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (EnsureNoDuplicates) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_EnsureNoDuplicates_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnsureNoDuplicatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodEnsureNoDuplicates, Fixture, methodEnsureNoDuplicatesPrametersTypes);
        }

        #endregion

        #region Method Call : (EnsureNoDuplicates) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_EnsureNoDuplicates_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<Boolean>();
            var isOnline = CreateType<Boolean>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.EnsureNoDuplicates(properties, isAdd, isOnline);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EnsureNoDuplicates) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_EnsureNoDuplicates_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<Boolean>();
            var isOnline = CreateType<Boolean>();
            var methodEnsureNoDuplicatesPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(Boolean), typeof(Boolean) };
            object[] parametersOfEnsureNoDuplicates = { properties, isAdd, isOnline };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnsureNoDuplicates, methodEnsureNoDuplicatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfEnsureNoDuplicates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnsureNoDuplicates.ShouldNotBeNull();
            parametersOfEnsureNoDuplicates.Length.ShouldBe(3);
            methodEnsureNoDuplicatesPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnsureNoDuplicates) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_EnsureNoDuplicates_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<Boolean>();
            var isOnline = CreateType<Boolean>();
            var methodEnsureNoDuplicatesPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(Boolean), typeof(Boolean) };
            object[] parametersOfEnsureNoDuplicates = { properties, isAdd, isOnline };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodEnsureNoDuplicates, parametersOfEnsureNoDuplicates, methodEnsureNoDuplicatesPrametersTypes);

            // Assert
            parametersOfEnsureNoDuplicates.ShouldNotBeNull();
            parametersOfEnsureNoDuplicates.Length.ShouldBe(3);
            methodEnsureNoDuplicatesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureNoDuplicates) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_EnsureNoDuplicates_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnsureNoDuplicates, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnsureNoDuplicates) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_EnsureNoDuplicates_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnsureNoDuplicatesPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(Boolean), typeof(Boolean) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodEnsureNoDuplicates, Fixture, methodEnsureNoDuplicatesPrametersTypes);

            // Assert
            methodEnsureNoDuplicatesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnsureNoDuplicates) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_EnsureNoDuplicates_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnsureNoDuplicates, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceWithDuplicateEmail) (Return Type : SPListItemCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_GetResourceWithDuplicateEmail_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetResourceWithDuplicateEmailPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetResourceWithDuplicateEmail, Fixture, methodGetResourceWithDuplicateEmailPrametersTypes);
        }

        #endregion

        #region Method Call : (GetResourceWithDuplicateEmail) (Return Type : SPListItemCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetResourceWithDuplicateEmail_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<Boolean>();
            var isOnline = CreateType<Boolean>();
            var sharePointAccount = CreateType<string>();
            var u = CreateType<SPUser>();
            var methodGetResourceWithDuplicateEmailPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(Boolean), typeof(Boolean), typeof(string), typeof(SPUser) };
            object[] parametersOfGetResourceWithDuplicateEmail = { properties, isAdd, isOnline, sharePointAccount, u };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceWithDuplicateEmail, methodGetResourceWithDuplicateEmailPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetResourceWithDuplicateEmail, Fixture, methodGetResourceWithDuplicateEmailPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SPListItemCollection>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetResourceWithDuplicateEmail, parametersOfGetResourceWithDuplicateEmail, methodGetResourceWithDuplicateEmailPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_coreFunctionsInstanceFixture, parametersOfGetResourceWithDuplicateEmail);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetResourceWithDuplicateEmail.ShouldNotBeNull();
            parametersOfGetResourceWithDuplicateEmail.Length.ShouldBe(5);
            methodGetResourceWithDuplicateEmailPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceWithDuplicateEmail) (Return Type : SPListItemCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetResourceWithDuplicateEmail_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPItemEventProperties>();
            var isAdd = CreateType<Boolean>();
            var isOnline = CreateType<Boolean>();
            var sharePointAccount = CreateType<string>();
            var u = CreateType<SPUser>();
            var methodGetResourceWithDuplicateEmailPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(Boolean), typeof(Boolean), typeof(string), typeof(SPUser) };
            object[] parametersOfGetResourceWithDuplicateEmail = { properties, isAdd, isOnline, sharePointAccount, u };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPListItemCollection>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetResourceWithDuplicateEmail, parametersOfGetResourceWithDuplicateEmail, methodGetResourceWithDuplicateEmailPrametersTypes);

            // Assert
            parametersOfGetResourceWithDuplicateEmail.ShouldNotBeNull();
            parametersOfGetResourceWithDuplicateEmail.Length.ShouldBe(5);
            methodGetResourceWithDuplicateEmailPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetResourceWithDuplicateEmail) (Return Type : SPListItemCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetResourceWithDuplicateEmail_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetResourceWithDuplicateEmailPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(Boolean), typeof(Boolean), typeof(string), typeof(SPUser) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetResourceWithDuplicateEmail, Fixture, methodGetResourceWithDuplicateEmailPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetResourceWithDuplicateEmailPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetResourceWithDuplicateEmail) (Return Type : SPListItemCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetResourceWithDuplicateEmail_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetResourceWithDuplicateEmailPrametersTypes = new Type[] { typeof(SPItemEventProperties), typeof(Boolean), typeof(Boolean), typeof(string), typeof(SPUser) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodGetResourceWithDuplicateEmail, Fixture, methodGetResourceWithDuplicateEmailPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetResourceWithDuplicateEmailPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetResourceWithDuplicateEmail) (Return Type : SPListItemCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetResourceWithDuplicateEmail_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetResourceWithDuplicateEmail, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_coreFunctionsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetResourceWithDuplicateEmail) (Return Type : SPListItemCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_GetResourceWithDuplicateEmail_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetResourceWithDuplicateEmail, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ScheduleReportingRefreshJob) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_ScheduleReportingRefreshJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodScheduleReportingRefreshJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodScheduleReportingRefreshJob, Fixture, methodScheduleReportingRefreshJobPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ScheduleReportingRefreshJob) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_ScheduleReportingRefreshJob_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodScheduleReportingRefreshJobPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfScheduleReportingRefreshJob = { spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodScheduleReportingRefreshJob, parametersOfScheduleReportingRefreshJob, methodScheduleReportingRefreshJobPrametersTypes);

            // Assert
            parametersOfScheduleReportingRefreshJob.ShouldNotBeNull();
            parametersOfScheduleReportingRefreshJob.Length.ShouldBe(1);
            methodScheduleReportingRefreshJobPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion
        
        #region Method Call : (ScheduleReportingRefreshJob) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_ScheduleReportingRefreshJob_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodScheduleReportingRefreshJobPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodScheduleReportingRefreshJob, Fixture, methodScheduleReportingRefreshJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodScheduleReportingRefreshJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (ScheduleReportingRefreshJob) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_ScheduleReportingRefreshJob_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodScheduleReportingRefreshJob, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateProjectInNewWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_CreateProjectInNewWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodCreateProjectInNewWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateProjectInNewWorkspace, Fixture, methodCreateProjectInNewWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateProjectInNewWorkspace) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateProjectInNewWorkspace_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listTitle = CreateType<string>();
            var url = CreateType<string>();
            var title = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => CoreFunctions.CreateProjectInNewWorkspace(web, listTitle, url, title);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateProjectInNewWorkspace) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateProjectInNewWorkspace_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var listTitle = CreateType<string>();
            var url = CreateType<string>();
            var title = CreateType<string>();
            var methodCreateProjectInNewWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCreateProjectInNewWorkspace = { web, listTitle, url, title };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateProjectInNewWorkspace, parametersOfCreateProjectInNewWorkspace, methodCreateProjectInNewWorkspacePrametersTypes);

            // Assert
            parametersOfCreateProjectInNewWorkspace.ShouldNotBeNull();
            parametersOfCreateProjectInNewWorkspace.Length.ShouldBe(4);
            methodCreateProjectInNewWorkspacePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateProjectInNewWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateProjectInNewWorkspace_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateProjectInNewWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateProjectInNewWorkspace, Fixture, methodCreateProjectInNewWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateProjectInNewWorkspacePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (CreateProjectInNewWorkspace) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_CreateProjectInNewWorkspace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateProjectInNewWorkspacePrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodCreateProjectInNewWorkspace, Fixture, methodCreateProjectInNewWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateProjectInNewWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CoreFunctions_IsAlphaNumeric_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsAlphaNumericPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);
        }

        #endregion
        
        #region Method Call : (IsAlphaNumeric) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_IsAlphaNumeric_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var strToCheck = CreateType<string>();
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsAlphaNumeric = { strToCheck };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodIsAlphaNumeric, parametersOfIsAlphaNumeric, methodIsAlphaNumericPrametersTypes);

            // Assert
            parametersOfIsAlphaNumeric.ShouldNotBeNull();
            parametersOfIsAlphaNumeric.Length.ShouldBe(1);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsAlphaNumeric) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CoreFunctions_IsAlphaNumeric_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsAlphaNumericPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_coreFunctionsInstanceFixture, _coreFunctionsInstanceType, MethodIsAlphaNumeric, Fixture, methodIsAlphaNumericPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsAlphaNumericPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}