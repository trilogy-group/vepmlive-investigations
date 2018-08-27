using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SolutionStoreProxy" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class SolutionStoreProxyTest : AbstractBaseSetupTypedTest<SolutionStoreProxy>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SolutionStoreProxy) Initializer

        private const string MethodInitializePropAndFlds = "InitializePropAndFlds";
        private const string MethodCallWorkEngineDotComSvc = "CallWorkEngineDotComSvc";
        private const string MethodCallWorkEngineListSvc = "CallWorkEngineListSvc";
        private const string MethodCallWorkEngineCopySvc = "CallWorkEngineCopySvc";
        private const string MethodList_GetListItems_InXml = "List_GetListItems_InXml";
        private const string MethodList_GetList_InXml = "List_GetList_InXml";
        private const string MethodList_GetList_InJSON = "List_GetList_InJSON";
        private const string MethodList_GetListItems_InJSON = "List_GetListItems_InJSON";
        private const string MethodSimplifySPGetListItemsXml = "SimplifySPGetListItemsXml";
        private const string MethodSimplifySPGetListXml = "SimplifySPGetListXml";
        private const string MethodGetDefaultXMLWriterSettings = "GetDefaultXMLWriterSettings";
        private const string MethodPage_Load = "Page_Load";
        private const string Field_data = "_data";
        private const string Field_dataManager = "_dataManager";
        private const string Field_webSvcName = "_webSvcName";
        private const string Field_webSvcMethod = "_webSvcMethod";
        private const string Field_compLevels = "_compLevels";
        private const string Field_solutionType = "_solutionType";
        private const string FieldWEB_SVC_NAME = "WEB_SVC_NAME";
        private const string FieldWEB_SVC_METHOD = "WEB_SVC_METHOD";
        private Type _solutionStoreProxyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SolutionStoreProxy _solutionStoreProxyInstance;
        private SolutionStoreProxy _solutionStoreProxyInstanceFixture;

        #region General Initializer : Class (SolutionStoreProxy) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SolutionStoreProxy" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _solutionStoreProxyInstanceType = typeof(SolutionStoreProxy);
            _solutionStoreProxyInstanceFixture = Create(true);
            _solutionStoreProxyInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SolutionStoreProxy)

        #region General Initializer : Class (SolutionStoreProxy) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SolutionStoreProxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitializePropAndFlds, 0)]
        [TestCase(MethodCallWorkEngineDotComSvc, 0)]
        [TestCase(MethodCallWorkEngineListSvc, 0)]
        [TestCase(MethodCallWorkEngineCopySvc, 0)]
        [TestCase(MethodList_GetListItems_InXml, 0)]
        [TestCase(MethodList_GetListItems_InXml, 1)]
        [TestCase(MethodList_GetList_InXml, 0)]
        [TestCase(MethodList_GetList_InJSON, 0)]
        [TestCase(MethodList_GetListItems_InJSON, 0)]
        [TestCase(MethodSimplifySPGetListItemsXml, 0)]
        [TestCase(MethodSimplifySPGetListXml, 0)]
        [TestCase(MethodGetDefaultXMLWriterSettings, 0)]
        [TestCase(MethodPage_Load, 0)]
        public void AUT_SolutionStoreProxy_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_solutionStoreProxyInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SolutionStoreProxy) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SolutionStoreProxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_data)]
        [TestCase(Field_dataManager)]
        [TestCase(Field_webSvcName)]
        [TestCase(Field_webSvcMethod)]
        [TestCase(Field_compLevels)]
        [TestCase(Field_solutionType)]
        [TestCase(FieldWEB_SVC_NAME)]
        [TestCase(FieldWEB_SVC_METHOD)]
        public void AUT_SolutionStoreProxy_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_solutionStoreProxyInstanceFixture, 
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
        ///     Class (<see cref="SolutionStoreProxy" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SolutionStoreProxy_Is_Instance_Present_Test()
        {
            // Assert
            _solutionStoreProxyInstanceType.ShouldNotBeNull();
            _solutionStoreProxyInstance.ShouldNotBeNull();
            _solutionStoreProxyInstanceFixture.ShouldNotBeNull();
            _solutionStoreProxyInstance.ShouldBeAssignableTo<SolutionStoreProxy>();
            _solutionStoreProxyInstanceFixture.ShouldBeAssignableTo<SolutionStoreProxy>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SolutionStoreProxy) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SolutionStoreProxy_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SolutionStoreProxy instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _solutionStoreProxyInstanceType.ShouldNotBeNull();
            _solutionStoreProxyInstance.ShouldNotBeNull();
            _solutionStoreProxyInstanceFixture.ShouldNotBeNull();
            _solutionStoreProxyInstance.ShouldBeAssignableTo<SolutionStoreProxy>();
            _solutionStoreProxyInstanceFixture.ShouldBeAssignableTo<SolutionStoreProxy>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SolutionStoreProxy" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitializePropAndFlds)]
        [TestCase(MethodCallWorkEngineDotComSvc)]
        [TestCase(MethodCallWorkEngineListSvc)]
        [TestCase(MethodCallWorkEngineCopySvc)]
        [TestCase(MethodList_GetListItems_InXml)]
        [TestCase(MethodList_GetList_InXml)]
        [TestCase(MethodList_GetList_InJSON)]
        [TestCase(MethodList_GetListItems_InJSON)]
        [TestCase(MethodSimplifySPGetListItemsXml)]
        [TestCase(MethodSimplifySPGetListXml)]
        [TestCase(MethodGetDefaultXMLWriterSettings)]
        [TestCase(MethodPage_Load)]
        public void AUT_SolutionStoreProxy_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SolutionStoreProxy>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitializePropAndFlds) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_InitializePropAndFlds_Method_Call_Internally(Type[] types)
        {
            var methodInitializePropAndFldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodInitializePropAndFlds, Fixture, methodInitializePropAndFldsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializePropAndFlds) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_InitializePropAndFlds_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializePropAndFldsPrametersTypes = null;
            object[] parametersOfInitializePropAndFlds = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializePropAndFlds, methodInitializePropAndFldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfInitializePropAndFlds);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializePropAndFlds.ShouldBeNull();
            methodInitializePropAndFldsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializePropAndFlds) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_InitializePropAndFlds_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializePropAndFldsPrametersTypes = null;
            object[] parametersOfInitializePropAndFlds = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodInitializePropAndFlds, parametersOfInitializePropAndFlds, methodInitializePropAndFldsPrametersTypes);

            // Assert
            parametersOfInitializePropAndFlds.ShouldBeNull();
            methodInitializePropAndFldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializePropAndFlds) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_InitializePropAndFlds_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializePropAndFldsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodInitializePropAndFlds, Fixture, methodInitializePropAndFldsPrametersTypes);

            // Assert
            methodInitializePropAndFldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializePropAndFlds) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_InitializePropAndFlds_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializePropAndFlds, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineDotComSvc) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_CallWorkEngineDotComSvc_Method_Call_Internally(Type[] types)
        {
            var methodCallWorkEngineDotComSvcPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodCallWorkEngineDotComSvc, Fixture, methodCallWorkEngineDotComSvcPrametersTypes);
        }

        #endregion

        #region Method Call : (CallWorkEngineDotComSvc) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineDotComSvc_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineDotComSvcPrametersTypes = null;
            object[] parametersOfCallWorkEngineDotComSvc = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCallWorkEngineDotComSvc, methodCallWorkEngineDotComSvcPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfCallWorkEngineDotComSvc);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCallWorkEngineDotComSvc.ShouldBeNull();
            methodCallWorkEngineDotComSvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineDotComSvc) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineDotComSvc_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineDotComSvcPrametersTypes = null;
            object[] parametersOfCallWorkEngineDotComSvc = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodCallWorkEngineDotComSvc, parametersOfCallWorkEngineDotComSvc, methodCallWorkEngineDotComSvcPrametersTypes);

            // Assert
            parametersOfCallWorkEngineDotComSvc.ShouldBeNull();
            methodCallWorkEngineDotComSvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineDotComSvc) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineDotComSvc_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineDotComSvcPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodCallWorkEngineDotComSvc, Fixture, methodCallWorkEngineDotComSvcPrametersTypes);

            // Assert
            methodCallWorkEngineDotComSvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineDotComSvc) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineDotComSvc_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCallWorkEngineDotComSvc, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineListSvc) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_CallWorkEngineListSvc_Method_Call_Internally(Type[] types)
        {
            var methodCallWorkEngineListSvcPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodCallWorkEngineListSvc, Fixture, methodCallWorkEngineListSvcPrametersTypes);
        }

        #endregion

        #region Method Call : (CallWorkEngineListSvc) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineListSvc_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineListSvcPrametersTypes = null;
            object[] parametersOfCallWorkEngineListSvc = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCallWorkEngineListSvc, methodCallWorkEngineListSvcPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfCallWorkEngineListSvc);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCallWorkEngineListSvc.ShouldBeNull();
            methodCallWorkEngineListSvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineListSvc) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineListSvc_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineListSvcPrametersTypes = null;
            object[] parametersOfCallWorkEngineListSvc = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodCallWorkEngineListSvc, parametersOfCallWorkEngineListSvc, methodCallWorkEngineListSvcPrametersTypes);

            // Assert
            parametersOfCallWorkEngineListSvc.ShouldBeNull();
            methodCallWorkEngineListSvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineListSvc) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineListSvc_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineListSvcPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodCallWorkEngineListSvc, Fixture, methodCallWorkEngineListSvcPrametersTypes);

            // Assert
            methodCallWorkEngineListSvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineListSvc) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineListSvc_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCallWorkEngineListSvc, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineCopySvc) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_CallWorkEngineCopySvc_Method_Call_Internally(Type[] types)
        {
            var methodCallWorkEngineCopySvcPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodCallWorkEngineCopySvc, Fixture, methodCallWorkEngineCopySvcPrametersTypes);
        }

        #endregion

        #region Method Call : (CallWorkEngineCopySvc) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineCopySvc_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineCopySvcPrametersTypes = null;
            object[] parametersOfCallWorkEngineCopySvc = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCallWorkEngineCopySvc, methodCallWorkEngineCopySvcPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfCallWorkEngineCopySvc);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCallWorkEngineCopySvc.ShouldBeNull();
            methodCallWorkEngineCopySvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineCopySvc) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineCopySvc_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineCopySvcPrametersTypes = null;
            object[] parametersOfCallWorkEngineCopySvc = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodCallWorkEngineCopySvc, parametersOfCallWorkEngineCopySvc, methodCallWorkEngineCopySvcPrametersTypes);

            // Assert
            parametersOfCallWorkEngineCopySvc.ShouldBeNull();
            methodCallWorkEngineCopySvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineCopySvc) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineCopySvc_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCallWorkEngineCopySvcPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodCallWorkEngineCopySvc, Fixture, methodCallWorkEngineCopySvcPrametersTypes);

            // Assert
            methodCallWorkEngineCopySvcPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CallWorkEngineCopySvc) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_CallWorkEngineCopySvc_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCallWorkEngineCopySvc, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Internally(Type[] types)
        {
            var methodList_GetListItems_InXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetListItems_InXml, Fixture, methodList_GetListItems_InXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var inJSON = CreateType<bool>();
            var methodList_GetListItems_InXmlPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfList_GetListItems_InXml = { inJSON };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodList_GetListItems_InXml, methodList_GetListItems_InXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfList_GetListItems_InXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfList_GetListItems_InXml.ShouldNotBeNull();
            parametersOfList_GetListItems_InXml.Length.ShouldBe(1);
            methodList_GetListItems_InXmlPrametersTypes.Length.ShouldBe(1);
            methodList_GetListItems_InXmlPrametersTypes.Length.ShouldBe(parametersOfList_GetListItems_InXml.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var inJSON = CreateType<bool>();
            var methodList_GetListItems_InXmlPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfList_GetListItems_InXml = { inJSON };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodList_GetListItems_InXml, parametersOfList_GetListItems_InXml, methodList_GetListItems_InXmlPrametersTypes);

            // Assert
            parametersOfList_GetListItems_InXml.ShouldNotBeNull();
            parametersOfList_GetListItems_InXml.Length.ShouldBe(1);
            methodList_GetListItems_InXmlPrametersTypes.Length.ShouldBe(1);
            methodList_GetListItems_InXmlPrametersTypes.Length.ShouldBe(parametersOfList_GetListItems_InXml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodList_GetListItems_InXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodList_GetListItems_InXmlPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetListItems_InXml, Fixture, methodList_GetListItems_InXmlPrametersTypes);

            // Assert
            methodList_GetListItems_InXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodList_GetListItems_InXml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodList_GetListItems_InXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetListItems_InXml, Fixture, methodList_GetListItems_InXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodList_GetListItems_InXmlPrametersTypes = null;
            object[] parametersOfList_GetListItems_InXml = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodList_GetListItems_InXml, methodList_GetListItems_InXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfList_GetListItems_InXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfList_GetListItems_InXml.ShouldBeNull();
            methodList_GetListItems_InXmlPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodList_GetListItems_InXmlPrametersTypes = null;
            object[] parametersOfList_GetListItems_InXml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodList_GetListItems_InXml, parametersOfList_GetListItems_InXml, methodList_GetListItems_InXmlPrametersTypes);

            // Assert
            parametersOfList_GetListItems_InXml.ShouldBeNull();
            methodList_GetListItems_InXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodList_GetListItems_InXmlPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetListItems_InXml, Fixture, methodList_GetListItems_InXmlPrametersTypes);

            // Assert
            methodList_GetListItems_InXmlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InXml_Method_Call_Overloading_Of_1_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodList_GetListItems_InXml, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InXml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_List_GetList_InXml_Method_Call_Internally(Type[] types)
        {
            var methodList_GetList_InXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetList_InXml, Fixture, methodList_GetList_InXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (List_GetList_InXml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InXml_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var inJSON = CreateType<bool>();
            var methodList_GetList_InXmlPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfList_GetList_InXml = { inJSON };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodList_GetList_InXml, methodList_GetList_InXmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfList_GetList_InXml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfList_GetList_InXml.ShouldNotBeNull();
            parametersOfList_GetList_InXml.Length.ShouldBe(1);
            methodList_GetList_InXmlPrametersTypes.Length.ShouldBe(1);
            methodList_GetList_InXmlPrametersTypes.Length.ShouldBe(parametersOfList_GetList_InXml.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InXml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InXml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var inJSON = CreateType<bool>();
            var methodList_GetList_InXmlPrametersTypes = new Type[] { typeof(bool) };
            object[] parametersOfList_GetList_InXml = { inJSON };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodList_GetList_InXml, parametersOfList_GetList_InXml, methodList_GetList_InXmlPrametersTypes);

            // Assert
            parametersOfList_GetList_InXml.ShouldNotBeNull();
            parametersOfList_GetList_InXml.Length.ShouldBe(1);
            methodList_GetList_InXmlPrametersTypes.Length.ShouldBe(1);
            methodList_GetList_InXmlPrametersTypes.Length.ShouldBe(parametersOfList_GetList_InXml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InXml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodList_GetList_InXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (List_GetList_InXml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodList_GetList_InXmlPrametersTypes = new Type[] { typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetList_InXml, Fixture, methodList_GetList_InXmlPrametersTypes);

            // Assert
            methodList_GetList_InXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InXml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InXml_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodList_GetList_InXml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InJSON) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_List_GetList_InJSON_Method_Call_Internally(Type[] types)
        {
            var methodList_GetList_InJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetList_InJSON, Fixture, methodList_GetList_InJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (List_GetList_InJSON) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InJSON_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodList_GetList_InJSONPrametersTypes = null;
            object[] parametersOfList_GetList_InJSON = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodList_GetList_InJSON, methodList_GetList_InJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfList_GetList_InJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfList_GetList_InJSON.ShouldBeNull();
            methodList_GetList_InJSONPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InJSON) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InJSON_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodList_GetList_InJSONPrametersTypes = null;
            object[] parametersOfList_GetList_InJSON = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodList_GetList_InJSON, parametersOfList_GetList_InJSON, methodList_GetList_InJSONPrametersTypes);

            // Assert
            parametersOfList_GetList_InJSON.ShouldBeNull();
            methodList_GetList_InJSONPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InJSON) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodList_GetList_InJSONPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetList_InJSON, Fixture, methodList_GetList_InJSONPrametersTypes);

            // Assert
            methodList_GetList_InJSONPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetList_InJSON) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetList_InJSON_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodList_GetList_InJSON, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InJSON) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_List_GetListItems_InJSON_Method_Call_Internally(Type[] types)
        {
            var methodList_GetListItems_InJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetListItems_InJSON, Fixture, methodList_GetListItems_InJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (List_GetListItems_InJSON) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InJSON_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodList_GetListItems_InJSONPrametersTypes = null;
            object[] parametersOfList_GetListItems_InJSON = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodList_GetListItems_InJSON, methodList_GetListItems_InJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfList_GetListItems_InJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfList_GetListItems_InJSON.ShouldBeNull();
            methodList_GetListItems_InJSONPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InJSON) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InJSON_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodList_GetListItems_InJSONPrametersTypes = null;
            object[] parametersOfList_GetListItems_InJSON = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodList_GetListItems_InJSON, parametersOfList_GetListItems_InJSON, methodList_GetListItems_InJSONPrametersTypes);

            // Assert
            parametersOfList_GetListItems_InJSON.ShouldBeNull();
            methodList_GetListItems_InJSONPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InJSON) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodList_GetListItems_InJSONPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodList_GetListItems_InJSON, Fixture, methodList_GetListItems_InJSONPrametersTypes);

            // Assert
            methodList_GetListItems_InJSONPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (List_GetListItems_InJSON) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_List_GetListItems_InJSON_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodList_GetListItems_InJSON, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SimplifySPGetListItemsXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_SimplifySPGetListItemsXml_Method_Call_Internally(Type[] types)
        {
            var methodSimplifySPGetListItemsXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodSimplifySPGetListItemsXml, Fixture, methodSimplifySPGetListItemsXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (SimplifySPGetListItemsXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListItemsXml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<XmlNode>();
            var methodSimplifySPGetListItemsXmlPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfSimplifySPGetListItemsXml = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSimplifySPGetListItemsXml, methodSimplifySPGetListItemsXmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SolutionStoreProxy, string>(_solutionStoreProxyInstanceFixture, out exception1, parametersOfSimplifySPGetListItemsXml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SolutionStoreProxy, string>(_solutionStoreProxyInstance, MethodSimplifySPGetListItemsXml, parametersOfSimplifySPGetListItemsXml, methodSimplifySPGetListItemsXmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSimplifySPGetListItemsXml.ShouldNotBeNull();
            parametersOfSimplifySPGetListItemsXml.Length.ShouldBe(1);
            methodSimplifySPGetListItemsXmlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfSimplifySPGetListItemsXml));
        }

        #endregion

        #region Method Call : (SimplifySPGetListItemsXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListItemsXml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<XmlNode>();
            var methodSimplifySPGetListItemsXmlPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfSimplifySPGetListItemsXml = { data };

            // Assert
            parametersOfSimplifySPGetListItemsXml.ShouldNotBeNull();
            parametersOfSimplifySPGetListItemsXml.Length.ShouldBe(1);
            methodSimplifySPGetListItemsXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SolutionStoreProxy, string>(_solutionStoreProxyInstance, MethodSimplifySPGetListItemsXml, parametersOfSimplifySPGetListItemsXml, methodSimplifySPGetListItemsXmlPrametersTypes));
        }

        #endregion

        #region Method Call : (SimplifySPGetListItemsXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListItemsXml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSimplifySPGetListItemsXmlPrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodSimplifySPGetListItemsXml, Fixture, methodSimplifySPGetListItemsXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSimplifySPGetListItemsXmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SimplifySPGetListItemsXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListItemsXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSimplifySPGetListItemsXmlPrametersTypes = new Type[] { typeof(XmlNode) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodSimplifySPGetListItemsXml, Fixture, methodSimplifySPGetListItemsXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSimplifySPGetListItemsXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SimplifySPGetListItemsXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListItemsXml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSimplifySPGetListItemsXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SimplifySPGetListItemsXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListItemsXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSimplifySPGetListItemsXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SimplifySPGetListXml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_SimplifySPGetListXml_Method_Call_Internally(Type[] types)
        {
            var methodSimplifySPGetListXmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodSimplifySPGetListXml, Fixture, methodSimplifySPGetListXmlPrametersTypes);
        }

        #endregion

        #region Method Call : (SimplifySPGetListXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListXml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<XmlNode>();
            var methodSimplifySPGetListXmlPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfSimplifySPGetListXml = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSimplifySPGetListXml, methodSimplifySPGetListXmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SolutionStoreProxy, string>(_solutionStoreProxyInstanceFixture, out exception1, parametersOfSimplifySPGetListXml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SolutionStoreProxy, string>(_solutionStoreProxyInstance, MethodSimplifySPGetListXml, parametersOfSimplifySPGetListXml, methodSimplifySPGetListXmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSimplifySPGetListXml.ShouldNotBeNull();
            parametersOfSimplifySPGetListXml.Length.ShouldBe(1);
            methodSimplifySPGetListXmlPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfSimplifySPGetListXml));
        }

        #endregion

        #region Method Call : (SimplifySPGetListXml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListXml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<XmlNode>();
            var methodSimplifySPGetListXmlPrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfSimplifySPGetListXml = { data };

            // Assert
            parametersOfSimplifySPGetListXml.ShouldNotBeNull();
            parametersOfSimplifySPGetListXml.Length.ShouldBe(1);
            methodSimplifySPGetListXmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SolutionStoreProxy, string>(_solutionStoreProxyInstance, MethodSimplifySPGetListXml, parametersOfSimplifySPGetListXml, methodSimplifySPGetListXmlPrametersTypes));
        }

        #endregion

        #region Method Call : (SimplifySPGetListXml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListXml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSimplifySPGetListXmlPrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodSimplifySPGetListXml, Fixture, methodSimplifySPGetListXmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSimplifySPGetListXmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SimplifySPGetListXml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListXml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSimplifySPGetListXmlPrametersTypes = new Type[] { typeof(XmlNode) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodSimplifySPGetListXml, Fixture, methodSimplifySPGetListXmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSimplifySPGetListXmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SimplifySPGetListXml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListXml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSimplifySPGetListXml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SimplifySPGetListXml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_SimplifySPGetListXml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSimplifySPGetListXml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefaultXMLWriterSettings) (Return Type : XmlWriterSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_GetDefaultXMLWriterSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetDefaultXMLWriterSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodGetDefaultXMLWriterSettings, Fixture, methodGetDefaultXMLWriterSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefaultXMLWriterSettings) (Return Type : XmlWriterSettings) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_GetDefaultXMLWriterSettings_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetDefaultXMLWriterSettingsPrametersTypes = null;
            object[] parametersOfGetDefaultXMLWriterSettings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetDefaultXMLWriterSettings, methodGetDefaultXMLWriterSettingsPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetDefaultXMLWriterSettings.ShouldBeNull();
            methodGetDefaultXMLWriterSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfGetDefaultXMLWriterSettings));
        }

        #endregion

        #region Method Call : (GetDefaultXMLWriterSettings) (Return Type : XmlWriterSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_GetDefaultXMLWriterSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDefaultXMLWriterSettingsPrametersTypes = null;
            object[] parametersOfGetDefaultXMLWriterSettings = null; // no parameter present

            // Assert
            parametersOfGetDefaultXMLWriterSettings.ShouldBeNull();
            methodGetDefaultXMLWriterSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<SolutionStoreProxy, XmlWriterSettings>(_solutionStoreProxyInstance, MethodGetDefaultXMLWriterSettings, parametersOfGetDefaultXMLWriterSettings, methodGetDefaultXMLWriterSettingsPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDefaultXMLWriterSettings) (Return Type : XmlWriterSettings) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_GetDefaultXMLWriterSettings_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetDefaultXMLWriterSettingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodGetDefaultXMLWriterSettings, Fixture, methodGetDefaultXMLWriterSettingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetDefaultXMLWriterSettingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultXMLWriterSettings) (Return Type : XmlWriterSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_GetDefaultXMLWriterSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDefaultXMLWriterSettingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodGetDefaultXMLWriterSettings, Fixture, methodGetDefaultXMLWriterSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefaultXMLWriterSettingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefaultXMLWriterSettings) (Return Type : XmlWriterSettings) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_GetDefaultXMLWriterSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefaultXMLWriterSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SolutionStoreProxy_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_solutionStoreProxyInstanceFixture, parametersOfPage_Load);

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
        public void AUT_SolutionStoreProxy_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_solutionStoreProxyInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_SolutionStoreProxy_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_SolutionStoreProxy_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_solutionStoreProxyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SolutionStoreProxy_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_solutionStoreProxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}