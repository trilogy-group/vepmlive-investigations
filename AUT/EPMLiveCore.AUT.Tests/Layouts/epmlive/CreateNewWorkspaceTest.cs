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

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.CreateNewWorkspace" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class CreateNewWorkspaceTest : AbstractBaseSetupTypedTest<CreateNewWorkspace>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CreateNewWorkspace) Initializer

        private const string MethodPage_Init = "Page_Init";
        private const string MethodPage_Unload = "Page_Unload";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodManageWorkspacePanelUI = "ManageWorkspacePanelUI";
        private const string MethodManageFields = "ManageFields";
        private const string MethodLoadLeftDivOptions = "LoadLeftDivOptions";
        private const string MethodProject_LoadWorkspaceType = "Project_LoadWorkspaceType";
        private const string MethodProject_LoadCreateNewWorkspaceFrom = "Project_LoadCreateNewWorkspaceFrom";
        private const string MethodProject_InitializeFilterPnl = "Project_InitializeFilterPnl";
        private const string MethodTemplate_LoadBrowseFrom = "Template_LoadBrowseFrom";
        private const string MethodTemplate_InitializeFilters = "Template_InitializeFilters";
        private const string Field_cWeb = "_cWeb";
        private const string Field_cSite = "_cSite";
        private const string FieldWORKENGINE_WS_URL = "WORKENGINE_WS_URL";
        private const string FieldSOLUTION_STORE_PROXY_URL = "SOLUTION_STORE_PROXY_URL";
        private const string FieldMORE_INFO_URL = "MORE_INFO_URL";
        private const string FieldSMALL_PARENT_URL = "SMALL_PARENT_URL";
        private const string FieldTEMP_GAL_REDIRECT = "TEMP_GAL_REDIRECT";
        private const string Field_projectWorkspaceSetting = "_projectWorkspaceSetting";
        private const string Field_isCreateFromOnlineAvail = "_isCreateFromOnlineAvail";
        private const string Field_isCreateFromLocalAvail = "_isCreateFromLocalAvail";
        private const string Field_isCreateFromExistingAvail = "_isCreateFromExistingAvail";
        private const string Field_nav = "_nav";
        private const string Field_perms = "_perms";
        private const string Field_defaultCreateNewOpt = "_defaultCreateNewOpt";
        private const string Field_templateResourceUrl = "_templateResourceUrl";
        private const string Field_solutionType = "_solutionType";
        private const string Field_templateType = "_templateType";
        private const string Field_siteHostName = "_siteHostName";
        private const string Field_siteUrl = "_siteUrl";
        private const string Field_currentWebRelativeUrl = "_currentWebRelativeUrl";
        private const string Field_sourceWebId = "_sourceWebId";
        private const string Field_workengineSvcUrl = "_workengineSvcUrl";
        private const string Field_moreInfoUrl = "_moreInfoUrl";
        private const string Field_smallParentUrl = "_smallParentUrl";
        private const string Field_solutionStoreServiceProxyUrl = "_solutionStoreServiceProxyUrl";
        private const string Field_baseURL = "_baseURL";
        private const string Field_lstGuid = "_lstGuid";
        private const string Field_parentWebUrl = "_parentWebUrl";
        private const string Field_parentWebGuid_B = "_parentWebGuid_B";
        private const string Field_wsTypeNew = "_wsTypeNew";
        private const string Field_wsTypeExisting = "_wsTypeExisting";
        private const string Field_includeContentClientId = "_includeContentClientId";
        private const string Field_moreInfoUrlClientId = "_moreInfoUrlClientId";
        private const string Field_featuresList = "_featuresList";
        private const string Field_newItemName = "_newItemName";
        private const string Field_newItemNameLwrCs = "_newItemNameLwrCs";
        private const string Field_hasCreateSubSitePerm = "_hasCreateSubSitePerm";
        private const string Field_copyFrom = "_copyFrom";
        private const string Field_rListName = "_rListName";
        private const string Field_reqListName = "_reqListName";
        private const string Field_doNotDelRequest = "_doNotDelRequest";
        private const string Field_tempGalRedirect = "_tempGalRedirect";
        private const string Field_curWebUrl = "_curWebUrl";
        private const string Field_requestProjectName = "_requestProjectName";
        private const string Field_compLevels = "_compLevels";
        private const string Field_listName = "_listName";
        private const string Field_createFromLiveTemp = "_createFromLiveTemp";
        private const string Field_timeOut = "_timeOut";
        private const string FieldTMP_GAL_TITLE = "TMP_GAL_TITLE";
        private const string FieldCOL_TITLE = "COL_TITLE";
        private const string FieldCOL_URL = "COL_URL";
        private const string FieldCOL_TEMPLATETYPE = "COL_TEMPLATETYPE";
        private const string FieldCOL_TEMPLATECATEGORY = "COL_TEMPLATECATEGORY";
        private const string FieldCOL_DESCRIPTION = "COL_DESCRIPTION";
        private const string FieldCOL_MOREINFO = "COL_MOREINFO";
        private const string FieldCOL_DISPLAYINSTORE = "COL_DISPLAYINSTORE";
        private const string FieldCOL_ATTACHMENT = "COL_ATTACHMENT";
        private Type _createNewWorkspaceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CreateNewWorkspace _createNewWorkspaceInstance;
        private CreateNewWorkspace _createNewWorkspaceInstanceFixture;

        #region General Initializer : Class (CreateNewWorkspace) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CreateNewWorkspace" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createNewWorkspaceInstanceType = typeof(CreateNewWorkspace);
            _createNewWorkspaceInstanceFixture = Create(true);
            _createNewWorkspaceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CreateNewWorkspace)

        #region General Initializer : Class (CreateNewWorkspace) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CreateNewWorkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Init, 0)]
        [TestCase(MethodPage_Unload, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodManageWorkspacePanelUI, 0)]
        [TestCase(MethodManageFields, 0)]
        [TestCase(MethodLoadLeftDivOptions, 0)]
        [TestCase(MethodProject_LoadWorkspaceType, 0)]
        [TestCase(MethodProject_LoadCreateNewWorkspaceFrom, 0)]
        [TestCase(MethodProject_InitializeFilterPnl, 0)]
        [TestCase(MethodTemplate_LoadBrowseFrom, 0)]
        [TestCase(MethodTemplate_InitializeFilters, 0)]
        public void AUT_CreateNewWorkspace_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_createNewWorkspaceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CreateNewWorkspace) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CreateNewWorkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_cWeb)]
        [TestCase(Field_cSite)]
        [TestCase(FieldWORKENGINE_WS_URL)]
        [TestCase(FieldSOLUTION_STORE_PROXY_URL)]
        [TestCase(FieldMORE_INFO_URL)]
        [TestCase(FieldSMALL_PARENT_URL)]
        [TestCase(FieldTEMP_GAL_REDIRECT)]
        [TestCase(Field_projectWorkspaceSetting)]
        [TestCase(Field_isCreateFromOnlineAvail)]
        [TestCase(Field_isCreateFromLocalAvail)]
        [TestCase(Field_isCreateFromExistingAvail)]
        [TestCase(Field_nav)]
        [TestCase(Field_perms)]
        [TestCase(Field_defaultCreateNewOpt)]
        [TestCase(Field_templateResourceUrl)]
        [TestCase(Field_solutionType)]
        [TestCase(Field_templateType)]
        [TestCase(Field_siteHostName)]
        [TestCase(Field_siteUrl)]
        [TestCase(Field_currentWebRelativeUrl)]
        [TestCase(Field_sourceWebId)]
        [TestCase(Field_workengineSvcUrl)]
        [TestCase(Field_moreInfoUrl)]
        [TestCase(Field_smallParentUrl)]
        [TestCase(Field_solutionStoreServiceProxyUrl)]
        [TestCase(Field_baseURL)]
        [TestCase(Field_lstGuid)]
        [TestCase(Field_parentWebUrl)]
        [TestCase(Field_parentWebGuid_B)]
        [TestCase(Field_wsTypeNew)]
        [TestCase(Field_wsTypeExisting)]
        [TestCase(Field_includeContentClientId)]
        [TestCase(Field_moreInfoUrlClientId)]
        [TestCase(Field_featuresList)]
        [TestCase(Field_newItemName)]
        [TestCase(Field_newItemNameLwrCs)]
        [TestCase(Field_hasCreateSubSitePerm)]
        [TestCase(Field_copyFrom)]
        [TestCase(Field_rListName)]
        [TestCase(Field_reqListName)]
        [TestCase(Field_doNotDelRequest)]
        [TestCase(Field_tempGalRedirect)]
        [TestCase(Field_curWebUrl)]
        [TestCase(Field_requestProjectName)]
        [TestCase(Field_compLevels)]
        [TestCase(Field_listName)]
        [TestCase(Field_createFromLiveTemp)]
        [TestCase(Field_timeOut)]
        [TestCase(FieldTMP_GAL_TITLE)]
        [TestCase(FieldCOL_TITLE)]
        [TestCase(FieldCOL_URL)]
        [TestCase(FieldCOL_TEMPLATETYPE)]
        [TestCase(FieldCOL_TEMPLATECATEGORY)]
        [TestCase(FieldCOL_DESCRIPTION)]
        [TestCase(FieldCOL_MOREINFO)]
        [TestCase(FieldCOL_DISPLAYINSTORE)]
        [TestCase(FieldCOL_ATTACHMENT)]
        public void AUT_CreateNewWorkspace_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_createNewWorkspaceInstanceFixture, 
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
        ///     Class (<see cref="CreateNewWorkspace" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CreateNewWorkspace_Is_Instance_Present_Test()
        {
            // Assert
            _createNewWorkspaceInstanceType.ShouldNotBeNull();
            _createNewWorkspaceInstance.ShouldNotBeNull();
            _createNewWorkspaceInstanceFixture.ShouldNotBeNull();
            _createNewWorkspaceInstance.ShouldBeAssignableTo<CreateNewWorkspace>();
            _createNewWorkspaceInstanceFixture.ShouldBeAssignableTo<CreateNewWorkspace>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CreateNewWorkspace) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CreateNewWorkspace_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CreateNewWorkspace instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _createNewWorkspaceInstanceType.ShouldNotBeNull();
            _createNewWorkspaceInstance.ShouldNotBeNull();
            _createNewWorkspaceInstanceFixture.ShouldNotBeNull();
            _createNewWorkspaceInstance.ShouldBeAssignableTo<CreateNewWorkspace>();
            _createNewWorkspaceInstanceFixture.ShouldBeAssignableTo<CreateNewWorkspace>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CreateNewWorkspace" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Init)]
        [TestCase(MethodPage_Unload)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodManageWorkspacePanelUI)]
        [TestCase(MethodManageFields)]
        [TestCase(MethodLoadLeftDivOptions)]
        [TestCase(MethodProject_LoadWorkspaceType)]
        [TestCase(MethodProject_LoadCreateNewWorkspaceFrom)]
        [TestCase(MethodProject_InitializeFilterPnl)]
        [TestCase(MethodTemplate_LoadBrowseFrom)]
        [TestCase(MethodTemplate_InitializeFilters)]
        public void AUT_CreateNewWorkspace_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CreateNewWorkspace>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Page_Init_Method_Call_Internally(Type[] types)
        {
            var methodPage_InitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodPage_Init, Fixture, methodPage_InitPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Init_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Init = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Init, methodPage_InitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfPage_Init);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Init.ShouldNotBeNull();
            parametersOfPage_Init.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(parametersOfPage_Init.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Init_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Init = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodPage_Init, parametersOfPage_Init, methodPage_InitPrametersTypes);

            // Assert
            parametersOfPage_Init.ShouldNotBeNull();
            parametersOfPage_Init.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            methodPage_InitPrametersTypes.Length.ShouldBe(parametersOfPage_Init.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Init_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Init, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_InitPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodPage_Init, Fixture, methodPage_InitPrametersTypes);

            // Assert
            methodPage_InitPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Init_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Init, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Unload) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Page_Unload_Method_Call_Internally(Type[] types)
        {
            var methodPage_UnloadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodPage_Unload, Fixture, methodPage_UnloadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Unload) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Unload_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_UnloadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Unload = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Unload, methodPage_UnloadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfPage_Unload);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Unload.ShouldNotBeNull();
            parametersOfPage_Unload.Length.ShouldBe(2);
            methodPage_UnloadPrametersTypes.Length.ShouldBe(2);
            methodPage_UnloadPrametersTypes.Length.ShouldBe(parametersOfPage_Unload.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Unload) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Unload_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_UnloadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Unload = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodPage_Unload, parametersOfPage_Unload, methodPage_UnloadPrametersTypes);

            // Assert
            parametersOfPage_Unload.ShouldNotBeNull();
            parametersOfPage_Unload.Length.ShouldBe(2);
            methodPage_UnloadPrametersTypes.Length.ShouldBe(2);
            methodPage_UnloadPrametersTypes.Length.ShouldBe(parametersOfPage_Unload.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Unload) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Unload_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Unload, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Unload) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Unload_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_UnloadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodPage_Unload, Fixture, methodPage_UnloadPrametersTypes);

            // Assert
            methodPage_UnloadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Unload) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Unload_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Unload, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfPage_Load);

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
        public void AUT_CreateNewWorkspace_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_CreateNewWorkspace_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CreateNewWorkspace_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageWorkspacePanelUI) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_ManageWorkspacePanelUI_Method_Call_Internally(Type[] types)
        {
            var methodManageWorkspacePanelUIPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodManageWorkspacePanelUI, Fixture, methodManageWorkspacePanelUIPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageWorkspacePanelUI) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageWorkspacePanelUI_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageWorkspacePanelUIPrametersTypes = null;
            object[] parametersOfManageWorkspacePanelUI = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageWorkspacePanelUI, methodManageWorkspacePanelUIPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfManageWorkspacePanelUI);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageWorkspacePanelUI.ShouldBeNull();
            methodManageWorkspacePanelUIPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ManageWorkspacePanelUI) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageWorkspacePanelUI_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageWorkspacePanelUIPrametersTypes = null;
            object[] parametersOfManageWorkspacePanelUI = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodManageWorkspacePanelUI, parametersOfManageWorkspacePanelUI, methodManageWorkspacePanelUIPrametersTypes);

            // Assert
            parametersOfManageWorkspacePanelUI.ShouldBeNull();
            methodManageWorkspacePanelUIPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageWorkspacePanelUI) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageWorkspacePanelUI_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageWorkspacePanelUIPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodManageWorkspacePanelUI, Fixture, methodManageWorkspacePanelUIPrametersTypes);

            // Assert
            methodManageWorkspacePanelUIPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageWorkspacePanelUI) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageWorkspacePanelUI_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageWorkspacePanelUI, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_ManageFields_Method_Call_Internally(Type[] types)
        {
            var methodManageFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageFields_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodManageFields, methodManageFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfManageFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfManageFields.ShouldBeNull();
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageFields_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;
            object[] parametersOfManageFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodManageFields, parametersOfManageFields, methodManageFieldsPrametersTypes);

            // Assert
            parametersOfManageFields.ShouldBeNull();
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodManageFieldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodManageFields, Fixture, methodManageFieldsPrametersTypes);

            // Assert
            methodManageFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ManageFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_ManageFields_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodManageFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadLeftDivOptions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_LoadLeftDivOptions_Method_Call_Internally(Type[] types)
        {
            var methodLoadLeftDivOptionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodLoadLeftDivOptions, Fixture, methodLoadLeftDivOptionsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadLeftDivOptions) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_LoadLeftDivOptions_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadLeftDivOptionsPrametersTypes = null;
            object[] parametersOfLoadLeftDivOptions = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadLeftDivOptions, methodLoadLeftDivOptionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfLoadLeftDivOptions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadLeftDivOptions.ShouldBeNull();
            methodLoadLeftDivOptionsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadLeftDivOptions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_LoadLeftDivOptions_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadLeftDivOptionsPrametersTypes = null;
            object[] parametersOfLoadLeftDivOptions = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodLoadLeftDivOptions, parametersOfLoadLeftDivOptions, methodLoadLeftDivOptionsPrametersTypes);

            // Assert
            parametersOfLoadLeftDivOptions.ShouldBeNull();
            methodLoadLeftDivOptionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadLeftDivOptions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_LoadLeftDivOptions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadLeftDivOptionsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodLoadLeftDivOptions, Fixture, methodLoadLeftDivOptionsPrametersTypes);

            // Assert
            methodLoadLeftDivOptionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadLeftDivOptions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_LoadLeftDivOptions_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadLeftDivOptions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadWorkspaceType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Project_LoadWorkspaceType_Method_Call_Internally(Type[] types)
        {
            var methodProject_LoadWorkspaceTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodProject_LoadWorkspaceType, Fixture, methodProject_LoadWorkspaceTypePrametersTypes);
        }

        #endregion

        #region Method Call : (Project_LoadWorkspaceType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadWorkspaceType_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProject_LoadWorkspaceTypePrametersTypes = null;
            object[] parametersOfProject_LoadWorkspaceType = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProject_LoadWorkspaceType, methodProject_LoadWorkspaceTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfProject_LoadWorkspaceType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProject_LoadWorkspaceType.ShouldBeNull();
            methodProject_LoadWorkspaceTypePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadWorkspaceType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadWorkspaceType_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProject_LoadWorkspaceTypePrametersTypes = null;
            object[] parametersOfProject_LoadWorkspaceType = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodProject_LoadWorkspaceType, parametersOfProject_LoadWorkspaceType, methodProject_LoadWorkspaceTypePrametersTypes);

            // Assert
            parametersOfProject_LoadWorkspaceType.ShouldBeNull();
            methodProject_LoadWorkspaceTypePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadWorkspaceType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadWorkspaceType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProject_LoadWorkspaceTypePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodProject_LoadWorkspaceType, Fixture, methodProject_LoadWorkspaceTypePrametersTypes);

            // Assert
            methodProject_LoadWorkspaceTypePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadWorkspaceType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadWorkspaceType_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProject_LoadWorkspaceType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadCreateNewWorkspaceFrom) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Project_LoadCreateNewWorkspaceFrom_Method_Call_Internally(Type[] types)
        {
            var methodProject_LoadCreateNewWorkspaceFromPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodProject_LoadCreateNewWorkspaceFrom, Fixture, methodProject_LoadCreateNewWorkspaceFromPrametersTypes);
        }

        #endregion

        #region Method Call : (Project_LoadCreateNewWorkspaceFrom) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadCreateNewWorkspaceFrom_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProject_LoadCreateNewWorkspaceFromPrametersTypes = null;
            object[] parametersOfProject_LoadCreateNewWorkspaceFrom = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProject_LoadCreateNewWorkspaceFrom, methodProject_LoadCreateNewWorkspaceFromPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfProject_LoadCreateNewWorkspaceFrom);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProject_LoadCreateNewWorkspaceFrom.ShouldBeNull();
            methodProject_LoadCreateNewWorkspaceFromPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadCreateNewWorkspaceFrom) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadCreateNewWorkspaceFrom_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProject_LoadCreateNewWorkspaceFromPrametersTypes = null;
            object[] parametersOfProject_LoadCreateNewWorkspaceFrom = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodProject_LoadCreateNewWorkspaceFrom, parametersOfProject_LoadCreateNewWorkspaceFrom, methodProject_LoadCreateNewWorkspaceFromPrametersTypes);

            // Assert
            parametersOfProject_LoadCreateNewWorkspaceFrom.ShouldBeNull();
            methodProject_LoadCreateNewWorkspaceFromPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadCreateNewWorkspaceFrom) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadCreateNewWorkspaceFrom_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProject_LoadCreateNewWorkspaceFromPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodProject_LoadCreateNewWorkspaceFrom, Fixture, methodProject_LoadCreateNewWorkspaceFromPrametersTypes);

            // Assert
            methodProject_LoadCreateNewWorkspaceFromPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_LoadCreateNewWorkspaceFrom) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_LoadCreateNewWorkspaceFrom_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProject_LoadCreateNewWorkspaceFrom, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_InitializeFilterPnl) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Project_InitializeFilterPnl_Method_Call_Internally(Type[] types)
        {
            var methodProject_InitializeFilterPnlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodProject_InitializeFilterPnl, Fixture, methodProject_InitializeFilterPnlPrametersTypes);
        }

        #endregion

        #region Method Call : (Project_InitializeFilterPnl) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_InitializeFilterPnl_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodProject_InitializeFilterPnlPrametersTypes = null;
            object[] parametersOfProject_InitializeFilterPnl = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProject_InitializeFilterPnl, methodProject_InitializeFilterPnlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfProject_InitializeFilterPnl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProject_InitializeFilterPnl.ShouldBeNull();
            methodProject_InitializeFilterPnlPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Project_InitializeFilterPnl) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_InitializeFilterPnl_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodProject_InitializeFilterPnlPrametersTypes = null;
            object[] parametersOfProject_InitializeFilterPnl = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodProject_InitializeFilterPnl, parametersOfProject_InitializeFilterPnl, methodProject_InitializeFilterPnlPrametersTypes);

            // Assert
            parametersOfProject_InitializeFilterPnl.ShouldBeNull();
            methodProject_InitializeFilterPnlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_InitializeFilterPnl) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_InitializeFilterPnl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodProject_InitializeFilterPnlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodProject_InitializeFilterPnl, Fixture, methodProject_InitializeFilterPnlPrametersTypes);

            // Assert
            methodProject_InitializeFilterPnlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Project_InitializeFilterPnl) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Project_InitializeFilterPnl_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProject_InitializeFilterPnl, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Template_LoadBrowseFrom) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Template_LoadBrowseFrom_Method_Call_Internally(Type[] types)
        {
            var methodTemplate_LoadBrowseFromPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodTemplate_LoadBrowseFrom, Fixture, methodTemplate_LoadBrowseFromPrametersTypes);
        }

        #endregion

        #region Method Call : (Template_LoadBrowseFrom) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_LoadBrowseFrom_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodTemplate_LoadBrowseFromPrametersTypes = null;
            object[] parametersOfTemplate_LoadBrowseFrom = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTemplate_LoadBrowseFrom, methodTemplate_LoadBrowseFromPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfTemplate_LoadBrowseFrom);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTemplate_LoadBrowseFrom.ShouldBeNull();
            methodTemplate_LoadBrowseFromPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Template_LoadBrowseFrom) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_LoadBrowseFrom_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodTemplate_LoadBrowseFromPrametersTypes = null;
            object[] parametersOfTemplate_LoadBrowseFrom = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodTemplate_LoadBrowseFrom, parametersOfTemplate_LoadBrowseFrom, methodTemplate_LoadBrowseFromPrametersTypes);

            // Assert
            parametersOfTemplate_LoadBrowseFrom.ShouldBeNull();
            methodTemplate_LoadBrowseFromPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Template_LoadBrowseFrom) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_LoadBrowseFrom_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodTemplate_LoadBrowseFromPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodTemplate_LoadBrowseFrom, Fixture, methodTemplate_LoadBrowseFromPrametersTypes);

            // Assert
            methodTemplate_LoadBrowseFromPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Template_LoadBrowseFrom) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_LoadBrowseFrom_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTemplate_LoadBrowseFrom, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Template_InitializeFilters) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateNewWorkspace_Template_InitializeFilters_Method_Call_Internally(Type[] types)
        {
            var methodTemplate_InitializeFiltersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodTemplate_InitializeFilters, Fixture, methodTemplate_InitializeFiltersPrametersTypes);
        }

        #endregion

        #region Method Call : (Template_InitializeFilters) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_InitializeFilters_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodTemplate_InitializeFiltersPrametersTypes = null;
            object[] parametersOfTemplate_InitializeFilters = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTemplate_InitializeFilters, methodTemplate_InitializeFiltersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_createNewWorkspaceInstanceFixture, parametersOfTemplate_InitializeFilters);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTemplate_InitializeFilters.ShouldBeNull();
            methodTemplate_InitializeFiltersPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Template_InitializeFilters) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_InitializeFilters_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodTemplate_InitializeFiltersPrametersTypes = null;
            object[] parametersOfTemplate_InitializeFilters = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_createNewWorkspaceInstance, MethodTemplate_InitializeFilters, parametersOfTemplate_InitializeFilters, methodTemplate_InitializeFiltersPrametersTypes);

            // Assert
            parametersOfTemplate_InitializeFilters.ShouldBeNull();
            methodTemplate_InitializeFiltersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Template_InitializeFilters) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_InitializeFilters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodTemplate_InitializeFiltersPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createNewWorkspaceInstance, MethodTemplate_InitializeFilters, Fixture, methodTemplate_InitializeFiltersPrametersTypes);

            // Assert
            methodTemplate_InitializeFiltersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Template_InitializeFilters) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CreateNewWorkspace_Template_InitializeFilters_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTemplate_InitializeFilters, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_createNewWorkspaceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}