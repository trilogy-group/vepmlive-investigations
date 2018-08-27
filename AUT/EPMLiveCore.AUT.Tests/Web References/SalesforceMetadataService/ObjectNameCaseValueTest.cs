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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ObjectNameCaseValue" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ObjectNameCaseValueTest : AbstractBaseSetupTypedTest<ObjectNameCaseValue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ObjectNameCaseValue) Initializer

        private const string Propertyarticle = "article";
        private const string PropertyarticleSpecified = "articleSpecified";
        private const string PropertycaseType = "caseType";
        private const string PropertycaseTypeSpecified = "caseTypeSpecified";
        private const string Propertyplural = "plural";
        private const string PropertypluralSpecified = "pluralSpecified";
        private const string Propertypossessive = "possessive";
        private const string PropertypossessiveSpecified = "possessiveSpecified";
        private const string Propertyvalue = "value";
        private const string FieldarticleField = "articleField";
        private const string FieldarticleFieldSpecified = "articleFieldSpecified";
        private const string FieldcaseTypeField = "caseTypeField";
        private const string FieldcaseTypeFieldSpecified = "caseTypeFieldSpecified";
        private const string FieldpluralField = "pluralField";
        private const string FieldpluralFieldSpecified = "pluralFieldSpecified";
        private const string FieldpossessiveField = "possessiveField";
        private const string FieldpossessiveFieldSpecified = "possessiveFieldSpecified";
        private const string FieldvalueField = "valueField";
        private Type _objectNameCaseValueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ObjectNameCaseValue _objectNameCaseValueInstance;
        private ObjectNameCaseValue _objectNameCaseValueInstanceFixture;

        #region General Initializer : Class (ObjectNameCaseValue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ObjectNameCaseValue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _objectNameCaseValueInstanceType = typeof(ObjectNameCaseValue);
            _objectNameCaseValueInstanceFixture = Create(true);
            _objectNameCaseValueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ObjectNameCaseValue)

        #region General Initializer : Class (ObjectNameCaseValue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ObjectNameCaseValue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyarticle)]
        [TestCase(PropertyarticleSpecified)]
        [TestCase(PropertycaseType)]
        [TestCase(PropertycaseTypeSpecified)]
        [TestCase(Propertyplural)]
        [TestCase(PropertypluralSpecified)]
        [TestCase(Propertypossessive)]
        [TestCase(PropertypossessiveSpecified)]
        [TestCase(Propertyvalue)]
        public void AUT_ObjectNameCaseValue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_objectNameCaseValueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ObjectNameCaseValue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ObjectNameCaseValue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldarticleField)]
        [TestCase(FieldarticleFieldSpecified)]
        [TestCase(FieldcaseTypeField)]
        [TestCase(FieldcaseTypeFieldSpecified)]
        [TestCase(FieldpluralField)]
        [TestCase(FieldpluralFieldSpecified)]
        [TestCase(FieldpossessiveField)]
        [TestCase(FieldpossessiveFieldSpecified)]
        [TestCase(FieldvalueField)]
        public void AUT_ObjectNameCaseValue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_objectNameCaseValueInstanceFixture, 
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
        ///     Class (<see cref="ObjectNameCaseValue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ObjectNameCaseValue_Is_Instance_Present_Test()
        {
            // Assert
            _objectNameCaseValueInstanceType.ShouldNotBeNull();
            _objectNameCaseValueInstance.ShouldNotBeNull();
            _objectNameCaseValueInstanceFixture.ShouldNotBeNull();
            _objectNameCaseValueInstance.ShouldBeAssignableTo<ObjectNameCaseValue>();
            _objectNameCaseValueInstanceFixture.ShouldBeAssignableTo<ObjectNameCaseValue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ObjectNameCaseValue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ObjectNameCaseValue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ObjectNameCaseValue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _objectNameCaseValueInstanceType.ShouldNotBeNull();
            _objectNameCaseValueInstance.ShouldNotBeNull();
            _objectNameCaseValueInstanceFixture.ShouldNotBeNull();
            _objectNameCaseValueInstance.ShouldBeAssignableTo<ObjectNameCaseValue>();
            _objectNameCaseValueInstanceFixture.ShouldBeAssignableTo<ObjectNameCaseValue>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ObjectNameCaseValue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Article) , Propertyarticle)]
        [TestCaseGeneric(typeof(bool) , PropertyarticleSpecified)]
        [TestCaseGeneric(typeof(CaseType) , PropertycaseType)]
        [TestCaseGeneric(typeof(bool) , PropertycaseTypeSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertyplural)]
        [TestCaseGeneric(typeof(bool) , PropertypluralSpecified)]
        [TestCaseGeneric(typeof(Possessive) , Propertypossessive)]
        [TestCaseGeneric(typeof(bool) , PropertypossessiveSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_ObjectNameCaseValue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ObjectNameCaseValue, T>(_objectNameCaseValueInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (article) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_article_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyarticle);
            Action currentAction = () => propertyInfo.SetValue(_objectNameCaseValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (article) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_article_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyarticle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (articleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_articleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyarticleSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (caseType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_caseType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycaseType);
            Action currentAction = () => propertyInfo.SetValue(_objectNameCaseValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (caseType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_caseType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (caseTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_caseTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (plural) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_plural_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyplural);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (pluralSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_pluralSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypluralSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (possessive) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_possessive_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertypossessive);
            Action currentAction = () => propertyInfo.SetValue(_objectNameCaseValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (possessive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_possessive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypossessive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (possessiveSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_possessiveSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypossessiveSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ObjectNameCaseValue) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ObjectNameCaseValue_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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