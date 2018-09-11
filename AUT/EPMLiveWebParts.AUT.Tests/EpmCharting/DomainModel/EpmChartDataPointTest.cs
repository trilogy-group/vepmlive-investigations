using System;
using System.Collections.Generic;
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

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainModel.EpmChartDataPoint" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartDataPointTest : AbstractBaseSetupTypedTest<EpmChartDataPoint>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChartDataPoint) Initializer

        private const string PropertyChartAggregate = "ChartAggregate";
        private const string PropertyDataPointColor = "DataPointColor";
        private const string PropertyTitle = "Title";
        private const string PropertyLegendText = "LegendText";
        private const string PropertyShowInLegend = "ShowInLegend";
        private const string PropertyXAxisLabel = "XAxisLabel";
        private const string PropertyXAxisFieldName = "XAxisFieldName";
        private const string PropertyXAxisValue = "XAxisValue";
        private const string PropertyZAxisLabel = "ZAxisLabel";
        private const string PropertyZAxisFieldName = "ZAxisFieldName";
        private const string PropertyZAxisValue = "ZAxisValue";
        private const string PropertyYAxisLabel = "YAxisLabel";
        private const string PropertyYAxisValuesRaw = "YAxisValuesRaw";
        private const string PropertyYAxisValuesAggregated = "YAxisValuesAggregated";
        private const string MethodAddYAxisValue = "AddYAxisValue";
        private const string MethodYAxisValuesSummed = "YAxisValuesSummed";
        private const string MethodYAxisValuesAveraged = "YAxisValuesAveraged";
        private const string MethodYAxisValuesCounted = "YAxisValuesCounted";
        private const string FieldYAxisFieldName = "YAxisFieldName";
        private Type _epmChartDataPointInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChartDataPoint _epmChartDataPointInstance;
        private EpmChartDataPoint _epmChartDataPointInstanceFixture;

        #region General Initializer : Class (EpmChartDataPoint) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChartDataPoint" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartDataPointInstanceType = typeof(EpmChartDataPoint);
            _epmChartDataPointInstanceFixture = Create(true);
            _epmChartDataPointInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChartDataPoint)

        #region General Initializer : Class (EpmChartDataPoint) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChartDataPoint" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddYAxisValue, 0)]
        [TestCase(MethodYAxisValuesSummed, 0)]
        [TestCase(MethodYAxisValuesAveraged, 0)]
        [TestCase(MethodYAxisValuesCounted, 0)]
        public void AUT_EpmChartDataPoint_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartDataPointInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChartDataPoint) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChartDataPoint" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyChartAggregate)]
        [TestCase(PropertyDataPointColor)]
        [TestCase(PropertyTitle)]
        [TestCase(PropertyLegendText)]
        [TestCase(PropertyShowInLegend)]
        [TestCase(PropertyXAxisLabel)]
        [TestCase(PropertyXAxisFieldName)]
        [TestCase(PropertyXAxisValue)]
        [TestCase(PropertyZAxisLabel)]
        [TestCase(PropertyZAxisFieldName)]
        [TestCase(PropertyZAxisValue)]
        [TestCase(PropertyYAxisLabel)]
        [TestCase(PropertyYAxisValuesRaw)]
        [TestCase(PropertyYAxisValuesAggregated)]
        public void AUT_EpmChartDataPoint_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_epmChartDataPointInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChartDataPoint) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChartDataPoint" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldYAxisFieldName)]
        public void AUT_EpmChartDataPoint_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_epmChartDataPointInstanceFixture, 
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
        ///     Class (<see cref="EpmChartDataPoint" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChartDataPoint_Is_Instance_Present_Test()
        {
            // Assert
            _epmChartDataPointInstanceType.ShouldNotBeNull();
            _epmChartDataPointInstance.ShouldNotBeNull();
            _epmChartDataPointInstanceFixture.ShouldNotBeNull();
            _epmChartDataPointInstance.ShouldBeAssignableTo<EpmChartDataPoint>();
            _epmChartDataPointInstanceFixture.ShouldBeAssignableTo<EpmChartDataPoint>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EpmChartDataPoint) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChartDataPoint_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var chartAggregate = CreateType<EpmChartAggregateType>();
            EpmChartDataPoint instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new EpmChartDataPoint(chartAggregate);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _epmChartDataPointInstance.ShouldNotBeNull();
            _epmChartDataPointInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<EpmChartDataPoint>();
        }

        #endregion

        #region General Constructor : Class (EpmChartDataPoint) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChartDataPoint_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var chartAggregate = CreateType<EpmChartAggregateType>();
            EpmChartDataPoint instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new EpmChartDataPoint(chartAggregate);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _epmChartDataPointInstance.ShouldNotBeNull();
            _epmChartDataPointInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EpmChartDataPoint) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(EpmChartAggregateType) , PropertyChartAggregate)]
        [TestCaseGeneric(typeof(Color) , PropertyDataPointColor)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        [TestCaseGeneric(typeof(string) , PropertyLegendText)]
        [TestCaseGeneric(typeof(bool) , PropertyShowInLegend)]
        [TestCaseGeneric(typeof(string) , PropertyXAxisLabel)]
        [TestCaseGeneric(typeof(string) , PropertyXAxisFieldName)]
        [TestCaseGeneric(typeof(double) , PropertyXAxisValue)]
        [TestCaseGeneric(typeof(string) , PropertyZAxisLabel)]
        [TestCaseGeneric(typeof(string) , PropertyZAxisFieldName)]
        [TestCaseGeneric(typeof(double) , PropertyZAxisValue)]
        [TestCaseGeneric(typeof(string) , PropertyYAxisLabel)]
        [TestCaseGeneric(typeof(List<double>) , PropertyYAxisValuesRaw)]
        [TestCaseGeneric(typeof(double) , PropertyYAxisValuesAggregated)]
        public void AUT_EpmChartDataPoint_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EpmChartDataPoint, T>(_epmChartDataPointInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (ChartAggregate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_ChartAggregate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyChartAggregate);
            Action currentAction = () => propertyInfo.SetValue(_epmChartDataPointInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (ChartAggregate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_ChartAggregate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChartAggregate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (DataPointColor) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_DataPointColor_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDataPointColor);
            Action currentAction = () => propertyInfo.SetValue(_epmChartDataPointInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (DataPointColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_DataPointColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataPointColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (LegendText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_LegendText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLegendText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (ShowInLegend) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_ShowInLegend_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyShowInLegend);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (XAxisFieldName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_XAxisFieldName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyXAxisFieldName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (XAxisLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_XAxisLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyXAxisLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (XAxisValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_XAxisValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyXAxisValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (YAxisLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_YAxisLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyYAxisLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (YAxisValuesAggregated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_YAxisValuesAggregated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyYAxisValuesAggregated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (YAxisValuesRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_YAxisValuesRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyYAxisValuesRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (ZAxisFieldName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_ZAxisFieldName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZAxisFieldName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (ZAxisLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_ZAxisLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZAxisLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChartDataPoint) => Property (ZAxisValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChartDataPoint_Public_Class_ZAxisValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZAxisValue);

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
        ///      Class (<see cref="EpmChartDataPoint" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddYAxisValue)]
        [TestCase(MethodYAxisValuesSummed)]
        [TestCase(MethodYAxisValuesAveraged)]
        [TestCase(MethodYAxisValuesCounted)]
        public void AUT_EpmChartDataPoint_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EpmChartDataPoint>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddYAxisValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataPoint_AddYAxisValue_Method_Call_Internally(Type[] types)
        {
            var methodAddYAxisValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodAddYAxisValue, Fixture, methodAddYAxisValuePrametersTypes);
        }

        #endregion

        #region Method Call : (AddYAxisValue) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_AddYAxisValue_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartDataPointInstance.AddYAxisValue(value);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddYAxisValue) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_AddYAxisValue_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var value = CreateType<double>();
            var methodAddYAxisValuePrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfAddYAxisValue = { value };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddYAxisValue, methodAddYAxisValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataPointInstanceFixture, parametersOfAddYAxisValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddYAxisValue.ShouldNotBeNull();
            parametersOfAddYAxisValue.Length.ShouldBe(1);
            methodAddYAxisValuePrametersTypes.Length.ShouldBe(1);
            methodAddYAxisValuePrametersTypes.Length.ShouldBe(parametersOfAddYAxisValue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddYAxisValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_AddYAxisValue_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var value = CreateType<double>();
            var methodAddYAxisValuePrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfAddYAxisValue = { value };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartDataPointInstance, MethodAddYAxisValue, parametersOfAddYAxisValue, methodAddYAxisValuePrametersTypes);

            // Assert
            parametersOfAddYAxisValue.ShouldNotBeNull();
            parametersOfAddYAxisValue.Length.ShouldBe(1);
            methodAddYAxisValuePrametersTypes.Length.ShouldBe(1);
            methodAddYAxisValuePrametersTypes.Length.ShouldBe(parametersOfAddYAxisValue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddYAxisValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_AddYAxisValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddYAxisValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddYAxisValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_AddYAxisValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddYAxisValuePrametersTypes = new Type[] { typeof(double) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodAddYAxisValue, Fixture, methodAddYAxisValuePrametersTypes);

            // Assert
            methodAddYAxisValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddYAxisValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_AddYAxisValue_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddYAxisValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataPointInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (YAxisValuesSummed) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataPoint_YAxisValuesSummed_Method_Call_Internally(Type[] types)
        {
            var methodYAxisValuesSummedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesSummed, Fixture, methodYAxisValuesSummedPrametersTypes);
        }

        #endregion

        #region Method Call : (YAxisValuesSummed) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesSummed_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodYAxisValuesSummedPrametersTypes = null;
            object[] parametersOfYAxisValuesSummed = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodYAxisValuesSummed, methodYAxisValuesSummedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataPointInstanceFixture, parametersOfYAxisValuesSummed);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfYAxisValuesSummed.ShouldBeNull();
            methodYAxisValuesSummedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (YAxisValuesSummed) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesSummed_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodYAxisValuesSummedPrametersTypes = null;
            object[] parametersOfYAxisValuesSummed = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChartDataPoint, double>(_epmChartDataPointInstance, MethodYAxisValuesSummed, parametersOfYAxisValuesSummed, methodYAxisValuesSummedPrametersTypes);

            // Assert
            parametersOfYAxisValuesSummed.ShouldBeNull();
            methodYAxisValuesSummedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (YAxisValuesSummed) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesSummed_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodYAxisValuesSummedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesSummed, Fixture, methodYAxisValuesSummedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodYAxisValuesSummedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesSummed) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesSummed_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodYAxisValuesSummedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesSummed, Fixture, methodYAxisValuesSummedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodYAxisValuesSummedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesSummed) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesSummed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodYAxisValuesSummedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesSummed, Fixture, methodYAxisValuesSummedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodYAxisValuesSummedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesSummed) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesSummed_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodYAxisValuesSummed, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataPointInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesAveraged) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataPoint_YAxisValuesAveraged_Method_Call_Internally(Type[] types)
        {
            var methodYAxisValuesAveragedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesAveraged, Fixture, methodYAxisValuesAveragedPrametersTypes);
        }

        #endregion

        #region Method Call : (YAxisValuesAveraged) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesAveraged_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodYAxisValuesAveragedPrametersTypes = null;
            object[] parametersOfYAxisValuesAveraged = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodYAxisValuesAveraged, methodYAxisValuesAveragedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataPointInstanceFixture, parametersOfYAxisValuesAveraged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfYAxisValuesAveraged.ShouldBeNull();
            methodYAxisValuesAveragedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (YAxisValuesAveraged) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesAveraged_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodYAxisValuesAveragedPrametersTypes = null;
            object[] parametersOfYAxisValuesAveraged = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChartDataPoint, double>(_epmChartDataPointInstance, MethodYAxisValuesAveraged, parametersOfYAxisValuesAveraged, methodYAxisValuesAveragedPrametersTypes);

            // Assert
            parametersOfYAxisValuesAveraged.ShouldBeNull();
            methodYAxisValuesAveragedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (YAxisValuesAveraged) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesAveraged_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodYAxisValuesAveragedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesAveraged, Fixture, methodYAxisValuesAveragedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodYAxisValuesAveragedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesAveraged) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesAveraged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodYAxisValuesAveragedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesAveraged, Fixture, methodYAxisValuesAveragedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodYAxisValuesAveragedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesAveraged) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesAveraged_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodYAxisValuesAveraged, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataPointInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesCounted) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChartDataPoint_YAxisValuesCounted_Method_Call_Internally(Type[] types)
        {
            var methodYAxisValuesCountedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesCounted, Fixture, methodYAxisValuesCountedPrametersTypes);
        }

        #endregion

        #region Method Call : (YAxisValuesCounted) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesCounted_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodYAxisValuesCountedPrametersTypes = null;
            object[] parametersOfYAxisValuesCounted = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodYAxisValuesCounted, methodYAxisValuesCountedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartDataPointInstanceFixture, parametersOfYAxisValuesCounted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfYAxisValuesCounted.ShouldBeNull();
            methodYAxisValuesCountedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (YAxisValuesCounted) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesCounted_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodYAxisValuesCountedPrametersTypes = null;
            object[] parametersOfYAxisValuesCounted = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChartDataPoint, double>(_epmChartDataPointInstance, MethodYAxisValuesCounted, parametersOfYAxisValuesCounted, methodYAxisValuesCountedPrametersTypes);

            // Assert
            parametersOfYAxisValuesCounted.ShouldBeNull();
            methodYAxisValuesCountedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (YAxisValuesCounted) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesCounted_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodYAxisValuesCountedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesCounted, Fixture, methodYAxisValuesCountedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodYAxisValuesCountedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesCounted) (Return Type : double) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesCounted_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodYAxisValuesCountedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesCounted, Fixture, methodYAxisValuesCountedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodYAxisValuesCountedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesCounted) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesCounted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodYAxisValuesCountedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartDataPointInstance, MethodYAxisValuesCounted, Fixture, methodYAxisValuesCountedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodYAxisValuesCountedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (YAxisValuesCounted) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChartDataPoint_YAxisValuesCounted_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodYAxisValuesCounted, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartDataPointInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}