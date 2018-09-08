using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.EpmCharting.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmCharting.DomainModel.BubbleChartAxisToColumnMapping" />)
    ///     and namespace <see cref="EPMLiveWebParts.EpmCharting.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BubbleChartAxisToColumnMappingTest : AbstractBaseSetupTypedTest<BubbleChartAxisToColumnMapping>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (BubbleChartAxisToColumnMapping) Initializer

        private const string PropertyXaxisColumnIndex = "XaxisColumnIndex";
        private const string PropertyYaxisColumnIndex = "YaxisColumnIndex";
        private const string PropertyZaxisColumnIndex = "ZaxisColumnIndex";
        private const string PropertyZaxisColorColumnIndex = "ZaxisColorColumnIndex";
        private Type _bubbleChartAxisToColumnMappingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private BubbleChartAxisToColumnMapping _bubbleChartAxisToColumnMappingInstance;
        private BubbleChartAxisToColumnMapping _bubbleChartAxisToColumnMappingInstanceFixture;

        #region General Initializer : Class (BubbleChartAxisToColumnMapping) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BubbleChartAxisToColumnMapping" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _bubbleChartAxisToColumnMappingInstanceType = typeof(BubbleChartAxisToColumnMapping);
            _bubbleChartAxisToColumnMappingInstanceFixture = Create(true);
            _bubbleChartAxisToColumnMappingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BubbleChartAxisToColumnMapping)

        #region General Initializer : Class (BubbleChartAxisToColumnMapping) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="BubbleChartAxisToColumnMapping" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyXaxisColumnIndex)]
        [TestCase(PropertyYaxisColumnIndex)]
        [TestCase(PropertyZaxisColumnIndex)]
        [TestCase(PropertyZaxisColorColumnIndex)]
        public void AUT_BubbleChartAxisToColumnMapping_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_bubbleChartAxisToColumnMappingInstanceFixture,
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
        ///     Class (<see cref="BubbleChartAxisToColumnMapping" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_BubbleChartAxisToColumnMapping_Is_Instance_Present_Test()
        {
            // Assert
            _bubbleChartAxisToColumnMappingInstanceType.ShouldNotBeNull();
            _bubbleChartAxisToColumnMappingInstance.ShouldNotBeNull();
            _bubbleChartAxisToColumnMappingInstanceFixture.ShouldNotBeNull();
            _bubbleChartAxisToColumnMappingInstance.ShouldBeAssignableTo<BubbleChartAxisToColumnMapping>();
            _bubbleChartAxisToColumnMappingInstanceFixture.ShouldBeAssignableTo<BubbleChartAxisToColumnMapping>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BubbleChartAxisToColumnMapping) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_BubbleChartAxisToColumnMapping_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BubbleChartAxisToColumnMapping instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _bubbleChartAxisToColumnMappingInstanceType.ShouldNotBeNull();
            _bubbleChartAxisToColumnMappingInstance.ShouldNotBeNull();
            _bubbleChartAxisToColumnMappingInstanceFixture.ShouldNotBeNull();
            _bubbleChartAxisToColumnMappingInstance.ShouldBeAssignableTo<BubbleChartAxisToColumnMapping>();
            _bubbleChartAxisToColumnMappingInstanceFixture.ShouldBeAssignableTo<BubbleChartAxisToColumnMapping>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (BubbleChartAxisToColumnMapping) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyXaxisColumnIndex)]
        [TestCaseGeneric(typeof(int) , PropertyYaxisColumnIndex)]
        [TestCaseGeneric(typeof(int) , PropertyZaxisColumnIndex)]
        [TestCaseGeneric(typeof(int) , PropertyZaxisColorColumnIndex)]
        public void AUT_BubbleChartAxisToColumnMapping_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<BubbleChartAxisToColumnMapping, T>(_bubbleChartAxisToColumnMappingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (BubbleChartAxisToColumnMapping) => Property (XaxisColumnIndex) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BubbleChartAxisToColumnMapping_Public_Class_XaxisColumnIndex_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyXaxisColumnIndex);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (BubbleChartAxisToColumnMapping) => Property (YaxisColumnIndex) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BubbleChartAxisToColumnMapping_Public_Class_YaxisColumnIndex_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyYaxisColumnIndex);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (BubbleChartAxisToColumnMapping) => Property (ZaxisColorColumnIndex) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BubbleChartAxisToColumnMapping_Public_Class_ZaxisColorColumnIndex_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZaxisColorColumnIndex);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (BubbleChartAxisToColumnMapping) => Property (ZaxisColumnIndex) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BubbleChartAxisToColumnMapping_Public_Class_ZaxisColumnIndex_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyZaxisColumnIndex);

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