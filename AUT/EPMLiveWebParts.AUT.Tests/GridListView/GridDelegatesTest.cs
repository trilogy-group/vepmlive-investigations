using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint.JSGrid;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.GridDelegates" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GridDelegatesTest : AbstractBaseSetupTypedTest<GridDelegates>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GridDelegates) Initializer

        private const string MethodPopulateGridRow = "PopulateGridRow";
        private Type _gridDelegatesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GridDelegates _gridDelegatesInstance;
        private GridDelegates _gridDelegatesInstanceFixture;

        #region General Initializer : Class (GridDelegates) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GridDelegates" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gridDelegatesInstanceType = typeof(GridDelegates);
            _gridDelegatesInstanceFixture = Create(true);
            _gridDelegatesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GridDelegates)

        #region General Initializer : Class (GridDelegates) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="GridDelegates" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPopulateGridRow, 0)]
        public void AUT_GridDelegates_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gridDelegatesInstanceFixture, 
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
        ///     Class (<see cref="GridDelegates" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_GridDelegates_Is_Instance_Present_Test()
        {
            // Assert
            _gridDelegatesInstanceType.ShouldNotBeNull();
            _gridDelegatesInstance.ShouldNotBeNull();
            _gridDelegatesInstanceFixture.ShouldNotBeNull();
            _gridDelegatesInstance.ShouldBeAssignableTo<GridDelegates>();
            _gridDelegatesInstanceFixture.ShouldBeAssignableTo<GridDelegates>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GridDelegates) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_GridDelegates_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GridDelegates instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gridDelegatesInstanceType.ShouldNotBeNull();
            _gridDelegatesInstance.ShouldNotBeNull();
            _gridDelegatesInstanceFixture.ShouldNotBeNull();
            _gridDelegatesInstance.ShouldBeAssignableTo<GridDelegates>();
            _gridDelegatesInstanceFixture.ShouldBeAssignableTo<GridDelegates>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="GridDelegates" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPopulateGridRow)]
        public void AUT_GridDelegates_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<GridDelegates>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_GridDelegates_PopulateGridRow_Method_Call_Internally(Type[] types)
        {
            var methodPopulateGridRowPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDelegatesInstance, MethodPopulateGridRow, Fixture, methodPopulateGridRowPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridDelegates_PopulateGridRow_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var node = CreateType<System.Collections.Generic.IEnumerable<GroupingNode>>();
            Action executeAction = null;

            // Act
            executeAction = () => _gridDelegatesInstance.PopulateGridRow(node);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridDelegates_PopulateGridRow_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var node = CreateType<System.Collections.Generic.IEnumerable<GroupingNode>>();
            var methodPopulateGridRowPrametersTypes = new Type[] { typeof(System.Collections.Generic.IEnumerable<GroupingNode>) };
            object[] parametersOfPopulateGridRow = { node };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateGridRow, methodPopulateGridRowPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gridDelegatesInstanceFixture, parametersOfPopulateGridRow);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateGridRow.ShouldNotBeNull();
            parametersOfPopulateGridRow.Length.ShouldBe(1);
            methodPopulateGridRowPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridDelegates_PopulateGridRow_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var node = CreateType<System.Collections.Generic.IEnumerable<GroupingNode>>();
            var methodPopulateGridRowPrametersTypes = new Type[] { typeof(System.Collections.Generic.IEnumerable<GroupingNode>) };
            object[] parametersOfPopulateGridRow = { node };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<GridDelegates, GridDelegates>(_gridDelegatesInstance, MethodPopulateGridRow, parametersOfPopulateGridRow, methodPopulateGridRowPrametersTypes);

            // Assert
            parametersOfPopulateGridRow.ShouldNotBeNull();
            parametersOfPopulateGridRow.Length.ShouldBe(1);
            methodPopulateGridRowPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridDelegates_PopulateGridRow_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodPopulateGridRowPrametersTypes = new Type[] { typeof(System.Collections.Generic.IEnumerable<GroupingNode>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDelegatesInstance, MethodPopulateGridRow, Fixture, methodPopulateGridRowPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodPopulateGridRowPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridDelegates_PopulateGridRow_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateGridRowPrametersTypes = new Type[] { typeof(System.Collections.Generic.IEnumerable<GroupingNode>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gridDelegatesInstance, MethodPopulateGridRow, Fixture, methodPopulateGridRowPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPopulateGridRowPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridDelegates_PopulateGridRow_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateGridRow, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gridDelegatesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (PopulateGridRow) (Return Type : GridDelegates) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_GridDelegates_PopulateGridRow_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateGridRow, 0);
            const int parametersCount = 1;

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