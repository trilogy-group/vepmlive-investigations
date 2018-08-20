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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Letterhead" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LetterheadTest : AbstractBaseSetupTypedTest<Letterhead>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Letterhead) Initializer

        private const string Propertyavailable = "available";
        private const string PropertybackgroundColor = "backgroundColor";
        private const string PropertybodyColor = "bodyColor";
        private const string PropertybottomLine = "bottomLine";
        private const string Propertydescription = "description";
        private const string Propertyfooter = "footer";
        private const string Propertyheader = "header";
        private const string PropertymiddleLine = "middleLine";
        private const string Propertyname = "name";
        private const string PropertytopLine = "topLine";
        private const string FieldavailableField = "availableField";
        private const string FieldbackgroundColorField = "backgroundColorField";
        private const string FieldbodyColorField = "bodyColorField";
        private const string FieldbottomLineField = "bottomLineField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldfooterField = "footerField";
        private const string FieldheaderField = "headerField";
        private const string FieldmiddleLineField = "middleLineField";
        private const string FieldnameField = "nameField";
        private const string FieldtopLineField = "topLineField";
        private Type _letterheadInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Letterhead _letterheadInstance;
        private Letterhead _letterheadInstanceFixture;

        #region General Initializer : Class (Letterhead) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Letterhead" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _letterheadInstanceType = typeof(Letterhead);
            _letterheadInstanceFixture = Create(true);
            _letterheadInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Letterhead)

        #region General Initializer : Class (Letterhead) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Letterhead" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyavailable)]
        [TestCase(PropertybackgroundColor)]
        [TestCase(PropertybodyColor)]
        [TestCase(PropertybottomLine)]
        [TestCase(Propertydescription)]
        [TestCase(Propertyfooter)]
        [TestCase(Propertyheader)]
        [TestCase(PropertymiddleLine)]
        [TestCase(Propertyname)]
        [TestCase(PropertytopLine)]
        public void AUT_Letterhead_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_letterheadInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Letterhead) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Letterhead" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldavailableField)]
        [TestCase(FieldbackgroundColorField)]
        [TestCase(FieldbodyColorField)]
        [TestCase(FieldbottomLineField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldfooterField)]
        [TestCase(FieldheaderField)]
        [TestCase(FieldmiddleLineField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldtopLineField)]
        public void AUT_Letterhead_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_letterheadInstanceFixture, 
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
        ///     Class (<see cref="Letterhead" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Letterhead_Is_Instance_Present_Test()
        {
            // Assert
            _letterheadInstanceType.ShouldNotBeNull();
            _letterheadInstance.ShouldNotBeNull();
            _letterheadInstanceFixture.ShouldNotBeNull();
            _letterheadInstance.ShouldBeAssignableTo<Letterhead>();
            _letterheadInstanceFixture.ShouldBeAssignableTo<Letterhead>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Letterhead) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Letterhead_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Letterhead instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _letterheadInstanceType.ShouldNotBeNull();
            _letterheadInstance.ShouldNotBeNull();
            _letterheadInstanceFixture.ShouldNotBeNull();
            _letterheadInstance.ShouldBeAssignableTo<Letterhead>();
            _letterheadInstanceFixture.ShouldBeAssignableTo<Letterhead>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Letterhead) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyavailable)]
        [TestCaseGeneric(typeof(string) , PropertybackgroundColor)]
        [TestCaseGeneric(typeof(string) , PropertybodyColor)]
        [TestCaseGeneric(typeof(LetterheadLine) , PropertybottomLine)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(LetterheadHeaderFooter) , Propertyfooter)]
        [TestCaseGeneric(typeof(LetterheadHeaderFooter) , Propertyheader)]
        [TestCaseGeneric(typeof(LetterheadLine) , PropertymiddleLine)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(LetterheadLine) , PropertytopLine)]
        public void AUT_Letterhead_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Letterhead, T>(_letterheadInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (available) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_available_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyavailable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (backgroundColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_backgroundColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Letterhead) => Property (bodyColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_bodyColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybodyColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (bottomLine) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_bottomLine_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybottomLine);
            Action currentAction = () => propertyInfo.SetValue(_letterheadInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (bottomLine) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_bottomLine_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybottomLine);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (footer) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_footer_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfooter);
            Action currentAction = () => propertyInfo.SetValue(_letterheadInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (footer) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_footer_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfooter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (header) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_header_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyheader);
            Action currentAction = () => propertyInfo.SetValue(_letterheadInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (header) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_header_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheader);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (middleLine) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_middleLine_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymiddleLine);
            Action currentAction = () => propertyInfo.SetValue(_letterheadInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (middleLine) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_middleLine_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymiddleLine);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (topLine) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_topLine_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytopLine);
            Action currentAction = () => propertyInfo.SetValue(_letterheadInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Letterhead) => Property (topLine) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Letterhead_Public_Class_topLine_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytopLine);

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