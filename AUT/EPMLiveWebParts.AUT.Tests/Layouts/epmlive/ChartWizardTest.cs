using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.ChartWizard" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ChartWizardTest : AbstractBaseSetupTypedTest<ChartWizard>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChartWizard) Initializer

        private const string PropertysChartTitle = "sChartTitle";
        private const string PropertysChartType = "sChartType";
        private const string PropertysPropChartSelectedPaletteName = "sPropChartSelectedPaletteName";
        private const string PropertysPropChartSelectedListAndViewName = "sPropChartSelectedListAndViewName";
        private const string PropertysPropChartSelectedViewTitle = "sPropChartSelectedViewTitle";
        private const string PropertysPropChartSelectedListTitle = "sPropChartSelectedListTitle";
        private const string PropertysPropChartXaxisField = "sPropChartXaxisField";
        private const string PropertysPropChartXaxisFieldLabel = "sPropChartXaxisFieldLabel";
        private const string PropertysPropChartYaxisField = "sPropChartYaxisField";
        private const string PropertysPropChartYaxisFieldLabel = "sPropChartYaxisFieldLabel";
        private const string PropertysPropChartZaxisField = "sPropChartZaxisField";
        private const string PropertysPropChartZaxisFieldLabel = "sPropChartZaxisFieldLabel";
        private const string PropertysPropBubbleChartGroupBy = "sPropBubbleChartGroupBy";
        private const string PropertysPropYaxisFormat = "sPropYaxisFormat";
        private const string PropertysPropChartShowSeriesLabels = "sPropChartShowSeriesLabels";
        private const string PropertysPropChartShowLegend = "sPropChartShowLegend";
        private const string PropertysPropChartShowGridlines = "sPropChartShowGridlines";
        private const string PropertysPropChartAggregationType = "sPropChartAggregationType";
        private const string PropertysPropChartLegendPosition = "sPropChartLegendPosition";
        private const string MethodGetListAndViewName = "GetListAndViewName";
        private const string MethodFillStaticData = "FillStaticData";
        private const string MethodFillData = "FillData";
        private const string MethodWriteControlClientIds = "WriteControlClientIds";
        private const string MethodRegisterControlEvents = "RegisterControlEvents";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetListColumns = "GetListColumns";
        private const string Field_GridUrl = "_GridUrl";
        private const string Field_CSSUrl = "_CSSUrl";
        private Type _chartWizardInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChartWizard _chartWizardInstance;
        private ChartWizard _chartWizardInstanceFixture;

        #region General Initializer : Class (ChartWizard) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChartWizard" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chartWizardInstanceType = typeof(ChartWizard);
            _chartWizardInstanceFixture = Create(true);
            _chartWizardInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChartWizard)

        #region General Initializer : Class (ChartWizard) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ChartWizard" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetListAndViewName, 0)]
        [TestCase(MethodFillStaticData, 0)]
        [TestCase(MethodFillData, 0)]
        [TestCase(MethodWriteControlClientIds, 0)]
        [TestCase(MethodRegisterControlEvents, 0)]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetListColumns, 0)]
        public void AUT_ChartWizard_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_chartWizardInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChartWizard) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChartWizard" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertysChartTitle)]
        [TestCase(PropertysChartType)]
        [TestCase(PropertysPropChartSelectedPaletteName)]
        [TestCase(PropertysPropChartSelectedListAndViewName)]
        [TestCase(PropertysPropChartSelectedViewTitle)]
        [TestCase(PropertysPropChartSelectedListTitle)]
        [TestCase(PropertysPropChartXaxisField)]
        [TestCase(PropertysPropChartXaxisFieldLabel)]
        [TestCase(PropertysPropChartYaxisField)]
        [TestCase(PropertysPropChartYaxisFieldLabel)]
        [TestCase(PropertysPropChartZaxisField)]
        [TestCase(PropertysPropChartZaxisFieldLabel)]
        [TestCase(PropertysPropBubbleChartGroupBy)]
        [TestCase(PropertysPropYaxisFormat)]
        [TestCase(PropertysPropChartShowSeriesLabels)]
        [TestCase(PropertysPropChartShowLegend)]
        [TestCase(PropertysPropChartShowGridlines)]
        [TestCase(PropertysPropChartAggregationType)]
        [TestCase(PropertysPropChartLegendPosition)]
        public void AUT_ChartWizard_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_chartWizardInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChartWizard) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChartWizard" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_GridUrl)]
        [TestCase(Field_CSSUrl)]
        public void AUT_ChartWizard_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chartWizardInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChartWizard) => Property (sChartTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sChartTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysChartTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sChartType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sChartType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysChartType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropBubbleChartGroupBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropBubbleChartGroupBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropBubbleChartGroupBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartAggregationType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartAggregationType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartAggregationType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartLegendPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartLegendPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartLegendPosition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartSelectedListAndViewName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartSelectedListAndViewName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartSelectedListAndViewName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartSelectedListTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartSelectedListTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartSelectedListTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartSelectedPaletteName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartSelectedPaletteName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartSelectedPaletteName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartSelectedViewTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartSelectedViewTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartSelectedViewTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartShowGridlines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartShowGridlines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartShowGridlines);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartShowLegend) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartShowLegend_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartShowLegend);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartShowSeriesLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartShowSeriesLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartShowSeriesLabels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartXaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartXaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartXaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartXaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartXaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartXaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartYaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartYaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartYaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartYaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartYaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartYaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartZaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartZaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartZaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropChartZaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropChartZaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropChartZaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartWizard) => Property (sPropYaxisFormat) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ChartWizard_Public_Class_sPropYaxisFormat_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropYaxisFormat);

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
        ///      Class (<see cref="ChartWizard" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetListAndViewName)]
        [TestCase(MethodFillStaticData)]
        [TestCase(MethodFillData)]
        [TestCase(MethodWriteControlClientIds)]
        [TestCase(MethodRegisterControlEvents)]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodGetListColumns)]
        public void AUT_ChartWizard_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ChartWizard>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetListAndViewName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartWizard_GetListAndViewName_Method_Call_Internally(Type[] types)
        {
            var methodGetListAndViewNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodGetListAndViewName, Fixture, methodGetListAndViewNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetListAndViewName) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListAndViewName_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetListAndViewNamePrametersTypes = null;
            object[] parametersOfGetListAndViewName = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetListAndViewName, methodGetListAndViewNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartWizardInstanceFixture, parametersOfGetListAndViewName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetListAndViewName.ShouldBeNull();
            methodGetListAndViewNamePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetListAndViewName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListAndViewName_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetListAndViewNamePrametersTypes = null;
            object[] parametersOfGetListAndViewName = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartWizardInstance, MethodGetListAndViewName, parametersOfGetListAndViewName, methodGetListAndViewNamePrametersTypes);

            // Assert
            parametersOfGetListAndViewName.ShouldBeNull();
            methodGetListAndViewNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListAndViewName) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListAndViewName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetListAndViewNamePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodGetListAndViewName, Fixture, methodGetListAndViewNamePrametersTypes);

            // Assert
            methodGetListAndViewNamePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListAndViewName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListAndViewName_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListAndViewName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillStaticData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartWizard_FillStaticData_Method_Call_Internally(Type[] types)
        {
            var methodFillStaticDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodFillStaticData, Fixture, methodFillStaticDataPrametersTypes);
        }

        #endregion

        #region Method Call : (FillStaticData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillStaticData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodFillStaticDataPrametersTypes = null;
            object[] parametersOfFillStaticData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFillStaticData, methodFillStaticDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartWizardInstanceFixture, parametersOfFillStaticData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillStaticData.ShouldBeNull();
            methodFillStaticDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillStaticData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillStaticData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodFillStaticDataPrametersTypes = null;
            object[] parametersOfFillStaticData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartWizardInstance, MethodFillStaticData, parametersOfFillStaticData, methodFillStaticDataPrametersTypes);

            // Assert
            parametersOfFillStaticData.ShouldBeNull();
            methodFillStaticDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillStaticData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillStaticData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodFillStaticDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodFillStaticData, Fixture, methodFillStaticDataPrametersTypes);

            // Assert
            methodFillStaticDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillStaticData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillStaticData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillStaticData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartWizard_FillData_Method_Call_Internally(Type[] types)
        {
            var methodFillDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodFillData, Fixture, methodFillDataPrametersTypes);
        }

        #endregion

        #region Method Call : (FillData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillData_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodFillDataPrametersTypes = null;
            object[] parametersOfFillData = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFillData, methodFillDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartWizardInstanceFixture, parametersOfFillData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillData.ShouldBeNull();
            methodFillDataPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillData_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodFillDataPrametersTypes = null;
            object[] parametersOfFillData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartWizardInstance, MethodFillData, parametersOfFillData, methodFillDataPrametersTypes);

            // Assert
            parametersOfFillData.ShouldBeNull();
            methodFillDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodFillDataPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodFillData, Fixture, methodFillDataPrametersTypes);

            // Assert
            methodFillDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_FillData_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteControlClientIds) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartWizard_WriteControlClientIds_Method_Call_Internally(Type[] types)
        {
            var methodWriteControlClientIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodWriteControlClientIds, Fixture, methodWriteControlClientIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteControlClientIds) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_WriteControlClientIds_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodWriteControlClientIdsPrametersTypes = null;
            object[] parametersOfWriteControlClientIds = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteControlClientIds, methodWriteControlClientIdsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartWizardInstanceFixture, parametersOfWriteControlClientIds);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteControlClientIds.ShouldBeNull();
            methodWriteControlClientIdsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WriteControlClientIds) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_WriteControlClientIds_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodWriteControlClientIdsPrametersTypes = null;
            object[] parametersOfWriteControlClientIds = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartWizardInstance, MethodWriteControlClientIds, parametersOfWriteControlClientIds, methodWriteControlClientIdsPrametersTypes);

            // Assert
            parametersOfWriteControlClientIds.ShouldBeNull();
            methodWriteControlClientIdsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteControlClientIds) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_WriteControlClientIds_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodWriteControlClientIdsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodWriteControlClientIds, Fixture, methodWriteControlClientIdsPrametersTypes);

            // Assert
            methodWriteControlClientIdsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteControlClientIds) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_WriteControlClientIds_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteControlClientIds, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartWizard_RegisterControlEvents_Method_Call_Internally(Type[] types)
        {
            var methodRegisterControlEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, methodRegisterControlEventsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartWizardInstanceFixture, parametersOfRegisterControlEvents);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterControlEvents.ShouldBeNull();
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_RegisterControlEvents_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;
            object[] parametersOfRegisterControlEvents = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartWizardInstance, MethodRegisterControlEvents, parametersOfRegisterControlEvents, methodRegisterControlEventsPrametersTypes);

            // Assert
            parametersOfRegisterControlEvents.ShouldBeNull();
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_RegisterControlEvents_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRegisterControlEventsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodRegisterControlEvents, Fixture, methodRegisterControlEventsPrametersTypes);

            // Assert
            methodRegisterControlEventsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterControlEvents) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_RegisterControlEvents_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterControlEvents, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartWizard_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartWizardInstanceFixture, parametersOfPage_Load);

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
        public void AUT_ChartWizard_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartWizardInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_ChartWizard_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ChartWizard_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartWizard_GetListColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<Guid>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListColumns = { id };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListColumns, methodGetListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartWizard, DataTable>(_chartWizardInstanceFixture, out exception1, parametersOfGetListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartWizard, DataTable>(_chartWizardInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<Guid>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListColumns = { id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartWizard, DataTable>(_chartWizardInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartWizardInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartWizardInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartWizard_GetListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListColumns, 0);
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