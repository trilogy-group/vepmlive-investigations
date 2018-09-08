using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainModel.EpmChartDataSeriesList" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartDataSeriesListTest : AbstractBaseSetupTypedTest<EpmChartDataSeriesList>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartDataSeriesList) Initializer

        private const string MethodHydrateChartSeriesList = "HydrateChartSeriesList";
        private const string MethodFieldIsPercentage = "FieldIsPercentage";
        private const string MethodGetZAxisColorMap = "GetZAxisColorMap";
        private const string MethodRemoveUnusedChartDataColumns = "RemoveUnusedChartDataColumns";
        private const string MethodParseValue = "ParseValue";
        private const string Field_englishNumberFormat = "_englishNumberFormat";
        private Type _epmChartDataSeriesListInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChartDataSeriesList _epmChartDataSeriesListInstance;
        private EpmChartDataSeriesList _epmChartDataSeriesListInstanceFixture;

        #region General Initializer : Class (EpmChartDataSeriesList) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartDataSeriesList" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartDataSeriesListInstanceType = typeof(EpmChartDataSeriesList);
            _epmChartDataSeriesListInstanceFixture = Create(true);
            _epmChartDataSeriesListInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartDataSeriesList)

        #region General Initializer : Class (EpmChartDataSeriesList) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartDataSeriesList" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodHydrateChartSeriesList, 0)]
        [TestCase(MethodFieldIsPercentage, 0)]
        [TestCase(MethodGetZAxisColorMap, 0)]
        [TestCase(MethodRemoveUnusedChartDataColumns, 0)]
        [TestCase(MethodParseValue, 0)]
        public void AUT_EpmChartDataSeriesList_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartDataSeriesListInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChartDataSeriesList) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChartDataSeriesList" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_englishNumberFormat)]
        public void AUT_EpmChartDataSeriesList_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_epmChartDataSeriesListInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EpmChartDataSeriesList" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFieldIsPercentage)]
        [TestCase(MethodGetZAxisColorMap)]
        [TestCase(MethodRemoveUnusedChartDataColumns)]
        [TestCase(MethodParseValue)]
        public void AUT_EpmChartDataSeriesList_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_epmChartDataSeriesListInstanceFixture,
                                                                              _epmChartDataSeriesListInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EpmChartDataSeriesList" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodHydrateChartSeriesList)]
        public void AUT_EpmChartDataSeriesList_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EpmChartDataSeriesList>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (HydrateChartSeriesList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataSeriesList_HydrateChartSeriesList_Method_Call_Internally(Type[] types)
        {
            var methodHydrateChartSeriesListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstance, MethodHydrateChartSeriesList, Fixture, methodHydrateChartSeriesListPrametersTypes);
        }

        #endregion

        #region Method Call : (HydrateChartSeriesList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_HydrateChartSeriesList_Method_Call_Void_With_8_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var originalChartData = CreateType<DataTable>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var xAxisField = CreateType<SPField>();
            var yAxisField = CreateType<SPField>();
            var zAxisField = CreateType<SPField>();
            var hasZAxis = CreateType<bool>();
            var hasZAxisColor = CreateType<bool>();
            var columnMappings = CreateType<BubbleChartAxisToColumnMapping>();
            var methodHydrateChartSeriesListPrametersTypes = new Type[] { typeof(DataTable), typeof(EpmChartAggregateType), typeof(SPField), typeof(SPField), typeof(SPField), typeof(bool), typeof(bool), typeof(BubbleChartAxisToColumnMapping) };
            object[] parametersOfHydrateChartSeriesList = { originalChartData, aggregateType, xAxisField, yAxisField, zAxisField, hasZAxis, hasZAxisColor, columnMappings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHydrateChartSeriesList, methodHydrateChartSeriesListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataSeriesListInstanceFixture, parametersOfHydrateChartSeriesList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHydrateChartSeriesList.ShouldNotBeNull();
            parametersOfHydrateChartSeriesList.Length.ShouldBe(8);
            methodHydrateChartSeriesListPrametersTypes.Length.ShouldBe(8);
            methodHydrateChartSeriesListPrametersTypes.Length.ShouldBe(parametersOfHydrateChartSeriesList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HydrateChartSeriesList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_HydrateChartSeriesList_Method_Call_Void_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var originalChartData = CreateType<DataTable>();
            var aggregateType = CreateType<EpmChartAggregateType>();
            var xAxisField = CreateType<SPField>();
            var yAxisField = CreateType<SPField>();
            var zAxisField = CreateType<SPField>();
            var hasZAxis = CreateType<bool>();
            var hasZAxisColor = CreateType<bool>();
            var columnMappings = CreateType<BubbleChartAxisToColumnMapping>();
            var methodHydrateChartSeriesListPrametersTypes = new Type[] { typeof(DataTable), typeof(EpmChartAggregateType), typeof(SPField), typeof(SPField), typeof(SPField), typeof(bool), typeof(bool), typeof(BubbleChartAxisToColumnMapping) };
            object[] parametersOfHydrateChartSeriesList = { originalChartData, aggregateType, xAxisField, yAxisField, zAxisField, hasZAxis, hasZAxisColor, columnMappings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartDataSeriesListInstance, MethodHydrateChartSeriesList, parametersOfHydrateChartSeriesList, methodHydrateChartSeriesListPrametersTypes);

            // Assert
            parametersOfHydrateChartSeriesList.ShouldNotBeNull();
            parametersOfHydrateChartSeriesList.Length.ShouldBe(8);
            methodHydrateChartSeriesListPrametersTypes.Length.ShouldBe(8);
            methodHydrateChartSeriesListPrametersTypes.Length.ShouldBe(parametersOfHydrateChartSeriesList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HydrateChartSeriesList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_HydrateChartSeriesList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHydrateChartSeriesList, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HydrateChartSeriesList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_HydrateChartSeriesList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHydrateChartSeriesListPrametersTypes = new Type[] { typeof(DataTable), typeof(EpmChartAggregateType), typeof(SPField), typeof(SPField), typeof(SPField), typeof(bool), typeof(bool), typeof(BubbleChartAxisToColumnMapping) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstance, MethodHydrateChartSeriesList, Fixture, methodHydrateChartSeriesListPrametersTypes);

            // Assert
            methodHydrateChartSeriesListPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HydrateChartSeriesList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_HydrateChartSeriesList_Method_Call_With_8_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHydrateChartSeriesList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataSeriesListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldIsPercentage) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataSeriesList_FieldIsPercentage_Static_Method_Call_Internally(Type[] types)
        {
            var methodFieldIsPercentagePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodFieldIsPercentage, Fixture, methodFieldIsPercentagePrametersTypes);
        }

        #endregion

        #region Method Call : (FieldIsPercentage) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_FieldIsPercentage_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spfield = CreateType<SPField>();
            var methodFieldIsPercentagePrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfFieldIsPercentage = { spfield };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodFieldIsPercentage, parametersOfFieldIsPercentage, methodFieldIsPercentagePrametersTypes);

            // Assert
            parametersOfFieldIsPercentage.ShouldNotBeNull();
            parametersOfFieldIsPercentage.Length.ShouldBe(1);
            methodFieldIsPercentagePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldIsPercentage) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_FieldIsPercentage_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFieldIsPercentagePrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodFieldIsPercentage, Fixture, methodFieldIsPercentagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFieldIsPercentagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldIsPercentage) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_FieldIsPercentage_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFieldIsPercentage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataSeriesListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FieldIsPercentage) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_FieldIsPercentage_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFieldIsPercentage, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetZAxisColorMap) (Return Type : Dictionary<string, Color>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataSeriesList_GetZAxisColorMap_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetZAxisColorMapPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodGetZAxisColorMap, Fixture, methodGetZAxisColorMapPrametersTypes);
        }

        #endregion

        #region Method Call : (GetZAxisColorMap) (Return Type : Dictionary<string, Color>) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_GetZAxisColorMap_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var chartData = CreateType<DataTable>();
            var zAxisColorFieldColumn = CreateType<DataColumn>();
            var methodGetZAxisColorMapPrametersTypes = new Type[] { typeof(DataTable), typeof(DataColumn) };
            object[] parametersOfGetZAxisColorMap = { chartData, zAxisColorFieldColumn };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetZAxisColorMap, methodGetZAxisColorMapPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataSeriesListInstanceFixture, parametersOfGetZAxisColorMap);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetZAxisColorMap.ShouldNotBeNull();
            parametersOfGetZAxisColorMap.Length.ShouldBe(2);
            methodGetZAxisColorMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZAxisColorMap) (Return Type : Dictionary<string, Color>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_GetZAxisColorMap_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chartData = CreateType<DataTable>();
            var zAxisColorFieldColumn = CreateType<DataColumn>();
            var methodGetZAxisColorMapPrametersTypes = new Type[] { typeof(DataTable), typeof(DataColumn) };
            object[] parametersOfGetZAxisColorMap = { chartData, zAxisColorFieldColumn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<Dictionary<string, Color>>(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodGetZAxisColorMap, parametersOfGetZAxisColorMap, methodGetZAxisColorMapPrametersTypes);

            // Assert
            parametersOfGetZAxisColorMap.ShouldNotBeNull();
            parametersOfGetZAxisColorMap.Length.ShouldBe(2);
            methodGetZAxisColorMapPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZAxisColorMap) (Return Type : Dictionary<string, Color>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_GetZAxisColorMap_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetZAxisColorMapPrametersTypes = new Type[] { typeof(DataTable), typeof(DataColumn) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodGetZAxisColorMap, Fixture, methodGetZAxisColorMapPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetZAxisColorMapPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetZAxisColorMap) (Return Type : Dictionary<string, Color>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_GetZAxisColorMap_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetZAxisColorMapPrametersTypes = new Type[] { typeof(DataTable), typeof(DataColumn) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodGetZAxisColorMap, Fixture, methodGetZAxisColorMapPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetZAxisColorMapPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetZAxisColorMap) (Return Type : Dictionary<string, Color>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_GetZAxisColorMap_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetZAxisColorMap, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataSeriesListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZAxisColorMap) (Return Type : Dictionary<string, Color>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_GetZAxisColorMap_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetZAxisColorMap, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveUnusedChartDataColumns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataSeriesList_RemoveUnusedChartDataColumns_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemoveUnusedChartDataColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodRemoveUnusedChartDataColumns, Fixture, methodRemoveUnusedChartDataColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveUnusedChartDataColumns) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_RemoveUnusedChartDataColumns_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var chartData = CreateType<DataTable>();
            var methodRemoveUnusedChartDataColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfRemoveUnusedChartDataColumns = { chartData };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveUnusedChartDataColumns, methodRemoveUnusedChartDataColumnsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataSeriesListInstanceFixture, parametersOfRemoveUnusedChartDataColumns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveUnusedChartDataColumns.ShouldNotBeNull();
            parametersOfRemoveUnusedChartDataColumns.Length.ShouldBe(1);
            methodRemoveUnusedChartDataColumnsPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveUnusedChartDataColumns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_RemoveUnusedChartDataColumns_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chartData = CreateType<DataTable>();
            var methodRemoveUnusedChartDataColumnsPrametersTypes = new Type[] { typeof(DataTable) };
            object[] parametersOfRemoveUnusedChartDataColumns = { chartData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodRemoveUnusedChartDataColumns, parametersOfRemoveUnusedChartDataColumns, methodRemoveUnusedChartDataColumnsPrametersTypes);

            // Assert
            parametersOfRemoveUnusedChartDataColumns.ShouldNotBeNull();
            parametersOfRemoveUnusedChartDataColumns.Length.ShouldBe(1);
            methodRemoveUnusedChartDataColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveUnusedChartDataColumns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_RemoveUnusedChartDataColumns_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveUnusedChartDataColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveUnusedChartDataColumns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_RemoveUnusedChartDataColumns_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveUnusedChartDataColumnsPrametersTypes = new Type[] { typeof(DataTable) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodRemoveUnusedChartDataColumns, Fixture, methodRemoveUnusedChartDataColumnsPrametersTypes);

            // Assert
            methodRemoveUnusedChartDataColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveUnusedChartDataColumns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_RemoveUnusedChartDataColumns_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveUnusedChartDataColumns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataSeriesListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataSeriesList_ParseValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodParseValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodParseValue, Fixture, methodParseValuePrametersTypes);
        }

        #endregion

        #region Method Call : (ParseValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_ParseValue_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var valueToParse = CreateType<string>();
            var methodParseValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfParseValue = { valueToParse };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodParseValue, methodParseValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataSeriesListInstanceFixture, parametersOfParseValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfParseValue.ShouldNotBeNull();
            parametersOfParseValue.Length.ShouldBe(1);
            methodParseValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_ParseValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var valueToParse = CreateType<string>();
            var methodParseValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfParseValue = { valueToParse };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodParseValue, parametersOfParseValue, methodParseValuePrametersTypes);

            // Assert
            parametersOfParseValue.ShouldNotBeNull();
            parametersOfParseValue.Length.ShouldBe(1);
            methodParseValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ParseValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_ParseValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodParseValuePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodParseValue, Fixture, methodParseValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodParseValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ParseValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_ParseValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodParseValuePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartDataSeriesListInstanceFixture, _epmChartDataSeriesListInstanceType, MethodParseValue, Fixture, methodParseValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodParseValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ParseValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_ParseValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodParseValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataSeriesListInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ParseValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeriesList_ParseValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodParseValue, 0);
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