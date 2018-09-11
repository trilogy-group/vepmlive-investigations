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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.VfPoint" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class VfPointTest : AbstractBaseSetupTypedTest<VfPoint>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (VfPoint) Initializer

        private const string PropertyYAxisLabel = "YAxisLabel";
        private const string PropertyZAxisLabel = "ZAxisLabel";
        private const string PropertyDataPointColorAsString = "DataPointColorAsString";
        private const string FieldTitle = "Title";
        private const string FieldXAxisLabel = "XAxisLabel";
        private const string FieldXAxisFieldName = "XAxisFieldName";
        private const string FieldXAxisValue = "XAxisValue";
        private const string FieldYAxisFieldName = "YAxisFieldName";
        private const string FieldYValue = "YValue";
        private const string FieldZAxisFieldName = "ZAxisFieldName";
        private const string FieldZValue = "ZValue";
        private const string FieldShowInLegend = "ShowInLegend";
        private const string FieldLegendText = "LegendText";
        private const string FieldDataPointColor = "DataPointColor";
        private Type _vfPointInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private VfPoint _vfPointInstance;
        private VfPoint _vfPointInstanceFixture;

        #region General Initializer : Class (VfPoint) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="VfPoint" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _vfPointInstanceType = typeof(VfPoint);
            _vfPointInstanceFixture = Create(true);
            _vfPointInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (VfPoint)

        #region General Initializer : Class (VfPoint) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="VfPoint" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyYAxisLabel)]
        [TestCase(PropertyZAxisLabel)]
        [TestCase(PropertyDataPointColorAsString)]
        public void AUT_VfPoint_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_vfPointInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (VfPoint) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="VfPoint" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldTitle)]
        [TestCase(FieldXAxisLabel)]
        [TestCase(FieldXAxisFieldName)]
        [TestCase(FieldXAxisValue)]
        [TestCase(FieldYAxisFieldName)]
        [TestCase(FieldYValue)]
        [TestCase(FieldZAxisFieldName)]
        [TestCase(FieldZValue)]
        [TestCase(FieldShowInLegend)]
        [TestCase(FieldLegendText)]
        [TestCase(FieldDataPointColor)]
        public void AUT_VfPoint_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_vfPointInstanceFixture, 
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
        ///     Class (<see cref="VfPoint" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_VfPoint_Is_Instance_Present_Test()
        {
            // Assert
            _vfPointInstanceType.ShouldNotBeNull();
            _vfPointInstance.ShouldNotBeNull();
            _vfPointInstanceFixture.ShouldNotBeNull();
            _vfPointInstance.ShouldBeAssignableTo<VfPoint>();
            _vfPointInstanceFixture.ShouldBeAssignableTo<VfPoint>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (VfPoint) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_VfPoint_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            VfPoint instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new VfPoint(xAxisLabel, yValue, zValue);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _vfPointInstance.ShouldNotBeNull();
            _vfPointInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<VfPoint>();
        }

        #endregion

        #region General Constructor : Class (VfPoint) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_VfPoint_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var xAxisLabel = CreateType<string>();
            var yValue = CreateType<double>();
            var zValue = CreateType<double>();
            VfPoint instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new VfPoint(xAxisLabel, yValue, zValue);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _vfPointInstance.ShouldNotBeNull();
            _vfPointInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (VfPoint) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyYAxisLabel)]
        [TestCaseGeneric(typeof(string) , PropertyZAxisLabel)]
        [TestCaseGeneric(typeof(string) , PropertyDataPointColorAsString)]
        public void AUT_VfPoint_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<VfPoint, T>(_vfPointInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (VfPoint) => Property (DataPointColorAsString) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfPoint_Public_Class_DataPointColorAsString_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataPointColorAsString);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfPoint) => Property (YAxisLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfPoint_Public_Class_YAxisLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfPoint) => Property (ZAxisLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfPoint_Public_Class_ZAxisLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}