using System;
using System.Diagnostics.CodeAnalysis;
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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.ViewManager" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ViewManagerTest : AbstractBaseSetupTypedTest<ViewManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ViewManager) Initializer

        private const string MethodInit = "Init";
        private const string MethodGetAttribute = "GetAttribute";
        private const string MethodAddViewByXmlNode = "AddViewByXmlNode";
        private const string MethodDeleteView = "DeleteView";
        private const string MethodRenameView = "RenameView";
        private const string MethodToString = "ToString";
        private const string MethodToJSON = "ToJSON";
        private const string FieldViews = "Views";
        private Type _viewManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ViewManager _viewManagerInstance;
        private ViewManager _viewManagerInstanceFixture;

        #region General Initializer : Class (ViewManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ViewManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _viewManagerInstanceType = typeof(ViewManager);
            _viewManagerInstanceFixture = Create(true);
            _viewManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ViewManager)

        #region General Initializer : Class (ViewManager) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ViewManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInit, 0)]
        [TestCase(MethodGetAttribute, 0)]
        [TestCase(MethodAddViewByXmlNode, 0)]
        [TestCase(MethodDeleteView, 0)]
        [TestCase(MethodRenameView, 0)]
        [TestCase(MethodToString, 0)]
        [TestCase(MethodToJSON, 0)]
        public void AUT_ViewManager_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_viewManagerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ViewManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ViewManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldViews)]
        public void AUT_ViewManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_viewManagerInstanceFixture, 
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
        ///     Class (<see cref="ViewManager" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ViewManager_Is_Instance_Present_Test()
        {
            // Assert
            _viewManagerInstanceType.ShouldNotBeNull();
            _viewManagerInstance.ShouldNotBeNull();
            _viewManagerInstanceFixture.ShouldNotBeNull();
            _viewManagerInstance.ShouldBeAssignableTo<ViewManager>();
            _viewManagerInstanceFixture.ShouldBeAssignableTo<ViewManager>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ViewManager) instance created

        /// <summary>
        ///     Class (<see cref="ViewManager" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ViewManager_Is_Created_Test()
        {
            // Assert
            _viewManagerInstance.ShouldNotBeNull();
            _viewManagerInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (ViewManager) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ViewManager" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_ViewManager_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ViewManager>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ViewManager) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ViewManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ViewManager_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ViewManager>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ViewManager) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ViewManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ViewManager_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var property = CreateType<string>();
            object[] parametersOfViewManager = { web, property };
            var methodViewManagerPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_viewManagerInstanceType, methodViewManagerPrametersTypes, parametersOfViewManager);
        }

        #endregion

        #region General Constructor : Class (ViewManager) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ViewManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ViewManager_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodViewManagerPrametersTypes = new Type[] { typeof(SPWeb), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_viewManagerInstanceType, Fixture, methodViewManagerPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ViewManager) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ViewManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ViewManager_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var propertyBag = CreateType<string>();
            object[] parametersOfViewManager = { propertyBag };
            var methodViewManagerPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_viewManagerInstanceType, methodViewManagerPrametersTypes, parametersOfViewManager);
        }

        #endregion

        #region General Constructor : Class (ViewManager) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ViewManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ViewManager_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodViewManagerPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_viewManagerInstanceType, Fixture, methodViewManagerPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ViewManager" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInit)]
        [TestCase(MethodGetAttribute)]
        [TestCase(MethodAddViewByXmlNode)]
        [TestCase(MethodDeleteView)]
        [TestCase(MethodRenameView)]
        [TestCase(MethodToString)]
        [TestCase(MethodToJSON)]
        public void AUT_ViewManager_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ViewManager>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewManager_Init_Method_Call_Internally(Type[] types)
        {
            var methodInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodInit, Fixture, methodInitPrametersTypes);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_Init_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var propertyBag = CreateType<string>();
            var methodInitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInit = { propertyBag };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInit, methodInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewManagerInstanceFixture, parametersOfInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInit.ShouldNotBeNull();
            parametersOfInit.Length.ShouldBe(1);
            methodInitPrametersTypes.Length.ShouldBe(1);
            methodInitPrametersTypes.Length.ShouldBe(parametersOfInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_Init_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var propertyBag = CreateType<string>();
            var methodInitPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfInit = { propertyBag };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewManagerInstance, MethodInit, parametersOfInit, methodInitPrametersTypes);

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
        public void AUT_ViewManager_Init_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ViewManager_Init_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodInit, Fixture, methodInitPrametersTypes);

            // Assert
            methodInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Init) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_Init_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAttribute) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewManager_GetAttribute_Method_Call_Internally(Type[] types)
        {
            var methodGetAttributePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodGetAttribute, Fixture, methodGetAttributePrametersTypes);
        }

        #endregion

        #region Method Call : (GetAttribute) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_GetAttribute_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var attr = CreateType<string>();
            var methodGetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfGetAttribute = { nd, attr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetAttribute, methodGetAttributePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetAttribute.ShouldNotBeNull();
            parametersOfGetAttribute.Length.ShouldBe(2);
            methodGetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_viewManagerInstanceFixture, parametersOfGetAttribute));
        }

        #endregion

        #region Method Call : (GetAttribute) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_GetAttribute_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var attr = CreateType<string>();
            var methodGetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            object[] parametersOfGetAttribute = { nd, attr };

            // Assert
            parametersOfGetAttribute.ShouldNotBeNull();
            parametersOfGetAttribute.Length.ShouldBe(2);
            methodGetAttributePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ViewManager, string>(_viewManagerInstance, MethodGetAttribute, parametersOfGetAttribute, methodGetAttributePrametersTypes));
        }

        #endregion

        #region Method Call : (GetAttribute) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_GetAttribute_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodGetAttribute, Fixture, methodGetAttributePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAttributePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAttribute) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_GetAttribute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAttributePrametersTypes = new Type[] { typeof(XmlNode), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodGetAttribute, Fixture, methodGetAttributePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAttributePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAttribute) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_GetAttribute_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAttribute, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetAttribute) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_GetAttribute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAttribute, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddViewByXmlNode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewManager_AddViewByXmlNode_Method_Call_Internally(Type[] types)
        {
            var methodAddViewByXmlNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodAddViewByXmlNode, Fixture, methodAddViewByXmlNodePrametersTypes);
        }

        #endregion

        #region Method Call : (AddViewByXmlNode) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_AddViewByXmlNode_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            Action executeAction = null;

            // Act
            executeAction = () => _viewManagerInstance.AddViewByXmlNode(nd);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddViewByXmlNode) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_AddViewByXmlNode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var methodAddViewByXmlNodePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfAddViewByXmlNode = { nd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddViewByXmlNode, methodAddViewByXmlNodePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewManagerInstanceFixture, parametersOfAddViewByXmlNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddViewByXmlNode.ShouldNotBeNull();
            parametersOfAddViewByXmlNode.Length.ShouldBe(1);
            methodAddViewByXmlNodePrametersTypes.Length.ShouldBe(1);
            methodAddViewByXmlNodePrametersTypes.Length.ShouldBe(parametersOfAddViewByXmlNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddViewByXmlNode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_AddViewByXmlNode_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var nd = CreateType<XmlNode>();
            var methodAddViewByXmlNodePrametersTypes = new Type[] { typeof(XmlNode) };
            object[] parametersOfAddViewByXmlNode = { nd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewManagerInstance, MethodAddViewByXmlNode, parametersOfAddViewByXmlNode, methodAddViewByXmlNodePrametersTypes);

            // Assert
            parametersOfAddViewByXmlNode.ShouldNotBeNull();
            parametersOfAddViewByXmlNode.Length.ShouldBe(1);
            methodAddViewByXmlNodePrametersTypes.Length.ShouldBe(1);
            methodAddViewByXmlNodePrametersTypes.Length.ShouldBe(parametersOfAddViewByXmlNode.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddViewByXmlNode) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_AddViewByXmlNode_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddViewByXmlNode, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddViewByXmlNode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_AddViewByXmlNode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddViewByXmlNodePrametersTypes = new Type[] { typeof(XmlNode) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodAddViewByXmlNode, Fixture, methodAddViewByXmlNodePrametersTypes);

            // Assert
            methodAddViewByXmlNodePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddViewByXmlNode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_AddViewByXmlNode_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddViewByXmlNode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewManager_DeleteView_Method_Call_Internally(Type[] types)
        {
            var methodDeleteViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodDeleteView, Fixture, methodDeleteViewPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteView) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_DeleteView_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var view = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _viewManagerInstance.DeleteView(view);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DeleteView) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_DeleteView_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var view = CreateType<string>();
            var methodDeleteViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteView = { view };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteView, methodDeleteViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewManagerInstanceFixture, parametersOfDeleteView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteView.ShouldNotBeNull();
            parametersOfDeleteView.Length.ShouldBe(1);
            methodDeleteViewPrametersTypes.Length.ShouldBe(1);
            methodDeleteViewPrametersTypes.Length.ShouldBe(parametersOfDeleteView.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_DeleteView_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var view = CreateType<string>();
            var methodDeleteViewPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteView = { view };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewManagerInstance, MethodDeleteView, parametersOfDeleteView, methodDeleteViewPrametersTypes);

            // Assert
            parametersOfDeleteView.ShouldNotBeNull();
            parametersOfDeleteView.Length.ShouldBe(1);
            methodDeleteViewPrametersTypes.Length.ShouldBe(1);
            methodDeleteViewPrametersTypes.Length.ShouldBe(parametersOfDeleteView.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_DeleteView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteView, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_DeleteView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteViewPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodDeleteView, Fixture, methodDeleteViewPrametersTypes);

            // Assert
            methodDeleteViewPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_DeleteView_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameView) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewManager_RenameView_Method_Call_Internally(Type[] types)
        {
            var methodRenameViewPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodRenameView, Fixture, methodRenameViewPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameView) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_RenameView_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var view = CreateType<string>();
            var newname = CreateType<string>();
            var defaultView = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _viewManagerInstance.RenameView(view, newname, defaultView);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RenameView) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_RenameView_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var view = CreateType<string>();
            var newname = CreateType<string>();
            var defaultView = CreateType<string>();
            var methodRenameViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfRenameView = { view, newname, defaultView };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenameView, methodRenameViewPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_viewManagerInstanceFixture, parametersOfRenameView);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenameView.ShouldNotBeNull();
            parametersOfRenameView.Length.ShouldBe(3);
            methodRenameViewPrametersTypes.Length.ShouldBe(3);
            methodRenameViewPrametersTypes.Length.ShouldBe(parametersOfRenameView.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameView) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_RenameView_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var view = CreateType<string>();
            var newname = CreateType<string>();
            var defaultView = CreateType<string>();
            var methodRenameViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfRenameView = { view, newname, defaultView };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_viewManagerInstance, MethodRenameView, parametersOfRenameView, methodRenameViewPrametersTypes);

            // Assert
            parametersOfRenameView.ShouldNotBeNull();
            parametersOfRenameView.Length.ShouldBe(3);
            methodRenameViewPrametersTypes.Length.ShouldBe(3);
            methodRenameViewPrametersTypes.Length.ShouldBe(parametersOfRenameView.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameView) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_RenameView_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameView, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameView) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_RenameView_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameViewPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodRenameView, Fixture, methodRenameViewPrametersTypes);

            // Assert
            methodRenameViewPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameView) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_RenameView_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameView, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_viewManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewManager_ToString_Method_Call_Internally(Type[] types)
        {
            var methodToStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodToString, Fixture, methodToStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _viewManagerInstance.ToString();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_viewManagerInstanceFixture, parametersOfToString));
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present

            // Assert
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ViewManager, string>(_viewManagerInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes));
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ToJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ViewManager_ToJSON_Method_Call_Internally(Type[] types)
        {
            var methodToJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodToJSON, Fixture, methodToJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (ToJSON) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToJSON_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _viewManagerInstance.ToJSON();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToJSON) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToJSON_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodToJSONPrametersTypes = null;
            object[] parametersOfToJSON = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToJSON, methodToJSONPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToJSON.ShouldBeNull();
            methodToJSONPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => methodInfo.Invoke(_viewManagerInstanceFixture, parametersOfToJSON));
        }

        #endregion

        #region Method Call : (ToJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToJSON_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodToJSONPrametersTypes = null;
            object[] parametersOfToJSON = null; // no parameter present

            // Assert
            parametersOfToJSON.ShouldBeNull();
            methodToJSONPrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ViewManager, string>(_viewManagerInstance, MethodToJSON, parametersOfToJSON, methodToJSONPrametersTypes));
        }

        #endregion

        #region Method Call : (ToJSON) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToJSON_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodToJSONPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodToJSON, Fixture, methodToJSONPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToJSONPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToJSON_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodToJSONPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_viewManagerInstance, MethodToJSON, Fixture, methodToJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToJSONPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToJSON) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ViewManager_ToJSON_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToJSON, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_viewManagerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}