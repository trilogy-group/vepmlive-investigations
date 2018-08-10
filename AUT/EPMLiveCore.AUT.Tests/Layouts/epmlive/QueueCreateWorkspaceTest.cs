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

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.QueueCreateWorkspace" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class QueueCreateWorkspaceTest : AbstractBaseSetupTypedTest<QueueCreateWorkspace>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueueCreateWorkspace) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodRespond = "Respond";
        private const string MethodInitFields = "InitFields";
        private const string MethodGetFeatures = "GetFeatures";
        private const string MethodGetQueryStringParameters = "GetQueryStringParameters";
        private const string MethodGetTemplateResourceURLWithLockedWeb = "GetTemplateResourceURLWithLockedWeb";
        private const string MethodGetWorkengineServiceURL = "GetWorkengineServiceURL";
        private const string MethodGetCompLevels = "GetCompLevels";
        private const string MethodGetListName = "GetListName";
        private const string MethodGetWorkspaceTitle = "GetWorkspaceTitle";
        private const string MethodGetDefaultCreateWorkspaceUISettings = "GetDefaultCreateWorkspaceUISettings";
        private const string FieldWORKENGINE_WS_URL = "WORKENGINE_WS_URL";
        private const string Field_isStandAlone = "_isStandAlone";
        private const string Field_compLevels = "_compLevels";
        private const string Field_workEngineSvcUrl = "_workEngineSvcUrl";
        private const string Field_lstGuid = "_lstGuid";
        private const string Field_listName = "_listName";
        private const string Field_itemId = "_itemId";
        private const string Field_newItemName = "_newItemName";
        private const string Field_newItemNameLwrCs = "_newItemNameLwrCs";
        private const string Field_templateType = "_templateType";
        private const string Field_workspaceTitle = "_workspaceTitle";
        private const string Field_rListName = "_rListName";
        private const string Field_reqListName = "_reqListName";
        private const string Field_doNotDelRequest = "_doNotDelRequest";
        private const string Field_tempGalRedirect = "_tempGalRedirect";
        private const string Field_curWebUrl = "_curWebUrl";
        private const string Field_requestProjectName = "_requestProjectName";
        private const string Field_uniquePermission = "_uniquePermission";
        private const string Field_defaultCreateNewOpt = "_defaultCreateNewOpt";
        private const string Field_currentUserId = "_currentUserId";
        private const string Field_showInProgress = "_showInProgress";
        private const string Field_isDlg = "_isDlg";
        private const string Field_redirectToModal = "_redirectToModal";
        private const string Field_hideEverything = "_hideEverything";
        private const string Field_projectWorkspaceSetting = "_projectWorkspaceSetting";
        private const string Field_isCreateFromOnlineAvail = "_isCreateFromOnlineAvail";
        private const string Field_isCreateFromLocalAvail = "_isCreateFromLocalAvail";
        private const string Field_isCreateFromExistingAvail = "_isCreateFromExistingAvail";
        private const string Field_createFromLiveTemp = "_createFromLiveTemp";
        private const string Field_features = "_features";
        private Type _queueCreateWorkspaceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private QueueCreateWorkspace _queueCreateWorkspaceInstance;
        private QueueCreateWorkspace _queueCreateWorkspaceInstanceFixture;

        #region General Initializer : Class (QueueCreateWorkspace) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueueCreateWorkspace" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queueCreateWorkspaceInstanceType = typeof(QueueCreateWorkspace);
            _queueCreateWorkspaceInstanceFixture = Create(true);
            _queueCreateWorkspaceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueueCreateWorkspace)

        #region General Initializer : Class (QueueCreateWorkspace) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="QueueCreateWorkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodRespond, 0)]
        [TestCase(MethodInitFields, 0)]
        [TestCase(MethodGetFeatures, 0)]
        [TestCase(MethodGetQueryStringParameters, 0)]
        [TestCase(MethodGetTemplateResourceURLWithLockedWeb, 0)]
        [TestCase(MethodGetWorkengineServiceURL, 0)]
        [TestCase(MethodGetCompLevels, 0)]
        [TestCase(MethodGetListName, 0)]
        [TestCase(MethodGetWorkspaceTitle, 0)]
        [TestCase(MethodGetDefaultCreateWorkspaceUISettings, 0)]
        public void AUT_QueueCreateWorkspace_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_queueCreateWorkspaceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (QueueCreateWorkspace) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueueCreateWorkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldWORKENGINE_WS_URL)]
        [TestCase(Field_isStandAlone)]
        [TestCase(Field_compLevels)]
        [TestCase(Field_workEngineSvcUrl)]
        [TestCase(Field_lstGuid)]
        [TestCase(Field_listName)]
        [TestCase(Field_itemId)]
        [TestCase(Field_newItemName)]
        [TestCase(Field_newItemNameLwrCs)]
        [TestCase(Field_templateType)]
        [TestCase(Field_workspaceTitle)]
        [TestCase(Field_rListName)]
        [TestCase(Field_reqListName)]
        [TestCase(Field_doNotDelRequest)]
        [TestCase(Field_tempGalRedirect)]
        [TestCase(Field_curWebUrl)]
        [TestCase(Field_requestProjectName)]
        [TestCase(Field_uniquePermission)]
        [TestCase(Field_defaultCreateNewOpt)]
        [TestCase(Field_currentUserId)]
        [TestCase(Field_showInProgress)]
        [TestCase(Field_isDlg)]
        [TestCase(Field_redirectToModal)]
        [TestCase(Field_hideEverything)]
        [TestCase(Field_projectWorkspaceSetting)]
        [TestCase(Field_isCreateFromOnlineAvail)]
        [TestCase(Field_isCreateFromLocalAvail)]
        [TestCase(Field_isCreateFromExistingAvail)]
        [TestCase(Field_createFromLiveTemp)]
        [TestCase(Field_features)]
        public void AUT_QueueCreateWorkspace_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queueCreateWorkspaceInstanceFixture, 
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
        ///     Class (<see cref="QueueCreateWorkspace" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueueCreateWorkspace_Is_Instance_Present_Test()
        {
            // Assert
            _queueCreateWorkspaceInstanceType.ShouldNotBeNull();
            _queueCreateWorkspaceInstance.ShouldNotBeNull();
            _queueCreateWorkspaceInstanceFixture.ShouldNotBeNull();
            _queueCreateWorkspaceInstance.ShouldBeAssignableTo<QueueCreateWorkspace>();
            _queueCreateWorkspaceInstanceFixture.ShouldBeAssignableTo<QueueCreateWorkspace>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueueCreateWorkspace) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_QueueCreateWorkspace_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueueCreateWorkspace instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queueCreateWorkspaceInstanceType.ShouldNotBeNull();
            _queueCreateWorkspaceInstance.ShouldNotBeNull();
            _queueCreateWorkspaceInstanceFixture.ShouldNotBeNull();
            _queueCreateWorkspaceInstance.ShouldBeAssignableTo<QueueCreateWorkspace>();
            _queueCreateWorkspaceInstanceFixture.ShouldBeAssignableTo<QueueCreateWorkspace>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="QueueCreateWorkspace" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodRespond)]
        [TestCase(MethodInitFields)]
        [TestCase(MethodGetFeatures)]
        [TestCase(MethodGetQueryStringParameters)]
        [TestCase(MethodGetTemplateResourceURLWithLockedWeb)]
        [TestCase(MethodGetWorkengineServiceURL)]
        [TestCase(MethodGetCompLevels)]
        [TestCase(MethodGetListName)]
        [TestCase(MethodGetWorkspaceTitle)]
        [TestCase(MethodGetDefaultCreateWorkspaceUISettings)]
        public void AUT_QueueCreateWorkspace_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<QueueCreateWorkspace>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfPage_Load);

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
        public void AUT_QueueCreateWorkspace_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queueCreateWorkspaceInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_QueueCreateWorkspace_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_QueueCreateWorkspace_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Respond) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_Respond_Method_Call_Internally(Type[] types)
        {
            var methodRespondPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodRespond, Fixture, methodRespondPrametersTypes);
        }

        #endregion

        #region Method Call : (Respond) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_Respond_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRespondPrametersTypes = null;
            object[] parametersOfRespond = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRespond, methodRespondPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfRespond);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRespond.ShouldBeNull();
            methodRespondPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Respond) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_Respond_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRespondPrametersTypes = null;
            object[] parametersOfRespond = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queueCreateWorkspaceInstance, MethodRespond, parametersOfRespond, methodRespondPrametersTypes);

            // Assert
            parametersOfRespond.ShouldBeNull();
            methodRespondPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Respond) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_Respond_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRespondPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodRespond, Fixture, methodRespondPrametersTypes);

            // Assert
            methodRespondPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Respond) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_Respond_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRespond, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_InitFields_Method_Call_Internally(Type[] types)
        {
            var methodInitFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodInitFields, Fixture, methodInitFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_InitFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitFieldsPrametersTypes = null;
            object[] parametersOfInitFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitFields, methodInitFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfInitFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitFields.ShouldBeNull();
            methodInitFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_InitFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitFieldsPrametersTypes = null;
            object[] parametersOfInitFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queueCreateWorkspaceInstance, MethodInitFields, parametersOfInitFields, methodInitFieldsPrametersTypes);

            // Assert
            parametersOfInitFields.ShouldBeNull();
            methodInitFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_InitFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodInitFields, Fixture, methodInitFieldsPrametersTypes);

            // Assert
            methodInitFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_InitFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatures) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetFeatures_Method_Call_Internally(Type[] types)
        {
            var methodGetFeaturesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetFeatures, Fixture, methodGetFeaturesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFeatures) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetFeatures_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetFeaturesPrametersTypes = null;
            object[] parametersOfGetFeatures = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFeatures, methodGetFeaturesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfGetFeatures);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFeatures.ShouldBeNull();
            methodGetFeaturesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatures) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetFeatures_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFeaturesPrametersTypes = null;
            object[] parametersOfGetFeatures = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queueCreateWorkspaceInstance, MethodGetFeatures, parametersOfGetFeatures, methodGetFeaturesPrametersTypes);

            // Assert
            parametersOfGetFeatures.ShouldBeNull();
            methodGetFeaturesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatures) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetFeatures_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFeaturesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetFeatures, Fixture, methodGetFeaturesPrametersTypes);

            // Assert
            methodGetFeaturesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFeatures) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetFeatures_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFeatures, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryStringParameters) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetQueryStringParameters_Method_Call_Internally(Type[] types)
        {
            var methodGetQueryStringParametersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetQueryStringParameters, Fixture, methodGetQueryStringParametersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQueryStringParameters) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetQueryStringParameters_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetQueryStringParametersPrametersTypes = null;
            object[] parametersOfGetQueryStringParameters = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetQueryStringParameters, methodGetQueryStringParametersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfGetQueryStringParameters);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetQueryStringParameters.ShouldBeNull();
            methodGetQueryStringParametersPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryStringParameters) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetQueryStringParameters_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetQueryStringParametersPrametersTypes = null;
            object[] parametersOfGetQueryStringParameters = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queueCreateWorkspaceInstance, MethodGetQueryStringParameters, parametersOfGetQueryStringParameters, methodGetQueryStringParametersPrametersTypes);

            // Assert
            parametersOfGetQueryStringParameters.ShouldBeNull();
            methodGetQueryStringParametersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryStringParameters) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetQueryStringParameters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetQueryStringParametersPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetQueryStringParameters, Fixture, methodGetQueryStringParametersPrametersTypes);

            // Assert
            methodGetQueryStringParametersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryStringParameters) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetQueryStringParameters_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQueryStringParameters, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTemplateResourceURLWithLockedWeb) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetTemplateResourceURLWithLockedWeb_Method_Call_Internally(Type[] types)
        {
            var methodGetTemplateResourceURLWithLockedWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetTemplateResourceURLWithLockedWeb, Fixture, methodGetTemplateResourceURLWithLockedWebPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTemplateResourceURLWithLockedWeb) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetTemplateResourceURLWithLockedWeb_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetTemplateResourceURLWithLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetTemplateResourceURLWithLockedWeb = { lockedWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTemplateResourceURLWithLockedWeb, methodGetTemplateResourceURLWithLockedWebPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstanceFixture, out exception1, parametersOfGetTemplateResourceURLWithLockedWeb);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetTemplateResourceURLWithLockedWeb, parametersOfGetTemplateResourceURLWithLockedWeb, methodGetTemplateResourceURLWithLockedWebPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTemplateResourceURLWithLockedWeb.ShouldNotBeNull();
            parametersOfGetTemplateResourceURLWithLockedWeb.Length.ShouldBe(1);
            methodGetTemplateResourceURLWithLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfGetTemplateResourceURLWithLockedWeb));
        }

        #endregion

        #region Method Call : (GetTemplateResourceURLWithLockedWeb) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetTemplateResourceURLWithLockedWeb_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetTemplateResourceURLWithLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetTemplateResourceURLWithLockedWeb = { lockedWeb };

            // Assert
            parametersOfGetTemplateResourceURLWithLockedWeb.ShouldNotBeNull();
            parametersOfGetTemplateResourceURLWithLockedWeb.Length.ShouldBe(1);
            methodGetTemplateResourceURLWithLockedWebPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetTemplateResourceURLWithLockedWeb, parametersOfGetTemplateResourceURLWithLockedWeb, methodGetTemplateResourceURLWithLockedWebPrametersTypes));
        }

        #endregion

        #region Method Call : (GetTemplateResourceURLWithLockedWeb) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetTemplateResourceURLWithLockedWeb_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTemplateResourceURLWithLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetTemplateResourceURLWithLockedWeb, Fixture, methodGetTemplateResourceURLWithLockedWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTemplateResourceURLWithLockedWebPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTemplateResourceURLWithLockedWeb) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetTemplateResourceURLWithLockedWeb_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTemplateResourceURLWithLockedWebPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetTemplateResourceURLWithLockedWeb, Fixture, methodGetTemplateResourceURLWithLockedWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTemplateResourceURLWithLockedWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTemplateResourceURLWithLockedWeb) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetTemplateResourceURLWithLockedWeb_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTemplateResourceURLWithLockedWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTemplateResourceURLWithLockedWeb) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetTemplateResourceURLWithLockedWeb_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTemplateResourceURLWithLockedWeb, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkengineServiceURL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetWorkengineServiceURL_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkengineServiceURLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetWorkengineServiceURL, Fixture, methodGetWorkengineServiceURLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkengineServiceURL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkengineServiceURL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetWorkengineServiceURLPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetWorkengineServiceURL = { lockedWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkengineServiceURL, methodGetWorkengineServiceURLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstanceFixture, out exception1, parametersOfGetWorkengineServiceURL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetWorkengineServiceURL, parametersOfGetWorkengineServiceURL, methodGetWorkengineServiceURLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkengineServiceURL.ShouldNotBeNull();
            parametersOfGetWorkengineServiceURL.Length.ShouldBe(1);
            methodGetWorkengineServiceURLPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfGetWorkengineServiceURL));
        }

        #endregion

        #region Method Call : (GetWorkengineServiceURL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkengineServiceURL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetWorkengineServiceURLPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetWorkengineServiceURL = { lockedWeb };

            // Assert
            parametersOfGetWorkengineServiceURL.ShouldNotBeNull();
            parametersOfGetWorkengineServiceURL.Length.ShouldBe(1);
            methodGetWorkengineServiceURLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetWorkengineServiceURL, parametersOfGetWorkengineServiceURL, methodGetWorkengineServiceURLPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkengineServiceURL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkengineServiceURL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkengineServiceURLPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetWorkengineServiceURL, Fixture, methodGetWorkengineServiceURLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkengineServiceURLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWorkengineServiceURL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkengineServiceURL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkengineServiceURLPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetWorkengineServiceURL, Fixture, methodGetWorkengineServiceURLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkengineServiceURLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkengineServiceURL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkengineServiceURL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkengineServiceURL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkengineServiceURL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkengineServiceURL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkengineServiceURL, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCompLevels) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetCompLevels_Method_Call_Internally(Type[] types)
        {
            var methodGetCompLevelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetCompLevels, Fixture, methodGetCompLevelsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCompLevels) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetCompLevels_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetCompLevelsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetCompLevels = { lockedWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCompLevels, methodGetCompLevelsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCompLevels.ShouldNotBeNull();
            parametersOfGetCompLevels.Length.ShouldBe(1);
            methodGetCompLevelsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfGetCompLevels));
        }

        #endregion

        #region Method Call : (GetCompLevels) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetCompLevels_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetCompLevelsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetCompLevels = { lockedWeb };

            // Assert
            parametersOfGetCompLevels.ShouldNotBeNull();
            parametersOfGetCompLevels.Length.ShouldBe(1);
            methodGetCompLevelsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetCompLevels, parametersOfGetCompLevels, methodGetCompLevelsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCompLevels) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetCompLevels_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCompLevelsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetCompLevels, Fixture, methodGetCompLevelsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCompLevelsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCompLevels) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetCompLevels_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCompLevelsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetCompLevels, Fixture, methodGetCompLevelsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCompLevelsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCompLevels) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetCompLevels_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCompLevels, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCompLevels) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetCompLevels_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCompLevels, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetListName_Method_Call_Internally(Type[] types)
        {
            var methodGetListNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetListName, Fixture, methodGetListNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetListName_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetListNamePrametersTypes = null;
            object[] parametersOfGetListName = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListName, methodGetListNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstanceFixture, out exception1, parametersOfGetListName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetListName, parametersOfGetListName, methodGetListNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetListName.ShouldBeNull();
            methodGetListNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetListName, parametersOfGetListName, methodGetListNamePrametersTypes));
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetListName_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetListNamePrametersTypes = null;
            object[] parametersOfGetListName = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListName, methodGetListNamePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListName.ShouldBeNull();
            methodGetListNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfGetListName));
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetListName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetListNamePrametersTypes = null;
            object[] parametersOfGetListName = null; // no parameter present

            // Assert
            parametersOfGetListName.ShouldBeNull();
            methodGetListNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetListName, parametersOfGetListName, methodGetListNamePrametersTypes));
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetListName_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetListNamePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetListName, Fixture, methodGetListNamePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetListNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetListName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetListNamePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetListName, Fixture, methodGetListNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListNamePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListName) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetListName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetWorkspaceTitle) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetWorkspaceTitle_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkspaceTitlePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetWorkspaceTitle, Fixture, methodGetWorkspaceTitlePrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkspaceTitle) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkspaceTitle_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetWorkspaceTitlePrametersTypes = null;
            object[] parametersOfGetWorkspaceTitle = null; // no parameter present

            // Assert
            parametersOfGetWorkspaceTitle.ShouldBeNull();
            methodGetWorkspaceTitlePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<QueueCreateWorkspace, string>(_queueCreateWorkspaceInstance, MethodGetWorkspaceTitle, parametersOfGetWorkspaceTitle, methodGetWorkspaceTitlePrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkspaceTitle) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkspaceTitle_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetWorkspaceTitlePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetWorkspaceTitle, Fixture, methodGetWorkspaceTitlePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetWorkspaceTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkspaceTitle) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkspaceTitle_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetWorkspaceTitlePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetWorkspaceTitle, Fixture, methodGetWorkspaceTitlePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkspaceTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkspaceTitle) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetWorkspaceTitle_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceTitle, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultCreateWorkspaceUISettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueueCreateWorkspace_GetDefaultCreateWorkspaceUISettings_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultCreateWorkspaceUISettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetDefaultCreateWorkspaceUISettings, Fixture, methodGetDefaultCreateWorkspaceUISettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultCreateWorkspaceUISettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetDefaultCreateWorkspaceUISettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetDefaultCreateWorkspaceUISettingsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetDefaultCreateWorkspaceUISettings = { lockedWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDefaultCreateWorkspaceUISettings, methodGetDefaultCreateWorkspaceUISettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queueCreateWorkspaceInstanceFixture, parametersOfGetDefaultCreateWorkspaceUISettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDefaultCreateWorkspaceUISettings.ShouldNotBeNull();
            parametersOfGetDefaultCreateWorkspaceUISettings.Length.ShouldBe(1);
            methodGetDefaultCreateWorkspaceUISettingsPrametersTypes.Length.ShouldBe(1);
            methodGetDefaultCreateWorkspaceUISettingsPrametersTypes.Length.ShouldBe(parametersOfGetDefaultCreateWorkspaceUISettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultCreateWorkspaceUISettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetDefaultCreateWorkspaceUISettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lockedWeb = CreateType<SPWeb>();
            var methodGetDefaultCreateWorkspaceUISettingsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetDefaultCreateWorkspaceUISettings = { lockedWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queueCreateWorkspaceInstance, MethodGetDefaultCreateWorkspaceUISettings, parametersOfGetDefaultCreateWorkspaceUISettings, methodGetDefaultCreateWorkspaceUISettingsPrametersTypes);

            // Assert
            parametersOfGetDefaultCreateWorkspaceUISettings.ShouldNotBeNull();
            parametersOfGetDefaultCreateWorkspaceUISettings.Length.ShouldBe(1);
            methodGetDefaultCreateWorkspaceUISettingsPrametersTypes.Length.ShouldBe(1);
            methodGetDefaultCreateWorkspaceUISettingsPrametersTypes.Length.ShouldBe(parametersOfGetDefaultCreateWorkspaceUISettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultCreateWorkspaceUISettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetDefaultCreateWorkspaceUISettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefaultCreateWorkspaceUISettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultCreateWorkspaceUISettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetDefaultCreateWorkspaceUISettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefaultCreateWorkspaceUISettingsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queueCreateWorkspaceInstance, MethodGetDefaultCreateWorkspaceUISettings, Fixture, methodGetDefaultCreateWorkspaceUISettingsPrametersTypes);

            // Assert
            methodGetDefaultCreateWorkspaceUISettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefaultCreateWorkspaceUISettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueueCreateWorkspace_GetDefaultCreateWorkspaceUISettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultCreateWorkspaceUISettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queueCreateWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}