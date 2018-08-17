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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LetterheadHeaderFooter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LetterheadHeaderFooterTest : AbstractBaseSetupTypedTest<LetterheadHeaderFooter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LetterheadHeaderFooter) Initializer

        private const string PropertybackgroundColor = "backgroundColor";
        private const string Propertyheight = "height";
        private const string PropertyhorizontalAlignment = "horizontalAlignment";
        private const string PropertyhorizontalAlignmentSpecified = "horizontalAlignmentSpecified";
        private const string Propertylogo = "logo";
        private const string PropertyverticalAlignment = "verticalAlignment";
        private const string PropertyverticalAlignmentSpecified = "verticalAlignmentSpecified";
        private const string FieldbackgroundColorField = "backgroundColorField";
        private const string FieldheightField = "heightField";
        private const string FieldhorizontalAlignmentField = "horizontalAlignmentField";
        private const string FieldhorizontalAlignmentFieldSpecified = "horizontalAlignmentFieldSpecified";
        private const string FieldlogoField = "logoField";
        private const string FieldverticalAlignmentField = "verticalAlignmentField";
        private const string FieldverticalAlignmentFieldSpecified = "verticalAlignmentFieldSpecified";
        private Type _letterheadHeaderFooterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LetterheadHeaderFooter _letterheadHeaderFooterInstance;
        private LetterheadHeaderFooter _letterheadHeaderFooterInstanceFixture;

        #region General Initializer : Class (LetterheadHeaderFooter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LetterheadHeaderFooter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _letterheadHeaderFooterInstanceType = typeof(LetterheadHeaderFooter);
            _letterheadHeaderFooterInstanceFixture = Create(true);
            _letterheadHeaderFooterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LetterheadHeaderFooter)

        #region General Initializer : Class (LetterheadHeaderFooter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LetterheadHeaderFooter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybackgroundColor)]
        [TestCase(Propertyheight)]
        [TestCase(PropertyhorizontalAlignment)]
        [TestCase(PropertyhorizontalAlignmentSpecified)]
        [TestCase(Propertylogo)]
        [TestCase(PropertyverticalAlignment)]
        [TestCase(PropertyverticalAlignmentSpecified)]
        public void AUT_LetterheadHeaderFooter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_letterheadHeaderFooterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LetterheadHeaderFooter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LetterheadHeaderFooter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbackgroundColorField)]
        [TestCase(FieldheightField)]
        [TestCase(FieldhorizontalAlignmentField)]
        [TestCase(FieldhorizontalAlignmentFieldSpecified)]
        [TestCase(FieldlogoField)]
        [TestCase(FieldverticalAlignmentField)]
        [TestCase(FieldverticalAlignmentFieldSpecified)]
        public void AUT_LetterheadHeaderFooter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_letterheadHeaderFooterInstanceFixture, 
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
        ///     Class (<see cref="LetterheadHeaderFooter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LetterheadHeaderFooter_Is_Instance_Present_Test()
        {
            // Assert
            _letterheadHeaderFooterInstanceType.ShouldNotBeNull();
            _letterheadHeaderFooterInstance.ShouldNotBeNull();
            _letterheadHeaderFooterInstanceFixture.ShouldNotBeNull();
            _letterheadHeaderFooterInstance.ShouldBeAssignableTo<LetterheadHeaderFooter>();
            _letterheadHeaderFooterInstanceFixture.ShouldBeAssignableTo<LetterheadHeaderFooter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LetterheadHeaderFooter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LetterheadHeaderFooter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LetterheadHeaderFooter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _letterheadHeaderFooterInstanceType.ShouldNotBeNull();
            _letterheadHeaderFooterInstance.ShouldNotBeNull();
            _letterheadHeaderFooterInstanceFixture.ShouldNotBeNull();
            _letterheadHeaderFooterInstance.ShouldBeAssignableTo<LetterheadHeaderFooter>();
            _letterheadHeaderFooterInstanceFixture.ShouldBeAssignableTo<LetterheadHeaderFooter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybackgroundColor)]
        [TestCaseGeneric(typeof(int) , Propertyheight)]
        [TestCaseGeneric(typeof(LetterheadHorizontalAlignment) , PropertyhorizontalAlignment)]
        [TestCaseGeneric(typeof(bool) , PropertyhorizontalAlignmentSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylogo)]
        [TestCaseGeneric(typeof(LetterheadVerticalAlignment) , PropertyverticalAlignment)]
        [TestCaseGeneric(typeof(bool) , PropertyverticalAlignmentSpecified)]
        public void AUT_LetterheadHeaderFooter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LetterheadHeaderFooter, T>(_letterheadHeaderFooterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (backgroundColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_Public_Class_backgroundColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (height) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_Public_Class_height_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (horizontalAlignment) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_horizontalAlignment_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyhorizontalAlignment);
            Action currentAction = () => propertyInfo.SetValue(_letterheadHeaderFooterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (horizontalAlignment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_Public_Class_horizontalAlignment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhorizontalAlignment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (horizontalAlignmentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_Public_Class_horizontalAlignmentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhorizontalAlignmentSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (logo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_Public_Class_logo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylogo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (verticalAlignment) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_verticalAlignment_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyverticalAlignment);
            Action currentAction = () => propertyInfo.SetValue(_letterheadHeaderFooterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (verticalAlignment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_Public_Class_verticalAlignment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyverticalAlignment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LetterheadHeaderFooter) => Property (verticalAlignmentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LetterheadHeaderFooter_Public_Class_verticalAlignmentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyverticalAlignmentSpecified);

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