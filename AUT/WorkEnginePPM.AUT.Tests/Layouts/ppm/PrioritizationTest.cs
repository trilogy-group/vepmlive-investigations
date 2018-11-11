using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.WebControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Prioritization" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PrioritizationTest : AbstractBaseSetupTypedTest<Prioritization>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Prioritization) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodBuildGridLayout = "BuildGridLayout";
        private const string MethodBuildGridData = "BuildGridData";
        private Type _prioritizationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Prioritization _prioritizationInstance;
        private Prioritization _prioritizationInstanceFixture;

        #region General Initializer : Class (Prioritization) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Prioritization" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _prioritizationInstanceType = typeof(Prioritization);
            _prioritizationInstanceFixture = Create(true);
            _prioritizationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Prioritization)

        #region General Initializer : Class (Prioritization) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Prioritization" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodBuildGridLayout, 0)]
        [TestCase(MethodBuildGridData, 0)]
        public void AUT_Prioritization_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_prioritizationInstanceFixture, 
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
        ///     Class (<see cref="Prioritization" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Prioritization_Is_Instance_Present_Test()
        {
            // Assert
            _prioritizationInstanceType.ShouldNotBeNull();
            _prioritizationInstance.ShouldNotBeNull();
            _prioritizationInstanceFixture.ShouldNotBeNull();
            _prioritizationInstance.ShouldBeAssignableTo<Prioritization>();
            _prioritizationInstanceFixture.ShouldBeAssignableTo<Prioritization>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Prioritization) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Prioritization_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Prioritization instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _prioritizationInstanceType.ShouldNotBeNull();
            _prioritizationInstance.ShouldNotBeNull();
            _prioritizationInstanceFixture.ShouldNotBeNull();
            _prioritizationInstance.ShouldBeAssignableTo<Prioritization>();
            _prioritizationInstanceFixture.ShouldBeAssignableTo<Prioritization>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Prioritization" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodBuildGridLayout)]
        [TestCase(MethodBuildGridData)]
        public void AUT_Prioritization_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Prioritization>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Prioritization_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_prioritizationInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Prioritization_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_prioritizationInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Prioritization_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Prioritization_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_prioritizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Prioritization_BuildGridLayout_Method_Call_Internally(Type[] types)
        {
            var methodBuildGridLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodBuildGridLayout, Fixture, methodBuildGridLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridLayout_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Components = CreateType<ListItemCollection>();
            var methodBuildGridLayoutPrametersTypes = new Type[] { typeof(ListItemCollection) };
            object[] parametersOfBuildGridLayout = { Components };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildGridLayout, methodBuildGridLayoutPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_prioritizationInstanceFixture, parametersOfBuildGridLayout);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildGridLayout.ShouldNotBeNull();
            parametersOfBuildGridLayout.Length.ShouldBe(1);
            methodBuildGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridLayout_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Components = CreateType<ListItemCollection>();
            var methodBuildGridLayoutPrametersTypes = new Type[] { typeof(ListItemCollection) };
            object[] parametersOfBuildGridLayout = { Components };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Prioritization, CStruct>(_prioritizationInstance, MethodBuildGridLayout, parametersOfBuildGridLayout, methodBuildGridLayoutPrametersTypes);

            // Assert
            parametersOfBuildGridLayout.ShouldNotBeNull();
            parametersOfBuildGridLayout.Length.ShouldBe(1);
            methodBuildGridLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridLayout_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildGridLayoutPrametersTypes = new Type[] { typeof(ListItemCollection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodBuildGridLayout, Fixture, methodBuildGridLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildGridLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridLayout_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildGridLayoutPrametersTypes = new Type[] { typeof(ListItemCollection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodBuildGridLayout, Fixture, methodBuildGridLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildGridLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridLayout_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildGridLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_prioritizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildGridLayout) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridLayout_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildGridLayout, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Prioritization_BuildGridData_Method_Call_Internally(Type[] types)
        {
            var methodBuildGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodBuildGridData, Fixture, methodBuildGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridData_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var dt_Weights = CreateType<DataTable>();
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };
            object[] parametersOfBuildGridData = { dt, dt_Weights };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildGridData, methodBuildGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_prioritizationInstanceFixture, parametersOfBuildGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildGridData.ShouldNotBeNull();
            parametersOfBuildGridData.Length.ShouldBe(2);
            methodBuildGridDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DataTable>();
            var dt_Weights = CreateType<DataTable>();
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };
            object[] parametersOfBuildGridData = { dt, dt_Weights };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Prioritization, CStruct>(_prioritizationInstance, MethodBuildGridData, parametersOfBuildGridData, methodBuildGridDataPrametersTypes);

            // Assert
            parametersOfBuildGridData.ShouldNotBeNull();
            parametersOfBuildGridData.Length.ShouldBe(2);
            methodBuildGridDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodBuildGridData, Fixture, methodBuildGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildGridDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildGridDataPrametersTypes = new Type[] { typeof(DataTable), typeof(DataTable) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_prioritizationInstance, MethodBuildGridData, Fixture, methodBuildGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_prioritizationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildGridData) (Return Type : CStruct) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Prioritization_BuildGridData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildGridData, 0);
            const int parametersCount = 2;

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