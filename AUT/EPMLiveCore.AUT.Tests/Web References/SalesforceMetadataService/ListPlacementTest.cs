using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ListPlacement" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ListPlacementTest : AbstractBaseSetupTypedTest<ListPlacement>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ListPlacement) Initializer

        private const string Propertyheight = "height";
        private const string PropertyheightSpecified = "heightSpecified";
        private const string Propertylocation = "location";
        private const string Propertyunits = "units";
        private const string Propertywidth = "width";
        private const string PropertywidthSpecified = "widthSpecified";
        private const string FieldheightField = "heightField";
        private const string FieldheightFieldSpecified = "heightFieldSpecified";
        private const string FieldlocationField = "locationField";
        private const string FieldunitsField = "unitsField";
        private const string FieldwidthField = "widthField";
        private const string FieldwidthFieldSpecified = "widthFieldSpecified";
        private Type _listPlacementInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ListPlacement _listPlacementInstance;
        private ListPlacement _listPlacementInstanceFixture;

        #region General Initializer : Class (ListPlacement) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ListPlacement" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _listPlacementInstanceType = typeof(ListPlacement);
            _listPlacementInstanceFixture = Create(true);
            _listPlacementInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ListPlacement)

        #region General Initializer : Class (ListPlacement) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ListPlacement" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyheight)]
        [TestCase(PropertyheightSpecified)]
        [TestCase(Propertylocation)]
        [TestCase(Propertyunits)]
        [TestCase(Propertywidth)]
        [TestCase(PropertywidthSpecified)]
        public void AUT_ListPlacement_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_listPlacementInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ListPlacement) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ListPlacement" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldheightField)]
        [TestCase(FieldheightFieldSpecified)]
        [TestCase(FieldlocationField)]
        [TestCase(FieldunitsField)]
        [TestCase(FieldwidthField)]
        [TestCase(FieldwidthFieldSpecified)]
        public void AUT_ListPlacement_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_listPlacementInstanceFixture, 
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
        ///     Class (<see cref="ListPlacement" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ListPlacement_Is_Instance_Present_Test()
        {
            // Assert
            _listPlacementInstanceType.ShouldNotBeNull();
            _listPlacementInstance.ShouldNotBeNull();
            _listPlacementInstanceFixture.ShouldNotBeNull();
            _listPlacementInstance.ShouldBeAssignableTo<ListPlacement>();
            _listPlacementInstanceFixture.ShouldBeAssignableTo<ListPlacement>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ListPlacement) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ListPlacement_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ListPlacement instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _listPlacementInstanceType.ShouldNotBeNull();
            _listPlacementInstance.ShouldNotBeNull();
            _listPlacementInstanceFixture.ShouldNotBeNull();
            _listPlacementInstance.ShouldBeAssignableTo<ListPlacement>();
            _listPlacementInstanceFixture.ShouldBeAssignableTo<ListPlacement>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ListPlacement) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , Propertyheight)]
        [TestCaseGeneric(typeof(bool) , PropertyheightSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylocation)]
        [TestCaseGeneric(typeof(string) , Propertyunits)]
        [TestCaseGeneric(typeof(int) , Propertywidth)]
        [TestCaseGeneric(typeof(bool) , PropertywidthSpecified)]
        public void AUT_ListPlacement_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ListPlacement, T>(_listPlacementInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ListPlacement) => Property (height) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListPlacement_Public_Class_height_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheight);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListPlacement) => Property (heightSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListPlacement_Public_Class_heightSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyheightSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListPlacement) => Property (location) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListPlacement_Public_Class_location_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylocation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListPlacement) => Property (units) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListPlacement_Public_Class_units_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyunits);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListPlacement) => Property (width) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListPlacement_Public_Class_width_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertywidth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ListPlacement) => Property (widthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ListPlacement_Public_Class_widthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywidthSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}