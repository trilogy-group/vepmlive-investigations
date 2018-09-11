using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.EpmCharting.DomainModel;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.Mappers
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.Mappers.EpmChartSeriesToVisifireChartSeriesMapper" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.Mappers"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartSeriesToVisifireChartSeriesMapperTest : AbstractBaseSetupTest
    {

        public EpmChartSeriesToVisifireChartSeriesMapperTest() : base(typeof(EpmChartSeriesToVisifireChartSeriesMapper))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartSeriesToVisifireChartSeriesMapper) Initializer

        private const string MethodGetVisifireChartSeries = "GetVisifireChartSeries";
        private Type _epmChartSeriesToVisifireChartSeriesMapperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (EpmChartSeriesToVisifireChartSeriesMapper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartSeriesToVisifireChartSeriesMapper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartSeriesToVisifireChartSeriesMapperInstanceType = typeof(EpmChartSeriesToVisifireChartSeriesMapper);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartSeriesToVisifireChartSeriesMapper)

        #region General Initializer : Class (EpmChartSeriesToVisifireChartSeriesMapper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartSeriesToVisifireChartSeriesMapper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetVisifireChartSeries, 0)]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="EpmChartSeriesToVisifireChartSeriesMapper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_Is_Static_Type_Present_Test()
        {
            // Assert
            _epmChartSeriesToVisifireChartSeriesMapperInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EpmChartSeriesToVisifireChartSeriesMapper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetVisifireChartSeries)]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _epmChartSeriesToVisifireChartSeriesMapperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetVisifireChartSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _epmChartSeriesToVisifireChartSeriesMapperInstanceType, MethodGetVisifireChartSeries, Fixture, methodGetVisifireChartSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var chartDataSeries = CreateType<EpmChartDataSeriesList>();
            Action executeAction = null;

            // Act
            executeAction = () => EpmChartSeriesToVisifireChartSeriesMapper.GetVisifireChartSeries(chartDataSeries);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var chartDataSeries = CreateType<EpmChartDataSeriesList>();
            var methodGetVisifireChartSeriesPrametersTypes = new Type[] { typeof(EpmChartDataSeriesList) };
            object[] parametersOfGetVisifireChartSeries = { chartDataSeries };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetVisifireChartSeries, methodGetVisifireChartSeriesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _epmChartSeriesToVisifireChartSeriesMapperInstanceType, MethodGetVisifireChartSeries, Fixture, methodGetVisifireChartSeriesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<VfChartSeries>>(null, _epmChartSeriesToVisifireChartSeriesMapperInstanceType, MethodGetVisifireChartSeries, parametersOfGetVisifireChartSeries, methodGetVisifireChartSeriesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetVisifireChartSeries);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetVisifireChartSeries.ShouldNotBeNull();
            parametersOfGetVisifireChartSeries.Length.ShouldBe(1);
            methodGetVisifireChartSeriesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chartDataSeries = CreateType<EpmChartDataSeriesList>();
            var methodGetVisifireChartSeriesPrametersTypes = new Type[] { typeof(EpmChartDataSeriesList) };
            object[] parametersOfGetVisifireChartSeries = { chartDataSeries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<VfChartSeries>>(null, _epmChartSeriesToVisifireChartSeriesMapperInstanceType, MethodGetVisifireChartSeries, parametersOfGetVisifireChartSeries, methodGetVisifireChartSeriesPrametersTypes);

            // Assert
            parametersOfGetVisifireChartSeries.ShouldNotBeNull();
            parametersOfGetVisifireChartSeries.Length.ShouldBe(1);
            methodGetVisifireChartSeriesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetVisifireChartSeriesPrametersTypes = new Type[] { typeof(EpmChartDataSeriesList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _epmChartSeriesToVisifireChartSeriesMapperInstanceType, MethodGetVisifireChartSeries, Fixture, methodGetVisifireChartSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetVisifireChartSeriesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetVisifireChartSeriesPrametersTypes = new Type[] { typeof(EpmChartDataSeriesList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _epmChartSeriesToVisifireChartSeriesMapperInstanceType, MethodGetVisifireChartSeries, Fixture, methodGetVisifireChartSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetVisifireChartSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetVisifireChartSeries, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetVisifireChartSeries) (Return Type : List<VfChartSeries>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartSeriesToVisifireChartSeriesMapper_GetVisifireChartSeries_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetVisifireChartSeries, 0);
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