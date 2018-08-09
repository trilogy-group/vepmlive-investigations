using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveIntegration;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using static EPMLiveCore.API.Integration.IntegrationCore;

namespace EPMLiveCore.API.Integration
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Integration.IntegrationCore" />)
    ///     and namespace <see cref="EPMLiveCore.API.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class IntegrationCoreTest : AbstractBaseSetupTypedTest<IntegrationCore>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (IntegrationCore) Initializer

        private const string MethodGetIntegrationControl = "GetIntegrationControl";
        private const string MethodGetIntegrationControlByIntId = "GetIntegrationControlByIntId";
        private const string MethodGetIntegrationsForList = "GetIntegrationsForList";
        private const string MethodInstallIntegration = "InstallIntegration";
        private const string MethodGetListItemFromExternalID = "GetListItemFromExternalID";
        private const string MethodRemoveIntegration = "RemoveIntegration";
        private const string MethodGetIntegrations = "GetIntegrations";
        private const string MethodExecuteEvent = "ExecuteEvent";
        private const string MethodSaveProperties = "SaveProperties";
        private const string MethodGetDataSet = "GetDataSet";
        private const string MethodExecuteQuery = "ExecuteQuery";
        private const string MethodGetDropDownProperties = "GetDropDownProperties";
        private const string MethodTestModuleConnection = "TestModuleConnection";
        private const string MethodGetColumns = "GetColumns";
        private const string MethodGetModuleProperties = "GetModuleProperties";
        private const string MethodGetLookupItem = "GetLookupItem";
        private const string MethodProcessItemRow = "ProcessItemRow";
        private const string MethodiProcessItemRow = "iProcessItemRow";
        private const string MethodProcessLIItem = "ProcessLIItem";
        private const string MethodProcessItemIncoming = "ProcessItemIncoming";
        private const string MethodDeleteSharePointItem = "DeleteSharePointItem";
        private const string MethodUpdatePriorityNumbers = "UpdatePriorityNumbers";
        private const string MethodProcessItemOutgoing = "ProcessItemOutgoing";
        private const string MethodLogMessage = "LogMessage";
        private const string MethodGetUserMap = "GetUserMap";
        private const string MethodPostIntegration = "PostIntegration";
        private const string MethodPostCheckBit = "PostCheckBit";
        private const string MethodPostIntegrationDeleteToExternal = "PostIntegrationDeleteToExternal";
        private const string MethodGetControlURL = "GetControlURL";
        private const string MethodGetItemButtons = "GetItemButtons";
        private const string MethodGetGlobalButtons = "GetGlobalButtons";
        private const string MethodGetEmbbededControls = "GetEmbbededControls";
        private const string MethodPullData = "PullData";
        private const string MethodPostIntegrationUpdateToExternal = "PostIntegrationUpdateToExternal";
        private const string MethodGetExternalItem = "GetExternalItem";
        private const string MethodGetProxyResult = "GetProxyResult";
        private const string MethodGetWebProps = "GetWebProps";
        private const string MethodGetProperties = "GetProperties";
        private const string MethodGetIntegrator = "GetIntegrator";
        private const string MethodGetIntegratorFromModule = "GetIntegratorFromModule";
        private const string MethodProcessItem = "ProcessItem";
        private const string MethodSubmitDeleteListEvent = "SubmitDeleteListEvent";
        private const string MethodSubmitListEvent = "SubmitListEvent";
        private const string MethodbCheckBit = "bCheckBit";
        private const string MethodAddField = "AddField";
        private const string MethodGetAPIUrl = "GetAPIUrl";
        private const string MethodOpenConnection = "OpenConnection";
        private const string MethodCloseConnection = "CloseConnection";
        private const string FieldColNameIntListId = "ColNameIntListId";
        private const string FieldColNameListId = "ColNameListId";
        private const string FieldColNameColId = "ColNameColId";
        private const string FieldTextIntUid = "TextIntUid";
        private const string Field_site = "_site";
        private const string Field_web = "_web";
        private const string Fieldcn = "cn";
        private const string FieldWasOpen = "WasOpen";
        private Type _integrationCoreInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private IntegrationCore _integrationCoreInstance;
        private IntegrationCore _integrationCoreInstanceFixture;

        #region General Initializer : Class (IntegrationCore) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="IntegrationCore" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integrationCoreInstanceType = typeof(IntegrationCore);
            _integrationCoreInstanceFixture = Create(true);
            _integrationCoreInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (IntegrationCore)

        #region General Initializer : Class (IntegrationCore) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="IntegrationCore" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetIntegrationControl, 0)]
        [TestCase(MethodGetIntegrationControlByIntId, 0)]
        [TestCase(MethodGetIntegrationsForList, 0)]
        [TestCase(MethodInstallIntegration, 0)]
        [TestCase(MethodGetListItemFromExternalID, 0)]
        [TestCase(MethodRemoveIntegration, 0)]
        [TestCase(MethodGetIntegrations, 0)]
        [TestCase(MethodExecuteEvent, 0)]
        [TestCase(MethodSaveProperties, 0)]
        [TestCase(MethodGetDataSet, 0)]
        [TestCase(MethodExecuteQuery, 0)]
        [TestCase(MethodGetDropDownProperties, 0)]
        [TestCase(MethodTestModuleConnection, 0)]
        [TestCase(MethodGetColumns, 0)]
        [TestCase(MethodTestModuleConnection, 1)]
        [TestCase(MethodGetModuleProperties, 0)]
        [TestCase(MethodGetLookupItem, 0)]
        [TestCase(MethodProcessItemRow, 0)]
        [TestCase(MethodiProcessItemRow, 0)]
        [TestCase(MethodProcessLIItem, 0)]
        [TestCase(MethodProcessItemIncoming, 0)]
        [TestCase(MethodDeleteSharePointItem, 0)]
        [TestCase(MethodUpdatePriorityNumbers, 0)]
        [TestCase(MethodProcessItemOutgoing, 0)]
        [TestCase(MethodLogMessage, 0)]
        [TestCase(MethodGetUserMap, 0)]
        [TestCase(MethodPostIntegration, 0)]
        [TestCase(MethodPostCheckBit, 0)]
        [TestCase(MethodPostIntegrationDeleteToExternal, 0)]
        [TestCase(MethodGetControlURL, 0)]
        [TestCase(MethodGetItemButtons, 0)]
        [TestCase(MethodGetGlobalButtons, 0)]
        [TestCase(MethodGetEmbbededControls, 0)]
        [TestCase(MethodPullData, 0)]
        [TestCase(MethodPostIntegrationUpdateToExternal, 0)]
        [TestCase(MethodGetExternalItem, 0)]
        [TestCase(MethodGetProxyResult, 0)]
        [TestCase(MethodGetWebProps, 0)]
        [TestCase(MethodGetProperties, 0)]
        [TestCase(MethodGetIntegrator, 0)]
        [TestCase(MethodGetIntegratorFromModule, 0)]
        [TestCase(MethodProcessItem, 0)]
        [TestCase(MethodSubmitDeleteListEvent, 0)]
        [TestCase(MethodSubmitListEvent, 0)]
        [TestCase(MethodbCheckBit, 0)]
        [TestCase(MethodAddField, 0)]
        [TestCase(MethodGetDataSet, 1)]
        [TestCase(MethodGetAPIUrl, 0)]
        [TestCase(MethodOpenConnection, 0)]
        [TestCase(MethodCloseConnection, 0)]
        public void AUT_IntegrationCore_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_integrationCoreInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (IntegrationCore) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="IntegrationCore" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_site)]
        [TestCase(Field_web)]
        [TestCase(Fieldcn)]
        [TestCase(FieldWasOpen)]
        public void AUT_IntegrationCore_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_integrationCoreInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="IntegrationCore" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetIntegrationControl)]
        [TestCase(MethodGetIntegrationControlByIntId)]
        [TestCase(MethodGetIntegrationsForList)]
        [TestCase(MethodInstallIntegration)]
        [TestCase(MethodGetListItemFromExternalID)]
        [TestCase(MethodRemoveIntegration)]
        [TestCase(MethodGetIntegrations)]
        [TestCase(MethodExecuteEvent)]
        [TestCase(MethodSaveProperties)]
        [TestCase(MethodGetDataSet)]
        [TestCase(MethodExecuteQuery)]
        [TestCase(MethodGetDropDownProperties)]
        [TestCase(MethodTestModuleConnection)]
        [TestCase(MethodGetColumns)]
        [TestCase(MethodGetModuleProperties)]
        [TestCase(MethodGetLookupItem)]
        [TestCase(MethodProcessItemRow)]
        [TestCase(MethodiProcessItemRow)]
        [TestCase(MethodProcessLIItem)]
        [TestCase(MethodProcessItemIncoming)]
        [TestCase(MethodDeleteSharePointItem)]
        [TestCase(MethodUpdatePriorityNumbers)]
        [TestCase(MethodProcessItemOutgoing)]
        [TestCase(MethodLogMessage)]
        [TestCase(MethodGetUserMap)]
        [TestCase(MethodPostIntegration)]
        [TestCase(MethodPostCheckBit)]
        [TestCase(MethodPostIntegrationDeleteToExternal)]
        [TestCase(MethodGetControlURL)]
        [TestCase(MethodGetItemButtons)]
        [TestCase(MethodGetGlobalButtons)]
        [TestCase(MethodGetEmbbededControls)]
        [TestCase(MethodPullData)]
        [TestCase(MethodPostIntegrationUpdateToExternal)]
        [TestCase(MethodGetExternalItem)]
        [TestCase(MethodGetProxyResult)]
        [TestCase(MethodGetWebProps)]
        [TestCase(MethodGetProperties)]
        [TestCase(MethodGetIntegrator)]
        [TestCase(MethodGetIntegratorFromModule)]
        [TestCase(MethodProcessItem)]
        [TestCase(MethodSubmitDeleteListEvent)]
        [TestCase(MethodSubmitListEvent)]
        [TestCase(MethodbCheckBit)]
        [TestCase(MethodAddField)]
        [TestCase(MethodGetAPIUrl)]
        [TestCase(MethodOpenConnection)]
        [TestCase(MethodCloseConnection)]
        public void AUT_IntegrationCore_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<IntegrationCore>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetIntegrationControl_Method_Call_Internally(Type[] types)
        {
            var methodGetIntegrationControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationControl, Fixture, methodGetIntegrationControlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControl_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ListId = CreateType<Guid>();
            var control = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetIntegrationControl(ListId, control);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControl_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ListId = CreateType<Guid>();
            var control = CreateType<string>();
            var methodGetIntegrationControlPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetIntegrationControl = { ListId, control };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntegrationControl, methodGetIntegrationControlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataTable>(_integrationCoreInstanceFixture, out exception1, parametersOfGetIntegrationControl);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetIntegrationControl, parametersOfGetIntegrationControl, methodGetIntegrationControlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetIntegrationControl.ShouldNotBeNull();
            parametersOfGetIntegrationControl.Length.ShouldBe(2);
            methodGetIntegrationControlPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetIntegrationControl));
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ListId = CreateType<Guid>();
            var control = CreateType<string>();
            var methodGetIntegrationControlPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetIntegrationControl = { ListId, control };

            // Assert
            parametersOfGetIntegrationControl.ShouldNotBeNull();
            parametersOfGetIntegrationControl.Length.ShouldBe(2);
            methodGetIntegrationControlPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetIntegrationControl, parametersOfGetIntegrationControl, methodGetIntegrationControlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntegrationControlPrametersTypes = new Type[] { typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationControl, Fixture, methodGetIntegrationControlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetIntegrationControlPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntegrationControlPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationControl, Fixture, methodGetIntegrationControlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntegrationControlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControl_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntegrationControl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntegrationControl) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntegrationControl, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_Call_Internally(Type[] types)
        {
            var methodGetIntegrationControlByIntIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationControlByIntId, Fixture, methodGetIntegrationControlByIntIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var IntListId = CreateType<Guid>();
            var control = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetIntegrationControlByIntId(IntListId, control);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var IntListId = CreateType<Guid>();
            var control = CreateType<string>();
            var methodGetIntegrationControlByIntIdPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetIntegrationControlByIntId = { IntListId, control };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntegrationControlByIntId, methodGetIntegrationControlByIntIdPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataTable>(_integrationCoreInstanceFixture, out exception1, parametersOfGetIntegrationControlByIntId);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetIntegrationControlByIntId, parametersOfGetIntegrationControlByIntId, methodGetIntegrationControlByIntIdPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetIntegrationControlByIntId.ShouldNotBeNull();
            parametersOfGetIntegrationControlByIntId.Length.ShouldBe(2);
            methodGetIntegrationControlByIntIdPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetIntegrationControlByIntId));
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var IntListId = CreateType<Guid>();
            var control = CreateType<string>();
            var methodGetIntegrationControlByIntIdPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetIntegrationControlByIntId = { IntListId, control };

            // Assert
            parametersOfGetIntegrationControlByIntId.ShouldNotBeNull();
            parametersOfGetIntegrationControlByIntId.Length.ShouldBe(2);
            methodGetIntegrationControlByIntIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetIntegrationControlByIntId, parametersOfGetIntegrationControlByIntId, methodGetIntegrationControlByIntIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntegrationControlByIntIdPrametersTypes = new Type[] { typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationControlByIntId, Fixture, methodGetIntegrationControlByIntIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetIntegrationControlByIntIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntegrationControlByIntIdPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationControlByIntId, Fixture, methodGetIntegrationControlByIntIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntegrationControlByIntIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntegrationControlByIntId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntegrationControlByIntId) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationControlByIntId_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntegrationControlByIntId, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetIntegrationsForList_Method_Call_Internally(Type[] types)
        {
            var methodGetIntegrationsForListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationsForList, Fixture, methodGetIntegrationsForListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationsForList_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ListId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetIntegrationsForList(ListId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationsForList_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ListId = CreateType<Guid>();
            var methodGetIntegrationsForListPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetIntegrationsForList = { ListId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntegrationsForList, methodGetIntegrationsForListPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataTable>(_integrationCoreInstanceFixture, out exception1, parametersOfGetIntegrationsForList);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetIntegrationsForList, parametersOfGetIntegrationsForList, methodGetIntegrationsForListPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetIntegrationsForList.ShouldNotBeNull();
            parametersOfGetIntegrationsForList.Length.ShouldBe(1);
            methodGetIntegrationsForListPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetIntegrationsForList));
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationsForList_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ListId = CreateType<Guid>();
            var methodGetIntegrationsForListPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetIntegrationsForList = { ListId };

            // Assert
            parametersOfGetIntegrationsForList.ShouldNotBeNull();
            parametersOfGetIntegrationsForList.Length.ShouldBe(1);
            methodGetIntegrationsForListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetIntegrationsForList, parametersOfGetIntegrationsForList, methodGetIntegrationsForListPrametersTypes));
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationsForList_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntegrationsForListPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationsForList, Fixture, methodGetIntegrationsForListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetIntegrationsForListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationsForList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntegrationsForListPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrationsForList, Fixture, methodGetIntegrationsForListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntegrationsForListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationsForList_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntegrationsForList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntegrationsForList) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrationsForList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntegrationsForList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_InstallIntegration_Method_Call_Internally(Type[] types)
        {
            var methodInstallIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_InstallIntegration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var message = CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfInstallIntegration = { intlistid, listid, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, bool>(_integrationCoreInstanceFixture, out exception1, parametersOfInstallIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(3);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfInstallIntegration));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_InstallIntegration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var message = CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfInstallIntegration = { intlistid, listid, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, methodInstallIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, bool>(_integrationCoreInstanceFixture, out exception1, parametersOfInstallIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(3);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_InstallIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var message = CreateType<string>();
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfInstallIntegration = { intlistid, listid, message };

            // Assert
            parametersOfInstallIntegration.ShouldNotBeNull();
            parametersOfInstallIntegration.Length.ShouldBe(3);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodInstallIntegration, parametersOfInstallIntegration, methodInstallIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_InstallIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstallIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodInstallIntegration, Fixture, methodInstallIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInstallIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_InstallIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstallIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InstallIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_InstallIntegration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstallIntegration, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListItemFromExternalID) (Return Type : SPListItem) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetListItemFromExternalID_Method_Call_Internally(Type[] types)
        {
            var methodGetListItemFromExternalIDPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetListItemFromExternalID, Fixture, methodGetListItemFromExternalIDPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListItemFromExternalID) (Return Type : SPListItem) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetListItemFromExternalID_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<string>();
            var intuid = CreateType<string>();
            var methodGetListItemFromExternalIDPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListItemFromExternalID = { intlistid, intuid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListItemFromExternalID, methodGetListItemFromExternalIDPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, SPListItem>(_integrationCoreInstanceFixture, out exception1, parametersOfGetListItemFromExternalID);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, SPListItem>(_integrationCoreInstance, MethodGetListItemFromExternalID, parametersOfGetListItemFromExternalID, methodGetListItemFromExternalIDPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListItemFromExternalID.ShouldNotBeNull();
            parametersOfGetListItemFromExternalID.Length.ShouldBe(2);
            methodGetListItemFromExternalIDPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetListItemFromExternalID));
        }

        #endregion

        #region Method Call : (GetListItemFromExternalID) (Return Type : SPListItem) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetListItemFromExternalID_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<string>();
            var intuid = CreateType<string>();
            var methodGetListItemFromExternalIDPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetListItemFromExternalID = { intlistid, intuid };

            // Assert
            parametersOfGetListItemFromExternalID.ShouldNotBeNull();
            parametersOfGetListItemFromExternalID.Length.ShouldBe(2);
            methodGetListItemFromExternalIDPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, SPListItem>(_integrationCoreInstance, MethodGetListItemFromExternalID, parametersOfGetListItemFromExternalID, methodGetListItemFromExternalIDPrametersTypes));
        }

        #endregion

        #region Method Call : (GetListItemFromExternalID) (Return Type : SPListItem) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetListItemFromExternalID_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListItemFromExternalIDPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetListItemFromExternalID, Fixture, methodGetListItemFromExternalIDPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListItemFromExternalIDPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetListItemFromExternalID) (Return Type : SPListItem) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetListItemFromExternalID_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListItemFromExternalIDPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetListItemFromExternalID, Fixture, methodGetListItemFromExternalIDPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListItemFromExternalIDPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListItemFromExternalID) (Return Type : SPListItem) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetListItemFromExternalID_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListItemFromExternalID, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListItemFromExternalID) (Return Type : SPListItem) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetListItemFromExternalID_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListItemFromExternalID, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_RemoveIntegration_Method_Call_Internally(Type[] types)
        {
            var methodRemoveIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_RemoveIntegration_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var message = CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfRemoveIntegration = { intlistid, listid, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, bool>(_integrationCoreInstanceFixture, out exception1, parametersOfRemoveIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(3);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfRemoveIntegration));
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_RemoveIntegration_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var message = CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfRemoveIntegration = { intlistid, listid, message };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, methodRemoveIntegrationPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, bool>(_integrationCoreInstanceFixture, out exception1, parametersOfRemoveIntegration);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(3);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_RemoveIntegration_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var message = CreateType<string>();
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfRemoveIntegration = { intlistid, listid, message };

            // Assert
            parametersOfRemoveIntegration.ShouldNotBeNull();
            parametersOfRemoveIntegration.Length.ShouldBe(3);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodRemoveIntegration, parametersOfRemoveIntegration, methodRemoveIntegrationPrametersTypes));
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_RemoveIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveIntegrationPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodRemoveIntegration, Fixture, methodRemoveIntegrationPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveIntegrationPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_RemoveIntegration_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveIntegration) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_RemoveIntegration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveIntegration, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetIntegrations_Method_Call_Internally(Type[] types)
        {
            var methodGetIntegrationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrations, Fixture, methodGetIntegrationsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrations_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var bOnline = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetIntegrations(bOnline);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrations_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var bOnline = CreateType<bool>();
            var methodGetIntegrationsPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfGetIntegrations = { bOnline };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntegrations, methodGetIntegrationsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataSet>(_integrationCoreInstanceFixture, out exception1, parametersOfGetIntegrations);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataSet>(_integrationCoreInstance, MethodGetIntegrations, parametersOfGetIntegrations, methodGetIntegrationsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetIntegrations.ShouldNotBeNull();
            parametersOfGetIntegrations.Length.ShouldBe(1);
            methodGetIntegrationsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetIntegrations));
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrations_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var bOnline = CreateType<bool>();
            var methodGetIntegrationsPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfGetIntegrations = { bOnline };

            // Assert
            parametersOfGetIntegrations.ShouldNotBeNull();
            parametersOfGetIntegrations.Length.ShouldBe(1);
            methodGetIntegrationsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataSet>(_integrationCoreInstance, MethodGetIntegrations, parametersOfGetIntegrations, methodGetIntegrationsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrations_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntegrationsPrametersTypes = new Type[] { typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrations, Fixture, methodGetIntegrationsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetIntegrationsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrations_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntegrationsPrametersTypes = new Type[] { typeof(bool) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrations, Fixture, methodGetIntegrationsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntegrationsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrations_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntegrations, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntegrations) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrations_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntegrations, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_ExecuteEvent_Method_Call_Internally(Type[] types)
        {
            var methodExecuteEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodExecuteEvent, Fixture, methodExecuteEventPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteEvent) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteEvent_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.ExecuteEvent(dr);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteEvent_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodExecuteEventPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfExecuteEvent = { dr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteEvent, methodExecuteEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfExecuteEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteEvent.ShouldNotBeNull();
            parametersOfExecuteEvent.Length.ShouldBe(1);
            methodExecuteEventPrametersTypes.Length.ShouldBe(1);
            methodExecuteEventPrametersTypes.Length.ShouldBe(parametersOfExecuteEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteEvent_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodExecuteEventPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfExecuteEvent = { dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodExecuteEvent, parametersOfExecuteEvent, methodExecuteEventPrametersTypes);

            // Assert
            parametersOfExecuteEvent.ShouldNotBeNull();
            parametersOfExecuteEvent.Length.ShouldBe(1);
            methodExecuteEventPrametersTypes.Length.ShouldBe(1);
            methodExecuteEventPrametersTypes.Length.ShouldBe(parametersOfExecuteEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteEvent, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteEventPrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodExecuteEvent, Fixture, methodExecuteEventPrametersTypes);

            // Assert
            methodExecuteEventPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteEvent_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveProperties) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_SaveProperties_Method_Call_Internally(Type[] types)
        {
            var methodSavePropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodSaveProperties, Fixture, methodSavePropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveProperties) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SaveProperties_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var hshProps = CreateType<Hashtable>();
            var methodSavePropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Hashtable) };
            object[] parametersOfSaveProperties = { intlistid, hshProps };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveProperties, methodSavePropertiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfSaveProperties);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveProperties.ShouldNotBeNull();
            parametersOfSaveProperties.Length.ShouldBe(2);
            methodSavePropertiesPrametersTypes.Length.ShouldBe(2);
            methodSavePropertiesPrametersTypes.Length.ShouldBe(parametersOfSaveProperties.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveProperties) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SaveProperties_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var hshProps = CreateType<Hashtable>();
            var methodSavePropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Hashtable) };
            object[] parametersOfSaveProperties = { intlistid, hshProps };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodSaveProperties, parametersOfSaveProperties, methodSavePropertiesPrametersTypes);

            // Assert
            parametersOfSaveProperties.ShouldNotBeNull();
            parametersOfSaveProperties.Length.ShouldBe(2);
            methodSavePropertiesPrametersTypes.Length.ShouldBe(2);
            methodSavePropertiesPrametersTypes.Length.ShouldBe(parametersOfSaveProperties.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveProperties) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SaveProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveProperties, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveProperties) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SaveProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSavePropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Hashtable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodSaveProperties, Fixture, methodSavePropertiesPrametersTypes);

            // Assert
            methodSavePropertiesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveProperties) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SaveProperties_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveProperties, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetDataSet_Method_Call_Internally(Type[] types)
        {
            var methodGetDataSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDataSet, Fixture, methodGetDataSetPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var sqlparams = CreateType<Hashtable>();
            var methodGetDataSetPrametersTypes = new Type[] { typeof(string), typeof(Hashtable) };
            object[] parametersOfGetDataSet = { sql, sqlparams };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataSet, methodGetDataSetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataSet>(_integrationCoreInstanceFixture, out exception1, parametersOfGetDataSet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataSet>(_integrationCoreInstance, MethodGetDataSet, parametersOfGetDataSet, methodGetDataSetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataSet.ShouldNotBeNull();
            parametersOfGetDataSet.Length.ShouldBe(2);
            methodGetDataSetPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetDataSet));
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var sqlparams = CreateType<Hashtable>();
            var methodGetDataSetPrametersTypes = new Type[] { typeof(string), typeof(Hashtable) };
            object[] parametersOfGetDataSet = { sql, sqlparams };

            // Assert
            parametersOfGetDataSet.ShouldNotBeNull();
            parametersOfGetDataSet.Length.ShouldBe(2);
            methodGetDataSetPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataSet>(_integrationCoreInstance, MethodGetDataSet, parametersOfGetDataSet, methodGetDataSetPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataSetPrametersTypes = new Type[] { typeof(string), typeof(Hashtable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDataSet, Fixture, methodGetDataSetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataSetPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataSetPrametersTypes = new Type[] { typeof(string), typeof(Hashtable) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDataSet, Fixture, methodGetDataSetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataSetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataSet, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataSet, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_ExecuteQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodExecuteQuery, Fixture, methodExecuteQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteQuery_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var sqlparams = CreateType<Hashtable>();
            var Close = CreateType<bool>();
            var methodExecuteQueryPrametersTypes = new Type[] { typeof(string), typeof(Hashtable), typeof(bool) };
            object[] parametersOfExecuteQuery = { sql, sqlparams, Close };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteQuery, methodExecuteQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfExecuteQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteQuery.ShouldNotBeNull();
            parametersOfExecuteQuery.Length.ShouldBe(3);
            methodExecuteQueryPrametersTypes.Length.ShouldBe(3);
            methodExecuteQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteQuery_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var sqlparams = CreateType<Hashtable>();
            var Close = CreateType<bool>();
            var methodExecuteQueryPrametersTypes = new Type[] { typeof(string), typeof(Hashtable), typeof(bool) };
            object[] parametersOfExecuteQuery = { sql, sqlparams, Close };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodExecuteQuery, parametersOfExecuteQuery, methodExecuteQueryPrametersTypes);

            // Assert
            parametersOfExecuteQuery.ShouldNotBeNull();
            parametersOfExecuteQuery.Length.ShouldBe(3);
            methodExecuteQueryPrametersTypes.Length.ShouldBe(3);
            methodExecuteQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteQuery, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteQueryPrametersTypes = new Type[] { typeof(string), typeof(Hashtable), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodExecuteQuery, Fixture, methodExecuteQueryPrametersTypes);

            // Assert
            methodExecuteQueryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ExecuteQuery_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDropDownProperties) (Return Type : Dictionary<String, String>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetDropDownProperties_Method_Call_Internally(Type[] types)
        {
            var methodGetDropDownPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDropDownProperties, Fixture, methodGetDropDownPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDropDownProperties) (Return Type : Dictionary<String, String>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDropDownProperties_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var moduleid = CreateType<Guid>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var property = CreateType<string>();
            var parentpropertvalue = CreateType<string>();
            var methodGetDropDownPropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownProperties = { moduleid, intlistid, listid, property, parentpropertvalue };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDropDownProperties, methodGetDropDownPropertiesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, Dictionary<String, String>>(_integrationCoreInstanceFixture, out exception1, parametersOfGetDropDownProperties);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, Dictionary<String, String>>(_integrationCoreInstance, MethodGetDropDownProperties, parametersOfGetDropDownProperties, methodGetDropDownPropertiesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDropDownProperties.ShouldNotBeNull();
            parametersOfGetDropDownProperties.Length.ShouldBe(5);
            methodGetDropDownPropertiesPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetDropDownProperties));
        }

        #endregion

        #region Method Call : (GetDropDownProperties) (Return Type : Dictionary<String, String>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDropDownProperties_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var moduleid = CreateType<Guid>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var property = CreateType<string>();
            var parentpropertvalue = CreateType<string>();
            var methodGetDropDownPropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfGetDropDownProperties = { moduleid, intlistid, listid, property, parentpropertvalue };

            // Assert
            parametersOfGetDropDownProperties.ShouldNotBeNull();
            parametersOfGetDropDownProperties.Length.ShouldBe(5);
            methodGetDropDownPropertiesPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, Dictionary<String, String>>(_integrationCoreInstance, MethodGetDropDownProperties, parametersOfGetDropDownProperties, methodGetDropDownPropertiesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDropDownProperties) (Return Type : Dictionary<String, String>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDropDownProperties_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDropDownPropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDropDownProperties, Fixture, methodGetDropDownPropertiesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDropDownPropertiesPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetDropDownProperties) (Return Type : Dictionary<String, String>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDropDownProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDropDownPropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDropDownProperties, Fixture, methodGetDropDownPropertiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDropDownPropertiesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDropDownProperties) (Return Type : Dictionary<String, String>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDropDownProperties_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDropDownProperties, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDropDownProperties) (Return Type : Dictionary<String, String>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDropDownProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDropDownProperties, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_TestModuleConnection_Method_Call_Internally(Type[] types)
        {
            var methodTestModuleConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodTestModuleConnection, Fixture, methodTestModuleConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var moduleid = CreateType<Guid>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var message = CreateType<string>();
            var methodTestModuleConnectionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfTestModuleConnection = { moduleid, intlistid, listid, message };

            // Assert
            parametersOfTestModuleConnection.ShouldNotBeNull();
            parametersOfTestModuleConnection.Length.ShouldBe(4);
            methodTestModuleConnectionPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodTestModuleConnection, parametersOfTestModuleConnection, methodTestModuleConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTestModuleConnectionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodTestModuleConnection, Fixture, methodTestModuleConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTestModuleConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTestModuleConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTestModuleConnection, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Properties = CreateType<Hashtable>();
            var moduleid = CreateType<Guid>();
            var intlistid = CreateType<Guid>();
            var list = CreateType<SPList>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid), typeof(Guid), typeof(SPList) };
            object[] parametersOfGetColumns = { Properties, moduleid, intlistid, list };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetColumns, methodGetColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, List<ColumnProperty>>(_integrationCoreInstanceFixture, out exception1, parametersOfGetColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, List<ColumnProperty>>(_integrationCoreInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(4);
            methodGetColumnsPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetColumns));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Properties = CreateType<Hashtable>();
            var moduleid = CreateType<Guid>();
            var intlistid = CreateType<Guid>();
            var list = CreateType<SPList>();
            var methodGetColumnsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid), typeof(Guid), typeof(SPList) };
            object[] parametersOfGetColumns = { Properties, moduleid, intlistid, list };

            // Assert
            parametersOfGetColumns.ShouldNotBeNull();
            parametersOfGetColumns.Length.ShouldBe(4);
            methodGetColumnsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, List<ColumnProperty>>(_integrationCoreInstance, MethodGetColumns, parametersOfGetColumns, methodGetColumnsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid), typeof(Guid), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnsPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid), typeof(Guid), typeof(SPList) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetColumns, Fixture, methodGetColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumns) (Return Type : List<ColumnProperty>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetColumns, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_TestModuleConnection_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodTestModuleConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodTestModuleConnection, Fixture, methodTestModuleConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var moduleid = CreateType<Guid>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var Properties = CreateType<Hashtable>();
            var message = CreateType<string>();
            var methodTestModuleConnectionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(Hashtable), typeof(string) };
            object[] parametersOfTestModuleConnection = { moduleid, intlistid, listid, Properties, message };

            // Assert
            parametersOfTestModuleConnection.ShouldNotBeNull();
            parametersOfTestModuleConnection.Length.ShouldBe(5);
            methodTestModuleConnectionPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodTestModuleConnection, parametersOfTestModuleConnection, methodTestModuleConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTestModuleConnectionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(Hashtable), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodTestModuleConnection, Fixture, methodTestModuleConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTestModuleConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTestModuleConnection, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (TestModuleConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_TestModuleConnection_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodTestModuleConnection, 1);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetModuleProperties) (Return Type : XmlDocument) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetModuleProperties_Method_Call_Internally(Type[] types)
        {
            var methodGetModulePropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetModuleProperties, Fixture, methodGetModulePropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetModuleProperties) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetModuleProperties_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var methodGetModulePropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            object[] parametersOfGetModuleProperties = { intlistid, moduleid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetModuleProperties, methodGetModulePropertiesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, XmlDocument>(_integrationCoreInstanceFixture, out exception1, parametersOfGetModuleProperties);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, XmlDocument>(_integrationCoreInstance, MethodGetModuleProperties, parametersOfGetModuleProperties, methodGetModulePropertiesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetModuleProperties.ShouldNotBeNull();
            parametersOfGetModuleProperties.Length.ShouldBe(2);
            methodGetModulePropertiesPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetModuleProperties));
        }

        #endregion

        #region Method Call : (GetModuleProperties) (Return Type : XmlDocument) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetModuleProperties_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var methodGetModulePropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            object[] parametersOfGetModuleProperties = { intlistid, moduleid };

            // Assert
            parametersOfGetModuleProperties.ShouldNotBeNull();
            parametersOfGetModuleProperties.Length.ShouldBe(2);
            methodGetModulePropertiesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, XmlDocument>(_integrationCoreInstance, MethodGetModuleProperties, parametersOfGetModuleProperties, methodGetModulePropertiesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetModuleProperties) (Return Type : XmlDocument) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetModuleProperties_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetModulePropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetModuleProperties, Fixture, methodGetModulePropertiesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetModulePropertiesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetModuleProperties) (Return Type : XmlDocument) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetModuleProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetModulePropertiesPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetModuleProperties, Fixture, methodGetModulePropertiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetModulePropertiesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetModuleProperties) (Return Type : XmlDocument) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetModuleProperties_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetModuleProperties, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetModuleProperties) (Return Type : XmlDocument) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetModuleProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetModuleProperties, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookupItem) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetLookupItem_Method_Call_Internally(Type[] types)
        {
            var methodGetLookupItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetLookupItem, Fixture, methodGetLookupItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetLookupItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetLookupItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listid = CreateType<string>();
            var intuid = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var methodGetLookupItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Guid), typeof(Guid) };
            object[] parametersOfGetLookupItem = { listid, intuid, intlistid, moduleid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetLookupItem, methodGetLookupItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, string>(_integrationCoreInstanceFixture, out exception1, parametersOfGetLookupItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetLookupItem, parametersOfGetLookupItem, methodGetLookupItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetLookupItem.ShouldNotBeNull();
            parametersOfGetLookupItem.Length.ShouldBe(4);
            methodGetLookupItemPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetLookupItem));
        }

        #endregion

        #region Method Call : (GetLookupItem) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetLookupItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<string>();
            var intuid = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var methodGetLookupItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Guid), typeof(Guid) };
            object[] parametersOfGetLookupItem = { listid, intuid, intlistid, moduleid };

            // Assert
            parametersOfGetLookupItem.ShouldNotBeNull();
            parametersOfGetLookupItem.Length.ShouldBe(4);
            methodGetLookupItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetLookupItem, parametersOfGetLookupItem, methodGetLookupItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetLookupItem) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetLookupItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetLookupItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Guid), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetLookupItem, Fixture, methodGetLookupItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetLookupItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetLookupItem) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetLookupItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetLookupItemPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(Guid), typeof(Guid) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetLookupItem, Fixture, methodGetLookupItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetLookupItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetLookupItem) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetLookupItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetLookupItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetLookupItem) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetLookupItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetLookupItem, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItemRow) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_ProcessItemRow_Method_Call_Internally(Type[] types)
        {
            var methodProcessItemRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItemRow, Fixture, methodProcessItemRowPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessItemRow) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemRow_Method_Call_Void_With_11_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var list = CreateType<SPList>();
            var dtColumns = CreateType<DataTable>();
            var Properties = CreateType<Hashtable>();
            var ColId = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var bCanAdd = CreateType<bool>();
            var dtUserFields = CreateType<DataTable>();
            var hshUserMap = CreateType<Hashtable>();
            var bBuildTeamSec = CreateType<bool>();
            var methodProcessItemRowPrametersTypes = new Type[] { typeof(DataRow), typeof(SPList), typeof(DataTable), typeof(Hashtable), typeof(string), typeof(Guid), typeof(Guid), typeof(bool), typeof(DataTable), typeof(Hashtable), typeof(bool) };
            object[] parametersOfProcessItemRow = { dr, list, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap, bBuildTeamSec };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessItemRow, methodProcessItemRowPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfProcessItemRow);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessItemRow.ShouldNotBeNull();
            parametersOfProcessItemRow.Length.ShouldBe(11);
            methodProcessItemRowPrametersTypes.Length.ShouldBe(11);
            methodProcessItemRowPrametersTypes.Length.ShouldBe(parametersOfProcessItemRow.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemRow) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemRow_Method_Call_Void_With_11_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var list = CreateType<SPList>();
            var dtColumns = CreateType<DataTable>();
            var Properties = CreateType<Hashtable>();
            var ColId = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var bCanAdd = CreateType<bool>();
            var dtUserFields = CreateType<DataTable>();
            var hshUserMap = CreateType<Hashtable>();
            var bBuildTeamSec = CreateType<bool>();
            var methodProcessItemRowPrametersTypes = new Type[] { typeof(DataRow), typeof(SPList), typeof(DataTable), typeof(Hashtable), typeof(string), typeof(Guid), typeof(Guid), typeof(bool), typeof(DataTable), typeof(Hashtable), typeof(bool) };
            object[] parametersOfProcessItemRow = { dr, list, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap, bBuildTeamSec };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodProcessItemRow, parametersOfProcessItemRow, methodProcessItemRowPrametersTypes);

            // Assert
            parametersOfProcessItemRow.ShouldNotBeNull();
            parametersOfProcessItemRow.Length.ShouldBe(11);
            methodProcessItemRowPrametersTypes.Length.ShouldBe(11);
            methodProcessItemRowPrametersTypes.Length.ShouldBe(parametersOfProcessItemRow.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemRow) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemRow_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessItemRow, 0);
            const int parametersCount = 11;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItemRow) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemRow_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessItemRowPrametersTypes = new Type[] { typeof(DataRow), typeof(SPList), typeof(DataTable), typeof(Hashtable), typeof(string), typeof(Guid), typeof(Guid), typeof(bool), typeof(DataTable), typeof(Hashtable), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItemRow, Fixture, methodProcessItemRowPrametersTypes);

            // Assert
            methodProcessItemRowPrametersTypes.Length.ShouldBe(11);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemRow) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemRow_Method_Call_With_11_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessItemRow, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (iProcessItemRow) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_iProcessItemRow_Method_Call_Internally(Type[] types)
        {
            var methodiProcessItemRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodiProcessItemRow, Fixture, methodiProcessItemRowPrametersTypes);
        }

        #endregion

        #region Method Call : (iProcessItemRow) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_iProcessItemRow_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var list = CreateType<SPList>();
            var dtColumns = CreateType<DataTable>();
            var Properties = CreateType<Hashtable>();
            var ColId = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var bCanAdd = CreateType<bool>();
            var dtUserFields = CreateType<DataTable>();
            var hshUserMap = CreateType<Hashtable>();
            var methodiProcessItemRowPrametersTypes = new Type[] { typeof(DataRow), typeof(SPList), typeof(DataTable), typeof(Hashtable), typeof(string), typeof(Guid), typeof(Guid), typeof(bool), typeof(DataTable), typeof(Hashtable) };
            object[] parametersOfiProcessItemRow = { dr, list, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiProcessItemRow, methodiProcessItemRowPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, int>(_integrationCoreInstanceFixture, out exception1, parametersOfiProcessItemRow);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, int>(_integrationCoreInstance, MethodiProcessItemRow, parametersOfiProcessItemRow, methodiProcessItemRowPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfiProcessItemRow.ShouldNotBeNull();
            parametersOfiProcessItemRow.Length.ShouldBe(10);
            methodiProcessItemRowPrametersTypes.Length.ShouldBe(10);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfiProcessItemRow));
        }

        #endregion

        #region Method Call : (iProcessItemRow) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_iProcessItemRow_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var list = CreateType<SPList>();
            var dtColumns = CreateType<DataTable>();
            var Properties = CreateType<Hashtable>();
            var ColId = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var bCanAdd = CreateType<bool>();
            var dtUserFields = CreateType<DataTable>();
            var hshUserMap = CreateType<Hashtable>();
            var methodiProcessItemRowPrametersTypes = new Type[] { typeof(DataRow), typeof(SPList), typeof(DataTable), typeof(Hashtable), typeof(string), typeof(Guid), typeof(Guid), typeof(bool), typeof(DataTable), typeof(Hashtable) };
            object[] parametersOfiProcessItemRow = { dr, list, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodiProcessItemRow, methodiProcessItemRowPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, int>(_integrationCoreInstanceFixture, out exception1, parametersOfiProcessItemRow);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, int>(_integrationCoreInstance, MethodiProcessItemRow, parametersOfiProcessItemRow, methodiProcessItemRowPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfiProcessItemRow.ShouldNotBeNull();
            parametersOfiProcessItemRow.Length.ShouldBe(10);
            methodiProcessItemRowPrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, int>(_integrationCoreInstance, MethodiProcessItemRow, parametersOfiProcessItemRow, methodiProcessItemRowPrametersTypes));
        }

        #endregion

        #region Method Call : (iProcessItemRow) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_iProcessItemRow_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var list = CreateType<SPList>();
            var dtColumns = CreateType<DataTable>();
            var Properties = CreateType<Hashtable>();
            var ColId = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var bCanAdd = CreateType<bool>();
            var dtUserFields = CreateType<DataTable>();
            var hshUserMap = CreateType<Hashtable>();
            var methodiProcessItemRowPrametersTypes = new Type[] { typeof(DataRow), typeof(SPList), typeof(DataTable), typeof(Hashtable), typeof(string), typeof(Guid), typeof(Guid), typeof(bool), typeof(DataTable), typeof(Hashtable) };
            object[] parametersOfiProcessItemRow = { dr, list, dtColumns, Properties, ColId, intlistid, moduleid, bCanAdd, dtUserFields, hshUserMap };

            // Assert
            parametersOfiProcessItemRow.ShouldNotBeNull();
            parametersOfiProcessItemRow.Length.ShouldBe(10);
            methodiProcessItemRowPrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, int>(_integrationCoreInstance, MethodiProcessItemRow, parametersOfiProcessItemRow, methodiProcessItemRowPrametersTypes));
        }

        #endregion

        #region Method Call : (iProcessItemRow) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_iProcessItemRow_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodiProcessItemRowPrametersTypes = new Type[] { typeof(DataRow), typeof(SPList), typeof(DataTable), typeof(Hashtable), typeof(string), typeof(Guid), typeof(Guid), typeof(bool), typeof(DataTable), typeof(Hashtable) };
            const int parametersCount = 10;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodiProcessItemRow, Fixture, methodiProcessItemRowPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodiProcessItemRowPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (iProcessItemRow) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_iProcessItemRow_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodiProcessItemRow, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (iProcessItemRow) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_iProcessItemRow_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodiProcessItemRow, 0);
            const int parametersCount = 10;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessLIItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_ProcessLIItem_Method_Call_Internally(Type[] types)
        {
            var methodProcessLIItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessLIItem, Fixture, methodProcessLIItemPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessLIItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessLIItem_Method_Call_Void_With_9_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var li = CreateType<SPListItem>();
            var dr = CreateType<DataRow>();
            var dtColumns = CreateType<DataTable>();
            var ColId = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var hshUserMap = CreateType<Hashtable>();
            var dtUserFields = CreateType<DataTable>();
            var methodProcessLIItemPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(DataRow), typeof(DataTable), typeof(string), typeof(Guid), typeof(Guid), typeof(Hashtable), typeof(DataTable) };
            object[] parametersOfProcessLIItem = { list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessLIItem, methodProcessLIItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfProcessLIItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessLIItem.ShouldNotBeNull();
            parametersOfProcessLIItem.Length.ShouldBe(9);
            methodProcessLIItemPrametersTypes.Length.ShouldBe(9);
            methodProcessLIItemPrametersTypes.Length.ShouldBe(parametersOfProcessLIItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLIItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessLIItem_Method_Call_Void_With_9_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var li = CreateType<SPListItem>();
            var dr = CreateType<DataRow>();
            var dtColumns = CreateType<DataTable>();
            var ColId = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var moduleid = CreateType<Guid>();
            var hshUserMap = CreateType<Hashtable>();
            var dtUserFields = CreateType<DataTable>();
            var methodProcessLIItemPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(DataRow), typeof(DataTable), typeof(string), typeof(Guid), typeof(Guid), typeof(Hashtable), typeof(DataTable) };
            object[] parametersOfProcessLIItem = { list, li, dr, dtColumns, ColId, intlistid, moduleid, hshUserMap, dtUserFields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodProcessLIItem, parametersOfProcessLIItem, methodProcessLIItemPrametersTypes);

            // Assert
            parametersOfProcessLIItem.ShouldNotBeNull();
            parametersOfProcessLIItem.Length.ShouldBe(9);
            methodProcessLIItemPrametersTypes.Length.ShouldBe(9);
            methodProcessLIItemPrametersTypes.Length.ShouldBe(parametersOfProcessLIItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLIItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessLIItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessLIItem, 0);
            const int parametersCount = 9;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessLIItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessLIItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessLIItemPrametersTypes = new Type[] { typeof(SPList), typeof(SPListItem), typeof(DataRow), typeof(DataTable), typeof(string), typeof(Guid), typeof(Guid), typeof(Hashtable), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessLIItem, Fixture, methodProcessLIItemPrametersTypes);

            // Assert
            methodProcessLIItemPrametersTypes.Length.ShouldBe(9);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessLIItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessLIItem_Method_Call_With_9_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessLIItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemIncoming) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_ProcessItemIncoming_Method_Call_Internally(Type[] types)
        {
            var methodProcessItemIncomingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItemIncoming, Fixture, methodProcessItemIncomingPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessItemIncoming) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemIncoming_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodProcessItemIncomingPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfProcessItemIncoming = { dr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessItemIncoming, methodProcessItemIncomingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfProcessItemIncoming);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessItemIncoming.ShouldNotBeNull();
            parametersOfProcessItemIncoming.Length.ShouldBe(1);
            methodProcessItemIncomingPrametersTypes.Length.ShouldBe(1);
            methodProcessItemIncomingPrametersTypes.Length.ShouldBe(parametersOfProcessItemIncoming.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemIncoming) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemIncoming_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodProcessItemIncomingPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfProcessItemIncoming = { dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodProcessItemIncoming, parametersOfProcessItemIncoming, methodProcessItemIncomingPrametersTypes);

            // Assert
            parametersOfProcessItemIncoming.ShouldNotBeNull();
            parametersOfProcessItemIncoming.Length.ShouldBe(1);
            methodProcessItemIncomingPrametersTypes.Length.ShouldBe(1);
            methodProcessItemIncomingPrametersTypes.Length.ShouldBe(parametersOfProcessItemIncoming.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemIncoming) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemIncoming_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessItemIncoming, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItemIncoming) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemIncoming_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessItemIncomingPrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItemIncoming, Fixture, methodProcessItemIncomingPrametersTypes);

            // Assert
            methodProcessItemIncomingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemIncoming) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemIncoming_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessItemIncoming, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSharePointItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_DeleteSharePointItem_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSharePointItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodDeleteSharePointItem, Fixture, methodDeleteSharePointItemPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSharePointItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_DeleteSharePointItem_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var intuid = CreateType<string>();
            var col = CreateType<string>();
            var methodDeleteSharePointItemPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string) };
            object[] parametersOfDeleteSharePointItem = { list, intuid, col };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteSharePointItem, methodDeleteSharePointItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfDeleteSharePointItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteSharePointItem.ShouldNotBeNull();
            parametersOfDeleteSharePointItem.Length.ShouldBe(3);
            methodDeleteSharePointItemPrametersTypes.Length.ShouldBe(3);
            methodDeleteSharePointItemPrametersTypes.Length.ShouldBe(parametersOfDeleteSharePointItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSharePointItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_DeleteSharePointItem_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var intuid = CreateType<string>();
            var col = CreateType<string>();
            var methodDeleteSharePointItemPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string) };
            object[] parametersOfDeleteSharePointItem = { list, intuid, col };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodDeleteSharePointItem, parametersOfDeleteSharePointItem, methodDeleteSharePointItemPrametersTypes);

            // Assert
            parametersOfDeleteSharePointItem.ShouldNotBeNull();
            parametersOfDeleteSharePointItem.Length.ShouldBe(3);
            methodDeleteSharePointItemPrametersTypes.Length.ShouldBe(3);
            methodDeleteSharePointItemPrametersTypes.Length.ShouldBe(parametersOfDeleteSharePointItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSharePointItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_DeleteSharePointItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteSharePointItem, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteSharePointItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_DeleteSharePointItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteSharePointItemPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodDeleteSharePointItem, Fixture, methodDeleteSharePointItemPrametersTypes);

            // Assert
            methodDeleteSharePointItemPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSharePointItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_DeleteSharePointItem_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteSharePointItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePriorityNumbers) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_UpdatePriorityNumbers_Method_Call_Internally(Type[] types)
        {
            var methodUpdatePriorityNumbersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodUpdatePriorityNumbers, Fixture, methodUpdatePriorityNumbersPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdatePriorityNumbers) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_UpdatePriorityNumbers_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var methodUpdatePriorityNumbersPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfUpdatePriorityNumbers = { listid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdatePriorityNumbers, methodUpdatePriorityNumbersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfUpdatePriorityNumbers);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdatePriorityNumbers.ShouldNotBeNull();
            parametersOfUpdatePriorityNumbers.Length.ShouldBe(1);
            methodUpdatePriorityNumbersPrametersTypes.Length.ShouldBe(1);
            methodUpdatePriorityNumbersPrametersTypes.Length.ShouldBe(parametersOfUpdatePriorityNumbers.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePriorityNumbers) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_UpdatePriorityNumbers_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var methodUpdatePriorityNumbersPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfUpdatePriorityNumbers = { listid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodUpdatePriorityNumbers, parametersOfUpdatePriorityNumbers, methodUpdatePriorityNumbersPrametersTypes);

            // Assert
            parametersOfUpdatePriorityNumbers.ShouldNotBeNull();
            parametersOfUpdatePriorityNumbers.Length.ShouldBe(1);
            methodUpdatePriorityNumbersPrametersTypes.Length.ShouldBe(1);
            methodUpdatePriorityNumbersPrametersTypes.Length.ShouldBe(parametersOfUpdatePriorityNumbers.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePriorityNumbers) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_UpdatePriorityNumbers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdatePriorityNumbers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdatePriorityNumbers) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_UpdatePriorityNumbers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdatePriorityNumbersPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodUpdatePriorityNumbers, Fixture, methodUpdatePriorityNumbersPrametersTypes);

            // Assert
            methodUpdatePriorityNumbersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdatePriorityNumbers) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_UpdatePriorityNumbers_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdatePriorityNumbers, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemOutgoing) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_ProcessItemOutgoing_Method_Call_Internally(Type[] types)
        {
            var methodProcessItemOutgoingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItemOutgoing, Fixture, methodProcessItemOutgoingPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessItemOutgoing) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemOutgoing_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodProcessItemOutgoingPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfProcessItemOutgoing = { dr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessItemOutgoing, methodProcessItemOutgoingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfProcessItemOutgoing);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessItemOutgoing.ShouldNotBeNull();
            parametersOfProcessItemOutgoing.Length.ShouldBe(1);
            methodProcessItemOutgoingPrametersTypes.Length.ShouldBe(1);
            methodProcessItemOutgoingPrametersTypes.Length.ShouldBe(parametersOfProcessItemOutgoing.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemOutgoing) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemOutgoing_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dr = CreateType<DataRow>();
            var methodProcessItemOutgoingPrametersTypes = new Type[] { typeof(DataRow) };
            object[] parametersOfProcessItemOutgoing = { dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodProcessItemOutgoing, parametersOfProcessItemOutgoing, methodProcessItemOutgoingPrametersTypes);

            // Assert
            parametersOfProcessItemOutgoing.ShouldNotBeNull();
            parametersOfProcessItemOutgoing.Length.ShouldBe(1);
            methodProcessItemOutgoingPrametersTypes.Length.ShouldBe(1);
            methodProcessItemOutgoingPrametersTypes.Length.ShouldBe(parametersOfProcessItemOutgoing.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemOutgoing) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemOutgoing_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessItemOutgoing, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItemOutgoing) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemOutgoing_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessItemOutgoingPrametersTypes = new Type[] { typeof(DataRow) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItemOutgoing, Fixture, methodProcessItemOutgoingPrametersTypes);

            // Assert
            methodProcessItemOutgoingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItemOutgoing) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItemOutgoing_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessItemOutgoing, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_LogMessage_Method_Call_Internally(Type[] types)
        {
            var methodLogMessagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_LogMessage_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var intlistid = CreateType<string>();
            var listid = CreateType<string>();
            var message = CreateType<string>();
            var type = CreateType<int>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfLogMessage = { intlistid, listid, message, type };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLogMessage, methodLogMessagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfLogMessage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_LogMessage_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<string>();
            var listid = CreateType<string>();
            var message = CreateType<string>();
            var type = CreateType<int>();
            var methodLogMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfLogMessage = { intlistid, listid, message, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodLogMessage, parametersOfLogMessage, methodLogMessagePrametersTypes);

            // Assert
            parametersOfLogMessage.ShouldNotBeNull();
            parametersOfLogMessage.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(4);
            methodLogMessagePrametersTypes.Length.ShouldBe(parametersOfLogMessage.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_LogMessage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogMessage, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_LogMessage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogMessagePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodLogMessage, Fixture, methodLogMessagePrametersTypes);

            // Assert
            methodLogMessagePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogMessage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_LogMessage_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogMessage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserMap) (Return Type : Hashtable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetUserMap_Method_Call_Internally(Type[] types)
        {
            var methodGetUserMapPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetUserMap, Fixture, methodGetUserMapPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserMap) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetUserMap_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var integrationlistid = CreateType<string>();
            var reverse = CreateType<bool>();
            var methodGetUserMapPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetUserMap = { integrationlistid, reverse };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUserMap, methodGetUserMapPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, Hashtable>(_integrationCoreInstanceFixture, out exception1, parametersOfGetUserMap);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, Hashtable>(_integrationCoreInstance, MethodGetUserMap, parametersOfGetUserMap, methodGetUserMapPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUserMap.ShouldNotBeNull();
            parametersOfGetUserMap.Length.ShouldBe(2);
            methodGetUserMapPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetUserMap));
        }

        #endregion

        #region Method Call : (GetUserMap) (Return Type : Hashtable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetUserMap_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var integrationlistid = CreateType<string>();
            var reverse = CreateType<bool>();
            var methodGetUserMapPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfGetUserMap = { integrationlistid, reverse };

            // Assert
            parametersOfGetUserMap.ShouldNotBeNull();
            parametersOfGetUserMap.Length.ShouldBe(2);
            methodGetUserMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, Hashtable>(_integrationCoreInstance, MethodGetUserMap, parametersOfGetUserMap, methodGetUserMapPrametersTypes));
        }

        #endregion

        #region Method Call : (GetUserMap) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetUserMap_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserMapPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetUserMap, Fixture, methodGetUserMapPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserMapPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetUserMap) (Return Type : Hashtable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetUserMap_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserMapPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetUserMap, Fixture, methodGetUserMapPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserMapPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserMap) (Return Type : Hashtable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetUserMap_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserMap, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserMap) (Return Type : Hashtable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetUserMap_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserMap, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostIntegration) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_PostIntegration_Method_Call_Internally(Type[] types)
        {
            var methodPostIntegrationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostIntegration, Fixture, methodPostIntegrationPrametersTypes);
        }

        #endregion

        #region Method Call : (PostIntegration) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegration_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var dtUserFields = CreateType<DataTable>();
            var dtColumns = CreateType<DataTable>();
            var list = CreateType<SPList>();
            var methodPostIntegrationPrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable), typeof(DataTable), typeof(SPList) };
            object[] parametersOfPostIntegration = { dtItems, dtUserFields, dtColumns, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPostIntegration, methodPostIntegrationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfPostIntegration);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPostIntegration.ShouldNotBeNull();
            parametersOfPostIntegration.Length.ShouldBe(4);
            methodPostIntegrationPrametersTypes.Length.ShouldBe(4);
            methodPostIntegrationPrametersTypes.Length.ShouldBe(parametersOfPostIntegration.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PostIntegration) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegration_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var dtUserFields = CreateType<DataTable>();
            var dtColumns = CreateType<DataTable>();
            var list = CreateType<SPList>();
            var methodPostIntegrationPrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable), typeof(DataTable), typeof(SPList) };
            object[] parametersOfPostIntegration = { dtItems, dtUserFields, dtColumns, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodPostIntegration, parametersOfPostIntegration, methodPostIntegrationPrametersTypes);

            // Assert
            parametersOfPostIntegration.ShouldNotBeNull();
            parametersOfPostIntegration.Length.ShouldBe(4);
            methodPostIntegrationPrametersTypes.Length.ShouldBe(4);
            methodPostIntegrationPrametersTypes.Length.ShouldBe(parametersOfPostIntegration.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostIntegration) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegration_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostIntegration, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostIntegration) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegration_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostIntegrationPrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable), typeof(DataTable), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostIntegration, Fixture, methodPostIntegrationPrametersTypes);

            // Assert
            methodPostIntegrationPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostIntegration) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegration_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostIntegration, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostCheckBit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_PostCheckBit_Method_Call_Internally(Type[] types)
        {
            var methodPostCheckBitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostCheckBit, Fixture, methodPostCheckBitPrametersTypes);
        }

        #endregion

        #region Method Call : (PostCheckBit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostCheckBit_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var itemid = CreateType<string>();
            var bCheck = CreateType<bool>();
            var methodPostCheckBitPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool) };
            object[] parametersOfPostCheckBit = { intlistid, itemid, bCheck };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPostCheckBit, methodPostCheckBitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfPostCheckBit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPostCheckBit.ShouldNotBeNull();
            parametersOfPostCheckBit.Length.ShouldBe(3);
            methodPostCheckBitPrametersTypes.Length.ShouldBe(3);
            methodPostCheckBitPrametersTypes.Length.ShouldBe(parametersOfPostCheckBit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PostCheckBit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostCheckBit_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var itemid = CreateType<string>();
            var bCheck = CreateType<bool>();
            var methodPostCheckBitPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool) };
            object[] parametersOfPostCheckBit = { intlistid, itemid, bCheck };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodPostCheckBit, parametersOfPostCheckBit, methodPostCheckBitPrametersTypes);

            // Assert
            parametersOfPostCheckBit.ShouldNotBeNull();
            parametersOfPostCheckBit.Length.ShouldBe(3);
            methodPostCheckBitPrametersTypes.Length.ShouldBe(3);
            methodPostCheckBitPrametersTypes.Length.ShouldBe(parametersOfPostCheckBit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostCheckBit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostCheckBit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostCheckBit, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostCheckBit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostCheckBit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostCheckBitPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostCheckBit, Fixture, methodPostCheckBitPrametersTypes);

            // Assert
            methodPostCheckBitPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostCheckBit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostCheckBit_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostCheckBit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostIntegrationDeleteToExternal) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_PostIntegrationDeleteToExternal_Method_Call_Internally(Type[] types)
        {
            var methodPostIntegrationDeleteToExternalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostIntegrationDeleteToExternal, Fixture, methodPostIntegrationDeleteToExternalPrametersTypes);
        }

        #endregion

        #region Method Call : (PostIntegrationDeleteToExternal) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationDeleteToExternal_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var methodPostIntegrationDeleteToExternalPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid) };
            object[] parametersOfPostIntegrationDeleteToExternal = { dtItems, intlistid, listid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPostIntegrationDeleteToExternal, methodPostIntegrationDeleteToExternalPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfPostIntegrationDeleteToExternal);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPostIntegrationDeleteToExternal.ShouldNotBeNull();
            parametersOfPostIntegrationDeleteToExternal.Length.ShouldBe(3);
            methodPostIntegrationDeleteToExternalPrametersTypes.Length.ShouldBe(3);
            methodPostIntegrationDeleteToExternalPrametersTypes.Length.ShouldBe(parametersOfPostIntegrationDeleteToExternal.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PostIntegrationDeleteToExternal) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationDeleteToExternal_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var methodPostIntegrationDeleteToExternalPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid) };
            object[] parametersOfPostIntegrationDeleteToExternal = { dtItems, intlistid, listid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodPostIntegrationDeleteToExternal, parametersOfPostIntegrationDeleteToExternal, methodPostIntegrationDeleteToExternalPrametersTypes);

            // Assert
            parametersOfPostIntegrationDeleteToExternal.ShouldNotBeNull();
            parametersOfPostIntegrationDeleteToExternal.Length.ShouldBe(3);
            methodPostIntegrationDeleteToExternalPrametersTypes.Length.ShouldBe(3);
            methodPostIntegrationDeleteToExternalPrametersTypes.Length.ShouldBe(parametersOfPostIntegrationDeleteToExternal.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostIntegrationDeleteToExternal) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationDeleteToExternal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostIntegrationDeleteToExternal, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostIntegrationDeleteToExternal) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationDeleteToExternal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostIntegrationDeleteToExternalPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostIntegrationDeleteToExternal, Fixture, methodPostIntegrationDeleteToExternalPrametersTypes);

            // Assert
            methodPostIntegrationDeleteToExternalPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostIntegrationDeleteToExternal) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationDeleteToExternal_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostIntegrationDeleteToExternal, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetControlURL_Method_Call_Internally(Type[] types)
        {
            var methodGetControlURLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetControlURL, Fixture, methodGetControlURLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetControlURL_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var control = CreateType<string>();
            var ItemId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetControlURL(intlistid, listid, control, ItemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetControlURL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var control = CreateType<string>();
            var ItemId = CreateType<string>();
            var methodGetControlURLPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfGetControlURL = { intlistid, listid, control, ItemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetControlURL, methodGetControlURLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, string>(_integrationCoreInstanceFixture, out exception1, parametersOfGetControlURL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetControlURL, parametersOfGetControlURL, methodGetControlURLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetControlURL.ShouldNotBeNull();
            parametersOfGetControlURL.Length.ShouldBe(4);
            methodGetControlURLPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetControlURL));
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetControlURL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var control = CreateType<string>();
            var ItemId = CreateType<string>();
            var methodGetControlURLPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            object[] parametersOfGetControlURL = { intlistid, listid, control, ItemId };

            // Assert
            parametersOfGetControlURL.ShouldNotBeNull();
            parametersOfGetControlURL.Length.ShouldBe(4);
            methodGetControlURLPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetControlURL, parametersOfGetControlURL, methodGetControlURLPrametersTypes));
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetControlURL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetControlURLPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetControlURL, Fixture, methodGetControlURLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetControlURLPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetControlURL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetControlURLPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetControlURL, Fixture, methodGetControlURLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetControlURLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetControlURL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetControlURL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetControlURL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetControlURL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetControlURL, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemButtons) (Return Type : List<IntegrationControl>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetItemButtons_Method_Call_Internally(Type[] types)
        {
            var methodGetItemButtonsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetItemButtons, Fixture, methodGetItemButtonsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetItemButtons) (Return Type : List<IntegrationControl>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetItemButtons_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var li = CreateType<SPListItem>();
            var Errors = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetItemButtons(listid, li, out Errors);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetItemButtons) (Return Type : List<IntegrationControl>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetItemButtons_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var li = CreateType<SPListItem>();
            var Errors = CreateType<string>();
            var methodGetItemButtonsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            object[] parametersOfGetItemButtons = { listid, li, Errors };

            // Assert
            parametersOfGetItemButtons.ShouldNotBeNull();
            parametersOfGetItemButtons.Length.ShouldBe(3);
            methodGetItemButtonsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, List<IntegrationControl>>(_integrationCoreInstance, MethodGetItemButtons, parametersOfGetItemButtons, methodGetItemButtonsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetItemButtons) (Return Type : List<IntegrationControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetItemButtons_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetItemButtonsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetItemButtons, Fixture, methodGetItemButtonsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetItemButtonsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetItemButtons) (Return Type : List<IntegrationControl>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetItemButtons_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetItemButtonsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetItemButtons, Fixture, methodGetItemButtonsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetItemButtonsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetItemButtons) (Return Type : List<IntegrationControl>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetItemButtons_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetItemButtons, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetItemButtons) (Return Type : List<IntegrationControl>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetItemButtons_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetItemButtons, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGlobalButtons) (Return Type : List<IntegrationControl>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetGlobalButtons_Method_Call_Internally(Type[] types)
        {
            var methodGetGlobalButtonsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetGlobalButtons, Fixture, methodGetGlobalButtonsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetGlobalButtons) (Return Type : List<IntegrationControl>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetGlobalButtons_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var li = CreateType<SPListItem>();
            var Errors = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetGlobalButtons(listid, li, out Errors);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetGlobalButtons) (Return Type : List<IntegrationControl>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetGlobalButtons_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var li = CreateType<SPListItem>();
            var Errors = CreateType<string>();
            var methodGetGlobalButtonsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            object[] parametersOfGetGlobalButtons = { listid, li, Errors };

            // Assert
            parametersOfGetGlobalButtons.ShouldNotBeNull();
            parametersOfGetGlobalButtons.Length.ShouldBe(3);
            methodGetGlobalButtonsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, List<IntegrationControl>>(_integrationCoreInstance, MethodGetGlobalButtons, parametersOfGetGlobalButtons, methodGetGlobalButtonsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetGlobalButtons) (Return Type : List<IntegrationControl>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetGlobalButtons_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetGlobalButtonsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetGlobalButtons, Fixture, methodGetGlobalButtonsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetGlobalButtonsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetGlobalButtons) (Return Type : List<IntegrationControl>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetGlobalButtons_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetGlobalButtonsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetGlobalButtons, Fixture, methodGetGlobalButtonsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetGlobalButtonsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetGlobalButtons) (Return Type : List<IntegrationControl>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetGlobalButtons_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetGlobalButtons, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetGlobalButtons) (Return Type : List<IntegrationControl>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetGlobalButtons_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetGlobalButtons, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEmbbededControls) (Return Type : List<IntegrationControlDef>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetEmbbededControls_Method_Call_Internally(Type[] types)
        {
            var methodGetEmbbededControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetEmbbededControls, Fixture, methodGetEmbbededControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetEmbbededControls) (Return Type : List<IntegrationControlDef>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetEmbbededControls_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var li = CreateType<SPListItem>();
            var Errors = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationCoreInstance.GetEmbbededControls(listid, li, out Errors);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetEmbbededControls) (Return Type : List<IntegrationControlDef>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetEmbbededControls_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listid = CreateType<Guid>();
            var li = CreateType<SPListItem>();
            var Errors = CreateType<string>();
            var methodGetEmbbededControlsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            object[] parametersOfGetEmbbededControls = { listid, li, Errors };

            // Assert
            parametersOfGetEmbbededControls.ShouldNotBeNull();
            parametersOfGetEmbbededControls.Length.ShouldBe(3);
            methodGetEmbbededControlsPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, List<IntegrationControlDef>>(_integrationCoreInstance, MethodGetEmbbededControls, parametersOfGetEmbbededControls, methodGetEmbbededControlsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetEmbbededControls) (Return Type : List<IntegrationControlDef>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetEmbbededControls_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetEmbbededControlsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetEmbbededControls, Fixture, methodGetEmbbededControlsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetEmbbededControlsPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetEmbbededControls) (Return Type : List<IntegrationControlDef>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetEmbbededControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetEmbbededControlsPrametersTypes = new Type[] { typeof(Guid), typeof(SPListItem), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetEmbbededControls, Fixture, methodGetEmbbededControlsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetEmbbededControlsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetEmbbededControls) (Return Type : List<IntegrationControlDef>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetEmbbededControls_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetEmbbededControls, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetEmbbededControls) (Return Type : List<IntegrationControlDef>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetEmbbededControls_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetEmbbededControls, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_PullData_Method_Call_Internally(Type[] types)
        {
            var methodPullDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PullData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var dtLastSynched = CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(DateTime) };
            object[] parametersOfPullData = { dtItems, intlistid, listid, dtLastSynched };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPullData, methodPullDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataTable>(_integrationCoreInstanceFixture, out exception1, parametersOfPullData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfPullData));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PullData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var dtLastSynched = CreateType<DateTime>();
            var methodPullDataPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(DateTime) };
            object[] parametersOfPullData = { dtItems, intlistid, listid, dtLastSynched };

            // Assert
            parametersOfPullData.ShouldNotBeNull();
            parametersOfPullData.Length.ShouldBe(4);
            methodPullDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodPullData, parametersOfPullData, methodPullDataPrametersTypes));
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PullData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPullDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PullData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPullDataPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(DateTime) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPullData, Fixture, methodPullDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPullDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PullData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPullData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PullData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PullData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPullData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostIntegrationUpdateToExternal) (Return Type : TransactionTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_PostIntegrationUpdateToExternal_Method_Call_Internally(Type[] types)
        {
            var methodPostIntegrationUpdateToExternalPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostIntegrationUpdateToExternal, Fixture, methodPostIntegrationUpdateToExternalPrametersTypes);
        }

        #endregion

        #region Method Call : (PostIntegrationUpdateToExternal) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationUpdateToExternal_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var methodPostIntegrationUpdateToExternalPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid) };
            object[] parametersOfPostIntegrationUpdateToExternal = { dtItems, intlistid, listid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostIntegrationUpdateToExternal, methodPostIntegrationUpdateToExternalPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, TransactionTable>(_integrationCoreInstanceFixture, out exception1, parametersOfPostIntegrationUpdateToExternal);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, TransactionTable>(_integrationCoreInstance, MethodPostIntegrationUpdateToExternal, parametersOfPostIntegrationUpdateToExternal, methodPostIntegrationUpdateToExternalPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPostIntegrationUpdateToExternal.ShouldNotBeNull();
            parametersOfPostIntegrationUpdateToExternal.Length.ShouldBe(3);
            methodPostIntegrationUpdateToExternalPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfPostIntegrationUpdateToExternal));
        }

        #endregion

        #region Method Call : (PostIntegrationUpdateToExternal) (Return Type : TransactionTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationUpdateToExternal_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var methodPostIntegrationUpdateToExternalPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid) };
            object[] parametersOfPostIntegrationUpdateToExternal = { dtItems, intlistid, listid };

            // Assert
            parametersOfPostIntegrationUpdateToExternal.ShouldNotBeNull();
            parametersOfPostIntegrationUpdateToExternal.Length.ShouldBe(3);
            methodPostIntegrationUpdateToExternalPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, TransactionTable>(_integrationCoreInstance, MethodPostIntegrationUpdateToExternal, parametersOfPostIntegrationUpdateToExternal, methodPostIntegrationUpdateToExternalPrametersTypes));
        }

        #endregion

        #region Method Call : (PostIntegrationUpdateToExternal) (Return Type : TransactionTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationUpdateToExternal_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPostIntegrationUpdateToExternalPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostIntegrationUpdateToExternal, Fixture, methodPostIntegrationUpdateToExternalPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPostIntegrationUpdateToExternalPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (PostIntegrationUpdateToExternal) (Return Type : TransactionTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationUpdateToExternal_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostIntegrationUpdateToExternalPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodPostIntegrationUpdateToExternal, Fixture, methodPostIntegrationUpdateToExternalPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPostIntegrationUpdateToExternalPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostIntegrationUpdateToExternal) (Return Type : TransactionTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationUpdateToExternal_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostIntegrationUpdateToExternal, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostIntegrationUpdateToExternal) (Return Type : TransactionTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_PostIntegrationUpdateToExternal_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostIntegrationUpdateToExternal, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalItem) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetExternalItem_Method_Call_Internally(Type[] types)
        {
            var methodGetExternalItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetExternalItem, Fixture, methodGetExternalItemPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExternalItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetExternalItem_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var itemid = CreateType<string>();
            var methodGetExternalItemPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetExternalItem = { dtItems, intlistid, listid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetExternalItem, methodGetExternalItemPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataTable>(_integrationCoreInstanceFixture, out exception1, parametersOfGetExternalItem);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetExternalItem, parametersOfGetExternalItem, methodGetExternalItemPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetExternalItem.ShouldNotBeNull();
            parametersOfGetExternalItem.Length.ShouldBe(4);
            methodGetExternalItemPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetExternalItem));
        }

        #endregion

        #region Method Call : (GetExternalItem) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetExternalItem_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtItems = CreateType<DataTable>();
            var intlistid = CreateType<Guid>();
            var listid = CreateType<Guid>();
            var itemid = CreateType<string>();
            var methodGetExternalItemPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(string) };
            object[] parametersOfGetExternalItem = { dtItems, intlistid, listid, itemid };

            // Assert
            parametersOfGetExternalItem.ShouldNotBeNull();
            parametersOfGetExternalItem.Length.ShouldBe(4);
            methodGetExternalItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataTable>(_integrationCoreInstance, MethodGetExternalItem, parametersOfGetExternalItem, methodGetExternalItemPrametersTypes));
        }

        #endregion

        #region Method Call : (GetExternalItem) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetExternalItem_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetExternalItemPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetExternalItem, Fixture, methodGetExternalItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExternalItemPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetExternalItem) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetExternalItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExternalItemPrametersTypes = new Type[] { typeof(DataTable), typeof(Guid), typeof(Guid), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetExternalItem, Fixture, methodGetExternalItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExternalItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExternalItem) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetExternalItem_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExternalItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetExternalItem) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetExternalItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExternalItem, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetProxyResult_Method_Call_Internally(Type[] types)
        {
            var methodGetProxyResultPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProxyResult_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var ItemId = CreateType<string>();
            var Control = CreateType<string>();
            var Property = CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { intlistid, ItemId, Control, Property };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetProxyResult, methodGetProxyResultPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, string>(_integrationCoreInstanceFixture, out exception1, parametersOfGetProxyResult);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetProxyResult, parametersOfGetProxyResult, methodGetProxyResultPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetProxyResult.ShouldNotBeNull();
            parametersOfGetProxyResult.Length.ShouldBe(4);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetProxyResult));
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProxyResult_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var ItemId = CreateType<string>();
            var Control = CreateType<string>();
            var Property = CreateType<string>();
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetProxyResult = { intlistid, ItemId, Control, Property };

            // Assert
            parametersOfGetProxyResult.ShouldNotBeNull();
            parametersOfGetProxyResult.Length.ShouldBe(4);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetProxyResult, parametersOfGetProxyResult, methodGetProxyResultPrametersTypes));
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProxyResult_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetProxyResultPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProxyResult_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetProxyResultPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetProxyResult, Fixture, methodGetProxyResultPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetProxyResultPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProxyResult_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProxyResult, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProxyResult) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProxyResult_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProxyResult, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebProps) (Return Type : WebProperties) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetWebProps_Method_Call_Internally(Type[] types)
        {
            var methodGetWebPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetWebProps, Fixture, methodGetWebPropsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebProps) (Return Type : WebProperties) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetWebProps_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var Props = CreateType<Hashtable>();
            var intlistid = CreateType<Guid>();
            var methodGetWebPropsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid) };
            object[] parametersOfGetWebProps = { Props, intlistid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWebProps, methodGetWebPropsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, WebProperties>(_integrationCoreInstanceFixture, out exception1, parametersOfGetWebProps);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, WebProperties>(_integrationCoreInstance, MethodGetWebProps, parametersOfGetWebProps, methodGetWebPropsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWebProps.ShouldNotBeNull();
            parametersOfGetWebProps.Length.ShouldBe(2);
            methodGetWebPropsPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetWebProps));
        }

        #endregion

        #region Method Call : (GetWebProps) (Return Type : WebProperties) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetWebProps_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Props = CreateType<Hashtable>();
            var intlistid = CreateType<Guid>();
            var methodGetWebPropsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid) };
            object[] parametersOfGetWebProps = { Props, intlistid };

            // Assert
            parametersOfGetWebProps.ShouldNotBeNull();
            parametersOfGetWebProps.Length.ShouldBe(2);
            methodGetWebPropsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, WebProperties>(_integrationCoreInstance, MethodGetWebProps, parametersOfGetWebProps, methodGetWebPropsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWebProps) (Return Type : WebProperties) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetWebProps_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWebPropsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetWebProps, Fixture, methodGetWebPropsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWebPropsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetWebProps) (Return Type : WebProperties) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetWebProps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebPropsPrametersTypes = new Type[] { typeof(Hashtable), typeof(Guid) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetWebProps, Fixture, methodGetWebPropsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebPropsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebProps) (Return Type : WebProperties) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetWebProps_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebProps, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWebProps) (Return Type : WebProperties) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetWebProps_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebProps, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProperties) (Return Type : Hashtable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetProperties_Method_Call_Internally(Type[] types)
        {
            var methodGetPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetProperties, Fixture, methodGetPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetProperties) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProperties_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var methodGetPropertiesPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetProperties = { intlistid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetProperties, methodGetPropertiesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, Hashtable>(_integrationCoreInstanceFixture, out exception1, parametersOfGetProperties);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, Hashtable>(_integrationCoreInstance, MethodGetProperties, parametersOfGetProperties, methodGetPropertiesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetProperties.ShouldNotBeNull();
            parametersOfGetProperties.Length.ShouldBe(1);
            methodGetPropertiesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetProperties));
        }

        #endregion

        #region Method Call : (GetProperties) (Return Type : Hashtable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProperties_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var methodGetPropertiesPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetProperties = { intlistid };

            // Assert
            parametersOfGetProperties.ShouldNotBeNull();
            parametersOfGetProperties.Length.ShouldBe(1);
            methodGetPropertiesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, Hashtable>(_integrationCoreInstance, MethodGetProperties, parametersOfGetProperties, methodGetPropertiesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetProperties) (Return Type : Hashtable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProperties_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPropertiesPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetProperties, Fixture, methodGetPropertiesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPropertiesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetProperties) (Return Type : Hashtable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPropertiesPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetProperties, Fixture, methodGetPropertiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPropertiesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetProperties) (Return Type : Hashtable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProperties_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetProperties, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetProperties) (Return Type : Hashtable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetProperties_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetProperties, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrator) (Return Type : IntegratorDef) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetIntegrator_Method_Call_Internally(Type[] types)
        {
            var methodGetIntegratorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrator, Fixture, methodGetIntegratorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntegrator) (Return Type : IntegratorDef) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrator_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntegratorPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrator, Fixture, methodGetIntegratorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetIntegratorPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetIntegrator) (Return Type : IntegratorDef) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrator_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntegratorPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegrator, Fixture, methodGetIntegratorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntegratorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegrator) (Return Type : IntegratorDef) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrator_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntegrator, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntegrator) (Return Type : IntegratorDef) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegrator_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntegrator, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegratorFromModule) (Return Type : IIntegrator) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetIntegratorFromModule_Method_Call_Internally(Type[] types)
        {
            var methodGetIntegratorFromModulePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegratorFromModule, Fixture, methodGetIntegratorFromModulePrametersTypes);
        }

        #endregion

        #region Method Call : (GetIntegratorFromModule) (Return Type : IIntegrator) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegratorFromModule_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var moduleid = CreateType<Guid>();
            var title = CreateType<string>();
            var methodGetIntegratorFromModulePrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetIntegratorFromModule = { moduleid, title };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIntegratorFromModule, methodGetIntegratorFromModulePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, IIntegrator>(_integrationCoreInstanceFixture, out exception1, parametersOfGetIntegratorFromModule);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, IIntegrator>(_integrationCoreInstance, MethodGetIntegratorFromModule, parametersOfGetIntegratorFromModule, methodGetIntegratorFromModulePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetIntegratorFromModule.ShouldNotBeNull();
            parametersOfGetIntegratorFromModule.Length.ShouldBe(2);
            methodGetIntegratorFromModulePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetIntegratorFromModule));
        }

        #endregion

        #region Method Call : (GetIntegratorFromModule) (Return Type : IIntegrator) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegratorFromModule_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var moduleid = CreateType<Guid>();
            var title = CreateType<string>();
            var methodGetIntegratorFromModulePrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetIntegratorFromModule = { moduleid, title };

            // Assert
            parametersOfGetIntegratorFromModule.ShouldNotBeNull();
            parametersOfGetIntegratorFromModule.Length.ShouldBe(2);
            methodGetIntegratorFromModulePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, IIntegrator>(_integrationCoreInstance, MethodGetIntegratorFromModule, parametersOfGetIntegratorFromModule, methodGetIntegratorFromModulePrametersTypes));
        }

        #endregion

        #region Method Call : (GetIntegratorFromModule) (Return Type : IIntegrator) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegratorFromModule_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIntegratorFromModulePrametersTypes = new Type[] { typeof(Guid), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegratorFromModule, Fixture, methodGetIntegratorFromModulePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetIntegratorFromModulePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIntegratorFromModule) (Return Type : IIntegrator) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegratorFromModule_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIntegratorFromModulePrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetIntegratorFromModule, Fixture, methodGetIntegratorFromModulePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIntegratorFromModulePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIntegratorFromModule) (Return Type : IIntegrator) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegratorFromModule_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIntegratorFromModule, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIntegratorFromModule) (Return Type : IIntegrator) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetIntegratorFromModule_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIntegratorFromModule, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_ProcessItem_Method_Call_Internally(Type[] types)
        {
            var methodProcessItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItem, Fixture, methodProcessItemPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItem_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var dsItem = CreateType<DataSet>();
            var li = CreateType<SPListItem>();
            var list = CreateType<SPList>();
            var methodProcessItemPrametersTypes = new Type[] { typeof(DataSet), typeof(SPListItem), typeof(SPList) };
            object[] parametersOfProcessItem = { dsItem, li, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessItem, methodProcessItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfProcessItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessItem.ShouldNotBeNull();
            parametersOfProcessItem.Length.ShouldBe(3);
            methodProcessItemPrametersTypes.Length.ShouldBe(3);
            methodProcessItemPrametersTypes.Length.ShouldBe(parametersOfProcessItem.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItem_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dsItem = CreateType<DataSet>();
            var li = CreateType<SPListItem>();
            var list = CreateType<SPList>();
            var methodProcessItemPrametersTypes = new Type[] { typeof(DataSet), typeof(SPListItem), typeof(SPList) };
            object[] parametersOfProcessItem = { dsItem, li, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodProcessItem, parametersOfProcessItem, methodProcessItemPrametersTypes);

            // Assert
            parametersOfProcessItem.ShouldNotBeNull();
            parametersOfProcessItem.Length.ShouldBe(3);
            methodProcessItemPrametersTypes.Length.ShouldBe(3);
            methodProcessItemPrametersTypes.Length.ShouldBe(parametersOfProcessItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessItem, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessItemPrametersTypes = new Type[] { typeof(DataSet), typeof(SPListItem), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodProcessItem, Fixture, methodProcessItemPrametersTypes);

            // Assert
            methodProcessItemPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_ProcessItem_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubmitDeleteListEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_SubmitDeleteListEvent_Method_Call_Internally(Type[] types)
        {
            var methodSubmitDeleteListEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodSubmitDeleteListEvent, Fixture, methodSubmitDeleteListEventPrametersTypes);
        }

        #endregion

        #region Method Call : (SubmitDeleteListEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitDeleteListEvent_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var AfterProperties = CreateType<SPItemEventDataCollection>();
            var methodSubmitDeleteListEventPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPItemEventDataCollection) };
            object[] parametersOfSubmitDeleteListEvent = { li, AfterProperties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSubmitDeleteListEvent, methodSubmitDeleteListEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfSubmitDeleteListEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSubmitDeleteListEvent.ShouldNotBeNull();
            parametersOfSubmitDeleteListEvent.Length.ShouldBe(2);
            methodSubmitDeleteListEventPrametersTypes.Length.ShouldBe(2);
            methodSubmitDeleteListEventPrametersTypes.Length.ShouldBe(parametersOfSubmitDeleteListEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SubmitDeleteListEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitDeleteListEvent_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var AfterProperties = CreateType<SPItemEventDataCollection>();
            var methodSubmitDeleteListEventPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPItemEventDataCollection) };
            object[] parametersOfSubmitDeleteListEvent = { li, AfterProperties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodSubmitDeleteListEvent, parametersOfSubmitDeleteListEvent, methodSubmitDeleteListEventPrametersTypes);

            // Assert
            parametersOfSubmitDeleteListEvent.ShouldNotBeNull();
            parametersOfSubmitDeleteListEvent.Length.ShouldBe(2);
            methodSubmitDeleteListEventPrametersTypes.Length.ShouldBe(2);
            methodSubmitDeleteListEventPrametersTypes.Length.ShouldBe(parametersOfSubmitDeleteListEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubmitDeleteListEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitDeleteListEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSubmitDeleteListEvent, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SubmitDeleteListEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitDeleteListEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSubmitDeleteListEventPrametersTypes = new Type[] { typeof(SPListItem), typeof(SPItemEventDataCollection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodSubmitDeleteListEvent, Fixture, methodSubmitDeleteListEventPrametersTypes);

            // Assert
            methodSubmitDeleteListEventPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubmitDeleteListEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitDeleteListEvent_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSubmitDeleteListEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubmitListEvent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_SubmitListEvent_Method_Call_Internally(Type[] types)
        {
            var methodSubmitListEventPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodSubmitListEvent, Fixture, methodSubmitListEventPrametersTypes);
        }

        #endregion

        #region Method Call : (SubmitListEvent) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitListEvent_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var eventType = CreateType<int>();
            var AfterProperties = CreateType<SPItemEventDataCollection>();
            var methodSubmitListEventPrametersTypes = new Type[] { typeof(SPListItem), typeof(int), typeof(SPItemEventDataCollection) };
            object[] parametersOfSubmitListEvent = { li, eventType, AfterProperties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSubmitListEvent, methodSubmitListEventPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfSubmitListEvent);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSubmitListEvent.ShouldNotBeNull();
            parametersOfSubmitListEvent.Length.ShouldBe(3);
            methodSubmitListEventPrametersTypes.Length.ShouldBe(3);
            methodSubmitListEventPrametersTypes.Length.ShouldBe(parametersOfSubmitListEvent.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SubmitListEvent) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitListEvent_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var li = CreateType<SPListItem>();
            var eventType = CreateType<int>();
            var AfterProperties = CreateType<SPItemEventDataCollection>();
            var methodSubmitListEventPrametersTypes = new Type[] { typeof(SPListItem), typeof(int), typeof(SPItemEventDataCollection) };
            object[] parametersOfSubmitListEvent = { li, eventType, AfterProperties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodSubmitListEvent, parametersOfSubmitListEvent, methodSubmitListEventPrametersTypes);

            // Assert
            parametersOfSubmitListEvent.ShouldNotBeNull();
            parametersOfSubmitListEvent.Length.ShouldBe(3);
            methodSubmitListEventPrametersTypes.Length.ShouldBe(3);
            methodSubmitListEventPrametersTypes.Length.ShouldBe(parametersOfSubmitListEvent.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubmitListEvent) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitListEvent_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSubmitListEvent, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SubmitListEvent) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitListEvent_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSubmitListEventPrametersTypes = new Type[] { typeof(SPListItem), typeof(int), typeof(SPItemEventDataCollection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodSubmitListEvent, Fixture, methodSubmitListEventPrametersTypes);

            // Assert
            methodSubmitListEventPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SubmitListEvent) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_SubmitListEvent_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSubmitListEvent, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (bCheckBit) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_bCheckBit_Method_Call_Internally(Type[] types)
        {
            var methodbCheckBitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodbCheckBit, Fixture, methodbCheckBitPrametersTypes);
        }

        #endregion

        #region Method Call : (bCheckBit) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_bCheckBit_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var colid = CreateType<string>();
            var methodbCheckBitPrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(string) };
            object[] parametersOfbCheckBit = { intlistid, itemid, colid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodbCheckBit, methodbCheckBitPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, bool>(_integrationCoreInstanceFixture, out exception1, parametersOfbCheckBit);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodbCheckBit, parametersOfbCheckBit, methodbCheckBitPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfbCheckBit.ShouldNotBeNull();
            parametersOfbCheckBit.Length.ShouldBe(3);
            methodbCheckBitPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfbCheckBit));
        }

        #endregion

        #region Method Call : (bCheckBit) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_bCheckBit_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var colid = CreateType<string>();
            var methodbCheckBitPrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(string) };
            object[] parametersOfbCheckBit = { intlistid, itemid, colid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodbCheckBit, methodbCheckBitPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, bool>(_integrationCoreInstanceFixture, out exception1, parametersOfbCheckBit);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodbCheckBit, parametersOfbCheckBit, methodbCheckBitPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfbCheckBit.ShouldNotBeNull();
            parametersOfbCheckBit.Length.ShouldBe(3);
            methodbCheckBitPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodbCheckBit, parametersOfbCheckBit, methodbCheckBitPrametersTypes));
        }

        #endregion

        #region Method Call : (bCheckBit) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_bCheckBit_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intlistid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var colid = CreateType<string>();
            var methodbCheckBitPrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(string) };
            object[] parametersOfbCheckBit = { intlistid, itemid, colid };

            // Assert
            parametersOfbCheckBit.ShouldNotBeNull();
            parametersOfbCheckBit.Length.ShouldBe(3);
            methodbCheckBitPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, bool>(_integrationCoreInstance, MethodbCheckBit, parametersOfbCheckBit, methodbCheckBitPrametersTypes));
        }

        #endregion

        #region Method Call : (bCheckBit) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_bCheckBit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodbCheckBitPrametersTypes = new Type[] { typeof(Guid), typeof(int), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodbCheckBit, Fixture, methodbCheckBitPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodbCheckBitPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (bCheckBit) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_bCheckBit_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodbCheckBit, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (bCheckBit) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_bCheckBit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodbCheckBit, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_AddField_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodAddField, Fixture, methodAddFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (AddField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_AddField_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var dtU = CreateType<DataTable>();
            var drIntegrationModule = CreateType<DataRow>();
            var dt = CreateType<DataTable>();
            var methodAddFieldPrametersTypes = new Type[] { typeof(SPField), typeof(DataTable), typeof(DataRow), typeof(DataTable) };
            object[] parametersOfAddField = { field, dtU, drIntegrationModule, dt };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddField, methodAddFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfAddField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddField.ShouldNotBeNull();
            parametersOfAddField.Length.ShouldBe(4);
            methodAddFieldPrametersTypes.Length.ShouldBe(4);
            methodAddFieldPrametersTypes.Length.ShouldBe(parametersOfAddField.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_AddField_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var dtU = CreateType<DataTable>();
            var drIntegrationModule = CreateType<DataRow>();
            var dt = CreateType<DataTable>();
            var methodAddFieldPrametersTypes = new Type[] { typeof(SPField), typeof(DataTable), typeof(DataRow), typeof(DataTable) };
            object[] parametersOfAddField = { field, dtU, drIntegrationModule, dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodAddField, parametersOfAddField, methodAddFieldPrametersTypes);

            // Assert
            parametersOfAddField.ShouldNotBeNull();
            parametersOfAddField.Length.ShouldBe(4);
            methodAddFieldPrametersTypes.Length.ShouldBe(4);
            methodAddFieldPrametersTypes.Length.ShouldBe(parametersOfAddField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_AddField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddField, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_AddField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldPrametersTypes = new Type[] { typeof(SPField), typeof(DataTable), typeof(DataRow), typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodAddField, Fixture, methodAddFieldPrametersTypes);

            // Assert
            methodAddFieldPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_AddField_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetDataSet_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetDataSetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDataSet, Fixture, methodGetDataSetPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var eventfromid = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var methodGetDataSetPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(Guid) };
            object[] parametersOfGetDataSet = { list, eventfromid, intlistid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDataSet, methodGetDataSetPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, DataSet>(_integrationCoreInstanceFixture, out exception1, parametersOfGetDataSet);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataSet>(_integrationCoreInstance, MethodGetDataSet, parametersOfGetDataSet, methodGetDataSetPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDataSet.ShouldNotBeNull();
            parametersOfGetDataSet.Length.ShouldBe(3);
            methodGetDataSetPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetDataSet));
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var eventfromid = CreateType<string>();
            var intlistid = CreateType<Guid>();
            var methodGetDataSetPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(Guid) };
            object[] parametersOfGetDataSet = { list, eventfromid, intlistid };

            // Assert
            parametersOfGetDataSet.ShouldNotBeNull();
            parametersOfGetDataSet.Length.ShouldBe(3);
            methodGetDataSetPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, DataSet>(_integrationCoreInstance, MethodGetDataSet, parametersOfGetDataSet, methodGetDataSetPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataSetPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDataSet, Fixture, methodGetDataSetPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataSetPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataSetPrametersTypes = new Type[] { typeof(SPList), typeof(string), typeof(Guid) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetDataSet, Fixture, methodGetDataSetPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataSetPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDataSet, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDataSet) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetDataSet_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataSet, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAPIUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_GetAPIUrl_Method_Call_Internally(Type[] types)
        {
            var methodGetAPIUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetAPIUrl, Fixture, methodGetAPIUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAPIUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetAPIUrl_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var webappid = CreateType<Guid>();
            var methodGetAPIUrlPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetAPIUrl = { webappid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAPIUrl, methodGetAPIUrlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<IntegrationCore, string>(_integrationCoreInstanceFixture, out exception1, parametersOfGetAPIUrl);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetAPIUrl, parametersOfGetAPIUrl, methodGetAPIUrlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetAPIUrl.ShouldNotBeNull();
            parametersOfGetAPIUrl.Length.ShouldBe(1);
            methodGetAPIUrlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfGetAPIUrl));
        }

        #endregion

        #region Method Call : (GetAPIUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetAPIUrl_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var webappid = CreateType<Guid>();
            var methodGetAPIUrlPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetAPIUrl = { webappid };

            // Assert
            parametersOfGetAPIUrl.ShouldNotBeNull();
            parametersOfGetAPIUrl.Length.ShouldBe(1);
            methodGetAPIUrlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<IntegrationCore, string>(_integrationCoreInstance, MethodGetAPIUrl, parametersOfGetAPIUrl, methodGetAPIUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetAPIUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetAPIUrl_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAPIUrlPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetAPIUrl, Fixture, methodGetAPIUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAPIUrlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetAPIUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetAPIUrl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAPIUrlPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodGetAPIUrl, Fixture, methodGetAPIUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAPIUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAPIUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetAPIUrl_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAPIUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAPIUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_GetAPIUrl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAPIUrl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OpenConnection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_OpenConnection_Method_Call_Internally(Type[] types)
        {
            var methodOpenConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodOpenConnection, Fixture, methodOpenConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (OpenConnection) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_OpenConnection_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodOpenConnectionPrametersTypes = null;
            object[] parametersOfOpenConnection = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOpenConnection, methodOpenConnectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfOpenConnection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOpenConnection.ShouldBeNull();
            methodOpenConnectionPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OpenConnection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_OpenConnection_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodOpenConnectionPrametersTypes = null;
            object[] parametersOfOpenConnection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodOpenConnection, parametersOfOpenConnection, methodOpenConnectionPrametersTypes);

            // Assert
            parametersOfOpenConnection.ShouldBeNull();
            methodOpenConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OpenConnection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_OpenConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodOpenConnectionPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodOpenConnection, Fixture, methodOpenConnectionPrametersTypes);

            // Assert
            methodOpenConnectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OpenConnection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_OpenConnection_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOpenConnection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseConnection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationCore_CloseConnection_Method_Call_Internally(Type[] types)
        {
            var methodCloseConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodCloseConnection, Fixture, methodCloseConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (CloseConnection) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_CloseConnection_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var force = CreateType<bool>();
            var methodCloseConnectionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfCloseConnection = { force };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCloseConnection, methodCloseConnectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationCoreInstanceFixture, parametersOfCloseConnection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCloseConnection.ShouldNotBeNull();
            parametersOfCloseConnection.Length.ShouldBe(1);
            methodCloseConnectionPrametersTypes.Length.ShouldBe(1);
            methodCloseConnectionPrametersTypes.Length.ShouldBe(parametersOfCloseConnection.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CloseConnection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_CloseConnection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var force = CreateType<bool>();
            var methodCloseConnectionPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfCloseConnection = { force };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationCoreInstance, MethodCloseConnection, parametersOfCloseConnection, methodCloseConnectionPrametersTypes);

            // Assert
            parametersOfCloseConnection.ShouldNotBeNull();
            parametersOfCloseConnection.Length.ShouldBe(1);
            methodCloseConnectionPrametersTypes.Length.ShouldBe(1);
            methodCloseConnectionPrametersTypes.Length.ShouldBe(parametersOfCloseConnection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseConnection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_CloseConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCloseConnection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CloseConnection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_CloseConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCloseConnectionPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationCoreInstance, MethodCloseConnection, Fixture, methodCloseConnectionPrametersTypes);

            // Assert
            methodCloseConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CloseConnection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationCore_CloseConnection_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCloseConnection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationCoreInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}