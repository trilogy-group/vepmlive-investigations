using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainModel.EpmChartDataSeries" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartDataSeriesTest : AbstractBaseSetupTypedTest<EpmChartDataSeries>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartDataSeries) Initializer

        private const string PropertySeriesName = "SeriesName";
        private const string PropertyChartDataPoints = "ChartDataPoints";
        private const string MethodAddDataPoint = "AddDataPoint";
        private const string MethodOrderDataPointsSoSmallerBubblesAreInFront = "OrderDataPointsSoSmallerBubblesAreInFront";
        private Type _epmChartDataSeriesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChartDataSeries _epmChartDataSeriesInstance;
        private EpmChartDataSeries _epmChartDataSeriesInstanceFixture;

        #region General Initializer : Class (EpmChartDataSeries) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartDataSeries" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartDataSeriesInstanceType = typeof(EpmChartDataSeries);
            _epmChartDataSeriesInstanceFixture = Create(true);
            _epmChartDataSeriesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartDataSeries)

        #region General Initializer : Class (EpmChartDataSeries) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartDataSeries" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddDataPoint, 0)]
        [TestCase(MethodOrderDataPointsSoSmallerBubblesAreInFront, 0)]
        public void AUT_EpmChartDataSeries_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartDataSeriesInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChartDataSeries) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChartDataSeries" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertySeriesName)]
        [TestCase(PropertyChartDataPoints)]
        public void AUT_EpmChartDataSeries_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_epmChartDataSeriesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="EpmChartDataSeries" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChartDataSeries_Is_Instance_Present_Test()
        {
            // Assert
            _epmChartDataSeriesInstanceType.ShouldNotBeNull();
            _epmChartDataSeriesInstance.ShouldNotBeNull();
            _epmChartDataSeriesInstanceFixture.ShouldNotBeNull();
            _epmChartDataSeriesInstance.ShouldBeAssignableTo<EpmChartDataSeries>();
            _epmChartDataSeriesInstanceFixture.ShouldBeAssignableTo<EpmChartDataSeries>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EpmChartDataSeries) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChartDataSeries_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var seriesName = CreateType<string>();
            EpmChartDataSeries instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new EpmChartDataSeries(seriesName);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _epmChartDataSeriesInstance.ShouldNotBeNull();
            _epmChartDataSeriesInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<EpmChartDataSeries>();
        }

        #endregion

        #region General Constructor : Class (EpmChartDataSeries) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChartDataSeries_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var seriesName = CreateType<string>();
            EpmChartDataSeries instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new EpmChartDataSeries(seriesName);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _epmChartDataSeriesInstance.ShouldNotBeNull();
            _epmChartDataSeriesInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EpmChartDataSeries) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertySeriesName)]
        [TestCaseGeneric(typeof(List<EpmChartDataPoint>) , PropertyChartDataPoints)]
        public void AUT_EpmChartDataSeries_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EpmChartDataSeries, T>(_epmChartDataSeriesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataSeries) => Property (ChartDataPoints) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataSeries_Public_Class_ChartDataPoints_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChartDataPoints);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataSeries) => Property (SeriesName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataSeries_Public_Class_SeriesName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="EpmChartDataSeries" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddDataPoint)]
        [TestCase(MethodOrderDataPointsSoSmallerBubblesAreInFront)]
        public void AUT_EpmChartDataSeries_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EpmChartDataSeries>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddDataPoint) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataSeries_AddDataPoint_Method_Call_Internally(Type[] types)
        {
            var methodAddDataPointPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataSeriesInstance, MethodAddDataPoint, Fixture, methodAddDataPointPrametersTypes);
        }

        #endregion

        #region Method Call : (AddDataPoint) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_AddDataPoint_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var dataPoint = CreateType<EpmChartDataPoint>();
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartDataSeriesInstance.AddDataPoint(dataPoint);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddDataPoint) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_AddDataPoint_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dataPoint = CreateType<EpmChartDataPoint>();
            var methodAddDataPointPrametersTypes = new Type[] { typeof(EpmChartDataPoint) };
            object[] parametersOfAddDataPoint = { dataPoint };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddDataPoint, methodAddDataPointPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataSeriesInstanceFixture, parametersOfAddDataPoint);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddDataPoint.ShouldNotBeNull();
            parametersOfAddDataPoint.Length.ShouldBe(1);
            methodAddDataPointPrametersTypes.Length.ShouldBe(1);
            methodAddDataPointPrametersTypes.Length.ShouldBe(parametersOfAddDataPoint.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddDataPoint) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_AddDataPoint_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataPoint = CreateType<EpmChartDataPoint>();
            var methodAddDataPointPrametersTypes = new Type[] { typeof(EpmChartDataPoint) };
            object[] parametersOfAddDataPoint = { dataPoint };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartDataSeriesInstance, MethodAddDataPoint, parametersOfAddDataPoint, methodAddDataPointPrametersTypes);

            // Assert
            parametersOfAddDataPoint.ShouldNotBeNull();
            parametersOfAddDataPoint.Length.ShouldBe(1);
            methodAddDataPointPrametersTypes.Length.ShouldBe(1);
            methodAddDataPointPrametersTypes.Length.ShouldBe(parametersOfAddDataPoint.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddDataPoint) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_AddDataPoint_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddDataPoint, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddDataPoint) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_AddDataPoint_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddDataPointPrametersTypes = new Type[] { typeof(EpmChartDataPoint) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataSeriesInstance, MethodAddDataPoint, Fixture, methodAddDataPointPrametersTypes);

            // Assert
            methodAddDataPointPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddDataPoint) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_AddDataPoint_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddDataPoint, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataSeriesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OrderDataPointsSoSmallerBubblesAreInFront) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataSeries_OrderDataPointsSoSmallerBubblesAreInFront_Method_Call_Internally(Type[] types)
        {
            var methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataSeriesInstance, MethodOrderDataPointsSoSmallerBubblesAreInFront, Fixture, methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes);
        }

        #endregion

        #region Method Call : (OrderDataPointsSoSmallerBubblesAreInFront) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_OrderDataPointsSoSmallerBubblesAreInFront_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartDataSeriesInstance.OrderDataPointsSoSmallerBubblesAreInFront();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (OrderDataPointsSoSmallerBubblesAreInFront) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_OrderDataPointsSoSmallerBubblesAreInFront_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes = null;
            object[] parametersOfOrderDataPointsSoSmallerBubblesAreInFront = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOrderDataPointsSoSmallerBubblesAreInFront, methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataSeriesInstanceFixture, parametersOfOrderDataPointsSoSmallerBubblesAreInFront);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOrderDataPointsSoSmallerBubblesAreInFront.ShouldBeNull();
            methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OrderDataPointsSoSmallerBubblesAreInFront) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_OrderDataPointsSoSmallerBubblesAreInFront_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes = null;
            object[] parametersOfOrderDataPointsSoSmallerBubblesAreInFront = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartDataSeriesInstance, MethodOrderDataPointsSoSmallerBubblesAreInFront, parametersOfOrderDataPointsSoSmallerBubblesAreInFront, methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes);

            // Assert
            parametersOfOrderDataPointsSoSmallerBubblesAreInFront.ShouldBeNull();
            methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OrderDataPointsSoSmallerBubblesAreInFront) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_OrderDataPointsSoSmallerBubblesAreInFront_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataSeriesInstance, MethodOrderDataPointsSoSmallerBubblesAreInFront, Fixture, methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes);

            // Assert
            methodOrderDataPointsSoSmallerBubblesAreInFrontPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OrderDataPointsSoSmallerBubblesAreInFront) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataSeries_OrderDataPointsSoSmallerBubblesAreInFront_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOrderDataPointsSoSmallerBubblesAreInFront, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataSeriesInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}