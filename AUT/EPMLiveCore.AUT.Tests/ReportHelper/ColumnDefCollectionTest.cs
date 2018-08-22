using System;
using System.Collections.Generic;
using System.Data;
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

namespace EPMLiveCore.ReportHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.ColumnDefCollection" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ColumnDefCollectionTest : AbstractBaseSetupTypedTest<ColumnDefCollection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ColumnDefCollection) Initializer

        private const string MethodAddColumn = "AddColumn";
        private const string MethodDiffColumns = "DiffColumns";
        private const string MethodGetSqlColumnDefs = "GetSqlColumnDefs";
        private const string MethodGetSqlCreateTable = "GetSqlCreateTable";
        private const string MethodToString = "ToString";
        private Type _columnDefCollectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ColumnDefCollection _columnDefCollectionInstance;
        private ColumnDefCollection _columnDefCollectionInstanceFixture;

        #region General Initializer : Class (ColumnDefCollection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ColumnDefCollection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _columnDefCollectionInstanceType = typeof(ColumnDefCollection);
            _columnDefCollectionInstanceFixture = Create(true);
            _columnDefCollectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ColumnDefCollection)

        #region General Initializer : Class (ColumnDefCollection) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ColumnDefCollection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddColumn, 0)]
        [TestCase(MethodAddColumn, 1)]
        [TestCase(MethodDiffColumns, 0)]
        [TestCase(MethodGetSqlColumnDefs, 0)]
        [TestCase(MethodGetSqlCreateTable, 0)]
        [TestCase(MethodToString, 0)]
        [TestCase(MethodDiffColumns, 1)]
        public void AUT_ColumnDefCollection_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_columnDefCollectionInstanceFixture, 
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
        ///     Class (<see cref="ColumnDefCollection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ColumnDefCollection_Is_Instance_Present_Test()
        {
            // Assert
            _columnDefCollectionInstanceType.ShouldNotBeNull();
            _columnDefCollectionInstance.ShouldNotBeNull();
            _columnDefCollectionInstanceFixture.ShouldNotBeNull();
            _columnDefCollectionInstance.ShouldBeAssignableTo<ColumnDefCollection>();
            _columnDefCollectionInstanceFixture.ShouldBeAssignableTo<ColumnDefCollection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ColumnDefCollection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ColumnDefCollection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ColumnDefCollection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _columnDefCollectionInstanceType.ShouldNotBeNull();
            _columnDefCollectionInstance.ShouldNotBeNull();
            _columnDefCollectionInstanceFixture.ShouldNotBeNull();
            _columnDefCollectionInstance.ShouldBeAssignableTo<ColumnDefCollection>();
            _columnDefCollectionInstanceFixture.ShouldBeAssignableTo<ColumnDefCollection>();
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var capacity = CreateType<int>();
            ColumnDefCollection instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ColumnDefCollection(capacity);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _columnDefCollectionInstance.ShouldNotBeNull();
            _columnDefCollectionInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ColumnDefCollection>();
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var capacity = CreateType<int>();
            ColumnDefCollection instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ColumnDefCollection(capacity);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _columnDefCollectionInstance.ShouldNotBeNull();
            _columnDefCollectionInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) instance created

        /// <summary>
        ///     Class (<see cref="ColumnDefCollection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Is_Created_Test()
        {
            // Assert
            _columnDefCollectionInstance.ShouldNotBeNull();
            _columnDefCollectionInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ColumnDefCollection" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void AUT_ColumnDefCollection_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ColumnDefCollection>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ColumnDefCollection>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfColumnDefCollection = {  };
            Type [] methodColumnDefCollectionPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefCollectionInstanceType, methodColumnDefCollectionPrametersTypes, parametersOfColumnDefCollection);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodColumnDefCollectionPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefCollectionInstanceType, Fixture, methodColumnDefCollectionPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var capacity = CreateType<int>();
            object[] parametersOfColumnDefCollection = { capacity };
            var methodColumnDefCollectionPrametersTypes = new Type[] { typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefCollectionInstanceType, methodColumnDefCollectionPrametersTypes, parametersOfColumnDefCollection);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefCollectionPrametersTypes = new Type[] { typeof(int) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefCollectionInstanceType, Fixture, methodColumnDefCollectionPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var collection = CreateType<IEnumerable<ColumnDef>>();
            object[] parametersOfColumnDefCollection = { collection };
            var methodColumnDefCollectionPrametersTypes = new Type[] { typeof(IEnumerable<ColumnDef>) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefCollectionInstanceType, methodColumnDefCollectionPrametersTypes, parametersOfColumnDefCollection);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefCollectionPrametersTypes = new Type[] { typeof(IEnumerable<ColumnDef>) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefCollectionInstanceType, Fixture, methodColumnDefCollectionPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var columns = CreateType<DataColumnCollection>();
            object[] parametersOfColumnDefCollection = { columns };
            var methodColumnDefCollectionPrametersTypes = new Type[] { typeof(DataColumnCollection) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_columnDefCollectionInstanceType, methodColumnDefCollectionPrametersTypes, parametersOfColumnDefCollection);
        }

        #endregion

        #region General Constructor : Class (ColumnDefCollection) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ColumnDefCollection" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ColumnDefCollection_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodColumnDefCollectionPrametersTypes = new Type[] { typeof(DataColumnCollection) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_columnDefCollectionInstanceType, Fixture, methodColumnDefCollectionPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ColumnDefCollection" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodDiffColumns)]
        public void AUT_ColumnDefCollection_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_columnDefCollectionInstanceFixture,
                                                                              _columnDefCollectionInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ColumnDefCollection" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddColumn)]
        [TestCase(MethodDiffColumns)]
        [TestCase(MethodGetSqlColumnDefs)]
        [TestCase(MethodGetSqlCreateTable)]
        [TestCase(MethodToString)]
        public void AUT_ColumnDefCollection_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ColumnDefCollection>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDefCollection_AddColumn_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            Action executeAction = null;

            // Act
            executeAction = () => _columnDefCollectionInstance.AddColumn(field);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfAddColumn = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColumn, methodAddColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefCollectionInstanceFixture, parametersOfAddColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(parametersOfAddColumn.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfAddColumn = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_columnDefCollectionInstance, MethodAddColumn, parametersOfAddColumn, methodAddColumnPrametersTypes);

            // Assert
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(parametersOfAddColumn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumn, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);

            // Assert
            methodAddColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefCollectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDefCollection_AddColumn_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var column = CreateType<DataColumn>();
            Action executeAction = null;

            // Act
            executeAction = () => _columnDefCollectionInstance.AddColumn(column);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var column = CreateType<DataColumn>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(DataColumn) };
            object[] parametersOfAddColumn = { column };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColumn, methodAddColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefCollectionInstanceFixture, parametersOfAddColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(parametersOfAddColumn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Void_Overloading_Of_1_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var column = CreateType<DataColumn>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(DataColumn) };
            object[] parametersOfAddColumn = { column };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_columnDefCollectionInstance, MethodAddColumn, parametersOfAddColumn, methodAddColumnPrametersTypes);

            // Assert
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(1);
            methodAddColumnPrametersTypes.Length.ShouldBe(parametersOfAddColumn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumn, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnPrametersTypes = new Type[] { typeof(DataColumn) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);

            // Assert
            methodAddColumnPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_AddColumn_Method_Call_Overloading_Of_1_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumn, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefCollectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDefCollection_DiffColumns_Method_Call_Internally(Type[] types)
        {
            var methodDiffColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodDiffColumns, Fixture, methodDiffColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var newSet = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => _columnDefCollectionInstance.DiffColumns(newSet);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var newSet = CreateType<List<ColumnDef>>();
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>) };
            object[] parametersOfDiffColumns = { newSet };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDiffColumns, methodDiffColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ColumnDefCollection, ColumnDefCollection>(_columnDefCollectionInstanceFixture, out exception1, parametersOfDiffColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ColumnDefCollection, ColumnDefCollection>(_columnDefCollectionInstance, MethodDiffColumns, parametersOfDiffColumns, methodDiffColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDiffColumns.ShouldNotBeNull();
            parametersOfDiffColumns.Length.ShouldBe(1);
            methodDiffColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var newSet = CreateType<List<ColumnDef>>();
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>) };
            object[] parametersOfDiffColumns = { newSet };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDiffColumns, methodDiffColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefCollectionInstanceFixture, parametersOfDiffColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDiffColumns.ShouldNotBeNull();
            parametersOfDiffColumns.Length.ShouldBe(1);
            methodDiffColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var newSet = CreateType<List<ColumnDef>>();
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>) };
            object[] parametersOfDiffColumns = { newSet };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ColumnDefCollection, ColumnDefCollection>(_columnDefCollectionInstance, MethodDiffColumns, parametersOfDiffColumns, methodDiffColumnsPrametersTypes);

            // Assert
            parametersOfDiffColumns.ShouldNotBeNull();
            parametersOfDiffColumns.Length.ShouldBe(1);
            methodDiffColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodDiffColumns, Fixture, methodDiffColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDiffColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodDiffColumns, Fixture, methodDiffColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDiffColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDiffColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefCollectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDiffColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSqlColumnDefs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDefCollection_GetSqlColumnDefs_Method_Call_Internally(Type[] types)
        {
            var methodGetSqlColumnDefsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodGetSqlColumnDefs, Fixture, methodGetSqlColumnDefsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSqlColumnDefs) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlColumnDefs_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _columnDefCollectionInstance.GetSqlColumnDefs();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSqlColumnDefs) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlColumnDefs_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetSqlColumnDefsPrametersTypes = null;
            object[] parametersOfGetSqlColumnDefs = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSqlColumnDefs, methodGetSqlColumnDefsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefCollectionInstanceFixture, parametersOfGetSqlColumnDefs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSqlColumnDefs.ShouldBeNull();
            methodGetSqlColumnDefsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSqlColumnDefs) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlColumnDefs_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSqlColumnDefsPrametersTypes = null;
            object[] parametersOfGetSqlColumnDefs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ColumnDefCollection, string>(_columnDefCollectionInstance, MethodGetSqlColumnDefs, parametersOfGetSqlColumnDefs, methodGetSqlColumnDefsPrametersTypes);

            // Assert
            parametersOfGetSqlColumnDefs.ShouldBeNull();
            methodGetSqlColumnDefsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSqlColumnDefs) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlColumnDefs_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetSqlColumnDefsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodGetSqlColumnDefs, Fixture, methodGetSqlColumnDefsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSqlColumnDefsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSqlColumnDefs) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlColumnDefs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSqlColumnDefsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodGetSqlColumnDefs, Fixture, methodGetSqlColumnDefsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSqlColumnDefsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSqlColumnDefs) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlColumnDefs_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSqlColumnDefs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefCollectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDefCollection_GetSqlCreateTable_Method_Call_Internally(Type[] types)
        {
            var methodGetSqlCreateTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodGetSqlCreateTable, Fixture, methodGetSqlCreateTablePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlCreateTable_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _columnDefCollectionInstance.GetSqlCreateTable(tableName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlCreateTable_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetSqlCreateTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSqlCreateTable = { tableName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSqlCreateTable, methodGetSqlCreateTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefCollectionInstanceFixture, parametersOfGetSqlCreateTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSqlCreateTable.ShouldNotBeNull();
            parametersOfGetSqlCreateTable.Length.ShouldBe(1);
            methodGetSqlCreateTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlCreateTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var methodGetSqlCreateTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSqlCreateTable = { tableName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ColumnDefCollection, string>(_columnDefCollectionInstance, MethodGetSqlCreateTable, parametersOfGetSqlCreateTable, methodGetSqlCreateTablePrametersTypes);

            // Assert
            parametersOfGetSqlCreateTable.ShouldNotBeNull();
            parametersOfGetSqlCreateTable.Length.ShouldBe(1);
            methodGetSqlCreateTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlCreateTable_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSqlCreateTablePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodGetSqlCreateTable, Fixture, methodGetSqlCreateTablePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSqlCreateTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlCreateTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSqlCreateTablePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodGetSqlCreateTable, Fixture, methodGetSqlCreateTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSqlCreateTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlCreateTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSqlCreateTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefCollectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSqlCreateTable) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_GetSqlCreateTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSqlCreateTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDefCollection_ToString_Method_Call_Internally(Type[] types)
        {
            var methodToStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodToString, Fixture, methodToStringPrametersTypes);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_ToString_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _columnDefCollectionInstance.ToString();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_ToString_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodToString, methodToStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefCollectionInstanceFixture, parametersOfToString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_ToString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            object[] parametersOfToString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ColumnDefCollection, string>(_columnDefCollectionInstance, MethodToString, parametersOfToString, methodToStringPrametersTypes);

            // Assert
            parametersOfToString.ShouldBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_ToString_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_ToString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodToStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_columnDefCollectionInstance, MethodToString, Fixture, methodToStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodToStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ToString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_ToString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodToString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefCollectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ColumnDefCollection_DiffColumns_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodDiffColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefCollectionInstanceFixture, _columnDefCollectionInstanceType, MethodDiffColumns, Fixture, methodDiffColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var existingSet = CreateType<List<ColumnDef>>();
            var newSet = CreateType<List<ColumnDef>>();
            Action executeAction = null;

            // Act
            executeAction = () => ColumnDefCollection.DiffColumns(existingSet, newSet);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var existingSet = CreateType<List<ColumnDef>>();
            var newSet = CreateType<List<ColumnDef>>();
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>), typeof(List<ColumnDef>) };
            object[] parametersOfDiffColumns = { existingSet, newSet };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDiffColumns, methodDiffColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_columnDefCollectionInstanceFixture, parametersOfDiffColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDiffColumns.ShouldNotBeNull();
            parametersOfDiffColumns.Length.ShouldBe(2);
            methodDiffColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var existingSet = CreateType<List<ColumnDef>>();
            var newSet = CreateType<List<ColumnDef>>();
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>), typeof(List<ColumnDef>) };
            object[] parametersOfDiffColumns = { existingSet, newSet };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ColumnDefCollection>(_columnDefCollectionInstanceFixture, _columnDefCollectionInstanceType, MethodDiffColumns, parametersOfDiffColumns, methodDiffColumnsPrametersTypes);

            // Assert
            parametersOfDiffColumns.ShouldNotBeNull();
            parametersOfDiffColumns.Length.ShouldBe(2);
            methodDiffColumnsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>), typeof(List<ColumnDef>) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefCollectionInstanceFixture, _columnDefCollectionInstanceType, MethodDiffColumns, Fixture, methodDiffColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDiffColumnsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDiffColumnsPrametersTypes = new Type[] { typeof(List<ColumnDef>), typeof(List<ColumnDef>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_columnDefCollectionInstanceFixture, _columnDefCollectionInstanceType, MethodDiffColumns, Fixture, methodDiffColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDiffColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDiffColumns, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_columnDefCollectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DiffColumns) (Return Type : ColumnDefCollection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ColumnDefCollection_DiffColumns_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDiffColumns, 1);
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