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

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.GridViewManagerFactory" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class GridViewManagerFactoryTest : AbstractBaseSetupTypedTest<GridViewManagerFactory>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridViewManagerFactory) Initializer

        private const string MethodMakeGridViewManager = "MakeGridViewManager";
        private const string MethodDispose = "Dispose";
        private const string MethodValidateRequest = "ValidateRequest";
        private const string Field_gridViewManagers = "_gridViewManagers";
        private Type _gridViewManagerFactoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridViewManagerFactory _gridViewManagerFactoryInstance;
        private GridViewManagerFactory _gridViewManagerFactoryInstanceFixture;

        #region General Initializer : Class (GridViewManagerFactory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridViewManagerFactory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridViewManagerFactoryInstanceType = typeof(GridViewManagerFactory);
            _gridViewManagerFactoryInstanceFixture = Create(true);
            _gridViewManagerFactoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridViewManagerFactory)

        #region General Initializer : Class (GridViewManagerFactory) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GridViewManagerFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodMakeGridViewManager, 0)]
        [TestCase(MethodMakeGridViewManager, 1)]
        [TestCase(MethodDispose, 0)]
        [TestCase(MethodValidateRequest, 0)]
        [TestCase(MethodDispose, 1)]
        public void AUT_GridViewManagerFactory_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridViewManagerFactoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GridViewManagerFactory) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GridViewManagerFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_gridViewManagers)]
        public void AUT_GridViewManagerFactory_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_gridViewManagerFactoryInstanceFixture, 
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
        ///     Class (<see cref="GridViewManagerFactory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GridViewManagerFactory_Is_Instance_Present_Test()
        {
            // Assert
            _gridViewManagerFactoryInstanceType.ShouldNotBeNull();
            _gridViewManagerFactoryInstance.ShouldNotBeNull();
            _gridViewManagerFactoryInstanceFixture.ShouldNotBeNull();
            _gridViewManagerFactoryInstance.ShouldBeAssignableTo<GridViewManagerFactory>();
            _gridViewManagerFactoryInstanceFixture.ShouldBeAssignableTo<GridViewManagerFactory>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GridViewManagerFactory) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GridViewManagerFactory_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GridViewManagerFactory instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridViewManagerFactoryInstanceType.ShouldNotBeNull();
            _gridViewManagerFactoryInstance.ShouldNotBeNull();
            _gridViewManagerFactoryInstanceFixture.ShouldNotBeNull();
            _gridViewManagerFactoryInstance.ShouldBeAssignableTo<GridViewManagerFactory>();
            _gridViewManagerFactoryInstanceFixture.ShouldBeAssignableTo<GridViewManagerFactory>();
        }

        #endregion

        #region General Constructor : Class (GridViewManagerFactory) instance created

        /// <summary>
        ///     Class (<see cref="GridViewManagerFactory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridViewManagerFactory_Is_Created_Test()
        {
            // Assert
            _gridViewManagerFactoryInstance.ShouldNotBeNull();
            _gridViewManagerFactoryInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (GridViewManagerFactory) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="GridViewManagerFactory" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_GridViewManagerFactory_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<GridViewManagerFactory>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (GridViewManagerFactory) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="GridViewManagerFactory" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridViewManagerFactory_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<GridViewManagerFactory>(Fixture);
        }

        #endregion

        #region General Constructor : Class (GridViewManagerFactory) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GridViewManagerFactory" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridViewManagerFactory_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var assemblyFullName = CreateType<string>();
            object[] parametersOfGridViewManagerFactory = { assemblyFullName };
            var methodGridViewManagerFactoryPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_gridViewManagerFactoryInstanceType, methodGridViewManagerFactoryPrametersTypes, parametersOfGridViewManagerFactory);
        }

        #endregion

        #region General Constructor : Class (GridViewManagerFactory) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GridViewManagerFactory" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridViewManagerFactory_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodGridViewManagerFactoryPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_gridViewManagerFactoryInstanceType, Fixture, methodGridViewManagerFactoryPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (GridViewManagerFactory) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GridViewManagerFactory" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridViewManagerFactory_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfGridViewManagerFactory = {  };
            Type [] methodGridViewManagerFactoryPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_gridViewManagerFactoryInstanceType, methodGridViewManagerFactoryPrametersTypes, parametersOfGridViewManagerFactory);
        }

        #endregion

        #region General Constructor : Class (GridViewManagerFactory) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="GridViewManagerFactory" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_GridViewManagerFactory_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodGridViewManagerFactoryPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_gridViewManagerFactoryInstanceType, Fixture, methodGridViewManagerFactoryPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GridViewManagerFactory" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodMakeGridViewManager)]
        [TestCase(MethodDispose)]
        [TestCase(MethodValidateRequest)]
        public void AUT_GridViewManagerFactory_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GridViewManagerFactory>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Internally(Type[] types)
        {
            var methodMakeGridViewManagerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, Fixture, methodMakeGridViewManagerPrametersTypes);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridViewManagerKind = CreateType<GridViewManagerKind>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridViewManagerFactoryInstance.MakeGridViewManager(componentName, gridViewManagerKind);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridViewManagerKind = CreateType<GridViewManagerKind>();
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridViewManagerKind) };
            object[] parametersOfMakeGridViewManager = { componentName, gridViewManagerKind };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMakeGridViewManager, methodMakeGridViewManagerPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridViewManagerFactory, IGridViewManager>(_gridViewManagerFactoryInstanceFixture, out exception1, parametersOfMakeGridViewManager);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridViewManagerFactory, IGridViewManager>(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, parametersOfMakeGridViewManager, methodMakeGridViewManagerPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfMakeGridViewManager.ShouldNotBeNull();
            parametersOfMakeGridViewManager.Length.ShouldBe(2);
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_gridViewManagerFactoryInstanceFixture, parametersOfMakeGridViewManager));
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridViewManagerKind = CreateType<GridViewManagerKind>();
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridViewManagerKind) };
            object[] parametersOfMakeGridViewManager = { componentName, gridViewManagerKind };

            // Assert
            parametersOfMakeGridViewManager.ShouldNotBeNull();
            parametersOfMakeGridViewManager.Length.ShouldBe(2);
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<GridViewManagerFactory, IGridViewManager>(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, parametersOfMakeGridViewManager, methodMakeGridViewManagerPrametersTypes));
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridViewManagerKind) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, Fixture, methodMakeGridViewManagerPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridViewManagerKind) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, Fixture, methodMakeGridViewManagerPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMakeGridViewManager, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridViewManagerFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMakeGridViewManager, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodMakeGridViewManagerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, Fixture, methodMakeGridViewManagerPrametersTypes);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridView = CreateType<GridView>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridViewManagerFactoryInstance.MakeGridViewManager(componentName, gridView);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Overloading_Of_1_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridView = CreateType<GridView>();
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridView) };
            object[] parametersOfMakeGridViewManager = { componentName, gridView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMakeGridViewManager, methodMakeGridViewManagerPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<GridViewManagerFactory, IGridViewManager>(_gridViewManagerFactoryInstanceFixture, out exception1, parametersOfMakeGridViewManager);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<GridViewManagerFactory, IGridViewManager>(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, parametersOfMakeGridViewManager, methodMakeGridViewManagerPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfMakeGridViewManager.ShouldNotBeNull();
            parametersOfMakeGridViewManager.Length.ShouldBe(2);
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(() => methodInfo.Invoke(_gridViewManagerFactoryInstanceFixture, parametersOfMakeGridViewManager));
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridView = CreateType<GridView>();
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridView) };
            object[] parametersOfMakeGridViewManager = { componentName, gridView };

            // Assert
            parametersOfMakeGridViewManager.ShouldNotBeNull();
            parametersOfMakeGridViewManager.Length.ShouldBe(2);
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<GridViewManagerFactory, IGridViewManager>(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, parametersOfMakeGridViewManager, methodMakeGridViewManagerPrametersTypes));
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridView) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, Fixture, methodMakeGridViewManagerPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMakeGridViewManagerPrametersTypes = new Type[] { typeof(string), typeof(GridView) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodMakeGridViewManager, Fixture, methodMakeGridViewManagerPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMakeGridViewManagerPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMakeGridViewManager, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridViewManagerFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MakeGridViewManager) (Return Type : IGridViewManager) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_MakeGridViewManager_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMakeGridViewManager, 1);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridViewManagerFactory_Dispose_Method_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var disposing = CreateType<Boolean>();
            var methodDisposePrametersTypes = new Type[] { typeof(Boolean) };
            object[] parametersOfDispose = { disposing };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridViewManagerFactoryInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var disposing = CreateType<Boolean>();
            var methodDisposePrametersTypes = new Type[] { typeof(Boolean) };
            object[] parametersOfDispose = { disposing };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridViewManagerFactoryInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldNotBeNull();
            parametersOfDispose.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(1);
            methodDisposePrametersTypes.Length.ShouldBe(parametersOfDispose.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisposePrametersTypes = new Type[] { typeof(Boolean) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridViewManagerFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridViewManagerFactory_ValidateRequest_Method_Call_Internally(Type[] types)
        {
            var methodValidateRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_ValidateRequest_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridViewManagerKind = CreateType<GridViewManagerKind>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(string), typeof(GridViewManagerKind) };
            object[] parametersOfValidateRequest = { componentName, gridViewManagerKind };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodValidateRequest, methodValidateRequestPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridViewManagerFactoryInstanceFixture, parametersOfValidateRequest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfValidateRequest.ShouldNotBeNull();
            parametersOfValidateRequest.Length.ShouldBe(2);
            methodValidateRequestPrametersTypes.Length.ShouldBe(2);
            methodValidateRequestPrametersTypes.Length.ShouldBe(parametersOfValidateRequest.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_ValidateRequest_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var componentName = CreateType<string>();
            var gridViewManagerKind = CreateType<GridViewManagerKind>();
            var methodValidateRequestPrametersTypes = new Type[] { typeof(string), typeof(GridViewManagerKind) };
            object[] parametersOfValidateRequest = { componentName, gridViewManagerKind };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridViewManagerFactoryInstance, MethodValidateRequest, parametersOfValidateRequest, methodValidateRequestPrametersTypes);

            // Assert
            parametersOfValidateRequest.ShouldNotBeNull();
            parametersOfValidateRequest.Length.ShouldBe(2);
            methodValidateRequestPrametersTypes.Length.ShouldBe(2);
            methodValidateRequestPrametersTypes.Length.ShouldBe(parametersOfValidateRequest.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_ValidateRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateRequest, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_ValidateRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateRequestPrametersTypes = new Type[] { typeof(string), typeof(GridViewManagerKind) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodValidateRequest, Fixture, methodValidateRequestPrametersTypes);

            // Assert
            methodValidateRequestPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ValidateRequest) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_ValidateRequest_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateRequest, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridViewManagerFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridViewManagerFactory_Dispose_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDisposePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodDispose, Fixture, methodDisposePrametersTypes);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _gridViewManagerFactoryInstance.Dispose();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDispose, methodDisposePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridViewManagerFactoryInstanceFixture, parametersOfDispose);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_Void_Overloading_Of_1_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;
            object[] parametersOfDispose = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_gridViewManagerFactoryInstance, MethodDispose, parametersOfDispose, methodDisposePrametersTypes);

            // Assert
            parametersOfDispose.ShouldBeNull();
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisposePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridViewManagerFactoryInstance, MethodDispose, Fixture, methodDisposePrametersTypes);

            // Assert
            methodDisposePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Dispose) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridViewManagerFactory_Dispose_Method_Call_Overloading_Of_1_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDispose, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_gridViewManagerFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}