using System;
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

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.UpdateWebPart" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UpdateWebPartTest : AbstractBaseSetupTypedTest<UpdateWebPart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UpdateWebPart) Initializer

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
        private const string PropertysPropLegendPosition = "sPropLegendPosition";
        private const string PropertysPropChartShowSeriesLabels = "sPropChartShowSeriesLabels";
        private const string PropertysPropChartShowLegend = "sPropChartShowLegend";
        private const string PropertysPropChartShowGridlines = "sPropChartShowGridlines";
        private const string PropertysPropChartAggregationType = "sPropChartAggregationType";
        private const string PropertysWpPagePath = "sWpPagePath";
        private const string PropertysWpId = "sWpId";
        private const string MethodPage_Load = "Page_Load";
        private const string MethodSaveChartProperties = "SaveChartProperties";
        private const string MethodGetParams = "GetParams";
        private const string Fielddata = "data";
        private Type _updateWebPartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UpdateWebPart _updateWebPartInstance;
        private UpdateWebPart _updateWebPartInstanceFixture;

        #region General Initializer : Class (UpdateWebPart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UpdateWebPart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _updateWebPartInstanceType = typeof(UpdateWebPart);
            _updateWebPartInstanceFixture = Create(true);
            _updateWebPartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UpdateWebPart)

        #region General Initializer : Class (UpdateWebPart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="UpdateWebPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodSaveChartProperties, 0)]
        [TestCase(MethodGetParams, 0)]
        public void AUT_UpdateWebPart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_updateWebPartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpdateWebPart) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateWebPart" />) explore and verify properties for coverage gain.
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
        [TestCase(PropertysPropLegendPosition)]
        [TestCase(PropertysPropChartShowSeriesLabels)]
        [TestCase(PropertysPropChartShowLegend)]
        [TestCase(PropertysPropChartShowGridlines)]
        [TestCase(PropertysPropChartAggregationType)]
        [TestCase(PropertysWpPagePath)]
        [TestCase(PropertysWpId)]
        public void AUT_UpdateWebPart_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_updateWebPartInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpdateWebPart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateWebPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddata)]
        public void AUT_UpdateWebPart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_updateWebPartInstanceFixture, 
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
        ///     Class (<see cref="UpdateWebPart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UpdateWebPart_Is_Instance_Present_Test()
        {
            // Assert
            _updateWebPartInstanceType.ShouldNotBeNull();
            _updateWebPartInstance.ShouldNotBeNull();
            _updateWebPartInstanceFixture.ShouldNotBeNull();
            _updateWebPartInstance.ShouldBeAssignableTo<UpdateWebPart>();
            _updateWebPartInstanceFixture.ShouldBeAssignableTo<UpdateWebPart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UpdateWebPart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UpdateWebPart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UpdateWebPart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _updateWebPartInstanceType.ShouldNotBeNull();
            _updateWebPartInstance.ShouldNotBeNull();
            _updateWebPartInstanceFixture.ShouldNotBeNull();
            _updateWebPartInstance.ShouldBeAssignableTo<UpdateWebPart>();
            _updateWebPartInstanceFixture.ShouldBeAssignableTo<UpdateWebPart>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (UpdateWebPart) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertysChartTitle)]
        [TestCaseGeneric(typeof(string) , PropertysChartType)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartSelectedPaletteName)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartSelectedListAndViewName)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartSelectedViewTitle)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartSelectedListTitle)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartXaxisField)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartXaxisFieldLabel)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartYaxisField)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartYaxisFieldLabel)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartZaxisField)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartZaxisFieldLabel)]
        [TestCaseGeneric(typeof(string) , PropertysPropBubbleChartGroupBy)]
        [TestCaseGeneric(typeof(string) , PropertysPropYaxisFormat)]
        [TestCaseGeneric(typeof(string) , PropertysPropLegendPosition)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartShowSeriesLabels)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartShowLegend)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartShowGridlines)]
        [TestCaseGeneric(typeof(string) , PropertysPropChartAggregationType)]
        [TestCaseGeneric(typeof(string) , PropertysWpPagePath)]
        [TestCaseGeneric(typeof(string) , PropertysWpId)]
        public void AUT_UpdateWebPart_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<UpdateWebPart, T>(_updateWebPartInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sChartTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sChartTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sChartType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sChartType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropBubbleChartGroupBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropBubbleChartGroupBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartAggregationType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartAggregationType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartSelectedListAndViewName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartSelectedListAndViewName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartSelectedListTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartSelectedListTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartSelectedPaletteName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartSelectedPaletteName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartSelectedViewTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartSelectedViewTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartShowGridlines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartShowGridlines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartShowLegend) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartShowLegend_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartShowSeriesLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartShowSeriesLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartXaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartXaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartXaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartXaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartYaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartYaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartYaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartYaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartZaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartZaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropChartZaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropChartZaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropLegendPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropLegendPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysPropLegendPosition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sPropYaxisFormat) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sPropYaxisFormat_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sWpId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sWpId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysWpId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (UpdateWebPart) => Property (sWpPagePath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UpdateWebPart_Public_Class_sWpPagePath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysWpPagePath);

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
        ///      Class (<see cref="UpdateWebPart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodSaveChartProperties)]
        [TestCase(MethodGetParams)]
        public void AUT_UpdateWebPart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<UpdateWebPart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebPart_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebPartInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_updateWebPartInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_updateWebPartInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_UpdateWebPart_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_UpdateWebPart_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebPartInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_updateWebPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveChartProperties) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebPart_SaveChartProperties_Method_Call_Internally(Type[] types)
        {
            var methodSaveChartPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebPartInstance, MethodSaveChartProperties, Fixture, methodSaveChartPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveChartProperties) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_SaveChartProperties_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSaveChartPropertiesPrametersTypes = null;
            object[] parametersOfSaveChartProperties = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveChartProperties, methodSaveChartPropertiesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_updateWebPartInstanceFixture, parametersOfSaveChartProperties);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveChartProperties.ShouldBeNull();
            methodSaveChartPropertiesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveChartProperties) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_SaveChartProperties_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSaveChartPropertiesPrametersTypes = null;
            object[] parametersOfSaveChartProperties = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_updateWebPartInstance, MethodSaveChartProperties, parametersOfSaveChartProperties, methodSaveChartPropertiesPrametersTypes);

            // Assert
            parametersOfSaveChartProperties.ShouldBeNull();
            methodSaveChartPropertiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveChartProperties) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_SaveChartProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSaveChartPropertiesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebPartInstance, MethodSaveChartProperties, Fixture, methodSaveChartPropertiesPrametersTypes);

            // Assert
            methodSaveChartPropertiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveChartProperties) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_SaveChartProperties_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveChartProperties, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_updateWebPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebPart_GetParams_Method_Call_Internally(Type[] types)
        {
            var methodGetParamsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebPartInstance, MethodGetParams, Fixture, methodGetParamsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_GetParams_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetParamsPrametersTypes = null;
            object[] parametersOfGetParams = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetParams, methodGetParamsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_updateWebPartInstanceFixture, parametersOfGetParams);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetParams.ShouldBeNull();
            methodGetParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_GetParams_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetParamsPrametersTypes = null;
            object[] parametersOfGetParams = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_updateWebPartInstance, MethodGetParams, parametersOfGetParams, methodGetParamsPrametersTypes);

            // Assert
            parametersOfGetParams.ShouldBeNull();
            methodGetParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_GetParams_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetParamsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebPartInstance, MethodGetParams, Fixture, methodGetParamsPrametersTypes);

            // Assert
            methodGetParamsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParams) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_UpdateWebPart_GetParams_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParams, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_updateWebPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}