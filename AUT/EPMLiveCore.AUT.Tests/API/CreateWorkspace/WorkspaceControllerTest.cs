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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.WorkspaceController" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkspaceControllerTest : AbstractBaseSetupTypedTest<WorkspaceController>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceController) Initializer

        private const string MethodInit = "Init";
        private const string MethodGetFactory = "GetFactory";
        private const string MethodGetTempType = "GetTempType";
        private const string MethodCreateWorkspace = "CreateWorkspace";
        private const string FieldwsFact = "wsFact";
        private const string FieldcreateParams = "createParams";
        private const string FieldcreateResults = "createResults";
        private Type _workspaceControllerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkspaceController _workspaceControllerInstance;
        private WorkspaceController _workspaceControllerInstanceFixture;

        #region General Initializer : Class (WorkspaceController) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceController" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceControllerInstanceType = typeof(WorkspaceController);
            _workspaceControllerInstanceFixture = Create(true);
            _workspaceControllerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceController)

        #region General Initializer : Class (WorkspaceController) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkspaceController" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInit, 0)]
        [TestCase(MethodGetFactory, 0)]
        [TestCase(MethodGetTempType, 0)]
        [TestCase(MethodCreateWorkspace, 0)]
        public void AUT_WorkspaceController_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workspaceControllerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkspaceController) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceController" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldwsFact)]
        [TestCase(FieldcreateParams)]
        [TestCase(FieldcreateResults)]
        public void AUT_WorkspaceController_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workspaceControllerInstanceFixture, 
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
        ///      Class (<see cref="WorkspaceController" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInit)]
        [TestCase(MethodGetFactory)]
        [TestCase(MethodGetTempType)]
        [TestCase(MethodCreateWorkspace)]
        public void AUT_WorkspaceController_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkspaceController>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceController_Init_Method_Call_Internally(Type[] types)
        {
            var methodInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodInit, Fixture, methodInitPrametersTypes);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_Init_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodInitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInit = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInit, methodInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workspaceControllerInstanceFixture, parametersOfInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInit.ShouldNotBeNull();
            parametersOfInit.Length.ShouldBe(1);
            methodInitPrametersTypes.Length.ShouldBe(1);
            methodInitPrametersTypes.Length.ShouldBe(parametersOfInit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_Init_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodInitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInit = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workspaceControllerInstance, MethodInit, parametersOfInit, methodInitPrametersTypes);

            // Assert
            parametersOfInit.ShouldNotBeNull();
            parametersOfInit.Length.ShouldBe(1);
            methodInitPrametersTypes.Length.ShouldBe(1);
            methodInitPrametersTypes.Length.ShouldBe(parametersOfInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_Init_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodInit, Fixture, methodInitPrametersTypes);

            // Assert
            methodInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_Init_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceControllerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFactory) (Return Type : WorkspaceFactory) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceController_GetFactory_Method_Call_Internally(Type[] types)
        {
            var methodGetFactoryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodGetFactory, Fixture, methodGetFactoryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFactory) (Return Type : WorkspaceFactory) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetFactory_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetFactoryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFactory = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFactory, methodGetFactoryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceController, WorkspaceFactory>(_workspaceControllerInstanceFixture, out exception1, parametersOfGetFactory);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceController, WorkspaceFactory>(_workspaceControllerInstance, MethodGetFactory, parametersOfGetFactory, methodGetFactoryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFactory.ShouldNotBeNull();
            parametersOfGetFactory.Length.ShouldBe(1);
            methodGetFactoryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_workspaceControllerInstanceFixture, parametersOfGetFactory));
        }

        #endregion

        #region Method Call : (GetFactory) (Return Type : WorkspaceFactory) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetFactory_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetFactoryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFactory = { data };

            // Assert
            parametersOfGetFactory.ShouldNotBeNull();
            parametersOfGetFactory.Length.ShouldBe(1);
            methodGetFactoryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceController, WorkspaceFactory>(_workspaceControllerInstance, MethodGetFactory, parametersOfGetFactory, methodGetFactoryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFactory) (Return Type : WorkspaceFactory) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetFactory_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFactoryPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodGetFactory, Fixture, methodGetFactoryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFactoryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFactory) (Return Type : WorkspaceFactory) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetFactory_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFactoryPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodGetFactory, Fixture, methodGetFactoryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFactoryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFactory) (Return Type : WorkspaceFactory) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetFactory_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFactory, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceControllerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFactory) (Return Type : WorkspaceFactory) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetFactory_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFactory, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTempType) (Return Type : TemplateSource) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceController_GetTempType_Method_Call_Internally(Type[] types)
        {
            var methodGetTempTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodGetTempType, Fixture, methodGetTempTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTempType) (Return Type : TemplateSource) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetTempType_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetTempTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTempType = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTempType, methodGetTempTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceController, TemplateSource>(_workspaceControllerInstanceFixture, out exception1, parametersOfGetTempType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceController, TemplateSource>(_workspaceControllerInstance, MethodGetTempType, parametersOfGetTempType, methodGetTempTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTempType.ShouldNotBeNull();
            parametersOfGetTempType.Length.ShouldBe(1);
            methodGetTempTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceController, TemplateSource>(_workspaceControllerInstance, MethodGetTempType, parametersOfGetTempType, methodGetTempTypePrametersTypes));
        }

        #endregion

        #region Method Call : (GetTempType) (Return Type : TemplateSource) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetTempType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetTempTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTempType = { data };

            // Assert
            parametersOfGetTempType.ShouldNotBeNull();
            parametersOfGetTempType.Length.ShouldBe(1);
            methodGetTempTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceController, TemplateSource>(_workspaceControllerInstance, MethodGetTempType, parametersOfGetTempType, methodGetTempTypePrametersTypes));
        }

        #endregion

        #region Method Call : (GetTempType) (Return Type : TemplateSource) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetTempType_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTempTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodGetTempType, Fixture, methodGetTempTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTempTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTempType) (Return Type : TemplateSource) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetTempType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTempTypePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodGetTempType, Fixture, methodGetTempTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTempTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTempType) (Return Type : TemplateSource) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetTempType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTempType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceControllerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTempType) (Return Type : TemplateSource) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_GetTempType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTempType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceController_CreateWorkspace_Method_Call_Internally(Type[] types)
        {
            var methodCreateWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_CreateWorkspace_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _workspaceControllerInstance.CreateWorkspace();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_CreateWorkspace_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            object[] parametersOfCreateWorkspace = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateWorkspace, methodCreateWorkspacePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WorkspaceController, ICreatedWorkspaceInfo>(_workspaceControllerInstanceFixture, out exception1, parametersOfCreateWorkspace);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WorkspaceController, ICreatedWorkspaceInfo>(_workspaceControllerInstance, MethodCreateWorkspace, parametersOfCreateWorkspace, methodCreateWorkspacePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateWorkspace.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_workspaceControllerInstanceFixture, parametersOfCreateWorkspace));
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_CreateWorkspace_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            object[] parametersOfCreateWorkspace = null; // no parameter present

            // Assert
            parametersOfCreateWorkspace.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<WorkspaceController, ICreatedWorkspaceInfo>(_workspaceControllerInstance, MethodCreateWorkspace, parametersOfCreateWorkspace, methodCreateWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_CreateWorkspace_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_CreateWorkspace_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workspaceControllerInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceController_CreateWorkspace_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceControllerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}