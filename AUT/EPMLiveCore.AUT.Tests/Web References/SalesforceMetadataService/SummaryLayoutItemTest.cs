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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SummaryLayoutItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SummaryLayoutItemTest : AbstractBaseSetupTypedTest<SummaryLayoutItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SummaryLayoutItem) Initializer

        private const string PropertycustomLink = "customLink";
        private const string Propertyfield = "field";
        private const string PropertyposX = "posX";
        private const string PropertyposY = "posY";
        private const string PropertyposYSpecified = "posYSpecified";
        private const string PropertyposZ = "posZ";
        private const string PropertyposZSpecified = "posZSpecified";
        private const string FieldcustomLinkField = "customLinkField";
        private const string FieldfieldField = "fieldField";
        private const string FieldposXField = "posXField";
        private const string FieldposYField = "posYField";
        private const string FieldposYFieldSpecified = "posYFieldSpecified";
        private const string FieldposZField = "posZField";
        private const string FieldposZFieldSpecified = "posZFieldSpecified";
        private Type _summaryLayoutItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SummaryLayoutItem _summaryLayoutItemInstance;
        private SummaryLayoutItem _summaryLayoutItemInstanceFixture;

        #region General Initializer : Class (SummaryLayoutItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SummaryLayoutItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _summaryLayoutItemInstanceType = typeof(SummaryLayoutItem);
            _summaryLayoutItemInstanceFixture = Create(true);
            _summaryLayoutItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SummaryLayoutItem)

        #region General Initializer : Class (SummaryLayoutItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SummaryLayoutItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomLink)]
        [TestCase(Propertyfield)]
        [TestCase(PropertyposX)]
        [TestCase(PropertyposY)]
        [TestCase(PropertyposYSpecified)]
        [TestCase(PropertyposZ)]
        [TestCase(PropertyposZSpecified)]
        public void AUT_SummaryLayoutItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_summaryLayoutItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SummaryLayoutItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SummaryLayoutItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomLinkField)]
        [TestCase(FieldfieldField)]
        [TestCase(FieldposXField)]
        [TestCase(FieldposYField)]
        [TestCase(FieldposYFieldSpecified)]
        [TestCase(FieldposZField)]
        [TestCase(FieldposZFieldSpecified)]
        public void AUT_SummaryLayoutItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_summaryLayoutItemInstanceFixture, 
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
        ///     Class (<see cref="SummaryLayoutItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SummaryLayoutItem_Is_Instance_Present_Test()
        {
            // Assert
            _summaryLayoutItemInstanceType.ShouldNotBeNull();
            _summaryLayoutItemInstance.ShouldNotBeNull();
            _summaryLayoutItemInstanceFixture.ShouldNotBeNull();
            _summaryLayoutItemInstance.ShouldBeAssignableTo<SummaryLayoutItem>();
            _summaryLayoutItemInstanceFixture.ShouldBeAssignableTo<SummaryLayoutItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SummaryLayoutItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SummaryLayoutItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SummaryLayoutItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _summaryLayoutItemInstanceType.ShouldNotBeNull();
            _summaryLayoutItemInstance.ShouldNotBeNull();
            _summaryLayoutItemInstanceFixture.ShouldNotBeNull();
            _summaryLayoutItemInstance.ShouldBeAssignableTo<SummaryLayoutItem>();
            _summaryLayoutItemInstanceFixture.ShouldBeAssignableTo<SummaryLayoutItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SummaryLayoutItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycustomLink)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(int) , PropertyposX)]
        [TestCaseGeneric(typeof(int) , PropertyposY)]
        [TestCaseGeneric(typeof(bool) , PropertyposYSpecified)]
        [TestCaseGeneric(typeof(int) , PropertyposZ)]
        [TestCaseGeneric(typeof(bool) , PropertyposZSpecified)]
        public void AUT_SummaryLayoutItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SummaryLayoutItem, T>(_summaryLayoutItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayoutItem) => Property (customLink) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayoutItem_Public_Class_customLink_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomLink);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayoutItem) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayoutItem_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayoutItem) => Property (posX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayoutItem_Public_Class_posX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyposX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayoutItem) => Property (posY) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayoutItem_Public_Class_posY_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyposY);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayoutItem) => Property (posYSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayoutItem_Public_Class_posYSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyposYSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayoutItem) => Property (posZ) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayoutItem_Public_Class_posZ_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyposZ);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayoutItem) => Property (posZSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayoutItem_Public_Class_posZSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyposZSpecified);

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