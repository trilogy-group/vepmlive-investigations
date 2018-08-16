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

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SummaryLayout" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SummaryLayoutTest : AbstractBaseSetupTypedTest<SummaryLayout>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SummaryLayout) Initializer

        private const string PropertymasterLabel = "masterLabel";
        private const string PropertysizeX = "sizeX";
        private const string PropertysizeY = "sizeY";
        private const string PropertysizeYSpecified = "sizeYSpecified";
        private const string PropertysizeZ = "sizeZ";
        private const string PropertysizeZSpecified = "sizeZSpecified";
        private const string PropertysummaryLayoutItems = "summaryLayoutItems";
        private const string PropertysummaryLayoutStyle = "summaryLayoutStyle";
        private const string FieldmasterLabelField = "masterLabelField";
        private const string FieldsizeXField = "sizeXField";
        private const string FieldsizeYField = "sizeYField";
        private const string FieldsizeYFieldSpecified = "sizeYFieldSpecified";
        private const string FieldsizeZField = "sizeZField";
        private const string FieldsizeZFieldSpecified = "sizeZFieldSpecified";
        private const string FieldsummaryLayoutItemsField = "summaryLayoutItemsField";
        private const string FieldsummaryLayoutStyleField = "summaryLayoutStyleField";
        private Type _summaryLayoutInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SummaryLayout _summaryLayoutInstance;
        private SummaryLayout _summaryLayoutInstanceFixture;

        #region General Initializer : Class (SummaryLayout) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SummaryLayout" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _summaryLayoutInstanceType = typeof(SummaryLayout);
            _summaryLayoutInstanceFixture = Create(true);
            _summaryLayoutInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SummaryLayout)

        #region General Initializer : Class (SummaryLayout) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SummaryLayout" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertymasterLabel)]
        [TestCase(PropertysizeX)]
        [TestCase(PropertysizeY)]
        [TestCase(PropertysizeYSpecified)]
        [TestCase(PropertysizeZ)]
        [TestCase(PropertysizeZSpecified)]
        [TestCase(PropertysummaryLayoutItems)]
        [TestCase(PropertysummaryLayoutStyle)]
        public void AUT_SummaryLayout_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_summaryLayoutInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SummaryLayout) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SummaryLayout" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmasterLabelField)]
        [TestCase(FieldsizeXField)]
        [TestCase(FieldsizeYField)]
        [TestCase(FieldsizeYFieldSpecified)]
        [TestCase(FieldsizeZField)]
        [TestCase(FieldsizeZFieldSpecified)]
        [TestCase(FieldsummaryLayoutItemsField)]
        [TestCase(FieldsummaryLayoutStyleField)]
        public void AUT_SummaryLayout_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_summaryLayoutInstanceFixture, 
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
        ///     Class (<see cref="SummaryLayout" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SummaryLayout_Is_Instance_Present_Test()
        {
            // Assert
            _summaryLayoutInstanceType.ShouldNotBeNull();
            _summaryLayoutInstance.ShouldNotBeNull();
            _summaryLayoutInstanceFixture.ShouldNotBeNull();
            _summaryLayoutInstance.ShouldBeAssignableTo<SummaryLayout>();
            _summaryLayoutInstanceFixture.ShouldBeAssignableTo<SummaryLayout>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SummaryLayout) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SummaryLayout_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SummaryLayout instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _summaryLayoutInstanceType.ShouldNotBeNull();
            _summaryLayoutInstance.ShouldNotBeNull();
            _summaryLayoutInstanceFixture.ShouldNotBeNull();
            _summaryLayoutInstance.ShouldBeAssignableTo<SummaryLayout>();
            _summaryLayoutInstanceFixture.ShouldBeAssignableTo<SummaryLayout>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SummaryLayout) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertymasterLabel)]
        [TestCaseGeneric(typeof(int) , PropertysizeX)]
        [TestCaseGeneric(typeof(int) , PropertysizeY)]
        [TestCaseGeneric(typeof(bool) , PropertysizeYSpecified)]
        [TestCaseGeneric(typeof(int) , PropertysizeZ)]
        [TestCaseGeneric(typeof(bool) , PropertysizeZSpecified)]
        [TestCaseGeneric(typeof(SummaryLayoutItem[]) , PropertysummaryLayoutItems)]
        [TestCaseGeneric(typeof(SummaryLayoutStyle) , PropertysummaryLayoutStyle)]
        public void AUT_SummaryLayout_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SummaryLayout, T>(_summaryLayoutInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (masterLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_masterLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymasterLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (sizeX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_sizeX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysizeX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (sizeY) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_sizeY_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysizeY);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (sizeYSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_sizeYSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysizeYSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (sizeZ) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_sizeZ_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysizeZ);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (sizeZSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_sizeZSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysizeZSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (summaryLayoutItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_summaryLayoutItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysummaryLayoutItems);
            Action currentAction = () => propertyInfo.SetValue(_summaryLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (summaryLayoutItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_summaryLayoutItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryLayoutItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (summaryLayoutStyle) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_summaryLayoutStyle_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysummaryLayoutStyle);
            Action currentAction = () => propertyInfo.SetValue(_summaryLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SummaryLayout) => Property (summaryLayoutStyle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SummaryLayout_Public_Class_summaryLayoutStyle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryLayoutStyle);

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