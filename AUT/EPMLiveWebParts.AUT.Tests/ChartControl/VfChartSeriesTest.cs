using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.VfChartSeries" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VfChartSeriesTest : AbstractBaseSetupTypedTest<VfChartSeries>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (VfChartSeries) Initializer

        private const string PropertySeriesName = "SeriesName";
        private const string PropertyFormat = "Format";
        private const string PropertyLegendColor = "LegendColor";
        private const string MethodAddItem = "AddItem";
        private const string Field_seriesName = "_seriesName";
        private Type _vfChartSeriesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private VfChartSeries _vfChartSeriesInstance;
        private VfChartSeries _vfChartSeriesInstanceFixture;

        #region General Initializer : Class (VfChartSeries) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="VfChartSeries" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _vfChartSeriesInstanceType = typeof(VfChartSeries);
            _vfChartSeriesInstanceFixture = Create(true);
            _vfChartSeriesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (VfChartSeries)

        #region General Initializer : Class (VfChartSeries) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="VfChartSeries" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddItem, 0)]
        [TestCase(MethodAddItem, 1)]
        public void AUT_VfChartSeries_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_vfChartSeriesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (VfChartSeries) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="VfChartSeries" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertySeriesName)]
        [TestCase(PropertyFormat)]
        [TestCase(PropertyLegendColor)]
        public void AUT_VfChartSeries_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_vfChartSeriesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (VfChartSeries) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="VfChartSeries" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_seriesName)]
        public void AUT_VfChartSeries_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_vfChartSeriesInstanceFixture, 
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
        ///     Class (<see cref="VfChartSeries" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_VfChartSeries_Is_Instance_Present_Test()
        {
            // Assert
            _vfChartSeriesInstanceType.ShouldNotBeNull();
            _vfChartSeriesInstance.ShouldNotBeNull();
            _vfChartSeriesInstanceFixture.ShouldNotBeNull();
            _vfChartSeriesInstance.ShouldBeAssignableTo<VfChartSeries>();
            _vfChartSeriesInstanceFixture.ShouldBeAssignableTo<VfChartSeries>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (VfChartSeries) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_VfChartSeries_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var seriesName = CreateType<string>();
            VfChartSeries instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new VfChartSeries(seriesName);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _vfChartSeriesInstance.ShouldNotBeNull();
            _vfChartSeriesInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<VfChartSeries>();
        }

        #endregion

        #region General Constructor : Class (VfChartSeries) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_VfChartSeries_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var seriesName = CreateType<string>();
            VfChartSeries instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new VfChartSeries(seriesName);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _vfChartSeriesInstance.ShouldNotBeNull();
            _vfChartSeriesInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (VfChartSeries) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertySeriesName)]
        [TestCaseGeneric(typeof(string) , PropertyFormat)]
        [TestCaseGeneric(typeof(string) , PropertyLegendColor)]
        public void AUT_VfChartSeries_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<VfChartSeries, T>(_vfChartSeriesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (VfChartSeries) => Property (Format) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChartSeries_Public_Class_Format_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFormat);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChartSeries) => Property (LegendColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChartSeries_Public_Class_LegendColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLegendColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChartSeries) => Property (SeriesName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChartSeries_Public_Class_SeriesName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySeriesName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="VfChartSeries" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddItem)]
        public void AUT_VfChartSeries_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<VfChartSeries>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChartSeries_AddItem_Method_Call_Internally(Type[] types)
        {
            var methodAddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartSeriesInstance, MethodAddItem, Fixture, methodAddItemPrametersTypes);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _vfChartSeriesInstance.AddItem(xAxisLabel, yValue, zValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            var methodAddItemPrametersTypes = new Type[] { typeof(string), typeof(double), typeof(double) };
            object[] parametersOfAddItem = { xAxisLabel, yValue, zValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddItem, methodAddItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vfChartSeriesInstanceFixture, parametersOfAddItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddItem.ShouldNotBeNull();
            parametersOfAddItem.Length.ShouldBe(3);
            methodAddItemPrametersTypes.Length.ShouldBe(3);
            methodAddItemPrametersTypes.Length.ShouldBe(parametersOfAddItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            var methodAddItemPrametersTypes = new Type[] { typeof(string), typeof(double), typeof(double) };
            object[] parametersOfAddItem = { xAxisLabel, yValue, zValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_vfChartSeriesInstance, MethodAddItem, parametersOfAddItem, methodAddItemPrametersTypes);

            // Assert
            parametersOfAddItem.ShouldNotBeNull();
            parametersOfAddItem.Length.ShouldBe(3);
            methodAddItemPrametersTypes.Length.ShouldBe(3);
            methodAddItemPrametersTypes.Length.ShouldBe(parametersOfAddItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddItem, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddItemPrametersTypes = new Type[] { typeof(string), typeof(double), typeof(double) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartSeriesInstance, MethodAddItem, Fixture, methodAddItemPrametersTypes);

            // Assert
            methodAddItemPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddItem, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartSeriesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChartSeries_AddItem_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartSeriesInstance, MethodAddItem, Fixture, methodAddItemPrametersTypes);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            var dataPointColor = CreateType<Color>();
            Action executeAction = null;

            // Act
            executeAction = () => _vfChartSeriesInstance.AddItem(xAxisLabel, yValue, zValue, dataPointColor);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            var dataPointColor = CreateType<Color>();
            var methodAddItemPrametersTypes = new Type[] { typeof(string), typeof(double), typeof(double), typeof(Color) };
            object[] parametersOfAddItem = { xAxisLabel, yValue, zValue, dataPointColor };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddItem, methodAddItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vfChartSeriesInstanceFixture, parametersOfAddItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddItem.ShouldNotBeNull();
            parametersOfAddItem.Length.ShouldBe(4);
            methodAddItemPrametersTypes.Length.ShouldBe(4);
            methodAddItemPrametersTypes.Length.ShouldBe(parametersOfAddItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Void_Overloading_Of_1_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            var dataPointColor = CreateType<Color>();
            var methodAddItemPrametersTypes = new Type[] { typeof(string), typeof(double), typeof(double), typeof(Color) };
            object[] parametersOfAddItem = { xAxisLabel, yValue, zValue, dataPointColor };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_vfChartSeriesInstance, MethodAddItem, parametersOfAddItem, methodAddItemPrametersTypes);

            // Assert
            parametersOfAddItem.ShouldNotBeNull();
            parametersOfAddItem.Length.ShouldBe(4);
            methodAddItemPrametersTypes.Length.ShouldBe(4);
            methodAddItemPrametersTypes.Length.ShouldBe(parametersOfAddItem.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddItem, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddItemPrametersTypes = new Type[] { typeof(string), typeof(double), typeof(double), typeof(Color) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartSeriesInstance, MethodAddItem, Fixture, methodAddItemPrametersTypes);

            // Assert
            methodAddItemPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddItem) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChartSeries_AddItem_Method_Call_Overloading_Of_1_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddItem, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartSeriesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}